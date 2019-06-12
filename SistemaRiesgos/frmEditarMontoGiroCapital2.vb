Imports System.Data
Imports System.Data.SqlClient
Public Class frmEditarMontoGiroCapital2
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter
    Public _TABLA29 As DataTable = New DataTable
    Private Sub frmEditarMontoGiroCapital2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        EditarMontoSolicitud()
    End Sub

    Sub EditarMontoSolicitud()
        Dim RECIBERESPUESTA As DialogResult
        Dim TOMAMONTO As String = ""
        Dim ID_SOLICITUD As String = ""
        Dim USUARIO As String
        'Try
        ID_SOLICITUD = Trim(Datadetalle.Rows(0).Cells(0).Value())
        TOMAMONTO = Trim(textMontoNuevo.Text)
        USUARIO = frmPerfil.CbmUsuario.SelectedItem
        'MsgBox(USUARIO)
        If Trim(TextTiposolciitud.Text) = "RENUNCIA" Then
            RECIBERESPUESTA = MessageBox.Show("Esta Solicitud de giro de capital  es del tipo  'RENUNCIA'  esta seguro  que desea cambiar el valor del monto", "RENUNCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            ' RECIBERESPUESTA = MessageBox.Show("Los montos concuerdan  esta seguro de realizar indexacion", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        ElseIf Trim(TextTiposolciitud.Text) = "FALLECIMIENTO" Then
            RECIBERESPUESTA = MessageBox.Show("Esta Solicitud de giro de capital  es del tipo  'FALLECIMIENTO'  esta seguro  que desea cambiar el valor del monto", "FALLECIMIENTO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        ElseIf Trim(TextTiposolciitud.Text) = "GIRO CAPITAL" Then
            RECIBERESPUESTA = MessageBox.Show("Esta Solicitud de giro de capital  es del tipo  'GIRO CAPITAL'  esta seguro  que desea cambiar el valor del monto", "GIRO CAPITAL", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        End If

        If RECIBERESPUESTA = Windows.Forms.DialogResult.Yes Then
            If ID_SOLICITUD <> "" And TOMAMONTO <> "" Then
                Dim conexiones60 As New CConexion
                conexiones60.conexion()
                _adaptador.UpdateCommand = New SqlCommand("UPDATE [_RIESGO_SOLICITUD_GIRO_CAPITAL]  set [MONTO_SOLICITUD] ='" + Trim(TOMAMONTO) + "' ,[MODIFICAMONTO]='" + USUARIO.ToString.Trim + "',FECHAMODIFICAMONTO=GETDATE()  where ID_SOLICITUD= '" + ID_SOLICITUD + "' ", conexiones60._conexion)
                conexiones60.abrir()
                _adaptador.UpdateCommand.Connection = conexiones60._conexion
                _adaptador.UpdateCommand.ExecuteNonQuery()
                conexiones60.cerrar()
                frmEstadosGiroCapital.IdentificarEstados()
                ' Me.Close()
                actualizagrilla(ID_SOLICITUD)
                frmEditarMontosSolicitudGiroCapital.estadosgenerales()
            Else
            End If
            'Catch
        ElseIf RECIBERESPUESTA = Windows.Forms.DialogResult.No Then
        End If
    End Sub


    Sub AUDITORIAMODIFICAMONTO()
        Dim USUARIO As String
        Dim Contrasena As String = ""
        Dim Departamento As String = ""
        USUARIO = frmPerfil.CbmUsuario.SelectedItem
        Dim conexiones2 As New CConexion
        conexiones2.conexion()
        Dim command2 As SqlCommand = New SqlCommand("SELECT dbo.FU_DESENCRIPTA(ENSUPERCONTRASENA),DEPARTAMENTO FROM _RIESGO_PERFIL WHERE USUARIO='" + USUARIO.ToString.Trim + "'", conexiones2._conexion)
        conexiones2.abrir()

        Dim reader2 As SqlDataReader = command2.ExecuteReader()
        If reader2.HasRows Then
            Do While reader2.Read()
                Contrasena = reader2(0).ToString
                Departamento = reader2(1).ToString
            Loop
        Else
        End If
        reader2.Close()
    End Sub

                    


    Sub actualizagrilla(ByVal ID_SOLICITUD As String)
        ' Dim ID_SOLICITUD As String = ""
        ' ID_SOLICITUD = Trim(Datadetalle.Rows(0).Cells(0).Value())
        _TABLA29.Rows.Clear()
        _TABLA29.Columns.Clear()
        Datadetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        Dim conexiones1306 As New CConexion
        conexiones1306.conexion()
        _adaptador.SelectCommand = New SqlCommand("select  ID_SOLICITUD ,SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD , ESTADO_SOLICITUD , dbo.puntos(MONTO_SOLICITUD) as MONTO, USUARIO ,NOMBRE_SOCIO   from [_RIESGO_SOLICITUD_GIRO_CAPITAL] where ID_SOLICITUD = '" + ID_SOLICITUD + "' ", conexiones1306._conexion)
        conexiones1306.abrir()
        _adaptador.Fill(_TABLA29)
        Datadetalle.DataSource = _TABLA29
        conexiones1306.cerrar()
    End Sub
   
    Private Sub textMontoNuevo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textMontoNuevo.TextChanged
        If Not IsNumeric(Replace(Trim(textMontoNuevo.Text), ".", "")) Then
            MsgBox("Debe ingresar un valor numerico")
        Else
        End If
    End Sub
End Class