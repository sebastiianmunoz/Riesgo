<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreditosRiesgo
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
        Me.DGreditosRiesgo = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtEjecutiva = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtid = New System.Windows.Forms.TextBox()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Txtproducto = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.txtNrosocio = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Fecha = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ChkAutoAvisoRiesgo = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        CType(Me.DGreditosRiesgo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGreditosRiesgo
        '
        Me.DGreditosRiesgo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.DGreditosRiesgo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGreditosRiesgo.Location = New System.Drawing.Point(16, 12)
        Me.DGreditosRiesgo.Name = "DGreditosRiesgo"
        Me.DGreditosRiesgo.Size = New System.Drawing.Size(781, 423)
        Me.DGreditosRiesgo.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(821, 7)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(236, 462)
        Me.TabControl1.TabIndex = 17
        '
        'TabPage2
        '
        Me.TabPage2.BackgroundImage = Global.SistemaRiesgos.My.Resources.Resources.Informe4
        Me.TabPage2.Controls.Add(Me.txtEjecutiva)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.txtid)
        Me.TabPage2.Controls.Add(Me.txtSucursal)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.txtMonto)
        Me.TabPage2.Controls.Add(Me.Txtproducto)
        Me.TabPage2.Controls.Add(Me.txtFecha)
        Me.TabPage2.Controls.Add(Me.txtNrosocio)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.DateTimePicker2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.Fecha)
        Me.TabPage2.Controls.Add(Me.Button3)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(228, 436)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Analizar"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtEjecutiva
        '
        Me.txtEjecutiva.Location = New System.Drawing.Point(19, 291)
        Me.txtEjecutiva.Name = "txtEjecutiva"
        Me.txtEjecutiva.ReadOnly = True
        Me.txtEjecutiva.Size = New System.Drawing.Size(191, 20)
        Me.txtEjecutiva.TabIndex = 51
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(19, 261)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 16)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "EJECUTIVA:"
        '
        'txtid
        '
        Me.txtid.Location = New System.Drawing.Point(21, 448)
        Me.txtid.Multiline = True
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(194, 24)
        Me.txtid.TabIndex = 37
        Me.txtid.Visible = False
        '
        'txtSucursal
        '
        Me.txtSucursal.Location = New System.Drawing.Point(18, 347)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.ReadOnly = True
        Me.txtSucursal.Size = New System.Drawing.Size(191, 20)
        Me.txtSucursal.TabIndex = 49
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(19, 323)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 16)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "SUCURSAL:"
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(18, 227)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.ReadOnly = True
        Me.txtMonto.Size = New System.Drawing.Size(191, 20)
        Me.txtMonto.TabIndex = 47
        '
        'Txtproducto
        '
        Me.Txtproducto.Location = New System.Drawing.Point(18, 159)
        Me.Txtproducto.Name = "Txtproducto"
        Me.Txtproducto.ReadOnly = True
        Me.Txtproducto.Size = New System.Drawing.Size(191, 20)
        Me.Txtproducto.TabIndex = 46
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(18, 101)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(191, 20)
        Me.txtFecha.TabIndex = 45
        '
        'txtNrosocio
        '
        Me.txtNrosocio.Location = New System.Drawing.Point(18, 40)
        Me.txtNrosocio.Name = "txtNrosocio"
        Me.txtNrosocio.ReadOnly = True
        Me.txtNrosocio.Size = New System.Drawing.Size(191, 20)
        Me.txtNrosocio.TabIndex = 44
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(18, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 16)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "PRODUCTO:"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(3, 520)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(207, 20)
        Me.DateTimePicker2.TabIndex = 41
        Me.DateTimePicker2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(18, 197)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 16)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "MONTO SOLICITADO:"
        '
        'Fecha
        '
        Me.Fecha.AutoSize = True
        Me.Fecha.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fecha.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Fecha.Location = New System.Drawing.Point(18, 78)
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Size = New System.Drawing.Size(62, 16)
        Me.Fecha.TabIndex = 38
        Me.Fecha.Text = "FECHA:"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(18, 383)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(194, 23)
        Me.Button3.TabIndex = 35
        Me.Button3.Text = "Analizar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(15, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 16)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "NUMERO SOCIO:"
        '
        'TabPage1
        '
        Me.TabPage1.BackgroundImage = Global.SistemaRiesgos.My.Resources.Resources.Informe4
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.ComboBox2)
        Me.TabPage1.Controls.Add(Me.Button9)
        Me.TabPage1.Controls.Add(Me.Button10)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(228, 436)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Busqueda"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(9, 129)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(207, 23)
        Me.Button1.TabIndex = 45
        Me.Button1.Text = "ACTUALIZAR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboBox2
        '
        Me.ComboBox2.Enabled = False
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"", "Edad", "EstadoCivil", "FormaPago", "Ingreso", "Ncreditos", "Socio", "TipoIngreso", "Vivienda"})
        Me.ComboBox2.Location = New System.Drawing.Point(9, 69)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(207, 21)
        Me.ComboBox2.TabIndex = 43
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(9, 100)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(207, 23)
        Me.Button9.TabIndex = 37
        Me.Button9.Text = "BUSQUEDA POR CATEGORIA"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(9, 32)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(207, 23)
        Me.Button10.TabIndex = 36
        Me.Button10.Text = "BUSQUEDA GENERAL"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'ChkAutoAvisoRiesgo
        '
        Me.ChkAutoAvisoRiesgo.AutoSize = True
        Me.ChkAutoAvisoRiesgo.BackColor = System.Drawing.Color.Transparent
        Me.ChkAutoAvisoRiesgo.Checked = True
        Me.ChkAutoAvisoRiesgo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkAutoAvisoRiesgo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAutoAvisoRiesgo.ForeColor = System.Drawing.Color.Transparent
        Me.ChkAutoAvisoRiesgo.Location = New System.Drawing.Point(696, 441)
        Me.ChkAutoAvisoRiesgo.Name = "ChkAutoAvisoRiesgo"
        Me.ChkAutoAvisoRiesgo.Size = New System.Drawing.Size(101, 19)
        Me.ChkAutoAvisoRiesgo.TabIndex = 53
        Me.ChkAutoAvisoRiesgo.Text = "AUTOAVISO"
        Me.ChkAutoAvisoRiesgo.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(13, 446)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(173, 16)
        Me.Label7.TabIndex = 58
        Me.Label7.Text = "AUTO-ACTUALIZACIÓN"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(16, 465)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(781, 14)
        Me.ProgressBar1.TabIndex = 57
        '
        'frmCreditosRiesgo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1085, 491)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.ChkAutoAvisoRiesgo)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.DGreditosRiesgo)
        Me.Name = "frmCreditosRiesgo"
        CType(Me.DGreditosRiesgo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGreditosRiesgo As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtNrosocio As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Fecha As System.Windows.Forms.Label
    Friend WithEvents txtid As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEjecutiva As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents Txtproducto As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ChkAutoAvisoRiesgo As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
