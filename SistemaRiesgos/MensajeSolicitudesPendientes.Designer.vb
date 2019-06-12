<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MensajeSolicitudesPendientes
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
        Me.GRIDPENDIENTES = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RESULTADOPREAPORBADO = New System.Windows.Forms.Label()
        Me.RESULTADOAPROBADO = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckCOLOR = New System.Windows.Forms.CheckBox()
        Me.Textrojo = New System.Windows.Forms.TextBox()
        CType(Me.GRIDPENDIENTES, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GRIDPENDIENTES
        '
        Me.GRIDPENDIENTES.AllowUserToAddRows = False
        Me.GRIDPENDIENTES.AllowUserToOrderColumns = True
        Me.GRIDPENDIENTES.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.GRIDPENDIENTES.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDPENDIENTES.Location = New System.Drawing.Point(12, 154)
        Me.GRIDPENDIENTES.Name = "GRIDPENDIENTES"
        Me.GRIDPENDIENTES.Size = New System.Drawing.Size(617, 198)
        Me.GRIDPENDIENTES.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RESULTADOPREAPORBADO)
        Me.GroupBox1.Controls.Add(Me.RESULTADOAPROBADO)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(617, 80)
        Me.GroupBox1.TabIndex = 95
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Alerta"
        '
        'RESULTADOPREAPORBADO
        '
        Me.RESULTADOPREAPORBADO.AutoSize = True
        Me.RESULTADOPREAPORBADO.Location = New System.Drawing.Point(472, 48)
        Me.RESULTADOPREAPORBADO.Name = "RESULTADOPREAPORBADO"
        Me.RESULTADOPREAPORBADO.Size = New System.Drawing.Size(13, 13)
        Me.RESULTADOPREAPORBADO.TabIndex = 92
        Me.RESULTADOPREAPORBADO.Text = "0"
        '
        'RESULTADOAPROBADO
        '
        Me.RESULTADOAPROBADO.AutoSize = True
        Me.RESULTADOAPROBADO.Location = New System.Drawing.Point(472, 16)
        Me.RESULTADOAPROBADO.Name = "RESULTADOAPROBADO"
        Me.RESULTADOAPROBADO.Size = New System.Drawing.Size(13, 13)
        Me.RESULTADOAPROBADO.TabIndex = 91
        Me.RESULTADOAPROBADO.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(318, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 16)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "PREAPROBADO    "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(318, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 16)
        Me.Label3.TabIndex = 89
        Me.Label3.Text = "APROBADOS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(280, 16)
        Me.Label2.TabIndex = 88
        Me.Label2.Text = "Existen Solicitudes Pendietes de Pago "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 16)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Solicitudes"
        '
        'CheckCOLOR
        '
        Me.CheckCOLOR.AutoSize = True
        Me.CheckCOLOR.Location = New System.Drawing.Point(113, 128)
        Me.CheckCOLOR.Name = "CheckCOLOR"
        Me.CheckCOLOR.Size = New System.Drawing.Size(68, 17)
        Me.CheckCOLOR.TabIndex = 97
        Me.CheckCOLOR.Text = "Colorear "
        Me.CheckCOLOR.UseVisualStyleBackColor = True
        '
        'Textrojo
        '
        Me.Textrojo.Location = New System.Drawing.Point(356, 332)
        Me.Textrojo.Name = "Textrojo"
        Me.Textrojo.Size = New System.Drawing.Size(31, 20)
        Me.Textrojo.TabIndex = 98
        '
        'MensajeSolicitudesPendientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(669, 380)
        Me.Controls.Add(Me.CheckCOLOR)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GRIDPENDIENTES)
        Me.Controls.Add(Me.Textrojo)
        Me.Name = "MensajeSolicitudesPendientes"
        CType(Me.GRIDPENDIENTES, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GRIDPENDIENTES As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RESULTADOPREAPORBADO As System.Windows.Forms.Label
    Friend WithEvents RESULTADOAPROBADO As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckCOLOR As System.Windows.Forms.CheckBox
    Friend WithEvents Textrojo As System.Windows.Forms.TextBox
End Class
