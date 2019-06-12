<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBandejaCapital6EditarNominaTransferencia
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
        Me.GridSupervisada = New System.Windows.Forms.DataGridView()
        Me.numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.esatdo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.monto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aprobacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Textdesdedia = New System.Windows.Forms.TextBox()
        Me.btnConsultarPeriodo = New System.Windows.Forms.Button()
        Me.Textdesdeaño = New System.Windows.Forms.TextBox()
        Me.Textdesdemes = New System.Windows.Forms.TextBox()
        Me.GridSupervisadadetalle = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipocuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numerocuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Seleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GridSeleccion = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gridrecibetablaprincipal = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.coregreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.iddd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextIDnomina = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.GridSupervisada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridSupervisadadetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridSeleccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridrecibetablaprincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridSupervisada
        '
        Me.GridSupervisada.AllowUserToAddRows = False
        Me.GridSupervisada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridSupervisada.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.numero, Me.fecha, Me.esatdo, Me.monto, Me.usuario, Me.aprobacion, Me.id})
        Me.GridSupervisada.Location = New System.Drawing.Point(12, 47)
        Me.GridSupervisada.Name = "GridSupervisada"
        Me.GridSupervisada.RowHeadersVisible = False
        Me.GridSupervisada.Size = New System.Drawing.Size(705, 222)
        Me.GridSupervisada.TabIndex = 60
        '
        'numero
        '
        Me.numero.HeaderText = "Nro Nomina "
        Me.numero.Name = "numero"
        '
        'fecha
        '
        Me.fecha.HeaderText = "Fecha Nomina "
        Me.fecha.Name = "fecha"
        '
        'esatdo
        '
        Me.esatdo.HeaderText = "Estado Nomina "
        Me.esatdo.Name = "esatdo"
        '
        'monto
        '
        Me.monto.HeaderText = "Monto"
        Me.monto.Name = "monto"
        '
        'usuario
        '
        Me.usuario.HeaderText = "Usuario"
        Me.usuario.Name = "usuario"
        '
        'aprobacion
        '
        Me.aprobacion.HeaderText = "Aprobacion Subgerente Finanzas "
        Me.aprobacion.Name = "aprobacion"
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Textdesdedia)
        Me.GroupBox1.Controls.Add(Me.btnConsultarPeriodo)
        Me.GroupBox1.Controls.Add(Me.Textdesdeaño)
        Me.GroupBox1.Controls.Add(Me.Textdesdemes)
        Me.GroupBox1.Location = New System.Drawing.Point(725, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(340, 52)
        Me.GroupBox1.TabIndex = 61
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Consulta Período "
        '
        'Textdesdedia
        '
        Me.Textdesdedia.Location = New System.Drawing.Point(14, 19)
        Me.Textdesdedia.Name = "Textdesdedia"
        Me.Textdesdedia.Size = New System.Drawing.Size(32, 20)
        Me.Textdesdedia.TabIndex = 8
        '
        'btnConsultarPeriodo
        '
        Me.btnConsultarPeriodo.Location = New System.Drawing.Point(185, 18)
        Me.btnConsultarPeriodo.Name = "btnConsultarPeriodo"
        Me.btnConsultarPeriodo.Size = New System.Drawing.Size(122, 21)
        Me.btnConsultarPeriodo.TabIndex = 7
        Me.btnConsultarPeriodo.Text = "Consultar Período"
        Me.btnConsultarPeriodo.UseVisualStyleBackColor = True
        '
        'Textdesdeaño
        '
        Me.Textdesdeaño.Location = New System.Drawing.Point(92, 19)
        Me.Textdesdeaño.Name = "Textdesdeaño"
        Me.Textdesdeaño.Size = New System.Drawing.Size(46, 20)
        Me.Textdesdeaño.TabIndex = 3
        '
        'Textdesdemes
        '
        Me.Textdesdemes.Location = New System.Drawing.Point(54, 19)
        Me.Textdesdemes.Name = "Textdesdemes"
        Me.Textdesdemes.Size = New System.Drawing.Size(32, 20)
        Me.Textdesdemes.TabIndex = 2
        '
        'GridSupervisadadetalle
        '
        Me.GridSupervisadadetalle.AllowUserToAddRows = False
        Me.GridSupervisadadetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.GridSupervisadadetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridSupervisadadetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn7, Me.tipocuenta, Me.numerocuenta, Me.idd, Me.Seleccion})
        Me.GridSupervisadadetalle.Location = New System.Drawing.Point(13, 277)
        Me.GridSupervisadadetalle.Name = "GridSupervisadadetalle"
        Me.GridSupervisadadetalle.RowHeadersVisible = False
        Me.GridSupervisadadetalle.Size = New System.Drawing.Size(1053, 277)
        Me.GridSupervisadadetalle.TabIndex = 62
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Fecha  Solicitud "
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 102
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Estado Solicitud "
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 102
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Rut"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 49
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Nombre Completo"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 106
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Monto"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 62
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Banco"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 63
        '
        'tipocuenta
        '
        Me.tipocuenta.HeaderText = "Tipo Cuenta "
        Me.tipocuenta.Name = "tipocuenta"
        Me.tipocuenta.Width = 86
        '
        'numerocuenta
        '
        Me.numerocuenta.HeaderText = "Numero Cuenta "
        Me.numerocuenta.Name = "numerocuenta"
        '
        'idd
        '
        Me.idd.HeaderText = "Id"
        Me.idd.Name = "idd"
        Me.idd.Width = 41
        '
        'Seleccion
        '
        Me.Seleccion.HeaderText = "Seleccionar"
        Me.Seleccion.Name = "Seleccion"
        Me.Seleccion.Width = 69
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(182, 29)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(125, 23)
        Me.Button1.TabIndex = 63
        Me.Button1.Text = "Sacar  de la  Nómina "
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GridSeleccion)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Location = New System.Drawing.Point(725, 94)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(341, 177)
        Me.GroupBox2.TabIndex = 64
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sacar de Nomina "
        '
        'GridSeleccion
        '
        Me.GridSeleccion.AllowUserToAddRows = False
        Me.GridSeleccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridSeleccion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn13})
        Me.GridSeleccion.Location = New System.Drawing.Point(14, 19)
        Me.GridSeleccion.Name = "GridSeleccion"
        Me.GridSeleccion.RowHeadersVisible = False
        Me.GridSeleccion.Size = New System.Drawing.Size(93, 145)
        Me.GridSeleccion.TabIndex = 66
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(386, -1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(351, 31)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "Editar  Nóminas Aprobadas "
        '
        'gridrecibetablaprincipal
        '
        Me.gridrecibetablaprincipal.AllowUserToAddRows = False
        Me.gridrecibetablaprincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridrecibetablaprincipal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.coregreso, Me.iddd})
        Me.gridrecibetablaprincipal.Location = New System.Drawing.Point(12, 572)
        Me.gridrecibetablaprincipal.Name = "gridrecibetablaprincipal"
        Me.gridrecibetablaprincipal.RowHeadersVisible = False
        Me.gridrecibetablaprincipal.Size = New System.Drawing.Size(304, 132)
        Me.gridrecibetablaprincipal.TabIndex = 67
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Estado Solicitud "
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'coregreso
        '
        Me.coregreso.HeaderText = "Correlativo Egreso "
        Me.coregreso.Name = "coregreso"
        '
        'iddd
        '
        Me.iddd.HeaderText = "Id Solicitud"
        Me.iddd.Name = "iddd"
        '
        'TextIDnomina
        '
        Me.TextIDnomina.Location = New System.Drawing.Point(543, 605)
        Me.TextIDnomina.Name = "TextIDnomina"
        Me.TextIDnomina.Size = New System.Drawing.Size(100, 20)
        Me.TextIDnomina.TabIndex = 68
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(540, 585)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "ID NOMINA "
        '
        'frmBandejaCapital6EditarNominaTransferencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1075, 566)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextIDnomina)
        Me.Controls.Add(Me.gridrecibetablaprincipal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GridSupervisadadetalle)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GridSupervisada)
        Me.MaximizeBox = False
        Me.Name = "frmBandejaCapital6EditarNominaTransferencia"
        CType(Me.GridSupervisada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GridSupervisadadetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GridSeleccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridrecibetablaprincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridSupervisada As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnConsultarPeriodo As System.Windows.Forms.Button
    Friend WithEvents Textdesdeaño As System.Windows.Forms.TextBox
    Friend WithEvents Textdesdemes As System.Windows.Forms.TextBox
    Friend WithEvents numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents esatdo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents monto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents usuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aprobacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GridSupervisadadetalle As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipocuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numerocuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Seleccion As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GridSeleccion As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gridrecibetablaprincipal As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents coregreso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents iddd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextIDnomina As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Textdesdedia As System.Windows.Forms.TextBox
End Class
