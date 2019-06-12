<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrepago
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
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtTotalaPagar = New System.Windows.Forms.TextBox()
        Me.txtComisionAnticipoCredito = New System.Windows.Forms.TextBox()
        Me.txtInteresdelmes = New System.Windows.Forms.TextBox()
        Me.txtInteresVencidoNoPagado = New System.Windows.Forms.TextBox()
        Me.txtCapitalPrestamo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtSaldoInsoluto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LboxConsumo = New System.Windows.Forms.ListBox()
        Me.LboxEmergencia = New System.Windows.Forms.ListBox()
        Me.LBoxAdicional = New System.Windows.Forms.ListBox()
        Me.LBoxComercial = New System.Windows.Forms.ListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCuotasPrestamos = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Quitar = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.LboxAgregados = New System.Windows.Forms.ListBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(19, 136)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(61, 23)
        Me.btnAgregar.TabIndex = 1
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(28, 169)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(171, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "(+) Saldo Capital Prestamo "
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.BackgroundImage = Global.SistemaRiesgos.My.Resources.Resources.Informe4
        Me.Panel1.Controls.Add(Me.txtTotalaPagar)
        Me.Panel1.Controls.Add(Me.txtComisionAnticipoCredito)
        Me.Panel1.Controls.Add(Me.txtInteresdelmes)
        Me.Panel1.Controls.Add(Me.txtInteresVencidoNoPagado)
        Me.Panel1.Controls.Add(Me.txtCapitalPrestamo)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(86, 260)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(398, 86)
        Me.Panel1.TabIndex = 3
        '
        'txtTotalaPagar
        '
        Me.txtTotalaPagar.Location = New System.Drawing.Point(258, 244)
        Me.txtTotalaPagar.Name = "txtTotalaPagar"
        Me.txtTotalaPagar.Size = New System.Drawing.Size(125, 20)
        Me.txtTotalaPagar.TabIndex = 21
        '
        'txtComisionAnticipoCredito
        '
        Me.txtComisionAnticipoCredito.Location = New System.Drawing.Point(258, 190)
        Me.txtComisionAnticipoCredito.Name = "txtComisionAnticipoCredito"
        Me.txtComisionAnticipoCredito.Size = New System.Drawing.Size(125, 20)
        Me.txtComisionAnticipoCredito.TabIndex = 18
        '
        'txtInteresdelmes
        '
        Me.txtInteresdelmes.Location = New System.Drawing.Point(258, 156)
        Me.txtInteresdelmes.Name = "txtInteresdelmes"
        Me.txtInteresdelmes.Size = New System.Drawing.Size(125, 20)
        Me.txtInteresdelmes.TabIndex = 16
        '
        'txtInteresVencidoNoPagado
        '
        Me.txtInteresVencidoNoPagado.Location = New System.Drawing.Point(258, 198)
        Me.txtInteresVencidoNoPagado.Name = "txtInteresVencidoNoPagado"
        Me.txtInteresVencidoNoPagado.Size = New System.Drawing.Size(125, 20)
        Me.txtInteresVencidoNoPagado.TabIndex = 14
        '
        'txtCapitalPrestamo
        '
        Me.txtCapitalPrestamo.Location = New System.Drawing.Point(258, 169)
        Me.txtCapitalPrestamo.Name = "txtCapitalPrestamo"
        Me.txtCapitalPrestamo.Size = New System.Drawing.Size(125, 20)
        Me.txtCapitalPrestamo.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label11.Location = New System.Drawing.Point(255, 221)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 16)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "------------------------------"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label10.Location = New System.Drawing.Point(28, 244)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(108, 16)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "(=) Total a Pagar"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(28, 190)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(221, 16)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "(+) Comisión por anticipo del crédito"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(28, 160)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "(+) Intereses del mes"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(255, 221)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "------------------------------"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(28, 201)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(195, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "(+) Interes Vencido No Pagado "
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label17.Location = New System.Drawing.Point(279, 363)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(170, 16)
        Me.Label17.TabIndex = 22
        Me.Label17.Text = "Individual del prestamo"
        '
        'txtSaldoInsoluto
        '
        Me.txtSaldoInsoluto.Location = New System.Drawing.Point(170, 178)
        Me.txtSaldoInsoluto.Name = "txtSaldoInsoluto"
        Me.txtSaldoInsoluto.ReadOnly = True
        Me.txtSaldoInsoluto.Size = New System.Drawing.Size(427, 20)
        Me.txtSaldoInsoluto.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(16, 182)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Abono a prestamo"
        '
        'LboxConsumo
        '
        Me.LboxConsumo.FormattingEnabled = True
        Me.LboxConsumo.Location = New System.Drawing.Point(19, 43)
        Me.LboxConsumo.Name = "LboxConsumo"
        Me.LboxConsumo.Size = New System.Drawing.Size(130, 95)
        Me.LboxConsumo.TabIndex = 6
        '
        'LboxEmergencia
        '
        Me.LboxEmergencia.FormattingEnabled = True
        Me.LboxEmergencia.Location = New System.Drawing.Point(170, 42)
        Me.LboxEmergencia.Name = "LboxEmergencia"
        Me.LboxEmergencia.Size = New System.Drawing.Size(130, 95)
        Me.LboxEmergencia.TabIndex = 7
        '
        'LBoxAdicional
        '
        Me.LBoxAdicional.FormattingEnabled = True
        Me.LBoxAdicional.Location = New System.Drawing.Point(317, 43)
        Me.LBoxAdicional.Name = "LBoxAdicional"
        Me.LBoxAdicional.Size = New System.Drawing.Size(130, 95)
        Me.LBoxAdicional.TabIndex = 8
        '
        'LBoxComercial
        '
        Me.LBoxComercial.FormattingEnabled = True
        Me.LBoxComercial.Location = New System.Drawing.Point(467, 43)
        Me.LBoxComercial.Name = "LBoxComercial"
        Me.LBoxComercial.Size = New System.Drawing.Size(130, 95)
        Me.LBoxComercial.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(16, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Social"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label9.Location = New System.Drawing.Point(167, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 16)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Emergencia"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label12.Location = New System.Drawing.Point(338, 82)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(0, 16)
        Me.Label12.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label13.Location = New System.Drawing.Point(314, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 16)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Adicional"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label14.Location = New System.Drawing.Point(464, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(78, 16)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Comercial"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(94, 136)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(55, 23)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Ver"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(238, 136)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(62, 23)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "Ver"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(170, 136)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(62, 23)
        Me.Button3.TabIndex = 16
        Me.Button3.Text = "Agregar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(385, 136)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(62, 23)
        Me.Button4.TabIndex = 19
        Me.Button4.Text = "Ver"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(317, 136)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(62, 23)
        Me.Button5.TabIndex = 18
        Me.Button5.Text = "Agregar"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(535, 136)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(62, 23)
        Me.Button6.TabIndex = 21
        Me.Button6.Text = "Ver"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(467, 136)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(62, 23)
        Me.Button7.TabIndex = 20
        Me.Button7.Text = "Agregar"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label16.Location = New System.Drawing.Point(83, 379)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(210, 16)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "Acumulado de los Prestamos"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label8.Location = New System.Drawing.Point(13, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(157, 16)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Monto Acumulado Cuota "
        '
        'txtCuotasPrestamos
        '
        Me.txtCuotasPrestamos.Location = New System.Drawing.Point(11, 85)
        Me.txtCuotasPrestamos.Name = "txtCuotasPrestamos"
        Me.txtCuotasPrestamos.ReadOnly = True
        Me.txtCuotasPrestamos.Size = New System.Drawing.Size(407, 20)
        Me.txtCuotasPrestamos.TabIndex = 30
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.BackgroundImage = Global.SistemaRiesgos.My.Resources.Resources.Informe4
        Me.Panel2.Controls.Add(Me.Button10)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.txtMonto)
        Me.Panel2.Controls.Add(Me.LboxEmergencia)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.txtSaldoInsoluto)
        Me.Panel2.Controls.Add(Me.Button9)
        Me.Panel2.Controls.Add(Me.Quitar)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Button8)
        Me.Panel2.Controls.Add(Me.btnAgregar)
        Me.Panel2.Controls.Add(Me.LboxConsumo)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.LboxAgregados)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.LBoxAdicional)
        Me.Panel2.Controls.Add(Me.Button6)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Button7)
        Me.Panel2.Controls.Add(Me.Button5)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.LBoxComercial)
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Location = New System.Drawing.Point(12, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(894, 217)
        Me.Panel2.TabIndex = 31
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(794, 139)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(91, 23)
        Me.Button10.TabIndex = 29
        Me.Button10.Text = "Volver"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(652, 178)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.ReadOnly = True
        Me.txtMonto.Size = New System.Drawing.Size(232, 20)
        Me.txtMonto.TabIndex = 25
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(795, 110)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(91, 23)
        Me.Button9.TabIndex = 27
        Me.Button9.Text = "Limpiar"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Quitar
        '
        Me.Quitar.Location = New System.Drawing.Point(794, 75)
        Me.Quitar.Name = "Quitar"
        Me.Quitar.Size = New System.Drawing.Size(90, 23)
        Me.Quitar.TabIndex = 28
        Me.Quitar.Text = "Quitar"
        Me.Quitar.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(794, 43)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(91, 23)
        Me.Button8.TabIndex = 26
        Me.Button8.Text = "Solicitar"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'LboxAgregados
        '
        Me.LboxAgregados.FormattingEnabled = True
        Me.LboxAgregados.Location = New System.Drawing.Point(653, 41)
        Me.LboxAgregados.Name = "LboxAgregados"
        Me.LboxAgregados.Size = New System.Drawing.Size(130, 121)
        Me.LboxAgregados.TabIndex = 22
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label15.Location = New System.Drawing.Point(653, 17)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 16)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "Agregados"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel3.BackgroundImage = Global.SistemaRiesgos.My.Resources.Resources.Informe4
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.txtCuotasPrestamos)
        Me.Panel3.Location = New System.Drawing.Point(501, 352)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(427, 117)
        Me.Panel3.TabIndex = 32
        '
        'frmPrepago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(916, 237)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmPrepago"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotalaPagar As System.Windows.Forms.TextBox
    Friend WithEvents txtComisionAnticipoCredito As System.Windows.Forms.TextBox
    Friend WithEvents txtInteresdelmes As System.Windows.Forms.TextBox
    Friend WithEvents txtSaldoInsoluto As System.Windows.Forms.TextBox
    Friend WithEvents txtInteresVencidoNoPagado As System.Windows.Forms.TextBox
    Friend WithEvents txtCapitalPrestamo As System.Windows.Forms.TextBox
    Friend WithEvents LboxConsumo As System.Windows.Forms.ListBox
    Friend WithEvents LboxEmergencia As System.Windows.Forms.ListBox
    Friend WithEvents LBoxAdicional As System.Windows.Forms.ListBox
    Friend WithEvents LBoxComercial As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCuotasPrestamos As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Button10 As Button
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents Button9 As Button
    Friend WithEvents Quitar As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents LboxAgregados As ListBox
    Friend WithEvents Label15 As Label
End Class
