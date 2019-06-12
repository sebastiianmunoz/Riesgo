Imports System.Data
Imports System.Data.SqlClient
Public Class frmRevalorizacionUFGlobal
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter
    Dim REVALORIZACIONREALIZADA As String = "NO"
    Private Sub frmRevalorizacionUFGlobal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LLENARGRILLASOLICITUDESPORPAGAR()
        Mensajeparpadiante.Start()
        'acrualizarvalores()
        GroupBox1.Visible = False
    End Sub


    Sub LLENARGRILLASOLICITUDESPORPAGAR()
        ' conexiones.conexion()
        '_adaptador.Fill(_tabla)
        GridRevalorizacionUF.Rows.Clear()
        Dim Numeroregistros As Integer = 0
        Dim conexiones7 As New CConexion
        conexiones7.conexion()
        Dim command7 As SqlCommand = New SqlCommand("SELECT COUNT(*) FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL] WHERE  CORREGRESO=0 AND ESTADO_SOLICITUD <>'ANULADA' AND ESTADO_SOLICITUD<>'RECHAZADA' AND (TIPOSOLICITUD2='R' or TIPOSOLICITUD2='F')    ", conexiones7._conexion)
        conexiones7.abrir()
        Dim reader7 As SqlDataReader = command7.ExecuteReader()
        If reader7.HasRows Then
            Do While reader7.Read()
                Numeroregistros = reader7(0)
            Loop
        Else
        End If
        reader7.Close()
        'llena con valor en blanco grilla para luego ingresar los valores que biene de la consulta sql  
        For x = 0 To Numeroregistros - 1
            GridRevalorizacionUF.Rows.Add(" ", "", "", "", "", "")
        Next

        Dim conexiones5 As New CConexion
        conexiones5.conexion()
        Dim command5 As SqlCommand = New SqlCommand("SELECT SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD ,MONTO_SOLICITUD,ESTADO_SOLICITUD ,NROSOCIO,FORMA_PAGO,ID_SOLICITUD   FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL] WHERE  CORREGRESO=0  AND ESTADO_SOLICITUD <>'ANULADA' AND ESTADO_SOLICITUD<>'RECHAZADA'AND (TIPOSOLICITUD2='R' or TIPOSOLICITUD2='F')  order by  [_RIESGO_SOLICITUD_GIRO_CAPITAL].ID_SOLICITUD  desc  ", conexiones5._conexion)
        conexiones5.abrir()
        Dim reader5 As SqlDataReader = command5.ExecuteReader()
        If reader5.HasRows Then
            Dim z As Integer = 0
            Do While reader5.Read()
                'MsgBox(z)
                GridRevalorizacionUF.Rows(z).Cells(0).Value() = reader5(0).ToString
                GridRevalorizacionUF.Rows(z).Cells(1).Value() = CDbl(reader5(1))
                GridRevalorizacionUF.Rows(z).Cells(2).Value() = reader5(2).ToString
                GridRevalorizacionUF.Rows(z).Cells(3).Value() = CDbl(reader5(3))
                GridRevalorizacionUF.Rows(z).Cells(4).Value() = reader5(4).ToString
                GridRevalorizacionUF.Rows(z).Cells(5).Value() = CDbl(reader5(5))
                'MsgBox(GridRevalorizacionUF.Rows(z).Cells(0).Value())
                z = z + 1
            Loop
        Else
        End If
        reader5.Close()
    End Sub


    Sub RevalorizacionUF(ByVal NROSOCIO As String)
        'Variable dia actual '"16/06/2009 se recibe valor con slash "



        Dim FECHACOMPLETA2 As String = ""
        'variable con la fecha actual pero sin lo slash 
        Dim FECHACOMPLETA3 As String = ""
        ' variable año actual 
        Dim AÑO As String = ""
        FECHACOMPLETA2 = DateTime.Now().ToShortDateString()  '"16/06/2009"
        FECHACOMPLETA3 = Mid(FECHACOMPLETA2, 7, 10) + Mid(FECHACOMPLETA2, 4, 2) + Mid(FECHACOMPLETA2, 1, 2)
        AÑO = Mid(FECHACOMPLETA2, 7, 10)
        'Dim ValorUFdiaActualstring As String = ""
        'Dim ValorUFdiaActualstringparte1 As String = ""
        'Dim ValorUFdiaActualstringparte2 As String = ""
        'Dim ValorUFdiaActual As Double
        Dim ValorMontoReajustado As Long = 0
        Dim valordiaactulauf As String = ""

        Dim Sumatotal As Long = 0
        Dim saldo As Long = 0
        'Dim nrosocio As String = ""
        'nrosocio = Trim(Textnrosocio.Text)
        'Dim sumatotal As Long
        'SELECT VALORUF FROM [LROSAS_R].[dbo].[_VALORUF] where FECHA='20150103' 
        Try
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
            conexionesee.cerrar()
        Catch ex As Exception
            ' VERIFICAR  QUE NO SE COMETA ERRROR AL BUSCAR 
        End Try
        'Textvalorufdiactual.Text = valordiaactulauf
        'MsgBox(NROSOCIO)
        Try
            If Trim(NROSOCIO) <> "" Then
                ' -------------------------------------------------
                Dim xSql As String
                xSql = ""
                xSql = xSql + "SELECT ISNULL(SUM(ACTU),0) AS ACTU FROM ( "
                xSql = xSql + "SELECT SUM(ROUND(_CAPITALSOCIAL.MOVUF * _VALORUF.VALORUF,0)) AS ACTU "
                xSql = xSql + "FROM _CAPITALSOCIAL  "
                xSql = xSql + "INNER JOIN _VALORUF ON _VALORUF.FECHA = '" + Trim(FECHACOMPLETA3) + "' "
                xSql = xSql + "WHERE(_CAPITALSOCIAL.NROSOCIO = " + Trim(NROSOCIO) + " "
                'xSql = xSql + "AND _CAPITALSOCIAL.FECHA >= '" + Trim(AÑO) + "0101' )"
                xSql = xSql + "AND _CAPITALSOCIAL.FECHA >= '20170101' )"
                xSql = xSql + "UNION ALL  "
                xSql = xSql + "SELECT ROUND(CONVERT(NUMERIC(19,6),_INGRESOS.CAPITALSOCIAL-_INGRESOS.CAPITALSOCIAL2)/CONVERT(NUMERIC(19,6),UF1.VALORUF)*UF2.VALORUF,0)  AS CAPITAL "
                xSql = xSql + "FROM _INGRESOS  "
                xSql = xSql + "INNER JOIN _VALORUF UF1 ON UF1.FECHA = _INGRESOS.FECHA "
                xSql = xSql + "INNER JOIN _VALORUF UF2 ON UF2.FECHA = '" + Trim(FECHACOMPLETA3) + "' "
                xSql = xSql + "WHERE _INGRESOS.ESTADOCONT = 'S' AND _INGRESOS.TIPOINGRESO <> 'LIQUIDA' AND (_INGRESOS.CAPITALSOCIAL<>0 OR _INGRESOS.CAPITALSOCIAL2 <> 0) "
                xSql = xSql + "AND _INGRESOS.NROSOCIO = " + Trim(NROSOCIO) + " "
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
                conexiones.cerrar()
                '  --------------------------------------------------
            End If
        Catch ex As Exception
            ' VERIFICAR  QUE NO SE COMETA ERRROR AL BUSCAR 
        End Try

        Try
            'MONTO TOTAL
            Dim conexiones5 As New CConexion
            conexiones5.conexion()
            Dim command5 As SqlCommand = New SqlCommand(" SELECT SUM(MONTOAPORTE -MONTORETIRO) FROM [_CAPITALSOCIAL]  WHERE NROSOCIO = '" + Trim(NROSOCIO) + "'  ", conexiones5._conexion)
            conexiones5.abrir()
            Dim reader5 As SqlDataReader = command5.ExecuteReader()
            If reader5.HasRows Then
                Do While reader5.Read()
                    Sumatotal = reader5(0).ToString
                Loop
            Else
            End If
            reader5.Close()
            conexiones5.cerrar()
        Catch ex As Exception
            ' VERIFICAR  QUE NO SE COMETA ERRROR AL BUSCAR 
        End Try


        'TextrevalorizacionUF.Text = ValorMontoReajustado
        'Textmontorequerido.Text = ValorMontoReajustado
        'TextrevalorizacionUF.ReadOnly = True 
        Textvalorreajustado.Text = ValorMontoReajustado
        Textmontocapital.Text = Sumatotal
        Textsaldo.Text = ValorMontoReajustado - Sumatotal





    End Sub

    'frmBandejaCapital2.Texcapital4.Text = 1
    Sub acrualizarvalores()
        TimerRevalorizacionUF.Enabled = True
        TimerRevalorizacionUF.Start()



        Dim CONTADOR As Long = 0
        Dim FECHACOMPLETA2 As String = ""
        'variable con la fecha actual pero sin lo slash 
        Dim FECHACOMPLETA3 As String = ""
        ' variable año actual 
        Dim AÑO As String = ""
        FECHACOMPLETA2 = DateTime.Now().ToShortDateString()  '"16/06/2009"
        FECHACOMPLETA3 = Mid(FECHACOMPLETA2, 7, 10) + Mid(FECHACOMPLETA2, 4, 2) + Mid(FECHACOMPLETA2, 1, 2)
        AÑO = Mid(FECHACOMPLETA2, 7, 10)


        Dim consultasiyarecalculo As Long = 0
        ProgressrevalorisacionUF.Value = 0
        ProgressrevalorisacionUF.Maximum = 100
        TimerRevalorizacionUF.Interval = 1
        TimerRevalorizacionUF.Enabled = True

        Dim banderapase As Boolean = False

        Dim totalfilas As Integer = GridRevalorizacionUF.Rows.Count - 1
        Dim totalselecionado As Integer = 0
        Dim id_fila As String = ""
        Dim formapago As String = ""
        Dim NROSOCIO As String = ""
        ' MsgBox(totalfilas)
        For I = 0 To totalfilas
            'If frmBandejaCapital2.GridbandejaCapital.Rows(I).Cells(9).Value() = True Then
            'MsgBox("pase")

            id_fila = GridRevalorizacionUF.Rows(I).Cells(5).Value()
            'formapago = frmBandejaCapital2.GridbandejaCapital.Rows(I).Cells(4).Value()
            'MsgBox(formapago)
            NROSOCIO = GridRevalorizacionUF.Rows(I).Cells(3).Value()
            RevalorizacionUF(NROSOCIO)

            If Trim(Textvalorreajustado.Text) <> 0 Or Trim(Textvalorreajustado.Text) <> "" Then

                Dim conexionesee As New CConexion
                conexionesee.conexion()
                Dim commandee As SqlCommand = New SqlCommand("SELECT MONTO_SOLICITUD  FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL] WHERE [ID_SOLICITUD] ='" + Trim(id_fila) + "' ", conexionesee._conexion)
                conexionesee.abrir()
                Dim readeree As SqlDataReader = commandee.ExecuteReader()
                If readeree.HasRows Then
                    Do While readeree.Read()
                        consultasiyarecalculo = readeree(0)
                        'ValorUFdiaActual = reader(0)
                        'MsgBox(ValorUFdiaActual)
                    Loop
                Else
                End If
                readeree.Close()
                conexionesee.cerrar()

                'MsgBox(consultasiyarecalculo)
                'MsgBox(Textvalorreajustado.Text)
                If consultasiyarecalculo = Trim(Textvalorreajustado.Text) Then
                    CONTADOR = CONTADOR + 1
                    ' MsgBox(CONTADOR)
                    Label7.Text = +CONTADOR

                ElseIf consultasiyarecalculo <> Trim(Textvalorreajustado.Text) Then

                    Dim conexiones60 As New CConexion
                    conexiones60.conexion()
                    _adaptador.UpdateCommand = New SqlCommand(" UPDATE  [_RIESGO_SOLICITUD_GIRO_CAPITAL] set [MONTO_SOLICITUD]='" + Trim(Textvalorreajustado.Text) + "' , [SALDOVRUFCAPITAL] = '" + Trim(Textsaldo.Text) + "'  WHERE [ID_SOLICITUD] ='" + Trim(id_fila) + "'", conexiones60._conexion)
                    conexiones60.abrir()
                    _adaptador.UpdateCommand.Connection = conexiones60._conexion
                    _adaptador.UpdateCommand.ExecuteNonQuery()
                    conexiones60.cerrar()
                    Textvalorreajustado.Text = ""
                    Textmontocapital.Text = ""
                    Textsaldo.Text = ""

                End If

            End If
        Next

        'If banderapase = True Then
        'Me.Close()
        'ElseIf banderapase = False Then
        'MsgBox("Debe Seleccionar Solicitud para liberar ")
        'End If
        'frmBandejaCapital2.Timer1.Interval = 500
        'frmBandejaCapital2.Timer1.Start()
        'Me.Close()

        'ProgressrevalorisacionUF.Value = 100
        ' TimerRevalorizacionUF.Enabled = False
        Mensajeparpadiante.Enabled = False
        Label9.Text = "Revalorizacion Terminada"
        MsgBox("revalorización UF al dia actual  terminada ")
        ProgressrevalorisacionUF.Value = 100
        LLENARGRILLASOLICITUDESPORPAGAR()
    End Sub




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
  
        'Mensajeparpadiante.Start()
        acrualizarvalores()

    End Sub

    Private Sub TimerRevalorizacionUF_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerRevalorizacionUF.Tick
        ' Dim a As Integer = 0
        ' a = a + 1
        ProgressrevalorisacionUF.Increment(1)

        If ProgressrevalorisacionUF.Value = 101 Then
            Label6.Text = "Proceso Finalizado"
            ' Mensajeparpadiante.Stop()
        Else
            Label5.Text = ProgressrevalorisacionUF.Value & (" %")
        End If

    End Sub

    Private Sub Mensajeparpadiante_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mensajeparpadiante.Tick
        Static contador As Integer = 0
        contador = contador + 1
        If contador = 1 Then
            Label9.Visible = True
            ' Labelminicomponente.ForeColor = Color.Green
        ElseIf contador = 2 Then

            Label9.Visible = False
            'Labelminicomponente.ForeColor = Color.DarkRed
        ElseIf contador = 3 Then

            Label9.Visible = True
            'Labelminicomponente.ForeColor = Color.Black
            contador = 0
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GroupBox1.Visible = True
        CREACOLUMNA()
        Button2.Enabled = False
    End Sub

    Sub CREACOLUMNA()
        Dim newcol As DataGridViewColumn = New DataGridViewCheckBoxColumn
        newcol.HeaderText = "SELECCION"
        newcol.Name = "Nombrecol"
        newcol.DataPropertyName = "nombre_campo" 'Campo de enlace a datos
        GridRevalorizacionUF.Columns.Add(newcol)
    End Sub


    Sub acrualizarvaloresPERSONALIZADO()
        TimerRevalorizacionUF.Enabled = True
        TimerRevalorizacionUF.Start()




        Dim CONTADOR As Long = 0
        Dim FECHACOMPLETA2 As String = ""
        'variable con la fecha actual pero sin lo slash 
        Dim FECHACOMPLETA3 As String = ""
        ' variable año actual 
        Dim AÑO As String = ""
        '  FECHACOMPLETA2 = DateTime.Now().ToShortDateString()  '"16/06/2009"
        FECHACOMPLETA3 = Trim(Textdesdeaño.Text) + Trim(Textdesdemes.Text) + Trim(Textdesdedia.Text)

        AÑO = Mid(FECHACOMPLETA2, 7, 10)
        Dim consultasiyarecalculo As Long = 0
        ProgressrevalorisacionUF.Value = 0
        ProgressrevalorisacionUF.Maximum = 100
        TimerRevalorizacionUF.Interval = 1
        TimerRevalorizacionUF.Enabled = True

        Dim banderapase As Boolean = False
        Dim totalfilas As Integer = GridRevalorizacionUF.Rows.Count - 1
        Dim totalselecionado As Integer = 0
        Dim id_fila As String = ""
        Dim formapago As String = ""
        Dim NROSOCIO As String = ""
        ' MsgBox(totalfilas)
        For I = 0 To totalfilas
            'If frmBandejaCapital2.GridbandejaCapital.Rows(I).Cells(9).Value() = True Then
            'MsgBox("pase")
            If GridRevalorizacionUF.Rows(I).Cells("Nombrecol").Value() = True Then



                id_fila = GridRevalorizacionUF.Rows(I).Cells(5).Value()
                'formapago = frmBandejaCapital2.GridbandejaCapital.Rows(I).Cells(4).Value()
                'MsgBox(formapago)
                NROSOCIO = GridRevalorizacionUF.Rows(I).Cells(3).Value()
                RevalorizacionUFPERSONALIZADO(NROSOCIO)

                If Trim(Textvalorreajustado.Text) <> 0 Or Trim(Textvalorreajustado.Text) <> "" Then

                    Dim conexionesee As New CConexion
                    conexionesee.conexion()
                    Dim commandee As SqlCommand = New SqlCommand("SELECT MONTO_SOLICITUD  FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL] WHERE [ID_SOLICITUD] ='" + Trim(id_fila) + "' ", conexionesee._conexion)
                    conexionesee.abrir()
                    Dim readeree As SqlDataReader = commandee.ExecuteReader()
                    If readeree.HasRows Then
                        Do While readeree.Read()
                            consultasiyarecalculo = readeree(0)
                            'ValorUFdiaActual = reader(0)
                            'MsgBox(ValorUFdiaActual)
                        Loop
                    Else
                    End If
                    readeree.Close()
                    conexionesee.cerrar()

                    'MsgBox(consultasiyarecalculo)
                    'MsgBox(Textvalorreajustado.Text)
                    If consultasiyarecalculo = Trim(Textvalorreajustado.Text) Then
                        CONTADOR = CONTADOR + 1
                        ' MsgBox(CONTADOR)
                        Label7.Text = +CONTADOR

                    ElseIf consultasiyarecalculo <> Trim(Textvalorreajustado.Text) Then

                        Dim conexiones60 As New CConexion
                        conexiones60.conexion()
                        _adaptador.UpdateCommand = New SqlCommand(" UPDATE  [_RIESGO_SOLICITUD_GIRO_CAPITAL] set [MONTO_SOLICITUD]='" + Trim(Textvalorreajustado.Text) + "' , [SALDOVRUFCAPITAL] = '" + Trim(Textsaldo.Text) + "'  WHERE [ID_SOLICITUD] ='" + Trim(id_fila) + "'", conexiones60._conexion)
                        conexiones60.abrir()
                        _adaptador.UpdateCommand.Connection = conexiones60._conexion
                        _adaptador.UpdateCommand.ExecuteNonQuery()
                        conexiones60.cerrar()
                        Textvalorreajustado.Text = ""
                        Textmontocapital.Text = ""
                        Textsaldo.Text = ""

                    End If

                End If
            End If

        Next

       


        'If banderapase = True Then
        'Me.Close()
        'ElseIf banderapase = False Then
        'MsgBox("Debe Seleccionar Solicitud para liberar ")
        'End If
        'frmBandejaCapital2.Timer1.Interval = 500
        'frmBandejaCapital2.Timer1.Start()
        'Me.Close()

        'ProgressrevalorisacionUF.Value = 100
        ' TimerRevalorizacionUF.Enabled = False
        Mensajeparpadiante.Enabled = False
        Label9.Text = "Revalorizacion Terminada"
        MsgBox("revalorización UF al dia actual  terminada ")
        ProgressrevalorisacionUF.Value = 100
        LLENARGRILLASOLICITUDESPORPAGAR()




    End Sub
    Sub RevalorizacionUFPERSONALIZADO(ByVal NROSOCIO As String)
        'Variable dia actual '"16/06/2009 se recibe valor con slash "

        GridRevalorizacionUF.Rows.Add(NROSOCIO.ToString)

        Dim FECHACOMPLETA2 As String = ""
        'variable con la fecha actual pero sin lo slash 
        Dim FECHACOMPLETA3 As String = ""
        ' variable año actual 
        Dim AÑO As String = ""
        FECHACOMPLETA2 = DateTime.Now().ToShortDateString()  '"16/06/2009"
        FECHACOMPLETA3 = Trim(Textdesdeaño.Text) + Trim(Textdesdemes.Text) + Trim(Textdesdedia.Text)
        AÑO = Mid(FECHACOMPLETA2, 7, 10)
        'Dim ValorUFdiaActualstring As String = ""
        'Dim ValorUFdiaActualstringparte1 As String = ""
        'Dim ValorUFdiaActualstringparte2 As String = ""
        'Dim ValorUFdiaActual As Double
        Dim ValorMontoReajustado As Long = 0
        Dim valordiaactulauf As String = ""

        Dim Sumatotal As Long = 0
        Dim saldo As Long = 0
        'Dim nrosocio As String = ""
        'nrosocio = Trim(Textnrosocio.Text)
        'Dim sumatotal As Long
        'SELECT VALORUF FROM [LROSAS_R].[dbo].[_VALORUF] where FECHA='20150103' 
        Try
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
            conexionesee.cerrar()
        Catch ex As Exception
            ' VERIFICAR  QUE NO SE COMETA ERRROR AL BUSCAR 
        End Try
        'Textvalorufdiactual.Text = valordiaactulauf
        'MsgBox(NROSOCIO)
        Try
            If Trim(NROSOCIO) <> "" Then
                ' -------------------------------------------------
                Dim xSql As String
                xSql = ""
                xSql = xSql + "SELECT ISNULL(SUM(ACTU),0) AS ACTU FROM ( "
                xSql = xSql + "SELECT SUM(ROUND(_CAPITALSOCIAL.MOVUF * _VALORUF.VALORUF,0)) AS ACTU "
                xSql = xSql + "FROM _CAPITALSOCIAL  "
                xSql = xSql + "INNER JOIN _VALORUF ON _VALORUF.FECHA = '" + Trim(FECHACOMPLETA3) + "' "
                xSql = xSql + "WHERE(_CAPITALSOCIAL.NROSOCIO = " + Trim(NROSOCIO) + " "
                xSql = xSql + "UNION ALL  "
                xSql = xSql + "SELECT ROUND(CONVERT(NUMERIC(19,6),_INGRESOS.CAPITALSOCIAL-_INGRESOS.CAPITALSOCIAL2)/CONVERT(NUMERIC(19,6),UF1.VALORUF)*UF2.VALORUF,0)  AS CAPITAL "
                xSql = xSql + "FROM _INGRESOS  "
                xSql = xSql + "INNER JOIN _VALORUF UF1 ON UF1.FECHA = _INGRESOS.FECHA "
                xSql = xSql + "INNER JOIN _VALORUF UF2 ON UF2.FECHA = '" + Trim(FECHACOMPLETA3) + "' "
                xSql = xSql + "WHERE _INGRESOS.ESTADOCONT = 'S' AND _INGRESOS.TIPOINGRESO <> 'LIQUIDA' AND (_INGRESOS.CAPITALSOCIAL<>0 OR _INGRESOS.CAPITALSOCIAL2 <> 0) "
                xSql = xSql + "AND _INGRESOS.NROSOCIO = " + Trim(NROSOCIO) + " "
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
                conexiones.cerrar()
                '  --------------------------------------------------
            End If
        Catch ex As Exception
            ' VERIFICAR  QUE NO SE COMETA ERRROR AL BUSCAR 
        End Try

        Try
            'MONTO TOTAL
            Dim conexiones5 As New CConexion
            conexiones5.conexion()
            Dim command5 As SqlCommand = New SqlCommand(" SELECT SUM(MONTOAPORTE -MONTORETIRO) FROM [_CAPITALSOCIAL]  WHERE NROSOCIO = '" + Trim(NROSOCIO) + "'  ", conexiones5._conexion)
            conexiones5.abrir()
            Dim reader5 As SqlDataReader = command5.ExecuteReader()
            If reader5.HasRows Then
                Do While reader5.Read()
                    Sumatotal = reader5(0).ToString
                Loop
            Else
            End If
            reader5.Close()
            conexiones5.cerrar()
        Catch ex As Exception
            ' VERIFICAR  QUE NO SE COMETA ERRROR AL BUSCAR 
        End Try


        'TextrevalorizacionUF.Text = ValorMontoReajustado
        'Textmontorequerido.Text = ValorMontoReajustado
        'TextrevalorizacionUF.ReadOnly = True 
        Textvalorreajustado.Text = ValorMontoReajustado
        Textmontocapital.Text = Sumatotal
        Textsaldo.Text = ValorMontoReajustado - Sumatotal

    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Trim(Textdesdeaño.Text) = "" Or Trim(Textdesdemes.Text) = "" Or Trim(Textdesdedia.Text) = "" Then
            MsgBox("debe ingresar fecha a la cual desea recalcular ")
        Else
            acrualizarvaloresPERSONALIZADO()
            GRIDSOCIOS.Rows.Clear()
            GroupBox1.Visible = False
            ' Button2.Enabled = False
        End If

    End Sub

    Private Sub Textdesdedia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textdesdedia.TextChanged
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
        If Not IsNumeric(Trim(Textdesdeaño.Text)) Then
            MsgBox("Debe Ingresar Valores Numericos ")
        Else
            Dim TOTOAL As Double = 0
            TOTOAL = Len(Textdesdeaño.Text)
            If TOTOAL = 4 Then
                Button3.Focus()
            End If
        End If
    End Sub
End Class