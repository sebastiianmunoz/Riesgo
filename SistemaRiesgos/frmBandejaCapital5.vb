
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Public Class frmBandejaCapital5
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter
    Public adaptador2 As SqlDataAdapter = New SqlDataAdapter
    Public adaptador3 As SqlDataAdapter = New SqlDataAdapter

    Dim contador As Integer = 0
    Public _tabla30 As DataTable = New DataTable
    Public _tabla31 As DataTable = New DataTable
    Public _tabla26 As DataTable = New DataTable
    Dim newcol As New DataGridViewTextBoxColumn
    Dim FECHACOMPLETASINSALSH As String = ""
    Dim NROSOLICITUDESDENTRO7DIAS As String = ""
    Dim correopersonal As String = ""
    Dim clavecorreopersonal As String = ""
    Dim SUCURSAL2 As String = ""
    Dim NOMBRESOCIO As String = ""
    Dim FECHASOLICITUD As String = ""
   
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If contador < 100 Then
            ProgressBar1.Value = contador
            contador = contador + 1
        Else
            Timer1.Enabled = False
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = 100
        Timer1.Interval = 1
        Timer1.Enabled = True
        'Datadetalle
        Dim ID_SOLICITUD As String = ""
        Dim TIPOSOLICITUD As String = ""
        ID_SOLICITUD = Trim(Gridreporte2.Rows(0).Cells(0).Value())
        ' MsgBox(ID_SOLICITUD)
        Dim conexiones2 As New CConexion
        conexiones2.conexion()
        Dim command2 As SqlCommand = New SqlCommand(" SELECT [TIPOSOLICITUD2] FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL]  WHERE ID_SOLICITUD ='" + Trim(ID_SOLICITUD) + "'", conexiones2._conexion)
        conexiones2.abrir()
        Dim reader2 As SqlDataReader = command2.ExecuteReader()
        If reader2.HasRows Then
            Do While reader2.Read()
                TIPOSOLICITUD = (reader2(0).ToString)
                'NOMBRESOCIO = (reader2(0).ToString)
                'MsgBox(TIPOSOLICITUD)
            Loop
        Else
        End If
        reader2.Close()
        If Trim(TIPOSOLICITUD) = "R" Or Trim(TIPOSOLICITUD) = "F" Then
            Dim report As New ReporteFichaEvaluacionGiroCapitalRF
            Dim ds As New DataSet
            Try
                'agregar nueva tabla al dataset
                ds.Tables.Add("GiroCapital")
                'agregar las columnas
                Dim col As DataColumn
                For Each dgvCol As DataGridViewColumn In Gridreporte2.Columns
                    col = New DataColumn(dgvCol.Name)
                    ds.Tables("GiroCapital").Columns.Add(col)
                    'MsgBox(ds.Tables)
                Next
                Dim row As DataRow
                Dim colcount As Integer = Gridreporte2.Columns.Count
                For i As Integer = 0 To Gridreporte2.Rows.Count - 1
                    row = ds.Tables("GiroCapital").Rows.Add
                    For Each column As DataGridViewColumn In Gridreporte2.Columns
                        ' MsgBox(Datainfo.Rows.Item(i).Cells(column.Index).Value)
                        row.Item(column.Index) = Gridreporte2.Rows.Item(i).Cells(column.Index).Value
                    Next
                Next
            Catch ex As Exception
                MessageBox.Show("Error Converting from DataGridView" & ex.InnerException.ToString, _
                "Error Converting from DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            report.SetDataSource(ds.Tables(0))
            frmFichaEvaluacionGiroCapitalRF.CrystalReportViewer1.ReportSource = report
            frmFichaEvaluacionGiroCapitalRF.Visible = True

        Else


            Dim report As New ReporteFichaEvaluacionGiroCapital2
            Dim ds As New DataSet
            Try
                'agregar nueva tabla al dataset
                ds.Tables.Add("GiroCapital")
                'agregar las columnas
                Dim col As DataColumn
                For Each dgvCol As DataGridViewColumn In Gridreporte2.Columns
                    col = New DataColumn(dgvCol.Name)
                    ds.Tables("GiroCapital").Columns.Add(col)
                    'MsgBox(ds.Tables)
                Next
                Dim row As DataRow
                Dim colcount As Integer = Gridreporte2.Columns.Count
                For i As Integer = 0 To Gridreporte2.Rows.Count - 1
                    row = ds.Tables("GiroCapital").Rows.Add
                    For Each column As DataGridViewColumn In Gridreporte2.Columns
                        ' MsgBox(Datainfo.Rows.Item(i).Cells(column.Index).Value)
                        row.Item(column.Index) = Gridreporte2.Rows.Item(i).Cells(column.Index).Value
                    Next
                Next
            Catch ex As Exception
                MessageBox.Show("Error Converting from DataGridView" & ex.InnerException.ToString, _
                "Error Converting from DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            report.SetDataSource(ds.Tables(0))
            frmFichaEvaluacionGiroCapital2.CrystalReportViewer1.ReportSource = report
            frmFichaEvaluacionGiroCapital2.Visible = True
















            'frmFichaEvaluacionGiroCapital2.Visible = True
            'solicitudes_pendietes()
        End If
        'End Sub
        'frmFichaEvaluacionGiroCapitalRF.Visible = True
        'End If
        ProgressBar1.Value = 100
        Timer1.Enabled = False


    End Sub
    Private Sub frmBandejaCapital5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'BtncartaCapital.Enabled = False
        Button2.Enabled = True
        Dim cargo As String = ""
        Dim conexiones2 As New CConexion
        conexiones2.conexion()
        Dim command2 As SqlCommand = New SqlCommand("SELECT CARGO ,correo,clavecorreo FROM _RIESGO_PERFIL WHERE USUARIO='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "'", conexiones2._conexion)
        conexiones2.abrir()
        Dim reader2 As SqlDataReader = command2.ExecuteReader()
        If reader2.HasRows Then
            Do While reader2.Read()
                cargo = (reader2(0).ToString)
                correopersonal = (reader2(1).ToString)
                clavecorreopersonal = (reader2(2).ToString)
            Loop
        Else
        End If
        reader2.Close()
        conexiones2.cerrar()

        If cargo.Trim = "SFINANZAS" Then
            Button1.Visible = True
        Else
            Button1.Visible = False
        End If
        solicitudes_pendietes()

        Dim ID_SOLICITUD As String = ""
        ID_SOLICITUD = Trim(Datadetalle.Rows(0).Cells(0).Value())
        Dim SUMADESCUENTOS As Integer = 0

        Dim conexiones3 As New CConexion
        conexiones3.conexion()
        Dim command3 As SqlCommand = New SqlCommand("select  CUOTAGASTOS+MONTOABONAPRESTAMOS+[MONTOPAGAOTROS] AS SUMADESCUENTOS   from [_RIESGO_SOLICITUD_GIRO_CAPITAL] where ID_SOLICITUD='" + ID_SOLICITUD + "'  ", conexiones3._conexion)
        conexiones3.abrir()
        Dim reader3 As SqlDataReader = command3.ExecuteReader()
        If reader3.HasRows Then
            Do While reader3.Read()
                SUMADESCUENTOS = reader3(0).ToString
            Loop
        Else
        End If
        reader3.Close()
        conexiones3.cerrar()

        Dim MONTO As String = ""
        Dim MONTODESCUENTOSINCLUIDOS As Integer = 0
        MONTO = Trim(Datadetalle.Rows(0).Cells(3).Value())
        MONTODESCUENTOSINCLUIDOS = Int(MONTO) - Int(SUMADESCUENTOS)
        ' MsgBox(MONTODESCUENTOSINCLUIDOS)
        _tabla30.Rows.Clear()
        _tabla30.Columns.Clear()
        Dim conexiones4 As New CConexion
        conexiones4.conexion()
        '_adaptador.SelectCommand = New SqlCommand(" select  ID_SOLICITUD  ,SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD , ESTADO_SOLICITUD ,dbo.puntos(MONTO_SOLICITUD) ,CONVERT(varchar(8),RUT )+'-'+CONVERT(varchar(1),DVRUT ) AS RUT,NOMBRE_SOCIO  ,NROSOCIO,DESCRIPCION,giro.BANCO,descripcion as TIPO_CUENTA,NRO_CUENTA ,CORRELATIVO,FORMA_PAGO,USUARIO,sucursal  ,TIPO_SOLICITUD,dbo.puntos([TOTALCAPITALSOCIAL]),dbo.puntos([CORRECCION_MONETARIA]),dbo.puntos([CUOTAS_PARTICIPACION]) ,dbo.puntos([TOTAL_NORETIRABLE]) ,dbo.puntos([MONTO_DISPONIBLE]) ,dbo.puntos([MONTO_MAXIMO_RETIRABLE]),dbo.puntos([FILTRO_CAPITAL_MINIMO]),dbo.puntos([FILTRO_MONTO_SOLICITADO]),[FILTRO_GIROS_ANUAL],[FILTRO_GIROS_MENSUAL],[FILTRO_SOCIO_SINMORA] ,[FILTRO_AVAL_SINMORA],[FILTRO_RESTRICCIONES] ,[FILTRO_CAPITAL_GLOBAL],[COMENTARIO_EVALUACION],[COMENTARIO_SUBGERENTE],[COMENTARIO_SUBGERENTE_FINANZAS],[COMENTARIO_LIBERA_CAPITAL]from [_RIESGO_SOLICITUD_GIRO_CAPITAL]as giro left join _TESORERIA_TIPO_CUENTA_BANCO as teso on giro.TIPO_CUENTA  = teso.CODIGO where ID_SOLICITUD = '" + ID + "' ", conexiones4._conexion)
        _adaptador.SelectCommand = New SqlCommand("select  ID_SOLICITUD  ,SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD ,ESTADO_SOLICITUD ,'" + Trim(MONTO.ToString) + "'  as MONTO_SOLICITUD,CONVERT(varchar(8),RUT )+'-'+CONVERT(varchar(1),DVRUT ) AS RUT,NOMBRE_SOCIO  ,NROSOCIO,DESCRIPCION,giro.BANCO,descripcion as TIPO_CUENTA,NRO_CUENTA ,CORRELATIVO,FORMA_PAGO,USUARIO,sucursal  ,TIPO_SOLICITUD,CONVERT(varchar ,dbo.puntos([TOTALCAPITALSOCIAL]) )       as [TOTALCAPITALSOCIAL],CONVERT(varchar ,dbo.puntos([CORRECCION_MONETARIA]))as [CORRECCION_MONETARIA] ,CONVERT(varchar ,dbo.puntos([CUOTAS_PARTICIPACION]) ) as [CUOTAS_PARTICIPACION],CONVERT(varchar ,dbo.puntos([TOTAL_NORETIRABLE]) ) as [TOTAL_NORETIRABLE],CONVERT(varchar ,dbo.puntos([MONTO_DISPONIBLE]) ) as [MONTO_DISPONIBLE],CONVERT(varchar ,dbo.puntos([MONTO_MAXIMO_RETIRABLE]))as [MONTO_MAXIMO_RETIRABLE] ,[FILTRO_CAPITAL_MINIMO] ,[FILTRO_MONTO_SOLICITADO] ,[FILTRO_GIROS_ANUAL],[FILTRO_GIROS_MENSUAL],[FILTRO_SOCIO_SINMORA] ,[FILTRO_AVAL_SINMORA],[FILTRO_RESTRICCIONES],[FILTRO_CAPITAL_GLOBAL],[COMENTARIO_EVALUACION],[COMENTARIO_SUBGERENTE],[COMENTARIO_SUBGERENTE_FINANZAS],[COMENTARIO_LIBERA_CAPITAL],[VALORUFDIAACTUAL],dbo.puntos([CUOTAGASTOS]) as [CUOTAGASTOS] ,dbo.puntos([MONTOABONAPRESTAMOS]) as [MONTOABONAPRESTAMOS] ,(select case  when [TIPOSOLICITUD2] ='R' then 'RENUNCIA' WHEN [TIPOSOLICITUD2]='F' THEN 'FALLECIMIENTO' end  ) as  [TIPOSOLICITUD2]  ,[SALDOVRUFCAPITAL],dbo.puntos('" + MONTODESCUENTOSINCLUIDOS.ToString + "') AS SALDOFINAL , dbo.puntos([MONTOPAGAOTROS]) as [MONTOPAGAOTROS]  from [_RIESGO_SOLICITUD_GIRO_CAPITAL]as giro left join _TESORERIA_TIPO_CUENTA_BANCO as teso on giro.TIPO_CUENTA  = teso.CODIGO where ID_SOLICITUD='" + ID_SOLICITUD.ToString + "' ", conexiones4._conexion)
        _adaptador.Fill(_tabla30)
        Gridreporte2.DataSource = _tabla30
        conexiones4.cerrar()
        ' solicitudes_pendietes()
        llenacorreoelectorncio()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Anular()
    End Sub

    Sub Anular()

        Dim TOMAVALOR As String = ""
        Dim TOMAESTADO As String = ""
        Dim TIPO As String = ""
        Dim ID_SOLICITUD As String = ""
        Dim TIPOSOLICITUD2 As String = ""
        Dim CORRELATIVORF As String = ""
        Dim AYUDASOCIAL As Long = 0
        Dim NROSOCIO As String = ""

        TIPO = Trim(GridReporte.Rows(0).Cells(12).Value())
        ID_SOLICITUD = Trim(Datadetalle.Rows(0).Cells(0).Value())
        Dim conexiones3 As New CConexion
        conexiones3.conexion()
        Dim command3 As SqlCommand = New SqlCommand("select ESTADO_SOLICITUD , [TIPOSOLICITUD2] , CORRELATIVO,NROSOCIO  from  [_RIESGO_SOLICITUD_GIRO_CAPITAL]  WHERE ID_SOLICITUD = '" + Trim(Datadetalle.Rows(0).Cells(0).Value()) + "'  ", conexiones3._conexion)
        conexiones3.abrir()
        Dim reader3 As SqlDataReader = command3.ExecuteReader()
        If reader3.HasRows Then
            Do While reader3.Read()
                TOMAESTADO = reader3(0).ToString
                TIPOSOLICITUD2 = reader3(1).ToString
                CORRELATIVORF = reader3(2).ToString
                NROSOCIO = reader3(3).ToString

            Loop
        Else
        End If
        reader3.Close()
        conexiones3.cerrar()


        Dim xsql As String = ""
        xsql = ""
        xsql = xsql + " Select solidario2 From _ingresos"
        xsql = xsql + " Where nrosocio ='" + NROSOCIO + "'"
        xsql = xsql + " And codconcepto ='245'"
        xsql = xsql + " And id_solicapital = '" + ID_SOLICITUD + "'"
        xsql = xsql + " And (estadocont ='S' or estadocont ='C')"
        Dim conexiones As New CConexion
        conexiones.conexion()
        Dim command As SqlCommand = New SqlCommand(xsql, conexiones._conexion)
        conexiones.abrir()
        Dim reader As SqlDataReader = command.ExecuteReader()
        If reader.HasRows Then
            Do While reader.Read()
                AYUDASOCIAL = reader(0)
            Loop
        Else
        End If
        reader.Close()
        conexiones.cerrar()



        If Trim(TOMAESTADO) = "PAGADO" Then

            MsgBox("No se puede anular la solicitud esta ya se encuentra pagada")
            'If AYUDASOCIAL <> 0 Then


        ElseIf AYUDASOCIAL <> 0 Then

            MsgBox("No se puede Anular esta solicitud ya que posee ayuda social ")


        Else
            'MsgBox(frmRIESGO.Textusuario.Text)
            Textanulacion.Text = Trim(frmRIESGO.ToolNombres.Text)


            If TIPO = "EFECTIVO" Or TIPO = "CHEQUE" Or TIPO = "EX-SOCIOS" Or TIPO = "SIN-LIQUIDO" Then

                If TIPOSOLICITUD2 = "R" Or TIPOSOLICITUD2 = "F" Or TIPOSOLICITUD2 = "T" Or TIPOSOLICITUD2 = "C" Or TIPOSOLICITUD2 = "B" Then

                    Dim conexiones60 As New CConexion
                    conexiones60.conexion()
                    _adaptador.UpdateCommand = New SqlCommand("UPDATE [_RIESGO_SOLICITUD_GIRO_CAPITAL]  Set ESTADO_SOLICITUD='ANULADA' ,ESTADO_SOLICITUD2= 0,ESTADO_SOLICITUD3=0 ,[AUTORIZAANULA] ='" + Trim(Textanulacion.Text) + "',FECHAANULA=( SELECT GETDATE() )where ID_SOLICITUD= '" + ID_SOLICITUD + "'  ", conexiones60._conexion)
                    conexiones60.abrir()
                    _adaptador.UpdateCommand.Connection = conexiones60._conexion
                    _adaptador.UpdateCommand.ExecuteNonQuery()
                    conexiones60.cerrar()
                    frmEstadosGiroCapital.IdentificarEstados()
                    Me.Close()

                    Dim conexiones601 As New CConexion
                    conexiones601.conexion()
                    _adaptador.UpdateCommand = New SqlCommand("UPDATE [_INGRESOS]  set ESTADOCONT='A'  where CORRELATIVO = '" + CORRELATIVORF + "'  ", conexiones601._conexion)
                    conexiones601.abrir()
                    _adaptador.UpdateCommand.Connection = conexiones601._conexion
                    _adaptador.UpdateCommand.ExecuteNonQuery()
                    conexiones601.cerrar()
                    frmEstadosGiroCapital.IdentificarEstados()
                    Me.Close()
                Else
                    Dim conexiones60 As New CConexion
                    conexiones60.conexion()
                    _adaptador.UpdateCommand = New SqlCommand("UPDATE [_RIESGO_SOLICITUD_GIRO_CAPITAL]  set ESTADO_SOLICITUD='ANULADA' ,ESTADO_SOLICITUD2= 0,ESTADO_SOLICITUD3=0 ,[AUTORIZAANULA] ='" + Trim(Textanulacion.Text) + "' ,FECHAANULA=( SELECT GETDATE() )   where ID_SOLICITUD= '" + ID_SOLICITUD + "'  ", conexiones60._conexion)
                    conexiones60.abrir()
                    _adaptador.UpdateCommand.Connection = conexiones60._conexion
                    _adaptador.UpdateCommand.ExecuteNonQuery()
                    conexiones60.cerrar()
                    frmEstadosGiroCapital.IdentificarEstados()
                    Me.Close()
                End If

            ElseIf TIPO = "TRANSFERENCIA" Then

                Dim conexiones5 As New CConexion
                conexiones5.conexion()
                Dim command5 As SqlCommand = New SqlCommand(" SELECT ID_FILA  FROM [_RIESGO_DETA_NOMINA_TRANSFERENCIA] where ID_SOLICITUD= '" + ID_SOLICITUD + "' AND ESTADO_EN_NOMINA ='SELECCIONADO' ", conexiones5._conexion)
                conexiones5.abrir()
                Dim reader5 As SqlDataReader = command5.ExecuteReader()
                If reader5.HasRows Then
                    Do While reader5.Read()
                        TOMAVALOR = reader5(0).ToString
                    Loop
                Else
                End If
                reader5.Close()
                conexiones5.cerrar()


                If TOMAVALOR.Trim = "" Then
                    Dim conexiones60 As New CConexion
                    conexiones60.conexion()
                    _adaptador.UpdateCommand = New SqlCommand("UPDATE [_RIESGO_SOLICITUD_GIRO_CAPITAL]  set ESTADO_SOLICITUD='ANULADA' ,ESTADO_SOLICITUD2= 0,ESTADO_SOLICITUD3=0 , [AUTORIZAANULA] ='" + Trim(Textanulacion.Text) + "' where ID_SOLICITUD= '" + Trim(Datadetalle.Rows(0).Cells(0).Value()) + "'  ", conexiones60._conexion)
                    conexiones60.abrir()
                    _adaptador.UpdateCommand.Connection = conexiones60._conexion
                    _adaptador.UpdateCommand.ExecuteNonQuery()
                    conexiones60.cerrar()


                    If TIPOSOLICITUD2 = "R" Or TIPOSOLICITUD2 = "F" Or TIPOSOLICITUD2 = "T" Or TIPOSOLICITUD2 = "C" Or TIPOSOLICITUD2 = "B" Then

                        Dim conexiones601 As New CConexion
                        conexiones601.conexion()
                        _adaptador.UpdateCommand = New SqlCommand("UPDATE [_INGRESOS]  set ESTADOCONT='A'  where CORRELATIVO = '" + CORRELATIVORF + "'  ", conexiones601._conexion)
                        conexiones601.abrir()
                        _adaptador.UpdateCommand.Connection = conexiones601._conexion
                        _adaptador.UpdateCommand.ExecuteNonQuery()
                        conexiones601.cerrar()

                    Else
                        '  MsgBox("preuba ")
                    End If





                    frmEstadosGiroCapital.IdentificarEstados()
                    Me.Close()




                Else
                    MsgBox("No se puede anular  la solicitud esta transferencia ya pertenece a una nomina generada ")
                End If
                End If
        End If


    End Sub
    Sub solicitudes_pendietes()
        'MsgBox("pasa el  metodo")

        Dim NROSOCIO As String = ""
        'MsgBox(GridReporte.Rows(0).Cells(1).Value())
        NROSOCIO = Trim(GridReporte.Rows(0).Cells(6).Value())



        Textnorosico.Text = Trim(GridReporte.Rows(0).Cells(6).Value())

        Dim TOMAFEHCACOMPELTA As String = ""
        Dim FECHAMESAÑO As String = ""
        Dim FECHAAÑOMESANTERIOR As String = ""
        Dim MESANTERIOR As String = ""
        Dim AÑOANTERIOR As String = ""
        Dim MES As String = ""

        TOMAFEHCACOMPELTA = GridReporte.Rows(0).Cells(1).Value()
        FECHACOMPLETASINSALSH = Mid(TOMAFEHCACOMPELTA, 7, 10) + Mid(TOMAFEHCACOMPELTA, 4, 2) + Mid(TOMAFEHCACOMPELTA, 1, 2)

        Dim SIETEDIASATRAS As String = Int(Mid(TOMAFEHCACOMPELTA, 1, 2)) - 7
        Dim totaldiashabiles As String = ""

        FECHAMESAÑO = Mid(TOMAFEHCACOMPELTA, 7, 10) + Mid(TOMAFEHCACOMPELTA, 4, 2)
        MESANTERIOR = Int(Mid(TOMAFEHCACOMPELTA, 4, 2)) - 1
        MES = Mid(TOMAFEHCACOMPELTA, 4, 2)
        'MsgBox(MESANTERIOR)
        Dim DIA As String = Mid(TOMAFEHCACOMPELTA, 1, 2)




        If MES = "01" Then       'If MES = "01" And Int(DIA) < 12 Then  IF ORIGINAL 

            MESANTERIOR = "12"
            AÑOANTERIOR = Int(Mid(TOMAFEHCACOMPELTA, 7, 10)) - 1
            FECHAAÑOMESANTERIOR = AÑOANTERIOR + MESANTERIOR

            'If MESANTERIOR = 0 Then
            'MsgBox(AÑOANTERIOR)
            'MsgBox(FECHAAÑOMESANTERIOR)
            'MsgBox("año anterior ")
            'End If
        ElseIf MES <> "01" Then  'ElseIf MES <> "01" And Int(DIA) < 12 Then IF ORIGINAL 
            'IF SI EL MES  ES DISTINTO A A ENERO  Y EL LARGO DE LA RESTA ENTRE EL MES ACTUAL MENOS 1 ES 1 ENTOCES SE DEBE AGREGAR "0"  EJEMPLO (02-03-04-05-06-07-08-09)

            If Len(MESANTERIOR) = 1 Then
                MESANTERIOR = "0" + MESANTERIOR
                FECHAAÑOMESANTERIOR = Mid(TOMAFEHCACOMPELTA, 7, 10) + MESANTERIOR
                'IF SI EL MES  ES DISTINTO A A ENERO  Y EL LARGO DE LA RESTA ENTRE EL MES ACTUAL MENOS 1 ES 2 ENTOCES SE DEJA TAL CUAL   EJEMPLO (10-11-12)

                'MsgBox(Mid(TOMAFEHCACOMPELTA, 7, 10))

            ElseIf Len(MESANTERIOR) = 2 Then
                FECHAAÑOMESANTERIOR = Mid(TOMAFEHCACOMPELTA, 7, 10) + MESANTERIOR
            End If

            'ElseIf (MES <> "01" And Int(DIA) >= 12) Or (MES = "01" And Int(DIA) >= 12) Then  ' ElseIf (MES <> "01" And Int(DIA) >= 12) Or (MES = "01" And Int(DIA) >= 12) Then  IF ORIGINAL 
            'If MES = "01" Then
            'MESANTERIOR = "12"
            'Else
            'End If
            'FECHAAÑOMESANTERIOR = Mid(TOMAFEHCACOMPELTA, 7, 10) + Mid(TOMAFEHCACOMPELTA, 4, 2)
            'FECHAAÑOMESANTERIOR = Mid(TOMAFEHCACOMPELTA, 7, 10) + MESANTERIOR
        End If

        'MsgBox(DIA)
        'If MES = "01" And Int(DIA) < 12 Then

        '    If MESANTERIOR = 0 Then
        '        MESANTERIOR = "12"
        '        AÑOANTERIOR = Int(Mid(TOMAFEHCACOMPELTA, 7, 10)) - 1
        '        'MsgBox(AÑOANTERIOR)
        '        FECHAAÑOMESANTERIOR = AÑOANTERIOR + MESANTERIOR
        '        'MsgBox(FECHAAÑOMESANTERIOR)
        '        'MsgBox("año anterior ")
        '    End If
        '    ' MsgBox("preuba1")
        'ElseIf MES <> "01" And Int(DIA) < 12 Then

        '    If Len(MESANTERIOR) = 1 Then
        '        MESANTERIOR = "0" + MESANTERIOR
        '        'MsgBox(MESANTERIOR)
        '        FECHAAÑOMESANTERIOR = Mid(TOMAFEHCACOMPELTA, 7, 10) + MESANTERIOR
        '    End If
        '    ' MsgBox("preuba2")
        'ElseIf (MES <> "01" And Int(DIA) >= 12) Or (MES = "01" And Int(DIA) >= 12) Then

        '    If MES = "01" Then
        '        MESANTERIOR = "12"
        '    Else
        '     End If
        '    'FECHAAÑOMESANTERIOR = Mid(TOMAFEHCACOMPELTA, 7, 10) + Mid(TOMAFEHCACOMPELTA, 4, 2)
        '    FECHAAÑOMESANTERIOR = Mid(TOMAFEHCACOMPELTA, 7, 10) + MESANTERIOR
        'End If

            'MsgBox(FECHACOMPLETASINSALSH)
            'MsgBox(FECHAAÑOMESANTERIOR)
            'MsgBox(FECHAMESAÑO)
            'MsgBox(FECHAAÑOMESANTERIOR)
            _tabla31.Rows.Clear()
            _tabla31.Columns.Clear()
            Dim conexiones4 As New CConexion
            conexiones4.conexion()
            adaptador3.SelectCommand = New SqlCommand("SET LANGUAGE Español  SELECT DERIVEDTBL1.*  FROM (SELECT FECHA,NOMBREDIA,FESTIVO FROM (SELECT _BSC_CALENDARIO.FECHA, DATENAME(WEEKDAY,_BSC_CALENDARIO.FECHA) AS NOMBREDIA ,ISNULL(_FESTIVOS.FECHA,'XX')  AS FESTIVO FROM _BSC_CALENDARIO LEFT OUTER JOIN _FESTIVOS ON _BSC_CALENDARIO.FECHA= _FESTIVOS.FECHA WHERE LEFT(_BSC_CALENDARIO.FECHA,6) <='" + Trim(FECHAMESAÑO.ToString) + "' and LEFT(_BSC_CALENDARIO.FECHA,6)> = '" + Trim(FECHAAÑOMESANTERIOR.ToString) + "' )DERIVEDTBL WHERE DERIVEDTBL.FECHA <> DERIVEDTBL.FESTIVO AND DERIVEDTBL.NOMBREDIA <> 'Domingo' AND DERIVEDTBL.NOMBREDIA <> 'Sábado')DERIVEDTBL1  ", conexiones4._conexion)
            conexiones4.abrir()
            adaptador3.Fill(_tabla31)
            Gridmesactualmesanterior.DataSource = _tabla31
            conexiones4.cerrar()
            Dim DIAHABIL7DIASATRAS As String = ""
            Dim Totalfilas As Integer = Gridmesactualmesanterior.RowCount - 1
            Dim CONTADRODIAS As Integer = 0
            For z = 0 To Totalfilas
                ' MsgBox(Gridmesactualmesanterior.Rows(z).Cells(0).Value())
                ' MsgBox(FECHACOMPLETASINSALSH)
                CONTADRODIAS = CONTADRODIAS + 1
                ' Gridmesactualmesanterior
                If Trim(Gridmesactualmesanterior.Rows(z).Cells(0).Value()) = Trim(FECHACOMPLETASINSALSH) Then
                'If CONTADRODIAS = 7 Then
                'DIAHABIL7DIASATRAS = Trim(Gridmesactualmesanterior.Rows(z - 6).Cells(0).Value())
                ' Else
                Try
                    DIAHABIL7DIASATRAS = Trim(Gridmesactualmesanterior.Rows(z - 7).Cells(0).Value())
                    'End If
                    'DIAHABIL7DIASATRAS = Trim(Gridmesactualmesanterior.Rows(z - 7).Cells(0).Value())
                Catch ex As Exception
                End Try
                ' End If
                'Else
                'End If
                'MsgBox(DIAHABIL7DIASATRAS)
            End If
            Next
            'MsgBox(DIAHABIL7DIASATRAS)
            lableCargareporte.Text = DIAHABIL7DIASATRAS
            _tabla26.Rows.Clear()
            _tabla26.Columns.Clear()
            'NROSOLICITUDESDENTRO7DIAS = ""
            'Dim conexiones2 As New CConexion
            'conexiones2.conexion()
            'Dim command2 As SqlCommand = New SqlCommand("SELECT  COUNT(*)   from  [_RIESGO_SOLICITUD_GIRO_CAPITAL] where  [FECHA_SOLICITUD] < =  '" + Trim(FECHACOMPLETASINSALSH.ToString) + "' AND [FECHA_SOLICITUD] > =  '" + Trim(DIAHABIL7DIASATRAS.ToString) + "' and (estado_solicitud <>'ANULADA')  and NROSOCIO='" + Trim(NROSOCIO.ToString) + "'   ", conexiones2._conexion)
            'conexiones2.abrir()
            'Dim reader2 As SqlDataReader = command2.ExecuteReader()
            'If reader2.HasRows Then
            '    Do While reader2.Read()
            '        NROSOLICITUDESDENTRO7DIAS = (reader2(0).ToString)
            '    Loop
            'Else
            'End If
            'reader2.Close()
            'conexiones2.cerrar()
            'Dim valor As Long = 0
            'valor = Str(Int(DIAHABIL7DIASATRAS) - 7)
            'DIAHABIL7DIASATRAS = Str(valor)

            textfechasolicitud.Text = Trim(FECHACOMPLETASINSALSH)
            Textfecha7diasatras.Text = Trim(DIAHABIL7DIASATRAS)
            'crearcolumna()
            'ESTA CONSULTAME MUESTRA EL DETALLE PRO CADA SOLICITU QUE SE ENCUTRE DENTRO DE  LOS 7 DIAS  DE LA SOCILITUD ----- QUEDA PENDIETE  MIENTRAS EL SISTEMA MOSTRARA LA CANTIDAD DE SOLICTTUDES DENTRO DEL LOS 7 DIAS 
            '--------------------------------------------------------------------------------- CON  LA GRILLA SOLICUTDESPENDIETES 
            Dim conexiones44 As New CConexion
            conexiones44.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT  NROSOCIO as NRO_SOCIOS ,ID_SOLICITUD ,SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD ,DBO.PUNTOS(MONTO_SOLICITUD) AS MONTO_SOLICITUD ,ESTADO_SOLICITUD   from  [_RIESGO_SOLICITUD_GIRO_CAPITAL] where  [FECHA_SOLICITUD] < =  '" + Trim(FECHACOMPLETASINSALSH.ToString) + "' AND [FECHA_SOLICITUD] > =  '" + Trim(DIAHABIL7DIASATRAS.ToString) + "' and (estado_solicitud <>'ANULADA')  and NROSOCIO='" + Trim(NROSOCIO.ToString) + "' ORDER BY FECHA_SOLICITUD  desc  ", conexiones44._conexion)
            conexiones44.abrir()
            _adaptador.Fill(_tabla26)
            GridSolicitudesPendientes.DataSource = _tabla26
            conexiones44.cerrar()
    End Sub

    Private Sub BtncartaCapital_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtncartaCapital.Click
        Dim ID_SOLICITUD As String = ""
        Dim TIPOSOLICITUD As String = ""
        ID_SOLICITUD = Trim(Gridreporte2.Rows(0).Cells(0).Value())
        frmEnvioCorreoElectronico.TextID.Text = ID_SOLICITUD


        Dim NROSOCIO As String = ""
        Dim CORREOELECTRONICO As String = ""
        ' MsgBox(ID_SOLICITUD)
        Dim conexiones2 As New CConexion
        conexiones2.conexion()
        Dim command2 As SqlCommand = New SqlCommand(" SELECT [TIPOSOLICITUD2] , NROSOCIO ,  CASE WHEN SUCURSAL2='1' OR SUCURSAL2='4'  THEN 'VALPARAÍSO' WHEN SUCURSAL2='2'   THEN 'VIÑA DEL MAR' END AS SUCURSAL2 , NOMBRE_SOCIO,SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD  FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL]  WHERE ID_SOLICITUD ='" + Trim(ID_SOLICITUD) + "'", conexiones2._conexion)
        conexiones2.abrir()
        Dim reader2 As SqlDataReader = command2.ExecuteReader()
        If reader2.HasRows Then
            Do While reader2.Read()
                TIPOSOLICITUD = (reader2(0).ToString)
                NROSOCIO = (reader2(1).ToString)
                SUCURSAL2 = (reader2(2).ToString)
                NOMBRESOCIO = (reader2(3).ToString)
                FECHASOLICITUD = (reader2(4).ToString)
            Loop
        Else
        End If
        reader2.Close()
        conexiones2.cerrar()
        'MsgBox(FECHASOLICITUD)

        Dim conexiones22 As New CConexion
        conexiones22.conexion()
        'MsgBox(NROSOCIO)
        Dim command22 As SqlCommand = New SqlCommand(" SELECT EMAIL  FROM [_SOCIOS]  WHERE NROSOCIO ='" + Trim(NROSOCIO) + "'", conexiones22._conexion)
        conexiones22.abrir()
        Dim reader22 As SqlDataReader = command22.ExecuteReader()
        If reader22.HasRows Then
            Do While reader22.Read()
                'TIPOSOLICITUD = (reader22(0).ToString)
                CORREOELECTRONICO = (reader22(0).ToString)
                'MsgBox(TIPOSOLICITUD)
            Loop
        Else
        End If
        reader22.Close()

        ' CORREOELECTRONICO = "rossanacerda@gmail.com"
        'CORREOELECTRONICO = "sebastian.munoz@lautarorosas.cl"
        ' CORREOELECTRONICO = "sebastian.munoz.pinto@hotmail.com"

        frmEnvioCorreoElectronico.TxtNombre.Text = NOMBRESOCIO
        ' MsgBox(FECHASOLICITUD)
        frmEnvioCorreoElectronico.TextFECHA.Text = FECHASOLICITUD
        frmEnvioCorreoElectronico.Textsucursal.Text = SUCURSAL2
        frmEnvioCorreoElectronico.Visible = True

        frmEnvioCorreoElectronico.TextDE.Text = correopersonal
        frmEnvioCorreoElectronico.TextCONTRASEÑA.Text = clavecorreopersonal
        frmEnvioCorreoElectronico.TextAsunto.Text = "Solicitud de retiro de capital  o cuotas de participación"

        Dim textpreuba As String = ""
        Dim textpreuba1 As String = ""
        Dim textpreuba2 As String = ""
        Dim textpreuba3 As String = ""
        Dim textpreuba4 As String = ""
        Dim textpreuba5 As String = ""

        'textpreuba = "Ant.: Solicitud de retiro de capital o cuotas de participación.-"
        'textpreuba1 = "Ref.: Responde solicitud en los términos planteados.-"""
        'frmEnvioCorreoElectronico.txtmensaje1.Text =

        ' TextCoreoElectronico.Text = "sebastian.munoz@lautarorosas.cl"
        'muestracorreo()
        ' frmEnvioCorreoElectronico.TextPARA.Text = "sebastian.munoz@lautarorosas.cl"


        If Trim(CORREOELECTRONICO) = "" Then
            ' frmEnvioCorreoElectronico.TextPARA.Text = "secretaria.gerencia@lautarorosas.cl"
            MsgBox("Socio no tiene correo registrado ")
            ' TextCoreoElectronico.Text = "secretaria.gerencia@lautarorosas.cl"
        ElseIf Trim(CORREOELECTRONICO) <> "" Then
            frmEnvioCorreoElectronico.TextPARA.Text = CORREOELECTRONICO
            ' TextCoreoElectronico.Text = "secretaria.gerencia@lautarorosas.cl"
        End If

    End Sub

    Sub muestracorreo()
     

        frmEnvioCorreoElectronico.Textmuestraejecutiva.Text = SUCURSAL2 + vbCrLf +
      "" + vbCrLf +
      "Ant.: Solicitud de retiro de capital o cuotas de participación.-" + vbCrLf +
      "" + vbCrLf +
      "Ref.: Responde solicitud en los términos planteados.-""" + vbCrLf +
      "" + vbCrLf +
      "SR" + vbCrLf +
      "" + vbCrLf +
      NOMBRESOCIO + vbCrLf +
      "" + vbCrLf +
      "PRESENTE" + vbCrLf +
        "" + vbCrLf +
        "" + vbCrLf +
        "De mi consideración" + vbCrLf +
        "" + vbCrLf +
        "" + vbCrLf +
        "" + vbCrLf +
        "En relación a su solicitud de retiro de capital o cuotas de participación " + vbCrLf +
        "recibido vía (mail/telefónica/presencial) con fecha" + FECHASOLICITUD + " , cumplo con indicarle " + vbCrLf +
        "que esta solicitud fue recepcionada correctamente y ha sido ingresada a la" + vbCrLf +
        "correspondiente Nómina de Solicitudes de Retiro de Cuotas de Participación " + vbCrLf +
        "para su pago. Por favor, le pido tomar en cuenta las siguientes " + vbCrLf +
        "consideraciones:" + vbCrLf +
        "" + vbCrLf +
        "" + vbCrLf +
        "1) El artículo 19 bis de la Ley General de Cooperativas, recientemente " + vbCrLf +
        "modificado en virtud de la Ley Nº20.881 publicada en el Diario Oficial el pasado " + vbCrLf +
"06 de Enero del año 2016, establece que: Tratándose de las Cooperativas de " + vbCrLf +
"Ahorro y Crédito (como la nuestra), en ningún caso podrán devolverse cuotas " + vbCrLf +
"de participación sin que se hubieren enterado en la Cooperativa previamente " + vbCrLf +
"aportes de capital por una suma al menos equivalente al monto de las " + vbCrLf +
"devoluciones requeridas por causa legal, reglamentaria o estatutaria, que las " + vbCrLf +
"haga exigibles o procedentes. Dichos pagos serán exigibles y deberán " + vbCrLf +
"efectuarse atendiendo estrictamente a la fecha en que tenga lugar la " + vbCrLf +
"circunstancia que los causa. """ + vbCrLf +
         "" + vbCrLf +
         "" + vbCrLf +
         "" + vbCrLf +
        "" + vbCrLf +
        "Lo anterior implica que toda solicitud de retiro de cuotas de participación " + vbCrLf +
"recibido por la Cooperativa deberá pagarse siguiendo el orden de prelación " + vbCrLf +
"establecido por la norma, esto es, atendiendo estrictamente a la fecha en que " + vbCrLf +
"tenga lugar la renuncia, exclusión, fallecimiento del socio, solicitud de reducción" + vbCrLf +
"o retiro parcial de cuotas de participación. " + vbCrLf +
         "" + vbCrLf +
          "" + vbCrLf +
           "" + vbCrLf +
        "" + vbCrLf +
        "2) De esta forma, la Cooperativa cuenta con una plataforma digital de Capital " + vbCrLf +
"que registra las solicitudes de retiro conforme las fechas en que han sido " + vbCrLf +
"requeridas por nuestros socios, de modo que estas solicitudes se pagan " + vbCrLf +
"siguiendo esta prelación y siempre sujeto el pago a la condición de que, " + vbCrLf +
"previamente, ingresen cuotas de participación o aportes de capital por una " + vbCrLf +
"suma, al menos, equivalente al egreso de cuotas que deberá pagarse. Por " + vbCrLf +
"tratarse ésta última de una condición, la Cooperativa no puede dar una fecha " + vbCrLf +
"cierta de pago." + vbCrLf +
         "" + vbCrLf +
         "" + vbCrLf +
         "" + vbCrLf +
"3) Que la condición descrita en el numeral anterior debe ser respetada por la " + vbCrLf +
"Cooperativa por tratarse de una exigencia legal, cuestión que es informada " + vbCrLf +
"mensualmente y supervisada por la Superintendencia de Bancos e " + vbCrLf +
"Instituciones Financieras." + vbCrLf +
         "" + vbCrLf +
          "" + vbCrLf +
         "" + vbCrLf +
        "Por tanto, cumpliéndose lo antes señalado, la Cooperativa le comunicará la " + vbCrLf +
        "realización del pago de sus cuotas o capital requerido." + vbCrLf +
        "" + vbCrLf +
        "" + vbCrLf +
        "Agradeciendo su comprensión, le saludo muy atentamente;" + vbCrLf +
        "" + vbCrLf +
         "" + vbCrLf +
        "Jaime Emilio RODENAS Pizarro" + vbCrLf +
        "" + vbCrLf +
        "Gerente General" + vbCrLf +
        "" + vbCrLf +
        " Cooperativa de Ahorro y Crédito Lautaro ROSAS Limitada" + vbCrLf
    End Sub

    Sub enviocorreo()

        '"<br>" + SUCURSAL2 + "</b>" + vbCrLf +
        '"<br>" + vbCrLf +
        '"Ant.: Solicitud de retiro de capital o cuotas de participación.-" + vbCrLf +
        '"<br>" + vbCrLf +
        '"Ref.: Responde solicitud en los términos planteados.-""" + vbCrLf +
        '"<br>" + vbCrLf +
        '"<br>" + vbCrLf +
        '"<br>" + vbCrLf +
        '"<br> SR </b>" + vbCrLf +
        '"<br>" + vbCrLf +
        '"<b>" + NOMBRESOCIO + "</b>" + vbCrLf +
        '"<br>" + vbCrLf +
        '"PRESENTE" + vbCrLf +
        '"<br>" + vbCrLf +
        '"<br>" + vbCrLf +
        '"<br>" + vbCrLf +
        '"" + vbCrLf +
        '"De mi consideración" + vbCrLf +
        '"<br>" + vbCrLf +
        '"<br>" + vbCrLf +
        '"<br>" + vbCrLf +
        '"En relación a su solicitud de retiro de capital o cuotas de participación " + vbCrLf +
        '"<br>" + vbCrLf +
        '"recibido vía (mail/telefónica/presencial) con fecha" + FECHASOLICITUD + " , cumplo con indicarle " + vbCrLf +
        '"<br>" + vbCrLf +
        '"que esta solicitud fue recepcionada correctamente y ha sido ingresada a la" + vbCrLf +
        '"<br>" + vbCrLf +
        '"correspondiente Nómina de Solicitudes de Retiro de Cuotas de Participación " + vbCrLf +
        '"<br>" + vbCrLf +
        '"para su pago. Por favor, le pido tomar en cuenta las siguientes " + vbCrLf +
        '"<br>" + vbCrLf +
        '"consideraciones:" + vbCrLf +
        '"<br>" + vbCrLf +
        '"<br>" + vbCrLf +
        '"<br>" + vbCrLf +
        '"" + vbCrLf +
        '"1) El artículo 19 bis de la Ley General de Cooperativas, recientemente " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"modificado en virtud de la Ley Nº20.881 publicada en el Diario Oficial el pasado " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"06 de Enero del año 2016, establece que: Tratándose de las Cooperativas de " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"Ahorro y Crédito (como la nuestra), en ningún caso podrán devolverse cuotas " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"de participación sin que se hubieren enterado en la Cooperativa previamente " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"aportes de capital por una suma al menos equivalente al monto de las " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"devoluciones requeridas por causa legal, reglamentaria o estatutaria, que las " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"haga exigibles o procedentes. Dichos pagos serán exigibles y deberán " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"efectuarse atendiendo estrictamente a la fecha en que tenga lugar la " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"circunstancia que los causa. """ + vbCrLf +
        ' "<br>" + vbCrLf +
        ' "<br>" + vbCrLf +
        ' "<br>" + vbCrLf +
        '"" + vbCrLf +
        '"Lo anterior implica que toda solicitud de retiro de cuotas de participación " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"recibido por la Cooperativa deberá pagarse siguiendo el orden de prelación " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"establecido por la norma, esto es, atendiendo estrictamente a la fecha en que " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"tenga lugar la renuncia, exclusión, fallecimiento del socio, solicitud de reducción" + vbCrLf +
        ' "<br>" + vbCrLf +
        '"o retiro parcial de cuotas de participación. " + vbCrLf +
        ' "<br>" + vbCrLf +
        '  "<br>" + vbCrLf +
        '   "<br>" + vbCrLf +
        '"" + vbCrLf +
        '"2) De esta forma, la Cooperativa cuenta con una plataforma digital de Capital " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"que registra las solicitudes de retiro conforme las fechas en que han sido " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"requeridas por nuestros socios, de modo que estas solicitudes se pagan " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"siguiendo esta prelación y siempre sujeto el pago a la condición de que, " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"previamente, ingresen cuotas de participación o aportes de capital por una " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"suma, al menos, equivalente al egreso de cuotas que deberá pagarse. Por " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"tratarse ésta última de una condición, la Cooperativa no puede dar una fecha " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"cierta de pago." + vbCrLf +
        ' "<br>" + vbCrLf +
        ' "<br>" + vbCrLf +
        ' "<br>" + vbCrLf +
        ' "" + vbCrLf +
        '"3) Que la condición descrita en el numeral anterior debe ser respetada por la " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"Cooperativa por tratarse de una exigencia legal, cuestión que es informada " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"mensualmente y supervisada por la Superintendencia de Bancos e " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"Instituciones Financieras." + vbCrLf +
        ' "<br>" + vbCrLf +
        '  "<br>" + vbCrLf +
        '"" + vbCrLf +
        '"Por tanto, cumpliéndose lo antes señalado, la Cooperativa le comunicará la " + vbCrLf +
        ' "<br>" + vbCrLf +
        '"realización del pago de sus cuotas o capital requerido." + vbCrLf +
        ' "<br>" + vbCrLf +
        '  "<br>" + vbCrLf +
        '  "" + vbCrLf +
        '  "" + vbCrLf +
        '"Agradeciendo su comprensión, le saludo muy atentamente;" + vbCrLf +
        '  "<br>" + vbCrLf +
        '  "<br>" + vbCrLf +
        '  "<br>" + vbCrLf +
        ' "<b> Jaime Emilio RODENAS Pizarro </b> " + vbCrLf +
        ' "<br>" + vbCrLf +
        ' "Gerente General" + vbCrLf +
        ' "<br>" + vbCrLf +
        ' "<b> Cooperativa de Ahorro y Crédito Lautaro ROSAS Limitada </b> " + vbCrLf +
        ' "<br>" + vbCrLf
    End Sub

    Sub llenacorreoelectorncio()

        Dim NROSOCIO As String = ""
        Dim CORREOELECTRONICO As String = ""
        Dim id_solicitud As String = ""
        ID_SOLICITUD = Trim(Gridreporte2.Rows(0).Cells(0).Value())
        ' MsgBox(ID_SOLICITUD)
        Dim conexiones2 As New CConexion
        conexiones2.conexion()
        Dim command2 As SqlCommand = New SqlCommand(" SELECT  NROSOCIO  FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL]  WHERE ID_SOLICITUD ='" + Trim(ID_SOLICITUD) + "'", conexiones2._conexion)
        conexiones2.abrir()
        Dim reader2 As SqlDataReader = command2.ExecuteReader()
        If reader2.HasRows Then
            Do While reader2.Read()
                NROSOCIO = (reader2(0).ToString)
        Loop
        Else
        End If
        reader2.Close()
        conexiones2.cerrar()


        Dim conexiones22 As New CConexion
        conexiones22.conexion()
        'MsgBox(NROSOCIO)
        Dim command22 As SqlCommand = New SqlCommand(" SELECT EMAIL  FROM [_SOCIOS]  WHERE NROSOCIO ='" + Trim(NROSOCIO) + "'", conexiones22._conexion)
        conexiones22.abrir()
        Dim reader22 As SqlDataReader = command22.ExecuteReader()
        If reader22.HasRows Then
            Do While reader22.Read()
                CORREOELECTRONICO = (reader22(0).ToString)
            Loop
        Else
        End If
        reader22.Close()

        'CORREOELECTRONICO = "rossanacerda@gmail.com"
        '   TextCoreoElectronico.Text = "sebastian.munoz@lautarorosas.cl"

        'CORREOELECTRONICO = "sebastian.munoz@lautarorosas.cl"

        If Trim(CORREOELECTRONICO) = "" Then
            ' frmEnvioCorreoElectronico.TextPARA.Text = "secretaria.gerencia@lautarorosas.cl"
            'TextCoreoElectronico.Text = "secretaria.gerencia@lautarorosas.cl"
            MsgBox("Socio no tiene correo registrado ")
        ElseIf Trim(CORREOELECTRONICO) <> "" Then
            frmEnvioCorreoElectronico.TextPARA.Text = CORREOELECTRONICO
            TextCoreoElectronico.Text = CORREOELECTRONICO
        End If
        TextCoreoElectronico.Enabled = False
    End Sub




End Class