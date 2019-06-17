
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient


Public Class frmEvaluar

    Dim resultado As Integer = 0
    Dim resultado2 As Integer = 0
    Public años As Double
    Dim Datos As New CDatos
    Dim aumentoTasa As Integer = 0
    Public rentavisible1 As String = "NO"
    Public rentavisible2 As String = "NO"
    Dim sRet As String
    Dim plantillas As Metodos = New Metodos
    Dim tabla As New DataTable
    Dim contar = 0
    Public TASASALTAS As String = "NO"



    Sub versolicitudes()


        Datos._Rut = txtRut2.Text.ToString.Trim

        plantillas._tabla2.Rows.Clear()
        plantillas._tabla2.Columns.Clear()
        If plantillas.Consultar_prestamos_historicosxNrosocio2(Datos) Then
            tabla = plantillas.tabla2
            DGHistoricoPrestamos.DataSource = tabla

        End If

        DGHistoricoPrestamos.AllowUserToAddRows = False

        DGHistoricoPrestamos.Visible = True
        If DGHistoricoPrestamos.RowCount = 0 Then
            LblSOLICITUDES.Visible = True
        Else
            LblSOLICITUDES.Visible = False
        End If


    End Sub
    Sub cargarCompromisos()
        If (Cbotipo.SelectedItem = "SOCIO") Then

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
            'conexiones1.cerrar()
            Datos._Compromiso_Usuario = Trim(frmPerfil.CbmUsuario.SelectedItem.ToString)
            usuario = Datos._Compromiso_Usuario
            rut = Trim(Datos._Compromiso_Rut.ToString)
            'MsgBox(Datos._Compromiso_Rut)
            'MsgBox(usuario)
            'MsgBox(rut)

            Dim conexiones71 As New CConexion
            conexiones71.conexion()
            conexiones71.abrir()
            Dim cmd71 As New SqlCommand("_Riesgo_ComportamientoEjecutiva2", conexiones71._conexion)
            cmd71.CommandType = CommandType.StoredProcedure
            Dim prm71 As SqlParameter =
            New SqlParameter("@rut", SqlDbType.NVarChar)
            Dim prm71_2 As SqlParameter =
            New SqlParameter("@usuario", SqlDbType.NVarChar)
            cmd71.Parameters.Add(prm71)
            cmd71.Parameters.Add(prm71_2)
            With cmd71
                .Parameters("@rut").Value = rut
                .Parameters("@usuario").Value = usuario
            End With
            Dim dr71 As SqlDataReader = cmd71.ExecuteReader(CommandBehavior.CloseConnection)
            conexiones71.cerrar()


            Dim conexiones9 As New CConexion
            conexiones9.conexion()
            Dim command9 As SqlCommand = New SqlCommand("SELECT TIPO,COMENTARIO FROM _RIESGO_COMPORTAMIENTO_COMENTARIOS where USUARIO='" + usuario + "' AND RUT ='" + rut + "'", conexiones9._conexion)
            conexiones9.abrir()
            Dim reader9 As SqlDataReader = command9.ExecuteReader()

            If reader9.HasRows Then
                Do While reader9.Read()
                    'MsgBox(reader9(0).ToString.Trim)
                    'MsgBox(reader9(1).ToString.Trim)
                    If reader9(0).ToString.Trim = "24 MESES CLASIFICACION EJECUTIVO" Then
                        TxtComportamientoClasificacion.Text = reader9(1).ToString.Trim
                    ElseIf reader9(0).ToString.Trim = "24 MESES CAPITAL EJECUTIVO" Then
                        txtComportamientoCapital.Text = reader9(1).ToString.Trim
                    ElseIf reader9(0).ToString.Trim = "GENERAL MESES EJECUTIVO" Then
                        txtClasificacionBaja.Text = reader9(1).ToString.Trim
                    Else
                        txtComportamientoCapital.Text = "0"
                        TxtComportamientoClasificacion.Text = "0"
                    End If

                Loop
            Else
            End If
            reader9.Close()
            'conexiones9.cerrar()
        Else
            txtClasificacionBaja.Text = "NUNCA HA SIDO CLASIFICADO"
            txtComportamientoCapital.Text = "0"
            TxtComportamientoClasificacion.Text = "0"
        End If
    End Sub

    Sub cargarprestamo()
        CboProducto.Items.Clear()
        Lreferenciado.Text = ""


        CboProducto.Items.Add("")
        Dim conexiones1 As New CConexion
        conexiones1.conexion()
        Dim command1 As SqlCommand = New SqlCommand("  SELECT rtrim(c.DESCRIPCION),[MONTOMIN],[MONTOMAX] FROM [_NOMBRECREDITO_VIGENCIA] as n inner join _nombrecredito  as c on n.CODNOM=c.CODNOM where FECHADESDE<=  CONVERT(VARCHAR(8), GETDATE(), 112) and FECHAHASTA>=  CONVERT(VARCHAR(8), GETDATE(), 112) and n.CODNOM NOT IN (12,17,20,21,22)", conexiones1._conexion)
        conexiones1.abrir()
        Dim reader1 As SqlDataReader = command1.ExecuteReader()

        If reader1.HasRows Then
            Do While reader1.Read()
                CboProducto.Items.Add(reader1(0).ToString)
            Loop
        Else
        End If
        reader1.Close()

        'conexiones1.cerrar()
        'MsgBox(CboProtestosyMorocidades.SelectedItem.ToString.Trim)
        'MsgBox(CboFormaDePago.SelectedItem.ToString.Trim)
        'MsgBox(txtClasificacionBaja.Text.Trim)
        'If CboProtestosyMorocidades.SelectedItem.ToString.Trim = "Sin Antecedentes" And CboFormaDePago.SelectedItem.ToString.Trim <> "PLANILLA" And (txtClasificacionBaja.Text.Trim = "A" Or txtClasificacionBaja.Text.Trim = "B" Or txtClasificacionBaja.Text.Trim = "NUNCA HA SIDO CLASIFICADO") Then
        '    Dim conexiones5 As New CConexion
        '    conexiones5.conexion()
        '    Dim command5 As SqlCommand = New SqlCommand(" SELECT c.DESCRIPCION FROM [_NOMBRECREDITO_VIGENCIA] as n inner join _nombrecredito  as c on n.CODNOM=c.CODNOM where FECHADESDE<=  CONVERT(VARCHAR(8), GETDATE(), 112) and FECHAHASTA>=  CONVERT(VARCHAR(8), GETDATE(), 112) and n.CODNOM  IN (21)", conexiones5._conexion)
        '    conexiones5.abrir()
        '    Dim reader5 As SqlDataReader = command5.ExecuteReader()

        '    If reader5.HasRows Then
        '        Do While reader5.Read()
        '            CboProducto.Items.Add(reader5(0).ToString)
        '        Loop
        '    Else
        '    End If
        '    reader5.Close()
        '    Lreferenciado.ForeColor = Color.Green
        '    Lreferenciado.Text = "TIENE DISPONIBLE UN CRÉDITO EXPRESS OCTUBRE POR UN MONTO IGUAL O SUPERIOR A $3.000.000 A UNA TASA DEL 1.19%"
        'End If


        If CboFormaDePago.SelectedItem.ToString.Trim <> "PLANILLA" Then
            Dim DISPONIBLE As String = "NO"
            Dim conexiones5 As New CConexion
            conexiones5.conexion()
            Dim command5 As SqlCommand = New SqlCommand(" SELECT c.DESCRIPCION FROM [_NOMBRECREDITO_VIGENCIA] as n inner join _nombrecredito  as c on n.CODNOM=c.CODNOM where FECHADESDE<=  CONVERT(VARCHAR(8), GETDATE(), 112) and FECHAHASTA>=  CONVERT(VARCHAR(8), GETDATE(), 112) and n.CODNOM  IN (22)", conexiones5._conexion)
            conexiones5.abrir()
            Dim reader5 As SqlDataReader = command5.ExecuteReader()

            If reader5.HasRows Then
                Do While reader5.Read()
                    CboProducto.Items.Add(reader5(0).ToString)
                    DISPONIBLE = reader5(0).ToString
                Loop
            Else
            End If
            reader5.Close()
            'conexiones5.cerrar()
            If DISPONIBLE <> "NO" Then
                Lreferenciado.ForeColor = Color.Green
                Lreferenciado.Text = "TIENE DISPONIBLE UN CRÉDITO PROMOCIONAL CON PAGO AL MES SUBSIGUIENTE"
            End If

        End If

        If txtReferenciado.Text.Trim = "SI" Then


            If txtTipoRefenciado.Text.Trim = "6" Or txtTipoRefenciado.Text.Trim = "7" Then

                If Cbotipo.SelectedItem.ToString.Trim = "SOCIO" Then
                    Dim USADO As Integer
                    Dim conexiones5 As New CConexion
                    conexiones5.conexion()
                    Dim command5 As SqlCommand = New SqlCommand(" SELECT  COUNT(RECONSTRU) FROM [_PRESTDIARIO] where NROSOCIO=4970 and ESTADO in ('C','S') AND RECONSTRU  IN (17) ", conexiones5._conexion)
                    conexiones5.abrir()
                    Dim reader5 As SqlDataReader = command5.ExecuteReader()
                    If reader5.HasRows Then
                        Do While reader5.Read()
                            USADO = (reader5(0).ToString)
                        Loop
                    Else
                    End If
                    reader5.Close()
                    'conexiones5.cerrar()

                    If USADO = 0 Then
                        Dim conexiones6 As New CConexion
                        conexiones6.conexion()
                        Dim command6 As SqlCommand = New SqlCommand(" SELECT c.DESCRIPCION FROM [_NOMBRECREDITO_VIGENCIA] as n inner join _nombrecredito  as c on n.CODNOM=c.CODNOM where FECHADESDE<=  CONVERT(VARCHAR(8), GETDATE(), 112) and FECHAHASTA>=  CONVERT(VARCHAR(8), GETDATE(), 112) and n.CODNOM  IN (17)", conexiones6._conexion)
                        conexiones6.abrir()
                        Dim reader6 As SqlDataReader = command6.ExecuteReader()
                        If reader6.HasRows Then
                            Do While reader6.Read()
                                CboProducto.Items.Add(reader6(0).ToString)
                            Loop
                        Else
                        End If
                        reader6.Close()
                        'conexiones6.cerrar()
                        Lreferenciado.ForeColor = Color.Green
                        Lreferenciado.Text = "TIENE DISPONIBLE UN CRÉDITO CAMPAÑA SOCIO"
                    Else
                        Lreferenciado.ForeColor = Color.Red
                        Lreferenciado.Text = "REGISTRA UN CREDITO CAMPAÑA SOCIO CONTABILIZADO O SOLICITADO"
                    End If


                Else

                    Dim conexiones5 As New CConexion
                    conexiones5.conexion()
                    Dim command5 As SqlCommand = New SqlCommand(" SELECT c.DESCRIPCION FROM [_NOMBRECREDITO_VIGENCIA] as n inner join _nombrecredito  as c on n.CODNOM=c.CODNOM where FECHADESDE<=  CONVERT(VARCHAR(8), GETDATE(), 112) and FECHAHASTA>=  CONVERT(VARCHAR(8), GETDATE(), 112) and n.CODNOM  IN (17)", conexiones5._conexion)
                    conexiones5.abrir()
                    Dim reader5 As SqlDataReader = command5.ExecuteReader()

                    If reader5.HasRows Then
                        Do While reader5.Read()
                            CboProducto.Items.Add(reader5(0).ToString)
                        Loop
                    Else
                    End If
                    reader5.Close()
                    'conexiones5.cerrar()
                    Lreferenciado.ForeColor = Color.Green
                    Lreferenciado.Text = "TIENE DISPONIBLE UN CRÉDITO CAMPAÑA SOCIO"

                End If



            ElseIf txtTipoRefenciado.Text.Trim = "8" Then


                If Cbotipo.SelectedItem.ToString.Trim = "SOCIO" Then

                    Dim USADO As Integer
                    Dim conexiones5 As New CConexion
                    conexiones5.conexion()
                    Dim command5 As SqlCommand = New SqlCommand(" SELECT  COUNT(RECONSTRU) FROM [_PRESTDIARIO] where NROSOCIO=4970 and ESTADO in ('C','S') AND RECONSTRU  IN (20) ", conexiones5._conexion)
                    conexiones5.abrir()
                    Dim reader5 As SqlDataReader = command5.ExecuteReader()
                    If reader5.HasRows Then
                        Do While reader5.Read()
                            USADO = (reader5(0).ToString)
                        Loop
                    Else
                    End If
                    reader5.Close()
                    'conexiones5.cerrar()

                    If USADO = 0 Then
                        Dim conexiones6 As New CConexion
                        conexiones6.conexion()
                        Dim command6 As SqlCommand = New SqlCommand(" SELECT c.DESCRIPCION FROM [_NOMBRECREDITO_VIGENCIA] as n inner join _nombrecredito  as c on n.CODNOM=c.CODNOM where FECHADESDE<=  CONVERT(VARCHAR(8), GETDATE(), 112) and FECHAHASTA>=  CONVERT(VARCHAR(8), GETDATE(), 112) and n.CODNOM  IN (20)", conexiones6._conexion)
                        conexiones6.abrir()
                        Dim reader6 As SqlDataReader = command6.ExecuteReader()
                        If reader6.HasRows Then
                            Do While reader6.Read()
                                CboProducto.Items.Add(reader6(0).ToString)
                            Loop
                        Else
                        End If
                        reader6.Close()
                        'conexiones6.cerrar()
                        Lreferenciado.ForeColor = Color.Green
                        Lreferenciado.Text = "TIENE DISPONIBLE UN CRÉDITO ANIVERSARIO REFERENCIADO"
                    Else
                        Lreferenciado.ForeColor = Color.Red
                        Lreferenciado.Text = "REGISTRA UN CRÉDITO ANIVERSARIO REFERENCIADO"
                    End If


                Else

                    Dim conexiones5 As New CConexion
                    conexiones5.conexion()
                    Dim command5 As SqlCommand = New SqlCommand(" SELECT c.DESCRIPCION FROM [_NOMBRECREDITO_VIGENCIA] as n inner join _nombrecredito  as c on n.CODNOM=c.CODNOM where FECHADESDE<=  CONVERT(VARCHAR(8), GETDATE(), 112) and FECHAHASTA>=  CONVERT(VARCHAR(8), GETDATE(), 112) and n.CODNOM  IN (20)", conexiones5._conexion)
                    conexiones5.abrir()
                    Dim reader5 As SqlDataReader = command5.ExecuteReader()

                    If reader5.HasRows Then
                        Do While reader5.Read()
                            CboProducto.Items.Add(reader5(0).ToString)
                        Loop
                    Else
                    End If
                    reader5.Close()
                    'conexiones5.cerrar()
                    Lreferenciado.ForeColor = Color.Green
                    Lreferenciado.Text = "TIENE DISPONIBLE UN CRÉDITO ANIVERSARIO REFERENCIADO"

                End If
            End If
        End If


        CboProducto.SelectedItem = ""
    End Sub



    Private Sub frmEvaluar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CboFormaDePago.SelectedItem = ""
        CboProtestosyMorocidades.SelectedItem = ""
        cboFueradeZona.SelectedItem = ""


        CboEjecutivo.Items.Clear()
        CboEjecutivo.Items.Add("SIN EJECUTIVO")
        Dim conexiones2 As New CConexion
        conexiones2.conexion()
        Dim command2 As SqlCommand = New SqlCommand("SELECT RTRIM([NOMBRE]) FROM [_USUARIOS] where modificatasa=1 and vigente <>0", conexiones2._conexion)
        conexiones2.abrir()
        Dim reader2 As SqlDataReader = command2.ExecuteReader()

        If reader2.HasRows Then
            Do While reader2.Read()
                CboEjecutivo.Items.Add(reader2(0).ToString)
            Loop
        Else
        End If

        reader2.Close()
        'conexiones2.cerrar()




        'cboInteres.SelectedItem = "1,900"
        'Dim dias As Integer = 45
        'CboDiasdeGracia.SelectedItem = dias.ToString


        txtDeudaHipotecaria.Text = "0"
        txtDeudaComercial.Text = "0"
        txtDeudaConsumo.Text = "0"
        txtDeudaVencida.Text = "0"
        txtLineaCredito.Text = "0"



        Pic1.Visible = False
        Pic1A.Visible = False

        Pic2.Visible = False
        Pic2A.Visible = False

        'Pic3.Visible = False
        'Pic3A.Visible = False

        'Pic4.Visible = False
        'Pic4A.Visible = False

        Pic5.Visible = False
        Pic5A.Visible = False




        'DGEmpreadosyPensionados.Rows(DGEmpreadosyPensionados.CurrentRow.Index).Cells(0).Value = "a"



        'testingggg
        'Cbotipo.SelectedItem = "SOCIO"
        'CboEjecutivo.SelectedItem = "SIN EJECUTIVO"
        'txtNrosocio.Text = "1166"
        'txtCapital.Text = "50000"
        'TxtCuota.Text = "1828408"
        'txtRentaLiquidaDepurada.Text = "3422328"
        'txtInternaPagoMensual.Text = "500000"
        'chknocontrato.Checked = True

        'CboProtestosyMorocidades.SelectedItem = "Sin Antecedentes"
        'cboFueradeZona.SelectedItem = "NO"
        'cboPlataforma.SelectedItem = "Plataforma Comercial"
        'TxtMonto.Text = "50000000"
        'TxtDeudaFinanciera.Text = Format(24500000, "#,##0")
        'txtDeudaHipotecaria.Text = "15000000"
        'txtDeudaComercial.Text = "5000000"
        'txtDeudaConsumo.Text = "3000000"
        'txtDeudaVencida.Text = "10000000"
        'txtLineaCredito.Text = "1500000"
        'txtNumeroAcreedoresFinan.Text = "20"
        'CboCuotas.SelectedItem = "10"
        'CboProducto.SelectedItem = "Comercial"
        'CboObjetivo.SelectedItem = "Arreglo de vivienda"
        'CboCuotas.SelectedItem = "40"
        'CboFormaDePago.SelectedItem = "Pac"
        'CboRenta.SelectedItem = "Empleados"
        'CboProtestosyMorocidades.SelectedItem = "Registra Protestos y Morosidades Vigentes"
        'cboCompartamiento.SelectedItem = "En los últimos 24 meses registra cuotas con morosidad mayor a 90 días"
        'DGEmpreadosyPensionados.Rows(0).Cells(1).Value() = "600000"
        'DGEmpreadosyPensionados.Rows(0).Cells(2).Value() = "600000"
        'DGEmpreadosyPensionados.Rows(0).Cells(3).Value() = "600000"


        'CboFormaDePago.SelectedItem = "PLANILLA"
        'CboFormaDePago2.SelectedItem = "Directemar"

        'CboFormaDePago.SelectedItem = "PAC"
        'CboFormaDePago2.SelectedItem = "BancoEstado"
        'testingggg



    End Sub
    Sub VerificaCampana()
        Dim conexiones9 As New CConexion
        Dim verifica As String = "No"

        If Cbotipo.SelectedItem.ToString = "SOCIO" Then


            conexiones9.conexion()
            'Dim command9 As SqlCommand = New SqlCommand(" select p.corcredito from _SOCIOS as s inner join _RIESGO_PRESTAMOS_ULTIMO as p on s.NROSOCIO=p.NROSOCIO  where RUT='" + rut + "' and s.Estado=0 AND P.ADICIONAL=0 AND  P.NROSOCIO>0 AND P.TIPOCREDITO='C' AND DEUDA='SI'", conexiones9._conexion)

            Dim command9 As SqlCommand = New SqlCommand("SELECT  [NROSOCIO] FROM _RIESGO_EXCEPCIONES_CAMPANA where NROSOCIO = " + txtNrosocio.Text + "", conexiones9._conexion)

            conexiones9.abrir()
            Dim reader9 As SqlDataReader = command9.ExecuteReader()

            If reader9.HasRows Then
                Do While reader9.Read()

                    verifica = reader9(0).ToString
                Loop
            Else
            End If
            reader9.Close()
        End If


        txtCampanaRefinancia.Text = verifica
    End Sub


    Friend Function VERIFICA()
        Dim Nrosocio As String = txtNrosocio.Text


        Dim conexiones3 As New CConexion
        conexiones3.conexion()
        Dim command3 As SqlCommand
        If (Trim(Cbotipo.SelectedItem) = "SOCIO") Then
            'MsgBox("ES SOCIO")
            command3 = New SqlCommand("SELECT COUNT(*) FROM _SOCIOS  where SOCIOSINO='S' AND  NROSOCIO='" + Nrosocio + "' and Estado=0 ", conexiones3._conexion)



        ElseIf (Trim(Cbotipo.SelectedItem) = "PRE-SOCIO") Then
            'MsgBox("ES PRE-SOCIO")
            command3 = New SqlCommand("SELECT COUNT(*) FROM _PRESOCIOS  where SOCIOSINO='S' AND  NROSOCIO='" + Nrosocio + "' and Estado=0", conexiones3._conexion)

        End If

        conexiones3.abrir()
        Dim reader3 As SqlDataReader = command3.ExecuteReader()


        If reader3.HasRows Then
            Do While reader3.Read()



                If reader3(0).ToString.ToString.Trim = "0" Then

                    sRet = Cbotipo.SelectedItem.ToString + " NO EXISTE"
                Else
                    sRet = "EXISTE"
                End If


            Loop
        Else
        End If

        reader3.Close()

        conexiones3.cerrar()

    End Function







    Sub consultardatos()
        VERIFICA()
        If (sRet <> "EXISTE") Then
            'MsgBox(sRet)
        Else


            txtRut.Text = ""
            txtNombre.Text = ""
            txtCargasFamiliares.Text = ""
            txtInstitucion.Text = ""
            txtRemuneracion.Text = ""
            txtTipoDeSocio.Text = ""
            'txtConvenio.Text = ""
            txtReferenciado.Text = ""
            txtEdad.Text = ""
            txtScoringSexo.Text = ""
            txtScoringAntiguedad.Text = ""
            txtScoringMorosidades.Text = "NO"


            Dim contadorERROR As Integer = 0
            Dim contadorADVERTENCIA As Integer = 0


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

            frmPrepago.Show()
            frmPrepago.Visible = False
            frmRentas.Show()
            frmRentas.Visible = False

            AVISO.Show()
            AVISO.Visible = False

            If txtNrosocio.Text = "" Then
                MsgBox("Debe Indicar nroSocio")
            Else
                btnBuscar.BackColor = Color.White
                txtNrosocio.BackColor = Color.White
                TXTANUNCIO2.Visible = True
                Dim Nrosocio As String = txtNrosocio.Text
                Dim dt1 As DateTime
                Dim dt2 As DateTime
                Dim dt3 As DateTime
                Dim InputDateString1 As String = ""
                Dim InputDateString2 As String = ""
                Dim InputDateString3 As String = ""
                Dim estadocivil As String = ""
                Dim tipovivienda As String = ""



                Dim conexiones3 As New CConexion
                conexiones3.conexion()
                Dim command3 As SqlCommand
                'MsgBox(Trim(Cbotipo.SelectedItem))
                If (Trim(Cbotipo.SelectedItem) = "SOCIO") Then
                    'MsgBox("ES SOCIO")
                    command3 = New SqlCommand("SELECT convert(varchar,[RUT])+'-'+ convert(varchar,[DVRUT]),[FechaIng],[FechaNac],[FechaContrato],[Nombres]+' '+[Paterno]+' '+[Materno],[EstadoCivil],[CantCargas],[TipoViv],_INSTITUCIONES.DESCRIPCION,[SUELDOLIQUIDO] , _TIPO_DE_SOCIO.DESCRIPCION as tipo, '' ,case when left(MotivoIncorpora,1) in ('6','7','8') then 'SI' ELSE 'NO' END as REFERENCIADO,left(MotivoIncorpora,1) as MotivoIncorpora,convert(varchar,[RUT]) AS RUT2 ,_COMUNAS.descripcion as REGION ,DATEDIFF(year,convert(date,Fechanac,100),convert(date,SYSDATETIME(),100)) as edad,sexo ,DATEDIFF(year,convert(date,FechaING,100),convert(date,SYSDATETIME(),100)) as ANTIGUEDAD, _SOCIOS.CODINST FROM [_SOCIOS] left join _INSTITUCIONES on _SOCIOS.CODINST= _INSTITUCIONES.CODINS left join (SELECT [CODIGO],[DESCRIPCION] FROM [_COMUNAS]) as _COMUNAS on  _SOCIOS.Region= _COMUNAS.CODIGO left join _TIPO_DE_SOCIO on  _SOCIOS.tipo= _TIPO_DE_SOCIO.TIPO where NROSOCIO='" + Nrosocio + "' AND SOCIOSINO='S'", conexiones3._conexion)

                ElseIf (Trim(Cbotipo.SelectedItem) = "PRE-SOCIO") Then
                    'MsgBox("ES PRE-SOCIO")
                    command3 = New SqlCommand("SELECT convert(varchar,[RUT])+'-'+ convert(varchar,[DVRUT]),[FechaSolicitud],[FechaNac],[FechaContrato],[Nombres]+' '+[Paterno]+' '+[Materno],[EstadoCivil],[CantCargas],[TipoViv],_INSTITUCIONES.DESCRIPCION,[SUELDOLIQUIDO] , _TIPO_DE_SOCIO.DESCRIPCION as tipo ,'' , case when left(MotivoIncorpora,1) in ('6','7','8') then 'SI' ELSE 'NO' END as REFERENCIADO,left(MotivoIncorpora,1) as MotivoIncorpora ,convert(varchar,[RUT]) AS RUT2 ,_COMUNAS.descripcion as REGION ,DATEDIFF(year,convert(date,Fechanac,100),convert(date,SYSDATETIME(),100)) as edad, sexo , 0 AS ANTIGUEDAD, _PRESOCIOS.CODINST FROM [_PRESOCIOS] left join _INSTITUCIONES on _PRESOCIOS.CODINST= _INSTITUCIONES.CODINS left join (SELECT [CODIGO],[DESCRIPCION] FROM [_COMUNAS]) as _COMUNAS on  _PRESOCIOS.Region= _COMUNAS.CODIGO left join _TIPO_DE_SOCIO on  _PRESOCIOS.tipo= _TIPO_DE_SOCIO.TIPO where NROSOCIO='" + Nrosocio + "' AND SOCIOSINO='S'", conexiones3._conexion)
                    'LblSOLICITUDES.Visible = True
                    'DGHistoricoPrestamos.Visible = False

                End If

                conexiones3.abrir()
                Dim reader3 As SqlDataReader = command3.ExecuteReader()


                If reader3.HasRows Then
                    Do While reader3.Read()


                        txtRut.Text = (reader3(0).ToString)

                        InputDateString1 = (reader3(1).ToString)
                        InputDateString2 = (reader3(2).ToString)
                        InputDateString3 = (reader3(3).ToString)
                        txtNombre.Text = (reader3(4).ToString)
                        estadocivil = (reader3(5).ToString)
                        txtCargasFamiliares.Text = (reader3(6).ToString)
                        tipovivienda = (reader3(7).ToString)
                        txtInstitucion.Text = (reader3(8).ToString)
                        txtRemuneracion.Text = (reader3(9).ToString)
                        txtTipoDeSocio.Text = (reader3(10).ToString)
                        'txtConvenio.Text = (reader3(11).ToString)
                        txtReferenciado.Text = (reader3(12).ToString)
                        txtTipoRefenciado.Text = (reader3("MotivoIncorpora").ToString)
                        txtRut2.Text = (reader3("RUT2").ToString)
                        txtRegion.Text = (reader3("REGION").ToString)
                        txtScoringEdad.Text = (reader3("EDAD").ToString)
                        txtScoringSexo.Text = (reader3("SEXO").ToString)
                        txtScoringAntiguedad.Text = (reader3("ANTIGUEDAD").ToString)
                        txtCOD_INST.Text = (reader3("CODINST").ToString)
                        'If txtCOD_INST.Text = "" Then
                        '    MsgBox("Debe Ingresar institución en Sistema de Cuentas Corrientes")
                        'End If
                    Loop
                Else
                End If

                reader3.Close()




                versolicitudes()




                If (Trim(Cbotipo.SelectedItem) = "SOCIO") Then

                    'Dim conexiones24 As New CConexion
                    'conexiones24.conexion()
                    'Dim command24 As SqlCommand = New SqlCommand("if exists ( select CC1.NROSOCIO from _prestdiario AS CC1 INNER JOIN (select * from _SOCIOS where sociosino='s') AS CC2 ON CC1.NROSOCIO=CC2.NROSOCIO left JOIN ( SELECT  CORCREDITO,CASE WHEN SUM(CUOTA) IS NULL  THEN 0 ELSE SUM(CUOTA) END  AS SUMATORIA_CUOTA FROM [_AMORTIZACION] WHERE case len([MESDESCUENTO]) when 1 then   convert(varchar,[ANODESCUENTO])+'0'+convert(varchar,[MESDESCUENTO]) else convert(varchar,[ANODESCUENTO])+convert(varchar,[MESDESCUENTO]) end > LEFT(CONVERT(varchar, DATEADD(MONTH,-1,GETDATE()),112),6) GROUP BY CORCREDITO )  AS CC7 ON CC1.CORCREDITO=CC7.CORCREDITO LEFT JOIN (SELECT opercred,SUMATORIA_POR_PAGAR=sum(cargo)-sum(case when FECHAACELERADO<>'' AND CODCONCEPTO=83  then 0 else abono end) FROM [_PRESTAMOS2] as cc1 left join ( select corcredito , fechaacelerado,cobercorfo from _prestdiario)as cc2 on cc1.opercred=cc2.corcredito group by opercred) AS CC8 ON CC1.CORCREDITO=CC8.OPERCRED left join (select corcredito,cc2.COBRANZAMES-1 as graciacobranza from _prestdiario as cc1 inner join _FORMAPAGO as cc2 on cc1.formadepago=cc2.CODFOR)  AS cc9 on cc9.corcredito=cc1.corcredito where CC1.estado='C' and (CASE   WHEN PRIMERDIVIDENDO=0 THEN 0 WHEN SUMATORIA_POR_PAGAR=0 THEN 0 ELSE (convert(decimal (15,3),SUMATORIA_POR_PAGAR)-(convert(decimal (15,3),CASE WHEN SUMATORIA_CUOTA is NULL  THEN 0 ELSE SUMATORIA_CUOTA  END)))/convert(decimal (15,3),PRIMERDIVIDENDO) END)-case when cc9.GRACIACOBRANZA is null then 0 else cc9.GRACIACOBRANZA end   >0 AND CC1.NROSOCIO='" + Nrosocio + "' )  SELECT  'SI'  else  select 'NO'", conexiones24._conexion)
                    'conexiones24.abrir()
                    'Dim reader24 As SqlDataReader = command24.ExecuteReader()


                    'If reader24.HasRows Then
                    '    Do While reader24.Read()
                    '        txtScoringMorosidades.Text = Trim((reader24(0).ToString))

                    '    Loop
                    'Else
                    'End If
                    'reader24.Close()
                    'conexiones24.cerrar()




                    Dim conexiones22 As New CConexion
                    conexiones22.conexion()
                    Dim command22 As SqlCommand = New SqlCommand("select capital from _DESCUENTO as cc1 inner join  (SELECT nrosocio , max(fecha)as fecha FROM [_DESCUENTO] where nrosocio='" + Nrosocio + "' group by nrosocio) as cc2 on cc1.nrosocio=cc2.nrosocio and cc1.fecha=cc2.fecha where cc1.nrosocio ='" + Nrosocio + "'", conexiones22._conexion)
                    conexiones22.abrir()
                    Dim reader22 As SqlDataReader = command22.ExecuteReader()


                    If reader22.HasRows Then
                        Do While reader22.Read()
                            txtCapital.Text = Trim((reader22(0).ToString))

                        Loop
                    Else
                    End If
                    reader22.Close()
                    'conexiones22.cerrar()

                    Dim conexiones23 As New CConexion
                    conexiones23.conexion()
                    Dim command23 As SqlCommand = New SqlCommand(" SELECT SUM( [MONTOAPORTE]-[MONTORETIRO]) FROM [_CAPITALSOCIAL] where NROSOCIO='" + Nrosocio + "' group by nrosocio", conexiones23._conexion)
                    conexiones23.abrir()
                    Dim reader23 As SqlDataReader = command23.ExecuteReader()


                    If reader23.HasRows Then
                        Do While reader23.Read()
                            txtMontoCapital.Text = Trim((reader23(0).ToString))

                        Loop
                    Else
                    End If

                    reader23.Close()
                    'conexiones23.cerrar()


                    Dim conexiones4 As New CConexion
                    conexiones4.conexion()
                    Dim command4 As SqlCommand = New SqlCommand("SELECT COUNT(*)  FROM _PRESTDIARIO  where NROSOCIO='" + Nrosocio + "'AND ESTADO='C' AND RENEGOCIACION=1", conexiones4._conexion)
                    conexiones4.abrir()
                    Dim reader4 As SqlDataReader = command4.ExecuteReader()

                    If reader4.HasRows Then
                        Do While reader4.Read()
                            txtNcreditos.Text = (reader4(0).ToString)

                        Loop
                    Else
                    End If

                    reader4.Close()
                    'conexiones4.cerrar()

                    txtNuevo.Text = "NO"
                ElseIf (Trim(Cbotipo.SelectedItem) = "PRE-SOCIO") Then

                    txtCapital.Text = "5000"
                    txtMontoCapital.Text = "0"
                    txtNcreditos.Text = "0"
                    btnPrepago.BackColor = Color.White
                    btnPrepago.Visible = False

                End If

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
                ElseIf estadocivil = "U" Then
                    txtEstadoCivil.Text = "Separación Bienes"
                ElseIf estadocivil = "M" Then
                    txtEstadoCivil.Text = "Comunidad de Bienes"
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




                If (InputDateString1.Trim <> "") Then
                    Dim theYear1 As Integer = System.Convert.ToInt32(InputDateString1.Substring(0, 4))
                    Dim theMonth1 As Integer = System.Convert.ToInt32(InputDateString1.Substring(4, 2))
                    Dim theDay1 As Integer = System.Convert.ToInt32(InputDateString1.Substring(6, 2))

                    dt1 = New DateTime(theYear1, theMonth1, theDay1)
                    DateFechaIngreso.Value = dt1
                End If

                If (InputDateString2.Trim <> "") Then
                    Dim theYear2 As Integer = System.Convert.ToInt32(InputDateString2.Substring(0, 4))
                    Dim theMonth2 As Integer = System.Convert.ToInt32(InputDateString2.Substring(4, 2))
                    Dim theDay2 As Integer = System.Convert.ToInt32(InputDateString2.Substring(6, 2))

                    dt2 = New DateTime(theYear2, theMonth2, theDay2)
                    DateFechaNacimiento.Value = dt2
                End If

                If (InputDateString3.Trim <> "") Then
                    Dim theYear3 As Integer = System.Convert.ToInt32(InputDateString3.Substring(0, 4))
                    Dim theMonth3 As Integer = System.Convert.ToInt32(InputDateString3.Substring(4, 2))
                    Dim theDay3 As Integer = System.Convert.ToInt32(InputDateString3.Substring(6, 2))

                    dt3 = New DateTime(theYear3, theMonth3, theDay3)
                    DateFechaContrato.Value = dt3
                End If





                frmPrepago.LboxConsumo.Items.Clear()
                frmPrepago.LBoxAdicional.Items.Clear()
                frmPrepago.LBoxComercial.Items.Clear()
                frmPrepago.LboxEmergencia.Items.Clear()



                Dim cadena As String = txtRut.Text
                Dim numeros() As String = cadena.Split("-")

                Dim rut As String = numeros(0)


                Dim conexiones9 As New CConexion
                conexiones9.conexion()
                'Dim command9 As SqlCommand = New SqlCommand(" select p.corcredito from _SOCIOS as s inner join _RIESGO_PRESTAMOS_ULTIMO as p on s.NROSOCIO=p.NROSOCIO  where RUT='" + rut + "' and s.Estado=0 AND P.ADICIONAL=0 AND  P.NROSOCIO>0 AND P.TIPOCREDITO='C' AND DEUDA='SI'", conexiones9._conexion)

                Dim command9 As SqlCommand = New SqlCommand("select corcredito from _prestdiario where nrosocio=" + Nrosocio + " and estado ='C' AND RECONSTRU=0 AND  CORCREDITO IN ( SELECT OPERCRED FROM _PRESTAMOS2 where nrosocio=" + Nrosocio + " GROUP BY OPERCRED  HAVING SUM(CARGO-ABONO)>0)", conexiones9._conexion)

                conexiones9.abrir()
                Dim reader9 As SqlDataReader = command9.ExecuteReader()

                If reader9.HasRows Then
                    Do While reader9.Read()
                        frmPrepago.LboxConsumo.Items.Add(reader9(0).ToString)
                        agregaprestamo(reader9(0).ToString, "Consumo")
                    Loop
                Else
                End If
                reader9.Close()
                'conexiones9.cerrar()



                Dim conexiones6 As New CConexion
                conexiones6.conexion()
                'Dim command6 As SqlCommand = New SqlCommand("select p.corcredito from _SOCIOS as s inner join _RIESGO_PRESTAMOS_ULTIMO as p on s.NROSOCIO=p.NROSOCIO  where RUT='" + rut + "' and s.Estado=0 AND P.ADICIONAL in (12) AND DEUDA='SI'", conexiones6._conexion)
                Dim command6 As SqlCommand = New SqlCommand("select corcredito from _prestdiario where nrosocio=" + Nrosocio + " and estado ='C' AND RECONSTRU=12  and  CORCREDITO IN ( SELECT OPERCRED FROM _PRESTAMOS2 where nrosocio=" + Nrosocio + "  GROUP BY OPERCRED  HAVING SUM(CARGO-ABONO)>0)", conexiones9._conexion)
                conexiones6.abrir()
                Dim reader6 As SqlDataReader = command6.ExecuteReader()

                If reader6.HasRows Then
                    Do While reader6.Read()
                        frmPrepago.LBoxComercial.Items.Add(reader6(0).ToString)
                        agregaprestamo(reader6(0).ToString, "Comercial")
                    Loop
                Else
                End If

                reader6.Close()
                'conexiones6.cerrar()

                Dim conexiones2 As New CConexion
                conexiones2.conexion()
                'Dim command2 As SqlCommand = New SqlCommand("select p.corcredito from _SOCIOS as s inner join _RIESGO_PRESTAMOS_ULTIMO as p on s.NROSOCIO=p.NROSOCIO  where RUT='" + rut + "' and s.Estado=0 AND P.ADICIONAL in (1,2,3,4,5,6,7,10) AND P.TIPOCREDITO='C' AND DEUDA='SI'", conexiones2._conexion)
                Dim command2 As SqlCommand = New SqlCommand("select corcredito from _prestdiario where nrosocio=" + Nrosocio + " and estado ='C' AND RECONSTRU not in (0,12,13,11) AND  CORCREDITO IN ( SELECT OPERCRED FROM _PRESTAMOS2 where nrosocio=" + Nrosocio + "  GROUP BY OPERCRED  HAVING SUM(CARGO-ABONO)>0)", conexiones9._conexion)
                conexiones2.abrir()
                Dim reader2 As SqlDataReader = command2.ExecuteReader()

                If reader2.HasRows Then
                    Do While reader2.Read()
                        frmPrepago.LBoxAdicional.Items.Add(reader2(0).ToString)
                        agregaprestamo(reader2(0).ToString, "Adicional")

                    Loop
                Else
                End If

                reader2.Close()
                'conexiones2.cerrar()


                Dim conexiones200 As New CConexion
                conexiones200.conexion()
                'Dim command200 As SqlCommand = New SqlCommand(" select p.corcredito from _SOCIOS as s inner join _RIESGO_PRESTAMOS_ULTIMO as p on s.NROSOCIO=p.NROSOCIO  where RUT='" + rut + "' and s.Estado=0  AND P.ADICIONAL=13 AND  P.NROSOCIO>0 AND P.TIPOCREDITO='C' AND DEUDA='SI'", conexiones200._conexion)
                Dim command200 As SqlCommand = New SqlCommand("select corcredito from _prestdiario where nrosocio=" + Nrosocio + " and estado ='C' AND RECONSTRU=13 AND  CORCREDITO IN ( SELECT OPERCRED FROM _PRESTAMOS2 where nrosocio=" + Nrosocio + " GROUP BY OPERCRED  HAVING SUM(CARGO-ABONO)>0)", conexiones9._conexion)
                conexiones200.abrir()
                Dim reader200 As SqlDataReader = command200.ExecuteReader()

                If reader200.HasRows Then
                    Do While reader200.Read()
                        frmPrepago.LboxConsumo.Items.Add(reader200(0).ToString)
                        agregaprestamo(reader200(0).ToString, "Social")
                    Loop
                Else
                End If

                reader200.Close()
                'conexiones200.cerrar()





                Dim conexiones1 As New CConexion
                conexiones1.conexion()
                'Dim command1 As SqlCommand = New SqlCommand("select p.corcredito from _SOCIOS as s inner join _RIESGO_PRESTAMOS_ULTIMO as p on (s.NROSOCIO)*-1=p.NROSOCIO  where RUT='" + rut + "' and s.Estado=0 AND P.ADICIONAL=11 AND  P.NROSOCIO<0 AND P.TIPOCREDITO='C' AND DEUDA='SI'", conexiones1._conexion)
                Dim command1 As SqlCommand = New SqlCommand("select corcredito from _prestdiario where nrosocio=" + Nrosocio + " and estado ='C' AND RECONSTRU in (11) AND  CORCREDITO IN ( SELECT OPERCRED FROM _PRESTAMOS2 where nrosocio=" + Nrosocio + "  GROUP BY OPERCRED  HAVING SUM(CARGO-ABONO)>0)", conexiones9._conexion)

                conexiones1.abrir()
                Dim reader1 As SqlDataReader = command1.ExecuteReader()

                If reader1.HasRows Then
                    Do While reader1.Read()
                        frmPrepago.LboxEmergencia.Items.Add(reader1(0).ToString)
                        agregaprestamo(reader1(0).ToString, "Emergencia")
                    Loop
                Else
                End If

                reader1.Close()
                'conexiones1.cerrar()

                If frmPrepago.LboxConsumo.Items.Count <> 0 Then
                    frmPrepago.LboxConsumo.SelectedIndex = "0"
                End If
                If frmPrepago.LBoxComercial.Items.Count <> 0 Then
                    frmPrepago.LBoxComercial.SelectedIndex = "0"
                End If
                If frmPrepago.LBoxAdicional.Items.Count <> 0 Then
                    frmPrepago.LBoxAdicional.SelectedIndex = "0"
                End If
                If frmPrepago.LboxEmergencia.Items.Count <> 0 Then
                    frmPrepago.LboxEmergencia.SelectedIndex = "0"
                End If





            End If


            If txtNrosocio.Text <> "" Then
                txtNrosocio.BackColor = Color.White
                btnBuscar.BackColor = Color.White
            Else
                txtNrosocio.BackColor = Color.MistyRose
                btnBuscar.BackColor = Color.MistyRose
            End If



            txtNrosocio.Enabled = False
            txtnuevosocio.Enabled = True
            btnBuscar.Enabled = False


            VerificaCampana()



            'Dim conexiones14 As New CConexion
            'conexiones14.conexion()
            'conexiones14.abrir()
            'Dim cmd14 As New SqlCommand("Riesgo_Actualiza_prepagos", conexiones14._conexion)
            'cmd14.CommandType = CommandType.StoredProcedure
            'Dim dr14 As SqlDataReader = cmd14.ExecuteReader(CommandBehavior.CloseConnection)
            'conexiones14.cerrar()
        End If
    End Sub





    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

        consultardatos()
        cargarCompromisos()
        cargarprestamo()
        cargardeuda()
    End Sub




    'Private Sub DGProfesionalesyTrabajadoresIndependientes2_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGProfesionalesyTrabajadoresIndependientes2.CellValueChanged
    '    DGProfesionalesyTrabajadoresIndependientes2.Rows(1).Cells(2).Value() = Decimal.Round((Integer.Parse(DGProfesionalesyTrabajadoresIndependientes2.Rows(0).Cells(1).Value()) - Integer.Parse(DGProfesionalesyTrabajadoresIndependientes2.Rows(1).Cells(1).Value())) / 12)
    '    DGProfesionalesyTrabajadoresIndependientes2.Rows(2).Cells(2).Value() = Decimal.Round((Integer.Parse(DGProfesionalesyTrabajadoresIndependientes2.Rows(1).Cells(2).Value()) + Integer.Parse(DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value())) / 2)

    'End Sub



    Private Sub DGProfesionalesyTrabajadoresIndependientes2_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'DGProfesionalesyTrabajadoresIndependientes2.Rows(1).Cells(2).Value() = Decimal.Round((Integer.Parse(DGProfesionalesyTrabajadoresIndependientes2.Rows(0).Cells(1).Value()) - Integer.Parse(DGProfesionalesyTrabajadoresIndependientes2.Rows(1).Cells(1).Value())) / 12)
        'DGProfesionalesyTrabajadoresIndependientes2.Rows(2).Cells(2).Value() = Decimal.Round((Integer.Parse(DGProfesionalesyTrabajadoresIndependientes2.Rows(1).Cells(2).Value()) + Integer.Parse(DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value())) / 2)

    End Sub

    Private Sub DGProfesionalesyTrabajadoresIndependientes_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ''DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value() = 0
        ''For i = 0 To 11
        ''    DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value() = DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value() + DGProfesionalesyTrabajadoresIndependientes.Rows(i).Cells(1).Value()
        ''Next

        ''DGProfesionalesyTrabajadoresIndependientes2.Rows(2).Cells(2).Value() = Decimal.Round((Integer.Parse(DGProfesionalesyTrabajadoresIndependientes2.Rows(1).Cells(2).Value()) + Integer.Parse(DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value())) / 2)

        'Dim minimo As Integer
        'Dim maximo As Integer


        'minimo = DGProfesionalesyTrabajadoresIndependientes.Rows(0).Cells(1).Value()
        'maximo = DGProfesionalesyTrabajadoresIndependientes.Rows(0).Cells(1).Value()
        'For i = 0 To 11
        '    If minimo > DGProfesionalesyTrabajadoresIndependientes.Rows(i).Cells(1).Value() Then
        '        minimo = DGProfesionalesyTrabajadoresIndependientes.Rows(i).Cells(1).Value()
        '    End If
        '    If maximo < DGProfesionalesyTrabajadoresIndependientes.Rows(i).Cells(1).Value() Then
        '        maximo = DGProfesionalesyTrabajadoresIndependientes.Rows(i).Cells(1).Value()
        '    End If
        'Next

        ''txtMax.Text = maximo
        ''TxtMin.Text = minimo
        ''txtminmultiplicado.Text = minimo * 1.3

        'If maximo > minimo * 1.3 Then
        '    DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value() = 0
        '    For i = 0 To 11
        '        resultado = resultado + DGProfesionalesyTrabajadoresIndependientes.Rows(i).Cells(1).Value()
        '    Next

        '    resultado = (resultado / 12) * 0.8
        'Else
        '    DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value() = 0
        '    For i = 0 To 11
        '        resultado = resultado + DGProfesionalesyTrabajadoresIndependientes.Rows(i).Cells(1).Value()
        '    Next

        '    resultado = (resultado / 12)
        'End If

        'DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value() = resultado


    End Sub




    'Private Sub TextBox13_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Try
    '        DFechaPrimerVencimiento.Value = Today

    '        DFechaPrimerVencimiento.Value = DFechaPrimerVencimiento.Value.AddDays(Integer.Parse(CboDiasdeGracia.SelectedItem))
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Sub cargardiasgracia(ByVal credito As String)

    '    Dim Dia As Integer = Microsoft.VisualBasic.DateAndTime.Day(Now)

    '    If CboFormaDePago2.SelectedItem = "Mecanizado Capredena" Then
    '        Dim fecha1 As Date = DateAdd(DateInterval.Month, 2, Now.Date)
    '        fecha1 = DateAdd(DateInterval.Day, -1, DateSerial(fecha1.Year, fecha1.Month, 1))
    '        fecha1 = fecha1.AddDays(1)
    '        Dim fechadias As Integer = ((Now.Date - fecha1).TotalDays) * -1
    '        CboDiasdeGracia.SelectedItem = (fechadias - 1).ToString
    '        MsgBox("Convenio Mecanizado Capredena pago mes subsiguiente")
    '    ElseIf CboFormaDePago2.SelectedItem = "Mecanizado Dipreca" Then
    '        Dim fecha1 As Date = DateAdd(DateInterval.Month, 2, Now.Date)
    '        fecha1 = DateAdd(DateInterval.Day, -1, DateSerial(fecha1.Year, fecha1.Month, 1))
    '        fecha1 = fecha1.AddDays(1)
    '        Dim fechadias As Integer = ((Now.Date - fecha1).TotalDays) * -1
    '        CboDiasdeGracia.SelectedItem = (fechadias - 1).ToString
    '        MsgBox("Convenio Mecanizado Dipreca pago mes subsiguiente")
    '    ElseIf CboFormaDePago2.SelectedItem = "Mecanizado Armada" Then
    '        Dim fecha1 As Date = DateAdd(DateInterval.Month, 2, Now.Date)
    '        fecha1 = DateAdd(DateInterval.Day, -1, DateSerial(fecha1.Year, fecha1.Month, 1))
    '        fecha1 = fecha1.AddDays(1)
    '        Dim fechadias As Integer = ((Now.Date - fecha1).TotalDays) * -1
    '        CboDiasdeGracia.SelectedItem = (fechadias - 1).ToString
    '        MsgBox("Convenio Mecanizado Armada pago mes subsiguiente")
    '    ElseIf CboFormaDePago2.SelectedItem = "Convenio APRAJUD" And Dia > 12 Then
    '        Dim fecha1 As Date = DateAdd(DateInterval.Month, 2, Now.Date)
    '        fecha1 = DateAdd(DateInterval.Day, -1, DateSerial(fecha1.Year, fecha1.Month, 1))
    '        fecha1 = fecha1.AddDays(1)
    '        Dim fechadias As Integer = ((Now.Date - fecha1).TotalDays) * -1
    '        CboDiasdeGracia.SelectedItem = (fechadias - 1).ToString
    '        MsgBox("Convenio APRAJUD pago mes subsiguiente posterior al dia 12 del mes")
    '    ElseIf CboFormaDePago2.SelectedItem = "MAGISTRADOS" And Dia > 22 Then
    '        Dim fecha1 As Date = DateAdd(DateInterval.Month, 2, Now.Date)
    '        fecha1 = DateAdd(DateInterval.Day, -1, DateSerial(fecha1.Year, fecha1.Month, 1))
    '        fecha1 = fecha1.AddDays(1)
    '        Dim fechadias As Integer = ((Now.Date - fecha1).TotalDays) * -1
    '        CboDiasdeGracia.SelectedItem = (fechadias - 1).ToString
    '        MsgBox("Convenio MAGISTRADOS pago mes subsiguiente posterior al dia 22 del mes")
    '    ElseIf CboFormaDePago2.SelectedItem = "Convenio ANEJUD" Then
    '        If Dia > 22 Then
    '            Dim fecha1 As Date = DateAdd(DateInterval.Month, 3, Now.Date)
    '            fecha1 = DateAdd(DateInterval.Day, -1, DateSerial(fecha1.Year, fecha1.Month, 1))
    '            fecha1 = fecha1.AddDays(1)
    '            Dim fechadias As Integer = ((Now.Date - fecha1).TotalDays) * -1
    '            CboDiasdeGracia.SelectedItem = (fechadias - 1).ToString
    '            MsgBox("Convenio ANEJUD pago mes sub-subsiguiente posterior al dia 22 del mes")
    '        Else
    '            Dim fecha1 As Date = DateAdd(DateInterval.Month, 2, Now.Date)
    '            fecha1 = DateAdd(DateInterval.Day, -1, DateSerial(fecha1.Year, fecha1.Month, 1))
    '            fecha1 = fecha1.AddDays(1)
    '            Dim fechadias As Integer = ((Now.Date - fecha1).TotalDays) * -1
    '            CboDiasdeGracia.SelectedItem = (fechadias - 1).ToString
    '            MsgBox("Convenio ANEJUD pago mes subsiguiente")
    '        End If
    '    End If
    '    If credito = "1" Then
    '        Dim fecha1 As Date = DateAdd(DateInterval.Month, 2, Now.Date)
    '        fecha1 = DateAdd(DateInterval.Day, -1, DateSerial(fecha1.Year, fecha1.Month, 1))
    '        fecha1 = fecha1.AddDays(1)
    '        Dim fechadias As Integer = ((Now.Date - fecha1).TotalDays) * -1
    '        CboDiasdeGracia.SelectedItem = (fechadias - 1).ToString
    '        MsgBox("Producto con pago al mes subsiguiente")
    '    End If

    '    '        JUNIO

    '    '3991
    '    '        PATRICIO AGUILAR 

    '    If (Trim(txtTipoDeSocio.Text) = "A") Then
    '        Dim fecha1 As Date = DateAdd(DateInterval.Month, 2, Now.Date)
    '        fecha1 = DateAdd(DateInterval.Day, -1, DateSerial(fecha1.Year, fecha1.Month, 1))
    '        fecha1 = fecha1.AddDays(1)
    '        Dim fechadias As Integer = ((Now.Date - fecha1).TotalDays) * -1
    '        CboDiasdeGracia.SelectedItem = (fechadias - 1).ToString
    '        MsgBox("Institución Armada con pago mes subsiguiente")
    '    End If


    '    If (Trim(txtNrosocio.Text) = "3991" And (Trim(Cbotipo.SelectedItem) = "PRE-SOCIO")) Then
    '        Dim fecha1 As Date = DateAdd(DateInterval.Month, 2, Now.Date)
    '        fecha1 = DateAdd(DateInterval.Day, -1, DateSerial(fecha1.Year, fecha1.Month, 1))
    '        fecha1 = fecha1.AddDays(1)
    '        Dim fechadias As Integer = ((Now.Date - fecha1).TotalDays) * -1
    '        CboDiasdeGracia.SelectedItem = (fechadias - 1).ToString
    '        MsgBox("Excepción de Pre-Socio con pago mes subsiguiente")




    '    End If


    '    If (Trim(txtNrosocio.Text) = "4007" And (Trim(Cbotipo.SelectedItem) = "PRE-SOCIO")) Then
    '        Dim fecha1 As Date = DateAdd(DateInterval.Month, 2, Now.Date)
    '        fecha1 = DateAdd(DateInterval.Day, -1, DateSerial(fecha1.Year, fecha1.Month, 1))
    '        fecha1 = fecha1.AddDays(1)
    '        Dim fechadias As Integer = ((Now.Date - fecha1).TotalDays) * -1
    '        CboDiasdeGracia.SelectedItem = (fechadias - 1).ToString
    '        MsgBox("Excepción de Pre-Socio con pago mes subsiguiente")
    '    End If

    'End Sub

    Sub calculardeudainterna()


        If (Trim(Cbotipo.SelectedItem) = "SOCIO") Then


            Dim conexiones8 As New CConexion
            conexiones8.conexion()
            Dim command8 As SqlCommand = New SqlCommand(" if exists (SELECT * FROM _RIESGO_DEUDAS_CREDITOS where tipo in ('Consumo','Social','Emergencia','Adicional') and Estado='Normal' AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "') SELECT sum(deuda) FROM _RIESGO_DEUDAS_CREDITOS where tipo in ('Consumo','Social','Emergencia','Adicional') and Estado='Normal' AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "' else select 0", conexiones8._conexion)
            conexiones8.abrir()
            Dim reader8 As SqlDataReader = command8.ExecuteReader()

            If reader8.HasRows Then
                Do While reader8.Read()


                    'MsgBox(txtInternaDeudaConsumo.Text)
                    txtInternaDeudaConsumo.Text = Integer.Parse((reader8(0).ToString))
                Loop
            Else
            End If

            reader8.Close()
            conexiones8.cerrar()

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
            conexiones9.cerrar()


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
            conexiones2.cerrar()

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
            conexiones3.cerrar()

        ElseIf (Trim(Cbotipo.SelectedItem) = "PRE-SOCIO") Then

            txtInternaDeudaIndirecta.Text = 0
            txtInternaPagoMensual.Text = 0
            txtInternaDeudaComercial.Text = 0
            txtInternaDeudaConsumo.Text = 0
        End If
    End Sub




    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        Dim permitesolicitudtasa = "SI"

        If CboFormaDePago.SelectedItem.ToString <> "PLANILLA" Then

            If CboEjecutivo.SelectedItem.ToString.Trim = "CARLOS BOMBAL SEREY" Or CboEjecutivo.SelectedItem.ToString.Trim = "LILIAN BARRIOS RAMIREZ" Or CboEjecutivo.SelectedItem.ToString.Trim = "CAROLINA JARAMILLO IGNES" Or CboEjecutivo.SelectedItem.ToString.Trim = "PRISCILA MATELUNA JORQUERA" Then

                permitesolicitudtasa = "SI"

            Else
                If cboTasaSolicitada.SelectedItem.ToString.Trim = "Por Defecto Sistema" Then
                    permitesolicitudtasa = "SI"
                Else
                    permitesolicitudtasa = "NO"
                End If


            End If

        Else
            permitesolicitudtasa = "SI"

        End If




        BtnCalcular2.BackColor = Color.MistyRose

        If CboFormaDePago.SelectedItem.ToString.Trim = "PLANILLA" And cboTasaSolicitada.SelectedItem = "Por Defecto Sistema" Then
            MsgBox("Para pagos por planilla se debe solicitar una tasa de acuerdo a las politicas")
        Else


            If txtVisibledEUDAeiNGRESOS.Text = "NO" Then
                MsgBox("Se debe Verificar Ficha deudas e ingresos antes de continuar")

            Else


                If txtProducto.Text.Trim = "" Then

                    MsgBox("Debe indicar producto")

                Else
                    If TxtMonto.Text = 0 Then
                        MsgBox("El monto a solicitar no puede ser 0")
                    Else


                        If CboCuotas.SelectedItem = "" Then

                            MsgBox("Debe indicar n° de cuotas")
                        Else

                            If btnPrepago.BackColor = Color.MistyRose And btnPrepago.Visible = True Then

                                MsgBox("Debe verificar el o los prepagos")

                            Else

                                TxtMonto.Text = Replace(TxtMonto.Text, ".", "")
                                txtPrepago.Text = Replace(txtPrepago.Text, ".", "")
                                'Try


                                If (txtVisibleSocio.Text = "NO") Then
                                    MsgBox("Se debe Verificar Ficha Socio antes de continuar")
                                Else

                                    If (TxtMonto.Text = "") Then
                                        MsgBox("Se debe agregar un monto")
                                    Else
                                        If (txtPrepago.Text = "") Then
                                            MsgBox("Se debe agregar un monto a prepago")
                                        Else

                                            If (Integer.Parse(txtPrepago.Text) > Integer.Parse(TxtMonto.Text)) Then
                                                MsgBox("El monto del prepago no puede ser mayor al monto solicitado")

                                            Else
                                                If txtPrepago.Text <> 0 And cboRefRen.SelectedItem.ToString = "NO" Then
                                                    MsgBox("Al estar prepagando una operación el objetivo debe ser Refinanciamiento o Renegociación, favor modificar este parametro")
                                                Else
                                                    If permitesolicitudtasa = "NO" Then
                                                        MsgBox("Usuario sin permiso para solicitar tasa por forma de pago directo")
                                                    Else
                                                        'If CboFormaDePago.SelectedItem = "PLANILLA" And (FRM) Then
                                                        '    MsgBox("Usuario sin permiso para solicitar tasa por forma de pago directo")
                                                        'Else
                                                        calculadescuentocampaña()
                                                        'calcularprestamo()

                                                        'If TASASALTAS = "SI" Then
                                                        '    'txtTasaSolicitada.Text = cboTasaSolicitada.SelectedItem.ToString
                                                        '    calculardeudainterna()
                                                        '    cargarcapacidadylvl()
                                                        '    puntajes()

                                                        '    If contar = 1 Then


                                                        '        recalcularprestamo()
                                                        '        contar = 0
                                                        '    End If
                                                        'End If
                                                    End If

                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If









    End Sub


    Sub calculadescuentocampaña()
        txtDescuento.Text = "No Aplica"
        txtDescuento.BackColor = Color.Red

        If Replace(TxtMonto.Text, ".", "") >= 3000000 Then

            If CboObjetivo.SelectedItem.ToString.Trim <> "Renegociación" Then

                If CboProducto.SelectedItem.ToString.Trim = "SOCIAL" Or CboProducto.SelectedItem.ToString.Trim = "ADICIONAL" Then

                    If CboFormaDePago.SelectedItem.ToString.Trim <> "PLANILLA" Then

                        If cboTasaSolicitada.SelectedItem.ToString.Trim = "Por Defecto Sistema" Then
                            'txtDescuento.Text = "Aplica"
                            'txtDescuento.BackColor = Color.Green
                            txtDescuento.Text = "No Aplica"
                            txtDescuento.BackColor = Color.Red
                        End If

                    End If

                End If

            End If
        End If

    End Sub



    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboProducto.SelectedIndexChanged


        If CboProducto.SelectedItem <> "" Then
            CboProducto.BackColor = Color.White
        Else
            CboProducto.BackColor = Color.MistyRose
            CboObjetivo.SelectedItem = ""
        End If



        'Dim fecha1 As Date = DateAdd(DateInterval.Month, 1, Now.Date)
        'fecha1 = DateAdd(DateInterval.Day, -1, DateSerial(fecha1.Year, fecha1.Month, 1))
        'fecha1 = fecha1.AddDays(1)
        'Dim fechadias As Integer = ((Now.Date - fecha1).TotalDays) * -1
        'CboDiasdeGracia.SelectedItem = (fechadias - 1).ToString

        If CboProducto.SelectedItem.ToString.Trim = "CUOTON" Then
            TxtMonto.Text = 0
            TxtDisponible2.Text = 0

            TxtMonto.Enabled = False
            TxtDisponible2.Enabled = True

            TxtMonto.BackColor = Color.White
            TxtDisponible2.BackColor = Color.MistyRose
        ElseIf CboProducto.SelectedItem.ToString.Trim = "RENEGOCIACION FLEXIBLE" Then
            TxtMonto.Text = 0
            TxtDisponible2.Text = 0

            TxtMonto.Enabled = True
            TxtDisponible2.Enabled = True

            TxtMonto.BackColor = Color.MistyRose
            TxtDisponible2.BackColor = Color.MistyRose
        Else

            If CboFormaDePago2.SelectedItem = "Senado CJ" Or CboFormaDePago2.SelectedItem = "Senado ANEF" Then
                TxtMonto.Text = 0
                TxtDisponible2.Text = 0

                TxtMonto.Enabled = False
                TxtDisponible2.Enabled = True

                TxtMonto.BackColor = Color.White
                TxtDisponible2.BackColor = Color.MistyRose
            Else
                TxtMonto.Text = 0
                TxtDisponible2.Text = 0
                TxtMonto.Enabled = True
                TxtDisponible2.Enabled = False

                TxtDisponible2.BackColor = Color.White
                TxtMonto.BackColor = Color.MistyRose
            End If



            'TxtDisponible2.Enabled = False
        End If


        CboEjecutivo.SelectedItem = "SIN EJECUTIVO"

        cboRefRen.Enabled = False
        Dim conexiones9 As New CConexion
        conexiones9.conexion()
        Dim command9 As SqlCommand = New SqlCommand("SELECT  ISNULL([PERMITE_RENEGOCIA],1) FROM [_NOMBRECREDITO_RESTRICCIONES] as cc1 inner join _nombrecredito as cc2 on cc1.CODNOM=CC2.CODNOM WHERE DESCRIPCION='" + CboProducto.SelectedItem.ToString.Trim + "'", conexiones9._conexion)
        conexiones9.abrir()
        Dim reader9 As SqlDataReader = command9.ExecuteReader()

        If reader9.HasRows Then
            Do While reader9.Read()


                If (reader9(0).ToString() = 1) Then

                    CboObjetivo.Items.Clear()
                    CboObjetivo.Items.Add("")
                    CboObjetivo.Items.Add("Renegociación")
                    CboObjetivo.Items.Add("Refinanciamiento")
                    CboObjetivo.Items.Add("Arreglo de vivienda")
                    CboObjetivo.Items.Add("Compra de cartera")
                    CboObjetivo.Items.Add("Compra de vehículos")
                    CboObjetivo.Items.Add("Compra de cartera")
                    CboObjetivo.Items.Add("Compra vivienda")
                    CboObjetivo.Items.Add("Gastos fin de año")
                    CboObjetivo.Items.Add("Gastos escolares")
                    CboObjetivo.Items.Add("Gastos médicos")
                    CboObjetivo.Items.Add("Gastos personales")

                    CboObjetivo.SelectedItem = ""
                Else

                    CboObjetivo.Items.Clear()
                    CboObjetivo.Items.Add("")
                    CboObjetivo.Items.Add("Arreglo de vivienda")
                    CboObjetivo.Items.Add("Compra de cartera")
                    CboObjetivo.Items.Add("Compra de vehículos")
                    CboObjetivo.Items.Add("Compra de cartera")
                    CboObjetivo.Items.Add("Compra vivienda")
                    CboObjetivo.Items.Add("Gastos fin de año")
                    CboObjetivo.Items.Add("Gastos escolares")
                    CboObjetivo.Items.Add("Gastos médicos")
                    CboObjetivo.Items.Add("Gastos personales")
                    cboRefRen.SelectedItem = "NO"

                    CboObjetivo.SelectedItem = ""

                    MsgBox("Producto sin opción a renegociación o refinanciamiento")
                End If

            Loop
        Else
        End If

        reader9.Close()





        'conexiones9.cerrar()



        txtProducto.Text = CboProducto.SelectedItem.ToString.Trim



    End Sub



    'Private Sub CboDiasdeGracia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDiasdeGracia.SelectedIndexChanged
    '    'Try
    '    '    DFechaPrimerVencimiento.Value = Today

    '    '    DFechaPrimerVencimiento.Value = DFechaPrimerVencimiento.Value.AddDays(Integer.Parse(CboDiasdeGracia.SelectedItem))
    '    'Catch ex As Exception

    '    'End Try
    'End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboObjetivo.SelectedIndexChanged
        If CboObjetivo.SelectedItem <> "" Then
            CboObjetivo.BackColor = Color.White


            If (CboObjetivo.SelectedItem.ToString = "Refinanciamiento" Or CboObjetivo.SelectedItem.ToString = "Renegociación") Then
                cboRefRen.Enabled = False
                cboRefRen.SelectedItem = "SI"
            Else
                cboRefRen.Enabled = False
                cboRefRen.SelectedItem = "NO"
            End If


        Else
            CboObjetivo.BackColor = Color.MistyRose
        End If



    End Sub

    Private Sub TxtMonto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMonto.KeyUp
        TxtMonto.Text = Puntos(TxtMonto.Text)
        TxtMonto.Select(TxtMonto.Text.Length, 0)
    End Sub

    Private Sub TxtMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMonto.TextChanged
        If TxtMonto.Text = "" Or TxtMonto.Text = "0" Then
            TxtMonto.BackColor = Color.MistyRose
        Else
            TxtMonto.BackColor = Color.White
        End If

    End Sub

    Private Sub CboCuotas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCuotas.SelectedIndexChanged
        If CboCuotas.SelectedItem <> "" Then
            CboCuotas.BackColor = Color.White
        Else
            CboCuotas.BackColor = Color.MistyRose
        End If
    End Sub


    Private Sub Pic1_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pic1.VisibleChanged


        If Pic1.Visible = True Then
            Pic1A.Visible = True
            Pic1B.Visible = False
        Else
            Pic1A.Visible = False
            Pic1B.Visible = True
        End If


    End Sub



    Private Sub Pic2_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pic2.VisibleChanged
        If Pic2.Visible = True Then
            Pic2A.Visible = True
            Pic2B.Visible = False
        Else
            Pic2A.Visible = False
            Pic2B.Visible = True
        End If
    End Sub









    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrepago.Click






        If cboRefRen.BackColor = Color.White Then
            frmPrepago.MdiParent = Me.MdiParent
            frmPrepago.Visible = True
            frmPrepago.Location = New Point(0, 0)

            If (frmPrepago.LboxEmergencia.Items.Count <> 0) Then

                'Dim prestamo As String = frmPrepago.LboxEmergencia.SelectedItem

                For number As Double = 0 To frmPrepago.LboxEmergencia.Items.Count - 1 Step 1



                    'MsgBox(prestamo)
                    Dim conexiones1 As New CConexion
                    conexiones1.conexion()
                    conexiones1.abrir()
                    Dim cmd1 As New SqlCommand("Riesgo_prepago3_H", conexiones1._conexion)
                    cmd1.CommandType = CommandType.StoredProcedure
                    Dim prm1 As SqlParameter =
                        New SqlParameter("@prestamo", SqlDbType.NChar, 30)
                    cmd1.Parameters.Add(prm1)

                    Dim prm2 As SqlParameter =
                        New SqlParameter("@PERFIL", SqlDbType.NChar, 30)
                    cmd1.Parameters.Add(prm2)

                    Dim prm3 As SqlParameter =
                       New SqlParameter("@nrosocio", SqlDbType.NChar, 30)
                    cmd1.Parameters.Add(prm3)

                    With cmd1
                        .Parameters("@prestamo").Value = frmPrepago.LboxEmergencia.Items(number)
                        .Parameters("@PERFIL").Value = frmPerfil.CbmUsuario.SelectedItem
                        .Parameters("@nrosocio").Value = txtNrosocio.Text.ToString.Trim
                    End With
                    Dim dr1 As SqlDataReader = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                    conexiones1.cerrar()


                Next

            End If
            If (frmPrepago.LboxConsumo.Items.Count <> 0) Then


                '    'llamado a agregar consumo
                'Dim prestamo As String = frmPrepago.LboxConsumo.SelectedItem

                For number As Double = 0 To frmPrepago.LboxConsumo.Items.Count - 1 Step 1

                    Dim conexiones1 As New CConexion
                    conexiones1.conexion()
                    conexiones1.abrir()
                    Dim cmd1 As New SqlCommand("Riesgo_prepago3_H", conexiones1._conexion)
                    cmd1.CommandType = CommandType.StoredProcedure
                    Dim prm1 As SqlParameter =
                        New SqlParameter("@prestamo", SqlDbType.NChar, 30)
                    cmd1.Parameters.Add(prm1)

                    Dim prm2 As SqlParameter =
                        New SqlParameter("@PERFIL", SqlDbType.NChar, 30)
                    cmd1.Parameters.Add(prm2)

                    Dim prm3 As SqlParameter =
                       New SqlParameter("@nrosocio", SqlDbType.NChar, 30)
                    cmd1.Parameters.Add(prm3)

                    With cmd1
                        .Parameters("@prestamo").Value = frmPrepago.LboxConsumo.Items(number)
                        .Parameters("@PERFIL").Value = frmPerfil.CbmUsuario.SelectedItem
                        .Parameters("@nrosocio").Value = txtNrosocio.Text.ToString.Trim
                    End With
                    Dim dr1 As SqlDataReader = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                    conexiones1.cerrar()

                Next
            End If

            If (frmPrepago.LBoxAdicional.Items.Count <> 0) Then


                '    'llamado a agregar consumo
                'Dim prestamo As String = frmPrepago.LBoxAdicional.SelectedItem

                For number As Double = 0 To frmPrepago.LBoxAdicional.Items.Count - 1 Step 1

                    Dim conexiones1 As New CConexion
                    conexiones1.conexion()
                    conexiones1.abrir()
                    Dim cmd1 As New SqlCommand("Riesgo_prepago3_H", conexiones1._conexion)
                    cmd1.CommandType = CommandType.StoredProcedure
                    Dim prm1 As SqlParameter =
                        New SqlParameter("@prestamo", SqlDbType.NChar, 30)
                    cmd1.Parameters.Add(prm1)

                    Dim prm2 As SqlParameter =
                        New SqlParameter("@PERFIL", SqlDbType.NChar, 30)
                    cmd1.Parameters.Add(prm2)

                    Dim prm3 As SqlParameter =
                       New SqlParameter("@nrosocio", SqlDbType.NChar, 30)
                    cmd1.Parameters.Add(prm3)

                    With cmd1
                        .Parameters("@prestamo").Value = frmPrepago.LBoxAdicional.Items(number)
                        .Parameters("@PERFIL").Value = frmPerfil.CbmUsuario.SelectedItem
                        .Parameters("@nrosocio").Value = txtNrosocio.Text.ToString.Trim
                    End With
                    Dim dr1 As SqlDataReader = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                    conexiones1.cerrar()

                Next

            End If

            If (frmPrepago.LBoxComercial.Items.Count <> 0) Then


                '    'llamado a agregar consumo
                'Dim prestamo As String = frmPrepago.LBoxComercial.SelectedItem



                For number As Double = 0 To frmPrepago.LBoxComercial.Items.Count - 1 Step 1

                    Dim conexiones1 As New CConexion
                    conexiones1.conexion()
                    conexiones1.abrir()
                    Dim cmd1 As New SqlCommand("Riesgo_prepago3_H", conexiones1._conexion)
                    cmd1.CommandType = CommandType.StoredProcedure
                    Dim prm1 As SqlParameter =
                        New SqlParameter("@prestamo", SqlDbType.NChar, 30)
                    cmd1.Parameters.Add(prm1)

                    Dim prm2 As SqlParameter =
                        New SqlParameter("@PERFIL", SqlDbType.NChar, 30)
                    cmd1.Parameters.Add(prm2)

                    Dim prm3 As SqlParameter =
                       New SqlParameter("@nrosocio", SqlDbType.NChar, 30)
                    cmd1.Parameters.Add(prm3)

                    With cmd1
                        .Parameters("@prestamo").Value = frmPrepago.LBoxComercial.Items(number)
                        .Parameters("@PERFIL").Value = frmPerfil.CbmUsuario.SelectedItem
                        .Parameters("@nrosocio").Value = txtNrosocio.Text.ToString.Trim
                    End With
                    Dim dr1 As SqlDataReader = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                    conexiones1.cerrar()


                Next


            End If

        Else
            MsgBox("Debe indicar si es renegociación o refinanciamiento")
        End If






    End Sub



    Sub cargarcapacidadylvl()
        Dim lvl As Integer
        Dim capcidadDePago As Integer

        lvl = 0
        lvl = Math.Round(((Double.Parse(Replace(txtDeudaConsumo.Text, ".", "")) + Double.Parse(Replace(txtDeudaComercial.Text, ".", "")) + Double.Parse(Replace(txtLineaCredito.Text, ".", "")) + Double.Parse(Replace(TxtMonto.Text, ".", "")) + Double.Parse(Replace(txtInternaTotalDeuda.Text, ".", ""))) / Double.Parse(Replace(TXTRENTALIQUIDA.Text, ".", ""))), 0, MidpointRounding.ToEven)
        capcidadDePago = 0

        capcidadDePago = Math.Round((((Double.Parse(Replace(TxtCuota.Text, ".", "")) + Double.Parse(Replace(txtInternaPagoMensual.Text, ".", "")) + Double.Parse(Replace(txtCapital.Text, ".", "")))) / (Double.Parse(Replace(txtRentaLiquidaDepurada.Text, ".", "")))) * 100, 2, MidpointRounding.ToEven)

        'MsgBox(Math.Round((((Double.Parse(Replace(TxtCuota.Text, ".", "")))))))
        'MsgBox(Math.Round((((Double.Parse(Replace(txtInternaPagoMensual.Text, ".", "")))))))
        'MsgBox(Math.Round((((Double.Parse(Replace(txtCapital.Text, ".", "")))))))
        'MsgBox(Math.Round((((Double.Parse(Replace(txtRentaLiquidaDepurada.Text, ".", "")))))))

        LPorciento.Text = capcidadDePago.ToString + "%"



        Dim mini As Integer
        Dim max As Integer


        Dim conexiones13 As New CConexion
        conexiones13.conexion()
        Dim command13 As SqlCommand = New SqlCommand("select min(tipo),max(tipo) from _RIESGO_LEVERAGE", conexiones13._conexion)
        conexiones13.abrir()
        Dim reader13 As SqlDataReader = command13.ExecuteReader()

        If reader13.HasRows Then
            Do While reader13.Read()
                mini = Integer.Parse(reader13(0).ToString)
                max = Integer.Parse(reader13(1).ToString)
            Loop
        Else
        End If
        reader13.Close()
        conexiones13.cerrar()


        '' LVL CORRESPONDIENTE------------------------------------------

        Dim LVLCORRESPONDIENTE As String = 0

        Dim RL As String = Replace(TXTRENTALIQUIDA.Text, ".", "")

        Dim conexiones112 As New CConexion
        conexiones112.conexion()
        Dim command112 As SqlCommand = New SqlCommand("SELECT TIPO FROM _RIESGO_LEVERAGE where CONVERT(INT,'" + RL + "')>=CONVERT(INT,MONTO1) AND CONVERT(INT,'" + RL + "')<=CONVERT(INT,MONTO2) ", conexiones112._conexion)
        conexiones112.abrir()
        Dim reader112 As SqlDataReader = command112.ExecuteReader()

        If reader112.HasRows Then
            Do While reader112.Read()

                LVLCORRESPONDIENTE = (reader112(0).ToString)

            Loop
        Else
        End If

        reader112.Close()
        conexiones112.cerrar()
        LlEVEL.Text = lvl.ToString





        If (Integer.Parse(capcidadDePago) <= 20 And Integer.Parse(capcidadDePago) >= 0) Then

            txtScoringCapacidad.Text = "BUENO"
            'MsgBox(capcidadDePago)
        Else
            txtScoringCapacidad.Text = "MALO"
            'MsgBox(capcidadDePago)
        End If

        txtScoringCapacidadNumero.Text = capcidadDePago.ToString

        If (Integer.Parse(lvl) > Integer.Parse(LVLCORRESPONDIENTE)) Then

            txtScoringLvl.Text = "MALO"
        Else

            txtScoringLvl.Text = "BUENO"
        End If



        txtScoringLvlnumerico.Text = lvl.ToString
        txtScoringCapacidadnumerico.Text = capcidadDePago.ToString



    End Sub



    Private Sub EVALUAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EVALUAR.Click




        If (Pic1A.Visible = True And Pic2A.Visible = True And Pic5A.Visible = True) Then

            If (txtestado2.Text = "ACEPTADO, SE ENVIA A RIESGO Y EVALUACIÓN PERO CON TASA CASTIGADA " Or txtestado2.Text = "RECHAZADO, SE ENVIA A RIESGO Y EVALUACIÓN PERO CON TASA CASTIGADA" Or txtestado2.Text = "ACEPTADO,PERO SE ENVIA A RIESGO" Or txtestado2.Text = "RECHAZADO, SE ENVIA A RIESGO ") Then
                BTNVALIDAR.Enabled = True
                txtestado2.Visible = True
                PanelResumen.Visible = True
                txtestado2.ForeColor = Color.Red
                TXTPROCESO.Text = "*SE ENVIARA A AGENTE Y DEP. RIESGO PARA SU VALIDACIÓN"

            Else
                BTNVALIDAR.Enabled = True
                PanelResumen.Visible = True
                txtestado2.Visible = True
                txtestado2.ForeColor = Color.Green
                TXTPROCESO.Text = "*SE ENVIARA A AGENTE PARA SU VALIDACIÓN"
            End If

        Else
            MsgBox("Todas las pestañas deben estar correctamente completadas antes de evaluar")
        End If



    End Sub


    Private Sub LPuntaje_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LPuntaje.TextChanged
        'If Integer.Parse(LPuntaje.Text) >= 500 Then
        '    'PicAceptado.Visible = True


        'ElseIf Integer.Parse(LPuntaje.Text) > 0 And Integer.Parse(LPuntaje.Text) <500 Then
        '    'PicDenegado.Visible = True

        'End If

    End Sub

    Function agregaprestamo(ByVal PRESTAMO As String, ByVal TIPO As String) As String
        Dim conexiones7 As New CConexion
        conexiones7.conexion()
        Dim command7 As SqlCommand = New SqlCommand("INSERT INTO _RIESGO_DEUDAS_CREDITOS (prestamo, tipo , perfil) values ('" + PRESTAMO + "','" + TIPO + "','" + frmPerfil.CbmUsuario.SelectedItem.ToString + "')", conexiones7._conexion)
        conexiones7.abrir()
        Dim reader7 As SqlDataReader = command7.ExecuteReader()
        reader7.Close()
        'conexiones7.cerrar()
        Return ("REALIZADO CON EXITO")
    End Function

    Private Sub ChkExternaAcreditado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkExternaAcreditado.CheckedChanged
        If (ChkExternaAcreditado.Checked = True) Then
            txtExternaAcreditado.Enabled = True
            MsgBox("En la acreditación deben estar considerados todos los productos (Comercial + Consumo + Hipotecario + Línea de crédito), en caso de no incluir todos se deberá castigar según la normativa vigente")
        Else
            txtExternaAcreditado.Enabled = False
            txtExternaAcreditado.Text = 0
        End If

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)





    End Sub

    Private Sub ChkActivos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkActivos.CheckedChanged
        If (ChkActivos.Checked = True) Then
            txtActivos.Enabled = True

        Else
            txtActivos.Enabled = False
            txtActivos.Text = 0
        End If
    End Sub

    Private Sub ChkPropiedades_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPropiedades.CheckedChanged
        If (ChkPropiedades.Checked = True) Then
            txtPropiedades.Enabled = True

        Else
            txtPropiedades.Enabled = False
            txtPropiedades.Text = 0
        End If
    End Sub

    Private Sub ChkVehiculos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkVehiculos.CheckedChanged
        If (ChkVehiculos.Checked = True) Then
            txtVehiculos.Enabled = True

        Else
            txtVehiculos.Enabled = False
            txtVehiculos.Text = 0
        End If
    End Sub



    Private Sub Verificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerificar.Click
        If CboFormaDePago.SelectedItem.ToString.Trim = "PLANILLA" And cboTasaSolicitada.SelectedItem.ToString.Trim = "Por Defecto Sistema" Then
            MsgBox("Para pagos por planilla se debe solicitar una tasa de acuerdo a las politicas")
        Else
            If (CboProducto.BackColor = Color.MistyRose Or CboObjetivo.BackColor = Color.MistyRose Or TxtMonto.BackColor = Color.MistyRose Or CboCuotas.BackColor = Color.MistyRose Or BtnCalcular2.BackColor = Color.MistyRose) Then
                MsgBox("Debe Completar todos los campos requeridos")
            Else

                If CboFormaDePago.SelectedItem.ToString.Trim = "PLANILLA" And (Double.Parse(Replace(Replace(TxtCuota.Text, ".", ""), "$", "")) > Double.Parse(Replace(Replace(txtMaxCuotaPlanilla.Text, ".", ""), "$", ""))) And txtCodDaca.Text = "" And txtTipoEP.Text = "Empleados" And txtCampanaRefinancia.Text = "No" Then
                    'MsgBox(txtCodDaca.Text)
                    MsgBox("Al ser su forma de pago por planilla la cuota no debe superar la máxima cuota a descontar (" + txtMaxCuotaPlanilla.Text + ")")

                Else
                    If CboFormaDePago.SelectedItem.ToString.Trim = "PLANILLA" And Replace(TxtMonto.Text, ".", "") = 0 And (Double.Parse(Replace(Replace(txtDisponible.Text, ".", ""), "$", "")) > Double.Parse(Replace(Replace(txtMaxCuotaPlanilla.Text, ".", ""), "$", ""))) And txtCampanaRefinancia.Text = "No" Then

                        MsgBox("La cuota Disponible no debe superar la máxima cuota a descontar (" + txtMaxCuotaPlanilla.Text + ")")

                    Else
                        If (CboFormaDePago.SelectedItem.ToString.Trim = "PLANILLA" And CboProducto.SelectedItem <> "CUOTON" And CboProducto.SelectedItem <> "RENEGOCIACION FLEXIBLE") And (Double.Parse(Replace(Replace(TxtMonto.Text, ".", ""), "$", "")) > Double.Parse(Replace(Replace(txtMaxMontoPlanilla.Text, ".", ""), "$", ""))) And txtCodDaca.Text = "" And txtTipoEP.Text = "Empleados" And txtCampanaRefinancia.Text = "No" Then

                            MsgBox("Al ser su forma de pago por planilla el monto solicitado no debe superar la máximo monto a descontar (" + txtMaxMontoPlanilla.Text + ")")
                        Else

                            Pic1.Visible = True
                            btnVerificar.Enabled = False
                            btnEditar.Enabled = True
                            TableLayoutPanel3.Enabled = False

                        End If
                    End If
                End If
            End If
        End If



    End Sub

    Private Sub txtCapital_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCapital.TextChanged

        If (txtCapital.Text = "") Then
            txtCapital.BackColor = Color.MistyRose
        Else
            txtCapital.BackColor = Color.White
            'txtCapital.Text = Format(Integer.Parse(txtCapital.Text), "#,##0")
        End If

    End Sub


    Private Sub txtPrepago_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrepago.TextChanged
        If (txtPrepago.Text = "") Then
            txtPrepago.BackColor = Color.MistyRose
        Else
            txtPrepago.BackColor = Color.White
            'txtPrepago.Text = Format(Integer.Parse(txtPrepago.Text), "#,##0")
        End If
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        EDITARPRESTAMO()
    End Sub

    Sub EDITARPRESTAMO()
        Pic1.Visible = False
        btnVerificar.Enabled = True
        btnEditar.Enabled = False
        TableLayoutPanel3.Enabled = True
        BtnCalcular2.BackColor = Color.MistyRose
    End Sub


    Private Sub btnEditar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar2.Click
        txtAumentaTasa2.Text = ""
        txtPuntaje2.Text = "0"
        Pic2.Visible = False
        btnVerificar2.Enabled = True
        btnEditar2.Enabled = False
        TableLayoutPanel2.Enabled = True
        chksicontrato.Checked = False
        chknocontrato.Checked = False
        CboFormaDePago.SelectedItem = ""
        CboRenta.SelectedItem = ""
        CboProtestosyMorocidades.SelectedItem = ""
        cboFueradeZona.SelectedItem = ""
        cboPlataforma.SelectedItem = ""
        txtVisibleSocio.Text = "NO"
        EDITARDEUDASEINGRESOS()
        'CboReferencias.SelectedItem = ""
    End Sub

    Private Sub CboFormaDePago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboFormaDePago.SelectedIndexChanged



        If (CboFormaDePago.SelectedItem = "") Then
            CboFormaDePago.BackColor = Color.MistyRose
            BtnRenta.BackColor = Color.MistyRose
        Else
            CboFormaDePago.BackColor = Color.White
            If (CboFormaDePago.SelectedItem = "PLANILLA") Then
                CboProducto.Items.Remove("ANIVERSARIO")
                MsgBox("Con la forma de pago 'Planilla' es necesario solicitar una tasa de acuerdo a las politicas del departamento comercial", MsgBoxStyle.Exclamation, "Advertencia")

                frmRentas.cboTipo.SelectedItem = ""
                frmRentas.RELLENA0PLANILLA()
                frmRentas.calcularhonorarios()
                frmRentas.calcularRPLIndependiente()
                frmRentas.calcularRPLTotal()
            Else
                frmRentas.cboTipo.SelectedItem = ""
                frmRentas.RELLENA0PLANILLA()
                frmRentas.calcularhonorarios()
                frmRentas.calcularRPLIndependiente()
                frmRentas.calcularRPLTotal()

                cargarprestamo()
            End If

        End If


        If txtCOD_INST.Text.ToString <> "" Then
            CboFormaDePago2.Items.Clear()
            CboFormaDePago2.Items.Add("")
            Dim conexiones1 As New CConexion
            conexiones1.conexion()
            'Dim command1 As SqlCommand = New SqlCommand("SELECT rtrim([DESCRIPCION]) FROM [_FORMAPAGO] WHERE [TIPOFORMAPAGO] ='" + CboFormaDePago.SelectedItem.ToString.Trim + "' and vigente = 1  ORDER BY rtrim([DESCRIPCION]) DESC", conexiones1._conexion)
            Dim command1 As SqlCommand = New SqlCommand("SELECT FP.DESCRIPCION FROM _FORMAPAGO AS FP  INNER JOIN _CONVENIO_FORMAPAGO AS CF ON FP.VIGENTE = 1 AND CF.CODFOR = FP.CODFOR AND CF.CODINS = " + txtCOD_INST.Text.ToString + " and FP.[TIPOFORMAPAGO] ='" + CboFormaDePago.SelectedItem.ToString.Trim + "' and FP.vigente = 1 UNION SELECT FP.DESCRIPCION FROM _FORMAPAGO AS FP WHERE FP.VIGENTE = 1 AND FP.TODO_CONVENIO = 1 and FP.[TIPOFORMAPAGO] ='" + CboFormaDePago.SelectedItem.ToString.Trim + "' and FP.vigente = 1 UNION  SELECT FP.DESCRIPCION FROM _FORMAPAGO AS FP WHERE FP.CODFOR=" + txtCOD_INST.Text.ToString + " and FP.[TIPOFORMAPAGO] ='" + CboFormaDePago.SelectedItem.ToString.Trim + "' and FP.vigente = 1 ORDER BY 1  ", conexiones1._conexion)
            conexiones1.abrir()
            Dim reader1 As SqlDataReader = command1.ExecuteReader()

            If reader1.HasRows Then
                Do While reader1.Read()

                    CboFormaDePago2.Items.Add(reader1(0).ToString)

                Loop
            Else
            End If
            reader1.Close()
        End If

        'conexiones1.cerrar()

        'CboFormaDePago2.SelectedItem = ""
        'CboFormaDePago2.SelectedItem = txtInstitucion.Text.ToString.Trim
        BtnRenta.BackColor = Color.MistyRose


    End Sub

    Private Sub CboProtestosyMorocidades_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboProtestosyMorocidades.SelectedIndexChanged
        If (CboProtestosyMorocidades.SelectedItem = "") Then
            CboProtestosyMorocidades.BackColor = Color.MistyRose
        Else
            CboProtestosyMorocidades.BackColor = Color.White

        End If
    End Sub

    Private Sub cboCompartamiento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCompartamiento.SelectedIndexChanged
        If (cboCompartamiento.SelectedItem = "") Then
            cboCompartamiento.BackColor = Color.MistyRose
        Else
            cboCompartamiento.BackColor = Color.White

        End If
    End Sub

















    Private Sub Pic5_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Pic5.VisibleChanged
        If Pic5.Visible = True Then
            Pic5A.Visible = True
            Pic5B.Visible = False
        Else
            Pic5A.Visible = False
            Pic5B.Visible = True
        End If
    End Sub






    Private Sub TxtDeudaFinanciera_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDeudaFinanciera.TextChanged
        If (TxtDeudaFinanciera.Text = "") Then
            TxtDeudaFinanciera.BackColor = Color.MistyRose
        Else
            TxtDeudaFinanciera.BackColor = Color.White

        End If
    End Sub

    Private Sub txtDeudaHipotecaria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeudaHipotecaria.TextChanged
        If (txtDeudaHipotecaria.Text = "") Then
            txtDeudaHipotecaria.BackColor = Color.MistyRose
        Else
            txtDeudaHipotecaria.BackColor = Color.White

        End If
    End Sub

    Private Sub txtDeudaConsumo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeudaConsumo.TextChanged
        If (txtDeudaConsumo.Text = "") Then
            txtDeudaConsumo.BackColor = Color.MistyRose
        Else
            txtDeudaConsumo.BackColor = Color.White

        End If
    End Sub

    Private Sub txtDeudaComercial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeudaComercial.TextChanged
        If (txtDeudaComercial.Text = "") Then
            txtDeudaComercial.BackColor = Color.MistyRose
        Else
            txtDeudaComercial.BackColor = Color.White

        End If
    End Sub

    Private Sub txtDeudaVencida_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeudaVencida.TextChanged
        If (txtDeudaVencida.Text = "") Then
            txtDeudaVencida.BackColor = Color.MistyRose
        Else
            txtDeudaVencida.BackColor = Color.White

        End If
    End Sub

    Private Sub txtLineaCredito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLineaCredito.TextChanged
        If (txtLineaCredito.Text = "") Then
            txtLineaCredito.BackColor = Color.MistyRose
        Else
            txtLineaCredito.BackColor = Color.White

        End If
    End Sub

    Private Sub txtNumeroAcreedoresFinan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroAcreedoresFinan.TextChanged
        If (txtNumeroAcreedoresFinan.Text = "") Then
            txtNumeroAcreedoresFinan.BackColor = Color.MistyRose
        Else
            txtNumeroAcreedoresFinan.BackColor = Color.White
        End If
    End Sub

    Private Sub txtExternaAcreditado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExternaAcreditado.TextChanged
        If (txtExternaAcreditado.Text = "") Then
            txtExternaAcreditado.BackColor = Color.MistyRose
        Else
            txtExternaAcreditado.BackColor = Color.White
        End If
    End Sub

    Private Sub txtActivos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtActivos.TextChanged
        If (txtActivos.Text = "") Then
            txtActivos.BackColor = Color.MistyRose
        Else
            txtActivos.BackColor = Color.White
        End If
    End Sub

    Private Sub txtPropiedades_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPropiedades.TextChanged
        If (txtPropiedades.Text = "") Then
            txtPropiedades.BackColor = Color.MistyRose
        Else
            txtPropiedades.BackColor = Color.White
        End If
    End Sub

    Private Sub txtVehiculos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVehiculos.TextChanged
        If (txtVehiculos.Text = "") Then
            txtVehiculos.BackColor = Color.MistyRose
        Else
            txtVehiculos.BackColor = Color.White
        End If
    End Sub

    Private Sub btnVerificar4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerificar5.Click
        If (TxtDeudaFinanciera.BackColor = Color.MistyRose Or txtDeudaHipotecaria.BackColor = Color.MistyRose Or txtDeudaConsumo.BackColor = Color.MistyRose Or txtDeudaComercial.BackColor = Color.MistyRose Or txtDeudaVencida.BackColor = Color.MistyRose Or txtLineaCredito.BackColor = Color.MistyRose Or txtDeudaComercial.BackColor = Color.MistyRose Or txtNumeroAcreedoresFinan.BackColor = Color.MistyRose Or txtExternaAcreditado.BackColor = Color.MistyRose Or txtActivos.BackColor = Color.MistyRose Or txtPropiedades.BackColor = Color.MistyRose Or txtVehiculos.BackColor = Color.MistyRose) Then
            MsgBox("Debe Completar todos los campos requeridos")
        Else


            If (txtVisibleSocio.Text = "NO") Then
                MsgBox("Se debe Verificar Ficha Socio antes de continuar")
            Else

                If (TxtDeudaFinanciera.BackColor = Color.MistyRose Or txtDeudaHipotecaria.BackColor = Color.MistyRose Or txtDeudaConsumo.BackColor = Color.MistyRose Or txtDeudaComercial.BackColor = Color.MistyRose Or txtDeudaVencida.BackColor = Color.MistyRose Or txtLineaCredito.BackColor = Color.MistyRose Or txtDeudaComercial.BackColor = Color.MistyRose Or txtNumeroAcreedoresFinan.BackColor = Color.MistyRose Or txtExternaAcreditado.BackColor = Color.MistyRose Or txtActivos.BackColor = Color.MistyRose Or txtPropiedades.BackColor = Color.MistyRose Or txtVehiculos.BackColor = Color.MistyRose) Then
                    MsgBox("Debe Completar todos los campos requeridos")
                Else

                    If ValidarRut(txtrutaval1.Text) = "Rut Incorrecto" Then

                        MsgBox("Aval 1 digitado incorrecto")
                    Else


                        If ValidarRut(txtRutAval2.Text) = "Rut Incorrecto" Then

                            MsgBox("Aval 2 digitado incorrecto")

                        Else

                            If IsNumeric(txtPYM6.Text) = False And IsNumeric(txtPYM6.Text) = False And IsNumeric(txtPYM1224.Text) = False And IsNumeric(txtPYM612.Text) = False Then
                                MsgBox("Verifique los datos ingresados en DICOM- Protesto y Morosidades")
                            Else

                                If (Integer.Parse(Replace(txtPYM6.Text, ".", "")) + Integer.Parse(Replace(txtPYM24.Text, ".", "")) + Integer.Parse(Replace(txtPYM1224.Text, ".", "")) + Integer.Parse(Replace(txtPYM612.Text, ".", ""))) = 0 And (CboProtestosyMorocidades.SelectedItem = "Registra Morosidades Vigentes DICOM y SBIF" Or CboProtestosyMorocidades.SelectedItem = "Registra Morosidades Vigentes DICOM") Then


                                    MsgBox("Debe registrar las morosidades Dicom tal como se indico en la pestaña Socio")
                                Else

                                    txtPYMTotal.Text = Integer.Parse(Replace(txtPYM6.Text, ".", "")) + Integer.Parse(Replace(txtPYM24.Text, ".", "")) + Integer.Parse(Replace(txtPYM1224.Text, ".", "")) + Integer.Parse(Replace(txtPYM612.Text, ".", ""))
                                    txtPYMTotal.Text = Puntos(txtPYMTotal.Text)
                                    TxtDeudaFinanciera.Text = Int(txtDeudaHipotecaria.Text) + Int(txtDeudaConsumo.Text) + Int(txtDeudaComercial.Text)
                                    '+ Int(txtDeudaVencida.Text)

                                    'If CboRenta.SelectedItem = "" Then
                                    '    'TXTRENTALIQUIDA.Text = 0
                                    'ElseIf CboRenta.SelectedItem = "Mixta" Then
                                    '    TXTRENTALIQUIDA.Text = Math.Round(DGEmpreadosyPensionados.Rows(6).Cells(5).Value() + DGProfesionalesyTrabajadoresIndependientes2.Rows(2).Cells(2).Value(), 0, MidpointRounding.ToEven)
                                    'ElseIf CboRenta.SelectedItem = "Empleados" Then
                                    '    TXTRENTALIQUIDA.Text = Math.Round(DGEmpreadosyPensionados.Rows(6).Cells(5).Value(), 0, MidpointRounding.ToEven)
                                    'ElseIf CboRenta.SelectedItem = "Pensionados" Then
                                    '    TXTRENTALIQUIDA.Text = Math.Round(DGEmpreadosyPensionados.Rows(6).Cells(5).Value(), 0, MidpointRounding.ToEven)
                                    'ElseIf CboRenta.SelectedItem = "Independientes" Then
                                    '    TXTRENTALIQUIDA.Text = Math.Round(DGProfesionalesyTrabajadoresIndependientes2.Rows(2).Cells(2).Value(), 0, MidpointRounding.ToEven)
                                    'End If

                                    If (Integer.Parse(txtExternaAcreditado.Text) > 0) Then
                                        txtCargaFinanciera.Text = Double.Parse(txtExternaAcreditado.Text).ToString
                                    Else
                                        txtCargaFinanciera.Text = Double.Parse((Integer.Parse(txtDeudaConsumo.Text) * 0.05) + (Integer.Parse(txtDeudaComercial.Text) * 0.05) + (Integer.Parse(txtLineaCredito.Text) * 0.025) + (Integer.Parse(txtDeudaHipotecaria.Text) * 0.01))
                                    End If
                                    txtRentaLiquidaDepurada.Text = (Double.Parse(TXTRENTALIQUIDA.Text) - Double.Parse(txtCargaFinanciera.Text)).ToString
                                    btnEditar5.Enabled = True
                                    btnVerificar5.Enabled = True
                                    txtPYM6.ReadOnly = True
                                    txtPYM1224.ReadOnly = True
                                    txtPYM612.ReadOnly = True
                                    txtPYM24.ReadOnly = True
                                    Pic5.Visible = True
                                    btnVerificar5.Enabled = False
                                    btnEditar5.Enabled = True
                                    txtVisibledEUDAeiNGRESOS.Text = "SI"
                                    ChkExternaAcreditado.Enabled = False
                                    ChkActivos.Enabled = False
                                    ChkPropiedades.Enabled = False
                                    ChkVehiculos.Enabled = False
                                    ChkAval1.Enabled = False
                                    ChkAval2.Enabled = False
                                    txtExternaAcreditado.ReadOnly = True
                                    txtActivos.ReadOnly = True
                                    txtPropiedades.ReadOnly = True
                                    txtVehiculos.ReadOnly = True
                                    txtrutaval1.ReadOnly = True
                                    txtRutAval2.ReadOnly = True
                                    cboPeriodo2.Enabled = False
                                    ChkmodificaDeudaExterna.Enabled = False
                                    cboPeriodo2.Enabled = False
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub





    Private Sub btnEditar5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar5.Click
        EDITARDEUDASEINGRESOS()
    End Sub


    Sub EDITARDEUDASEINGRESOS()
        Pic5.Visible = False
        btnVerificar5.Enabled = True
        btnEditar5.Enabled = False
        txtRentaLiquidaDepurada.Text = 0
        txtVisibledEUDAeiNGRESOS.Text = "NO"


        ChkExternaAcreditado.Enabled = True
        ChkActivos.Enabled = True

        ChkPropiedades.Enabled = True
        ChkVehiculos.Enabled = True

        ChkAval1.Enabled = True
        ChkAval2.Enabled = True


        txtExternaAcreditado.ReadOnly = False
        txtActivos.ReadOnly = False
        txtPropiedades.ReadOnly = False
        txtVehiculos.ReadOnly = False
        txtrutaval1.ReadOnly = False
        txtRutAval2.ReadOnly = False

        txtPYM6.Text = "0"
        txtPYM1224.Text = "0"
        txtPYM612.Text = "0"
        txtPYM24.Text = "0"
        txtPYMTotal.Text = "0"

        txtPYM6.ReadOnly = False
        txtPYM1224.ReadOnly = False
        txtPYM612.ReadOnly = False
        txtPYM24.ReadOnly = False


        Pic1.Visible = False
        btnVerificar.Enabled = True
        btnEditar.Enabled = False
        TableLayoutPanel3.Enabled = True

        cboPeriodo2.Enabled = True


        ChkmodificaDeudaExterna.Enabled = True
        EDITARPRESTAMO()
    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNVALIDAR.Click

        Me.Enabled = False
        My.Forms.frmFicha.MdiParent = My.Forms.frmRIESGO
        My.Forms.frmFicha.WindowState = FormWindowState.Normal
        My.Forms.frmFicha.Show()
        My.Forms.frmFicha.Location = New Point(0, 0)



    End Sub


    Private Sub Pic4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chksicontrato.CheckedChanged
        If (chksicontrato.Checked = True) Then
            DateFechaContrato.Enabled = True
            chknocontrato.Checked = False
            chksicontrato.BackColor = Color.Transparent
            chknocontrato.BackColor = Color.Transparent
        Else
            DateFechaContrato.Enabled = False
            DateFechaContrato.Value = Date.Now()
            chknocontrato.Checked = True
        End If
    End Sub

    Private Sub chknocontrato_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chknocontrato.CheckedChanged
        If (chknocontrato.Checked = True) Then
            DateFechaContrato.Enabled = False
            chksicontrato.Checked = False
            chksicontrato.BackColor = Color.Transparent
            chknocontrato.BackColor = Color.Transparent
        Else
            DateFechaContrato.Enabled = True
            chksicontrato.Checked = True
        End If
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



    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnuevosocio.Click
        If EstaAbierto(frmRentas) Then
            frmRentas.Close()
        End If
        If EstaAbierto(frmPrepago) Then
            frmPrepago.Close()
        End If
        If EstaAbierto(frmFicha) Then
            frmFicha.Close()
        End If
        If EstaAbierto(AVISO) Then
            AVISO.Close()
        End If


        'txtNrosocio.Text = ""
        'txtNrosocio.Enabled = True
        'TXTANUNCIO2.Visible = False
        'CERRARTODO()
        Me.Close()

        frmRIESGO.abrirevaluarpersonas()



        'txtnuevosocio.Enabled = False
        'btnBuscar.Enabled = True


    End Sub






    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("Cbotipo.SelectedItem " + Cbotipo.SelectedItem)
        MsgBox("Cbotipo..SelectedValue " + Cbotipo.SelectedValue)
        MsgBox("Cbotipo.SelectedItem " + Cbotipo.SelectedItem)



    End Sub

    Private Sub CboEjecutivo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboEjecutivo.SelectedIndexChanged

        Dim producto As String = ""


        Try
            producto = txtProducto.Text.ToString.Trim
        Catch ex As Exception

        End Try


        If (CboEjecutivo.SelectedItem.ToString.Trim <> "SIN EJECUTIVO") Then
            cboTasaSolicitada.Enabled = True
            cboTasaSolicitada.Items.Clear()
            cboTasaSolicitada.Items.Add("Por Defecto Sistema")
            For i = 0.8 To 2.01 Step 0.01
                cboTasaSolicitada.Items.Add(i.ToString)
            Next

        Else
            cboTasaSolicitada.Items.Clear()
            cboTasaSolicitada.Items.Add("Por Defecto Sistema")
            cboTasaSolicitada.Enabled = False
        End If


        If CboFormaDePago.SelectedItem = "PLANILLA" Then
            cboTasaSolicitada.SelectedItem = txtTasaConvenio.Text
            'cboTasaSolicitada.Enabled = False
        Else
            cboTasaSolicitada.SelectedItem = "Por Defecto Sistema"
            'cboTasaSolicitada.Enabled = True
        End If


    End Sub



    Private Sub txtNrosocio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNrosocio.KeyDown
        If e.KeyCode = Keys.Enter Then

            consultardatos()
            cargarCompromisos()
            cargarprestamo()
            cargardeuda()

        End If
    End Sub



    Private Sub TxtComportamientoClasificacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtComportamientoClasificacion.TextChanged
        If TxtComportamientoClasificacion.Text.Trim <> "0" Then
            TxtComportamientoClasificacion.BackColor = Color.Red
        Else
            TxtComportamientoClasificacion.BackColor = Color.Green
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



    Private Sub btnVerificar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerificar2.Click
        If (CboReferencias.BackColor = Color.MistyRose Or CboFormaDePago.BackColor = Color.MistyRose Or BtnRenta.BackColor = Color.MistyRose Or CboProtestosyMorocidades.BackColor = Color.MistyRose Or chksicontrato.BackColor = Color.MistyRose Or CboFormaDePago2.BackColor = Color.MistyRose Or cboFueradeZona.BackColor = Color.MistyRose Or cboPlataforma.BackColor = Color.MistyRose Or cboAtencion.BackColor = Color.MistyRose) Then
            MsgBox("Debe Completar todos los campos requeridos")
        Else
            Pic2.Visible = True
            btnVerificar2.Enabled = False
            btnEditar2.Enabled = True
            TableLayoutPanel2.Enabled = False
            cargarprestamo()
            txtVisibleSocio.Text = "SI"


            txtAumentaTasa2.Text = "0"


            If CboProtestosyMorocidades.SelectedItem = "Registra Morosidades Vigentes DICOM" Or CboProtestosyMorocidades.SelectedItem = "Registra Morosidades Vigentes DICOM y SBIF" Then
                txtPYM6.Text = "0"
                txtPYM1224.Text = "0"
                txtPYM612.Text = "0"
                txtPYM24.Text = "0"

                txtPYM6.ReadOnly = False
                txtPYM1224.ReadOnly = False
                txtPYM612.ReadOnly = False
                txtPYM24.ReadOnly = False
            Else
                txtPYM6.Text = "0"
                txtPYM1224.Text = "0"
                txtPYM612.Text = "0"
                txtPYM24.Text = "0"

                txtPYM6.ReadOnly = True
                txtPYM1224.ReadOnly = True
                txtPYM612.ReadOnly = True
                txtPYM24.ReadOnly = True
            End If

            CargarCodFormaPago()


        End If





    End Sub

    Sub CargarCodFormaPago()


        Dim conexiones15 As New CConexion
        conexiones15.conexion()
        Dim command15 As SqlCommand = New SqlCommand("SELECT CODFOR FROM _FORMAPAGO WHERE DESCRIPCION='" + CboFormaDePago2.SelectedItem.ToString().Trim() + "'", conexiones15._conexion)
        conexiones15.abrir()
        Dim reader15 As SqlDataReader = command15.ExecuteReader()

        If reader15.HasRows Then
            Do While reader15.Read()
                txtCOD_FORMAPAGO.Text = (reader15(0).ToString)
            Loop
        Else

        End If

    End Sub


    Private Sub CboFormaDePago2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboFormaDePago2.SelectedIndexChanged

        If (CboFormaDePago2.SelectedItem = "") Then
            CboFormaDePago2.BackColor = Color.MistyRose
        Else
            CboFormaDePago2.BackColor = Color.White
        End If


    End Sub

    Private Sub Cbotipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbotipo.SelectedIndexChanged



        If Cbotipo.SelectedItem = "SOCIO" Then
            Label1.Text = "Nº  SOCIO :"
        ElseIf Cbotipo.SelectedItem = "PRE-SOCIO" Then
            Label1.Text = "Nº  PRE-SOCIO :"
        End If
    End Sub


    Private Sub txtRut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRut.TextChanged
        Dim fraude As String = ""

        Dim conexiones14 As New CConexion
        conexiones14.conexion()
        Dim command14 As SqlCommand = New SqlCommand("SELECT  DESCRIPCION FROM [_COBRANZA_RUT_RIESGO] where convert(varchar,rut)+'-'+dv='" + txtRut.Text + "'", conexiones14._conexion)
        conexiones14.abrir()
        Dim reader14 As SqlDataReader = command14.ExecuteReader()

        If reader14.HasRows Then
            Do While reader14.Read()
                fraude = (reader14(0).ToString)
            Loop
        Else
        End If

        reader14.Close()
        'conexiones14.cerrar()
        labelRiesgoRut.Text = fraude

    End Sub

    Private Sub txtReferenciado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReferenciado.TextChanged
        If txtReferenciado.Text = "SI" Then
            txtReferenciado.ForeColor = Color.Green
        End If
    End Sub

    Private Sub txtNrosocio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNrosocio.TextChanged

    End Sub

    Private Sub cboRefRen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRefRen.SelectedIndexChanged
        If cboRefRen.SelectedItem <> "" Then
            cboRefRen.BackColor = Color.White
        Else
            cboRefRen.BackColor = Color.MistyRose
        End If

        btnPrepago.BackColor = Color.MistyRose
    End Sub

    Private Sub CboReferencias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboReferencias.SelectedIndexChanged
        If (CboReferencias.SelectedItem = "") Then
            CboReferencias.BackColor = Color.MistyRose
        Else
            CboReferencias.BackColor = Color.White
        End If
    End Sub



    Private Sub cboFueradeZona_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFueradeZona.SelectedIndexChanged
        If (cboFueradeZona.SelectedItem = "") Then
            cboFueradeZona.BackColor = Color.MistyRose
        Else
            cboFueradeZona.BackColor = Color.White
        End If
    End Sub

    Private Sub cboPlataforma_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPlataforma.SelectedIndexChanged
        If (cboPlataforma.SelectedItem = "") Then
            cboPlataforma.BackColor = Color.MistyRose
        Else
            cboPlataforma.BackColor = Color.White
        End If
    End Sub



    Public Sub puntajes()
        richTextBox2.Clear()
        'richTextBox2.BulletIndent = 30
        'WriteTextToRichTextBox()
        Dim ADVERTENCIA As String = ""
        Dim edad As String
        Dim estadocivil As String
        Dim vivienda As String
        Dim categoria As String
        Dim formadepago2 As String
        Dim region As String
        Dim puntaje As String
        Dim antiguedad As String
        Dim sexo As String
        Dim lvl As String
        Dim capacidad As String
        Dim renta As String
        Dim plazo As String
        Dim TipodeSocio As String
        Dim DiasdeGracia As String
        Dim Plataforma As String
        Dim Monto As String
        Dim contador As Integer = 0
        Dim aumentaTasa As Integer = 0

        Dim Words As New List(Of String)

        richTextBox2.Text = ""
        puntaje = 0


        '' ---------------- CATEGORIA PLANILLA O CONSUMO
        'TXTPUNTAJES3.Text = TXTPUNTAJES3.Text + "{\rtf1\ansi This is in \b bold\b0.}" + Environment.NewLine
        'richTextBox1.Rtf = "{\rtf1\ansi This is in \b bold\b0.}"
        If CboFormaDePago.SelectedItem.ToString = "PLANILLA" Then
            categoria = "Planilla"
            richTextBox2.Text = "Forma De Pago No valida por PLANILLA" + Environment.NewLine + Environment.NewLine
        Else
            categoria = "Consumo"
        End If


        ''INDICE FORMAPAGO------------------------------------------


        formadepago2 = CboFormaDePago2.SelectedItem.ToString.Trim
        'MsgBox(formadepago2)
        'If (formadepago2 = "") Then
        '    formadepago2 = "Pago en Oficina"
        '    ADVERTENCIA = "* No tiene Historico por defecto 'Pago en Oficina' "
        'End If


        Dim conexiones7 As New CConexion
        conexiones7.conexion()
        Dim command7 As SqlCommand = New SqlCommand("  SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (6,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Forma Pago' and  [Rango1] ='" + formadepago2 + "'", conexiones7._conexion)
        conexiones7.abrir()
        Dim reader7 As SqlDataReader = command7.ExecuteReader()

        If reader7.HasRows Then
            Do While reader7.Read()


                puntaje = puntaje + Double.Parse((reader7(0).ToString))



                richTextBox2.Text += "Forma de pago:" + Environment.NewLine + " " + formadepago2 + " |  " + reader7(0).ToString + Environment.NewLine + Environment.NewLine
                'richTextBox1.Text += " " + formadepago2 + " |  " + reader7(0).ToString + Environment.NewLine


                If (ADVERTENCIA <> "") Then
                    richTextBox2.Text = richTextBox2.Text + ADVERTENCIA + Environment.NewLine + Environment.NewLine
                End If
                Words.Add(reader7(0).ToString)
                'colorWord(reader7(0).ToString)
            Loop
        Else
        End If

        reader7.Close()
        conexiones7.cerrar()
        ADVERTENCIA = ""



        ' ''INDICE CAPACIDAD------------------------------------------


        'If Replace(txtScoringCapacidadnumerico.Text.ToString, "%", "") = "" Then
        '    capacidad = "0"
        '    ADVERTENCIA = "* No tiene Historico por defecto 0 "
        'Else
        capacidad = txtScoringCapacidadnumerico.Text.ToString

        'End If

        'End If


        Dim conexiones9 As New CConexion
        conexiones9.conexion()
        Dim command9 As SqlCommand = New SqlCommand("SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (38,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Capacidad' and   CONVERT(decimal (38,2),'" + capacidad + "')>CONVERT(decimal (38,2),rango1) AND CONVERT(decimal (38,2),'" + capacidad + "')<=CONVERT(decimal (38,2),rango2) ", conexiones9._conexion)
        conexiones9.abrir()
        Dim reader9 As SqlDataReader = command9.ExecuteReader()

        If reader9.HasRows Then
            Do While reader9.Read()

                puntaje = puntaje + Double.Parse((reader9(0).ToString))


                'richTextBox1.Text = richTextBox1.Text + "Capacidad de Pago (" + capacidad.Trim + ") " + reader9(0).ToString + Environment.NewLine

                richTextBox2.Text += "Capacidad de pago:" + Environment.NewLine + " " + capacidad.Trim + " |  " + reader9(0).ToString + Environment.NewLine + Environment.NewLine
                'richTextBox1.Text += 


                If (ADVERTENCIA <> "") Then
                    richTextBox2.Text = richTextBox2.Text + ADVERTENCIA + Environment.NewLine + Environment.NewLine
                End If

                Words.Add(reader9(0).ToString)
            Loop
        Else
        End If

        reader9.Close()
        conexiones9.cerrar()
        ADVERTENCIA = ""

        ''INDICE EDAD------------------------------------------
        edad = txtScoringEdad.Text.Trim

        Dim conexiones8 As New CConexion
        conexiones8.conexion()
        Dim command8 As SqlCommand = New SqlCommand("SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (38,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Edad' and   CONVERT(decimal (38,2),'" + edad + "')>CONVERT(decimal (38,2),rango1) AND CONVERT(decimal (38,2),'" + edad + "')<=CONVERT(decimal (38,2),rango2)", conexiones8._conexion)
        conexiones8.abrir()
        Dim reader8 As SqlDataReader = command8.ExecuteReader()

        If reader8.HasRows Then
            Do While reader8.Read()
                puntaje = puntaje + Double.Parse((reader8(0).ToString))

                richTextBox2.Text += "Edad:" + Environment.NewLine + " " + edad.Trim + " |  " + reader8(0).ToString + Environment.NewLine + Environment.NewLine

                Words.Add(reader8(0).ToString)
            Loop
        Else
        End If

        reader8.Close()
        conexiones8.cerrar()

        ''INDICE LEVERAGE------------------------------------------

        lvl = txtScoringLvlnumerico.Text
        Dim conexiones88 As New CConexion
        conexiones88.conexion()
        Dim command88 As SqlCommand = New SqlCommand("SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (38,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Leverage' and   CONVERT(decimal (38,2),'" + lvl + "')>CONVERT(decimal (38,2),rango1) AND CONVERT(decimal (38,2),'" + lvl + "')<=CONVERT(decimal (38,2),rango2)", conexiones88._conexion)
        conexiones88.abrir()
        Dim reader88 As SqlDataReader = command88.ExecuteReader()

        If reader88.HasRows Then
            Do While reader88.Read()
                puntaje = puntaje + Double.Parse((reader88(0).ToString))
                richTextBox2.Text += "Leverage:" + Environment.NewLine + " " + lvl.Trim + " |  " + reader88(0).ToString + Environment.NewLine + Environment.NewLine
                Words.Add(reader88(0).ToString)
            Loop
        Else
        End If

        reader88.Close()
        conexiones88.cerrar()

        ''INDICE VIVIENDA------------------------------------------


        vivienda = txtTipoVivienda.Text.Trim
        'MsgBox(formadepago2)
        If (vivienda = "") Then
            vivienda = "Sin registro"
            ADVERTENCIA = "* No tiene Historico por defecto 'Sin registro' "
        End If


        Dim conexiones77 As New CConexion
        conexiones77.conexion()
        Dim command77 As SqlCommand = New SqlCommand("  SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (6,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Vivienda' and  [Rango1] ='" + vivienda + "'", conexiones77._conexion)
        conexiones77.abrir()
        Dim reader77 As SqlDataReader = command77.ExecuteReader()

        If reader77.HasRows Then
            Do While reader77.Read()


                puntaje = puntaje + Double.Parse((reader77(0).ToString))


                richTextBox2.Text += "Vivienda:" + Environment.NewLine + " " + vivienda.Trim + " |  " + reader77(0).ToString + Environment.NewLine + Environment.NewLine

                If (ADVERTENCIA <> "") Then
                    richTextBox2.Text = richTextBox2.Text + ADVERTENCIA + Environment.NewLine + Environment.NewLine
                End If

                Words.Add(reader77(0).ToString)
            Loop
        Else
        End If

        reader77.Close()
        conexiones77.cerrar()
        ADVERTENCIA = ""

        '    ''INDICE ESTADO CIVIL------------------------------------------

        estadocivil = txtEstadoCivil.Text.Trim

        If (estadocivil = "") Then
            estadocivil = "Soltero"
            ADVERTENCIA = "* No tiene Historico por defecto 'Soltero' "
        End If


        Dim conexiones99 As New CConexion
        conexiones99.conexion()
        Dim command99 As SqlCommand = New SqlCommand("  SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (6,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Estado Civil' and  [Rango1] ='" + estadocivil + "'", conexiones99._conexion)
        conexiones99.abrir()
        Dim reader99 As SqlDataReader = command99.ExecuteReader()

        If reader99.HasRows Then
            Do While reader99.Read()


                puntaje = puntaje + Double.Parse((reader99(0).ToString))

                richTextBox2.Text += "Estado Civil:" + Environment.NewLine + " " + estadocivil.Trim + " |  " + reader99(0).ToString + Environment.NewLine + Environment.NewLine

                If (ADVERTENCIA <> "") Then
                    richTextBox2.Text = richTextBox2.Text + ADVERTENCIA + Environment.NewLine + Environment.NewLine
                End If

                Words.Add(reader99(0).ToString)
            Loop
        Else
        End If

        reader99.Close()
        conexiones99.cerrar()
        ADVERTENCIA = ""

        ''INDICE REGIÓN------------------------------------------

        region = txtRegion.Text.Trim

        If (region = "") Then
            region = "VALPARAISO                              "
            ADVERTENCIA = "* No tiene Historico por defecto 'VALPARAISO' "
        End If


        Dim conexiones99b As New CConexion
        conexiones99b.conexion()
        Dim command99b As SqlCommand = New SqlCommand("  SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (6,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Región' and  [Rango1] ='" + region + "'", conexiones99b._conexion)
        conexiones99b.abrir()
        Dim reader99b As SqlDataReader = command99b.ExecuteReader()

        If reader99b.HasRows Then
            Do While reader99b.Read()


                puntaje = puntaje + Double.Parse((reader99b(0).ToString))


                richTextBox2.Text += "Región:" + Environment.NewLine + " " + region.Trim + " |  " + reader99b(0).ToString + Environment.NewLine + Environment.NewLine

                If (ADVERTENCIA <> "") Then
                    richTextBox2.Text = richTextBox2.Text + ADVERTENCIA + Environment.NewLine + Environment.NewLine
                End If

                Words.Add(reader99b(0).ToString)
            Loop
        Else
        End If

        reader99b.Close()
        conexiones99b.cerrar()
        ADVERTENCIA = ""




        ''INDICE SEXO------------------------------------------

        sexo = txtScoringSexo.Text.Trim

        'If (region = "") Then
        '    region = "VALPARAISO                              "
        '    ADVERTENCIA = "* No tiene Historico por defecto 'VALPARAISO' "
        'End If


        Dim conexiones99C As New CConexion
        conexiones99C.conexion()
        Dim command99C As SqlCommand = New SqlCommand("  SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (6,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Sexo' and  [Rango1] ='" + sexo + "'", conexiones99C._conexion)
        conexiones99C.abrir()
        Dim reader99C As SqlDataReader = command99C.ExecuteReader()

        If reader99C.HasRows Then
            Do While reader99C.Read()


                puntaje = puntaje + Double.Parse((reader99C(0).ToString))


                richTextBox2.Text += "Sexo:" + Environment.NewLine + " " + sexo.Trim + " |  " + reader99C(0).ToString + Environment.NewLine + Environment.NewLine

                'If (ADVERTENCIA <> "") Then
                '    richTextBox1.Text = richTextBox1.Text + ADVERTENCIA + Environment.NewLine
                'End If

                Words.Add(reader99C(0).ToString)
            Loop
        Else
        End If
        reader99C.Close()
        conexiones99C.cerrar()
        '    reader99C.Close()


        ''INDICE ANTIGUEDAD------------------------------------------
        antiguedad = txtScoringAntiguedad.Text
        Dim conexiones88A As New CConexion
        conexiones88A.conexion()
        Dim command88A As SqlCommand = New SqlCommand("SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (38,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Antigüedad' and   CONVERT(decimal (38,2),'" + antiguedad + "')>CONVERT(decimal (38,2),rango1) AND CONVERT(decimal (38,2),'" + antiguedad + "')<=CONVERT(decimal (38,2),rango2)", conexiones88A._conexion)
        conexiones88A.abrir()
        Dim reader88A As SqlDataReader = command88A.ExecuteReader()

        If reader88A.HasRows Then
            Do While reader88A.Read()
                puntaje = puntaje + Double.Parse((reader88A(0).ToString))
                richTextBox2.Text += "Antiguedad:" + Environment.NewLine + " " + antiguedad.Trim + " |  " + reader88A(0).ToString + Environment.NewLine + Environment.NewLine
                Words.Add(reader88A(0).ToString)
            Loop
        Else
        End If

        reader88A.Close()
        conexiones88A.cerrar()


        '    ''INDICE RENTA------------------------------------------
        renta = Replace(TXTRENTALIQUIDA.Text, ".", "")
        Dim conexiones88B As New CConexion
        conexiones88B.conexion()
        Dim command88B As SqlCommand = New SqlCommand("SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (38,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Renta' and   CONVERT(decimal (38,2),'" + renta + "')>CONVERT(decimal (38,2),rango1) AND CONVERT(decimal (38,2),'" + renta + "')<=CONVERT(decimal (38,2),rango2)", conexiones88B._conexion)
        conexiones88B.abrir()
        Dim reader88B As SqlDataReader = command88B.ExecuteReader()

        If reader88B.HasRows Then
            Do While reader88B.Read()
                puntaje = puntaje + Double.Parse((reader88B(0).ToString))
                richTextBox2.Text += "Renta:" + Environment.NewLine + " " + TXTRENTALIQUIDA.Text.Trim + " |  " + reader88B(0).ToString + Environment.NewLine + Environment.NewLine
                Words.Add(reader88B(0).ToString)
            Loop
        Else
        End If

        reader88B.Close()
        conexiones88B.cerrar()


        'INDICE PLAZO------------------------------------------
        plazo = CboCuotas.SelectedItem.ToString.Trim
        Dim conexiones88C As New CConexion
        conexiones88C.conexion()
        Dim command88C As SqlCommand = New SqlCommand("SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (38,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='plazo' and   CONVERT(decimal (38,2),'" + plazo + "')>CONVERT(decimal (38,2),rango1) AND CONVERT(decimal (38,2),'" + plazo + "')<=CONVERT(decimal (38,2),rango2)", conexiones88C._conexion)
        conexiones88C.abrir()
        Dim reader88C As SqlDataReader = command88C.ExecuteReader()

        If reader88C.HasRows Then
            Do While reader88C.Read()
                puntaje = puntaje + Double.Parse((reader88C(0).ToString))
                richTextBox2.Text += "Plazo:" + Environment.NewLine + " " + plazo.Trim + " |  " + reader88C(0).ToString + Environment.NewLine + Environment.NewLine
                Words.Add(reader88C(0).ToString)
            Loop
        Else
        End If

        reader88C.Close()
        conexiones88C.cerrar()
        '    'INDICE MONTO------------------------------------------
        Monto = Replace(TxtMonto.Text, ".", "")
        Dim conexiones88D As New CConexion
        conexiones88D.conexion()
        Dim command88D As SqlCommand = New SqlCommand("SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (38,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Monto' and   CONVERT(decimal (38,2),'" + Monto + "')>CONVERT(decimal (38,2),rango1) AND CONVERT(decimal (38,2),'" + Monto + "')<=CONVERT(decimal (38,2),rango2)", conexiones88D._conexion)
        conexiones88D.abrir()
        Dim reader88D As SqlDataReader = command88D.ExecuteReader()

        If reader88D.HasRows Then
            Do While reader88D.Read()
                puntaje = puntaje + Double.Parse((reader88D(0).ToString))
                richTextBox2.Text += "Monto:" + Environment.NewLine + " " + TxtMonto.Text.Trim + " |  " + reader88D(0).ToString + Environment.NewLine + Environment.NewLine
                Words.Add(reader88D(0).ToString)
            Loop
        Else
        End If

        reader88D.Close()
        conexiones88D.cerrar()
        'ADVERTENCIA = ""


        ''INDICE Tipo de Socio------------------------------------------

        TipodeSocio = txtInstitucion.Text.Trim

        If (TipodeSocio = "") Then
            TipodeSocio = "Particular"
            ADVERTENCIA = "* No tiene Historico por defecto 'Particular' "
        End If



        Dim conexiones99De As New CConexion
        conexiones99De.conexion()
        Dim command99De As SqlCommand = New SqlCommand("IF EXISTS (SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (6,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Tipo de Socio' and  [Rango1] ='" + TipodeSocio + "') select 'SI' ELSE select 'NO'", conexiones99De._conexion)
        conexiones99De.abrir()
        Dim reader99De As SqlDataReader = command99De.ExecuteReader()

        If reader99De.HasRows Then
            Do While reader99De.Read()
                If (reader99De(0).ToString = "NO") Then
                    TipodeSocio = "Particular"
                    ADVERTENCIA = "* Categoria no ingresada por defecto puntaje de 'Particular' "
                End If
            Loop
        Else
        End If

        reader99De.Close()
        conexiones99De.cerrar()



        Dim conexiones99D As New CConexion
        conexiones99D.conexion()
        Dim command99D As SqlCommand = New SqlCommand("  SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (6,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Tipo de Socio' and  [Rango1] ='" + TipodeSocio + "'", conexiones99D._conexion)
        conexiones99D.abrir()
        Dim reader99D As SqlDataReader = command99D.ExecuteReader()

        If reader99D.HasRows Then
            Do While reader99D.Read()


                puntaje = puntaje + Double.Parse((reader99D(0).ToString))


                richTextBox2.Text += "Tipo de Socio:" + Environment.NewLine + " " + txtInstitucion.Text.Trim + " |  " + reader99D(0).ToString + Environment.NewLine + Environment.NewLine

                If (ADVERTENCIA <> "") Then
                    richTextBox2.Text = richTextBox2.Text + ADVERTENCIA + Environment.NewLine + Environment.NewLine
                End If

                Words.Add(reader99D(0).ToString)
            Loop
        Else
        End If

        reader99D.Close()
        conexiones99D.cerrar()

        '    ADVERTENCIA = ""


        'INDICE Dias de Gracia------------------------------------------
        DiasdeGracia = CboDiasdeGracia.Text

        Dim conexiones88F As New CConexion
        conexiones88F.conexion()
        Dim command88F As SqlCommand = New SqlCommand("SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (38,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Dias de Gracia' and   CONVERT(decimal (38,2),'" + DiasdeGracia + "')>CONVERT(decimal (38,2),rango1) AND CONVERT(decimal (38,2),'" + DiasdeGracia + "')<=CONVERT(decimal (38,2),rango2)", conexiones88F._conexion)
        conexiones88F.abrir()
        Dim reader88F As SqlDataReader = command88F.ExecuteReader()

        If reader88F.HasRows Then
            Do While reader88F.Read()
                puntaje = puntaje + Double.Parse((reader88F(0).ToString))
                richTextBox2.Text += "Dias de Gracia:" + Environment.NewLine + " " + DiasdeGracia.ToString.Trim + " |  " + reader88F(0).ToString + Environment.NewLine + Environment.NewLine
                Words.Add(reader88F(0).ToString)
            Loop
        Else
        End If
        reader88F.Close()
        conexiones88F.cerrar()


        ''INDICE PLATAFORMA------------------------------------------

        Plataforma = cboPlataforma.SelectedItem.ToString.Trim

        'If (region = "") Then
        '    region = "VALPARAISO                              "
        '    ADVERTENCIA = "* No tiene Historico por defecto 'VALPARAISO' "
        'End If

        Dim conexiones99F As New CConexion
        conexiones99F.conexion()
        Dim command99F As SqlCommand = New SqlCommand("  SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (6,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Plataforma' and  [Rango1] ='" + Plataforma + "'", conexiones99F._conexion)
        conexiones99F.abrir()
        Dim reader99F As SqlDataReader = command99F.ExecuteReader()

        If reader99F.HasRows Then
            Do While reader99F.Read()


                puntaje = puntaje + Double.Parse((reader99F(0).ToString))


                richTextBox2.Text += "Plataforma:" + Environment.NewLine + " " + Plataforma.Trim + " |  " + reader99F(0).ToString + Environment.NewLine + Environment.NewLine

                'If (ADVERTENCIA <> "") Then
                '    richTextBox1.Text = richTextBox1.Text + ADVERTENCIA + Environment.NewLine
                'End If

                Words.Add(reader99F(0).ToString)
            Loop
        Else
        End If

        reader99F.Close()
        conexiones99F.cerrar()
        ADVERTENCIA = ""




        'INDICA EL PUNTAJE FINAL
        'If (txtPuntaje3.Text.Trim <> "") Then
        '    txtPuntaje2.Text = txtPuntaje3.Text.Trim
        '    puntaje = txtPuntaje3.Text.Trim
        'Else
        '    txtPuntaje2.Text = puntaje
        richTextBox2.Text = Environment.NewLine + "Indice Acumulado " + puntaje + Environment.NewLine + Environment.NewLine + richTextBox2.Text
        'richTextBox1.SelectedRtf = richTextBox1.Text + Environment.NewLine + "{\rtf1\ansi This is in \b bold\b0.}" + puntaje + Environment.NewLine
        Words.Add(puntaje)
        'LPuntaje.Text = puntaje
        'End If

        'For i As Integer = 0 To Words.Count - 1
        '    colorWord(Words.Item(i))
        'Next

        'SIZEWord("Indice Acumulado " + puntaje, "titulo")
        ''SIZEWord("Factor ", "titulo")

        'SIZEWord("Forma de pago:", "subtitulo")
        'SIZEWord("Capacidad de pago:", "subtitulo")
        'SIZEWord("Edad:", "subtitulo")
        'SIZEWord("Leverage:", "subtitulo")
        'SIZEWord("Vivienda:", "subtitulo")
        'SIZEWord("Estado Civil:", "subtitulo")
        'SIZEWord("Región:", "subtitulo")
        'SIZEWord("Sexo:", "subtitulo")
        'SIZEWord("Antiguedad:", "subtitulo")
        'SIZEWord("Renta:", "subtitulo")
        'SIZEWord("Plazo:", "subtitulo")
        'SIZEWord("Monto:", "subtitulo")
        'SIZEWord("Tipo de Socio:", "subtitulo")
        'SIZEWord("Dias de Gracia:", "subtitulo")
        'SIZEWord("Plataforma:", "subtitulo")
        'SIZEWord("Forma De Pago No valida por PLANILLA", "subtitulo")

        '    'MsgBox(aumentaTasa)


        '   txtAumentaTasa2.Text = aumentaTasa.ToString

        txtAumentaTasa2.Text = 0


        cargarfactor(categoria, puntaje, plazo, txtTasaFinal.Text)
        cargartasamaxima(Replace(TxtMonto.Text, ".", ""))

        'cargarestado()


        cargardatos()
        EXCEPCIONESTASAS()

        contar = 1
    End Sub




    Sub EXCEPCIONESTASAS()






        Dim DeudaPYM As Integer = 0
        Dim DeudavIndirecta As Integer = 0
        Dim DeudavDirecta As Integer = 0

        'Dim Words As New List(Of String)


        If CboProtestosyMorocidades.SelectedItem.ToString.Trim = "Sin Antecedentes" Or CboProtestosyMorocidades.SelectedItem.ToString.Trim = "Buen comportamiento financiero" Then

            txtScoringAntecedentes.Text = "BUENO"
            txtAntecedentes.Text = "NO"
        Else

            txtScoringAntecedentes.Text = "MALO"
            txtAntecedentes.Text = "SI"
        End If

        'DATOS EXCEPCIONES


        If txtClasificacionBaja.Text.Trim = "A" Or txtClasificacionBaja.Text.Trim = "B" Or txtClasificacionBaja.Text.Trim = "NUNCA HA SIDO CLASIFICADO" Then
            txtScoringComportamiento.Text = "BUENO"
        Else
            txtScoringComportamiento.Text = "MALO"
        End If


        txtScoringMorosidades500000.Text = "BUENO"

        DeudaPYM = Integer.Parse(Replace(txtPYM6.Text, ".", "")) + Integer.Parse(Replace(txtPYM612.Text, ".", ""))
        DeudavIndirecta = Integer.Parse(Replace(txtDeudaVencidaIndirecta.Text, ".", ""))
        DeudavDirecta = Integer.Parse(Replace(txtDeudaVencida.Text, ".", ""))

        If DeudaPYM > 500000 Then
            txtScoringMorosidades500000.Text = "MALO"
        End If

        If DeudavIndirecta > 500000 Then
            txtScoringMorosidades500000.Text = "MALO"
        End If


        If DeudavDirecta > 500000 Then
            txtScoringMorosidades500000.Text = "MALO"
        End If




        If (Trim(Cbotipo.SelectedItem) = "PRE-SOCIO") Then

            txtNuevo.Text = "SI"
        Else
            txtNuevo.Text = "NO"
        End If

        txtEdad.Text = txtScoringEdad.Text

        If txtEstadoCivil.Text = "Casado en Sociedad Conyugal" Or txtEstadoCivil.Text = "Casado Separación de Bienes" Or txtEstadoCivil.Text = "Comunidad de Bienes" Then
            txtScoringEstadoCivil.Text = "BUENO"
        Else
            txtScoringEstadoCivil.Text = "MALO"
        End If

        If txtTipoVivienda.Text = "Propia" Or txtTipoVivienda.Text = "Propia con Dividendos" Then
            txtScoringPropiedad.Text = "BUENO"
        Else
            txtScoringPropiedad.Text = "MALO"
        End If

        If Double.Parse(txtRentaLiquidaDepurada.Text) > 250000 Then
            txtScoringRenta.Text = "BUENO"
        Else
            txtScoringRenta.Text = "MALO"
        End If



        If Math.Round((DateDiff("d", Date.Parse(DateFechaContrato.Value), Date.Now) / 365), 0, MidpointRounding.ToEven) >= 1 Then
            txtScoringAntiguedadLab2.Text = "BUENO"
        Else
            txtScoringAntiguedadLab2.Text = "MALO"
        End If




        Dim POLITICAS As String = ""
        Dim CONTADOR As Integer = 0











        'CONDICIONES EXCEPCIONES
        'PAGO POR PLANILLLA ---------------------------------------------------------------------------------------------------
        If CboFormaDePago.SelectedItem.ToString.Trim = "PLANILLA" Then


            'SI ES PAGO POR PLANILLLA ---- Y ES REFINANCIAMIENTO
            If CboObjetivo.SelectedItem.ToString.Trim = "Refinanciamiento" Then

                POLITICAS = "Socio forma de pago por planilla con objetivo de " + CboObjetivo.SelectedItem.ToString.Trim + Environment.NewLine + Environment.NewLine

                Dim avance As Integer = 0
                Dim Plazo As Integer = 0
                Dim cuota As Integer = 0


                Dim conexiones14 As New CConexion
                conexiones14.conexion()
                'Dim command14 As SqlCommand = New SqlCommand("SELECT MAX([PLAZO]) AS PLAZO ,SUM([PRIMERDIVIDENDO]) AS CUOTA FROM [_PRESTDIARIO] where CORCREDITO IN (select PRESTAMO from _RIESGO_DEUDAS_CREDITOS where perfil='" + Trim(frmPerfil.CbmUsuario.SelectedItem.ToString) + "' and Estado<>'Normal' ) GROUP BY NROSOCIO", conexiones14._conexion)
                Dim command14 As SqlCommand = New SqlCommand("SELECT MAX([PLAZO]) AS PLAZO ,SUM([PRIMERDIVIDENDO]) AS CUOTA,(SELECT (sum([ABONO])*100)/sum([CARGO]) FROM [_PRESTAMOS2] where opercred in (select PRESTAMO from _RIESGO_DEUDAS_CREDITOS where perfil='" + Trim(frmPerfil.CbmUsuario.SelectedItem.ToString) + "' and Estado<>'Normal' )  group by nrosocio) as AVANCE  FROM [_PRESTDIARIO] where CORCREDITO IN (select PRESTAMO from _RIESGO_DEUDAS_CREDITOS where perfil='" + Trim(frmPerfil.CbmUsuario.SelectedItem.ToString) + "' and Estado<>'Normal' ) GROUP BY NROSOCIO", conexiones14._conexion)
                conexiones14.abrir()
                Dim reader14 As SqlDataReader = command14.ExecuteReader()

                If reader14.HasRows Then
                    Do While reader14.Read()
                        Plazo = (reader14(0).ToString)
                        cuota = (reader14(1).ToString)
                        avance = (reader14(2).ToString)
                    Loop
                Else
                End If

                Dim valorplazo As Decimal = Math.Round(((((Integer.Parse(Replace(CboCuotas.SelectedItem.ToString, ".", "")) * 100)) / Plazo) - 100), 1)
                'PLAZO
                If valorplazo > 0 Then
                    POLITICAS = POLITICAS + "Respecto al plazo mayor de sus creditos a prepagar (" + Plazo.ToString + "), la diferencia es un " + valorplazo.ToString + "% más alto." + Environment.NewLine + Environment.NewLine
                ElseIf valorplazo = 0 Then
                    POLITICAS = POLITICAS + "Respecto al plazo mayor de sus creditos a prepagar (" + Plazo.ToString + "), la diferencia es igual." + Environment.NewLine + Environment.NewLine
                Else
                    POLITICAS = POLITICAS + "Respecto al plazo mayor de sus creditos a prepagar (" + Plazo.ToString + "), la diferencia es un " + valorplazo.ToString + "% más bajo." + Environment.NewLine + Environment.NewLine
                End If


                Dim valorcuotas As Decimal = Math.Round(((((Integer.Parse(Replace(TxtCuota.Text.ToString.Trim, ".", "")) * 100)) / cuota) - 100), 1)
                'CUOTAS
                If valorcuotas > 0 Then
                    POLITICAS = POLITICAS + "Respecto a la sumatoria cuotas de sus créditos a prepagar (" + Puntos(cuota.ToString) + "), la diferencia es un " + valorcuotas.ToString + "% más alto." + Environment.NewLine + Environment.NewLine
                ElseIf valorcuotas = 0 Then
                    POLITICAS = POLITICAS + "Respecto a la sumatoria cuotas de sus créditos a prepagar (" + Puntos(cuota.ToString) + "), la diferencia es igual." + Environment.NewLine + Environment.NewLine
                Else
                    POLITICAS = POLITICAS + "Respecto a la sumatoria cuotas de sus créditos a prepagar (" + Puntos(cuota.ToString) + "), la diferencia es un " + valorcuotas.ToString + "% más bajo." + Environment.NewLine + Environment.NewLine
                End If


                'AVANCE
                If avance < 30 Then
                    POLITICAS = POLITICAS + "Respecto al avance de sus creditos a prepagar representa un " + avance.ToString + "% siendo MALO para este proposito." + Environment.NewLine + Environment.NewLine
                Else
                    POLITICAS = POLITICAS + "Respecto al avance de sus creditos a prepagar representa un " + avance.ToString + "% siendo BUENO para este proposito." + Environment.NewLine + Environment.NewLine
                End If


            Else
                POLITICAS = "No aplicable para forma de pago por planilla en caso de no ser Refinanciamiento"
            End If


        Else

            ' PAGO DIRECTO--------------------------------------------------------------------------------------------------------------


            'PAGO DIRECTO---------------SIN CLASIFICACIONES
            If txtClasificacionBaja.Text.Trim = "NUNCA HA SIDO CLASIFICADO" Then

                ' PAGO DIRECTO---------SIN CLASIFICACIONES -------RECHAZO PUNTAJE PERO LVL BUENO Y CAPACIDAD BUENA SE VERIFICA SI PUEDE EXCEPCIONAR
                If Double.Parse(txtpuntaje4.Text) > -30 And txtScoringLvl.Text.Trim = "BUENO" And txtScoringCapacidad.Text.Trim = "BUENO" Then

                    POLITICAS = "Socio sin clasificaciones, Rechazado por:" + Environment.NewLine + Environment.NewLine


                    If Integer.Parse(txtEdad.Text) <= 30 Then

                        'EDAD
                        POLITICAS = POLITICAS + "Condiciones de edad menor a 30 años:" + Environment.NewLine + Environment.NewLine

                        'CONDICION 1 CASADO
                        If txtScoringEstadoCivil.Text.Trim = "MALO" Then
                            POLITICAS = POLITICAS + "1:Estado Civil MALO" + Environment.NewLine
                        Else
                            POLITICAS = POLITICAS + "1:Estado Civil BUENO" + Environment.NewLine
                            CONTADOR = CONTADOR + 1
                        End If

                        'CONDICION 2 PROPIEDAD
                        If txtScoringPropiedad.Text.Trim = "MALO" Then
                            POLITICAS = POLITICAS + "2:Propiedad MALO" + Environment.NewLine
                        Else
                            POLITICAS = POLITICAS + "2:Propiedad BUENO" + Environment.NewLine
                            CONTADOR = CONTADOR + 1
                        End If

                        'CONDICION 3 RENTA
                        If txtScoringRenta.Text.Trim = "MALO" Then
                            POLITICAS = POLITICAS + "3:Renta MALO" + Environment.NewLine
                        Else
                            POLITICAS = POLITICAS + "3:Renta BUENO" + Environment.NewLine
                            CONTADOR = CONTADOR + 1
                        End If

                        'CONDICION 4 ANTIGUEDAD LABORAL
                        If txtScoringAntiguedadLab.Text.Trim = "MALO" Then
                            POLITICAS = POLITICAS + "4:Antiguedad Lab MALO" + Environment.NewLine
                        Else
                            POLITICAS = POLITICAS + "4:Antiguedad Lab BUENO" + Environment.NewLine
                            CONTADOR = CONTADOR + 1
                        End If

                        'CONDICION 5 ANTECEDENTES
                        If txtScoringAntecedentes.Text.Trim = "MALO" Then
                            POLITICAS = POLITICAS + "5:Antecedentes MALO" + Environment.NewLine

                        Else
                            POLITICAS = POLITICAS + "5:Antecedentes BUENO" + Environment.NewLine
                            CONTADOR = CONTADOR + 1
                        End If

                        If CONTADOR >= 3 Then
                            POLITICAS = POLITICAS + "Tiene condiciones favorables para aplicar excepción, cantidad: " + CONTADOR.ToString + "/5"
                        Else
                            POLITICAS = POLITICAS + Environment.NewLine + "No se excepciona al tener " + CONTADOR.ToString + "/5 condiciones favorables"
                        End If



                    ElseIf Integer.Parse(txtEdad.Text) > 30 And Integer.Parse(txtEdad.Text) <= 40 Then


                        'EDAD
                        POLITICAS = POLITICAS + "Condiciones de edad entre A 31 y 40 años: " + Environment.NewLine + Environment.NewLine

                        'CONDICION 1 PROPIEDAD
                        If txtScoringPropiedad.Text.Trim = "MALO" Then
                            POLITICAS = POLITICAS + "1:Propidad MALO" + Environment.NewLine
                        Else
                            POLITICAS = POLITICAS + " 1:Propidad BUENO" + Environment.NewLine
                            CONTADOR = CONTADOR + 1
                        End If

                        'CONDICION 2 RENTA
                        If txtScoringRenta.Text.Trim = "MALO" Then
                            POLITICAS = POLITICAS + " 2:Renta MALO" + Environment.NewLine
                        Else
                            POLITICAS = POLITICAS + " 2:Renta BUENO" + Environment.NewLine
                            CONTADOR = CONTADOR + 1
                        End If

                        'CONDICION 3 ANTIGUEDAD LABORAL
                        If txtScoringAntiguedadLab2.Text.Trim = "MALO" Then
                            POLITICAS = POLITICAS + " 3:Antiguedad Lab MALO" + Environment.NewLine
                        Else
                            POLITICAS = POLITICAS + " 3:Antiguedad Lab  BUENO" + Environment.NewLine
                            CONTADOR = CONTADOR + 1
                        End If

                        'CONDICION 4 ANTECEDENTES
                        If txtScoringAntecedentes.Text.Trim = "MALO" Then
                            POLITICAS = POLITICAS + " 4:Antecedentes MALO" + Environment.NewLine
                        Else
                            POLITICAS = POLITICAS + " 4:Antecedentes BUENO" + Environment.NewLine
                            CONTADOR = CONTADOR + 1
                        End If

                        If CONTADOR >= 2 Then
                            POLITICAS = POLITICAS + "Tiene condiciones favorables para aplicar excepción, cantidad: " + CONTADOR.ToString + "/4"
                        Else
                            POLITICAS = POLITICAS + Environment.NewLine + "No se excepciona al tener " + CONTADOR.ToString + "/4 condiciones favorables"
                        End If

                    Else
                        'EDAD
                        POLITICAS = POLITICAS + "Condiciones de edad mayor a 40 Años: " + Environment.NewLine + Environment.NewLine

                        'CONDICION 3 ANTIGUEDAD LABORAL
                        If txtScoringAntiguedadLab2.Text.Trim = "MALO" Then
                            POLITICAS = POLITICAS + " 1:Antiguedad Lab MALO" + Environment.NewLine
                        Else
                            POLITICAS = POLITICAS + " 1:Antiguedad Lab BUENO" + Environment.NewLine
                            CONTADOR = CONTADOR + 1
                        End If

                        'CONDICION 4 ANTECEDENTES
                        If txtScoringAntecedentes.Text.Trim = "MALO" Then
                            POLITICAS = POLITICAS + " 2:Antecedentes MALO" + Environment.NewLine
                        Else
                            POLITICAS = POLITICAS + " 2:Antecedentes BUENO" + Environment.NewLine
                            CONTADOR = CONTADOR + 1
                        End If

                        If CONTADOR >= 2 Then
                            POLITICAS = POLITICAS + "Tiene condiciones favorables para aplicar excepción, cantidad: " + CONTADOR.ToString + "/2"
                        Else
                            POLITICAS = POLITICAS + Environment.NewLine + "No se excepciona al tener " + CONTADOR.ToString + "/2 condiciones favorables"
                        End If


                    End If

                Else



                    ' PAGO DIRECTO---------SIN CLASIFICACIONES -------RECHAZO PUNTAJE PERO LVL BUENO Y CAPACIDAD BUENA SE VERIFICA SI PUEDE EXCEPCIONAR
                    POLITICAS = "Socio sin clasificaciones, Rechazado por:" + Environment.NewLine + Environment.NewLine

                    If Double.Parse(txtpuntaje4.Text) > -30 Then
                        POLITICAS = POLITICAS + "-Tiene un puntaje MALO de " + txtpuntaje4.Text.Trim + Environment.NewLine
                    Else
                        POLITICAS = POLITICAS + "-Tiene puntaje BUENO de " + txtpuntaje4.Text.Trim + Environment.NewLine
                    End If


                    POLITICAS = POLITICAS + "-Tiene Leverage " + txtScoringLvl.Text.Trim + " de " + LlEVEL.Text.Trim + Environment.NewLine

                    POLITICAS = POLITICAS + "-Tiene capacidad de pago " + txtScoringCapacidad.Text.Trim + " de " + LPorciento.Text.Trim + Environment.NewLine


                    POLITICAS = POLITICAS + Environment.NewLine + "Por cosiguiente no cumple con las politicas 6.1 de excepciones"



                    ' PAGO DIRECTO---------SIN CLASIFICACIONES -------RECHAZO DIRECTO


                End If

            Else


                'PAGO DIRECTO---------------CON CLASIFICACIONES

                'PAGO DIRECTO---------------CON CLASIFICACIONES---------- RECHAZO
                If Double.Parse(txtpuntaje4.Text) > -30 Or txtScoringLvl.Text.Trim = "MALO" Or txtScoringCapacidad.Text.Trim = "MALO" Or txtScoringAntecedentes.Text.Trim = "MALO" Then

                    POLITICAS = "Socio con clasificaciones, Rechazado por:" + Environment.NewLine + Environment.NewLine

                    If Double.Parse(txtpuntaje4.Text) > -30 Then

                        POLITICAS = POLITICAS + "- Puntaje MALO." + Environment.NewLine
                    Else
                        POLITICAS = POLITICAS + "- Puntaje BUENO." + Environment.NewLine
                    End If

                    If txtScoringLvl.Text.Trim = "MALO" Then

                        POLITICAS = POLITICAS + "- Leverage MALO." + Environment.NewLine
                    Else
                        POLITICAS = POLITICAS + "- Leverage BUENO." + Environment.NewLine
                    End If

                    If txtScoringCapacidad.Text.Trim = "MALO" Then

                        POLITICAS = POLITICAS + "- Capacidad de pago MALO." + Environment.NewLine
                    Else
                        POLITICAS = POLITICAS + "- Capacidad de pago BUENO." + Environment.NewLine
                    End If

                    If txtScoringAntecedentes.Text.Trim = "MALO" Then
                        POLITICAS = POLITICAS + "- Morosidades MALO." + Environment.NewLine
                    Else
                        POLITICAS = POLITICAS + "- Morosidades BUENO." + Environment.NewLine
                    End If

                    POLITICAS = POLITICAS + Environment.NewLine + "Condiciones excepciones:" + Environment.NewLine + Environment.NewLine

                    'CONDICION 1 COMPORTAMIENTO
                    If txtScoringComportamiento.Text = "BUENO" Then
                        POLITICAS = POLITICAS + "1: Comportamiento BUENO." + Environment.NewLine + Environment.NewLine

                    Else
                        POLITICAS = POLITICAS + "1: Comportamiento MALO." + Environment.NewLine + Environment.NewLine
                        CONTADOR = CONTADOR + 1

                    End If





                    'CONDICION 2 REFINANCIA CUATO Y PLAZO SIMILAR ULTIMA OPERACIÓN
                    If CboObjetivo.SelectedItem.ToString.Trim = "Refinanciamiento" Then



                        Dim avance As Integer = 0
                        Dim Plazo As Integer = 0
                        Dim cuota As Integer = 0


                        Dim conexiones14 As New CConexion
                        conexiones14.conexion()
                        Dim command14 As SqlCommand = New SqlCommand("SELECT MAX([PLAZO]) AS PLAZO ,SUM([PRIMERDIVIDENDO]) AS CUOTA,(SELECT (sum([ABONO])*100)/sum([CARGO]) FROM [_PRESTAMOS2] where opercred in (select PRESTAMO from _RIESGO_DEUDAS_CREDITOS where perfil='" + Trim(frmPerfil.CbmUsuario.SelectedItem.ToString) + "' and Estado<>'Normal' )  group by nrosocio) as AVANCE  FROM [_PRESTDIARIO] where CORCREDITO IN (select PRESTAMO from _RIESGO_DEUDAS_CREDITOS where perfil='" + Trim(frmPerfil.CbmUsuario.SelectedItem.ToString) + "' and Estado<>'Normal' ) GROUP BY NROSOCIO", conexiones14._conexion)
                        conexiones14.abrir()
                        Dim reader14 As SqlDataReader = command14.ExecuteReader()

                        If reader14.HasRows Then
                            Do While reader14.Read()
                                Plazo = (reader14(0).ToString)
                                cuota = (reader14(1).ToString)
                                avance = (reader14(2).ToString)
                            Loop
                        Else
                        End If


                        'If Math.Round(((Double.Parse(CboCuotas.SelectedItem.ToString) * 100) / Plazo) - 100, 0) > 0 Then

                        '    POLITICAS = POLITICAS + "2: Respecto al plazo mayor de sus creditos a prepagar (" + Plazo.ToString + "), la diferencia es un " + Math.Round((((Integer.Parse(CboCuotas.SelectedItem.ToString) * 100) / Plazo) - 100), 0).ToString + "% más alto." + Environment.NewLine + Environment.NewLine
                        '    CONTADOR = CONTADOR + 1

                        'ElseIf Math.Round(((Double.Parse(CboCuotas.SelectedItem.ToString) * 100) / Plazo) - 100, 0) = 0 Then

                        '    POLITICAS = POLITICAS + "2: Respecto al plazo mayor de sus creditos a prepagar (" + Plazo.ToString + "), la diferencia es igual." + Environment.NewLine + Environment.NewLine

                        'Else

                        '    POLITICAS = POLITICAS + "2: Respecto al plazo mayor de sus creditos a prepagar (" + Plazo.ToString + "), la diferencia es un " + (Math.Round((((Integer.Parse(CboCuotas.SelectedItem.ToString) * 100) / Plazo) - 100), 0) * -1).ToString + "% más bajo." + Environment.NewLine + Environment.NewLine

                        'End If
                        'MsgBox(cuota)
                        'MsgBox(TxtCuota.Text.ToString.Trim)
                        'MsgBox(Math.Round(((Double.Parse(TxtCuota.Text.ToString.Trim) * 100) / cuota) - 100, 0))

                        'If Math.Round(((Double.Parse(TxtCuota.Text.ToString.Trim) * 100) / cuota) - 100, 0) > 5 Then

                        Dim valor As Decimal = Math.Round(((((Integer.Parse(Replace(TxtCuota.Text.ToString.Trim, ".", "")) * 100)) / cuota) - 100), 1)

                        If valor > 5 Then
                            POLITICAS = POLITICAS + "2: Respecto a la sumatoria cuotas de sus créditos a prepagar (" + Puntos(cuota.ToString) + "), la diferencia es un " + valor.ToString + "% más alto es MALO" + Environment.NewLine + Environment.NewLine
                            CONTADOR = CONTADOR + 1
                        ElseIf valor <= 5 And valor > 0 Then
                            POLITICAS = POLITICAS + "2: Respecto a la sumatoria cuotas de sus créditos a prepagar (" + Puntos(cuota.ToString) + "), la diferencia es un " + valor.ToString + "% más alto pero es BUENO" + Environment.NewLine + Environment.NewLine
                        ElseIf valor = 0 Then
                            POLITICAS = POLITICAS + "2: Respecto a la sumatoria cuotas de sus créditos a prepagar (" + Puntos(cuota.ToString) + "), la diferencia es igual es BUENO" + Environment.NewLine + Environment.NewLine
                        Else
                            POLITICAS = POLITICAS + "2: Respecto a la sumatoria cuotas de sus créditos a prepagar (" + Puntos(cuota.ToString) + "), la diferencia es un " + valor.ToString + "% más bajo es BUENO" + Environment.NewLine + Environment.NewLine
                        End If
                        If avance < 30 Then

                            POLITICAS = POLITICAS + "2: Respecto al avance de sus creditos a prepagar representa un " + avance.ToString + "% siendo MALO para este proposito." + Environment.NewLine + Environment.NewLine

                            If Double.Parse(txtpuntaje4.Text) > -30 Or txtScoringLvl.Text.Trim = "MALO" Or txtScoringCapacidad.Text.Trim = "MALO" Or txtScoringMorosidades.Text = "SI" Then


                            End If



                        Else

                            POLITICAS = POLITICAS + "2: Respecto al avance de sus creditos a prepagar representa un " + avance.ToString + "% siendo un BUENO para este proposito." + Environment.NewLine + Environment.NewLine
                        End If

                    Else

                        POLITICAS = POLITICAS + "2: Refinanciamiento, No aplica objetivo es otro (" + CboObjetivo.SelectedItem.ToString.Trim + ")." + Environment.NewLine + Environment.NewLine

                    End If


                    'CONDICION 3 NO MANTIENE OPERACIONES VIGENTES







                    ''CONDICION 4 DEUDA COMERCIAL Y SBIF SIN DETERIORO 


                    If txtScoringMorosidades500000.Text.Trim = "MALO" Then
                        If ChkAval1.Checked = True And ChkAval2.Checked = False Then
                            POLITICAS = POLITICAS + "3: Info.Comercial, Antecedentes Negativos pero con 1 aval." + Environment.NewLine

                        ElseIf ChkAval1.Checked = True And ChkAval2.Checked = True Then
                            POLITICAS = POLITICAS + "3: Info.Comercial, Antecedentes Negativos pero con 2 avales." + Environment.NewLine

                        Else
                            POLITICAS = POLITICAS + "3: Info.Comercial, Antecedentes Negativos." + Environment.NewLine
                            CONTADOR = CONTADOR + 1
                        End If

                    Else
                        POLITICAS = POLITICAS + "3: Info.Comercial, Antecedentes Positivos." + Environment.NewLine
                    End If

                    If CONTADOR = 1 Then
                        POLITICAS = POLITICAS + Environment.NewLine + "No se excepciona al tener" + CONTADOR.ToString + " condición Negativa."

                    ElseIf CONTADOR > 1 Then

                        POLITICAS = POLITICAS + Environment.NewLine + "No se excepciona al tener " + CONTADOR.ToString + " condiciones Negativas."

                    Else
                        POLITICAS = POLITICAS + Environment.NewLine + "Tiene condiciones favorables para aplicar excepción."
                    End If



                    'MsgBox(CONTADOR.ToString)
                    'SIZEWord("Rechazado", "titulo")
                    ''SIZEWord("Factor ", "titulo")

                    'SIZEWord("Forma de pago:", "subtitulo")



                    'If txtScoringRenta.Text.Trim = "MALO" Then
                    '    POLITICAS = POLITICAS + "3:Renta -" + Environment.NewLine
                    'Else
                    '    POLITICAS = POLITICAS + "3:Renta +" + Environment.NewLine
                    '    CONTADOR = CONTADOR + 1
                    'End If



                    ''CONDICION 4 AVAL MAYOR DETERIORO
                    'If txtScoringAntiguedadLab.Text.Trim = "MALO" Then
                    '    POLITICAS = POLITICAS + "4:Antiguedad Lab -" + Environment.NewLine
                    'Else
                    '    POLITICAS = POLITICAS + "4:Antiguedad Lab +" + Environment.NewLine
                    '    CONTADOR = CONTADOR + 1
                    'End If







                    'POLITICAS = "No disponible para Socios con clasificaciones"



                End If




            End If






        End If



        If POLITICAS.Trim = "" Then

            If CboObjetivo.SelectedItem.ToString.Trim = "Refinanciamiento" Then


                Dim avance As Integer = 0
                Dim Plazo As Integer = 0
                Dim cuota As Integer = 0


                Dim conexiones14 As New CConexion
                conexiones14.conexion()
                Dim command14 As SqlCommand = New SqlCommand("SELECT MAX([PLAZO]) AS PLAZO ,SUM([PRIMERDIVIDENDO]) AS CUOTA,(SELECT (sum([ABONO])*100)/sum([CARGO]) FROM [_PRESTAMOS2] where opercred in (select PRESTAMO from _RIESGO_DEUDAS_CREDITOS where perfil='" + Trim(frmPerfil.CbmUsuario.SelectedItem.ToString) + "' and Estado<>'Normal' )  group by nrosocio) as AVANCE  FROM [_PRESTDIARIO] where CORCREDITO IN (select PRESTAMO from _RIESGO_DEUDAS_CREDITOS where perfil='" + Trim(frmPerfil.CbmUsuario.SelectedItem.ToString) + "' and Estado<>'Normal' ) GROUP BY NROSOCIO", conexiones14._conexion)
                conexiones14.abrir()
                Dim reader14 As SqlDataReader = command14.ExecuteReader()

                If reader14.HasRows Then
                    Do While reader14.Read()
                        Plazo = (reader14(0).ToString)
                        cuota = (reader14(1).ToString)
                        avance = (reader14(2).ToString)
                    Loop
                Else
                End If



                If avance < 30 Then

                    POLITICAS = POLITICAS + "1: Respecto al avance de sus creditos a prepagar representa un " + avance.ToString + "% siendo MALO para este proposito." + Environment.NewLine + Environment.NewLine
                Else

                    POLITICAS = POLITICAS + "1: Respecto al avance de sus creditos a prepagar representa un " + avance.ToString + "% siendo BUENO para este proposito." + Environment.NewLine + Environment.NewLine
                End If






                Dim valorplazo2 As Decimal = Math.Round(((((Integer.Parse(Replace(CboCuotas.SelectedItem.ToString, ".", "")) * 100)) / Plazo) - 100), 1)

                If valorplazo2 > 0 Then

                    POLITICAS = POLITICAS + "1: Respecto al plazo mayor de sus creditos a prepagar (" + Plazo.ToString + "), la diferencia es un " + valorplazo2.ToString + "% más alto." + Environment.NewLine + Environment.NewLine

                ElseIf valorplazo2 = 0 Then

                    POLITICAS = POLITICAS + "1: Respecto al plazo mayor de sus creditos a prepagar (" + Plazo.ToString + "), la diferencia es igual." + Environment.NewLine + Environment.NewLine

                Else

                    POLITICAS = POLITICAS + "1: Respecto al plazo mayor de sus creditos a prepagar (" + Plazo.ToString + "), la diferencia es un " + valorplazo2.ToString + "% más bajo." + Environment.NewLine + Environment.NewLine

                End If


                Dim valorcuota2 As Decimal = Math.Round(((((Integer.Parse(Replace(TxtCuota.Text.ToString.Trim, ".", "")) * 100)) / cuota) - 100), 1)


                If valorcuota2 > 0 Then

                    POLITICAS = POLITICAS + "1: Respecto a la sumatoria cuotas de sus créditos a prepagar (" + Puntos(cuota.ToString) + "), la diferencia es un " + valorcuota2.ToString + "% más alto." + Environment.NewLine + Environment.NewLine


                ElseIf valorcuota2 = 0 Then

                    POLITICAS = POLITICAS + "1: Respecto a la sumatoria cuotas de sus créditos a prepagar (" + Puntos(cuota.ToString) + "), la diferencia es igual." + Environment.NewLine + Environment.NewLine

                Else

                    POLITICAS = POLITICAS + "1: Respecto a la sumatoria cuotas de sus créditos a prepagar (" + Puntos(cuota.ToString) + "), la diferencia es un " + valorcuota2.ToString + "% más bajo." + Environment.NewLine + Environment.NewLine
                End If



            Else
                'POLITICAS = "Aceptado, por tener todas sus condiciones favorables de acuerdo a las politicas"
                POLITICAS = ""
            End If

        End If






        'For i As Integer = 0 To Words.Count - 1
        '    colorWord(Words.Item(i))
        'Next
        'Words.Add("Rechazado")

        'For i As Integer = 0 To Words.Count - 1
        '    'MsgBox(Words.Item(i))
        '    colorWord(Words.Item(i))
        'Next

        'TXTeXCEPCION2.SelectedText = "Rechazado" + ControlChars.Cr
        ''    ' Apply same font since font settings do not carry to next line.
        ''    richTextBox2.SelectionFont = New Font("Arial", 12)
        'TXTeXCEPCION2.SelectionColor = Color.Orange

        WriteTextToRichTextBox()

        If CboFormaDePago.SelectedItem.ToString.Trim = "PLANILLA" Then

            If Double.Parse(txtpuntaje4.Text) <= -50 And txtScoringLvl.Text.Trim = "BUENO" And txtAntecedentes.Text.Trim = "NO" And txtScoringCapacidad.Text.Trim = "BUENO" Then
                'LTEXTO.Text = "Resolución: Socio sujeto de crédito a tasas normales."
                txtpuntaje4.BackColor = Color.Green
                txtScoringLvl.BackColor = Color.Green
                txtAntecedentes.BackColor = Color.Green
                txtScoringCapacidad.BackColor = Color.Green
                txtTasaFinalSI.BackColor = Color.White
                TXTTasaFinalCI.BackColor = Color.White
                txtTasaReal.BackColor = Color.Green
                txtTasaCastigadaAumenta.Text = 0
                'txtTasaCastigadaAumenta.BackColor = Color.Green
                txtTasaSolicitada.BackColor = Color.Green
                txtTasaCastigadaAumenta.BackColor = Color.Green


                txtTasaFinal.Text = txtTasaSolicitada.Text
                txtTasaSolicitada.BackColor = Color.Green
                'txtDescuento.Text = "No aplica"
                txtestado2.Text = "ACEPTADO,PERO SE ENVIA A RIESGO"
                'txtestado2.Text = "ACEPTADO, SE ENVIA PARA EVALUACIÓN DIRECTA"
                lInfoTasa.Text = "* Planilla se aplica tasa solicitada sin castigo Scoring"

                If POLITICAS.Trim = "" Then
                    POLITICAS = "Aceptado, por tener todas sus condiciones favorables de acuerdo a las politicas"
                End If

            ElseIf Double.Parse(txtpuntaje4.Text) > -50 And Double.Parse(txtpuntaje4.Text) < 50 And txtScoringLvl.Text = "BUENO" And txtAntecedentes.Text = "NO" And txtScoringCapacidad.Text = "BUENO" Then
                'LTEXTO.Text = "Resolución: Socio sujeto de crédito, pero se incorpora pérdida esperada a la tasa aplicada al crédito, hasta el límite de la tasa máxima convencional."
                txtTasaReal.BackColor = Color.White
                txtTasaSolicitada.BackColor = Color.Green
                'txtTasaConvenio.BackColor = Color.White
                txtTasaCastigada.BackColor = Color.White
                txtTasaCastigadaAumenta.BackColor = Color.Red
                txtpuntaje4.BackColor = Color.Yellow
                txtScoringLvl.BackColor = Color.Green
                txtAntecedentes.BackColor = Color.Green
                txtScoringCapacidad.BackColor = Color.Green
                'txtTasaFinal.Text = txtTasaCastigada.Text




                txtTasaFinal.Text = txtTasaSolicitada.Text
                'txtDescuento.Text = "No aplica"
                txtestado2.Text = "ACEPTADO,PERO SE ENVIA A RIESGO"
                'txtestado2.Text = "ACEPTADO,PERO SE ENVIA PARA EVALUACIÓN"
                lInfoTasa.Text = "* Planilla se aplica tasa solicitada sin castigo Scoring"
            ElseIf Double.Parse(txtpuntaje4.Text) > 50 And txtScoringLvl.Text = "BUENO" And txtAntecedentes.Text = "NO" And txtScoringCapacidad.Text = "BUENO" Then
                'LTEXTO.Text = "Resolución: Se enviará solicitud de crédito y al área de riesgo para su evaluación,  se incorpora pérdida esperada a la tasa aplicada al crédito, hasta el límite de la tasa máxima convencional."

                txtTasaCastigadaAumenta.BackColor = Color.Red
                txtTasaReal.BackColor = Color.White
                txtTasaSolicitada.BackColor = Color.Green
                'txtTasaConvenio.BackColor = Color.White
                txtTasaCastigada.BackColor = Color.White
                txtpuntaje4.BackColor = Color.Red
                txtScoringLvl.BackColor = Color.Green
                txtAntecedentes.BackColor = Color.Green
                txtScoringCapacidad.BackColor = Color.Green
                'txtTasaFinal.Text = txtTasaCastigada.Text


                txtTasaFinal.Text = txtTasaSolicitada.Text
                txtestado2.Text = "ACEPTADO,PERO SE ENVIA A RIESGO"
                'txtDescuento.Text = "No aplica"
                lInfoTasa.Text = "* Planilla se aplica tasa solicitada sin castigo Scoring"
            Else
                'LTEXTO.Text = "Resolución: Se incorpora pérdida esperada a la tasa aplicada al crédito"

                If txtScoringLvl.Text <> "BUENO" Then
                    txtScoringLvl.BackColor = Color.Red
                End If

                If txtAntecedentes.Text <> "NO" Then
                    txtAntecedentes.BackColor = Color.Red
                End If

                If txtScoringCapacidad.Text <> "BUENO" Then
                    txtScoringCapacidad.BackColor = Color.Red
                End If


                If Double.Parse(txtpuntaje4.Text) <= -30 Then
                    txtpuntaje4.BackColor = Color.Green
                ElseIf Double.Parse(txtpuntaje4.Text) > -30 And Double.Parse(txtpuntaje4.Text) < 30 Then
                    txtpuntaje4.BackColor = Color.Yellow
                Else
                    txtpuntaje4.BackColor = Color.Red
                End If
                txtTasaCastigadaAumenta.BackColor = Color.Red
                txtTasaReal.BackColor = Color.White
                txtTasaSolicitada.BackColor = Color.Green
                'txtTasaConvenio.BackColor = Color.White
                txtTasaCastigada.BackColor = Color.White


                txtTasaFinal.Text = txtTasaSolicitada.Text
                'txtDescuento.Text = "No aplica"
                txtestado2.Text = "RECHAZADO, SE ENVIA A RIESGO "
                lInfoTasa.Text = "* Planilla se aplica tasa solicitada sin castigo Scoring"
                'txtestado2.ForeColor = Color.Red
            End If

        Else


            If Double.Parse(txtpuntaje4.Text) <= -30 And txtScoringLvl.Text.Trim = "BUENO" And txtAntecedentes.Text.Trim = "NO" And txtScoringCapacidad.Text.Trim = "BUENO" Then
                'LTEXTO.Text = "Resolución: Socio sujeto de crédito a tasas normales."


                txtpuntaje4.BackColor = Color.Green
                txtScoringLvl.BackColor = Color.Green
                txtAntecedentes.BackColor = Color.Green
                txtScoringCapacidad.BackColor = Color.Green
                txtTasaFinalSI.BackColor = Color.White
                TXTTasaFinalCI.BackColor = Color.White
                txtTasaReal.BackColor = Color.Green
                txtTasaCastigadaAumenta.Text = 0
                txtTasaCastigadaAumenta.BackColor = Color.Green

                txtTasaSolicitada.BackColor = Color.White
                If txtTasaSolicitada.Text <> 0 Then
                    txtTasaSolicitada.BackColor = Color.Green
                Else
                    txtTasaReal.BackColor = Color.Green
                End If
                txtTasaFinal.Text = txtTasaReal.Text
                'txtTasaFinal.Text = txtTasaActual.Text
                txtestado2.Text = "ACEPTADO, SE ENVIA PARA EVALUACIÓN"

                If txtDescuento.Text = "Aplica" Then
                    lInfoTasa.Text = "No se aplica Castigo Scoring y se realiza descuento de un 15%"
                Else
                    lInfoTasa.Text = "No se aplica Castigo Scoring pero NO realiza descuento promocional"
                End If


                If POLITICAS.Trim = "" Then
                    POLITICAS = "Aceptado, por tener todas sus condiciones favorables de acuerdo a las politicas"
                End If


            ElseIf Double.Parse(txtpuntaje4.Text) > -30 And Double.Parse(txtpuntaje4.Text) < 30 And txtScoringLvl.Text = "BUENO" And txtAntecedentes.Text = "NO" And txtScoringCapacidad.Text = "BUENO" Then
                'LTEXTO.Text = "Resolución: Socio sujeto de crédito, pero se incorpora pérdida esperada a la tasa aplicada al crédito, hasta el límite de la tasa máxima convencional."

                txtTasaReal.BackColor = Color.White
                txtTasaSolicitada.BackColor = Color.White
                If txtTasaSolicitada.Text <> 0 Then
                    txtTasaSolicitada.BackColor = Color.Yellow
                Else
                    txtTasaReal.BackColor = Color.Yellow
                End If

                txtTasaCastigada.BackColor = Color.Green

                txtTasaCastigadaAumenta.BackColor = Color.Red
                txtpuntaje4.BackColor = Color.Yellow
                txtScoringLvl.BackColor = Color.Green
                txtAntecedentes.BackColor = Color.Green
                txtScoringCapacidad.BackColor = Color.Green
                txtTasaFinal.Text = txtTasaCastigada.Text
                txtestado2.Text = "ACEPTADO, SE ENVIA PARA EVALUACIÓN PERO CON TASA CASTIGADA"

                If txtDescuento.Text = "Aplica" Then
                    lInfoTasa.Text = "Se aplica Castigo Scoring pero se realiza descuento de un 15%"
                Else
                    lInfoTasa.Text = "Se aplica Castigo Scoring y NO realiza descuento promocional"
                End If
            ElseIf Double.Parse(txtpuntaje4.Text) > 30 And txtScoringLvl.Text = "BUENO" And txtAntecedentes.Text = "NO" And txtScoringCapacidad.Text = "BUENO" Then
                'LTEXTO.Text = "Resolución: Se enviará solicitud de crédito y al área de riesgo para su evaluación,  se incorpora pérdida esperada a la tasa aplicada al crédito, hasta el límite de la tasa máxima convencional."

                txtTasaCastigadaAumenta.BackColor = Color.Red
                txtTasaReal.BackColor = Color.White
                txtTasaSolicitada.BackColor = Color.White
                'txtTasaConvenio.BackColor = Color.White
                If txtTasaSolicitada.Text <> 0 Then
                    txtTasaSolicitada.BackColor = Color.Yellow
                Else
                    txtTasaReal.BackColor = Color.Yellow
                End If
                txtTasaCastigada.BackColor = Color.Green
                txtpuntaje4.BackColor = Color.Red
                txtScoringLvl.BackColor = Color.Green
                txtAntecedentes.BackColor = Color.Green
                txtScoringCapacidad.BackColor = Color.Green
                txtTasaFinal.Text = txtTasaCastigada.Text
                txtestado2.Text = "ACEPTADO, SE ENVIA A RIESGO Y EVALUACIÓN PERO CON TASA CASTIGADA "
                If txtDescuento.Text = "Aplica" Then
                    lInfoTasa.Text = "Se aplica Castigo Scoring pero se realiza descuento de un 15%"
                Else
                    lInfoTasa.Text = "Se aplica Castigo Scoring y NO realiza descuento promocional"
                End If
            Else
                'LTEXTO.Text = "Resolución: Se incorpora pérdida esperada a la tasa aplicada al crédito"

                If txtScoringLvl.Text <> "BUENO" Then
                    txtScoringLvl.BackColor = Color.Red
                End If

                If txtAntecedentes.Text <> "NO" Then
                    txtAntecedentes.BackColor = Color.Red
                End If

                If txtScoringCapacidad.Text <> "BUENO" Then
                    txtScoringCapacidad.BackColor = Color.Red
                End If



                If Double.Parse(txtpuntaje4.Text) <= -30 Then
                    txtpuntaje4.BackColor = Color.Green
                ElseIf Double.Parse(txtpuntaje4.Text) > -30 And Double.Parse(txtpuntaje4.Text) < 30 Then
                    txtpuntaje4.BackColor = Color.Yellow
                Else
                    txtpuntaje4.BackColor = Color.Red
                End If
                txtTasaCastigadaAumenta.BackColor = Color.Red
                txtTasaReal.BackColor = Color.White
                txtTasaSolicitada.BackColor = Color.White
                If txtTasaSolicitada.Text <> 0 Then
                    txtTasaSolicitada.BackColor = Color.Yellow
                Else
                    txtTasaReal.BackColor = Color.Yellow
                End If
                'txtTasaConvenio.BackColor = Color.White
                txtTasaCastigada.BackColor = Color.Green
                txtTasaFinal.Text = txtTasaCastigada.Text
                txtestado2.Text = "RECHAZADO, SE ENVIA A RIESGO Y EVALUACIÓN PERO CON TASA CASTIGADA"
                If txtDescuento.Text = "Aplica" Then
                    lInfoTasa.Text = "Se aplica Castigo Scoring pero se realiza descuento promocional"
                Else
                    lInfoTasa.Text = "Se aplica Castigo Scoring y NO realiza descuento promocional"
                End If
                'txtestado2.ForeColor = Color.Red
            End If


            If CboProducto.SelectedItem = "EMERGENCIA" Then
                MsgBox("Al ser el producto Emergencia su Tasa sera " + txtTasaReal.Text + "")
                txtTasaCastigada.BackColor = Color.White
                txtTasaSolicitada.BackColor = Color.White
                txtTasaReal.BackColor = Color.Green
                txtTasaFinal.Text = txtTasaReal.Text
            End If

            txtTasaCastigadaAumenta.Text = txtTasaCastigada.Text - txtTasaReal.Text
            Label64.Text = (((txtTasaCastigada.Text * 100) / txtTasaReal.Text) - 100)

        End If


        If CboProducto.SelectedItem = "CUOTON" Or CboProducto.SelectedItem = "RENEGOCIACION FLEXIBLE" Then
            txtTasaFinal.Text = txtTasaSolicitada.Text
            txtestado2.Text = "ACEPTADO,PERO SE ENVIA A RIESGO"
        End If



        TXTeXCEPCION2.Text = POLITICAS
    End Sub



    Private Sub WriteTextToRichTextBox()

        Dim i As Integer
        Dim cadena As String = TXTeXCEPCION2.Text
        For i = 0 To TXTeXCEPCION2.TextLength - 9
            'MsgBox(cadena.Substring(i, 9))
            If cadena.Substring(i, 9) = "Rechazado" Then
                TXTeXCEPCION2.Select(i, 9)
                TXTeXCEPCION2.SelectionColor = Color.Red
                i = i + 1
            End If
        Next
        For i = 0 To TXTeXCEPCION2.TextLength - 5
            If cadena.Substring(i, 5) = "BUENO" Then
                TXTeXCEPCION2.Select(i, 5)
                TXTeXCEPCION2.SelectionColor = Color.Green
                i = i + 1
            End If
        Next

        For i = 0 To TXTeXCEPCION2.TextLength - 4
            If cadena.Substring(i, 4) = "MALO" Then
                TXTeXCEPCION2.Select(i, 4)
                TXTeXCEPCION2.SelectionColor = Color.Red
                i = i + 1
            End If
        Next

        For i = 0 To TXTeXCEPCION2.TextLength - 9
            If cadena.Substring(i, 9) = "Negativos" Then
                TXTeXCEPCION2.Select(i, 9)
                TXTeXCEPCION2.SelectionColor = Color.Red
                i = i + 1
            End If
        Next


        For i = 0 To TXTeXCEPCION2.TextLength - 9
            If cadena.Substring(i, 9) = "No aplica" Then
                TXTeXCEPCION2.Select(i, 9)
                TXTeXCEPCION2.SelectionColor = Color.Blue
                i = i + 1
            End If
        Next

        For i = 0 To TXTeXCEPCION2.TextLength - 9
            If cadena.Substring(i, 9) = "No aplica" Then
                TXTeXCEPCION2.Select(i, 9)
                TXTeXCEPCION2.SelectionColor = Color.Blue
                i = i + 1
            End If
        Next

        For i = 0 To TXTeXCEPCION2.TextLength - 51
            If cadena.Substring(i, 51) = "Tiene condiciones favorables para aplicar excepción" Then
                TXTeXCEPCION2.Select(i, 51)
                TXTeXCEPCION2.SelectionColor = Color.Green
                TXTeXCEPCION2.SelectionFont = New Font("Arial", 11)
                i = i + 1
            End If
        Next

        For i = 0 To TXTeXCEPCION2.TextLength - 49
            If cadena.Substring(i, 49) = "No se excepciona al tener 2 condiciones Negativas" Or cadena.Substring(i, 49) = "No se excepciona al tener 3 condiciones Negativas" Or cadena.Substring(i, 49) = "No se excepciona al tener 4 condiciones Negativas" Then
                TXTeXCEPCION2.Select(i, 49)
                TXTeXCEPCION2.SelectionColor = Color.Red
                TXTeXCEPCION2.SelectionFont = New Font("Arial", 11)
                i = i + 1
            End If
        Next

        For i = 0 To TXTeXCEPCION2.TextLength - 46
            If cadena.Substring(i, 46) = "No se excepciona al tener 1 condición Negativa" Then
                TXTeXCEPCION2.Select(i, 46)
                TXTeXCEPCION2.SelectionColor = Color.Red
                TXTeXCEPCION2.SelectionFont = New Font("Arial", 11)
                i = i + 1
            End If
        Next

        For i = 0 To TXTeXCEPCION2.TextLength - 8
            If cadena.Substring(i, 8) = "más alto" Then
                TXTeXCEPCION2.Select(i, 8)
                TXTeXCEPCION2.SelectionColor = Color.Red
                i = i + 1
            End If
        Next

        For i = 0 To TXTeXCEPCION2.TextLength - 8
            If cadena.Substring(i, 8) = "más bajo" Then
                TXTeXCEPCION2.Select(i, 8)
                TXTeXCEPCION2.SelectionColor = Color.Green
                i = i + 1
            End If
        Next


        For i = 0 To TXTeXCEPCION2.TextLength - 5
            If cadena.Substring(i, 5) = "igual" Then
                TXTeXCEPCION2.Select(i, 5)
                TXTeXCEPCION2.SelectionColor = Color.Green
                i = i + 1
            End If
        Next

        For i = 0 To TXTeXCEPCION2.TextLength - 62
            If cadena.Substring(i, 62) = "Por cosiguiente no cumple con las politicas 6.1 de excepciones" Then
                TXTeXCEPCION2.Select(i, 62)
                TXTeXCEPCION2.SelectionColor = Color.Red
                TXTeXCEPCION2.SelectionFont = New Font("Arial", 11)
                i = i + 1
            End If
        Next

        For i = 0 To TXTeXCEPCION2.TextLength - 16
            If cadena.Substring(i, 16) = "No se excepciona" Then
                TXTeXCEPCION2.Select(i, 16)
                TXTeXCEPCION2.SelectionColor = Color.Red
                TXTeXCEPCION2.SelectionFont = New Font("Arial", 11)
                i = i + 1
            End If
        Next




    End Sub

    Sub colorWord(ByVal word As String) ' by im4dbr0
        For i As Integer = 0 To TXTeXCEPCION2.TextLength
            Try
                If TXTeXCEPCION2.Text.ElementAt(i).ToString = word.ElementAt(0).ToString Then
                    Dim found As Boolean = False
                    For j As Integer = 1 To word.Count - 1
                        If TXTeXCEPCION2.Text.ElementAt(i + j) = word.ElementAt(j) Then
                            found = True
                        Else
                            found = False
                            Exit For
                        End If
                    Next
                    If found = True Then
                        TXTeXCEPCION2.Select(i, word.Length)
                        If word <= 0 Then
                            TXTeXCEPCION2.SelectionColor = Drawing.Color.Green
                        ElseIf word > 0 And word <= 100 Then
                            TXTeXCEPCION2.SelectionColor = Drawing.Color.Orange
                        Else
                            TXTeXCEPCION2.SelectionColor = Drawing.Color.Red
                        End If

                    End If
                End If
            Catch ex As Exception
                Continue For
            End Try
        Next
    End Sub

    Sub SIZEWord(ByVal word As String, ByVal tipo As String) ' by im4dbr0
        For i As Integer = 0 To TXTeXCEPCION2.TextLength
            Try
                If TXTeXCEPCION2.Text.ElementAt(i).ToString = word.ElementAt(0).ToString Then
                    Dim found As Boolean = False
                    For j As Integer = 1 To word.Count - 1
                        If TXTeXCEPCION2.Text.ElementAt(i + j) = word.ElementAt(j) Then
                            found = True
                        Else
                            found = False
                            Exit For
                        End If
                    Next
                    If found = True Then
                        TXTeXCEPCION2.Select(i, word.Length)

                        'If tipo = "titulo" Then
                        '    TXTeXCEPCION2.SelectionFont = New Font("Tahoma", 12, FontStyle.Bold)
                        'ElseIf tipo = "subtitulo" Then

                        '    TXTeXCEPCION2.SelectionFont = New Font("Tahoma", 9, FontStyle.Bold)
                        '    TXTeXCEPCION2.SelectionBullet = True
                        'End If



                    End If
                End If
            Catch ex As Exception
                Continue For
            End Try
        Next
    End Sub



    Private Sub EnNegrita(ByVal Rtf As RichTextBox, ByVal Texto As String)
        Rtf.SelectionStart = InStr(Rtf.Text, Texto) - 1
        Rtf.SelectionLength = Len(Texto)
        Rtf.Width = 20
    End Sub
    Sub cargarfactor(ByRef categoria As String, ByRef puntaje As Double, ByRef plazo As Integer, ByRef tasa As Double)

        Dim conexiones2 As New CConexion
        conexiones2.conexion()
        conexiones2.abrir()
        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter
        Dim dtTable As DataTable


        'Indico el SP que voy a utilizar
        If CboObjetivo.SelectedItem.ToString.Trim = "Renegociación" Then

            command = New SqlCommand("Riesgo_puntajes2_tasa_renegociado", conexiones2._conexion)
            command.CommandType = CommandType.StoredProcedure
            adapter = New SqlDataAdapter(command)
            dtTable = New DataTable
            With command.Parameters
                'Envió los parámetros que necesito
                .Add(New SqlParameter("@puntaje", SqlDbType.Decimal)).Value = puntaje
                .Add(New SqlParameter("@PLAZO", SqlDbType.Int)).Value = plazo
                .Add(New SqlParameter("@tasa", SqlDbType.Decimal)).Value = tasa
            End With
        Else
            command = New SqlCommand("Riesgo_puntajes2_tasa", conexiones2._conexion)
            command.CommandType = CommandType.StoredProcedure
            adapter = New SqlDataAdapter(command)
            dtTable = New DataTable
            With command.Parameters
                'Envió los parámetros que necesito
                .Add(New SqlParameter("@Categoria", SqlDbType.VarChar)).Value = categoria
                .Add(New SqlParameter("@puntaje", SqlDbType.Decimal)).Value = puntaje
                .Add(New SqlParameter("@PLAZO", SqlDbType.Int)).Value = plazo
                .Add(New SqlParameter("@tasa", SqlDbType.Decimal)).Value = tasa
            End With


        End If
        Try
            'Aquí ejecuto el SP y lo lleno en el DataTable
            adapter.Fill(dtTable)
            'Enlazo mis datos obtenidos en el DataTable con el grid
            DGScoring.DataSource = dtTable
            'Si no pongo esta línea, se crean automáticamente los campos del grid dependiendo de los campos del DataTable
            DGScoring.AutoGenerateColumns = False
            'Aquí le indico cuales campos del select de mi SP van con los campos de mi grid
            'With DGPuntajes2
            '    .Columns("Tipo").DataPropertyName = "Tipo"
            '    '.Columns("Campo2").DataPropertyName = "campo2"
            '    '.Columns("Campo3").DataPropertyName = "campo3"
            'End With
        Catch expSQL As SqlException
            'MsgBox(expSQL.ToString, MsgBoxStyle.OkOnly, "SQL Exception")
            Exit Sub
        End Try

        DGScoring.AllowUserToAddRows = False
    End Sub

    Sub cargardeuda()
        Try


            Dim conexiones As New CConexion
            conexiones.conexion()
            conexiones.abrir()
            Dim command As SqlCommand
            Dim adapter As SqlDataAdapter
            Dim dtTable As DataTable

            'Indico el SP que voy a utilizar
            cboPeriodo.SelectedItem = "201903"
            cboPeriodo2.SelectedItem = "201903"

            command = New SqlCommand("SBIF_DEUDA", conexiones._conexion)
            command.CommandType = CommandType.StoredProcedure
            adapter = New SqlDataAdapter(command)
            dtTable = New DataTable
            With command.Parameters
                'Envió los parámetros que necesito

                .Add(New SqlParameter("@rut", SqlDbType.VarChar)).Value = txtRut2.Text.ToString.Trim
            End With

            Try
                'Aquí ejecuto el SP y lo lleno en el DataTable
                adapter.Fill(dtTable)
                'Enlazo mis datos obtenidos en el DataTable con el grid
                DGDeuda.DataSource = dtTable
                'Si no pongo esta línea, se crean automáticamente los campos del grid dependiendo de los campos del DataTable
                DGDeuda.AutoGenerateColumns = False
                'Aquí le indico cuales campos del select de mi SP van con los campos de mi grid
                'With DGPuntajes2
                '    .Columns("Tipo").DataPropertyName = "Tipo"
                '    '.Columns("Campo2").DataPropertyName = "campo2"
                '    '.Columns("Campo3").DataPropertyName = "campo3"
                'End With
            Catch expSQL As SqlException
                MsgBox(expSQL.ToString, MsgBoxStyle.OkOnly, "SQL Exception")
                Exit Sub
            End Try

            DGScoring.AllowUserToAddRows = False

            Try
                'txtPeriodo.Text = DGDeuda.Rows(0).Cells("PERIODO").Value.ToString.Trim
                cboPeriodo.SelectedItem = DGDeuda.Rows(0).Cells("PERIODO").Value.ToString.Trim
                cboPeriodo2.SelectedItem = DGDeuda.Rows(0).Cells("PERIODO").Value.ToString.Trim
                txtDeudaHipotecaria.Text = DGDeuda.Rows(0).Cells("HIPOTECARIA").Value.ToString.Trim
                If Integer.Parse(DGDeuda.Rows(0).Cells("CONSUMO").Value.ToString.Trim) < 0 Then
                    txtDeudaConsumo.Text = 0
                Else
                    txtDeudaConsumo.Text = DGDeuda.Rows(0).Cells("CONSUMO").Value.ToString.Trim
                End If

                If Integer.Parse(DGDeuda.Rows(0).Cells("COMERCIAL").Value.ToString.Trim) < 0 Then
                    txtDeudaComercial.Text = 0
                Else
                    txtDeudaComercial.Text = DGDeuda.Rows(0).Cells("COMERCIAL").Value.ToString.Trim
                End If
                txtDeudaVencida.Text = DGDeuda.Rows(0).Cells("DEUDAS_VENCIDAS").Value.ToString.Trim
                txtDeudaVencidaIndirecta.Text = DGDeuda.Rows(0).Cells("DEUDAS_VENCIDAS_INDIRECTAS").Value.ToString.Trim
                txtLineaCredito.Text = DGDeuda.Rows(0).Cells("LINEA_DE_CREDITO").Value.ToString.Trim
                txtNumeroAcreedoresFinan.Text = DGDeuda.Rows(0).Cells("NRO_ACREEDORES").Value.ToString.Trim


                cboPeriodo.Enabled = False

                txtDeudaHipotecaria.ReadOnly = True
                txtDeudaConsumo.ReadOnly = True
                txtDeudaComercial.ReadOnly = True
                txtDeudaVencida.ReadOnly = True
                txtDeudaVencidaIndirecta.ReadOnly = True
                txtLineaCredito.ReadOnly = True
                txtNumeroAcreedoresFinan.ReadOnly = True

                ChkmodificaDeudaExterna.Checked = False

            Catch ex As Exception

            End Try
            'txtTasaActual.Text = ""


        Catch ex As Exception

        End Try

    End Sub



    Sub cargardeudaPeriodo()
        Try


            Dim conexiones As New CConexion
            conexiones.conexion()
            conexiones.abrir()
            Dim command As SqlCommand
            Dim adapter As SqlDataAdapter
            Dim dtTable As DataTable

            'Indico el SP que voy a utilizar
            'cboPeriodo.SelectedItem = "201704"

            'MsgBox(cboPeriodo2.SelectedItem.ToString.Substring(0, 4))

            'MsgBox(cboPeriodo2.SelectedItem.ToString.Substring(0, 4) + "_" + cboPeriodo2.SelectedItem.ToString.Substring(4, 2))

            command = New SqlCommand("SBIF_DEUDA_PERIODO", conexiones._conexion)
            command.CommandType = CommandType.StoredProcedure
            adapter = New SqlDataAdapter(command)
            dtTable = New DataTable
            With command.Parameters
                'Envió los parámetros que necesito
                .Add(New SqlParameter("@rut", SqlDbType.VarChar)).Value = txtRut2.Text.ToString.Trim
                .Add(New SqlParameter("@periodo", SqlDbType.VarChar)).Value = cboPeriodo2.SelectedItem.ToString.Substring(0, 4) + "_" + cboPeriodo2.SelectedItem.ToString.Substring(4, 2)
                .Add(New SqlParameter("@periodo2", SqlDbType.VarChar)).Value = cboPeriodo2.SelectedItem.ToString
            End With

            Try
                'Aquí ejecuto el SP y lo lleno en el DataTable
                adapter.Fill(dtTable)
                'Enlazo mis datos obtenidos en el DataTable con el grid
                DGDeuda.DataSource = dtTable
                'Si no pongo esta línea, se crean automáticamente los campos del grid dependiendo de los campos del DataTable
                DGDeuda.AutoGenerateColumns = False
                'Aquí le indico cuales campos del select de mi SP van con los campos de mi grid
                'With DGPuntajes2
                '    .Columns("Tipo").DataPropertyName = "Tipo"
                '    '.Columns("Campo2").DataPropertyName = "campo2"
                '    '.Columns("Campo3").DataPropertyName = "campo3"
                'End With
            Catch expSQL As SqlException
                'MsgBox(expSQL.ToString, MsgBoxStyle.OkOnly, "SQL Exception")
                MsgBox("No existen datos del periodo selecionado", MsgBoxStyle.OkOnly, "SQL Exception")
                Exit Sub
            End Try

            DGScoring.AllowUserToAddRows = False

            Try
                'txtPeriodo.Text = DGDeuda.Rows(0).Cells("PERIODO").Value.ToString.Trim



                If DGDeuda.Rows.Count > 1 Then
                    cboPeriodo.SelectedItem = DGDeuda.Rows(0).Cells("PERIODO").Value.ToString.Trim
                    cboPeriodo2.SelectedItem = DGDeuda.Rows(0).Cells("PERIODO").Value.ToString.Trim
                    txtDeudaHipotecaria.Text = DGDeuda.Rows(0).Cells("HIPOTECARIA").Value.ToString.Trim

                    If Integer.Parse(DGDeuda.Rows(0).Cells("CONSUMO").Value.ToString.Trim) < 0 Then
                        txtDeudaConsumo.Text = 0
                    Else
                        txtDeudaConsumo.Text = DGDeuda.Rows(0).Cells("CONSUMO").Value.ToString.Trim
                    End If

                    If Integer.Parse(DGDeuda.Rows(0).Cells("COMERCIAL").Value.ToString.Trim) < 0 Then
                        txtDeudaComercial.Text = 0
                    Else
                        txtDeudaComercial.Text = DGDeuda.Rows(0).Cells("COMERCIAL").Value.ToString.Trim
                    End If



                    txtDeudaVencida.Text = DGDeuda.Rows(0).Cells("DEUDAS_VENCIDAS").Value.ToString.Trim
                    txtDeudaVencidaIndirecta.Text = DGDeuda.Rows(0).Cells("DEUDAS_VENCIDAS_INDIRECTAS").Value.ToString.Trim
                    txtLineaCredito.Text = DGDeuda.Rows(0).Cells("LINEA_DE_CREDITO").Value.ToString.Trim

                    txtNumeroAcreedoresFinan.Text = DGDeuda.Rows(0).Cells("NRO_ACREEDORES").Value.ToString.Trim


                    cboPeriodo.Enabled = False

                    txtDeudaHipotecaria.ReadOnly = True
                    txtDeudaConsumo.ReadOnly = True
                    txtDeudaComercial.ReadOnly = True
                    txtDeudaVencida.ReadOnly = True
                    txtDeudaVencidaIndirecta.ReadOnly = True
                    txtLineaCredito.ReadOnly = True
                    txtNumeroAcreedoresFinan.ReadOnly = True

                    ChkmodificaDeudaExterna.Checked = False
                Else

                    MsgBox("No existen datos del periodo selecionado", MsgBoxStyle.OkOnly, "SQL Exception")

                End If

            Catch ex As Exception

            End Try
            'txtTasaActual.Text = ""
        Catch ex As Exception

        End Try



    End Sub
    Sub cargartasamaxima(ByRef monto As Integer)

        Dim conexiones2 As New CConexion
        conexiones2.conexion()
        conexiones2.abrir()
        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter
        Dim dtTable As DataTable

        'Indico el SP que voy a utilizar

        command = New SqlCommand("Riesgo_puntaje_tasamaxima", conexiones2._conexion)
        command.CommandType = CommandType.StoredProcedure
        adapter = New SqlDataAdapter(command)
        dtTable = New DataTable
        With command.Parameters
            'Envió los parámetros que necesito
            .Add(New SqlParameter("@monto", SqlDbType.Int)).Value = monto
        End With

        Try
            'Aquí ejecuto el SP y lo lleno en el DataTable
            adapter.Fill(dtTable)
            'Enlazo mis datos obtenidos en el DataTable con el grid
            DGTasaMaxima.DataSource = dtTable
            'Si no pongo esta línea, se crean automáticamente los campos del grid dependiendo de los campos del DataTable
            DGTasaMaxima.AutoGenerateColumns = False
            'Aquí le indico cuales campos del select de mi SP van con los campos de mi grid
            'With DGPuntajes2
            '    .Columns("Tipo").DataPropertyName = "Tipo"
            '    '.Columns("Campo2").DataPropertyName = "campo2"
            '    '.Columns("Campo3").DataPropertyName = "campo3"
            'End With
        Catch expSQL As SqlException
            MsgBox(expSQL.ToString, MsgBoxStyle.OkOnly, "SQL Exception")
            Exit Sub
        End Try

        DGScoring.AllowUserToAddRows = False
    End Sub


    Sub cargardatos()
        Try


            txtTasaActual.Text = ""
            txtpuntaje4.Text = ""
            txtPlazo2.Text = ""
            txtMontoUF.Text = ""
            txtTasaFinalSI.Text = ""
            TXTTasaFinalCI.Text = ""
            txtTipo.Text = ""
            txtCategoria.Text = ""
            txtRango1.Text = ""
            txtFactorSI.Text = ""
            txtFactorCI.Text = ""
            txtFactorPlazoSI.Text = ""
            txtFactorPlazoCI.Text = ""
            txtAntecedentes.Text = ""
            txtPregago2.Text = ""
            'TXTPE.Text = ""
            'TXTPI.Text = ""
            'txtPDI.Text = ""

            txtTasaActual.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("tasa").Value.ToString.Trim
            txtpuntaje4.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("puntaje").Value.ToString.Trim
            txtPlazo2.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("plazo").Value.ToString.Trim
            'txtMontoUF.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("monto_solicitado").Value.ToString.Trim
            txtTasaFinalSI.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("Factor_total_plazo_tasafinal").Value.ToString.Trim
            TXTTasaFinalCI.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("Factor_total_con_informes_plazo_tasafinal").Value.ToString.Trim
            txtTipo.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("Tipo").Value.ToString.Trim
            txtCategoria.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("Categoria").Value.ToString.Trim
            txtRango1.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("Rango1").Value.ToString.Trim
            txtRango2.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("Rango2").Value.ToString.Trim
            txtFactorSI.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("Factor_total").Value.ToString.Trim
            txtFactorCI.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("Factor_total_con_informes").Value.ToString.Trim
            txtFactorPlazoSI.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("Factor_total_plazo").Value.ToString.Trim
            txtFactorPlazoCI.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("Factor_total_con_informes_plazo").Value.ToString.Trim
            'TXTPE.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("PE").Value.ToString.Trim
            'TXTPI.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("PI").Value.ToString.Trim
            'txtPDI.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("PDI").Value.ToString.Trim

            If CboObjetivo.SelectedItem.ToString.Trim = "Renegociación" Or CboObjetivo.SelectedItem.ToString.Trim = "Refinanciamiento" Then
                txtPregago2.Text = "SI"
            Else
                txtPregago2.Text = "NO"
            End If


            txtMonto2.Text = ""
            txtMontoUF.Text = ""
            txtTasaMaxima.Text = ""
            txtMontoUF.Text = DGTasaMaxima.Rows(DGTasaMaxima.CurrentRow.Index).Cells("montouf").Value.ToString.Trim
            txtTasaMaxima.Text = DGTasaMaxima.Rows(DGTasaMaxima.CurrentRow.Index).Cells("tasa").Value.ToString.Trim
            txtMonto2.Text = DGTasaMaxima.Rows(DGTasaMaxima.CurrentRow.Index).Cells("monto").Value.ToString.Trim



            If CboProtestosyMorocidades.SelectedItem.ToString.Trim = "Sin Antecedentes" Or CboProtestosyMorocidades.SelectedItem.ToString.Trim = "Buen comportamiento financiero" Then
                If Double.Parse(txtTasaFinalSI.Text) > Double.Parse(txtTasaMaxima.Text) Then
                    txtTasaMaxima.BackColor = Color.Green
                    txtTasaCastigada.Text = txtTasaMaxima.Text
                    txtTasaFinalSI.BackColor = Color.Orange
                    TXTTasaFinalCI.BackColor = Color.White
                    txtAntecedentes.Text = "NO"

                Else
                    txtTasaMaxima.BackColor = Color.White
                    txtTasaFinalSI.BackColor = Color.Green
                    txtTasaCastigada.Text = txtTasaFinalSI.Text
                    TXTTasaFinalCI.BackColor = Color.White
                    txtAntecedentes.Text = "NO"

                End If


            Else
                If Double.Parse(txtTasaFinalSI.Text) > Double.Parse(txtTasaMaxima.Text) Then
                    txtTasaMaxima.BackColor = Color.Green
                    txtTasaCastigada.Text = txtTasaMaxima.Text
                    txtTasaFinalSI.BackColor = Color.White
                    TXTTasaFinalCI.BackColor = Color.Orange
                    txtAntecedentes.Text = "SI"
                Else
                    txtTasaMaxima.BackColor = Color.White
                    txtTasaFinalSI.BackColor = Color.White
                    TXTTasaFinalCI.BackColor = Color.Green
                    txtTasaCastigada.Text = TXTTasaFinalCI.Text
                    txtAntecedentes.Text = "SI"
                End If



            End If


        Catch ex As Exception

        End Try
    End Sub



    'Sub carculartasanormal()
    '    'MsgBox(txtAumentoTasa.Text)
    '    If Integer.Parse(txtAumentoTasa.Text) = 0 Then

    '        txtTasaNormal.Text = txtTasa.Text
    '    Else
    '        txtTasaNormal.Text = (txtTasa.Text * 100) / (txtAumentoTasa.Text + 100)
    '    End If
    'End Sub



    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        EXCEPCIONESTASAS()
    End Sub


    Private Sub DateFechaContrato_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateFechaContrato.ValueChanged

    End Sub

    Private Sub DGDeuda_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDeuda.CellContentClick

    End Sub



    Public Function ValidarRut(ByVal Rut As String) As String


        If Rut = "Ejemplo: 15883797-8" Then

        Else
            If Len(Rut) < 8 Then

                ValidarRut = "Rut Incorrecto"
            Else


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

            End If

        End If
        Return ValidarRut

    End Function

    Private Sub ChkAval1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAval1.CheckedChanged
        If (ChkAval1.Checked = True) Then
            txtrutaval1.ReadOnly = False
            txtrutaval1.Text = ""
        Else

            txtrutaval1.ReadOnly = True

            txtrutaval1.Text = "Ejemplo: 15883797-8"
        End If
    End Sub

    Private Sub ChkAval2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAval2.CheckedChanged
        If (ChkAval2.Checked = True) Then
            txtRutAval2.ReadOnly = False
            txtRutAval2.Text = ""
        Else

            txtRutAval2.ReadOnly = True

            txtRutAval2.Text = "Ejemplo: 15883797-8"
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkmodificaDeudaExterna.CheckedChanged
        If (ChkmodificaDeudaExterna.Checked = True) Then
            cboPeriodo.Enabled = True
            txtDeudaHipotecaria.ReadOnly = False
            txtDeudaConsumo.ReadOnly = False
            txtDeudaComercial.ReadOnly = False
            txtDeudaVencida.ReadOnly = False
            txtDeudaVencidaIndirecta.ReadOnly = False
            txtLineaCredito.ReadOnly = False
            txtNumeroAcreedoresFinan.ReadOnly = False

            cboPeriodo.SelectedItem = "201804"
            txtDeudaHipotecaria.Text = "0"
            txtDeudaConsumo.Text = "0"
            txtDeudaComercial.Text = "0"
            txtDeudaVencida.Text = "0"
            txtDeudaVencidaIndirecta.Text = "0"
            txtLineaCredito.Text = "0"
            txtNumeroAcreedoresFinan.Text = "0"
            cboPeriodo2.Visible = False
            Label138.Visible = False
            Label116.Visible = True
            cboPeriodo.Visible = True
            cboPeriodo.SelectedItem = cboPeriodo2.SelectedItem
            MsgBox("No se debe considerar el monto de la deuda interna (Saldo Capital)")

        Else
            cboPeriodo2.Visible = True
            Label138.Visible = True
            Label116.Visible = False
            cboPeriodo.Visible = False
            cargardeuda()
        End If

    End Sub



    Private Sub txtPYM6_KeyUp(sender As Object, e As KeyEventArgs) Handles txtPYM6.KeyUp
        If IsNumeric(txtPYM6.Text) Then
            txtPYM6.Text = Puntos(txtPYM6.Text)
            txtPYM6.Select(txtPYM6.Text.Length, 0)
        Else

            MsgBox("Debe ser númerico")
        End If


        '
        'txtPYM6.Text = Replace(TxtMonto.Text, ".", "")

    End Sub



    Private Sub txtPYM612_KeyUp(sender As Object, e As KeyEventArgs) Handles txtPYM612.KeyUp
        If IsNumeric(txtPYM612.Text) Then
            txtPYM612.Text = Puntos(txtPYM612.Text)
            txtPYM612.Select(txtPYM612.Text.Length, 0)
        Else

            MsgBox("Debe ser númerico")
        End If
    End Sub


    Private Sub txtPYM1224_KeyUp(sender As Object, e As KeyEventArgs) Handles txtPYM1224.KeyUp
        If IsNumeric(txtPYM1224.Text) Then
            txtPYM1224.Text = Puntos(txtPYM1224.Text)
            txtPYM1224.Select(txtPYM1224.Text.Length, 0)
        Else

            MsgBox("Debe ser númerico")
        End If
    End Sub


    Private Sub txtPYM24_KeyUp(sender As Object, e As KeyEventArgs) Handles txtPYM24.KeyUp
        If IsNumeric(txtPYM24.Text) Then
            txtPYM24.Text = Puntos(txtPYM24.Text)
            txtPYM24.Select(txtPYM24.Text.Length, 0)
        Else

            MsgBox("Debe ser númerico")
        End If
    End Sub

    Private Sub cboPeriodo2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPeriodo2.SelectedIndexChanged
        cargardeudaPeriodo()
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles BtnRenta.Click


        If CboFormaDePago.SelectedItem = "" Then
            MsgBox("Debe Indicar una forma de pago")
        Else
            frmRentas.MdiParent = Me.MdiParent
            frmRentas.Visible = True
            frmRentas.Location = New Point(0, 0)
        End If
    End Sub

    Private Sub frmEvaluar_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        CERRARTODO()
    End Sub

    Private Sub frmEvaluar_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        CERRARTODO()
    End Sub


    Sub CERRARTODO()

        If EstaAbierto(frmRentas) = True Then
            frmRentas.Close()
        End If
        If EstaAbierto(frmPrepago) = True Then
            frmPrepago.Close()
        End If
        If EstaAbierto(frmFicha) = True Then
            frmFicha.Close()
        End If
        If EstaAbierto(AVISO) = True Then
            AVISO.Close()
        End If


    End Sub

    Public Function EstaAbierto(ByVal Myform As Form)
        Dim objForm As Form
        Dim blnAbierto As Boolean = False
        blnAbierto = False
        For Each objForm In My.Application.OpenForms
            If (Trim(objForm.Name) = Trim(Myform.Name)) Then
                blnAbierto = True
            End If
        Next
        Return blnAbierto
    End Function

    Private Sub cboTasaSolicitada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTasaSolicitada.SelectedIndexChanged
        If CboFormaDePago.SelectedItem = "PLANILLA" And cboTasaSolicitada.SelectedItem <> txtTasaConvenio.Text And txtCodDaca.Text = "" And txtTipoEP.Text = "Empleados" Then
            MsgBox("No es posible modificar la tasa declarada en la renta")
            cboTasaSolicitada.SelectedItem = txtTasaConvenio.Text
        End If

    End Sub

    Private Sub Button1_Click_3(sender As Object, e As EventArgs) Handles BtnCalcular2.Click


        Dim permitesolicitudtasa = "SI"

        If CboFormaDePago.SelectedItem.ToString <> "PLANILLA" Then

            If CboEjecutivo.SelectedItem.ToString.Trim = "LILIAN BARRIOS RAMIREZ" Or CboEjecutivo.SelectedItem.ToString.Trim = "PRISCILA MATELUNA JORQUERA" Then

                permitesolicitudtasa = "SI"

            Else
                If cboTasaSolicitada.SelectedItem.ToString.Trim = "Por Defecto Sistema" Then
                    permitesolicitudtasa = "SI"
                Else
                    permitesolicitudtasa = "NO"
                End If


            End If

        Else
            permitesolicitudtasa = "SI"

        End If

        If CboProducto.SelectedItem = "CUOTON" Or CboProducto.SelectedItem = "RENEGOCIACION FLEXIBLE" Then
            permitesolicitudtasa = "SI"
        End If
        Dim permitevalidacion As Integer = 0
        If CboFormaDePago2.SelectedItem = "Senado CJ" Or CboFormaDePago2.SelectedItem = "Senado ANEF" Then
            permitevalidacion = 1
        End If

        BtnCalcular2.BackColor = Color.MistyRose
        If CboProducto.SelectedItem = "RENEGOCIACION FLEXIBLE" And cboTasaSolicitada.SelectedItem = "Por Defecto Sistema" Then
            MsgBox("Para el producto RENEGOCIACION FLEXIBLE,se debe solicitar una tasa de acuerdo a las politicas")
        Else
            If CboProducto.SelectedItem = "CUOTON" And cboTasaSolicitada.SelectedItem = "Por Defecto Sistema" Then
                MsgBox("Para el producto CUOTON,se debe solicitar una tasa de acuerdo a las politicas")
            Else
                If (CboFormaDePago.SelectedItem.ToString.Trim = "PLANILLA") And cboTasaSolicitada.SelectedItem = "Por Defecto Sistema" Then
                    MsgBox("Para pagos por planilla se debe solicitar una tasa de acuerdo a las politicas")
                Else
                    If CboObjetivo.SelectedItem = "" Then
                        MsgBox("Debe señalar un objetivo")
                    Else

                        If txtVisibledEUDAeiNGRESOS.Text = "NO" Then
                            MsgBox("Se debe Verificar Ficha deudas e ingresos antes de continuar")

                        Else


                            If txtProducto.Text.Trim = "" Then

                                MsgBox("Debe indicar producto")

                            Else

                                If CboProducto.SelectedItem = "RENEGOCIACION FLEXIBLE" And (TxtMonto.Text = 0 Or TxtDisponible2.Text = 0) Then
                                    MsgBox("El producto RENEGOCIACION FLEXIBLE debe indicar Monto Solicitado y Disponible diferente a 0")
                                Else
                                    If TxtMonto.Text = 0 And TxtDisponible2.Text = 0 Then
                                        MsgBox("El monto a solicitar no puede ser 0")
                                    Else


                                        If CboCuotas.SelectedItem = "" Then

                                            MsgBox("Debe indicar n° de cuotas")
                                        Else

                                            If btnPrepago.BackColor = Color.MistyRose And btnPrepago.Visible = True Then

                                                MsgBox("Debe verificar el o los prepagos")

                                            Else

                                                TxtMonto.Text = Replace(TxtMonto.Text, ".", "")
                                                txtPrepago.Text = Replace(txtPrepago.Text, ".", "")
                                                'Try


                                                If (txtVisibleSocio.Text = "NO") Then
                                                    MsgBox("Se debe Verificar Ficha Socio antes de continuar")
                                                Else

                                                    If (TxtMonto.Text = "") Then
                                                        MsgBox("Se debe agregar un monto")
                                                    Else
                                                        If (txtPrepago.Text = "") Then
                                                            MsgBox("Se debe agregar un monto a prepago")
                                                        Else

                                                            If (Integer.Parse(txtPrepago.Text) > Integer.Parse(TxtMonto.Text) And permitevalidacion = 0) Then
                                                                MsgBox("El monto del prepago no puede ser mayor al monto solicitado")

                                                            Else
                                                                If txtPrepago.Text <> 0 And cboRefRen.SelectedItem.ToString = "NO" Then
                                                                    MsgBox("Al estar prepagando una operación el objetivo debe ser Refinanciamiento o Renegociación, favor modificar este parametro")
                                                                Else
                                                                    If permitesolicitudtasa = "NO" Then
                                                                        MsgBox("Usuario sin permiso para solicitar tasa por forma de pago directo")
                                                                    Else


                                                                        Dim MontoMin As Integer = 0
                                                                        Dim MontoMax As Integer = 0
                                                                        Dim PlazoMin As Integer = 0
                                                                        Dim PlazoMax As Integer = 0

                                                                        Dim conexiones1 As New CConexion
                                                                        conexiones1.conexion()
                                                                        Dim command1 As SqlCommand = New SqlCommand("SELECT [MONTOMIN],[MONTOMAX],PLAZOMIN,PLAZOMAX FROM [_NOMBRECREDITO_VIGENCIA] as n inner join _nombrecredito  as c on n.CODNOM=c.CODNOM where FECHADESDE<=  CONVERT(VARCHAR(8), GETDATE(), 112) and FECHAHASTA>=  CONVERT(VARCHAR(8), GETDATE(), 112) and n.CODNOM NOT IN (12,17,20,21,22) AND rtrim(c.DESCRIPCION)='" + CboProducto.SelectedItem.ToString.Trim + "'", conexiones1._conexion)
                                                                        conexiones1.abrir()
                                                                        Dim reader1 As SqlDataReader = command1.ExecuteReader()

                                                                        If reader1.HasRows Then
                                                                            Do While reader1.Read()

                                                                                MontoMin = (reader1(0).ToString)
                                                                                MontoMax = (reader1(1).ToString)
                                                                                PlazoMin = (reader1(2).ToString)
                                                                                PlazoMax = (reader1(3).ToString)
                                                                            Loop
                                                                        Else
                                                                        End If
                                                                        reader1.Close()





                                                                        If Integer.Parse(Replace(TxtMonto.Text, ".", "")) < MontoMin And permitevalidacion = 0 Then
                                                                            MsgBox("El producto " + CboProducto.SelectedItem.ToString.Trim + " esta fuera del MONTO MINIMO permitido")
                                                                        Else
                                                                            If Integer.Parse(Replace(TxtMonto.Text, ".", "")) > MontoMax Then
                                                                                MsgBox("El producto " + CboProducto.SelectedItem.ToString.Trim + " esta fuera del MONTO MAXIMO permitido")
                                                                            Else
                                                                                If Integer.Parse(CboCuotas.SelectedItem) < PlazoMin Then
                                                                                    MsgBox("El producto " + CboProducto.SelectedItem.ToString.Trim + " esta fuera del PLAZO MINIMO permitido")
                                                                                Else
                                                                                    If Integer.Parse(CboCuotas.SelectedItem) > PlazoMax Then
                                                                                        MsgBox("El producto " + CboProducto.SelectedItem.ToString.Trim + " esta fuera del PLAZO MAXIMO permitido")
                                                                                    Else

                                                                                        'If CboFormaDePago.SelectedItem = "PLANILLA" And (FRM) Then
                                                                                        '    MsgBox("Usuario sin permiso para solicitar tasa por forma de pago directo")
                                                                                        'Else
                                                                                        calculadescuentocampaña()
                                                                                        calcularprestamo2()

                                                                                        If TASASALTAS = "SI" Then
                                                                                            'txtTasaSolicitada.Text = cboTasaSolicitada.SelectedItem.ToString
                                                                                            calculardeudainterna()
                                                                                            cargarcapacidadylvl()
                                                                                            puntajes()

                                                                                            If contar = 1 Then
                                                                                                recalcularprestamo()
                                                                                                contar = 0
                                                                                            End If
                                                                                        End If
                                                                                    End If

                                                                                End If
                                                                            End If
                                                                        End If
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub ChkFechaInicio_CheckedChanged(sender As Object, e As EventArgs) Handles ChkFechaInicio.CheckedChanged
        If (ChkFechaInicio.Checked = True) Then
            Dim RECIBERESPUESTA As DialogResult
            RECIBERESPUESTA = MessageBox.Show("¿Esta seguro que desea cambiar la fecha de inicio del credito?", "DIAS DE GRACIA", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If RECIBERESPUESTA = Windows.Forms.DialogResult.Yes Then
                DFechaInicio.Enabled = True
                DFechaInicio.Visible = True
            Else
                DFechaInicio.Visible = False
                DFechaInicio.Enabled = False
                ChkFechaInicio.Checked = False
            End If

        Else
            DFechaInicio.Enabled = False
        End If
    End Sub

    Sub recalcularprestamo()


        'If txtDescuento.Text = "Aplica" Then
        '    txtTasaFinal.Text = Math.Round(Double.Parse(txtTasaFinal.Text) - ((Double.Parse(txtTasaFinal.Text) * 15) / 100), 2)
        'End If


        '-----------PARAMETROS GENERALES
        'SOCIO O PRESOCIO
        Dim SOCIO_PRESOCIO As Integer = 1
        If (Trim(Cbotipo.SelectedItem) = "PRE-SOCIO") Then
            SOCIO_PRESOCIO = 2
        End If
        'NUMERO DE SOCIO
        Dim NROSOCIO As String = txtNrosocio.Text.ToString
        'CANTIDAD DE CUOTAS (PLAZO) DEL CREDITO
        Dim CANT_CUOTAS As String = ""
        If CboProducto.SelectedItem = "CUOTON" Or CboProducto.SelectedItem = "RENEGOCIACION FLEXIBLE" Then
            CANT_CUOTAS = Integer.Parse(CboCuotas.SelectedItem.ToString) - 1
        Else
            CANT_CUOTAS = CboCuotas.SelectedItem.ToString
        End If
        'TIPO DE CONVENIO (TABLA _FORMAPAGO)

        Dim FORMAPAGO As Integer = 1

        Dim conexiones2 As New CConexion
        conexiones2.conexion()
        Dim command2 As SqlCommand = New SqlCommand("SELECT CODFOR FROM _FORMAPAGO WHERE DESCRIPCION='" + CboFormaDePago2.SelectedItem.ToString() + "'", conexiones2._conexion)
        conexiones2.abrir()
        Dim reader2 As SqlDataReader = command2.ExecuteReader()

        If reader2.HasRows Then
            Do While reader2.Read()
                FORMAPAGO = Integer.Parse(reader2(0).ToString)
            Loop
        Else
        End If
        reader2.Close()

        'TASA DE INTERES DEL CREDITO

        Dim TASA As Double = txtTasaFinal.Text
        'FECHA DE OTORGAMIENTO


        Dim FECHA_PTMO As String = System.DateTime.Today.ToString("yyyyMMdd")

        '------------PARAMETROS SOLO PARA CREDITOS MENSUALES
        'MONTO SOLICITADO 

        Dim MONTO_PTMO As Double = Replace(TxtMonto.Text, ".", "")
        If CboProducto.SelectedItem = "CUOTON" Then
            MONTO_PTMO = 0
        End If
        If CboFormaDePago2.SelectedItem = "Senado CJ" Or CboFormaDePago2.SelectedItem = "Senado ANEF" Then
            MONTO_PTMO = 0
        End If

        'DIAS GRACIA
        Dim DIASGRACIA As String = "S"
        'INDICA FORZOSAMENTE EL MES Y EL AÑO DE INICIO
        Dim MES_PRIMERA As Integer = 0
        'INDICA FORZOSAMENTE EL MES Y EL AÑO DE INICIO
        Dim ANO_PRIMERA As Integer = 0

        If (ChkFechaInicio.Checked = True) Then
            MES_PRIMERA = DFechaInicio.Value.Date.ToString("MM")
            ANO_PRIMERA = DFechaInicio.Value.Date.ToString("yyyy")

            Datos._MES_PRIMERA = DFechaInicio.Value.Date.ToString("MM")
            Datos._ANO_PRIMERA = DFechaInicio.Value.Date.ToString("yyyy")
        End If
        Dim DISPONIBLE As Integer = Replace(TxtDisponible2.Text, ".", "")

        '------------PARAMETROS SOLO PARA CREDITOS CONGRESO 
        Dim COD_NOM_CRED As Integer = 0

        Dim conexiones1 As New CConexion
        conexiones1.conexion()
        Dim command1 As SqlCommand = New SqlCommand(" select CODNOM from _nombrecredito  where DESCRIPCION='" + CboProducto.SelectedItem.ToString.Trim + "'  ", conexiones1._conexion)
        conexiones1.abrir()
        Dim reader1 As SqlDataReader = command1.ExecuteReader()

        If reader1.HasRows Then
            Do While reader1.Read()
                COD_NOM_CRED = (reader1(0).ToString)
            Loop
        Else
        End If
        reader1.Close()



        'Dim COD_NOM_CRED As Integer = txtcod
        'MONTO QUE PAGARA POR CONCEPTO DE CAPITAL SOCIAL POR CADA PAGO DE CUOTA (SE REBAJARA DEL DISPONIBLE PARA CREDITO)
        Dim CON_DESGRAL As Integer = 0
        'MONTO QUE PAGARA POR CONCEPTO DE CUOTA GASTOS POR CADA PAGO DE CUOTA (SE REBAJARA DEL DISPONIBLE PARA CREDITO)
        Dim CON_CESANT As Integer = 0

        Dim CON_SOLIDARIO As Integer = 0

        '.Add(New SqlParameter("@COD_NOM_CRED", SqlDbType.Int)).Value = CAPITAL_SOCIAL
        '.Add(New SqlParameter("@CON_DESGRA", SqlDbType.Int)).Value = GASTOS
        '.Add(New SqlParameter("@CON_CESANT", SqlDbType.Int)).Value = GASTOS
        '.Add(New SqlParameter("@CON_SOLIDARIO  ", SqlDbType.Int)).Value = GASTOS




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


        'Aquí ejecuto el SP y lo lleno en el DataTable
        adapter12.Fill(dtTable12)
        'Enlazo mis datos obtenidos en el DataTable con el grid
        DgAmortizacion2.DataSource = dtTable12
        'Si no pongo esta línea, se crean automáticamente los campos del grid dependiendo de los campos del DataTable
        DgAmortizacion2.AutoGenerateColumns = False
        'Aquí le indico cuales campos del select de mi SP van con los campos de mi grid
        'With DGPuntajes2
        '    .Columns("Tipo").DataPropertyName = "Tipo"
        '    '.Columns("Campo2").DataPropertyName = "campo2"
        '    '.Columns("Campo3").DataPropertyName = "campo3"
        'End With

        DGScoring.AllowUserToAddRows = False
        conexiones12.cerrar()



        'CboDiasdeGracia.Text = DgAmortizacion2.Rows(1).Cells("DIVIDENDO").Value.ToString.Trim
        CboDiasdeGracia.Text = DgAmortizacion2.Rows(1).Cells("DIVIDENDO").Value.ToString.Trim
        'TxtCuota.Text = DgAmortizacion2.Rows(5).Cells("DIVIDENDO").Value.ToString.Trim


        'MsgBox(DgAmortizacion2.Rows(3).Cells("DIVIDENDO").Value.ToString.Trim)


        BtnCalcular2.BackColor = Color.Transparent

        BtnCalcular2.BackColor = Color.White

        txtProducto2.Text = txtProducto.Text.Trim

        CARGARDATOSAMORTIZACION()
    End Sub
    Sub calcularprestamo2()


        Me.DgAmortizacion.Rows.Clear()
        Dim tasaactual As String = ""
        Dim tasanueva As String = ""
        Dim datos As String = ""
        Dim permite_aumento_tasa As String = ""
        Dim permite_renegociacion_tasa_rango As String = ""
        Dim permite_Diasgracia_subsiguiente As String = ""
        txtTasaReal.Text = 0
        txtTasaSolicitada.Text = 0

        ' VERFIFICA SI EL PRODUCTO SOLICITADO PERMITE AUMENTO DE TASA , Y REBAJA DE TASA SI ES QUE PERMITE RENEGOCIACIÓN
        Dim conexiones9 As New CConexion
        conexiones9.conexion()
        Dim command9 As SqlCommand = New SqlCommand("SELECT  ISNULL(PERMITE_AUMENTO_TASA,0),ISNULL(PERMITE_RENEGOCIACION_TASA_RANGO,1),isnull(PERMITE_DIASGRACIA_SUBSIGUINETE,1) FROM [_NOMBRECREDITO_RESTRICCIONES]as cc1 inner join _nombrecredito as cc2 on cc1.CODNOM=CC2.CODNOM WHERE DESCRIPCION='" + txtProducto.Text.ToString.Trim + "'", conexiones9._conexion)
        conexiones9.abrir()
        Dim reader9 As SqlDataReader = command9.ExecuteReader()

        If reader9.HasRows Then
            Do While reader9.Read()

                permite_aumento_tasa = reader9(0).ToString()
                permite_renegociacion_tasa_rango = reader9(1).ToString()
                permite_Diasgracia_subsiguiente = reader9(2).ToString()

            Loop
        Else
        End If

        reader9.Close()
        conexiones9.cerrar()
        'CARGA LOS DIAS DE GRACIAS SEGÚN LOS CONVENIOS
        'cargardiasgracia(permite_Diasgracia_subsiguiente)


        'SI EL CREDITO ES BAJO UNA RENEGOCIACION SE VERIFICA QUE PERMITA BAJO ESTE CRITERIO UNA BAJA DE TASA RESPECTO AL MONTO SOLICITADO SI NO LO PERMITE SE DEJA A LA TASA NORMAL DE DICHO PRODUCTO

        Dim conexiones As New CConexion
        conexiones.conexion()
        If cboRefRen.SelectedItem.ToString.Trim = "SI" And permite_renegociacion_tasa_rango = 0 Then
            'MsgBox("tasa normal")
            datos = "SELECT TASA_NORMAL FROM [_TASA_RANGO] as n inner join _nombrecredito  as c on n.CODNOM=c.CODNOM WHERE n.fecha =  (select max(N.fecha)  FROM [_TASA_RANGO] as n inner join _nombrecredito  as c on n.CODNOM=c.CODNOM WHERE  N.fecha  <=CONVERT(VARCHAR(8), GETDATE(), 112) AND c.DESCRIPCION='" + txtProducto.Text.ToString + "')  AND  rango1<=" + Replace(TxtMonto.Text, ".", "") + "   and rango2>=" + Replace(TxtMonto.Text, ".", "") + " and c.DESCRIPCION='" + txtProducto.Text.ToString + "'"
        Else
            'MsgBox("tasa campaña")
            datos = "SELECT [TASA] FROM [_TASA_RANGO] as n inner join _nombrecredito  as c on n.CODNOM=c.CODNOM WHERE n.fecha =  (select max(N.fecha)  FROM [_TASA_RANGO] as n inner join _nombrecredito  as c on n.CODNOM=c.CODNOM WHERE  N.fecha  <=CONVERT(VARCHAR(8), GETDATE(), 112) AND c.DESCRIPCION='" + txtProducto.Text.ToString + "')  AND  rango1<=" + Replace(TxtMonto.Text, ".", "") + "   and rango2>=" + Replace(TxtMonto.Text, ".", "") + " and c.DESCRIPCION='" + txtProducto.Text.ToString + "'"
        End If
        conexiones.abrir()
        Dim command As SqlCommand = New SqlCommand(datos, conexiones._conexion)

        Dim reader As SqlDataReader = command.ExecuteReader()
        If reader.HasRows Then
            Do While reader.Read()
                'TASA REAL
                'TASA QUEDA POR DEFECTO SEGUN TASAS_RANGOS
                tasanueva = reader(0).ToString
                txtTasaReal.Text = Decimal.Round(Decimal.Parse(reader(0).ToString), 2)
            Loop
        End If
        reader.Close()
        conexiones.cerrar()
        If (tasanueva = "") Then
            MsgBox("El monto no esta dentro del rango del producto solicitado ")
            TASASALTAS = "NO"
            Return
        Else


            'MODIFICACIONES DE TASAS MANUAL

            'MODIFICACIONES DE TASAS MANUAL
            If (cboTasaSolicitada.Enabled = True And cboTasaSolicitada.SelectedItem <> "Por Defecto Sistema") Then
                'DEBE SER POR PLANILLA LAS TASAS O REALIZADAS POR CARLOS BOMBAL

                If CboFormaDePago.SelectedItem.ToString = "PLANILLA" Or CboProducto.SelectedItem = "CUOTON" Or CboProducto.SelectedItem = "RENEGOCIACION FLEXIBLE" Then
                    txtTasaSolicitada.Text = cboTasaSolicitada.SelectedItem.ToString
                Else
                    MsgBox("Modificación de tasa solicitada permitido solo para pagos por Planilla o producto Cuoton")
                End If

            End If




            'CAMPO EXCLUSIVO PARA CAMPAÑA CREDITO ANIVERSARIO
            'If CboProducto.SelectedItem.ToString.Trim = "ANIVERSARIO" Then
            '    If CboReferencias.SelectedItem.ToString.Trim = "0" Then
            '        MsgBox("De acuerdo a lo establecido para este tipo de producto y referencias la tasa es de 1,5")
            '        txtConvenio.Text = "1,5"
            '    ElseIf CboReferencias.SelectedItem.ToString.Trim = "1" Then
            '        MsgBox("De acuerdo a lo establecido para este tipo de producto y referencias la tasa BAJA a 1,4")
            '        txtConvenio.Text = "1,5"
            '    ElseIf CboReferencias.SelectedItem.ToString.Trim = "2" Then
            '        MsgBox("De acuerdo a lo establecido para este tipo de producto y referencias la tasa BAJA a 1,3")
            '        txtConvenio.Text = "1,5"
            '    ElseIf CboReferencias.SelectedItem.ToString.Trim = "3" Then
            '        MsgBox("De acuerdo a lo establecido para este tipo de producto y referencias la tasa BAJA a 1,2")
            '        txtConvenio.Text = "1,5"
            '    End If
            'Else
            'If CboProducto.SelectedItem.ToString.Trim = "REFERENCIADO" Then
            '    MsgBox("De acuerdo a lo establecido para este tipo de producto y referencias la tasa BAJA a 1,3")
            '    txtConvenio.Text = "1,5"
            'End If




            Dim monto As Double = Double.Parse(TxtMonto.Text)
            Dim interes As Double = 0


            'PRIORIDAD TASA SOLICITADA , TASA CONVENIO Y FINALMENTE TASA REAL
            If txtTasaSolicitada.Text <> 0 Then
                interes = txtTasaSolicitada.Text / 100
                txtTasaSolicitada.BackColor = Color.Green
                txtTasaFinal.Text = txtTasaSolicitada.Text
            Else
                interes = txtTasaReal.Text / 100
                txtTasaReal.BackColor = Color.Green
                txtTasaFinal.Text = txtTasaReal.Text
            End If


            '-----------PARAMETROS GENERALES
            'SOCIO O PRESOCIO
            Dim SOCIO_PRESOCIO As Integer = 1
            If (Trim(Cbotipo.SelectedItem) = "PRE-SOCIO") Then
                SOCIO_PRESOCIO = 2
            End If
            'NUMERO DE SOCIO
            Dim NROSOCIO As String = txtNrosocio.Text.ToString
            'CANTIDAD DE CUOTAS (PLAZO) DEL CREDITO
            Dim CANT_CUOTAS As String = ""
            If CboProducto.SelectedItem = "CUOTON" Or CboProducto.SelectedItem = "RENEGOCIACION FLEXIBLE" Then
                CANT_CUOTAS = Integer.Parse(CboCuotas.SelectedItem.ToString) - 1

            Else
                CANT_CUOTAS = CboCuotas.SelectedItem.ToString

            End If

            'TIPO DE CONVENIO (TABLA _FORMAPAGO)

            Dim FORMAPAGO As Integer = 1

            Dim conexiones2 As New CConexion
            conexiones2.conexion()
            Dim command2 As SqlCommand = New SqlCommand("SELECT CODFOR FROM _FORMAPAGO WHERE DESCRIPCION='" + CboFormaDePago2.SelectedItem.ToString() + "'", conexiones2._conexion)
            conexiones2.abrir()
            Dim reader2 As SqlDataReader = command2.ExecuteReader()

            If reader2.HasRows Then
                Do While reader2.Read()
                    FORMAPAGO = Integer.Parse(reader2(0).ToString)
                Loop
            Else
            End If
            reader2.Close()

            'TASA DE INTERES DEL CREDITO

            Dim TASA As Double = txtTasaFinal.Text
            'FECHA DE OTORGAMIENTO


            Dim FECHA_PTMO As String = System.DateTime.Today.ToString("yyyyMMdd")

            '------------PARAMETROS SOLO PARA CREDITOS MENSUALES
            'MONTO SOLICITADO 
            Dim MONTO_PTMO As Double = 0
            If CboProducto.SelectedItem <> "CUOTON" Or CboProducto.SelectedItem <> "RENEGOCIACION FLEXIBLE" Then
                MONTO_PTMO = Replace(TxtMonto.Text, ".", "")
            End If
            'DIAS GRACIA
            Dim DIASGRACIA As String = "S"
            'INDICA FORZOSAMENTE EL MES Y EL AÑO DE INICIO
            Dim MES_PRIMERA As Integer = 0
            'INDICA FORZOSAMENTE EL MES Y EL AÑO DE INICIO
            Dim ANO_PRIMERA As Integer = 0

            If (ChkFechaInicio.Checked = True) Then
                MES_PRIMERA = DFechaInicio.Value.Date.ToString("MM")
                ANO_PRIMERA = DFechaInicio.Value.Date.ToString("yyyy")
            End If

            '------------PARAMETROS SOLO PARA CREDITOS CONGRESO 
            'DISPONIBLE TOTAL DEL CERTIFICADO DE SUELDOS
            Dim DISPONIBLE As Integer = Replace(TxtDisponible2.Text, ".", "")

            '------------PARAMETROS SOLO PARA CREDITOS CONGRESO 
            Dim COD_NOM_CRED As Integer = 0

            Dim conexiones1 As New CConexion
            conexiones1.conexion()
            Dim command1 As SqlCommand = New SqlCommand(" select CODNOM from _nombrecredito  where DESCRIPCION='" + CboProducto.SelectedItem.ToString.Trim + "'  ", conexiones1._conexion)
            conexiones1.abrir()
            Dim reader1 As SqlDataReader = command1.ExecuteReader()

            If reader1.HasRows Then
                Do While reader1.Read()
                    COD_NOM_CRED = (reader1(0).ToString)
                Loop
            Else
            End If
            reader1.Close()



            'Dim COD_NOM_CRED As Integer = txtcod
            'MONTO QUE PAGARA POR CONCEPTO DE CAPITAL SOCIAL POR CADA PAGO DE CUOTA (SE REBAJARA DEL DISPONIBLE PARA CREDITO)
            Dim CON_DESGRAL As Integer = 0
            'MONTO QUE PAGARA POR CONCEPTO DE CUOTA GASTOS POR CADA PAGO DE CUOTA (SE REBAJARA DEL DISPONIBLE PARA CREDITO)
            Dim CON_CESANT As Integer = 0

            Dim CON_SOLIDARIO As Integer = 0

            '.Add(New SqlParameter("@COD_NOM_CRED", SqlDbType.Int)).Value = CAPITAL_SOCIAL
            '.Add(New SqlParameter("@CON_DESGRA", SqlDbType.Int)).Value = GASTOS
            '.Add(New SqlParameter("@CON_CESANT", SqlDbType.Int)).Value = GASTOS
            '.Add(New SqlParameter("@CON_SOLIDARIO  ", SqlDbType.Int)).Value = GASTOS




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


            'Aquí ejecuto el SP y lo lleno en el DataTable
            adapter12.Fill(dtTable12)
            'Enlazo mis datos obtenidos en el DataTable con el grid
            DgAmortizacion2.DataSource = dtTable12
            'Si no pongo esta línea, se crean automáticamente los campos del grid dependiendo de los campos del DataTable
            DgAmortizacion2.AutoGenerateColumns = False
            'Aquí le indico cuales campos del select de mi SP van con los campos de mi grid
            'With DGPuntajes2
            '    .Columns("Tipo").DataPropertyName = "Tipo"
            '    '.Columns("Campo2").DataPropertyName = "campo2"
            '    '.Columns("Campo3").DataPropertyName = "campo3"
            'End With

            DGScoring.AllowUserToAddRows = False
            conexiones12.cerrar()
        End If

        'MsgBox(DgAmortizacion2.Rows(1).Cells("DIVIDENDO").Value.ToString.Trim)
        'CboDiasdeGracia.Text = DgAmortizacion2.Rows(1).Cells("DIVIDENDO").Value.ToString.Trim
        CboDiasdeGracia.Text = DgAmortizacion2.Rows(1).Cells("DIVIDENDO").Value.ToString.Trim
        'TxtCuota.Text = DgAmortizacion2.Rows(5).Cells("DIVIDENDO").Value.ToString.Trim



        'MsgBox(DgAmortizacion2.Rows(3).Cells("DIVIDENDO").Value.ToString.Trim)

        BtnCalcular2.BackColor = Color.Transparent

        BtnCalcular2.BackColor = Color.White

        txtProducto2.Text = txtProducto.Text.Trim

        TASASALTAS = "SI"

        CARGARDATOSAMORTIZACION()


    End Sub
    'Sub calcularprestamo()

    '    Me.DgAmortizacion.Rows.Clear()


    '    Dim tasaactual As String = ""
    '    Dim tasanueva As String = ""
    '    Dim datos As String = ""
    '    Dim permite_aumento_tasa As String = ""
    '    Dim permite_renegociacion_tasa_rango As String = ""
    '    Dim permite_Diasgracia_subsiguiente As String = ""
    '    txtTasaReal.Text = 0
    '    txtTasaSolicitada.Text = 0
    '    'txtTasaConvenio.Text = 0

    '    ' VERFIFICA SI EL PRODUCTO SOLICITADO PERMITE AUMENTO DE TASA , Y REBAJA DE TASA SI ES QUE PERMITE RENEGOCIACIÓN
    '    Dim conexiones9 As New CConexion
    '    conexiones9.conexion()
    '    Dim command9 As SqlCommand = New SqlCommand("SELECT  ISNULL(PERMITE_AUMENTO_TASA,0),ISNULL(PERMITE_RENEGOCIACION_TASA_RANGO,1),isnull(PERMITE_DIASGRACIA_SUBSIGUINETE,1) FROM [_NOMBRECREDITO_RESTRICCIONES]as cc1 inner join _nombrecredito as cc2 on cc1.CODNOM=CC2.CODNOM WHERE DESCRIPCION='" + txtProducto.Text.ToString.Trim + "'", conexiones9._conexion)
    '    conexiones9.abrir()
    '    Dim reader9 As SqlDataReader = command9.ExecuteReader()

    '    If reader9.HasRows Then
    '        Do While reader9.Read()

    '            permite_aumento_tasa = reader9(0).ToString()
    '            permite_renegociacion_tasa_rango = reader9(1).ToString()
    '            permite_Diasgracia_subsiguiente = reader9(2).ToString()

    '        Loop
    '    Else
    '    End If

    '    reader9.Close()
    '    'conexiones9.cerrar()

    '    'CARGA LOS DIAS DE GRACIAS SEGÚN LOS CONVENIOS
    '    'cargardiasgracia(permite_Diasgracia_subsiguiente)


    '    'SI EL CREDITO ES BAJO UNA RENEGOCIACION SE VERIFICA QUE PERMITA BAJO ESTE CRITERIO UNA BAJA DE TASA RESPECTO AL MONTO SOLICITADO SI NO LO PERMITE SE DEJA A LA TASA NORMAL DE DICHO PRODUCTO

    '    Dim conexiones As New CConexion
    '    conexiones.conexion()
    '    If cboRefRen.SelectedItem.ToString.Trim = "SI" And permite_renegociacion_tasa_rango = 0 Then
    '        'MsgBox("tasa normal")
    '        datos = "SELECT TASA_NORMAL FROM [_TASA_RANGO] as n inner join _nombrecredito  as c on n.CODNOM=c.CODNOM WHERE n.fecha =  (select max(N.fecha)  FROM [_TASA_RANGO] as n inner join _nombrecredito  as c on n.CODNOM=c.CODNOM WHERE  N.fecha  <=CONVERT(VARCHAR(8), GETDATE(), 112) AND c.DESCRIPCION='" + txtProducto.Text.ToString + "')  AND  rango1<=" + Replace(TxtMonto.Text, ".", "") + "   and rango2>=" + Replace(TxtMonto.Text, ".", "") + " and c.DESCRIPCION='" + txtProducto.Text.ToString + "'"
    '    Else
    '        'MsgBox("tasa campaña")
    '        datos = "SELECT [TASA] FROM [_TASA_RANGO] as n inner join _nombrecredito  as c on n.CODNOM=c.CODNOM WHERE n.fecha =  (select max(N.fecha)  FROM [_TASA_RANGO] as n inner join _nombrecredito  as c on n.CODNOM=c.CODNOM WHERE  N.fecha  <=CONVERT(VARCHAR(8), GETDATE(), 112) AND c.DESCRIPCION='" + txtProducto.Text.ToString + "')  AND  rango1<=" + Replace(TxtMonto.Text, ".", "") + "   and rango2>=" + Replace(TxtMonto.Text, ".", "") + " and c.DESCRIPCION='" + txtProducto.Text.ToString + "'"
    '    End If
    '    conexiones.abrir()
    '    Dim command As SqlCommand = New SqlCommand(datos, conexiones._conexion)

    '    Dim reader As SqlDataReader = command.ExecuteReader()
    '    If reader.HasRows Then
    '        Do While reader.Read()
    '            'TASA REAL
    '            'TASA QUEDA POR DEFECTO SEGUN TASAS_RANGOS
    '            tasanueva = reader(0).ToString
    '            txtTasaReal.Text = Decimal.Round(Decimal.Parse(reader(0).ToString), 2)
    '            'SI EL PRODUCTO ADMITE EL AUMENTO DE TASA SE AGREGA EN CASO CONTRARIO DE DEJA LA REAL
    '            'If permite_aumento_tasa = 1 Then
    '            '    txtTasaCastigada.Text = "SI"
    '            '    txtTasaFinal.Text = Decimal.Round(Decimal.Parse(tasanueva), 2)
    '            'Else
    '            '    txtTasaCastigada.Text = "NO"
    '            '    txtTasaFinal.Text = Decimal.Round(Decimal.Parse(txtTasaCastigada.Text), 2)
    '            'End If
    '        Loop
    '    End If
    '    reader.Close()
    '    conexiones.cerrar()
    '    If (tasanueva = "") Then
    '        MsgBox("El monto no esta dentro del rango del producto solicitado ")
    '        TASASALTAS = "NO"
    '        Return
    '    Else


    '        'Dim tasaConsumo As String = ""
    '        'Dim tasaCompraDeCartera As String = ""

    '        'Dim conexiones1 As New CConexion
    '        'conexiones1.conexion()
    '        'Dim command1 As SqlCommand = New SqlCommand("IF EXISTS (SELECT [TASACONSUMO], [TASACOMPRACARTERA] FROM [_FORMAPAGO_CONVENIO_TASAS] AS CC1 INNER JOIN (SELECT CODINS, MAX(ID_TABLA) AS ID_TABLA FROM _FORMAPAGO_CONVENIO_TASAS GROUP BY CODINS) AS CC2 ON CC1.CODINS=CC2.CODINS AND CC1.ID_TABLA=CC2.ID_TABLA WHERE CC1.CODINS IN (SELECT CODFOR FROM [_FORMAPAGO] WHERE [DESCRIPCION] ='" + CboFormaDePago2.SelectedItem.ToString.Trim + "' and vigente = 1)) BEGIN SELECT [TASACONSUMO],[TASACOMPRACARTERA]FROM [_FORMAPAGO_CONVENIO_TASAS] AS CC1 INNER JOIN (SELECT CODINS, MAX(ID_TABLA) AS ID_TABLA FROM _FORMAPAGO_CONVENIO_TASAS GROUP BY CODINS) AS CC2 ON CC1.CODINS=CC2.CODINS AND CC1.ID_TABLA=CC2.ID_TABLA WHERE CC1.CODINS IN (SELECT CODFOR FROM [_FORMAPAGO] WHERE [DESCRIPCION] ='" + CboFormaDePago2.SelectedItem.ToString.Trim + "' and vigente = 1) END ELSE SELECT 0,0 ", conexiones1._conexion)
    '        'conexiones1.abrir()
    '        'Dim reader1 As SqlDataReader = command1.ExecuteReader()


    '        'If reader1.HasRows Then
    '        '    Do While reader1.Read()
    '        '        tasaConsumo = reader1(0).ToString
    '        '        tasaCompraDeCartera = reader1(1).ToString
    '        '    Loop
    '        'Else
    '        'End If
    '        'reader1.Close()
    '        ''conexiones1.cerrar()



    '        'If tasaConsumo <> "0" And CboObjetivo.SelectedItem.ToString <> "Compra de cartera" Then
    '        '    txtTasaConvenio.Text = tasaConsumo
    '        'ElseIf tasaCompraDeCartera <> "0" And CboObjetivo.SelectedItem.ToString = "Compra de cartera" Then
    '        '    txtTasaConvenio.Text = tasaCompraDeCartera
    '        'End If


    '        'MODIFICACIONES DE TASAS MANUAL

    '        'MODIFICACIONES DE TASAS MANUAL
    '        If (cboTasaSolicitada.Enabled = True And cboTasaSolicitada.SelectedItem <> "Por Defecto Sistema") Then
    '            'DEBE SER POR PLANILLA LAS TASAS O REALIZADAS POR CARLOS BOMBAL
    '            If (CboFormaDePago.SelectedItem.ToString = "PLANILLA" Or CboEjecutivo.SelectedItem.ToString.Trim = "CARLOS BOMBAL SEREY" Or CboEjecutivo.SelectedItem.ToString.Trim = "LILIAN BARRIOS RAMIREZ" Or CboEjecutivo.SelectedItem.ToString.Trim = "CAROLINA JARAMILLO IGNES" Or CboEjecutivo.SelectedItem.ToString.Trim = "PRISCILA MATELUNA JORQUERA") Then
    '                txtTasaSolicitada.Text = cboTasaSolicitada.SelectedItem.ToString
    '            Else
    '                MsgBox("En el convenio la forma de pago debe ser por planilla para modificar su tasa predeterminada")
    '            End If
    '        End If




    '        'CAMPO EXCLUSIVO PARA CAMPAÑA CREDITO ANIVERSARIO
    '        If CboProducto.SelectedItem.ToString.Trim = "ANIVERSARIO" Then
    '            If CboReferencias.SelectedItem.ToString.Trim = "0" Then
    '                MsgBox("De acuerdo a lo establecido para este tipo de producto y referencias la tasa es de 1,5")
    '                txtConvenio.Text = "1,5"
    '            ElseIf CboReferencias.SelectedItem.ToString.Trim = "1" Then
    '                MsgBox("De acuerdo a lo establecido para este tipo de producto y referencias la tasa BAJA a 1,4")
    '                txtConvenio.Text = "1,5"
    '            ElseIf CboReferencias.SelectedItem.ToString.Trim = "2" Then
    '                MsgBox("De acuerdo a lo establecido para este tipo de producto y referencias la tasa BAJA a 1,3")
    '                txtConvenio.Text = "1,5"
    '            ElseIf CboReferencias.SelectedItem.ToString.Trim = "3" Then
    '                MsgBox("De acuerdo a lo establecido para este tipo de producto y referencias la tasa BAJA a 1,2")
    '                txtConvenio.Text = "1,5"
    '            End If
    '        ElseIf CboProducto.SelectedItem.ToString.Trim = "REFERENCIADO" Then
    '            MsgBox("De acuerdo a lo establecido para este tipo de producto y referencias la tasa BAJA a 1,3")
    '            txtConvenio.Text = "1,5"
    '        End If




    '        Dim monto As Double = Double.Parse(TxtMonto.Text)
    '        Dim interes As Double = 0
    '        'PRIORIDAD TASA SOLICITADA , TASA CONVENIO Y FINALMENTE TASA REAL
    '        If txtTasaSolicitada.Text <> 0 Then
    '            interes = txtTasaSolicitada.Text / 100
    '            txtTasaSolicitada.BackColor = Color.Green
    '            txtTasaFinal.Text = txtTasaSolicitada.Text
    '            'ElseIf txtTasaConvenio.Text <> 0 Then
    '            '    interes = txtTasaConvenio.Text / 100
    '            '    txtTasaConvenio.BackColor = Color.Green
    '            '    txtTasaFinal.Text = txtTasaConvenio.Text
    '        Else
    '            interes = txtTasaReal.Text / 100
    '            txtTasaReal.BackColor = Color.Green
    '            txtTasaFinal.Text = txtTasaReal.Text
    '        End If



    '        Dim diasgracia As Double = Double.Parse(CboDiasdeGracia.SelectedItem)
    '        Dim plazo As Double = Double.Parse(CboCuotas.SelectedItem)


    '        Dim Cargodiasdegracia As Double = Decimal.Round(((monto * interes) * diasgracia) / 30)
    '        Dim InteresAplicado As Double = Decimal.Round(plazo * (monto + Cargodiasdegracia) * (1 / ((((1 - (1 / ((1 + (interes)) ^ plazo)))) / (interes)))) - (monto + Cargodiasdegracia))
    '        Dim InteresAplicadoder1 As Double = Decimal.Round(plazo * (Cargodiasdegracia) * (1 / ((((1 - (1 / ((1 + (interes)) ^ plazo)))) / (interes)))) - (Cargodiasdegracia))
    '        Dim InteresAplicadoder2 As Double = Decimal.Round((Cargodiasdegracia + InteresAplicadoder1) / plazo)

    '        Dim SaldoPrestamo As Double = Decimal.Round(monto + Cargodiasdegracia + InteresAplicado)
    '        Dim Dividendo As Double = Decimal.Round((monto + Cargodiasdegracia + InteresAplicado) / plazo)
    '        Dim InteresTabla As Double = Decimal.Round((monto * interes) + InteresAplicadoder2)
    '        Dim Capital As Double = Decimal.Round(Dividendo - InteresTabla)
    '        Dim SaldoMonto As Double = Decimal.Round(monto - Capital)

    '        TxtCuota.Text = Format(Double.Parse(Dividendo), "#,##0")

    '        For i = 1 To Integer.Parse(plazo)
    '            Me.DgAmortizacion.Rows.Add()
    '        Next

    '        Dim nrocuotas As Integer = 1

    '        For i = 0 To (Integer.Parse(plazo) - 1)

    '            DgAmortizacion.Rows(i).Cells(0).Value() = nrocuotas
    '            DgAmortizacion.Rows(i).Cells(1).Value() = TxtCuota.Text
    '            nrocuotas = nrocuotas + 1

    '        Next



    '        'CAPITAL
    '        DgAmortizacion.Rows(0).Cells(2).Value() = Capital
    '        'INTERES
    '        DgAmortizacion.Rows(0).Cells(3).Value() = InteresTabla
    '        'DEUDA
    '        DgAmortizacion.Rows(0).Cells(4).Value() = SaldoMonto
    '        'saldo prestamo
    '        DgAmortizacion.Rows(0).Cells(5).Value() = SaldoPrestamo


    '        Dim v As Integer = 0

    '        For i = 1 To (Integer.Parse(CboCuotas.SelectedItem) - 1)

    '            DgAmortizacion.Rows(i).Cells(5).Value() = Decimal.Round(DgAmortizacion.Rows(v).Cells(5).Value()) - Decimal.Round(DgAmortizacion.Rows(v).Cells(1).Value())
    '            DgAmortizacion.Rows(i).Cells(3).Value() = Decimal.Round(((Decimal.Round(DgAmortizacion.Rows(v).Cells(4).Value())) * interes) + InteresAplicadoder2)
    '            DgAmortizacion.Rows(i).Cells(2).Value() = Decimal.Round(DgAmortizacion.Rows(i).Cells(1).Value()) - Decimal.Round(DgAmortizacion.Rows(i).Cells(3).Value())
    '            DgAmortizacion.Rows(i).Cells(4).Value() = Decimal.Round(DgAmortizacion.Rows(v).Cells(4).Value()) - Decimal.Round(DgAmortizacion.Rows(i).Cells(2).Value())
    '            v = v + 1

    '        Next

    '        DgAmortizacion.Rows(Integer.Parse(CboCuotas.SelectedItem) - 1).Cells(1).Value() = Integer.Parse(Replace(TxtCuota.Text, ".", "")) + DgAmortizacion.Rows(Integer.Parse(CboCuotas.SelectedItem) - 1).Cells(4).Value()
    '        DgAmortizacion.Rows(Integer.Parse(CboCuotas.SelectedItem) - 1).Cells(4).Value() = 0

    '        BtnCalcular.BackColor = Color.Transparent

    '        BtnCalcular.BackColor = Color.White

    '        txtProducto2.Text = txtProducto.Text.Trim

    '    End If
    '    TASASALTAS = "SI"
    'End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        DFechaInicio.Format = DateTimePickerFormat.Custom
        DFechaInicio.CustomFormat = "MM/yyyy"
    End Sub

    Private Sub Button2_Click_2(sender As Object, e As EventArgs)

    End Sub

    'Private Sub txtDisponible_TextChanged(sender As Object, e As EventArgs) Handles txtDisponible.TextChanged
    '    txtDisponible.Text = Puntos(txtDisponible.Text)
    '    txtDisponible.Select(txtDisponible.Text.Length, 0)
    'End Sub

    'Private Sub txtDisponible_KeyUp(sender As Object, e As KeyEventArgs) Handles txtDisponible.KeyUp
    '    txtDisponible.Text = Puntos(txtDisponible.Text)
    '    txtDisponible.Select(txtDisponible.Text.Length, 0)
    'End Sub

    Private Sub cboAtencion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAtencion.SelectedIndexChanged
        If (cboAtencion.SelectedItem = "") Then
            cboAtencion.BackColor = Color.MistyRose
        Else
            cboAtencion.BackColor = Color.White
        End If
    End Sub
    Sub CARGARDATOSAMORTIZACION()
        Dim totalfilas2 As Integer = DgAmortizacion2.RowCount - 1

        DgAmortizacion.Rows.Clear()

        For i = 0 To totalfilas2
            If DgAmortizacion2.Rows(i).Cells("TIPOREG").Value() = "40" Then
                DgAmortizacion.Rows.Add(DgAmortizacion2.Rows(i).Cells("CUOTA_REAL").Value(), DgAmortizacion2.Rows(i).Cells("FECHA_REAL").Value(), DgAmortizacion2.Rows(i).Cells("DIVIDENDO").Value(), DgAmortizacion2.Rows(i).Cells("SALDOCAPITAL").Value())
            End If
        Next


        txtFechaInicio.Text = DgAmortizacion.Rows(1).Cells("FECHA").Value.ToString.Trim
        TxtCuota.Text = DgAmortizacion.Rows(1).Cells(2).Value.ToString.Trim
        txtUltimaCuota.Text = DgAmortizacion.Rows(DgAmortizacion.RowCount - 2).Cells(2).Value.ToString.Trim
        If CboProducto.SelectedItem = "CUOTON" Then
            TxtMonto.Text = Puntos(DgAmortizacion.Rows(0).Cells(3).Value.ToString.Trim)
        End If
        'If TxtMonto.Text = "0" Then
        '    TxtMonto.Text = Puntos(DgAmortizacion.Rows(0).Cells(3).Value.ToString.Trim)
        'End If
        If CboFormaDePago2.SelectedItem = "Senado CJ" Or CboFormaDePago2.SelectedItem = "Senado ANEF" Then
            TxtMonto.Text = Puntos(DgAmortizacion.Rows(0).Cells(3).Value.ToString.Trim)
        End If

    End Sub

    Private Sub Button1_Click_4(sender As Object, e As EventArgs) Handles Button1.Click
        recalcularprestamo()
    End Sub

    Private Sub TxtDisponible2_TextChanged(sender As Object, e As EventArgs) Handles TxtDisponible2.TextChanged
        If TxtDisponible2.Text = "" Then
            TxtDisponible2.Text = "0"
        End If
        If TxtDisponible2.Text = "0" Then
            TxtDisponible2.BackColor = Color.MistyRose
        Else
            TxtDisponible2.BackColor = Color.White
        End If
    End Sub

    Private Sub TxtDisponible2_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtDisponible2.KeyUp
        TxtDisponible2.Text = Puntos(TxtDisponible2.Text)
        TxtDisponible2.Select(TxtDisponible2.Text.Length, 0)
    End Sub
End Class