<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGestionPerfil
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ListPerfil = New System.Windows.Forms.CheckedListBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.CboTipo = New System.Windows.Forms.ComboBox()
        Me.txtCod = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.DGUsuarios = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cboDepartamento = New System.Windows.Forms.ComboBox()
        Me.cboAtributo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
        Me.ListAtributos = New System.Windows.Forms.CheckedListBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        CType(Me.DGUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(59, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(713, 277)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(218, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Modificar Usuario y Permisos"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(393, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "COD PERFIL"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(394, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "NOMBRE"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(393, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "USUARIO"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(393, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "DEPARTAMENTO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(394, 203)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "UBICACIÓN"
        '
        'ListPerfil
        '
        Me.ListPerfil.FormattingEnabled = True
        Me.ListPerfil.Items.AddRange(New Object() {"Evaluar" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & "/ Personas", "Evaluar        " & Global.Microsoft.VisualBasic.ChrW(9) & "/ Empresas", "Estados      " & Global.Microsoft.VisualBasic.ChrW(9) & "/ Riesgo", "Estados     " & Global.Microsoft.VisualBasic.ChrW(9) & "/ Por Aprobar", "Estados" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & "/ Mis Prestamos", "Estados" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & "/ Historico", "Auditoria" & Global.Microsoft.VisualBasic.ChrW(9) & "/ Puntajes", "Estadisticas" & Global.Microsoft.VisualBasic.ChrW(9) & "/ Ejecutivos", "Estadisticas" & Global.Microsoft.VisualBasic.ChrW(9) & "/ Prestamos", "Perfil" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(9) & "/ Gestor", "Evaluar        " & Global.Microsoft.VisualBasic.ChrW(9) & "/Capital", "Nomina Transfer      " & Global.Microsoft.VisualBasic.ChrW(9) & "/Capital", "Giros Pendientes      " & Global.Microsoft.VisualBasic.ChrW(9) & "/Capital", "Disponibilidad Capital   /Capital", "Estado Solicitud Capital/Capital", "Otros / Captaciones", "Otros /Txt Captaciones"})
        Me.ListPerfil.Location = New System.Drawing.Point(710, 43)
        Me.ListPerfil.Name = "ListPerfil"
        Me.ListPerfil.Size = New System.Drawing.Size(221, 199)
        Me.ListPerfil.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(707, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Tipo"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(872, 12)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(59, 23)
        Me.Button4.TabIndex = 14
        Me.Button4.Text = "Buscar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'CboTipo
        '
        Me.CboTipo.FormattingEnabled = True
        Me.CboTipo.Items.AddRange(New Object() {"Personalizado", "Administrador", "SubAdministrador", "Ejecutivo", "Evaluador", "Riesgo nivel 1", "Riesgo nivel 2"})
        Me.CboTipo.Location = New System.Drawing.Point(741, 13)
        Me.CboTipo.Name = "CboTipo"
        Me.CboTipo.Size = New System.Drawing.Size(105, 21)
        Me.CboTipo.TabIndex = 15
        '
        'txtCod
        '
        Me.txtCod.Location = New System.Drawing.Point(394, 43)
        Me.txtCod.Name = "txtCod"
        Me.txtCod.Size = New System.Drawing.Size(310, 20)
        Me.txtCod.TabIndex = 16
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(394, 85)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(310, 20)
        Me.txtNombre.TabIndex = 17
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(394, 126)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(310, 20)
        Me.txtUsuario.TabIndex = 18
        '
        'DGUsuarios
        '
        Me.DGUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGUsuarios.Location = New System.Drawing.Point(12, 12)
        Me.DGUsuarios.Name = "DGUsuarios"
        Me.DGUsuarios.Size = New System.Drawing.Size(364, 324)
        Me.DGUsuarios.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(713, 248)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(218, 23)
        Me.Button2.TabIndex = 23
        Me.Button2.Text = "Crear Usuario"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cboDepartamento
        '
        Me.cboDepartamento.FormattingEnabled = True
        Me.cboDepartamento.Items.AddRange(New Object() {"AGENCIA", "AUDITORIA", "COMISIONI", "COMISIONS", "GERENTE", "INFORMATICA", "NORMALIZACION", "OPERACIONES", "SUBGENRENTE", "SUBGERENTE", "SFINANZAS"})
        Me.cboDepartamento.Location = New System.Drawing.Point(395, 170)
        Me.cboDepartamento.Name = "cboDepartamento"
        Me.cboDepartamento.Size = New System.Drawing.Size(309, 21)
        Me.cboDepartamento.TabIndex = 26
        '
        'cboAtributo
        '
        Me.cboAtributo.FormattingEnabled = True
        Me.cboAtributo.Items.AddRange(New Object() {"AGENCIA", "AUDITOR", "COMISIONI", "COMISIONS", "GENERAL", "GERENTE", "RIESGO", "SUBGERENTE"})
        Me.cboAtributo.Location = New System.Drawing.Point(395, 264)
        Me.cboAtributo.Name = "cboAtributo"
        Me.cboAtributo.Size = New System.Drawing.Size(309, 21)
        Me.cboAtributo.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(395, 249)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "ATRIBUTO EVALUACION"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(713, 335)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(218, 23)
        Me.Button3.TabIndex = 29
        Me.Button3.Text = "Restablecer Contraseña"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(713, 306)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(218, 23)
        Me.Button5.TabIndex = 30
        Me.Button5.Text = "Eliminar Usuario"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'cboSucursal
        '
        Me.cboSucursal.FormattingEnabled = True
        Me.cboSucursal.Items.AddRange(New Object() {"VALPARAÍSO          ", "VIÑA DEL MAR        "})
        Me.cboSucursal.Location = New System.Drawing.Point(395, 219)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(309, 21)
        Me.cboSucursal.TabIndex = 102
        '
        'ListAtributos
        '
        Me.ListAtributos.FormattingEnabled = True
        Me.ListAtributos.Items.AddRange(New Object() {"Creditos Pre-Agente", "Creditos Riesgo", "Creditos Agente", "Prepago Agente", "Creditos Subgerente ", "Capital Subgerente ", "Nominas Subgerente ", "Creditos Gerente", "Creditos CCI", "Creditos CCS"})
        Me.ListAtributos.Location = New System.Drawing.Point(950, 43)
        Me.ListAtributos.Name = "ListAtributos"
        Me.ListAtributos.Size = New System.Drawing.Size(221, 199)
        Me.ListAtributos.TabIndex = 103
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(947, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(150, 13)
        Me.Label8.TabIndex = 104
        Me.Label8.Text = "ATRIBUTOS AUTORIZADOS"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(950, 249)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(218, 23)
        Me.Button6.TabIndex = 105
        Me.Button6.Text = "Ver Atributos"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(950, 278)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(218, 23)
        Me.Button7.TabIndex = 106
        Me.Button7.Text = "Modificar Atributos"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'FrmGestionPerfil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1236, 360)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ListAtributos)
        Me.Controls.Add(Me.cboSucursal)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboAtributo)
        Me.Controls.Add(Me.cboDepartamento)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtCod)
        Me.Controls.Add(Me.CboTipo)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ListPerfil)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGUsuarios)
        Me.Name = "FrmGestionPerfil"
        Me.Text = "FrmGestionPerfil"
        CType(Me.DGUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ListPerfil As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents CboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents txtCod As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents DGUsuarios As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cboDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents cboAtributo As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents ListAtributos As CheckedListBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
End Class
