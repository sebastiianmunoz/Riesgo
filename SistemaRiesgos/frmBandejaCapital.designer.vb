<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBandejaCapital
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
        Me.GridbandejaCapital = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnEnviar_nomina = New System.Windows.Forms.Button()
        Me.txtEjecutiva = New System.Windows.Forms.TextBox()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.btnGenera_Nomina = New System.Windows.Forms.Button()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.txtNrosocio = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Fecha = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Textid = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Gridnomina = New System.Windows.Forms.DataGridView()
        Me.TIPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RUT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DVRUT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PATERNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MATERNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FORMA_PAGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BANCO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NRO_CUENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MONTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SECTOR_FINANCIERO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Gridnominaseleccion = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPOSOLICITUD2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GridSupervisada = New System.Windows.Forms.DataGridView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Colorfilas = New System.Windows.Forms.CheckBox()
        Me.Gridcuentadetanomina = New System.Windows.Forms.DataGridView()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Checkparaactualizaciongrilla = New System.Windows.Forms.CheckBox()
        Me.TEXTESTADONOMINA = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.CheckColorear = New System.Windows.Forms.CheckBox()
        Me.GridverNominaRealpagada = New System.Windows.Forms.DataGridView()
        Me.di = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBuscarID = New System.Windows.Forms.TextBox()
        Me.BtnbuscarID = New System.Windows.Forms.Button()
        CType(Me.GridbandejaCapital, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gridnomina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gridnominaseleccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridSupervisada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gridcuentadetanomina, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.GridverNominaRealpagada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridbandejaCapital
        '
        Me.GridbandejaCapital.AllowUserToAddRows = False
        Me.GridbandejaCapital.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridbandejaCapital.Location = New System.Drawing.Point(15, 12)
        Me.GridbandejaCapital.Name = "GridbandejaCapital"
        Me.GridbandejaCapital.Size = New System.Drawing.Size(1000, 475)
        Me.GridbandejaCapital.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1055, 345)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(192, 23)
        Me.Button1.TabIndex = 58
        Me.Button1.Text = "Borrar Nomina"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnEnviar_nomina
        '
        Me.btnEnviar_nomina.Location = New System.Drawing.Point(1055, 316)
        Me.btnEnviar_nomina.Name = "btnEnviar_nomina"
        Me.btnEnviar_nomina.Size = New System.Drawing.Size(192, 23)
        Me.btnEnviar_nomina.TabIndex = 54
        Me.btnEnviar_nomina.Text = "Enviar  Nómina"
        Me.btnEnviar_nomina.UseVisualStyleBackColor = True
        '
        'txtEjecutiva
        '
        Me.txtEjecutiva.Location = New System.Drawing.Point(1054, 219)
        Me.txtEjecutiva.Name = "txtEjecutiva"
        Me.txtEjecutiva.ReadOnly = True
        Me.txtEjecutiva.Size = New System.Drawing.Size(193, 20)
        Me.txtEjecutiva.TabIndex = 51
        '
        'txtSucursal
        '
        Me.txtSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtSucursal.Location = New System.Drawing.Point(1055, 261)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.ReadOnly = True
        Me.txtSucursal.Size = New System.Drawing.Size(191, 20)
        Me.txtSucursal.TabIndex = 49
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(1054, 177)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.ReadOnly = True
        Me.txtMonto.Size = New System.Drawing.Size(193, 20)
        Me.txtMonto.TabIndex = 47
        '
        'btnGenera_Nomina
        '
        Me.btnGenera_Nomina.Location = New System.Drawing.Point(1055, 287)
        Me.btnGenera_Nomina.Name = "btnGenera_Nomina"
        Me.btnGenera_Nomina.Size = New System.Drawing.Size(192, 23)
        Me.btnGenera_Nomina.TabIndex = 35
        Me.btnGenera_Nomina.Text = "Generar Nómina"
        Me.btnGenera_Nomina.UseVisualStyleBackColor = True
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(1054, 131)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(193, 20)
        Me.txtFecha.TabIndex = 45
        '
        'txtNrosocio
        '
        Me.txtNrosocio.Location = New System.Drawing.Point(1054, 89)
        Me.txtNrosocio.Name = "txtNrosocio"
        Me.txtNrosocio.ReadOnly = True
        Me.txtNrosocio.Size = New System.Drawing.Size(192, 20)
        Me.txtNrosocio.TabIndex = 44
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(1056, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 16)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "EJECUTIVO:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(1056, 242)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 16)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "SUCURSAL:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(1056, 158)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(160, 16)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "MONTO SOLICITADO:"
        '
        'Fecha
        '
        Me.Fecha.AutoSize = True
        Me.Fecha.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fecha.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Fecha.Location = New System.Drawing.Point(1056, 112)
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Size = New System.Drawing.Size(62, 16)
        Me.Fecha.TabIndex = 38
        Me.Fecha.Text = "FECHA:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(1052, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 16)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "NÚMERO SOCIO:"
        '
        'Textid
        '
        Me.Textid.Location = New System.Drawing.Point(1059, 512)
        Me.Textid.Name = "Textid"
        Me.Textid.ReadOnly = True
        Me.Textid.Size = New System.Drawing.Size(187, 20)
        Me.Textid.TabIndex = 58
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label9.Location = New System.Drawing.Point(1056, 493)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 16)
        Me.Label9.TabIndex = 57
        Me.Label9.Text = "ID:"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1059, 538)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(188, 23)
        Me.Button3.TabIndex = 56
        Me.Button3.Text = "Analizar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Gridnomina
        '
        Me.Gridnomina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Gridnomina.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TIPO, Me.RUT, Me.DVRUT, Me.NOMBRES, Me.PATERNO, Me.MATERNO, Me.FORMA_PAGO, Me.BANCO, Me.NRO_CUENTA, Me.MONTO, Me.SECTOR_FINANCIERO})
        Me.Gridnomina.Location = New System.Drawing.Point(31, 585)
        Me.Gridnomina.Name = "Gridnomina"
        Me.Gridnomina.Size = New System.Drawing.Size(164, 107)
        Me.Gridnomina.TabIndex = 55
        '
        'TIPO
        '
        Me.TIPO.HeaderText = "TIPO"
        Me.TIPO.Name = "TIPO"
        Me.TIPO.ReadOnly = True
        '
        'RUT
        '
        Me.RUT.HeaderText = "RUT"
        Me.RUT.Name = "RUT"
        Me.RUT.ReadOnly = True
        '
        'DVRUT
        '
        Me.DVRUT.HeaderText = "DVRUT"
        Me.DVRUT.Name = "DVRUT"
        Me.DVRUT.ReadOnly = True
        '
        'NOMBRES
        '
        Me.NOMBRES.HeaderText = "NOMBRES"
        Me.NOMBRES.Name = "NOMBRES"
        Me.NOMBRES.ReadOnly = True
        '
        'PATERNO
        '
        Me.PATERNO.HeaderText = "PATERNO"
        Me.PATERNO.Name = "PATERNO"
        Me.PATERNO.ReadOnly = True
        '
        'MATERNO
        '
        Me.MATERNO.HeaderText = "MATERNO"
        Me.MATERNO.Name = "MATERNO"
        Me.MATERNO.ReadOnly = True
        '
        'FORMA_PAGO
        '
        Me.FORMA_PAGO.HeaderText = "FORMA_PAGO"
        Me.FORMA_PAGO.Name = "FORMA_PAGO"
        '
        'BANCO
        '
        Me.BANCO.HeaderText = "BANCO"
        Me.BANCO.Name = "BANCO"
        Me.BANCO.ReadOnly = True
        '
        'NRO_CUENTA
        '
        Me.NRO_CUENTA.HeaderText = "NRO_CUENTA"
        Me.NRO_CUENTA.Name = "NRO_CUENTA"
        Me.NRO_CUENTA.ReadOnly = True
        '
        'MONTO
        '
        Me.MONTO.HeaderText = "MONTO"
        Me.MONTO.Name = "MONTO"
        Me.MONTO.ReadOnly = True
        '
        'SECTOR_FINANCIERO
        '
        Me.SECTOR_FINANCIERO.HeaderText = "SECTOR_FINANCIERO"
        Me.SECTOR_FINANCIERO.Name = "SECTOR_FINANCIERO"
        Me.SECTOR_FINANCIERO.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(83, 695)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 24)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Grilla TXT"
        '
        'Gridnominaseleccion
        '
        Me.Gridnominaseleccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Gridnominaseleccion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.TIPOSOLICITUD2})
        Me.Gridnominaseleccion.Location = New System.Drawing.Point(6, 18)
        Me.Gridnominaseleccion.Name = "Gridnominaseleccion"
        Me.Gridnominaseleccion.Size = New System.Drawing.Size(1006, 498)
        Me.Gridnominaseleccion.TabIndex = 58
        '
        'Column1
        '
        Me.Column1.HeaderText = "NRO_OPERACION"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "FECHA_SOLICITUD"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "ESTADO"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "RUT"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "NOMBRES"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "PATERNO"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "MATERNO"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "MONTO"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "BANCO"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "CUENTA"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.HeaderText = "NRO_CUENTA"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.HeaderText = "FORMA_PAGO"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'TIPOSOLICITUD2
        '
        Me.TIPOSOLICITUD2.HeaderText = "TIPOSOLICITUD2"
        Me.TIPOSOLICITUD2.Name = "TIPOSOLICITUD2"
        Me.TIPOSOLICITUD2.ReadOnly = True
        '
        'GridSupervisada
        '
        Me.GridSupervisada.AllowUserToAddRows = False
        Me.GridSupervisada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridSupervisada.Location = New System.Drawing.Point(3, 18)
        Me.GridSupervisada.Name = "GridSupervisada"
        Me.GridSupervisada.Size = New System.Drawing.Size(1005, 483)
        Me.GridSupervisada.TabIndex = 59
        '
        'Timer1
        '
        '
        'Colorfilas
        '
        Me.Colorfilas.AutoSize = True
        Me.Colorfilas.Location = New System.Drawing.Point(934, 562)
        Me.Colorfilas.Name = "Colorfilas"
        Me.Colorfilas.Size = New System.Drawing.Size(77, 17)
        Me.Colorfilas.TabIndex = 61
        Me.Colorfilas.Text = "Diferenciar"
        Me.Colorfilas.UseVisualStyleBackColor = True
        '
        'Gridcuentadetanomina
        '
        Me.Gridcuentadetanomina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Gridcuentadetanomina.Location = New System.Drawing.Point(235, 618)
        Me.Gridcuentadetanomina.Name = "Gridcuentadetanomina"
        Me.Gridcuentadetanomina.Size = New System.Drawing.Size(66, 54)
        Me.Gridcuentadetanomina.TabIndex = 62
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(231, 585)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(257, 24)
        Me.Label10.TabIndex = 63
        Me.Label10.Text = "Grilla detallenomina pagadas "
        '
        'Checkparaactualizaciongrilla
        '
        Me.Checkparaactualizaciongrilla.AutoSize = True
        Me.Checkparaactualizaciongrilla.Location = New System.Drawing.Point(882, 503)
        Me.Checkparaactualizaciongrilla.Name = "Checkparaactualizaciongrilla"
        Me.Checkparaactualizaciongrilla.Size = New System.Drawing.Size(133, 17)
        Me.Checkparaactualizaciongrilla.TabIndex = 64
        Me.Checkparaactualizaciongrilla.Text = "Detener Actualización "
        Me.Checkparaactualizaciongrilla.UseVisualStyleBackColor = True
        '
        'TEXTESTADONOMINA
        '
        Me.TEXTESTADONOMINA.Location = New System.Drawing.Point(1102, 606)
        Me.TEXTESTADONOMINA.Name = "TEXTESTADONOMINA"
        Me.TEXTESTADONOMINA.Size = New System.Drawing.Size(100, 20)
        Me.TEXTESTADONOMINA.TabIndex = 65
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(212, 681)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(186, 20)
        Me.TextBox1.TabIndex = 59
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label11.Location = New System.Drawing.Point(358, 503)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(125, 13)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "AUTO-ACTUALIZACIÓN"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(489, 502)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(387, 14)
        Me.ProgressBar1.TabIndex = 54
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage1)
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Location = New System.Drawing.Point(12, 12)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(1033, 553)
        Me.TabControl2.TabIndex = 68
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.GridbandejaCapital)
        Me.TabPage1.Controls.Add(Me.ProgressBar1)
        Me.TabPage1.Controls.Add(Me.Checkparaactualizaciongrilla)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1025, 527)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "GIRO CAPITAL SOCIAL"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Gridnominaseleccion)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1025, 527)
        Me.TabPage3.TabIndex = 1
        Me.TabPage3.Text = "NOMINA GENERADA"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.CheckColorear)
        Me.TabPage4.Controls.Add(Me.GridSupervisada)
        Me.TabPage4.Controls.Add(Me.Colorfilas)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1025, 527)
        Me.TabPage4.TabIndex = 2
        Me.TabPage4.Text = "NOMINA SUPERVISADA"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'CheckColorear
        '
        Me.CheckColorear.AutoSize = True
        Me.CheckColorear.Location = New System.Drawing.Point(3, 507)
        Me.CheckColorear.Name = "CheckColorear"
        Me.CheckColorear.Size = New System.Drawing.Size(109, 17)
        Me.CheckColorear.TabIndex = 69
        Me.CheckColorear.Text = "Colorear Estados "
        Me.CheckColorear.UseVisualStyleBackColor = True
        '
        'GridverNominaRealpagada
        '
        Me.GridverNominaRealpagada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridverNominaRealpagada.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.di})
        Me.GridverNominaRealpagada.Location = New System.Drawing.Point(589, 618)
        Me.GridverNominaRealpagada.Name = "GridverNominaRealpagada"
        Me.GridverNominaRealpagada.Size = New System.Drawing.Size(144, 150)
        Me.GridverNominaRealpagada.TabIndex = 69
        '
        'di
        '
        Me.di.HeaderText = "ID SOLICITUD "
        Me.di.Name = "di"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(1056, 393)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 16)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "ID:"
        '
        'TextBuscarID
        '
        Me.TextBuscarID.Location = New System.Drawing.Point(1059, 412)
        Me.TextBuscarID.Name = "TextBuscarID"
        Me.TextBuscarID.Size = New System.Drawing.Size(187, 20)
        Me.TextBuscarID.TabIndex = 75
        '
        'BtnbuscarID
        '
        Me.BtnbuscarID.Location = New System.Drawing.Point(1059, 438)
        Me.BtnbuscarID.Name = "BtnbuscarID"
        Me.BtnbuscarID.Size = New System.Drawing.Size(188, 23)
        Me.BtnbuscarID.TabIndex = 73
        Me.BtnbuscarID.Text = "Buscar"
        Me.BtnbuscarID.UseVisualStyleBackColor = True
        '
        'frmBandejaCapital
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1265, 574)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBuscarID)
        Me.Controls.Add(Me.BtnbuscarID)
        Me.Controls.Add(Me.GridverNominaRealpagada)
        Me.Controls.Add(Me.txtEjecutiva)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtSucursal)
        Me.Controls.Add(Me.Gridnomina)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtMonto)
        Me.Controls.Add(Me.btnEnviar_nomina)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.Textid)
        Me.Controls.Add(Me.txtNrosocio)
        Me.Controls.Add(Me.TabControl2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnGenera_Nomina)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TEXTESTADONOMINA)
        Me.Controls.Add(Me.Fecha)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Gridcuentadetanomina)
        Me.MaximizeBox = False
        Me.Name = "frmBandejaCapital"
        CType(Me.GridbandejaCapital, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gridnomina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gridnominaseleccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridSupervisada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gridcuentadetanomina, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.GridverNominaRealpagada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridbandejaCapital As System.Windows.Forms.DataGridView
    Friend WithEvents btnEnviar_nomina As System.Windows.Forms.Button
    Friend WithEvents txtEjecutiva As System.Windows.Forms.TextBox
    Friend WithEvents btnGenera_Nomina As System.Windows.Forms.Button
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtNrosocio As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Fecha As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Gridnomina As System.Windows.Forms.DataGridView
    Friend WithEvents TIPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RUT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DVRUT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PATERNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MATERNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FORMA_PAGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BANCO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NRO_CUENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MONTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SECTOR_FINANCIERO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Gridnominaseleccion As System.Windows.Forms.DataGridView
    Friend WithEvents GridSupervisada As System.Windows.Forms.DataGridView
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Textid As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Colorfilas As System.Windows.Forms.CheckBox
    Friend WithEvents Gridcuentadetanomina As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Checkparaactualizaciongrilla As System.Windows.Forms.CheckBox
    Friend WithEvents TEXTESTADONOMINA As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents CheckColorear As System.Windows.Forms.CheckBox
    Friend WithEvents GridverNominaRealpagada As System.Windows.Forms.DataGridView
    Friend WithEvents di As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBuscarID As System.Windows.Forms.TextBox
    Friend WithEvents BtnbuscarID As System.Windows.Forms.Button
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents TIPOSOLICITUD2 As DataGridViewTextBoxColumn
End Class
