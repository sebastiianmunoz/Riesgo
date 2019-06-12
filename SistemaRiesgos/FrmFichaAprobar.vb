Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmFichaAprobar
    Dim id As String = frmCreditosPorAprobar.txtid.Text
    Dim texto As String
    Dim CARGO As String
    Dim prestamo As String = ""
    Dim plantillas As Metodos = New Metodos
    Dim plantillas2 As Metodos = New Metodos
    Dim tabla As New DataTable
    Dim tabla2 As New DataTable
    Dim Datos As New CDatos
    Dim ATRIBUTO_PRESTAMO2 As String

    Public cmd As SqlCommand
    Public da As SqlDataAdapter
    Public dtb As DataTable
    Public ar As String = ""
    'Public VARIABLE As String = "NO"
    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGHistoricoPrestamos.CellClick
        If e.ColumnIndex = 0 Then
            'VARIABLE = "SI"

            If plantillas.EstaAbierto(frmFichaHistorico) Then
                frmFichaHistorico.Close()
            End If

            My.Settings.variableglobal = "HistoricoPrestamos"
            My.Settings.Save()
            My.Forms.frmFichaHistorico.MdiParent = My.Forms.frmRIESGO
            My.Forms.frmFichaHistorico.WindowState = FormWindowState.Normal
            My.Forms.frmFichaHistorico.Location = New Point(0, 0)
            My.Forms.frmFichaHistorico.Show()

            My.Forms.frmFichaHistorico.BringToFront()
        End If
    End Sub

    'Private Sub DIGITAL()
    '    txtDicom.Text = "NO"
    '    txtAdjuntos.Text = "NO"
    '    If File.Exists("Z:\_____DICOM HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut2.Text.ToString) + ".pdf") Then
    '        txtDicom.Text = "SI"
    '    End If
    '    If File.Exists("Z:\_____DOCUMENTOS HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut2.Text.ToString) + ".pdf") Then
    '        txtAdjuntos.Text = "SI"
    '    End If
    'End Sub
    Sub versolicitudes()

        Datos._Rut = txtrut3.Text.ToString.Trim
        plantillas2._tabla.Rows.Clear()
        plantillas2._tabla.Columns.Clear()
        If plantillas2.Consultar_prestamos_historicosXNrosocio2(Datos) Then
            tabla2 = plantillas2.tabla2
            DGHistoricoPrestamos.DataSource = tabla2

        End If

        DGHistoricoPrestamos.AllowUserToAddRows = False

        DGHistoricoPrestamos.Visible = True
        If DGHistoricoPrestamos.RowCount = 0 Then
            LblSOLICITUDES.Visible = True
        Else
            LblSOLICITUDES.Visible = False
        End If


    End Sub

    'Private Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As TabControlCancelEventArgs) Handles TabControl1.Selecting
    '    'If Me.TabControl1.SelectedIndex = 10 Then
    '    '    AxAcroPDF1.src = "Z:\_____DICOM HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut2.Text.ToString) + ".pdf"

    '    '    AxAcroPDF1.setZoom(90)

    '    'End If


    '    'If Me.TabControl1.SelectedIndex = 11 Then
    '    '    AxAcroPDF2.src = "Z:\_____DOCUMENTOS HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut2.Text.ToString) + ".pdf"
    '    '    AxAcroPDF2.setZoom(90)
    '    'End If



    'End Sub



    Sub agregar()

        Dim conexiones1 As New CConexion
        conexiones1.conexion()
        conexiones1.abrir()
        Dim cmd1 As New SqlCommand("Riesgo_prepago3_H", conexiones1._conexion)
        cmd1.CommandType = CommandType.StoredProcedure
        Dim prm1 As SqlParameter = _
            New SqlParameter("@prestamo", SqlDbType.NChar, 30)
        cmd1.Parameters.Add(prm1)

        Dim prm2 As SqlParameter = _
            New SqlParameter("@PERFIL", SqlDbType.NChar, 30)
        cmd1.Parameters.Add(prm2)

        Dim prm3 As SqlParameter = _
           New SqlParameter("@nrosocio", SqlDbType.NChar, 30)
        cmd1.Parameters.Add(prm3)

        With cmd1
            .Parameters("@prestamo").Value = prestamo
            .Parameters("@PERFIL").Value = frmPerfil.CbmUsuario.SelectedItem
            .Parameters("@nrosocio").Value = txtNrosocio2.Text.ToString.Trim
        End With
        Dim dr1 As SqlDataReader = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
        conexiones1.cerrar()


        Dim conexiones6 As New CConexion
        conexiones6.conexion()
        Dim command6 As SqlCommand = New SqlCommand("SELECT * FROM _RIESGO_PREPAGO where prestamo='" + prestamo + "'", conexiones6._conexion)
        conexiones6.abrir()
        Dim reader6 As SqlDataReader = command6.ExecuteReader()

        If reader6.HasRows Then
            Do While reader6.Read()
                txtCapitalPrestamo.Text = Format(Integer.Parse(reader6(0).ToString), "#,##0")
                txtInteresVencidoNoPagado.Text = Format(Integer.Parse(reader6(1).ToString), "#,##0")
                txtInteresdelmes.Text = Format(Integer.Parse(reader6(2).ToString), "#,##0")
                txtComisionAnticipoCredito.Text = Format(Integer.Parse(reader6(3).ToString), "#,##0")
            Loop
        Else
        End If

        reader6.Close()

        txtSaldoInsoluto.Text = Format(Integer.Parse(Replace(txtCapitalPrestamo.Text, ".", "")) + Integer.Parse(Replace(txtInteresVencidoNoPagado.Text, ".", "")), "#,##0")

        txtTotalaPagar.Text = Format(Integer.Parse(Replace(txtSaldoInsoluto.Text, ".", "")) + Integer.Parse(Replace(txtInteresdelmes.Text, ".", "")) + Integer.Parse(Replace(txtComisionAnticipoCredito.Text, ".", "")), "#,##0")

        Dim conexiones5 As New CConexion
        conexiones5.conexion()
        Dim command5 As SqlCommand = New SqlCommand("  update _RIESGO_PREPAGO set estado='SI' where prestamo='" + prestamo + "' AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem + "'", conexiones5._conexion)
        conexiones5.abrir()
        Dim reader5 As SqlDataReader = command5.ExecuteReader()

        reader5.Close()



        LboxAgregados.Items.Clear()

        Dim conexiones8 As New CConexion
        conexiones8.conexion()
        Dim command8 As SqlCommand = New SqlCommand("SELECT [Prestamo] FROM [_RIESGO_PREPAGO] where estado='SI' AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem + "'", conexiones8._conexion)
        conexiones8.abrir()
        Dim reader8 As SqlDataReader = command8.ExecuteReader()

        If reader8.HasRows Then
            Do While reader8.Read()
                LboxAgregados.Items.Add(reader8(0).ToString)

            Loop
        Else
        End If

        reader8.Close()
    End Sub
    Sub sumar()

        Try
            Dim conexiones8 As New CConexion
            conexiones8.conexion()
            Dim command8 As SqlCommand = New SqlCommand("SELECT sum([Saldo_Capital_Prestamo]+[Interes_Vencido_No_Pagado]+[Intereses_del_mes]+[Comision_por_anticipo_del_credito]) FROM [_RIESGO_PREPAGO] where estado='SI' AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem + "'", conexiones8._conexion)
            conexiones8.abrir()
            Dim reader8 As SqlDataReader = command8.ExecuteReader()

            If reader8.HasRows Then
                Do While reader8.Read()
                    txtCuotasPrepagadas2.Text = Format(Integer.Parse(reader8(0).ToString), "#,##0")

                Loop
            Else
            End If

            reader8.Close()

            frmEvaluar.txtPrepago.Text = TxtMonto.Text




            Dim conexiones9 As New CConexion
            conexiones9.conexion()
            Dim command9 As SqlCommand = New SqlCommand("SELECT sum(Cuota_Actual) FROM [_RIESGO_PREPAGO] where estado='SI' AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem + "'", conexiones9._conexion)
            conexiones9.abrir()
            Dim reader9 As SqlDataReader = command9.ExecuteReader()

            If reader9.HasRows Then
                Do While reader9.Read()
                    txtCuotasPrestamos.Text = Format(Integer.Parse(reader9(0).ToString), "#,##0")

                Loop
            Else
            End If

            reader9.Close()

        Catch ex As Exception

        End Try
    End Sub

    Sub cargartasa()
        Dim i As Decimal
        For i = 0 To 2.8 Step 0.01
            cboTasaSolicitada4.Items.Add(i.ToString)
            cboTasaSolicitada5.Items.Add(i.ToString)
        Next
        cboTasaSolicitada4.SelectedItem = 0
        cboTasaSolicitada5.SelectedItem = 0

    End Sub

    Private Sub FrmFichaAprobar_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            frmCreditosPorAprobar.CheckBox1.Checked = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WriteTextToRichTextBox()

        Dim i As Integer
        Dim cadena As String = txtComentarioSistema2.Text
        For i = 0 To txtComentarioSistema2.TextLength - 9
            'MsgBox(cadena.Substring(i, 9))
            If cadena.Substring(i, 9) = "Rechazado" Then
                txtComentarioSistema2.Select(i, 9)
                txtComentarioSistema2.SelectionColor = Color.Red
                i = i + 1
            End If
        Next
        For i = 0 To txtComentarioSistema2.TextLength - 5
            If cadena.Substring(i, 5) = "BUENO" Then
                txtComentarioSistema2.Select(i, 5)
                txtComentarioSistema2.SelectionColor = Color.Green
                i = i + 1
            End If
        Next

        For i = 0 To txtComentarioSistema2.TextLength - 4
            If cadena.Substring(i, 4) = "MALO" Then
                txtComentarioSistema2.Select(i, 4)
                txtComentarioSistema2.SelectionColor = Color.Red
                i = i + 1
            End If
        Next

        For i = 0 To txtComentarioSistema2.TextLength - 9
            If cadena.Substring(i, 9) = "Negativos" Then
                txtComentarioSistema2.Select(i, 9)
                txtComentarioSistema2.SelectionColor = Color.Red
                i = i + 1
            End If
        Next


        For i = 0 To txtComentarioSistema2.TextLength - 9
            If cadena.Substring(i, 9) = "No aplica" Then
                txtComentarioSistema2.Select(i, 9)
                txtComentarioSistema2.SelectionColor = Color.Blue
                i = i + 1
            End If
        Next

        For i = 0 To txtComentarioSistema2.TextLength - 9
            If cadena.Substring(i, 9) = "No aplica" Then
                txtComentarioSistema2.Select(i, 9)
                txtComentarioSistema2.SelectionColor = Color.Blue
                i = i + 1
            End If
        Next

        For i = 0 To txtComentarioSistema2.TextLength - 51
            If cadena.Substring(i, 51) = "Tiene condiciones favorables para aplicar excepción" Then
                txtComentarioSistema2.Select(i, 51)
                txtComentarioSistema2.SelectionColor = Color.Green
                txtComentarioSistema2.SelectionFont = New Font("Arial", 11)
                i = i + 1
            End If
        Next

        For i = 0 To txtComentarioSistema2.TextLength - 49
            If cadena.Substring(i, 49) = "No se excepciona al tener 2 condiciones Negativas" Or cadena.Substring(i, 49) = "No se excepciona al tener 3 condiciones Negativas" Or cadena.Substring(i, 49) = "No se excepciona al tener 4 condiciones Negativas" Then
                txtComentarioSistema2.Select(i, 49)
                txtComentarioSistema2.SelectionColor = Color.Red
                txtComentarioSistema2.SelectionFont = New Font("Arial", 11)
                i = i + 1
            End If
        Next

        For i = 0 To txtComentarioSistema2.TextLength - 46
            If cadena.Substring(i, 46) = "No se excepciona al tener 1 condición Negativa" Then
                txtComentarioSistema2.Select(i, 46)
                txtComentarioSistema2.SelectionColor = Color.Red
                txtComentarioSistema2.SelectionFont = New Font("Arial", 11)
                i = i + 1
            End If
        Next

        For i = 0 To txtComentarioSistema2.TextLength - 8
            If cadena.Substring(i, 8) = "más alto" Then
                txtComentarioSistema2.Select(i, 8)
                txtComentarioSistema2.SelectionColor = Color.Red
                i = i + 1
            End If
        Next

        For i = 0 To txtComentarioSistema2.TextLength - 8
            If cadena.Substring(i, 8) = "más bajo" Then
                txtComentarioSistema2.Select(i, 8)
                txtComentarioSistema2.SelectionColor = Color.Green
                i = i + 1
            End If
        Next


        For i = 0 To txtComentarioSistema2.TextLength - 5
            If cadena.Substring(i, 5) = "igual" Then
                txtComentarioSistema2.Select(i, 5)
                txtComentarioSistema2.SelectionColor = Color.Green
                i = i + 1
            End If
        Next

        For i = 0 To txtComentarioSistema2.TextLength - 62
            If cadena.Substring(i, 62) = "Por cosiguiente no cumple con las politicas 6.1 de excepciones" Then
                txtComentarioSistema2.Select(i, 62)
                txtComentarioSistema2.SelectionColor = Color.Red
                txtComentarioSistema2.SelectionFont = New Font("Arial", 11)
                i = i + 1
            End If
        Next

        For i = 0 To txtComentarioSistema2.TextLength - 16
            If cadena.Substring(i, 16) = "No se excepciona" Then
                txtComentarioSistema2.Select(i, 16)
                txtComentarioSistema2.SelectionColor = Color.Red
                txtComentarioSistema2.SelectionFont = New Font("Arial", 11)
                i = i + 1
            End If
        Next

        For i = 0 To txtComentarioSistema2.TextLength - 9
            If cadena.Substring(i, 9) = "positivos" Or cadena.Substring(i, 9) = "Positivos" Then
                txtComentarioSistema2.Select(i, 9)
                txtComentarioSistema2.SelectionColor = Color.Green
                i = i + 1
            End If
        Next


        For i = 0 To txtComentarioSistema2.TextLength - 12
            If cadena.Substring(i, 12) = "No aplicable" Then
                txtComentarioSistema2.Select(i, 12)
                txtComentarioSistema2.SelectionColor = Color.Blue
                i = i + 1
            End If
        Next


    End Sub
    Sub crearcolumna()
        If DGHistoricoPrestamos.Columns.Contains("btn") Then
        Else
            Dim btn As New DataGridViewButtonColumn()
            DGHistoricoPrestamos.Columns.Add(btn)
            btn.HeaderText = "Analisis"
            btn.Text = "Ver"
            btn.Name = "btn"
            btn.UseColumnTextForButtonValue = True
        End If
    End Sub

    Private Sub FrmFichaAprobar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load




        crearcolumna()

        cargartasa()
        txtCodigoId.Text = frmCreditosPorAprobar.txtid.Text
        TXTUSUARIO.Text = frmPerfil.CbmUsuario.SelectedItem.ToString
        Dim ATRIBUTO_PERFIL As String
        Dim ATRIBUTO_PRESTAMO As String
        CARGO = ""
        Dim conexiones3 As New CConexion
        conexiones3.conexion()
        Dim command3 As SqlCommand = New SqlCommand("SELECT  CC1.*,CC2.Comentario_PreAgente,cc2.Comentario_riesgo as Comentario_riesgo2 ,cc2.Comentario_Gerente as Comentario_Gerente2 , cc2.Comentario_SubGerente as Comentario_SubGerente2 , cc2.Comentario_Agencia as Comentario_Agencia2  , cc2.Comentario_PreAgente_Tipos ,tasa_castigada,tasa_real,comentario_tasa,Descuento_campaña,EDeudadVencidasIndirectas,RutAval1,RutAval2,Eperiodo,modificaciondeudaexterna,PYM6,PYM6A12,PYM12A24,PYM24,ID_RENTA,MaximoMontoPlanilla,MaximaCuotaPlanilla,COD_DACA,MES_PRIMERA,ANO_PRIMERA,COD_FORMAPAGO,DISPONIBLE,CUOTA_ULTIMA,Condicional_Plazo_R,Condicional_Monto_R,Condicional_Tasa_R,Condicional_R  FROM [_RIESGO_PRESTAMOS_SOLICITADOS] AS CC1  LEFT JOIN  _RIESGO_COMENTARIOS_PRESTAMOS AS CC2 ON CC1.id_solicitud=CC2.id_solicitud    where  CC1.id_solicitud='" + id + "'", conexiones3._conexion)
        conexiones3.abrir()
        Dim reader3 As SqlDataReader = command3.ExecuteReader()
        If reader3.HasRows Then
            Do While reader3.Read()
                txtNrosocio2.Text = (reader3("Nrosocio").ToString)
                txtFecha.Text = (reader3("fecha_solicitud").ToString)
                txtProducto.Text = (reader3("producto").ToString)
                txtProducto2.Text = (reader3("producto").ToString)

                If txtProducto2.Text.Trim = "CUOTON" Then

                    TxtMonto3.Enabled = False
                    txtNuevoMontoDisponible2.Enabled = True


                ElseIf txtProducto2.Text.Trim = "RENEGOCIACION FLEXIBLE" Then


                    TxtMonto3.Enabled = True
                    txtNuevoMontoDisponible2.Enabled = True


                Else

                    TxtMonto3.Enabled = True
                    txtNuevoMontoDisponible2.Enabled = True

                    'TxtDisponible2.Enabled = False
                End If

                txtObjetivo2.Text = (reader3("objetivo").ToString)
                'TxtMonto.Text = (reader3(5).ToString)
                TxtMonto.Text = Format(Decimal.Round(reader3("monto_solicitado").ToString), "#,##0")
                'TxtMonto2.Text = (reader3(5).ToString)
                TxtMonto2.Text = Format(Decimal.Round(reader3("monto_solicitado").ToString), "#,##0")
                'TxtMonto3.Text = (reader3(5).ToString)
                TxtMonto3.Text = Format(Decimal.Round(reader3("monto_solicitado").ToString), "#,##0")
                'txtCapital.Text = (reader3(6).ToString)
                txtCapital.Text = Format(Decimal.Round(reader3("capital").ToString), "#,##0")
                'txtPrepago.Text = (reader3(7).ToString)
                txtPrepago.Text = Format(Decimal.Round(reader3("prepago").ToString), "#,##0")
                'txtPrepago2.Text = (reader3(7).ToString)
                txtPrepago2.Text = Format(Decimal.Round(reader3("prepago").ToString), "#,##0")
                'txtMonto4.Text = (reader3(7).ToString)
                txtMonto4.Text = Format(Decimal.Round(reader3("prepago").ToString), "#,##0")
                'txtMonto4.Text = "Por Analizar"
                txtPrepagos.Text = (reader3("NroPrepagos").ToString)
                txtPrepagos2.Text = (reader3("NroPrepagos").ToString)
                txtPlazo.Text = (reader3("nrocuotas").ToString)
                txtPlazo2.Text = (reader3("nrocuotas").ToString)

                cboNuevoPlazo.Items.Clear()
                'CboNuevaTasa.Items.Add("Por Defecto Sistema")
                For i = 1 To 150 Step 1
                    cboNuevoPlazo.Items.Add(i.ToString)
                Next

                cboNuevoPlazo.SelectedItem = (reader3("nrocuotas").ToString.Trim)


                'TxtCuota.Text = (reader3(10).ToString)
                TxtCuota.Text = Format(Decimal.Round(reader3("primera_cuota").ToString), "#,##0")
                'TxtCuota2.Text = (reader3(10).ToString)
                TxtCuota2.Text = Format(Decimal.Round(reader3("primera_cuota").ToString), "#,##0")
                'txtCuota3.Text = (reader3(10).ToString)
                txtCuota3.Text = Format(Decimal.Round(reader3("primera_cuota").ToString), "#,##0")

                txtTasa.Text = (reader3("tasa").ToString)
                txtTasa2.Text = (reader3("tasa").ToString)
                CboNuevaTasa.Items.Clear()
                'CboNuevaTasa.Items.Add("Por Defecto Sistema")
                For i = 0.5 To 3.01 Step 0.01
                    CboNuevaTasa.Items.Add(i.ToString)
                Next

                CboNuevaTasa.SelectedItem = (reader3("tasa").ToString.Trim)

                txtTasaCastigo.Text = (reader3("tasa_castigada").ToString)
                txtTasaSolicitud.Text = (reader3("Tasa_solicitada").ToString)
                txtDescuentoTasa.Text = (reader3("Descuento_campaña").ToString)
                txtTasaReal.Text = (reader3("tasa_real").ToString)

                txtDiasGracia.Text = (reader3("dias_gracia").ToString)
                txtDiasGracia2.Text = (reader3("dias_gracia").ToString)
                txtNrocuotas.Text = (reader3("ncreditos").ToString)
                txtFechaPrimeraCuota.Text = (reader3("fechaprimervencimiento").ToString)
                txtFormaPago.Text = (reader3("forpago").ToString)
                txtRenta2.Text = (reader3("tiporenta").ToString)
                txtProtesto2.Text = (reader3("protestosmorocidades").ToString)
                'txtComportamiento2.Text = (reader3("comportamientopago").ToString.Trim)




                'txtEdeudafinanciera.Text = (reader3(19).ToString)
                txtEdeudafinanciera.Text = Format(Decimal.Round(reader3("Edeudafinanciera").ToString), "#,##0")
                'txtEdeudaHipo.Text = (reader3(20).ToString)
                txtEdeudaHipo.Text = Format(Decimal.Round(reader3("EdeudaHipo").ToString), "#,##0")
                'txtEdeudaConsumo.Text = (reader3(21).ToString)
                txtEdeudaConsumo.Text = Format(Decimal.Round(reader3("EdeudaConsumo").ToString), "#,##0")
                'txtEdeudaComercial.Text = (reader3(22).ToString)
                txtEdeudaComercial.Text = Format(Decimal.Round(reader3("EdeudaComercial").ToString), "#,##0")
                'txtEDeudadVencidas.Text = (reader3(23).ToString)
                txtEDeudadVencidas.Text = Format(Decimal.Round(reader3("EDeudadVencidas").ToString), "#,##0")
                'txtELineaCredito.Text = (reader3(24).ToString)
                txtELineaCredito.Text = Format(Decimal.Round(reader3("ELineaCredito").ToString), "#,##0")
                txtENumeroAcreedores.Text = (reader3("ENumeroAcreedores").ToString)


                'txtItotaldeuda.Text = (reader3(26).ToString)
                txtItotaldeuda.Text = Format(Decimal.Round(reader3("Itotaldeuda").ToString), "#,##0")
                'txtItotaldeuda2.Text = (reader3(26).ToString)
                txtItotaldeuda2.Text = Format(Decimal.Round(reader3("Itotaldeuda").ToString), "#,##0")
                'txtInternaTotalDeuda.Text = (reader3(26).ToString)
                txtInternaTotalDeuda.Text = Format(Decimal.Round(reader3("Itotaldeuda").ToString), "#,##0")
                'txtInternaTotalDeuda.Text = (reader3(26).ToString)
                txtInternaTotalDeuda.Text = Format(Decimal.Round(reader3("Itotaldeuda").ToString), "#,##0")


                'txtIdeudaConsumo.Text = (reader3(27).ToString)
                txtIdeudaConsumo.Text = Format(Decimal.Round(reader3("IdeudaConsumo").ToString), "#,##0")
                'txtInternaDeudaConsumo.Text = (reader3(27).ToString)
                txtInternaDeudaConsumo.Text = Format(Decimal.Round(reader3("IdeudaConsumo").ToString), "#,##0")

                'txtIdeudaComercial.Text = (reader3(28).ToString)
                txtIdeudaComercial.Text = Format(Decimal.Round(reader3("IdeudaComercial").ToString), "#,##0")
                'txtInternaDeudaComercial.Text = (reader3(28).ToString)
                txtInternaDeudaComercial.Text = Format(Decimal.Round(reader3("IdeudaComercial").ToString), "#,##0")

                'txtIDeudaIndirecta.Text = (reader3(29).ToString)
                txtIDeudaIndirecta.Text = Format(Decimal.Round(reader3("IDeudaIndirecta").ToString), "#,##0")
                'txtInternaDeudaIndirecta.Text = (reader3(29).ToString)
                txtInternaDeudaIndirecta.Text = Format(Decimal.Round(reader3("IDeudaIndirecta").ToString), "#,##0")


                'txtIPagoMensual.Text = (reader3(30).ToString)
                txtIPagoMensual.Text = Format(Decimal.Round(reader3("IPagoMensual").ToString), "#,##0")
                'txtIPagoMensual2.Text = (reader3(30).ToString)
                txtIPagoMensual2.Text = Format(Decimal.Round(reader3("IPagoMensual").ToString), "#,##0")
                'txtInternaPagoMensual.Text = (reader3(30).ToString)
                txtInternaPagoMensual.Text = Format(Decimal.Round(reader3("IPagoMensual").ToString), "#,##0")

                'txtRLP.Text = (reader3(31).ToString)
                txtRLP.Text = Format(Decimal.Round(reader3("RLP").ToString), "#,##0")
                'txtCargaFinanciera.Text = (reader3(32).ToString)
                txtCargaFinanciera.Text = Format(Decimal.Round(reader3("CargaFinanciera").ToString), "#,##0")
                'txtExternaAcreditado.Text = (reader3(33).ToString)
                txtExternaAcreditado.Text = Format(Decimal.Round(reader3("ExternaAcreditado").ToString), "#,##0")


                'txtActivos.Text = (reader3(34).ToString)
                txtActivos.Text = Format(Decimal.Round(reader3("Activos").ToString), "#,##0")
                'txtPropiedades.Text = (reader3(35).ToString)
                txtPropiedades.Text = Format(Decimal.Round(reader3("Propiedades").ToString), "#,##0")
                'txtVehiculos.Text = (reader3(36).ToString)
                txtVehiculos.Text = Format(Decimal.Round(reader3("Vehiculos").ToString), "#,##0")
                'txtRentaLiquidaDepurada.Text = (reader3(37).ToString)
                txtRentaLiquidaDepurada.Text = Format(Decimal.Round(reader3("RentaLiquidaDepurada").ToString), "#,##0")



                txtLeverage.Text = (reader3("LVL").ToString)
                txtLeverage2.Text = (reader3("LVL").ToString)

                txtCapacidad.Text = (reader3("Capacidad").ToString)
                txtCapacidad2.Text = (reader3("Capacidad").ToString)

                txtvalidaciones2.Text = (reader3("Validaciones").ToString)
                txtEjecutivo.Text = (reader3("Ejecutiva").ToString)
                txtSucursal.Text = (reader3("Sucursal").ToString)

                txtPuntaje.Text = (reader3("Puntaje").ToString)
                txtAntiguedadLab2.Text = (reader3("Anos_contrato").ToString)
                txtEdad2.Text = (reader3("Edad").ToString)
                txtAntiguedad2.Text = (reader3("Anos_antiguedad").ToString)
                ATRIBUTO_PRESTAMO = (reader3("Atribucion").ToString)
                ATRIBUTO_PRESTAMO2 = (reader3("Atribucion").ToString)
                txtCapitalAcumulado.Text = (reader3("Monto_capital").ToString)
                txtCapitalAcumulado.Text = Format(Decimal.Round(reader3("Monto_capital").ToString), "#,##0")


                txtCuotasPrepagadas.Text = (reader3("Cuotas_prepago").ToString)
                txtCuotasPrepagadas2.Text = (reader3("Cuotas_prepago").ToString)
                txtCuotasPrestamos.Text = (reader3("Cuotas_prepago").ToString)

                txtPuntajes.Text = (reader3("Puntajes_Validaciones").ToString)
                If (Trim(reader3("Presocio").ToString) = Trim(reader3("Nrosocio").ToString)) Then
                    Timer1.Enabled = True
                    Timer1.Interval = 250
                End If

                txtComportamientoClasificaciones.Text = (reader3("comportamiento_clasificacion").ToString)
                txtComportamientoCapital.Text = (reader3("comportamiento_abonocapital").ToString)
                txtClasificacionBaja.Text = (reader3("comportamiento_baja_clasificacion").ToString)

                txtEjecutivoVentas.Text = (reader3("Ejecutivo_convenio").ToString)

                txtReref.Text = (reader3("renegocia_refinancia").ToString)
                txtValidacionAgente.Text = (reader3("PreAprobacion_Agente").ToString.Trim)

                txtComentarioAgente.Text = (reader3("Comentario_PreAgente").ToString.Trim)
                txtValidacionAgente.Text = (reader3("PreAprobacion_Agente").ToString.Trim)

                txtComentarioEjecutivo.Text = (reader3("Comentario_Ejecutiva").ToString)
                txtComentarioEjecutivoUser.Text = (reader3("Ejecutiva").ToString)

                txtComentarioRiesgo.Text = (reader3("Comentario_riesgo2").ToString)
                txtComentarioRiesgoUser.Text = (reader3("Riesgo_perfil").ToString)

                txtComentarioAgente.Text = (reader3("Comentario_PreAgente").ToString)
                txtComentarioAgenteUser.Text = (reader3("PreAgencia_Perfil").ToString)


                txtComentarioGerente2.Text = (reader3("Comentario_Gerente2").ToString)
                txtComentarioGerente2User.Text = (reader3("Gerencia_Perfil").ToString)

                txtComentarioSubGerente.Text = (reader3("Comentario_SubGerente2").ToString)
                txtComentarioSubGerenteUser.Text = (reader3("Subgerencia_Perfil").ToString)

                txtComentarioAgencia.Text = (reader3("Comentario_Agencia2").ToString)
                txtComentarioAgenciaUser.Text = (reader3("Agencia_Perfil").ToString)
                cboTipologiasDeObjeciones.SelectedItem = (reader3("Comentario_PreAgente_Tipos").ToString.Trim)
                txtRegion.Text = (reader3("Region").ToString)
                txtInstitucion.Text = (reader3("Institucion").ToString)
                txtPlataforma.Text = (reader3("Plataforma").ToString)

                If frmPerfil.CbmUsuario.SelectedItem.ToString.Trim = "CCAMPOS" Or frmPerfil.CbmUsuario.SelectedItem.ToString.Trim = "CAGUILAR" Or frmPerfil.CbmUsuario.SelectedItem.ToString.Trim = "HHERRERA(R)" Or frmPerfil.CbmUsuario.SelectedItem.ToString.Trim = "JFARIAS(R)" Or frmPerfil.CbmUsuario.SelectedItem.ToString.Trim = "BPEREZ(R)" Then
                    txtComentarioSistema2.Text = (reader3("comentario_tasa").ToString)
                Else
                    txtComentarioSistema2.Text = "TESTEO DE EXCEPCIONES, SOLO PARA DISPONIBLE PARA DEPARTAMENTO DE RIESGO"
                End If

                txtEDeudadIndirectasVencidas.Text = (reader3("EDeudadVencidasIndirectas").ToString.Trim)

                txtAval1.Text = (reader3("RutAval1").ToString.Trim)
                txtAval2.Text = (reader3("RutAval2").ToString.Trim)
                txtPeriodo.Text = (reader3("Eperiodo").ToString.Trim)

                If reader3("modificaciondeudaexterna").ToString.Trim = "SI" Then
                    LDeudaExterna.Text = "Deuda externa incorporada MANUALMENTE"
                Else
                    LDeudaExterna.Text = "Deuda externa incorporada AUTOMATICAMENTE"
                End If


                txtPYM6.Text = Puntos((reader3("PYM6").ToString.Trim))
                txtPYM612.Text = Puntos((reader3("PYM6A12").ToString.Trim))
                txtPYM1224.Text = Puntos((reader3("PYM12A24").ToString.Trim))
                TXTPYM24.Text = Puntos((reader3("PYM24").ToString.Trim))

                TXTPYMTOTAL.Text = Integer.Parse(Replace(txtPYM6.Text, ".", "")) + Integer.Parse(Replace(TXTPYM24.Text, ".", "")) + Integer.Parse(Replace(txtPYM1224.Text, ".", "")) + Integer.Parse(Replace(txtPYM612.Text, ".", ""))
                TXTPYMTOTAL.Text = Puntos(TXTPYMTOTAL.Text)


                txtIdRenta.Text = Puntos((reader3("ID_RENTA").ToString.Trim))
                txtMaxCuota.Text = Puntos((reader3("MaximaCuotaPlanilla").ToString.Trim))
                txtMaxMonto.Text = Puntos((reader3("MaximoMontoPlanilla").ToString.Trim))

                TXTCodDaca.Text = Puntos((reader3("COD_DACA").ToString.Trim))

                If reader3("MES_PRIMERA").ToString.Trim <> "0" Then
                    lNuevoPeriodo.Visible = True
                    TableNuevoPeriodo.Visible = True
                    txtNuevoPeriodoMes.Text = (reader3("MES_PRIMERA").ToString.Trim)
                    txtNuevoPeriodoAño.Text = (reader3("ANO_PRIMERA").ToString.Trim)
                Else
                    lNuevoPeriodo.Visible = False
                    TableNuevoPeriodo.Visible = False
                End If

                txtMontoDisponible.Text = Puntos((reader3("DISPONIBLE").ToString.Trim))
                txtMontoDisponible2.Text = Puntos((reader3("DISPONIBLE").ToString.Trim))
                txtNuevoMontoDisponible2.Text = Puntos((reader3("DISPONIBLE").ToString.Trim))

                txtCuotaFinal.Text = Puntos((reader3("CUOTA_ULTIMA").ToString.Trim))
                txtCodFormaDePago.Text = reader3("COD_FORMAPAGO").ToString.Trim
             
                If (reader3("Condicional_R").ToString.Trim) <> "" Then
                    LCondicion.Visible = True
                    PGenerarCondicion.Visible = False

                    txtCondicion2.Text = reader3("Condicional_R").ToString.Trim
                    If reader3("Condicional_Plazo_R").ToString.Trim <> "" Then
                        chkPlazo2.Checked = True
                        txtPlazoSolicitado5.Text = reader3("Condicional_Plazo_R").ToString.Trim
                    End If
                    If reader3("Condicional_Monto_R").ToString.Trim <> "" Then
                        chkMonto2.Checked = True
                        txtmontosolicitado5.Text = reader3("Condicional_Monto_R").ToString.Trim
                    End If
                    If reader3("Condicional_Tasa_R").ToString.Trim <> "" Then
                        chkTasa2.Checked = True
                        cboTasaSolicitada5.SelectedItem = reader3("Condicional_Tasa_R").ToString.Trim
                    End If
                Else
                    LCondicion.Visible = False
                    PanelBotonesRiesgo.Visible = False
                    PGenerarCondicion.Visible = True
                End If
            Loop
        Else
        End If

        reader3.Close()

        Dim estadocivil As String
        Dim tipovivienda As String

        Dim conexiones4 As New CConexion
        conexiones4.conexion()
        Dim command4 As SqlCommand
        If (Timer1.Enabled = False) Then
            'MsgBox("ES SOCIO")
            command4 = New SqlCommand("SELECT convert(varchar,[RUT])+'-'+ convert(varchar,[DVRUT]),[FechaIng],[FechaNac],[FechaContrato],[Nombres]+' '+[Paterno]+' '+[Materno],[EstadoCivil],[CantCargas],[TipoViv],_INSTITUCIONES.DESCRIPCION,[SUELDOLIQUIDO], convert(varchar,[RUT])AS RUT2 , sexo  FROM [_SOCIOS] left join _INSTITUCIONES on _SOCIOS.CODINST= _INSTITUCIONES.CODINS where NROSOCIO='" + txtNrosocio2.Text + "'", conexiones3._conexion)
         
        ElseIf (Timer1.Enabled = True) Then
            'MsgBox("ES PRE-SOCIO")
            command4 = New SqlCommand("SELECT convert(varchar,[RUT])+'-'+ convert(varchar,[DVRUT]),[FechaSolicitud],[FechaNac],[FechaContrato],[Nombres]+' '+[Paterno]+' '+[Materno],[EstadoCivil],[CantCargas],[TipoViv],_INSTITUCIONES.DESCRIPCION,[SUELDOLIQUIDO], convert(varchar,[RUT]) AS RUT2 , sexo FROM [_PRESOCIOS] left join _INSTITUCIONES on _PRESOCIOS.CODINST= _INSTITUCIONES.CODINS where NROSOCIO='" + txtNrosocio2.Text + "'", conexiones3._conexion)
  
        End If
        'Dim command4 As SqlCommand = New SqlCommand("SELECT convert(varchar,[RUT])+'-'+ convert(varchar,[DVRUT]),[FechaIng],[FechaNac],[FechaContrato],[Nombres]+' '+[Paterno]+' '+[Materno],[EstadoCivil],[CantCargas],[TipoViv],_INSTITUCIONES.DESCRIPCION,[SUELDOLIQUIDO]FROM [_SOCIOS] left join _INSTITUCIONES on _SOCIOS.CODINST= _INSTITUCIONES.CODINS where NROSOCIO='" + txtNrosocio2.Text + "'", conexiones4._conexion)
        conexiones4.abrir()
        Dim reader4 As SqlDataReader = command4.ExecuteReader()


        If reader4.HasRows Then
            Do While reader4.Read()
                txtRut2.Text = (reader4(0).ToString)
                'InputDateString1 = (reader4(1).ToString)
                'InputDateString2 = (reader4(2).ToString)
                'InputDateString4 = (reader4(3).ToString)
                txtNombre2.Text = (reader4(4).ToString)
                estadocivil = (reader4(5).ToString)
                'txtCargasFamiliares.Text = (reader4(6).ToString)
                tipovivienda = (reader4(7).ToString)
                'txtProtesto.Text = (reader4(8).ToString)
                'txtRemuneracion.Text = (reader4(9).ToString)
                txtrut3.Text = (reader4("RUT2").ToString)
                txtSexo.Text = (reader4("Sexo").ToString)

            Loop
        Else
        End If

        reader4.Close()


        versolicitudes()

        If estadocivil = "C" Then
            txtEstadocivil2.Text = "Casado en Sociedad Conyugal"
        ElseIf estadocivil = "S" Then
            txtEstadocivil2.Text = "Soltero"
        ElseIf estadocivil = "V" Then
            txtEstadocivil2.Text = "Viudo"
        ElseIf estadocivil = "P" Then
            txtEstadocivil2.Text = "Divorciado"
        ElseIf estadocivil = "B" Then
            txtEstadocivil2.Text = "Casado Separación de Bienes"
        Else
            txtEstadocivil2.Text = "Sin registro"
        End If


        If tipovivienda = "1" Then
            txtTipovivienda2.Text = "Propia"
        ElseIf tipovivienda = "2" Then
            txtTipovivienda2.Text = "Propia con Dividendos"
        ElseIf tipovivienda = "3" Then
            txtTipovivienda2.Text = "Arrendada"
        ElseIf tipovivienda = "4" Then
            txtTipovivienda2.Text = "Cedida o Gratuita"
        Else
            txtTipovivienda2.Text = "Sin registro"
        End If


        Dim conexiones2 As New CConexion
        conexiones2.conexion()
        Dim command2 As SqlCommand = New SqlCommand("SELECT NOMBRE,ATRIBUTO,CARGO FROM _RIESGO_PERFIL WHERE USUARIO='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "'", conexiones2._conexion)
        conexiones2.abrir()

        Dim reader2 As SqlDataReader = command2.ExecuteReader()


        If reader2.HasRows Then
            Do While reader2.Read()
                TXTUSUARIO.Text = (reader2(0).ToString)
                ATRIBUTO_PERFIL = (reader2(1).ToString)
                CARGO = (reader2(2).ToString)
            Loop
        Else
        End If

        reader2.Close()

        'MsgBox(ATRIBUTO_PERFIL)

        If Trim(CARGO) = "AGENCIA" Then
            If txtValidacionAgente.Text = "Por Analizar" Then
                cboTipologiasDeObjeciones.Enabled = True
                txtComentarioAgente.ReadOnly = False
                txtComentarioAgente.Text = ""
            Else
                txtComentarioAgencia.ReadOnly = False
                txtComentarioAgencia.Text = ""
            End If
        ElseIf Trim(CARGO) = "SUBGERENTE" Then
            txtComentarioSubGerente.ReadOnly = False
            txtComentarioSubGerente.Text = ""
        ElseIf Trim(CARGO) = "GERENTE" Then
            txtComentarioGerente2.ReadOnly = False
            txtComentarioGerente2.Text = ""
        ElseIf Trim(CARGO) = "RIESGO" Then
            txtComentarioRiesgo.ReadOnly = False
            txtComentarioRiesgo.Text = ""
            chkTasa2.Enabled = True
            chkMonto2.Enabled = True
            chkPlazo2.Enabled = True
            btnCondicion2.Enabled = True
            PanelCondicion.Visible = True
        ElseIf Trim(CARGO) = "RIESGO_RENTA" Then
            'txtComentarioRiesgo.ReadOnly = False
            'txtComentarioRiesgo.Text = ""
            'chkTasa2.Enabled = True
            'chkMonto2.Enabled = True
            'chkPlazo2.Enabled = True
            'btnCondicion2.Enabled = True
            'PanelCondicion.Visible = True
        End If





        If txtValidacionAgente.Text = "Por Analizar" Then
            CboAprobar.Items.Add("LIBERADO SIN OBJECIONES")
            CboAprobar.Items.Add("LIBERADO CON OBJECIONES")
            CboAprobar.Items.Add("NO LIBERADO")
            CboAprobar.Items.Add("DESCARTADO")
            CboAprobar.Items.Add("NO VALIDA")
        Else
            If (Int(ATRIBUTO_PERFIL) >= Int(ATRIBUTO_PRESTAMO)) Then
                CboAprobar.Items.Add("SI")
                CboAprobar.Items.Add("SI CONDICIONAL")
                CboAprobar.Items.Add("NO")
                CboAprobar.Items.Add("DESCARTADO")
                PanelBotonesRiesgo.Visible = True

            ElseIf (Int(ATRIBUTO_PERFIL) < Int(ATRIBUTO_PRESTAMO)) Then
                CboAprobar.Items.Add("RECOMIENDO")
                CboAprobar.Items.Add("RECOMIENDO CONDICIONAL")
                CboAprobar.Items.Add("NO RECOMIENDO")
                CboAprobar.Items.Add("DESCARTADO")

                If (frmPerfil.CbmUsuario.SelectedItem = "PBOMBAL" Or frmPerfil.CbmUsuario.SelectedItem = "CCAMPOS(S)") Then
                    ChkSustituir.Enabled = True
                End If
            End If
        End If


        If Trim(CARGO) = "RIESGO_RENTA" Then
            CboAprobar.Items.Clear()
            CboAprobar.Items.Add("Si")
            CboAprobar.Items.Add("No")
            CboAprobar.Items.Add("Error Datos")
            CboAprobar.Items.Add("Error Renta")
            CboAprobar.Items.Add("Error PLanilla")
        End If




        Dim conexiones5 As New CConexion
        conexiones5.conexion()
        Dim command5 As SqlCommand = New SqlCommand("DELETE _RIESGO_PREPAGO WHERE PERFIL ='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "'", conexiones5._conexion)
        conexiones5.abrir()
        Dim reader5 As SqlDataReader = command5.ExecuteReader()
        reader5.Close()

        Dim conexiones13 As New CConexion
        conexiones13.conexion()
        Dim command13 As SqlCommand = New SqlCommand("DELETE _RIESGO_DEUDAS_CREDITOS WHERE PERFIL ='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "'", conexiones13._conexion)
        conexiones13.abrir()
        Dim reader13 As SqlDataReader = command13.ExecuteReader()
        reader13.Close()





        LboxConsumo.Items.Clear()
        LBoxAdicional.Items.Clear()
        LBoxComercial.Items.Clear()
        LboxEmergencia.Items.Clear()



        Dim cadena As String = txtRut2.Text
        Dim numeros() As String = cadena.Split("-")

        Dim rut As String = numeros(0)







        If lpresocio.Visible = False Then




            Dim conexiones9 As New CConexion
            conexiones9.conexion()
            'Dim command9 As SqlCommand = New SqlCommand(" select s.NROSOCIO from _SOCIOS as s inner join _RIESGO_PRESTAMOS_ULTIMO as p on s.NROSOCIO=p.NROSOCIO  where RUT='" + rut + "' and s.Estado=0 AND P.ADICIONAL=0 AND  P.NROSOCIO>0 AND P.TIPOCREDITO='C' AND DEUDA='SI'", conexiones9._conexion)
            Dim command9 As SqlCommand = New SqlCommand("select corcredito from _prestdiario where nrosocio=" + txtNrosocio2.Text + " and estado ='C' AND RECONSTRU=0 AND  CORCREDITO IN ( SELECT OPERCRED FROM _PRESTAMOS2 where nrosocio=" + txtNrosocio2.Text + "  GROUP BY OPERCRED  HAVING SUM(CARGO-ABONO)>0)", conexiones9._conexion)
            conexiones9.abrir()
            Dim reader9 As SqlDataReader = command9.ExecuteReader()

            If reader9.HasRows Then
                Do While reader9.Read()
                    LboxConsumo.Items.Add(reader9(0).ToString)
                    agregaprestamo(reader9(0).ToString, "Consumo")
                Loop
            Else
            End If

            reader9.Close()


            Dim conexiones6 As New CConexion
            conexiones6.conexion()
            'Dim command6 As SqlCommand = New SqlCommand("select s.NROSOCIO from _SOCIOS as s inner join _RIESGO_PRESTAMOS_ULTIMO as p on s.NROSOCIO=p.NROSOCIO  where RUT='" + rut + "' and s.Estado=0 AND P.TIPOCREDITO='M' AND DEUDA='SI'", conexiones6._conexion)
            Dim command6 As SqlCommand = New SqlCommand("select corcredito from _prestdiario where nrosocio=" + txtNrosocio2.Text + " and estado ='C' AND RECONSTRU=12 AND  CORCREDITO IN ( SELECT OPERCRED FROM _PRESTAMOS2 where nrosocio=" + txtNrosocio2.Text + "  GROUP BY OPERCRED  HAVING SUM(CARGO-ABONO)>0)", conexiones9._conexion)
            conexiones6.abrir()
            Dim reader6 As SqlDataReader = command6.ExecuteReader()

            If reader6.HasRows Then
                Do While reader6.Read()
                    LBoxComercial.Items.Add(reader6(0).ToString)
                    agregaprestamo(reader6(0).ToString, "Comercial")
                Loop
            Else
            End If

            reader6.Close()



            Dim conexiones22 As New CConexion
            conexiones22.conexion()
            'Dim command22 As SqlCommand = New SqlCommand("select s.NROSOCIO from _SOCIOS as s inner join _RIESGO_PRESTAMOS_ULTIMO as p on s.NROSOCIO=p.NROSOCIO  where RUT='" + rut + "' and s.Estado=0 AND P.ADICIONAL<>0 AND P.TIPOCREDITO='C' AND DEUDA='SI'", conexiones22._conexion)
            'Dim command22 As SqlCommand = New SqlCommand("select corcredito from _prestdiario where nrosocio=" + txtNrosocio2.Text + " and estado ='C' AND RECONSTRU=13 AND  CORCREDITO IN ( SELECT OPERCRED FROM _PRESTAMOS2 where nrosocio=" + txtNrosocio2.Text + "  GROUP BY OPERCRED  HAVING SUM(CARGO-ABONO)>0)", conexiones9._conexion)
            Dim command22 As SqlCommand = New SqlCommand("select corcredito from _prestdiario where nrosocio=" + txtNrosocio2.Text + " and estado ='C' AND RECONSTRU in (1,2,3,4,5,6,7,10) AND  CORCREDITO IN ( SELECT OPERCRED FROM _PRESTAMOS2 where nrosocio=" + txtNrosocio2.Text + "  GROUP BY OPERCRED  HAVING SUM(CARGO-ABONO)>0)", conexiones9._conexion)
            conexiones22.abrir()
            Dim reader22 As SqlDataReader = command22.ExecuteReader()

            If reader22.HasRows Then
                Do While reader22.Read()
                    LBoxAdicional.Items.Add(reader22(0).ToString)
                    agregaprestamo(reader22(0).ToString, "Adicional")
                Loop
            Else
            End If
            reader22.Close()



            Dim conexiones1 As New CConexion
            conexiones1.conexion()
            'Dim command1 As SqlCommand = New SqlCommand("select P.NROSOCIO from _SOCIOS as s inner join _RIESGO_PRESTAMOS_ULTIMO as p on (s.NROSOCIO)*-1=p.NROSOCIO  where RUT='" + rut + "'and s.Estado=0 AND P.ADICIONAL=0 AND  P.NROSOCIO<0 AND P.TIPOCREDITO='C' AND DEUDA='SI'", conexiones1._conexion)
            Dim command1 As SqlCommand = New SqlCommand("select corcredito from _prestdiario where nrosocio=" + txtNrosocio2.Text + " and estado ='C' AND RECONSTRU=11 AND  CORCREDITO IN ( SELECT OPERCRED FROM _PRESTAMOS2 where nrosocio=" + txtNrosocio2.Text + "  GROUP BY OPERCRED  HAVING SUM(CARGO-ABONO)>0)", conexiones9._conexion)
            conexiones1.abrir()
            Dim reader1 As SqlDataReader = command1.ExecuteReader()

            If reader1.HasRows Then
                Do While reader1.Read()
                    LboxEmergencia.Items.Add(reader1(0).ToString)
                    agregaprestamo(reader1(0).ToString, "Emergencia")
                Loop
            Else
            End If

            reader1.Close()




        End If





        If LboxConsumo.Items.Count <> 0 Then
            LboxConsumo.SelectedIndex = "0"
        End If
        If LBoxComercial.Items.Count <> 0 Then
            LBoxComercial.SelectedIndex = "0"
        End If
        If LBoxAdicional.Items.Count <> 0 Then
            LBoxAdicional.SelectedIndex = "0"
        End If
        If LboxEmergencia.Items.Count <> 0 Then
            LboxEmergencia.SelectedIndex = "0"
        End If









        'Dim conexiones14 As New CConexion
        'conexiones14.conexion()
        'conexiones14.abrir()
        'Dim cmd14 As New SqlCommand("Riesgo_Actualiza_prepagos", conexiones14._conexion)
        'cmd14.CommandType = CommandType.StoredProcedure
        'Dim dr14 As SqlDataReader = cmd14.ExecuteReader(CommandBehavior.CloseConnection)
        'conexiones14.cerrar()




        'AxAcroPDF1.src = "Z:\_____DICOM HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut2.Text.ToString) + ".pdf"
        ''MsgBox("Z:\_____DICOM HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut2.Text.ToString) + ".pdf")
        'AxAcroPDF1.setZoom(90)

        'AxAcroPDF2.src = "Z:\_____DOCUMENTOS HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut2.Text.ToString) + ".pdf"
        'AxAcroPDF2.setZoom(90)












        'DIGITAL()


        txtCapcid.Text = "La capacidad de pago no debe mayor a 20% o menor 0%"
        If txtFormaPago.Text.Trim = "PLANILLA" Then
            txtPuntaj.Text = "El puntaje debe ser inferior a los -50 puntos"
        Else
            txtPuntaj.Text = "El puntaje debe ser inferior a los -30 puntos"
        End If

        calcular2()

        If (Integer.Parse(Replace(txtCapacidad.Text, "%", "")) > 20 Or Integer.Parse(Replace(txtCapacidad.Text, "%", "")) <= 0) Then
            txtCapcid.ForeColor = Color.Red
        End If

        If txtFormaPago.Text.Trim = "PLANILLA" Then
            If (Double.Parse(txtPuntaje.Text) > -50) Then
                txtPuntaj.ForeColor = Color.Red
            End If
        Else
            If (Double.Parse(txtPuntaje.Text) > -30) Then
                txtPuntaj.ForeColor = Color.Red
            End If
        End If

        'Calcular()

        cargarrentas()

        WriteTextToRichTextBox()

        'plantillas._tabla2.Rows.Clear()
        'plantillas._tabla2.Columns.Clear()

        'If plantillas.Consultar_puntajes2() Then
        '    tabla = plantillas.tabla2
        '    DGPuntajes2.DataSource = tabla
        'End If

    End Sub


    Sub calcular2()

        Dim LVLCORRESPONDIENTE As String = 0

        Dim RL As String = Replace(txtRLP.Text, ".", "")

        Dim conexiones112 As New CConexion
        conexiones112.conexion()
        Dim command112 As SqlCommand = New SqlCommand("SELECT TIPO FROM _RIESGO_LEVERAGE where CONVERT(INT,'" + RL + "')>=CONVERT(INT,MONTO1) AND CONVERT(INT,'" + RL + "')<=CONVERT(INT,MONTO2) ", conexiones112._conexion)
        conexiones112.abrir()
        Dim reader112 As SqlDataReader = command112.ExecuteReader()

        If reader112.HasRows Then
            Do While reader112.Read()

                txtLvl.Text = "El RPL debe ser inferior a " + (reader112(0).ToString)

                If (Integer.Parse(txtLeverage.Text) > Integer.Parse((reader112(0).ToString))) Then
                    txtLvl.ForeColor = Color.Red
                End If


            Loop
        Else
        End If

        reader112.Close()

    End Sub

    Function agregaprestamo(ByVal PRESTAMO As String, ByVal TIPO As String) As String

        Dim conexiones7 As New CConexion
        conexiones7.conexion()
        Dim command7 As SqlCommand = New SqlCommand("INSERT INTO _RIESGO_DEUDAS_CREDITOS (prestamo, tipo , perfil) values ('" + PRESTAMO + "','" + TIPO + "','" + frmPerfil.CbmUsuario.SelectedItem.ToString + "')", conexiones7._conexion)
        conexiones7.abrir()
        Dim reader7 As SqlDataReader = command7.ExecuteReader()
        reader7.Close()
        Return ("REALIZADO CON EXITO")
        conexiones7.cerrar()
    End Function

    Sub enviar()



        Dim Datos As New CDatos()
        Dim USUARIO As String
        Dim Contrasena As String = ""
        Dim Departamento As String = ""
        Dim CONTINUA As String = "SI"

        USUARIO = frmPerfil.CbmUsuario.SelectedItem
        If (CboAprobar.SelectedItem = "SI CONDICIONAL") Then
            Datos._Condicional = txtCondicion.Text
        End If
        If (CboAprobar.SelectedItem = "RECOMIENDO CONDICIONAL") Then
            Datos._Condicional_R = txtCondicion2.Text
        End If



        If (CboAprobar.SelectedItem = "SI" And txtCondicion2.Text <> "") Then
            Dim RECIBERESPUESTA As DialogResult
            RECIBERESPUESTA = MessageBox.Show("Desea aprobar el credito SIN LA CONDICIÓN del Departamento de Riesgo?", "CONDICION DE RIESGO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If RECIBERESPUESTA = Windows.Forms.DialogResult.Yes Then
                CONTINUA = "SI"
            Else
                MsgBox("Cancelado, favor aceptar las condiciones o generar una nueva")
                CONTINUA = "NO"
                CboAprobar.SelectedItem = "SI CONDICIONAL"
            End If
        Else
            CONTINUA = "SI"
        End If



        Datos._id_solicitud = txtCodigoId.Text.ToString


        'If (CboAprobar.SelectedItem = "SI" And txtCondicion2.Text.Length <= 0) Then

        'End If
        'MsgBox("Se debe generar alguna condición")




        If CONTINUA = "SI" Then


            If (CboAprobar.SelectedItem = "RECOMIENDO CONDICIONAL" And txtCondicion2.Text.Length <= 0) Then
                MsgBox("Se debe generar alguna condición")
            ElseIf (CboAprobar.SelectedItem = "SI CONDICIONAL" And txtCondicion.Text.Length <= 0) Then
                MsgBox("Se debe generar alguna condición")

            ElseIf CboAprobar.SelectedItem = "LIBERADO CON OBJECIONES" And (txtComentarioAgente.Text.Length <= 0 Or cboTipologiasDeObjeciones.SelectedItem.ToString.Trim = "Sin Objeciones") Then

                MsgBox("Se debe agregar algún comentario y tipo de objeción")

            ElseIf CboAprobar.SelectedItem = "NO LIBERADO" And (txtComentarioAgente.Text.Length <= 0 Or cboTipologiasDeObjeciones.SelectedItem.ToString.Trim = "Sin Objeciones") Then

                MsgBox("Se debe agregar algún comentario y tipo")

            ElseIf CboAprobar.SelectedItem = "SI CONDICIONAL" And txtCondicion.Text.Length > 260 Then
                MsgBox("La condición sobrepasa los 260 caracteres")

            Else


                If CboAprobar.SelectedItem = "" Then

                    MsgBox("Debe selecionar una opción de Analisis")

                Else

                    If txtContrasena.Text = "" Then

                        MsgBox("Debe indicar contraseña de seguridad")

                    Else


                        Dim conexiones2 As New CConexion
                        conexiones2.conexion()
                        Dim command2 As SqlCommand = New SqlCommand("SELECT dbo.FU_DESENCRIPTA(ENSUPERCONTRASENA),CARGO FROM _RIESGO_PERFIL WHERE USUARIO='" + USUARIO.ToString.Trim + "'", conexiones2._conexion)
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







                        If Contrasena.ToString.Trim = txtContrasena.Text.Trim Then


                            Dim Plantillas As New CCEstadosGeneral




                            Dim operaciones_aprueba As String = ""
                            Dim operaciones_perfil As String = ""
                            Dim subgerencia_aprueba As String = ""
                            Dim subgerencia_perfil As String = ""
                            Dim gerencia_aprueba As String = ""
                            Dim gerencia_perfil As String = ""
                            Dim cci_aprueba As String = ""
                            Dim cci_perfil As String = ""
                            Dim ccs_aprueba As String = ""
                            Dim ccs_perfil As String = ""
                            Dim pre_agencia_aprueba As String = ""
                            Dim pre_agencia_perfil As String = ""
                            Dim riesgo_aprueba As String = ""
                            Dim riesgo_perfil As String = ""


                            If (CboAprobar.SelectedItem = "SI CONDICIONAL") Then
                                Datos._Condicion_Tasa = ""
                                Datos._Condicion_Monto = ""
                                Datos._Condicion_Plazo = ""

                                If chkTasa.Checked = True Then
                                    Datos._Condicion_Tasa = cboTasaSolicitada4.SelectedItem.ToString.Trim
                                End If
                                If chkMonto.Checked = True Then
                                    Datos._Condicion_Monto = txtmontosolicitado4.Text.ToString.Trim
                                End If
                                If chkPlazo.Checked = True Then
                                    Datos._Condicion_Plazo = txtPlazoSolicitado4.Text.ToString.Trim
                                End If

                            End If


                            If (CboAprobar.SelectedItem = "RECOMIENDO CONDICIONAL") Then
                                Datos._Condicion_Tasa = ""
                                Datos._Condicion_Monto = ""
                                Datos._Condicion_Plazo = ""

                                If chkTasa2.Checked = True Then
                                    Datos._Condicion_Tasa_R = cboTasaSolicitada5.SelectedItem.ToString.Trim
                                End If
                                If chkMonto2.Checked = True Then
                                    Datos._Condicion_Monto_R = txtmontosolicitado5.Text.ToString.Trim
                                End If
                                If chkPlazo2.Checked = True Then
                                    Datos._Condicion_Plazo_R = txtPlazoSolicitado5.Text.ToString.Trim
                                End If

                            End If




                            Dim conexiones3 As New CConexion
                            conexiones3.conexion()

                            Dim command3 As SqlCommand = New SqlCommand("SELECT [Aprobacion_Operaciones],[Agencia_Perfil],[Aprobacion_SubGerencia],[Subgerencia_Perfil],[Aprobacion_Gerencia],[Gerencia_Perfil],[Aprobacion_Comision_Credito_Interno],[CCI_Perfil],[Aprobacion_Comision_Credito_Superior],[CCS_perfil],[PreAprobacion_Agente],[PreAgencia_Perfil],[PreAprobacion_Riesgo],[Riesgo_Perfil] FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where [id_solicitud]='" + Datos._id_solicitud.ToString.Trim + "'", conexiones3._conexion)
                            conexiones3.abrir()

                            Dim reader3 As SqlDataReader = command3.ExecuteReader()


                            If reader3.HasRows Then
                                Do While reader3.Read()

                                    operaciones_aprueba = Trim(reader3(0).ToString)
                                    operaciones_perfil = Trim(reader3(1).ToString)
                                    subgerencia_aprueba = Trim(reader3(2).ToString)
                                    subgerencia_perfil = Trim(reader3(3).ToString)
                                    gerencia_aprueba = Trim(reader3(4).ToString)
                                    gerencia_perfil = Trim(reader3(5).ToString)
                                    cci_aprueba = Trim(reader3(6).ToString)
                                    cci_perfil = Trim(reader3(7).ToString)
                                    ccs_aprueba = Trim(reader3(8).ToString)
                                    ccs_perfil = Trim(reader3(9).ToString)
                                    pre_agencia_aprueba = Trim(reader3(10).ToString)
                                    pre_agencia_perfil = Trim(reader3(11).ToString)
                                    riesgo_aprueba = Trim(reader3(12).ToString)
                                    riesgo_perfil = Trim(reader3(13).ToString)
                                Loop
                            Else
                            End If

                            reader3.Close()

                            If Trim(Departamento) = "GERENTE" Then

                                If (gerencia_aprueba.ToString = "Por Analizar") Then

                                    If (txtComentarioGerente2.Text.Length > 450) Then

                                        MsgBox("El comentario sobrepasa los 450 caracteres")
                                    Else
                                        Datos._Comentario_Gerencia = txtComentarioGerente2.Text
                                        Datos._Aprobacion_Gerencia = CboAprobar.SelectedItem.ToString
                                        Datos._Gerente_Perfil = frmPerfil.CbmUsuario.SelectedItem


                                        If Plantillas.Actualizar_Prestamo_enviado_APROBAR_GERENCIA(Datos) Then

                                            MsgBox("Credito Actualizado Con exito")

                                            Dim conexiones1 As New CConexion
                                            conexiones1.conexion()
                                            conexiones1.abrir()
                                            Dim cmd1 As New SqlCommand("Riesgo_Aprobar_Rechazar", conexiones1._conexion)
                                            Dim dr1 As SqlDataReader = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                                            conexiones1.cerrar()

                                            frmCreditosPorAprobar.vercreditos()
                                            'Dim plantillas2 As Metodos = New Metodos
                                            'Dim tabla As New DataTable

                                            'plantillas2._tabla.Rows.Clear()
                                            'plantillas2._tabla.Columns.Clear()

                                            'If plantillas2.Consultar_Creditos_AprobarXGerencia Then
                                            '    tabla = plantillas2.tabla
                                            '    frmCreditosPorAprobar.DGreditosAprobar.DataSource = tabla
                                            'End If
                                            'frmCreditosPorAprobar.CheckBox1.Checked = False
                                            Me.Close()

                                        Else
                                            MessageBox.Show("Error al consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        End If

                                    End If

                                Else

                                    MsgBox("Este credito ya fue analizado por :" + gerencia_perfil.ToString)
                                    frmCreditosPorAprobar.CheckBox1.Checked = False
                                    Me.Close()


                                End If



                            ElseIf Trim(Departamento) = "SUBGERENTE" Or Trim(Departamento) = "SUBGENRENTE" Then

                                If (subgerencia_aprueba.ToString = "Por Analizar") Then

                                    If (txtComentarioSubGerente.Text.Length > 450) Then

                                        MsgBox("El comentario sobrepasa los 450 caracteres")
                                    Else
                                        Datos._Comentario_Subgerencia = txtComentarioSubGerente.Text
                                        Datos._Aprobacion_SubGerencia = CboAprobar.SelectedItem.ToString
                                        Datos._Subgerente_Perfil = frmPerfil.CbmUsuario.SelectedItem
                                        Datos._Comentario_Gerencia = txtComentarioGerente2.Text
                                        Datos._Aprobacion_Gerencia = CboAprobar.SelectedItem.ToString
                                        Datos._Gerente_Perfil = frmPerfil.CbmUsuario.SelectedItem

                                        If Plantillas.Actualizar_Prestamo_enviado_APROBAR_SUBGERENCIA(Datos) Then

                                            If ChkSustituir.Checked = False Then
                                                MsgBox("Credito Actualizado Con exito")
                                            Else
                                                If Plantillas.Actualizar_Prestamo_enviado_APROBAR_GERENCIA(Datos) Then

                                                    MsgBox("Credito Actualizado Con exito")
                                                End If

                                            End If

                                            Dim conexiones1 As New CConexion
                                            conexiones1.conexion()
                                            conexiones1.abrir()
                                            Dim cmd1 As New SqlCommand("Riesgo_Aprobar_Rechazar", conexiones1._conexion)
                                            Dim dr1 As SqlDataReader = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                                            conexiones1.cerrar()
                                            frmCreditosPorAprobar.vercreditos()
                                            'Dim plantillas2 As Metodos = New Metodos
                                            'Dim tabla As New DataTable

                                            'plantillas2._tabla.Rows.Clear()
                                            'plantillas2._tabla.Columns.Clear()

                                            'If plantillas2.Consultar_Creditos_AprobarXSubGerencia Then
                                            '    tabla = plantillas2.tabla
                                            '    frmCreditosPorAprobar.DGreditosAprobar.DataSource = tabla
                                            'End If
                                            'frmCreditosPorAprobar.CheckBox1.Checked = False
                                            Me.Close()


                                        Else
                                            MessageBox.Show("Error al consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        End If

                                    End If

                                Else

                                    MsgBox("Este credito ya fue analizado por :" + subgerencia_perfil.ToString)
                                    frmCreditosPorAprobar.CheckBox1.Checked = False
                                    Me.Close()
                                End If





                            ElseIf Trim(Departamento) = "RIESGO_RENTA" Then
                                Datos._Aprobacion_Riesgo = CboAprobar.SelectedItem.ToString
                                If Plantillas.Actualizar_Prestamo_enviado_Riesgo_Renta(Datos) Then
                                    MsgBox("Estado Renta Actualizado con exito")
                                    frmCreditosPorAprobar.vercreditos()
                                    Me.Close()

                                Else
                                    MessageBox.Show("Error al consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If








                            ElseIf Trim(Departamento) = "RIESGO" Then

                                    If (riesgo_aprueba.ToString.Trim = "Por Analizar") Then

                                        If (txtComentarioRiesgo.Text.Length > 450) Then
                                            MsgBox("El comentario sobrepasa los 450 caracteres")
                                        Else
                                            If (Trim(txtComentarioRiesgo.Text) = "") Then
                                                MsgBox("Se debe agregar un COMENTARIO antes de enviar")
                                            Else
                                                Datos._Comentario_Riesgo = txtComentarioRiesgo.Text
                                                Datos._Aprobacion_Riesgo = CboAprobar.SelectedItem.ToString
                                                Datos._Riesgo_Perfil = frmPerfil.CbmUsuario.SelectedItem

                                                If Trim(CboAprobar.SelectedItem.ToString.Trim) = "RECOMIENDO" Then
                                                    Datos._Estado = "Enviado por Dep.riesgo como RECOMENDADO"
                                                    txtCondicion2.Text = ""
                                                ElseIf Trim(CboAprobar.SelectedItem.ToString.Trim) = "RECOMIENDO CONDICIONAL" Then
                                                    Datos._Estado = "Enviado por Dep.riesgo como RECOMENDADO CONDICIONAL"

                                                ElseIf Trim(CboAprobar.SelectedItem.ToString.Trim) = "NO RECOMIENDO" Then
                                                    Datos._Estado = "Enviado por Dep.riesgo como NO RECOMENDADO"
                                                    txtCondicion2.Text = ""
                                                Else
                                                    Datos._Estado = "DESCARTADO"
                                                    txtCondicion2.Text = ""
                                                End If

                                                Datos._PreAprobacion_Riesgo = Trim(CboAprobar.SelectedItem.ToString)


                                                If Plantillas.Actualizar_Prestamo_enviado_Riesgo(Datos) Then

                                                    MsgBox("Credito Actualizado Con exito")


                                                    Dim conexiones1 As New CConexion
                                                    conexiones1.conexion()
                                                    conexiones1.abrir()
                                                    Dim cmd1 As New SqlCommand("Riesgo_Aprobar_Rechazar", conexiones1._conexion)
                                                    Dim dr1 As SqlDataReader = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                                                    conexiones1.cerrar()



                                                    'Dim plantillas2 As Metodos = New Metodos
                                                    'Dim tabla As New DataTable

                                                    'plantillas2._tabla.Rows.Clear()
                                                    'plantillas2._tabla.Columns.Clear()

                                                    'If plantillas2.Consultar_Creditos_Aprobar Then
                                                    '    tabla = plantillas2.tabla
                                                    '    frmCreditosPorAprobar.DGreditosAprobar.DataSource = tabla
                                                    'End If
                                                    'frmCreditosPorAprobar.CheckBox1.Checked = False
                                                    frmCreditosPorAprobar.vercreditos()
                                                    Me.Close()

                                                Else
                                                    MessageBox.Show("Error al consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End If
                                            End If
                                        End If

                                    Else

                                        MsgBox("Este credito ya fue analizado por :" + riesgo_perfil.ToString)
                                        frmCreditosPorAprobar.CheckBox1.Checked = False

                                        Me.Close()
                                    End If

                                    'If Trim(CbEstado.SelectedItem.ToString) = "Enviar para aprobación" Then
                                    '    Datos._Estado = "Enviado por Dep.riesgo como RECOMENDADO"
                                    'ElseIf Trim(CbEstado.SelectedItem.ToString) = "Enviar como no recomendado" Then
                                    '    Datos._Estado = "Enviado por Dep.riesgo como NO RECOMENDADO"
                                    'Else
                                    '    Datos._Estado = "DESCARTADO"
                                    'End If



                                    'Datos._PreAprobacion_Riesgo = Trim(CbEstado.SelectedItem.ToString)


                                    'If Plantillas.Actualizar_Prestamo_enviado_Riesgo(Datos) Then

                                    '    MsgBox("Credito Actualizado Con exito")
                                    '    Dim plantillas2 As Metodos = New Metodos
                                    '    Dim tabla As New DataTable
                                    '    plantillas2._tabla.Rows.Clear()
                                    '    plantillas2._tabla.Columns.Clear()



                                    '    If plantillas2.Consultar_Creditos_Riesgo Then
                                    '        tabla = plantillas2.tabla
                                    '        frmCreditosRiesgo.DGreditosRiesgo.DataSource = tabla
                                    '    End If
                                    '    Me.Close()

                                ElseIf Trim(Departamento) = "AGENCIA" Then

                                    If txtValidacionAgente.Text = "Por Analizar" Then

                                        If (pre_agencia_aprueba.ToString.Trim = "Por Analizar") Then

                                            If (txtComentarioAgente.Text.Length > 450) Then
                                                MsgBox("El comentario sobrepasa los 450 caracteres")
                                            Else
                                                Datos._Comentario_Pre_Agencia = txtComentarioAgente.Text
                                                Datos._Aprobacion_Pre_Agencia = CboAprobar.SelectedItem.ToString
                                                Datos._Pre_Agencia_Perfil = frmPerfil.CbmUsuario.SelectedItem
                                                Datos._Comentario_Pre_Agencia_Tipo = cboTipologiasDeObjeciones.SelectedItem.ToString.Trim
                                                If riesgo_aprueba = "Por Analizar" Then
                                                    Datos._Estado = "Enviado a Riesgo"
                                                Else
                                                    Datos._Estado = "Enviado de Ejecutivos para aprobación"
                                                End If

                                                If Plantillas.Actualizar_Prestamo_enviado_APROBAR_PREAGENTE(Datos) Then

                                                    MsgBox("Credito Actualizado Con exito")


                                                    Dim conexiones1 As New CConexion
                                                    conexiones1.conexion()
                                                    conexiones1.abrir()
                                                    Dim cmd1 As New SqlCommand("Riesgo_Aprobar_Rechazar", conexiones1._conexion)
                                                    Dim dr1 As SqlDataReader = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                                                    conexiones1.cerrar()



                                                    'Dim plantillas2 As Metodos = New Metodos
                                                    'Dim tabla As New DataTable

                                                    'plantillas2._tabla.Rows.Clear()
                                                    'plantillas2._tabla.Columns.Clear()

                                                    'If plantillas2.Consultar_Creditos_Aprobar Then
                                                    '    tabla = plantillas2.tabla
                                                    '    frmCreditosPorAprobar.DGreditosAprobar.DataSource = tabla
                                                    'End If
                                                    'frmCreditosPorAprobar.CheckBox1.Checked = False
                                                    frmCreditosPorAprobar.vercreditos()
                                                    Me.Close()

                                                Else
                                                    MessageBox.Show("Error al consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End If
                                            End If

                                        Else

                                            MsgBox("Este credito ya fue analizado por :" + pre_agencia_perfil.ToString)
                                            frmCreditosPorAprobar.CheckBox1.Checked = False

                                            Me.Close()
                                        End If

                                    Else


                                        If (operaciones_aprueba.ToString = "Por Analizar") Then
                                            If (txtComentarioAgencia.Text.Length > 450) Then
                                                MsgBox("El comentario sobrepasa los 450 caracteres")
                                            Else
                                                Datos._Comentario_Agencia = txtComentarioAgencia.Text
                                                Datos._Aprobacion_Operaciones = CboAprobar.SelectedItem.ToString
                                                Datos._Agencia_Perfil = frmPerfil.CbmUsuario.SelectedItem

                                                If Plantillas.Actualizar_Prestamo_enviado_APROBAR_OPERACIONES(Datos) Then

                                                    MsgBox("Credito Actualizado Con exito")


                                                    Dim conexiones1 As New CConexion
                                                    conexiones1.conexion()
                                                    conexiones1.abrir()
                                                    Dim cmd1 As New SqlCommand("Riesgo_Aprobar_Rechazar", conexiones1._conexion)
                                                    Dim dr1 As SqlDataReader = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                                                    conexiones1.cerrar()

                                                    frmCreditosPorAprobar.vercreditos()
                                                    Me.Close()

                                                    'Dim plantillas2 As Metodos = New Metodos
                                                    'Dim tabla As New DataTable

                                                    'plantillas2._tabla.Rows.Clear()
                                                    'plantillas2._tabla.Columns.Clear()

                                                    'If plantillas2.Consultar_Creditos_Aprobar Then
                                                    '    tabla = plantillas2.tabla
                                                    '    frmCreditosPorAprobar.DGreditosAprobar.DataSource = tabla
                                                    'End If
                                                    'frmCreditosPorAprobar.CheckBox1.Checked = False
                                                    'Me.Close()

                                                Else
                                                    MessageBox.Show("Error al consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End If
                                            End If

                                        Else

                                            MsgBox("Este credito ya fue analizado por :" + operaciones_perfil.ToString)
                                            frmCreditosPorAprobar.CheckBox1.Checked = False

                                            Me.Close()
                                        End If
                                    End If

                                ElseIf Trim(Departamento) = "COMISIONI" Then

                                    If (cci_aprueba.ToString = "Por Analizar") Then



                                        Datos._Aprobacion_Comision_Credito_Interno = CboAprobar.SelectedItem.ToString
                                        Datos._CCI_Perfil = frmPerfil.CbmUsuario.SelectedItem

                                        If Plantillas.Actualizar_Prestamo_enviado_APROBAR_CCI(Datos) Then

                                            MsgBox("Credito Actualizado Con exito")

                                            Dim conexiones1 As New CConexion
                                            conexiones1.conexion()
                                            conexiones1.abrir()
                                            Dim cmd1 As New SqlCommand("Riesgo_Aprobar_Rechazar", conexiones1._conexion)
                                            Dim dr1 As SqlDataReader = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                                            conexiones1.cerrar()
                                            frmCreditosPorAprobar.vercreditos()
                                            'Dim plantillas2 As Metodos = New Metodos
                                            'Dim tabla As New DataTable

                                            'plantillas2._tabla.Rows.Clear()
                                            'plantillas2._tabla.Columns.Clear()

                                            'If plantillas2.Consultar_Creditos_AprobarXCCI Then
                                            '    tabla = plantillas2.tabla
                                            '    frmCreditosPorAprobar.DGreditosAprobar.DataSource = tabla
                                            'End If
                                            'frmCreditosPorAprobar.CheckBox1.Checked = False
                                            Me.Close()

                                        Else
                                            MessageBox.Show("Error al consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        End If



                                    Else

                                        MsgBox("Este credito ya fue analizado por :" + cci_perfil.ToString)
                                        frmCreditosPorAprobar.CheckBox1.Checked = False
                                        Me.Close()
                                    End If

                                ElseIf Trim(Departamento) = "COMISIONS" Then

                                    If (ccs_aprueba.ToString = "Por Analizar") Then



                                        Datos._Aprobacion_Comision_Credito_Superior = CboAprobar.SelectedItem.ToString
                                        Datos._CCS_Perfil = frmPerfil.CbmUsuario.SelectedItem


                                        'MsgBox(Datos._Aprobacion_Comision_Credito_Superior)
                                        'MsgBox(Datos._CCS_Perfil)


                                        If Plantillas.Actualizar_Prestamo_enviado_APROBAR_CCS(Datos) Then

                                            MsgBox("Credito Actualizado Con exito")

                                            Dim conexiones1 As New CConexion
                                            conexiones1.conexion()
                                            conexiones1.abrir()
                                            Dim cmd1 As New SqlCommand("Riesgo_Aprobar_Rechazar", conexiones1._conexion)
                                            Dim dr1 As SqlDataReader = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                                            conexiones1.cerrar()
                                            frmCreditosPorAprobar.vercreditos()
                                            'Dim plantillas2 As Metodos = New Metodos
                                            'Dim tabla As New DataTable

                                            'plantillas2._tabla.Rows.Clear()
                                            'plantillas2._tabla.Columns.Clear()

                                            'If plantillas2.Consultar_Creditos_AprobarXCCS Then
                                            '    tabla = plantillas2.tabla
                                            '    frmCreditosPorAprobar.DGreditosAprobar.DataSource = tabla
                                            'End If
                                            'frmCreditosPorAprobar.CheckBox1.Checked = False
                                            Me.Close()
                                        Else
                                            MessageBox.Show("Error al consultar CS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        End If

                                    End If

                                Else

                                    MsgBox("Este credito ya fue analizado por :" + ccs_perfil.ToString)
                                frmCreditosPorAprobar.CheckBox1.Checked = False
                                Me.Close()
                            End If

                        Else
                            MsgBox("Contraseña incorrecta")

                        End If

                    End If

                End If

            End If
        End If







    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click



        enviar()




    End Sub



    Private Sub txtComentarioGerente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComentarioGerente2.KeyUp, txtComentarioGerente2.KeyUp
        txtGerente.Text = 450 - (txtComentarioGerente2.Text.Length)
    End Sub

    Private Sub txtComentarioSubGerente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComentarioSubGerente.KeyUp
        txtSubgerente.Text = 450 - (txtComentarioSubGerente.Text.Length)
    End Sub

    Private Sub txtComentarioAgencia_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComentarioAgencia.KeyUp
        txtAgencia.Text = 450 - (txtComentarioAgencia.Text.Length)
    End Sub

    'Private Sub txtComentarioAgencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComentarioAgencia.TextChanged
    '    txtAgencia.Text = 250 - (txtComentarioAgencia.Text.Length)
    'End Sub


    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    frmCreditosPorAprobar.CheckBox1.Checked = False
    '    Me.Close()
    'End Sub

    Private Sub Calcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calcular.Click









        ''TxtMonto3.Text = Replace(TxtMonto3.Text, ".", "")
        ''txtMonto4.Text = Replace(txtMonto4.Text, ".", "")

        ''texto = ""

        ''Try


        ''    If (TxtMonto3.Text = "") Then
        ''        MsgBox("Se debe agregar un monto")
        ''    Else
        ''        If (txtPlazo3.Text = "") Then
        ''            MsgBox("Se debe agregar un plazo")
        ''        Else

        ''            If (Integer.Parse(txtMonto4.Text) > Integer.Parse(TxtMonto3.Text)) Then
        ''                MsgBox("El monto del prepago no puede ser mayor al monto solicitado")
        ''            Else





        ''                Me.DgAmortizacion.Rows.Clear()

        ''                Dim monto As Integer = Integer.Parse(TxtMonto3.Text)
        ''                Dim interes As Double = txtTasa2.Text / 100
        ''                Dim diasgracia As Integer = Integer.Parse(txtDiasGracia2.Text)
        ''                Dim plazo As Integer = Integer.Parse(txtPlazo3.Text)



        ''                Dim Cargodiasdegracia As Integer = Decimal.Round(((monto * interes) * diasgracia) / 30)
        ''                Dim InteresAplicado As Integer = Decimal.Round(plazo * (monto + Cargodiasdegracia) * (1 / ((((1 - (1 / ((1 + (interes)) ^ plazo)))) / (interes)))) - (monto + Cargodiasdegracia))
        ''                Dim InteresAplicadoder1 As Integer = Decimal.Round(plazo * (Cargodiasdegracia) * (1 / ((((1 - (1 / ((1 + (interes)) ^ plazo)))) / (interes)))) - (Cargodiasdegracia))
        ''                Dim InteresAplicadoder2 As Integer = Decimal.Round((Cargodiasdegracia + InteresAplicadoder1) / plazo)

        ''                Dim SaldoPrestamo As Integer = Decimal.Round(monto + Cargodiasdegracia + InteresAplicado)
        ''                Dim Dividendo As Integer = Decimal.Round((monto + Cargodiasdegracia + InteresAplicado) / plazo)
        ''                Dim InteresTabla As Integer = Decimal.Round((monto * interes) + InteresAplicadoder2)
        ''                Dim Capital As Integer = Decimal.Round(Dividendo - InteresTabla)
        ''                Dim SaldoMonto As Integer = Decimal.Round(monto - Capital)

        ''                txtCuota3.Text = Format(Integer.Parse(Dividendo), "#,##0")


        ''                'Cargodiasdegracia = ((Integer.Parse(TxtMonto.Text) * interes) * Integer.Parse(CboDiasdeGracia.SelectedItem)) / 30
        ''                'Cargodiasdegracia = ((Integer.Parse(TxtMonto.Text) * interes) * Integer.Parse(CboDiasdeGracia.SelectedItem)) / 30
        ''                'Dim montogracia As Integer
        ''                'TxtCuota.Text = Decimal.Round((Integer.Parse(TxtMonto.Text) + diasdegracia) * ((interes * (1 + interes) ^ Integer.Parse(CboCuotas.SelectedItem)) / ((1 + interes) ^ Integer.Parse(CboCuotas.SelectedItem) - 1)))
        ''                'montogracia = Decimal.Round(Integer.Parse(TxtMonto.Text) + diasdegracia)



        ''                For i = 1 To Integer.Parse(plazo)
        ''                    Me.DgAmortizacion.Rows.Add()
        ''                Next

        ''                Dim nrocuotas As Integer = 1

        ''                For i = 0 To (Integer.Parse(plazo) - 1)

        ''                    DgAmortizacion.Rows(i).Cells(0).Value() = nrocuotas
        ''                    DgAmortizacion.Rows(i).Cells(1).Value() = txtCuota3.Text
        ''                    nrocuotas = nrocuotas + 1

        ''                Next



        ''                'CAPITAL
        ''                DgAmortizacion.Rows(0).Cells(2).Value() = Capital
        ''                'INTERES
        ''                DgAmortizacion.Rows(0).Cells(3).Value() = InteresTabla
        ''                'DEUDA
        ''                DgAmortizacion.Rows(0).Cells(4).Value() = SaldoMonto
        ''                'saldo prestamo
        ''                DgAmortizacion.Rows(0).Cells(5).Value() = SaldoPrestamo


        ''                ''CAPITAL
        ''                'DgAmortizacion.Rows(0).Cells(2).Value() = DgAmortizacion.Rows(0).Cells(1).Value() - DgAmortizacion.Rows(0).Cells(3).Value()
        ''                ''INTERES
        ''                'DgAmortizacion.Rows(0).Cells(3).Value() = Decimal.Round(montogracia * interes)
        ''                ''DEUDA
        ''                'DgAmortizacion.Rows(0).Cells(4).Value() = Decimal.Round(Integer.Parse(montogracia) - DgAmortizacion.Rows(0).Cells(2).Value())

        ''                Dim v As Integer = 0

        ''                For i = 1 To (Integer.Parse(txtPlazo3.Text) - 1)

        ''                    DgAmortizacion.Rows(i).Cells(5).Value() = Decimal.Round(DgAmortizacion.Rows(v).Cells(5).Value()) - Decimal.Round(DgAmortizacion.Rows(v).Cells(1).Value())
        ''                    DgAmortizacion.Rows(i).Cells(3).Value() = Decimal.Round(((Decimal.Round(DgAmortizacion.Rows(v).Cells(4).Value())) * interes) + InteresAplicadoder2)
        ''                    DgAmortizacion.Rows(i).Cells(2).Value() = Decimal.Round(DgAmortizacion.Rows(i).Cells(1).Value()) - Decimal.Round(DgAmortizacion.Rows(i).Cells(3).Value())
        ''                    DgAmortizacion.Rows(i).Cells(4).Value() = Decimal.Round(DgAmortizacion.Rows(v).Cells(4).Value()) - Decimal.Round(DgAmortizacion.Rows(i).Cells(2).Value())

        ''                    'DgAmortizacion.Rows(i).Cells(2).Value() = DgAmortizacion.Rows(i).Cells(1).Value() - DgAmortizacion.Rows(i).Cells(3).Value()
        ''                    'DgAmortizacion.Rows(i).Cells(4).Value() = Decimal.Round(DgAmortizacion.Rows(v).Cells(4).Value() - DgAmortizacion.Rows(i).Cells(2).Value())
        ''                    v = v + 1

        ''                Next

        ''                DgAmortizacion.Rows(Integer.Parse(plazo) - 1).Cells(1).Value() = Integer.Parse(Replace(txtCuota3.Text, ".", "")) + DgAmortizacion.Rows(Integer.Parse(plazo) - 1).Cells(4).Value()
        ''                DgAmortizacion.Rows(Integer.Parse(plazo) - 1).Cells(4).Value() = 0




        ''                'TxtMonto3.Text = Format(Integer.Parse(TxtMonto3.Text), "#,##0")



        ''                'Catch ex As Exception

        ''                '    MsgBox(ex.Message)
        ''                '    'MsgBox("No deben estar los campos en blanco")
        ''                'End Try
        ''            End If
        ''        End If
        ''    End If



        ''    Dim conexiones14 As New CConexion
        ''    conexiones14.conexion()
        ''    conexiones14.abrir()
        ''    Dim cmd14 As New SqlCommand("Riesgo_prestamo_deudas3", conexiones14._conexion)
        ''    cmd14.CommandType = CommandType.StoredProcedure
        ''    Dim prm2 As SqlParameter = _
        ''        New SqlParameter("@PERFIL", SqlDbType.NChar, 30)
        ''    cmd14.Parameters.Add(prm2)
        ''    With cmd14
        ''        .Parameters("@PERFIL").Value = frmPerfil.CbmUsuario.SelectedItem
        ''    End With
        ''    Dim dr14 As SqlDataReader = cmd14.ExecuteReader(CommandBehavior.CloseConnection)
        ''    conexiones14.cerrar()




        ''    Dim conexiones8 As New CConexion
        ''    conexiones8.conexion()
        ''    Dim command8 As SqlCommand = New SqlCommand(" if exists (SELECT * FROM _RIESGO_DEUDAS_CREDITOS where tipo in ('Consumo','Emergencia','Adicional') and Estado='Normal' AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "') SELECT sum(deuda) FROM _RIESGO_DEUDAS_CREDITOS where tipo in ('Consumo','Emergencia','Adicional') and Estado='Normal' AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "' else select 0", conexiones8._conexion)
        ''    conexiones8.abrir()
        ''    Dim reader8 As SqlDataReader = command8.ExecuteReader()

        ''    If reader8.HasRows Then
        ''        Do While reader8.Read()
        ''            txtInternaDeudaConsumo.Text = Integer.Parse((reader8(0).ToString))
        ''        Loop
        ''    Else
        ''    End If

        ''    reader8.Close()


        ''    Dim conexiones9 As New CConexion
        ''    conexiones9.conexion()
        ''    Dim command9 As SqlCommand = New SqlCommand(" if exists(SELECT * FROM _RIESGO_DEUDAS_CREDITOS where tipo in ('Comercial') and Estado='Normal' AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "') SELECT sum(deuda) FROM _RIESGO_DEUDAS_CREDITOS where tipo in ('Comercial') and Estado='Normal' AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "' else select 0", conexiones9._conexion)
        ''    conexiones9.abrir()
        ''    Dim reader9 As SqlDataReader = command9.ExecuteReader()

        ''    If reader9.HasRows Then
        ''        Do While reader9.Read()
        ''            txtInternaDeudaComercial.Text = Integer.Parse(reader9(0).ToString)
        ''        Loop
        ''    Else
        ''    End If
        ''    reader9.Close()

        ''    txtInternaTotalDeuda.Text = Integer.Parse(txtInternaDeudaComercial.Text) + Integer.Parse(txtInternaDeudaConsumo.Text)

        ''    Dim conexiones2 As New CConexion
        ''    conexiones2.conexion()
        ''    Dim command2 As SqlCommand = New SqlCommand(" if exists (SELECT * FROM _RIESGO_DEUDAS_CREDITOS where Estado='Normal' AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "') SELECT sum(cuota) FROM _RIESGO_DEUDAS_CREDITOS where  Estado='Normal'  AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "' else select 0", conexiones2._conexion)
        ''    conexiones2.abrir()
        ''    Dim reader2 As SqlDataReader = command2.ExecuteReader()

        ''    If reader2.HasRows Then
        ''        Do While reader2.Read()
        ''            txtInternaPagoMensual.Text = Integer.Parse(reader2(0).ToString)
        ''        Loop
        ''    Else
        ''    End If
        ''    reader2.Close()


        ''    Dim conexiones3 As New CConexion
        ''    conexiones3.conexion()
        ''    Dim command3 As SqlCommand = New SqlCommand("if exists ( SELECT * FROM _RIESGO_PRESTAMOS_ULTIMO WHERE AVAL1='" + txtRut.Text + "' OR AVAL2='" + txtRut.Text + "') SELECT SUM(MONTO_DEUDA) FROM _RIESGO_PRESTAMOS_ULTIMO WHERE AVAL1='" + txtRut.Text + "' OR AVAL2='" + txtRut.Text + "' else select 0", conexiones3._conexion)
        ''    conexiones3.abrir()
        ''    Dim reader3 As SqlDataReader = command3.ExecuteReader()

        ''    If reader3.HasRows Then
        ''        Do While reader3.Read()
        ''            txtInternaDeudaIndirecta.Text = Integer.Parse(reader3(0).ToString)
        ''        Loop
        ''    Else
        ''    End If
        ''    reader3.Close()

        'Try

        '    txtCapacidad3.Text = 0
        '    txtCapacidad3.Text = Math.Round((((Integer.Parse(Replace(txtCuota3.Text, ".", "")) + Integer.Parse(Replace(txtInternaPagoMensual.Text, ".", "")) + Integer.Parse(Replace(txtCapital.Text, ".", "")))) / (Integer.Parse(Replace(txtRentaLiquidaDepurada.Text, ".", "")))) * 100, 2, MidpointRounding.ToEven)

        '    txtLeverage3.Text = 0
        '    txtLeverage3.Text = Math.Round(((Integer.Parse(Replace(txtEdeudaConsumo.Text, ".", "")) + Integer.Parse(Replace(txtEdeudaComercial.Text, ".", "")) + Integer.Parse(Replace(txtELineaCredito.Text, ".", "")) + Integer.Parse(Replace(TxtMonto3.Text, ".", "")) + Integer.Parse(Replace(txtInternaTotalDeuda.Text, ".", ""))) / Integer.Parse(Replace(txtRLP.Text, ".", ""))), 0, MidpointRounding.ToEven)



        '    texto = "Monto por un valor de $" + TxtMonto3.Text + " ,con plazo de " + txtPlazo3.Text + " y con cuota de " + txtCuota3.Text








        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub TxtMonto3_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMonto3.KeyUp
        TxtMonto3.Text = Puntos(TxtMonto3.Text)
        TxtMonto3.Select(TxtMonto3.Text.Length, 0)

        'TxtMonto3.Text = Puntos(TxtMonto3.Text)
        'TxtMonto3.Select(TxtMonto3.Text.Length, 0)
    End Sub


    Public Function Puntos(ByVal strValor As String, Optional ByVal intNumDecimales As Integer = 0) As String

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



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Trim(CARGO) = "AGENCIA" Then
            txtComentarioAgencia.Text = txtComentarioAgencia.Text + texto

        ElseIf Trim(CARGO) = "SUBGERENTE" Then
            txtComentarioSubGerente.Text = txtComentarioSubGerente.Text + texto
        ElseIf Trim(CARGO) = "GERENTE" Then
            txtComentarioGerente2.Text = txtComentarioGerente2.Text + texto
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        prestamo = LboxConsumo.SelectedItem
        agregar()

        sumar()
    End Sub


    Private Sub LboxAgregados_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LboxAgregados.SelectedIndexChanged
        sumar()

    End Sub


    Private Sub LboxAgregados_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LboxAgregados.SelectedValueChanged
        sumar()
    End Sub


    Private Sub LboxAgregados_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LboxAgregados.TextChanged
        sumar()
    End Sub

    Private Sub LboxAgregados_ForeColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LboxAgregados.ForeColorChanged
        sumar()
    End Sub


    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        prestamo = LboxEmergencia.SelectedItem
        agregar()

        sumar()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        prestamo = LBoxAdicional.SelectedItem

        agregar()

        sumar()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        prestamo = LBoxComercial.SelectedItem
        agregar()

        sumar()
    End Sub

    Private Sub Quitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Quitar.Click
        Dim prestamo As String = LboxAgregados.SelectedItem

        If prestamo = "" Then
            MsgBox("Debe Selecionar el prestamo que desee quitar")

        Else
            Dim conexiones5 As New CConexion
            conexiones5.conexion()
            Dim command5 As SqlCommand = New SqlCommand(" update _RIESGO_PREPAGO set estado='NO' where prestamo='" + prestamo + "' AND PERFIL ='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "'", conexiones5._conexion)
            conexiones5.abrir()
            Dim reader5 As SqlDataReader = command5.ExecuteReader()

            reader5.Close()

            LboxAgregados.Items.Clear()

            Dim conexiones8 As New CConexion
            conexiones8.conexion()
            Dim command8 As SqlCommand = New SqlCommand("SELECT [Prestamo] FROM [_RIESGO_PREPAGO] where estado='SI' AND PERFIL ='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "'", conexiones8._conexion)
            conexiones8.abrir()
            Dim reader8 As SqlDataReader = command8.ExecuteReader()

            If reader8.HasRows Then
                Do While reader8.Read()
                    LboxAgregados.Items.Add(reader8(0).ToString)

                Loop
            Else
            End If

            reader8.Close()


            sumar()


        End If



        If (LboxAgregados.Items.Count = 0) Then
            txtCuotasPrepagadas2.Text = 0
            txtCuotasPrestamos.Text = 0
        End If


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim conexiones5 As New CConexion
        conexiones5.conexion()
        Dim command5 As SqlCommand = New SqlCommand(" update _RIESGO_PREPAGO set estado='NO' WHERE PERFIL ='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "'", conexiones5._conexion)
        conexiones5.abrir()
        Dim reader5 As SqlDataReader = command5.ExecuteReader()

        reader5.Close()

        LboxAgregados.Items.Clear()

        Dim conexiones8 As New CConexion
        conexiones8.conexion()
        Dim command8 As SqlCommand = New SqlCommand("SELECT [Prestamo] FROM [_RIESGO_PREPAGO] where estado='SI' AND PERFIL ='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "'", conexiones8._conexion)
        conexiones8.abrir()
        Dim reader8 As SqlDataReader = command8.ExecuteReader()

        If reader8.HasRows Then
            Do While reader8.Read()
                LboxAgregados.Items.Add(reader8(0).ToString)

            Loop
        Else
        End If

        reader8.Close()

        txtMonto4.Text = 0
        txtCuotasPrestamos.Text = 0
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click




        TxtMonto3.Text = Replace(TxtMonto3.Text, ".", "")
        txtMonto4.Text = Replace(txtMonto4.Text, ".", "")

        texto = ""




        If txtNuevoMontoDisponible2.Text = "" Then
            MsgBox("El disponible no puede ser un dato en blanco")
        Else

            If (TxtMonto3.Enabled = True And TxtMonto3.Text = "") Then
                MsgBox("Se debe agregar un monto")
            Else
                'If (txtPlazo3.Text = "") Then
                '    MsgBox("Se debe agregar un plazo")
                'Else

                If (Integer.Parse(txtMonto4.Text) > Integer.Parse(TxtMonto3.Text)) Then
                    MsgBox("El monto del prepago no puede ser mayor al monto solicitado")
                Else

                    '-----------PARAMETROS GENERALES
                    'SOCIO O PRESOCIO
                    Dim SOCIO_PRESOCIO As Integer = 1
                    If lpresocio.Visible = True Then
                        SOCIO_PRESOCIO = 2
                    End If
                    'NUMERO DE SOCIO
                    Dim NROSOCIO As String = txtNrosocio2.Text.ToString
                    'CANTIDAD DE CUOTAS (PLAZO) DEL CREDITO
                    Dim CANT_CUOTAS As String = Integer.Parse(cboNuevoPlazo.SelectedItem.ToString)
                    'TIPO DE CONVENIO (TABLA _FORMAPAGO)

                    Dim FORMAPAGO As Integer = txtCodFormaDePago.Text

                   

                    'TASA DE INTERES DEL CREDITO
                    Dim TASA As Double = CboNuevaTasa.SelectedItem
                    'If txtNuevaTasa.Text <> "" Then
                    '        TASA = txtNuevaTasa.Text
                    '    End If

                    'FECHA DE OTORGAMIENTO


                    Dim FECHA_PTMO As String = System.DateTime.Today.ToString("yyyyMMdd")

                    '------------PARAMETROS SOLO PARA CREDITOS MENSUALES
                    'MONTO SOLICITADO 
                    Dim MONTO_PTMO As Double = Replace(TxtMonto3.Text, ".", "")
                    'DIAS GRACIA
                    Dim DIASGRACIA As String = "S"
                    'INDICA FORZOSAMENTE EL MES Y EL AÑO DE INICIO
                    Dim MES_PRIMERA As Integer = 0
                    'INDICA FORZOSAMENTE EL MES Y EL AÑO DE INICIO
                    Dim ANO_PRIMERA As Integer = 0

                    If (TableNuevoPeriodo.Visible = True) Then
                        MES_PRIMERA = txtNuevoPeriodoMes.Text
                        ANO_PRIMERA = txtNuevoPeriodoAño.Text
                    End If

                    '------------PARAMETROS SOLO PARA CREDITOS CONGRESO 
                    'DISPONIBLE TOTAL DEL CERTIFICADO DE SUELDOS
                    Dim DISPONIBLE As Integer = Replace(txtNuevoMontoDisponible2.Text, ".", "")

                    '------------PARAMETROS SOLO PARA CREDITOS CONGRESO 
                    Dim COD_NOM_CRED As Integer = 0

                    Dim conexiones1 As New CConexion
                    conexiones1.conexion()
                    Dim command1 As SqlCommand = New SqlCommand(" select CODNOM from _nombrecredito  where DESCRIPCION='" + txtProducto.Text.ToString.Trim + "'  ", conexiones1._conexion)
                    conexiones1.abrir()
                    Dim reader1 As SqlDataReader = command1.ExecuteReader()

                    If reader1.HasRows Then
                        Do While reader1.Read()
                            COD_NOM_CRED = (reader1(0).ToString)
                        Loop
                    Else
                    End If
                    reader1.Close()


                    'MONTO QUE PAGARA POR CONCEPTO DE CAPITAL SOCIAL POR CADA PAGO DE CUOTA (SE REBAJARA DEL DISPONIBLE PARA CREDITO)
                    Dim CON_DESGRAL As Integer = 0
                    'MONTO QUE PAGARA POR CONCEPTO DE CUOTA GASTOS POR CADA PAGO DE CUOTA (SE REBAJARA DEL DISPONIBLE PARA CREDITO)
                    Dim CON_CESANT As Integer = 0

                    Dim CON_SOLIDARIO As Integer = 0






                    Dim conexiones12 As New CConexion
                    conexiones12.conexion()
                    conexiones12.abrir()
                    Dim command12 As SqlCommand
                    Dim adapter12 As SqlDataAdapter
                    Dim dtTable12 As DataTable


                    'Indico el SP que voy a utilizar

                    'MsgBox(TASA)
                    command12 = New SqlCommand("_LAUCOOP_SOLICITA_CREDITO", conexiones12._conexion)
                    command12.CommandType = CommandType.StoredProcedure
                    adapter12 = New SqlDataAdapter(command12)
                    dtTable12 = New DataTable
                    With command12.Parameters
                        'Envió los parámetros que necesito
                        .Add(New SqlParameter("@NROSOCIO", SqlDbType.Int)).Value = NROSOCIO
                        .Add(New SqlParameter("@SOCIO_PRESOCIO", SqlDbType.Int)).Value = SOCIO_PRESOCIO
                        .Add(New SqlParameter("@CANT_CUOTAS", SqlDbType.Int)).Value = CANT_CUOTAS
                        .Add(New SqlParameter("@FORMAPAGO", SqlDbType.Int)).Value = FORMAPAGO
                        .Add(New SqlParameter("@TASA", SqlDbType.Decimal)).Value = TASA
                        .Add(New SqlParameter("@FECHA_PTMO", SqlDbType.VarChar)).Value = FECHA_PTMO
                        .Add(New SqlParameter("@MONTO_PTMO", SqlDbType.Decimal)).Value = MONTO_PTMO
                        .Add(New SqlParameter("@DIASGRACIA", SqlDbType.VarChar)).Value = DIASGRACIA
                        .Add(New SqlParameter("@MES_PRIMERA", SqlDbType.Int)).Value = MES_PRIMERA
                        .Add(New SqlParameter("@ANO_PRIMERA", SqlDbType.Int)).Value = ANO_PRIMERA
                        .Add(New SqlParameter("@DISPONIBLE", SqlDbType.Int)).Value = DISPONIBLE
                        .Add(New SqlParameter("@COD_NOM_CRED", SqlDbType.Int)).Value = COD_NOM_CRED
                        .Add(New SqlParameter("@CON_DESGRA", SqlDbType.Int)).Value = CON_DESGRAL
                        .Add(New SqlParameter("@CON_CESANT", SqlDbType.Int)).Value = CON_CESANT
                        .Add(New SqlParameter("@CON_SOLIDARIO  ", SqlDbType.Int)).Value = CON_SOLIDARIO

                    End With
                    adapter12.Fill(dtTable12)

                    DgAmortizacion2.DataSource = dtTable12

                    DgAmortizacion2.AutoGenerateColumns = False

                    conexiones12.cerrar()

                    txtNuevosDiasDeGracia.Text = DgAmortizacion2.Rows(1).Cells("DIVIDENDO").Value.ToString.Trim

                    CARGARDATOSAMORTIZACION()


                    txtCapacidad3.Text = 0
                    txtCapacidad3.Text = Math.Round((((Double.Parse(Replace(txtCuota3.Text, ".", "")) + Double.Parse(Replace(txtInternaPagoMensual.Text, ".", "")) + Double.Parse(Replace(txtCapital.Text, ".", "")))) / (Double.Parse(Replace(txtRentaLiquidaDepurada.Text, ".", "")))) * 100, 2, MidpointRounding.ToEven)

                    txtLeverage3.Text = 0
                    txtLeverage3.Text = Math.Round(((Integer.Parse(Replace(txtEdeudaConsumo.Text, ".", "")) + Integer.Parse(Replace(txtEdeudaComercial.Text, ".", "")) + Integer.Parse(Replace(txtELineaCredito.Text, ".", "")) + Integer.Parse(Replace(TxtMonto3.Text, ".", "")) + Integer.Parse(Replace(txtInternaTotalDeuda.Text, ".", ""))) / Integer.Parse(Replace(txtRLP.Text, ".", ""))), 0, MidpointRounding.ToEven)

                End If

            End If

        End If

    End Sub
    Sub CARGARDATOSAMORTIZACION()
        Dim totalfilas2 As Integer = DgAmortizacion2.RowCount - 1

        DGridamortizacion3.Rows.Clear()

        For i = 0 To totalfilas2
            If DgAmortizacion2.Rows(i).Cells("TIPOREG").Value() = "40" Then
                DGridamortizacion3.Rows.Add(DgAmortizacion2.Rows(i).Cells("CUOTA_REAL").Value(), DgAmortizacion2.Rows(i).Cells("FECHA_REAL").Value(), DgAmortizacion2.Rows(i).Cells("DIVIDENDO").Value(), DgAmortizacion2.Rows(i).Cells("SALDOCAPITAL").Value())
            End If
        Next

        txtCuota3.Text = DGridamortizacion3.Rows(1).Cells(2).Value.ToString.Trim
        'txtFechaInicio.Text = DgAmortizacion.Rows(1).Cells("FECHA").Value.ToString.Trim
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try


            Dim conexiones14 As New CConexion
            conexiones14.conexion()
            conexiones14.abrir()
            Dim cmd14 As New SqlCommand("Riesgo_prestamo_deudas3", conexiones14._conexion)
            cmd14.CommandType = CommandType.StoredProcedure
            Dim prm2 As SqlParameter =
                New SqlParameter("@PERFIL", SqlDbType.NChar, 30)
            cmd14.Parameters.Add(prm2)
            With cmd14
                .Parameters("@PERFIL").Value = frmPerfil.CbmUsuario.SelectedItem
            End With
            Dim dr14 As SqlDataReader = cmd14.ExecuteReader(CommandBehavior.CloseConnection)
            conexiones14.cerrar()




            Dim conexiones8 As New CConexion
            conexiones8.conexion()
            Dim command8 As SqlCommand = New SqlCommand(" if exists (SELECT * FROM _RIESGO_DEUDAS_CREDITOS where tipo in ('Consumo','Emergencia','Adicional') and Estado='Normal' AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "') SELECT sum(deuda) FROM _RIESGO_DEUDAS_CREDITOS where tipo in ('Consumo','Emergencia','Adicional') and Estado='Normal' AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "' else select 0", conexiones8._conexion)
            conexiones8.abrir()
            Dim reader8 As SqlDataReader = command8.ExecuteReader()

            If reader8.HasRows Then
                Do While reader8.Read()
                    txtInternaDeudaConsumo.Text = Integer.Parse((reader8(0).ToString))
                Loop
            Else
            End If

            reader8.Close()


            Dim conexiones9 As New CConexion
            conexiones9.conexion()
            Dim command9 As SqlCommand = New SqlCommand(" if exists(SELECT * FROM _RIESGO_DEUDAS_CREDITOS where tipo in ('Comercial') and Estado='Normal' AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "') SELECT sum(deuda) FROM _RIESGO_DEUDAS_CREDITOS where tipo in ('Comercial') and Estado='Normal' AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "' else select 0", conexiones9._conexion)
            conexiones9.abrir()
            Dim reader9 As SqlDataReader = command9.ExecuteReader()

            If reader9.HasRows Then
                Do While reader9.Read()
                    txtInternaDeudaComercial.Text = Integer.Parse(reader9(0).ToString)
                Loop
            Else
            End If
            reader9.Close()

            txtInternaTotalDeuda.Text = Integer.Parse(txtInternaDeudaComercial.Text) + Integer.Parse(txtInternaDeudaConsumo.Text)

            Dim conexiones2 As New CConexion
            conexiones2.conexion()
            Dim command2 As SqlCommand = New SqlCommand(" if exists (SELECT * FROM _RIESGO_DEUDAS_CREDITOS where Estado='Normal' AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "') SELECT sum(cuota) FROM _RIESGO_DEUDAS_CREDITOS where  Estado='Normal'  AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "' else select 0", conexiones2._conexion)
            conexiones2.abrir()
            Dim reader2 As SqlDataReader = command2.ExecuteReader()

            If reader2.HasRows Then
                Do While reader2.Read()
                    txtInternaPagoMensual.Text = Integer.Parse(reader2(0).ToString)
                Loop
            Else
            End If
            reader2.Close()


            Dim conexiones3 As New CConexion
            conexiones3.conexion()
            Dim command3 As SqlCommand = New SqlCommand("if exists ( SELECT * FROM _RIESGO_PRESTAMOS_ULTIMO WHERE AVAL1='" + txtRut.Text + "' OR AVAL2='" + txtRut.Text + "') SELECT SUM(MONTO_DEUDA) FROM _RIESGO_PRESTAMOS_ULTIMO WHERE AVAL1='" + txtRut.Text + "' OR AVAL2='" + txtRut.Text + "' else select 0", conexiones3._conexion)
            conexiones3.abrir()
            Dim reader3 As SqlDataReader = command3.ExecuteReader()

            If reader3.HasRows Then
                Do While reader3.Read()
                    txtInternaDeudaIndirecta.Text = Integer.Parse(reader3(0).ToString)
                Loop
            Else
            End If
            reader3.Close()



            txtCapacidad3.Text = 0
            txtCapacidad3.Text = Math.Round((((Integer.Parse(Replace(txtCuota3.Text, ".", "")) + Integer.Parse(Replace(txtInternaPagoMensual.Text, ".", "")) + Integer.Parse(Replace(txtCapital.Text, ".", "")))) / (Integer.Parse(Replace(txtRentaLiquidaDepurada.Text, ".", "")))) * 100, 2, MidpointRounding.ToEven)

            txtLeverage3.Text = 0
            txtLeverage3.Text = Math.Round(((Integer.Parse(Replace(txtEdeudaConsumo.Text, ".", "")) + Integer.Parse(Replace(txtEdeudaComercial.Text, ".", "")) + Integer.Parse(Replace(txtELineaCredito.Text, ".", "")) + Integer.Parse(Replace(TxtMonto3.Text, ".", "")) + Integer.Parse(Replace(txtInternaTotalDeuda.Text, ".", ""))) / Integer.Parse(Replace(txtRLP.Text, ".", ""))), 0, MidpointRounding.ToEven)



            'texto = "Monto por un valor de $" + TxtMonto3.Text + " ,con plazo de " + cboNuevoPlazo.SelectedItem.ToString + " y con cuota de " + txtCuota3.Text
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub TxtMonto3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMonto3.TextChanged
        If TxtMonto3.Text = "" Then
            TxtMonto3.Text = "0"
        End If
    End Sub

    Private Sub txtObjetivo2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObjetivo2.TextChanged
        If txtObjetivo2.Text = "Renegociación" Then
            txtObjetivo2.BackColor = Color.Red
            txtAviso.Visible = True
        End If
    End Sub

    Private Sub CboAprobar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAprobar.SelectedIndexChanged


        Dim USUARIO As String
        Dim Departamento As String = ""
        USUARIO = frmPerfil.CbmUsuario.SelectedItem



        Dim conexiones2 As New CConexion
        conexiones2.conexion()
        Dim command2 As SqlCommand = New SqlCommand("SELECT CARGO FROM _RIESGO_PERFIL WHERE USUARIO='" + USUARIO.ToString.Trim + "'", conexiones2._conexion)
        conexiones2.abrir()

        Dim reader2 As SqlDataReader = command2.ExecuteReader()


        If reader2.HasRows Then
            Do While reader2.Read()

                Departamento = reader2(0).ToString
            Loop
        Else
        End If

        reader2.Close()




        'If (CboAprobar.SelectedItem = "LIBERADO CON OBJECIONES" or  CboAprobar.Items.Add("NO LIBERADO") or ) Then
        '    txtComentarioAgente.Visible = False
        '    txtComentarioAgente.Visible = False
        '    txtComentarioAgente.Enabled = False
        'Else
        '    txtComentarioAgente.Visible = True
        '    txtComentarioAgente.Visible = True
        '    txtComentarioAgente.Enabled = True
        'End If

        If (CboAprobar.SelectedItem = "RECOMIENDO CONDICIONAL") Then
            txtCondicion2.Visible = True
            btnCondicion2.Enabled = True
        Else
            If Departamento.Trim = "RIESGO" Then
                chkMonto2.Checked = False
                chkPlazo2.Checked = False
                chkTasa2.Checked = False
                btnCondicion2.Enabled = False
                txtCondicion2.Visible = False
                txtCondicion2.Text = ""
            End If

        End If



        If (CboAprobar.SelectedItem = "SI CONDICIONAL") Then
            txtCondicion.Visible = True
            txtCondicion.Visible = True
            btnCondicion.Enabled = True
        Else
            If Departamento.Trim <> "RIESGO" Then
                btnCondicion.Enabled = False
                txtCondicion.Visible = False
                txtCondicion.Text = ""
                chkMonto.Checked = False
                chkPlazo.Checked = False
                chkTasa.Checked = False
            End If
        End If


        If Trim(CboAprobar.SelectedItem) = "SI" Or Trim(CboAprobar.SelectedItem) = "RECOMIENDO" Or Trim(CboAprobar.SelectedItem) = "LIBERADO SIN OBJECIONES" Then
            CboAprobar.BackColor = Color.Green
            CboAprobar.ForeColor = Color.White
        ElseIf Trim(CboAprobar.SelectedItem) = "SI CONDICIONAL" Or Trim(CboAprobar.SelectedItem) = "LIBERADO CON OBJECIONES" Or Trim(CboAprobar.SelectedItem) = "RECOMIENDO CONDICIONAL" Then
            CboAprobar.BackColor = Color.Yellow
            CboAprobar.ForeColor = Color.Black
        ElseIf Trim(CboAprobar.SelectedItem) = "NO" Or Trim(CboAprobar.SelectedItem) = "NO RECOMIENDO" Then
            CboAprobar.BackColor = Color.Red
            CboAprobar.ForeColor = Color.White
        ElseIf Trim(CboAprobar.SelectedItem) = "DESCARTADO" Or Trim(CboAprobar.SelectedItem) = "NO VALIDA" Or Trim(CboAprobar.SelectedItem) = "NO LIBERADO" Then

            CboAprobar.BackColor = Color.Black
            CboAprobar.ForeColor = Color.White
        Else
            CboAprobar.BackColor = Color.White
        End If




    End Sub

    Private Sub txtCondicion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        txtcaracteres5.Text = 60 - (txtCondicion.Text.Length)
    End Sub

    Private Sub txtCondicion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  If (CboAprobar.SelectedItem = "SI CONDICIONAL") Then
        ' txtCondicion.Enabled = True
        '  Else
        ' txtCondicion.Enabled = False
        ' txtCondicion.Text = ""
        '  End If

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




    Private Sub txtCodigoId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoId.TextChanged

        Try
            Datos._idprestamo2 = Integer.Parse(txtCodigoId.Text)
            plantillas._tabla.Rows.Clear()
            plantillas._tabla.Columns.Clear()
            If plantillas.Consultar_Informacion_prepagos(Datos) Then
                tabla = plantillas.tabla
                DGPrepago.DataSource = tabla
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'AxAcroPDF1.src = "Z:\_____DICOM HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut2.Text.ToString) + ".pdf"
        'AxAcroPDF1.setZoom(90)
    End Sub

    'Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
    '    AxAcroPDF2.src = "Z:\_____DOCUMENTOS HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut2.Text.ToString) + ".pdf"
    '    AxAcroPDF2.setZoom(90)


    'End Sub



    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If Timer1.Enabled = True Then
            MsgBox("Los Pre-Socios no registran comportamientos historicos")
        Else


            Dim usuario As String
            Dim rut As String


            Dim conexiones1 As New CConexion
            conexiones1.conexion()
            Dim command1 As SqlCommand = New SqlCommand("SELECT convert(varchar,[RUT]) from _socios where SOCIOSINO='S' and RTRIM(NROSOCIO)='" + txtNrosocio2.Text + "'", conexiones1._conexion)
            conexiones1.abrir()
            Dim reader1 As SqlDataReader = command1.ExecuteReader()

            If reader1.HasRows Then
                Do While reader1.Read()
                    Datos._Compromiso_Rut = (reader1(0).ToString.Trim)
                Loop
            Else
            End If
            reader1.Close()



            Datos._Compromiso_Usuario = Trim(frmPerfil.CbmUsuario.SelectedItem.ToString)
            usuario = Datos._Compromiso_Usuario
            rut = Trim(Datos._Compromiso_Rut.ToString)

            'MsgBox(Datos._Compromiso_Rut)
            'MsgBox(usuario)
            'MsgBox(rut)


            Dim conexiones71 As New CConexion
            conexiones71.conexion()
            conexiones71.abrir()
            Dim cmd71 As New SqlCommand("_Riesgo_Comportamiento4", conexiones71._conexion)
            cmd71.CommandType = CommandType.StoredProcedure
            Dim prm71 As SqlParameter = _
            New SqlParameter("@rut", SqlDbType.NVarChar)
            Dim prm71_2 As SqlParameter = _
            New SqlParameter("@usuario", SqlDbType.NVarChar)
            cmd71.Parameters.Add(prm71)
            cmd71.Parameters.Add(prm71_2)
            With cmd71
                .Parameters("@rut").Value = rut
                .Parameters("@usuario").Value = usuario
            End With
            Dim dr71 As SqlDataReader = cmd71.ExecuteReader(CommandBehavior.CloseConnection)
            conexiones71.cerrar()


            plantillas._tabla.Rows.Clear()
            plantillas._tabla.Columns.Clear()
            If plantillas.Consultar_Comportamiento(Datos) Then
                tabla = plantillas.tabla
                DGComportamiento.DataSource = tabla
            End If



            Dim conexiones9 As New CConexion
            conexiones9.conexion()
            Dim command9 As SqlCommand = New SqlCommand("SELECT TIPO,COMENTARIO FROM _RIESGO_COMPORTAMIENTO_COMENTARIOS where USUARIO='" + usuario + "' AND RUT ='" + rut + "'", conexiones9._conexion)
            conexiones9.abrir()
            Dim reader9 As SqlDataReader = command9.ExecuteReader()

            If reader9.HasRows Then
                Do While reader9.Read()

                    If reader9(0).ToString.Trim = "GENERAL MESES" Then
                        txtGeneral.Text = reader9(1).ToString.Trim
                    ElseIf reader9(0).ToString.Trim = "1 MES" Then
                        txt1Mes.Text = reader9(1).ToString.Trim
                    ElseIf reader9(0).ToString.Trim = "6 MESES CLASIFICACION" Then
                        txt6MesesClasificacion.Text = reader9(1).ToString.Trim
                    ElseIf reader9(0).ToString.Trim = "6 MESES CAPITAL" Then
                        txt6MesesCapital.Text = reader9(1).ToString.Trim
                    ElseIf reader9(0).ToString.Trim = "12 MESES CLASIFICACION" Then
                        txt12MesesClasificacion.Text = reader9(1).ToString.Trim
                    ElseIf reader9(0).ToString.Trim = "12 MESES CAPITAL" Then
                        txt12MesesCapital.Text = reader9(1).ToString.Trim
                    ElseIf reader9(0).ToString.Trim = "24 MESES CLASIFICACION" Then
                        txt24MesesClasificacion.Text = reader9(1).ToString.Trim
                    ElseIf reader9(0).ToString.Trim = "24 MESES CAPITAL" Then
                        txt24MesesCapital.Text = reader9(1).ToString.Trim
                    ElseIf reader9(0).ToString.Trim = "HISTORICO CLASIFICACION" Then
                        txtHistoricoClasificacion.Text = reader9(1).ToString.Trim
                    ElseIf reader9(0).ToString.Trim = "HISTORICO CAPITAL" Then
                        txtHistoricoCapital.Text = reader9(1).ToString.Trim
                    End If

                Loop
            Else
            End If

            reader9.Close()

        End If
    End Sub



    Private Sub txt6MesesClasificacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt6MesesClasificacion.TextChanged
        If (Trim(txt6MesesClasificacion.Text) = "EN LOS ULTIMOS 6 MESES PRESENTA 0 CLASIFICACIÓN/ES NEGATIVA") Then
            txt6MesesClasificacion.BackColor = Color.Green()
        Else
            txt6MesesClasificacion.BackColor = Color.Red()
        End If
    End Sub

    Private Sub txt6MesesCapital_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt6MesesCapital.TextChanged
        If (Trim(txt6MesesCapital.Text) = "EN LOS ULTIMOS 6 MESES HA PAGADO CON CAPITAL 0, POR UN TOTAL DE $0") Then
            txt6MesesCapital.BackColor = Color.Green()
        Else
            txt6MesesCapital.BackColor = Color.Red()
        End If
    End Sub

    Private Sub txt12MesesClasificacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt12MesesClasificacion.TextChanged
        If (Trim(txt12MesesClasificacion.Text) = "EN LOS ULTIMOS 12 MESES PRESENTA 0 CLASIFICACIÓN/ES NEGATIVA") Then
            txt12MesesClasificacion.BackColor = Color.Green()
        Else
            txt12MesesClasificacion.BackColor = Color.Red()
        End If
    End Sub

    Private Sub txt12MesesCapital_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt12MesesCapital.TextChanged
        If (Trim(txt12MesesCapital.Text) = "EN LOS ULTIMOS 12 MESES HA PAGADO CON CAPITAL 0, POR UN TOTAL DE $0") Then
            txt12MesesCapital.BackColor = Color.Green()
        Else
            txt12MesesCapital.BackColor = Color.Red()
        End If
    End Sub

    Private Sub txt24MesesClasificacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt24MesesClasificacion.TextChanged
        If (Trim(txt24MesesClasificacion.Text) = "EN LOS ULTIMOS 24 MESES PRESENTA 0 CLASIFICACIÓN/ES NEGATIVA") Then
            txt24MesesClasificacion.BackColor = Color.Green()
        Else
            txt24MesesClasificacion.BackColor = Color.Red()
        End If
    End Sub

    Private Sub txt24MesesCapital_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt24MesesCapital.TextChanged
        If (Trim(txt24MesesCapital.Text) = "EN LOS ULTIMOS 24 MESES HA PAGADO CON CAPITAL 0, POR UN TOTAL DE $0") Then
            txt24MesesCapital.BackColor = Color.Green()
        Else
            txt24MesesCapital.BackColor = Color.Red()
        End If
    End Sub

    Private Sub txtComportamientoClasificaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComportamientoClasificaciones.TextChanged
        If txtComportamientoClasificaciones.Text.Trim <> "0" Then
            txtComportamientoClasificaciones.BackColor = Color.Red
        Else
            txtComportamientoClasificaciones.BackColor = Color.Green
        End If
    End Sub

    Private Sub txtComportamientoCapital_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComportamientoCapital.TextChanged
        If txtComportamientoCapital.Text.Trim <> "0" Then
            txtComportamientoCapital.BackColor = Color.Red
        Else
            txtComportamientoCapital.BackColor = Color.Green
        End If
    End Sub

    Private Sub txtClasificacionBaja_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClasificacionBaja.TextChanged
        If txtClasificacionBaja.Text.Trim = "A" Or txtClasificacionBaja.Text.Trim = "B" Or txtClasificacionBaja.Text.Trim = "NUNCA HA SIDO CLASIFICADO" Then
            txtClasificacionBaja.BackColor = Color.Green
        Else
            txtClasificacionBaja.BackColor = Color.Red
        End If
    End Sub

    Private Sub txtCondicion_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCondicion.KeyUp
        txtcaracteres5.Text = 60 - (txtCondicion.Text.Length)
    End Sub





    Private Sub ChkSustituir_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSustituir.CheckedChanged
        PanelBotonesRiesgo.Visible = False
        If ChkSustituir.Checked = True Then
            txtComentarioGerente2.Text = ""
            txtComentarioSubGerente.Text = "Sustitución automatica de Gerente"
            txtComentarioSubGerente.Enabled = False
            txtComentarioGerente2.ReadOnly = False

            If ATRIBUTO_PRESTAMO2 > 3 Then
                CboAprobar.Items.Clear()
                CboAprobar.Items.Add("RECOMIENDO")
                CboAprobar.Items.Add("NO RECOMIENDO")
                CboAprobar.Items.Add("DESCARTADO")

            Else

                CboAprobar.Items.Clear()
                CboAprobar.Items.Add("SI")
                CboAprobar.Items.Add("SI CONDICIONAL")
                CboAprobar.Items.Add("NO")
                CboAprobar.Items.Add("DESCARTADO")
                PanelBotonesRiesgo.Visible = True
            End If
        Else
            txtComentarioGerente2.Text = ""
            txtComentarioSubGerente.Text = ""
            txtComentarioSubGerente.Enabled = True
            txtComentarioGerente2.Enabled = False
            CboAprobar.Items.Clear()
            CboAprobar.Items.Add("RECOMIENDO")
            CboAprobar.Items.Add("NO RECOMIENDO")
            CboAprobar.Items.Add("DESCARTADO")
        End If

    End Sub



    Sub cargarcondicion()
        txtCondicion.Text = ""
        If chkTasa.Checked = True Then
            txtCondicion.Text = "-Modificar Tasa de " + txtTasa.Text.ToString + " por " + cboTasaSolicitada4.SelectedItem.ToString + vbNewLine
        End If
        If chkMonto.Checked = True Then
            txtCondicion.Text = txtCondicion.Text + "-Modificar Monto de " + TxtMonto.Text.ToString.Trim + " por " + txtmontosolicitado4.Text.ToString + vbNewLine
        End If

        If chkPlazo.Checked = True Then
            txtCondicion.Text = txtCondicion.Text + "-Modificar Plazo de " + txtPlazo.Text.ToString.Trim + " por " + txtPlazoSolicitado4.Text.ToString


        End If
    End Sub

    Sub cargarcondicion_r()
        txtCondicion2.Text = ""


        If chkTasa2.Checked = True Then
            txtCondicion2.Text = "-Modificar Tasa de " + txtTasa.Text.ToString + " por " + cboTasaSolicitada5.SelectedItem.ToString + vbNewLine
        End If
        If chkMonto2.Checked = True Then
            txtCondicion2.Text = txtCondicion2.Text + "-Modificar Monto de " + TxtMonto.Text.ToString.Trim + " por " + txtmontosolicitado5.Text.ToString + vbNewLine
        End If

        If chkPlazo2.Checked = True Then
            txtCondicion2.Text = txtCondicion2.Text + "-Modificar Plazo de " + txtPlazo.Text.ToString.Trim + " por " + txtPlazoSolicitado5.Text.ToString
        End If

        If (txtCondicion2.Text <> "") Then
            txtComentarioRiesgo.Text = "Se condiciona crédito para su recomendación"
        End If


    End Sub
    Private Sub btnCondicion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCondicion.Click




        If chkTasa.Checked = True Or chkMonto.Checked = True Or chkPlazo.Checked = True Then

            cargarcondicion()

        Else

            MsgBox("Se debe selecionar una opción antes de generar la condicional")
        End If
    End Sub

    Private Sub chkTasa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTasa.CheckedChanged
        If chkTasa.Checked = True Then
            cboTasaSolicitada4.SelectedItem = "0"
            cboTasaSolicitada4.Enabled = True
        Else
            cboTasaSolicitada4.SelectedItem = "0"
            cboTasaSolicitada4.Enabled = False
            cargarcondicion()

        End If
    End Sub

    Private Sub txtmontosolicitado4_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmontosolicitado4.KeyUp
        txtmontosolicitado4.Text = Puntos(txtmontosolicitado4.Text)
        txtmontosolicitado4.Select(txtmontosolicitado4.Text.Length, 0)
    End Sub



    Private Sub txtEjecutivoVentas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEjecutivoVentas.TextChanged
        If txtEjecutivoVentas.Text.Trim <> "SIN EJECUTIVO" Then
            txtEjecutivoVentas.BackColor = Color.Green
        End If
    End Sub

    Private Sub chkMonto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMonto.CheckedChanged
        If chkMonto.Checked = True Then
            txtmontosolicitado4.Text = "0"
            txtmontosolicitado4.Enabled = True
        Else
            txtmontosolicitado4.Text = "0"
            txtmontosolicitado4.Enabled = False
            cargarcondicion()
        End If
    End Sub

    Private Sub chkPlazo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPlazo.CheckedChanged
        If chkPlazo.Checked = True Then
            txtPlazoSolicitado4.Text = "0"
            txtPlazoSolicitado4.Enabled = True
        Else
            txtPlazoSolicitado4.Text = "0"
            txtPlazoSolicitado4.Enabled = False
            cargarcondicion()
        End If
    End Sub


    Private Sub txtReref_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReref.TextChanged
        If txtReref.Text.Trim = "NO" Then
            txtReref.BackColor = Color.Green
        Else
            txtReref.BackColor = Color.Red
        End If
    End Sub

    Private Sub txtComentarioAgente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComentarioAgente.KeyUp
        txtAgente.Text = 450 - (txtComentarioAgente.Text.Length)
    End Sub

    Private Sub txtContrasena_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtContrasena.KeyDown

        If e.KeyCode = Keys.Enter Then
            enviar()
        End If

    End Sub

    Private Sub txtComentarioRiesgo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComentarioRiesgo.KeyDown
        txtRiesgo.Text = 450 - (txtComentarioRiesgo.Text.Length)
    End Sub

    Private Sub txtComentarioSubGerente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComentarioSubGerente.TextChanged

    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox(cboTipologiasDeObjeciones.SelectedItem.ToString)
    End Sub









    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = 0 Then
            Dim i As Integer = Me.DataGridView1.CurrentRow.Index
            Dim cod As Integer = Integer.Parse(Me.DataGridView1.Rows(i).Cells(2).Value.ToString())
            Dim conexiones3 As New CConexion
            conexiones3.conexion()
            cmd = New SqlCommand("select doc from [DocBD].[dbo].documentos where docId=" & cod & " and estado=1 ", conexiones3._conexion)
            da = New SqlDataAdapter(cmd)
            dtb = New DataTable()
            da.Fill(dtb)
            Dim f As DataRow = dtb.Rows(0)
            Dim Bits As Byte() = (CType((f.ItemArray(0)), Byte()))
            Dim sFile As String = "a" & GenerarNombreFichero() & ".pdf"
            Dim fs As New FileStream(sFile, FileMode.Create)
            fs.Write(Bits, 0, Convert.ToInt32(Bits.Length))
            fs.Close()
            Dim obj As System.Diagnostics.Process = New System.Diagnostics.Process()
            'AxAcroPDF1.src = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
            AxAcroPDF1.src = "C:\SISTEMAS\Riesgo\" + sFile
            'AxAcroPDF1.setCurrentPage(2)
            AxAcroPDF1.setZoom(90)
            Dim ArchivoBorrar As String
            'ArchivoBorrar = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
            ArchivoBorrar = "C:\SISTEMAS\Riesgo\" + sFile
            If System.IO.File.Exists(ArchivoBorrar) = True Then
                System.IO.File.Delete(ArchivoBorrar)
            End If

        End If
    End Sub







    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If e.ColumnIndex = 0 Then
            Dim i As Integer = Me.DataGridView2.CurrentRow.Index
            Dim cod As Integer = Integer.Parse(Me.DataGridView2.Rows(i).Cells(2).Value.ToString())
            Dim conexiones3 As New CConexion
            conexiones3.conexion()
            cmd = New SqlCommand("select doc from [DocBD].[dbo].documentos where docId=" & cod & " and estado=1 ", conexiones3._conexion)
            da = New SqlDataAdapter(cmd)
            dtb = New DataTable()
            da.Fill(dtb)
            Dim f As DataRow = dtb.Rows(0)
            Dim Bits As Byte() = (CType((f.ItemArray(0)), Byte()))
            Dim sFile As String = "a" & GenerarNombreFichero() & ".pdf"
            Dim fs As New FileStream(sFile, FileMode.Create)
            fs.Write(Bits, 0, Convert.ToInt32(Bits.Length))
            fs.Close()
            Dim obj As System.Diagnostics.Process = New System.Diagnostics.Process()
            'AxAcroPDF2.src = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
            AxAcroPDF2.src = "C:\SISTEMAS\Riesgo\" + sFile
            'AxAcroPDF2.setCurrentPage(2)
            AxAcroPDF2.setZoom(90)
            Dim ArchivoBorrar As String
            'ArchivoBorrar = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
            ArchivoBorrar = "C:\SISTEMAS\Riesgo\" + sFile
            If System.IO.File.Exists(ArchivoBorrar) = True Then
                System.IO.File.Delete(ArchivoBorrar)
            End If

        End If
    End Sub

    'Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnteriorAdjuntos.Click
    '    AxAcroPDF2.gotoPreviousPage()
    'End Sub

    'Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguenteAdjuntos.Click, Button6.Click
    '    AxAcroPDF2.gotoNextPage()
    'End Sub

    'Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnteriorDicom.Click, Button7.Click
    '    AxAcroPDF1.gotoPreviousPage()
    'End Sub

    'Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguienteDicom.Click
    '    AxAcroPDF1.gotoNextPage()
    'End Sub



    'Private Sub btnLeer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeer.Click

    'End Sub


    Private Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As TabControlCancelEventArgs) Handles TabControl1.Selecting
        If Me.TabControl1.SelectedIndex = 11 Then
            Try
                buscarrutDICOM()
                'txtCodigo.Text = "select top 1  doc from [DocBD].[dbo].documentos where fecha='" & Trim(txtFecha.Text.ToString).Substring(0, 10) & "' and rut ='" & Trim(txtRut2.Text.ToString) & "' and tipo='DICOM' and estado=1 order by docid desc"
                Dim Archivo As String
                Dim conexiones3 As New CConexion
                conexiones3.conexion()
                cmd = New SqlCommand("select top 1  doc from [DocBD].[dbo].documentos where fecha='" & Trim(txtFecha.Text.ToString).Substring(0, 10) & "' and rut ='" & Trim(txtRut2.Text.ToString) & "' and tipo='DICOM' and estado=1  order by docid desc", conexiones3._conexion)
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
                'Archivo = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
                Archivo = "C:\SISTEMAS\Riesgo\" + sFile
                AxAcroPDF1.src = Archivo
                'AxAcroPDF1.setCurrentPage(2)
                AxAcroPDF1.setZoom(90)
                If System.IO.File.Exists(Archivo) = True Then
                    System.IO.File.Delete(Archivo)
                End If

            Catch ex As Exception
                MsgBox("Dicom No encontrado")
            End Try
        End If




        If Me.TabControl1.SelectedIndex = 12 Then
            Try
                buscarrutADJUNTOS()
                'txtCodigo.Text = "select top 1  doc from [DocBD].[dbo].documentos where fecha='" & Trim(txtFecha.Text.ToString).Substring(0, 10) & "' and rut ='" & Trim(txtRut2.Text.ToString) & "' and tipo='ADJUNTOS' and estado=1  order by docid desc"
                Dim Archivo As String
                Dim conexiones3 As New CConexion
                conexiones3.conexion()
                cmd = New SqlCommand("select top 1  doc from [DocBD].[dbo].documentos where fecha='" & Trim(txtFecha.Text.ToString).Substring(0, 10) & "' and rut ='" & Trim(txtRut2.Text.ToString) & "' and tipo='ADJUNTOS' and estado=1  order by docid desc", conexiones3._conexion)
                da = New SqlDataAdapter(cmd)
                dtb = New DataTable()
                da.Fill(dtb)
                Dim f As DataRow = dtb.Rows(0)
                Dim Bits As Byte() = (CType((f.ItemArray(0)), Byte()))
                Dim sFile As String = "a" & GenerarNombreFichero() & ".pdf"
                Dim fs As New FileStream(sFile, FileMode.Create)
                fs.Write(Bits, 0, Convert.ToInt32(Bits.Length))
                fs.Close()
                Dim obj As System.Diagnostics.Process = New System.Diagnostics.Process()
                'Archivo = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
                Archivo = "C:\SISTEMAS\Riesgo\" + sFile
                AxAcroPDF2.src = Archivo
                'AxAcroPDF1.setCurrentPage(2)
                AxAcroPDF2.setZoom(90)
                If System.IO.File.Exists(Archivo) = True Then
                    System.IO.File.Delete(Archivo)
                End If

            Catch ex As Exception
                MsgBox("Adjuntos No encontrado")
            End Try
        End If



    End Sub
    Public Function GenerarNombreFichero()
        Dim ultimoTick As Integer = 0
        While ultimoTick = Environment.TickCount
            System.Threading.Thread.Sleep(1)
        End While
        ultimoTick = Environment.TickCount
        Return DateTime.Now.ToString("yyyyMMddhhmmss") + "." + ultimoTick.ToString()
    End Function




   
   


    Sub buscarrutDICOM()
        'txtTitulo.Focus()
        crearcolumnaDicom()
        Dim conexiones3 As New CConexion
        conexiones3.conexion()
        cmd = New SqlCommand(" select top 20 CC1.fecha,CC1.docid from [DocBD].[dbo].documentos AS CC1 INNER JOIN (SELECT [rut] ,[fecha] ,MAX(docId) AS docId FROM [DocBD].[dbo].[DOCUMENTOS] where estado=1  and tipo='DICOM' GROUP BY rut, fecha ) AS CC2 ON  CC1.docId=CC2.docId  where CC1.rut='" + Trim(txtRut2.Text.ToString) + "' order by CC1.fecha DESC", conexiones3._conexion)
        da = New SqlDataAdapter(cmd)
        dtb = New DataTable()
        da.Fill(dtb)
        DataGridView1.DataSource = dtb
        DataGridView1.Columns(1).Width = 250
        conexiones3.cerrar()
        DataGridView1.AllowUserToAddRows = False
        COLOREARACTUALDICOM()
    End Sub

    Sub buscarrutADJUNTOS()
        'txtTitulo.Focus()
        crearcolumnaAdjuntos()
        Dim conexiones3 As New CConexion
        conexiones3.conexion()
        cmd = New SqlCommand(" select top 20 CC1.fecha,CC1.docid from [DocBD].[dbo].documentos AS CC1 INNER JOIN (SELECT [rut] ,[fecha] ,MAX(docId) AS docId FROM [DocBD].[dbo].[DOCUMENTOS]  where estado=1  and tipo='ADJUNTOS' GROUP BY rut, fecha ) AS CC2 ON  CC1.docId=CC2.docId  where CC1.rut='" + Trim(txtRut2.Text.ToString) + "'  order by CC1.fecha DESC", conexiones3._conexion)
        da = New SqlDataAdapter(cmd)
        dtb = New DataTable()
        da.Fill(dtb)
        DataGridView2.DataSource = dtb
        DataGridView2.Columns(1).Width = 250
        conexiones3.cerrar()
        DataGridView2.AllowUserToAddRows = False
        COLOREARACTUALADJUNTO()
    End Sub


    Sub COLOREARACTUALDICOM()
        For Each fila As DataGridViewRow In DataGridView1.Rows
            If fila.Cells("Fecha").Value = Trim(txtFecha.Text.ToString).Substring(0, 10) Then
                fila.DefaultCellStyle.BackColor = Color.Blue
                fila.DefaultCellStyle.ForeColor = Color.White
                'Else
                '    fila.DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub
    Sub COLOREARACTUALADJUNTO()
        For Each fila As DataGridViewRow In DataGridView2.Rows
            If fila.Cells("Fecha").Value = Trim(txtFecha.Text.ToString).Substring(0, 10) Then
                fila.DefaultCellStyle.BackColor = Color.Blue
                fila.DefaultCellStyle.ForeColor = Color.White
                'Else
                '    fila.DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub
    Sub crearcolumnaDicom()
        If DataGridView1.Columns.Contains("btn") Then
        Else

            Dim btn As New DataGridViewButtonColumn()
            DataGridView1.Columns.Add(btn)
            btn.HeaderText = "Ver"
            btn.Text = "Ver"
            btn.Name = "btn"
            btn.UseColumnTextForButtonValue = True
        End If
    End Sub

    Sub crearcolumnaAdjuntos()
        If DataGridView2.Columns.Contains("btn") Then
        Else

            Dim btn As New DataGridViewButtonColumn()
            DataGridView2.Columns.Add(btn)
            btn.HeaderText = "Ver"
            btn.Text = "Ver"
            btn.Name = "btn"
            btn.UseColumnTextForButtonValue = True
        End If
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmCreditosPorAprobar.CheckBox1.Checked = False
        Me.Close()
    End Sub

    Private Sub btnAnteriorDicom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnteriorDicom.Click
        AxAcroPDF1.gotoPreviousPage()
    End Sub

    Private Sub btnSiguienteDicom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguienteDicom.Click
        AxAcroPDF1.gotoNextPage()
    End Sub


    Private Sub btnAnteriorAdjuntos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnteriorAdjuntos.Click
        AxAcroPDF2.gotoPreviousPage()
    End Sub

    Private Sub btnSiguenteAdjuntos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguenteAdjuntos.Click
        AxAcroPDF2.gotoNextPage()
    End Sub


    'Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
    '    Dim i As Integer = Me.DataGridView2.CurrentRow.Index
    '    Dim cod As Integer = Integer.Parse(Me.DataGridView2.Rows(i).Cells(0).Value.ToString())
    '    Dim conexiones3 As New CConexion
    '    conexiones3.conexion()
    '    cmd = New SqlCommand("select doc from [DocBD].[dbo].documentos where docId=" & cod & " and estado=1 ", conexiones3._conexion)
    '    da = New SqlDataAdapter(cmd)
    '    dtb = New DataTable()
    '    da.Fill(dtb)
    '    Dim f As DataRow = dtb.Rows(0)
    '    Dim Bits As Byte() = (CType((f.ItemArray(0)), Byte()))
    '    Dim sFile As String = "a" & GenerarNombreFichero() & ".pdf"
    '    Dim fs As New FileStream(sFile, FileMode.Create)
    '    fs.Write(Bits, 0, Convert.ToInt32(Bits.Length))
    '    fs.Close()
    '    Dim obj As System.Diagnostics.Process = New System.Diagnostics.Process()
    '    AxAcroPDF2.src = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
    '    'AxAcroPDF2.setCurrentPage(2)
    '    AxAcroPDF2.setZoom(90)
    '    Dim ArchivoBorrar As String
    '    ArchivoBorrar = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
    '    If System.IO.File.Exists(ArchivoBorrar) = True Then
    '        System.IO.File.Delete(ArchivoBorrar)
    '    End If
    'End Sub


    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Try

          Dim Archivo As String
            Dim conexiones3 As New CConexion
            conexiones3.conexion()
            cmd = New SqlCommand("select top 1  doc from [DocBD].[dbo].documentos where fecha='" & Trim(txtFecha.Text.ToString).Substring(0, 10) & "' and rut ='" & Trim(txtRut2.Text.ToString) & "' and tipo='ADJUNTOS' and estado=1  order by docid desc", conexiones3._conexion)
            da = New SqlDataAdapter(cmd)
            dtb = New DataTable()
            da.Fill(dtb)
            Dim f As DataRow = dtb.Rows(0)
            Dim Bits As Byte() = (CType((f.ItemArray(0)), Byte()))
            Dim sFile As String = "a" & GenerarNombreFichero() & ".pdf"
            Dim fs As New FileStream(sFile, FileMode.Create)
            fs.Write(Bits, 0, Convert.ToInt32(Bits.Length))
            fs.Close()
            Dim obj As System.Diagnostics.Process = New System.Diagnostics.Process()
            'Archivo = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
            Archivo = "C:\SISTEMAS\Riesgo\" + sFile
            AxAcroPDF2.src = Archivo
            'AxAcroPDF1.setCurrentPage(2)
            AxAcroPDF2.setZoom(90)
            If System.IO.File.Exists(Archivo) = True Then
                System.IO.File.Delete(Archivo)
            End If

        Catch ex As Exception
            MsgBox("Adjuntos No encontrado")
        End Try
    End Sub

    Private Sub Button12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Try

            Dim Archivo As String
            Dim conexiones3 As New CConexion
            conexiones3.conexion()
            cmd = New SqlCommand("select top 1  doc from [DocBD].[dbo].documentos where fecha='" & Trim(txtFecha.Text.ToString).Substring(0, 10) & "' and rut ='" & Trim(txtRut2.Text.ToString) & "' and tipo='DICOM' and estado=1  order by docid desc", conexiones3._conexion)
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
            'Archivo = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
            Archivo = "C:\SISTEMAS\Riesgo\" + sFile
            AxAcroPDF1.src = Archivo
            'AxAcroPDF1.setCurrentPage(2)
            AxAcroPDF1.setZoom(90)
            If System.IO.File.Exists(Archivo) = True Then
                System.IO.File.Delete(Archivo)
            End If

        Catch ex As Exception
            MsgBox("Dicom No encontrado")
        End Try
    End Sub


    Sub cargarguadados()

        Dim CADENA As String = ""

        Dim conexiones22 As New CConexion
        conexiones22.conexion()
        Dim command22 As SqlCommand = New SqlCommand("SELECT  [VALOR] FROM [_RIESGO_RENTA] WHERE ID=REPLACE('" + txtIdRenta.Text + "','.','') ORDER BY ID DESC ", conexiones22._conexion)

        conexiones22.abrir()
        Dim reader22 As SqlDataReader = command22.ExecuteReader()


        If reader22.HasRows Then
            Do While reader22.Read()
                CADENA = Trim((reader22(0).ToString))

            Loop
        Else
        End If
        reader22.Close()

        Dim conexiones2 As New CConexion
        conexiones2.conexion()
        conexiones2.abrir()
        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter
        Dim dtTable As DataTable


        command = New SqlCommand("RecibirParametros", conexiones2._conexion)
        command.CommandType = CommandType.StoredProcedure
        adapter = New SqlDataAdapter(command)
        dtTable = New DataTable
        With command.Parameters
            'Envió los parámetros que necesito
            .Add(New SqlParameter("@Parametros", SqlDbType.VarChar)).Value = CADENA
        End With

        Try
            adapter.Fill(dtTable)
            DGRentas.DataSource = dtTable
            DGRentas.AutoGenerateColumns = False
        Catch expSQL As SqlException
            MsgBox(expSQL.ToString, MsgBoxStyle.OkOnly, "SQL Exception")
            Exit Sub
        End Try

        DGRentas.AllowUserToAddRows = False




        Dim NUMERO As Integer = 0
        'cboTipo.Visible = True

        ''TIPO
        'cboTipo.SelectedItem = DataGridView1.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1

        'RENTA LIQUIDA MENSUAL
        For m = 1 To DGEmpreadosyPensionados4.ColumnCount - 3
            For i = 0 To DGEmpreadosyPensionados4.RowCount - 2
                DGEmpreadosyPensionados4.Rows(i).Cells(m).Value() = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
                NUMERO = NUMERO + 1

            Next
        Next

        'PORCENTAJE DESCUENTO
        cboPorcentajeDescuento.Text = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1

        ''DESCUENTOS DE LA ULTIMA LIQUIDACION
        For i = 0 To DGEDescuentos.RowCount - 2
            DGEDescuentos.Rows(i).Cells(1).Value() = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
            NUMERO = NUMERO + 1
        Next

        ''HABERES IMPONIBLES

        For m = 1 To DGEmpreadosyPensionados.ColumnCount - 3
            For i = 0 To DGEmpreadosyPensionados.RowCount - 2
                DGEmpreadosyPensionados.Rows(i).Cells(m).Value() = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
                NUMERO = NUMERO + 1
            Next
        Next


        ''OPCIONAL 1
        DGEmpreadosyPensionados.Rows(20).Cells(0).Value() = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1
        ''OPCIONAL 2
        DGEmpreadosyPensionados.Rows(21).Cells(0).Value() = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1
        ''OPCIONAL 3
        DGEmpreadosyPensionados.Rows(22).Cells(0).Value() = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1


        ''TASA
        'CboTasa.SelectedItem = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1
        ''PLAZO
        'CboPlazo.SelectedItem = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1

        ''COMENTARIO

        txtComentario.Text = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1

        ''HONORARIOS
        For i = 0 To DGProfesionalesyTrabajadoresIndependientes.RowCount - 2
            DGProfesionalesyTrabajadoresIndependientes.Rows(i).Cells(1).Value() = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
            NUMERO = NUMERO + 1

        Next

        ''FORMULARIOS ANUAL
        For i = 0 To DGProfesionalesyTrabajadoresIndependientes2.RowCount - 1
            DGProfesionalesyTrabajadoresIndependientes2.Rows(i).Cells(1).Value() = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
            NUMERO = NUMERO + 1
        Next


        calcularRentaLiquida()
        calcularhaberes()
        calculardescuentos()
        calcularhonorarios()

        calcularRPLEmpleado()
        calcularRPLIndependiente()
        calcularRPLTotal()



        'DGGuardado.AllowUserToAddRows = False

    End Sub

    Sub cargarrentas()

        For i = 0 To 23
            Me.DGEmpreadosyPensionados.Rows.Add()
        Next

        For i = 0 To 6
            Me.DGEmpreadosyPensionados4.Rows.Add()
        Next

        For i = 0 To 9
            Me.DGEDescuentos.Rows.Add()
        Next


        For i = 0 To 12
            Me.DGProfesionalesyTrabajadoresIndependientes.Rows.Add()
        Next


        For i = 0 To 1
            Me.DGProfesionalesyTrabajadoresIndependientes2.Rows.Add()
        Next

        DGEmpreadosyPensionados4.Rows(0).Cells(0).Value() = "Sueldo Base Mas Gratificación"
        DGEmpreadosyPensionados4.Rows(1).Cells(0).Value() = "Otros haberes imponibles variables"
        DGEmpreadosyPensionados4.Rows(2).Cells(0).Value() = "Otros haberes no imponibles"
        DGEmpreadosyPensionados4.Rows(3).Cells(0).Value() = "Descuentos Legales"
        DGEmpreadosyPensionados4.Rows(4).Cells(0).Value() = "Descuentos Deudas u Obligaciones"
        DGEmpreadosyPensionados4.Rows(5).Cells(0).Value() = "Impuesto Único de Segunda Categoría"
        DGEmpreadosyPensionados4.Rows(6).Cells(0).Value() = "TOTAL"
        DGEmpreadosyPensionados4.Columns(5).DefaultCellStyle.BackColor = Color.LightGray
        DGEmpreadosyPensionados4.Columns(5).DefaultCellStyle.BackColor = Color.LightGray
        DGEmpreadosyPensionados4.Rows(6).DefaultCellStyle.BackColor = Color.Black
        DGEmpreadosyPensionados4.Rows(6).DefaultCellStyle.ForeColor = Color.White
        DGEmpreadosyPensionados4.Rows(6).ReadOnly = True


        DGEmpreadosyPensionados.Rows(0).Cells(0).Value() = "Salario del Período / Sueldo Base / ANEF / C.J"
        DGEmpreadosyPensionados.Rows(1).Cells(0).Value() = "Gratificación/Componente Base PMG/Asignación Municipal"
        DGEmpreadosyPensionados.Rows(2).Cells(0).Value() = "Incremento Remun. Imponible / Incremento Prev."
        DGEmpreadosyPensionados.Rows(3).Cells(0).Value() = "Asignación Unica Tributable"
        DGEmpreadosyPensionados.Rows(4).Cells(0).Value() = "Bonif. Salud ley 18566"
        DGEmpreadosyPensionados.Rows(5).Cells(0).Value() = "Asig. Ley 18675 Art. 10"
        DGEmpreadosyPensionados.Rows(6).Cells(0).Value() = "Asig. Ley 18717"
        DGEmpreadosyPensionados.Rows(7).Cells(0).Value() = "Asig. Ley 19529"
        DGEmpreadosyPensionados.Rows(8).Cells(0).Value() = "Bonif. Art. 21 Ley 19429"
        DGEmpreadosyPensionados.Rows(9).Cells(0).Value() = "Asig. Sust. L, 19185"
        DGEmpreadosyPensionados.Rows(10).Cells(0).Value() = "Asig. Fiscalización"
        DGEmpreadosyPensionados.Rows(11).Cells(0).Value() = "Bono Productividad / Bono Resultado/ Asig. Merito"
        DGEmpreadosyPensionados.Rows(12).Cells(0).Value() = "Incentivo"
        DGEmpreadosyPensionados.Rows(13).Cells(0).Value() = "Semana Corrida"
        DGEmpreadosyPensionados.Rows(14).Cells(0).Value() = "Horas Extras"
        DGEmpreadosyPensionados.Rows(15).Cells(0).Value() = "Bono Vacaciones"
        DGEmpreadosyPensionados.Rows(16).Cells(0).Value() = "Bono Producción Vacaciones"
        DGEmpreadosyPensionados.Rows(17).Cells(0).Value() = "Otros Bonos"
        DGEmpreadosyPensionados.Rows(18).Cells(0).Value() = "Atención Primaria (en salud)"
        DGEmpreadosyPensionados.Rows(19).Cells(0).Value() = "Otros Haberes Imp."
        DGEmpreadosyPensionados.Rows(20).Cells(0).Value() = "Opcional 1"
        DGEmpreadosyPensionados.Rows(21).Cells(0).Value() = "Opcional 2"
        DGEmpreadosyPensionados.Rows(22).Cells(0).Value() = "Opcional 3"
        DGEmpreadosyPensionados.Rows(23).Cells(0).Value() = "TOTAL"
        DGEmpreadosyPensionados.Columns(4).DefaultCellStyle.BackColor = Color.LightGray
        DGEmpreadosyPensionados.Columns(5).DefaultCellStyle.BackColor = Color.LightGray
        DGEmpreadosyPensionados.Rows(23).DefaultCellStyle.BackColor = Color.Black
        DGEmpreadosyPensionados.Rows(23).DefaultCellStyle.ForeColor = Color.White
        DGEmpreadosyPensionados.Rows(23).ReadOnly = True

        'DGEmpreadosyPensionados.Rows(20).DefaultCellStyle.ForeColor = Color.White


        DGEDescuentos.Rows(0).Cells(0).Value() = "Seguro Salud"
        DGEDescuentos.Rows(1).Cells(0).Value() = "Seguro de Vida"
        DGEDescuentos.Rows(2).Cells(0).Value() = "Seguro Catastrófico"
        DGEDescuentos.Rows(3).Cells(0).Value() = "Préstamo Interno"
        DGEDescuentos.Rows(4).Cells(0).Value() = "Cuota sindical Empresa"
        DGEDescuentos.Rows(5).Cells(0).Value() = "Cuota extra sindical"
        DGEDescuentos.Rows(6).Cells(0).Value() = "Cuota 75% sindical"
        DGEDescuentos.Rows(7).Cells(0).Value() = "Descuentos Varios (préstamos comerciales)"
        DGEDescuentos.Rows(8).Cells(0).Value() = "Otros Descuentos"
        DGEDescuentos.Rows(9).Cells(0).Value() = "TOTAL"
        DGEDescuentos.Rows(9).DefaultCellStyle.BackColor = Color.Black
        DGEDescuentos.Rows(9).DefaultCellStyle.ForeColor = Color.White
        DGEDescuentos.Rows(9).ReadOnly = True








        DGProfesionalesyTrabajadoresIndependientes.Rows(0).Cells(0).Value() = "Mes 1"
        DGProfesionalesyTrabajadoresIndependientes.Rows(1).Cells(0).Value() = "Mes 2"
        DGProfesionalesyTrabajadoresIndependientes.Rows(2).Cells(0).Value() = "Mes 3"
        DGProfesionalesyTrabajadoresIndependientes.Rows(3).Cells(0).Value() = "Mes 4"
        DGProfesionalesyTrabajadoresIndependientes.Rows(4).Cells(0).Value() = "Mes 5"
        DGProfesionalesyTrabajadoresIndependientes.Rows(5).Cells(0).Value() = "Mes 6"
        DGProfesionalesyTrabajadoresIndependientes.Rows(6).Cells(0).Value() = "Mes 7"
        DGProfesionalesyTrabajadoresIndependientes.Rows(7).Cells(0).Value() = "Mes 8"
        DGProfesionalesyTrabajadoresIndependientes.Rows(8).Cells(0).Value() = "Mes 9"
        DGProfesionalesyTrabajadoresIndependientes.Rows(9).Cells(0).Value() = "Mes 10"
        DGProfesionalesyTrabajadoresIndependientes.Rows(10).Cells(0).Value() = "Mes 11"
        DGProfesionalesyTrabajadoresIndependientes.Rows(11).Cells(0).Value() = "Mes 12"
        DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(0).Value() = "TOTAL"
        DGProfesionalesyTrabajadoresIndependientes.Rows(12).DefaultCellStyle.BackColor = Color.Black
        DGProfesionalesyTrabajadoresIndependientes.Rows(12).DefaultCellStyle.ForeColor = Color.White
        DGProfesionalesyTrabajadoresIndependientes.Rows(12).ReadOnly = True


        DGProfesionalesyTrabajadoresIndependientes2.Rows(0).Cells(0).Value() = "Línea 547, Formulario 22"
        DGProfesionalesyTrabajadoresIndependientes2.Rows(1).Cells(0).Value() = "Línea 492, Formulario 22"
        DGProfesionalesyTrabajadoresIndependientes2.Columns(0).DefaultCellStyle.ForeColor = Color.White
        DGProfesionalesyTrabajadoresIndependientes2.Columns(0).DefaultCellStyle.BackColor = Color.Black





        RELLENA0()
        BLOQUEACOLUMNAS()



        If txtIdRenta.Text = "" Or txtIdRenta.Text = "0" Then
            LaDVERTENCIARENTA.Visible = True

        Else
            LaDVERTENCIARENTA.Visible = False
            cargarguadados()
        End If




        'For i = 0.9 To 2.01 Step 0.01
        '    CboTasa.Items.Add(i.ToString)
        'Next









    End Sub


    Sub RELLENA0()


        For m = 1 To DGEmpreadosyPensionados.ColumnCount - 1
            For i = 0 To DGEmpreadosyPensionados.RowCount - 2
                DGEmpreadosyPensionados.Rows(i).Cells(m).Value() = 0
            Next
        Next
        DGEmpreadosyPensionados.Rows(23).Cells(5).Value() = 0

        For i = 0 To DGEDescuentos.RowCount - 1
            DGEDescuentos.Rows(i).Cells(1).Value() = 0
        Next



        For m = 1 To DGEmpreadosyPensionados4.ColumnCount - 1
            For i = 0 To DGEmpreadosyPensionados4.RowCount - 2
                DGEmpreadosyPensionados4.Rows(i).Cells(m).Value() = 0
            Next
        Next
        DGEmpreadosyPensionados4.Rows(6).Cells(5).Value() = 0


        For i = 0 To DGProfesionalesyTrabajadoresIndependientes.RowCount - 1
            DGProfesionalesyTrabajadoresIndependientes.Rows(i).Cells(1).Value() = 0
        Next

        For m = 1 To DGProfesionalesyTrabajadoresIndependientes2.ColumnCount - 1
            For i = 0 To DGProfesionalesyTrabajadoresIndependientes2.RowCount - 1
                DGProfesionalesyTrabajadoresIndependientes2.Rows(i).Cells(m).Value() = 0
            Next
        Next
    End Sub
    Sub calcularRentaLiquida()


        'inicio contar filas
        For f = 0 To DGEmpreadosyPensionados4.RowCount - 2

            'verifica que las finas no tengan valores en 0 antes de sumar el promedio
            If Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(f).Cells(1).Value(), ".", "")) = 0 Or Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(f).Cells(2).Value(), ".", "")) = 0 Or Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(f).Cells(3).Value(), ".", "")) = 0 Then
                ' si alguna columna tiene valor 0 no se realiza la sumatoria
                DGEmpreadosyPensionados4.Rows(f).Cells(4).Value() = 0
            Else
                ' tisi todos los meses tienen vvalor se realiza la suma de su total
                DGEmpreadosyPensionados4.Rows(f).Cells(4).Value() = Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(f).Cells(1).Value(), ".", "")) + Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(f).Cells(2).Value(), ".", "")) + Integer.Parse(Replace(DGEmpreadosyPensionados4.Rows(f).Cells(3).Value(), ".", ""))
                DGEmpreadosyPensionados4.Rows(f).Cells(4).Value() = Puntos(DGEmpreadosyPensionados4.Rows(f).Cells(4).Value())
            End If


            'si el promedio es 0 se deja el total 0
            If DGEmpreadosyPensionados4.Rows(f).Cells(4).Value() = 0 Then
                DGEmpreadosyPensionados4.Rows(f).Cells(5).Value() = 0
            Else
                'si el promedio no es 0 se divide por 3 para sacar el promedio
                DGEmpreadosyPensionados4.Rows(f).Cells(5).Value() = Math.Round((Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(f).Cells(4).Value(), ".", "")) / 3))
            End If


            ' de deja el total con puntos
            DGEmpreadosyPensionados4.Rows(f).Cells(5).Value() = Puntos(DGEmpreadosyPensionados4.Rows(f).Cells(5).Value())

        Next



        '   CALCULO DE LOS HABERES VARIABLES 

        Dim minimo As Integer = DGEmpreadosyPensionados4.Rows(1).Cells(1).Value()
        Dim maximo As Integer = DGEmpreadosyPensionados4.Rows(1).Cells(1).Value()
        Dim resultado As Integer

        For i = 2 To 3
            If Double.Parse(minimo) > Double.Parse(DGEmpreadosyPensionados4.Rows(1).Cells(i).Value()) Then
                minimo = DGEmpreadosyPensionados4.Rows(1).Cells(i).Value()
            End If
            If Double.Parse(maximo) < Double.Parse(DGEmpreadosyPensionados4.Rows(1).Cells(i).Value()) Then
                maximo = DGEmpreadosyPensionados4.Rows(1).Cells(i).Value()
            End If
        Next

        If DGEmpreadosyPensionados4.Rows(1).Cells(4).Value() = 0 Then
            DGEmpreadosyPensionados4.Rows(1).Cells(5).Value() = 0
        Else

            If (Double.Parse(maximo) - Double.Parse(minimo)) / Double.Parse(maximo) >= 0.3 Then
                DGEmpreadosyPensionados4.Rows(1).Cells(5).Value() = Math.Round((Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(1).Cells(4).Value(), ".", "")) / 3) * 0.8)

            Else

                DGEmpreadosyPensionados4.Rows(1).Cells(5).Value() = Math.Round((Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(1).Cells(4).Value(), ".", "")) / 3))
            End If
            DGEmpreadosyPensionados4.Rows(1).Cells(5).Value() = Puntos(DGEmpreadosyPensionados4.Rows(1).Cells(5).Value())
        End If


        '   CALCULO DE LOS HABERES NO IMPONIBLES 

        If DGEmpreadosyPensionados4.Rows(2).Cells(4).Value() = 0 Then


            DGEmpreadosyPensionados4.Rows(2).Cells(5).Value() = 0
        Else
            If (Double.Parse(DGEmpreadosyPensionados4.Rows(0).Cells(4).Value()) - Double.Parse(DGEmpreadosyPensionados4.Rows(2).Cells(4).Value())) / Double.Parse(DGEmpreadosyPensionados4.Rows(0).Cells(4).Value()) < 0.5 Then

                DGEmpreadosyPensionados4.Rows(2).Cells(5).Value() = Math.Round((Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(2).Cells(4).Value(), ".", "")) / 3) * 0.5)
            Else
                DGEmpreadosyPensionados4.Rows(2).Cells(5).Value() = Math.Round((Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(2).Cells(4).Value(), ".", "")) / 3))
            End If
            DGEmpreadosyPensionados4.Rows(2).Cells(5).Value() = Puntos(DGEmpreadosyPensionados4.Rows(2).Cells(5).Value())
        End If







        DGEmpreadosyPensionados4.Rows(6).Cells(5).Value() = 0

        For f = 0 To DGEmpreadosyPensionados4.RowCount - 2
            If f <= 2 Then
                DGEmpreadosyPensionados4.Rows(6).Cells(5).Value() = Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(6).Cells(5).Value(), ".", "")) + DGEmpreadosyPensionados4.Rows(f).Cells(5).Value()
            Else
                DGEmpreadosyPensionados4.Rows(6).Cells(5).Value() = Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(6).Cells(5).Value(), ".", "")) - DGEmpreadosyPensionados4.Rows(f).Cells(5).Value()
            End If

        Next

        DGEmpreadosyPensionados4.Rows(6).Cells(5).Value() = Puntos(DGEmpreadosyPensionados4.Rows(6).Cells(5).Value())


    End Sub

    Sub BLOQUEACOLUMNAS()


        For m = 0 To DGEmpreadosyPensionados.ColumnCount - 1
            DGEmpreadosyPensionados.Columns(m).SortMode = DataGridViewColumnSortMode.NotSortable
        Next


        For m = 0 To DGEDescuentos.ColumnCount - 1
            DGEDescuentos.Columns(m).SortMode = DataGridViewColumnSortMode.NotSortable
        Next



        For m = 0 To DGEmpreadosyPensionados4.ColumnCount - 1

            DGEmpreadosyPensionados4.Columns(m).SortMode = DataGridViewColumnSortMode.NotSortable
        Next





        For i = 0 To DGProfesionalesyTrabajadoresIndependientes.ColumnCount - 1
            DGProfesionalesyTrabajadoresIndependientes.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        For m = 0 To DGProfesionalesyTrabajadoresIndependientes2.ColumnCount - 1
            DGProfesionalesyTrabajadoresIndependientes2.Columns(m).SortMode = DataGridViewColumnSortMode.NotSortable
        Next


    End Sub

    Sub calcularRPLIndependiente()

        txtRPLIndependientes.Text = Math.Round((Decimal.Round((Double.Parse(DGProfesionalesyTrabajadoresIndependientes2.Rows(0).Cells(1).Value()) - Double.Parse(DGProfesionalesyTrabajadoresIndependientes2.Rows(1).Cells(1).Value())) / 12)) + (Double.Parse(DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value()) / 2))



        txtRPLIndependientes.Text = "$" + Puntos(txtRPLIndependientes.Text)


    End Sub


    Sub calcularRPLEmpleado()


        'If cboPorcentajeDescuento.SelectedItem = "" Then
        TxtRLPEmpleados.Text = Math.Round(Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(6).Cells(5).Value(), ".", "")))
        TxtRLPEmpleados.Text = "$" + Puntos(TxtRLPEmpleados.Text)

        'Else


        '    txtMaxCuota.Text = Math.Round(((Double.Parse(Replace(DGEmpreadosyPensionados.Rows(23).Cells(5).Value(), ".", "")) * Double.Parse(cboPorcentajeDescuento.SelectedItem)) / 100) - Double.Parse(Replace(DGEDescuentos.Rows(9).Cells(1).Value(), ".", ""))) - 6000
        '    txtMaxCuota.Text = "$" + Puntos(txtMaxCuota.Text)

        '    Dim plazo As Double = 0
        '    Dim tasa As Double = 0
        '    Dim monto As Double = 0
        '    Try

        '        monto = Math.Round(Double.Parse(Replace(Replace(txtMaxCuota.Text, ".", ""), "$", "")))

        '        plazo = Double.Parse(CboPlazo.SelectedItem)
        '        tasa = Double.Parse(CboTasa.SelectedItem) / 100


        '        txtMaxMonto.Text = Math.Round(monto * (((1 + tasa) ^ plazo - 1) / (tasa * (1 + tasa) ^ plazo)))
        '        txtMaxMonto.Text = "$" + Puntos(txtMaxMonto.Text)

        '    Catch ex As Exception

        '    End Try
        '    TxtRLPEmpleados.Text = Math.Round(Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(6).Cells(5).Value(), ".", "")))
        '    TxtRLPEmpleados.Text = "$" + Puntos(TxtRLPEmpleados.Text)
        'End If



    End Sub


    Sub calcularRPLTotal()

        txtRLPTotal.Text = Double.Parse(Replace(Replace(TxtRLPEmpleados.Text, ".", ""), "$", "")) + Double.Parse(Replace(Replace(txtRPLIndependientes.Text, ".", ""), "$", ""))
        txtRLPTotal.Text = "$" + Puntos(txtRLPTotal.Text)

    End Sub

    Sub calcularhaberes()

        'inicio contar filas
        For f = 0 To DGEmpreadosyPensionados.RowCount - 2

            'verifica que las finas no tengan valores en 0 antes de sumar el promedio
            If Double.Parse(Replace(DGEmpreadosyPensionados.Rows(f).Cells(1).Value(), ".", "")) = 0 Or Double.Parse(Replace(DGEmpreadosyPensionados.Rows(f).Cells(2).Value(), ".", "")) = 0 Or Double.Parse(Replace(DGEmpreadosyPensionados.Rows(f).Cells(3).Value(), ".", "")) = 0 Then
                ' si alguna columna tiene valor 0 no se realiza la sumatoria
                DGEmpreadosyPensionados.Rows(f).Cells(4).Value() = 0
            Else
                ' tisi todos los meses tienen vvalor se realiza la suma de su total
                DGEmpreadosyPensionados.Rows(f).Cells(4).Value() = Double.Parse(Replace(DGEmpreadosyPensionados.Rows(f).Cells(1).Value(), ".", "")) + Double.Parse(Replace(DGEmpreadosyPensionados.Rows(f).Cells(2).Value(), ".", "")) + Integer.Parse(Replace(DGEmpreadosyPensionados.Rows(f).Cells(3).Value(), ".", ""))
                DGEmpreadosyPensionados.Rows(f).Cells(4).Value() = Puntos(DGEmpreadosyPensionados.Rows(f).Cells(4).Value())
            End If


            'si el promedio es 0 se deja el total 0
            If DGEmpreadosyPensionados.Rows(f).Cells(4).Value() = 0 Then
                DGEmpreadosyPensionados.Rows(f).Cells(5).Value() = 0
            Else
                'si el promedio no es 0 se divide por 3 para sacar el promedio
                DGEmpreadosyPensionados.Rows(f).Cells(5).Value() = Math.Round((Double.Parse(Replace(DGEmpreadosyPensionados.Rows(f).Cells(4).Value(), ".", "")) / 3))
            End If


            ' de deja el total con puntos
            DGEmpreadosyPensionados.Rows(f).Cells(5).Value() = Puntos(DGEmpreadosyPensionados.Rows(f).Cells(5).Value())

        Next

        DGEmpreadosyPensionados.Rows(23).Cells(5).Value() = 0
        For f = 0 To DGEmpreadosyPensionados.RowCount - 2
            DGEmpreadosyPensionados.Rows(23).Cells(5).Value() = Double.Parse(Replace(DGEmpreadosyPensionados.Rows(23).Cells(5).Value(), ".", "")) + DGEmpreadosyPensionados.Rows(f).Cells(5).Value()
        Next


        DGEmpreadosyPensionados.Rows(23).Cells(5).Value() = Puntos(DGEmpreadosyPensionados.Rows(23).Cells(5).Value())

        If frmPerfil.CbmUsuario.SelectedItem = "CCAMPOS" Or frmPerfil.CbmUsuario.SelectedItem = "HHERRERA(R)" Or frmPerfil.CbmUsuario.SelectedItem = "CAGUILAR" Then

            DGEmpreadosyPensionados.Rows(23).Cells(3).Value() = 0
            For f = 0 To DGEmpreadosyPensionados.RowCount - 2
                DGEmpreadosyPensionados.Rows(23).Cells(3).Value() = Double.Parse(Replace(DGEmpreadosyPensionados.Rows(23).Cells(3).Value(), ".", "")) + DGEmpreadosyPensionados.Rows(f).Cells(3).Value()
            Next
            DGEmpreadosyPensionados.Rows(23).Cells(3).Value() = Puntos(DGEmpreadosyPensionados.Rows(23).Cells(3).Value())

            DGEmpreadosyPensionados.Rows(23).Cells(2).Value() = 0
            For f = 0 To DGEmpreadosyPensionados.RowCount - 2
                DGEmpreadosyPensionados.Rows(23).Cells(2).Value() = Double.Parse(Replace(DGEmpreadosyPensionados.Rows(23).Cells(2).Value(), ".", "")) + DGEmpreadosyPensionados.Rows(f).Cells(2).Value()
            Next
            DGEmpreadosyPensionados.Rows(23).Cells(2).Value() = Puntos(DGEmpreadosyPensionados.Rows(23).Cells(2).Value())

            DGEmpreadosyPensionados.Rows(23).Cells(1).Value() = 0
            For f = 0 To DGEmpreadosyPensionados.RowCount - 2
                DGEmpreadosyPensionados.Rows(23).Cells(1).Value() = Double.Parse(Replace(DGEmpreadosyPensionados.Rows(23).Cells(1).Value(), ".", "")) + DGEmpreadosyPensionados.Rows(f).Cells(1).Value()
            Next
            DGEmpreadosyPensionados.Rows(23).Cells(1).Value() = Puntos(DGEmpreadosyPensionados.Rows(23).Cells(1).Value())
        End If


    End Sub
    Sub calculardescuentos()



        DGEDescuentos.Rows(9).Cells(1).Value() = 0
        For f = 0 To DGEDescuentos.RowCount - 2
            DGEDescuentos.Rows(9).Cells(1).Value() = Double.Parse(Replace(DGEDescuentos.Rows(9).Cells(1).Value(), ".", "")) + DGEDescuentos.Rows(f).Cells(1).Value()
        Next
        DGEDescuentos.Rows(9).Cells(1).Value() = Puntos(DGEDescuentos.Rows(9).Cells(1).Value())


    End Sub

    Sub calcularhonorarios()



        DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value() = 0
        For f = 0 To DGProfesionalesyTrabajadoresIndependientes.RowCount - 2
            DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value() = Double.Parse(Replace(DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value(), ".", "")) + DGProfesionalesyTrabajadoresIndependientes.Rows(f).Cells(1).Value()
        Next
        DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value() = Puntos(Math.Round(DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value() / 12))




    End Sub

    Private Sub TabPage8_Click(sender As Object, e As EventArgs) Handles TabPage8.Click

    End Sub

    Private Sub txtComentarioAgente_TextChanged(sender As Object, e As EventArgs) Handles txtComentarioAgente.TextChanged

    End Sub

    Private Sub txtNuevoMontoDisponible2_TextChanged(sender As Object, e As EventArgs) Handles txtNuevoMontoDisponible2.TextChanged
        If txtNuevoMontoDisponible2.Text = "" Then
            txtNuevoMontoDisponible2.Text = "0"
        End If
    End Sub

    Private Sub txtNuevoMontoDisponible2_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNuevoMontoDisponible2.KeyUp
        txtNuevoMontoDisponible2.Text = Puntos(txtNuevoMontoDisponible2.Text)
        txtNuevoMontoDisponible2.Select(txtNuevoMontoDisponible2.Text.Length, 0)
    End Sub

    Private Sub Button13_Click_1(sender As Object, e As EventArgs) Handles btnCondicion2.Click




        If chkTasa2.Checked = True Or chkMonto2.Checked = True Or chkPlazo2.Checked = True Then
            If cboTasaSolicitada5.SelectedItem = 0 Then
                MsgBox("La tasa a modificar no puede ser 0")
            Else


                cargarcondicion_r()
            End If



        Else

            MsgBox("Se debe selecionar una opción antes de generar la condicional")
        End If
    End Sub

    Private Sub chkTasa2_CheckedChanged(sender As Object, e As EventArgs) Handles chkTasa2.CheckedChanged
        If chkTasa2.Checked = True Then
            cboTasaSolicitada5.SelectedItem = "0"
            cboTasaSolicitada5.Enabled = True
        Else
            cboTasaSolicitada5.SelectedItem = "0"
            cboTasaSolicitada5.Enabled = False
            cargarcondicion_r()

        End If
    End Sub

    Private Sub chkMonto2_CheckedChanged(sender As Object, e As EventArgs) Handles chkMonto2.CheckedChanged
        If chkMonto2.Checked = True Then
            txtmontosolicitado5.Text = "0"
            txtmontosolicitado5.Enabled = True
        Else
            txtmontosolicitado5.Text = "0"
            txtmontosolicitado5.Enabled = False
            cargarcondicion_r()
        End If
    End Sub

    Private Sub chkPlazo2_CheckedChanged(sender As Object, e As EventArgs) Handles chkPlazo2.CheckedChanged
        If chkPlazo2.Checked = True Then
            txtPlazoSolicitado5.Text = "0"
            txtPlazoSolicitado5.Enabled = True
        Else
            txtPlazoSolicitado5.Text = "0"
            txtPlazoSolicitado5.Enabled = False
            cargarcondicion_r()
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles btnCondicionRiesgo.Click
        If txtCondicion2.Text = "" Then
            MsgBox("Riesgo no ha indicado alguna recomendación de condición")
        Else
            If chkPlazo2.Checked = True Then
                chkPlazo.Checked = True
                txtPlazoSolicitado4.Text = txtPlazoSolicitado5.Text
            End If
            If chkMonto2.Checked = True Then
                chkMonto.Checked = True
                txtmontosolicitado4.Text = txtmontosolicitado5.Text
            End If
            If chkTasa2.Checked = True Then
                chkTasa.Checked = True
                cboTasaSolicitada4.SelectedItem = cboTasaSolicitada5.SelectedItem
            End If
            cargarcondicion()
            If txtComentarioSubGerente.ReadOnly = False Then
                txtComentarioSubGerente.Text = "Se aprueba condicional"
            End If

            If txtComentarioGerente2.ReadOnly = False Then
                txtComentarioGerente2.Text = "Se aprueba condicional"
            End If

            If txtComentarioAgencia.ReadOnly = False Then

                txtComentarioAgencia.Text = "Se aprueba condicional"
            End If





            MsgBox("Cargadas las condiones")
            PGenerarCondicion.Visible = False



        End If
    End Sub

    Private Sub BtnNuevaCondicion_Click(sender As Object, e As EventArgs) Handles BtnEditarCondicion.Click
        PGenerarCondicion.Visible = True
        chkPlazo.Checked = False
        chkMonto.Checked = False
        chkTasa.Checked = False
        txtCondicion.Text = ""
    End Sub

    Private Sub DGEmpreadosyPensionados4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGEmpreadosyPensionados4.CellContentClick

    End Sub
End Class