Imports System.Data.SqlClient
Imports System.Data
Imports System.IO

Public Class frmCaptacionesTXT

    Public _adaptador As SqlDataAdapter = New SqlDataAdapter
    Public _tabla As DataTable = New DataTable


    Private Sub frmCaptacionesTXT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _tabla.Rows.Clear()
        _tabla.Columns.Clear()
        Dim conexiones4 As New CConexion
        conexiones4.conexion()

        _adaptador.SelectCommand = New SqlCommand("SELECT TEXT FROM _COBRANZA_CAPTACIONES_TXT", conexiones4._conexion)
        conexiones4.abrir()
        _adaptador.Fill(_tabla)
        DGCaptaciones.DataSource = _tabla

        conexiones4.cerrar()
    End Sub

   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If DGCaptaciones.Rows.Count <> 0 Then

            If Not FileIO.FileSystem.DirectoryExists("C:\1890") Then
                FileIO.FileSystem.CreateDirectory("C:\1890")
            End If

            Dim sFile As String = "C:\1890\702863007.txt"

            Dim _Line As String = Nothing


            If File.Exists(sFile) = True Then 'Si el archivo existe, lo elimina antes
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                 FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If


            Dim swFile As StreamWriter = New StreamWriter(sFile)


            With DGCaptaciones 'DGCaptaciones es el nombre de mi DataGridView

                For i = 0 To .RowCount - 1

                    _Line = .Rows(i).Cells(0).Value
                    swFile.WriteLine(_Line)
                Next
            End With
            swFile.Close()

            MsgBox("Txt Generado en Disco C, Carpeta->1890")

        Else

            MsgBox("Error al Generar el Txt, No existen datos")

        End If

    End Sub

End Class