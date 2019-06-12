<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnvioCorreoElectronicoAuditoria
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
        Me.Gridestadogiros = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextaID = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.Gridestadogiros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Gridestadogiros
        '
        Me.Gridestadogiros.AllowUserToAddRows = False
        Me.Gridestadogiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Gridestadogiros.Location = New System.Drawing.Point(12, 59)
        Me.Gridestadogiros.Name = "Gridestadogiros"
        Me.Gridestadogiros.ReadOnly = True
        Me.Gridestadogiros.Size = New System.Drawing.Size(866, 326)
        Me.Gridestadogiros.TabIndex = 145
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(12, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 16)
        Me.Label2.TabIndex = 146
        Me.Label2.Text = "Cartas Enviadas "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 403)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(27, 13)
        Me.Label10.TabIndex = 156
        Me.Label10.Text = "ID : "
        '
        'TextaID
        '
        Me.TextaID.Location = New System.Drawing.Point(44, 400)
        Me.TextaID.Name = "TextaID"
        Me.TextaID.Size = New System.Drawing.Size(117, 20)
        Me.TextaID.TabIndex = 155
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(178, 398)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(134, 22)
        Me.Button1.TabIndex = 157
        Me.Button1.Text = "Confirmar Envio Fisico"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmEnvioCorreoElectronicoAuditoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 462)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextaID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Gridestadogiros)
        Me.Name = "frmEnvioCorreoElectronicoAuditoria"
        Me.Text = "L.R"
        CType(Me.Gridestadogiros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Gridestadogiros As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextaID As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
