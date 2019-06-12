Public Class AVISO

    Private Sub AVISO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnAceptarError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptarError.Click
        frmPrepago.Close()
        frmEvaluar.Close()
        Me.Close()
    End Sub

    Private Sub BtnAceptarVerificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptarVerificar.Click
        Me.Visible = False
        frmEvaluar.Enabled = True
    End Sub
End Class