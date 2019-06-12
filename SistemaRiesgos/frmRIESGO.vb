Imports System.Data
Imports System.Data.SqlClient
Imports System.Net

Public Class frmRIESGO
    Dim CONTEO As Integer = 0
    Dim METODO As CCEstadosGeneral = New CCEstadosGeneral
    Declare Sub ExitProcess Lib "kernel32" (ByVal uExitCode As Long)
    Dim tiempo As Integer = 0
    Dim tiempomaximo As Integer = 800
    Dim vueltas As Integer = 1
    Dim Usuario As String = ""
    Dim Sistema As String = ""
    Public Fecha As String = ""
    Public FechaULTIMA As String = ""
    Dim Datos As New CDatos
    Dim Plantillas As New Metodos
    Dim tabla As New DataTable
    Dim tabla2 As New DataTable
    Dim conexiones As New CConexion
    Sub cargarActualiza()

        Sistema = "RIESGO"
        Usuario = frmPerfil.CbmUsuario.SelectedItem.ToString.Trim


        Dim conexiones1 As New CConexion
        conexiones1.conexion()
        Dim command1 As SqlCommand = New SqlCommand("  SELECT MAX( FECHA)  FROM _RIESGO_ACTUALIZACIONES ", conexiones1._conexion)
        conexiones1.abrir()
        Dim reader1 As SqlDataReader = command1.ExecuteReader()
        If reader1.HasRows Then
            Do While reader1.Read()
                Fecha = (reader1(0).ToString)

            Loop
        Else

        End If



        Dim conexiones2 As New CConexion
        conexiones2.conexion()
        Dim command2 As SqlCommand = New SqlCommand("SELECT ISNULL(MAX(convert(bigint,FECHA)),201801010000) FROM _ACTUALIZACIONES_SISTEMAS   AS CC1 INNER JOIN (select MAX(ID) AS ID,SISTEMA,USUARIO from _ACTUALIZACIONES_SISTEMAS group by SISTEMA,USUARIO) AS CC2 ON CC1.ID=CC2.ID AND CC2.USUARIO=CC1.USUARIO AND CC1.SISTEMA=CC2.SISTEMA WHERE CC1.USUARIO='" + Usuario + "' AND CC1.SISTEMA='" + Sistema + "'", conexiones2._conexion)
        conexiones2.abrir()
        Dim reader2 As SqlDataReader = command2.ExecuteReader()
        If reader2.HasRows Then
            Do While reader2.Read()
                FechaULTIMA = (reader2(0).ToString)
                'MsgBox(Fecha)
            Loop
        Else

        End If


        Datos._sql1 = "SELECT substring([FECHA],1,4)+'/'+substring([FECHA],5,2)+'/'+substring([FECHA],7,2)+' '+ substring([FECHA],9,2)+':'+substring([FECHA],11,2)  as FECHA ,USUARIO,[VERSION_SISTEMA] AS VERSION ,RTRIM(MODULO) AS MODULO,rtrim([COMENTARIO]) AS DESCRIPCIÓN, FECHA AS FECHA2,PRIORIDAD  FROM _RIESGO_ACTUALIZACIONES where FECHA>" + FechaULTIMA + " order by FECHA desc"

        Plantillas.tabla.Rows.Clear()

        If Plantillas.Consultar_General(Datos) Then
            tabla = Plantillas.tabla
            frmActualizaciones.DGDatos.DataSource = tabla
        End If


        frmActualizaciones.DGDatos.AllowUserToAddRows = False





        Dim totalcolumnas As Integer = frmActualizaciones.DGDatos.Columns.Count - 1
        Dim tomadato As String = ""

        For A = 0 To totalcolumnas
            tomadato = Trim(frmActualizaciones.DGDatos.Columns(A).Name)

            If tomadato <> "FECHA" And tomadato <> "VERSION" And tomadato <> "DESCRIPCIÓN" And tomadato <> "USUARIO" And tomadato <> "MODULO" And tomadato <> "PRIORIDAD" Then
                frmActualizaciones.DGDatos.Columns(A).Visible = False
            End If
        Next
        colores()


    End Sub

    Sub colores()

        Dim totalcolumnas As Integer = frmActualizaciones.DGDatos.ColumnCount - 1
        Dim totalfilas As Integer = frmActualizaciones.DGDatos.Rows.Count - 1
        Dim tomadato As String = ""
        Dim tomadato2 As String = ""
        Dim estado_solicitud As String = ""


        For A = 0 To totalfilas
            tomadato = Trim(frmActualizaciones.DGDatos.Rows(A).Cells("PRIORIDAD").Value())

            If tomadato = "ALTA" Then
                For M = 0 To totalcolumnas
                    frmActualizaciones.DGDatos.Rows(A).Cells(M).Style.BackColor = Color.LightSalmon

                Next

            ElseIf tomadato = "MEDIA" Then
                For M = 0 To totalcolumnas
                    frmActualizaciones.DGDatos.Rows(A).Cells(M).Style.BackColor = Color.LightSkyBlue

                Next

            Else

                For M = 0 To totalcolumnas
                    frmActualizaciones.DGDatos.Rows(A).Cells(M).Style.BackColor = Color.LightGray

                Next

            End If


        Next



    End Sub
    Private Sub frmRIESGO_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Log("F", My.Settings.usuario, "Cierre Sistema")
        Global.System.Windows.Forms.Application.Exit()

    End Sub
    Sub ACTIVAR()
        MenuStrip1.Enabled = True
        ToolNombres.Visible = True
        ToolUbicacion.Visible = True
    End Sub


    Sub GUARDAR()
        If frmActualizaciones.TXTVisto.Text = "VISTO" Then

            Datos._sql1 = "insert into _ACTUALIZACIONES_SISTEMAS values ('" + Sistema + "','" + Usuario + "','" + Fecha + "')"


            Plantillas.Consultar_General(Datos)

            frmActualizaciones.Close()

        Else

            frmActualizaciones.Close()

        End If
    End Sub
    Sub Log(ByVal Tipo As String, ByVal Perfil As String, ByVal Mensaje As String)

        Try
            conexiones.conexion()
            conexiones.abrir()
            Dim cmd1 As New SqlCommand("_SISTEMAS_LOG", conexiones._conexion)
            cmd1.CommandType = CommandType.StoredProcedure
            Dim prm1 As SqlParameter = New SqlParameter("@Tipo", SqlDbType.NChar, 1)
            cmd1.Parameters.Add(prm1)

            Dim prm2 As SqlParameter = New SqlParameter("@Sistema", SqlDbType.NChar, 15)
            cmd1.Parameters.Add(prm2)

            Dim prm3 As SqlParameter = New SqlParameter("@Perfil", SqlDbType.NChar, 15)
            cmd1.Parameters.Add(prm3)

            Dim prm4 As SqlParameter = New SqlParameter("@Ip", SqlDbType.NChar, 15)
            cmd1.Parameters.Add(prm4)

            Dim prm5 As SqlParameter = New SqlParameter("@Mensaje", SqlDbType.NChar, 100)
            cmd1.Parameters.Add(prm5)




            With cmd1
                .Parameters("@Tipo").Value = Tipo
                .Parameters("@Sistema").Value = "RIESGO"
                .Parameters("@Perfil").Value = Perfil
                .Parameters("@Ip").Value = getIp()
                .Parameters("@Mensaje").Value = Mensaje
            End With
            Dim dr1 As SqlDataReader = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
            conexiones.cerrar()
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try



    End Sub
    Public Function getIp() As String

        Dim valorIp As String

        valorIp = Dns.GetHostEntry(My.Computer.Name).AddressList.FirstOrDefault(Function(i) i.AddressFamily = Sockets.AddressFamily.InterNetwork).ToString()

        Return valorIp

    End Function

    Private Sub frmRIESGO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ProgressBar1.ForeColor = Drawing.Color.Blue
        Me.Location = New Point(0, 0)
        My.Forms.frmPerfil.MdiParent = Me
        My.Forms.frmPerfil.WindowState = FormWindowState.Normal
        My.Forms.frmPerfil.StartPosition = FormStartPosition.CenterScreen
        My.Forms.frmPerfil.Show()
        DESACTIVAR()

        ProgressBar1.Maximum = tiempomaximo
        Timer1.Enabled = True
        Timer1.Interval = 1

    End Sub
    Sub DESACTIVAR()
        MenuStrip1.Enabled = False
        ToolNombres.Visible = False
        ToolUbicacion.Visible = False
        frmActualizaciones.Close()
    End Sub

    Private Sub AbrirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.Forms.frmAuditoriaPuntaje.MdiParent = Me
        My.Forms.frmAuditoriaPuntaje.WindowState = FormWindowState.Normal
        My.Forms.frmAuditoriaPuntaje.StartPosition = FormStartPosition.CenterScreen
        My.Forms.frmAuditoriaPuntaje.Show()
    End Sub



    Private Sub CerrarSistemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarSistemaToolStripMenuItem.Click
        Global.System.Windows.Forms.Application.Exit()
    End Sub



    Private Sub VERTICALToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VERTICALToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub HORIZONTALToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HORIZONTALToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub CASCADAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CASCADAToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmPerfil.TxtContrasena.Text = ""

        frmPerfil.Visible = True
        DESACTIVAR()
    End Sub


    Private Sub ErroresPerfilesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEstadisticasEjecutivos.Click
        My.Forms.frmEstadisticasEjecutivos.MdiParent = Me
        My.Forms.frmEstadisticasEjecutivos.WindowState = FormWindowState.Normal
        My.Forms.frmEstadisticasEjecutivos.StartPosition = FormStartPosition.CenterScreen
        My.Forms.frmEstadisticasEjecutivos.Show()
    End Sub

    Private Sub PrestamosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEstadisticasPrestamos.Click
        My.Forms.frmEstadisticasPrestamos.MdiParent = Me
        My.Forms.frmEstadisticasPrestamos.WindowState = FormWindowState.Normal
        My.Forms.frmEstadisticasPrestamos.StartPosition = FormStartPosition.CenterScreen
        My.Forms.frmEstadisticasPrestamos.Show()
    End Sub

    Private Sub ToolStripStatusLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub StatusStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub

  



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ProgressBar1.ForeColor = Color.Aqua


        Try

            tiempo = tiempo + 1


            If (tiempo >= tiempomaximo) Then


                ProgressBar1.Value = 0
                tiempo = 0
            Else
                ProgressBar1.Value = tiempo

            End If



            If tiempo = 1 Then
                If vueltas = 1 Then


                    ' ----------------- INICIO MENSAJE 1--------------------

                    Dim Datos As New CDatos
                    Dim Version As String
                    Dim Fecha As String
                    Dim tiempoactualizacion As Integer
                    Dim conexiones2 As New CConexion
                    conexiones2.conexion()
                    Dim command2 As SqlCommand = New SqlCommand("SELECT MAX(FECHA),DATEDIFF(MINUTE,CONVERT(datetime, convert(varchar, convert(datetime, substring(MAX(FECHA),1,8)), 111) +' '+substring(MAX(FECHA),9,2)+ ':' + substring(MAX(FECHA),11,2),102),GETDATE()) FROM _RIESGO_ACTUALIZACIONES", conexiones2._conexion)
                    conexiones2.abrir()
                    Dim reader2 As SqlDataReader = command2.ExecuteReader()


                    If reader2.HasRows Then
                        Do While reader2.Read()
                            Fecha = (reader2(0).ToString)
                            tiempoactualizacion = (reader2(1).ToString)
                        Loop
                    Else
                    End If

                    reader2.Close()

                    Dim conexiones3 As New CConexion
                    conexiones3.conexion()
                    Dim command3 As SqlCommand = New SqlCommand("SELECT VERSION_SISTEMA,COMENTARIO,FECHA FROM _RIESGO_ACTUALIZACIONES WHERE FECHA='" + Fecha + "'", conexiones3._conexion)
                    conexiones3.abrir()
                    Dim reader3 As SqlDataReader = command3.ExecuteReader()


                    If reader3.HasRows Then
                        Do While reader3.Read()
                            Version = (reader3(0).ToString)

                        Loop
                    Else
                    End If

                    reader3.Close()





                    If Version <> Datos._Version Then

                        If 5 - tiempoactualizacion < 1 Then
                            ToolExtras.Text = " ES NECESARIO ACTUALIZAR !!! " + " EXISTE LA NUEVA VERSIÓN " + Version.ToString + " DISPONIBLE "
                            If EstaAbierto(FrmCierreActualizacion) Then
                                'frmAbogadosCompromisos.cargar()
                                My.Forms.FrmCierreActualizacion.BringToFront()
                            Else
                                My.Forms.FrmCierreActualizacion.MdiParent = Me
                                My.Forms.FrmCierreActualizacion.WindowState = FormWindowState.Normal
                                My.Forms.FrmCierreActualizacion.StartPosition = FormStartPosition.CenterScreen
                                My.Forms.FrmCierreActualizacion.Show()
                            End If
                        Else
                            ToolExtras.Text = " ES NECESARIO ACTUALIZAR !!! " + " EXISTE LA NUEVA VERSIÓN " + Version.ToString + " DISPONIBLE " + vbCr + "SE ACTUALIZARA AUTOMATICAMENTE EN " + (5 - tiempoactualizacion).ToString + " MIN"
                        End If


                        ToolExtras.ForeColor = Color.Red
                        ToolActualiza.ForeColor = Color.Red
                        vueltas = 1



                    Else

                        ToolExtras.Text = " BIENVENIDO AL SISTEMA RIESGO" + vbCr + " VERSIÓN " + Datos._Version.ToString
                        ToolExtras.ForeColor = Color.Black
                        ToolActualiza.ForeColor = Color.Black
                        vueltas = vueltas + 1

                    End If
                    ' ----------------- FIN MENSAJE 1--------------------
                ElseIf vueltas = 2 Then
                    ' ----------------- INICIO MENSAJE 2--------------------
                    ToolExtras.ForeColor = Color.Black
                    ToolActualiza.ForeColor = Color.Black
                    Dim UF As String = ""
                    Dim conexiones22 As New CConexion
                    conexiones22.conexion()
                    Dim command22 As SqlCommand = New SqlCommand("SELECT [VALORUF] FROM [_VALORUF] where FECHA=REPLACE(SUBSTRING(CONVERT(VARCHAR,SYSDATETIME()),0,12),'-','') ", conexiones22._conexion)
                    conexiones22.abrir()
                    Dim reader22 As SqlDataReader = command22.ExecuteReader()



                    If reader22.HasRows Then
                        Do While reader22.Read()
                            UF = Trim((reader22(0).ToString))

                        Loop
                    Else
                    End If


                    ToolExtras.Text = "" + UCase(System.DateTime.Today.ToString("dddd dd MMMM  yyyy ")) + vbCr + "VALOR DE LA UF : " + UF.ToString


                    ' ----------------- FIN MENSAJE 2--------------------


                    vueltas = 1

                End If
            End If



        Catch ex As Exception

        End Try






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

    Private Sub frmRIESGO_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        'Me.MaximumSize = New System.Drawing.Size(1319, 690)
    End Sub

    Private Sub frmRIESGO_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged

    End Sub

    Private Sub HistoricoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEstadosHistoricos.Click
        My.Forms.FrmCreditosHistoricos.MdiParent = Me
        My.Forms.FrmCreditosHistoricos.WindowState = FormWindowState.Normal
        My.Forms.FrmCreditosHistoricos.StartPosition = FormStartPosition.CenterScreen
        My.Forms.FrmCreditosHistoricos.Show()
    End Sub

    Private Sub PuntajesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAuditoriaPuntajes.Click
        My.Forms.frmAuditoriaPuntaje.MdiParent = Me
        My.Forms.frmAuditoriaPuntaje.WindowState = FormWindowState.Normal
        My.Forms.frmAuditoriaPuntaje.StartPosition = FormStartPosition.CenterScreen
        My.Forms.frmAuditoriaPuntaje.Show()
    End Sub

    Private Sub CAMBIARCONTRASEÑAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MunuPerfilEditar.Click
        My.Forms.PerfilConfiguracion.MdiParent = Me
        My.Forms.PerfilConfiguracion.WindowState = FormWindowState.Normal
        My.Forms.PerfilConfiguracion.StartPosition = FormStartPosition.CenterScreen
        My.Forms.PerfilConfiguracion.Show()
        PerfilConfiguracion.Button5.Visible = False

    End Sub

    Private Sub AbrirToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub EnRiesgoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEstadosEnRiesgo.Click
        My.Forms.frmCreditosRiesgo.MdiParent = Me
        My.Forms.frmCreditosRiesgo.WindowState = FormWindowState.Normal
        My.Forms.frmCreditosRiesgo.StartPosition = FormStartPosition.CenterScreen
        My.Forms.frmCreditosRiesgo.Show()
    End Sub

    Private Sub PorAprobarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEstafodPorAprobar.Click
        My.Forms.frmCreditosPorAprobar.MdiParent = Me
        My.Forms.frmCreditosPorAprobar.WindowState = FormWindowState.Normal
        My.Forms.frmCreditosPorAprobar.StartPosition = FormStartPosition.CenterScreen
        My.Forms.frmCreditosPorAprobar.Show()
    End Sub

    Private Sub MisPrestamosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEstadosMisPrestamos.Click

        My.Forms.FrmCreditosPropios.MdiParent = Me
        My.Forms.FrmCreditosPropios.WindowState = FormWindowState.Normal
        My.Forms.FrmCreditosPropios.StartPosition = FormStartPosition.CenterScreen
        My.Forms.FrmCreditosPropios.Show()
    End Sub

    Private Sub PersonasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEvaluarPersonas.Click
        My.Forms.frmEvaluar.MdiParent = Me
        My.Forms.frmEvaluar.WindowState = FormWindowState.Normal
        My.Forms.frmEvaluar.StartPosition = FormStartPosition.CenterScreen
        My.Forms.frmEvaluar.Show()
    End Sub
    Sub abrirevaluarpersonas()
        My.Forms.frmEvaluar.MdiParent = Me
        My.Forms.frmEvaluar.WindowState = FormWindowState.Normal
        My.Forms.frmEvaluar.StartPosition = FormStartPosition.CenterScreen
        My.Forms.frmEvaluar.Show()
    End Sub



    Private Sub MenuPerfilGestor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuPerfilGestor.Click

        My.Forms.FrmGestionPerfil.MdiParent = Me
        My.Forms.FrmGestionPerfil.WindowState = FormWindowState.Normal
        My.Forms.FrmGestionPerfil.StartPosition = FormStartPosition.CenterScreen
        My.Forms.FrmGestionPerfil.Show()
    End Sub

    Private Sub CapitalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CapitalToolStripMenuItem.Click
        My.Forms.frmEvaluarCapital.MdiParent = Me
        My.Forms.frmEvaluarCapital.WindowState = FormWindowState.Normal
        My.Forms.frmEvaluarCapital.StartPosition = FormStartPosition.CenterScreen
        My.Forms.frmEvaluarCapital.Show()
    End Sub

    Private Sub NominaTransferenciasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NominaTransferenciasToolStripMenuItem.Click

        My.Forms.frmBandejaCapital.MdiParent = Me
        My.Forms.frmBandejaCapital.WindowState = FormWindowState.Normal
        My.Forms.frmBandejaCapital.StartPosition = FormStartPosition.CenterScreen
        My.Forms.frmBandejaCapital.Show()

    End Sub

    Private Sub RetiroCapitalPendientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetiroCapitalPendientesToolStripMenuItem.Click
        My.Forms.frmBandejaCapital2.MdiParent = Me
        My.Forms.frmBandejaCapital2.WindowState = FormWindowState.Normal
        My.Forms.frmBandejaCapital2.StartPosition = FormStartPosition.CenterScreen
        My.Forms.frmBandejaCapital2.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisponibilidadCapitalmenu.Click

        My.Forms.frmDisponibilidadRetiroCapital.MdiParent = Me
        My.Forms.frmDisponibilidadRetiroCapital.WindowState = FormWindowState.Normal
        My.Forms.frmDisponibilidadRetiroCapital.StartPosition = FormStartPosition.CenterScreen
        My.Forms.frmDisponibilidadRetiroCapital.Show()

    End Sub

    Private Sub EstadosSolicitudesGiroCapitalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadosSolicitudesGiroCapitalToolStripMenuItem.Click
        My.Forms.frmEstadosGiroCapital.MdiParent = Me
        My.Forms.frmEstadosGiroCapital.WindowState = FormWindowState.Normal
        My.Forms.frmEstadosGiroCapital.StartPosition = FormStartPosition.CenterScreen
        My.Forms.frmEstadosGiroCapital.Show()
    End Sub

    Private Sub MenuOtrosCaptaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuOtrosCaptaciones.Click
        My.Forms.frmCaptacionesGeneral.MdiParent = Me
        My.Forms.frmCaptacionesGeneral.WindowState = FormWindowState.Normal
        My.Forms.frmCaptacionesGeneral.StartPosition = FormStartPosition.CenterScreen
        My.Forms.frmCaptacionesGeneral.Show()
    End Sub

    Private Sub TXTFormularioNº1890SIIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuOtrosTXT.Click
        My.Forms.frmCaptacionesTXT.MdiParent = Me
        My.Forms.frmCaptacionesTXT.WindowState = FormWindowState.Normal
        My.Forms.frmCaptacionesTXT.StartPosition = FormStartPosition.CenterScreen
        My.Forms.frmCaptacionesTXT.Show()
    End Sub

    Private Sub ControlEstadosGiroCapitalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlEstadosGiroCapitalToolStripMenuItem.Click

        My.Forms.MensajeSolicitudesPendientes.MdiParent = Me
        My.Forms.MensajeSolicitudesPendientes.WindowState = FormWindowState.Normal
        My.Forms.MensajeSolicitudesPendientes.StartPosition = FormStartPosition.CenterScreen
        My.Forms.MensajeSolicitudesPendientes.Show()
    End Sub

    Private Sub ReconToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReconToolStripMenuItem.Click
        My.Forms.ModulosReconsideracion.MdiParent = Me
        My.Forms.ModulosReconsideracion.WindowState = FormWindowState.Normal
        My.Forms.ModulosReconsideracion.StartPosition = FormStartPosition.CenterScreen
        My.Forms.ModulosReconsideracion.Show()
    End Sub


    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub EditarNominaTransferenciasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarNominaTransferenciasToolStripMenuItem.Click

        My.Forms.frmBandejaCapital6EditarNominaTransferencia.MdiParent = Me
        My.Forms.frmBandejaCapital6EditarNominaTransferencia.WindowState = FormWindowState.Normal
        My.Forms.frmBandejaCapital6EditarNominaTransferencia.StartPosition = FormStartPosition.CenterScreen
        My.Forms.frmBandejaCapital6EditarNominaTransferencia.Show()

    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub ToolActualiza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolActualiza.Click
        METODO.crear()
        System.Diagnostics.Process.Start("C:\Sistemas\Actualiza\ACTUALIZARIESGO.BAT")
        ExitProcess(9)
    End Sub

    Private Sub ToolSesion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolSesion.Click

        Log("F", My.Settings.usuario, "Cierre Sesión")
        frmPerfil.TxtContrasena.Text = ""
        frmPerfil.Visible = True
        DESACTIVAR()
    End Sub

    Private Sub ToolCerrarSistema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCerrarSistema.Click
        Global.System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub MenuEvaluarEmpresas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEvaluarEmpresas.Click

    End Sub

    Private Sub EditarMontoSolicitudToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarMontoSolicitudToolStripMenuItem.Click

        My.Forms.frmEditarMontosSolicitudGiroCapital.MdiParent = Me
        My.Forms.frmEditarMontosSolicitudGiroCapital.WindowState = FormWindowState.Normal
        My.Forms.frmEditarMontosSolicitudGiroCapital.StartPosition = FormStartPosition.CenterScreen
        My.Forms.frmEditarMontosSolicitudGiroCapital.Show()

    End Sub

    Private Sub CartasEnviadasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CartasEnviadasToolStripMenuItem1.Click
        My.Forms.frmEnvioCorreoElectronicoAuditoria.MdiParent = Me
        My.Forms.frmEnvioCorreoElectronicoAuditoria.WindowState = FormWindowState.Normal
        My.Forms.frmEnvioCorreoElectronicoAuditoria.StartPosition = FormStartPosition.CenterScreen
        My.Forms.frmEnvioCorreoElectronicoAuditoria.Show()
    End Sub

    Private Sub CartasEnviadasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub SUBIDAADJUNTOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SUBIDAADJUNTOSToolStripMenuItem.Click
        My.Forms.PRUEBAS2.MdiParent = Me
        My.Forms.PRUEBAS2.WindowState = FormWindowState.Normal
        My.Forms.PRUEBAS2.StartPosition = FormStartPosition.CenterScreen
        My.Forms.PRUEBAS2.Show()
    End Sub

    Private Sub ActualizacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizacionesToolStripMenuItem.Click
        My.Forms.frmActualizacionesHistorico.MdiParent = Me
        My.Forms.frmActualizacionesHistorico.WindowState = FormWindowState.Normal
        My.Forms.frmActualizacionesHistorico.StartPosition = FormStartPosition.CenterScreen
        My.Forms.frmActualizacionesHistorico.Show()
        cargarActualizaHistorico()

    End Sub
    Sub cargarActualizaHistorico()



        Datos._sql1 = "SELECT substring([FECHA],1,4)+'/'+substring([FECHA],5,2)+'/'+substring([FECHA],7,2)+' '+ substring([FECHA],9,2)+':'+substring([FECHA],11,2)  as FECHA ,USUARIO,[VERSION_SISTEMA] AS VERSION ,RTRIM(MODULO) AS MODULO,rtrim([COMENTARIO]) AS DESCRIPCIÓN, FECHA AS FECHA2,PRIORIDAD  FROM _RIESGO_ACTUALIZACIONES where FECHA>201801010000 order by FECHA desc"

        Plantillas.tabla.Rows.Clear()

        If Plantillas.Consultar_General(Datos) Then
            tabla = Plantillas.tabla
            frmActualizacionesHistorico.DGDatos.DataSource = tabla
        End If


        frmActualizacionesHistorico.DGDatos.AllowUserToAddRows = False





        Dim totalcolumnas As Integer = frmActualizacionesHistorico.DGDatos.Columns.Count - 1
        Dim tomadato As String = ""

        For A = 0 To totalcolumnas
            tomadato = Trim(frmActualizacionesHistorico.DGDatos.Columns(A).Name)

            If tomadato <> "FECHA" And tomadato <> "VERSION" And tomadato <> "DESCRIPCIÓN" And tomadato <> "USUARIO" And tomadato <> "MODULO" And tomadato <> "PRIORIDAD" Then
                frmActualizacionesHistorico.DGDatos.Columns(A).Visible = False
            End If
        Next
        coloresHistorico()


    End Sub

    Sub coloresHistorico()

        Dim totalcolumnas As Integer = frmActualizacionesHistorico.DGDatos.ColumnCount - 1
        Dim totalfilas As Integer = frmActualizacionesHistorico.DGDatos.Rows.Count - 1
        Dim tomadato As String = ""
        Dim tomadato2 As String = ""
        Dim estado_solicitud As String = ""


        For A = 0 To totalfilas
            tomadato = Trim(frmActualizacionesHistorico.DGDatos.Rows(A).Cells("PRIORIDAD").Value())



            If tomadato = "ALTA" Then
                For M = 0 To totalcolumnas
                    frmActualizacionesHistorico.DGDatos.Rows(A).Cells(M).Style.BackColor = Color.LightSalmon

                Next

            ElseIf tomadato = "MEDIA" Then
                For M = 0 To totalcolumnas
                    frmActualizacionesHistorico.DGDatos.Rows(A).Cells(M).Style.BackColor = Color.LightSkyBlue

                Next

            Else

                For M = 0 To totalcolumnas
                    frmActualizacionesHistorico.DGDatos.Rows(A).Cells(M).Style.BackColor = Color.LightGray

                Next

            End If

        Next



    End Sub

End Class
