<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NoteEdit
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txt_Vel = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txt_Time = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_Length = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_Apply = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_Note = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txt_Vel)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(7, 22)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(105, 48)
        Me.Panel1.TabIndex = 0
        '
        'txt_Vel
        '
        Me.txt_Vel.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.txt_Vel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Vel.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Vel.ForeColor = System.Drawing.Color.White
        Me.txt_Vel.Location = New System.Drawing.Point(5, 20)
        Me.txt_Vel.Name = "txt_Vel"
        Me.txt_Vel.Size = New System.Drawing.Size(92, 20)
        Me.txt_Vel.TabIndex = 1
        Me.txt_Vel.Text = "0"
        Me.txt_Vel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(2, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Velocity:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txt_Time)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(7, 76)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(105, 48)
        Me.Panel2.TabIndex = 2
        '
        'txt_Time
        '
        Me.txt_Time.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.txt_Time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Time.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Time.ForeColor = System.Drawing.Color.White
        Me.txt_Time.Location = New System.Drawing.Point(5, 20)
        Me.txt_Time.Name = "txt_Time"
        Me.txt_Time.Size = New System.Drawing.Size(92, 20)
        Me.txt_Time.TabIndex = 1
        Me.txt_Time.Text = "0"
        Me.txt_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(2, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Start Time:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(2, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Duration:"
        '
        'txt_Length
        '
        Me.txt_Length.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.txt_Length.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Length.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Length.ForeColor = System.Drawing.Color.White
        Me.txt_Length.Location = New System.Drawing.Point(5, 20)
        Me.txt_Length.Name = "txt_Length"
        Me.txt_Length.Size = New System.Drawing.Size(92, 20)
        Me.txt_Length.TabIndex = 1
        Me.txt_Length.Text = "0"
        Me.txt_Length.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.txt_Length)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Location = New System.Drawing.Point(7, 130)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(105, 48)
        Me.Panel3.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(7, 185)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(49, 27)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Reset"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btn_Apply
        '
        Me.btn_Apply.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_Apply.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btn_Apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Apply.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Apply.ForeColor = System.Drawing.Color.White
        Me.btn_Apply.Location = New System.Drawing.Point(63, 185)
        Me.btn_Apply.Name = "btn_Apply"
        Me.btn_Apply.Size = New System.Drawing.Size(49, 27)
        Me.btn_Apply.TabIndex = 4
        Me.btn_Apply.Text = "Apply"
        Me.btn_Apply.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 15)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Note:"
        '
        'lbl_Note
        '
        Me.lbl_Note.AutoSize = True
        Me.lbl_Note.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Note.ForeColor = System.Drawing.Color.White
        Me.lbl_Note.Location = New System.Drawing.Point(33, 3)
        Me.lbl_Note.Name = "lbl_Note"
        Me.lbl_Note.Size = New System.Drawing.Size(12, 15)
        Me.lbl_Note.TabIndex = 5
        Me.lbl_Note.Text = "0"
        '
        'NoteEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(120, 232)
        Me.Controls.Add(Me.lbl_Note)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btn_Apply)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "NoteEdit"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Note Properties"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents txt_Vel As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txt_Time As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_Length As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents btn_Apply As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents lbl_Note As Label
End Class
