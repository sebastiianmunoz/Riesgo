<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MensajeAlertaMovimientoSocios7Dias
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GRIDPENDIENTES = New System.Windows.Forms.DataGridView()
        Me.Gridmesactualmesanterior = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Labeltotalsolicitudes = New System.Windows.Forms.Label()
        Me.LabelestadoAprobado = New System.Windows.Forms.Label()
        Me.LabelESTADOPREAPROBADO = New System.Windows.Forms.Label()
        Me.LabelESTADOPAGADO = New System.Windows.Forms.Label()
        Me.LabelRESULTADOTOTALSOLICITUD = New System.Windows.Forms.Label()
        Me.LabelRESULTADOTOTALAPROBADO = New System.Windows.Forms.Label()
        Me.LabelRESULTADOTOTALPREAPROBADO = New System.Windows.Forms.Label()
        Me.LabelRESULTADOTOTALPAGADOS = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LabelTotalReconcideracion = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.GRIDPENDIENTES, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gridmesactualmesanterior, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(404, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(181, 16)
        Me.Label5.TabIndex = 101
        Me.Label5.Text = "Movimiento  Socios  año "
        '
        'GRIDPENDIENTES
        '
        Me.GRIDPENDIENTES.AllowUserToAddRows = False
        Me.GRIDPENDIENTES.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GRIDPENDIENTES.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.GRIDPENDIENTES.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDPENDIENTES.Location = New System.Drawing.Point(12, 39)
        Me.GRIDPENDIENTES.Name = "GRIDPENDIENTES"
        Me.GRIDPENDIENTES.Size = New System.Drawing.Size(645, 221)
        Me.GRIDPENDIENTES.TabIndex = 102
        '
        'Gridmesactualmesanterior
        '
        Me.Gridmesactualmesanterior.AllowUserToAddRows = False
        Me.Gridmesactualmesanterior.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Gridmesactualmesanterior.Location = New System.Drawing.Point(15, 574)
        Me.Gridmesactualmesanterior.Name = "Gridmesactualmesanterior"
        Me.Gridmesactualmesanterior.Size = New System.Drawing.Size(324, 121)
        Me.Gridmesactualmesanterior.TabIndex = 103
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 545)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "DIA"
        '
        'Labeltotalsolicitudes
        '
        Me.Labeltotalsolicitudes.AutoSize = True
        Me.Labeltotalsolicitudes.BackColor = System.Drawing.Color.Transparent
        Me.Labeltotalsolicitudes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labeltotalsolicitudes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Labeltotalsolicitudes.Location = New System.Drawing.Point(56, 42)
        Me.Labeltotalsolicitudes.Name = "Labeltotalsolicitudes"
        Me.Labeltotalsolicitudes.Size = New System.Drawing.Size(137, 16)
        Me.Labeltotalsolicitudes.TabIndex = 105
        Me.Labeltotalsolicitudes.Text = "Total Solicitudes  :"
        '
        'LabelestadoAprobado
        '
        Me.LabelestadoAprobado.AutoSize = True
        Me.LabelestadoAprobado.BackColor = System.Drawing.Color.Transparent
        Me.LabelestadoAprobado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelestadoAprobado.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelestadoAprobado.Location = New System.Drawing.Point(56, 77)
        Me.LabelestadoAprobado.Name = "LabelestadoAprobado"
        Me.LabelestadoAprobado.Size = New System.Drawing.Size(274, 16)
        Me.LabelestadoAprobado.TabIndex = 106
        Me.LabelestadoAprobado.Text = " Solicitudes en  estado  APROBADO   :"
        '
        'LabelESTADOPREAPROBADO
        '
        Me.LabelESTADOPREAPROBADO.AutoSize = True
        Me.LabelESTADOPREAPROBADO.BackColor = System.Drawing.Color.Transparent
        Me.LabelESTADOPREAPROBADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelESTADOPREAPROBADO.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelESTADOPREAPROBADO.Location = New System.Drawing.Point(56, 109)
        Me.LabelESTADOPREAPROBADO.Name = "LabelESTADOPREAPROBADO"
        Me.LabelESTADOPREAPROBADO.Size = New System.Drawing.Size(301, 16)
        Me.LabelESTADOPREAPROBADO.TabIndex = 107
        Me.LabelESTADOPREAPROBADO.Text = " Solicitudes en  estado  PREAPROBADO  :"
        '
        'LabelESTADOPAGADO
        '
        Me.LabelESTADOPAGADO.AutoSize = True
        Me.LabelESTADOPAGADO.BackColor = System.Drawing.Color.Transparent
        Me.LabelESTADOPAGADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelESTADOPAGADO.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelESTADOPAGADO.Location = New System.Drawing.Point(56, 140)
        Me.LabelESTADOPAGADO.Name = "LabelESTADOPAGADO"
        Me.LabelESTADOPAGADO.Size = New System.Drawing.Size(249, 16)
        Me.LabelESTADOPAGADO.TabIndex = 108
        Me.LabelESTADOPAGADO.Text = " Solicitudes en  estado  PAGADO  :"
        '
        'LabelRESULTADOTOTALSOLICITUD
        '
        Me.LabelRESULTADOTOTALSOLICITUD.AutoSize = True
        Me.LabelRESULTADOTOTALSOLICITUD.BackColor = System.Drawing.Color.Transparent
        Me.LabelRESULTADOTOTALSOLICITUD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRESULTADOTOTALSOLICITUD.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelRESULTADOTOTALSOLICITUD.Location = New System.Drawing.Point(432, 42)
        Me.LabelRESULTADOTOTALSOLICITUD.Name = "LabelRESULTADOTOTALSOLICITUD"
        Me.LabelRESULTADOTOTALSOLICITUD.Size = New System.Drawing.Size(16, 16)
        Me.LabelRESULTADOTOTALSOLICITUD.TabIndex = 109
        Me.LabelRESULTADOTOTALSOLICITUD.Text = "0"
        '
        'LabelRESULTADOTOTALAPROBADO
        '
        Me.LabelRESULTADOTOTALAPROBADO.AutoSize = True
        Me.LabelRESULTADOTOTALAPROBADO.BackColor = System.Drawing.Color.Transparent
        Me.LabelRESULTADOTOTALAPROBADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRESULTADOTOTALAPROBADO.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelRESULTADOTOTALAPROBADO.Location = New System.Drawing.Point(432, 77)
        Me.LabelRESULTADOTOTALAPROBADO.Name = "LabelRESULTADOTOTALAPROBADO"
        Me.LabelRESULTADOTOTALAPROBADO.Size = New System.Drawing.Size(16, 16)
        Me.LabelRESULTADOTOTALAPROBADO.TabIndex = 110
        Me.LabelRESULTADOTOTALAPROBADO.Text = "0"
        '
        'LabelRESULTADOTOTALPREAPROBADO
        '
        Me.LabelRESULTADOTOTALPREAPROBADO.AutoSize = True
        Me.LabelRESULTADOTOTALPREAPROBADO.BackColor = System.Drawing.Color.Transparent
        Me.LabelRESULTADOTOTALPREAPROBADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRESULTADOTOTALPREAPROBADO.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelRESULTADOTOTALPREAPROBADO.Location = New System.Drawing.Point(432, 109)
        Me.LabelRESULTADOTOTALPREAPROBADO.Name = "LabelRESULTADOTOTALPREAPROBADO"
        Me.LabelRESULTADOTOTALPREAPROBADO.Size = New System.Drawing.Size(16, 16)
        Me.LabelRESULTADOTOTALPREAPROBADO.TabIndex = 111
        Me.LabelRESULTADOTOTALPREAPROBADO.Text = "0"
        '
        'LabelRESULTADOTOTALPAGADOS
        '
        Me.LabelRESULTADOTOTALPAGADOS.AutoSize = True
        Me.LabelRESULTADOTOTALPAGADOS.BackColor = System.Drawing.Color.Transparent
        Me.LabelRESULTADOTOTALPAGADOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRESULTADOTOTALPAGADOS.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelRESULTADOTOTALPAGADOS.Location = New System.Drawing.Point(432, 140)
        Me.LabelRESULTADOTOTALPAGADOS.Name = "LabelRESULTADOTOTALPAGADOS"
        Me.LabelRESULTADOTOTALPAGADOS.Size = New System.Drawing.Size(16, 16)
        Me.LabelRESULTADOTOTALPAGADOS.TabIndex = 112
        Me.LabelRESULTADOTOTALPAGADOS.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(56, 173)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(335, 16)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = " Solicitudes en  estado  RECONSIDERACIÓN   :"
        '
        'LabelTotalReconcideracion
        '
        Me.LabelTotalReconcideracion.AutoSize = True
        Me.LabelTotalReconcideracion.BackColor = System.Drawing.Color.Transparent
        Me.LabelTotalReconcideracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalReconcideracion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelTotalReconcideracion.Location = New System.Drawing.Point(432, 173)
        Me.LabelTotalReconcideracion.Name = "LabelTotalReconcideracion"
        Me.LabelTotalReconcideracion.Size = New System.Drawing.Size(16, 16)
        Me.LabelTotalReconcideracion.TabIndex = 114
        Me.LabelTotalReconcideracion.Text = "0"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackgroundImage = Global.SistemaRiesgos.My.Resources.Resources.fondo
        Me.GroupBox1.Controls.Add(Me.LabelTotalReconcideracion)
        Me.GroupBox1.Controls.Add(Me.Labeltotalsolicitudes)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.LabelestadoAprobado)
        Me.GroupBox1.Controls.Add(Me.LabelRESULTADOTOTALPAGADOS)
        Me.GroupBox1.Controls.Add(Me.LabelESTADOPREAPROBADO)
        Me.GroupBox1.Controls.Add(Me.LabelRESULTADOTOTALPREAPROBADO)
        Me.GroupBox1.Controls.Add(Me.LabelESTADOPAGADO)
        Me.GroupBox1.Controls.Add(Me.LabelRESULTADOTOTALAPROBADO)
        Me.GroupBox1.Controls.Add(Me.LabelRESULTADOTOTALSOLICITUD)
        Me.GroupBox1.Location = New System.Drawing.Point(663, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(501, 221)
        Me.GroupBox1.TabIndex = 115
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalle Información"
        '
        'MensajeAlertaMovimientoSocios7Dias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImage = Global.SistemaRiesgos.My.Resources.Resources.Informe4
        Me.ClientSize = New System.Drawing.Size(1173, 278)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Gridmesactualmesanterior)
        Me.Controls.Add(Me.GRIDPENDIENTES)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "MensajeAlertaMovimientoSocios7Dias"
        CType(Me.GRIDPENDIENTES, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gridmesactualmesanterior, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GRIDPENDIENTES As System.Windows.Forms.DataGridView
    Friend WithEvents Gridmesactualmesanterior As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Labeltotalsolicitudes As System.Windows.Forms.Label
    Friend WithEvents LabelestadoAprobado As System.Windows.Forms.Label
    Friend WithEvents LabelESTADOPREAPROBADO As System.Windows.Forms.Label
    Friend WithEvents LabelESTADOPAGADO As System.Windows.Forms.Label
    Friend WithEvents LabelRESULTADOTOTALSOLICITUD As System.Windows.Forms.Label
    Friend WithEvents LabelRESULTADOTOTALAPROBADO As System.Windows.Forms.Label
    Friend WithEvents LabelRESULTADOTOTALPREAPROBADO As System.Windows.Forms.Label
    Friend WithEvents LabelRESULTADOTOTALPAGADOS As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LabelTotalReconcideracion As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
