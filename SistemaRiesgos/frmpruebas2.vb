Public Class frmpruebas2

    Private Sub frmpruebas2_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
 
    End Sub




    Private Sub frmpruebas2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TXTTEXT.Select()
    End Sub

    Private Sub TXTTEXT_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTTEXT.KeyUp
        Me.Dispose()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        frmRentas.Show()
        PRUEBAS2.Show()
        PRUEBAS2.Location = New Point(2000, 100)

        frmRentas.WindowState = 2
        PRUEBAS2.WindowState = 2

    End Sub


End Class