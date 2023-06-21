<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sig_Gen_Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sig_Gen_Form1))
        Me.Test_TextBox = New System.Windows.Forms.TextBox()
        Me.Com_Ports = New System.Windows.Forms.ListBox()
        Me.Get_Ports_Button = New System.Windows.Forms.Button()
        Me.Connect_GroupBox = New System.Windows.Forms.GroupBox()
        Me.Exit_Button = New System.Windows.Forms.Button()
        Me.Run_Button = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Frequency_TextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Waveform_ListBox = New System.Windows.Forms.ListBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Connect_GroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'Test_TextBox
        '
        Me.Test_TextBox.Location = New System.Drawing.Point(22, 98)
        Me.Test_TextBox.Name = "Test_TextBox"
        Me.Test_TextBox.Size = New System.Drawing.Size(146, 22)
        Me.Test_TextBox.TabIndex = 25
        Me.Test_TextBox.Text = " Status Message"
        '
        'Com_Ports
        '
        Me.Com_Ports.FormattingEnabled = True
        Me.Com_Ports.ItemHeight = 16
        Me.Com_Ports.Location = New System.Drawing.Point(22, 56)
        Me.Com_Ports.Name = "Com_Ports"
        Me.Com_Ports.Size = New System.Drawing.Size(146, 36)
        Me.Com_Ports.TabIndex = 2
        '
        'Get_Ports_Button
        '
        Me.Get_Ports_Button.Location = New System.Drawing.Point(22, 21)
        Me.Get_Ports_Button.Name = "Get_Ports_Button"
        Me.Get_Ports_Button.Size = New System.Drawing.Size(146, 28)
        Me.Get_Ports_Button.TabIndex = 3
        Me.Get_Ports_Button.Text = "Available Com Ports"
        Me.Get_Ports_Button.UseVisualStyleBackColor = True
        '
        'Connect_GroupBox
        '
        Me.Connect_GroupBox.BackColor = System.Drawing.Color.LightGray
        Me.Connect_GroupBox.Controls.Add(Me.Exit_Button)
        Me.Connect_GroupBox.Controls.Add(Me.Run_Button)
        Me.Connect_GroupBox.Controls.Add(Me.Label2)
        Me.Connect_GroupBox.Controls.Add(Me.Frequency_TextBox)
        Me.Connect_GroupBox.Controls.Add(Me.Label1)
        Me.Connect_GroupBox.Controls.Add(Me.Waveform_ListBox)
        Me.Connect_GroupBox.Controls.Add(Me.Com_Ports)
        Me.Connect_GroupBox.Controls.Add(Me.Get_Ports_Button)
        Me.Connect_GroupBox.Controls.Add(Me.Test_TextBox)
        Me.Connect_GroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Connect_GroupBox.Location = New System.Drawing.Point(12, 38)
        Me.Connect_GroupBox.Name = "Connect_GroupBox"
        Me.Connect_GroupBox.Size = New System.Drawing.Size(183, 387)
        Me.Connect_GroupBox.TabIndex = 28
        Me.Connect_GroupBox.TabStop = False
        Me.Connect_GroupBox.Text = "Connect"
        '
        'Exit_Button
        '
        Me.Exit_Button.Location = New System.Drawing.Point(36, 312)
        Me.Exit_Button.Name = "Exit_Button"
        Me.Exit_Button.Size = New System.Drawing.Size(82, 23)
        Me.Exit_Button.TabIndex = 42
        Me.Exit_Button.Text = "EXIT"
        Me.Exit_Button.UseVisualStyleBackColor = True
        '
        'Run_Button
        '
        Me.Run_Button.Location = New System.Drawing.Point(43, 269)
        Me.Run_Button.Name = "Run_Button"
        Me.Run_Button.Size = New System.Drawing.Size(68, 37)
        Me.Run_Button.TabIndex = 41
        Me.Run_Button.Text = "RUN"
        Me.Run_Button.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(33, 210)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 16)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Frequency Hz"
        '
        'Frequency_TextBox
        '
        Me.Frequency_TextBox.Location = New System.Drawing.Point(22, 229)
        Me.Frequency_TextBox.Name = "Frequency_TextBox"
        Me.Frequency_TextBox.Size = New System.Drawing.Size(109, 22)
        Me.Frequency_TextBox.TabIndex = 28
        Me.Frequency_TextBox.Text = "1000"
        Me.Frequency_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(19, 138)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 16)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Select Waveform"
        '
        'Waveform_ListBox
        '
        Me.Waveform_ListBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Waveform_ListBox.FormattingEnabled = True
        Me.Waveform_ListBox.ItemHeight = 15
        Me.Waveform_ListBox.Items.AddRange(New Object() {"DDS Sin (0-50 kHz)", "DDS Tri (0-50 kHz)", "DDS RampUp (0-50kHz)", "DDS RampDn (0-50kHz)"})
        Me.Waveform_ListBox.Location = New System.Drawing.Point(9, 157)
        Me.Waveform_ListBox.Name = "Waveform_ListBox"
        Me.Waveform_ListBox.Size = New System.Drawing.Size(168, 34)
        Me.Waveform_ListBox.TabIndex = 26
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(183, 20)
        Me.TextBox1.TabIndex = 29
        Me.TextBox1.Text = "Arduino DDS Audio Signal Generator"
        '
        'Sig_Gen_Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(207, 435)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Connect_GroupBox)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Sig_Gen_Form1"
        Me.Text = "Aj_Sig_Gen"
        Me.Connect_GroupBox.ResumeLayout(False)
        Me.Connect_GroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Test_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Get_Ports_Button As System.Windows.Forms.Button
    Friend WithEvents Com_Ports As System.Windows.Forms.ListBox
    Friend WithEvents Connect_GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Waveform_ListBox As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Frequency_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Run_Button As System.Windows.Forms.Button
    Friend WithEvents Exit_Button As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

End Class
