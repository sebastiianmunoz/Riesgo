<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreditosPorAprobar
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TXTTIEMPOESPERA2 = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtFueradeZona = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtEjecutiva = New System.Windows.Forms.TextBox()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTiempoEspera = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNrosocio = New System.Windows.Forms.TextBox()
        Me.Fecha = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.Txtproducto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtid = New System.Windows.Forms.TextBox()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chkAprobar = New System.Windows.Forms.ComboBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.DGreditosAprobar = New System.Windows.Forms.DataGridView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TXTESTADO = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.CboSonido = New System.Windows.Forms.ComboBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ChkAutoAvisoRiesgo2 = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ChkAutoAvisoRiesgo = New System.Windows.Forms.CheckBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtComercial = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtRiesgo = New System.Windows.Forms.TextBox()
        Me.txtCCS = New System.Windows.Forms.TextBox()
        Me.txtOperaciones = New System.Windows.Forms.TextBox()
        Me.txtCCI = New System.Windows.Forms.TextBox()
        Me.LOperaciones = New System.Windows.Forms.Label()
        Me.txtSubgerencia = New System.Windows.Forms.TextBox()
        Me.txtGerencia = New System.Windows.Forms.TextBox()
        Me.LCCS = New System.Windows.Forms.Label()
        Me.LSubGerencia = New System.Windows.Forms.Label()
        Me.LCCI = New System.Windows.Forms.Label()
        Me.Lgerencia = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtValidacionAgente = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DGreditosAprobar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(881, 11)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(196, 549)
        Me.TabControl1.TabIndex = 19
        '
        'TabPage2
        '
        Me.TabPage2.BackgroundImage = Global.SistemaRiesgos.My.Resources.Resources.Informe4
        Me.TabPage2.Controls.Add(Me.TXTTIEMPOESPERA2)
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage2.Controls.Add(Me.txtid)
        Me.TabPage2.Controls.Add(Me.DateTimePicker2)
        Me.TabPage2.Controls.Add(Me.Button3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(188, 523)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Analizar"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TXTTIEMPOESPERA2
        '
        Me.TXTTIEMPOESPERA2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTIEMPOESPERA2.Location = New System.Drawing.Point(16, 526)
        Me.TXTTIEMPOESPERA2.Name = "TXTTIEMPOESPERA2"
        Me.TXTTIEMPOESPERA2.ReadOnly = True
        Me.TXTTIEMPOESPERA2.Size = New System.Drawing.Size(191, 26)
        Me.TXTTIEMPOESPERA2.TabIndex = 55
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.txtFueradeZona, 0, 16)
        Me.TableLayoutPanel2.Controls.Add(Me.Label14, 0, 15)
        Me.TableLayoutPanel2.Controls.Add(Me.txtEjecutiva, 0, 11)
        Me.TableLayoutPanel2.Controls.Add(Me.txtSucursal, 0, 13)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 12)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.txtTiempoEspera, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtNrosocio, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Fecha, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.txtMonto, 0, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.txtFecha, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.Txtproducto, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 6)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(5, 10)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 17
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(183, 491)
        Me.TableLayoutPanel2.TabIndex = 54
        '
        'txtFueradeZona
        '
        Me.txtFueradeZona.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFueradeZona.Location = New System.Drawing.Point(3, 463)
        Me.txtFueradeZona.Name = "txtFueradeZona"
        Me.txtFueradeZona.ReadOnly = True
        Me.txtFueradeZona.Size = New System.Drawing.Size(177, 22)
        Me.txtFueradeZona.TabIndex = 56
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label14.Location = New System.Drawing.Point(3, 440)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(116, 16)
        Me.Label14.TabIndex = 56
        Me.Label14.Text = "FUERA DE ZONA"
        '
        'txtEjecutiva
        '
        Me.txtEjecutiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEjecutiva.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtEjecutiva.Location = New System.Drawing.Point(3, 348)
        Me.txtEjecutiva.Name = "txtEjecutiva"
        Me.txtEjecutiva.ReadOnly = True
        Me.txtEjecutiva.Size = New System.Drawing.Size(177, 22)
        Me.txtEjecutiva.TabIndex = 51
        '
        'txtSucursal
        '
        Me.txtSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSucursal.ForeColor = System.Drawing.Color.Wheat
        Me.txtSucursal.Location = New System.Drawing.Point(3, 398)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.ReadOnly = True
        Me.txtSucursal.Size = New System.Drawing.Size(177, 22)
        Me.txtSucursal.TabIndex = 49
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label8.Location = New System.Drawing.Point(3, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(117, 16)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "TIEMPO ESPERA"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(3, 370)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 16)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "SUCURSAL"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(3, 320)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 16)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "EJECUTIVO"
        '
        'txtTiempoEspera
        '
        Me.txtTiempoEspera.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTiempoEspera.Location = New System.Drawing.Point(3, 28)
        Me.txtTiempoEspera.Multiline = True
        Me.txtTiempoEspera.Name = "txtTiempoEspera"
        Me.txtTiempoEspera.ReadOnly = True
        Me.txtTiempoEspera.Size = New System.Drawing.Size(177, 89)
        Me.txtTiempoEspera.TabIndex = 52
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(3, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 16)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "NUMERO SOCIO"
        '
        'txtNrosocio
        '
        Me.txtNrosocio.Location = New System.Drawing.Point(3, 148)
        Me.txtNrosocio.Name = "txtNrosocio"
        Me.txtNrosocio.ReadOnly = True
        Me.txtNrosocio.Size = New System.Drawing.Size(177, 20)
        Me.txtNrosocio.TabIndex = 44
        '
        'Fecha
        '
        Me.Fecha.AutoSize = True
        Me.Fecha.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fecha.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Fecha.Location = New System.Drawing.Point(3, 170)
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Size = New System.Drawing.Size(53, 16)
        Me.Fecha.TabIndex = 38
        Me.Fecha.Text = "FECHA"
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(3, 298)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.ReadOnly = True
        Me.txtMonto.Size = New System.Drawing.Size(177, 20)
        Me.txtMonto.TabIndex = 47
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(3, 198)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(177, 20)
        Me.txtFecha.TabIndex = 45
        '
        'Txtproducto
        '
        Me.Txtproducto.ForeColor = System.Drawing.Color.DarkGreen
        Me.Txtproducto.Location = New System.Drawing.Point(3, 248)
        Me.Txtproducto.Name = "Txtproducto"
        Me.Txtproducto.ReadOnly = True
        Me.Txtproducto.Size = New System.Drawing.Size(177, 20)
        Me.Txtproducto.TabIndex = 46
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(3, 270)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 16)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "MONTO SOLICITADO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(3, 220)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 16)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "PRODUCTO"
        '
        'txtid
        '
        Me.txtid.Location = New System.Drawing.Point(21, 554)
        Me.txtid.Multiline = True
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(194, 24)
        Me.txtid.TabIndex = 37
        Me.txtid.Visible = False
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(3, 557)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(207, 20)
        Me.DateTimePicker2.TabIndex = 41
        Me.DateTimePicker2.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(16, 532)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(194, 23)
        Me.Button3.TabIndex = 35
        Me.Button3.Text = "Analizar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.BackgroundImage = Global.SistemaRiesgos.My.Resources.Resources.Informe4
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.chkAprobar)
        Me.TabPage1.Controls.Add(Me.Button9)
        Me.TabPage1.Controls.Add(Me.Button10)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(188, 523)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Busqueda"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(176, 23)
        Me.Button1.TabIndex = 44
        Me.Button1.Text = "ACTUALIZAR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkAprobar
        '
        Me.chkAprobar.FormattingEnabled = True
        Me.chkAprobar.Items.AddRange(New Object() {"", "AGENCIA", "SUBGERENCIA", "GERENCIA", "CCI", "CCS"})
        Me.chkAprobar.Location = New System.Drawing.Point(9, 69)
        Me.chkAprobar.Name = "chkAprobar"
        Me.chkAprobar.Size = New System.Drawing.Size(207, 21)
        Me.chkAprobar.TabIndex = 43
        Me.chkAprobar.Visible = False
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(3, 100)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(182, 23)
        Me.Button9.TabIndex = 37
        Me.Button9.Text = "BUSQUEDA POR CATEGORIA"
        Me.Button9.UseVisualStyleBackColor = True
        Me.Button9.Visible = False
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(6, 129)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(179, 23)
        Me.Button10.TabIndex = 36
        Me.Button10.Text = "BUSQUEDA GENERAL"
        Me.Button10.UseVisualStyleBackColor = True
        Me.Button10.Visible = False
        '
        'DGreditosAprobar
        '
        Me.DGreditosAprobar.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.DGreditosAprobar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGreditosAprobar.Location = New System.Drawing.Point(3, 11)
        Me.DGreditosAprobar.Name = "DGreditosAprobar"
        Me.DGreditosAprobar.Size = New System.Drawing.Size(876, 328)
        Me.DGreditosAprobar.TabIndex = 18
        '
        'Timer1
        '
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel4.BackgroundImage = Global.SistemaRiesgos.My.Resources.Resources.Informe4
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Controls.Add(Me.Panel9)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.Panel8)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.Panel7)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel4.Location = New System.Drawing.Point(5, 389)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(874, 35)
        Me.Panel4.TabIndex = 59
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label17.Location = New System.Drawing.Point(606, 10)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(111, 15)
        Me.Label17.TabIndex = 66
        Me.Label17.Text = "PrePago Parcial"
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Panel9.Location = New System.Drawing.Point(573, 10)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(27, 18)
        Me.Panel9.TabIndex = 65
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label12.Location = New System.Drawing.Point(427, 10)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(137, 15)
        Me.Label12.TabIndex = 64
        Me.Label12.Text = "Nomina Giro Capital"
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Orange
        Me.Panel8.Location = New System.Drawing.Point(390, 8)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(27, 18)
        Me.Panel8.TabIndex = 63
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label11.Location = New System.Drawing.Point(129, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 15)
        Me.Label11.TabIndex = 62
        Me.Label11.Text = "Agente Analisis"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Gold
        Me.Panel7.Location = New System.Drawing.Point(96, 8)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(27, 18)
        Me.Panel7.TabIndex = 61
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label10.Location = New System.Drawing.Point(280, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 15)
        Me.Label10.TabIndex = 60
        Me.Label10.Text = "Giro de Capital"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label9.Location = New System.Drawing.Point(38, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 15)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Crédito"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Panel6.Location = New System.Drawing.Point(248, 8)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(27, 18)
        Me.Panel6.TabIndex = 5
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.SeaGreen
        Me.Panel5.Location = New System.Drawing.Point(5, 8)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(27, 18)
        Me.Panel5.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel3.BackgroundImage = Global.SistemaRiesgos.My.Resources.Resources.Informe4
        Me.Panel3.Controls.Add(Me.TXTESTADO)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel3.Location = New System.Drawing.Point(5, 348)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(874, 35)
        Me.Panel3.TabIndex = 58
        '
        'TXTESTADO
        '
        Me.TXTESTADO.AutoSize = True
        Me.TXTESTADO.BackColor = System.Drawing.Color.Transparent
        Me.TXTESTADO.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.TXTESTADO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTESTADO.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TXTESTADO.Location = New System.Drawing.Point(93, 12)
        Me.TXTESTADO.Name = "TXTESTADO"
        Me.TXTESTADO.Size = New System.Drawing.Size(0, 16)
        Me.TXTESTADO.TabIndex = 37
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(13, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 16)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "ESTADO:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel2.BackgroundImage = Global.SistemaRiesgos.My.Resources.Resources.Informe4
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.CboSonido)
        Me.Panel2.Controls.Add(Me.CheckBox1)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.ChkAutoAvisoRiesgo2)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.ChkAutoAvisoRiesgo)
        Me.Panel2.Controls.Add(Me.ProgressBar1)
        Me.Panel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel2.Location = New System.Drawing.Point(5, 491)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(874, 67)
        Me.Panel2.TabIndex = 57
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(627, 46)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 12)
        Me.Label19.TabIndex = 59
        Me.Label19.Text = "ALARMA"
        '
        'CboSonido
        '
        Me.CboSonido.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboSonido.FormattingEnabled = True
        Me.CboSonido.Items.AddRange(New Object() {"Por Defecto", "Alternativa 1", "Alternativa 2", "Alternativa 3"})
        Me.CboSonido.Location = New System.Drawing.Point(680, 42)
        Me.CboSonido.Name = "CboSonido"
        Me.CboSonido.Size = New System.Drawing.Size(190, 20)
        Me.CboSonido.TabIndex = 58
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.Black
        Me.CheckBox1.Location = New System.Drawing.Point(535, 44)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(86, 16)
        Me.CheckBox1.TabIndex = 57
        Me.CheckBox1.Text = "DESACTIVAR"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label13.Location = New System.Drawing.Point(98, 14)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(0, 16)
        Me.Label13.TabIndex = 35
        '
        'ChkAutoAvisoRiesgo2
        '
        Me.ChkAutoAvisoRiesgo2.AutoSize = True
        Me.ChkAutoAvisoRiesgo2.BackColor = System.Drawing.Color.Transparent
        Me.ChkAutoAvisoRiesgo2.Checked = True
        Me.ChkAutoAvisoRiesgo2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkAutoAvisoRiesgo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAutoAvisoRiesgo2.ForeColor = System.Drawing.Color.Black
        Me.ChkAutoAvisoRiesgo2.Location = New System.Drawing.Point(248, 44)
        Me.ChkAutoAvisoRiesgo2.Name = "ChkAutoAvisoRiesgo2"
        Me.ChkAutoAvisoRiesgo2.Size = New System.Drawing.Size(281, 16)
        Me.ChkAutoAvisoRiesgo2.TabIndex = 53
        Me.ChkAutoAvisoRiesgo2.Text = "ALARMA SI EXISTE ALGUNA SOLICITUD EN LA BANDEJA"
        Me.ChkAutoAvisoRiesgo2.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(11, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 13)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "AUTO-ACTUALIZACIÓN"
        '
        'ChkAutoAvisoRiesgo
        '
        Me.ChkAutoAvisoRiesgo.AutoSize = True
        Me.ChkAutoAvisoRiesgo.BackColor = System.Drawing.Color.Transparent
        Me.ChkAutoAvisoRiesgo.Checked = True
        Me.ChkAutoAvisoRiesgo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkAutoAvisoRiesgo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAutoAvisoRiesgo.ForeColor = System.Drawing.Color.Black
        Me.ChkAutoAvisoRiesgo.Location = New System.Drawing.Point(11, 45)
        Me.ChkAutoAvisoRiesgo.Name = "ChkAutoAvisoRiesgo"
        Me.ChkAutoAvisoRiesgo.Size = New System.Drawing.Size(237, 16)
        Me.ChkAutoAvisoRiesgo.TabIndex = 52
        Me.ChkAutoAvisoRiesgo.Text = "ALARMA POR LLEGADA DE NUEVA SOLICITUD"
        Me.ChkAutoAvisoRiesgo.UseVisualStyleBackColor = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(11, 22)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(859, 17)
        Me.ProgressBar1.TabIndex = 54
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.BackgroundImage = Global.SistemaRiesgos.My.Resources.Resources.Informe4
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel1.Location = New System.Drawing.Point(5, 429)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(874, 58)
        Me.Panel1.TabIndex = 20
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 173.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtComercial, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label18, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtRiesgo, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCCS, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtOperaciones, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCCI, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LOperaciones, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSubgerencia, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtGerencia, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LCCS, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LSubGerencia, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LCCI, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lgerencia, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label15, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label16, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtValidacionAgente, 7, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(18, 10)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(807, 45)
        Me.TableLayoutPanel1.TabIndex = 52
        '
        'txtComercial
        '
        Me.txtComercial.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.txtComercial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComercial.Location = New System.Drawing.Point(516, 23)
        Me.txtComercial.Name = "txtComercial"
        Me.txtComercial.ReadOnly = True
        Me.txtComercial.Size = New System.Drawing.Size(114, 20)
        Me.txtComercial.TabIndex = 60
        Me.txtComercial.Text = "No Verifica"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label18.Location = New System.Drawing.Point(516, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(85, 16)
        Me.Label18.TabIndex = 62
        Me.Label18.Text = "COMERCIAL"
        '
        'txtRiesgo
        '
        Me.txtRiesgo.Location = New System.Drawing.Point(399, 23)
        Me.txtRiesgo.Name = "txtRiesgo"
        Me.txtRiesgo.ReadOnly = True
        Me.txtRiesgo.Size = New System.Drawing.Size(111, 20)
        Me.txtRiesgo.TabIndex = 60
        '
        'txtCCS
        '
        Me.txtCCS.Location = New System.Drawing.Point(3, 23)
        Me.txtCCS.Name = "txtCCS"
        Me.txtCCS.ReadOnly = True
        Me.txtCCS.Size = New System.Drawing.Size(48, 20)
        Me.txtCCS.TabIndex = 51
        '
        'txtOperaciones
        '
        Me.txtOperaciones.Location = New System.Drawing.Point(309, 23)
        Me.txtOperaciones.Name = "txtOperaciones"
        Me.txtOperaciones.ReadOnly = True
        Me.txtOperaciones.Size = New System.Drawing.Size(84, 20)
        Me.txtOperaciones.TabIndex = 47
        '
        'txtCCI
        '
        Me.txtCCI.Location = New System.Drawing.Point(57, 23)
        Me.txtCCI.Name = "txtCCI"
        Me.txtCCI.ReadOnly = True
        Me.txtCCI.Size = New System.Drawing.Size(42, 20)
        Me.txtCCI.TabIndex = 49
        '
        'LOperaciones
        '
        Me.LOperaciones.AutoSize = True
        Me.LOperaciones.BackColor = System.Drawing.Color.Transparent
        Me.LOperaciones.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.LOperaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LOperaciones.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LOperaciones.Location = New System.Drawing.Point(309, 0)
        Me.LOperaciones.Name = "LOperaciones"
        Me.LOperaciones.Size = New System.Drawing.Size(67, 16)
        Me.LOperaciones.TabIndex = 38
        Me.LOperaciones.Text = "AGENCIA"
        '
        'txtSubgerencia
        '
        Me.txtSubgerencia.Location = New System.Drawing.Point(190, 23)
        Me.txtSubgerencia.Name = "txtSubgerencia"
        Me.txtSubgerencia.ReadOnly = True
        Me.txtSubgerencia.Size = New System.Drawing.Size(109, 20)
        Me.txtSubgerencia.TabIndex = 45
        '
        'txtGerencia
        '
        Me.txtGerencia.Location = New System.Drawing.Point(105, 23)
        Me.txtGerencia.Name = "txtGerencia"
        Me.txtGerencia.ReadOnly = True
        Me.txtGerencia.Size = New System.Drawing.Size(79, 20)
        Me.txtGerencia.TabIndex = 46
        '
        'LCCS
        '
        Me.LCCS.AutoSize = True
        Me.LCCS.BackColor = System.Drawing.Color.Transparent
        Me.LCCS.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.LCCS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCCS.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LCCS.Location = New System.Drawing.Point(3, 0)
        Me.LCCS.Name = "LCCS"
        Me.LCCS.Size = New System.Drawing.Size(41, 16)
        Me.LCCS.TabIndex = 50
        Me.LCCS.Text = "C.C.S"
        '
        'LSubGerencia
        '
        Me.LSubGerencia.AutoSize = True
        Me.LSubGerencia.BackColor = System.Drawing.Color.Transparent
        Me.LSubGerencia.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.LSubGerencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSubGerencia.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LSubGerencia.Location = New System.Drawing.Point(190, 0)
        Me.LSubGerencia.Name = "LSubGerencia"
        Me.LSubGerencia.Size = New System.Drawing.Size(109, 16)
        Me.LSubGerencia.TabIndex = 37
        Me.LSubGerencia.Text = "SUB-GERENCIA"
        '
        'LCCI
        '
        Me.LCCI.AutoSize = True
        Me.LCCI.BackColor = System.Drawing.Color.Transparent
        Me.LCCI.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.LCCI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCCI.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LCCI.Location = New System.Drawing.Point(57, 0)
        Me.LCCI.Name = "LCCI"
        Me.LCCI.Size = New System.Drawing.Size(35, 16)
        Me.LCCI.TabIndex = 48
        Me.LCCI.Text = "C.C.I"
        '
        'Lgerencia
        '
        Me.Lgerencia.AutoSize = True
        Me.Lgerencia.BackColor = System.Drawing.Color.Transparent
        Me.Lgerencia.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Lgerencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lgerencia.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Lgerencia.Location = New System.Drawing.Point(105, 0)
        Me.Lgerencia.Name = "Lgerencia"
        Me.Lgerencia.Size = New System.Drawing.Size(77, 16)
        Me.Lgerencia.TabIndex = 36
        Me.Lgerencia.Text = "GERENCIA"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label15.Location = New System.Drawing.Point(399, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 16)
        Me.Label15.TabIndex = 60
        Me.Label15.Text = "VALIDA RIESGO"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label16.Location = New System.Drawing.Point(637, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(114, 16)
        Me.Label16.TabIndex = 61
        Me.Label16.Text = "VALIDA AGENTE"
        '
        'txtValidacionAgente
        '
        Me.txtValidacionAgente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValidacionAgente.Location = New System.Drawing.Point(637, 23)
        Me.txtValidacionAgente.Name = "txtValidacionAgente"
        Me.txtValidacionAgente.ReadOnly = True
        Me.txtValidacionAgente.Size = New System.Drawing.Size(167, 20)
        Me.txtValidacionAgente.TabIndex = 55
        '
        'frmCreditosPorAprobar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1082, 570)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.DGreditosAprobar)
        Me.Name = "frmCreditosPorAprobar"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DGreditosAprobar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtEjecutiva As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtid As System.Windows.Forms.TextBox
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents Txtproducto As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtNrosocio As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Fecha As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents chkAprobar As System.Windows.Forms.ComboBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents DGreditosAprobar As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtOperaciones As System.Windows.Forms.TextBox
    Friend WithEvents txtGerencia As System.Windows.Forms.TextBox
    Friend WithEvents txtSubgerencia As System.Windows.Forms.TextBox
    Friend WithEvents LOperaciones As System.Windows.Forms.Label
    Friend WithEvents LSubGerencia As System.Windows.Forms.Label
    Friend WithEvents Lgerencia As System.Windows.Forms.Label
    Friend WithEvents txtCCS As System.Windows.Forms.TextBox
    Friend WithEvents LCCS As System.Windows.Forms.Label
    Friend WithEvents txtCCI As System.Windows.Forms.TextBox
    Friend WithEvents LCCI As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ChkAutoAvisoRiesgo As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAutoAvisoRiesgo2 As System.Windows.Forms.CheckBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTiempoEspera As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TXTESTADO As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents txtValidacionAgente As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtRiesgo As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TXTTIEMPOESPERA2 As System.Windows.Forms.TextBox
    Friend WithEvents txtFueradeZona As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents txtComercial As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents CboSonido As ComboBox
End Class
