Imports Melanchall.DryWetMidi.Devices
Imports Melanchall.DryWetMidi.Common
Imports Melanchall.DryWetMidi.Interaction
Imports Melanchall.DryWetMidi.Core
Imports Melanchall.DryWetMidi.MusicTheory
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class Form1
    Dim noteDrag As Boolean = False
    Dim noteResize As Boolean = False
    Dim midiFileName As String = Application.StartupPath & "\Resources\01.mid"
    Dim WidthZoomMin As Double = 2
    Dim WidthZoomMax As Double = 20.0
    Dim MIDILengthMin As Integer = 1
    Dim MIDILengthMax As Integer = 600000
    Public totalLength As Integer = 0
    Private previousPanelIndex As Integer = -1
    Private stopwatch As New Stopwatch()
    Private lastElapsedMilliseconds As Long
    Public WidthZoom As Long = 3
    Dim beatsPerMeasure As Integer = 4
    Dim beatDivision As Integer = 4
    Private Const KeyWidth As Integer = 10 ' Width of each piano key in pixels
    Private Const RollHeight As Integer = 128 * KeyWidth ' Height of the piano roll in pixels
    Private RollWidth As Integer = (9244 / WidthZoom) + 742 ' Width of the piano roll in pixels
    Public MIDIWidth As Integer ' Total Duration of the MIDI File
    Private GridRollWidth As Integer
    Private Const PianoWidth As Integer = 60 ' Width of the piano roll in pixels
    Private keyStates(127) As Boolean
    Private keyOff(127) As Boolean
    Public LastNoteIndex As Long = 0
    Public LastNoteX As Long = 0
    Public LastNoteY As Long = 0
    Public LastNoteLength As Long = 10
    Public LastVelocity As Long = 127
    Private lastKeyInterval(127) As Long
    Private NotePlayed As String
    Public midiFile As MidiFile
    Private outputDevice As OutputDevice
    Private playbackSpeed As Double = 1.0
    Private MidiClockTime As Long = 0
    Private isPlaying As Boolean
    Private BPM As Integer = 120

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "MIDI Editor: " & Path.GetFileName(midiFileName)
        ' Set the timer interval to a reasonable value (e.g., 1 ms)
        MidiClock.Interval = 1
        ' Initialize the keyOff array, setting all elements to True
        For i As Integer = 0 To 127
            keyOff(i) = True
            lastKeyInterval(i) = -1
        Next
        Me.DoubleBuffered = True
        For Each portname_out In OutputDevice.GetAll
            Combo_output.Items.Add(portname_out)
        Next
        Combo_output.SelectedIndex = 0
        outputDevice = CType(Combo_output.SelectedItem, OutputDevice)
        outputDevice.SendEvent(New NoteOffEvent(CType(0, SevenBitNumber), CType(0, SevenBitNumber)))

        picRollTest.Parent = picRollGrid
        picRollTest.BackColor = Color.Transparent
        picRollOverlay.Parent = picRollTest
        picRollOverlay.BackColor = Color.Transparent
        picRollTest.Size = New Size(RollWidth, RollHeight)
        picRollOverlay.Size = New Size(RollWidth, RollHeight)
        picRollGrid.Size = New Size(RollWidth, RollHeight)
        picTimeLine.Size = New Size(RollWidth, 17)
        picPiano.Size = New Size(PianoWidth, RollHeight)
        picPianoHighlight.Size = New Size(PianoWidth, RollHeight)
        picPianoHighlight.BackColor = Color.Transparent
        picPianoHighlight.Parent = picPiano
        pn_pointer.Location = New Point(-1, 0)

        rb_Add.Checked = True

        ResizeScrollbars()

        ' Load MIDI file
        midiFile = MidiFile.Read(midiFileName)
        ' Get the events from the track
        Dim events = midiFile.GetTimedEvents()

        Dim tempoMap = midiFile.GetTempoMap()
        Dim originalBpm = tempoMap.GetTempoAtTime(New MidiTimeSpan(0)).BeatsPerMinute
        SetBPMValue(originalBpm.ToString)

        ' Get the total length of the track
        totalLength = events.LastOrDefault()?.Time

        ' Display the total length
        'MessageBox.Show($"Tempo: {averageBpm} " & $"Beat Division (Beats per Bar): {beatDivision}", "MIDI Track Length", MessageBoxButtons.OK, MessageBoxIcon.Information)
        RollWidth = (totalLength / WidthZoom) + Panel3.Width
        MIDIWidth = totalLength / WidthZoom

        ' Get the time signature events from the track
        Dim timeSignatureEvents = midiFile.GetTimedEvents().OfType(Of TimeSignatureEvent)()

        ' Check if there are time signature events and use the last one found
        If timeSignatureEvents.Any() Then
            Dim lastTimeSignatureEvent = timeSignatureEvents.Last()
            beatsPerMeasure = lastTimeSignatureEvent.Numerator
            beatDivision = lastTimeSignatureEvent.Denominator
        End If

        ' Attach event handlers
        AddHandler HScrollBar1.Scroll, AddressOf HScrollBar_Scroll
        AddHandler VScrollBar1.Scroll, AddressOf VScrollBar_Scroll

        ' Initialize the drawing of the piano roll
        DrawGrid()
        DrawPianoRoll()
        DrawPiano()
        SetupTimer()
    End Sub

    Private Sub ResizeScrollbars()
        Dim LastVScroll As Long
        Dim LastVScrollMax As Long
        LastVScroll = VScrollBar1.Value
        LastVScrollMax = VScrollBar1.Maximum
        txt_Test.Text = LastVScroll & " - " & LastVScrollMax
        ' Set up the horizontal scrollbar
        HScrollBar1.Minimum = 0
        HScrollBar1.Maximum = RollWidth
        HScrollBar1.SmallChange = 50 ' You can adjust this according to your needs
        HScrollBar1.LargeChange = 100 ' Adjust the LargeChange to make the handle longer

        ' Set up the vertical scrollbar if needed
        VScrollBar1.Minimum = 0
        VScrollBar1.Maximum = RollHeight + 100 - Panel3.Height
        VScrollBar1.SmallChange = 10 ' Adjust as needed
        VScrollBar1.LargeChange = 100 ' Adjust the LargeChange to make the handle longer

        If VScrollBar1.Value > (VScrollBar1.Maximum * 0.8) Then ' Checks the current VScroll if it's 80%, if yes then anchor's the bottom part of the panel
            VScrollBar1.Value = VScrollBar1.Maximum - 100
            ScrollVertically()
        End If
        picRollTest.Size = New Size(RollWidth, RollHeight)
        picRollGrid.Size = New Size(RollWidth, RollHeight)
        picTimeLine.Size = New Size(RollWidth, 17)
        picRollOverlay.Size = New Size(RollWidth, RollHeight)
    End Sub

    Private Sub HScrollBar_Scroll(sender As Object, e As ScrollEventArgs)
        ScrollHorizontally()
        If isPlaying = False Then
            MidiClockTime = (HScrollBar1.Value * WidthZoom)
        End If
    End Sub

    Private Sub ScrollHorizontally()
        ' Update the PictureBox position based on the scrollbar value
        picRollGrid.Location = New Point(-HScrollBar1.Value, picRollGrid.Location.Y)
        'picRollOverlay.Location = New Point(-picRollGrid.Location.X, picRollOverlay.Location.Y)
        picTimeLine.Location = New Point(-HScrollBar1.Value, picTimeLine.Location.Y)
    End Sub

    Private Sub VScrollBar_Scroll(sender As Object, e As ScrollEventArgs)
        ScrollVertically()
    End Sub

    Private Sub ScrollVertically()
        picRollGrid.Location = New Point(picRollGrid.Location.X, -VScrollBar1.Value)
        picPiano.Location = New Point(picPiano.Location.X, -VScrollBar1.Value)
    End Sub

    Private Sub DrawPiano()
        ' Create a bitmap to draw on
        Dim bmp As New Bitmap(RollWidth, RollHeight)
        Dim pictureBoxWidth As Integer = RollWidth
        Dim pictureBoxHeight As Integer = RollHeight
        Dim lineHeight As Integer = KeyWidth
        Dim whiteKeyColor As Color = ColorTranslator.FromHtml("#FFFFFF")
        Dim blackKeyColor As Color = ColorTranslator.FromHtml("#000000")
        Dim textColor As Color = Color.Black ' Adjust the text color as needed

        ' Get the graphics object of the bitmap
        Using g As Graphics = Graphics.FromImage(bmp)
            Using whiteKeyBrush As New SolidBrush(whiteKeyColor), blackKeyBrush As New SolidBrush(blackKeyColor), textBrush As New SolidBrush(textColor)
                Dim previousColor As Color = whiteKeyColor

                For y As Integer = 0 To pictureBoxHeight Step lineHeight
                    Dim currentBrush As Brush
                    ' Determine if the key is white or black based on the position
                    Dim positionInOctave As Integer = (y \ lineHeight) Mod 12
                    If positionInOctave = 12 OrElse positionInOctave = 1 OrElse positionInOctave = 4 OrElse positionInOctave = 6 OrElse positionInOctave = 9 OrElse positionInOctave = 11 Then
                        currentBrush = blackKeyBrush
                    Else
                        currentBrush = whiteKeyBrush
                    End If

                    Dim lineRect As New Rectangle(0, y, pictureBoxWidth, lineHeight)
                    g.FillRectangle(currentBrush, lineRect)

                    ' Add text labels for C keys
                    If positionInOctave = 7 Then
                        Dim font As New Font("Arial", 8) ' Adjust the font as needed
                        Dim text As String = "C" & (((pictureBoxHeight - y) \ lineHeight - 13) \ 12).ToString() ' Adjust the starting label as needed
                        Dim textSize As SizeF = g.MeasureString(text, font)
                        Dim textX As Integer = picPiano.Width - CInt(textSize.Width - 1) ' Adjust the text position as needed
                        Dim textY As Integer = y + (lineHeight - CInt(textSize.Height)) \ 2 - 1
                        g.DrawString(text, font, textBrush, textX, textY)
                    End If
                Next
            End Using
        End Using

        picPiano.Image?.Dispose() ' Dispose of the previous image, if any

        ' Set the PictureBox image
        picPiano.Image = bmp

    End Sub

    Private Sub DrawPianoRoll()
        ' Create a bitmap to draw on
        Dim bmp As New Bitmap(RollWidth, RollHeight)
        Dim whiteKeyColor As Color = ColorTranslator.FromHtml("#34444e")
        Dim blackKeyColor As Color = ColorTranslator.FromHtml("#2e3e48")
        Dim gridColor0 As Color = ColorTranslator.FromHtml("#2a3a44")
        Dim gridColor1 As Color = ColorTranslator.FromHtml("#22323c")
        Dim gridColor2 As Color = ColorTranslator.FromHtml("#10202a")
        'Dim midiFile As MidiFile = MidiFile.Read(midiFileName)
        ' Get the graphics object of the bitmap
        Using g As Graphics = Graphics.FromImage(bmp)
            ' Get notes from the MIDI file
            Dim notes = midiFile.GetNotes()

            ' Set up drawing settings
            Dim noteHeight As Integer = KeyWidth

            ' Iterate through notes and draw rectangles
            For Each note In notes
                Dim x As Integer = CInt(note.Time / WidthZoom)
                Dim y As Integer = CInt((127 - note.NoteNumber.ToString) * noteHeight)
                Dim width As Integer = CInt(note.Length / WidthZoom)
                Dim outlineWidth As Integer = 1 ' Adjust the outline width as needed

                If NotePlayed = note.NoteNumber.ToString & note.Time.ToString Then
                    ' Create a LinearGradientBrush for a gradient fill
                    Using gradientBrush As New Drawing2D.LinearGradientBrush(New Point(x, y), New Point(x + width, y + noteHeight), ColorTranslator.FromHtml("#FAA0A0"), ColorTranslator.FromHtml("#E30B5C"))
                        ' Draw a filled rectangle with the gradient fill
                        g.FillRectangle(gradientBrush, x, y, width, noteHeight)
                    End Using

                    ' Draw an outlined rectangle around the note
                    Using outlinePen As New Pen(ColorTranslator.FromHtml("#F88379"), outlineWidth + 1)
                        g.DrawRectangle(outlinePen, x - outlineWidth \ 2, y - outlineWidth \ 2, width + outlineWidth, noteHeight + outlineWidth)
                    End Using
                Else
                    ' Create a LinearGradientBrush for a gradient fill
                    Using gradientBrush As New Drawing2D.LinearGradientBrush(New Point(x, y), New Point(x + width, y + noteHeight), ColorTranslator.FromHtml("#FCF55F"), ColorTranslator.FromHtml("#FFC000"))
                        ' Draw a filled rectangle with the gradient fill
                        g.FillRectangle(gradientBrush, x, y, width, noteHeight)
                    End Using

                    ' Draw an outlined rectangle around the note
                    Using outlinePen As New Pen(ColorTranslator.FromHtml("#343434"), outlineWidth)
                        g.DrawRectangle(outlinePen, x - outlineWidth \ 2, y - outlineWidth \ 2, width + outlineWidth, noteHeight + outlineWidth)
                    End Using
                End If

            Next
        End Using

        picRollTest.Image?.Dispose() ' Dispose of the previous image, if any

        ' Set the PictureBox image
        picRollTest.Image = bmp
    End Sub

    Private Sub DrawGrid()
        Dim vScrollBarValue As Long
        vScrollBarValue = VScrollBar1.Value
        VScrollBar1.Value = 0
        Dim midiFile As MidiFile = MidiFile.Read(midiFileName)
        Dim tempoMap = midiFile.GetTempoMap()
        Dim originalBpm = tempoMap.GetTempoAtTime(New MidiTimeSpan(0)).BeatsPerMinute
        ' Musical time signature
        Dim beatsPerBar As Integer = beatDivision
        ' Calculate the width of each beat and bar
        Dim beatWidth As Single = MIDIWidth / beatsPerMeasure
        Dim barWidth As Single = beatWidth / beatsPerBar

        ' Create a bitmap to draw on
        GridRollWidth = MIDIWidth + beatWidth + 1
        Dim bmpgrid As New Bitmap(GridRollWidth, RollHeight)
        Dim pictureBoxWidth As Integer = GridRollWidth
        Dim pictureBoxHeight As Integer = RollHeight
        Dim lineHeight As Integer = KeyWidth
        Dim whiteKeyColor As Color = ColorTranslator.FromHtml("#34444e")
        Dim blackKeyColor As Color = ColorTranslator.FromHtml("#2e3e48")
        Dim gridColor0 As Color = ColorTranslator.FromHtml("#2a3a44")
        Dim gridColor1 As Color = ColorTranslator.FromHtml("#22323c")
        Dim gridColor2 As Color = ColorTranslator.FromHtml("#10202a")
        ' Dispose of the previous image, if any
        picTimeLine.Image?.Dispose()

        ' Create a new Bitmap with the same size as the PictureBox
        picTimeLine.Image = New Bitmap(GridRollWidth, picTimeLine.Height)
        ' Get the graphics object of the bitmap
        Using g As Graphics = Graphics.FromImage(bmpgrid)
            Using whiteKeyBrush As New SolidBrush(whiteKeyColor), blackKeyBrush As New SolidBrush(blackKeyColor)
                Dim previousColor As Color = whiteKeyColor

                For y As Integer = 0 To pictureBoxHeight Step lineHeight
                    Dim currentBrush As Brush
                    Dim scrollOffset As Integer = VScrollBar1.Value
                    ' Determine if the key is white or black based on the position
                    Dim positionInOctave As Integer = ((y + scrollOffset) \ lineHeight) Mod 12
                    If positionInOctave = 12 OrElse positionInOctave = 1 OrElse positionInOctave = 4 OrElse positionInOctave = 6 OrElse positionInOctave = 9 OrElse positionInOctave = 11 Then
                        currentBrush = blackKeyBrush
                    Else
                        currentBrush = whiteKeyBrush
                    End If

                    Dim lineRect As New Rectangle(0, y, pictureBoxWidth, lineHeight)
                    g.FillRectangle(currentBrush, lineRect)

                    ' Draw a 1-pixel black line when the color changes
                    If (y \ lineHeight) Mod 1 <> 1 Then
                        Dim customPen As New Pen(gridColor1)
                        g.DrawLine(customPen, 0, y, pictureBoxWidth, y)
                    End If
                Next

                ' Draw 1-pixel vertical lines for each bar
                Using barPen As New Pen(gridColor1, 1)
                    For barIndex As Integer = 1 To (beatsPerMeasure * beatsPerBar) + beatsPerMeasure
                        Dim xPosition As Single = (barIndex - 1) * barWidth
                        g.DrawLine(barPen, xPosition, 0, xPosition, picRollGrid.Height)
                        ' Draw additional lines between each bar
                        If barIndex < (beatsPerMeasure * beatsPerBar) + (beatsPerBar * 3) Then
                            Dim spaceWidth As Single = barWidth / 8 ' Adjust as needed
                            For i As Integer = 1 To 7
                                Dim customPen As New Pen(gridColor0)
                                Dim additionalX As Single = xPosition + i * spaceWidth
                                g.DrawLine(customPen, additionalX, 0, additionalX, picRollGrid.Height)
                            Next
                        End If
                    Next
                End Using

                ' Draw 3-pixel vertical lines for each beat
                Using beatPen As New Pen(gridColor2, 1)
                    For beatIndex As Integer = 1 To beatsPerMeasure + 4
                        Dim xPosition As Single = (beatIndex - 1) * beatWidth
                        g.DrawLine(beatPen, xPosition, 0, xPosition, picRollGrid.Height)
                    Next
                End Using

            End Using
        End Using

        picRollGrid.Image?.Dispose() ' Dispose of the previous image, if any

        ' Set the PictureBox image
        picRollGrid.Image = bmpgrid
        VScrollBar1.Value = vScrollBarValue

        ' Create a Graphics object from the Bitmap
        Using g As Graphics = Graphics.FromImage(picTimeLine.Image)
            ' Draw 1-pixel horizontal line on the top
            g.DrawLine(New Pen(ColorTranslator.FromHtml("#364249"), 1), 0, 0, picTimeLine.Width - 1, 0)

            ' Draw 1-pixel horizontal line on the bottom
            g.DrawLine(New Pen(ColorTranslator.FromHtml("#2d3940"), 1), 0, picTimeLine.Height - 1, GridRollWidth - 1, picTimeLine.Height - 1)

            ' Fill the middle with black color
            Dim middleRect As New Rectangle(0, 1, GridRollWidth, picTimeLine.Height - 2)
            g.FillRectangle(New SolidBrush(ColorTranslator.FromHtml("#1f2a31")), middleRect)

            ' Draw text in the middle
            Dim text As String = "Your Text Here"
            Dim font As New Font("Arial", 8) ' Adjust the font as needed
            Dim brush As New SolidBrush(Color.LightGray) ' Adjust the text color as needed
            Dim textY As Single = (picTimeLine.Height - g.MeasureString(text, font).Height) / 2

            For beatIndex As Integer = 1 To beatsPerMeasure + 4
                Dim xPosition As Single = ((beatIndex - 1) * beatWidth)
                g.DrawString(beatIndex.ToString, font, brush, xPosition, textY)
            Next
        End Using

    End Sub


    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ResizeScrollbars()
    End Sub

    Private Sub RenderPianoSoundWithNote(n As Long, v As Long)
        ' Determine which key was clicked based on the mouse coordinates
        Dim totalKeys As Integer = 128
        Dim noteIndex As Integer = n
        Dim yIndex As Integer = (picPianoHighlight.Height - ((n + 1) * KeyWidth))
        ' Update the state of the clicked key
        keyStates(noteIndex) = True
        ' Change the color of the clicked key to yellow
        Dim keyColor As Color = ColorTranslator.FromHtml("#FCF55F")
        Dim keyRect As New Rectangle(0, yIndex, picPianoHighlight.Width, KeyWidth)
        'g.FillRectangle(New SolidBrush(keyColor), keyRect)

        ' Ensure the clickedKeyIndex is within the valid range
        noteIndex = Math.Max(0, Math.Min(noteIndex, totalKeys - 1))

        ' Do something with the clicked key index
        Dim channel = Combo_output.SelectedIndex ' Use the selected index from Combo_output as the channel
        outputDevice.SendEvent(New NoteOnEvent(CType(noteIndex, SevenBitNumber), CType(v, SevenBitNumber)))
        RedrawPianoKeys()
    End Sub


    Private Sub RedrawPianoKeys()
        picPianoHighlight.Image?.Dispose() ' Dispose of the previous image, if any
        ' Calculate the visible range based on the scroll bar's value
        Dim visibleStartIndex As Integer = VScrollBar1.Value + picPianoHighlight.Location.Y
        ' Create a new Bitmap with the same size as the PictureBox
        picPianoHighlight.Image = New Bitmap(picPianoHighlight.Width, picPianoHighlight.Height)
        ' Create a Graphics object from the Bitmap
        Using g As Graphics = Graphics.FromImage(picPianoHighlight.Image)
            ' Fill the entire Bitmap with a transparent color (e.g., Color.Transparent)
            'g.FillRectangle(Brushes.Transparent, 0, visibleStartIndex, picPianoHighlight.Width, Panel4.Height)
            Dim keyHeight As Integer = KeyWidth
            For i As Integer = 0 To keyStates.Length - 1
                If keyStates((keyStates.Length - 1) - i) Then
                    Dim keyColor As Color = ColorTranslator.FromHtml("#FCF55F")
                    Dim keyRect As New Rectangle(0, i * keyHeight, picPianoHighlight.Width, keyHeight)
                    g.FillRectangle(New SolidBrush(keyColor), keyRect)
                End If
            Next
        End Using
    End Sub

    Public Sub AddNote(noteindex As Integer, notevel As Integer, notetime As Integer, noteLength As Integer)
        ' Specify the properties of the new note
        Dim newNoteNumber As SevenBitNumber = noteindex ' Adjust the note number as needed
        Dim newNoteVelocity As SevenBitNumber = notevel ' Adjust the velocity as needed
        Dim newNoteTime As Integer
        newNoteTime = notetime - (noteLength / 2)
        ' Create NoteOnEvent for the new note
        Dim noteOnEvent As New NoteOnEvent(newNoteNumber, newNoteVelocity)
        noteOnEvent.Channel = Combo_output.SelectedIndex
        If newNoteTime < 0 Then
            noteOnEvent.DeltaTime = 0
        Else
            noteOnEvent.DeltaTime = newNoteTime
        End If
        ' Create NoteOffEvent for the new note (e.g., after 1000 ticks)
        Dim noteOffEvent As New NoteOffEvent(newNoteNumber, newNoteVelocity)
        noteOffEvent.Channel = noteOnEvent.Channel ' Match the channel
        noteOffEvent.DeltaTime = noteLength ' Adjust the delta time as needed

        ' Create a new track and add the NoteOnEvent and NoteOffEvent to it
        Dim newTrack As New TrackChunk()
        newTrack.Events.Add(noteOnEvent)
        newTrack.Events.Add(noteOffEvent)

        ' Insert the new track at the beginning of the MIDI file
        midiFile.Chunks.Insert(1, newTrack) ' Assumes track index 0 is the tempo map track
    End Sub

    Private Sub TurnOffNote(n As Long)
        outputDevice.SendEvent(New NoteOffEvent(CType(n, SevenBitNumber), CType(0, SevenBitNumber)))
        keyStates(n) = False
    End Sub

    Private Sub Btn_play_Click(sender As Object, e As EventArgs) Handles btn_play.Click
        If isPlaying Then
            PausePlaying()
        Else
            PlayMIDI()
        End If
    End Sub

    Private Sub PausePlaying()
        HScrollBar1.Enabled = True
        stopwatch.Stop()
        stopwatch.Reset()
        MidiClock.Stop()
        pn_pointer.Location = New Point(-1, 0)
        'MidiClockTime = 0
        btn_play.Text = "PLAY"
        isPlaying = False
        txt_Test.Text = "Ticks: " & MidiClockTime
        'HScrollBar1.Value = 0
        'ScrollHorizontally()
        lastElapsedMilliseconds = 0
        For i As Integer = 0 To keyStates.Length - 1
            keyStates(i) = False
            TurnOffNote(i)
            lastKeyInterval(i) = -1
        Next
        RedrawPianoKeys()
    End Sub

    Private Sub PlayMIDI()
        HScrollBar1.Enabled = False
        stopwatch.Start()
        MidiClock.Start()
        btn_play.Text = "PAUSE"
        isPlaying = True
    End Sub

    Private Sub MidiClock_Tick(sender As Object, e As EventArgs) Handles MidiClock.Tick
        ' Measure the elapsed time since the last tick
        Dim elapsedMilliseconds = stopwatch.ElapsedMilliseconds
        Dim elapsedSinceLastTick = elapsedMilliseconds - lastElapsedMilliseconds

        ' Update your logic based on the elapsed time
        UpdateLogic(elapsedSinceLastTick)

        ' Save the current elapsed time for the next tick
        lastElapsedMilliseconds = elapsedMilliseconds
    End Sub

    Private Sub SetupTimer()
        ' Assuming you want a tempo of 120 BPM
        Dim tempoBPM As Integer = CInt(txt_BPM.Text)
        Dim ticksPerQuarterNote As Integer = 480
        Dim tickInterval As Integer = CInt((60 * 1000) / (tempoBPM * ticksPerQuarterNote))

        ' Set up your timer with the calculated tick interval
        MidiClock.Interval = tickInterval
    End Sub

    Private Sub UpdateLogic(elapsedMilliseconds As Long)
        ' Adjust the increment value based on your desired time resolution
        Dim timeIncrement As Integer
        If txt_BPM.Text <> "" Then
            If CInt(txt_BPM.Text) < 40 Then
                timeIncrement = (elapsedMilliseconds * (40 / 240))
            ElseIf CInt(txt_BPM.Text) > 999.999 Then
                timeIncrement = (elapsedMilliseconds * (999.999 / 240))
            Else
                timeIncrement = (elapsedMilliseconds * (txt_BPM.Text / 240))
            End If
        Else
            timeIncrement = (elapsedMilliseconds * (40 / 240))
        End If
        Dim eventDetect As Boolean = False
        Dim MIDITicks As Integer
        If MidiClockTime >= (MIDIWidth * WidthZoom) Then
            stopwatch.Stop()
            stopwatch.Reset()
            MidiClock.Stop()
            MidiClockTime = -timeIncrement
            HScrollBar1.Value = 0
            ScrollHorizontally()
            pn_pointer.Location = New Point(0, 0)
            lastElapsedMilliseconds = 0
            For i As Integer = 0 To keyStates.Length - 1
                keyStates(i) = False
                TurnOffNote(i)
                lastKeyInterval(i) = -1
            Next
            stopwatch.Start()
            MidiClock.Start()
        Else
            If timeIncrement > 0 Then
                MidiClockTime = MidiClockTime + (timeIncrement * playbackSpeed)
                MIDITicks = MidiClockTime / WidthZoom
            End If
            If (MIDITicks) < HScrollBar1.Maximum And MIDITicks > 0 Then
                Dim panelWidth As Integer = Panel3.Width
                Dim offset As Integer = HScrollBar1.Value
                ' Calculate the current panel index
                Dim currentPanelIndex As Integer = (MIDITicks - offset) \ panelWidth
                ' Check if the panel index has changed
                If currentPanelIndex <> previousPanelIndex Then
                    ' Update the previous panel index
                    previousPanelIndex = currentPanelIndex
                    HScrollBar1.Value = MIDITicks
                    ScrollHorizontally()
                End If
                ' Move the pointer
                pn_pointer.Left = (MIDITicks - offset) Mod panelWidth
                'pn_pointer.Location = New Point(MIDITicks, 0)
            End If
        End If
        txt_Test.Text = "Ticks: " & MidiClockTime & " / " & (MIDIWidth * WidthZoom)
        ' Define a range of time values to process
        Dim currentTimeStart As Integer = MidiClockTime - timeIncrement
        Dim currentTimeEnd As Integer = MidiClockTime

        ' Render piano sound for each note within the time range
        Using g As Graphics = picPiano.CreateGraphics()
            For Each note In midiFile.GetNotes().Where(Function(n) n.Time <= currentTimeEnd AndAlso n.Time + n.Length >= currentTimeStart)
                ' Render piano sound for each note
                If lastKeyInterval(note.NoteNumber) = note.Time Then
                Else
                    TurnOffNote(note.NoteNumber)
                    If keyStates(note.NoteNumber) = False Then
                        RenderPianoSoundWithNote(note.NoteNumber, note.Velocity)
                    End If
                    lastKeyInterval(note.NoteNumber) = note.Time
                End If

                keyOff(note.NoteNumber) = False
                lastKeyInterval(note.NoteNumber) = note.Time
            Next
        End Using
        For i As Integer = 0 To 127
            If keyStates(i) = keyOff(i) Then
                TurnOffNote(i)
                eventDetect = True
            End If
            keyOff(i) = True
        Next
        If eventDetect = True Then
            RedrawPianoKeys()
            eventDetect = False
        End If
    End Sub

    Private Sub picPianoHighlight_MouseDown(sender As Object, e As MouseEventArgs) Handles picPianoHighlight.MouseDown
        If isPlaying = False Then
            Using g As Graphics = picPianoHighlight.CreateGraphics()
                RenderPianoSoundWithNote((picPianoHighlight.Height - e.Y) \ KeyWidth, e.X * 2.1)
            End Using
        End If
    End Sub

    Private Sub picPianoHighlight_MouseUp(sender As Object, e As MouseEventArgs) Handles picPianoHighlight.MouseUp
        If isPlaying = False Then
            ' Clear the state of all keys when mouse is released
            Dim channel = Combo_output.SelectedIndex ' Use the selected index from Combo_output as the channel
            Dim velocity As Integer
            velocity = 127
            ' Loop through each key in keyStates
            For i As Integer = 0 To keyStates.Length - 1
                If keyStates(i) Then
                    ' Send NoteOffEvent for the currently pressed key
                    outputDevice.SendEvent(New NoteOffEvent(CType(i, SevenBitNumber), CType(velocity, SevenBitNumber)))

                    ' Clear the state of the released key
                    keyStates(i) = False
                End If
            Next
            ' Redraw the piano keys (you might want to optimize this)
            RedrawPianoKeys()
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        StopPlaying()
        Dim openFileDialog As New OpenFileDialog()

        ' Set the file dialog properties
        openFileDialog.Title = "Select a MIDI File"
        openFileDialog.Filter = "MIDI Files|*.mid;*.midi|All Files|*.*"
        openFileDialog.InitialDirectory = Application.StartupPath & "\Resources\"
        openFileDialog.RestoreDirectory = True


        ' Show the file dialog
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Update the midiFileName variable with the selected file path
            midiFileName = openFileDialog.FileName
            ' Load MIDI file
            midiFile = MidiFile.Read(midiFileName)
            ' Set the title of the form using the file name of the MIDI file
            Me.Text = "Piano Test: " & Path.GetFileName(midiFileName)
            ' Get the events from the track
            Dim events = midiFile.GetTimedEvents()

            Dim tempoMap = midiFile.GetTempoMap()
            Dim originalBpm = tempoMap.GetTempoAtTime(New MidiTimeSpan(0)).BeatsPerMinute
            SetBPMValue(originalBpm.ToString)

            ' Get the total length of the track
            totalLength = events.LastOrDefault()?.Time
            If totalLength > 0 Then
                WidthZoom = WidthZoomMin + ((totalLength - MIDILengthMin) * (WidthZoomMax - WidthZoomMin)) / (MIDILengthMax - MIDILengthMin)
            Else
                WidthZoom = 3 ' Default Zoom
            End If

            ' Display the total length
            'MessageBox.Show($"Tempo: {averageBpm} " & $"Beat Division (Beats per Bar): {beatDivision}", "MIDI Track Length", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RollWidth = (totalLength / WidthZoom) + Panel3.Width
            MIDIWidth = totalLength / WidthZoom
            picRollTest.Size = New Size(RollWidth, RollHeight)
            picRollOverlay.Size = New Size(RollWidth, RollHeight)
            picRollGrid.Size = New Size(RollWidth, RollHeight)
            picTimeLine.Size = New Size(RollWidth, 17)
            picPiano.Size = New Size(PianoWidth, RollHeight)
            picPianoHighlight.Size = New Size(PianoWidth, RollHeight)
            ResizeScrollbars()
            ' Initialize the drawing of the piano roll
            DrawGrid()
            DrawPianoRoll()
            SetupTimer()
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        ' Use SaveFileDialog to get the export path
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "MIDI files (*.mid)|*.mid"
        saveFileDialog.Title = "Export MIDI File"
        saveFileDialog.InitialDirectory = Application.StartupPath & "\Resources\"
        saveFileDialog.FileName = "Untitled.mid"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            ' Check if the file already exists
            If File.Exists(saveFileDialog.FileName) Then
                ' If it exists, delete it
                File.Delete(saveFileDialog.FileName)
            End If
            ' Save the modified MIDI file to the selected path
            midiFile.Write(saveFileDialog.FileName)
            Me.Text = "Piano Test: " & Path.GetFileName(saveFileDialog.FileName)
        End If
    End Sub

    Private Sub picRollOverlay_MouseMove(sender As Object, e As MouseEventArgs) Handles picRollOverlay.MouseMove
        If isPlaying = False And rb_Add.Checked = True Then
            If Not (e.Button = MouseButtons.Left) And Not (e.Button = MouseButtons.Right) Then
                ' Get notes from the MIDI file
                Dim notes = midiFile.GetNotes()

                ' Set up drawing settings
                Dim noteHeight As Integer = KeyWidth
                Dim edgeTolerance As Integer = 5 ' Adjust the tolerance for considering the edge

                ' Iterate through notes and check if the mouse is over the start or end of any note
                For Each note In notes
                    Dim x As Integer = CInt(note.Time / WidthZoom)
                    Dim y As Integer = CInt((127 - note.NoteNumber.ToString) * noteHeight)
                    Dim width As Integer = CInt(note.Length / WidthZoom)

                    ' Check if the mouse is over the end of the note
                    If (e.X >= x + width - edgeTolerance AndAlso e.X <= x + width AndAlso
                e.Y >= y AndAlso e.Y <= y + noteHeight) Then

                        ' Change the cursor when over the start or end of a note
                        picRollTest.Cursor = Cursors.SizeWE ' Change to a horizontal resizing cursor
                        noteResize = True
                        LastNoteX = x
                        LastNoteY = e.Y
                        LastNoteIndex = note.NoteNumber
                        LastVelocity = note.Velocity
                        txt_Test.Text = "Resize Note"
                        Return
                    End If

                    ' Check if the mouse is over the rest of the note (excluding the end)
                    If (e.X >= x AndAlso e.X <= x + width AndAlso
                        e.Y >= y AndAlso e.Y <= y + noteHeight) Then

                        ' Change the cursor to a move cursor when over the rest of the note
                        picRollTest.Cursor = Cursors.SizeAll
                        If Not (e.Button = MouseButtons.Left) Then
                            noteResize = False
                            txt_Test.Text = "Move Note"
                        End If
                        Return
                    End If
                Next

                ' Reset the cursor when not over the start or end of any note
                picRollTest.Cursor = Cursors.Default
                noteResize = False
                txt_Test.Text = "Draw Note"
            End If
            If e.Button = MouseButtons.Right Then
                Dim channel = Combo_output.SelectedIndex ' Use the selected index from Combo_output as the channel
                Dim mouseX As Integer = e.X
                Dim mouseY As Integer = e.Y
                ' Iterate through notes and check if the mouse click is within a note rectangle
                For Each note In midiFile.GetNotes()
                    Dim noteX As Integer = CInt(note.Time / WidthZoom)
                    Dim noteY As Integer = CInt((127 - note.NoteNumber.ToString) * KeyWidth)
                    Dim noteWidth As Integer = CInt(note.Length / WidthZoom)
                    Dim noteHeight As Integer = KeyWidth

                    If mouseX >= noteX AndAlso mouseX <= noteX + noteWidth AndAlso
                   mouseY >= noteY AndAlso mouseY <= noteY + noteHeight Then
                        ' Define a predicate to match notes you want to remove
                        Dim predicate As Predicate(Of Melanchall.DryWetMidi.Interaction.Note) = Function(n) CInt(n.NoteNumber) = note.NoteNumber.ToString AndAlso n.Time = note.Time.ToString ' Modify these conditions as needed
                        midiFile.RemoveNotes(predicate)
                        DrawPianoRoll()
                        txt_Test.Text = "Note Removal"
                        Exit For ' Exit the loop once a note has been removed
                    End If
                Next
            End If
        End If
        DrawRollOverlay(e.X, e.Y, True)
    End Sub

    Private Sub DrawRollOverlay(x As Long, y As Long, play As Boolean)
        If noteDrag = True And isPlaying = False Then
            Dim noteHover As Integer
            noteHover = (picPiano.Height - y) \ KeyWidth
            If noteHover < 0 Then
                noteHover = 0
            ElseIf noteHover > 127 Then
                noteHover = 127
            End If
            If keyStates(noteHover) = False And Not noteResize Then
                For i As Integer = 0 To 127
                    If keyStates(i) = True Then
                        TurnOffNote(i)
                    End If
                Next
                If play Then
                    RenderPianoSoundWithNote(noteHover, LastVelocity)
                End If
            End If
            If noteResize Then
                picRollOverlay.Image?.Dispose() ' Dispose of the previous image, if any
                ' Create a new Bitmap with the same size as the PictureBox
                picRollOverlay.Image = New Bitmap(picRollOverlay.Width, picRollOverlay.Height)
                ' Calculate the key index based on the mouse Y position
                Dim keyIndex As Integer = CInt(Math.Ceiling((LastNoteY - KeyWidth) / KeyWidth))
                ' Calculate the top and height of the rectangle
                Dim top As Integer = keyIndex * KeyWidth
                Dim height As Integer = KeyWidth
                ' Calculate the width of the note rectangle (stretch only to the right)
                Dim noteWidth As Integer = Math.Max(0, x - LastNoteX)
                Dim noteX As Integer = LastNoteX ' Note starts from the initial mouse click position
                If noteWidth < 1 Then
                    noteWidth = 1
                End If
                txt_Test.Text = "Note Width:" & noteWidth
                LastNoteLength = noteWidth
                Using g As Graphics = Graphics.FromImage(picRollOverlay.Image)
                    Dim noteRect As New Rectangle(noteX, top, noteWidth, height)
                    ' Calculate two points for gradient direction
                    Dim startPoint As New Point(noteRect.Left, noteRect.Top)
                    Dim endPoint As New Point(noteRect.Right, noteRect.Top)
                    ' Create a LinearGradientBrush for gradient fill
                    Using gradientBrush As New LinearGradientBrush(startPoint, endPoint, ColorTranslator.FromHtml("#FCF55F"), ColorTranslator.FromHtml("#FFC000"))
                        ' Create a Pen for the outline
                        Using outlinePen As New Pen(ColorTranslator.FromHtml("#343434"), 1)
                            ' Draw the gradient-filled rectangle
                            g.FillRectangle(gradientBrush, noteRect)
                            ' Draw the outline
                            g.DrawRectangle(outlinePen, noteRect)
                        End Using
                    End Using
                End Using
                'txt_Test.Text = mouseX
            Else
                picRollOverlay.Image?.Dispose() ' Dispose of the previous image, if any
                ' Create a new Bitmap with the same size as the PictureBox
                picRollOverlay.Image = New Bitmap(picRollOverlay.Width, picRollOverlay.Height)
                ' Calculate the key index based on the mouse Y position
                Dim keyIndex As Integer = CInt(Math.Ceiling((y - KeyWidth) / KeyWidth))
                ' Calculate the top and height of the rectangle
                Dim top As Integer = keyIndex * KeyWidth
                Dim height As Integer = KeyWidth
                ' Fixed width for the note rectangle
                Dim noteWidth As Integer = LastNoteLength
                ' Calculate the X position based on the mouse X position
                Dim mouseX As Integer = x
                Dim noteX As Integer = Math.Max(0, mouseX - noteWidth / 2) ' Ensure the note is within the bounds
                Using g As Graphics = Graphics.FromImage(picRollOverlay.Image)
                    Dim noteRect As New Rectangle(noteX, top, noteWidth, height)
                    ' Calculate two points for gradient direction
                    Dim startPoint As New Point(noteRect.Left, noteRect.Top)
                    Dim endPoint As New Point(noteRect.Right, noteRect.Top)
                    ' Create a LinearGradientBrush for gradient fill
                    Using gradientBrush As New LinearGradientBrush(startPoint, endPoint, ColorTranslator.FromHtml("#FCF55F"), ColorTranslator.FromHtml("#FFC000"))
                        ' Create a Pen for the outline
                        Using outlinePen As New Pen(ColorTranslator.FromHtml("#343434"), 1)
                            ' Draw the gradient-filled rectangle
                            g.FillRectangle(gradientBrush, noteRect)
                            ' Draw the outline
                            g.DrawRectangle(outlinePen, noteRect)
                        End Using
                    End Using
                End Using
                LastNoteIndex = noteHover
                LastNoteX = mouseX
                LastNoteLength = noteWidth
            End If

        End If
    End Sub

    Private Sub picRollOverlay_MouseDown(sender As Object, e As MouseEventArgs) Handles picRollOverlay.MouseDown
        If isPlaying = False Then
            Dim channel = Combo_output.SelectedIndex ' Use the selected index from Combo_output as the channel
            ' Get the mouse coordinates
            Dim mouseX As Integer = e.X
            Dim mouseY As Integer = e.Y
            Using g As Graphics = picPianoHighlight.CreateGraphics()
                ' Iterate through notes and check if the mouse click is within a note rectangle
                For Each note In midiFile.GetNotes()
                    Dim noteX As Integer = CInt(note.Time / WidthZoom)
                    Dim noteY As Integer = CInt((127 - note.NoteNumber.ToString) * KeyWidth)
                    Dim noteWidth As Integer = CInt(note.Length / WidthZoom)
                    Dim noteHeight As Integer = KeyWidth

                    If mouseX >= noteX AndAlso mouseX <= noteX + noteWidth AndAlso
                   mouseY >= noteY AndAlso mouseY <= noteY + noteHeight Then
                        If e.Button = MouseButtons.Right Then
                            If rb_Add.Checked = True Then
                                ' Define a predicate to match notes you want to remove
                                Dim predicate As Predicate(Of Melanchall.DryWetMidi.Interaction.Note) = Function(n) CInt(n.NoteNumber) = note.NoteNumber.ToString AndAlso n.Time = note.Time.ToString ' Modify these conditions as needed
                                midiFile.RemoveNotes(predicate)
                                DrawPianoRoll()
                            End If
                        Else
                            If rb_Add.Checked = True Then
                                ' Define a predicate to match notes you want to remove
                                Dim predicate As Predicate(Of Melanchall.DryWetMidi.Interaction.Note) = Function(n) CInt(n.NoteNumber) = note.NoteNumber.ToString AndAlso n.Time = note.Time.ToString ' Modify these conditions as needed
                                If Not noteResize Then
                                    LastNoteLength = note.Length / WidthZoom
                                    LastNoteIndex = note.NoteNumber
                                    LastNoteX = (note.Time / WidthZoom) + 10
                                    LastVelocity = note.Velocity
                                End If
                                midiFile.RemoveNotes(predicate)
                                DrawPianoRoll()
                                noteDrag = True
                                DrawRollOverlay((note.Time / WidthZoom) + ((note.Length / WidthZoom) / 2), e.Y, False)
                                RenderPianoSoundWithNote(note.NoteNumber.ToString, note.Velocity)
                            ElseIf rb_listen.Checked = True Or rb_noteEdit.Checked = True Then
                                NotePlayed = note.NoteNumber.ToString & note.Time.ToString
                                txt_Test.Text = note.Time & " " & note.Length
                                DrawPianoRoll()
                                RenderPianoSoundWithNote(note.NoteNumber.ToString, note.Velocity)
                            End If
                        End If
                        Exit For ' Exit the loop once a note is clicked
                    End If
                Next
                If e.Button = MouseButtons.Left Then
                    If rb_Add.Checked = True Then
                        noteDrag = True
                        'AddNote((picPiano.Height - e.Y) \ KeyWidth, 127, (e.X * WidthZoom))
                        RenderPianoSoundWithNote((picPiano.Height - e.Y) \ KeyWidth, LastVelocity)
                    End If
                End If
            End Using
        End If
    End Sub

    Private Sub picRollOverlay_MouseUp(sender As Object, e As MouseEventArgs) Handles picRollOverlay.MouseUp
        If isPlaying = False Then
            Dim channel = Combo_output.SelectedIndex ' Use the selected index from Combo_output as the channel
            ' Loop through each key in keyStates
            For i As Integer = 0 To keyStates.Length - 1
                If keyStates(i) Then
                    TurnOffNote(i)
                End If
            Next
            If noteDrag = True Then
                If noteResize Then
                    DrawRollOverlay(e.X, e.Y, False)
                    LastNoteX = LastNoteX + (LastNoteLength / 2)
                    AddNote(LastNoteIndex, LastVelocity, LastNoteX * WidthZoom, LastNoteLength * WidthZoom)
                Else
                    DrawRollOverlay(e.X, e.Y, False)
                    LastNoteX = e.X
                    AddNote(LastNoteIndex, LastVelocity, LastNoteX * WidthZoom, LastNoteLength * WidthZoom)
                End If
                Dim events = midiFile.GetTimedEvents()
                ' Get the total length of the track
                Dim totalLength = events.LastOrDefault()?.Time
                ' Display the total length
                'MessageBox.Show($"Tempo: {averageBpm} " & $"Beat Division (Beats per Bar): {beatDivision}", "MIDI Track Length", MessageBoxButtons.OK, MessageBoxIcon.Information)
                RollWidth = (totalLength / WidthZoom) + Panel3.Width
                MIDIWidth = totalLength / WidthZoom
                picRollTest.Size = New Size(RollWidth, RollHeight)
                picRollOverlay.Size = New Size(RollWidth, RollHeight)
                picRollGrid.Size = New Size(RollWidth, RollHeight)
                picTimeLine.Size = New Size(RollWidth, 17)
                picPiano.Size = New Size(PianoWidth, RollHeight)
                picPianoHighlight.Size = New Size(PianoWidth, RollHeight)
                ResizeScrollbars()
                ' Initialize the drawing of the piano roll
                DrawGrid()
                DrawPianoRoll()
                SetupTimer()
            End If
            NotePlayed = ""
            noteDrag = False
            If rb_noteEdit.Checked = False Then
                DrawPianoRoll()
            End If
            RedrawPianoKeys()
            picRollOverlay.Image?.Dispose() ' Dispose of the previous image, if any
            ' Create a new Bitmap with the same size as the PictureBox
            picRollOverlay.Image = New Bitmap(picRollOverlay.Width, picRollOverlay.Height)
        End If
    End Sub

    Private Sub btn_stop_Click(sender As Object, e As EventArgs) Handles btn_stop.Click
        StopPlaying()
    End Sub

    Private Sub StopPlaying()
        If isPlaying Then
            HScrollBar1.Enabled = True
            stopwatch.Stop()
            stopwatch.Reset()
            MidiClock.Stop()
            MidiClockTime = 0
            pn_pointer.Location = New Point(-1, 0)
            btn_play.Text = "PLAY"
            isPlaying = False
            txt_Test.Text = "Ticks: " & MidiClockTime
            HScrollBar1.Value = 0
            ScrollHorizontally()
            lastElapsedMilliseconds = 0
            For i As Integer = 0 To keyStates.Length - 1
                keyStates(i) = False
                TurnOffNote(i)
                lastKeyInterval(i) = -1
            Next
            RedrawPianoKeys()
        Else
            HScrollBar1.Enabled = True
            MidiClockTime = 0
            txt_Test.Text = "Ticks: " & MidiClockTime
            HScrollBar1.Value = 0
            ScrollHorizontally()
            lastElapsedMilliseconds = 0
            For i As Integer = 0 To keyStates.Length - 1
                keyStates(i) = False
                TurnOffNote(i)
                lastKeyInterval(i) = -1
            Next
            RedrawPianoKeys()
        End If
    End Sub

    Private Sub TutorialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TutorialToolStripMenuItem.Click
        Tutorial.Show()
    End Sub

    Private Sub txt_BPM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_BPM.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            ' Validate and format the entered text
            ValidateAndFormatInput()
            ' Consume the Enter key to prevent a newline character from being added to the TextBox
            e.Handled = True
        End If
    End Sub

    Private Sub ValidateAndFormatInput()
        Dim inputText As String = txt_BPM.Text

        ' Remove any non-numeric characters
        For Each c As Char In inputText
            If Not Char.IsDigit(c) AndAlso c <> "." Then
                txt_BPM.Text = txt_BPM.Text.Replace(c, "")
            End If
        Next

        ' Allow only one decimal point
        Dim decimalCount As Integer = inputText.Count(Function(c) c = ".")
        If decimalCount > 1 Then
            txt_BPM.Text = txt_BPM.Text.Substring(0, txt_BPM.Text.LastIndexOf("."))
        End If

        ' Format the number to have at most 3 decimal places
        If Not String.IsNullOrWhiteSpace(txt_BPM.Text) AndAlso IsNumeric(txt_BPM.Text) Then
            Dim number As Double = Convert.ToDouble(txt_BPM.Text)

            ' Enforce minimum and maximum values
            If number < 40 Then
                number = 40
            ElseIf number > 999.999 Then
                number = 999.999
            End If

            txt_BPM.Text = number.ToString("F3")
        End If
    End Sub

    Private Sub SetBPMValue(value As Double)
        ' Format the value to have at most 3 decimal places
        Dim formattedValue As String = value.ToString("F3")

        ' Assign the formatted value to the TextBox
        txt_BPM.Text = formattedValue
    End Sub

    Private Sub picRollOverlay_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles picRollOverlay.MouseDoubleClick
        If rb_noteEdit.Checked = True Then
            Dim channel = Combo_output.SelectedIndex ' Use the selected index from Combo_output as the channel
            ' Get the mouse coordinates
            Dim mouseX As Integer = e.X
            Dim mouseY As Integer = e.Y

            ' Create a new instance of the form
            Dim myForm As New NoteEdit()

            For Each note In midiFile.GetNotes()
                Dim noteX As Integer = CInt(note.Time / WidthZoom)
                Dim noteY As Integer = CInt((127 - note.NoteNumber.ToString) * KeyWidth)
                Dim noteWidth As Integer = CInt(note.Length / WidthZoom)
                Dim noteHeight As Integer = KeyWidth

                If mouseX >= noteX AndAlso mouseX <= noteX + noteWidth AndAlso
                   mouseY >= noteY AndAlso mouseY <= noteY + noteHeight Then
                    LastNoteLength = note.Length
                    LastNoteIndex = note.NoteNumber
                    LastNoteX = note.Time
                    LastVelocity = note.Velocity
                    ' Access and modify the TextBox controls
                    myForm.txt_Vel.Text = LastVelocity
                    myForm.txt_Time.Text = LastNoteX
                    myForm.txt_Length.Text = LastNoteLength
                    myForm.lbl_Note.Text = LastNoteIndex
                    Exit For ' Exit the loop once a note is clicked
                End If
            Next

            ' Disable user input in Form1
            Me.Enabled = False

            ' Show the form
            AddHandler myForm.FormClosed, AddressOf myFormClosedHandler
            myForm.Show()
        End If
    End Sub
    Private Sub myFormClosedHandler(sender As Object, e As FormClosedEventArgs)
        DrawPianoRoll()
        RedrawPianoKeys()
        ' Re-enable user input in main form when noteedit is closed
        Me.Enabled = True
    End Sub

    Private Sub Btn_plus_Click(sender As Object, e As EventArgs) Handles btn_plus.Click
        If (WidthZoom * 0.7) > WidthZoomMin Then
            WidthZoom = WidthZoom * 0.7
        End If
        ' Display the total length
        'MessageBox.Show($"Tempo: {averageBpm} " & $"Beat Division (Beats per Bar): {beatDivision}", "MIDI Track Length", MessageBoxButtons.OK, MessageBoxIcon.Information)
        RollWidth = (totalLength / WidthZoom) + Panel3.Width
        MIDIWidth = totalLength / WidthZoom
        picRollTest.Size = New Size(RollWidth, RollHeight)
        picRollOverlay.Size = New Size(RollWidth, RollHeight)
        picRollGrid.Size = New Size(RollWidth, RollHeight)
        picTimeLine.Size = New Size(RollWidth, 17)
        ResizeScrollbars()
        ' Initialize the drawing of the piano roll
        DrawGrid()
        DrawPianoRoll()
        SetupTimer()
    End Sub

    Private Sub Btn_minus_Click(sender As Object, e As EventArgs) Handles btn_minus.Click
        If (WidthZoom * 1.4) < WidthZoomMax Then
            WidthZoom = WidthZoom * 1.4
        End If
        ' Display the total length
        'MessageBox.Show($"Tempo: {averageBpm} " & $"Beat Division (Beats per Bar): {beatDivision}", "MIDI Track Length", MessageBoxButtons.OK, MessageBoxIcon.Information)
        RollWidth = (totalLength / WidthZoom) + Panel3.Width
        MIDIWidth = totalLength / WidthZoom
        picRollTest.Size = New Size(RollWidth, RollHeight)
        picRollOverlay.Size = New Size(RollWidth, RollHeight)
        picRollGrid.Size = New Size(RollWidth, RollHeight)
        picTimeLine.Size = New Size(RollWidth, 17)
        ResizeScrollbars()
        ' Initialize the drawing of the piano roll
        DrawGrid()
        DrawPianoRoll()
        SetupTimer()
    End Sub
End Class


