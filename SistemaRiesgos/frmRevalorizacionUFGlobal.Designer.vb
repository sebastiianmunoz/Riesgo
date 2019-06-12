<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRevalorizacionUFGlobal
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GridRevalorizacionUF = New System.Windows.Forms.DataGridView()
        Me.Textvalorreajustado = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Textmontocapital = New System.Windows.Forms.TextBox()
        Me.Textsaldo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ProgressrevalorisacionUF = New System.Windows.Forms.ProgressBar()
        Me.TimerRevalorizacionUF = New System.Windows.Forms.Timer(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Mensajeparpadiante = New System.Windows.Forms.Timer(Me.components)
        Me.Textdesdeaño = New System.Windows.Forms.TextBox()
        Me.Textdesdedia = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Textdesdemes = New System.Windows.Forms.TextBox()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Monto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nrosocio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.formapgo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idsolicitud = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GRIDSOCIOS = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.GridRevalorizacionUF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GRIDSOCIOS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(301, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(329, 31)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Revalorizacion UF Global "
        '
        'GridRevalorizacionUF
        '
        Me.GridRevalorizacionUF.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridRevalorizacionUF.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.GridRevalorizacionUF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridRevalorizacionUF.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.Monto, Me.estado, Me.nrosocio, Me.formapgo, Me.idsolicitud})
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridRevalorizacionUF.DefaultCellStyle = DataGridViewCellStyle23
        Me.GridRevalorizacionUF.Location = New System.Drawing.Point(64, 77)
        Me.GridRevalorizacionUF.Name = "GridRevalorizacionUF"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridRevalorizacionUF.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.GridRevalorizacionUF.Size = New System.Drawing.Size(827, 496)
        Me.GridRevalorizacionUF.TabIndex = 21
        '
        'Textvalorreajustado
        '
        Me.Textvalorreajustado.Location = New System.Drawing.Point(58, 704)
        Me.Textvalorreajustado.Name = "Textvalorreajustado"
        Me.Textvalorreajustado.Size = New System.Drawing.Size(100, 20)
        Me.Textvalorreajustado.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(55, 688)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "MontoUF"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(55, 734)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "saldoufcapital"
        '
        'Textmontocapital
        '
        Me.Textmontocapital.Location = New System.Drawing.Point(58, 750)
        Me.Textmontocapital.Name = "Textmontocapital"
        Me.Textmontocapital.Size = New System.Drawing.Size(100, 20)
        Me.Textmontocapital.TabIndex = 24
        '
        'Textsaldo
        '
        Me.Textsaldo.Location = New System.Drawing.Point(58, 792)
        Me.Textsaldo.Name = "Textsaldo"
        Me.Textsaldo.Size = New System.Drawing.Size(100, 20)
        Me.Textsaldo.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(55, 776)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Saldo"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(717, 602)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 25)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "Recalcular"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(89, 606)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 16)
        Me.Label5.TabIndex = 122
        Me.Label5.Text = "0 %"
        '
        'ProgressrevalorisacionUF
        '
        Me.ProgressrevalorisacionUF.Location = New System.Drawing.Point(128, 604)
        Me.ProgressrevalorisacionUF.Name = "ProgressrevalorisacionUF"
        Me.ProgressrevalorisacionUF.Size = New System.Drawing.Size(277, 18)
        Me.ProgressrevalorisacionUF.TabIndex = 120
        '
        'TimerRevalorizacionUF
        '
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(411, 606)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "En Proceso"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(662, 606)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(16, 16)
        Me.Label7.TabIndex = 124
        Me.Label7.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(631, 606)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 16)
        Me.Label8.TabIndex = 125
        Me.Label8.Text = "Nº"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(150, 634)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(215, 16)
        Me.Label9.TabIndex = 126
        Me.Label9.Text = "Reajustando Montos Valor UF"
        '
        'Mensajeparpadiante
        '
        '
        'Textdesdeaño
        '
        Me.Textdesdeaño.Location = New System.Drawing.Point(127, 50)
        Me.Textdesdeaño.Name = "Textdesdeaño"
        Me.Textdesdeaño.Size = New System.Drawing.Size(41, 20)
        Me.Textdesdeaño.TabIndex = 154
        '
        'Textdesdedia
        '
        Me.Textdesdedia.Location = New System.Drawing.Point(45, 50)
        Me.Textdesdedia.Name = "Textdesdedia"
        Me.Textdesdedia.Size = New System.Drawing.Size(32, 20)
        Me.Textdesdedia.TabIndex = 151
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(53, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(113, 13)
        Me.Label10.TabIndex = 153
        Me.Label10.Text = "Fecha Revalorizacion "
        '
        'Textdesdemes
        '
        Me.Textdesdemes.Location = New System.Drawing.Point(85, 50)
        Me.Textdesdemes.Name = "Textdesdemes"
        Me.Textdesdemes.Size = New System.Drawing.Size(36, 20)
        Me.Textdesdemes.TabIndex = 152
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "FECHA"
        Me.Fecha.Name = "Fecha"
        '
        'Monto
        '
        Me.Monto.HeaderText = "MONTO SOLICITUD "
        Me.Monto.Name = "Monto"
        '
        'estado
        '
        Me.estado.HeaderText = "ESTADO SOLCITUD"
        Me.estado.Name = "estado"
        '
        'nrosocio
        '
        Me.nrosocio.HeaderText = "NROSOCIO "
        Me.nrosocio.Name = "nrosocio"
        '
        'formapgo
        '
        Me.formapgo.HeaderText = "FORMA PAGO "
        Me.formapgo.Name = "formapgo"
        '
        'idsolicitud
        '
        Me.idsolicitud.HeaderText = "ID SOLICITUD "
        Me.idsolicitud.Name = "idsolicitud"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(929, 77)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(210, 30)
        Me.Button2.TabIndex = 155
        Me.Button2.Text = "Personalizar "
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.GRIDSOCIOS)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Textdesdemes)
        Me.GroupBox1.Controls.Add(Me.Textdesdeaño)
        Me.GroupBox1.Controls.Add(Me.Textdesdedia)
        Me.GroupBox1.Location = New System.Drawing.Point(929, 120)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(221, 453)
        Me.GroupBox1.TabIndex = 156
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informacion"
        '
        'GRIDSOCIOS
        '
        Me.GRIDSOCIOS.AllowUserToAddRows = False
        Me.GRIDSOCIOS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.GRIDSOCIOS.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.GRIDSOCIOS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDSOCIOS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5})
        Me.GRIDSOCIOS.Location = New System.Drawing.Point(45, 88)
        Me.GRIDSOCIOS.Name = "GRIDSOCIOS"
        Me.GRIDSOCIOS.RowHeadersVisible = False
        Me.GRIDSOCIOS.Size = New System.Drawing.Size(137, 308)
        Me.GRIDSOCIOS.TabIndex = 160
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "NROSOCIOS"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 96
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(29, 411)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(171, 27)
        Me.Button3.TabIndex = 161
        Me.Button3.Text = "Recalcular Personalizado"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmRevalorizacionUFGlobal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1188, 657)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ProgressrevalorisacionUF)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Textsaldo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Textmontocapital)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Textvalorreajustado)
        Me.Controls.Add(Me.GridRevalorizacionUF)
        Me.Controls.Add(Me.Label4)
        Me.MaximizeBox = False
        Me.Name = "frmRevalorizacionUFGlobal"
        Me.Text = "frmRevalorizacionUFGlobal"
        CType(Me.GridRevalorizacionUF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GRIDSOCIOS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GridRevalorizacionUF As System.Windows.Forms.DataGridView
    Friend WithEvents Textvalorreajustado As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Textmontocapital As System.Windows.Forms.TextBox
    Friend WithEvents Textsaldo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ProgressrevalorisacionUF As System.Windows.Forms.ProgressBar
    Friend WithEvents TimerRevalorizacionUF As System.Windows.Forms.Timer
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Mensajeparpadiante As System.Windows.Forms.Timer
    Friend WithEvents Textdesdeaño As System.Windows.Forms.TextBox
    Friend WithEvents Textdesdedia As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Textdesdemes As System.Windows.Forms.TextBox
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Monto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nrosocio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents formapgo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idsolicitud As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GRIDSOCIOS As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
