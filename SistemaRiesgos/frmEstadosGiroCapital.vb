Imports System.Data
Imports System.Data.SqlClient
Public Class frmEstadosGiroCapital
    Public _Tabla As DataTable = New DataTable
    Public _Tabla29 As DataTable = New DataTable
    Public _Tabla30 As DataTable = New DataTable
    Public _Adaptador As SqlDataAdapter = New SqlDataAdapter
    Private xIdMenor As Integer
    Private xTodasId As String
    Private xOrden As String
    Public cambiaordenculumnasgrilla As Boolean = False
    Private Sub frmEstadosGiroCapital_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        xTodasId = "No"
        xOrden = "ID"
        xIdMenor = 18470  ' <<==== NO TOCAR ESTE NUMERO, CORRESPONDE A LA PRIMERA ID A QUIEN SE LE CONSEDIO AYUDA SOCIAL
        txtSocioBuscar.Text = ""
        txtIdBuscar.Text = ""
        cboSucursal.SelectedItem = "TODAS"
        cboEstadoCapital.SelectedItem = "TODOS"

        Textdesdedia.Text = "01"
        Textdesdemes.Text = "01"
        Textdesdeaño.Text = "2015"
        Texthastadia.Text = Now.Day
        TextHASTAMES.Text = Now.Month
        TextHASTAAÑO.Text = Now.Year


        Gridestadogiros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

        cboEstadoCapital.Items.Add("TODOS")
        cboEstadoCapital.Items.Add("PREAPROBADO")
        cboEstadoCapital.Items.Add("RECONSIDERACIÓN")
        cboEstadoCapital.Items.Add("PENDIENTE")
        cboEstadoCapital.Items.Add("APROBADO")
        cboEstadoCapital.Items.Add("RECHAZADA")
        cboEstadoCapital.Items.Add("PAGADO")
        cboEstadoCapital.Items.Add("ANULADA")
        cboEstadoCapital.SelectedItem = "TODOS"

        cboSucursal.Items.Add("TODAS")
        Dim Conexion As New CConexion
        Conexion.conexion()
        Dim command As SqlCommand = New SqlCommand("SELECT NOMBRECAJA FROM _SUCURSAL WHERE VIGENTE = 1 ORDER BY CODCAJA", Conexion._conexion)
        Conexion.abrir()
        Dim Lector As SqlDataReader = command.ExecuteReader()
        If Lector.HasRows Then
            Do While Lector.Read()
                cboSucursal.Items.Add(Lector(0).ToString)
            Loop
        Else
        End If
        Lector.Close()
        Conexion.cerrar()

        cboSucursal.SelectedItem = "TODAS"
        Consulta()
    End Sub

    Sub Consulta()
        lblCalculando.Visible = True
        lblCalculando.Refresh()
        LimpiaGrid()

        cambiaordenculumnasgrilla = True

        Dim Conexiones As New CConexion
        Conexiones.conexion()
        Dim Command As New SqlCommand
        Command = New SqlCommand("_LAUCOOP_PRELACION_ESTADO_TODAS", conexiones._conexion)
        Command.CommandType = CommandType.StoredProcedure
        _adaptador = New SqlDataAdapter(Command)
        With Command.Parameters
            'Envío los parámetros que necesito
            .Add(New SqlParameter("@NROSOCIO", SqlDbType.VarChar)).Value = "0" + txtSocioBuscar.Text.Trim()
            .Add(New SqlParameter("@ID_SOLICITUD", SqlDbType.VarChar)).Value = "0" + txtIdBuscar.Text.Trim()
            .Add(New SqlParameter("@FECHA", SqlDbType.VarChar)).Value = "HOY"
            .Add(New SqlParameter("@ORDEN", SqlDbType.VarChar)).Value = xOrden
            .Add(New SqlParameter("@1RA_AYUDA", SqlDbType.VarChar)).Value = xTodasId.Substring(0, 1).ToString()
            .Add(New SqlParameter("@F_RANGOINI", SqlDbType.VarChar)).Value = Textdesdeaño.Text + Textdesdemes.Text + Textdesdedia.Text
            .Add(New SqlParameter("@F_RANGOTER", SqlDbType.VarChar)).Value = TextHASTAAÑO.Text + TextHASTAMES.Text + Texthastadia.Text
            .Add(New SqlParameter("@ESTADO", SqlDbType.VarChar)).Value = cboEstadoCapital.Text
            .Add(New SqlParameter("@SUCURSAL", SqlDbType.VarChar)).Value = cboSucursal.Text
            .Add(New SqlParameter("@ID_MENOR", SqlDbType.VarChar)).Value = xIdMenor.ToString()
        End With
        Try
            _Adaptador.Fill(_Tabla)
        Catch expSQL As SqlException
            MsgBox(expSQL.ToString, MsgBoxStyle.OkOnly, "SQL Exception")
        End Try
        conexiones.cerrar()
        Gridestadogiros.DataSource = _Tabla
        lblCalculando.Visible = False
        lblCalculando.Refresh()
    End Sub
    Private Sub CheckOrdenprerelacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckOrdenPrelacion.CheckedChanged
        CheckOrdenPrelacion.Refresh()
        If CheckOrdenPrelacion.Checked = True Then
            xTodasId = "No"
            xOrden = "ID"
            xIdMenor = 18470  ' <<==== NO TOCAR ESTE NUMERO, CORRESPONDE A LA PRIMERA ID A QUIEN SE LE CONSEDIO AYUDA SOCIAL
            txtSocioBuscar.Text = ""
            txtIdBuscar.Text = ""
            cboSucursal.SelectedItem = "TODAS"
            cboEstadoCapital.SelectedItem = "TODOS"
            Textdesdedia.Text = "01"
            Textdesdemes.Text = "01"
            Textdesdeaño.Text = "2015"
            Texthastadia.Text = Now.Day
            TextHASTAMES.Text = Now.Month
            TextHASTAAÑO.Text = Now.Year

            txtSocioBuscar.Refresh()
            txtIdBuscar.Refresh()
            cboSucursal.Refresh()
            cboEstadoCapital.Refresh()
            Textdesdedia.Refresh()
            Textdesdemes.Refresh()
            Textdesdeaño.Refresh()
            Texthastadia.Refresh()
            TextHASTAMES.Refresh()
            TextHASTAAÑO.Refresh()

        Else
            xIdMenor = 0
            xTodasId = "Si"
            xOrden = "ID_DESC"
        End If
        Consulta()
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Consulta()
    End Sub


    Sub IdentificarEstados()
        Dim totalfilas As Integer = Gridestadogiros.Rows.Count - 1
        Dim tomadato As String = ""
        Dim tomaid As String = ""
        Dim estado2 As String = ""
        Dim estado3 As String = ""
        Dim estado_solicitud As String = ""
        For z = 0 To totalfilas
            tomadato = Trim(Gridestadogiros.Rows(z).Cells(2).Value())
            tomaid = Trim(Gridestadogiros.Rows(z).Cells(0).Value())

            If tomadato = "PAGADO" Then

                Gridestadogiros.Rows(z).Cells(2).Style.BackColor = Color.Blue
                Gridestadogiros.Rows(z).Cells(2).Style.ForeColor = Color.White

            ElseIf tomadato = "RECONSIDERACIÓN" Then

                Gridestadogiros.Rows(z).Cells(2).Style.BackColor = Color.Orange
                Gridestadogiros.Rows(z).Cells(2).Style.ForeColor = Color.White

            ElseIf tomadato = "RECHAZADA" Then

                Gridestadogiros.Rows(z).Cells(2).Style.BackColor = Color.Red
                Gridestadogiros.Rows(z).Cells(2).Style.ForeColor = Color.White

            ElseIf tomadato = "APROBADO" Then

                Gridestadogiros.Rows(z).Cells(2).Style.BackColor = Color.Green
                Gridestadogiros.Rows(z).Cells(2).Style.ForeColor = Color.White

            ElseIf tomadato = "PREAPROBADO" Then

                Gridestadogiros.Rows(z).Cells(2).Style.BackColor = Color.Green
                Gridestadogiros.Rows(z).Cells(2).Style.ForeColor = Color.White
            ElseIf tomadato = "ANULADA" Then

                Gridestadogiros.Rows(z).Cells(2).Style.BackColor = Color.Red
                Gridestadogiros.Rows(z).Cells(2).Style.ForeColor = Color.White
            ElseIf tomadato = "PENDIENTE" Then

                Gridestadogiros.Rows(z).Cells(2).Style.BackColor = Color.Indigo
                Gridestadogiros.Rows(z).Cells(2).Style.ForeColor = Color.White


            End If

            'If gridestadosgiroscapital2.Rows(z).Cells(0).Value() = 0 And gridestadosgiroscapital2.Rows(z).Cells(1).Value() = 0 And Trim(Gridestadogiros.Rows(z).Cells(2).Value()) <> "ANULADA" Then

            '    Gridestadogiros.Rows(z).Cells(2).Value() = "PENDIENTE"
            '    Gridestadogiros.Rows(z).Cells(2).Style.BackColor = Color.Indigo
            '    Gridestadogiros.Rows(z).Cells(2).Style.ForeColor = Color.White

            'ElseIf gridestadosgiroscapital2.Rows(z).Cells(0).Value() = 0 And gridestadosgiroscapital2.Rows(z).Cells(1).Value() = 0 And Trim(Gridestadogiros.Rows(z).Cells(2).Value()) = "ANULADA" Then

            '    Gridestadogiros.Rows(z).Cells(2).Value() = "ANULADA"
            '    Gridestadogiros.Rows(z).Cells(2).Style.BackColor = Color.Red
            '    Gridestadogiros.Rows(z).Cells(2).Style.ForeColor = Color.White

            'ElseIf gridestadosgiroscapital2.Rows(z).Cells(0).Value() = 0 And gridestadosgiroscapital2.Rows(z).Cells(1).Value() = 1 And Trim(Gridestadogiros.Rows(z).Cells(2).Value()) <> "ANULADA" Then

            '    Gridestadogiros.Rows(z).Cells(2).Value() = "APROBADO"
            '    Gridestadogiros.Rows(z).Cells(2).Style.BackColor = Color.Green
            '    Gridestadogiros.Rows(z).Cells(2).Style.ForeColor = Color.White

            'End If
        Next
    End Sub

    Private Sub Checktodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Checktodos.CheckedChanged
        If Checktodos.Checked = True Then
            IdentificarEstados()
        End If
    End Sub


    Private Sub CheckBoxcarta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxcarta.CheckedChanged
        ColoreaCartasEnviadas()
    End Sub
    Sub ColoreaCartasEnviadas()
        Dim totalfilas As Long = Gridestadogiros.RowCount - 1
        For z = 0 To totalfilas
            If Trim(Gridestadogiros.Rows(z).Cells(9).Value()) = "CARTA ENVIADA" Then
                Gridestadogiros.Rows(z).Cells(9).Style.BackColor = Color.Green
                Gridestadogiros.Rows(z).Cells(9).Style.ForeColor = Color.White

            ElseIf Trim(Gridestadogiros.Rows(z).Cells(9).Value()) = "Sin enviar" Then

                Gridestadogiros.Rows(z).Cells(9).Style.BackColor = Color.Red
                Gridestadogiros.Rows(z).Cells(9).Style.ForeColor = Color.White
            End If
        Next
    End Sub


    Private Sub Textdesdedia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textdesdedia.TextChanged
        LimpiaGrid()
        If Not IsNumeric(Trim(Textdesdedia.Text)) Then
            MsgBox("Debe Ingresar Valores Numericos ")
        Else
            Dim TOTOAL As Double = 0
            TOTOAL = Len(Textdesdedia.Text)

            If TOTOAL = 2 Then
                Textdesdemes.Focus()
            End If
        End If
    End Sub

    Private Sub Textdesdemes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textdesdemes.TextChanged
        LimpiaGrid()
        If Not IsNumeric(Trim(Textdesdemes.Text)) Then
            MsgBox("Debe Ingresar Valores Numericos ")
        Else

            Dim TOTOAL As Double = 0
            TOTOAL = Len(Textdesdemes.Text)

            If TOTOAL = 2 Then

                Textdesdeaño.Focus()


            End If
        End If
    End Sub

    Private Sub Textdesdeaño_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textdesdeaño.TextChanged
        LimpiaGrid()
        If Not IsNumeric(Trim(Textdesdeaño.Text)) Then
            MsgBox("Debe Ingresar Valores Numericos ")
        Else

            Dim TOTOAL As Double = 0
            TOTOAL = Len(Textdesdeaño.Text)

            If TOTOAL = 4 Then

                Texthastadia.Focus()


            End If
        End If
    End Sub

    Private Sub Texthastadia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Texthastadia.TextChanged
        LimpiaGrid()
        If Not IsNumeric(Trim(Texthastadia.Text)) Then
            MsgBox("Debe Ingresar Valores Numericos ")
        Else

            Dim TOTOAL As Double = 0
            TOTOAL = Len(Texthastadia.Text)

            If TOTOAL = 2 Then

                TextHASTAMES.Focus()


            End If
        End If
    End Sub

    Private Sub TextHASTAMES_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextHASTAMES.TextChanged
        LimpiaGrid()
        If Not IsNumeric(Trim(TextHASTAMES.Text)) Then
            MsgBox("Debe Ingresar Valores Numericos ")
        Else

            Dim TOTOAL As Double = 0
            TOTOAL = Len(TextHASTAMES.Text)

            If TOTOAL = 2 Then

                TextHASTAAÑO.Focus()


            End If
        End If
    End Sub

    Private Sub TextHASTAAÑO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextHASTAAÑO.TextChanged
        LimpiaGrid()
        If Not IsNumeric(Trim(TextHASTAAÑO.Text)) Then
            MsgBox("Debe Ingresar Valores Numericos ")
        Else

            Dim TOTOAL As Double = 0
            TOTOAL = Len(TextHASTAAÑO.Text)

            If TOTOAL = 4 Then
                btnBuscar.Focus()


            End If
        End If
    End Sub
    Private Sub LimpiaGrid()
        _Tabla.Clear()
        _Tabla.Columns.Clear()
        Gridestadogiros.DataSource = _Tabla
        Gridestadogiros.Refresh()
    End Sub
    Private Sub txtSocioBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtSocioBuscar.TextChanged
        LimpiaGrid()
    End Sub

    Private Sub txtIdBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtIdBuscar.TextChanged
        LimpiaGrid()
    End Sub

    Private Sub cboSucursal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSucursal.SelectedIndexChanged
        LimpiaGrid()
    End Sub

    Private Sub cboEstadoCapital_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstadoCapital.SelectedIndexChanged
        LimpiaGrid()
    End Sub



    Private Sub Gridestadogiros_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Gridestadogiros.CellClick
        Dim ID As String = ""
        Dim MONTO As String = ""
        'Dim reciberazonsocial As String = 0
        'Gridestadogiros.Rows(Gridestadogiros.CurrentRow.Index).Cells(0).Value().ToString()

        If e.ColumnIndex >= 0 Then
            _Tabla29.Rows.Clear()
            _Tabla29.Columns.Clear()

            If CheckOrdenPrelacion.Checked = True Then
                ID = Gridestadogiros.Rows(Gridestadogiros.CurrentRow.Index).Cells(1).Value().ToString()
                MONTO = Gridestadogiros.Rows(Gridestadogiros.CurrentRow.Index).Cells(4).Value().ToString()
                ' MsgBox(ID)
                'MsgBox(MONTO)

            ElseIf CheckOrdenPrelacion.Checked = False Then

                ID = Gridestadogiros.Rows(Gridestadogiros.CurrentRow.Index).Cells(0).Value().ToString()
                MONTO = Gridestadogiros.Rows(Gridestadogiros.CurrentRow.Index).Cells(3).Value().ToString()
                ' MsgBox(ID)
                ' MsgBox(MONTO)


            End If

            'ID = Gridestadogiros.Rows(Gridestadogiros.CurrentRow.Index).Cells(0).Value().ToString()
            'MONTO = Gridestadogiros.Rows(Gridestadogiros.CurrentRow.Index).Cells(3).Value().ToString()
            'MsgBox(MONTO)
            'MsgBox(ID)


            frmBandejaCapital5.TextID.Text = ID
            'reciberazonsocial = Datatipodoc.Rows(Datatipodoc.CurrentRow.Index).Cells(0).Value().ToString()
            'MsgBox(recibecorrelativo)
            'MsgBox(reciberazonsocial)
            frmBandejaCapital5.Datadetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            Dim conexiones1306 As New CConexion
            conexiones1306.conexion()
            _Adaptador.SelectCommand = New SqlCommand("select  ID_SOLICITUD ,SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD , ESTADO_SOLICITUD , '" + Trim(MONTO.ToString) + "'  as MONTO, USUARIO ,NOMBRE_SOCIO   from [_RIESGO_SOLICITUD_GIRO_CAPITAL] where ID_SOLICITUD = '" + ID.ToString + "' ", conexiones1306._conexion)
            conexiones1306.abrir()
            _Adaptador.Fill(_Tabla29)
            frmBandejaCapital5.Datadetalle.DataSource = _Tabla29
            conexiones1306.cerrar()


            _Tabla30.Rows.Clear()
            _Tabla30.Columns.Clear()
            'MsgBox(ID)
            Dim conexiones4 As New CConexion
            conexiones4.conexion()
            ' _adaptador.SelectCommand = New SqlCommand(" select  ID_SOLICITUD  ,SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD , ESTADO_SOLICITUD ,dbo.puntos(MONTO_SOLICITUD) ,CONVERT(varchar(8),RUT )+'-'+CONVERT(varchar(1),DVRUT ) AS RUT,NOMBRE_SOCIO  ,NROSOCIO,DESCRIPCION,giro.BANCO,descripcion as TIPO_CUENTA,NRO_CUENTA ,CORRELATIVO,FORMA_PAGO,USUARIO,sucursal  ,TIPO_SOLICITUD,dbo.puntos([TOTALCAPITALSOCIAL]),dbo.puntos([CORRECCION_MONETARIA]),dbo.puntos([CUOTAS_PARTICIPACION]) ,dbo.puntos([TOTAL_NORETIRABLE]) ,dbo.puntos([MONTO_DISPONIBLE]) ,dbo.puntos([MONTO_MAXIMO_RETIRABLE]),dbo.puntos([FILTRO_CAPITAL_MINIMO]),dbo.puntos([FILTRO_MONTO_SOLICITADO]),[FILTRO_GIROS_ANUAL],[FILTRO_GIROS_MENSUAL],[FILTRO_SOCIO_SINMORA] ,[FILTRO_AVAL_SINMORA],[FILTRO_RESTRICCIONES] ,[FILTRO_CAPITAL_GLOBAL],[COMENTARIO_EVALUACION],[COMENTARIO_SUBGERENTE],[COMENTARIO_SUBGERENTE_FINANZAS],[COMENTARIO_LIBERA_CAPITAL]from [_RIESGO_SOLICITUD_GIRO_CAPITAL]as giro left join _TESORERIA_TIPO_CUENTA_BANCO as teso on giro.TIPO_CUENTA  = teso.CODIGO where ID_SOLICITUD = '" + ID + "' ", conexiones4._conexion)
            _Adaptador.SelectCommand = New SqlCommand("select  ID_SOLICITUD  ,SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD ,ESTADO_SOLICITUD ,'" + Trim(MONTO.ToString) + "'  as MONTO_SOLICITUD,CONVERT(varchar(8),RUT )+'-'+CONVERT(varchar(1),DVRUT ) AS RUT,NOMBRE_SOCIO  ,NROSOCIO,DESCRIPCION,giro.BANCO,descripcion as TIPO_CUENTA,NRO_CUENTA ,CORRELATIVO,FORMA_PAGO,USUARIO,sucursal  ,TIPO_SOLICITUD,CONVERT(varchar ,dbo.puntos([TOTALCAPITALSOCIAL]) )       as [TOTALCAPITALSOCIAL],CONVERT(varchar ,dbo.puntos([CORRECCION_MONETARIA]))as [CORRECCION_MONETARIA] ,CONVERT(varchar ,dbo.puntos([CUOTAS_PARTICIPACION]) ) as [CUOTAS_PARTICIPACION],CONVERT(varchar ,dbo.puntos([TOTAL_NORETIRABLE]) ) as [TOTAL_NORETIRABLE],CONVERT(varchar ,dbo.puntos([MONTO_DISPONIBLE]) ) as [MONTO_DISPONIBLE],CONVERT(varchar ,dbo.puntos([MONTO_MAXIMO_RETIRABLE]))as [MONTO_MAXIMO_RETIRABLE] ,[FILTRO_CAPITAL_MINIMO] ,[FILTRO_MONTO_SOLICITADO] ,[FILTRO_GIROS_ANUAL],[FILTRO_GIROS_MENSUAL],[FILTRO_SOCIO_SINMORA] ,[FILTRO_AVAL_SINMORA],[FILTRO_RESTRICCIONES],[FILTRO_CAPITAL_GLOBAL],[COMENTARIO_EVALUACION],[COMENTARIO_SUBGERENTE],[COMENTARIO_SUBGERENTE_FINANZAS],[COMENTARIO_LIBERA_CAPITAL]from [_RIESGO_SOLICITUD_GIRO_CAPITAL]as giro left join _TESORERIA_TIPO_CUENTA_BANCO as teso on giro.TIPO_CUENTA  = teso.CODIGO where ID_SOLICITUD ='" + ID + "' ", conexiones4._conexion)
            _Adaptador.Fill(_Tabla30)
            frmBandejaCapital5.GridReporte.DataSource = _Tabla30
            conexiones4.cerrar()

            'PROCEDIMIENTO ALMACENADO 
            'select  ID_SOLICITUD  ,SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD , ESTADO_SOLICITUD , dbo.puntos(MONTO_SOLICITUD) as MONTO ,CONVERT(varchar(8),RUT )+'-'+CONVERT(varchar(1),DVRUT ) AS RUT,NOMBRE_SOCIO  ,NROSOCIO,DESCRIPCION,BANCO ,NRO_CUENTA ,CORRELATIVO,FORMA_PAGO,USUARIO,sucursal  ,TIPO_SOLICITUD ,[TOTAL_NORETIRABLE] ,[MONTO_DISPONIBLE] ,[MONTO_MAXIMO_RETIRABLE],[FILTRO_CAPITAL_MINIMO] ,[FILTRO_MONTO_SOLICITADO],[FILTRO_GIROS_ANUAL],[FILTRO_GIROS_MENSUAL],[FILTRO_SOCIO_SINMORA] ,[FILTRO_AVAL_SINMORA],[FILTRO_RESTRICCIONES] ,[FILTRO_CAPITAL_GLOBAL],[COMENTARIO_EVALUACION],[COMENTARIO_SUBGERENTE],[COMENTARIO_SUBGERENTE_FINANZAS],[COMENTARIO_LIBERA_CAPITAL]from [_RIESGO_SOLICITUD_GIRO_CAPITAL]as giro inner join _TESORERIA_TIPO_CUENTA_BANCO as teso on giro.TIPO_CUENTA  = teso.CODIGO where ID_SOLICITUD = '81' 

            If Trim(Gridestadogiros.Rows(Gridestadogiros.CurrentRow.Index).Cells(2).Value()) = "PAGADO" Or Trim(Gridestadogiros.Rows(Gridestadogiros.CurrentRow.Index).Cells(2).Value()) = "APROBADO" Or Trim(Gridestadogiros.Rows(Gridestadogiros.CurrentRow.Index).Cells(2).Value()) = "PREAPROBADO" Then

                frmBandejaCapital5.Button2.Enabled = True
                frmBandejaCapital5.Visible = True
            Else
                frmBandejaCapital5.Button2.Enabled = False
                frmBandejaCapital5.Visible = True
            End If
            'Gridestadogiros.Rows(Gridestadogiros.CurrentRow.Index).Cells(0).Value().ToString()
            'frmBandejaCapital5.Visible = True
            'Catch ex As Exception
            'End Try

        End If
    End Sub

    Private Sub Gridestadogiros_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Gridestadogiros.CellContentClick

    End Sub
End Class