<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tutorial
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ADD:MOVE:SIZE Tool"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(7, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(423, 83)
        Me.Panel1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(1, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(310, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "To ADD a note, Left-Click on any empty space on the piano Roll."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(1, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(337, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "To MOVE a note, Left-Click on any existing note then move the cursor."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(1, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(421, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "To RE-SIZE a note, hover the cursor at the end of an existing note then drag left" &
    " or right."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(1, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(358, 32)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "To REMOVE a note, Right-Click on any existing notes." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You can also hold the Right" &
    " Mouse button and drag to delete multiple notes."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(3, 123)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 20)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "NOTE EDIT Tool"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Location = New System.Drawing.Point(7, 146)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(423, 39)
        Me.Panel2.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(1, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(402, 32)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "To fine-tune a note's properties, just Double-Click on any existing notes and the" &
    " Note" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Edit window will show up."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(3, 199)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 20)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "LISTEN Tool"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Location = New System.Drawing.Point(7, 222)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(423, 20)
        Me.Panel3.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(1, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(342, 16)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "To Listen to each note, simply Left-Click on any notes to hear them play."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(3, 256)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(144, 20)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Importing a MIDI File:"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Location = New System.Drawing.Point(6, 279)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(423, 20)
        Me.Panel4.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(1, 1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(421, 16)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "To Import a MIDI File, just click File > Import MIDI File > Then browse for the d" &
    "esired file."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(3, 314)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(143, 20)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Exporting a MIDI File:"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.Panel5.Controls.Add(Me.Label13)
        Me.Panel5.Location = New System.Drawing.Point(7, 337)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(423, 20)
        Me.Panel5.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(1, 1)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(279, 16)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "To Export a MIDI File, navigate to File > Export MIDI File."
        '
        'Tutorial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(438, 367)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Tutorial"
        Me.Text = "Tutorial"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label13 As Label
End Class
