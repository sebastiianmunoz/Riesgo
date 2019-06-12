<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditarMontoGiroCapital2
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
        Me.Datadetalle = New System.Windows.Forms.DataGridView()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.textMontoNuevo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Textnorosico = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextID = New System.Windows.Forms.TextBox()
        Me.TextTiposolciitud = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.Datadetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Datadetalle
        '
        Me.Datadetalle.AllowUserToAddRows = False
        Me.Datadetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Datadetalle.Location = New System.Drawing.Point(12, 25)
        Me.Datadetalle.Name = "Datadetalle"
        Me.Datadetalle.Size = New System.Drawing.Size(913, 145)
        Me.Datadetalle.TabIndex = 1
        '
        'btnGrabar
        '
        Me.btnGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnGrabar.Location = New System.Drawing.Point(462, 176)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(134, 22)
        Me.btnGrabar.TabIndex = 151
        Me.btnGrabar.Text = "Actualizar nuevo monto "
        Me.btnGrabar.UseVisualStyleBackColor = False
        '
        'textMontoNuevo
        '
        Me.textMontoNuevo.BackColor = System.Drawing.Color.MistyRose
        Me.textMontoNuevo.Location = New System.Drawing.Point(328, 176)
        Me.textMontoNuevo.Name = "textMontoNuevo"
        Me.textMontoNuevo.Size = New System.Drawing.Size(128, 20)
        Me.textMontoNuevo.TabIndex = 150
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(630, 283)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 155
        Me.Label6.Text = "NroSocio"
        '
        'Textnorosico
        '
        Me.Textnorosico.Location = New System.Drawing.Point(687, 280)
        Me.Textnorosico.Name = "Textnorosico"
        Me.Textnorosico.Size = New System.Drawing.Size(100, 20)
        Me.Textnorosico.TabIndex = 154
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(656, 309)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 13)
        Me.Label5.TabIndex = 153
        Me.Label5.Text = "ID"
        '
        'TextID
        '
        Me.TextID.Location = New System.Drawing.Point(687, 306)
        Me.TextID.Name = "TextID"
        Me.TextID.Size = New System.Drawing.Size(100, 20)
        Me.TextID.TabIndex = 152
        '
        'TextTiposolciitud
        '
        Me.TextTiposolciitud.Location = New System.Drawing.Point(687, 332)
        Me.TextTiposolciitud.Name = "TextTiposolciitud"
        Me.TextTiposolciitud.Size = New System.Drawing.Size(100, 20)
        Me.TextTiposolciitud.TabIndex = 156
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(630, 339)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 157
        Me.Label1.Text = "Tipologia"
        '
        'frmEditarMontoGiroCapital2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SistemaRiesgos.My.Resources.Resources.fondo4
        Me.ClientSize = New System.Drawing.Size(937, 227)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextTiposolciitud)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Textnorosico)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextID)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.textMontoNuevo)
        Me.Controls.Add(Me.Datadetalle)
        Me.Name = "frmEditarMontoGiroCapital2"
        Me.Text = "L.R"
        CType(Me.Datadetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Datadetalle As System.Windows.Forms.DataGridView
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents textMontoNuevo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Textnorosico As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextID As System.Windows.Forms.TextBox
    Friend WithEvents TextTiposolciitud As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
