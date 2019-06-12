<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmpruebas
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
        Me.CheckValidaciones = New System.Windows.Forms.CheckedListBox()
        Me.txtprueba = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.cboTasaSolicitada = New System.Windows.Forms.ComboBox()
        Me.GridmesActual = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Gridfilasinsaldo = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.TabControl1.SuspendLayout()
        CType(Me.GridmesActual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Gridfilasinsaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CheckValidaciones
        '
        Me.CheckValidaciones.FormattingEnabled = True
        Me.CheckValidaciones.Items.AddRange(New Object() {"Puntaje Minimo.", "Capacidad de Pago.", "Nivel de Endeudamiento.", "Antecedentes Comerciales.", "Antiguedad Institucion (10 años).", "Antiguedad Institucion (1 año).", "Moras con mas de 30 dias.", "Edad superior a 81 años."})
        Me.CheckValidaciones.Location = New System.Drawing.Point(949, 501)
        Me.CheckValidaciones.Name = "CheckValidaciones"
        Me.CheckValidaciones.Size = New System.Drawing.Size(194, 139)
        Me.CheckValidaciones.TabIndex = 61
        '
        'txtprueba
        '
        Me.txtprueba.Location = New System.Drawing.Point(36, 461)
        Me.txtprueba.Name = "txtprueba"
        Me.txtprueba.Size = New System.Drawing.Size(100, 20)
        Me.txtprueba.TabIndex = 62
        Me.ToolTip1.SetToolTip(Me.txtprueba, "PONE EL NOMBR EWN")
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(61, 68)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 63
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(137, 498)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(357, 315)
        Me.TabControl1.TabIndex = 64
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(349, 289)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(349, 289)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Cursor = System.Windows.Forms.Cursors.VSplit
        Me.ProgressBar1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ProgressBar1.Location = New System.Drawing.Point(61, 26)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 23)
        Me.ProgressBar1.TabIndex = 65
        Me.ProgressBar1.Value = 30
        '
        'cboTasaSolicitada
        '
        Me.cboTasaSolicitada.FormattingEnabled = True
        Me.cboTasaSolicitada.Items.AddRange(New Object() {"egdfgdfsgdfsghdsfgdfg", "fgdfgdfgdfgsggsgsfgsdfgdfgdfgdf", "fdgdfgdgdghdg", "dfgdfgdfgdfgdfgdgsdgfggdsgsdfg"})
        Me.cboTasaSolicitada.Location = New System.Drawing.Point(61, 97)
        Me.cboTasaSolicitada.Name = "cboTasaSolicitada"
        Me.cboTasaSolicitada.Size = New System.Drawing.Size(121, 21)
        Me.cboTasaSolicitada.TabIndex = 66
        '
        'GridmesActual
        '
        Me.GridmesActual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridmesActual.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.GridmesActual.Location = New System.Drawing.Point(456, 140)
        Me.GridmesActual.Name = "GridmesActual"
        Me.GridmesActual.Size = New System.Drawing.Size(409, 298)
        Me.GridmesActual.TabIndex = 67
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Gridfilasinsaldo
        '
        Me.Gridfilasinsaldo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Gridfilasinsaldo.Location = New System.Drawing.Point(460, 469)
        Me.Gridfilasinsaldo.Name = "Gridfilasinsaldo"
        Me.Gridfilasinsaldo.Size = New System.Drawing.Size(333, 65)
        Me.Gridfilasinsaldo.TabIndex = 68
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(471, 97)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 69
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(16, 140)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(474, 277)
        Me.ListBox1.TabIndex = 70
        '
        'frmpruebas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(945, 562)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Gridfilasinsaldo)
        Me.Controls.Add(Me.GridmesActual)
        Me.Controls.Add(Me.cboTasaSolicitada)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtprueba)
        Me.Controls.Add(Me.CheckValidaciones)
        Me.Name = "frmpruebas"
        Me.Text = "frmpruebas"
        Me.TabControl1.ResumeLayout(False)
        CType(Me.GridmesActual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Gridfilasinsaldo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckValidaciones As System.Windows.Forms.CheckedListBox
    Friend WithEvents txtprueba As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents cboTasaSolicitada As System.Windows.Forms.ComboBox
    Friend WithEvents GridmesActual As System.Windows.Forms.DataGridView
    Friend WithEvents Gridfilasinsaldo As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As DataGridViewComboBoxColumn
    Friend WithEvents Button2 As Button
    Friend WithEvents ListBox1 As ListBox
End Class
