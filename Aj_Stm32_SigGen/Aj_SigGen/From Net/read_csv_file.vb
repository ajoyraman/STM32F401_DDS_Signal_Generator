Private Sub ReadCSVFileToArray()
 Dim strfilename As String
 Dim num_rows As Long
 Dim num_cols As Long
 Dim x As Integer
 Dim y As Integer
 Dim strarray(1, 1) As String

 ' Load the file.
 strfilename = "test.csv"

 'Check if file exist
 If File.Exists(strfilename) Then
  Dim tmpstream As StreamReader = File.OpenText(strfilename)
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

  ' Display the data in textbox
  For x = 0 To num_rows
   For y = 0 To num_cols
    TextBox1.Text = TextBox1.Text & strarray(x, y) & ","
   Next
   TextBox1.Text = TextBox1.Text & Environment.NewLine
  Next

 End If

End Sub