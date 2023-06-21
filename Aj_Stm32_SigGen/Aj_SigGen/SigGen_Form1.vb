Imports System
Imports System.IO.Ports
Imports System.Globalization


Public Class Sig_Gen_Form1
#Region "Definations"
#Region "Definitions for Connect to COM Port "
    'Definitions for COM Port Connection
    'Define  serial port instance
    Dim mPort As New SerialPort
    Dim myBuffer As Integer = 25
    'myBuffer = mPort.ReadBufferSize SET in Sub Test_232
#End Region

#Region "Definations for comPort_Setup and test"
    Public Shared selected_com_port As String
    'Gets possible serial port names and puts in listbox
    Dim myTestReadString As String 'Used by Test 232 & other readbacks
#End Region
#Region "Definations for Command String"
    Dim myHex_Freq(3) As Byte
    Dim myHex_Amp(1) As Byte
    Dim myHex_Offset(1) As Byte
    'Command String
    Dim myCommandHex() As Byte = {&H31, &H0, &HA3, &HD7, &H1F, &H80} 'Default
    Dim Frequency As String
    Dim Phase_Step, PhstepB0, PhstepB1, PhstepB2 As Integer
#End Region
#End Region
#Region "Main Form Load"
    Private Sub Sig_Gen_Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Waveform_ListBox.SelectedIndex = 0
        Offset_ListBox.SelectedIndex = 16
        Amplitude_ListBox.SelectedIndex = 4
        Frequency = 1000
    End Sub
#End Region

#Region "Connect To COM Port"
    Sub GetSerialPortNames()
        ' Show all available COM ports.
        'Get SP data and write to ListBox
        For Each sp As String In My.Computer.Ports.SerialPortNames
            Com_Ports.Items.Add(sp)
        Next
    End Sub
    'Sub called to get serial port names
    Private Sub Get_Ports_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Get_Ports_Button.Click
        'Calls GetSerialPortnames()
        GetSerialPortNames()
        Test_TextBox.Text = "Select Com Port"
    End Sub
    'shows available serial ports
    'on select removes other names from list
    'calls initialise of mPort with selected name
    Private Sub Available_Ports_ListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Com_Ports.SelectedIndexChanged
        RemoveOtherItems()
        Initialize_232()
        Test_232()
        ''which_port_TextBox.Text = selected_com_port
    End Sub
    'Removes Other than selected Item from Available_Ports_ListBox
    Private Sub RemoveOtherItems()
        Dim selected_index, item_count, x As Integer
        ' Determine index value of selected item
        selected_index = Com_Ports.SelectedIndex
        item_count = Com_Ports.Items.Count

        selected_com_port = Com_Ports.Items(selected_index)

        ' Clear all items below selected
        For x = (item_count - 1) To (selected_index + 1) Step -1
            Com_Ports.Items.RemoveAt(x)
        Next x

        selected_index = Com_Ports.SelectedIndex
        item_count = Com_Ports.Items.Count

        ' Remove all items above selected item in the ListBox.
        For x = (selected_index - 1) To 0 Step -1
            Com_Ports.Items.RemoveAt(x)
        Next x
        '' Clear all selections in the ListBox.
        'Available_Ports_ListBox.ClearSelected()
        ' Remove all items below now top item in the ListBox.
    End Sub
    'Initializes selected port
    Private Sub Initialize_232()
        'Close the port before defining parameters
        If mPort.IsOpen Then
            mPort.Close()
        End If
        'COM port number selected
        mPort.PortName = selected_com_port
        'Speed of your link. 
        mPort.BaudRate = 9600 '115200
        'Data Terminal Ready signal. 
        'It's better to set this enable.
        mPort.DtrEnable = True
        'Data Ready to Send signal. 
        'It's better to set this enable.
        mPort.RtsEnable = True
        'Optional, If you want to send AT commands.
        mPort.NewLine = Chr(13)
        'Open the port if not already open
        If mPort.IsOpen Then
            'do nothing
        Else
            mPort.Open()
        End If
        'By Default Bits=8, Stop Bits=1, Parity=None
    End Sub

    'Test Communication with SigGen Hardware
    Private Sub Test_232()
        Dim myTestHex() As Byte = {&H37, &H0, &H0, &H0, &H0, &H80} '6 Byte Test Command
        'Dim myTestReadString As String 'defined earlier

        myBuffer = mPort.ReadBufferSize
        mPort.DiscardInBuffer() 'Clear Input Buffer
        mPort.Write(myTestHex, 0, 6)  ' Write Test Command

        Try
            mPort.ReadTimeout = 500
            Do
                myTestReadString = mPort.ReadLine
                If myTestReadString Is Nothing Then
                    Exit Do
                Else
                    Test_TextBox.Text = myTestReadString
                    Exit Try
                End If
            Loop
        Catch ex As TimeoutException
            Test_TextBox.Text = "Time Out."
            mPort.Close()
            'Finally
            'If mPort IsNot Nothing Then mPort.Close()
        End Try
    End Sub
    
