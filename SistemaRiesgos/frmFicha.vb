Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.FtpWebRequest
Imports System.Net

Public Class frmFicha

    'Public Cadena As String = "Data Source=192.168.0.173; Initial Catalog=DocBD; User ID=sa;Password=universo"
    'Public Cadena As String = "Data Source=192.168.0.173; Initial Catalog=DocBD; User ID=sa;Password=universo"

    'Public conexion As SqlConnection = New SqlConnection(Cadena)
    Public cmd As SqlCommand
    Public da As SqlDataAdapter
    Public dtb As DataTable
    Public ar As String = ""
    Dim eva As frmEvaluar = New frmEvaluar()

    Private Sub DIGITAL()
        'txtDicom.Text = "NO"
        'txtAdjuntos.Text = "NO"
        'If File.Exists("Z:\_____DICOM HISTORICO_____\" + System.DateTime.Today.ToString("yyyy-MM-dd") + "-" + Trim(txtRut.Text.ToString) + ".pdf") Then
        '    txtDicom.Text = "SI"
        'End If
        'If File.Exists("Z:\_____DOCUMENTOS HISTORICO_____\" + System.DateTime.Today.ToString("yyyy-MM-dd") + "-" + Trim(txtRut.Text.ToString) + ".pdf") Then
        '    txtAdjuntos.Text = "SI"
        'End If


        txtRut.Text = frmEvaluar.txtRut.Text
        'txtFecha.Text = System.DateTime.Today.ToString("yyyy-MM-dd")

        'System.DateTime.Today.ToString("yyyy-MM-dd")
        ''txtDicom.Text = "NO"


        Dim conexiones4 As New CConexion
        conexiones4.conexion()
        Dim command4 As SqlCommand = New SqlCommand(" IF EXISTS (SELECT TOP 1 [docId] FROM [DocBD].[dbo].[documentos] where tipo='DICOM' and rut='" + txtRut.Text + "' and fecha=CONVERT(char(10), GetDate(),126)  order by docId) BEGIN SELECT 'SI' END ELSE SELECT 'NO'", conexiones4._conexion)
        conexiones4.abrir()
        Dim reader4 As SqlDataReader = command4.ExecuteReader()

        If reader4.HasRows Then
            Do While reader4.Read()


                txtDicom.Text = (reader4(0).ToString)
                'Datos._Sede = (reader4(1).ToString)
            Loop
        Else
        End If

        reader4.Close()



        Dim conexiones5 As New CConexion
        conexiones5.conexion()
        Dim command5 As SqlCommand = New SqlCommand(" IF EXISTS (SELECT TOP 1 [docId] FROM [DocBD].[dbo].[documentos] where tipo='ADJUNTOS' and rut='" + txtRut.Text + "' and fecha=CONVERT(char(10), GetDate(),126) order by docId) BEGIN SELECT 'SI' END ELSE SELECT 'NO'", conexiones5._conexion)
        conexiones5.abrir()
        Dim reader5 As SqlDataReader = command5.ExecuteReader()

        If reader5.HasRows Then
            Do While reader5.Read()


                txtAdjuntos.Text = (reader5(0).ToString)
                'Datos._Sede = (reader5(1).ToString)
            Loop
        Else
        End If

        reader5.Close()
    End Sub

    Private Sub frmFicha_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        frmEvaluar.Enabled = True
    End Sub
    Private Sub frmFicha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'DIGITAL()
        'txtRut.Text = "11437358-3"
        'LTEXTO.Text = ""
        'If frmEvaluar.txtTasaSolicitada.Text <> 0 Then
        ''    txtSolicitudTasa.ReadOnly = False
        'Try
        txtSolicitudTasa.Text = frmEvaluar.TXTeXCEPCION2.Text.Trim
        'Catch ex As Exception

        'End Try
        '"Favor indicar la causal de la tasa solicitada de " + frmEvaluar.cboTasaSolicitada.SelectedItem.ToString.Trim

        'Else
        'txtSolicitudTasa.ReadOnly = True
        'txtSolicitudTasa.Text = "No solicita tasa"

        'End If


        'TXTCOMENTARIO.Text = "Comentario ejecutiva"

        If (Trim(frmEvaluar.Cbotipo.SelectedItem) = "SOCIO") Then

        ElseIf (Trim(frmEvaluar.Cbotipo.SelectedItem) = "PRE-SOCIO") Then
            Timer1.Enabled = True
            Timer1.Interval = 250

        End If

        'txtProducto.Text = frmEvaluar.txtProducto.Text.ToString.Trim
        cboEjecutivoVenta.Text = frmEvaluar.CboEjecutivo.SelectedItem.ToString.Trim
        cboEjecutivo.Text = frmPerfil.CbmUsuario.SelectedItem.ToString.Trim
        cboSucursal.Text = frmRIESGO.ToolUbicacion.Text.ToString.Trim
        txtFueraDeZona.Text = frmEvaluar.cboFueradeZona.SelectedItem.ToString.Trim
        TxtNombre.Text = frmEvaluar.txtNombre.Text
        txtRut.Text = frmEvaluar.txtRut.Text
        txtNrosocio.Text = frmEvaluar.txtNrosocio.Text
        TxtEdad.Text = Math.Round((DateDiff("d", Date.Parse(frmEvaluar.DateFechaNacimiento.Value), Date.Now) / 365), 0, MidpointRounding.ToEven)
        txtAntiguedadSoc.Text = Math.Round((DateDiff("d", Date.Parse(frmEvaluar.DateFechaIngreso.Value), Date.Now) / 365), 0, MidpointRounding.ToEven)
        txtAntiguedadLab.Text = Math.Round((DateDiff("d", Date.Parse(frmEvaluar.DateFechaContrato.Value), Date.Now) / 365), 0, MidpointRounding.ToEven)
        txtEstadoCivil.Text = frmEvaluar.txtEstadoCivil.Text
        txtTipoVivienda.Text = frmEvaluar.txtTipoVivienda.Text

        CboFormaDePago.Text = frmEvaluar.CboFormaDePago.SelectedItem
        txtFormadePago2.Text = frmEvaluar.CboFormaDePago2.SelectedItem
        CboRenta.Text = frmEvaluar.CboRenta.SelectedItem
        CboProducto.Text = frmEvaluar.txtProducto2.Text.ToString.Trim
        txtInstitucion.Text = frmEvaluar.txtInstitucion.Text
        CboObjetivo.Text = frmEvaluar.CboObjetivo.SelectedItem


        TxtMonto.Text = frmEvaluar.TxtMonto.Text
        txtCapital.Text = frmEvaluar.txtCapital.Text
        TxtCuota.Text = frmEvaluar.TxtCuota.Text
        CboCuotas.Text = frmEvaluar.CboCuotas.SelectedItem
        cboInteres2.Text = frmEvaluar.txtTasaFinal.Text
        CboDiasdeGracia2.Text = frmEvaluar.CboDiasdeGracia.Text
        TxtEstado.Text = frmEvaluar.BTNVALIDAR.Text
        txtReRef.Text = frmEvaluar.cboRefRen.SelectedItem.ToString.Trim
        txtPlataforma.Text = frmEvaluar.cboPlataforma.SelectedItem.ToString.Trim

        DIGITAL()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Datos As New CDatos()
        Dim Plantillas As New CCEstadosGeneral

        'MsgBox(txtSolicitudTasa.Text.Substring(1, 10))


        If (TXTCOMENTARIO2.Text.Length > 550) Then
            MsgBox("El comentario sobrepasa los 550 caracteres")
        Else
            'If (txtSolicitudTasa.Text.Length > 200) Then

            '    MsgBox("El comentario tasa sobrepasa los 200 caracteres")
            'Else
            'If (txtSolicitudTasa.Text = "") Then
            '    MsgBox("Se debe agregar un comentario tasa antes de enviar")
            'Else
            'If (txtSolicitudTasa.Text.Substring(0, 10) = "Favor indicar la causal") Then
            '    MsgBox("Se debe agregar un comentario tasa antes de enviar")
            'else
            If (TXTCOMENTARIO2.Text = "") Then
                MsgBox("Se debe agregar un comentario antes de enviar")
            Else
                DIGITAL()
                'If (Trim(txtDicom.Text) = "SI" Or Trim(txtAdjuntos.Text) = "SI") Then
                If (Trim(txtDicom.Text) <> "SI" Or Trim(txtAdjuntos.Text) <> "SI") And My.Settings.usuario <> "CCAMPOS" Then
                    MsgBox("Se debe digitalizar Documentos Dicom y Adjuntos")
                Else

                    If (frmEvaluar.Cbotipo.SelectedItem = "PRE-SOCIO") Then
                        Datos._Presocios = Trim(frmEvaluar.txtNrosocio.Text)
                    End If
                    Datos._Nrosocio = Trim(frmEvaluar.txtNrosocio.Text)
                    Datos._fecha_solicitud = Trim(DTiemeFechaSolicitud.Value.ToString)
                    Datos._producto = frmEvaluar.txtProducto2.Text
                    Datos._objetivo = Trim(frmEvaluar.CboObjetivo.SelectedItem)
                    Datos._monto_solicitado = Trim(TxtMonto.Text)
                    Datos._capital = Trim(txtCapital.Text)
                    Datos._prepago = Trim(frmEvaluar.txtPrepago.Text)
                    Datos._nrocuotas = Trim(CboCuotas.Text)
                    Datos._primera_cuota = Trim(TxtCuota.Text)
                    Datos._dias_gracia = Trim(CboDiasdeGracia2.Text)
                    Datos._ncreditos = Trim(frmEvaluar.txtNcreditos.Text)
                    Datos._FueraDeZona = Trim(txtFueraDeZona.Text)
                    Datos._fechaprimervencimiento = Trim(frmEvaluar.DFechaPrimerVencimiento.Value.ToString)
                    Datos._forpago = Trim(frmEvaluar.CboFormaDePago.SelectedItem)
                    Datos._tiporenta = Trim(frmEvaluar.CboRenta.SelectedItem)
                    Datos._protestosmorocidades = Trim(frmEvaluar.CboProtestosyMorocidades.SelectedItem)
                    Datos._comportamientopago = Trim(frmEvaluar.cboCompartamiento.SelectedItem)
                    Datos._Plataforma = Trim(frmEvaluar.cboPlataforma.SelectedItem)
                    Datos._Edeudafinanciera = Trim(frmEvaluar.TxtDeudaFinanciera.Text)
                    Datos._EdeudaHipo = Trim(frmEvaluar.txtDeudaHipotecaria.Text)
                    Datos._EdeudaConsumo = Trim(frmEvaluar.txtDeudaConsumo.Text)
                    Datos._EdeudaComercial = Trim(frmEvaluar.txtDeudaComercial.Text)
                    Datos._EDeudadVencidas = Trim(frmEvaluar.txtDeudaVencida.Text)
                    Datos._EDeudasVencidasIndirectas = Trim(frmEvaluar.txtDeudaVencidaIndirecta.Text)
                    Datos._EPerido = Trim(frmEvaluar.cboPeriodo.SelectedItem.ToString.Trim)
                    Datos._ELineaCredito = Trim(frmEvaluar.txtLineaCredito.Text)
                    Datos._ENumeroAcreedores = Trim(frmEvaluar.txtNumeroAcreedoresFinan.Text)
                    Datos._Cuotas_prepago = Trim(frmPrepago.txtCuotasPrestamos.Text)
                    Datos._Itotaldeuda = Trim(frmEvaluar.txtInternaTotalDeuda.Text)
                    Datos._IdeudaConsumo = Trim(frmEvaluar.txtInternaDeudaConsumo.Text)
                    Datos._IdeudaComercial = Trim(frmEvaluar.txtInternaDeudaComercial.Text)
                    Datos._IDeudaIndirecta = Trim(frmEvaluar.txtInternaDeudaIndirecta.Text)
                    Datos._IPagoMensual = Trim(frmEvaluar.txtInternaPagoMensual.Text)
                    Datos._RLP = Trim(frmEvaluar.TXTRENTALIQUIDA.Text)
                    Datos._CargaFinanciera = Trim(frmEvaluar.txtCargaFinanciera.Text)
                    Datos._ExternaAcreditado = Trim(frmEvaluar.txtExternaAcreditado.Text)
                    Datos._Activos = Trim(frmEvaluar.txtActivos.Text)
                    Datos._Propiedades = Trim(frmEvaluar.txtPropiedades.Text)
                    Datos._Vehiculos = Trim(frmEvaluar.txtVehiculos.Text)
                    Datos._RentaLiquidaDepurada = Trim(frmEvaluar.txtRentaLiquidaDepurada.Text)
                    Datos._LVL = Trim(frmEvaluar.LlEVEL.Text)
                    Datos._capacidad = Trim(frmEvaluar.LPorciento.Text)
                    Datos._Validaciones = Trim(frmEvaluar.txtvalidaciones2.Text)
                    Datos._Ejecutiva = Trim(frmPerfil.CbmUsuario.SelectedItem)
                    Datos._Formadepago2 = txtFormadePago2.Text
                    Datos._Region = Trim(frmEvaluar.txtRegion.Text)
                    Datos._Institucion = Trim(frmEvaluar.txtInstitucion.Text)
                    Datos._Tasa_solicitada = frmEvaluar.cboTasaSolicitada.SelectedItem.ToString.Trim
                    Datos._comentario_tasa = Trim(txtSolicitudTasa.Text.Trim)
                    Datos._tasa_castigada = Trim(frmEvaluar.txtTasaCastigada.Text.Trim)
                    Datos._tasa_real = Trim(frmEvaluar.txtTasaReal.Text)
                    Datos._tasa = Trim(frmEvaluar.txtTasaFinal.Text)
                    Datos._descuento_campaña = Trim(frmEvaluar.txtDescuento.Text.Trim)
                    Datos._ATENCION = frmEvaluar.cboAtencion.SelectedItem.ToString.Trim
                    Datos._ESTADO_INI = frmEvaluar.txtestado2.Text
                    Datos._COD_INST = frmEvaluar.txtCOD_INST.Text
                    Datos._COD_FORMAPAGO = frmEvaluar.txtCOD_FORMAPAGO.Text
                    Datos._Disponible = Replace(frmEvaluar.TxtDisponible2.Text, ".", "")
                    Datos._CuotaUltima = frmEvaluar.txtUltimaCuota.Text

                    'FORMA DE PAGO
                    Datos._COD_FORMAPAGO = frmEvaluar.txtCOD_FORMAPAGO.Text



                    If frmEvaluar.txtrutaval1.Text = "Ejemplo: 15883797-8" Then
                        Datos._Aval1 = ""
                    Else
                        Datos._Aval1 = Trim(frmEvaluar.txtrutaval1.Text)
                    End If

                    If frmEvaluar.txtRutAval2.Text = "Ejemplo: 15883797-8" Then
                        Datos._Aval2 = ""
                    Else
                        Datos._Aval2 = Trim(frmEvaluar.txtRutAval2.Text)
                    End If



                    Dim conexiones4 As New CConexion
                    conexiones4.conexion()
                    Dim command4 As SqlCommand = New SqlCommand("  SELECT RTRIM([CIUDAD]) AS CIUDAD,RTRIM([NOMBRECAJA]) AS SEDE , CODCAJA FROM  [_SUCURSAL] WHERE VIGENTE=1 and RTRIM([CIUDAD])+' - '+RTRIM([NOMBRECAJA])='" + frmRIESGO.ToolUbicacion.Text.ToString.Trim + "'", conexiones4._conexion)
                    conexiones4.abrir()
                    Dim reader4 As SqlDataReader = command4.ExecuteReader()

                    If reader4.HasRows Then
                        Do While reader4.Read()
                            Datos._Sucursal = (reader4(0).ToString)
                            Datos._Sede = (reader4(1).ToString)
                            Datos._COD_SUCURSAL = (reader4(2).ToString)
                        Loop
                    Else
                    End If

                    reader4.Close()



                    'Datos._Sucursal = frmRIESGO.ToolUbicacion.Text.ToString.Trim




                    Datos._Comentario_Ejecutiva = Trim(TXTCOMENTARIO2.Text)
                    Datos._Puntajes_Validaciones = Trim(frmEvaluar.richTextBox2.Text)

                    Datos._Nombre = Trim(frmEvaluar.txtNombre.Text)
                    Datos._Rut = Trim(frmEvaluar.txtRut.Text)

                    Datos._Comentario_Riesgo = "Sin comentario"


                    Datos._Puntaje = Trim(frmEvaluar.txtpuntaje4.Text)

                    Datos._Edad = frmEvaluar.txtScoringEdad.Text
                    Datos._Anos_Antiguedad = frmEvaluar.txtScoringAntiguedad.Text
                    Datos._Anos_Contrato = txtAntiguedadLab.Text
                    Datos._Monto_Capital = frmEvaluar.txtMontoCapital.Text
                    Datos._Comportamiento_Capital = frmEvaluar.txtComportamientoCapital.Text.Trim
                    Datos._Comportamiento_Clasificacion = frmEvaluar.TxtComportamientoClasificacion.Text.Trim
                    Datos._Comportamiento_Clasificacion_Baja = frmEvaluar.txtClasificacionBaja.Text.Trim
                    'MsgBox(frmEvaluar.txtAumentaTasa2.Text.ToString.Trim)

                    If (frmEvaluar.txtTasaFinal.Text.ToString.Trim = frmEvaluar.txtTasaCastigada.Text.ToString.Trim) Then
                        Datos._Tasa_Aumento = frmEvaluar.txtAumentaTasa2.Text.ToString.Trim

                    Else
                        Datos._Tasa_Aumento = "0"
                    End If


                    Datos._PYM6 = frmEvaluar.txtPYM6.Text
                    Datos._PYM6A12 = frmEvaluar.txtPYM612.Text
                    Datos._PYM12A24 = frmEvaluar.txtPYM1224.Text
                    Datos._PYM24 = frmEvaluar.txtPYM24.Text
                    Datos._ID_RENTA = frmEvaluar.txtIdRentaSocios.Text

                    Datos._MaximoMontoPlanilla = Replace(frmEvaluar.txtMaxMontoPlanilla.Text, ".", "")
                    Datos._MaximaCuotaPlanilla = Replace(frmEvaluar.txtMaxCuotaPlanilla.Text, ".", "")


                    'MsgBox(Datos._Tasa_Aumento)

                    Dim Monto_atribucion As Integer = Int(Replace(TxtMonto.Text, ".", ""))

                    If (Monto_atribucion <= 500000) Then
                        Datos._Atribucion = "1"
                        Datos._Aprobacion_Operaciones = "Por Analizar"
                        Datos._Aprobacion_SubGerencia = "No Verifica"
                        Datos._Aprobacion_Gerencia = "No Verifica"
                        Datos._Aprobacion_Comision_Credito_Interno = "No Verifica"
                        Datos._Aprobacion_Comision_Credito_Superior = "No Verifica"
                    ElseIf (Monto_atribucion > 500000 And Monto_atribucion <= 3000000) Then
                        Datos._Atribucion = "2"
                        Datos._Aprobacion_Operaciones = "No Verifica"
                        Datos._Aprobacion_SubGerencia = "Por Analizar"
                        Datos._Aprobacion_Gerencia = "No Verifica"
                        Datos._Aprobacion_Comision_Credito_Interno = "No Verifica"
                        Datos._Aprobacion_Comision_Credito_Superior = "No Verifica"
                    ElseIf (Monto_atribucion > 3000000 And Monto_atribucion <= 10000000) Then
                        Datos._Atribucion = "3"
                        Datos._Aprobacion_Operaciones = "No Verifica"
                        Datos._Aprobacion_SubGerencia = "Por Analizar"
                        Datos._Aprobacion_Gerencia = "Por Analizar"
                        Datos._Aprobacion_Comision_Credito_Interno = "No Verifica"
                        Datos._Aprobacion_Comision_Credito_Superior = "No Verifica"
                        'ElseIf (Monto_atribucion > 3000000 And Monto_atribucion <= 40000000 And txtInstitucion.Text = "ANFACH") Then
                        '    Datos._Atribucion = "3"
                        '    Datos._Aprobacion_Operaciones = "No Verifica"
                        '    Datos._Aprobacion_SubGerencia = "Por Analizar"
                        '    Datos._Aprobacion_Gerencia = "Por Analizar"
                        '    Datos._Aprobacion_Comision_Credito_Interno = "No Verifica"
                        '    Datos._Aprobacion_Comision_Credito_Superior = "No Verifica"
                    ElseIf (Monto_atribucion > 10000001 And Monto_atribucion <= 50000000) Then
                        Datos._Atribucion = "4"
                        Datos._Aprobacion_Operaciones = "No Verifica"
                        Datos._Aprobacion_SubGerencia = "Por Analizar"
                        Datos._Aprobacion_Gerencia = "Por Analizar"
                        Datos._Aprobacion_Comision_Credito_Interno = "Por Analizar"
                        Datos._Aprobacion_Comision_Credito_Superior = "No Verifica"
                    Else
                        Datos._Atribucion = "5"
                        Datos._Aprobacion_Operaciones = "No Verifica"
                        Datos._Aprobacion_SubGerencia = "Por Analizar"
                        Datos._Aprobacion_Gerencia = "Por Analizar"
                        Datos._Aprobacion_Comision_Credito_Interno = "Por Analizar"
                        Datos._Aprobacion_Comision_Credito_Superior = "Por Analizar"
                    End If


                    If (Trim(frmEvaluar.TXTPROCESO.Text) = "*SE ENVIARA A AGENTE Y DEP. RIESGO PARA SU VALIDACIÓN") Then
                        Datos._Estado = "Enviado a Agente para su Liberación"
                        Datos._PreAprobacion_Riesgo = "Por Analizar"
                    ElseIf (Trim(frmEvaluar.TXTPROCESO.Text) = "*SE ENVIARA A AGENTE PARA SU VALIDACIÓN") Then
                        'Datos._Estado = "Enviado de Ejecutivos para aprobación"
                        Datos._Estado = "Enviado a Agente para su Liberación"
                        Datos._PreAprobacion_Riesgo = "Por Analizar"
                    End If



                    Datos._Aprobacion_Pre_Agencia = "Por Analizar"
                    'Datos._Ejecutivo_Convenio = Trim(cboEjecutivoVenta.Text)
                    Datos._PreAprobacion_Riesgo = "Por Analizar"

                    Datos._CODDACA = frmEvaluar.txtCodDaca.Text


                    If (frmEvaluar.CheckValidaciones.GetItemChecked(0) = True) Then
                        Datos._V_Puntaje = 1
                    End If
                    If (frmEvaluar.CheckValidaciones.GetItemChecked(1) = True) Then
                        Datos._V_Capacidad = 1
                    End If
                    If (frmEvaluar.CheckValidaciones.GetItemChecked(2) = True) Then
                        Datos._V_Endeudamiento = 1
                    End If
                    If (frmEvaluar.CheckValidaciones.GetItemChecked(3) = True) Then
                        Datos._V_Comerciales = 1
                    End If
                    If (frmEvaluar.CheckValidaciones.GetItemChecked(4) = True) Then
                        Datos._V_Antiguedad10 = 1
                    End If
                    If (frmEvaluar.CheckValidaciones.GetItemChecked(5) = True) Then
                        Datos._V_Antiguedad1 = 1
                    End If
                    If (frmEvaluar.CheckValidaciones.GetItemChecked(6) = True) Then
                        Datos._V_Moras = 1
                    End If
                    If (frmEvaluar.CheckValidaciones.GetItemChecked(7) = True) Then
                        Datos._V_Edad = 1
                    End If


                    Dim i As Long
                    ' recorremos todos los elementos
                    For i = 0 To frmPrepago.LboxAgregados.Items.Count - 1
                        ' construímos una cadena con cada uno de los valores
                        Datos._NroPrepagos = Datos._NroPrepagos + frmPrepago.LboxAgregados.Items(i)
                    Next
                    ' mostramos el resultado

                    Datos._Ejecutivo_Convenio = cboEjecutivoVenta.Text


                    If (frmEvaluar.ChkmodificaDeudaExterna.Checked = True) Then
                        Datos._modificaciondeudaexterna = "SI"
                    Else
                        Datos._modificaciondeudaexterna = "NO"
                    End If

                    If (frmEvaluar.ChkFechaInicio.Checked = True) Then
                        Datos._MES_PRIMERA = frmEvaluar.DFechaInicio.Value.Date.ToString("MM")
                        Datos._ANO_PRIMERA = frmEvaluar.DFechaInicio.Value.Date.ToString("yyyy")
                    End If




                    Datos._ReRef = txtReRef.Text.ToString
                    If Plantillas.Agregar_prestamo(Datos) Then
                        'subirDocumentoWeb()
                        MsgBox("Credito Enviado Con exito")




                        If (Trim(frmEvaluar.Cbotipo.SelectedItem) = "PRE-SOCIO") Then

                            Datos._Presocios = Trim(frmEvaluar.txtNrosocio.Text)
                            If Plantillas.Actualizar_Codigo_Presocio(Datos) Then

                            Else
                                MessageBox.Show("Error al consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If


                        End If


                        Me.Close()
                        frmEvaluar.Close()
                        frmPrepago.Close()

                    Else
                        MessageBox.Show("Error al consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        End If
        'End If
        'End If
        'End If
    End Sub


    Sub subirDocumentoWeb()
        Try
            Dim id As String = ""

            Dim conexiones4 As New CConexion
            conexiones4.conexion()
            Dim command4 As SqlCommand = New SqlCommand("SELECT max([id_solicitud]) FROM _RIESGO_PRESTAMOS_SOLICITADOS", conexiones4._conexion)
            conexiones4.abrir()
            Dim reader4 As SqlDataReader = command4.ExecuteReader()

            If reader4.HasRows Then
                Do While reader4.Read()
                    id = (reader4(0).ToString)
                Loop
            Else
            End If

            reader4.Close()



            'Dim open As New OpenFileDialog()
            'open.Title = "Abrir"
            'open.Filter = "Archivos Docx(*.pdf)|*.pdf|Archivos Docx(*.docx)|*.docx|Archivos doc(*.doc)|*.doc|Todos los Archivos(*.*)|*.*"
            'If open.ShowDialog() = DialogResult.OK Then
            '    ar = open.FileName
            '    txtRuta.Text = ar
            '    txtTitulo.Text = open.SafeFileName
            'End If

            'SUBE A LA WEB DICOM
            subirFichero(txtRuta.Text.ToString.Trim, "ftp://lautarorosas.cl/dicom/" + id.ToString + ".pdf", "ftp://lautarorosas.cl/dicom")
            'SUBE A LA WEB ADJUNTOS
            subirFichero(txtRuta2.Text.ToString.Trim, "ftp://lautarorosas.cl/adjuntos/" + id.ToString + ".pdf", "ftp://lautarorosas.cl/adjuntos")

        Catch ex As Exception

        End Try

    End Sub
    Public Function subirFichero(ByVal fichero As String, ByVal destino As String,
ByVal dir As String) As String
        Dim infoFichero As New FileInfo(fichero)

        Dim uri As String
        uri = destino

        ' Si no existe el directorio, lo creamos
        If Not existeObjeto(dir) Then
            creaDirectorio(dir)
        End If

        Dim peticionFTP As FtpWebRequest

        ' Creamos una peticion FTP con la dirección del fichero que vamos a subir
        peticionFTP = CType(FtpWebRequest.Create(New Uri(destino)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential("cristian@lautarorosas.cl", "universo2018")

        peticionFTP.KeepAlive = False
        peticionFTP.UsePassive = False

        ' Seleccionamos el comando que vamos a utilizar: Subir un fichero
        peticionFTP.Method = WebRequestMethods.Ftp.UploadFile

        ' Especificamos el tipo de transferencia de datos
        peticionFTP.UseBinary = True

        ' Informamos al servidor sobre el tamaño del fichero que vamos a subir
        peticionFTP.ContentLength = infoFichero.Length

        ' Fijamos un buffer de 2KB
        Dim longitudBuffer As Integer
        longitudBuffer = 2048
        Dim lector As Byte() = New Byte(2048) {}

        Dim num As Integer

        ' Abrimos el fichero para subirlo
        Dim fs As FileStream
        fs = infoFichero.OpenRead()

        Try
            Dim escritor As Stream
            escritor = peticionFTP.GetRequestStream()

            ' Leemos 2 KB del fichero en cada iteración
            num = fs.Read(lector, 0, longitudBuffer)

            While (num <> 0)
                ' Escribimos el contenido del flujo de lectura en el 
                ' flujo de escritura del comando FTP
                escritor.Write(lector, 0, num)
                num = fs.Read(lector, 0, longitudBuffer)
            End While

            escritor.Close()
            fs.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            Return ex.Message
        End Try
    End Function
    Public Function existeObjeto(ByVal dir As String) As Boolean
        Dim peticionFTP As FtpWebRequest

        ' Creamos una peticion FTP con la dirección del objeto que queremos saber si existe
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential("cristian@lautarorosas.cl", "universo2018")

        ' Para saber si el objeto existe, solicitamos la fecha de creación del mismo
        peticionFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp

        peticionFTP.UsePassive = False

        Try
            ' Si el objeto existe, se devolverá True
            Dim respuestaFTP As FtpWebResponse
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
            Return True

        Catch ex As Exception
            ' Si el objeto no existe, se producirá un error y al entrar por el Catch
            ' se devolverá falso

            Return False
        End Try
    End Function
    Public Function creaDirectorio(ByVal dir As String) As String
        Dim peticionFTP As FtpWebRequest

        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential("cristian@lautarorosas.cl", "universo2018")

        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory

        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            Return ex.Message
        End Try
    End Function
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmEvaluar.Enabled = True
        Me.Close()
    End Sub

    Private Sub TXTCOMENTARIO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTCOMENTARIO2.KeyUp, TXTCOMENTARIO2.KeyUp
        txtcaracteres.Text = 450 - (TXTCOMENTARIO2.Text.Length)
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static c As String
        c = c + 1
        If (c = 1) Then
            lpresocio.Visible = True
        ElseIf (c = 2) Then
            lpresocio.Visible = False
        ElseIf (c = 3) Then
            lpresocio.Visible = True
        ElseIf (c = 4) Then
            c = 0
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        DIGITAL()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim speller As Object
        Dim txt As String
        Dim new_txt As String
        Dim pos As Integer

        speller = CreateObject("Word.Basic")

        speller.FileNew()
        speller.Insert(TXTCOMENTARIO2.Text)
        speller.ToolsSpelling()
        speller.EditSelectAll()
        txt = speller.Selection()
        speller.FileExit(2)

        If RSet(txt, 1) = vbCr Then _
            txt = LSet(txt, Len(txt) - 1)
        new_txt = ""
        pos = InStr(txt, vbCr)
        Do While pos > 0
            new_txt = new_txt & LSet(txt, pos - 1) & vbCrLf
            txt = RSet(txt, Len(txt) - pos)
            pos = InStr(txt, vbCr)
        Loop
        new_txt = new_txt & txt

        TXTCOMENTARIO2.Text = new_txt
    End Sub

    'Private Sub txtSolicitudTasa_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSolicitudTasa.KeyUp
    '    txtcaracteres2.Text = 200 - (txtSolicitudTasa.Text.Length)
    'End Sub

    'Private Sub txtSolicitudTasa_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSolicitudTasa.MouseClick
    '    txtSolicitudTasa.Text = ""
    'End Sub





    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim open As New OpenFileDialog()
        open.Title = "Abrir"
        open.Filter = "Archivos Docx(*.pdf)|*.pdf|Archivos Docx(*.docx)|*.docx|Archivos doc(*.doc)|*.doc|Todos los Archivos(*.*)|*.*"
        If open.ShowDialog() = DialogResult.OK Then
            ar = open.FileName
            txtRuta.Text = ar
            txtTitulo.Text = open.SafeFileName
        End If
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim open As New OpenFileDialog()
        open.Title = "Abrir"
        open.Filter = "Archivos Docx(*.pdf)|*.pdf|Archivos Docx(*.docx)|*.docx|Archivos doc(*.doc)|*.doc|Todos los Archivos(*.*)|*.*"
        If open.ShowDialog() = DialogResult.OK Then
            ar = open.FileName
            txtRuta2.Text = ar
            txtTitulo2.Text = open.SafeFileName
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'txtRuta.Text =
        '    DataGridView2.Rows(0).Cells(0).Value.ToString

        'txtTitulo.Text = DataGridView2.Rows(1).Cells(1).Value.ToString

        If txtRuta.Text <> "" AndAlso txtTitulo.Text <> "" Then
            Dim fs As New FileStream(ar, FileMode.Open)
            Dim data(0 To fs.Length - 1) As Byte
            fs.Read(data, 0, Convert.ToInt32(fs.Length))
            'If conexion.State = 0 Then
            '    conexion.Open()
            'End If

            Dim conexiones4 As New CConexion
            conexiones4.conexion2()
            conexiones4.abrir2()
            cmd = New SqlCommand("P_Doc2", conexiones4._conexion2)
            cmd.CommandType = CommandType.StoredProcedure

            'txtRut.Text = "15883797-8"

            'txtFecha.Text = System.DateTime.Today.ToString("yyyy-MM-dd")
            cmd.Parameters.Add("@doc", SqlDbType.VarBinary).Value = data
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = txtTitulo.Text
            cmd.Parameters.Add("@tipo", SqlDbType.VarChar, 100).Value = "DICOM"
            cmd.Parameters.Add("@rut", SqlDbType.VarChar, 100).Value = txtRut.Text.Trim
            cmd.Parameters.Add("@fecha", SqlDbType.VarChar, 100).Value = txtFecha.Text

            cmd.ExecuteNonQuery()
            MessageBox.Show("Guardado Correctamente")
            Me.frmFicha_Load(Nothing, Nothing)
            conexiones4.cerrar2()
            fs.Close()
            'Limpiar()
        Else
            MessageBox.Show("Adjuntar y escribir Ttulo", "Error Guardar", MessageBoxButtons.OK)

        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'txtRuta.Text =
        '    DataGridView2.Rows(0).Cells(0).Value.ToString

        'txtTitulo.Text = DataGridView2.Rows(1).Cells(1).Value.ToString

        If txtRuta2.Text <> "" AndAlso txtTitulo2.Text <> "" Then
            Dim fs As New FileStream(ar, FileMode.Open)
            Dim data(0 To fs.Length - 1) As Byte
            fs.Read(data, 0, Convert.ToInt32(fs.Length))
            'If conexion.State = 0 Then
            '    conexion.Open()
            'End If
            Dim conexiones4 As New CConexion
            conexiones4.conexion2()
            conexiones4.abrir2()
            cmd = New SqlCommand("P_Doc", conexiones4._conexion2)
            cmd.CommandType = CommandType.StoredProcedure

            'txtRut.Text = "15883797-8"

            'txtFecha.Text = System.DateTime.Today.ToString("yyyy-MM-dd")
            cmd.Parameters.Add("@doc", SqlDbType.VarBinary).Value = data
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = txtTitulo.Text
            cmd.Parameters.Add("@tipo", SqlDbType.VarChar, 100).Value = "ADJUNTOS"
            cmd.Parameters.Add("@rut", SqlDbType.VarChar, 100).Value = txtRut.Text.Trim
            cmd.Parameters.Add("@fecha", SqlDbType.VarChar, 100).Value = txtFecha.Text

            cmd.ExecuteNonQuery()
            MessageBox.Show("Guardado Correctamente")
            Me.frmFicha_Load(Nothing, Nothing)
            conexiones4.cerrar2()
            fs.Close()
            'Limpiar()
        Else
            MessageBox.Show("Adjuntar y escribir Ttulo", "Error Guardar", MessageBoxButtons.OK)

        End If
    End Sub

    Private Sub txtDicom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDicom.TextChanged
        If txtDicom.Text = "NO" Then
            txtDicom.BackColor = Color.Red
            txtDicom.ForeColor = Color.White
            btnVerDicom.Enabled = False

        Else
            txtDicom.BackColor = Color.Green
            txtDicom.ForeColor = Color.White
            btnVerDicom.Enabled = True
        End If
    End Sub

    Private Sub txtAdjuntos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdjuntos.TextChanged
        If txtAdjuntos.Text = "NO" Then
            txtAdjuntos.BackColor = Color.Red
            txtAdjuntos.ForeColor = Color.White
            btnVerAdjuntos.Enabled = False
        Else
            txtAdjuntos.BackColor = Color.Green
            txtAdjuntos.ForeColor = Color.White
            btnVerAdjuntos.Enabled = True
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerDicom.Click
        Try
            LTEXTO.Text = "VIENDO DICOM DIGITALIZADO"

            Dim conexiones4 As New CConexion
            conexiones4.conexion2()
            conexiones4.abrir2()
            cmd = New SqlCommand(" select top 1 doc  from [DocBD].[dbo].documentos where tipo='DICOM' and rut='" + txtRut.Text.Trim + "' and fecha=CONVERT(char(10), GetDate(),126)  and estado=1 order by docId desc", conexiones4._conexion2)
            da = New SqlDataAdapter(cmd)
            dtb = New DataTable()
            da.Fill(dtb)
            Dim f As DataRow = dtb.Rows(0)
            Dim Bits As Byte() = (CType((f.ItemArray(0)), Byte()))
            Dim sFile As String = "d" & GenerarNombreFichero() & ".pdf"
            Dim fs As New FileStream(sFile, FileMode.Create)
            fs.Write(Bits, 0, Convert.ToInt32(Bits.Length))
            fs.Close()
            Dim obj As System.Diagnostics.Process = New System.Diagnostics.Process()
            'AxAcroPDF1.src = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
            AxAcroPDF1.src = "C:\SISTEMAS\Riesgo\" + sFile
            'AxAcroPDF1.setCurrentPage(2)
            'AxAcroPDF1.setZoom(90)
            Dim ArchivoBorrar As String
            'ArchivoBorrar = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
            ArchivoBorrar = "C:\SISTEMAS\Riesgo\" + sFile
            If System.IO.File.Exists(ArchivoBorrar) = True Then
                System.IO.File.Delete(ArchivoBorrar)
            End If
        Catch ex As Exception
            LTEXTO.Text = "ERROR DE LECTURA"
        End Try
    End Sub


    Public Function GenerarNombreFichero()
        Dim ultimoTick As Integer = 0
        While ultimoTick = Environment.TickCount
            System.Threading.Thread.Sleep(1)
        End While
        ultimoTick = Environment.TickCount
        Return DateTime.Now.ToString("yyyyMMddhhmmss") + "." + ultimoTick.ToString()
    End Function

    Private Sub btnVerAdjuntos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerAdjuntos.Click
        Try
            LTEXTO.Text = "VIENDO ADJUNTOS DIGITALIZADOS"

            Dim conexiones4 As New CConexion
            conexiones4.conexion2()
            conexiones4.abrir2()
            cmd = New SqlCommand(" select top 1 doc  from [DocBD].[dbo].documentos where tipo='ADJUNTOS' and rut='" + txtRut.Text.Trim + "' and fecha=CONVERT(char(10), GetDate(),126)  and estado=1 order by docId desc", conexiones4._conexion2)
            da = New SqlDataAdapter(cmd)
            dtb = New DataTable()
            da.Fill(dtb)
            Dim f As DataRow = dtb.Rows(0)
            Dim Bits As Byte() = (CType((f.ItemArray(0)), Byte()))
            Dim sFile As String = "d" & GenerarNombreFichero() & ".pdf"
            Dim fs As New FileStream(sFile, FileMode.Create)
            fs.Write(Bits, 0, Convert.ToInt32(Bits.Length))
            fs.Close()
            Dim obj As System.Diagnostics.Process = New System.Diagnostics.Process()
            'AxAcroPDF1.src = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
            AxAcroPDF1.src = "C:\SISTEMAS\Riesgo\" + sFile
            'AxAcroPDF1.setCurrentPage(2)
            'AxAcroPDF1.setZoom(90)
            Dim ArchivoBorrar As String
            'ArchivoBorrar = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
            ArchivoBorrar = "C:\SISTEMAS\Riesgo\" + sFile
            If System.IO.File.Exists(ArchivoBorrar) = True Then
                System.IO.File.Delete(ArchivoBorrar)
            End If
        Catch ex As Exception
            LTEXTO.Text = "ERROR DE LECTURA"
        End Try
    End Sub

    Private Sub TXTCOMENTARIO2_TextChanged(sender As Object, e As EventArgs) Handles TXTCOMENTARIO2.TextChanged

    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click

        DIGITAL()

        If (Trim(txtDicom.Text) <> "SI" Or Trim(txtAdjuntos.Text) <> "SI") Then
            MsgBox("Se debe digitalizar Documentos Dicom y Adjuntos")
        Else
            subirDocumentoWeb()

        End If

    End Sub
End Class