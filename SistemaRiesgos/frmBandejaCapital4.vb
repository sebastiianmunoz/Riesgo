Imports System.Data
Imports System.Data.SqlClient
Public Class frmBandejaCapital4
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter
    Private Sub txtComentarioliberaGirocapital_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComentarioliberaGirocapital.KeyUp
        txtcomentariototal.Text = 250 - (txtComentarioliberaGirocapital.Text.Length)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'frmBandejaCapital2.Texcapital4.Text = 1
        Dim banderapase As Boolean = False
        Dim totalfilas As Integer = frmBandejaCapital2.GridbandejaCapital.Rows.Count - 1
        Dim totalselecionado As Integer = 0
        Dim id_fila As String = ""
        Dim formapago As String = ""
        Dim TIPOSOLICITUD As String = ""

        For I = 0 To totalfilas
            If frmBandejaCapital2.GridbandejaCapital.Rows(I).Cells(11).Value() = True Then

                id_fila = frmBandejaCapital2.GridbandejaCapital.Rows(I).Cells(8).Value()
                formapago = frmBandejaCapital2.GridbandejaCapital.Rows(I).Cells(5).Value()
                TIPOSOLICITUD = frmBandejaCapital2.GridbandejaCapital.Rows(I).Cells(9).Value()


                'MsgBox(formapago)
                'CALFARO CAMBIAR LA F POR FALLECIMIENTO
                'CALFARO CAMBIAR LA R POR RETIRO
                'CALFARO ETC.


                If Trim(formapago) = "TRANSFERENCIA" And (Trim(TIPOSOLICITUD) <> "Fallecimiento" And Trim(TIPOSOLICITUD) <> "Renuncia" And Trim(TIPOSOLICITUD) <> "Castigo") Then

                    'RevalorizacionUF()
                    Dim conexiones60 As New CConexion
                    conexiones60.conexion()
                    _adaptador.UpdateCommand = New SqlCommand(" UPDATE  [_RIESGO_SOLICITUD_GIRO_CAPITAL] set  [ESTADO_SOLICITUD]='PREAPROBADO', [ESTADO_SOLICITUD2]= 1 , ESTADO_SOLICITUD3=1, COMENTARIO_LIBERA_CAPITAL ='" + txtComentarioliberaGirocapital.Text + "' ,FILTRO_CAPITAL_GLOBAL =  ( select  case   WHEN FILTRO_CAPITAL_GLOBAL = 'NO' AND ESTADO_SOLICITUD='RECONSIDERACIÓN' THEN 'SI' WHEN FILTRO_CAPITAL_GLOBAL = 'NO' AND ESTADO_SOLICITUD<> 'RECONSIDERACIÓN' THEN 'NO'WHEN FILTRO_CAPITAL_GLOBAL = 'SI' AND ESTADO_SOLICITUD<> 'RECONSIDERACIÓN' THEN 'SI' END) FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL]  WHERE [ID_SOLICITUD] ='" + Trim(id_fila) + "'", conexiones60._conexion)
                    conexiones60.abrir()
                    _adaptador.UpdateCommand.Connection = conexiones60._conexion
                    _adaptador.UpdateCommand.ExecuteNonQuery()
                    conexiones60.cerrar()

                    'CALFARO , falta el parentecis para enmarcar el OR
                ElseIf (Trim(formapago) = "EFECTIVO" Or Trim(formapago) = "CHEQUE") And (Trim(TIPOSOLICITUD) <> "Fallecimiento" And Trim(TIPOSOLICITUD) <> "Renuncia" And Trim(TIPOSOLICITUD) <> "Castigo") Then


                    'RevalorizacionUF()
                    Dim conexiones600 As New CConexion
                    conexiones600.conexion()
                    _adaptador.UpdateCommand = New SqlCommand(" UPDATE  [_RIESGO_SOLICITUD_GIRO_CAPITAL] set [ESTADO_SOLICITUD]='APROBADO', [ESTADO_SOLICITUD2]= 1 , ESTADO_SOLICITUD3=1, COMENTARIO_LIBERA_CAPITAL ='" + txtComentarioliberaGirocapital.Text + "' ,FILTRO_CAPITAL_GLOBAL =  ( select  case   WHEN FILTRO_CAPITAL_GLOBAL = 'NO' AND ESTADO_SOLICITUD='RECONSIDERACIÓN' THEN 'SI' WHEN FILTRO_CAPITAL_GLOBAL = 'NO' AND ESTADO_SOLICITUD<> 'RECONSIDERACIÓN' THEN 'NO'WHEN FILTRO_CAPITAL_GLOBAL = 'SI' AND ESTADO_SOLICITUD<> 'RECONSIDERACIÓN' THEN 'SI' END) FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL]  WHERE [ID_SOLICITUD] ='" + Trim(id_fila) + "'", conexiones600._conexion)
                    conexiones600.abrir()
                    _adaptador.UpdateCommand.Connection = conexiones600._conexion
                    _adaptador.UpdateCommand.ExecuteNonQuery()
                    conexiones600.cerrar()

                ElseIf Trim(TIPOSOLICITUD) = "Fallecimiento" Or Trim(TIPOSOLICITUD) = "Renuncia" Or Trim(TIPOSOLICITUD) = "Castigo" Then

                    'CALFARO DESDE AQUI 
                    ' RevalorizacionUF()
                    Dim conexiones600 As New CConexion
                    conexiones600.conexion()
                    conexiones600.abrir()
                    Dim cmd1 As New SqlCommand("_LAUCOOP_PRELACION_ACTUALIZA_CAPITAL", conexiones600._conexion)
                    cmd1.CommandType = CommandType.StoredProcedure
                    Dim prm1 As SqlParameter = New SqlParameter("@FECHA", SqlDbType.NChar, 30)
                    cmd1.Parameters.Add(prm1)

                    Dim prm2 As SqlParameter = New SqlParameter("@ID_SOLICITUD", SqlDbType.NChar, 30)
                    cmd1.Parameters.Add(prm2)

                    With cmd1
                        .Parameters("@FECHA").Value = "hoy"
                        .Parameters("@ID_SOLICITUD").Value = id_fila
                    End With
                    Dim dr1 As SqlDataReader = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                    conexiones600.cerrar()
                    ' CALFARO HASTA AQUI 


                    'CALFARO EN LA SIGUIENTE LINEA SE SACA EL VALOR DE LA ACTUALIZACION
                    conexiones600.conexion()
                    _adaptador.UpdateCommand = New SqlCommand(" UPDATE  [_RIESGO_SOLICITUD_GIRO_CAPITAL] set [ESTADO_SOLICITUD]='RECONSIDERACIÓN', [ESTADO_SOLICITUD2]= 1 , ESTADO_SOLICITUD3=1, COMENTARIO_LIBERA_CAPITAL ='" + txtComentarioliberaGirocapital.Text + "' ,FILTRO_CAPITAL_GLOBAL =  ( select  case   WHEN FILTRO_CAPITAL_GLOBAL = 'NO' AND ESTADO_SOLICITUD='RECONSIDERACIÓN' THEN 'SI' WHEN FILTRO_CAPITAL_GLOBAL = 'NO' AND ESTADO_SOLICITUD<> 'RECONSIDERACIÓN' THEN 'NO'WHEN FILTRO_CAPITAL_GLOBAL = 'SI' AND ESTADO_SOLICITUD<> 'RECONSIDERACIÓN' THEN 'SI' END),[REEVALUACION]='SI' , [Aprobacion_SubGerencia]='Por Analizar'  FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL]  WHERE [ID_SOLICITUD] ='" + Trim(id_fila) + "'", conexiones600._conexion)
                    conexiones600.abrir()
                    _adaptador.UpdateCommand.Connection = conexiones600._conexion
                    _adaptador.UpdateCommand.ExecuteNonQuery()
                    conexiones600.cerrar()
                End If
                banderapase = True

            End If
        Next
        'If banderapase = True Then
        ' Me.Close()
        'ElseIf banderapase = False Then
        'MsgBox("Debe Seleccionar Solicitud para liberar ")
        'End If
        frmBandejaCapital2.Timer1.Interval = 500
        frmBandejaCapital2.Timer1.Start()
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmBandejaCapital2.Timer1.Interval = 500
        frmBandejaCapital2.Timer1.Start()
        Me.Close()
        ' frmBandejaCapital2.Texcapital4.Text = 0
    End Sub

    Sub RevalorizacionUF()
        'REAL SQL CON LA VARIABLE DEL DIA ACTUAL 
        Dim FECHACOMPLETA2 As String = ""
        Dim FECHACOMPLETA3 As String = ""
        Dim AÑO As String = ""
        FECHACOMPLETA2 = DateTime.Now().ToShortDateString()  '"16/06/2009"
        'VOLVEEEER A DEJAR PARA QUE PEUDA  CAMBIAR  EN EL MIMSO MES  SOLMKANRTE 
        FECHACOMPLETA3 = Mid(FECHACOMPLETA2, 7, 10) + Mid(FECHACOMPLETA2, 4, 2) + Mid(FECHACOMPLETA2, 1, 2)
        AÑO = Mid(FECHACOMPLETA2, 7, 10)

        'Dim ValorUFdiaActualstring As String = ""
        'Dim ValorUFdiaActualstringparte1 As String = ""
        'Dim ValorUFdiaActualstringparte2 As String = ""
        'Dim ValorUFdiaActual As Double

        Dim ValorMontoReajustado As Long
        'Dim ValorSaldoAporteretiro As Long
        Dim valordiaactulauf As String = ""
        Dim nrosocio As String = ""
        nrosocio = Trim(Textnrosocio.Text)
        Dim sumatotal As Long

        'SELECT VALORUF FROM [LROSAS_R].[dbo].[_VALORUF] where FECHA='20150103' 

        Dim conexionesee As New CConexion
        conexionesee.conexion()
        Dim commandee As SqlCommand = New SqlCommand("SELECT VALORUF FROM [_VALORUF] where FECHA='" + Trim(FECHACOMPLETA3) + "' ", conexionesee._conexion)
        conexionesee.abrir()
        Dim readeree As SqlDataReader = commandee.ExecuteReader()
        If readeree.HasRows Then
            Do While readeree.Read()
                valordiaactulauf = readeree(0)
                'ValorUFdiaActual = reader(0)
                'MsgBox(ValorUFdiaActual)
            Loop
        Else
        End If
        readeree.Close()

        ''Textvalorufdiactual.Text = valordiaactulauf
        'Dim conexiones As New CConexion
        'conexiones.conexion()
        'Dim command As SqlCommand = New SqlCommand("select round(sum(_Capitalsocial.movuf*_valoruf.valoruf),0) from _Capitalsocial inner join _VALORUF on _valoruf.FECHA ='" + Trim(FECHACOMPLETA3) + "' where _capitalsocial.NROSOCIO  = '" + Trim(nrosocio) + "' and _capitalsocial.fecha >='" + Trim(AÑO) + "0101' ", conexiones._conexion)
        'conexiones.abrir()
        'Dim reader As SqlDataReader = command.ExecuteReader()
        'If reader.HasRows Then
        '    Do While reader.Read()
        '        ValorMontoReajustado = reader(0)
        '        'ValorUFdiaActual = reader(0)
        '        'MsgBox(ValorUFdiaActual)
        '    Loop
        'Else
        'End If
        'reader.Close()

        Try
            If Trim(nrosocio) <> "" Then
                ' -------------------------------------------------
                Dim xSql As String
                xSql = ""
                xSql = xSql + "SELECT ISNULL(SUM(ACTU),0) AS ACTU FROM ( "
                xSql = xSql + "SELECT SUM(ROUND(_CAPITALSOCIAL.MOVUF * _VALORUF.VALORUF,0)) AS ACTU "
                xSql = xSql + "FROM _CAPITALSOCIAL  "
                xSql = xSql + "INNER JOIN _VALORUF ON _VALORUF.FECHA = '" + Trim(FECHACOMPLETA3) + "' "
                xSql = xSql + "WHERE(_CAPITALSOCIAL.NROSOCIO = " + Trim(nrosocio) + " "
                '  xSql = xSql + "AND _CAPITALSOCIAL.FECHA >= '" + Trim(AÑO) + "0101' )"
                xSql = xSql + "AND _CAPITALSOCIAL.FECHA >= '20170101' )"
                xSql = xSql + "UNION ALL  "
                xSql = xSql + "SELECT ROUND(CONVERT(NUMERIC(19,6),_INGRESOS.CAPITALSOCIAL-_INGRESOS.CAPITALSOCIAL2)/CONVERT(NUMERIC(19,6),UF1.VALORUF)*UF2.VALORUF,0)  AS CAPITAL "
                xSql = xSql + "FROM _INGRESOS  "
                xSql = xSql + "INNER JOIN _VALORUF UF1 ON UF1.FECHA = _INGRESOS.FECHA "
                xSql = xSql + "INNER JOIN _VALORUF UF2 ON UF2.FECHA = '" + Trim(FECHACOMPLETA3) + "' "
                xSql = xSql + "WHERE _INGRESOS.ESTADOCONT = 'S' AND _INGRESOS.TIPOINGRESO <> 'LIQUIDA' AND (_INGRESOS.CAPITALSOCIAL<>0 OR _INGRESOS.CAPITALSOCIAL2 <> 0) "
                xSql = xSql + "AND _INGRESOS.NROSOCIO = " + Trim(nrosocio) + " "
                xSql = xSql + ") DERIVEDTBL "

                Dim conexiones As New CConexion
                conexiones.conexion()
                'select sum(round(_Capitalsocial.movuf*_valoruf.valoruf,0)) from _Capitalsocial inner join _VALORUF on _valoruf.FECHA ='" + Trim(FECHACOMPLETA3) + "' where _capitalsocial.NROSOCIO  = '" + Trim(NROSOCIO) + "' and _capitalsocial.fecha >='" + Trim(AÑO) + "0101'
                Dim command As SqlCommand = New SqlCommand(xSql, conexiones._conexion)
                conexiones.abrir()
                Dim reader As SqlDataReader = command.ExecuteReader()
                If reader.HasRows Then
                    Do While reader.Read()
                        ValorMontoReajustado = reader(0)
                        'ValorUFdiaActual = reader(0)
                        'MsgBox(ValorUFdiaActual)
                    Loop
                Else
                End If
                reader.Close()
                '--------------------------------------------------
            End If
        Catch ex As Exception
            'VERIFICAR  QUE NO SE COMETA ERRROR AL BUSCAR 
        End Try

        '---------------------------------------------------------------------------
        'TextrevalorizacionUF.Text = ValorMontoReajustado
        'Textmontorequerido.Text = ValorMontoReajustado
        ' TextrevalorizacionUF.ReadOnly = True
        Textvalorreajustado.Text = ValorMontoReajustado

    End Sub

    Private Sub frmBandejaCapital4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class