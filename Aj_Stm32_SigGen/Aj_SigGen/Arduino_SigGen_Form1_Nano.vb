Imports System
Imports System.IO
Imports System.IO.Ports
Imports System.Globalization
Imports System.Threading
Imports System.Math


Public Class Sig_Gen_Form1
#Region "Definations"
#Region "Definitions for Connect to COM Port "
    'Definitions for COM Port Connection
    'Define  serial port instance
    Dim mPort As New SerialPort
    Dim myBuffer As Integer = 25
#End Region

#Region "Definations for comPort_Setup and test"
    Public Shared selected_com_port As String
    'Gets possible serial port names and puts in listbox
    Dim myTestReadString As String 'Used by Test 232 & other readbacks
#End Region
#Region "Definations for Command String"
    Dim myHex_Freq(3) As Byte
    'Command String
    Dim myCommandHex() As Byte = {&H73, &H3, &H70, &HDC} 'Default Sin 5kHz
    Dim myBreakCmdHex() As Byte = {&H42, &H42, &H42, &H42} 'Break Cmd
    Dim myLoadCmdHex() As Byte = {&H4C, &H4C, &H4C, &H4C} 'Load Command followed by 128 Data
    Dim Frequency As String
    Dim Phase_Step, PhstepB0, PhstepB1, PhstepB2 As Integer
#End Region
#Region "Definations for Arbitrary Data"
    Dim arb_data(128) As Byte 'actually 129 bytes long
    Dim strFileName As String
#End Region
#End Region
#Region "Main Form Load"
    Private Sub Sig_Gen_Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Waveform_ListBox.SelectedIndex = 0
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
        ' Set the baud rate, parity, data bits, and stop bits
        mPort.BaudRate = 57600
        mPort.Parity = Parity.None
        mPort.DataBits = 8
        mPort.StopBits = StopBits.One

        'Appropriate settings for the usbser.sys driver
        mPort.Handshake = Handshake.None
        mPort.DtrEnable = True
        mPort.RtsEnable = True

        If mPort.IsOpen Then
            'do nothing
        Else
            mPort.Open()
        End If
        'By Default Bits=8, Stop Bits=1, Parity=None
    End Sub

    'Test Communication with SigGen Hardware
    Private Sub Test_232()
        Dim myTestHex() As Byte = {&H49, &H3, &H70, &HDC} '4 Byte Test Command Identify
        'Dim myTestReadString As String 'defined earlier

        myBuffer = mPort.ReadBufferSize
        mPort.DiscardInBuffer() 'Clear Input Buffer

        'Thread.Sleep(100)
        mPort.Write(myTestHex, 0, 4)  ' Write Test Command


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

#Region "Build and Write the Command Sequence"
    'Select waveform Type
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Waveform_ListBox.SelectedIndexChanged
        Dim Input_Text As String
        Input_Text = Waveform_ListBox.Text

        Select Case Input_Text
            Case "DDS Sin (0-50 kHz)"
                myCommandHex(0) = &H53
            Case "DDS Tri (0-50 kHz)"
                myCommandHex(0) = &H54
            Case "DDS RampUp (0-50kHz)"
                myCommandHex(0) = &H55
            Case "DDS RampDn (0-50kHz)"
                myCommandHex(0) = &H44
            Case "DDS Arb (0-50kHz)"
                myCommandHex(0) = &H41
                Open_DDS_File()
                Read_Data()
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
        If Frequency > 500000 Then
            Frequency = 500000
            MessageBox.Show("Out of Limit - Setting 500000")
            Frequency_TextBox.Text = 500000
        ElseIf Frequency < 0 Then
            Frequency = 0
            MessageBox.Show("Out of Limit - Setting 0")
            Frequency_TextBox.Text = 0
        End If
        'Phase_Step = Frequency * (16777216 / 372093)

        Phase_Step = Frequency * (16777216 / 512000)
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
    

    'Write the command string
    Private Sub Run_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Run_Button.Click

        myBuffer = mPort.ReadBufferSize
        mPort.DiscardInBuffer() 'Clear Input Buffer
        'mPort.Write(myBreakCmdHex, 0, 4) 'write the break command
        Thread.Sleep(100)
        mPort.Write(myCommandHex, 0, 4)  ' Write Freq and Waveform Command 
    End Sub

#End Region
#Region "Arbitrary"


    Private Sub Read_Data()
        ReadCSVFileToArray()
        mPort.Write(myBreakCmdHex, 0, 4) 'write the break command
        Thread.Sleep(100)
        mPort.Write(myLoadCmdHex, 0, 4) 'write the Load Command String
        Thread.Sleep(100)
        mPort.Write(arb_data, 0, 128)
    End Sub

    Private Sub ReadCSVFileToArray()
        'Dim strfilename As String
        Dim num_rows As Long
        Dim num_cols As Long
        Dim x As Integer
        Dim y As Integer
        Dim strarray(1, 1) As String
        ' Dim arb_data(127) As Byte
        ' Load the file.

        'strfilename = "c:\test\test.csv"

        'Check if file exist
        If File.Exists(strFileName) Then
            Dim tmpstream As StreamReader = File.OpenText(strFileName)
            Dim strlines() As String
            Dim strline() As String


            'Load content of file to strLines array
            strlines = tmpstream.ReadToEnd().Split(Environment.NewLine)

            ' Redimension the array.
            num_rows = UBound(strlines)
            strline = strlines(0).Split(",")
            num_cols = UBound(strline)
            ReDim strarray(num_rows, num_cols)

            ' Copy the data into the array.
            For x = 0 To num_rows
                strline = strlines(x).Split(",")
                For y = 0 To num_cols
                    strarray(x, y) = strline(y)
                Next
            Next

            For x = 0 To 127 'num_rows - 1
                arb_data(x) = Convert.ToByte(strarray(x, 0))
            Next


        End If

    End Sub

    Private Sub Open_DDS_File()
        Dim fd As OpenFileDialog = New OpenFileDialog()
        'Dim strFileName As String

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        'fd.Filter = "All files (*.*) |*.*|All files (*.*)|*.*"
        'based on    "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        fd.Filter = "csv files (*.csv)|*.csv"
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            strFileName = fd.FileName
        End If

    End Sub
#End Region
#Region "Exit"
    Private Sub Exit_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exit_Button.Click
        If mPort.IsOpen Then
            mPort.Write(myBreakCmdHex, 0, 4) 'write the break command
        End If
        Thread.Sleep(100)
        Me.Close()
    End Sub
#End Region

End Class

