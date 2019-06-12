<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAprobarNominaGiroCapital
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtestadonomina = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEjecutivo = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.Label117 = New System.Windows.Forms.Label()
        Me.txtCodigoId = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMontonomina = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Gridnomina = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TXTCARGO = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.txtContrasena = New System.Windows.Forms.TextBox()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.CboAprobar = New System.Windows.Forms.ComboBox()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Gridemergencia = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.Gridnomina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gridemergencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtestadonomina, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSucursal, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtEjecutivo, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtFecha, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label117, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCodigoId, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtMontonomina, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 5, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(275, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(778, 48)
        Me.TableLayoutPanel1.TabIndex = 86
        '
        'txtestadonomina
        '
        Me.txtestadonomina.Location = New System.Drawing.Point(652, 22)
        Me.txtestadonomina.Name = "txtestadonomina"
        Me.txtestadonomina.Size = New System.Drawing.Size(91, 20)
        Me.txtestadonomina.TabIndex = 96
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(546, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 15)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "Monto Nomina"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Sucursal:"
        '
        'txtSucursal
        '
        Me.txtSucursal.Location = New System.Drawing.Point(3, 22)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.ReadOnly = True
        Me.txtSucursal.Size = New System.Drawing.Size(121, 20)
        Me.txtSucursal.TabIndex = 46
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(130, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Ejecutivo:"
        '
        'txtEjecutivo
        '
        Me.txtEjecutivo.Location = New System.Drawing.Point(130, 22)
        Me.txtEjecutivo.Name = "txtEjecutivo"
        Me.txtEjecutivo.ReadOnly = True
        Me.txtEjecutivo.Size = New System.Drawing.Size(129, 20)
        Me.txtEjecutivo.TabIndex = 45
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(265, 22)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(123, 20)
        Me.txtFecha.TabIndex = 10
        '
        'Label117
        '
        Me.Label117.AutoSize = True
        Me.Label117.BackColor = System.Drawing.Color.Transparent
        Me.Label117.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label117.Location = New System.Drawing.Point(265, 0)
        Me.Label117.Name = "Label117"
        Me.Label117.Size = New System.Drawing.Size(94, 15)
        Me.Label117.TabIndex = 9
        Me.Label117.Text = "Fecha Solicitud:"
        '
        'txtCodigoId
        '
        Me.txtCodigoId.Location = New System.Drawing.Point(417, 22)
        Me.txtCodigoId.Name = "txtCodigoId"
        Me.txtCodigoId.ReadOnly = True
        Me.txtCodigoId.Size = New System.Drawing.Size(123, 20)
        Me.txtCodigoId.TabIndex = 55
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(417, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 15)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "Nro Nomina:"
        '
        'txtMontonomina
        '
        Me.txtMontonomina.Location = New System.Drawing.Point(546, 22)
        Me.txtMontonomina.Name = "txtMontonomina"
        Me.txtMontonomina.Size = New System.Drawing.Size(91, 20)
        Me.txtMontonomina.TabIndex = 56
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(652, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 15)
        Me.Label5.TabIndex = 97
        Me.Label5.Text = "Estado Nomina"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(28, 60)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1044, 416)
        Me.TabControl1.TabIndex = 87
        '
        'TabPage1
        '
        Me.TabPage1.BackgroundImage = Global.SistemaRiesgos.My.Resources.Resources.Informe4
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.Gridnomina)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1036, 390)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Nomina"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(877, 351)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(122, 20)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "Seleccionar Todo"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Gridnomina
        '
        Me.Gridnomina.AllowUserToAddRows = False
        Me.Gridnomina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Gridnomina.Location = New System.Drawing.Point(6, 20)
        Me.Gridnomina.Name = "Gridnomina"
        Me.Gridnomina.Size = New System.Drawing.Size(993, 316)
        Me.Gridnomina.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(32, 482)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 95
        Me.Button2.Text = "Volver"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TXTCARGO
        '
        Me.TXTCARGO.AutoSize = True
        Me.TXTCARGO.BackColor = System.Drawing.Color.Transparent
        Me.TXTCARGO.Location = New System.Drawing.Point(597, 487)
        Me.TXTCARGO.Name = "TXTCARGO"
        Me.TXTCARGO.Size = New System.Drawing.Size(0, 13)
        Me.TXTCARGO.TabIndex = 94
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.BackColor = System.Drawing.Color.Transparent
        Me.Label63.Location = New System.Drawing.Point(628, 487)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(0, 13)
        Me.Label63.TabIndex = 90
        '
        'txtContrasena
        '
        Me.txtContrasena.Location = New System.Drawing.Point(881, 491)
        Me.txtContrasena.Name = "txtContrasena"
        Me.txtContrasena.Size = New System.Drawing.Size(100, 20)
        Me.txtContrasena.TabIndex = 92
        Me.txtContrasena.UseSystemPasswordChar = True
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.BackColor = System.Drawing.Color.Transparent
        Me.Label64.Location = New System.Drawing.Point(794, 502)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(81, 13)
        Me.Label64.TabIndex = 91
        Me.Label64.Text = "CONTRASEÑA"
        '
        'CboAprobar
        '
        Me.CboAprobar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboAprobar.FormattingEnabled = True
        Me.CboAprobar.Location = New System.Drawing.Point(589, 487)
        Me.CboAprobar.Name = "CboAprobar"
        Me.CboAprobar.Size = New System.Drawing.Size(192, 26)
        Me.CboAprobar.TabIndex = 89
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.BackColor = System.Drawing.Color.Transparent
        Me.Label65.Location = New System.Drawing.Point(512, 500)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(71, 13)
        Me.Label65.TabIndex = 93
        Me.Label65.Text = "¿APROBAR?"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1000, 488)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 88
        Me.Button1.Text = "Enviar "
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Gridemergencia
        '
        Me.Gridemergencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Gridemergencia.Location = New System.Drawing.Point(362, 588)
        Me.Gridemergencia.Name = "Gridemergencia"
        Me.Gridemergencia.Size = New System.Drawing.Size(102, 20)
        Me.Gridemergencia.TabIndex = 96
        '
        'frmAprobarNominaGiroCapital
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1101, 578)
        Me.Controls.Add(Me.Gridemergencia)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TXTCARGO)
        Me.Controls.Add(Me.Label63)
        Me.Controls.Add(Me.txtContrasena)
        Me.Controls.Add(Me.Label64)
        Me.Controls.Add(Me.CboAprobar)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmAprobarNominaGiroCapital"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.Gridnomina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gridemergencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEjecutivo As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label117 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoId As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Gridnomina As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TXTCARGO As System.Windows.Forms.Label
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents txtContrasena As System.Windows.Forms.TextBox
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents CboAprobar As System.Windows.Forms.ComboBox
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMontonomina As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtestadonomina As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Gridemergencia As System.Windows.Forms.DataGridView
End Class
