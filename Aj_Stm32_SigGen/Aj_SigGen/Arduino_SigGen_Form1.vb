Imports System
Imports System.IO.Ports
Imports System.Globalization
Imports System.Threading


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
    Dim myCommandHex() As Byte = {&H53, &H3, &H70, &HDC} 'Default Sin 5kHz
    Dim myBreakCmdHex() As Byte = {&H42, &H42, &H42, &H42} 'Break Cmd
    Dim Frequency As String
    Dim Phase_Step, PhstepB0, PhstepB1, PhstepB2 As Integer
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
        'Speed of your link. 
        mPort.BaudRate = 37900 '9600 '115200
        'Data Terminal Ready signal. 
        'It's better to set this enable.
        mPort.DtrEnable = False ' True
        'Data Ready to Send signal. 
        'It's better to set this enable.
        mPort.RtsEnable = False 'True
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
#Region "Commands"

    'Writes the command and reads back the acknowledge
    Private Sub Write_Command()

        myBuffer = mPort.ReadBufferSize
        mPort.DiscardInBuffer() 'Clear Input Buffer
        mPort.Write(myBreakCmdHex, 0, 4) 'write the break command
        Thread.Sleep(100)
        mPort.Write(myCommandHex, 0, 4)  ' Write Test Command

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
                myCommandHex(0) = &H53
            Case "DDS Tri (0-50 kHz)"
                myCommandHex(0) = &H54
            Case "DDS RampUp (0-50kHz)"
                myCommandHex(0) = &H55
            Case "DDS RampDn (0-50kHz)"
                myCommandHex(0) = &H44
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
            MessageBox.Show("Out of Limit - Setting 5000")
            Frequency_TextBox.Text = 5000
        ElseIf Frequency < 0 Then
            Frequency = 0
            MessageBox.Show("Out of Limit - Setting 0")
            Frequency_TextBox.Text = 0
        End If
        Phase_Step = Frequency * (16777216 / 372093)

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
    
    
            
    'Write the command string
    Private Sub Run_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Run_Button.Click

        myBuffer = mPort.ReadBufferSize
        mPort.DiscardInBuffer() 'Clear Input Buffer

        mPort.Write(myBreakCmdHex, 0, 4) 'write the break command
        Thread.Sleep(100)
        mPort.Write(myCommandHex, 0, 4) 'write the Command String

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
        mPort.Write(myBreakCmdHex, 0, 4) 'write the break command
        Thread.Sleep(100)
        Me.Close()
    End Sub

    
End Class