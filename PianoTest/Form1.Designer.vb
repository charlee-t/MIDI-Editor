<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Combo_output = New System.Windows.Forms.ComboBox()
        Me.lbl_Test = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_BPM = New System.Windows.Forms.TextBox()
        Me.btn_play = New System.Windows.Forms.Button()
        Me.picRollTest = New System.Windows.Forms.PictureBox()
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar()
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pn_pointer = New System.Windows.Forms.PictureBox()
        Me.picRollOverlay = New System.Windows.Forms.PictureBox()
        Me.picRollGrid = New System.Windows.Forms.PictureBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.picPianoHighlight = New System.Windows.Forms.PictureBox()
        Me.picPiano = New System.Windows.Forms.PictureBox()
        Me.txt_Test = New System.Windows.Forms.Label()
        Me.MidiClock = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.picTimeLine = New System.Windows.Forms.PictureBox()
        Me.rb_Add = New System.Windows.Forms.RadioButton()
        Me.rb_listen = New System.Windows.Forms.RadioButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TutorialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_stop = New System.Windows.Forms.Button()
        Me.rb_noteEdit = New System.Windows.Forms.RadioButton()
        Me.btn_minus = New System.Windows.Forms.Button()
        Me.btn_plus = New System.Windows.Forms.Button()
        CType(Me.picRollTest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.pn_pointer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRollOverlay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRollGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.picPianoHighlight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPiano, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.picTimeLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Combo_output
        '
        Me.Combo_output.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.Combo_output.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Combo_output.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_output.ForeColor = System.Drawing.Color.White
        Me.Combo_output.FormattingEnabled = True
        Me.Combo_output.Location = New System.Drawing.Point(60, 28)
        Me.Combo_output.Name = "Combo_output"
        Me.Combo_output.Size = New System.Drawing.Size(154, 23)
        Me.Combo_output.TabIndex = 6
        Me.Combo_output.Text = "Test"
        '
        'lbl_Test
        '
        Me.lbl_Test.AutoSize = True
        Me.lbl_Test.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Test.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Test.ForeColor = System.Drawing.Color.White
        Me.lbl_Test.Location = New System.Drawing.Point(9, 31)
        Me.lbl_Test.Name = "lbl_Test"
        Me.lbl_Test.Size = New System.Drawing.Size(51, 15)
        Me.lbl_Test.TabIndex = 7
        Me.lbl_Test.Text = "MIDI OUT:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(220, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 15)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "BPM:"
        '
        'txt_BPM
        '
        Me.txt_BPM.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txt_BPM.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_BPM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txt_BPM.Location = New System.Drawing.Point(254, 30)
        Me.txt_BPM.Name = "txt_BPM"
        Me.txt_BPM.Size = New System.Drawing.Size(53, 20)
        Me.txt_BPM.TabIndex = 10
        Me.txt_BPM.Text = "120.000"
        Me.txt_BPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_play
        '
        Me.btn_play.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_play.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_play.ForeColor = System.Drawing.Color.White
        Me.btn_play.Location = New System.Drawing.Point(319, 30)
        Me.btn_play.Name = "btn_play"
        Me.btn_play.Size = New System.Drawing.Size(50, 20)
        Me.btn_play.TabIndex = 11
        Me.btn_play.Text = "PLAY"
        Me.btn_play.UseVisualStyleBackColor = True
        '
        'picRollTest
        '
        Me.picRollTest.BackColor = System.Drawing.Color.Transparent
        Me.picRollTest.Location = New System.Drawing.Point(0, 0)
        Me.picRollTest.Name = "picRollTest"
        Me.picRollTest.Size = New System.Drawing.Size(482, 334)
        Me.picRollTest.TabIndex = 12
        Me.picRollTest.TabStop = False
        '
        'HScrollBar1
        '
        Me.HScrollBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HScrollBar1.Location = New System.Drawing.Point(60, 56)
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New System.Drawing.Size(742, 17)
        Me.HScrollBar1.TabIndex = 13
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VScrollBar1.Location = New System.Drawing.Point(802, 91)
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(17, 369)
        Me.VScrollBar1.TabIndex = 14
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel3.Controls.Add(Me.pn_pointer)
        Me.Panel3.Controls.Add(Me.picRollOverlay)
        Me.Panel3.Controls.Add(Me.picRollTest)
        Me.Panel3.Controls.Add(Me.picRollGrid)
        Me.Panel3.Location = New System.Drawing.Point(60, 90)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(742, 370)
        Me.Panel3.TabIndex = 15
        '
        'pn_pointer
        '
        Me.pn_pointer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pn_pointer.BackColor = System.Drawing.Color.White
        Me.pn_pointer.Location = New System.Drawing.Point(515, 0)
        Me.pn_pointer.Name = "pn_pointer"
        Me.pn_pointer.Size = New System.Drawing.Size(1, 369)
        Me.pn_pointer.TabIndex = 25
        Me.pn_pointer.TabStop = False
        '
        'picRollOverlay
        '
        Me.picRollOverlay.BackColor = System.Drawing.Color.Transparent
        Me.picRollOverlay.Location = New System.Drawing.Point(0, 0)
        Me.picRollOverlay.Name = "picRollOverlay"
        Me.picRollOverlay.Size = New System.Drawing.Size(482, 334)
        Me.picRollOverlay.TabIndex = 24
        Me.picRollOverlay.TabStop = False
        '
        'picRollGrid
        '
        Me.picRollGrid.BackColor = System.Drawing.Color.Transparent
        Me.picRollGrid.Location = New System.Drawing.Point(0, 0)
        Me.picRollGrid.Name = "picRollGrid"
        Me.picRollGrid.Size = New System.Drawing.Size(482, 334)
        Me.picRollGrid.TabIndex = 13
        Me.picRollGrid.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel4.Controls.Add(Me.picPianoHighlight)
        Me.Panel4.Controls.Add(Me.picPiano)
        Me.Panel4.Location = New System.Drawing.Point(0, 90)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(60, 370)
        Me.Panel4.TabIndex = 16
        '
        'picPianoHighlight
        '
        Me.picPianoHighlight.Location = New System.Drawing.Point(0, 0)
        Me.picPianoHighlight.Name = "picPianoHighlight"
        Me.picPianoHighlight.Size = New System.Drawing.Size(60, 135)
        Me.picPianoHighlight.TabIndex = 13
        Me.picPianoHighlight.TabStop = False
        '
        'picPiano
        '
        Me.picPiano.Location = New System.Drawing.Point(0, 0)
        Me.picPiano.Name = "picPiano"
        Me.picPiano.Size = New System.Drawing.Size(60, 135)
        Me.picPiano.TabIndex = 12
        Me.picPiano.TabStop = False
        '
        'txt_Test
        '
        Me.txt_Test.AutoSize = True
        Me.txt_Test.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Test.ForeColor = System.Drawing.Color.White
        Me.txt_Test.Location = New System.Drawing.Point(656, 31)
        Me.txt_Test.Name = "txt_Test"
        Me.txt_Test.Size = New System.Drawing.Size(55, 20)
        Me.txt_Test.TabIndex = 17
        Me.txt_Test.Text = "Ticks: 0"
        '
        'MidiClock
        '
        Me.MidiClock.Interval = 1
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.picTimeLine)
        Me.Panel1.Location = New System.Drawing.Point(60, 73)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(742, 17)
        Me.Panel1.TabIndex = 16
        '
        'picTimeLine
        '
        Me.picTimeLine.BackColor = System.Drawing.Color.Transparent
        Me.picTimeLine.Location = New System.Drawing.Point(0, 0)
        Me.picTimeLine.Name = "picTimeLine"
        Me.picTimeLine.Size = New System.Drawing.Size(482, 13)
        Me.picTimeLine.TabIndex = 14
        Me.picTimeLine.TabStop = False
        '
        'rb_Add
        '
        Me.rb_Add.AutoSize = True
        Me.rb_Add.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_Add.ForeColor = System.Drawing.Color.White
        Me.rb_Add.Location = New System.Drawing.Point(421, 31)
        Me.rb_Add.Name = "rb_Add"
        Me.rb_Add.Size = New System.Drawing.Size(96, 19)
        Me.rb_Add.TabIndex = 18
        Me.rb_Add.TabStop = True
        Me.rb_Add.Text = "ADD:MOVE:SIZE"
        Me.rb_Add.UseVisualStyleBackColor = True
        '
        'rb_listen
        '
        Me.rb_listen.AutoSize = True
        Me.rb_listen.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_listen.ForeColor = System.Drawing.Color.White
        Me.rb_listen.Location = New System.Drawing.Point(593, 31)
        Me.rb_listen.Name = "rb_listen"
        Me.rb_listen.Size = New System.Drawing.Size(57, 19)
        Me.rb_listen.TabIndex = 22
        Me.rb_listen.TabStop = True
        Me.rb_listen.Text = "LISTEN"
        Me.rb_listen.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(820, 24)
        Me.MenuStrip1.TabIndex = 23
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.OpenToolStripMenuItem.Text = "Import MIDI File"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.SaveAsToolStripMenuItem.Text = "Export MIDI File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TutorialToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'TutorialToolStripMenuItem
        '
        Me.TutorialToolStripMenuItem.Name = "TutorialToolStripMenuItem"
        Me.TutorialToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.TutorialToolStripMenuItem.Text = "Tutorial"
        '
        'btn_stop
        '
        Me.btn_stop.BackColor = System.Drawing.Color.DarkRed
        Me.btn_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_stop.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_stop.ForeColor = System.Drawing.Color.White
        Me.btn_stop.Location = New System.Drawing.Point(375, 30)
        Me.btn_stop.Name = "btn_stop"
        Me.btn_stop.Size = New System.Drawing.Size(40, 20)
        Me.btn_stop.TabIndex = 24
        Me.btn_stop.Text = "STOP"
        Me.btn_stop.UseVisualStyleBackColor = False
        '
        'rb_noteEdit
        '
        Me.rb_noteEdit.AutoSize = True
        Me.rb_noteEdit.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_noteEdit.ForeColor = System.Drawing.Color.White
        Me.rb_noteEdit.Location = New System.Drawing.Point(517, 31)
        Me.rb_noteEdit.Name = "rb_noteEdit"
        Me.rb_noteEdit.Size = New System.Drawing.Size(74, 19)
        Me.rb_noteEdit.TabIndex = 25
        Me.rb_noteEdit.TabStop = True
        Me.rb_noteEdit.Text = "NOTE EDIT"
        Me.rb_noteEdit.UseVisualStyleBackColor = True
        '
        'btn_minus
        '
        Me.btn_minus.BackColor = System.Drawing.Color.Gray
        Me.btn_minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_minus.ForeColor = System.Drawing.Color.White
        Me.btn_minus.Location = New System.Drawing.Point(12, 55)
        Me.btn_minus.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_minus.Name = "btn_minus"
        Me.btn_minus.Size = New System.Drawing.Size(19, 19)
        Me.btn_minus.TabIndex = 26
        Me.btn_minus.Text = "−"
        Me.btn_minus.UseVisualStyleBackColor = False
        '
        'btn_plus
        '
        Me.btn_plus.BackColor = System.Drawing.Color.Gray
        Me.btn_plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_plus.ForeColor = System.Drawing.Color.White
        Me.btn_plus.Location = New System.Drawing.Point(36, 55)
        Me.btn_plus.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_plus.Name = "btn_plus"
        Me.btn_plus.Size = New System.Drawing.Size(19, 19)
        Me.btn_plus.TabIndex = 27
        Me.btn_plus.Text = "+"
        Me.btn_plus.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(820, 461)
        Me.Controls.Add(Me.btn_plus)
        Me.Controls.Add(Me.btn_minus)
        Me.Controls.Add(Me.rb_noteEdit)
        Me.Controls.Add(Me.btn_stop)
        Me.Controls.Add(Me.Combo_output)
        Me.Controls.Add(Me.rb_listen)
        Me.Controls.Add(Me.rb_Add)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txt_Test)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.VScrollBar1)
        Me.Controls.Add(Me.HScrollBar1)
        Me.Controls.Add(Me.btn_play)
        Me.Controls.Add(Me.txt_BPM)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_Test)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "MIDI Editor v1.0"
        CType(Me.picRollTest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.pn_pointer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRollOverlay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRollGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.picPianoHighlight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPiano, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.picTimeLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Combo_output As ComboBox
    Friend WithEvents lbl_Test As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_BPM As TextBox
    Friend WithEvents btn_play As Button
    Friend WithEvents picRollTest As PictureBox
    Friend WithEvents HScrollBar1 As HScrollBar
    Friend WithEvents VScrollBar1 As VScrollBar
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents picPiano As PictureBox
    Friend WithEvents picRollGrid As PictureBox
    Friend WithEvents txt_Test As Label
    Friend WithEvents MidiClock As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents picTimeLine As PictureBox
    Friend WithEvents picPianoHighlight As PictureBox
    Friend WithEvents rb_Add As RadioButton
    Friend WithEvents rb_listen As RadioButton
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents picRollOverlay As PictureBox
    Friend WithEvents btn_stop As Button
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TutorialToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents rb_noteEdit As RadioButton
    Friend WithEvents pn_pointer As PictureBox
    Friend WithEvents btn_minus As Button
    Friend WithEvents btn_plus As Button
End Class
