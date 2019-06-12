Imports System.Data
Imports System.Data.SqlClient

Public Class FrmCreditosPropios
    Dim plantillas As Metodos = New Metodos
    Dim tabla As New DataTable
    Dim Datos As New CDatos
    Public VARIABLE As String = "NO"
    Dim tiempo As Integer = 0
    Dim aprobadosnuevos As String = "NO"
    Dim exaprobados As Integer = 0
    Dim tiempomaximo As Integer = 1300
    Dim badeja = "entrada"
    Dim alarma_general As Integer = 0
    Dim contador As Integer = 1

    Sub CargarUsuarios()
        Dim conexiones As New CConexion
        conexiones.conexion()
        Dim command As SqlCommand = New SqlCommand("SELECT USUARIO FROM _RIESGO_PERFIL WHERE USUARIO NOT IN (SELECT USUARIO FROM _RIESGO_PERFIL  WHERE ESTADO='D') and DEPARTAMENTO='OPERACIONES' order by USUARIO", conexiones._conexion)
        conexiones.abrir()
        Dim reader As SqlDataReader = command.ExecuteReader()
        If reader.HasRows Then
            Do While reader.Read()
                cboSegundoUsuario.Items.Add(reader(0).ToString)
            Loop
        Else
        End If

        reader.Close()
    End Sub



    Private Sub FrmCreditosPropios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProgressBar1.Maximum = tiempomaximo
        Timer2.Enabled = True
        Timer2.Interval = 1
        vercreditos()
        CargarUsuarios()
     
        CboSonido.SelectedItem = My.Settings.sonido
    End Sub

    'Sub muestra()
    '    Dim totalcolumnas As Integer = DGreditosAprobar.Columns.Count - 1
    '    Dim tomadato As String = ""
    '    For A = 0 To totalcolumnas
    '        tomadato = Trim(DGreditosAprobar.Columns(A).Name)
    '        If tomadato <> "btn" And tomadato <> "id_solicitud" And tomadato <> "Nrosocio" And tomadato <> "Nombre" And tomadato <> "Estado" And tomadato <> "Fecha_Solicitud" And tomadato <> "monto_solicitado" And tomadato <> "nrocuotas" And tomadato <> "Sucursal" And tomadato <> "Ejecutiva" And tomadato <> "producto" And tomadato <> "forpago" And tomadato <> "Formadepago2" Then
    '            DGreditosAprobar.Columns(A).Visible = False
    '        End If
    '    Next
    'End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGreditosAprobar.CellClick
        If e.ColumnIndex = 0 Then
            If plantillas.EstaAbierto(frmFichaHistorico) Then
                frmFichaHistorico.Close()
            End If
            My.Settings.variableglobal = "Propios"
            My.Settings.Save()

            My.Forms.frmFichaHistorico.MdiParent = My.Forms.frmRIESGO
            My.Forms.frmFichaHistorico.WindowState = FormWindowState.Normal
            My.Forms.frmFichaHistorico.Show()

            My.Forms.frmFichaHistorico.BringToFront()
        ElseIf e.ColumnIndex = 1 Then
            IMPRIMIR()
        ElseIf e.ColumnIndex = 2 Then

            EnviarBandeja()
        End If
    End Sub


    Sub EnviarBandeja()

        If frmPerfil.CbmUsuario.SelectedItem.ToString = txtEjecutivo.Text.Trim Then


            Datos._id_solicitud = txtId.Text
            If badeja = "papelera" Then
                plantillas.Actualizar_prestamos_personales_bandeja_entrada(Datos)
                MsgBox("Credito " + Datos._id_solicitud + " enviado a la bandeja de entrada con exito")
                vercreditos()
            ElseIf badeja = "entrada" Then
                plantillas.Actualizar_prestamos_personales_bandeja_historicos(Datos)
                MsgBox("Credito " + Datos._id_solicitud + " enviado a la bandeja de papelera con exito")
                vercreditos()
            End If
        Else
            MsgBox("Solo puede cambiar de bandeja el ejecutivo creador de la solicitud")
        End If

    End Sub


    Sub muestra()
        Dim totalcolumnas As Integer = DGreditosAprobar.Columns.Count - 1
        Dim tomadato As String = ""
        For A = 0 To totalcolumnas
            tomadato = Trim(DGreditosAprobar.Columns(A).Name)
            If tomadato <> "btn" And tomadato <> "btn2" And tomadato <> "btn3" And tomadato <> "id_solicitud" And tomadato <> "Nombre" And tomadato <> "Fecha_solicitud" And tomadato <> "Nrosocio" And tomadato <> "Estado" And tomadato <> "Fecha_Solicitud" And tomadato <> "Ejecutiva" And tomadato <> "Subperfil" Then
                DGreditosAprobar.Columns(A).Visible = False
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

        If DGreditosAprobar.Columns.Contains("btn2") Then
        Else
            Dim btn As New DataGridViewButtonColumn()
            DGreditosAprobar.Columns.Add(btn)
            btn.HeaderText = "Documento"
            btn.Text = "Imprimir"
            btn.Name = "btn2"
            btn.UseColumnTextForButtonValue = True
        End If
        If DGreditosAprobar.Columns.Contains("btn3") Then
        Else
            Dim btn As New DataGridViewButtonColumn()
            DGreditosAprobar.Columns.Add(btn)
            btn.HeaderText = "Bandeja"
            btn.Text = "Cambiar"
            btn.Name = "btn3"
            btn.UseColumnTextForButtonValue = True
        End If
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

    Private Sub DGreditosAprobar_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGreditosAprobar.CellFormatting
        colores()
    End Sub


    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick



        If (CheckBox1.Checked = False) Then
            tiempo = tiempo + 1

            If (tiempo = tiempomaximo) Then

                If badeja = "entrada" Then

                    vercreditos()

                    If My.Settings.sonido = "Por Defecto" Then
                        If ChkAutoAvisoRiesgo.Checked = True And ChkAutoAvisoRiesgo2.Checked = True Then
                            If 0 < DGreditosAprobar.RowCount Then
                                If alarma_general <> 4 Then
                                    My.Computer.Audio.Play(My.Resources.alarma1, AudioPlayMode.Background)
                                Else
                                    My.Computer.Audio.Play(My.Resources.Beep, AudioPlayMode.Background)
                                    If frmRIESGO.WindowState = 1 Then
                                        frmRIESGO.WindowState = 0
                                    End If
                                End If

                            End If

                        ElseIf ChkAutoAvisoRiesgo.Checked = True And ChkAutoAvisoRiesgo2.Checked = False Then

                            If contador.ToString < DGreditosAprobar.RowCount.ToString Then

                                If alarma_general <> 4 Then
                                    My.Computer.Audio.Play(My.Resources.alarma1, AudioPlayMode.Background)
                                Else
                                    My.Computer.Audio.Play(My.Resources.Beep, AudioPlayMode.Background)
                                    If frmRIESGO.WindowState = 1 Then
                                        frmRIESGO.WindowState = 0
                                    End If
                                End If
                            End If


                        ElseIf ChkAutoAvisoRiesgo.Checked = False And ChkAutoAvisoRiesgo2.Checked = True Then

                            If 0 < DGreditosAprobar.RowCount Then

                                If alarma_general <> 4 Then
                                    My.Computer.Audio.Play(My.Resources.alarma1, AudioPlayMode.Background)
                                Else
                                    My.Computer.Audio.Play(My.Resources.Beep, AudioPlayMode.Background)
                                    If frmRIESGO.WindowState = 1 Then
                                        frmRIESGO.WindowState = 0
                                    End If
                                End If

                            End If

                        End If

                    ElseIf My.Settings.sonido = "Alternativa 1" Then
                        If ChkAutoAvisoRiesgo.Checked = True And ChkAutoAvisoRiesgo2.Checked = True Then
                            If 0 < DGreditosAprobar.RowCount Then
                                If alarma_general <> 4 Then
                                    My.Computer.Audio.Play(My.Resources.alarma2, AudioPlayMode.Background)
                                Else
                                    My.Computer.Audio.Play(My.Resources.Beep, AudioPlayMode.Background)
                                    If frmRIESGO.WindowState = 1 Then
                                        frmRIESGO.WindowState = 0
                                    End If
                                End If

                            End If

                        ElseIf ChkAutoAvisoRiesgo.Checked = True And ChkAutoAvisoRiesgo2.Checked = False Then

                            If contador.ToString < DGreditosAprobar.RowCount.ToString Then

                                If alarma_general <> 4 Then
                                    My.Computer.Audio.Play(My.Resources.alarma2, AudioPlayMode.Background)
                                Else
                                    My.Computer.Audio.Play(My.Resources.Beep, AudioPlayMode.Background)
                                    If frmRIESGO.WindowState = 1 Then
                                        frmRIESGO.WindowState = 0
                                    End If
                                End If
                            End If


                        ElseIf ChkAutoAvisoRiesgo.Checked = False And ChkAutoAvisoRiesgo2.Checked = True Then

                            If 0 < DGreditosAprobar.RowCount Then

                                If alarma_general <> 4 Then
                                    My.Computer.Audio.Play(My.Resources.alarma2, AudioPlayMode.Background)
                                Else
                                    My.Computer.Audio.Play(My.Resources.Beep, AudioPlayMode.Background)
                                    If frmRIESGO.WindowState = 1 Then
                                        frmRIESGO.WindowState = 0
                                    End If
                                End If



                            End If

                        End If



                    ElseIf My.Settings.sonido = "Alternativa 2" Then
                        If ChkAutoAvisoRiesgo.Checked = True And ChkAutoAvisoRiesgo2.Checked = True Then
                            If 0 < DGreditosAprobar.RowCount Then
                                If alarma_general <> 4 Then
                                    My.Computer.Audio.Play(My.Resources.alarma4, AudioPlayMode.Background)
                                Else
                                    My.Computer.Audio.Play(My.Resources.Beep, AudioPlayMode.Background)
                                    If frmRIESGO.WindowState = 1 Then
                                        frmRIESGO.WindowState = 0
                                    End If
                                End If

                            End If

                        ElseIf ChkAutoAvisoRiesgo.Checked = True And ChkAutoAvisoRiesgo2.Checked = False Then

                            If contador.ToString < DGreditosAprobar.RowCount.ToString Then

                                If alarma_general <> 4 Then
                                    My.Computer.Audio.Play(My.Resources.alarma4, AudioPlayMode.Background)
                                Else
                                    My.Computer.Audio.Play(My.Resources.Beep, AudioPlayMode.Background)
                                    If frmRIESGO.WindowState = 1 Then
                                        frmRIESGO.WindowState = 0
                                    End If
                                End If
                            End If


                        ElseIf ChkAutoAvisoRiesgo.Checked = False And ChkAutoAvisoRiesgo2.Checked = True Then

                            If 0 < DGreditosAprobar.RowCount Then

                                If alarma_general <> 4 Then
                                    My.Computer.Audio.Play(My.Resources.alarma4, AudioPlayMode.Background)
                                Else
                                    My.Computer.Audio.Play(My.Resources.Beep, AudioPlayMode.Background)
                                    If frmRIESGO.WindowState = 1 Then
                                        frmRIESGO.WindowState = 0
                                    End If
                                End If



                            End If

                        End If

                    ElseIf My.Settings.sonido = "Alternativa 3" Then
                        If ChkAutoAvisoRiesgo.Checked = True And ChkAutoAvisoRiesgo2.Checked = True Then
                            If 0 < DGreditosAprobar.RowCount Then
                                If alarma_general <> 4 Then
                                    My.Computer.Audio.Play(My.Resources.alarma5, AudioPlayMode.Background)
                                Else
                                    My.Computer.Audio.Play(My.Resources.Beep, AudioPlayMode.Background)
                                    If frmRIESGO.WindowState = 1 Then
                                        frmRIESGO.WindowState = 0
                                    End If
                                End If

                            End If

                        ElseIf ChkAutoAvisoRiesgo.Checked = True And ChkAutoAvisoRiesgo2.Checked = False Then

                            If contador.ToString < DGreditosAprobar.RowCount.ToString Then

                                If alarma_general <> 4 Then
                                    My.Computer.Audio.Play(My.Resources.alarma5, AudioPlayMode.Background)
                                Else
                                    My.Computer.Audio.Play(My.Resources.Beep, AudioPlayMode.Background)
                                    If frmRIESGO.WindowState = 1 Then
                                        frmRIESGO.WindowState = 0
                                    End If
                                End If
                            End If


                        ElseIf ChkAutoAvisoRiesgo.Checked = False And ChkAutoAvisoRiesgo2.Checked = True Then

                            If 0 < DGreditosAprobar.RowCount Then

                                If alarma_general <> 4 Then
                                    My.Computer.Audio.Play(My.Resources.alarma5, AudioPlayMode.Background)
                                Else
                                    My.Computer.Audio.Play(My.Resources.Beep, AudioPlayMode.Background)
                                    If frmRIESGO.WindowState = 1 Then
                                        frmRIESGO.WindowState = 0
                                    End If
                                End If



                            End If

                        End If

                    End If



                    contador = DGreditosAprobar.RowCount


                    If alarma_general >= 4 Then
                        alarma_general = 0
                    Else
                        alarma_general = alarma_general + 1
                    End If


















                End If






            End If
            If (tiempo >= tiempomaximo) Then


                ProgressBar1.Value = 0
                tiempo = 0
            Else
                ProgressBar1.Value = tiempo

            End If

        End If



        'If (CheckBox1.Checked = False) Then


        'tiempo = tiempo + 1

        'If (tiempo = tiempomaximo) Then


        '    If badeja = "entrada" Then


        '        If ChkAutoAvisoRiesgo.Checked = True And ChkAutoAvisoRiesgo2.Checked = True Then
        '            If 0 < DGreditosAprobar.RowCount Then
        '                If alarma_general <> 4 Then
        '                    My.Computer.Audio.Play(My.Resources.alarma1, AudioPlayMode.Background)
        '                Else
        '                    My.Computer.Audio.Play(My.Resources.Beep, AudioPlayMode.Background)
        '                    If frmRIESGO.WindowState = 1 Then
        '                        frmRIESGO.WindowState = 0
        '                    End If
        '                End If

        '            End If

        '            contador = DGreditosAprobar.RowCount

        '            If alarma_general >= 4 Then
        '                alarma_general = 0
        '            Else
        '                alarma_general = alarma_general + 1
        '            End If


        '        vercreditos()

        '        ProgressBar1.Value = 0
        '        tiempo = 0

        '        If (chkAviso.Checked = True) Then

        '            My.Computer.Audio.Play(My.Resources.alarma1, AudioPlayMode.Background)
        '            If frmRIESGO.WindowState = 1 Then
        '                frmRIESGO.WindowState = 0
        '            End If

        '        End If
        '    Else
        '        ProgressBar1.Value = 0
        '        tiempo = 0

        '        End If
        '    Else
        'ProgressBar1.Value = tiempo
        '    End If



        'End If
    End Sub


    Sub vercreditos2()
        crearcolumna()

        Datos._Ejecutiva = frmPerfil.CbmUsuario.SelectedItem.ToString
        Datos._Nrosocio = txtNrosocio2.Text.ToString.Trim
        'frmPerfil.CbmUsuario.SelectedItem = "CCAMPOS" Or
        If (frmPerfil.CbmUsuario.SelectedItem = "SMUÑOZ" Or frmPerfil.CbmUsuario.SelectedItem = "CAGUILAR" Or frmPerfil.CbmUsuario.SelectedItem = "CCAMPOS" Or frmPerfil.CbmUsuario.SelectedItem = "LBARRIOS(E)" Or frmPerfil.CbmUsuario.SelectedItem = "PMATELUNA(E)" Or frmPerfil.CbmUsuario.SelectedItem = "MNAVARRETE(A)" Or frmPerfil.CbmUsuario.SelectedItem = "PMATELUNA") Then
            plantillas._tabla.Rows.Clear()
            plantillas._tabla.Columns.Clear()
            If plantillas.Consultar_prestamos_personales_bandejaxnrosocio(Datos) Then
                tabla = plantillas.tabla
                DGreditosAprobar.DataSource = tabla

            End If
        Else
            plantillas._tabla.Rows.Clear()
            plantillas._tabla.Columns.Clear()
            Datos._Ejecutiva = frmPerfil.CbmUsuario.SelectedItem.ToString
            If plantillas.Consultar_prestamos_personales_bandeja_entradaxnrosocio(Datos) Then
                tabla = plantillas.tabla
                DGreditosAprobar.DataSource = tabla
            End If

        End If
        muestra()
        'DGreditosAprobar.Columns("Estado").Width = 300
        'Dim conexiones3 As New CConexion
        'conexiones3.conexion()
        'Dim command3 As SqlCommand = New SqlCommand("SELECT ISNULL(count(*),0) FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where RTRIM([Ejecutiva])=RTRIM('" + Datos._Ejecutiva + "')  and estado IN ('APROBADO','APROBADO CON CONDICIONAL','APROBADO SUPERIOR (GER)') ", conexiones3._conexion)
        'conexiones3.abrir()
        'Dim reader3 As SqlDataReader = command3.ExecuteReader()

        'If reader3.HasRows Then
        '    Do While reader3.Read()
        '        txtBandeja.Text = reader3(0).ToString
        '    Loop
        'Else
        'End If

        'reader3.Close()
        'muestra()

        DGreditosAprobar.Columns("Estado").Width = 300
        DGreditosAprobar.AllowUserToAddRows = False
    End Sub

    Sub vercreditos()
        crearcolumna()

        Datos._Ejecutiva = frmPerfil.CbmUsuario.SelectedItem.ToString
        If (frmPerfil.CbmUsuario.SelectedItem = "SMUÑOZ" Or frmPerfil.CbmUsuario.SelectedItem = "LBARRIOS(E)" Or frmPerfil.CbmUsuario.SelectedItem = "PMATELUNA(E)" Or frmPerfil.CbmUsuario.SelectedItem = "CCAMPOS" Or frmPerfil.CbmUsuario.SelectedItem = "PMATELUNA") Then
            plantillas._tabla.Rows.Clear()
            plantillas._tabla.Columns.Clear()
            If plantillas.Consultar_prestamos_personales_bandeja Then
                tabla = plantillas.tabla
                DGreditosAprobar.DataSource = tabla
            End If
        Else
            plantillas._tabla.Rows.Clear()
            plantillas._tabla.Columns.Clear()
            Datos._Ejecutiva = frmPerfil.CbmUsuario.SelectedItem.ToString
            If plantillas.Consultar_prestamos_personales_bandeja_entrada(Datos) Then
                tabla = plantillas.tabla
                DGreditosAprobar.DataSource = tabla
            End If

            DGreditosAprobar.AllowUserToAddRows = False

        End If
        muestra()
        DGreditosAprobar.Columns("Estado").Width = 300
        'Dim conexiones3 As New CConexion
        'conexiones3.conexion()
        'Dim command3 As SqlCommand = New SqlCommand("SELECT ISNULL(count(*),0) FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where RTRIM([Ejecutiva])=RTRIM('" + Datos._Ejecutiva + "')  and estado IN ('APROBADO','APROBADO CON CONDICIONAL','APROBADO SUPERIOR (GER)') ", conexiones3._conexion)
        'conexiones3.abrir()
        'Dim reader3 As SqlDataReader = command3.ExecuteReader()

        'If reader3.HasRows Then
        '    Do While reader3.Read()
        '        txtBandeja.Text = reader3(0).ToString
        '    Loop
        'Else
        'End If
        'reader3.Close()

        'muestra()
        'DGreditosAprobar.Columns("Estado").Width = 300

        DGreditosAprobar.AllowUserToAddRows = False
    End Sub




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        FCertificados.Show()
    End Sub




    Private Sub DGreditosAprobar_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGreditosAprobar.SelectionChanged

        Try
            txtId.Text = ""
            txtnrosocio.Text = ""
            txtEstado.Text = ""
            txtCondicional.Text = ""
            txtValidaAgente.Text = ""
            txtId.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("id_solicitud").Value
            txtnrosocio.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Nrosocio").Value
            txtEstado.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Estado").Value
            txtValidaAgente.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("PreAprobacion_Agente").Value
            txtEjecutivo.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Ejecutiva").Value
            txtSubAsignado.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Subperfil").Value
            txtCondicional.Text = NotNull(DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("condicional").Value, "")
            If Trim(txtValidaAgente.Text) = "Por Analizar" Then
                txtEstado.Text = "Por Validar Agente"
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Public Shared Function NotNull(Of T)(ByVal Value As T, ByVal DefaultValue As T) As T
        If Value Is Nothing OrElse IsDBNull(Value) Then
            Return DefaultValue
        Else
            Return Value
        End If
    End Function

    Private Sub txtEstado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
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



    Sub IMPRIMIR()
        Dim id As String = ""

        id = Trim(txtId.Text.ToString)


        Dim conexiones3 As New CConexion
        conexiones3.conexion()
        Dim command3 As SqlCommand = New SqlCommand("SELECT  * FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where  id_solicitud='" + id + "'", conexiones3._conexion)
        conexiones3.abrir()
        Dim reader3 As SqlDataReader = command3.ExecuteReader()


        If reader3.HasRows Then
            Do While reader3.Read()


                If (Trim((reader3("nrosocio").ToString)) = Trim(reader3("Presocio").ToString)) Then

                    MsgBox("No es posible imprimir un PRE-SOCIO, favor realice el cambio a SOCIO en Sistema de Cuentas Corrientes")
                ElseIf (Trim((reader3("corcredito").ToString)) = "") Then
                    MsgBox("No es posible imprimir, favor realice la solicitud con el id solicitud correspondiente en el Sistema de Cuentas Corrientes")
                Else
                    FCertificados.Show()
                End If


            Loop
        Else
        End If

        reader3.Close()
    End Sub






    Private Sub txtEstado_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEstado.TextChanged
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
            If Trim(txtValidaAgente.Text) = "Por Analizar" Then
                txtEstado.Text = "Por Validar Agente"
            End If
            txtEstado.BackColor = Color.Blue
        ElseIf (Trim(txtEstado.Text) = "Enviado por Dep.riesgo como NO RECOMENDADO") Then
            txtEstado.BackColor = Color.Blue
        ElseIf (Trim(txtEstado.Text) = "Enviado por Dep.riesgo como RECOMENDADO") Then
            txtEstado.BackColor = Color.Blue
        ElseIf (Trim(txtEstado.Text) = "RECHAZADO") Then
            txtEstado.BackColor = Color.Red
        End If

    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)







    End Sub


    Sub VER()
        'VARIABLE = "SI"
        If plantillas.EstaAbierto(frmFichaHistorico) Then
            frmFichaHistorico.Close()
        End If

        My.Settings.variableglobal = "Propios"
        My.Settings.Save()

        My.Forms.frmFichaHistorico.MdiParent = My.Forms.frmRIESGO
        My.Forms.frmFichaHistorico.WindowState = FormWindowState.Normal
        My.Forms.frmFichaHistorico.Show()

        My.Forms.frmFichaHistorico.BringToFront()
    End Sub




    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click



        If (txtNrosocio2.Text = "") Then
            MsgBox("No se ha especificado un nrosocio, se mostraran todos los Socios asociados")
            vercreditos()
        Else
            vercreditos2()
        End If



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


    
        If frmPerfil.CbmUsuario.SelectedItem.ToString = txtEjecutivo.Text.Trim Then

            Datos._id_solicitud = txtId.Text

            Datos._Perfil = cboSegundoUsuario.SelectedItem.ToString


            Dim RECIBERESPUESTA As DialogResult
            RECIBERESPUESTA = MessageBox.Show("¿Desea sub-asignar id " + Datos._id_solicitud + " al perfil " + Datos._Perfil + "", "SUB-ASIGNACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If RECIBERESPUESTA = Windows.Forms.DialogResult.Yes Then
                If plantillas.Actualizar_Segundo_Perfil(Datos) Then
                    MsgBox("Enviado con exito")
                End If
                vercreditos()
            Else
                MsgBox("Cancelado por el usuario")
            End If
        Else
            MsgBox("Solo puede asignar un sub-perfil el ejecutivo que ha solicitado el credito")
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles BtnPapelera.Click
        BtnPapelera.ForeColor = Color.ForestGreen
        BtnEntrada.ForeColor = Color.Gray
        plantillas._tabla.Rows.Clear()
        plantillas._tabla.Columns.Clear()
        Datos._Ejecutiva = frmPerfil.CbmUsuario.SelectedItem.ToString
        If plantillas.Consultar_prestamos_personales_bandeja_historicos(Datos) Then
            tabla = plantillas.tabla
            DGreditosAprobar.DataSource = tabla
        End If
        badeja = "papelera"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles BtnEntrada.Click
        BtnEntrada.ForeColor = Color.ForestGreen
        BtnPapelera.ForeColor = Color.Gray
        plantillas._tabla.Rows.Clear()
        plantillas._tabla.Columns.Clear()
        Datos._Ejecutiva = frmPerfil.CbmUsuario.SelectedItem.ToString
        If plantillas.Consultar_prestamos_personales_bandeja_entrada(Datos) Then
            tabla = plantillas.tabla
            DGreditosAprobar.DataSource = tabla
        End If
        badeja = "entrada"
    End Sub

    Private Sub CboSonido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CboSonido.KeyPress
        e.KeyChar = ""
    End Sub

    Private Sub CboSonido_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboSonido.SelectedIndexChanged

        My.Settings.sonido = CboSonido.SelectedItem.ToString
        My.Settings.Save()
    End Sub
End Class