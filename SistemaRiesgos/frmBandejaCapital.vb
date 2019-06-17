Imports System.Data
Imports System.Data.SqlClient
Public Class frmBandejaCapital
    Dim plantillas As Metodos = New Metodos
    Dim tabla5 As New DataTable
    Public _tabla6 As DataTable = New DataTable
    Public _TABLA27 As DataTable = New DataTable
    Dim newcol As DataGridViewColumn = New DataGridViewCheckBoxColumn
    Dim Sucursal2 As String = ""
    Dim contadortimer As Integer = 0
    Dim Contadorllenagrill As Integer = 1
    Dim tiempo As Integer = 0
    Dim tiempomaximo As Integer = 500
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter


    Private Sub frmBandejaCapital_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ACTUALIZAGRILLAGIROSCAPITAL()
        ProgressBar1.Maximum = tiempomaximo
        Timer1.Enabled = True
        Timer1.Interval = 1
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Checkparaactualizaciongrilla.Checked = False Then
            tiempo = tiempo + 1
            If (tiempo = tiempomaximo) Then
                sacarcolumna()
                ACTUALIZAGRILLAGIROSCAPITAL()
                ProgressBar1.Value = 0
                tiempo = 0
            Else
                ProgressBar1.Value = tiempo
            End If
        End If
    End Sub
    Private Sub Colorfilas_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Colorfilas.CheckStateChanged
        If Colorfilas.CheckState = 1 Then
            COLOREAR()

        ElseIf Colorfilas.CheckState = 0 Or Colorfilas.CheckState <> 0 And Colorfilas.CheckState <> 1 Then
            Dim Totalfilas As Integer = GridSupervisada.Rows.Count - 1
            For z = 0 To Totalfilas
                GridSupervisada.Rows(z).Cells(2).Style.BackColor = Color.White
                GridSupervisada.Rows(z).Cells(2).Style.ForeColor = Color.Black
            Next
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Gridnominaseleccion.Rows.Clear()
    End Sub
    Private Sub CheckColorear_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckColorear.CheckedChanged
        If CheckColorear.Checked = True Then
            COLOREAR()
        ElseIf CheckColorear.Checked = False Then
        End If
    End Sub

    Private Sub btnEnviar_nomina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar_nomina.Click
        Dim TOTOLFILAS As Integer = Gridnominaseleccion.Rows.Count - 1
        Dim TOMAVALOR As String = ""
        Dim BANDERA As Boolean = False
        Dim VALORZ As Integer = 0
        If IsNothing(Gridnominaseleccion.Rows(0).Cells(0).Value()) Then
            MsgBox("Debe Generar una Nómina antes de enviar ")
        Else
            For X = 0 To TOTOLFILAS
                TOMAVALOR = Gridnominaseleccion.Rows(X).Cells(0).Value()
                For d = X + 1 To TOTOLFILAS - 1
                    If TOMAVALOR = Gridnominaseleccion.Rows(d).Cells(0).Value() Then
                        BANDERA = True
                    End If
                Next
            Next
            If BANDERA = False Then
                ENVIANOMINA()
            ElseIf BANDERA = True Then
                MsgBox("Duplicacion De solicitudes de transferencia  en nómina generada ")
            End If
        End If
    End Sub




    Private Sub GridbandejaCapital_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridbandejaCapital.SelectionChanged
        Dim ID As String = ""
        Try
            txtFecha.Text = ""
            txtMonto.Text = ""
            txtNrosocio.Text = ""
            txtEjecutiva.Text = ""
            txtSucursal.Text = ""
            ID = GridbandejaCapital.Rows(GridbandejaCapital.CurrentRow.Index).Cells("ID_SOLICITUD").Value
            txtFecha.Text = GridbandejaCapital.Rows(GridbandejaCapital.CurrentRow.Index).Cells("FECHA_SOLICITUD").Value
            txtMonto.Text = GridbandejaCapital.Rows(GridbandejaCapital.CurrentRow.Index).Cells("MONTO").Value

            Dim conexiones2 As New CConexion
            conexiones2.conexion()
            Dim command2 As SqlCommand = New SqlCommand("select [USUARIO],[SUCURSAL],NROSOCIO FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL] where ID_SOLICITUD ='" + Trim(ID) + "' ", conexiones2._conexion)
            conexiones2.abrir()
            Dim reader2 As SqlDataReader = command2.ExecuteReader()
            If reader2.HasRows Then
                Do While reader2.Read()
                    txtEjecutiva.Text = (reader2(0).ToString)
                    txtSucursal.Text = (reader2(1).ToString)
                    txtNrosocio.Text = (reader2(2).ToString)
                Loop
            Else
            End If
            reader2.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridSupervisada_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridSupervisada.SelectionChanged

        Dim ID As String = ""
        Dim nronomina As String = ""
        Dim estadoNOMINA As String = ""
        Textid.Text = ""
        TEXTESTADONOMINA.Text = ""
        Try
            ID = GridSupervisada.Rows(GridSupervisada.CurrentRow.Index).Cells(8).Value
            Textid.Text = GridSupervisada.Rows(GridSupervisada.CurrentRow.Index).Cells(0).Value
            nronomina = GridSupervisada.Rows(GridSupervisada.CurrentRow.Index).Cells(0).Value
            TEXTESTADONOMINA.Text = Trim(GridSupervisada.Rows(GridSupervisada.CurrentRow.Index).Cells(2).Value)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Textid.Text = "" Then
            MsgBox("Debe Existir  por lo menos una nómina Supervisada  para ver su detalle")
        Else
            If TEXTESTADONOMINA.Text.Trim = "APROBADA" Or TEXTESTADONOMINA.Text.Trim = "PAGADA" Then
                My.Forms.frmBandejaCapital3.MdiParent = My.Forms.frmRIESGO
                My.Forms.frmBandejaCapital3.WindowState = FormWindowState.Normal
                My.Forms.frmBandejaCapital3.Show()
            Else
                MsgBox("Para Analizar la nomina debe tener estado APROBADA o PAGADA")
            End If
        End If
    End Sub




    'METODOS----------------------------------------------------------------------------- 

    'COLOREA  EL ESTADO   FINAL DE LAS NOMINAS DE TRANSFERENCIA -------------------------
    Sub COLOREAR()
        Dim Totalfilas As Integer = GridSupervisada.RowCount - 1
        Dim Tomastring As String = ""
        Dim TOMA2 As String = ""
        Dim TOMA3 As String = ""

        For z = 0 To Totalfilas
            'Guarda el  valor de la columna estado --------------------------------------
            Tomastring = GridSupervisada.Rows(z).Cells(2).Value()

            If Trim(Tomastring) = "GENERADA" Then
                GridSupervisada.Rows(z).Cells(2).Style.BackColor = Color.Orange
                GridSupervisada.Rows(z).Cells(2).Style.ForeColor = Color.White

                GridSupervisada.Rows(z).Cells(0).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(1).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(3).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(4).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(5).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(6).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(7).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(8).Style.BackColor = Color.Aquamarine


            ElseIf Trim(Tomastring) = "APROBADA" Then
                GridSupervisada.Rows(z).Cells(2).Style.BackColor = Color.Green
                GridSupervisada.Rows(z).Cells(2).Style.ForeColor = Color.GreenYellow
                GridSupervisada.Rows(z).Cells(0).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(1).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(3).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(4).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(5).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(6).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(7).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(8).Style.BackColor = Color.Aquamarine

            ElseIf Trim(Tomastring) = "RECHAZADA" Then
                GridSupervisada.Rows(z).Cells(2).Style.BackColor = Color.Red
                GridSupervisada.Rows(z).Cells(2).Style.ForeColor = Color.White
                GridSupervisada.Rows(z).Cells(0).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(1).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(3).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(4).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(5).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(6).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(7).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(8).Style.BackColor = Color.Aquamarine
            End If

            If Trim(Tomastring) = "APROBADA" Then
                GridSupervisada.Rows(z).Cells(2).Value() = "PAGADA"
                GridSupervisada.Rows(z).Cells(2).Style.BackColor = Color.Blue
                GridSupervisada.Rows(z).Cells(2).Style.ForeColor = Color.White
                GridSupervisada.Rows(z).Cells(0).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(1).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(3).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(4).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(5).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(6).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(7).Style.BackColor = Color.Aquamarine
                GridSupervisada.Rows(z).Cells(8).Style.BackColor = Color.Aquamarine

            End If
        Next
    End Sub

    'Agrega  columna para seleccionar el requerimiento -------------------------------------------------------------------------------------
    Sub crearcolumna()
        If GridbandejaCapital.Columns.Contains("Nombrecol") Then
        Else
            newcol.HeaderText = "SELECCION"
            newcol.Name = "Nombrecol"
            newcol.DataPropertyName = "nombre_campo" 'Campo de enlace a datos
            GridbandejaCapital.Columns.Add(newcol)
        End If
    End Sub
    'Saca  columna  cuando se actualiza la grila de solicitud   de transferencia ------------------------------------------------------------
    Sub sacarcolumna()
        GridbandejaCapital.Columns.Remove(newcol)
    End Sub

    Private Sub btnGenera_Nomina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenera_Nomina.Click
        'Verifica que exista por lo menos una solicitud  de transferencia  para  generar una nomina -----------------------------------------   
        If IsNothing(GridbandejaCapital) Then
            MsgBox("Debe Existir almenos  una transferencia para generar  una nomina ")
        Else
            Gridnominaseleccion.Rows.Clear()
            llenanominaseleccion()
        End If
    End Sub


    'GENERA LA NOMINA  PARA SU ENVIO 
    Sub llenanominaseleccion()

        '0ID_SOLICITUD
        '1FECHA_SOLICITUD
        '2ESTADO
        '3RUT
        '4NOMBRES
        '5PATERNO 
        '6MATERNO
        '7MONTO
        '8BANCO
        '9CUENTA
        '10FORMA_PAGO
        '11EJECUTIVO
        '12Nombrecol
        '13TIPOSOLICITUD2

        Dim totalfilas As Integer = GridbandejaCapital.RowCount - 1
        Dim GUARDAIDOPERACION As String = ""
        Dim Nombres As String = ""
        Dim SegundoNombre As String = ""
        Dim paterno As String = ""
        Dim materno As String = ""
        Dim formapago As String = ""
        Dim banco As String = ""
        Dim nrocuentabancaria As String = ""
        Dim monto As Integer = 0
        Dim sectorfinanciero As String = ""

        For i = 0 To totalfilas
            'RECORRE  LA GRILLA DE LAS SOLICITUDES  DE TRANSFERENCIA  Y  TOMA LAS QUE ESTAN SELECCIONADA 
            If GridbandejaCapital.Rows(i).Cells("Nombrecol").Value() = True Then
                ' SE ENVIA  A LA GRILLA NOMINA SELECCION  QUE ES DONDE SE GENERA LA NOMINA  FINAL  PARA SU  SUPERVICION 
                Gridnominaseleccion.Rows.Add(GridbandejaCapital.Rows(i).Cells("ID_SOLICITUD").Value(), GridbandejaCapital.Rows(i).Cells("FECHA_SOLICITUD").Value(), GridbandejaCapital.Rows(i).Cells("ESTADO").Value(), GridbandejaCapital.Rows(i).Cells("RUT").Value(), GridbandejaCapital.Rows(i).Cells("NOMBRES").Value(), GridbandejaCapital.Rows(i).Cells("PATERNO").Value(), GridbandejaCapital.Rows(i).Cells("MATERNO").Value(), frmEvaluarCapital.PuntoX(GridbandejaCapital.Rows(i).Cells("MONTO").Value()), GridbandejaCapital.Rows(i).Cells("BANCO").Value(), GridbandejaCapital.Rows(i).Cells("CUENTA").Value(), GridbandejaCapital.Rows(i).Cells("NRO_CUENTA").Value(), GridbandejaCapital.Rows(i).Cells("FORMA_PAGO").Value(), GridbandejaCapital.Rows(i).Cells("TIPOSOLICITUD2").Value())
            End If
        Next
        '************ NOMINA GENERADA  ****************************** 
        Dim filas3 As Integer = Gridnominaseleccion.RowCount - 1
        Dim suma2 As Integer = 0
        Dim t As Integer
        Dim total As String = "TOTAL NOMINA"
        For t = 0 To filas3 - 1
            'SUMA EL TOTAL  DE TODAS LAS SOLICITUDES DE TRNASFERENCIA  QUE CONFORMAN LA NOMINA GENERADA  
            suma2 = suma2 + Gridnominaseleccion.Rows(t).Cells(7).Value()
            Gridnominaseleccion.Rows(filas3).Cells(7).Value = frmEvaluarCapital.PuntoX(suma2)
            Gridnominaseleccion.Rows(filas3).Cells(6).Value() = total
        Next
    End Sub

    'ENVIA LA NOMINA PARA LA SUPERVICON  DE LA SUBGERENCIA 
    Sub ENVIANOMINA()
        'PARA QUE FUNCIONE LA ACTUALIZACION DE LA NOMINA 
        'variables decomponer rut ***** 
        Dim cadena As String
        Dim tabla() As String
        Dim n As Integer
        Dim tomarut As String
        Dim tomadigito As String
        '*******************************
        Dim rutfinal As Integer = 0
        Dim ID_SOLICITUD As String = ""
        Dim Fecha_solicitud As String = ""
        Dim estado As String = ""
        Dim rut As String = ""
        Dim nombres As String = ""
        Dim paterno As String = ""
        Dim materno As String = ""
        Dim monto As String = ""
        Dim banco As String = ""
        Dim cuenta As String = ""
        Dim nrocuenta As String = ""
        Dim formapago As String = ""
        Dim maximanomina As String = ""
        Dim numeronomina As Integer = 0
        Dim estadonomina As String = "GENERADA"
        Dim sumatotalnomina As Integer = 0

        'SELECCIONA EL NUMERO MAS ALTO QUE EXITE DENTRO DE LA TABLA _RIESGO_ENCA_NOMINA_TRANSFERENCIA  DE UNA  NOMINA  
        Dim conexiones2 As New CConexion
        conexiones2.conexion()
        Dim command2 As SqlCommand = New SqlCommand("SELECT MAX(NRO_NOMINA) FROM _RIESGO_ENCA_NOMINA_TRANSFERENCIA", conexiones2._conexion)
        conexiones2.abrir()
        Dim reader2 As SqlDataReader = command2.ExecuteReader()
        If reader2.HasRows Then
            Do While reader2.Read()
                maximanomina = (Trim(reader2(0).ToString))
            Loop
        Else
            MsgBox("ERROR")
        End If
        reader2.Close()
        'SI NO  EXISTEN UN NUMERO  EL SISTEMA POR DEFECTO INGRESA U 1 
        If maximanomina = "" Then
            numeronomina = 1
        Else
            'SI EXISTE UN NUMERO MAYOR  SE LE SUMA UNO  PARA LUEGO INGRESARLO 
            numeronomina = CInt(maximanomina)
            numeronomina = numeronomina + 1

        End If
        'RECORREMOS LA GRILA QUE  TIENE LA NOMINA  GENERADA PARA SUPERVISAR  Y TOMA  CADA VALOR DE CADA  SOLICITUD DENTRO DE LA NOMINA DE TRANSFERENCIA  
        Dim totalfilas As Integer = Gridnominaseleccion.RowCount - 1
        For i = 0 To totalfilas - 1

            'DATOS POR CADA  SOLICITUD DE TRANSFERENCIA----------------------------------------------------------------------------------------------
            ID_SOLICITUD = Gridnominaseleccion.Rows(i).Cells(0).Value().ToString
            Fecha_solicitud = Gridnominaseleccion.Rows(i).Cells(1).Value().ToString
            'MsgBox(Fecha_solicitud)
            Fecha_solicitud = Fecha_solicitud.Substring(6, 4) + Fecha_solicitud.Substring(3, 2) + Fecha_solicitud.Substring(0, 2)
            ' MsgBox(Fecha_solicitud)
            estado = Gridnominaseleccion.Rows(i).Cells(2).Value().ToString
            rut = Gridnominaseleccion.Rows(i).Cells(3).Value().ToString
            tabla = Split(rut, "-")
            tomarut = 0
            tomadigito = ""

            For n = 0 To UBound(tabla, 1)
                ' MessageBox.Show(tabla(n))
                If n = 0 Then
                    tomarut = (tabla(n))
                Else
                    tomadigito = (tabla(n))
                End If
            Next

            nombres = Trim(Gridnominaseleccion.Rows(i).Cells(4).Value().ToString)
            paterno = Trim(Gridnominaseleccion.Rows(i).Cells(5).Value().ToString)
            materno = Trim(Gridnominaseleccion.Rows(i).Cells(6).Value().ToString)
            monto = Trim(Int(Gridnominaseleccion.Rows(i).Cells(7).Value()))
            ' sumatotalnomina = sumatotalnomina + CInt(monto)
            banco = Trim(Gridnominaseleccion.Rows(i).Cells(8).Value().ToString)
            cuenta = Trim(Gridnominaseleccion.Rows(i).Cells(9).Value().ToString)
            nrocuenta = Trim(Gridnominaseleccion.Rows(i).Cells(10).Value().ToString)
            formapago = Trim(Gridnominaseleccion.Rows(i).Cells(11).Value().ToString)


            'DATOS POR CADA  SOLICITUD DE TRANSFERENCIA----------------------------------------------------------------------------------------------
            'DETALLE  DE LA NOMINA   INSERTA  CADA  DATO DE CADA SOLICITUDE DE LA NOMINA  EN LA TABLA  [_RIESGO_DETA_NOMINA_TRANSFERENCIA]
            'select ([MONTO_SOLICITUD]-([CUOTAGASTOS]+[MONTOABONAPRESTAMOS])) as  total   from  [_RIESGO_SOLICITUD_GIRO_CAPITAL]  where ID_SOLICITUD=7690  


            Dim conexiones As New CConexion
            Dim command As SqlCommand

            'CALFARO DESDE AQUI
            Dim xActualiza As String
            xActualiza = Gridnominaseleccion.Rows(i).Cells("TIPOSOLICITUD2").Value()

            '============================================================================================================================
            '============================================================================================================================
            '============================================================================================================================
            ' OJO HAY QUE AGREGAR COLUMNA TIPOSOLICITUD2
            '============================================================================================================================
            '============================================================================================================================
            '============================================================================================================================

            If xActualiza = "C" Or xActualiza = "R" Or xActualiza = "F" Then
                conexiones.conexion()
                conexiones.abrir()
                Dim cmd1 As New SqlCommand("_LAUCOOP_PRELACION_ACTUALIZA_CAPITAL", conexiones._conexion)
                cmd1.CommandType = CommandType.StoredProcedure
                Dim prm1 As SqlParameter = New SqlParameter("@FECHA", SqlDbType.NChar, 30)
                cmd1.Parameters.Add(prm1)

                Dim prm2 As SqlParameter = New SqlParameter("@ID_SOLICITUD", SqlDbType.NChar, 30)
                cmd1.Parameters.Add(prm2)

                With cmd1
                    .Parameters("@FECHA").Value = "hoy"
                    .Parameters("@ID_SOLICITUD").Value = ID_SOLICITUD
                End With
                Dim dr1 As SqlDataReader = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                conexiones.cerrar()

                'CALFARO HASTA AQUI
            End If



            Dim monto_solicitudmenosdecuentos As Long
            Dim conexiones22 As New CConexion
            conexiones22.conexion()
            '  Dim command22 As SqlCommand = New SqlCommand("select ([MONTO_SOLICITUD]-([CUOTAGASTOS]-[MONTOABONAPRESTAMOS]-[MONTOPAGAOTROS]+[OTROSHABERES])) as  total   from  [_RIESGO_SOLICITUD_GIRO_CAPITAL]  where ID_SOLICITUD='" + ID_SOLICITUD + "'  ", conexiones22._conexion)
            ' conexiones22.abrir()
            Dim command22 As SqlCommand = New SqlCommand("select [MONTO_SOLICITUD] as  total   from  [_RIESGO_SOLICITUD_GIRO_CAPITAL]  where ID_SOLICITUD='" + ID_SOLICITUD + "'  ", conexiones22._conexion)
            conexiones22.abrir()
            Dim reader22 As SqlDataReader = command22.ExecuteReader()
            If reader22.HasRows Then
                Do While reader22.Read()
                    monto_solicitudmenosdecuentos = (Trim(reader22(0).ToString))
                Loop
            Else
                ' MsgBox("ERROR")
            End If
            reader22.Close()

            '  monto_solicitudmenosdecuentos = monto - monto_solicitudmenosdecuentos

            conexiones.conexion()
            _adaptador.InsertCommand = New SqlCommand("INSERT INTO [_RIESGO_DETA_NOMINA_TRANSFERENCIA]([NRO_NOMINA],[ID_SOLICITUD],[FECHA_SOLICITUD],[ESTADO_SOLICITUD],[RUT],[DVRUT],[NOMBRES],[PATERNO],[MATERNO],[MONTO_SOLICITUD],[BANCO],[TIPO_CUENTA],[NRO_CUENTA],[FORMA_PAGO])VALUES('" + numeronomina.ToString + "','" + Trim(ID_SOLICITUD.ToString) + "','" + Trim(Fecha_solicitud.ToString) + "','" + Trim(estado.ToString) + "','" + Trim(tomarut.ToString) + "','" + Trim(tomadigito.ToString) + "','" + Trim(nombres.ToString) + "','" + Trim(paterno.ToString) + "','" + Trim(materno.ToString) + "','" + Trim(monto_solicitudmenosdecuentos.ToString) + "','" + Trim(banco.ToString) + "','" + Trim(cuenta.ToString) + "','" + Trim(nrocuenta.ToString) + "','" + Trim(formapago.ToString) + "')", conexiones._conexion)
            conexiones.abrir()
            _adaptador.InsertCommand.Connection = conexiones._conexion
            _adaptador.InsertCommand.ExecuteNonQuery()
            conexiones.cerrar()

            'DEJA  CONFIRMADO  EN LA TABLA [_RIESGO_SOLICITUD_GIRO_CAPITAL] set EN_NOMINA  = 1  UNA SOLICTUD  ESTA DENTRO DE UNA NOMINA  
            Dim conexiones61 As New CConexion
            conexiones61.conexion()
            _adaptador.UpdateCommand = New SqlCommand("update [_RIESGO_SOLICITUD_GIRO_CAPITAL] set EN_NOMINA  = 1  where ID_SOLICITUD = '" + Trim(ID_SOLICITUD) + "'", conexiones61._conexion)
            conexiones61.abrir()
            _adaptador.UpdateCommand.Connection = conexiones61._conexion
            _adaptador.UpdateCommand.ExecuteNonQuery()
            conexiones61.cerrar()

            'Dim conexiones6 As New CConexion
            'conexiones6.conexion()
            '_adaptador.UpdateCommand = New SqlCommand("update [_RIESGO_SOLICITUD_GIRO_CAPITAL] set EN_NOMINA  = 1  where ID_SOLICITUD = '" + Trim(ID_SOLICITUD) + "'", conexiones6._conexion)
            'conexiones6.abrir()
            '_adaptador.UpdateCommand.Connection = conexiones6._conexion
            '_adaptador.UpdateCommand.ExecuteNonQuery()
            'conexiones6.cerrar()
        Next


        'Suma el monto de la nomia  
        Dim conexiones222 As New CConexion
        conexiones222.conexion()
        Dim command222 As SqlCommand = New SqlCommand("select  sum([MONTO_SOLICITUD] ) from [_RIESGO_DETA_NOMINA_TRANSFERENCIA] where [NRO_NOMINA] = '" + numeronomina.ToString + "'  ", conexiones222._conexion)
        conexiones222.abrir()
        Dim reader222 As SqlDataReader = command222.ExecuteReader()
        If reader222.HasRows Then
            Do While reader222.Read()
                sumatotalnomina = (Trim(reader222(0).ToString))
            Loop
        Else
            ' MsgBox("ERROR")
        End If
        reader222.Close()

        'Inserta el encabezado de la nomina 
        Dim conexiones5 As New CConexion
        conexiones5.conexion()
        _adaptador.InsertCommand = New SqlCommand(" INSERT INTO [_RIESGO_ENCA_NOMINA_TRANSFERENCIA]([NRO_NOMINA],[FECHA_NOMINA],[ESTADO_NOMINA],[MONTO_NOMINA],[PRODUCTO],[USUARIO],[SUCURSAL],[APROBACION_SUBGERENTE_FINANZA]) VALUES('" + numeronomina.ToString + "',( CONVERT(VARCHAR(8),GETDATE(),112) ),'GENERADA','" + sumatotalnomina.ToString + "','NOMINA TRANSFERENCIA','" + frmPerfil.CbmUsuario.SelectedItem.ToString + "','" + Trim(Sucursal2.ToString) + "','Por Analizar')", conexiones5._conexion)
        conexiones5.abrir()
        _adaptador.InsertCommand.Connection = conexiones5._conexion
        _adaptador.InsertCommand.ExecuteNonQuery()
        conexiones5.cerrar()
        Gridnominaseleccion.Rows.Clear()
        MsgBox("NÓMINA GENERADA  Y ENVIADA")
        'METODO ACTUALIZA GRILLA 
        ACTUALIZAGRILLAGIROSCAPITAL()

    End Sub



    Sub ACTUALIZAGRILLAGIROSCAPITAL()
        GridbandejaCapital.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        plantillas._tabla.Rows.Clear()
        plantillas._tabla.Columns.Clear()
        GridbandejaCapital.Columns.Clear()

        If plantillas.Consultar_Giros_Trasferencia_Capital() Then
            crearcolumna()
            tabla5 = plantillas.tabla
            GridbandejaCapital.DataSource = tabla5
        End If
        _tabla6.Rows.Clear()
        _tabla6.Columns.Clear()


        Dim conexiones4 As New CConexion
        conexiones4.conexion()
        ' _adaptador.SelectCommand = New SqlCommand(" SELECT * FROM [_RIESGO_ENCA_NOMINA_TRANSFERENCIA] ORDER BY NRO_NOMINA DESC  ", conexiones4._conexion)
        _adaptador.SelectCommand = New SqlCommand("SELECT  [NRO_NOMINA], Substring([FECHA_NOMINA],7, 2) + '/' + Substring([FECHA_NOMINA], 5, 2) + '/' + Substring([FECHA_NOMINA],1, 4) AS FECHA_NOMINA,ESTADO_NOMINA,dbo.puntos(MONTO_NOMINA),PRODUCTO , USUARIO,SUCURSAL,[APROBACION_SUBGERENTE_FINANZA],ID_FILA  FROM  [_RIESGO_ENCA_NOMINA_TRANSFERENCIA] ORDER BY NRO_NOMINA DESC   ", conexiones4._conexion)
        conexiones4.abrir()
        _adaptador.Fill(_tabla6)
        GridSupervisada.DataSource = _tabla6
        conexiones4.cerrar()

        ' GridbandejaCapital.Columns("ID_SOLICITUD").Visible = True
        GridbandejaCapital.Columns("BANCO").Visible = False
        GridbandejaCapital.Columns("CUENTA").Visible = False
        GridbandejaCapital.Columns("FORMA_PAGO").Visible = False
        GridbandejaCapital.Columns("NRO_CUENTA").Visible = False
        'CALFARO
        'GridbandejaCapital.Columns("TIPOSOLICITUD2").Visible = False
        'GridbandejaCapital.Columns("PENDIENTES_ANTES").Visible = False

        'CALFARO HASTA AQUI

        'COLOREAR()
        '0ID_SOLICITUD
        '1FECHA_SOLICITUD
        '2ESTADO
        '3RUT
        '4NOMBRES
        '5PATERNO 
        '6MATERNO
        '7MONTO
        '8BANCO
        '9CUENTA
        '10FORMA_PAGO
        '11EJECUTIVO
        '12 Nombrecol
        'GridbandejaCapital.Columns("MONTO").Visible = False
        'GridbandejaCapital.ReadOnly = True
        'GridbandejaCapital.Columns("Nombrecol").ReadOnly = False
        'GridbandejaCapital.Columns("MONTO").Visible = False
        'GridbandejaCapital.Columns("MONTO").Visible = False

    End Sub

    'Sub consultaestadonomina()


    '    'GridverNominaRealpagada
    '    Try
    '        Dim conexiones4 As New CConexion
    '        conexiones4.conexion()
    '        Dim command4 As SqlCommand = New SqlCommand("select ID_SOLICITUD  from  [_RIESGO_deta_NOMINA_TRANSFERENCIA] where  NRO_NOMINA =215  AND ESTADO_EN_NOMINA='SELECCIONADO'  ", conexiones4._conexion)
    '        conexiones4.abrir()
    '        Dim reader4 As SqlDataReader = command4.ExecuteReader()
    '        If reader4.HasRows Then
    '            Do While reader4.Read()
    '                GridSupervisada.Rows.Add(reader4(0), reader4(1), reader4(2))
    '            Loop
    '        Else
    '        End If
    '        reader4.Close()
    '    Catch ex As Exception
    '    End Try





    'End Sub
    Private Sub BtnbuscarID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnbuscarID.Click

        ' CALFARO TODO ESTE BOTON

        Dim conexiones4 As New CConexion
        Try
            _tabla6.Rows.Clear()
            _tabla6.Columns.Clear()
            conexiones4.conexion()
            conexiones4.abrir()
            Dim command As SqlCommand
            command = New SqlCommand("_LAUCOOP_PRELACION_PARA_TRANSFERENCIAS", conexiones4._conexion)
            command.CommandType = CommandType.StoredProcedure
            _adaptador = New SqlDataAdapter(command)
            With command.Parameters
                'Envió los parámetros que necesito
                .Add(New SqlParameter("@NROSOCIO", SqlDbType.VarChar)).Value = "0"
                .Add(New SqlParameter("@ID_SOLICITUD", SqlDbType.VarChar)).Value = Trim(TextBuscarID.Text)
                .Add(New SqlParameter("@FECHA", SqlDbType.VarChar)).Value = "HOY"
                .Add(New SqlParameter("@1RA_AYUDA", SqlDbType.VarChar)).Value = "N"
            End With
            _adaptador.Fill(_tabla6)
            GridbandejaCapital.DataSource = _tabla6
        Catch expSQL As SqlException
            MsgBox(expSQL.Message)
        Finally
            conexiones4.cerrar()
        End Try

    End Sub

    Private Sub TextBuscarID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBuscarID.TextChanged
        If Trim(TextBuscarID.Text) = "" Then
            If plantillas.Consultar_Giros_Trasferencia_Capital() Then
                crearcolumna()
                tabla5 = plantillas.tabla
                GridbandejaCapital.DataSource = tabla5
            End If
            _tabla6.Rows.Clear()
            _tabla6.Columns.Clear()
        End If
    End Sub

    Private Sub GridbandejaCapital_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridbandejaCapital.CellClick
        'CALFARO TODA ESTA FUNCION
        Dim xTipo As String
        xTipo = GridbandejaCapital.Rows(GridbandejaCapital.CurrentRow.Index).Cells("TIPOSOLICITUD2").Value()
        If e.ColumnIndex = 0 Or e.ColumnIndex = 15 Then
            If GridbandejaCapital.Rows(GridbandejaCapital.CurrentRow.Index).Cells("PENDIENTES_ANTES").Value() <> 0 And (xTipo = "F" Or xTipo = "C" Or xTipo = "R") Then
                GridbandejaCapital.Columns("Nombrecol").ReadOnly = False
                GridbandejaCapital.Rows(GridbandejaCapital.CurrentRow.Index).Cells("Nombrecol").Value() = False
                'GridbandejaCapital.Columns("Nombrecol").ReadOnly = True
                MsgBox("No podra pagar esta solicitud por una de las siguientes razones : " + Chr(13) + "-Tiene solicitudes pendientes anteriores a la seleccionada" + Chr(13) + "-Tiene solicitudes pagadas pero no se ha terminado tu proceso de contabilización" + Chr(13) + "-Tiene solicitudes (Laucoop) de retiro ó abono de Capital Social pendientes de contabilización" + Chr(13) + Chr(13) + "debe terminar ese proceso antes de proceder con el pago de esta solicitud", MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub Checkparaactualizaciongrilla_CheckedChanged(sender As Object, e As EventArgs) Handles Checkparaactualizaciongrilla.CheckedChanged

    End Sub
End Class