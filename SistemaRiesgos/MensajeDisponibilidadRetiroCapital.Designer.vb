<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MensajeDisponibilidadRetiroCapital
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.textsino = New System.Windows.Forms.TextBox()
        Me.Radiosi = New System.Windows.Forms.RadioButton()
        Me.Radiono = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Radiono)
        Me.GroupBox1.Controls.Add(Me.Radiosi)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(586, 131)
        Me.GroupBox1.TabIndex = 94
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Confirmación"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(486, 65)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(94, 23)
        Me.Button2.TabIndex = 92
        Me.Button2.Text = "Aceptar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(45, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(202, 16)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "Volver  a mostrar este mensaje  :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(102, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(379, 16)
        Me.Label2.TabIndex = 88
        Me.Label2.Text = "Saldo negativo  o   en cero  debe ingresar monto de  respaldo "
        '
        'textsino
        '
        Me.textsino.Location = New System.Drawing.Point(498, 169)
        Me.textsino.Name = "textsino"
        Me.textsino.Size = New System.Drawing.Size(100, 20)
        Me.textsino.TabIndex = 95
        '
        'Radiosi
        '
        Me.Radiosi.AutoSize = True
        Me.Radiosi.Location = New System.Drawing.Point(275, 71)
        Me.Radiosi.Name = "Radiosi"
        Me.Radiosi.Size = New System.Drawing.Size(35, 17)
        Me.Radiosi.TabIndex = 93
        Me.Radiosi.TabStop = True
        Me.Radiosi.Text = "SI"
        Me.Radiosi.UseVisualStyleBackColor = True
        '
        'Radiono
        '
        Me.Radiono.AutoSize = True
        Me.Radiono.Location = New System.Drawing.Point(341, 71)
        Me.Radiono.Name = "Radiono"
        Me.Radiono.Size = New System.Drawing.Size(41, 17)
        Me.Radiono.TabIndex = 94
        Me.Radiono.TabStop = True
        Me.Radiono.Text = "NO"
        Me.Radiono.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(235, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(204, 13)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Debe seleccionar solo una opcion "
        '
        'MensajeDisponibilidadRetiroCapital
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 158)
        Me.Controls.Add(Me.textsino)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "MensajeDisponibilidadRetiroCapital"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents textsino As System.Windows.Forms.TextBox
    Friend WithEvents Radiono As System.Windows.Forms.RadioButton
    Friend WithEvents Radiosi As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
