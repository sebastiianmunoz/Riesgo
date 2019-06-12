<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AVISO
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
        Me.Lnombre = New System.Windows.Forms.Label()
        Me.Lnrosocio = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAvisos = New System.Windows.Forms.TextBox()
        Me.BtnAceptarError = New System.Windows.Forms.Button()
        Me.BtnAceptarVerificar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "El Socio :"
        '
        'Lnombre
        '
        Me.Lnombre.AutoSize = True
        Me.Lnombre.BackColor = System.Drawing.Color.Transparent
        Me.Lnombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnombre.Location = New System.Drawing.Point(88, 9)
        Me.Lnombre.Name = "Lnombre"
        Me.Lnombre.Size = New System.Drawing.Size(70, 16)
        Me.Lnombre.TabIndex = 1
        Me.Lnombre.Text = "(nombre)"
        '
        'Lnrosocio
        '
        Me.Lnrosocio.AutoSize = True
        Me.Lnrosocio.BackColor = System.Drawing.Color.Transparent
        Me.Lnrosocio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnrosocio.Location = New System.Drawing.Point(602, 9)
        Me.Lnrosocio.Name = "Lnrosocio"
        Me.Lnrosocio.Size = New System.Drawing.Size(78, 16)
        Me.Lnrosocio.TabIndex = 2
        Me.Lnrosocio.Text = "(nrosocio)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(524, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Nro Socio:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(384, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "No puede evaluar su credito debido a los siguientes conflictos :"
        '
        'txtAvisos
        '
        Me.txtAvisos.Location = New System.Drawing.Point(15, 81)
        Me.txtAvisos.Multiline = True
        Me.txtAvisos.Name = "txtAvisos"
        Me.txtAvisos.Size = New System.Drawing.Size(419, 117)
        Me.txtAvisos.TabIndex = 5
        '
        'BtnAceptarError
        '
        Me.BtnAceptarError.Location = New System.Drawing.Point(637, 196)
        Me.BtnAceptarError.Name = "BtnAceptarError"
        Me.BtnAceptarError.Size = New System.Drawing.Size(75, 23)
        Me.BtnAceptarError.TabIndex = 6
        Me.BtnAceptarError.Text = "Aceptar"
        Me.BtnAceptarError.UseVisualStyleBackColor = True
        Me.BtnAceptarError.Visible = False
        '
        'BtnAceptarVerificar
        '
        Me.BtnAceptarVerificar.Location = New System.Drawing.Point(637, 196)
        Me.BtnAceptarVerificar.Name = "BtnAceptarVerificar"
        Me.BtnAceptarVerificar.Size = New System.Drawing.Size(75, 23)
        Me.BtnAceptarVerificar.TabIndex = 7
        Me.BtnAceptarVerificar.Text = "Aceptar"
        Me.BtnAceptarVerificar.UseVisualStyleBackColor = True
        Me.BtnAceptarVerificar.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 206)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(330, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "*EDITAR EN FICHA SISTEMA CUENTA CORRIENTE"
        '
        'AVISO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SistemaRiesgos.My.Resources.Resources.Informe4
        Me.ClientSize = New System.Drawing.Size(734, 231)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnAceptarVerificar)
        Me.Controls.Add(Me.BtnAceptarError)
        Me.Controls.Add(Me.txtAvisos)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Lnrosocio)
        Me.Controls.Add(Me.Lnombre)
        Me.Controls.Add(Me.Label1)
        Me.Name = "AVISO"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Lnombre As System.Windows.Forms.Label
    Friend WithEvents Lnrosocio As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAvisos As System.Windows.Forms.TextBox
    Friend WithEvents BtnAceptarError As System.Windows.Forms.Button
    Friend WithEvents BtnAceptarVerificar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
