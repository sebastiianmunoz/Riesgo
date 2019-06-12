Imports System.Data
Imports System.Data.SqlClient

Public Class FrmCreditosHistoricos
    Dim plantillas As Metodos = New Metodos
    Dim tabla As New DataTable
    Dim Datos As New CDatos
    'Public VARIABLE As String = "NO"
    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGreditosAprobar.CellClick
        If e.ColumnIndex = 0 Then
            'VARIABLE = "SI"
            'plantillas.CheckForm(frmFichaHistorico)

            If plantillas.EstaAbierto(frmFichaHistorico) Then
                frmFichaHistorico.Close()
            End If

            My.Settings.variableglobal = "Historicos"
            My.Settings.Save()
            My.Forms.frmFichaHistorico.MdiParent = My.Forms.frmRIESGO
            My.Forms.frmFichaHistorico.WindowState = FormWindowState.Normal
            My.Forms.frmFichaHistorico.Location = New Point(0, 0)
            My.Forms.frmFichaHistorico.Show()

            My.Forms.frmFichaHistorico.BringToFront()

            'My.Forms.frmFichaHistorico.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub FrmCreditosHistoricos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ver()
    End Sub

    Sub ver()
        crearcolumna()
        plantillas._tabla.Rows.Clear()
        plantillas._tabla.Columns.Clear()
        If plantillas.Consultar_prestamos_historicos Then
            tabla = plantillas.tabla
            DGreditosAprobar.DataSource = tabla
        End If
        muestra()
        DGreditosAprobar.Columns("Estado").Width = 300
        DGreditosAprobar.Columns("Nombre").Width = 300
    End Sub

    Sub muestra()
        Dim totalcolumnas As Integer = DGreditosAprobar.Columns.Count - 1
        Dim tomadato As String = ""
        For A = 0 To totalcolumnas
            tomadato = Trim(DGreditosAprobar.Columns(A).Name)
            If tomadato <> "btn" And tomadato <> "id_solicitud" And tomadato <> "Nrosocio" And tomadato <> "Nombre" And tomadato <> "Estado" And tomadato <> "Fecha_Solicitud" And tomadato <> "monto_solicitado" And tomadato <> "nrocuotas" And tomadato <> "Sucursal" And tomadato <> "Ejecutiva" And tomadato <> "producto" And tomadato <> "forpago" And tomadato <> "Formadepago2" Then
                DGreditosAprobar.Columns(A).Visible = False
            End If
        Next
    End Sub

    Sub colores()
        Dim totalcolumnas As Integer = DGreditosAprobar.ColumnCount - 1
        Dim totalfilas As Integer = DGreditosAprobar.Rows.Count - 1
        Dim tomadato As String = ""
        Dim estado_solicitud As String = ""



        For A = 0 To totalfilas
            tomadato = Trim(DGreditosAprobar.Rows(A).Cells("Estado").Value())
            If (RTrim(tomadato) = "APROBADO") Then
                For M = 0 To totalcolumnas
                    DGreditosAprobar.Rows(A).Cells(M).Style.BackColor = Color.Green()
                    DGreditosAprobar.Rows(A).Cells(M).Style.ForeColor = Color.White
                Next
            ElseIf (tomadato = "DESCARTADO") Then
                For M = 0 To totalcolumnas
                    DGreditosAprobar.Rows(A).Cells(M).Style.BackColor = Color.Black
                    DGreditosAprobar.Rows(A).Cells(M).Style.ForeColor = Color.White
                Next
            ElseIf (tomadato = "RECHAZADO") Then
                For M = 0 To totalcolumnas
                    DGreditosAprobar.Rows(A).Cells(M).Style.BackColor = Color.Red
                    DGreditosAprobar.Rows(A).Cells(M).Style.ForeColor = Color.White
                Next
            ElseIf (tomadato = "APROBADO CON CONDICIONAL") Then
                For M = 0 To totalcolumnas
                    DGreditosAprobar.Rows(A).Cells(M).Style.BackColor = Color.Yellow
                    DGreditosAprobar.Rows(A).Cells(M).Style.ForeColor = Color.Black
                Next
            Else
                For M = 0 To totalcolumnas
                    DGreditosAprobar.Rows(A).Cells(M).Style.BackColor = Color.Blue
                    DGreditosAprobar.Rows(A).Cells(M).Style.ForeColor = Color.White
                Next
            End If


        Next

    End Sub



    Sub crearcolumna()
        If DGreditosAprobar.Columns.Contains("btn") Then
        Else

            Dim btn As New DataGridViewButtonColumn()
            DGreditosAprobar.Columns.Add(btn)
            btn.HeaderText = "Analisis"
            btn.Text = "Ver"
            btn.Name = "btn"
            btn.UseColumnTextForButtonValue = True
        End If
    End Sub

    Private Sub DGreditosAprobar_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGreditosAprobar.SelectionChanged

        Try

            txtid.Text = ""
            txtEjecutiva.Text = ""
            txtFecha.Text = ""
            txtMonto.Text = ""
            txtNrosocio.Text = ""
            Txtproducto.Text = ""
            txtEstado.Text = ""
            txttiemposCCI.Text = ""
            txttiemposCCS.Text = ""
            txttiempospreagencia.Text = ""
            txttiemposRiesgo.Text = ""
            txttiemposOperaciones.Text = ""
            txttiemposSubgerencia2.Text = ""
            txtTiemposGerencia2.Text = ""
            txtCreditoAsignado.Text = ""



            txtid.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("id_solicitud").Value
            txtNrosocio.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Nrosocio").Value
            txtFecha.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Fecha_Solicitud").Value
            Txtproducto.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("producto").Value
            txtMonto.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("monto_solicitado").Value
            txtEstado.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Estado").Value
            txtEjecutiva.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Ejecutiva").Value
            txtCreditoAsignado.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("corcredito").Value



            txtEstadoPreAgencia.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("PreAprobacion_Agente").Value
            txtEstadoRiesgo.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("PreAprobacion_Riesgo").Value
            txtEstadoAgencia.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Aprobacion_Operaciones").Value
            txtEstadoSubgerencia.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Aprobacion_SubGerencia").Value
            txtEstadogERENCIA.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Aprobacion_Gerencia").Value
            txtEstadoCCI.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Aprobacion_Comision_Credito_Interno").Value
            txtEstadoCCS.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Aprobacion_Comision_Credito_Superior").Value



            txtUsuarioValAgencia.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("PreAgencia_Perfil").Value
            txtUsuarioValRiesgo.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Riesgo_perfil").Value
            txtUsuarioAgencia.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Agencia_Perfil").Value
            txtUsuarioSubgerencia.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Subgerencia_Perfil").Value
            txtUsuarioGerencia.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Gerencia_Perfil").Value
            txtUsuarioCCI.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("CCI_Perfil").Value
            txtUsuarioCCS.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("CCS_perfil").Value


            If txtUsuarioValAgencia.Text.Trim = "" Then
                txttiempospreagencia.Text = 0
            Else
                txttiempospreagencia.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("TIEMPO_PREAGENCIA").Value
            End If


            If txtUsuarioValRiesgo.Text.Trim = "" Then
                txttiemposRiesgo.Text = 0
            Else
                txttiemposRiesgo.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("TIEMPO_RIESGO").Value - txttiempospreagencia.Text
            End If

            If txtUsuarioAgencia.Text.Trim = "" Then
                txttiemposOperaciones.Text = 0
            Else
                txttiemposOperaciones.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("TIEMPO_AGENCIA").Value - txttiempospreagencia.Text - txttiemposRiesgo.Text
            End If

            If txtUsuarioSubgerencia.Text.Trim = "" Then
                txttiemposSubgerencia2.Text = 0
            Else
                txttiemposSubgerencia2.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("TIEMPO_SUBGERENTE").Value - txttiempospreagencia.Text - txttiemposRiesgo.Text
            End If

            If txtTiemposGerencia2.Text.Trim = "" Then
                txtTiemposGerencia2.Text = 0
            Else
                txtTiemposGerencia2.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("TIEMPO_GERENTE").Value - txttiempospreagencia.Text - txttiemposRiesgo.Text - txttiemposSubgerencia2.Text
            End If


            If txtUsuarioCCI.Text.Trim = "" Then
                txttiemposCCI.Text = 0
            Else
                txttiemposCCI.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("TIEMPO_CCI").Value - txttiempospreagencia.Text - txttiemposRiesgo.Text - txttiemposSubgerencia2.Text - txtTiemposGerencia2.Text
            End If



            If txtUsuarioCCS.Text.Trim = "" Then
                txttiemposCCS.Text = 0
            Else
                txttiemposCCS.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("TIEMPO_CCS").Value - txttiempospreagencia.Text - txttiemposRiesgo.Text - txttiemposSubgerencia2.Text - txtTiemposGerencia2.Text - txttiemposCCS.Text
            End If



            txtTiempoTotal.Text = Integer.Parse(txttiempospreagencia.Text) + Integer.Parse(txttiemposRiesgo.Text) + Integer.Parse(txttiemposOperaciones.Text) + Integer.Parse(txttiemposSubgerencia2.Text) + Integer.Parse(txtTiemposGerencia2.Text) + Integer.Parse(txttiemposCCI.Text) + Integer.Parse(txttiemposCCS.Text)

            cargarhoras()



            If Trim(txtEstadoPreAgencia.Text) = "Por Analizar" Then
                txtEstado.Text = "Por Validar Agente"
            End If


            colores2()

        Catch ex As Exception

        End Try


    End Sub
    Sub colores2()


        txtEstadoPreAgencia.BackColor = Color.White
        txtEstadoRiesgo.BackColor = Color.White
        txtEstadoAgencia.BackColor = Color.White
        txtEstadoSubgerencia.BackColor = Color.White
        txtEstadogERENCIA.BackColor = Color.White
        txtEstadoCCI.BackColor = Color.White
        txtEstadoCCS.BackColor = Color.White

        txtUsuarioValAgencia.BackColor = Color.White
        txtUsuarioValRiesgo.BackColor = Color.White
        txtUsuarioAgencia.BackColor = Color.White
        txtUsuarioSubgerencia.BackColor = Color.White
        txtUsuarioGerencia.BackColor = Color.White
        txtUsuarioCCI.BackColor = Color.White
        txtUsuarioCCS.BackColor = Color.White


        txttiempospreagencia.BackColor = Color.White
        txttiemposRiesgo.BackColor = Color.White
        txttiemposOperaciones.BackColor = Color.White
        txttiemposSubgerencia2.BackColor = Color.White
        txtTiemposGerencia2.BackColor = Color.White
        txttiemposCCI.BackColor = Color.White
        txttiemposCCS.BackColor = Color.White

        If txtEstadoPreAgencia.Text.Trim = "No Verifica" Or txtEstadoPreAgencia.Text.Trim = "NO VALIDA" Then
            txtEstadoPreAgencia.BackColor = Color.Silver
            txtUsuarioValAgencia.BackColor = Color.Silver
            txttiempospreagencia.BackColor = Color.Silver

        ElseIf txtEstadoPreAgencia.Text.Trim = "RECOMIENDO" Or txtEstadoPreAgencia.Text.Trim = "SI" Or txtEstadoPreAgencia.Text.Trim = "LIBERADO SIN OBJECIONES" Then
            txtEstadoPreAgencia.BackColor = Color.Green
        ElseIf txtEstadoPreAgencia.Text.Trim = "NO RECOMIENDO" Or txtEstadoPreAgencia.Text.Trim = "SI CONDICIONAL" Or txtEstadoPreAgencia.Text.Trim = "LIBERADO CON OBJECIONES" Or txtEstadoPreAgencia.Text.Trim = "NO VALIDA" Then
            txtEstadoPreAgencia.BackColor = Color.Yellow
        ElseIf txtEstadoPreAgencia.Text.Trim = "DESCARTADO" Or txtEstadoPreAgencia.Text.Trim = "NO" Or txtEstadoPreAgencia.Text.Trim = "NO LIBERADO" Then
            txtEstadoPreAgencia.BackColor = Color.Red

        End If



        If txtEstadoRiesgo.Text.Trim = "No Verifica" Then
            txtEstadoRiesgo.BackColor = Color.Silver
            txtUsuarioValRiesgo.BackColor = Color.Silver
            txttiemposRiesgo.BackColor = Color.Silver

        ElseIf txtEstadoRiesgo.Text.Trim = "RECOMIENDO" Or txtEstadoRiesgo.Text.Trim = "SI" Or txtEstadoRiesgo.Text.Trim = "LIBERADO SIN OBJECIONES" Then
            txtEstadoRiesgo.BackColor = Color.Green
        ElseIf txtEstadoRiesgo.Text.Trim = "NO RECOMIENDO" Or txtEstadoRiesgo.Text.Trim = "SI CONDICIONAL" Or txtEstadoRiesgo.Text.Trim = "LIBERADO CON OBJECIONES" Or txtEstadoRiesgo.Text.Trim = "NO VALIDA" Or txtEstadoRiesgo.Text.Trim = "RECOMIENDO CONDICIONAL" Then
            txtEstadoRiesgo.BackColor = Color.Yellow
        ElseIf txtEstadoRiesgo.Text.Trim = "DESCARTADO" Or txtEstadoRiesgo.Text.Trim = "NO" Or txtEstadoRiesgo.Text.Trim = "NO LIBERADO" Then
            txtEstadoRiesgo.BackColor = Color.Red


        End If



        If txtEstadoAgencia.Text.Trim = "No Verifica" Then
            txtEstadoAgencia.BackColor = Color.Silver
            txtUsuarioAgencia.BackColor = Color.Silver
            txttiemposOperaciones.BackColor = Color.Silver

        ElseIf txtEstadoAgencia.Text.Trim = "RECOMIENDO" Or txtEstadoAgencia.Text.Trim = "SI" Or txtEstadoAgencia.Text.Trim = "LIBERADO SIN OBJECIONES" Then
            txtEstadoAgencia.BackColor = Color.Green
        ElseIf txtEstadoAgencia.Text.Trim = "NO RECOMIENDO" Or txtEstadoAgencia.Text.Trim = "SI CONDICIONAL" Or txtEstadoAgencia.Text.Trim = "LIBERADO CON OBJECIONES" Or txtEstadoAgencia.Text.Trim = "NO VALIDA" Then
            txtEstadoAgencia.BackColor = Color.Yellow
        ElseIf txtEstadoAgencia.Text.Trim = "DESCARTADO" Or txtEstadoAgencia.Text.Trim = "NO" Or txtEstadoAgencia.Text.Trim = "NO LIBERADO" Then
            txtEstadoAgencia.BackColor = Color.Red

        End If



        If txtEstadoSubgerencia.Text.Trim = "No Verifica" Then
            txtEstadoSubgerencia.BackColor = Color.Silver
            txtUsuarioSubgerencia.BackColor = Color.Silver
            txttiemposSubgerencia2.BackColor = Color.Silver

        ElseIf txtEstadoSubgerencia.Text.Trim = "RECOMIENDO" Or txtEstadoSubgerencia.Text.Trim = "SI" Or txtEstadoSubgerencia.Text.Trim = "LIBERADO SIN OBJECIONES" Then
            txtEstadoSubgerencia.BackColor = Color.Green
        ElseIf txtEstadoSubgerencia.Text.Trim = "NO RECOMIENDO" Or txtEstadoSubgerencia.Text.Trim = "SI CONDICIONAL" Or txtEstadoSubgerencia.Text.Trim = "LIBERADO CON OBJECIONES" Or txtEstadoSubgerencia.Text.Trim = "NO VALIDA" Then
            txtEstadoSubgerencia.BackColor = Color.Yellow
        ElseIf txtEstadoSubgerencia.Text.Trim = "DESCARTADO" Or txtEstadoSubgerencia.Text.Trim = "NO" Or txtEstadoSubgerencia.Text.Trim = "NO LIBERADO" Then
            txtEstadoSubgerencia.BackColor = Color.Red


        End If



        If txtEstadogERENCIA.Text.Trim = "No Verifica" Then
            txtEstadogERENCIA.BackColor = Color.Silver
            txtUsuarioGerencia.BackColor = Color.Silver
            txtTiemposGerencia2.BackColor = Color.Silver


        ElseIf txtEstadogERENCIA.Text.Trim = "RECOMIENDO" Or txtEstadogERENCIA.Text.Trim = "SI" Or txtEstadogERENCIA.Text.Trim = "LIBERADO SIN OBJECIONES" Then
            txtEstadogERENCIA.BackColor = Color.Green
        ElseIf txtEstadogERENCIA.Text.Trim = "NO RECOMIENDO" Or txtEstadogERENCIA.Text.Trim = "SI CONDICIONAL" Or txtEstadogERENCIA.Text.Trim = "LIBERADO CON OBJECIONES" Or txtEstadogERENCIA.Text.Trim = "NO VALIDA" Then
            txtEstadogERENCIA.BackColor = Color.Yellow
        ElseIf txtEstadogERENCIA.Text.Trim = "DESCARTADO" Or txtEstadogERENCIA.Text.Trim = "NO" Or txtEstadogERENCIA.Text.Trim = "NO LIBERADO" Then
            txtEstadogERENCIA.BackColor = Color.Red


        End If



        If txtEstadoCCI.Text.Trim = "No Verifica" Then
            txtEstadoCCI.BackColor = Color.Silver
            txtUsuarioCCI.BackColor = Color.Silver
            txttiemposCCI.BackColor = Color.Silver


        ElseIf txtEstadoCCI.Text.Trim = "RECOMIENDO" Or txtEstadoCCI.Text.Trim = "SI" Or txtEstadoCCI.Text.Trim = "LIBERADO SIN OBJECIONES" Then
            txtEstadoCCI.BackColor = Color.Green
        ElseIf txtEstadoCCI.Text.Trim = "NO RECOMIENDO" Or txtEstadoCCI.Text.Trim = "SI CONDICIONAL" Or txtEstadoCCI.Text.Trim = "LIBERADO CON OBJECIONES" Or txtEstadoCCI.Text.Trim = "NO VALIDA" Then
            txtEstadoCCI.BackColor = Color.Yellow
        ElseIf txtEstadoCCI.Text.Trim = "DESCARTADO" Or txtEstadoCCI.Text.Trim = "NO" Or txtEstadoCCI.Text.Trim = "NO LIBERADO" Then
            txtEstadoCCI.BackColor = Color.Red


        End If



        If txtEstadoCCS.Text.Trim = "No Verifica" Then
            txtEstadoCCS.BackColor = Color.Silver
            txtUsuarioCCS.BackColor = Color.Silver
            txttiemposCCS.BackColor = Color.Silver


        ElseIf txtEstadoCCS.Text.Trim = "RECOMIENDO" Or txtEstadoCCS.Text.Trim = "SI" Or txtEstadoCCS.Text.Trim = "LIBERADO SIN OBJECIONES" Then
            txtEstadoCCS.BackColor = Color.Green
        ElseIf txtEstadoCCS.Text.Trim = "NO RECOMIENDO" Or txtEstadoCCS.Text.Trim = "SI CONDICIONAL" Or txtEstadoCCS.Text.Trim = "LIBERADO CON OBJECIONES" Or txtEstadoCCS.Text.Trim = "NO VALIDA" Then
            txtEstadoCCS.BackColor = Color.Yellow
        ElseIf txtEstadoCCS.Text.Trim = "DESCARTADO" Or txtEstadoCCS.Text.Trim = "NO" Or txtEstadoCCS.Text.Trim = "NO LIBERADO" Then
            txtEstadoCCS.BackColor = Color.Red


        End If


    End Sub



    Sub cargarhoras()
        Dim minutos As Integer

        minutos = txtTiempoTotal.Text

        Dim horas As Integer

        While minutos >= 60

            horas = horas + 1

            minutos = minutos - 60

        End While

        Dim textohoras As String = ""
        Dim textominutos As String = ""

        If (horas) = 0 Then
            If minutos < 2 Then
                txtTiempoTotal.Text = minutos & " Minuto "
            Else
                txtTiempoTotal.Text = minutos & " Minutos "
            End If

        ElseIf (horas) = 1 Then
            If minutos < 2 Then
                txtTiempoTotal.Text = horas & " Hora y " & minutos & " Minuto "
            Else
                txtTiempoTotal.Text = horas & " Hora y " & minutos & " Minutos "
            End If


        Else

            If minutos < 2 Then
                txtTiempoTotal.Text = horas & " Horas y " & minutos & " Minuto "
            Else
                txtTiempoTotal.Text = horas & " Horas y " & minutos & " Minutos "
            End If

        End If
    End Sub

    Private Sub txtSucursal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEstado.TextChanged
        If (Trim(txtEstado.Text) = "APROBADO") Then
            txtEstado.BackColor = Color.Green()
        ElseIf (Trim(txtEstado.Text) = "APROBADO SUPERIOR (GER)") Then
            txtEstado.BackColor = Color.Green()
        ElseIf (Trim(txtEstado.Text) = "APROBADO SUPERIOR (SUB)") Then
            txtEstado.BackColor = Color.Green()
        ElseIf (Trim(txtEstado.Text) = "DESCARTADO") Then
            txtEstado.BackColor = Color.Black
        ElseIf (Trim(txtEstado.Text) = "DESCARTADOASALINAS") Then
            txtEstado.BackColor = Color.Black
        ElseIf (Trim(txtEstado.Text) = "DESCARTADOCAGUILAR") Then
            txtEstado.BackColor = Color.Black
        ElseIf (Trim(txtEstado.Text) = "Enviado a Dep.Riesgo") Then
            txtEstado.BackColor = Color.Blue
        ElseIf (Trim(txtEstado.Text) = "Enviado por Dep.riesgo como NO RECOMENDADO") Then
            txtEstado.BackColor = Color.Blue
        ElseIf (Trim(txtEstado.Text) = "Enviado por Dep.riesgo como RECOMENDADO") Then
            txtEstado.BackColor = Color.Blue
        ElseIf (Trim(txtEstado.Text) = "RECHAZADO") Then
            txtEstado.BackColor = Color.Red
        End If
    End Sub

   


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        plantillas._tabla.Rows.Clear()
        plantillas._tabla.Columns.Clear()

        Datos._Nrosocio = Trim(TxtNrosocio2.Text.ToString)

        If plantillas.Consultar_prestamos_historicosXNrosocio(Datos) Then
            tabla = plantillas.tabla
            DGreditosAprobar.DataSource = tabla
        End If

        muestra()
        DGreditosAprobar.Columns("Estado").Width = 300
        DGreditosAprobar.Columns("Nombre").Width = 300


    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click

        ver()
    End Sub


    Private Sub txtCreditoAsignado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCreditoAsignado.TextChanged
        If (Trim(txtCreditoAsignado.Text) <> "") Then
            txtCreditoAsignado.BackColor = Color.Green()
        Else
            txtCreditoAsignado.BackColor = Color.Black
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        plantillas._tabla.Rows.Clear()
        plantillas._tabla.Columns.Clear()

        Datos._Rut = Trim(txtRut.Text.ToString)

        If plantillas.Consultar_prestamos_personales_bandeja_historicosxrut(Datos) Then
            tabla = plantillas.tabla
            DGreditosAprobar.DataSource = tabla
        End If

        muestra()
        DGreditosAprobar.Columns("Estado").Width = 300
        'DGreditosAprobar.Columns("Nombre").Width = 300

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        ver()
    End Sub


    Private Sub DGreditosAprobar_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGreditosAprobar.CellFormatting
        colores()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        plantillas._tabla.Rows.Clear()
        plantillas._tabla.Columns.Clear()

        Datos._id_solicitud = Trim(txtIdSolicitud.Text.ToString)

        If plantillas.Consultar_prestamos_historicosXid(Datos) Then
            tabla = plantillas.tabla
            DGreditosAprobar.DataSource = tabla
        End If

        muestra()
        DGreditosAprobar.Columns("Estado").Width = 300
        DGreditosAprobar.Columns("Nombre").Width = 300
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        plantillas._tabla.Rows.Clear()
        plantillas._tabla.Columns.Clear()

        'Datos._Nombre = Trim(txtNombre.Text.ToString.Trim)

        If plantillas.Consultar_prestamos_historicosXNOMBRE(txtNombre.Text.ToString.Trim) Then
            tabla = plantillas.tabla
            DGreditosAprobar.DataSource = tabla
        End If

        muestra()
        DGreditosAprobar.Columns("Estado").Width = 300
        DGreditosAprobar.Columns("Nombre").Width = 300
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        plantillas._tabla.Rows.Clear()
        plantillas._tabla.Columns.Clear()

        Datos._forpago = Trim(cboForPago.SelectedItem.ToString.Trim)

        If plantillas.Consultar_prestamos_historicosXforpago(Datos) Then
            tabla = plantillas.tabla
            DGreditosAprobar.DataSource = tabla
        End If

        muestra()
        DGreditosAprobar.Columns("Estado").Width = 300
        DGreditosAprobar.Columns("Nombre").Width = 300
    End Sub
End Class