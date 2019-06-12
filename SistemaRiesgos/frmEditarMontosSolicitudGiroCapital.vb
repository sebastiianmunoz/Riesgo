Imports System.Data
Imports System.Data.SqlClient
Public Class frmEditarMontosSolicitudGiroCapital
    Public _TABLA27 As DataTable = New DataTable
    Public _TABLA29 As DataTable = New DataTable
    Public _tabla30 As DataTable = New DataTable
    Public _tabla31 As DataTable = New DataTable



    Dim cadena As String
    Dim tabla() As String
    Dim n As Integer
    Dim tomarut As String
    Dim tomadigito As String
    '----------------------------
    'validar que exista socio con rut ingresado 
    Dim nrosocio As String = ""
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter

    Private Sub frmEditarMontosSolicitudGiroCapital_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        estadosgenerales()
    End Sub

    Sub estadosgenerales()
        _TABLA27.Rows.Clear()
        _TABLA27.Columns.Clear()
        Gridestadogiros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        'LLENA   LA GRILLA  "GRIDESTADOSGIROS " Y  MUESTRA TODAS LAS SOLICITUDES DE GIRO DE CAPITAL 
        Dim xSql As String
        xSql = ""
        xSql = xSql + "Select ID_SOLICITUD"
        xSql = xSql + ",SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD"
        xSql = xSql + ", ESTADO_SOLICITUD "
        xSql = xSql + ", dbo.puntos(MONTO_SOLICITUD) as MONTO"
        xSql = xSql + ", USUARIO "
        xSql = xSql + ",NOMBRE_SOCIO "
        xSql = xSql + ",convert(varchar(8),[RUT])+'-'+DVRUT as RUT "
        xSql = xSql + ",(SELECT CASE  WHEN TIPOSOLICITUD2 = 'R' "
        xSql = xSql + "THEN 'RENUNCIA' WHEN   TIPOSOLICITUD2 = 'F' "
        xSql = xSql + "THEN 'FALLECIMIENTO'  WHEN   TIPOSOLICITUD2 ='T' "
        xSql = xSql + "THEN 'TRASPASO' ELSE 'GIRO CAPITAL' END ) AS TIPO_GIRO "
        xSql = xSql + ",FORMA_PAGO  "
        xSql = xSql + "from [_RIESGO_SOLICITUD_GIRO_CAPITAL] WHERE CORREGRESO=0 and estado_solicitud<>'RECONSIDERACIÓN'  order by ID_SOLICITUD desc "
        Dim conexiones4 As New CConexion
        conexiones4.conexion()
        _adaptador.SelectCommand = New SqlCommand(xSql, conexiones4._conexion)
        _adaptador.Fill(_TABLA27)
        Gridestadogiros.DataSource = _TABLA27
        conexiones4.cerrar()
    End Sub


    Sub BuscarIDespecifico()
        _TABLA27.Rows.Clear()
        _TABLA27.Columns.Clear()
        Dim id As String = ""
        id = Trim(textBuscarID.Text)
        Gridestadogiros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        If Trim(textBuscarID.Text) <> "" Then
            'LLENA   LA GRILLA  "GRIDESTADOSGIROS " Y  MUESTRA TODAS LAS SOLICITUDES DE GIRO DE CAPITAL 
            Dim xSql As String
            xSql = ""
            xSql = xSql + "Select ID_SOLICITUD"
            xSql = xSql + ",SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD"
            xSql = xSql + ", ESTADO_SOLICITUD "
            xSql = xSql + ", dbo.puntos(MONTO_SOLICITUD) as MONTO"
            xSql = xSql + ", USUARIO "
            xSql = xSql + ",NOMBRE_SOCIO "
            xSql = xSql + ",convert(varchar(8),[RUT])+'-'+DVRUT as RUT "
            xSql = xSql + ",(SELECT CASE  WHEN TIPOSOLICITUD2 = 'R' "
            xSql = xSql + "THEN 'RENUNCIA' WHEN   TIPOSOLICITUD2 = 'F' "
            xSql = xSql + "THEN 'FALLECIMIENTO'  WHEN   TIPOSOLICITUD2 ='T' "
            xSql = xSql + "THEN 'TRASPASO' ELSE 'GIRO CAPITAL' END ) AS TIPO_GIRO "
            xSql = xSql + ",FORMA_PAGO  "
            xSql = xSql + "from [_RIESGO_SOLICITUD_GIRO_CAPITAL] WHERE ID_SOLICITUD='" + id + "' order by ID_SOLICITUD desc "
            Dim conexiones4 As New CConexion
            conexiones4.conexion()
            _adaptador.SelectCommand = New SqlCommand(xSql, conexiones4._conexion)
            _adaptador.Fill(_TABLA27)
            Gridestadogiros.DataSource = _TABLA27
            conexiones4.cerrar()
        Else
            MsgBox("Debe ingresar un ID  valido ")
        End If

       
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        BuscarIDespecifico()
    End Sub

    Private Sub Gridestadogiros_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Gridestadogiros.CellClick
        Dim ID As String = ""
        Dim TIPOLOGIA As String = ""
        'Dim reciberazonsocial As String = 0
        If e.ColumnIndex >= 0 Then
            _tabla29.Rows.Clear()
            _tabla29.Columns.Clear()

            ID = Gridestadogiros.Rows(Gridestadogiros.CurrentRow.Index).Cells(0).Value().ToString()
            TIPOLOGIA = Gridestadogiros.Rows(Gridestadogiros.CurrentRow.Index).Cells(7).Value().ToString()

            frmEditarMontoGiroCapital2.TextID.Text = ID
            frmEditarMontoGiroCapital2.TextTiposolciitud.Text = TIPOLOGIA
            'reciberazonsocial = Datatipodoc.Rows(Datatipodoc.CurrentRow.Index).Cells(0).Value().ToString()
            'MsgBox(recibecorrelativo)
            'MsgBox(reciberazonsocial)

            frmEditarMontoGiroCapital2.Datadetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            Dim conexiones1306 As New CConexion
            conexiones1306.conexion()
            _adaptador.SelectCommand = New SqlCommand("select  ID_SOLICITUD ,SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD , ESTADO_SOLICITUD , dbo.puntos(MONTO_SOLICITUD) as MONTO, USUARIO ,NOMBRE_SOCIO   from [_RIESGO_SOLICITUD_GIRO_CAPITAL] where ID_SOLICITUD = '" + ID + "' ", conexiones1306._conexion)
            conexiones1306.abrir()
            _adaptador.Fill(_tabla29)
            frmEditarMontoGiroCapital2.Datadetalle.DataSource = _TABLA29
            conexiones1306.cerrar()
            '_tabla30.Rows.Clear()
            '_tabla30.Columns.Clear()
            ''MsgBox(ID)
            'Dim conexiones4 As New CConexion
            'conexiones4.conexion()
            '_adaptador.SelectCommand = New SqlCommand("select  ID_SOLICITUD  ,SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD ,ESTADO_SOLICITUD ,CONVERT(varchar,dbo.puntos(MONTO_SOLICITUD))  as MONTO_SOLICITUD,CONVERT(varchar(8),RUT )+'-'+CONVERT(varchar(1),DVRUT ) AS RUT,NOMBRE_SOCIO  ,NROSOCIO,DESCRIPCION,giro.BANCO,descripcion as TIPO_CUENTA,NRO_CUENTA ,CORRELATIVO,FORMA_PAGO,USUARIO,sucursal  ,TIPO_SOLICITUD,CONVERT(varchar ,dbo.puntos([TOTALCAPITALSOCIAL]) )       as [TOTALCAPITALSOCIAL],CONVERT(varchar ,dbo.puntos([CORRECCION_MONETARIA]))as [CORRECCION_MONETARIA] ,CONVERT(varchar ,dbo.puntos([CUOTAS_PARTICIPACION]) ) as [CUOTAS_PARTICIPACION],CONVERT(varchar ,dbo.puntos([TOTAL_NORETIRABLE]) ) as [TOTAL_NORETIRABLE],CONVERT(varchar ,dbo.puntos([MONTO_DISPONIBLE]) ) as [MONTO_DISPONIBLE],CONVERT(varchar ,dbo.puntos([MONTO_MAXIMO_RETIRABLE]))as [MONTO_MAXIMO_RETIRABLE] ,[FILTRO_CAPITAL_MINIMO] ,[FILTRO_MONTO_SOLICITADO] ,[FILTRO_GIROS_ANUAL],[FILTRO_GIROS_MENSUAL],[FILTRO_SOCIO_SINMORA] ,[FILTRO_AVAL_SINMORA],[FILTRO_RESTRICCIONES],[FILTRO_CAPITAL_GLOBAL],[COMENTARIO_EVALUACION],[COMENTARIO_SUBGERENTE],[COMENTARIO_SUBGERENTE_FINANZAS],[COMENTARIO_LIBERA_CAPITAL]from [_RIESGO_SOLICITUD_GIRO_CAPITAL]as giro left join _TESORERIA_TIPO_CUENTA_BANCO as teso on giro.TIPO_CUENTA  = teso.CODIGO where ID_SOLICITUD ='" + ID + "' ", conexiones4._conexion)
            '_adaptador.Fill(_tabla30)
            'frmBandejaCapital5.GridReporte.DataSource = _tabla30
            'conexiones4.cerrar()

            If Trim(Gridestadogiros.Rows(Gridestadogiros.CurrentRow.Index).Cells(2).Value()) = "APROBADO" Or Trim(Gridestadogiros.Rows(Gridestadogiros.CurrentRow.Index).Cells(2).Value()) = "PREAPROBADO" Then

                ' frmBandejaCapital5.Button2.Enabled = True
                frmEditarMontoGiroCapital2.Visible = True

            ElseIf Trim(Gridestadogiros.Rows(Gridestadogiros.CurrentRow.Index).Cells(2).Value()) = "RECONSIDERACIÓN" Then
                MessageBox.Show("Esta solicitud de giro  de capital se encuentra RECONSIDERACIÓN", "Información estado solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ElseIf Trim(Gridestadogiros.Rows(Gridestadogiros.CurrentRow.Index).Cells(2).Value()) = "PAGADO" Then
                ' frmBandejaCapital5.Button2.Enabled = False
                'frmEditarMontoGiroCapital2.Visible = True
                MessageBox.Show("Esta solicitud de giro  de capital se encuentra pagada", "Información estado solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
            'Gridestadogiros.Rows(Gridestadogiros.CurrentRow.Index).Cells(0).Value().ToString()
            'frmBandejaCapital5.Visible = True
            'Catch ex As Exception
            'End Try

        End If

    End Sub

    Private Sub Gridestadogiros_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Gridestadogiros.CellContentClick

    End Sub
End Class
