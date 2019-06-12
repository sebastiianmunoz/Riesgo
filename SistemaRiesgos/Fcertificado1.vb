Imports System.IO

Public Class Fcertificado1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FCertificados.Show()
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        TextBox1.Text = Puntos(TextBox1.Text)
        TextBox1.Select(TextBox1.Text.Length, 0)
    End Sub




    'Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
    '    TextBox1.Text = Format(TextBox1.Text, "##,##")
    'End Sub


    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    TextBox1.Text = Format(Integer.Parse(TextBox1.Text), "##,##00.00")
    'End Sub





    'Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
    '    Dim text As String = TextBox1.Text
    '    ''Obtenemos el text sin separadores decimales
    '    Dim trimedText As String = text.Replace(".", "")

    '    If trimedText.Length Mod 3 = 0 AndAlso text.ElementAt(text.Length - 1) <> "." Then
    '        TextBox1.Text += "."
    '        TextBox1.Select(TextBox1.Text.Length, 0)
    '    End If
    'End Sub

    Public Function Puntos(ByVal strValor As String, Optional ByVal intNumDecimales As Integer = 0) As String

        Dim strAux As String
        Dim strComas As String
        Dim strPuntos As String
        Dim intX As Integer
        Dim bolMenos As Boolean = False

        strComas = ""
        strValor = strValor.Replace(".", "")
        If InStr(strValor, ",") > 0 Then
            strAux = Mid(strValor, 1, InStr(strValor, ",") - 1)
            strComas = Mid(strValor, InStr(strValor, ","))
        Else
            strAux = strValor
        End If

        If Mid(strAux, 1, 1) = "-" Then
            bolMenos = True
            strAux = Mid(strAux, 2)
        End If

        strPuntos = strAux
        strAux = ""
        While strPuntos.Length > 3
            strAux = "." & Mid(strPuntos, strPuntos.Length - 2, 3) & strAux
            strPuntos = Mid(strPuntos, 1, strPuntos.Length - 3)
        End While
        If intNumDecimales <> 0 Then
            If strComas = "" Then strComas = ","
            For intX = Len(strComas) - 1 To intNumDecimales - 1
                strComas = strComas & "0"
            Next

        End If
        strAux = strPuntos & strAux & strComas
        If Mid(strAux, 1, 1) = "." Then strAux = Mid(strAux, 2)
        If bolMenos Then strAux = "-" & strAux

        Return strAux
    End Function

    Private Sub txttexto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttexto.KeyUp
        txtNumero.Text = (txttexto.Text.Length) - 250
    End Sub




    Private Sub Fcertificado1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'AxAcroPDF1.LoadFile("c:\documento.pdf")
        'Dim myStream As Stream = Nothing
        'Dim openFileDialog1 As New OpenFileDialog()

        'openFileDialog1.InitialDirectory = "c:\"
        'openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        'openFileDialog1.FilterIndex = 2
        'openFileDialog1.RestoreDirectory = True

        'If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
        '    Try
        '        myStream = openFileDialog1.OpenFile()
        '        If (myStream IsNot Nothing) Then
        '            ' Insert code to read the stream here.
        '        End If
        '    Catch Ex As Exception
        '        MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
        '    Finally
        '        ' Check this again, since we need to make sure we didn't throw an exception on open.
        '        If (myStream IsNot Nothing) Then
        '            myStream.Close()
        '        End If
        '    End Try
        'End If



        'openFileDialog1.ShowDialog()
        'AxAcroPDF1.src = openFileDialog1.FileName


        AxWebBrowser1.Navigate("http://www.dicom.cl/")
        

    End Sub
End Class