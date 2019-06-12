Imports System.Data
Imports System.Data.SqlClient

Public Class frmCreditosPorAprobar
    Dim plantillas As Metodos = New Metodos
    Dim tabla As New DataTable
    Dim contador As Integer = 1
    Dim alarma_general As Integer = 0
    Dim Datos As New CDatos
    Dim tiempo As Integer = 0
    Dim tiempomaximo As Integer = 1000


 

    Private Sub frmCreditosPorAprobar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProgressBar1.Maximum = tiempomaximo
        Timer1.Enabled = True
        Timer1.Interval = 1
        vercreditos()
        CboSonido.SelectedItem = My.Settings.sonido

    End Sub

    Sub vercreditos()


        Dim cargo As String = ""
        Dim tipo As String = ""
        Dim ciudad As String = ""
        Dim sucursal As String = ""
        Dim AtributosMuestra As String = ""


        Dim conexiones2 As New CConexion
        conexiones2.conexion()
        Dim command2 As SqlCommand = New SqlCommand("SELECT CARGO, RTRIM([CIUDAD]) as ciudad,RTRIM(NOMBRECAJA) AS SUCURSAL  from  _RIESGO_PERFIL inner join (SELECT * FROM [_SUCURSAL] WHERE VIGENTE=1) as  _SUCURSAL ON _RIESGO_PERFIL.UBICACION=_SUCURSAL.CODCAJA WHERE USUARIO='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "'", conexiones2._conexion)
        'Dim command2 As SqlCommand = New SqlCommand("SELECT CARGO, RTRIM([CIUDAD]) as ciudad,RTRIM(NOMBRECAJA) AS SUCURSAL , ATRIBUTOS_MUESTRA from  _RIESGO_PERFIL inner join (SELECT * FROM [_SUCURSAL] WHERE VIGENTE=1) as  _SUCURSAL ON _RIESGO_PERFIL.UBICACION=_SUCURSAL.CODCAJA WHERE USUARIO='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "'", conexiones2._conexion)
        conexiones2.abrir()

        Dim reader2 As SqlDataReader = command2.ExecuteReader()


        If reader2.HasRows Then
            Do While reader2.Read()
                cargo = (reader2(0).ToString)
                ciudad = (reader2(1).ToString)
                sucursal = (reader2(2).ToString)
                'AtributosMuestra = (reader2(3).ToString)
            Loop
        Else
        End If

        reader2.Close()
        conexiones2.cerrar()




        If (Trim(cargo) = "AGENCIA") Then
            tipo = "Aprobacion_Operaciones"
        ElseIf (Trim(cargo) = "SUBGERENTE") Then
            tipo = "Aprobacion_SubGerencia"
        ElseIf (Trim(cargo) = "GERENTE") Then
            tipo = "Aprobacion_Gerencia"
        ElseIf (Trim(cargo) = "COMISIONI") Then
            tipo = "Aprobacion_Comision_Credito_Interno"
        ElseIf (Trim(cargo) = "COMISIONS") Then
            tipo = "Aprobacion_Comision_Credito_Superior"
        ElseIf (Trim(cargo) = "SFINANZAS") Then
            tipo = "Aprobacion_SubGerenciaFinanzas"
        ElseIf (Trim(cargo) = "RIESGO") Then
            tipo = "Aprobacion_RiesgoAnalisis"
        ElseIf (Trim(cargo) = "RIESGO_RENTA") Then
            tipo = "Aprobacion_RiesgoRentaAnalisis"
        End If



        If tipo = "Aprobacion_SubGerencia" Then

            plantillas._tabla.Rows.Clear()
            plantillas._tabla.Columns.Clear()
            If plantillas.Consultar_Creditos_AprobarXSubGerencia() Then
                tabla = plantillas.tabla
                DGreditosAprobar.DataSource = tabla
            End If
            ' se llama al metodo para LA SRTA JESSICA SUPERVISE LAS NOMINA DE TRNASFERENCIAS   
        ElseIf tipo = "Aprobacion_SubGerenciaFinanzas" Then

            plantillas._tabla.Rows.Clear()
            plantillas._tabla.Columns.Clear()
            If plantillas.Consultar_Creditos_Aprobar_Con_Nomina_Transferencia() Then
                tabla = plantillas.tabla
                DGreditosAprobar.DataSource = tabla
            End If

        ElseIf tipo = "Aprobacion_Gerencia" Then

            plantillas._tabla.Rows.Clear()
            plantillas._tabla.Columns.Clear()
            If plantillas.Consultar_Creditos_AprobarXGerencia() Then
                tabla = plantillas.tabla
                DGreditosAprobar.DataSource = tabla
            End If
        ElseIf tipo = "Aprobacion_Operaciones" Then

            plantillas._tabla.Rows.Clear()
            plantillas._tabla.Columns.Clear()
            If plantillas.Consultar_Creditos_AprobarXTipoAgencia(tipo, sucursal, ciudad) Then
                tabla = plantillas.tabla
                DGreditosAprobar.DataSource = tabla
            End If

        ElseIf tipo = "Aprobacion_RiesgoAnalisis" Then

            plantillas._tabla.Rows.Clear()
            plantillas._tabla.Columns.Clear()
            If plantillas.Consultar_Creditos_Riesgo() Then
                tabla = plantillas.tabla
                DGreditosAprobar.DataSource = tabla
            End If
        ElseIf tipo = "Aprobacion_RiesgoRentaAnalisis" Then

            plantillas._tabla.Rows.Clear()
            plantillas._tabla.Columns.Clear()
            If plantillas.Consultar_Creditos_Riesgo_Renta() Then
                tabla = plantillas.tabla
                DGreditosAprobar.DataSource = tabla
            End If
        Else


            plantillas._tabla.Rows.Clear()
            plantillas._tabla.Columns.Clear()
            If plantillas.Consultar_Creditos_AprobarXTipo(tipo) Then
                tabla = plantillas.tabla
                DGreditosAprobar.DataSource = tabla
            End If
        End If


        DGreditosAprobar.AllowUserToAddRows = False


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

        colores(tipo)


        If alarma_general >= 4 Then
            alarma_general = 0
        Else
            alarma_general = alarma_general + 1
        End If


        crearcolumna()


        'Dim totalcolumnas As Integer = DGreditosAprobar.Columns.Count - 1
        'Dim tomadato As String = ""

        'For A = 0 To totalcolumnas
        '    tomadato = Trim(DGreditosAprobar.Columns(A).Name)

        '    If tomadato <> "id_solicitud" And tomadato <> "producto" And tomadato <> "Nrosocio" Then
        '        DGreditosAprobar.Columns(A).Visible = False
        '    End If
        'Next


    End Sub
    Sub crearcolumna()
        If DGreditosAprobar.Columns.Contains("btn") Then
        Else
            '    MsgBox("no")
            'newcol.HeaderText = "SELECCION"
            'newcol.Name = "Nombrecol"
            'newcol.DataPropertyName = "nombre_campo" 'Campo de enlace a datos
            'GridbandejaCapital.Columns.Add(newcol)
            Dim btn As New DataGridViewButtonColumn()
            DGreditosAprobar.Columns.Add(btn)
            btn.HeaderText = "Analisis"
            btn.Text = "Analizar"
            btn.Name = "btn"
            btn.UseColumnTextForButtonValue = True
        End If
    End Sub
    'Sub sacarcolumna()
    '    If DGreditosAprobar.Columns.Contains("btn") Then
    '        DGreditosAprobar.Columns.Remove("btn")
    '    End If


    'End Sub


    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGreditosAprobar.CellClick
        If e.ColumnIndex = 0 Then
            mover()
            verdetalle()
        End If
    End Sub



    'Private Sub DGreditosAprobar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGreditosAprobar.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        verdetalle()
    '    End If
    'End Sub


    Sub mover()
        Try

       
        txtid.Text = ""
        txtEjecutiva.Text = ""
        txtFecha.Text = ""
        txtMonto.Text = ""
        txtNrosocio.Text = ""
        Txtproducto.Text = ""
        txtSucursal.Text = ""
        txtTiempoEspera.Text = ""
            txtValidacionAgente.Text = ""
            txtFueradeZona.Text = ""

        txtid.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("id_solicitud").Value.ToString.Trim
        txtNrosocio.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Nrosocio").Value.ToString.Trim
        txtFecha.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("fecha_solicitud").Value.ToString.Trim
        Txtproducto.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("producto").Value.ToString.Trim
        txtMonto.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("monto_solicitado").Value.ToString.Trim
        txtEjecutiva.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Ejecutiva").Value.ToString.Trim
        txtSucursal.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Sucursal").Value.ToString.Trim
        txtTiempoEspera.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("tiempo").Value.ToString.Trim
        TXTTIEMPOESPERA2.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("tiempo").Value.ToString.Trim
        TXTESTADO.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Estado").Value.ToString.Trim
        txtGerencia.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Aprobacion_Gerencia").Value.ToString.Trim
        txtSubgerencia.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Aprobacion_SubGerencia").Value.ToString.Trim
        txtOperaciones.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Aprobacion_Operaciones").Value.ToString.Trim
        txtCCI.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Aprobacion_Comision_Credito_Interno").Value.ToString.Trim
        txtCCS.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("Aprobacion_Comision_Credito_Superior").Value.ToString.Trim
        txtValidacionAgente.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("PreAprobacion_Agente").Value.ToString.Trim
        txtRiesgo.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("PreAprobacion_Riesgo").Value.ToString.Trim
            txtFueradeZona.Text = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells("FueraDeZona").Value.ToString.Trim
   


            If Trim(txtValidacionAgente.Text) = "Por Analizar" Then
                TXTESTADO.Text = "Por Validar Agente"
            End If


            If Trim(txtFueradeZona.Text) = "" Then
                txtFueradeZona.Text = "No Indica"
            End If

            cargarhoras()
        Catch ex As Exception

        End Try
    End Sub

    Sub cargarhoras()
        Dim minutos As Integer

        minutos = txtTiempoEspera.Text

        Dim horas As Integer

        While minutos >= 60

            horas = horas + 1

            minutos = minutos - 60

        End While

        Dim textohoras As String = ""
        Dim textominutos As String = ""

        If (horas) = 0 Then
            If minutos < 2 Then
                txtTiempoEspera.Text = minutos & " Minuto "
            Else
                txtTiempoEspera.Text = minutos & " Minutos "
            End If

        ElseIf (horas) = 1 Then
            If minutos < 2 Then
                txtTiempoEspera.Text = horas & " Hora y " & vbNewLine & minutos & " Minuto "
            Else
                txtTiempoEspera.Text = horas & " Hora y " & vbNewLine & minutos & " Minutos "
            End If


        Else

            If minutos < 2 Then
                txtTiempoEspera.Text = horas & " Horas y " & vbNewLine & minutos & " Minuto "
            Else
                txtTiempoEspera.Text = horas & " Horas y " & vbNewLine & minutos & " Minutos "
            End If

        End If


        If Integer.Parse(TXTTIEMPOESPERA2.Text) < 25 Then
            txtTiempoEspera.BackColor = Color.Green
        ElseIf Integer.Parse(TXTTIEMPOESPERA2.Text) < 35 And Integer.Parse(TXTTIEMPOESPERA2.Text) >= 25 Then
            txtTiempoEspera.BackColor = Color.Yellow
        Else
            txtTiempoEspera.BackColor = Color.Red
        End If


    End Sub
    Private Sub DGreditosAprobar_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGreditosAprobar.SelectionChanged

        Try

            mover()


        Catch ex As Exception

        End Try

    End Sub
    'Private Sub txtOperaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOperaciones.TextChanged
    '   coloresetapas()
    'End Sub

    'Private Sub txtSubgerencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubgerencia.TextChanged
    ' coloresetapas()
    'End Sub

 

    


    Sub verdetalle()

        'MsgBox(DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells(0).Value.ToString.Trim)
        'If DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells(0).Value.ToString.Trim = "" Then
        '    MsgBox("Debe indicar una solicitud")
        'Else
        If (DGreditosAprobar.RowCount <= 0) Then
            MsgBox("No existen prestamos solicitados")
        ElseIf Trim(Txtproducto.Text) = "GIRO CAPITAL" Then  ' RECONCIDERENCION DON PEDRO
            'CheckBox1.Checked = True
            My.Forms.frmFichaAprobarGiroCapital.MdiParent = My.Forms.frmRIESGO
            My.Forms.frmFichaAprobarGiroCapital.WindowState = FormWindowState.Normal
            My.Forms.frmFichaAprobarGiroCapital.StartPosition = FormStartPosition.CenterScreen
            My.Forms.frmFichaAprobarGiroCapital.Show()
            ' FrmFichaAprobar.txtCodigoId.Text = txtid.Text
        ElseIf Trim(Txtproducto.Text) = "NOMINA GIRO CAPITAL" Then  ' RECONCIDERENCION DON PEDRO" Then
            'CheckBox1.Checked = True
            My.Forms.frmAprobarNominaGiroCapital.MdiParent = My.Forms.frmRIESGO
            My.Forms.frmAprobarNominaGiroCapital.WindowState = FormWindowState.Normal
            My.Forms.frmAprobarNominaGiroCapital.StartPosition = FormStartPosition.CenterScreen
            My.Forms.frmAprobarNominaGiroCapital.Show()
        ElseIf Trim(Txtproducto.Text) = "PREPAGO_PARCIAL" Then
            'CheckBox1.Checked = True
            My.Forms.FrmFichaPrepago.MdiParent = My.Forms.frmRIESGO
            My.Forms.FrmFichaPrepago.WindowState = FormWindowState.Normal
            My.Forms.FrmFichaPrepago.StartPosition = FormStartPosition.CenterScreen
            My.Forms.FrmFichaPrepago.Show()
        ElseIf Trim(Txtproducto.Text) <> "GIRO CAPITAL" And Trim(Txtproducto.Text) <> "NOMINA GIRO CAPITAL" Then
            'CheckBox1.Checked = True
            My.Forms.FrmFichaAprobar.MdiParent = My.Forms.frmRIESGO
            My.Forms.FrmFichaAprobar.WindowState = FormWindowState.Normal
            My.Forms.FrmFichaAprobar.StartPosition = FormStartPosition.CenterScreen
            My.Forms.FrmFichaAprobar.Show()

        End If




        'End If
    End Sub



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        verdetalle()
    End Sub



    Sub colores(ByVal tipo As String)
        Dim totalcolumnas As Integer = DGreditosAprobar.ColumnCount - 1
        Dim totalfilas As Integer = DGreditosAprobar.Rows.Count - 1
        Dim tomadato As String = ""
        Dim tomadato2 As String = ""
        Dim tomadato3 As String = ""
        Dim tomadato4 As String = ""
        Dim estado_solicitud As String = ""


        For A = 0 To totalfilas
            tomadato = Trim(DGreditosAprobar.Rows(A).Cells("producto").Value())
            tomadato2 = Trim(DGreditosAprobar.Rows(A).Cells("PreAprobacion_Agente").Value())
            tomadato3 = Trim(DGreditosAprobar.Rows(A).Cells("Atencion").Value())
            If tipo = "Aprobacion_RiesgoRentaAnalisis" Or tipo = "Aprobacion_RiesgoAnalisis" Then
                tomadato4 = Trim(DGreditosAprobar.Rows(A).Cells("Renta").Value())
            End If

            If tomadato = "GIRO CAPITAL" Then
                    For M = 0 To totalcolumnas
                        DGreditosAprobar.Rows(A).Cells(M).Style.BackColor = Color.LightBlue
                        'DGreditosAprobar.Rows(A).Cells(M).Style.ForeColor = Color.White
                    Next

                ElseIf tomadato = "NOMINA GIRO CAPITAL" Then
                    For M = 0 To totalcolumnas
                        DGreditosAprobar.Rows(A).Cells(M).Style.BackColor = Color.Orange
                        'DGreditosAprobar.Rows(A).Cells(M).Style.ForeColor = Color.White
                    Next

                ElseIf tomadato = "PREPAGO_PARCIAL" Then
                    For M = 0 To totalcolumnas
                        DGreditosAprobar.Rows(A).Cells(M).Style.BackColor = Color.PaleTurquoise
                        'DGreditosAprobar.Rows(A).Cells(M).Style.ForeColor = Color.White
                    Next
                Else
                    For M = 0 To totalcolumnas
                        If tomadato2 = "Por Analizar" Then

                            DGreditosAprobar.Rows(A).Cells(M).Style.BackColor = Color.Yellow
                        Else

                            DGreditosAprobar.Rows(A).Cells(M).Style.BackColor = Color.MediumSeaGreen

                        End If


                        'DGreditosAprobar.Rows(A).Cells(M).Style.ForeColor = Color.
                    Next

                End If

                If tomadato3 = "Presencial" Then

                    DGreditosAprobar.Rows(A).Cells(1).Style.BackColor = Color.LightGray
                    DGreditosAprobar.Rows(A).Cells(1).Style.ForeColor = Color.DarkRed
                Else

                    DGreditosAprobar.Rows(A).Cells(1).Style.BackColor = Color.LightGray

                End If

            If tipo = "Aprobacion_RiesgoRentaAnalisis" Or tipo = "Aprobacion_RiesgoAnalisis" Then

                If tomadato4 = "No" Then
                    DGreditosAprobar.Rows(A).Cells("Renta").Style.BackColor = Color.LightGray
                    DGreditosAprobar.Rows(A).Cells("Renta").Style.ForeColor = Color.DarkRed
                Else
                    DGreditosAprobar.Rows(A).Cells("Renta").Style.BackColor = Color.LightGray
                    DGreditosAprobar.Rows(A).Cells("Renta").Style.BackColor = Color.LightGreen

                End If
            End If

        Next



    End Sub



    Private Sub txtCCI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCCI.TextChanged
        If (Trim(txtCCI.Text) = "NO") Then
            txtCCI.BackColor = Color.Red

        ElseIf (Trim(txtCCI.Text) = "SI") Then
            txtCCI.BackColor = Color.Green

        ElseIf (Trim(txtCCI.Text) = "RECOMIENDO") Then
            txtCCI.BackColor = Color.Green()
        ElseIf (Trim(txtCCI.Text) = "NO RECOMIENDO") Then
            txtCCI.BackColor = Color.Red()
        ElseIf (Trim(txtCCI.Text) = "No Verifica") Then
            txtCCI.BackColor = Color.Gray
        Else
            txtCCI.BackColor = Color.Goldenrod
        End If
    End Sub

    Private Sub txtCCS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCCS.TextChanged
        If (Trim(txtCCS.Text) = "NO") Then
            txtCCS.BackColor = Color.Red

        ElseIf (Trim(txtCCS.Text) = "SI") Then
            txtCCS.BackColor = Color.Green

        ElseIf (Trim(txtCCS.Text) = "RECOMIENDO") Then
            txtCCS.BackColor = Color.Green()
        ElseIf (Trim(txtCCS.Text) = "NO RECOMIENDO") Then
            txtCCS.BackColor = Color.Red()
        ElseIf (Trim(txtCCS.Text) = "No Verifica") Then
            txtCCS.BackColor = Color.Gray
        Else
            txtCCS.BackColor = Color.Goldenrod
        End If
    End Sub


    Private Sub txtGerencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGerencia.TextChanged
        If (Trim(txtGerencia.Text) = "NO") Then
            txtGerencia.BackColor = Color.Red

        ElseIf (Trim(txtGerencia.Text) = "SI") Then
            txtGerencia.BackColor = Color.Green

        ElseIf (Trim(txtGerencia.Text) = "RECOMIENDO") Then
            txtGerencia.BackColor = Color.Green()
        ElseIf (Trim(txtGerencia.Text) = "NO RECOMIENDO") Then
            txtGerencia.BackColor = Color.Red()
        ElseIf (Trim(txtGerencia.Text) = "No Verifica") Then
            txtGerencia.BackColor = Color.Gray
        Else
            txtGerencia.BackColor = Color.Goldenrod
        End If
    End Sub


    Private Sub txtOperaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOperaciones.TextChanged
        If (Trim(txtOperaciones.Text) = "NO") Then
            txtOperaciones.BackColor = Color.Red

        ElseIf (Trim(txtOperaciones.Text) = "SI") Then
            txtOperaciones.BackColor = Color.Green

        ElseIf (Trim(txtOperaciones.Text) = "RECOMIENDO") Then
            txtOperaciones.BackColor = Color.Green()
        ElseIf (Trim(txtOperaciones.Text) = "NO RECOMIENDO") Then
            txtOperaciones.BackColor = Color.Red()
        ElseIf (Trim(txtOperaciones.Text) = "No Verifica") Then
            txtOperaciones.BackColor = Color.Gray
        Else
            txtOperaciones.BackColor = Color.Goldenrod
        End If
    End Sub



    Private Sub txtSubgerencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubgerencia.TextChanged
        If (Trim(txtSubgerencia.Text) = "NO") Then
            txtSubgerencia.BackColor = Color.Red

        ElseIf (Trim(txtSubgerencia.Text) = "SI") Then
            txtSubgerencia.BackColor = Color.Green

        ElseIf (Trim(txtSubgerencia.Text) = "RECOMIENDO") Then
            txtSubgerencia.BackColor = Color.Green()
        ElseIf (Trim(txtSubgerencia.Text) = "NO RECOMIENDO") Then
            txtSubgerencia.BackColor = Color.Red()
        ElseIf (Trim(txtSubgerencia.Text) = "No Verifica") Then
            txtSubgerencia.BackColor = Color.Gray
        Else
            txtSubgerencia.BackColor = Color.Goldenrod
        End If
    End Sub

    Private Sub txtRiesgo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRiesgo.TextChanged
        If (Trim(txtRiesgo.Text) = "NO") Then
            txtRiesgo.BackColor = Color.Red

        ElseIf (Trim(txtRiesgo.Text) = "SI") Then
            txtRiesgo.BackColor = Color.Green

        ElseIf (Trim(txtRiesgo.Text) = "RECOMIENDO") Then
            txtRiesgo.BackColor = Color.Green()
        ElseIf (Trim(txtRiesgo.Text) = "RECOMIENDO CONDICIONAL") Then
            txtRiesgo.BackColor = Color.YellowGreen()
        ElseIf (Trim(txtRiesgo.Text) = "NO RECOMIENDO") Then
            txtRiesgo.BackColor = Color.Red()
        ElseIf (Trim(txtRiesgo.Text) = "No Verifica") Then
            txtRiesgo.BackColor = Color.Gray
        Else
            txtRiesgo.BackColor = Color.Goldenrod
        End If
    End Sub



    Private Sub txtValidacionAgente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValidacionAgente.TextChanged
        If (Trim(txtValidacionAgente.Text) = "DESCARTADO") Then
            txtValidacionAgente.BackColor = Color.Red

        ElseIf (Trim(txtValidacionAgente.Text) = "LIBERADO SIN OBJECIONES") Then
            txtValidacionAgente.BackColor = Color.Green
        ElseIf (Trim(txtValidacionAgente.Text) = "LIBERADO CON OBJECIONES") Then
            txtValidacionAgente.BackColor = Color.Red()
        ElseIf (Trim(txtValidacionAgente.Text) = "NO VALIDA") Then
            txtValidacionAgente.BackColor = Color.YellowGreen
        Else
            txtValidacionAgente.BackColor = Color.Goldenrod
        End If
    End Sub


    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
     vercreditos()
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    vercreditos()

    'End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick


        If CheckBox1.Checked = False Then

        tiempo = tiempo + 1


            If (tiempo >= tiempomaximo) Then


                ProgressBar1.Value = 0
                tiempo = 0
            Else
                ProgressBar1.Value = tiempo

            End If



            If tiempo = 1 Then
                'Try
                '    Datos._Nombre = DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells(0).Value.ToString

                'Catch ex As Exception
                '    Datos._Nombre = ""
                'End Try

                'MsgBox(Datos._Nombre)

                vercreditos()

                'DGreditosAprobar.Rows(1).Selected = True
                'DGreditosAprobar.CurrentCell = DGreditosAprobar.Rows(1).Cells(0)

                'DGreditosAprobar.Rows(DGreditosAprobar.CurrentRow.Index).Cells(0).Value
            End If

        End If

    End Sub

 
    'Private Sub DGreditosAprobar_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGreditosAprobar.CellContentClick
    '    'verdetalle()
    'End Sub

    Private Sub txtTiempoEspera_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTiempoEspera.TextChanged

        'If Integer.Parse(TXTTIEMPOESPERA2.Text) < 25 Then
        '    txtTiempoEspera.BackColor = Color.Green
        'ElseIf Integer.Parse(TXTTIEMPOESPERA2.Text) < 35 Or Integer.Parse(TXTTIEMPOESPERA2.Text) >= 25 Then
        '    txtTiempoEspera.BackColor = Color.YellowGreen
        'Else
        '    txtTiempoEspera.BackColor = Color.Red
        'End If

    End Sub

    Private Sub DGreditosAprobar_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGreditosAprobar.CellContentClick

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        vercreditos()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboSonido.SelectedIndexChanged


        My.Settings.sonido = CboSonido.SelectedItem.ToString
        My.Settings.Save()
    End Sub

    Private Sub CboSonido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CboSonido.KeyPress
        e.KeyChar = ""
    End Sub
End Class