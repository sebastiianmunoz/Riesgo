<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditarMontosSolicitudGiroCapital
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
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.textBuscarID = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        CType(Me.Gridestadogiros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Gridestadogiros
        '
        Me.Gridestadogiros.AllowUserToAddRows = False
        Me.Gridestadogiros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Gridestadogiros.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Gridestadogiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Gridestadogiros.Location = New System.Drawing.Point(12, 31)
        Me.Gridestadogiros.Name = "Gridestadogiros"
        Me.Gridestadogiros.ReadOnly = True
        Me.Gridestadogiros.Size = New System.Drawing.Size(1164, 348)
        Me.Gridestadogiros.TabIndex = 145
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnBuscar.Location = New System.Drawing.Point(298, 402)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 148
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'textBuscarID
        '
        Me.textBuscarID.BackColor = System.Drawing.Color.MistyRose
        Me.textBuscarID.Location = New System.Drawing.Point(175, 404)
        Me.textBuscarID.Name = "textBuscarID"
        Me.textBuscarID.Size = New System.Drawing.Size(107, 20)
        Me.textBuscarID.TabIndex = 147
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label27.Location = New System.Drawing.Point(68, 407)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(101, 15)
        Me.Label27.TabIndex = 146
        Me.Label27.Text = "ID_SOLICITUD"
        '
        'frmEditarMontosSolicitudGiroCapital
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImage = Global.SistemaRiesgos.My.Resources.Resources.Informe4
        Me.ClientSize = New System.Drawing.Size(1193, 445)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.textBuscarID)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Gridestadogiros)
        Me.Name = "frmEditarMontosSolicitudGiroCapital"
        Me.Text = "L.R"
        CType(Me.Gridestadogiros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Gridestadogiros As System.Windows.Forms.DataGridView
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents textBuscarID As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
End Class
