Public Class FrmCierreActualizacion
    Dim METODO As CCEstadosGeneral = New CCEstadosGeneral
    Declare Sub ExitProcess Lib "kernel32" (ByVal uExitCode As Long)
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        METODO.crear()
        System.Diagnostics.Process.Start("C:\Sistemas\Actualiza\ACTUALIZARIESGO.BAT")
        ExitProcess(9)
    End Sub

    Private Sub FrmCierreActualizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class