
Imports System.Data
Imports System.Data.SqlClient


Public Class frmPerfil
    Dim Datos As New CDatos
    Dim METODO As CCEstadosGeneral = New CCEstadosGeneral
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter
    Declare Sub ExitProcess Lib "kernel32" (ByVal uExitCode As Long)
    Dim conexiones As New CConexion

    Private Sub TxtContrasena_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtContrasena.KeyDown
        If e.KeyCode = Keys.Enter Then
            permisos()
        End If
    End Sub





    Sub permisos()
        Dim usuario As String
        Dim Contrasena As String = ""
        Dim Permiso As String = ""
        Dim NOMBRE As String = ""
        Dim UBICACION As String = ""
        Dim Departamento As String = ""

        usuario = CbmUsuario.SelectedItem
        textusuario.Text = Trim(CbmUsuario.SelectedItem)
        frmRIESGO.ToolNombres.Text = Trim(CbmUsuario.SelectedItem)
        If TxtContrasena.Text = "" Then
            MsgBox("Debe ingresar contraseña")
        Else

            Dim conexiones2 As New CConexion
            conexiones2.conexion()
            Dim command2 As SqlCommand = New SqlCommand("SELECT dbo.FU_DESENCRIPTA(ENCONTRASENA) ,RTRIM([CIUDAD])+' - '+RTRIM(NOMBRECAJA),NOMBRE,dbo.FU_DESENCRIPTA( [ENPERMISOS]),dbo.FU_DESENCRIPTA( [ENSUPERCONTRASENA]),departamento FROM _RIESGO_PERFIL  inner join (SELECT * FROM [_SUCURSAL] WHERE VIGENTE=1) as  _SUCURSAL ON _RIESGO_PERFIL.UBICACION=_SUCURSAL.CODCAJA  WHERE USUARIO='" + usuario.ToString.Trim + "'", conexiones2._conexion)
            conexiones2.abrir()

            Dim reader2 As SqlDataReader = command2.ExecuteReader()


            If reader2.HasRows Then
                Do While reader2.Read()
                    Contrasena = reader2(0).ToString
                    TxtSede.Text = reader2(1).ToString
                    UBICACION = reader2(1).ToString
                    NOMBRE = reader2(2).ToString
                    Permiso = reader2(3).ToString
                    Departamento = reader2(5).ToString


                    ' MsgBox(Departamento)
                Loop
            Else
            End If

            reader2.Close()


            If Contrasena.ToString.Trim = TxtContrasena.Text.Trim Then
                Datos._Perfil = usuario
                Me.Visible = False

                If Contrasena.ToString.Trim = "LROSAS" Then

                    My.Forms.PerfilConfiguracion.MdiParent = frmRIESGO
                    My.Forms.PerfilConfiguracion.WindowState = FormWindowState.Normal
                    My.Forms.PerfilConfiguracion.StartPosition = FormStartPosition.CenterScreen
                    My.Forms.PerfilConfiguracion.Show()
                    PerfilConfiguracion.Button4.Visible = False
                    frmRIESGO.Log("I", CbmUsuario.SelectedItem.ToString.Trim(), "Acceso Concedido Password por defecto")
                Else

                    frmRIESGO.MenuEvaluarPersonas.Enabled = False
                    frmRIESGO.MenuEvaluarEmpresas.Enabled = False
                    frmRIESGO.MenuEvaluarEmpresas.Enabled = False
                    frmRIESGO.MenuEstadosEnRiesgo.Enabled = False
                    frmRIESGO.MenuEstafodPorAprobar.Enabled = False
                    frmRIESGO.MenuEstadosMisPrestamos.Enabled = False
                    frmRIESGO.MenuEstadosHistoricos.Enabled = False
                    frmRIESGO.MenuAuditoriaPuntajes.Enabled = False
                    frmRIESGO.MenuEstadosHistoricos.Enabled = False
                    frmRIESGO.MenuAuditoriaPuntajes.Enabled = False
                    frmRIESGO.MenuEstadisticasEjecutivos.Enabled = False
                    frmRIESGO.MenuEstadisticasPrestamos.Enabled = False
                    frmRIESGO.MenuPerfilGestor.Enabled = False



                    frmRIESGO.CapitalToolStripMenuItem.Enabled = False 'Evaluar Capital 
                    frmRIESGO.NominaTransferenciasToolStripMenuItem.Enabled = False ' Bnadeja Marcela para ver trnasferencias pendientes 
                    frmRIESGO.RetiroCapitalPendientesToolStripMenuItem.Enabled = False ''bandeja para la serta jjesica libera solicitudes pendietes pro falta de capital 
                    frmRIESGO.DisponibilidadCapitalmenu.Enabled = False ' Modulo que muestra el capital social de la empresa 
                    frmRIESGO.EstadosSolicitudesGiroCapitalToolStripMenuItem.Enabled = False ' ve estado de los creditos 
                    frmRIESGO.MenuOtrosCaptaciones.Enabled = False
                    frmRIESGO.MenuOtrosTXT.Enabled = False
                    frmRIESGO.EditarNominaTransferenciasToolStripMenuItem.Enabled = False 'editar nominas ya aprobadas 
                    frmRIESGO.EditarMontoSolicitudToolStripMenuItem.Enabled = False
                    frmRIESGO.CartasEnviadasToolStripMenuItem1.Enabled = False

                    If Trim(usuario) = "MTORRES" Then
                        frmRIESGO.CartasEnviadasToolStripMenuItem1.Enabled = True
                    End If

                    If Trim(usuario) = "HHERRERA(R)" Or Trim(usuario) = "CCAMPOS(R)" Then
                        frmRIESGO.SUBIDAADJUNTOSToolStripMenuItem.Visible = True
                    End If



                    If Departamento = "SFINANZAS" Or Departamento = "INFORMATICA" Then
                        'frmRIESGO.ControlEstadosGiroCapitalToolStripMenuItem.Enabled = True 'MensajeSolicitudesPendientes
                        frmRIESGO.ReconToolStripMenuItem.Enabled = True ' MODULO RECONCIDERACION 
                        frmRIESGO.EditarNominaTransferenciasToolStripMenuItem.Enabled = True  'Visualiza modulo nominas  ya aprobadas 
                        frmRIESGO.EditarMontoSolicitudToolStripMenuItem.Enabled = True
                        'frmRIESGO.CartasEnviadasToolStripMenuItem1.Enabled = True

                        'frmDisponibilidadRetiroCapital.Show()
                        'frmDisponibilidadRetiroCapital.Visible = False
                        'My.Forms.MensajeSolicitudesPendientes.MdiParent = frmRIESGO
                        'My.Forms.MensajeSolicitudesPendientes.WindowState = FormWindowState.Normal
                        'My.Forms.MensajeSolicitudesPendientes.StartPosition = FormStartPosition.CenterScreen
                        'My.Forms.MensajeSolicitudesPendientes.Show()

                        'frmRevalorizacionUFGlobal.Show()
                        'frmRevalorizacionUFGlobal.Enabled = True
                        'frmRevalorizacionUFGlobal.Visible = False
                    Else
                        frmRIESGO.ControlEstadosGiroCapitalToolStripMenuItem.Enabled = False
                        frmRIESGO.ReconToolStripMenuItem.Enabled = False
                    End If


                    'Evaluar		/ Personas
                    If Permiso.Substring(0, 1) = "1" Then
                        frmRIESGO.MenuEvaluarPersonas.Enabled = True
                    End If


                    'Evaluar        	/ Empresas
                    If Permiso.Substring(1, 1) = "1" Then
                        frmRIESGO.MenuEvaluarEmpresas.Enabled = True
                    End If

                    'Estados      	/ Riesgo
                    If Permiso.Substring(2, 1) = "1" Then
                        frmRIESGO.MenuEstadosEnRiesgo.Enabled = True
                    End If

                    'Estados     	/ Por Aprobar
                    If Permiso.Substring(3, 1) = "1" Then
                        frmRIESGO.MenuEstafodPorAprobar.Enabled = True
                    End If


                    'Estados		/ Mis Prestamos
                    If Permiso.Substring(4, 1) = "1" Then
                        frmRIESGO.MenuEstadosMisPrestamos.Enabled = True
                    End If

                    'Estados		/ Historico
                    If Permiso.Substring(5, 1) = "1" Then
                        frmRIESGO.MenuEstadosHistoricos.Enabled = True
                    End If

                    'Auditoria	/ Puntajes
                    If Permiso.Substring(6, 1) = "1" Then
                        frmRIESGO.MenuAuditoriaPuntajes.Enabled = True
                    End If

                    'Estadisticas	/ Ejecutivos
                    If Permiso.Substring(7, 1) = "1" Then
                        frmRIESGO.MenuEstadisticasEjecutivos.Enabled = True
                    End If


                    'Estadisticas	/ Prestamos
                    If Permiso.Substring(8, 1) = "1" Then
                        frmRIESGO.MenuEstadisticasPrestamos.Enabled = True
                    End If

                    'Perfil		/ Gestor
                    If Permiso.Substring(9, 1) = "1" Then
                        frmRIESGO.MenuPerfilGestor.Enabled = True
                    End If

                    'Giro de Capital  -------------------------------------------------------------------------------------------------------

                    If Permiso.Substring(10, 1) = "1" Then
                        frmRIESGO.CapitalToolStripMenuItem.Enabled = True
                    End If
                    If Permiso.Substring(11, 1) = "1" Then
                        frmRIESGO.NominaTransferenciasToolStripMenuItem.Enabled = True
                    End If
                    If Permiso.Substring(12, 1) = "1" Then
                        frmRIESGO.RetiroCapitalPendientesToolStripMenuItem.Enabled = True
                    End If
                    If Permiso.Substring(13, 1) = "1" Then
                        frmRIESGO.DisponibilidadCapitalmenu.Enabled = True
                    End If
                    If Permiso.Substring(14, 1) = "1" Then
                        frmRIESGO.EstadosSolicitudesGiroCapitalToolStripMenuItem.Enabled = True
                    End If


                    'OTROS / Captaciones-----------------------------------------------------------------------------------------------------
                    If Permiso.Substring(15, 1) = "1" Then
                        frmRIESGO.MenuOtrosCaptaciones.Enabled = True
                    End If

                    'OTROS / TXT Formualrio 1890-----------------------------------------------------------------------------------------------------
                    If Permiso.Substring(16, 1) = "1" Then
                        frmRIESGO.MenuOtrosTXT.Enabled = True
                    End If

                    frmRIESGO.ToolNombres.Text = NOMBRE
                    frmRIESGO.ToolUbicacion.Text = UBICACION
                    My.Settings.actualizacion = "no"
                    My.Settings.usuario = CbmUsuario.SelectedItem.ToString.Trim
                    My.Settings.Save()


                    'frmNavegadorWeb.Visible = False
                    'frmNavegadorWeb.Show()
                    'frmNavegadorWeb.MdiParent = Me.MdiParent
                    'frmNavegadorWeb.WebBrowser1.Navigate("http://www.dicom.cl/")
                    'frmNavegadorWeb.Visible = False


                    frmRIESGO.ACTIVAR()
                    frmActualizaciones.MdiParent = frmRIESGO
                    frmActualizaciones.WindowState = FormWindowState.Normal
                    frmActualizaciones.StartPosition = FormStartPosition.CenterScreen
                    frmActualizaciones.Show()
                    frmRIESGO.cargarActualiza()
                    If frmActualizaciones.DGDatos.RowCount = 0 Then
                        frmActualizaciones.Close()
                    End If
                    frmRIESGO.Log("I", CbmUsuario.SelectedItem.ToString.Trim(), "Acceso Concedido")
                End If


                Try
                    'frmRIESGO.PictureBox1.Image = Image.FromFile("Z:\ACTUALIZAR\fotospersonal\GENERALTRANSPARENTE.PNG")
                    'frmRIESGO.PictureBox1.Image = Image.FromFile("Z:\ACTUALIZAR\fotospersonal\" + CbmUsuario.SelectedItem.ToString.Trim + ".png")
                Catch ex As Exception
                End Try


            Else
                MsgBox("Contraseña incorrecta")
                frmRIESGO.Log("I", CbmUsuario.SelectedItem.ToString.Trim(), "Password No Valida")


            End If
        End If

        'ToolStripMenuItem1.enabled = False

        ' frmDisponibilidadRetiroCapital.Enabled = False
        ' frmDisponibilidadRetiroCapital.Visible = False

        If Datos._Testeo = "SI" Then
            MsgBox("SISTEMA EN FASE DE TESTING MODULO CAPITAL")
        End If

    End Sub

    Private Sub frmPerfil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'llenacombosucursal()

        Dim Fecha As String
        Dim Version As String
        LblVesion.Text = Datos._Version
        Dim conexiones2 As New CConexion
        conexiones2.conexion()
        Dim command2 As SqlCommand = New SqlCommand("SELECT MAX(FECHA) FROM _RIESGO_ACTUALIZACIONES", conexiones2._conexion)
        conexiones2.abrir()
        Dim reader2 As SqlDataReader = command2.ExecuteReader()
        If reader2.HasRows Then
            Do While reader2.Read()
                Fecha = (reader2(0).ToString)
            Loop
        Else
        End If
        reader2.Close()
        Dim conexiones3 As New CConexion
        conexiones3.conexion()
        Dim command3 As SqlCommand = New SqlCommand("SELECT VERSION_SISTEMA,COMENTARIO FROM _RIESGO_ACTUALIZACIONES WHERE FECHA='" + Fecha + "'", conexiones3._conexion)
        conexiones3.abrir()
        Dim reader3 As SqlDataReader = command3.ExecuteReader()
        If reader3.HasRows Then
            Do While reader3.Read()
                Version = (reader3(0).ToString)
                'txtmodificacion.Text = (reader3(1).ToString)
            Loop
        Else
        End If
        reader3.Close()
        'MsgBox(My.Settings.actualizacion)
        If Version <> Datos._Version Then
            If (My.Settings.actualizacion = "si") Then
                MsgBox("Es necesario realizar una actualización del Sistema")
                'frmRIESGO.BtnActualiza.BackColor = Color.DarkRed
                TxtContrasena.Enabled = False
                CbmUsuario.Enabled = False

            Else
                My.Settings.actualizacion = "si"
                My.Settings.Save()
                METODO.crear()
                System.Diagnostics.Process.Start("C:\Sistemas\Actualiza\ACTUALIZARIESGO.BAT")
                ExitProcess(9)

            End If
        Else
            Dim conexiones As New CConexion
            conexiones.conexion()
            Dim command As SqlCommand = New SqlCommand("SELECT USUARIO FROM _RIESGO_PERFIL WHERE USUARIO NOT IN (SELECT USUARIO FROM _RIESGO_PERFIL  WHERE ESTADO='D') order by USUARIO", conexiones._conexion)
            conexiones.abrir()
            Dim reader As SqlDataReader = command.ExecuteReader()
            If reader.HasRows Then
                Do While reader.Read()
                    CbmUsuario.Items.Add(reader(0).ToString)
                Loop
            Else
            End If

            reader.Close()

        End If
        If (My.Settings.usuario <> "") Then

            CbmUsuario.SelectedItem = My.Settings.usuario
        End If

        frmRIESGO.SUBIDAADJUNTOSToolStripMenuItem.Visible = False

        'My.Settings.actualizacion = 0
        'My.Settings.Save()

        'frmRIESGO.Label1.Visible = False

    End Sub

    Private Sub Panel1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseClick

        If CbmUsuario.SelectedItem = "CCAMPOS" Then
            frmRIESGO.MenuEvaluarPersonas.Enabled = True
            frmRIESGO.MenuEvaluarEmpresas.Enabled = True
            frmRIESGO.MenuEvaluarEmpresas.Enabled = True
            frmRIESGO.MenuEstadosEnRiesgo.Enabled = True
            frmRIESGO.MenuEstafodPorAprobar.Enabled = True
            frmRIESGO.MenuEstadosMisPrestamos.Enabled = True
            frmRIESGO.MenuEstadosHistoricos.Enabled = True
            frmRIESGO.MenuAuditoriaPuntajes.Enabled = True
            frmRIESGO.MenuEstadosHistoricos.Enabled = True
            frmRIESGO.MenuAuditoriaPuntajes.Enabled = True
            frmRIESGO.MenuEstadisticasEjecutivos.Enabled = True
            frmRIESGO.MenuEstadisticasPrestamos.Enabled = True
            frmRIESGO.MenuPerfilGestor.Enabled = True
            frmRIESGO.CapitalToolStripMenuItem.Enabled = True 'Evaluar Capital 
            frmRIESGO.NominaTransferenciasToolStripMenuItem.Enabled = True ' Bnadeja Marcela para ver trnasferencias pendientes 
            frmRIESGO.RetiroCapitalPendientesToolStripMenuItem.Enabled = True ''bandeja para la serta jjesica libera solicitudes pendietes pro falta de capital 
            frmRIESGO.DisponibilidadCapitalmenu.Enabled = True ' Modulo que muestra el capital social de la empresa 
            frmRIESGO.EstadosSolicitudesGiroCapitalToolStripMenuItem.Enabled = True ' ve estado de los creditos
            frmRIESGO.MenuOtrosTXT.Enabled = True

            Me.Visible = False
            frmRIESGO.Show()
            frmRIESGO.ACTIVAR()
            My.Settings.actualizacion = "no"
            My.Settings.usuario = CbmUsuario.SelectedItem.ToString.Trim
            My.Settings.Save()

            'frmRIESGO.PictureBox1.Image = Image.FromFile("Z:\ACTUALIZAR\fotospersonal\GENERALTRANSPARENTE.PNG")
            'frmRIESGO.PictureBox1.Image = Image.FromFile("Z:\ACTUALIZAR\fotospersonal\" + CbmUsuario.SelectedItem.ToString.Trim + ".png")


            frmRIESGO.ToolNombres.Text = " ADMINISTRADOR"
            frmRIESGO.ToolUbicacion.Text = "VALPARAÍSO"

            frmRIESGO.SUBIDAADJUNTOSToolStripMenuItem.Visible = True



            frmActualizaciones.MdiParent = frmRIESGO
            frmActualizaciones.WindowState = FormWindowState.Normal
            frmActualizaciones.StartPosition = FormStartPosition.CenterScreen
            frmActualizaciones.Show()
            frmRIESGO.cargarActualiza()
            If frmActualizaciones.DGDatos.RowCount = 0 Then
                frmActualizaciones.Close()
            End If

            'My.Forms.frmActualizaciones.frmPrepago.Visible = False

            'Me.Visible = False
            'frmRIESGO.Label1.Visible = True
            'frmRIESGO.Enabled = True
            'frmRIESGO.PictureBox1.Image = Image.FromFile("Z:\+CRISTIAN CAMPOS\fotosriesgo\GENERALTRANSPARENTE.PNG")
            'frmRIESGO.PictureBox1.Image = Image.FromFile("Z:\+CRISTIAN CAMPOS\fotosriesgo\" + CbmUsuario.SelectedItem.ToString.Trim + ".png")
            frmRIESGO.Log("I", CbmUsuario.SelectedItem.ToString.Trim(), "Acceso Concedido Soporte")

        End If

    End Sub

    Private Sub Panel3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel3.Click
        permisos()
    End Sub



    Private Sub CbmUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CbmUsuario.KeyPress
        e.KeyChar = ""
    End Sub



    'Private Sub CbmUsuario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbmUsuario.SelectedIndexChanged
    '    ACTUALIZASUCURSAL()
    'End Sub




    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class