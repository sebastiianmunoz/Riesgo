Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class frmFichaRiesgo
    Dim prestamo As String = ""
    Dim texto As String
    Dim CARGO As String
    Dim id As String = frmCreditosRiesgo.txtid.Text
    Dim plantillas As Metodos = New Metodos
    Dim tabla As New DataTable
    Dim Datos As New CDatos


    Private Sub DIGITAL()
        txtDicom.Text = "NO"
        txtAdjuntos.Text = "NO"
        If File.Exists("Z:\_____DICOM HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut.Text.ToString) + ".pdf") Then
            txtDicom.Text = "SI"
        End If
        If File.Exists("Z:\_____DOCUMENTOS HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut.Text.ToString) + ".pdf") Then
            txtAdjuntos.Text = "SI"
        End If
    End Sub






    Private Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As TabControlCancelEventArgs) Handles TabControl1.Selecting
        If Me.TabControl1.SelectedIndex = 8 Then
            AxAcroPDF1.src = "Z:\_____DICOM HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut.Text.ToString) + ".pdf"
            'MsgBox("Z:\_____DICOM HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut2.Text.ToString) + ".pdf")
            AxAcroPDF1.setZoom(90)
        End If
        If Me.TabControl1.SelectedIndex = 9 Then
            AxAcroPDF2.src = "Z:\_____DOCUMENTOS HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut.Text.ToString) + ".pdf"
            'MsgBox("Z:\_____DICOM HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut2.Text.ToString) + ".pdf")
            AxAcroPDF2.setZoom(90)
        End If
    End Sub


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
            .Parameters("@nrosocio").Value = txtNrosocio.Text
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
                    txtMonto4.Text = Format(Integer.Parse(reader8(0).ToString), "#,##0")

                Loop
            Else
            End If

            reader8.Close()

            frmEvaluar.txtPrepago.Text = txtMonto.Text




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

    Private Sub frmFichaRiesgo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim conexiones3 As New CConexion
        conexiones3.conexion()
        Dim command3 As SqlCommand = New SqlCommand("SELECT  * , 'DÍA: '+substring(fecha_solicitud,9,2)+'/'+substring(fecha_solicitud,6,2)+'/'+substring(fecha_solicitud,1,4)+' HORA: '+substring(fecha_solicitud,11,6) AS FECHA FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where  id_solicitud='" + id + "'", conexiones3._conexion)
        conexiones3.abrir()
        Dim reader3 As SqlDataReader = command3.ExecuteReader()


        If reader3.HasRows Then
            Do While reader3.Read()

                txtNrosocio.Text = (reader3(1).ToString)
                txtFecha.Text = (reader3(2).ToString)
                txtProducto.Text = (reader3(3).ToString)
                TxtObjetivo.Text = (reader3(4).ToString)
                TxtMonto.Text = (reader3(5).ToString)
                TxtMonto2.Text = (reader3(5).ToString)
                TxtMonto3.Text = (reader3(5).ToString)
                txtCapital.Text = (reader3(6).ToString)
                txtPrepago.Text = (reader3(7).ToString)
                txtPrepago2.Text = (reader3(7).ToString)
                txtMonto4.Text = (reader3(7).ToString)
                txtPrepagos.Text = (reader3(8).ToString)
                txtPrepagos2.Text = (reader3(8).ToString)
                txtPlazo.Text = (reader3(9).ToString)
                txtPlazo2.Text = (reader3(9).ToString)
                txtPlazo3.Text = (reader3(9).ToString)
                TxtCuota.Text = (reader3(10).ToString)
                TxtCuota2.Text = (reader3(10).ToString)
                txtCuota3.Text = (reader3(10).ToString)

                txtTasa.Text = (reader3(11).ToString)
                txtTasa2.Text = (reader3(11).ToString)
                txtDiasGracia.Text = (reader3(12).ToString)
                txtDiasGracia2.Text = (reader3(12).ToString)
                txtNrocuotas.Text = (reader3(13).ToString)
                txtFechaPrimeraCuota.Text = (reader3(14).ToString)
                txtFormaPago.Text = (reader3(15).ToString)
                txtTipoRenta.Text = (reader3(16).ToString)
                txtProtesto.Text = (reader3(17).ToString)
                txtComportamiento.Text = (reader3(18).ToString)
                txtEdeudafinanciera.Text = (reader3(19).ToString)
                txtEdeudaHipo.Text = (reader3(20).ToString)
                txtEdeudaConsumo.Text = (reader3(21).ToString)
                txtEdeudaComercial.Text = (reader3(22).ToString)
                txtEDeudadVencidas.Text = (reader3(23).ToString)
                txtELineaCredito.Text = (reader3(24).ToString)
                txtENumeroAcreedores.Text = (reader3(25).ToString)

                txtItotaldeuda.Text = (reader3(26).ToString)
                txtItotaldeuda2.Text = (reader3(26).ToString)
                txtInternaTotalDeuda.Text = (reader3(26).ToString)

                txtInternaTotalDeuda.Text = (reader3(26).ToString)

                txtIdeudaConsumo.Text = (reader3(27).ToString)
                txtInternaDeudaConsumo.Text = (reader3(27).ToString)

                txtIdeudaComercial.Text = (reader3(28).ToString)
                txtInternaDeudaComercial.Text = (reader3(28).ToString)

                txtIDeudaIndirecta.Text = (reader3(29).ToString)
                txtInternaDeudaIndirecta.Text = (reader3(29).ToString)

                txtIPagoMensual.Text = (reader3(30).ToString)
                txtIPagoMensual2.Text = (reader3(30).ToString)
                txtInternaPagoMensual.Text = (reader3(30).ToString)

                txtRLP.Text = (reader3(31).ToString)
                txtCargaFinanciera.Text = (reader3(32).ToString)
                txtExternaAcreditado.Text = (reader3(33).ToString)
                txtActivos.Text = (reader3(34).ToString)
                txtPropiedades.Text = (reader3(35).ToString)
                txtVehiculos.Text = (reader3(36).ToString)
                txtRentaLiquidaDepurada.Text = (reader3(37).ToString)

                txtLeverage.Text = (reader3(38).ToString)
                txtLeverage2.Text = (reader3(38).ToString)

                txtCapacidad.Text = (reader3(39).ToString)
                txtCapacidad2.Text = (reader3(39).ToString)

                txtvalidaciones2.Text = (reader3(40).ToString)
                txtEjecutivo.Text = (reader3(41).ToString)
                txtSucursal.Text = (reader3(42).ToString)
                txtComentarioEjecutiva.Text = (reader3(43).ToString)
                'txtComentarioRiesgo.Text = (reader3(44).ToString)
                txtPuntaje.Text = (reader3(49).ToString)
                txtAntiguedadLab.Text = (reader3(50).ToString)
                TxtEdad.Text = (reader3(51).ToString)
                txtAntiguedadSoc.Text = (reader3(52).ToString)

                txtCapitalAcumulado.Text = (reader3(67).ToString)


                txtCuotasPrepagadas.Text = (reader3(71).ToString)
                txtCuotasPrepagadas2.Text = (reader3(71).ToString)
                txtCuotasPrestamos.Text = (reader3(71).ToString)

                txtPuntajes.Text = (reader3(77).ToString)

                If (Trim(reader3(87).ToString) = Trim(reader3(1).ToString)) Then
                    Timer1.Enabled = True
                    Timer1.Interval = 250
                End If


                txtComportamientoClasificaciones.Text = (reader3(90).ToString)
                txtComportamientoCapital.Text = (reader3(91).ToString)
                txtClasificacionBaja.Text = (reader3(92).ToString)
                txtAumentoTasa.Text = (reader3(93).ToString)
                txtReref.Text = (reader3("renegocia_refinancia").ToString)

                'txtNrosocio.Text = (reader3(1).ToString)
                'txtFecha.Text = (reader3(2).ToString)
                'txtProducto.Text = (reader3(3).ToString)
                'TxtObjetivo.Text = (reader3(4).ToString)
                'TxtMonto.Text = (reader3(5).ToString)
                'TxtMonto2.Text = (reader3(5).ToString)
                'TxtMonto3.Text = (reader3(5).ToString)
                'txtCapital.Text = (reader3(6).ToString)
                'txtPrepago.Text = (reader3(7).ToString)
                'txtPrepago2.Text = (reader3(7).ToString)
                'txtPrepagos.Text = (reader3(8).ToString)
                'txtPlazo.Text = (reader3(9).ToString)
                'txtPlazo2.Text = (reader3(9).ToString)
                'txtPlazo3.Text = (reader3(9).ToString)
                'TxtCuota.Text = (reader3(10).ToString)
                'TxtCuota2.Text = (reader3(10).ToString)
                'txtTasa.Text = (reader3(11).ToString)
                'txtTasa2.Text = (reader3(11).ToString)
                'txtDiasGracia.Text = (reader3(12).ToString)
                'txtDiasGracia2.Text = (reader3(12).ToString)
                'txtNrocuotas.Text = (reader3(13).ToString)
                'txtFechaPrimeraCuota.Text = (reader3(14).ToString)
                'txtFormaPago.Text = (reader3(15).ToString)
                'txtTipoRenta.Text = (reader3(16).ToString)

                'txtProtesto.Text = (reader3(17).ToString)
                'txtComportamiento.Text = (reader3(18).ToString)

                'txtEdeudafinanciera.Text = (reader3(19).ToString)
                'txtEdeudaHipo.Text = (reader3(20).ToString)
                'txtEdeudaConsumo.Text = (reader3(21).ToString)
                'txtEdeudaComercial.Text = (reader3(22).ToString)
                'txtEDeudadVencidas.Text = (reader3(23).ToString)
                'txtELineaCredito.Text = (reader3(24).ToString)
                'txtENumeroAcreedores.Text = (reader3(25).ToString)
                'txtItotaldeuda.Text = (reader3(26).ToString)
                'txtIdeudaConsumo.Text = (reader3(27).ToString)
                'txtIdeudaComercial.Text = (reader3(28).ToString)
                'txtIDeudaIndirecta.Text = (reader3(29).ToString)
                'txtIPagoMensual.Text = (reader3(30).ToString)
                'txtRLP.Text = (reader3(31).ToString)
                'txtCargaFinanciera.Text = (reader3(32).ToString)
                'txtExternaAcreditado.Text = (reader3(33).ToString)
                'txtActivos.Text = (reader3(34).ToString)
                'txtPropiedades.Text = (reader3(35).ToString)
                'txtVehiculos.Text = (reader3(36).ToString)
                'txtRentaLiquidaDepurada.Text = (reader3(37).ToString)

                'txtLeverage.Text = (reader3(38).ToString)
                'txtCapacidad.Text = (reader3(39).ToString)

                'txtvalidaciones2.Text = (reader3(40).ToString)
                'txtEjecutivo.Text = (reader3(41).ToString)
                'txtSucursal.Text = (reader3(42).ToString)
                'txtComentarioEjecutiva.Text = (reader3(43).ToString)
                'txtPuntaje.Text = (reader3(49).ToString)
                'txtAntiguedadLab.Text = (reader3(50).ToString)
                'TxtEdad.Text = (reader3(51).ToString)
                'txtAntiguedadSoc.Text = (reader3(52).ToString)
                ''txtCapitalAcumulado.Text = (reader3(58).ToString)
                'txtCapitalAcumulado.Text = (reader3(67).ToString)
                'txtCuotasPrepagadas.Text = (reader3(71).ToString)

                'txtPuntajes.Text = (reader3(77).ToString)

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
            command4 = New SqlCommand("SELECT convert(varchar,[RUT])+'-'+ convert(varchar,[DVRUT]),[FechaIng],[FechaNac],[FechaContrato],[Nombres]+' '+[Paterno]+' '+[Materno],[EstadoCivil],[CantCargas],[TipoViv],_INSTITUCIONES.DESCRIPCION,[SUELDOLIQUIDO] , RUT FROM [_SOCIOS] left join _INSTITUCIONES on _SOCIOS.CODINST= _INSTITUCIONES.CODINS where NROSOCIO='" + txtNrosocio.Text + "'", conexiones3._conexion)

        ElseIf (Timer1.Enabled = True) Then
            'MsgBox("ES PRE-SOCIO")
            command4 = New SqlCommand("SELECT convert(varchar,[RUT])+'-'+ convert(varchar,[DVRUT]),[FechaSolicitud],[FechaNac],[FechaContrato],[Nombres]+' '+[Paterno]+' '+[Materno],[EstadoCivil],[CantCargas],[TipoViv],_INSTITUCIONES.DESCRIPCION,[SUELDOLIQUIDO] , RUT FROM [_PRESOCIOS] left join _INSTITUCIONES on _PRESOCIOS.CODINST= _INSTITUCIONES.CODINS where NROSOCIO='" + txtNrosocio.Text + "'", conexiones3._conexion)
        End If

        'Dim command4 As SqlCommand = New SqlCommand("SELECT convert(varchar,[RUT])+'-'+ convert(varchar,[DVRUT]),[FechaIng],[FechaNac],[FechaContrato],[Nombres]+' '+[Paterno]+' '+[Materno],[EstadoCivil],[CantCargas],[TipoViv],_INSTITUCIONES.DESCRIPCION,[SUELDOLIQUIDO]FROM [_SOCIOS] left join _INSTITUCIONES on _SOCIOS.CODINST= _INSTITUCIONES.CODINS where NROSOCIO='" + txtNrosocio.Text + "'", conexiones4._conexion)
        conexiones4.abrir()
        Dim reader4 As SqlDataReader = command4.ExecuteReader()


        If reader4.HasRows Then
            Do While reader4.Read()
                txtRut.Text = (reader4(0).ToString)
                'InputDateString1 = (reader4(1).ToString)
                'InputDateString2 = (reader4(2).ToString)
                'InputDateString4 = (reader4(3).ToString)
                TxtNombre.Text = (reader4(4).ToString)
                estadocivil = (reader4(5).ToString)
                'txtCargasFamiliares.Text = (reader4(6).ToString)
                tipovivienda = (reader4(7).ToString)
                'txtProtesto.Text = (reader4(8).ToString)
                'txtRemuneracion.Text = (reader4(9).ToString)
                Datos._Compromiso_Rut = (reader4(10).ToString)


            Loop
        Else
        End If

        reader4.Close()

        If estadocivil = "C" Then
            txtEstadoCivil.Text = "Casado en Sociedad Conyugal"
        ElseIf estadocivil = "S" Then
            txtEstadoCivil.Text = "Soltero"
        ElseIf estadocivil = "V" Then
            txtEstadoCivil.Text = "Viudo"
        ElseIf estadocivil = "P" Then
            txtEstadoCivil.Text = "Divorciado"
        ElseIf estadocivil = "B" Then
            txtEstadoCivil.Text = "Casado Separación de Bienes"
        Else
            txtEstadoCivil.Text = "Sin registro"
        End If


        If tipovivienda = "1" Then
            txtTipoVivienda.Text = "Propia"
        ElseIf tipovivienda = "2" Then
            txtTipoVivienda.Text = "Propia con Dividendos"
        ElseIf tipovivienda = "3" Then
            txtTipoVivienda.Text = "Arrendada"
        ElseIf tipovivienda = "4" Then
            txtTipoVivienda.Text = "Cedida o Gratuita"
        Else
            txtTipoVivienda.Text = "Sin registro"
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



        Dim cadena As String = txtRut.Text
        Dim numeros() As String = cadena.Split("-")

        Dim rut As String = numeros(0)



        Dim conexiones9 As New CConexion
        conexiones9.conexion()
        'Dim command9 As SqlCommand = New SqlCommand(" select s.NROSOCIO from _SOCIOS as s inner join _RIESGO_PRESTAMOS_ULTIMO as p on s.NROSOCIO=p.NROSOCIO  where RUT='" + rut + "' and s.Estado=0 AND P.ADICIONAL=0 AND  P.NROSOCIO>0 AND P.TIPOCREDITO='C' AND DEUDA='SI'", conexiones9._conexion)
        Dim command9 As SqlCommand = New SqlCommand("select corcredito from _prestdiario where nrosocio=" + txtNrosocio.Text + " and estado ='C' and TIPOCREDITO='C' AND RECONSTRU=12 AND  CORCREDITO IN ( SELECT OPERCRED FROM _PRESTAMOS2 where nrosocio=" + txtNrosocio.Text + "  GROUP BY OPERCRED  HAVING SUM(CARGO-ABONO)>0)", conexiones9._conexion)
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
        'Dim command9 As SqlCommand = New SqlCommand("select corcredito from _prestdiario where nrosocio=" + txtNrosocio2.Text + " and estado ='C' AND RECONSTRU=12 AND  CORCREDITO IN ( SELECT OPERCRED FROM _PRESTAMOS2 where nrosocio=" + txtNrosocio2.Text + "  GROUP BY OPERCRED  HAVING SUM(CARGO-ABONO)>0)", conexiones9._conexion)
        Dim command6 As SqlCommand = New SqlCommand("select corcredito from _prestdiario where nrosocio=" + txtNrosocio.Text + " and estado ='C' and TIPOCREDITO='C' AND RECONSTRU=12 AND  CORCREDITO IN ( SELECT OPERCRED FROM _PRESTAMOS2 where nrosocio=" + txtNrosocio.Text + "  GROUP BY OPERCRED  HAVING SUM(CARGO-ABONO)>0)", conexiones9._conexion)
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
        Dim command22 As SqlCommand = New SqlCommand("select corcredito from _prestdiario where nrosocio=" + txtNrosocio.Text + " and estado ='C' and TIPOCREDITO='C' AND RECONSTRU in (1,2,3,4,5,6,7,10) AND  CORCREDITO IN ( SELECT OPERCRED FROM _PRESTAMOS2 where nrosocio=" + txtNrosocio.Text + "  GROUP BY OPERCRED  HAVING SUM(CARGO-ABONO)>0)", conexiones9._conexion)
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
        Dim command1 As SqlCommand = New SqlCommand("select corcredito from _prestdiario where nrosocio=" + txtNrosocio.Text + " and estado ='C' and TIPOCREDITO='C' AND RECONSTRU=11 AND  CORCREDITO IN ( SELECT OPERCRED FROM _PRESTAMOS2 where nrosocio=" + txtNrosocio.Text + "  GROUP BY OPERCRED  HAVING SUM(CARGO-ABONO)>0)", conexiones9._conexion)
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



        'AxAcroPDF1.src = "Z:\_____DICOM HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut.Text.ToString) + ".pdf"
        ''MsgBox("Z:\_____DICOM HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut2.Text.ToString) + ".pdf")
        'AxAcroPDF1.setZoom(90)


        'AxAcroPDF2.src = "Z:\_____DOCUMENTOS HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut.Text.ToString) + ".pdf"
        ''MsgBox("Z:\_____DICOM HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut2.Text.ToString) + ".pdf")
        'AxAcroPDF2.setZoom(90)


        DIGITAL()



        txtCapcid.Text = "La capacidad de pago no debe mayor a 20% o menor 0%"
        txtPuntaj.Text = "El puntaje debe ser superior a los 500 puntos"
        calcular()

        If (Integer.Parse(Replace(txtCapacidad.Text, "%", "")) > 20 Or Integer.Parse(Replace(txtCapacidad.Text, "%", "")) <= 0) Then
            txtCapcid.ForeColor = Color.Red
        End If

        If (Integer.Parse(txtPuntaje.Text) < 500) Then
            txtPuntaj.ForeColor = Color.Red
        End If

        'Me.ReportViewer1.RefreshReport()
    End Sub


    Sub calcular()

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

        'JG

        Return ("REALIZADO CON EXITO")
    End Function


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim Datos As New CDatos()
        Dim Plantillas As New CCEstadosGeneral

        If (txtComentarioRiesgo.Text.Length > 250) Then

            MsgBox("El comentario sobrepasa los 250 caracteres")
        Else

            If (Trim(txtComentarioRiesgo.Text) = "") Then
                MsgBox("Se debe agregar un COMENTARIO antes de enviar")
            Else

                If (CbEstado.SelectedItem = "") Then
                    MsgBox("Se debe selecionar un ESTADO antes de enviar")
                Else
                    Datos._id_solicitud = txtCodigoId.Text.ToString
                    Datos._Comentario_Riesgo = txtComentarioRiesgo.Text
                    Datos._Riesgo_Perfil = Trim(frmPerfil.CbmUsuario.SelectedItem.ToString)

                    If Trim(CbEstado.SelectedItem.ToString) = "Enviar para aprobación" Then
                        Datos._Estado = "Enviado por Dep.riesgo como RECOMENDADO"
                    ElseIf Trim(CbEstado.SelectedItem.ToString) = "Enviar como no recomendado" Then
                        Datos._Estado = "Enviado por Dep.riesgo como NO RECOMENDADO"
                    Else
                        Datos._Estado = "DESCARTADO"
                    End If

                    Datos._PreAprobacion_Riesgo = Trim(CbEstado.SelectedItem.ToString)


                    If Plantillas.Actualizar_Prestamo_enviado_Riesgo(Datos) Then

                        MsgBox("Credito Actualizado Con exito")
                        Dim plantillas2 As Metodos = New Metodos
                        Dim tabla As New DataTable
                        plantillas2._tabla.Rows.Clear()
                        plantillas2._tabla.Columns.Clear()



                        If plantillas2.Consultar_Creditos_Riesgo Then
                            tabla = plantillas2.tabla
                            frmCreditosRiesgo.DGreditosRiesgo.DataSource = tabla
                        End If
                        Me.Close()

                    Else
                        MessageBox.Show("Error al consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If




                End If




            End If

        End If



    End Sub

    Private Sub txtComentarioRiesgo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComentarioRiesgo.KeyUp
        txtcaracteres.Text = 250 - (txtComentarioRiesgo.Text.Length)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtComentarioRiesgo.Text = txtComentarioRiesgo.Text + texto
    End Sub

    Private Sub Calcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TxtMonto3.Text = Replace(TxtMonto3.Text, ".", "")
        txtPrepago2.Text = Replace(txtPrepago2.Text, ".", "")

        texto = ""

        Try


            If (TxtMonto3.Text = "") Then
                MsgBox("Se debe agregar un monto")
            Else
                If (txtPlazo3.Text = "") Then
                    MsgBox("Se debe agregar un plazo")
                Else

                    If (Integer.Parse(txtPrepago2.Text) > Integer.Parse(TxtMonto3.Text)) Then
                        MsgBox("El monto del prepago no puede ser mayor al monto solicitado")
                    Else





                        Me.DgAmortizacion.Rows.Clear()

                        Dim monto As Integer = Integer.Parse(TxtMonto3.Text)
                        Dim interes As Double = txtTasa2.Text / 100
                        Dim diasgracia As Integer = Integer.Parse(txtDiasGracia2.Text)
                        Dim plazo As Integer = Integer.Parse(txtPlazo3.Text)
                        Dim Cargodiasdegracia As Integer = Decimal.Round(((monto * interes) * diasgracia) / 30)
                        Dim InteresAplicado As Integer = Decimal.Round(plazo * (monto + Cargodiasdegracia) * (1 / ((((1 - (1 / ((1 + (interes)) ^ plazo)))) / (interes)))) - (monto + Cargodiasdegracia))
                        Dim InteresAplicadoder1 As Integer = Decimal.Round(plazo * (Cargodiasdegracia) * (1 / ((((1 - (1 / ((1 + (interes)) ^ plazo)))) / (interes)))) - (Cargodiasdegracia))
                        Dim InteresAplicadoder2 As Integer = Decimal.Round((Cargodiasdegracia + InteresAplicadoder1) / plazo)

                        Dim SaldoPrestamo As Integer = Decimal.Round(monto + Cargodiasdegracia + InteresAplicado)
                        Dim Dividendo As Integer = Decimal.Round((monto + Cargodiasdegracia + InteresAplicado) / plazo)
                        Dim InteresTabla As Integer = Decimal.Round((monto * interes) + InteresAplicadoder2)
                        Dim Capital As Integer = Decimal.Round(Dividendo - InteresTabla)
                        Dim SaldoMonto As Integer = Decimal.Round(monto - Capital)

                        txtCuota3.Text = Format(Integer.Parse(Dividendo), "#,##0")


                        'Cargodiasdegracia = ((Integer.Parse(TxtMonto.Text) * interes) * Integer.Parse(CboDiasdeGracia.SelectedItem)) / 30
                        'Cargodiasdegracia = ((Integer.Parse(TxtMonto.Text) * interes) * Integer.Parse(CboDiasdeGracia.SelectedItem)) / 30
                        'Dim montogracia As Integer
                        'TxtCuota.Text = Decimal.Round((Integer.Parse(TxtMonto.Text) + diasdegracia) * ((interes * (1 + interes) ^ Integer.Parse(CboCuotas.SelectedItem)) / ((1 + interes) ^ Integer.Parse(CboCuotas.SelectedItem) - 1)))
                        'montogracia = Decimal.Round(Integer.Parse(TxtMonto.Text) + diasdegracia)



                        For i = 1 To Integer.Parse(plazo)
                            Me.DgAmortizacion.Rows.Add()
                        Next

                        Dim nrocuotas As Integer = 1

                        For i = 0 To (Integer.Parse(plazo) - 1)

                            DgAmortizacion.Rows(i).Cells(0).Value() = nrocuotas
                            DgAmortizacion.Rows(i).Cells(1).Value() = txtCuota3.Text
                            nrocuotas = nrocuotas + 1

                        Next



                        'CAPITAL
                        DgAmortizacion.Rows(0).Cells(2).Value() = Capital
                        'INTERES
                        DgAmortizacion.Rows(0).Cells(3).Value() = InteresTabla
                        'DEUDA
                        DgAmortizacion.Rows(0).Cells(4).Value() = SaldoMonto
                        'saldo prestamo
                        DgAmortizacion.Rows(0).Cells(5).Value() = SaldoPrestamo


                        ''CAPITAL
                        'DgAmortizacion.Rows(0).Cells(2).Value() = DgAmortizacion.Rows(0).Cells(1).Value() - DgAmortizacion.Rows(0).Cells(3).Value()
                        ''INTERES
                        'DgAmortizacion.Rows(0).Cells(3).Value() = Decimal.Round(montogracia * interes)
                        ''DEUDA
                        'DgAmortizacion.Rows(0).Cells(4).Value() = Decimal.Round(Integer.Parse(montogracia) - DgAmortizacion.Rows(0).Cells(2).Value())

                        Dim v As Integer = 0

                        For i = 1 To (Integer.Parse(txtPlazo3.Text) - 1)

                            DgAmortizacion.Rows(i).Cells(5).Value() = Decimal.Round(DgAmortizacion.Rows(v).Cells(5).Value()) - Decimal.Round(DgAmortizacion.Rows(v).Cells(1).Value())
                            DgAmortizacion.Rows(i).Cells(3).Value() = Decimal.Round(((Decimal.Round(DgAmortizacion.Rows(v).Cells(4).Value())) * interes) + InteresAplicadoder2)
                            DgAmortizacion.Rows(i).Cells(2).Value() = Decimal.Round(DgAmortizacion.Rows(i).Cells(1).Value()) - Decimal.Round(DgAmortizacion.Rows(i).Cells(3).Value())
                            DgAmortizacion.Rows(i).Cells(4).Value() = Decimal.Round(DgAmortizacion.Rows(v).Cells(4).Value()) - Decimal.Round(DgAmortizacion.Rows(i).Cells(2).Value())

                            'DgAmortizacion.Rows(i).Cells(2).Value() = DgAmortizacion.Rows(i).Cells(1).Value() - DgAmortizacion.Rows(i).Cells(3).Value()
                            'DgAmortizacion.Rows(i).Cells(4).Value() = Decimal.Round(DgAmortizacion.Rows(v).Cells(4).Value() - DgAmortizacion.Rows(i).Cells(2).Value())
                            v = v + 1

                        Next

                        DgAmortizacion.Rows(Integer.Parse(txtPlazo3.Text) - 1).Cells(1).Value() = Integer.Parse(Replace(TxtCuota2.Text, ".", "")) + DgAmortizacion.Rows(Integer.Parse(txtPlazo3.Text) - 1).Cells(4).Value()
                        DgAmortizacion.Rows(Integer.Parse(txtPlazo3.Text) - 1).Cells(4).Value() = 0




                        'TxtMonto3.Text = Format(Integer.Parse(TxtMonto3.Text), "#,##0")



                        'Catch ex As Exception

                        '    MsgBox(ex.Message)
                        '    'MsgBox("No deben estar los campos en blanco")
                        'End Try
                    End If
                End If
            End If


            txtCapacidad3.Text = 0
            txtCapacidad3.Text = Math.Round((((Integer.Parse(Replace(txtCuota3.Text, ".", "")) + Integer.Parse(Replace(txtIPagoMensual.Text, ".", "")) + Integer.Parse(Replace(txtCapital.Text, ".", "")))) / (Integer.Parse(Replace(txtRentaLiquidaDepurada.Text, ".", "")))) * 100, 2, MidpointRounding.ToEven)

            txtLeverage3.Text = 0
            txtLeverage3.Text = Math.Round(((Integer.Parse(Replace(txtEdeudaConsumo.Text, ".", "")) + Integer.Parse(Replace(txtEdeudaComercial.Text, ".", "")) + Integer.Parse(Replace(txtELineaCredito.Text, ".", "")) + Integer.Parse(Replace(TxtMonto3.Text, ".", "")) + Integer.Parse(Replace(txtItotaldeuda.Text, ".", ""))) / Integer.Parse(Replace(txtRLP.Text, ".", ""))), 0, MidpointRounding.ToEven)


            texto = "Monto por un valor de $" + TxtMonto3.Text + " ,con plazo de " + txtPlazo3.Text + " y con cuota de " + txtCuota3.Text

        Catch ex As Exception

        End Try

    End Sub



    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click




        TxtMonto3.Text = Replace(TxtMonto3.Text, ".", "")
        txtMonto4.Text = Replace(txtMonto4.Text, ".", "")

        texto = ""

        Try




            If (TxtMonto3.Text = "") Then
                MsgBox("Se debe agregar un monto")
            Else
                If (txtPlazo3.Text = "") Then
                    MsgBox("Se debe agregar un plazo")
                Else

                    If (Integer.Parse(txtMonto4.Text) > Integer.Parse(TxtMonto3.Text)) Then
                        MsgBox("El monto del prepago no puede ser mayor al monto solicitado")
                    Else





                        Me.DgAmortizacion.Rows.Clear()

                        Dim monto As Integer = Integer.Parse(TxtMonto3.Text)
                        Dim interes As Double = txtTasa2.Text / 100
                        Dim diasgracia As Integer = Integer.Parse(txtDiasGracia2.Text)
                        Dim plazo As Integer = Integer.Parse(txtPlazo3.Text)



                        Dim Cargodiasdegracia As Integer = Decimal.Round(((monto * interes) * diasgracia) / 30)
                        Dim InteresAplicado As Integer = Decimal.Round(plazo * (monto + Cargodiasdegracia) * (1 / ((((1 - (1 / ((1 + (interes)) ^ plazo)))) / (interes)))) - (monto + Cargodiasdegracia))
                        Dim InteresAplicadoder1 As Integer = Decimal.Round(plazo * (Cargodiasdegracia) * (1 / ((((1 - (1 / ((1 + (interes)) ^ plazo)))) / (interes)))) - (Cargodiasdegracia))
                        Dim InteresAplicadoder2 As Integer = Decimal.Round((Cargodiasdegracia + InteresAplicadoder1) / plazo)

                        Dim SaldoPrestamo As Integer = Decimal.Round(monto + Cargodiasdegracia + InteresAplicado)
                        Dim Dividendo As Integer = Decimal.Round((monto + Cargodiasdegracia + InteresAplicado) / plazo)
                        Dim InteresTabla As Integer = Decimal.Round((monto * interes) + InteresAplicadoder2)
                        Dim Capital As Integer = Decimal.Round(Dividendo - InteresTabla)
                        Dim SaldoMonto As Integer = Decimal.Round(monto - Capital)

                        txtCuota3.Text = Format(Integer.Parse(Dividendo), "#,##0")


                        'Cargodiasdegracia = ((Integer.Parse(TxtMonto.Text) * interes) * Integer.Parse(CboDiasdeGracia.SelectedItem)) / 30
                        'Cargodiasdegracia = ((Integer.Parse(TxtMonto.Text) * interes) * Integer.Parse(CboDiasdeGracia.SelectedItem)) / 30
                        'Dim montogracia As Integer
                        'TxtCuota.Text = Decimal.Round((Integer.Parse(TxtMonto.Text) + diasdegracia) * ((interes * (1 + interes) ^ Integer.Parse(CboCuotas.SelectedItem)) / ((1 + interes) ^ Integer.Parse(CboCuotas.SelectedItem) - 1)))
                        'montogracia = Decimal.Round(Integer.Parse(TxtMonto.Text) + diasdegracia)



                        For i = 1 To Integer.Parse(plazo)
                            Me.DgAmortizacion.Rows.Add()
                        Next

                        Dim nrocuotas As Integer = 1

                        For i = 0 To (Integer.Parse(plazo) - 1)

                            DgAmortizacion.Rows(i).Cells(0).Value() = nrocuotas
                            DgAmortizacion.Rows(i).Cells(1).Value() = txtCuota3.Text
                            nrocuotas = nrocuotas + 1

                        Next



                        'CAPITAL
                        DgAmortizacion.Rows(0).Cells(2).Value() = Capital
                        'INTERES
                        DgAmortizacion.Rows(0).Cells(3).Value() = InteresTabla
                        'DEUDA
                        DgAmortizacion.Rows(0).Cells(4).Value() = SaldoMonto
                        'saldo prestamo
                        DgAmortizacion.Rows(0).Cells(5).Value() = SaldoPrestamo


                        ''CAPITAL
                        'DgAmortizacion.Rows(0).Cells(2).Value() = DgAmortizacion.Rows(0).Cells(1).Value() - DgAmortizacion.Rows(0).Cells(3).Value()
                        ''INTERES
                        'DgAmortizacion.Rows(0).Cells(3).Value() = Decimal.Round(montogracia * interes)
                        ''DEUDA
                        'DgAmortizacion.Rows(0).Cells(4).Value() = Decimal.Round(Integer.Parse(montogracia) - DgAmortizacion.Rows(0).Cells(2).Value())

                        Dim v As Integer = 0

                        For i = 1 To (Integer.Parse(txtPlazo3.Text) - 1)

                            DgAmortizacion.Rows(i).Cells(5).Value() = Decimal.Round(DgAmortizacion.Rows(v).Cells(5).Value()) - Decimal.Round(DgAmortizacion.Rows(v).Cells(1).Value())
                            DgAmortizacion.Rows(i).Cells(3).Value() = Decimal.Round(((Decimal.Round(DgAmortizacion.Rows(v).Cells(4).Value())) * interes) + InteresAplicadoder2)
                            DgAmortizacion.Rows(i).Cells(2).Value() = Decimal.Round(DgAmortizacion.Rows(i).Cells(1).Value()) - Decimal.Round(DgAmortizacion.Rows(i).Cells(3).Value())
                            DgAmortizacion.Rows(i).Cells(4).Value() = Decimal.Round(DgAmortizacion.Rows(v).Cells(4).Value()) - Decimal.Round(DgAmortizacion.Rows(i).Cells(2).Value())

                            'DgAmortizacion.Rows(i).Cells(2).Value() = DgAmortizacion.Rows(i).Cells(1).Value() - DgAmortizacion.Rows(i).Cells(3).Value()
                            'DgAmortizacion.Rows(i).Cells(4).Value() = Decimal.Round(DgAmortizacion.Rows(v).Cells(4).Value() - DgAmortizacion.Rows(i).Cells(2).Value())
                            v = v + 1

                        Next

                        DgAmortizacion.Rows(Integer.Parse(plazo) - 1).Cells(1).Value() = Integer.Parse(Replace(txtCuota3.Text, ".", "")) + DgAmortizacion.Rows(Integer.Parse(plazo) - 1).Cells(4).Value()
                        DgAmortizacion.Rows(Integer.Parse(plazo) - 1).Cells(4).Value() = 0




                        'TxtMonto3.Text = Format(Integer.Parse(TxtMonto3.Text), "#,##0")



                        'Catch ex As Exception

                        '    MsgBox(ex.Message)
                        '    'MsgBox("No deben estar los campos en blanco")
                        'End Try
                    End If
                End If
            End If




            txtCapacidad3.Text = 0
            txtCapacidad3.Text = Math.Round((((Double.Parse(Replace(txtCuota3.Text, ".", "")) + Double.Parse(Replace(txtInternaPagoMensual.Text, ".", "")) + Integer.Parse(Replace(txtCapital.Text, ".", "")))) / (Double.Parse(Replace(txtRentaLiquidaDepurada.Text, ".", "")))) * 100, 2, MidpointRounding.ToEven)

            txtLeverage3.Text = 0
            txtLeverage3.Text = Math.Round(((Integer.Parse(Replace(txtEdeudaConsumo.Text, ".", "")) + Integer.Parse(Replace(txtEdeudaComercial.Text, ".", "")) + Integer.Parse(Replace(txtELineaCredito.Text, ".", "")) + Integer.Parse(Replace(TxtMonto3.Text, ".", "")) + Integer.Parse(Replace(txtInternaTotalDeuda.Text, ".", ""))) / Integer.Parse(Replace(txtRLP.Text, ".", ""))), 0, MidpointRounding.ToEven)



            texto = "Monto por un valor de $" + TxtMonto3.Text + " ,con plazo de " + txtPlazo3.Text + " y con cuota de " + txtCuota3.Text


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        prestamo = LboxConsumo.SelectedItem
        agregar()

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



            texto = "Monto por un valor de $" + TxtMonto3.Text + " ,con plazo de " + txtPlazo3.Text + " y con cuota de " + txtCuota3.Text
        Catch ex As Exception
        End Try

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
            txtMonto4.Text = 0
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


    'Private Sub TxtObjetivo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtObjetivo.TextChanged
    '    If txtObjetivo2.Text = "Renegociación" Then
    '        txtObjetivo2.BackColor = Color.Red
    '        txtAviso.Visible = True
    '    End If
    'End Sub

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

    Private Sub Actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Actualizar.Click
        AxAcroPDF1.src = "Z:\_____DICOM HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut.Text.ToString) + ".pdf"
        AxAcroPDF1.setZoom(90)
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        AxAcroPDF2.src = "Z:\_____DOCUMENTOS HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut.Text.ToString) + ".pdf"
        AxAcroPDF2.setZoom(90)
    End Sub

    Private Sub Dicom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dicom.Click

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        'Dim usuario As String
        'Dim rut As String

        'MsgBox(Datos._Compromiso_Rut)

        'Datos._Compromiso_Usuario = Trim(frmPerfil.CbmUsuario.SelectedItem.ToString)
        'usuario = Datos._Compromiso_Usuario
        'rut = Trim(Datos._Compromiso_Rut.ToString)



        'Dim conexiones71 As New CConexion
        'conexiones71.conexion()
        'conexiones71.abrir()
        'Dim cmd71 As New SqlCommand("_Riesgo_Comportamiento", conexiones71._conexion)
        'cmd71.CommandType = CommandType.StoredProcedure
        'Dim prm71 As SqlParameter = _
        'New SqlParameter("@rut", SqlDbType.NChar, 30)
        'Dim prm71_2 As SqlParameter = _
        'New SqlParameter("@usuario", SqlDbType.NChar, 30)
        'cmd71.Parameters.Add(prm71)
        'cmd71.Parameters.Add(prm71_2)
        'With cmd71
        '    .Parameters("@rut").Value = rut
        '    .Parameters("@usuario").Value = usuario
        'End With
        'Dim dr71 As SqlDataReader = cmd71.ExecuteReader(CommandBehavior.CloseConnection)
        'conexiones71.cerrar()


        'plantillas._tabla.Rows.Clear()
        'plantillas._tabla.Columns.Clear()
        'If plantillas.Consultar_Comportamiento(Datos) Then
        '    tabla = plantillas.tabla
        '    DGComportamiento.DataSource = tabla
        'End If



        'Dim conexiones9 As New CConexion
        'conexiones9.conexion()
        'Dim command9 As SqlCommand = New SqlCommand("SELECT TIPO,COMENTARIO FROM _RIESGO_COMPORTAMIENTO_COMENTARIOS where USUARIO='" + usuario + "' AND RUT ='" + rut + "'", conexiones9._conexion)
        'conexiones9.abrir()
        'Dim reader9 As SqlDataReader = command9.ExecuteReader()

        'If reader9.HasRows Then
        '    Do While reader9.Read()

        '        If reader9(0).ToString.Trim = "GENERAL MESES" Then
        '            txtGeneral.Text = reader9(1).ToString.Trim
        '        ElseIf reader9(0).ToString.Trim = "1MES" Then
        '            txt1Mes.Text = reader9(1).ToString.Trim
        '        End If

        '    Loop
        'Else
        'End If

        'reader9.Close()




    End Sub




    Private Sub Button10_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim usuario As String
        Dim rut As String


        Dim conexiones1 As New CConexion
        conexiones1.conexion()
        Dim command1 As SqlCommand = New SqlCommand("SELECT convert(varchar,[RUT]) from _socios where SOCIOSINO='S' and RTRIM(NROSOCIO)='" + txtNrosocio.Text + "'", conexiones1._conexion)
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

    Private Sub CbEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbEstado.SelectedIndexChanged
        If Trim(CbEstado.SelectedItem) = "Enviar para aprobación" Then
            txtComentarioRiesgo.BackColor = Color.Green
            txtComentarioRiesgo.ForeColor = Color.White
            CbEstado.BackColor = Color.Green
            CbEstado.ForeColor = Color.White
        ElseIf Trim(CbEstado.SelectedItem) = "Enviar como no recomendado" Then
            txtComentarioRiesgo.BackColor = Color.Red
            txtComentarioRiesgo.ForeColor = Color.White
            CbEstado.BackColor = Color.Red
            CbEstado.ForeColor = Color.White
        ElseIf Trim(CbEstado.SelectedItem) = "DESCARTADO" Then
            txtComentarioRiesgo.BackColor = Color.Black
            txtComentarioRiesgo.ForeColor = Color.White
            CbEstado.BackColor = Color.Black
            CbEstado.ForeColor = Color.White
        Else
            txtComentarioRiesgo.BackColor = Color.White
            txtComentarioRiesgo.ForeColor = Color.Black
            CbEstado.BackColor = Color.White
        End If


    End Sub



    Private Sub txtAumentoTasa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAumentoTasa.TextChanged
        If txtAumentoTasa.Text.Trim = "0" Then
            txtAumentoTasa.BackColor = Color.Green
        Else
            txtAumentoTasa.BackColor = Color.Red
        End If
    End Sub



    Private Sub txtReref_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReref.TextChanged
        If txtReref.Text.Trim = "NO" Then
            txtReref.BackColor = Color.Green
        Else
            txtReref.BackColor = Color.Red
        End If
    End Sub
End Class