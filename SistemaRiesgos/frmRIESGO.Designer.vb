<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRIESGO
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRIESGO))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.EVALUAR = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuEvaluarPersonas = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuEvaluarEmpresas = New System.Windows.Forms.ToolStripMenuItem()
        Me.CapitalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ESTADOS = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuEstafodPorAprobar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuEstadosMisPrestamos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuEstadosHistoricos = New System.Windows.Forms.ToolStripMenuItem()
        Me.NominaTransferenciasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RetiroCapitalPendientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstadosSolicitudesGiroCapitalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ControlEstadosGiroCapitalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReconToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlzamientoGarantiasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuEstadosEnRiesgo = New System.Windows.Forms.ToolStripMenuItem()
        Me.AUDITORIA = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuAuditoriaPuntajes = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisponibilidadCapitalmenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarNominaTransferenciasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarMontoSolicitudToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ESTADISTICAS = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuEstadisticasEjecutivos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuEstadisticasPrestamos = New System.Windows.Forms.ToolStripMenuItem()
        Me.CartasEnviadasToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PERFIL = New System.Windows.Forms.ToolStripMenuItem()
        Me.MunuPerfilEditar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuPerfilGestor = New System.Windows.Forms.ToolStripMenuItem()
        Me.OTROS = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuOtrosCaptaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuOtrosTXT = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActualizacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SUBIDAADJUNTOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VENTANA = New System.Windows.Forms.ToolStripMenuItem()
        Me.HORIZONTALToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VERTICALToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CASCADAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SALIR = New System.Windows.Forms.ToolStripMenuItem()
        Me.CerrarSistemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.ToolNombres = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolUbicacion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolActualiza = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolSesion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolCerrarSistema = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolExtras = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.TextSucural22 = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EVALUAR, Me.ESTADOS, Me.AUDITORIA, Me.ESTADISTICAS, Me.PERFIL, Me.OTROS, Me.VENTANA, Me.SALIR})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1317, 24)
        Me.MenuStrip1.TabIndex = 15
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'EVALUAR
        '
        Me.EVALUAR.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuEvaluarPersonas, Me.MenuEvaluarEmpresas, Me.CapitalToolStripMenuItem})
        Me.EVALUAR.Name = "EVALUAR"
        Me.EVALUAR.Size = New System.Drawing.Size(71, 20)
        Me.EVALUAR.Tag = "1"
        Me.EVALUAR.Text = "EVALUAR"
        '
        'MenuEvaluarPersonas
        '
        Me.MenuEvaluarPersonas.Name = "MenuEvaluarPersonas"
        Me.MenuEvaluarPersonas.Size = New System.Drawing.Size(126, 22)
        Me.MenuEvaluarPersonas.Text = "Personas"
        '
        'MenuEvaluarEmpresas
        '
        Me.MenuEvaluarEmpresas.Enabled = False
        Me.MenuEvaluarEmpresas.Name = "MenuEvaluarEmpresas"
        Me.MenuEvaluarEmpresas.Size = New System.Drawing.Size(126, 22)
        Me.MenuEvaluarEmpresas.Text = "Empresas"
        '
        'CapitalToolStripMenuItem
        '
        Me.CapitalToolStripMenuItem.Name = "CapitalToolStripMenuItem"
        Me.CapitalToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.CapitalToolStripMenuItem.Text = "Capital"
        '
        'ESTADOS
        '
        Me.ESTADOS.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuEstafodPorAprobar, Me.MenuEstadosMisPrestamos, Me.MenuEstadosHistoricos, Me.NominaTransferenciasToolStripMenuItem, Me.RetiroCapitalPendientesToolStripMenuItem, Me.EstadosSolicitudesGiroCapitalToolStripMenuItem, Me.ControlEstadosGiroCapitalToolStripMenuItem, Me.ReconToolStripMenuItem, Me.AlzamientoGarantiasToolStripMenuItem, Me.MenuEstadosEnRiesgo})
        Me.ESTADOS.Name = "ESTADOS"
        Me.ESTADOS.Size = New System.Drawing.Size(71, 20)
        Me.ESTADOS.Text = "ESTADOS"
        '
        'MenuEstafodPorAprobar
        '
        Me.MenuEstafodPorAprobar.Enabled = False
        Me.MenuEstafodPorAprobar.Name = "MenuEstafodPorAprobar"
        Me.MenuEstafodPorAprobar.Size = New System.Drawing.Size(233, 22)
        Me.MenuEstafodPorAprobar.Text = "Por Analizar"
        '
        'MenuEstadosMisPrestamos
        '
        Me.MenuEstadosMisPrestamos.Enabled = False
        Me.MenuEstadosMisPrestamos.Name = "MenuEstadosMisPrestamos"
        Me.MenuEstadosMisPrestamos.Size = New System.Drawing.Size(233, 22)
        Me.MenuEstadosMisPrestamos.Text = "Mis Prestamos"
        '
        'MenuEstadosHistoricos
        '
        Me.MenuEstadosHistoricos.Name = "MenuEstadosHistoricos"
        Me.MenuEstadosHistoricos.Size = New System.Drawing.Size(233, 22)
        Me.MenuEstadosHistoricos.Text = "Prestamos Historico"
        '
        'NominaTransferenciasToolStripMenuItem
        '
        Me.NominaTransferenciasToolStripMenuItem.Name = "NominaTransferenciasToolStripMenuItem"
        Me.NominaTransferenciasToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.NominaTransferenciasToolStripMenuItem.Text = "Nómina Transferencias "
        '
        'RetiroCapitalPendientesToolStripMenuItem
        '
        Me.RetiroCapitalPendientesToolStripMenuItem.Name = "RetiroCapitalPendientesToolStripMenuItem"
        Me.RetiroCapitalPendientesToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.RetiroCapitalPendientesToolStripMenuItem.Text = "Retiro Capital  Pendientes "
        '
        'EstadosSolicitudesGiroCapitalToolStripMenuItem
        '
        Me.EstadosSolicitudesGiroCapitalToolStripMenuItem.Name = "EstadosSolicitudesGiroCapitalToolStripMenuItem"
        Me.EstadosSolicitudesGiroCapitalToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.EstadosSolicitudesGiroCapitalToolStripMenuItem.Text = "Estados Solicitud Giro Capital"
        '
        'ControlEstadosGiroCapitalToolStripMenuItem
        '
        Me.ControlEstadosGiroCapitalToolStripMenuItem.Name = "ControlEstadosGiroCapitalToolStripMenuItem"
        Me.ControlEstadosGiroCapitalToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.ControlEstadosGiroCapitalToolStripMenuItem.Text = "Control Estados Giro Capital "
        '
        'ReconToolStripMenuItem
        '
        Me.ReconToolStripMenuItem.Name = "ReconToolStripMenuItem"
        Me.ReconToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.ReconToolStripMenuItem.Text = "Reconsideración Historico"
        '
        'AlzamientoGarantiasToolStripMenuItem
        '
        Me.AlzamientoGarantiasToolStripMenuItem.Enabled = False
        Me.AlzamientoGarantiasToolStripMenuItem.Name = "AlzamientoGarantiasToolStripMenuItem"
        Me.AlzamientoGarantiasToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.AlzamientoGarantiasToolStripMenuItem.Text = "Alzamiento Garantias"
        '
        'MenuEstadosEnRiesgo
        '
        Me.MenuEstadosEnRiesgo.Enabled = False
        Me.MenuEstadosEnRiesgo.Name = "MenuEstadosEnRiesgo"
        Me.MenuEstadosEnRiesgo.Size = New System.Drawing.Size(233, 22)
        Me.MenuEstadosEnRiesgo.Text = "En Riesgo"
        Me.MenuEstadosEnRiesgo.Visible = False
        '
        'AUDITORIA
        '
        Me.AUDITORIA.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuAuditoriaPuntajes, Me.DisponibilidadCapitalmenu, Me.EditarNominaTransferenciasToolStripMenuItem, Me.EditarMontoSolicitudToolStripMenuItem})
        Me.AUDITORIA.Name = "AUDITORIA"
        Me.AUDITORIA.Size = New System.Drawing.Size(85, 20)
        Me.AUDITORIA.Text = "AUDITORIA"
        '
        'MenuAuditoriaPuntajes
        '
        Me.MenuAuditoriaPuntajes.Enabled = False
        Me.MenuAuditoriaPuntajes.Name = "MenuAuditoriaPuntajes"
        Me.MenuAuditoriaPuntajes.Size = New System.Drawing.Size(238, 22)
        Me.MenuAuditoriaPuntajes.Text = "Puntajes"
        '
        'DisponibilidadCapitalmenu
        '
        Me.DisponibilidadCapitalmenu.Name = "DisponibilidadCapitalmenu"
        Me.DisponibilidadCapitalmenu.Size = New System.Drawing.Size(238, 22)
        Me.DisponibilidadCapitalmenu.Text = "Disponibilidad Retiro Capital "
        '
        'EditarNominaTransferenciasToolStripMenuItem
        '
        Me.EditarNominaTransferenciasToolStripMenuItem.Name = "EditarNominaTransferenciasToolStripMenuItem"
        Me.EditarNominaTransferenciasToolStripMenuItem.Size = New System.Drawing.Size(238, 22)
        Me.EditarNominaTransferenciasToolStripMenuItem.Text = "Editar Nomina Transferencias "
        '
        'EditarMontoSolicitudToolStripMenuItem
        '
        Me.EditarMontoSolicitudToolStripMenuItem.Name = "EditarMontoSolicitudToolStripMenuItem"
        Me.EditarMontoSolicitudToolStripMenuItem.Size = New System.Drawing.Size(238, 22)
        Me.EditarMontoSolicitudToolStripMenuItem.Text = "Editar Monto Solicitud "
        '
        'ESTADISTICAS
        '
        Me.ESTADISTICAS.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuEstadisticasEjecutivos, Me.MenuEstadisticasPrestamos, Me.CartasEnviadasToolStripMenuItem1})
        Me.ESTADISTICAS.Name = "ESTADISTICAS"
        Me.ESTADISTICAS.Size = New System.Drawing.Size(99, 20)
        Me.ESTADISTICAS.Text = "ESTADISTICAS"
        '
        'MenuEstadisticasEjecutivos
        '
        Me.MenuEstadisticasEjecutivos.Enabled = False
        Me.MenuEstadisticasEjecutivos.Name = "MenuEstadisticasEjecutivos"
        Me.MenuEstadisticasEjecutivos.Size = New System.Drawing.Size(161, 22)
        Me.MenuEstadisticasEjecutivos.Text = "Ejecutivos"
        '
        'MenuEstadisticasPrestamos
        '
        Me.MenuEstadisticasPrestamos.Enabled = False
        Me.MenuEstadisticasPrestamos.Name = "MenuEstadisticasPrestamos"
        Me.MenuEstadisticasPrestamos.Size = New System.Drawing.Size(161, 22)
        Me.MenuEstadisticasPrestamos.Text = "Prestamos"
        '
        'CartasEnviadasToolStripMenuItem1
        '
        Me.CartasEnviadasToolStripMenuItem1.Name = "CartasEnviadasToolStripMenuItem1"
        Me.CartasEnviadasToolStripMenuItem1.Size = New System.Drawing.Size(161, 22)
        Me.CartasEnviadasToolStripMenuItem1.Text = "Cartas Enviadas "
        '
        'PERFIL
        '
        Me.PERFIL.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MunuPerfilEditar, Me.MenuPerfilGestor})
        Me.PERFIL.Name = "PERFIL"
        Me.PERFIL.Size = New System.Drawing.Size(56, 20)
        Me.PERFIL.Text = "PERFIL"
        '
        'MunuPerfilEditar
        '
        Me.MunuPerfilEditar.Name = "MunuPerfilEditar"
        Me.MunuPerfilEditar.Size = New System.Drawing.Size(167, 22)
        Me.MunuPerfilEditar.Text = "Mi configuración"
        '
        'MenuPerfilGestor
        '
        Me.MenuPerfilGestor.Name = "MenuPerfilGestor"
        Me.MenuPerfilGestor.Size = New System.Drawing.Size(167, 22)
        Me.MenuPerfilGestor.Text = "Gestor"
        '
        'OTROS
        '
        Me.OTROS.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuOtrosCaptaciones, Me.MenuOtrosTXT, Me.ActualizacionesToolStripMenuItem, Me.SUBIDAADJUNTOSToolStripMenuItem})
        Me.OTROS.Name = "OTROS"
        Me.OTROS.Size = New System.Drawing.Size(59, 20)
        Me.OTROS.Text = "OTROS"
        '
        'MenuOtrosCaptaciones
        '
        Me.MenuOtrosCaptaciones.Name = "MenuOtrosCaptaciones"
        Me.MenuOtrosCaptaciones.Size = New System.Drawing.Size(207, 22)
        Me.MenuOtrosCaptaciones.Text = "Captaciones"
        '
        'MenuOtrosTXT
        '
        Me.MenuOtrosTXT.Name = "MenuOtrosTXT"
        Me.MenuOtrosTXT.Size = New System.Drawing.Size(207, 22)
        Me.MenuOtrosTXT.Text = "TXT Formulario Nº 1890"
        '
        'ActualizacionesToolStripMenuItem
        '
        Me.ActualizacionesToolStripMenuItem.Name = "ActualizacionesToolStripMenuItem"
        Me.ActualizacionesToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.ActualizacionesToolStripMenuItem.Text = "Actualizaciones"
        '
        'SUBIDAADJUNTOSToolStripMenuItem
        '
        Me.SUBIDAADJUNTOSToolStripMenuItem.Name = "SUBIDAADJUNTOSToolStripMenuItem"
        Me.SUBIDAADJUNTOSToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.SUBIDAADJUNTOSToolStripMenuItem.Text = "SUBIDA ADJUNTOS"
        Me.SUBIDAADJUNTOSToolStripMenuItem.Visible = False
        '
        'VENTANA
        '
        Me.VENTANA.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HORIZONTALToolStripMenuItem, Me.VERTICALToolStripMenuItem, Me.CASCADAToolStripMenuItem})
        Me.VENTANA.Name = "VENTANA"
        Me.VENTANA.Size = New System.Drawing.Size(73, 20)
        Me.VENTANA.Text = "VENTANA"
        '
        'HORIZONTALToolStripMenuItem
        '
        Me.HORIZONTALToolStripMenuItem.Name = "HORIZONTALToolStripMenuItem"
        Me.HORIZONTALToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.HORIZONTALToolStripMenuItem.Text = "Horizontal"
        '
        'VERTICALToolStripMenuItem
        '
        Me.VERTICALToolStripMenuItem.Name = "VERTICALToolStripMenuItem"
        Me.VERTICALToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.VERTICALToolStripMenuItem.Text = "Vertical"
        '
        'CASCADAToolStripMenuItem
        '
        Me.CASCADAToolStripMenuItem.Name = "CASCADAToolStripMenuItem"
        Me.CASCADAToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.CASCADAToolStripMenuItem.Text = "Cascada"
        '
        'SALIR
        '
        Me.SALIR.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CerrarSistemaToolStripMenuItem})
        Me.SALIR.Name = "SALIR"
        Me.SALIR.Size = New System.Drawing.Size(52, 20)
        Me.SALIR.Text = "SALIR"
        '
        'CerrarSistemaToolStripMenuItem
        '
        Me.CerrarSistemaToolStripMenuItem.Name = "CerrarSistemaToolStripMenuItem"
        Me.CerrarSistemaToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.CerrarSistemaToolStripMenuItem.Text = "Cerrar Sistema"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolNombres, Me.ToolUbicacion, Me.ToolStripStatusLabel4, Me.ToolActualiza, Me.ToolSesion, Me.ToolCerrarSistema, Me.ToolExtras, Me.ProgressBar1})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 653)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(1317, 37)
        Me.StatusStrip2.TabIndex = 28
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'ToolNombres
        '
        Me.ToolNombres.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolNombres.Image = CType(resources.GetObject("ToolNombres.Image"), System.Drawing.Image)
        Me.ToolNombres.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.ToolNombres.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolNombres.Margin = New System.Windows.Forms.Padding(10, 3, 0, 2)
        Me.ToolNombres.Name = "ToolNombres"
        Me.ToolNombres.Size = New System.Drawing.Size(24, 32)
        Me.ToolNombres.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'ToolUbicacion
        '
        Me.ToolUbicacion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolUbicacion.Image = CType(resources.GetObject("ToolUbicacion.Image"), System.Drawing.Image)
        Me.ToolUbicacion.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.ToolUbicacion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolUbicacion.Margin = New System.Windows.Forms.Padding(5, 3, 0, 2)
        Me.ToolUbicacion.Name = "ToolUbicacion"
        Me.ToolUbicacion.Size = New System.Drawing.Size(24, 32)
        Me.ToolUbicacion.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(0, 32)
        Me.ToolStripStatusLabel4.Text = "ToolStripStatusLabel4"
        '
        'ToolActualiza
        '
        Me.ToolActualiza.BackColor = System.Drawing.SystemColors.Control
        Me.ToolActualiza.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolActualiza.ForeColor = System.Drawing.Color.Black
        Me.ToolActualiza.Image = CType(resources.GetObject("ToolActualiza.Image"), System.Drawing.Image)
        Me.ToolActualiza.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.ToolActualiza.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolActualiza.Margin = New System.Windows.Forms.Padding(100, 3, 0, 2)
        Me.ToolActualiza.Name = "ToolActualiza"
        Me.ToolActualiza.Size = New System.Drawing.Size(111, 32)
        Me.ToolActualiza.Text = "ACTUALIZAR"
        Me.ToolActualiza.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'ToolSesion
        '
        Me.ToolSesion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolSesion.Image = CType(resources.GetObject("ToolSesion.Image"), System.Drawing.Image)
        Me.ToolSesion.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.ToolSesion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolSesion.Margin = New System.Windows.Forms.Padding(5, 3, 0, 2)
        Me.ToolSesion.Name = "ToolSesion"
        Me.ToolSesion.Size = New System.Drawing.Size(129, 32)
        Me.ToolSesion.Text = "CERRAR SESION"
        Me.ToolSesion.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'ToolCerrarSistema
        '
        Me.ToolCerrarSistema.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolCerrarSistema.Image = CType(resources.GetObject("ToolCerrarSistema.Image"), System.Drawing.Image)
        Me.ToolCerrarSistema.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.ToolCerrarSistema.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolCerrarSistema.Margin = New System.Windows.Forms.Padding(5, 3, 0, 2)
        Me.ToolCerrarSistema.Name = "ToolCerrarSistema"
        Me.ToolCerrarSistema.Size = New System.Drawing.Size(137, 32)
        Me.ToolCerrarSistema.Text = "CERRAR SISTEMA"
        Me.ToolCerrarSistema.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'ToolExtras
        '
        Me.ToolExtras.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolExtras.Name = "ToolExtras"
        Me.ToolExtras.Size = New System.Drawing.Size(650, 32)
        Me.ToolExtras.Spring = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 31)
        '
        'TextSucural22
        '
        Me.TextSucural22.Location = New System.Drawing.Point(1323, 630)
        Me.TextSucural22.Name = "TextSucural22"
        Me.TextSucural22.Size = New System.Drawing.Size(100, 20)
        Me.TextSucural22.TabIndex = 30
        Me.TextSucural22.Visible = False
        '
        'frmRIESGO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1317, 690)
        Me.Controls.Add(Me.TextSucural22)
        Me.Controls.Add(Me.StatusStrip2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmRIESGO"
        Me.Text = "SISTEMA RIESGO"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents EVALUAR As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AUDITORIA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAuditoriaPuntajes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PERFIL As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MunuPerfilEditar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ESTADOS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEstadosEnRiesgo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEstafodPorAprobar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEstadosMisPrestamos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEstadosHistoricos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ESTADISTICAS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SALIR As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerrarSistemaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VENTANA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VERTICALToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HORIZONTALToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CASCADAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEstadisticasEjecutivos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEstadisticasPrestamos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MenuPerfilGestor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEvaluarPersonas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuEvaluarEmpresas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CapitalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NominaTransferenciasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RetiroCapitalPendientesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisponibilidadCapitalmenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstadosSolicitudesGiroCapitalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OTROS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuOtrosCaptaciones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuOtrosTXT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ControlEstadosGiroCapitalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReconToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarNominaTransferenciasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip2 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolNombres As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolUbicacion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolActualiza As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolSesion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolCerrarSistema As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolExtras As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents TextSucural22 As System.Windows.Forms.TextBox
    Friend WithEvents AlzamientoGarantiasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarMontoSolicitudToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CartasEnviadasToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SUBIDAADJUNTOSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ActualizacionesToolStripMenuItem As ToolStripMenuItem
End Class
