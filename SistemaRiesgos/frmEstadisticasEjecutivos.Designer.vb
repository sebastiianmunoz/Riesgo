<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstadisticasEjecutivos
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
        Me.DGEjecutivosDescartados = New System.Windows.Forms.DataGridView()
        Me.DGEjecutivosAprobadosyRechazados = New System.Windows.Forms.DataGridView()
        Me.DGEjecutivosSolicitados = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.DGEjecutivosDescartados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGEjecutivosAprobadosyRechazados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGEjecutivosSolicitados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGEjecutivosDescartados
        '
        Me.DGEjecutivosDescartados.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.DGEjecutivosDescartados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGEjecutivosDescartados.Location = New System.Drawing.Point(12, 72)
        Me.DGEjecutivosDescartados.Name = "DGEjecutivosDescartados"
        Me.DGEjecutivosDescartados.Size = New System.Drawing.Size(257, 412)
        Me.DGEjecutivosDescartados.TabIndex = 21
        '
        'DGEjecutivosAprobadosyRechazados
        '
        Me.DGEjecutivosAprobadosyRechazados.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.DGEjecutivosAprobadosyRechazados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGEjecutivosAprobadosyRechazados.Location = New System.Drawing.Point(577, 72)
        Me.DGEjecutivosAprobadosyRechazados.Name = "DGEjecutivosAprobadosyRechazados"
        Me.DGEjecutivosAprobadosyRechazados.Size = New System.Drawing.Size(559, 412)
        Me.DGEjecutivosAprobadosyRechazados.TabIndex = 23
        '
        'DGEjecutivosSolicitados
        '
        Me.DGEjecutivosSolicitados.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.DGEjecutivosSolicitados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGEjecutivosSolicitados.Location = New System.Drawing.Point(293, 72)
        Me.DGEjecutivosSolicitados.Name = "DGEjecutivosSolicitados"
        Me.DGEjecutivosSolicitados.Size = New System.Drawing.Size(269, 412)
        Me.DGEjecutivosSolicitados.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(399, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(296, 20)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "RAKING EJECUTIVOS HISTORICO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(43, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 15)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "CREDITOS DESCARTADOS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(332, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(169, 15)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "CREDITOS SOLICITADOS"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(666, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(392, 15)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "CREDITOS APROBADOS V/S RECHAZADOS POR EJECUTIVA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(290, 487)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(159, 15)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "*No agrega los descartados"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(974, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(156, 20)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Desde el 15/04/2013"
        '
        'frmEstadisticasEjecutivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1148, 518)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGEjecutivosSolicitados)
        Me.Controls.Add(Me.DGEjecutivosAprobadosyRechazados)
        Me.Controls.Add(Me.DGEjecutivosDescartados)
        Me.Name = "frmEstadisticasEjecutivos"
        CType(Me.DGEjecutivosDescartados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGEjecutivosAprobadosyRechazados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGEjecutivosSolicitados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGEjecutivosDescartados As System.Windows.Forms.DataGridView
    Friend WithEvents DGEjecutivosAprobadosyRechazados As System.Windows.Forms.DataGridView
    Friend WithEvents DGEjecutivosSolicitados As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
