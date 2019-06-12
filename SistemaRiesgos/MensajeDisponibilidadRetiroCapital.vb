Public Class MensajeDisponibilidadRetiroCapital
    ' Dim MOSTRAR As String = ""

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'MOSTRAR = "SI"
        'Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' MOSTRAR = "NO"
        If Radiosi.Checked = True And Radiono.Checked = False Then
            textsino.Text = "SI"
        ElseIf Radiono.Checked = True And Radiosi.Checked = False Then
            textsino.Text = "NO"
        ElseIf Radiono.Checked = False And Radiosi.Checked = False Then
            Label1.Visible = True
        End If
        Me.Visible = False
        'MsgBox(textsino.Text)
        'Me.Close()
    End Sub

    Private Sub MensajeDisponibilidadRetiroCapital_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Visible = False
    End Sub

End Class