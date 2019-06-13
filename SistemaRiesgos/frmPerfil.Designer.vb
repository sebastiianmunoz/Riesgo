<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPerfil
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPerfil))
        Me.LblVesion = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtContrasena = New System.Windows.Forms.TextBox()
        Me.CbmUsuario = New System.Windows.Forms.ComboBox()
        Me.TxtSede = New System.Windows.Forms.TextBox()
        Me.textusuario = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'LblVesion
        '
        Me.LblVesion.AutoSize = True
        Me.LblVesion.BackColor = System.Drawing.Color.Transparent
        Me.LblVesion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVesion.ForeColor = System.Drawing.SystemColors.Control
        Me.LblVesion.Location = New System.Drawing.Point(238, 67)
        Me.LblVesion.Name = "LblVesion"
        Me.LblVesion.Size = New System.Drawing.Size(63, 20)
        Me.LblVesion.TabIndex = 22
        Me.LblVesion.Text = "Label5"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(499, 239)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "CONTRASEÑA"
        '
        'TxtContrasena
        '
        Me.TxtContrasena.Location = New System.Drawing.Point(174, 157)
        Me.TxtContrasena.Name = "TxtContrasena"
        Me.TxtContrasena.Size = New System.Drawing.Size(194, 20)
        Me.TxtContrasena.TabIndex = 16
        Me.TxtContrasena.UseSystemPasswordChar = True
        '
        'CbmUsuario
        '
        Me.CbmUsuario.FormattingEnabled = True
        Me.CbmUsuario.Location = New System.Drawing.Point(173, 108)
        Me.CbmUsuario.Name = "CbmUsuario"
        Me.CbmUsuario.Size = New System.Drawing.Size(194, 21)
        Me.CbmUsuario.TabIndex = 15
        '
        'TxtSede
        '
        Me.TxtSede.Location = New System.Drawing.Point(503, 203)
        Me.TxtSede.Name = "TxtSede"
        Me.TxtSede.Size = New System.Drawing.Size(140, 20)
        Me.TxtSede.TabIndex = 24
        Me.TxtSede.UseSystemPasswordChar = True
        Me.TxtSede.Visible = False
        '
        'textusuario
        '
        Me.textusuario.Location = New System.Drawing.Point(503, 242)
        Me.textusuario.Name = "textusuario"
        Me.textusuario.Size = New System.Drawing.Size(58, 20)
        Me.textusuario.TabIndex = 26
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Location = New System.Drawing.Point(-1, 240)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(32, 28)
        Me.Panel1.TabIndex = 38
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Location = New System.Drawing.Point(107, 220)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(194, 28)
        Me.Panel3.TabIndex = 46
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Label5.Location = New System.Drawing.Point(85, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(157, 20)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "Sistema Riesgo V."
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(260, 184)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox1.TabIndex = 49
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'frmPerfil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(131, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(86, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(396, 267)
        Me.ControlBox = False
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.textusuario)
        Me.Controls.Add(Me.TxtSede)
        Me.Controls.Add(Me.LblVesion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtContrasena)
        Me.Controls.Add(Me.CbmUsuario)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPerfil"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblVesion As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtContrasena As System.Windows.Forms.TextBox
    Friend WithEvents CbmUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents TxtSede As System.Windows.Forms.TextBox
    Friend WithEvents textusuario As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As CheckBox
End Class
