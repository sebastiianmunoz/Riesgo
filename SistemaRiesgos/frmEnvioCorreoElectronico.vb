Imports System.Net
Imports System.Net.Mail
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class frmEnvioCorreoElectronico
    Private correos As New MailMessage
    Private envios As New SmtpClient
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Me.OpenFileDialog1.ShowDialog()
            If Me.OpenFileDialog1.FileName <> "" Then
                Textruta.Text = Me.OpenFileDialog1.FileName
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnenviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnenviar.Click
        'enviarcorreo(TextDE.Text, TextCONTRASEÑA.Text, txtmensaje1.Text, TextAsunto.Text, TextPARA.Text, Textruta.Text)
        enviarcorreo(TextDE.Text, TextCONTRASEÑA.Text, textmensajecorreo2muestra.Text, TextAsunto.Text, TextPARA.Text, Textruta.Text)
    End Sub

    Sub enviarcorreo(ByVal emisor As String, ByVal password As String, ByVal mensaje As String, ByVal asunto As String, ByVal destinatario As String, ByVal ruta As String)

        Dim ID_SOLICITUD As String = ""
        ID_SOLICITUD = Trim(TextID.Text)
        Dim ENVIOCARTAVERIFICA As String = ""
        Dim conexiones2 As New CConexion
        conexiones2.conexion()
        Dim command2 As SqlCommand = New SqlCommand("SELECT CORREOENVIOCARTA FROM  [_RIESGO_SOLICITUD_GIRO_CAPITAL] where ID_SOLICITUD='" + ID_SOLICITUD + "' ", conexiones2._conexion)
        conexiones2.abrir()
        Dim reader2 As SqlDataReader = command2.ExecuteReader()
        If reader2.HasRows Then
            Do While reader2.Read()
                ENVIOCARTAVERIFICA = (reader2(0).ToString)
            Loop
        Else
        End If
        reader2.Close()
        conexiones2.cerrar()

        If Trim(ENVIOCARTAVERIFICA) = 0 Then
            Auditoriaenviomensaje()
            Try
                correos.To.Clear()
                correos.Body = ""
                'correos.Subject = ""
                correos.Body = mensaje
                correos.Subject = asunto
                correos.SubjectEncoding = System.Text.Encoding.UTF8
                correos.IsBodyHtml = True
                correos.BodyEncoding = System.Text.Encoding.UTF8
                correos.To.Add(Trim(destinatario))
                If ruta <> "" Then
                    Dim archivo As Net.Mail.Attachment = New Net.Mail.Attachment(ruta)
                    correos.Attachments.Add(archivo)
                End If
                correos.From = New MailAddress(emisor)
                envios.Credentials = New NetworkCredential(emisor, password)

                'datos importantes no modificables para tneer  acceso  a las  cuentas 
                ' envios.Host = "smtp.live.com"
                'envios.Host = "smtp.domain.com"
                envios.Host = "mail.lautarorosas.cl"
                ' envios.Host = " smtp.domain.com"

                envios.Port = 25
                'envios.Port = 465
                'envios.Port = 587

                envios.EnableSsl = True
                envios.Send(correos)
                MsgBox("El mensajes  fue enviado correctamente", MsgBoxStyle.Information, "mensaje")
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Mensajeria 1.0 vb.net", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf Trim(ENVIOCARTAVERIFICA) = 1 Then

            MessageBox.Show("Este socio ya recibió el correo con anterioridad ", "Información envio correo ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ElseIf Trim(ENVIOCARTAVERIFICA) = "" Then

            MessageBox.Show(" Contactarse con el administrador  ", "Información envio correo ", MessageBoxButtons.OK, MessageBoxIcon.Information)


        End If



        
    End Sub

    Sub Auditoriaenviomensaje()

        Dim CORREOEJECUTIVA As String = ""
        Dim CORREORECPECION As String = ""
        Dim ID_SOLICITUD As String = ""

        ID_SOLICITUD = TextID.Text
        CORREOEJECUTIVA = Trim(TextDE.Text)
        CORREORECPECION = Trim(TextPARA.Text)

        Dim conexiones As New CConexion
        conexiones.conexion()
        _adaptador.InsertCommand = New SqlCommand("INSERT INTO [_RIESGO_GIRO_CAPITAL_ENVIO_CARTA_SOCIO]  ([CORREOEJECUTIVA],[FECHAENVIO],[CORREORECEPCION],[ID_SOLICITUD])VALUES('" + CORREOEJECUTIVA + "', GETDATE() ,'" + CORREORECPECION + "','" + ID_SOLICITUD + "')", conexiones._conexion)
        conexiones.abrir()
        _adaptador.InsertCommand.Connection = conexiones._conexion
        _adaptador.InsertCommand.ExecuteNonQuery()
        conexiones.cerrar()


        If Trim(CORREORECPECION) = "secretaria.gerencia@lautarorosas.cl" Then

        ElseIf Trim(CORREORECPECION) <> "secretaria.gerencia@lautarorosas.cl" Then

            Dim conexiones60 As New CConexion
            conexiones60.conexion()
            _adaptador.UpdateCommand = New SqlCommand("UPDATE [_RIESGO_SOLICITUD_GIRO_CAPITAL]  set [CORREOENVIOCARTA] =1 where ID_SOLICITUD= '" + ID_SOLICITUD + "' ", conexiones60._conexion)
            conexiones60.abrir()
            _adaptador.UpdateCommand.Connection = conexiones60._conexion
            _adaptador.UpdateCommand.ExecuteNonQuery()
            conexiones60.cerrar()
        End If





    End Sub



    Private Sub frmEnvioCorreoElectronico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TextPARA.IsReadOnly()
        Dim Validarfecha As String = Trim(TextFECHA.Text)
        'MsgBox(Validarfecha)
        'MsgBox(Validarfecha.Substring(0, 2))
        'MsgBox(Validarfecha.Substring(3, 2))
        ' If Validarfecha.Substring(0, 2) = "05" And Validarfecha.Substring(3, 2) = "05" Then
        ' textmensajecorreo2muestra.Text = Textencabezado.Text + Textsucursal.Text + txtmensaje1.Text + TxtNombre.Text + txtmensaje2remplaza.Text + txtmensaje3.Text
        '  Else
        ' textmensajecorreo2muestra.Text = Textencabezado.Text + Textsucursal.Text + txtmensaje1.Text + TxtNombre.Text + txtmensaje2.Text + TextFECHA.Text + txtmensaje3.Text
        ' End If
        'ElseIf Validarfecha.Substring(2, 2) = "05" Then
        'End If
        'textmensajecorreo2muestra.Text = Textencabezado.Text + Textsucursal.Text + txtmensaje1.Text + TxtNombre.Text + txtmensaje2.Text + TextFECHA.Text + txtmensaje3.Text
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btngenerarcarta.Click
        frmReporteCartagirocapital.Visible = True
        'textmensajecorreo2muestra.Text = txtmensaje1.Text + Txtputonombre.Text + txtmensaje2.Text + TextFECHA.Text + txtmensaje3.Text
    End Sub

    Private Sub textmensajecorreo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmensaje1.TextChanged
    End Sub

    Private Sub Txtputonombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNombre.TextChanged
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'progre()
    End Sub

    Private Sub txtmensaje2remplaza_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmensaje2remplaza.TextChanged
    End Sub
End Class