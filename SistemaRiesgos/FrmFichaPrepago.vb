Imports System.Data.SqlClient

Public Class FrmFichaPrepago
    Dim id As String = frmCreditosPorAprobar.txtid.Text
    Private Sub FrmFichaPrepago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCodigoId.Text = frmCreditosPorAprobar.txtid.Text
        TXTUSUARIO.Text = frmPerfil.CbmUsuario.SelectedItem.ToString

        Dim conexiones3 As New CConexion
        conexiones3.conexion()
        Dim command3 As SqlCommand = New SqlCommand("SELECT  [ID_SOLICITUD],[Atencion],cc1.NROSOCIO,[MONTO_SOLICITADO],[Ejecutivo] ,[Sede],cc1.Estado,[Aprobacion_Operaciones],[Fecha_Solicitud],[CORRELATIVO],cc1.CORCREDITO,[CANTCUOTAS],[NUEVOCAPITAL],[ANOMESPAGO],[INCHACAPITAL],cc2.PLAZO,cc2.MONTOPRESTAMO,cc2.FORMAPAGO,cc2.NOMBRECREDITO,cc2.TAZAINTERES,CC3.*,(SELECT TOP (1) [DIVIDENDO_NEW] FROM _PREPAGO_PARCIAL_DETALLE where ID_SOLICITUD=cc1.ID_SOLICITUD and DIVIDENDO_NEW<>0  order by CUOTANRO desc) as dividendo , cc2.PRIMERDIVIDENDO FROM _RIESGO_SOLICITUD_PREPAGO as cc1 inner join (select _PRESTDIARIO.* , _FORMAPAGO.DESCRIPCION AS FORMAPAGO, _NOMBRECREDITO.DESCRIPCION AS NOMBRECREDITO from _PRESTDIARIO inner join _FORMAPAGO on _PRESTDIARIO.FORMADEPAGO=_FORMAPAGO.CODFOR inner join _NOMBRECREDITO on _PRESTDIARIO.RECONSTRU=_NOMBRECREDITO.CODNOM)   as cc2 on cc1.CORCREDITO=cc2.CORCREDITO  inner join (SELECT nrosocio,convert(varchar,[RUT])+'-'+ convert(varchar,[DVRUT]) as RUT,[FechaIng],[FechaNac],[FechaContrato],[Nombres]+' '+[Paterno]+' '+[Materno] AS NOMBRE,[EstadoCivil],_INSTITUCIONES.DESCRIPCION AS INSTITUCION, sexo  FROM [_SOCIOS] left join _INSTITUCIONES on _SOCIOS.CODINST= _INSTITUCIONES.CODINS) as cc3 on cc1.NROSOCIO=cc3.NROSOCIO  where  CC1.id_solicitud='" + id + "'", conexiones3._conexion)
        conexiones3.abrir()
        Dim reader3 As SqlDataReader = command3.ExecuteReader()
        If reader3.HasRows Then
            Do While reader3.Read()


                txtNrosocio2.Text = (reader3("Nrosocio").ToString)
                txtFecha.Text = (reader3("fecha_solicitud").ToString)
                txtProducto.Text = (reader3("NOMBRECREDITO").ToString)
                TxtMonto.Text = Format(Decimal.Round(reader3("monto_solicitado").ToString), "#,##0")
                txtPlazo.Text = (reader3("PLAZO").ToString)
                txtTasaReal.Text = (reader3("TAZAINTERES").ToString)
                txtFormaPago.Text = (reader3("FORMAPAGO").ToString)
                txtEjecutivo.Text = (reader3("Ejecutivo").ToString)
                txtSucursal.Text = (reader3("Sede").ToString)

                txtPValorCuota.Text = Format(Decimal.Round(reader3("INCHACAPITAL").ToString), "#,##0")
                txtPPlazo.Text = Format(Decimal.Round(reader3("CANTCUOTAS").ToString), "#,##0")
                txtPSaldoCapital.Text = Format(Decimal.Round(reader3("NUEVOCAPITAL").ToString), "#,##0")
                txtRut.Text = (reader3("RUT").ToString)
                txtNombre2.Text = (reader3("NOMBRE").ToString)
                Dim ESTADOCIVIL As String = ""
                ESTADOCIVIL = reader3("EstadoCivil").ToString()

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


                txtInstitucion.Text = reader3("INSTITUCION").ToString()

                'txtCargasFamiliares.Text = (reader4(6).ToString)

                'txtProtesto.Text = (reader4(8).ToString)
                'txtRemuneracion.Text = (reader4(9).ToString)
                'txtRut.Text = (reader3("RUT").ToString)
                'txtSexo.Text = (reader3("Sexo").ToString)

                'txtInstitucion.Text = (reader3("Sexo").ToString)
                txtSexo.Text = (reader3("sexo").ToString)
                txtPValorCuota.Text = Format(Decimal.Round(reader3("DIVIDENDO").ToString), "#,##0")

                TxtCuota.Text = Format(Decimal.Round(reader3("PRIMERDIVIDENDO").ToString), "#,##0")
                'TxtCuota.Text = Format(Decimal.Round(reader3("primera_cuota").ToString), "#,##0")
                'txtTasa.Text = (reader3("tasa").ToString)
                'txtDiasGracia.Text = (reader3("dias_gracia").ToString)
                'txtNrocuotas.Text = (reader3("ncreditos").ToString)
                'txtFechaPrimeraCuota.Text = (reader3("fechaprimervencimiento").ToString)
                'txtCapitalAcumulado.Text = (reader3("Monto_capital").ToString)
                'txtCapitalAcumulado.Text = Format(Decimal.Round(reader3("Monto_capital").ToString), "#,##0")
                'txtCuotasPrepagadas.Text = (reader3("Cuotas_prepago").ToString)
                'txtComentarioAgente.Text = (reader3("Comentario_PreAgente").ToString.Trim)
                'txtValidacionAgente.Text = (reader3("PreAprobacion_Agente").ToString.Trim)
                'txtComentarioAgencia.Text = (reader3("Comentario_Agencia2").ToString)
                'txtComentarioAgenciaUser.Text = (reader3("Agencia_Perfil").ToString)
            Loop
        Else
        End If
        reader3.Close()


        CboAprobar.Items.Add("SI")
        CboAprobar.Items.Add("NO")
        CboAprobar.Items.Add("DESCARTADO")


    End Sub

    Private Sub txtComentarioAgencia_KeyUp(sender As Object, e As KeyEventArgs) Handles txtComentarioAgencia.KeyUp
        txtAgencia.Text = 450 - (txtAgencia.Text.Length)
    End Sub

    Private Sub CboAprobar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboAprobar.SelectedIndexChanged

        If Trim(CboAprobar.SelectedItem) = "SI" Or Trim(CboAprobar.SelectedItem) = "RECOMIENDO" Or Trim(CboAprobar.SelectedItem) = "LIBERADO SIN OBJECIONES" Then
            CboAprobar.BackColor = Color.Green
            CboAprobar.ForeColor = Color.White
            txtComentarioAgencia.BackColor = Color.Green
            txtComentarioAgencia.ForeColor = Color.White

        ElseIf Trim(CboAprobar.SelectedItem) = "SI CONDICIONAL" Or Trim(CboAprobar.SelectedItem) = "LIBERADO CON OBJECIONES" Then
            CboAprobar.BackColor = Color.Yellow
            CboAprobar.ForeColor = Color.Black
            txtComentarioAgencia.BackColor = Color.Yellow
            txtComentarioAgencia.ForeColor = Color.Black
        ElseIf Trim(CboAprobar.SelectedItem) = "NO" Or Trim(CboAprobar.SelectedItem) = "NO RECOMIENDO" Then
            CboAprobar.BackColor = Color.Red
            CboAprobar.ForeColor = Color.White
            txtComentarioAgencia.BackColor = Color.Red
            txtComentarioAgencia.ForeColor = Color.White
        ElseIf Trim(CboAprobar.SelectedItem) = "DESCARTADO" Or Trim(CboAprobar.SelectedItem) = "NO VALIDA" Or Trim(CboAprobar.SelectedItem) = "NO LIBERADO" Then

            CboAprobar.BackColor = Color.Black
            CboAprobar.ForeColor = Color.White
            txtComentarioAgencia.BackColor = Color.Black
            txtComentarioAgencia.ForeColor = Color.White
        Else
            CboAprobar.BackColor = Color.White
            txtComentarioAgencia.BackColor = Color.White
            txtComentarioAgencia.ForeColor = Color.Black
        End If

    End Sub

    Private Sub txtAgencia_TextChanged(sender As Object, e As EventArgs) Handles txtAgencia.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        enviar()
    End Sub

    Sub enviar()



        Dim Datos As New CDatos()
        Dim USUARIO As String
        Dim Contrasena As String = ""
        Dim Departamento As String = ""


        USUARIO = frmPerfil.CbmUsuario.SelectedItem
        Datos._id_solicitud = txtCodigoId.Text.ToString





        If (txtComentarioAgencia.Text.Length <= 0) Then
            MsgBox("Se debe agregar algún comentario")
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


                        Dim conexiones3 As New CConexion
                        conexiones3.conexion()

                        Dim command3 As SqlCommand = New SqlCommand("SELECT [Aprobacion_Operaciones],[Agencia_Perfil] FROM [_RIESGO_SOLICITUD_PREPAGO] where [id_solicitud]='" + Datos._id_solicitud.ToString.Trim + "'", conexiones3._conexion)
                        conexiones3.abrir()

                        Dim reader3 As SqlDataReader = command3.ExecuteReader()


                        If reader3.HasRows Then
                            Do While reader3.Read()

                                operaciones_aprueba = Trim(reader3(0).ToString)
                                operaciones_perfil = Trim(reader3(1).ToString)

                            Loop
                        Else
                        End If

                        reader3.Close()



                        If (operaciones_aprueba.ToString.Trim = "Por Analizar") Then

                            If (txtComentarioAgencia.Text.Length > 450) Then
                                MsgBox("El comentario sobrepasa los 450 caracteres")
                            Else
                                Datos._Comentario_Agencia = txtComentarioAgencia.Text
                                Datos._Aprobacion_Operaciones = CboAprobar.SelectedItem.ToString
                                Datos._Agencia_Perfil = frmPerfil.CbmUsuario.SelectedItem

                                If CboAprobar.SelectedItem = "SI" Then
                                    Datos._Estado = "ACEPTADO"
                                ElseIf CboAprobar.SelectedItem = "NO" Then
                                    Datos._Estado = "RECHAZADO"
                                Else
                                    Datos._Estado = "DESCARTADO"
                                End If

                                If Plantillas.Actualizar_Prestamo_enviado_APROBAR_OPERACIONES_PREPAGO(Datos) Then

                                    MsgBox("Credito Actualizado Con exito")

                                    frmCreditosPorAprobar.vercreditos()
                                    Me.Close()

                                Else
                                    MessageBox.Show("Error al consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End If

                        Else

                            MsgBox("Este credito ya fue analizado por :" + operaciones_aprueba.ToString)
                            frmCreditosPorAprobar.CheckBox1.Checked = False

                            Me.Close()
                        End If




                    Else


                        MsgBox("Contraseña incorrecta")



                    End If
                End If

            End If




        End If



    End Sub
End Class