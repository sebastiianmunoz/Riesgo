
Imports System.Data
Imports System.Data.SqlClient
Public Class frmEvaluarCapital

    ' Label38.text.visible  = FALSE 

    Dim ValorCuota As Double = 0
    Dim REVALORISACIONDELCAPITAL As Integer = 0
    Dim Sumatotal As Integer = 0
    Dim validasocio As String = ""  'valida que  el socio exista 
    Dim recibevalor As Integer = 0
    Dim recibemontoretirable = 0
    Dim tomafecha As String = ""
    Dim tomafecha2 As String = ""
    Dim Descripcion As String = ""
    Dim diasgracias As Integer = 0
    Dim validarcolumnacheckcreada As Boolean = False

    've que el monto  solicitado no sea meyor al monto  total que pose el socio 
    Dim banderatotalsaldocapitalsocio As Boolean = True
    Dim Tienemonto As Boolean = False

    'Filtros
    Dim cumplecapitalminimo As Boolean = False
    Dim cumplemontosolicitado As Boolean = False
    Dim cumplenroretirosanuales As Boolean = False
    Dim cumplenroretirosmensuales As Boolean = False
    Dim cumplesociosinmora As Boolean = False
    Dim cumpleavalsinmora As Boolean = False

    Dim cumplerestricciones As Boolean = True 'Caso especial 
    Dim cumplesaldoencapital As Boolean = False

    'AVAL
    Dim RUTAVAL As String = ""
    'DATOS BANCO SOCIO 
    Dim codigobanco As String = ""
    Dim tipocuenta As String = ""
    Dim Nombrenaco As String = ""
    'Formas de buscar socio 
    Dim tomanumerososcio As String = """ "
    'tomar Rut 
    Dim cadena As String
    Dim tabla() As String
    Dim n As Integer
    Dim tomarut As String
    Dim tomadigito As String

    'Correlativos credito 
    Dim tomacorcredito As String
    Dim newcol As DataGridViewColumn = New DataGridViewCheckBoxColumn
    Public _tabla26 As DataTable = New DataTable
    Public _TABLA27 As DataTable = New DataTable
    Public _TABLA28 As DataTable = New DataTable
    Public _TABLA29 As DataTable = New DataTable
    Public _tabla30 As DataTable = New DataTable ' EVALUACION DEL AVAL  LOS CREDITOS 
    Public _tabla36 As DataTable = New DataTable
    Public _tabla37 As DataTable = New DataTable
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter

    'VARIABLE PARA EL BLOKEO 
    Dim BANDERASOCIOBLOKEADO As Boolean = False
    Dim NOMBRECOMPLETO As String = ""
    Dim FECHA As String = ""


    'VARIABLE DE BOLEEAN CORCREDITO  INDIRECTO MOROSO 
    Dim PRIMERFILTROCREDITOINDIRECTOMOROS As Boolean = False
    'ocultar boton pendiente 


    ' ------------------------------------------------------------ CAPA DISEÑO  Y  VALIDACION  DE BOTONOS ANTES DE LAS  FUNCIONES ------------------------------------------------------------------------------------------------------------------
    Private Sub Cbotipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbotipo.SelectedIndexChanged
        If Cbotipo.SelectedItem = "TELÉFONICO" Or Cbotipo.SelectedItem = "CORREO ELECTRÓNICO" Then
            cboformapago.Items.Clear()
            cboformapago.Items.Add("TRANSFERENCIA")

        ElseIf Cbotipo.SelectedItem = "PRESENCIAL" Then
            cboformapago.Items.Clear()
            cboformapago.Items.Add("EFECTIVO")
            cboformapago.Items.Add("CHEQUE")
            cboformapago.Items.Add("TRANSFERENCIA")
        End If

    End Sub

    Private Sub Textmontorequerido_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Textmontorequerido.KeyUp
        If Not IsNumeric(Replace(Trim(Textmontorequerido.Text), ".", "")) Then
            MsgBox("Debe ingresar un valor numerico")
        Else
            If Texttotales.Text > 0 Then
                'ojo ver  comparacion  
                If Int(Textmontorequerido.Text) > Int(Texttotales.Text) Then
                    MsgBox("El monto Solicitado es mayor  al monto total Disponible")
                    Textmontorequerido.Text = 0
                Else
                    'banderatotalsaldocapitalsocio = True
                End If
                If cboformapago.SelectedItem = "EFECTIVO" And Textmontorequerido.Text > 30000 Then
                    MsgBox("Cuando la forma de pago es en efectivo  el valor solicitado no puede superar los 30.000 ")
                    Textmontorequerido.Text = 0
                End If
            ElseIf Texttotales.Text = 0 Then
                MsgBox("No Cumple con capital disponible  para realizar un giro ")
                Textmontorequerido.Text = 0
            End If
            Textmontorequerido.Text = PuntoX(Textmontorequerido.Text)
            Textmontorequerido.Select(Textmontorequerido.Text.Length, 0)
        End If
    End Sub

    Sub usuarioblokeado()
        'ByVal RUT As String
        ' SELECT * FROM _BLOQUEO_CAPITAL WHERE NROSOCIO = 5203 ORDER BY FECHAHORA DESC
        ' BANDERASOCIOBLOKEADO()
        NOMBRECOMPLETO = ""
        FECHA = ""

        txtNrosocio.Clear()
        ' Try
        Dim conexiones33 As New CConexion
        conexiones33.conexion()
        Dim command33 As SqlCommand = New SqlCommand("SELECT nrosocio  ,NOMBRES,PATERNO ,MATERNO  from _socios WHERE  RUT = " + Trim(tomarut.ToString) + " and estado = 0 ", conexiones33._conexion)
        conexiones33.abrir()
        Dim reader33 As SqlDataReader = command33.ExecuteReader()
        If reader33.HasRows Then
            Do While reader33.Read()
                txtNrosocio.Text = reader33(0).ToString
                NOMBRECOMPLETO = reader33(1).ToString + " " + reader33(2).ToString + "" + reader33(3).ToString
            Loop
        Else
        End If
        reader33.Close()
        conexiones33.cerrar()
        ' Catch ex As Exception
        'MsgBox("No Existe Socio ")
        ' End Try


        ' Try
        GridBlokeo.Rows.Clear()
        Dim conexiones3 As New CConexion
        conexiones3.conexion()
        Dim command3 As SqlCommand = New SqlCommand("SELECT ACCION ,SUBSTRING(FECHAHORA,7,2)+'/'+SUBSTRING(FECHAHORA,5,2)+'/'+SUBSTRING(FECHAHORA,1,4) AS FECHA  FROM _BLOQUEO_CAPITAL WHERE NROSOCIO ='" + Trim(txtNrosocio.Text) + "' ORDER BY FECHAHORA DESC", conexiones3._conexion)
        conexiones3.abrir()
        Dim reader3 As SqlDataReader = command3.ExecuteReader()
        If reader3.HasRows Then
            Do While reader3.Read()
                GridBlokeo.Rows.Add((Trim(reader3(0).ToString)))
                FECHA = (Trim(reader3(1).ToString))

            Loop
        Else
        End If
        reader3.Close()
        conexiones3.cerrar()
        'Catch ex As Exception
        'MsgBox("tiene capital ")
        ' End Try
        Dim totolfilas As Integer = GridBlokeo.RowCount

        'For z = 0 To totolfilas
        If totolfilas >= 1 Then

            If Trim(GridBlokeo.Rows(0).Cells(0).Value()) = "1" Then
                BANDERASOCIOBLOKEADO = True
            ElseIf Trim(GridBlokeo.Rows(0).Cells(0).Value()) = "0" Then
                BANDERASOCIOBLOKEADO = False
            ElseIf Trim(GridBlokeo.Rows(0).Cells(0).Value()) = "" Then
                BANDERASOCIOBLOKEADO = False
            End If
            'Next
        Else
            BANDERASOCIOBLOKEADO = False

        End If


    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        'VALIDAR  LLENAR TEXTBOX  RUT Y COMBOBOX  DEL  TIPO DE SOLICITUD --------------------------------------------
        ' MsgBox(Checkrenuncia.CheckState)
        If textrutbuscar.Text = "" Then
            MsgBox("Debe  Ingresar  Rut  socio  ")

        ElseIf Cbotipo.SelectedIndex = -1 Then
            MsgBox("Debe  seleccionar el tipo de solicitud ")

        ElseIf textrutbuscar.Text <> "" And Cbotipo.SelectedIndex <> -1 And Checkrenuncia.CheckState = 0 And Checfallecimiento.CheckState = 0 Then
            If ValidarRut(Me.textrutbuscar.Text.ToString) = "Rut Correcto" Then
                cadena = textrutbuscar.Text.ToString
                tabla = Split(cadena, "-")
                For n = 0 To UBound(tabla, 1)
                    ' MessageBox.Show(tabla(n))
                    If n = 0 Then
                        tomarut = (tabla(n))
                    Else
                        tomadigito = (tabla(n))
                    End If
                Next
                'if  si   no se encuentra blokeado  mostrar 
                'GridBlokeo
                usuarioblokeado()
                If BANDERASOCIOBLOKEADO = True Then
                    Fichacompleta.Visible = False
                    MsgBox("Con fecha " + FECHA + ", el capital del Socio " + Trim(txtNrosocio.Text) + "------" + NOMBRECOMPLETO + "---, se encuentra bloqueado por : Embargo Tesoreria.")
                ElseIf BANDERASOCIOBLOKEADO = False Then

                    consultardatoscapital()
                End If
                'else  de lo contrario 
                'End if 
            Else
                MsgBox("Rut invalido")
            End If
        ElseIf textrutbuscar.Text <> "" And Cbotipo.SelectedIndex <> -1 And (Checkrenuncia.CheckState = 1 Or Checfallecimiento.CheckState = 1) Then
            'MsgBox("jojojo es una renuncia ")
            If ValidarRut(Me.textrutbuscar.Text.ToString) = "Rut Correcto" Then
                cadena = textrutbuscar.Text.ToString
                tabla = Split(cadena, "-")
                For n = 0 To UBound(tabla, 1)
                    ' MessageBox.Show(tabla(n))
                    If n = 0 Then
                        tomarut = (tabla(n))
                    Else
                        tomadigito = (tabla(n))
                    End If
                Next

                consultardatoscapital()
                ' RevalorizacionUF()

                If Checkrenuncia.CheckState = 1 Then
                    Texttiposolicitud2.Text = "R"
                ElseIf Checfallecimiento.CheckState = 1 Then
                    Texttiposolicitud2.Text = "F"

                    'MsgBox(Texttiposolicitud2.Text)
                    If Trim(Texttiposolicitud2.Text) = "F" Then
                        cboformapago.Items.Clear()
                        cboformapago.Items.Add("EX-SOCIOS")
                    Else
                    End If
                End If
            Else
                MsgBox("Rut invalido")
            End If
        End If
    End Sub

    Private Sub cboformapago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboformapago.SelectedIndexChanged
        If cboformapago.SelectedItem <> "TRANSFERENCIA" Then
            Gridcuentas.Enabled = False
            ' Gridcuentas.Visible = False
        Else
            ' Gridcuentas.Visible = True
            Gridcuentas.Enabled = True
        End If
    End Sub


    'LLENA COMBO FORMA DE PAGO
    Sub LLENACOMBOFORMADEPAGO()
        Label3.Visible = False
        Textcorrelativo.Visible = False
        Fichacompleta.Visible = False
        Textfecha.Text = DateTime.Now().ToShortDateString()
        cboformapago.Items.Add("TRANSFERENCIA")
        cboformapago.Items.Add("EFECTIVO")
        cboformapago.Items.Add("CHEQUE")
        '  cboformapago.Items.Add("EX-SOCIOS")
        '  cboformapago.Items.Add("SIN-LIQUIDO")

        txtNrosocio.Visible = False
        Label1.Visible = False
    End Sub

    Sub crearcolumna()
        newcol.HeaderText = "SELECCION"
        newcol.Name = "Nombrecol"
        newcol.DataPropertyName = "nombre_campo" 'Campo de enlace a datos
        Gridcuentas.Columns.Add(newcol)
    End Sub
    Sub sacarcolumna()
        Gridcuentas.Columns.Remove(newcol)
    End Sub
    Private Sub frmEvaluarCapital_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' MsgBox("ola1")
        LLENACOMBOFORMADEPAGO()
        frmMuestraEvaluacionCapital.BtnPendiente.Visible = False
        Label38.Visible = False
        Checkrenuncia.Visible = False
        Checfallecimiento.Visible = False

        '---------------------------------------------
        LabelrevalorizacionUF.Visible = False
        TextrevalorizacionUF.Visible = False

        Label32.Visible = False
        Textcuotadegastos.Visible = False

        Label33.Visible = False
        TextCapitalabonaCreditos.Visible = False

        Label37.Visible = False
        Textotrospagos.Visible = False

        Label7.Visible = False
        TextDiminucioncapital.Visible = False
        '---------------------------------------------
    End Sub
    Private Sub txtNrosocio_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNrosocio.KeyUp
        If Not IsNumeric(Replace(Trim(txtNrosocio.Text), ".", "")) Then
            MsgBox("Debe ingresar un valor numerico")
        End If

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim contadrocheck As Integer = 0
        Dim totalfilas As Integer = 0
        Dim TOMAFEHCACOMPELTA As String = ""
        Dim TOMAFECHAAÑOMESDIA As String = ""
        TOMAFEHCACOMPELTA = DateTime.Now().ToShortDateString()  '"16/06/2009"
        TOMAFECHAAÑOMESDIA = Mid(TOMAFEHCACOMPELTA, 7, 10) + Mid(TOMAFEHCACOMPELTA, 4, 2) + Mid(TOMAFEHCACOMPELTA, 1, 2) '201410'

        Dim nrosocio As String = Textnrosocio.Text
        Dim maximafecha As String = ""
        Dim conexiones66 As New CConexion
        conexiones66.conexion()
        Dim command66 As SqlCommand = New SqlCommand("SELECT (SELECT CASE  WHEN  MAX(FECHA) IS NULL  THEN 'Sin Beneficio Prelación Avanza' ELSE MAX(FECHA) END ) AS FECHA FROM  _INGRESOS WHERE ESTADOCONT <>'A' AND CODCONCEPTO=317 AND NROSOCIO='" + nrosocio + "'", conexiones66._conexion)
        conexiones66.abrir()
        Dim reader66 As SqlDataReader = command66.ExecuteReader()
        If reader66.HasRows Then
            Do While reader66.Read()
                maximafecha = reader66(0)
            Loop
        Else
        End If
        reader66.Close()
        conexiones66.cerrar()

        Dim AÑO As String = ""
        Dim AÑOPERIODO As Integer = 0
        Dim FECHAMUESTRA As String = ""
        Dim FECHAMUESTRA2 As String = ""

        If maximafecha <> "Sin Beneficio Prelación Avanza" Then
            FECHAMUESTRA = Mid(maximafecha, 1, 4) + "/" + Mid(maximafecha, 5, 2) + "/" + Mid(maximafecha, 7, 2)
            AÑO = Mid(maximafecha, 1, 4)
            AÑOPERIODO = Int(AÑO) + 2
            FECHAMUESTRA = AÑOPERIODO.ToString + Mid(maximafecha, 5, 2) + Mid(maximafecha, 7, 2)
            FECHAMUESTRA2 = AÑOPERIODO.ToString + "/" + Mid(maximafecha, 5, 2) + "/" + Mid(maximafecha, 7, 2)
            '   MsgBox(FECHAMUESTRA2)
        Else

        End If


        '  MsgBox("ola")


        If Textmontorequerido.Text = 0 Then
            MsgBox("Debe ingresar un valor mayor  a  0")
        Else
            If cboformapago.SelectedItem = "TRANSFERENCIA" And IsNumeric(Replace(Trim(Textmontorequerido.Text), ".", "")) Then

                'SI SELECCIONO TRANSFERENCIA  COMO FORMA DE PAGO  Y SELECCIONO  EL CHECK DE LA CUENTA BANCARIA EN LA GRILLA (validarcolumnacheckcreada = True)
                If validarcolumnacheckcreada = True Then
                    totalfilas = Gridcuentas.RowCount - 1
                    For x = 0 To totalfilas
                        'RECORRE LA GRILLA  TOMANDO LOS DATOS DONDE EL USURIO SELECCIONO  LA CUENTA BANCARIA  CON EL CHECKBOX 
                        If Gridcuentas.Rows(x).Cells(5).EditedFormattedValue = True Then
                            textnombretipocuenta.Text = Gridcuentas.Rows(x).Cells(0).Value()
                            Textnombrebanco.Text = Gridcuentas.Rows(x).Cells(2).Value()
                            Textcodtipocuenta.Text = Gridcuentas.Rows(x).Cells(4).Value()
                            Textnrocuentabanco.Text = Gridcuentas.Rows(x).Cells(1).Value()
                            Textcodbanco.Text = Gridcuentas.Rows(x).Cells(3).Value()
                            contadrocheck = contadrocheck + 1
                        End If
                    Next
                    'SI (contadrocheck = 1)  ES QUE SE  SELECCIONO  SOLO UNA FILA  DE LA GRILLA DE CUENTAS BANCARIAS 

                    If contadrocheck = 1 Then
                        'si el check renuncia esta en cero es por que no fue seleccionado 
                        'If Checkrenuncia.CheckState = 0 And Checfallecimiento.CheckState = 0 Then
                        Textformapago.Text = cboformapago.SelectedItem
                        'Beneficio Prelación Avanza 
                        If maximafecha <> "Sin Beneficio Prelación Avanza" Then
                            ' MsgBox(FECHAMUESTRA)
                            'MsgBox(TOMAFECHAAÑOMESDIA)

                            If Int(FECHAMUESTRA) <= Int(TOMAFECHAAÑOMESDIA) Then
                                BotonEvaluar() '------------------------------------------------------
                            Else
                                MsgBox("El socio Numero :" + nrosocio.ToString + " utilizo  el  Beneficio Prelación Avanza por lo cual segun los reglamentos no puede volver a solicitar un giro dentro de 24 meses a contar de la fecha " + FECHAMUESTRA2.ToString + "", MessageBoxIcon.Stop)
                                '  MsgBox("sds")

                            End If

                        ElseIf maximafecha = "Sin Beneficio Prelación Avanza" Then

                            BotonEvaluar()


                        End If














                        'si el check renuncia esta en 1  es por que  fue seleccionado 
                        ' ElseIf Checkrenuncia.CheckState = 1 Or Checfallecimiento.CheckState = 1 Then
                        'If Trim(Textcuotadegastos.Text) <> "" And Trim(TextCapitalabonaCreditos.Text) <> "" And Trim(Textotrospagos.Text) <> "" Then
                        '  BotonEvaluarRenunciaoFallecimiento()
                        '   RECONCIDERA_FALLECIMIENTO_RENUNCIA()
                        '  RECONCIDERA_FALLECIMIENTO_RENUNCIA()
                        'ElseIf Trim(Textcuotadegastos.Text) = "" Or Trim(TextCapitalabonaCreditos.Text) = "" Or Trim(Textotrospagos.Text) = "" Then
                        '    MsgBox("Debe ingresar valor en saldo cuota de gastos  , en capital credito y tambien en otros gastos  ")
                        'End If
                        ' End 
                        'If (contadrocheck > 1) ES  QUE EN LA GRILLA  SE SELECCIONO  MAS DE UNA CUENTA BANCARIA 
                    ElseIf contadrocheck > 1 Then
                        MsgBox("Existe  mas de  una cuenta seleccionada ")
                        'SI (contadrocheck = 0 ) ES  QUE NO  SE SELECIONO  NIGUNA CUENTA BANCARIA EN LA GRILLA  
                    ElseIf contadrocheck = 0 Then
                        MsgBox("Debe seleccionar una cuenta para transferir  ")
                    End If
                    'SI (validarcolumnacheckcreada = False ) ES  QUE  NO EXISTE CUENTA BANCARIA  PARA EL SOCIO DENTRO DE LA BASE DE DATOS 
                ElseIf validarcolumnacheckcreada = False Then
                    ' If Checkrenuncia.CheckState = 0 And Checfallecimiento.CheckState = 0 Then
                    'Beneficio Prelación Avanza 
                    If maximafecha <> "Sin Beneficio Prelación Avanza" Then
                        '  MsgBox(maximafecha)
                        '  MsgBox(TOMAFECHAAÑOMESDIA)


                        If Int(FECHAMUESTRA) >= Int(TOMAFECHAAÑOMESDIA) Then
                            BotonEvaluar() '------------------------------------------------------
                        Else
                            MsgBox("El socio Numero :" + nrosocio.ToString + " utilizo  el  Beneficio Prelación Avanza por lo cual segun los reglamentos no puede volver a solicitar un giro dentro de 24 meses a contar de la fecha " + FECHAMUESTRA2.ToString + "", MessageBoxIcon.Stop)
                            '  MsgBox("sds")
                        End If

                    ElseIf maximafecha = "Sin Beneficio Prelación Avanza" Then
                        BotonEvaluar()
                    End If

                    'ElseIf Checkrenuncia.CheckState = 1 Or Checfallecimiento.CheckState = 1 Then
                    'If Trim(Textcuotadegastos.Text) <> "" And Trim(TextCapitalabonaCreditos.Text) <> "" And Trim(Textotrospagos.Text) <> "" Then
                    'BotonEvaluarRenunciaoFallecimiento()
                    'ElseIf Trim(Textcuotadegastos.Text) = "" Or Trim(TextCapitalabonaCreditos.Text) = "" Or Trim(Textotrospagos.Text) = "" Then
                    'MsgBox("Debe ingresar valor en saldo cuota de gastos  , en capital credito y tambien en otros gastos  ")
                    'End If
                    'End If
                End If
                ElseIf cboformapago.SelectedItem = "TRANSFERENCIA" And Not IsNumeric(Replace(Trim(Textmontorequerido.Text), ".", "")) Then
                    MsgBox("Debe ingresar valores numericos  en el monto solicitado  ")
                ElseIf cboformapago.SelectedItem = "" Then
                    MsgBox("Debe seleccionar una forma de pago")
                ElseIf cboformapago.SelectedItem <> "" And cboformapago.SelectedItem <> "TRANSFERENCIA" Then
                    '----------------------------------------------------------------------------------------
                    If Not IsNumeric(Replace(Trim(Textmontorequerido.Text), ".", "")) Then
                        MsgBox("Debe ingresar valores numericos  en el monto solicitado ")
                    Else
                    '-----------------------------------------------------------------------------------------
                    'If Checkrenuncia.CheckState = 0 And Checfallecimiento.CheckState = 0 Then
                    Textformapago.Text = cboformapago.SelectedItem




                    'Beneficio Prelación Avanza 
                    If maximafecha <> "Sin Beneficio Prelación Avanza" Then

                        ' MsgBox(maximafecha)
                        ' MsgBox(TOMAFECHAAÑOMESDIA)

                        If Int(FECHAMUESTRA) <= Int(TOMAFECHAAÑOMESDIA) Then
                            BotonEvaluar() '------------------------------------------------------
                        Else
                            MsgBox("El socio Numero :" + nrosocio.ToString + " utilizo  el  Beneficio Prelación Avanza por lo cual segun los reglamentos no puede volver a solicitar un giro dentro de 24 meses a contar de la fecha " + FECHAMUESTRA2.ToString + "", MessageBoxIcon.Stop)
                            '  MsgBox("sds")
                        End If

                    ElseIf maximafecha = "Sin Beneficio Prelación Avanza" Then
                        BotonEvaluar()
                    End If

                    'ElseIf Checkrenuncia.CheckState = 1 Or Checfallecimiento.CheckState = 1 Then
                    'If Trim(Textcuotadegastos.Text) <> "" And Trim(TextCapitalabonaCreditos.Text) <> "" And Trim(Textotrospagos.Text) <> "" Then
                    'MsgBox("pasa")
                    'BotonEvaluarRenunciaoFallecimiento()
                    'ElseIf Trim(Textcuotadegastos.Text) = "" Or Trim(TextCapitalabonaCreditos.Text) = "" Or Trim(Textotrospagos.Text) = "" Then
                    'MsgBox("Debe ingresar valor en saldo cuota de gastos  , en capital credito y tambien en otros gastos ")
                    'End If
                    'End If
                End If
                End If
            End If
            ' End If
            'End If
    End Sub

    ' ------------------------------------------------------------ FIN  CAPA DISEÑO  Y  VALIDACION  DE BOTONOS ANTES DE LAS  FUNCIONES   ------------------------------------------------------------------------------------------------------------------
    'CAPA EVALUACION  DEL SOCIO  PARA EL RETIRO DE CAPITAL 
    'funcion  la cual recibe los datos del socio  para llenar le modulo  de  evalucion 
    Sub consultardatoscapital()
        Dim Tomacorrelativo As Integer = 0
        Dim nombretipocuenta As String = ""
        Dim Tipocuentabanco As String = ""
        Dim banco As String = ""
        Dim nrocuentabanco As String = ""
        Dim sucrusalbanco As String = ""
        Dim correo As String = ""

        TextrevalorizacionUF.ReadOnly = True
        Textcuotadegastos.ReadOnly = True
        TextCapitalabonaCreditos.ReadOnly = True
        'If Not IsNumeric(Replace(Trim(txtNrosocio.Text), ".", "")) Then
        'MsgBox("Debe ingresar un valor numerico")
        'Else
        'If Cbotipo.SelectedIndex <> -1 Then
        'MsgBox(tomarut)
        txtNrosocio.Clear()
        Try
            Dim conexiones33 As New CConexion
            conexiones33.conexion()
            Dim command33 As SqlCommand = New SqlCommand("SELECT nrosocio from _socios   WHERE  RUT = " + Trim(tomarut.ToString) + " and estado = 0 ", conexiones33._conexion)
            conexiones33.abrir()
            Dim reader33 As SqlDataReader = command33.ExecuteReader()
            If reader33.HasRows Then
                Do While reader33.Read()
                    txtNrosocio.Text = reader33(0).ToString
                Loop
            Else
            End If
            reader33.Close()
            conexiones33.cerrar()
        Catch ex As Exception
            MsgBox("No Existe Socio ")
        End Try
        'End If
        'MsgBox(txtNrosocio.Text)
        If txtNrosocio.Text <> "" Then
            Dim conexiones3 As New CConexion
            conexiones3.conexion()
            Dim command3 As SqlCommand = New SqlCommand("SELECT CONVERT(varchar(8),RUT )+'-'+CONVERT(varchar(1),DVRUT ) AS RUT  , Nombres +' '+ Paterno+' '+ Materno AS NOMBRE_COMPLETO , NROSOCIO,rtrim(Direccion) +' '+rtrim(SECTOR)+' '+rtrim(Villa)+' '+rtrim(Ciudad) as direccion,TELEFONO+'/'+CELULAR AS TELEFONO, EMAIL+''+LABOEMAIL  AS CORREO  ,(select  case  when Descripcion IS NULL THEN 'Sin Institucion' ELSE Descripcion  END ) as Institucion   ,Nombres,Paterno,MATERNO  FROM _SOCIOS  as socio  Left join _INSTITUCIONES as inst on socio.CODINST = inst.CODINS   WHERE  NROSOCIO = " + Trim(txtNrosocio.Text) + " ", conexiones3._conexion)
            conexiones3.abrir()
            Dim reader3 As SqlDataReader = command3.ExecuteReader()
            If reader3.HasRows Then
                Do While reader3.Read()
                    Textrut.Text = reader3(0).ToString
                    validasocio = reader3(0).ToString
                    Textnombre.Text = reader3(1).ToString
                    Textnrosocio.Text = reader3(2).ToString
                    Textdireccion.Text = reader3(3).ToString
                    Texttelefono.Text = reader3(4).ToString
                    Textcorreo.Text = reader3(5).ToString
                    Descripcion = reader3(6).ToString
                    'diasgracias = reader3(7)
                    'MsgBox(reader3(3).ToString)
                    textnombres2.Text = reader3(7).ToString
                    textpaterno.Text = reader3(8).ToString
                    Textmaterno.Text = reader3(9).ToString
                    If Trim(Textcorreo.Text) = "" Then
                        Textcorreo.Text = "Sin Correo Registrado"
                    End If
                Loop
            Else
            End If
            reader3.Close()
            conexiones3.cerrar()
            If validasocio <> "" Then
                validasocio = ""
                'Saca fecha actual 
                tomafecha = DateTime.Now().ToShortDateString()  '"16/06/2009"
                ' MsgBox(tomafecha)
                ' MsgBox(tomafecha.Substring(7, 9))
                tomafecha2 = Mid(tomafecha, 7, 10) + Mid(tomafecha, 4, 2) + Mid(tomafecha, 1, 2)
                ' MsgBox(tomafecha2)
                Dim conexiones As New CConexion
                conexiones.conexion()
                Dim command As SqlCommand = New SqlCommand(" SELECT * FROM _VALORCUOTA WHERE FECHA <= '" + Trim(tomafecha2) + "' ORDER BY FECHA ASC", conexiones._conexion)
                conexiones.abrir()
                Dim reader As SqlDataReader = command.ExecuteReader()
                If reader.HasRows Then
                    Do While reader.Read()
                        ValorCuota = (Trim(reader(1)))
                    Loop
                Else
                End If
                reader.Close()
                conexiones.cerrar()
                ValorCuota = (ValorCuota * 1000)
                conexiones.cerrar()
                Try
                    'MONTO REVALORISACIONDELCAPITAL

                    Dim conexiones2 As New CConexion
                    conexiones2.conexion()
                    Dim command2 As SqlCommand = New SqlCommand("SELECT SUM(MONTOAPORTE)  FROM [_CAPITALSOCIAL]  WHERE NROSOCIO ='" + Trim(txtNrosocio.Text) + "' AND CODCONCEPTO = 7  ", conexiones2._conexion)
                    conexiones2.abrir()
                    Dim reader2 As SqlDataReader = command2.ExecuteReader()
                    If reader2.HasRows Then
                        Do While reader2.Read()
                            ' MsgBox(reader2(0).ToString)
                            ' MsgBox(txtNrosocio.Text)
                            REVALORISACIONDELCAPITAL = reader2(0).ToString
                        Loop
                    Else
                    End If
                    reader2.Close()
                    conexiones2.cerrar()
                Catch ex As Exception
                    MsgBox("No Cuenta con revalorizacion del capital ")
                End Try
                Try
                    'MONTO TOTAL
                    Dim conexiones5 As New CConexion
                    conexiones5.conexion()
                    Dim command5 As SqlCommand = New SqlCommand(" SELECT SUM(MONTOAPORTE -MONTORETIRO) FROM [_CAPITALSOCIAL]  WHERE NROSOCIO = " + Trim(txtNrosocio.Text) + "  ", conexiones5._conexion)
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
                    MsgBox("No Cuenta con capital social")
                End Try


                ' SE AGREGA LA RESTA DE PAGOS  NO CONTABILAZDOS ---------------------------------------------------
                ' SE AGREGA LA RESTA DE PAGOS  NO CONTABILAZDOS ---------------------------------------------------
                ' SE AGREGA LA RESTA DE PAGOS  NO CONTABILAZDOS ---------------------------------------------------
                ' SE AGREGA LA RESTA DE PAGOS  NO CONTABILAZDOS ---------------------------------------------------
                ' SE AGREGA LA RESTA DE PAGOS  NO CONTABILAZDOS ---------------------------------------------------
                ' SE AGREGA LA RESTA DE PAGOS  NO CONTABILAZDOS ---------------------------------------------------
                Dim sumaingresonocontabilizado As Long
                Dim conexiones72 As New CConexion
                conexiones72.conexion()
                Dim command72 As SqlCommand = New SqlCommand(" select    ISNULL(sum(CAPITALSOCIAL),0)  FROM  [_INGRESOS] where  NROSOCIO =  " + Trim(txtNrosocio.Text) + "  and ESTADOCONT ='S'  ", conexiones72._conexion)
                conexiones72.abrir()
                Dim reader72 As SqlDataReader = command72.ExecuteReader()
                If reader72.HasRows Then
                    Do While reader72.Read()
                        sumaingresonocontabilizado = reader72(0)
                    Loop
                Else
                End If
                reader72.Close()
                conexiones72.cerrar()
                Sumatotal = Sumatotal + sumaingresonocontabilizado
                ' SE AGREGA LA RESTA DE PAGOS  NO CONTABILAZDOS ---------------------------------------------------
                ' SE AGREGA LA RESTA DE PAGOS  NO CONTABILAZDOS ---------------------------------------------------
                ' SE AGREGA LA RESTA DE PAGOS  NO CONTABILAZDOS ---------------------------------------------------
                ' SE AGREGA LA RESTA DE PAGOS  NO CONTABILAZDOS ---------------------------------------------------
                ' SE AGREGA LA RESTA DE PAGOS  NO CONTABILAZDOS ---------------------------------------------------
                ' SE AGREGA LA RESTA DE PAGOS  NO CONTABILAZDOS ---------------------------------------------------
                Dim RestaRetiroNocontabilizado As Long
                Dim conexiones7 As New CConexion
                conexiones7.conexion()
                Dim command7 As SqlCommand = New SqlCommand(" select ISNULL(sum(CAPITALSOCIAL2),0)  FROM  [_INGRESOS] where  NROSOCIO =  " + Trim(txtNrosocio.Text) + "  and ESTADOCONT ='S'  ", conexiones7._conexion)
                conexiones7.abrir()
                Dim reader7 As SqlDataReader = command7.ExecuteReader()
                If reader7.HasRows Then
                    Do While reader7.Read()
                        RestaRetiroNocontabilizado = reader7(0)
                    Loop
                Else
                End If
                reader7.Close()
                conexiones7.cerrar()
                Sumatotal = Sumatotal - RestaRetiroNocontabilizado

                'SE AGREGA LA RESTA DE PAGOS  NO CONTABILAZDOS ---------------------------------------------------
                'SE AGREGA LA RESTA DE PAGOS  NO CONTABILAZDOS ---------------------------------------------------
                'SE AGREGA LA RESTA DE PAGOS  NO CONTABILAZDOS ---------------------------------------------------
                'SE AGREGA LA RESTA DE PAGOS  NO CONTABILAZDOS ---------------------------------------------------
                'SE AGREGA LA RESTA DE PAGOS  NO CONTABILAZDOS ---------------------------------------------------
                'SE AGREGA LA RESTA DE PAGOS  NO CONTABILAZDOS ---------------------------------------------------
                'llena grid de las cuentas  bancarias que tiene el socio 

                If validarcolumnacheckcreada = True Then
                    sacarcolumna()
                End If

                _tabla26.Rows.Clear()
                _tabla26.Columns.Clear()
                Dim conexiones4 As New CConexion
                conexiones4.conexion()
                _adaptador.SelectCommand = New SqlCommand("SELECT  banco.DESCRIPCION ,[CUENTA] AS Nº_CUENTA,bancos2.descripcion as BANCO ,bancos2.CODBANCO as CODIGO_BANCO ,banco.codigo as CODIGO_CUENTA FROM [_SOCIOSCUENTAS] as cuentas   inner join [_TESORERIA_TIPO_CUENTA_BANCO] as banco on cuentas.TIPOCTA = banco.CODIGO  inner join _TESORERIA_BANCOS as bancos2 on bancos2.codbanco = cuentas.CODIGOBANCO     WHERE NROSOCIO = " + Trim(txtNrosocio.Text) + "  ORDER BY USUAL desc  ", conexiones4._conexion)
                conexiones4.abrir()
                _adaptador.Fill(_tabla26)
                Gridcuentas.DataSource = _tabla26
                conexiones4.cerrar()

                Dim Validacuenta As String = ""
                Dim conexiones11 As New CConexion
                conexiones11.conexion()
                Dim command11 As SqlCommand = New SqlCommand(" SELECT NROSOCIO FROM [_SOCIOSCUENTAS] where NROSOCIO = " + Trim(txtNrosocio.Text) + " ", conexiones11._conexion)
                conexiones11.abrir()
                Dim reader11 As SqlDataReader = command11.ExecuteReader()
                If reader11.HasRows Then
                    Do While reader11.Read()
                        Validacuenta = reader11(0).ToString
                    Loop
                Else
                End If
                reader11.Close()
                conexiones11.cerrar()
                If Validacuenta = "" Then
                    MsgBox("Sin cuenta bancaria ")
                    'cboformapago.Items.Clear()
                    'cboformapago.Items.Add("EFECTIVO")
                    'cboformapago.Items.Add("CHEQUE")
                    validarcolumnacheckcreada = False
                Else
                    'cboformapago.Items.Clear()
                    'cboformapago.Items.Add("TRANSFERENCIA")
                    'cboformapago.Items.Add("EFECTIVO")
                    'cboformapago.Items.Add("CHEQUE")
                    validarcolumnacheckcreada = True
                    crearcolumna()
                End If

                Gridcuentas.AllowUserToAddRows = False
                'Llenado de textbox
                Textcuotasdeparticipacion.Text = PuntoX(ValorCuota)
                Texttiporequerimiento.Text = Cbotipo.SelectedItem.ToString()
                Textcorrecionmonetaria.Text = PuntoX(REVALORISACIONDELCAPITAL)
                Texttotales.Text = PuntoX(Sumatotal)
                Texttotalnoretirable.Text = PuntoX(ValorCuota + REVALORISACIONDELCAPITAL)


                recibevalor = (Sumatotal - Texttotalnoretirable.Text)
                ' MsgBox(recibevalor)


                Dim sumaRequeriminetosnopagados As String = ""
                Dim totalparaverificar As Long = 0
                ' Dim nopermitehacersolciitud As Boolean = True
                Dim conexiones112 As New CConexion
                conexiones112.conexion()
                Dim command112 As SqlCommand = New SqlCommand(" SELECT isnull(sum(monto_solicitud),0) FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL] where NROSOCIO = " + Trim(txtNrosocio.Text) + " and estado_solicitud<>'PAGADO ' AND estado_solicitud<>'ANULADA' AND estado_solicitud<>'RECHAZADA'", conexiones112._conexion)
                conexiones112.abrir()
                Dim reader112 As SqlDataReader = command112.ExecuteReader()
                If reader112.HasRows Then
                    Do While reader112.Read()
                        sumaRequeriminetosnopagados = reader112(0).ToString
                    Loop
                Else
                End If
                reader112.Close()
                conexiones112.cerrar()



                If recibevalor > 0 Then
                    Textmontodisponible.Text = PuntoX(Sumatotal - Texttotalnoretirable.Text)
                    Textmontodisponible.Text = PuntoX(Textmontodisponible.Text - sumaRequeriminetosnopagados)
                ElseIf recibevalor < 0 Then
                    'Textmontodisponible.Text = PuntoX((Texttotalnoretirable.Text - Sumatotal) * -1)
                    Textmontodisponible.Text = 0
                    'ElseIf recibevalor < 0 Then

                ElseIf recibevalor = 0 Then
                    Textmontodisponible.Text = 0

                End If
                ' MsgBox(Textmontodisponible.Text)
                recibemontoretirable = Math.Round(Int(Textmontodisponible.Text / 2 / 1000) * 1000)
                Textmontomaximoretirable.Text = PuntoX(recibemontoretirable)
                Fichacompleta.Visible = True
                'Informacion  montos 

                Texttiporequerimiento.ReadOnly = True
                Textrut.ReadOnly = True
                Texttotales.ReadOnly = True
                Textcorrecionmonetaria.ReadOnly = True
                Textcuotasdeparticipacion.ReadOnly = True
                Texttotalnoretirable.ReadOnly = True
                Textmontodisponible.ReadOnly = True
                Textmontomaximoretirable.ReadOnly = True
                'Informacion Socio 
                Textnombre.ReadOnly = True
                Textnrosocio.ReadOnly = True
                Textcorreo.ReadOnly = True
                Texttelefono.ReadOnly = True
                Textdireccion.ReadOnly = True
                Textestado.Text = "SOLICITADO"


                'Dim sumaRequeriminetosnopagados As String = ""
                'Dim totalparaverificar As Long = 0
                '' Dim nopermitehacersolciitud As Boolean = True
                'Dim conexiones112 As New CConexion
                'conexiones112.conexion()
                'Dim command112 As SqlCommand = New SqlCommand(" SELECT isnull(sum(monto_solicitud),0) FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL] where NROSOCIO = " + Trim(txtNrosocio.Text) + " and estado_solicitud<>'PAGADO ' AND estado_solicitud<>'ANULADA' AND estado_solicitud<>'RECHAZADA'", conexiones112._conexion)
                'conexiones112.abrir()
                'Dim reader112 As SqlDataReader = command112.ExecuteReader()
                'If reader112.HasRows Then
                '    Do While reader112.Read()
                '        sumaRequeriminetosnopagados = reader112(0).ToString
                '    Loop
                'Else
                'End If
                'reader112.Close()
                'conexiones112.cerrar()

                If sumaRequeriminetosnopagados = "" Then
                    Textmontototalmenoss.Text = 0
                ElseIf sumaRequeriminetosnopagados <> "" And sumaRequeriminetosnopagados <> "0" Then
                    Textmontototalmenoss.Text = sumaRequeriminetosnopagados
                End If

                ' MsgBox(totalparaverificar)
                ' MsgBox()

                totalparaverificar = CLng(Texttotales.Text) - CLng(sumaRequeriminetosnopagados)
                Textsaldoreal.Text = totalparaverificar
                'MsgBox(totalparaverificar)
                If totalparaverificar = 0 Or totalparaverificar < 0 Then
                    Button1.Enabled = False
                Else
                End If

              







                MensajeAlertaMovimientoSocios7Dias.Enabled = True
                MensajeAlertaMovimientoSocios7Dias.Show()
            Else
                MsgBox("No existe Nº de socio ingresado ")
            End If
                'End If
                'que no exista numero socio 
            Else
                MsgBox("No existe Socio con ese rut  ")

            End If
        'End If





    End Sub

    'funcion  la cual  evalua  si el  socio esta en condiciones de retirar  capital  
    Sub BotonEvaluar()


        If CLng(Textsaldoreal.Text) > CLng(Textmontorequerido.Text) Or CLng(Textsaldoreal.Text) = CLng(Textmontorequerido.Text) Then
                Dim Retirocapitalanual As Integer = 0
                Dim Retirocapitalmensual As Integer = 0
                Dim diasmora As Integer = 0
                Dim totalfilasgrid As Integer = 0
                Dim totalfilasgrid2 As Integer = 0
                Dim recibesaldoprestamos As Integer = 0
                Dim contadorsaldoprestamos As Integer = 0
                Dim contadorestadoprestamos As Integer = 0
                'saldos gridcreditos 
                Dim recibesaldogridcreditos As Integer = 0
                Dim recibecorcreditogridcreditos As String = ""
                'saldos gridestadoscreditos 
                Dim recibesaldogridestadoscreditos As Integer = 0
                Dim banderacreditomoros As Boolean = False
                Dim banderaexitecredito As Boolean = False
                Dim SumanAprobaciondirecta As Integer = 0
                'fitors papuchones 
                Dim Banderacapitalminimo As Boolean = False
                Dim banderacapitlaglobal As Boolean = False
                Dim deudaindirecta As Integer = 0

                'Dim recibecorcreditogridcreditos
                '6.0 Botón EVALUAR: Para obtener la evaluación se debe marcar esta opción.					
                '1. Capital mínimo.					
                '2. Monto solicitado sea menor o igual a MMR.					
                '3. No posea mas de 5 retiros en el año.					
                '4.  No posee otro retiro en el mes.			        Condiciones de 		      Condiciones de 
                '5.  Socio no se encuentra en mora.			            Cumplimiento		      Cumplimiento 
                '6. Avalado no se encuentra en mora.					Reevaluables
                '7. Socio no tenga otras restricciones.					
                '8. El capital de la Cooperativa se encuentre dentro del Límite.

                If Textmontorequerido.Text <> "" Then

                    'NUMERO DE RETIROS EN EL AÑO 
                    Dim conexiones As New CConexion
                    conexiones.conexion()
                    Dim command As SqlCommand = New SqlCommand("SELECT COUNT(*) as retiro_en_año  FROM [_CAPITALSOCIAL] where  NROSOCIO =" + Trim(txtNrosocio.Text) + " and MONTORETIRO > 0 and FECHA >=" + Mid(tomafecha, 7, 10) + "0101 and FECHA <=" + Mid(tomafecha, 7, 10) + "1231 ", conexiones._conexion)
                    conexiones.abrir()
                    Dim reader As SqlDataReader = command.ExecuteReader()
                    If reader.HasRows Then
                        Do While reader.Read()
                            Retirocapitalanual = reader(0)
                            ' MsgBox(Retirocapitalanual)
                        Loop
                    Else
                    End If
                    reader.Close()
                    conexiones.cerrar()
                    'NUMERO DE RETIROS EN EL MES 
                    'Dim conexiones2 As New CConexion
                    'conexiones2.conexion()
                    'Dim command2 As SqlCommand = New SqlCommand("SELECT COUNT(*) as retiro_en_mes FROM [_CAPITALSOCIAL] where  NROSOCIO =" + Trim(txtNrosocio.Text) + " and MONTORETIRO > 0 and FECHA >=" + Mid(tomafecha, 7, 10) + Mid(tomafecha, 4, 2) + "01 and FECHA <=" + Mid(tomafecha, 7, 10) + Mid(tomafecha, 4, 2) + "31 ", conexiones2._conexion)
                    'conexiones2.abrir()
                    'Dim reader2 As SqlDataReader = command2.ExecuteReader()
                    'If reader2.HasRows Then
                    '    Do While reader2.Read()
                    '        Retirocapitalmensual = reader2(0)
                    '        '  MsgBox(Retirocapitalmensual)
                    '    Loop
                    'Else
                    'End If
                    'reader2.Close()
                    _TABLA27.Rows.Clear()
                    _TABLA27.Columns.Clear()
                    'VERIFICA CREDITO AL DIA ------------------------------------------------------------------------------
                    Dim conexiones4 As New CConexion
                    conexiones4.conexion()
                    _adaptador.SelectCommand = New SqlCommand("SELECT _PRESTDIARIO.CORCREDITO,(SELECT SUM(CARGO-ABONO) FROM (SELECT CARGO,ABONO FROM _PRESTAMOS2 WHERE OPERCRED = _PRESTDIARIO.CORCREDITO AND FECHA <=  " + Mid(tomafecha, 7, 10) + Mid(tomafecha, 4, 2) + "31 UNION ALL SELECT 0 AS CARGO , CASaldoCapital+CAInteresVencidoNP+CAInteresGanado+CAInteresProximo+CAInteresNoVencido AS ABONO  FROM _INGRESOS INNER JOIN _INGREOPER ON _INGRESOS.CORRELATIVO = _INGREOPER.OPERING AND _INGRESOS.TIPOINGRESO = 'INGCAJA' AND _INGRESOS.ESTADOCONT = 'S'AND _INGREOPER.CACORCREDITO = _PRESTDIARIO.CORCREDITO) DERIVEDTBL ) AS SALDOREAL,isnull((SELECT SUM(CAPITAL+INTERES) FROM _AMORTIZACION WHERE _AMORTIZACION.CORCREDITO = _PRESTDIARIO.CORCREDITO AND _AMORTIZACION.ANODESCUENTO*100+_AMORTIZACION.MESDESCUENTO >=" + Mid(tomafecha, 7, 10) + Mid(tomafecha, 4, 2) + "),0 )AS SALDOCORRECTO FROM _PRESTDIARIO WHERE NROSOCIO =" + Trim(txtNrosocio.Text) + "", conexiones4._conexion)
                    _adaptador.Fill(_TABLA27)
                    Gridestadocreditos.DataSource = _TABLA27
                    conexiones4.cerrar()
                    totalfilasgrid = Gridestadocreditos.RowCount - 1
                    For X = 0 To totalfilasgrid
                        'Gridsociocreditos.Rows(X).Cells(0).Value(CORRCREDITO)
                        If Gridestadocreditos.Rows(X).Cells(1).Value() Is DBNull.Value Then
                            'MsgBox("Existe un valor null verificar por favor ")
                        Else
                            If Gridestadocreditos.Rows(X).Cells(1).Value() > 0 Then
                                ' MsgBox(Gridestadocreditos.Rows(X).Cells(1).Value())
                                ' MsgBox(Gridestadocreditos.Rows(X).Cells(2).Value())
                                If Gridestadocreditos.Rows(X).Cells(1).Value() = Gridestadocreditos.Rows(X).Cells(2).Value() Or Gridestadocreditos.Rows(X).Cells(1).Value() < Gridestadocreditos.Rows(X).Cells(2).Value() Then
                                    'MsgBox("Credito al dia ")
                                    'banderacreditomoros = False
                                    cumplesociosinmora = False
                                ElseIf Gridestadocreditos.Rows(X).Cells(1).Value() > Gridestadocreditos.Rows(X).Cells(2).Value() Then
                                    'MsgBox("Credito  con mora")
                                    banderacreditomoros = True
                                    cumplesociosinmora = True
                                End If
                            End If
                        End If
                    Next
                    Try
                        RUTAVAL = ""
                        Dim conexiones6 As New CConexion
                        conexiones6.conexion()
                        Dim command6 As SqlCommand = New SqlCommand("select RUT  from [_AVALES] where RUT = " + Trim(tomarut.ToString) + " ", conexiones6._conexion)
                        conexiones6.abrir()
                        Dim reader6 As SqlDataReader = command6.ExecuteReader()
                        If reader6.HasRows Then
                            Do While reader6.Read()
                                RUTAVAL = reader6(0).ToString
                            Loop
                        Else
                        End If
                        reader6.Close()
                        conexiones.cerrar()
                    Catch ex As Exception
                        MsgBox("Problemas al buscar rut aval ")
                    End Try

                    If RUTAVAL <> "" Then
                        'SELECT AVAL1,AVAL2,NROSOCIO FROM _PRESTDIARIO  WHERE AVAL1  = 17203498 or AVAL2 =17203498
                        _TABLA29.Rows.Clear()
                        _TABLA29.Columns.Clear()
                        'Verifica Creditos al dia 
                        Dim conexiones44 As New CConexion
                        conexiones44.conexion()
                        _adaptador.SelectCommand = New SqlCommand("SELECT AVAL1,AVAL2,CORCREDITO FROM _PRESTDIARIO  WHERE AVAL1  = " + Trim(tomarut.ToString) + " or AVAL2 =" + Trim(tomarut.ToString) + "", conexiones44._conexion)
                        _adaptador.Fill(_TABLA29)
                        GridAval.DataSource = _TABLA29
                        conexiones44.cerrar()

                        Gridaval2.Rows.Clear()
                        Dim totalfilas As Integer = GridAval.Rows.Count - 1
                        For z = 0 To totalfilas
                            Gridaval2.Rows.Add(GridAval.Rows(z).Cells(2).Value())
                            tomacorcredito = GridAval.Rows(z).Cells(2).Value()
                            'MsgBox(tomacorcredito)
                        Next
                        Dim totalfilas2 As Integer = Gridaval2.Rows.Count - 1
                        For t = 0 To totalfilas2
                            _TABLA27.Rows.Clear()
                            _TABLA27.Columns.Clear()
                            'Verifica Creditos al dia 
                            'MsgBox(Trim(Gridaval2.Rows(t).Cells(0).Value()))
                            Dim conexiones444 As New CConexion
                            conexiones444.conexion()
                            _adaptador.SelectCommand = New SqlCommand("SELECT _PRESTDIARIO.CORCREDITO,(SELECT SUM(CARGO-ABONO) FROM (SELECT CARGO,ABONO FROM _PRESTAMOS2 WHERE OPERCRED = _PRESTDIARIO.CORCREDITO AND FECHA <=  " + Mid(tomafecha, 7, 10) + Mid(tomafecha, 4, 2) + "31 UNION ALL SELECT 0 AS CARGO , CASaldoCapital+CAInteresVencidoNP+CAInteresGanado+CAInteresProximo+CAInteresNoVencido AS ABONO  FROM _INGRESOS INNER JOIN _INGREOPER ON _INGRESOS.CORRELATIVO = _INGREOPER.OPERING AND _INGRESOS.TIPOINGRESO = 'INGCAJA' AND _INGRESOS.ESTADOCONT = 'S'AND _INGREOPER.CACORCREDITO = _PRESTDIARIO.CORCREDITO) DERIVEDTBL ) AS SALDOREAL,isnull((SELECT SUM(CAPITAL+INTERES) FROM _AMORTIZACION WHERE _AMORTIZACION.CORCREDITO = _PRESTDIARIO.CORCREDITO AND _AMORTIZACION.ANODESCUENTO*100+_AMORTIZACION.MESDESCUENTO >=" + Mid(tomafecha, 7, 10) + Mid(tomafecha, 4, 2) + "),0 )AS SALDOCORRECTO FROM _PRESTDIARIO WHERE CORCREDITO =" + Trim(Gridaval2.Rows(t).Cells(0).Value()) + "", conexiones444._conexion)
                            _adaptador.Fill(_TABLA27)
                            Gridestadocreditos.DataSource = _TABLA27
                            conexiones444.cerrar()
                            totalfilasgrid = Gridestadocreditos.RowCount - 1
                            ' MsgBox(Trim(Gridaval2.Rows(t).Cells(0).Value()))
                            For x = 0 To totalfilasgrid
                                'Gridsociocreditos.Rows(X).Cells(0).Value(CORRCREDITO)
                                If Gridestadocreditos.Rows(x).Cells(1).Value() Is DBNull.Value Then
                                    ' MsgBox("Existe un valor null verificar por favor ")
                                Else
                                    If Gridestadocreditos.Rows(x).Cells(1).Value() > 0 Then
                                        If Int(Gridestadocreditos.Rows(x).Cells(1).Value()) = Int(Gridestadocreditos.Rows(x).Cells(2).Value()) Or Int(Gridestadocreditos.Rows(x).Cells(1).Value()) < Int(Gridestadocreditos.Rows(x).Cells(2).Value()) Then
                                            '    MsgBox("Credito al dia ")
                                            cumpleavalsinmora = False
                                            PRIMERFILTROCREDITOINDIRECTOMOROS = False
                                        ElseIf Int(Gridestadocreditos.Rows(x).Cells(1).Value()) > Int(Gridestadocreditos.Rows(x).Cells(2).Value()) Then
                                            ' MsgBox("Credito  como aval  mora")
                                            cumpleavalsinmora = True
                                            PRIMERFILTROCREDITOINDIRECTOMOROS = True
                                            deudaindirecta = deudaindirecta + 1
                                            'MsgBox(Gridaval2.Rows(t).Cells(0).Value())
                                        End If
                                    End If
                                End If
                            Next
                        Next


                        '**************************************************************************************************************************************************************************
                        'Se  ve si el socio como aval posee una deuda indirecta si esta se encutra en castigo o avenimiento 
                        _tabla37.Rows.Clear()
                        _tabla37.Columns.Clear()
                        Dim conexiones666 As New CConexion
                        conexiones666.conexion()
                        _adaptador.SelectCommand = New SqlCommand("SELECT NROSOCIO,PATERNO,MATERNO,NOMBRES,ISNULL((SELECT SUM(CARGO-ABONO) FROM _PRESTAMOS2 WHERE OPERCRED IN (SELECT CORCREDITO FROM _PRESTDIARIO WHERE AVAL1 = _SOCIOS.RUT OR AVAL2 = _SOCIOS.RUT )),0) AS PRESTAMOSINDIRECTOS,ISNULL((SELECT SUM(CARGO-ABONO) FROM _CASTIGOCOLOCACIONES2 WHERE OPERCRED IN (SELECT CORCREDITO FROM _PRESTDIARIO WHERE AVAL1 = _SOCIOS.RUT OR AVAL2 = _SOCIOS.RUT )),0) AS CASTIGOSINDIRECTOS,ISNULL((SELECT SUM(CAR_AVENIM+CAR_PORIMPU-ABO_ABOGADO-ABO_RECEPTOR-ABO_JUDICIAL-ABO_INTERES-ABO_CAPITAL) FROM _AVECUENTA WHERE OPERCRED IN (SELECT CORCREDITO FROM _PRESTDIARIO WHERE AVAL1 = _SOCIOS.RUT OR AVAL2 = _SOCIOS.RUT )),0) AS AVENIMIENTO From _SOCIOS WHERE NROSOCIO ='" + Trim(Textnrosocio.Text) + "'", conexiones666._conexion)
                        _adaptador.Fill(_tabla37)
                        Deudasindirectas.DataSource = _tabla37
                        conexiones666.cerrar()
                        Gridaval2.Rows.Clear()

                        Dim totalfiasdeudaindirecta As Integer = Deudasindirectas.Rows.Count - 1
                        'MsgBox(totalfiasdeudaindirecta)
                        For x = 0 To totalfiasdeudaindirecta
                            If Trim(Deudasindirectas.Rows(x).Cells(5).Value()) = "0" And Trim(Deudasindirectas.Rows(x).Cells(6).Value()) = "0" Then
                                'MsgBox("Sin deuda indirecta ")
                                If PRIMERFILTROCREDITOINDIRECTOMOROS = False Then
                                    cumpleavalsinmora = False
                                ElseIf PRIMERFILTROCREDITOINDIRECTOMOROS = True Then
                                    cumpleavalsinmora = True
                                End If

                            Else
                                ' MsgBox("Pose una deuda indirecta ")
                                If PRIMERFILTROCREDITOINDIRECTOMOROS = True Then
                                    cumpleavalsinmora = True
                                ElseIf PRIMERFILTROCREDITOINDIRECTOMOROS = False Then
                                    cumpleavalsinmora = False
                                End If



                            End If
                        Next
                        'MsgBox(cumpleavalsinmora)
                        '******-********************************************************************************************************************************************************************
                    Else
                        'MsgBox("No es Aval ")
                    End If

                    'Dim recibecorcreditogridcreditos
                    '6.0 Botón EVALUAR: Para obtener la evaluación se debe marcar esta opción.					
                    '1. Capital mínimo.					
                    '2. Monto solicitado sea menor o igual a MMR.					
                    '3. No posea mas de 5 retiros en el año.					
                    '4.  No posee otro retiro en el mes.			        Condiciones de 		      Condiciones de 
                    '5.  Socio no se encuentra en mora.			            Cumplimiento		      Cumplimiento 
                    '6. Avalado no se encuentra en mora.					Reevaluables
                    '7. Socio no tenga otras restricciones.					
                    '8. El capital de la Cooperativa se encuentre dentro del Límite.

                    '
                    If Texttotales.Text = 0 Then
                        Tienemonto = False
                    Else
                        Tienemonto = True
                    End If
                    '1. Capital mínimo.-------------------------------------------------------------------------------------------------------------------------------------------------------------------	
                    If Texttotales.Text = 0 Then
                        frmMuestraEvaluacionCapital.Pic1B.Visible = True
                        frmMuestraEvaluacionCapital.Pic1A.Visible = False
                        'filtro
                        cumplecapitalminimo = False
                    ElseIf Texttotales.Text > 0 Then

                        frmMuestraEvaluacionCapital.Pic1B.Visible = False
                        frmMuestraEvaluacionCapital.Pic1A.Visible = True
                        'filtro
                        cumplecapitalminimo = True
                    End If
                    '2. Monto solicitado sea menor o igual a MMR.-----------------------------------------------------------------------------------------------------------------------------------------				
                    If Int(Textmontorequerido.Text) > Int(Textmontomaximoretirable.Text) Then
                        frmMuestraEvaluacionCapital.Pic2B.Visible = True
                        frmMuestraEvaluacionCapital.Pic2A.Visible = False
                        'filtro
                        'MsgBox("soy mayor")
                        cumplemontosolicitado = False

                    ElseIf Int(Textmontorequerido.Text) <= Int(Textmontomaximoretirable.Text) Then
                        frmMuestraEvaluacionCapital.Pic2B.Visible = False
                        frmMuestraEvaluacionCapital.Pic2A.Visible = True
                        'filtro
                        cumplemontosolicitado = True
                    End If

                    '3. No posea mas de 5 retiros en el año.----------------------------------------------------------------------------------------------------------------------------------------------	
                    If Retirocapitalanual >= 5 Then
                        frmMuestraEvaluacionCapital.Pic3B.Visible = True
                        frmMuestraEvaluacionCapital.Pic3A.Visible = False
                        'filtro
                        cumplenroretirosanuales = False

                    ElseIf Retirocapitalanual <= 5 Then
                        frmMuestraEvaluacionCapital.Pic3B.Visible = False
                        frmMuestraEvaluacionCapital.Pic3A.Visible = True
                        'filtro
                        cumplenroretirosanuales = True

                    End If

                    'If Retirocapitalmensual >= 1 Then
                    '    'MsgBox("Poseee mas  de 1 retir en el mes  ")
                    '    frmMuestraEvaluacionCapital.Pic4B.Visible = True
                    '    frmMuestraEvaluacionCapital.Pic4A.Visible = False
                    '    cumplenroretirosmensuales = False
                    'ElseIf Retirocapitalmensual < 1 Then
                    '    frmMuestraEvaluacionCapital.Pic4B.Visible = False
                    '    frmMuestraEvaluacionCapital.Pic4A.Visible = True
                    '    '----------------------------------------------------------------------------4
                    '    SumanAprobaciondirecta = SumanAprobaciondirecta + 1
                    '    cumplenroretirosmensuales = True
                    'End If


                    '5.  Socio no se encuentra en mora.---------------------------------------------------------------------------------------------------------------------------------------------------		
                    If banderacreditomoros = True Then
                        'Credito en mora------------------------------ 
                        'sicio en mora 
                        frmMuestraEvaluacionCapital.Pic5B.Visible = True
                        frmMuestraEvaluacionCapital.Pic5A.Visible = False
                        cumplesociosinmora = False
                    ElseIf banderacreditomoros = False Then

                        frmMuestraEvaluacionCapital.Pic5B.Visible = False
                        frmMuestraEvaluacionCapital.Pic5A.Visible = True
                        cumplesociosinmora = True
                    End If

                    '6. Avalado no se encuentra en mora.---------------------------------------------------------------------------------------------------------------------------------------------------	
                    If cumpleavalsinmora = False Then
                        frmMuestraEvaluacionCapital.Pic6B.Visible = False
                        frmMuestraEvaluacionCapital.Pic6A.Visible = True
                        'filtro
                        cumpleavalsinmora = False

                    ElseIf cumpleavalsinmora = True Then
                        frmMuestraEvaluacionCapital.Pic6B.Visible = True
                        frmMuestraEvaluacionCapital.Pic6A.Visible = False
                        'filtro
                        cumpleavalsinmora = True
                    End If


                    '7 Socio no tenga otras restricciones.------------------------------------------------------------------------------------------------------------------------------------------------		
                    If cumplerestricciones = False Then
                        'aval en mora 
                        frmMuestraEvaluacionCapital.Pic7B.Visible = True
                        frmMuestraEvaluacionCapital.Pic7A.Visible = False
                    ElseIf cumplerestricciones = True Then
                        'HACE REFERENCIA A QUE EL AVAL ESTA PAGANDO EL CREDITO
                        frmMuestraEvaluacionCapital.Pic7B.Visible = False
                        frmMuestraEvaluacionCapital.Pic7A.Visible = True

                    End If

                    'filtro para el totoal de capitla disponible 
                    '8. El capital de la Cooperativa se encuentre dentro del Límite.---------------------------------------------------------------------------------------------------------------------




                    Dim filtroestatico As String = ""
                    Try
                        Dim conexiones22 As New CConexion
                        conexiones22.conexion()
                        Dim command22 As SqlCommand = New SqlCommand("SELECT [FILTRO_CAPITAL_GLOBAL]  FROM  [_RIESGO_DETA_CONTROL_CAPITAL] WHERE ID_TABLA=(SELECT MAX(ID_TABLA) FROM  [_RIESGO_DETA_CONTROL_CAPITAL] )", conexiones22._conexion)
                        conexiones22.abrir()
                        Dim reader22 As SqlDataReader = command22.ExecuteReader()
                        If reader22.HasRows Then
                            Do While reader22.Read()
                                filtroestatico = reader22(0).ToString
                                'MsgBox(filtroestatico)
                            Loop
                        Else
                        End If
                        reader22.Close()
                        conexiones22.cerrar()
                    Catch ex As Exception
                        MsgBox("No se encuentra fecha  para ver el saldo de capital contactarse con el administrador")
                    End Try

                    If filtroestatico = "SI" Then
                        frmMuestraEvaluacionCapital.Pic8B.Visible = False
                        frmMuestraEvaluacionCapital.Pic8A.Visible = True
                        'filtro
                        cumplesaldoencapital = True
                    ElseIf filtroestatico = "NO" Then

                        frmMuestraEvaluacionCapital.Pic8B.Visible = True
                        frmMuestraEvaluacionCapital.Pic8A.Visible = False
                        'filtro
                        cumplesaldoencapital = False
                    End If


                    If Tienemonto = True Then
                        'VARIABLES------------------------------------------------------ 
                        'MsgBox(cumplecapitalminimo)
                        'MsgBox(cumplemontosolicitado)
                        'MsgBox(cumplenroretirosanuales)
                        ''MsgBox(cumplenroretirosmensuales)
                        'MsgBox(cumplesociosinmora)
                        'MsgBox(cumpleavalsinmora)
                        'MsgBox(cumplerestricciones)
                        'MsgBox(cumplesaldoencapital)

                        If cumplecapitalminimo = True And cumplemontosolicitado = True And cumplenroretirosanuales = True And cumplesociosinmora = True And cumpleavalsinmora = False And cumplerestricciones = True And cumplesaldoencapital = True Then
                            'cumplemontosolicitado =    False ' monto solicitado es mayor al monto maximo retirable 
                            'cumplenroretirosanuales =  False pose mas de 5 retiros en el año 
                            'cumplesociosinmora = True  Socio  sin mora 
                            ' cumpleavalsinmora = False  socio sin dedua inderecta
                            ' cumplesaldoencapital = True existe capital  en la coop 
                            frmMuestraEvaluacionCapital.PicDenegado.Visible = False
                            frmMuestraEvaluacionCapital.PicAprobado.Visible = True
                            frmMuestraEvaluacionCapital.btnAutoriza.Enabled = True
                            frmMuestraEvaluacionCapital.btnReconcideracion.Enabled = False
                            MsgBox("APROBADO DIRECTO ")
                            'Falata  el limite de sobre giro capital  para completar la validacion 

                        ElseIf cumplecapitalminimo = False And cumplesaldoencapital = True Then
                            'cumplemontosolicitado =    False ' monto solicitado es mayor al monto maximo retirable 
                            'cumplenroretirosanuales =  False pose mas de 5 retiros en el año 
                            'cumplesociosinmora = True  Socio  sin mora 
                            'cumpleavalsinmora = False  socio sin dedua inderecta
                            'cumplesaldoencapital = True existe capital  en la coop 
                            frmMuestraEvaluacionCapital.PicDenegado.Visible = True
                            frmMuestraEvaluacionCapital.PicAprobado.Visible = False
                            frmMuestraEvaluacionCapital.btnAutoriza.Enabled = False
                            frmMuestraEvaluacionCapital.btnReconcideracion.Enabled = False
                            MsgBox("SOLICITUD DENEGADA ")

                        ElseIf cumplecapitalminimo = True And cumplesaldoencapital = False And (cumplemontosolicitado = True And cumplenroretirosanuales = True And cumplesociosinmora = True And cumpleavalsinmora = False And cumplerestricciones = True) Then
                            'cumplemontosolicitado =    False ' monto solicitado es mayor al monto maximo retirable 
                            'cumplenroretirosanuales =  False pose mas de 5 retiros en el año 
                            'cumplesociosinmora = True  Socio  sin mora 
                            ' cumpleavalsinmora = False  socio sin dedua inderecta
                            ' cumplesaldoencapital = True existe capital  en la coop 
                            frmMuestraEvaluacionCapital.PicDenegado.Visible = False
                            frmMuestraEvaluacionCapital.PicAprobado.Visible = False
                            frmMuestraEvaluacionCapital.btnAutoriza.Enabled = True
                            frmMuestraEvaluacionCapital.btnReconcideracion.Enabled = False
                            MsgBox("CUMPLE PERO QUEDA EN ESTADO  PENDIENTE  POR CAPITAL DISPONIBLE")
                        ElseIf cumplecapitalminimo = True And cumplesaldoencapital = True And (cumplemontosolicitado = False Or cumplenroretirosanuales = False Or cumplesociosinmora = False Or cumpleavalsinmora = True Or cumplerestricciones = False) Then
                            'cumplemontosolicitado =    False ' monto solicitado es mayor al monto maximo retirable 
                            'cumplenroretirosanuales =  False pose mas de 5 retiros en el año 
                            'cumplesociosinmora = True  Socio  sin mora 
                            ' cumpleavalsinmora = False  socio sin dedua inderecta
                            ' cumplesaldoencapital = True existe capital  en la coop 
                            frmMuestraEvaluacionCapital.PicDenegado.Visible = False
                            frmMuestraEvaluacionCapital.PicAprobado.Visible = False
                            frmMuestraEvaluacionCapital.btnAutoriza.Enabled = False
                            frmMuestraEvaluacionCapital.btnReconcideracion.Enabled = True
                            MsgBox("PUEDE SER REEVALUABLE")
                            'Falata la restrccion y el limite de sobre giro capital 
                        ElseIf cumplecapitalminimo = True And cumplesaldoencapital = False And (cumplemontosolicitado = False Or cumplenroretirosanuales = False Or cumplesociosinmora = False Or cumpleavalsinmora = True Or cumplerestricciones = False) Then
                            'cumplemontosolicitado =    False ' monto solicitado es mayor al monto maximo retirable 
                            'cumplenroretirosanuales =  False pose mas de 5 retiros en el año 
                            'cumplesociosinmora = True  Socio  sin mora 
                            ' cumpleavalsinmora = False  socio sin dedua inderecta
                            ' cumplesaldoencapital = True existe capital  en la coop 
                            frmMuestraEvaluacionCapital.PicDenegado.Visible = False
                            frmMuestraEvaluacionCapital.PicAprobado.Visible = False
                            frmMuestraEvaluacionCapital.btnAutoriza.Enabled = False
                            frmMuestraEvaluacionCapital.btnReconcideracion.Enabled = True 'FALTA AGREGAR  LA FOTO DE LA RECONCIDERACION  PENDIENTE POR CAPITAL 
                            MsgBox("RECONSIDERACIÓN  Y LUEGO  EN ESTADO  PENDIENTE  POR CAPITAL DISPONIBLE")


                        End If


                    Else
                        'No tiene capital para retirar 
                        MsgBox("SOLICITUD DENEGADA ")
                        frmMuestraEvaluacionCapital.PicDenegado.Visible = True
                        frmMuestraEvaluacionCapital.PicAprobado.Visible = False
                        frmMuestraEvaluacionCapital.btnAutoriza.Enabled = False
                        frmMuestraEvaluacionCapital.btnReconcideracion.Enabled = False
                    End If
                    Me.Visible = False
                    frmMuestraEvaluacionCapital.MdiParent = frmRIESGO
                    frmMuestraEvaluacionCapital.Visible = True
                Else
                    MsgBox("Debe ingresar monto  a retirar ")
                End If


            ElseIf CLng(Textsaldoreal.Text) < CLng(Textmontorequerido.Text) Then
                Button1.Enabled = False
                MsgBox("Monto solicitado supera al monto maximo retirable")
            End If


        '





        'MsgBox("El socio Numero :" + nrosocio.ToString + " utilizo  el  Beneficio Prelación Avanza por lo cual segun los reglamentos no puede volver a solicitar un giro dentro de 24 meses a contar de la fecha " + FECHAMUESTRA.ToString + "", MessageBoxIcon.Stop)
        'MsgBox("Error no concuerda el R.U.T ", MessageBoxIcon.Stop)








        ' End If





    End Sub
    'FUNCIONES  DE  ( DISEÑO PUNTOS )  Y ( VALIDACION RUT )
    Public Function ValidarRut(ByVal Rut As String) As String
        Dim Digito As Integer
        Dim Contador As Integer
        Dim Multiplo As Integer
        Dim Acumulador As Integer
        Dim str_AuxDig As String = Nothing
        Dim str_Digito As String = Mid(Rut.ToUpper(), Rut.Length(), 1)
        Dim str_Rut As String = Mid(Rut, 1, Rut.Length() - 2)
        Contador = 2
        Acumulador = 0
        While str_Rut <> 0
            Multiplo = (str_Rut Mod 10) * Contador
            Acumulador = Acumulador + Multiplo
            str_Rut = str_Rut \ 10
            Contador = Contador + 1
            If Contador = 8 Then
                Contador = 2
            End If
        End While
        Digito = 11 - (Acumulador Mod 11)
        str_AuxDig = CStr(Digito)
        Select Case Digito
            Case Is = 10 : str_AuxDig = "K"
            Case Is = 11 : str_AuxDig = "0"
            Case Else : str_AuxDig = str_AuxDig
        End Select
        If str_Digito <> str_AuxDig Then
            ValidarRut = "Rut Incorrecto"
        Else
            ValidarRut = "Rut Correcto"
        End If
        Return ValidarRut
    End Function

    'Sub RevalorizacionUF()
    '    'REAL SQL CON LA VARIABLE DEL DIA ACTUAL 

    '    TextrevalorizacionUF.ReadOnly = True
    '    Textcuotadegastos.ReadOnly = False
    '    TextCapitalabonaCreditos.ReadOnly = False


    '    Dim FECHACOMPLETA2 As String = ""
    '    Dim FECHACOMPLETA3 As String = ""
    '    Dim AÑO As String = ""
    '    FECHACOMPLETA2 = DateTime.Now().ToShortDateString()  '"16/06/2009"
    '    'VOLVEEEER A DEJAR PARA QUE PEUDA  CAMBIAR  EN EL MIMSO MES  SOLMKANRTE 
    '    FECHACOMPLETA3 = Mid(FECHACOMPLETA2, 7, 10) + Mid(FECHACOMPLETA2, 4, 2) + Mid(FECHACOMPLETA2, 1, 2)
    '    AÑO = Mid(FECHACOMPLETA2, 7, 10)

    '    'Dim ValorUFdiaActualstring As String = ""
    '    'Dim ValorUFdiaActualstringparte1 As String = ""
    '    'Dim ValorUFdiaActualstringparte2 As String = ""
    '    'Dim ValorUFdiaActual As Double

    '    Dim ValorMontoReajustado As Long
    '    'Dim ValorSaldoAporteretiro As Long
    '    Dim valordiaactulauf As String = ""

    '    Dim diferenciavalorufmenoscapitalsocial As Long

    '    'SELECT VALORUF FROM [LROSAS_R].[dbo].[_VALORUF] where FECHA='20150103' 

    '    Dim conexionesee As New CConexion
    '    conexionesee.conexion()
    '    Dim commandee As SqlCommand = New SqlCommand("SELECT VALORUF FROM [_VALORUF] where FECHA='" + Trim(FECHACOMPLETA3) + "' ", conexionesee._conexion)
    '    conexionesee.abrir()
    '    Dim readeree As SqlDataReader = commandee.ExecuteReader()
    '    If readeree.HasRows Then
    '        Do While readeree.Read()
    '            valordiaactulauf = readeree(0)
    '            'ValorUFdiaActual = reader(0)
    '            'MsgBox(ValorUFdiaActual)
    '        Loop
    '    Else
    '    End If
    '    readeree.Close()
    '    conexionesee.cerrar()
    '    'Textvalorufdiactual.Text = Math.Round(CDbl(valordiaactulauf))
    '    Textvalorufdiactual.Text = valordiaactulauf

    '    Try
    '        Dim conexiones As New CConexion
    '        conexiones.conexion()
    '        Dim command As SqlCommand = New SqlCommand("select round(sum(_Capitalsocial.movuf*_valoruf.valoruf),0) from _Capitalsocial inner join _VALORUF on _valoruf.FECHA ='" + Trim(FECHACOMPLETA3) + "' where _capitalsocial.NROSOCIO  = '" + Trim(txtNrosocio.Text) + "' and _capitalsocial.fecha >='" + Trim(AÑO) + "0101' ", conexiones._conexion)
    '        conexiones.abrir()
    '        Dim reader As SqlDataReader = command.ExecuteReader()
    '        If reader.HasRows Then
    '            Do While reader.Read()
    '                ValorMontoReajustado = reader(0)
    '                'ValorUFdiaActual = reader(0)
    '                'MsgBox(ValorUFdiaActual)
    '            Loop
    '        Else
    '        End If
    '        reader.Close()
    '        conexiones.cerrar()
    '    Catch ex As Exception
    '        ' MsgBox("tiene capital ")
    '    End Try

    '    TextrevalorizacionUF.Text = ValorMontoReajustado
    '    TextrevalorizacionUF.Text = PuntoX(TextrevalorizacionUF.Text)

    '    Textmontorequerido.Text = ValorMontoReajustado
    '    Textmontorequerido.Text = PuntoX(Textmontorequerido.Text)


    '    TextrevalorizacionUF.ReadOnly = True

    '    Dim sumafinal As Long
    '    Try
    '        'MONTO TOTAL
    '        Dim conexiones5 As New CConexion
    '        conexiones5.conexion()
    '        Dim command5 As SqlCommand = New SqlCommand(" SELECT SUM(MONTOAPORTE -MONTORETIRO) FROM [_CAPITALSOCIAL]  WHERE NROSOCIO =  '" + Trim(txtNrosocio.Text) + "' ", conexiones5._conexion)
    '        conexiones5.abrir()
    '        Dim reader5 As SqlDataReader = command5.ExecuteReader()
    '        If reader5.HasRows Then
    '            Do While reader5.Read()
    '                sumafinal = reader5(0)
    '            Loop
    '        Else
    '        End If
    '        reader5.Close()
    '        conexiones5.cerrar()
    '    Catch ex As Exception
    '        MsgBox("No Cuenta con capital social")
    '    End Try


    '    diferenciavalorufmenoscapitalsocial = ValorMontoReajustado - sumafinal
    '    Textdiferenciufcapital.Text = diferenciavalorufmenoscapitalsocial
    '    'Dim conexiones5 As New CConexion
    '    ' conexiones5.conexion()
    '    ' Dim command5 As SqlCommand = New SqlCommand(" SELECT SUM(MONTOAPORTE -MONTORETIRO) FROM [_CAPITALSOCIAL]  WHERE NROSOCIO = " + Trim(txtNrosocio.Text) + "  ", conexiones5._conexion)
    '    ' conexiones5.abrir()
    '    ' Dim reader5 As SqlDataReader = command5.ExecuteReader()
    '    ' If reader5.HasRows Then
    '    '     Do While reader5.Read()
    '    '         ValorSaldoAporteretiro = reader5(0).ToString
    '    '     Loop
    '    ' Else
    '    ' End If
    '    ' reader5.Close()

    '    'Dim conexiones1 As New CConexion
    '    'conexiones1.conexion()
    '    'Dim command1 As SqlCommand = New SqlCommand("select round(sum(movuf)  * '" + CDbl(ValorUFdiaActual) + "', 0 ) from _Capitalsocial where nrosocio  = '" + Trim(txtNrosocio.Text) + "' and  fecha >='" + Trim(AÑO) + "0101'", conexiones1._conexion)
    '    'conexiones1.abrir()
    '    'Dim reader1 As SqlDataReader = command.ExecuteReader()
    '    'If reader1.HasRows Then
    '    '    Do While reader1.Read()
    '    '        ValorMontoReajustado = reader(0)
    '    '        'MsgBox(Retirocapitalanual)
    '    '    Loop
    '    'Else
    '    'End If
    '    'reader1.Close()
    '    Dim cuotagastos As Integer = 0
    '    Dim conexiones22 As New CConexion
    '    conexiones22.conexion()
    '    Dim command22 As SqlCommand = New SqlCommand("SELECT SUM(CARGO-ABONO) FROM [_CUOTASGASTO2] where nrosocio = '" + Trim(txtNrosocio.Text) + "'", conexiones22._conexion)
    '    conexiones22.abrir()
    '    Dim reader22 As SqlDataReader = command22.ExecuteReader()
    '    If reader22.HasRows Then
    '        Do While reader22.Read()
    '            cuotagastos = reader22(0)
    '            ' MsgBox(Retirocapitalanual)
    '        Loop
    '    Else
    '    End If
    '    reader22.Close()
    '    conexiones22.cerrar()
    '    Textcuotadegastos.Text = PuntoX(cuotagastos)
    '    'Dim ArrCadenaW As String() = ValorUFdiaActualstring.Split(",")
    '    'ValorUFdiaActualstringparte1 = ArrCadenaW(0)
    '    'ValorUFdiaActualstringparte2 = ArrCadenaW(1)
    '    'ValorUFdiaActualstring = ArrCadenaW(0) + "." + ArrCadenaW(1)
    '    'MsgBox(ValorUFdiaActualstring)


    'End Sub


    Public Function PuntoX(ByVal strValor As String, Optional ByVal intNumDecimales As Integer = 0) As String
        Dim strAux As String
        Dim strComas As String
        Dim strPuntos As String
        Dim intX As Integer
        Dim bolMenos As Boolean = False
        strComas = ""
        strValor = strValor.Replace(".", "")
        If InStr(strValor, ",") > 0 Then
            strAux = Mid(strValor, 1, InStr(strValor, ",") - 1)
            strComas = Mid(strValor, InStr(strValor, ","))
        Else
            strAux = strValor
        End If
        If Mid(strAux, 1, 1) = "-" Then
            bolMenos = True
            strAux = Mid(strAux, 2)
        End If
        strPuntos = strAux
        strAux = ""
        While strPuntos.Length > 3
            strAux = "." & Mid(strPuntos, strPuntos.Length - 2, 3) & strAux
            strPuntos = Mid(strPuntos, 1, strPuntos.Length - 3)
        End While
        If intNumDecimales <> 0 Then
            If strComas = "" Then strComas = ","
            For intX = Len(strComas) - 1 To intNumDecimales - 1
                strComas = strComas & "0"
            Next
        End If
        strAux = strPuntos & strAux & strComas
        If Mid(strAux, 1, 1) = "." Then strAux = Mid(strAux, 2)
        If bolMenos Then strAux = "-" & strAux
        Return strAux
    End Function


    'Sub BotonEvaluarRenunciaoFallecimiento()

    '    'frmMuestraEvaluacionCapital.Panel6.Visible = False
    '    frmMuestraEvaluacionCapital.Panel7.Visible = False
    '    'frmMuestraEvaluacionCapital.Panel5.Visible = False
    '    frmMuestraEvaluacionCapital.Panel3.Visible = False
    '    frmMuestraEvaluacionCapital.Panel1.Visible = False
    '    frmMuestraEvaluacionCapital.Panel2.Visible = False



    '    Dim FECHACOMPLETA2 As String = ""
    '    Dim FECHACOMPLETA3 As String = ""
    '    FECHACOMPLETA2 = DateTime.Now().ToShortDateString()  '"16/06/2009"
    '    FECHACOMPLETA3 = Mid(FECHACOMPLETA2, 7, 10) + Mid(FECHACOMPLETA2, 4, 2) + Mid(FECHACOMPLETA2, 1, 2) ' fecha  actual 

    '    Dim Saldoactual As Long

    '    frmDisponibilidadRetiroCapital.Show()
    '    frmDisponibilidadRetiroCapital.Enabled = True
    '    frmDisponibilidadRetiroCapital.BuscarSaldorealfechaactual()
    '    Saldoactual = CDbl(frmDisponibilidadRetiroCapital.Textsaldodeldiaactual.Text)
    '    frmDisponibilidadRetiroCapital.Visible = False
    '    Dim Montosolicitado As Long = CDbl(Textmontorequerido.Text)
    '    If Montosolicitado <= Saldoactual Then
    '        '  MsgBox("Monto solicitado menor  al saldo  actual  ")
    '        frmMuestraEvaluacionCapital.Pic8B.Visible = False
    '        frmMuestraEvaluacionCapital.Pic8A.Visible = True
    '        frmMuestraEvaluacionCapital.PicAprobado.Visible = False
    '        frmMuestraEvaluacionCapital.BtnPendiente.Visible = False
    '        frmMuestraEvaluacionCapital.btnAutoriza.Visible = True
    '        frmMuestraEvaluacionCapital.btnReconcideracion.Visible = False
    '        frmMuestraEvaluacionCapital.Pic8B.Visible = False
    '        frmMuestraEvaluacionCapital.Pic8A.Visible = True
    '    ElseIf Montosolicitado = Saldoactual Then

    '        'MsgBox("Monto  solicitado  es  igual  al   saldo del dia actual  ")

    '        frmMuestraEvaluacionCapital.Pic8B.Visible = False
    '        frmMuestraEvaluacionCapital.Pic8A.Visible = True

    '        frmMuestraEvaluacionCapital.PicAprobado.Visible = False
    '        frmMuestraEvaluacionCapital.BtnPendiente.Visible = False
    '        frmMuestraEvaluacionCapital.btnAutoriza.Visible = True
    '        frmMuestraEvaluacionCapital.btnReconcideracion.Visible = False


    '        frmMuestraEvaluacionCapital.Pic8B.Visible = False
    '        frmMuestraEvaluacionCapital.Pic8A.Visible = True


    '    ElseIf Montosolicitado > Saldoactual Then
    '        '  MsgBox("monto  solicitado es   mayor  al saldo diario  actual  ")
    '        frmMuestraEvaluacionCapital.BtnPendiente.Visible = True
    '        frmMuestraEvaluacionCapital.btnAutoriza.Visible = False
    '        frmMuestraEvaluacionCapital.btnReconcideracion.Visible = False

    '        frmMuestraEvaluacionCapital.PicAprobado.Visible = False
    '        frmMuestraEvaluacionCapital.PicDenegado.Visible = False


    '        frmMuestraEvaluacionCapital.Pic8B.Visible = True
    '        frmMuestraEvaluacionCapital.Pic8A.Visible = False


    '    End If


    '    Dim Retirocapitalanual As Integer = 0
    '    Dim Retirocapitalmensual As Integer = 0
    '    Dim diasmora As Integer = 0
    '    Dim totalfilasgrid As Integer = 0
    '    Dim totalfilasgrid2 As Integer = 0
    '    Dim recibesaldoprestamos As Integer = 0
    '    Dim contadorsaldoprestamos As Integer = 0
    '    Dim contadorestadoprestamos As Integer = 0
    '    'saldos gridcreditos 
    '    Dim recibesaldogridcreditos As Integer = 0
    '    Dim recibecorcreditogridcreditos As String = ""
    '    'saldos gridestadoscreditos 
    '    Dim recibesaldogridestadoscreditos As Integer = 0
    '    Dim banderacreditomoros As Boolean = False
    '    Dim banderaexitecredito As Boolean = False
    '    Dim SumanAprobaciondirecta As Integer = 0
    '    'fitors papuchones 
    '    Dim Banderacapitalminimo As Boolean = False
    '    Dim banderacapitlaglobal As Boolean = False
    '    Dim deudaindirecta As Integer = 0



    '    'Socio no se encuentra en mora.			            
    '    'Avalado no se encuentra en mora.					
    '    'Socio no tenga otras restricciones.					
    '    'El capital de la Cooperativa se encuentre dentro del Límite.

    '    'CREDITO AL DIA ------------------------------------------------------------------------
    '    Dim conexiones4 As New CConexion
    '    conexiones4.conexion()
    '    _adaptador.SelectCommand = New SqlCommand("SELECT _PRESTDIARIO.CORCREDITO,(SELECT SUM(CARGO-ABONO) FROM (SELECT CARGO,ABONO FROM _PRESTAMOS2 WHERE OPERCRED = _PRESTDIARIO.CORCREDITO AND FECHA <=  " + Mid(tomafecha, 7, 10) + Mid(tomafecha, 4, 2) + "31 UNION ALL SELECT 0 AS CARGO , CASaldoCapital+CAInteresVencidoNP+CAInteresGanado+CAInteresProximo+CAInteresNoVencido AS ABONO  FROM _INGRESOS INNER JOIN _INGREOPER ON _INGRESOS.CORRELATIVO = _INGREOPER.OPERING AND _INGRESOS.TIPOINGRESO = 'INGCAJA' AND _INGRESOS.ESTADOCONT = 'S'AND _INGREOPER.CACORCREDITO = _PRESTDIARIO.CORCREDITO) DERIVEDTBL ) AS SALDOREAL,isnull((SELECT SUM(CAPITAL+INTERES) FROM _AMORTIZACION WHERE _AMORTIZACION.CORCREDITO = _PRESTDIARIO.CORCREDITO AND _AMORTIZACION.ANODESCUENTO*100+_AMORTIZACION.MESDESCUENTO >=" + Mid(tomafecha, 7, 10) + Mid(tomafecha, 4, 2) + "),0 )AS SALDOCORRECTO FROM _PRESTDIARIO WHERE NROSOCIO =" + Trim(txtNrosocio.Text) + "", conexiones4._conexion)
    '    _adaptador.Fill(_TABLA27)
    '    Gridestadocreditos.DataSource = _TABLA27
    '    conexiones4.cerrar()
    '    totalfilasgrid = Gridestadocreditos.RowCount - 1
    '    For X = 0 To totalfilasgrid
    '        If Gridestadocreditos.Rows(X).Cells(1).Value() Is DBNull.Value Then
    '        Else
    '            If Gridestadocreditos.Rows(X).Cells(1).Value() > 0 Then

    '                If Gridestadocreditos.Rows(X).Cells(1).Value() = Gridestadocreditos.Rows(X).Cells(2).Value() Or Gridestadocreditos.Rows(X).Cells(1).Value() < Gridestadocreditos.Rows(X).Cells(2).Value() Then
    '                    'MsgBox("Credito al dia ")
    '                    cumplesociosinmora = False
    '                ElseIf Gridestadocreditos.Rows(X).Cells(1).Value() > Gridestadocreditos.Rows(X).Cells(2).Value() Then
    '                    banderacreditomoros = True
    '                    cumplesociosinmora = True
    '                End If
    '            End If
    '        End If
    '    Next
    '    Try
    '        RUTAVAL = ""
    '        Dim conexiones6 As New CConexion
    '        conexiones6.conexion()
    '        Dim command6 As SqlCommand = New SqlCommand("select RUT  from [_AVALES] where RUT = " + Trim(tomarut.ToString) + " ", conexiones6._conexion)
    '        conexiones6.abrir()
    '        Dim reader6 As SqlDataReader = command6.ExecuteReader()
    '        If reader6.HasRows Then
    '            Do While reader6.Read()
    '                RUTAVAL = reader6(0).ToString
    '            Loop
    '        Else
    '        End If
    '        reader6.Close()
    '        conexiones6.cerrar()
    '    Catch ex As Exception
    '        MsgBox("Problemas al buscar rut aval ")
    '    End Try

    '    If RUTAVAL <> "" Then
    '        'SELECT AVAL1,AVAL2,NROSOCIO FROM _PRESTDIARIO  WHERE AVAL1  = 17203498 or AVAL2 =17203498
    '        _TABLA29.Rows.Clear()
    '        _TABLA29.Columns.Clear()
    '        'Verifica Creditos al dia 
    '        Dim conexiones44 As New CConexion
    '        conexiones44.conexion()
    '        _adaptador.SelectCommand = New SqlCommand("SELECT AVAL1,AVAL2,CORCREDITO FROM _PRESTDIARIO  WHERE AVAL1  = " + Trim(tomarut.ToString) + " or AVAL2 =" + Trim(tomarut.ToString) + "", conexiones44._conexion)
    '        _adaptador.Fill(_TABLA29)
    '        GridAval.DataSource = _TABLA29
    '        conexiones44.cerrar()

    '        Gridaval2.Rows.Clear()
    '        Dim totalfilas As Integer = GridAval.Rows.Count - 1
    '        For z = 0 To totalfilas
    '            Gridaval2.Rows.Add(GridAval.Rows(z).Cells(2).Value())
    '            tomacorcredito = GridAval.Rows(z).Cells(2).Value()
    '            'MsgBox(tomacorcredito)
    '        Next
    '        Dim totalfilas2 As Integer = Gridaval2.Rows.Count - 1
    '        For t = 0 To totalfilas2
    '            _TABLA27.Rows.Clear()
    '            _TABLA27.Columns.Clear()
    '            'Verifica Creditos al dia 
    '            'MsgBox(Trim(Gridaval2.Rows(t).Cells(0).Value()))
    '            Dim conexiones444 As New CConexion
    '            conexiones444.conexion()
    '            _adaptador.SelectCommand = New SqlCommand("SELECT _PRESTDIARIO.CORCREDITO,(SELECT SUM(CARGO-ABONO) FROM (SELECT CARGO,ABONO FROM _PRESTAMOS2 WHERE OPERCRED = _PRESTDIARIO.CORCREDITO AND FECHA <=  " + Mid(tomafecha, 7, 10) + Mid(tomafecha, 4, 2) + "31 UNION ALL SELECT 0 AS CARGO , CASaldoCapital+CAInteresVencidoNP+CAInteresGanado+CAInteresProximo+CAInteresNoVencido AS ABONO  FROM _INGRESOS INNER JOIN _INGREOPER ON _INGRESOS.CORRELATIVO = _INGREOPER.OPERING AND _INGRESOS.TIPOINGRESO = 'INGCAJA' AND _INGRESOS.ESTADOCONT = 'S'AND _INGREOPER.CACORCREDITO = _PRESTDIARIO.CORCREDITO) DERIVEDTBL ) AS SALDOREAL,isnull((SELECT SUM(CAPITAL+INTERES) FROM _AMORTIZACION WHERE _AMORTIZACION.CORCREDITO = _PRESTDIARIO.CORCREDITO AND _AMORTIZACION.ANODESCUENTO*100+_AMORTIZACION.MESDESCUENTO >=" + Mid(tomafecha, 7, 10) + Mid(tomafecha, 4, 2) + "),0 )AS SALDOCORRECTO FROM _PRESTDIARIO WHERE CORCREDITO =" + Trim(Gridaval2.Rows(t).Cells(0).Value()) + "", conexiones444._conexion)
    '            _adaptador.Fill(_TABLA27)
    '            Gridestadocreditos.DataSource = _TABLA27
    '            conexiones444.cerrar()
    '            totalfilasgrid = Gridestadocreditos.RowCount - 1
    '            ' MsgBox(Trim(Gridaval2.Rows(t).Cells(0).Value()))
    '            For x = 0 To totalfilasgrid
    '                'Gridsociocreditos.Rows(X).Cells(0).Value(CORRCREDITO)
    '                If Gridestadocreditos.Rows(x).Cells(1).Value() Is DBNull.Value Then
    '                    ' MsgBox("Existe un valor null verificar por favor ")
    '                Else
    '                    If Gridestadocreditos.Rows(x).Cells(1).Value() > 0 Then
    '                        If Gridestadocreditos.Rows(x).Cells(1).Value() = Gridestadocreditos.Rows(x).Cells(2).Value() Or Gridestadocreditos.Rows(x).Cells(1).Value() < Gridestadocreditos.Rows(x).Cells(2).Value() Then
    '                            'MsgBox("Credito al dia ")
    '                            cumpleavalsinmora = False
    '                        ElseIf Gridestadocreditos.Rows(x).Cells(1).Value() > Gridestadocreditos.Rows(x).Cells(2).Value() Then
    '                            'MsgBox("Credito  como aval  mora")
    '                            cumpleavalsinmora = True
    '                            deudaindirecta = deudaindirecta + 1
    '                            'MsgBox(Gridaval2.Rows(t).Cells(0).Value())
    '                        End If
    '                    End If
    '                End If
    '            Next
    '        Next
    '        '**************************************************************************************************************************************************************************
    '        'Se  ve si el socio como aval posee una deuda indirecta si esta se encutra en castigo o avenimiento 
    '        _tabla37.Rows.Clear()
    '        _tabla37.Columns.Clear()
    '        Dim conexiones666 As New CConexion
    '        conexiones666.conexion()
    '        _adaptador.SelectCommand = New SqlCommand("SELECT NROSOCIO,PATERNO,MATERNO,NOMBRES,ISNULL((SELECT SUM(CARGO-ABONO) FROM _PRESTAMOS2 WHERE OPERCRED IN (SELECT CORCREDITO FROM _PRESTDIARIO WHERE AVAL1 = _SOCIOS.RUT OR AVAL2 = _SOCIOS.RUT )),0) AS PRESTAMOSINDIRECTOS,ISNULL((SELECT SUM(CARGO-ABONO) FROM _CASTIGOCOLOCACIONES2 WHERE OPERCRED IN (SELECT CORCREDITO FROM _PRESTDIARIO WHERE AVAL1 = _SOCIOS.RUT OR AVAL2 = _SOCIOS.RUT )),0) AS CASTIGOSINDIRECTOS,ISNULL((SELECT SUM(CAR_AVENIM+CAR_PORIMPU-ABO_ABOGADO-ABO_RECEPTOR-ABO_JUDICIAL-ABO_INTERES-ABO_CAPITAL) FROM _AVECUENTA WHERE OPERCRED IN (SELECT CORCREDITO FROM _PRESTDIARIO WHERE AVAL1 = _SOCIOS.RUT OR AVAL2 = _SOCIOS.RUT )),0) AS AVENIMIENTO From _SOCIOS WHERE NROSOCIO ='" + Trim(Textnrosocio.Text) + "'", conexiones666._conexion)
    '        _adaptador.Fill(_tabla37)
    '        Deudasindirectas.DataSource = _tabla37
    '        conexiones666.cerrar()
    '        Gridaval2.Rows.Clear()

    '        Dim totalfiasdeudaindirecta As Integer = Deudasindirectas.Rows.Count - 1
    '        'MsgBox(totalfiasdeudaindirecta)
    '        For x = 0 To totalfiasdeudaindirecta
    '            If Trim(Deudasindirectas.Rows(x).Cells(5).Value()) = "0" And Trim(Deudasindirectas.Rows(x).Cells(6).Value()) = "0" Then
    '                'MsgBox("Sin deuda indirecta ")
    '                cumpleavalsinmora = False
    '            Else
    '                'MsgBox("Pose una deuda indirecta ")
    '                cumpleavalsinmora = True
    '            End If
    '        Next
    '        'MsgBox(cumpleavalsinmora)
    '        '******-********************************************************************************************************************************************************************
    '    Else
    '        'MsgBox("No es Aval ")
    '    End If


    '    If banderacreditomoros = True Then
    '        'Credito en mora------------------------------ 
    '        'sicio en mora 
    '        frmMuestraEvaluacionCapital.Pic5B.Visible = True
    '        frmMuestraEvaluacionCapital.Pic5A.Visible = False
    '        'cumplesociosinmora = False
    '    ElseIf banderacreditomoros = False Then

    '        frmMuestraEvaluacionCapital.Pic5B.Visible = False
    '        frmMuestraEvaluacionCapital.Pic5A.Visible = True

    '    End If

    '    '6. Avalado no se encuentra en mora.---------------------------------------------------------------------------------------------------------------------------------------------------	
    '    If cumpleavalsinmora = False Then
    '        frmMuestraEvaluacionCapital.Pic6B.Visible = False
    '        frmMuestraEvaluacionCapital.Pic6A.Visible = True
    '        'filtro
    '        cumpleavalsinmora = False

    '    ElseIf cumpleavalsinmora = True Then
    '        frmMuestraEvaluacionCapital.Pic6B.Visible = True
    '        frmMuestraEvaluacionCapital.Pic6A.Visible = False
    '        'filtro
    '        cumpleavalsinmora = True
    '    End If


    '    ' valor  cuota de gastos 
    '    Dim cuotagastos As Integer = 0
    '    Dim conexiones22 As New CConexion
    '    conexiones22.conexion()
    '    Dim command22 As SqlCommand = New SqlCommand("SELECT SUM(CARGO-ABONO) FROM [_CUOTASGASTO2] where nrosocio = '" + Trim(txtNrosocio.Text) + "'", conexiones22._conexion)
    '    conexiones22.abrir()
    '    Dim reader22 As SqlDataReader = command22.ExecuteReader()
    '    If reader22.HasRows Then
    '        Do While reader22.Read()
    '            cuotagastos = reader22(0)
    '            ' MsgBox(Retirocapitalanual)
    '        Loop
    '    Else
    '    End If
    '    reader22.Close()
    '    conexiones22.cerrar()
    '    ' credito moroso 
    '    If banderacreditomoros = True Then
    '        If CDbl(TextCapitalabonaCreditos.Text) = 0 Then
    '            MsgBox("debe ingresar monto para pagar  credito ")
    '        ElseIf CDbl(TextCapitalabonaCreditos.Text) > 0 Then
    '            If (CDbl(Textcuotadegastos.Text) = CDbl(cuotagastos)) Then
    '                frmMuestraEvaluacionCapital.MdiParent = frmRIESGO
    '                frmMuestraEvaluacionCapital.Visible = True

    '            ElseIf (CDbl(Textcuotadegastos.Text) <> CDbl(cuotagastos)) Then
    '                MsgBox("debe ingresar cuota de gasto correcta  ")
    '            End If
    '        End If

    '    ElseIf banderacreditomoros = False Then
    '        If (CDbl(Textcuotadegastos.Text) = CDbl(cuotagastos)) Then
    '            frmMuestraEvaluacionCapital.MdiParent = frmRIESGO
    '            frmMuestraEvaluacionCapital.Visible = True

    '        ElseIf (CDbl(Textcuotadegastos.Text) <> CDbl(cuotagastos)) Then
    '            MsgBox("debe ingresar cuota de gasto correcta  ")

    '        End If

    '    End If





    '    'Textcuotadegastos.Text = PuntoX(cuotagastos)
    '    'If Texttiposolicitud2.Text = "F" Then
    '    'SOCIO  SIN CREDITOS MOROSOS  NO NECESITA INGRESAR MONTO A PAGAR 
    '    'If (CDbl(TextCapitalabonaCreditos.Text) = 0 And banderacreditomoros = False) And (CDbl(Textcuotadegastos.Text) = CDbl(cuotagastos)) Then

    '    '    frmMuestraEvaluacionCapital.MdiParent = frmRIESGO
    '    '    frmMuestraEvaluacionCapital.Visible = True
    '    'ElseIf (CDbl(TextCapitalabonaCreditos.Text) > 0 And banderacreditomoros = False) And (CDbl(Textcuotadegastos.Text) = CDbl(cuotagastos)) Then
    '    '    frmMuestraEvaluacionCapital.MdiParent = frmRIESGO
    '    '    frmMuestraEvaluacionCapital.Visible = True
    '    '    'SOCIO CON CREDITO MOROSO  Y SIN ABONAR MONTO  PARA PAGAR CREDITO 
    '    'ElseIf (CDbl(TextCapitalabonaCreditos.Text) = 0 And banderacreditomoros = True) And (CDbl(Textcuotadegastos.Text) <> CDbl(cuotagastos)) Then
    '    '    MsgBox("Socio tiene  credito con saldo pendiente debe ingresar  monto , tambien verifique la cuota de gastos ingresada  ")

    '    '    'SOCIO  CON MONTO INGRESADO MAYOR A CERO  Y CON SALDO DE CREDITO   
    '    'ElseIf (CDbl(TextCapitalabonaCreditos.Text) > 0 And banderacreditomoros = True) And (CDbl(Textcuotadegastos.Text) = CDbl(cuotagastos)) Then

    '    '    frmMuestraEvaluacionCapital.MdiParent = frmRIESGO
    '    '    frmMuestraEvaluacionCapital.Visible = True

    '    '    'ElseIf (CDbl(TextCapitalabonaCreditos.Text) = 0 And banderacreditomoros = False) And (CDbl(Textcuotadegastos.Text) = CDbl(cuotagastos)) Then
    '    '    'ElseIf (CDbl(TextCapitalabonaCreditos.Text) > 0 And banderacreditomoros = True) And (CDbl(Textcuotadegastos.Text) = CDbl(cuotagastos)) Then
    '    '    'ElseIf (Trim(TextCapitalabonaCreditos.Text) <> "0" And banderacreditomoros = False) And (CDbl(Textcuotadegastos.Text) < CDbl(cuotagastos)) Then
    '    '    ' MsgBox("La cuota de gastos es  menor al valor real adeudado ")
    '    '    'ElseIf (Trim(TextCapitalabonaCreditos.Text) <> "0" And banderacreditomoros = False) And (CDbl(Textcuotadegastos.Text) = CDbl(cuotagastos)) Then
    '    '    'ElseIf (Trim(TextCapitalabonaCreditos.Text) <> "0" And banderacreditomoros = True) And (CDbl(Textcuotadegastos.Text) = CDbl(cuotagastos)) Then
    '    '    'frmMuestraEvaluacionCapital.MdiParent = frmRIESGO
    '    '    'frmMuestraEvaluacionCapital.Visible = True
    '    'End If
    '    ' ElseIf (banderacreditomoros = True Or banderacreditomoros = False) And Texttiposolicitud2.Text = "R" Then
    '    ' MsgBox("SOCIO CON CREDITO EN MORA  ")
    '    '  End If





    'End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Textmontorequerido_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textmontorequerido.TextChanged

    End Sub

    Private Sub Textcuotadegastos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Textcuotadegastos.KeyUp
        Textcuotadegastos.Text = PuntoX(Textcuotadegastos.Text)
        Textcuotadegastos.Select(Textcuotadegastos.Text.Length, 0) 'If Not IsNumeric(Replace(Trim(Textcuotadegastos.Text), ".", "")) Then
        If (e.KeyCode = 13) Then
            If Trim(TextCapitalabonaCreditos.Text) <> "" And Trim(Textcuotadegastos.Text) <> "" And Trim(TextrevalorizacionUF.Text) <> "" And Trim(Textotrospagos.Text) <> "" Then
                TextDiminucioncapital.Text = CDbl(TextrevalorizacionUF.Text) - (CDbl(Textcuotadegastos.Text) + CDbl(TextCapitalabonaCreditos.Text) + CDbl(Textotrospagos.Text))
                TextDiminucioncapital.Text = PuntoX(TextDiminucioncapital.Text)
            Else
            End If
        End If
    End Sub

    Private Sub Textcuotadegastos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textcuotadegastos.TextChanged
        If Not IsNumeric(Replace(Trim(Textcuotadegastos.Text), ".", "")) Then
            MsgBox("Debe ingresar un valor numerico")
        Else
        End If

        If Trim(TextCapitalabonaCreditos.Text) <> "" And Trim(Textcuotadegastos.Text) <> "" And Trim(TextrevalorizacionUF.Text) <> "" And Trim(Textotrospagos.Text) <> "" Then
            TextDiminucioncapital.Text = CDbl(TextrevalorizacionUF.Text) - (CDbl(Textcuotadegastos.Text) + CDbl(TextCapitalabonaCreditos.Text) + CDbl(Textotrospagos.Text))
            TextDiminucioncapital.Text = PuntoX(TextDiminucioncapital.Text)
        Else
        End If
    End Sub

    Private Sub TextCapitalabonaCreditos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextCapitalabonaCreditos.KeyUp
        TextCapitalabonaCreditos.Text = PuntoX(TextCapitalabonaCreditos.Text)
        TextCapitalabonaCreditos.Select(TextCapitalabonaCreditos.Text.Length, 0)
        If (e.KeyCode = 13) Then
            If Trim(TextCapitalabonaCreditos.Text) <> "" And Trim(Textcuotadegastos.Text) <> "" And Trim(TextrevalorizacionUF.Text) <> "" And Trim(Textotrospagos.Text) <> "" Then
                TextDiminucioncapital.Text = CDbl(TextrevalorizacionUF.Text) - (CDbl(Textcuotadegastos.Text) + CDbl(TextCapitalabonaCreditos.Text) + CDbl(Textotrospagos.Text))
                TextDiminucioncapital.Text = PuntoX(TextDiminucioncapital.Text)
            Else
            End If
        End If
    End Sub

    Private Sub TextCapitalabonaCreditos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextCapitalabonaCreditos.TextChanged
        If Not IsNumeric(Replace(Trim(TextCapitalabonaCreditos.Text), ".", "")) Then
            MsgBox("Debe ingresar un valor numerico")
        Else

        End If
        If Trim(TextCapitalabonaCreditos.Text) <> "" And Trim(Textcuotadegastos.Text) <> "" And Trim(TextrevalorizacionUF.Text) <> "" And Trim(Textotrospagos.Text) <> "" Then

            TextDiminucioncapital.Text = CDbl(TextrevalorizacionUF.Text) - (CDbl(Textcuotadegastos.Text) + CDbl(TextCapitalabonaCreditos.Text) + CDbl(Textotrospagos.Text))
            TextDiminucioncapital.Text = PuntoX(TextDiminucioncapital.Text)
        Else
        End If
    End Sub

  Private Sub Checkrenuncia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Checkrenuncia.CheckedChanged
        If Checkrenuncia.CheckState = 0 Then
            Checfallecimiento.Enabled = True
        ElseIf Checkrenuncia.CheckState = 1 Then
            Checfallecimiento.Enabled = False
        End If
    End Sub

    Private Sub Checfallecimiento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Checfallecimiento.CheckedChanged
        If Checfallecimiento.CheckState = 0 Then
            Checkrenuncia.Enabled = True
        ElseIf Checfallecimiento.CheckState = 1 Then
            Checkrenuncia.Enabled = False
        End If
    End Sub
    Private Sub TextDiminucioncapital_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextDiminucioncapital.KeyUp
        TextDiminucioncapital.Text = PuntoX(TextDiminucioncapital.Text)
        TextDiminucioncapital.Select(TextDiminucioncapital.Text.Length, 0)
    End Sub

    Private Sub TextDiminucioncapital_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextDiminucioncapital.TextChanged

        If CDbl(TextDiminucioncapital.Text) <= 0 And Trim(Texttiposolicitud2.Text) = "F" Then
            Label38.Visible = True
            cboformapago.Items.Clear()
            cboformapago.Text = "SIN-LIQUIDO"
            cboformapago.Items.Add("SIN-LIQUIDO")
            'cboformapago.Items.Add("SIN-LIQUIDO")

            cboformapago.SelectedItem = "SIN-LIQUIDO"

        ElseIf CDbl(TextDiminucioncapital.Text) > 0 And Trim(Texttiposolicitud2.Text) = "F" Then
            Label38.Visible = False
            cboformapago.Items.Clear()
            cboformapago.Text = "EX-SOCIOS"
            cboformapago.Items.Add("EX-SOCIOS")
            'cboformapago.SelectedItem = "EX-SOCIOS"
        End If
    End Sub

    Private Sub Textotrospagos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Textotrospagos.KeyUp
        Textotrospagos.Text = PuntoX(Textotrospagos.Text)
        Textotrospagos.Select(Textotrospagos.Text.Length, 0)
        If (e.KeyCode = 13) Then
            If Trim(TextCapitalabonaCreditos.Text) <> "" And Trim(Textcuotadegastos.Text) <> "" And Trim(TextrevalorizacionUF.Text) <> "" And Trim(Textotrospagos.Text) <> "" Then

                TextDiminucioncapital.Text = CDbl(TextrevalorizacionUF.Text) - (CDbl(Textcuotadegastos.Text) + CDbl(TextCapitalabonaCreditos.Text) + CDbl(Textotrospagos.Text))
                TextDiminucioncapital.Text = PuntoX(TextDiminucioncapital.Text)
            Else
            End If
        End If
    End Sub

    Private Sub Textotrospagos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textotrospagos.TextChanged
        If Trim(TextCapitalabonaCreditos.Text) <> "" And Trim(Textcuotadegastos.Text) <> "" And Trim(TextrevalorizacionUF.Text) <> "" And Trim(Textotrospagos.Text) <> "" Then
            TextDiminucioncapital.Text = CDbl(TextrevalorizacionUF.Text) - (CDbl(Textcuotadegastos.Text) + CDbl(TextCapitalabonaCreditos.Text) + CDbl(Textotrospagos.Text))
            TextDiminucioncapital.Text = PuntoX(TextDiminucioncapital.Text)
        Else
        End If
    End Sub
End Class