<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBandejaCapital5
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
        Me.Datadetalle = New System.Windows.Forms.DataGridView()
        Me.GridReporte = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lableCargareporte = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GridSolicitudesPendientes = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Gridmesactualmesanterior = New System.Windows.Forms.DataGridView()
        Me.TextID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Textnorosico = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.textfechasolicitud = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Textfecha7diasatras = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Gridreporte2 = New System.Windows.Forms.DataGridView()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Textanulacion = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BtncartaCapital = New System.Windows.Forms.Button()
        Me.TextCoreoElectronico = New System.Windows.Forms.TextBox()
        CType(Me.Datadetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridSolicitudesPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gridmesactualmesanterior, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gridreporte2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Datadetalle
        '
        Me.Datadetalle.AllowUserToAddRows = False
        Me.Datadetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Datadetalle.Location = New System.Drawing.Point(23, 22)
        Me.Datadetalle.Name = "Datadetalle"
        Me.Datadetalle.Size = New System.Drawing.Size(710, 105)
        Me.Datadetalle.TabIndex = 0
        '
        'GridReporte
        '
        Me.GridReporte.AllowUserToAddRows = False
        Me.GridReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridReporte.Location = New System.Drawing.Point(23, 464)
        Me.GridReporte.Name = "GridReporte"
        Me.GridReporte.Size = New System.Drawing.Size(712, 80)
        Me.GridReporte.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(23, 133)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(159, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Reporte"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(596, 136)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(137, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Anular"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(479, 220)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(254, 18)
        Me.ProgressBar1.TabIndex = 5
        '
        'lableCargareporte
        '
        Me.lableCargareporte.AutoSize = True
        Me.lableCargareporte.Location = New System.Drawing.Point(52, 556)
        Me.lableCargareporte.Name = "lableCargareporte"
        Me.lableCargareporte.Size = New System.Drawing.Size(79, 13)
        Me.lableCargareporte.TabIndex = 6
        Me.lableCargareporte.Text = "Carga Reporte "
        '
        'Timer1
        '
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 434)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "REPORTE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 676)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(200, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "REPORTE SOLICITUDES PENDIETES "
        '
        'GridSolicitudesPendientes
        '
        Me.GridSolicitudesPendientes.AllowUserToAddRows = False
        Me.GridSolicitudesPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridSolicitudesPendientes.Location = New System.Drawing.Point(24, 692)
        Me.GridSolicitudesPendientes.Name = "GridSolicitudesPendientes"
        Me.GridSolicitudesPendientes.Size = New System.Drawing.Size(476, 107)
        Me.GridSolicitudesPendientes.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(91, 434)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 13)
        Me.Label4.TabIndex = 106
        Me.Label4.Text = "DIA"
        '
        'Gridmesactualmesanterior
        '
        Me.Gridmesactualmesanterior.AllowUserToAddRows = False
        Me.Gridmesactualmesanterior.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Gridmesactualmesanterior.Location = New System.Drawing.Point(23, 572)
        Me.Gridmesactualmesanterior.Name = "Gridmesactualmesanterior"
        Me.Gridmesactualmesanterior.Size = New System.Drawing.Size(324, 94)
        Me.Gridmesactualmesanterior.TabIndex = 105
        '
        'TextID
        '
        Me.TextID.Location = New System.Drawing.Point(636, 644)
        Me.TextID.Name = "TextID"
        Me.TextID.Size = New System.Drawing.Size(100, 20)
        Me.TextID.TabIndex = 108
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(605, 647)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 13)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "ID"
        '
        'Textnorosico
        '
        Me.Textnorosico.Location = New System.Drawing.Point(636, 618)
        Me.Textnorosico.Name = "Textnorosico"
        Me.Textnorosico.Size = New System.Drawing.Size(100, 20)
        Me.Textnorosico.TabIndex = 110
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(579, 621)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 111
        Me.Label6.Text = "NroSocio"
        '
        'textfechasolicitud
        '
        Me.textfechasolicitud.Location = New System.Drawing.Point(636, 672)
        Me.textfechasolicitud.Name = "textfechasolicitud"
        Me.textfechasolicitud.Size = New System.Drawing.Size(100, 20)
        Me.textfechasolicitud.TabIndex = 112
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(550, 675)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 113
        Me.Label7.Text = "Fecha Solicitud"
        '
        'Textfecha7diasatras
        '
        Me.Textfecha7diasatras.Location = New System.Drawing.Point(636, 699)
        Me.Textfecha7diasatras.Name = "Textfecha7diasatras"
        Me.Textfecha7diasatras.Size = New System.Drawing.Size(100, 20)
        Me.Textfecha7diasatras.TabIndex = 114
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(541, 706)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 13)
        Me.Label8.TabIndex = 115
        Me.Label8.Text = "Fecha 7 Solicitud"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(394, 220)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "Carga Reporte "
        '
        'Gridreporte2
        '
        Me.Gridreporte2.AllowUserToAddRows = False
        Me.Gridreporte2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Gridreporte2.Location = New System.Drawing.Point(23, 339)
        Me.Gridreporte2.Name = "Gridreporte2"
        Me.Gridreporte2.Size = New System.Drawing.Size(712, 80)
        Me.Gridreporte2.TabIndex = 117
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(23, 314)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 13)
        Me.Label9.TabIndex = 118
        Me.Label9.Text = "REPORTE F O R "
        '
        'Textanulacion
        '
        Me.Textanulacion.Location = New System.Drawing.Point(636, 586)
        Me.Textanulacion.Name = "Textanulacion"
        Me.Textanulacion.Size = New System.Drawing.Size(100, 20)
        Me.Textanulacion.TabIndex = 119
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(509, 589)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(121, 13)
        Me.Label10.TabIndex = 120
        Me.Label10.Text = "USUARIO ANULACION"
        '
        'BtncartaCapital
        '
        Me.BtncartaCapital.Location = New System.Drawing.Point(188, 133)
        Me.BtncartaCapital.Name = "BtncartaCapital"
        Me.BtncartaCapital.Size = New System.Drawing.Size(159, 23)
        Me.BtncartaCapital.TabIndex = 121
        Me.BtncartaCapital.Text = "Enviar Carta"
        Me.BtncartaCapital.UseVisualStyleBackColor = True
        '
        'TextCoreoElectronico
        '
        Me.TextCoreoElectronico.Location = New System.Drawing.Point(353, 136)
        Me.TextCoreoElectronico.Name = "TextCoreoElectronico"
        Me.TextCoreoElectronico.Size = New System.Drawing.Size(235, 20)
        Me.TextCoreoElectronico.TabIndex = 122
        '
        'frmBandejaCapital5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(789, 251)
        Me.Controls.Add(Me.TextCoreoElectronico)
        Me.Controls.Add(Me.BtncartaCapital)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Textanulacion)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Gridreporte2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Textfecha7diasatras)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.textfechasolicitud)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Textnorosico)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextID)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Gridmesactualmesanterior)
        Me.Controls.Add(Me.GridSolicitudesPendientes)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lableCargareporte)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GridReporte)
        Me.Controls.Add(Me.Datadetalle)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBandejaCapital5"
        CType(Me.Datadetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridSolicitudesPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gridmesactualmesanterior, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gridreporte2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Datadetalle As System.Windows.Forms.DataGridView
    Friend WithEvents GridReporte As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lableCargareporte As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GridSolicitudesPendientes As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Gridmesactualmesanterior As System.Windows.Forms.DataGridView
    Friend WithEvents TextID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Textnorosico As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents textfechasolicitud As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Textfecha7diasatras As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Gridreporte2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Textanulacion As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents BtncartaCapital As System.Windows.Forms.Button
    Friend WithEvents TextCoreoElectronico As System.Windows.Forms.TextBox
End Class
