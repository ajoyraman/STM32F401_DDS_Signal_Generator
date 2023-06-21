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
        Me.Test_TextBox = New System.Windows.Forms.TextBox
        Me.Com_Ports = New System.Windows.Forms.ListBox
        Me.Get_Ports_Button = New System.Windows.Forms.Button
        Me.Connect_GroupBox = New System.Windows.Forms.GroupBox
        Me.Exit_Button = New System.Windows.Forms.Button
        Me.Run_Button = New System.Windows.Forms.Button
        Me.Offset_ListBox = New System.Windows.Forms.ListBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Amplitude_ListBox = New System.Windows.Forms.ListBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Frequency_TextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Waveform_ListBox = New System.Windows.Forms.ListBox
        Me.Connect_GroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'Test_TextBox
        '
        Me.Test_TextBox.Location = New System.Drawing.Point(6, 109)
        Me.Test_TextBox.Name = "Test_TextBox"
        Me.Test_TextBox.Size = New System.Drawing.Size(208, 22)
        Me.Test_TextBox.TabIndex = 25
        Me.Test_TextBox.Text = " Status Message"
        '
        'Com_Ports
        '
        Me.Com_Ports.FormattingEnabled = True
        Me.Com_Ports.ItemHeight = 16
        Me.Com_Ports.Location = New System.Drawing.Point(6, 63)
        Me.Com_Ports.Name = "Com_Ports"
        Me.Com_Ports.Size = New System.Drawing.Size(208, 36)
        Me.Com_Ports.TabIndex = 2
        '
        'Get_Ports_Button
        '
        Me.Get_Ports_Button.Location = New System.Drawing.Point(6, 29)
        Me.Get_Ports_Button.Name = "Get_Ports_Button"
        Me.Get_Ports_Button.Size = New System.Drawing.Size(208, 28)
        Me.Get_Ports_Button.TabIndex = 3
        Me.Get_Ports_Button.Text = "Available Com Ports"
        Me.Get_Ports_Button.UseVisualStyleBackColor = True
        '
        'Connect_GroupBox
        '
        Me.Connect_GroupBox.BackColor = System.Drawing.Color.LightGray
        Me.Connect_GroupBox.Controls.Add(Me.Exit_Button)
        Me.Connect_GroupBox.Controls.Add(Me.Run_Button)
        Me.Connect_GroupBox.Controls.Add(Me.Offset_ListBox)
        Me.Connect_GroupBox.Controls.Add(Me.Label4)
        Me.Connect_GroupBox.Controls.Add(Me.Amplitude_ListBox)
        Me.Connect_GroupBox.Controls.Add(Me.Label3)
        Me.Connect_GroupBox.Controls.Add(Me.Label2)
        Me.Connect_GroupBox.Controls.Add(Me.Frequency_TextBox)
        Me.Connect_GroupBox.Controls.Add(Me.Label1)
        Me.Connect_GroupBox.Controls.Add(Me.Waveform_ListBox)
        Me.Connect_GroupBox.Controls.Add(Me.Com_Ports)
        Me.Connect_GroupBox.Controls.Add(Me.Get_Ports_Button)
        Me.Connect_GroupBox.Controls.Add(Me.Test_TextBox)
        Me.Connect_GroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Connect_GroupBox.Location = New System.Drawing.Point(12, 12)
        Me.Connect_GroupBox.Name = "Connect_GroupBox"
        Me.Connect_GroupBox.Size = New System.Drawing.Size(227, 476)
        Me.Connect_GroupBox.TabIndex = 28
        Me.Connect_GroupBox.TabStop = False
        Me.Connect_GroupBox.Text = "Connect To Com Port"
        '
        'Exit_Button
        '
        Me.Exit_Button.Location = New System.Drawing.Point(66, 447)
        Me.Exit_Button.Name = "Exit_Button"
        Me.Exit_Button.Size = New System.Drawing.Size(75, 23)
        Me.Exit_Button.TabIndex = 42
        Me.Exit_Button.Text = "EXIT"
        Me.Exit_Button.UseVisualStyleBackColor = True
        '
        'Run_Button
        '
        Me.Run_Button.Location = New System.Drawing.Point(6, 372)
        Me.Run_Button.Name = "Run_Button"
        Me.Run_Button.Size = New System.Drawing.Size(208, 37)
        Me.Run_Button.TabIndex = 41
        Me.Run_Button.Text = "RUN"
        Me.Run_Button.UseVisualStyleBackColor = True
        '
        'Offset_ListBox
        '
        Me.Offset_ListBox.FormattingEnabled = True
        Me.Offset_ListBox.ItemHeight = 16
        Me.Offset_ListBox.Items.AddRange(New Object() {"+4.000 V", "+3.750 V", "+3.500 V", "+3.250 V", "+3.000 V", "+2.750 V", "+2.500 V", "+2.250 V", "+2.000 V", "+1.750 V", "+1.500 V", "+1.250 V", "+1.000 V", "+0.750 V", "+0.500 V", "+0.250 V", "0.000 V", "-0.250 V", "-0.500 V", "-0.750 V", "-1.000 V", "-1.250 V", "-1.500 V", "-1.750 V", "-2.000 V", "-2.250 V", "-2.500 V", "-2.750 V", "-3.000 V", "-3.250 V", "-3.500 V", "-3.750 V", "-4.000 V"})
        Me.Offset_ListBox.Location = New System.Drawing.Point(113, 288)
        Me.Offset_ListBox.Name = "Offset_ListBox"
        Me.Offset_ListBox.Size = New System.Drawing.Size(101, 52)
        Me.Offset_ListBox.TabIndex = 40
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(110, 267)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 16)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Offset "
        '
        'Amplitude_ListBox
        '
        Me.Amplitude_ListBox.FormattingEnabled = True
        Me.Amplitude_ListBox.ItemHeight = 16
        Me.Amplitude_ListBox.Items.AddRange(New Object() {"0.00 V", "0.25 V", "0.50 V", "0.75 V", "1.00 V", "1.25 V", "1.50 V", "1.75 V", "2.00 V", "2.25 V", "2.50 V", "2.75 V", "3.00 V", "3.25 V", "3.50 V", "3.75 V", "4.00 V", "4.25 V", "4.50 V", "4.75 V", "5.00 V", "5.25 V", "5.50 V", "5.75 V", "6.00 V", "6.25 V", "6.50 V", "6.75 V", "7.00 V", "7.25 V", "7.50 V", "7.75 V"})
        Me.Amplitude_ListBox.Location = New System.Drawing.Point(6, 288)
        Me.Amplitude_ListBox.Name = "Amplitude_ListBox"
        Me.Amplitude_ListBox.Size = New System.Drawing.Size(101, 52)
        Me.Amplitude_ListBox.TabIndex = 38
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(6, 267)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 16)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Amplitude "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(40, 210)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 16)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Frequency Hz"
        '
        'Frequency_TextBox
        '
        Me.Frequency_TextBox.Location = New System.Drawing.Point(43, 231)
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
        Me.Label1.Location = New System.Drawing.Point(7, 136)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 16)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Select Waveform"
        '
        'Waveform_ListBox
        '
        Me.Waveform_ListBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Waveform_ListBox.FormattingEnabled = True
        Me.Waveform_ListBox.ItemHeight = 16
        Me.Waveform_ListBox.Items.AddRange(New Object() {"DDS Sin (0-50 kHz)", "DDS Tri (0-50 kHz)", "Sin 50 kHz", "Tri 50 kHz", "Sin 100 kHz", "Tri 100 kHz"})
        Me.Waveform_ListBox.Location = New System.Drawing.Point(9, 157)
        Me.Waveform_ListBox.Name = "Waveform_ListBox"
        Me.Waveform_ListBox.Size = New System.Drawing.Size(205, 36)
        Me.Waveform_ListBox.TabIndex = 26
        '
        'Sig_Gen_Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(254, 500)
        Me.Controls.Add(Me.Connect_GroupBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Sig_Gen_Form1"
        Me.Text = "Aj_Signal-Generator"
        Me.Connect_GroupBox.ResumeLayout(False)
        Me.Connect_GroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Test_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Get_Ports_Button As System.Windows.Forms.Button
    Friend WithEvents Com_Ports As System.Windows.Forms.ListBox
    Friend WithEvents Connect_GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Waveform_ListBox As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Frequency_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Amplitude_ListBox As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Offset_ListBox As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Run_Button As System.Windows.Forms.Button
    Friend WithEvents Exit_Button As System.Windows.Forms.Button

End Class