#End Region
#Region "Commands"

    'Writes the command and reads back the acknowledge
    Private Sub Write_Command()

        myBuffer = mPort.ReadBufferSize
        mPort.DiscardInBuffer() 'Clear Input Buffer
        mPort.Write(myCommandHex, 0, 6)  ' Write Test Command

        Try
            mPort.ReadTimeout = 500
            Do
                myTestReadString = mPort.ReadLine
                If myTestReadString Is Nothing Then
                    Exit Do
                Else
                    Test_TextBox.Text = myTestReadString
                    Exit Try
                End If
            Loop
        Catch ex As TimeoutException
            Test_TextBox.Text = "Time Out."
            'mPort.Close()
            'Finally
            'If mPort IsNot Nothing Then mPort.Close()
        End Try

    End Sub


    

#End Region
#Region "Build and Write the Command Sequence"
    'Select waveform Type
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Waveform_ListBox.SelectedIndexChanged
        Dim Input_Text As String
        Input_Text = Waveform_ListBox.Text

        Select Case Input_Text
            Case "DDS Sin (0-50 kHz)"
                myCommandHex(0) = &H31
            Case "DDS Tri (0-50 kHz)"
                myCommandHex(0) = &H32
            Case "Sin 50 kHz"
                myCommandHex(0) = &H33
            Case "Tri 50 kHz"
                myCommandHex(0) = &H34
            Case "Sin 100 kHz"
                myCommandHex(0) = &H35
            Case "Tri 100 kHz"
                myCommandHex(0) = &H36
        End Select

        'Get Frequency Bits
        'B0_TextBox.Text = myCommandHex(0)

    End Sub

    'Set the Frequency
    Private Sub Frequency_TextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Frequency_TextBox.TextChanged
        Dim numericCheck As Boolean
        'Dim Phase_Step, PhstepB0, PhstepB1, PhstepB2 As Integer
        Frequency = Frequency_TextBox.Text
        'check for numeric
        numericCheck = IsNumeric(Frequency)
        If numericCheck = False Then
            MessageBox.Show("Not A Valid Number - Setting 1000")
            Frequency_TextBox.Text = 1000
            Frequency = 1000
        End If
        'limit check
        If Frequency > 50000 Then
            Frequency = 50000
            MessageBox.Show("Out of Limit - Setting 50000")
            Frequency_TextBox.Text = 5000
        ElseIf Frequency < 0 Then
            Frequency = 0
            MessageBox.Show("Out of Limit - Setting 0")
            Frequency_TextBox.Text = 0
        End If
        Phase_Step = Frequency * (16777216 / 372000)
        'Phase_Step = Frequency * (16777216 / 400000)
        'PhstepB2 = Phase_Step / 65536
        PhstepB2 = Math.Floor(Phase_Step / 65536)
        Phase_Step = Phase_Step - PhstepB2 * 65536
        'PhstepB1 = Phase_Step / 256
        PhstepB1 = Math.Floor(Phase_Step / 256)
        PhstepB0 = Phase_Step - PhstepB1 * 256
        PhstepB0 = Math.Floor(PhstepB0)
        myCommandHex(1) = PhstepB2
        myCommandHex(2) = PhstepB1
        myCommandHex(3) = PhstepB0
        'B1_TextBox.Text = myCommandHex(1)
        'B2_TextBox.Text = myCommandHex(2)
        'B3_TextBox.Text = myCommandHex(3)

    End Sub
    ' Set the Amplitude
    Private Sub Amplitude_ListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Amplitude_ListBox.SelectedIndexChanged
        Dim Amplitude As String
        Amplitude = Amplitude_ListBox.Text
        Select Case Amplitude
            Case "0.00 V"
                myCommandHex(4) = 0
            Case "0.25 V"
                myCommandHex(4) = 1
            Case "0.50 V"
                myCommandHex(4) = 2
            Case "0.75 V"
                myCommandHex(4) = 3
            Case "1.00 V"
                myCommandHex(4) = 4
            Case "1.25 V"
                myCommandHex(4) = 5
            Case "1.50 V"
                myCommandHex(4) = 6
            Case "1.75 V"
                myCommandHex(4) = 7
            Case "2.00 V"
                myCommandHex(4) = 8
            Case "2.25 V"
                myCommandHex(4) = 9
            Case "2.50 V"
                myCommandHex(4) = 10
            Case "2.75 V"
                myCommandHex(4) = 11
            Case "3.00 V"
                myCommandHex(4) = 12
            Case "3.25 V"
                myCommandHex(4) = 13
            Case "3.50 V"
                myCommandHex(4) = 14
            Case "3.75 V"
                myCommandHex(4) = 15
            Case "4.00 V"
                myCommandHex(4) = 16
            Case "4.25 V"
                myCommandHex(4) = 17
            Case "4.50 V"
                myCommandHex(4) = 18
            Case "4.75 V"
                myCommandHex(4) = 19
            Case "5.00 V"
                myCommandHex(4) = 20
            Case "5.25 V"
                myCommandHex(4) = 21
            Case "5.50 V"
                myCommandHex(4) = 22
            Case "5.75 V"
                myCommandHex(4) = 23
            Case "6.00 V"
                myCommandHex(4) = 24
            Case "6.25 V"
                myCommandHex(4) = 25
            Case "6.50 V"
                myCommandHex(4) = 26
            Case "6.75 V"
                myCommandHex(4) = 27
            Case "7.00 V"
                myCommandHex(4) = 28
            Case "7.25 V"
                myCommandHex(4) = 29
            Case "7.50 V"
                myCommandHex(4) = 30
            Case "7.75 V"
                myCommandHex(4) = 31
        End Select

        'B4_TextBox.Text = myCommandHex(4)

    End Sub
    'Set the offset
    Private Sub Offset_ListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Offset_ListBox.SelectedIndexChanged
        Dim Offset As String
        Offset = Offset_ListBox.Text

        Select Case Offset
            Case "+4.000 V"
                myCommandHex(5) = 255 - 0
            Case "+3.750 V"
                myCommandHex(5) = 256 - 8
            Case "+3.500 V"
                myCommandHex(5) = 256 - 16
            Case "+3.250 V"
                myCommandHex(5) = 256 - 24
            Case "+3.000 V"
                myCommandHex(5) = 256 - 32
            Case "+2.750 V"
                myCommandHex(5) = 256 - 40
            Case "+2.500 V"
                myCommandHex(5) = 256 - 48
            Case "+2.250 V"
                myCommandHex(5) = 256 - 56
            Case "+2.000 V"
                myCommandHex(5) = 256 - 64
            Case "+1.750 V"
                myCommandHex(5) = 256 - 72
            Case "+1.500 V"
                myCommandHex(5) = 256 - 80
            Case "+1.250 V"
                myCommandHex(5) = 256 - 88
            Case "+1.000 V"
                myCommandHex(5) = 256 - 96
            Case "+0.750 V"
                myCommandHex(5) = 256 - 104
            Case "+0.500 V"
                myCommandHex(5) = 256 - 112
            Case "+0.250 V"
                myCommandHex(5) = 256 - 120
            Case "0.000 V"
                myCommandHex(5) = 128
            Case "-0.250 V"
                myCommandHex(5) = 256 - 136
            Case "-0.500 V"
                myCommandHex(5) = 256 - 144
            Case "-0.750 V"
                myCommandHex(5) = 256 - 152
            Case "-1.000 V"
                myCommandHex(5) = 256 - 160
            Case "-1.250 V"
                myCommandHex(5) = 256 - 168
            Case "-1.500 V"
                myCommandHex(5) = 256 - 176
            Case "-1.750 V"
                myCommandHex(5) = 256 - 184
            Case "-2.000 V"
                myCommandHex(5) = 256 - 192
            Case "-2.250 V"
                myCommandHex(5) = 256 - 200
            Case "-2.500 V"
                myCommandHex(5) = 256 - 208
            Case "-2.750 V"
                myCommandHex(5) = 256 - 216
            Case "-3.000 V"
                myCommandHex(5) = 256 - 224
            Case "-3.250 V"
                myCommandHex(5) = 256 - 232
            Case "-3.500 V"
                myCommandHex(5) = 256 - 240
            Case "-3.750 V"
                myCommandHex(5) = 256 - 248
            Case "-4.000 V"
                myCommandHex(5) = 0
        End Select
        'B5_TextBox.Text = myCommandHex(5)
    End Sub
    'Write the command string
    Private Sub Run_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Run_Button.Click

        myBuffer = mPort.ReadBufferSize
        mPort.DiscardInBuffer() 'Clear Input Buffer

        mPort.Write(myCommandHex, 0, 6) 'write the Command String

        Try
            mPort.ReadTimeout = 500
            Do
                myTestReadString = mPort.ReadLine
                If myTestReadString Is Nothing Then
                    Exit Do
                Else
                    Test_TextBox.Text = myTestReadString
                    Exit Try
                End If
            Loop
        Catch ex As TimeoutException
            Test_TextBox.Text = "Time Out."
            'mPort.Close()
            'Finally
            'If mPort IsNot Nothing Then mPort.Close()
        End Try
    End Sub

#End Region

    
    Private Sub Exit_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exit_Button.Click
        Me.Close()
    End Sub
End Class