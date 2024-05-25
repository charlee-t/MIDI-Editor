Imports Melanchall.DryWetMidi.Interaction

Public Class NoteEdit
    Dim DefaultVel As Integer
    Dim DefaultTime As Integer
    Dim DefaultLength As Integer

    Private Sub NoteEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DefaultVel = txt_Vel.Text
        DefaultTime = txt_Time.Text
        DefaultLength = txt_Length.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txt_Vel.Text = DefaultVel
        txt_Time.Text = DefaultTime
        txt_Length.Text = DefaultLength
    End Sub

    Private Sub Btn_Apply_Click(sender As Object, e As EventArgs) Handles btn_Apply.Click
        With Form1
            ' Define a predicate to match notes you want to remove
            Dim predicate As Predicate(Of Melanchall.DryWetMidi.Interaction.Note) = Function(n) CInt(n.NoteNumber) = .LastNoteIndex AndAlso n.Time = .LastNoteX ' Modify these conditions as needed
            .midiFile.RemoveNotes(predicate)
            .AddNote(.LastNoteIndex, CInt(txt_Vel.Text), CInt(txt_Time.Text) + (CInt(txt_Length.Text) / 2), CInt(txt_Length.Text))
        End With
        Me.Close()
    End Sub

    Private Sub txt_Vel_TextChanged(sender As Object, e As EventArgs) Handles txt_Vel.TextChanged
        ' Check if the entered text is a valid integer
        If Integer.TryParse(txt_Vel.Text, Nothing) Then
            ' Ensure the value stays within the range of 0 to 127
            Dim value As Integer = CInt(txt_Vel.Text)
            If value < 0 Then
                txt_Vel.Text = "0"
            ElseIf value > 127 Then
                txt_Vel.Text = "127"
            End If
        Else
            ' Reset the text to 0 if it's not a valid integer
            txt_Vel.Text = "0"
        End If
    End Sub

    Private Sub txt_Time_TextChanged(sender As Object, e As EventArgs) Handles txt_Time.TextChanged
        ' Check if the entered text is a valid integer
        If Integer.TryParse(txt_Time.Text, Nothing) Then
            ' Ensure the value stays within the range of 0 to 127
            Dim value As Integer = CInt(txt_Time.Text)
            If value < 0 Then
                txt_Time.Text = "0"
            ElseIf value > CInt(Form1.MIDIWidth * Form1.WidthZoom) Then
                txt_Time.Text = CInt(Form1.MIDIWidth * Form1.WidthZoom) - 1
            End If
        Else
            ' Reset the text to 0 if it's not a valid integer
            txt_Time.Text = "0"
        End If
    End Sub

    Private Sub txt_Length_TextChanged(sender As Object, e As EventArgs) Handles txt_Length.TextChanged
        ' Check if the entered text is a valid integer
        If Integer.TryParse(txt_Length.Text, Nothing) Then
            ' Ensure the value stays within the range of 0 to 127
            Dim value As Integer = CInt(txt_Length.Text)
            If value < 0 Then
                txt_Length.Text = "0"
            ElseIf value > CInt(Form1.MIDIWidth * Form1.WidthZoom) Then
                txt_Length.Text = CInt(Form1.MIDIWidth * Form1.WidthZoom) - 1
            End If
        Else
            ' Reset the text to 0 if it's not a valid integer
            txt_Length.Text = "0"
        End If
    End Sub
End Class