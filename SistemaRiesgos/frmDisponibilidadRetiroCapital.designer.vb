<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDisponibilidadRetiroCapital
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
        Me.Gridmeslineas = New System.Windows.Forms.DataGridView()
        Me.fechas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mONTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GridmesActual = New System.Windows.Forms.DataGridView()
        Me.FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.APORTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RETIRO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SALDOCAPITAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SOBREGIRO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SALDOACUMULA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Textdesdemes = New System.Windows.Forms.TextBox()
        Me.Textdesdeaño = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnConsultarPeriodo = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Textsobregiro = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Gridfilasinsaldo = New System.Windows.Forms.DataGridView()
        Me.FECHA2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.APORTE2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RETIRO2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SALDOCAPITLA2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SALDOACUMULADO2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Textsaldodeldiaactual = New System.Windows.Forms.TextBox()
        Me.Saldodeldiaactual = New System.Windows.Forms.Label()
        Me.Labelmenasajesaldonegativo = New System.Windows.Forms.Label()
        Me.Labelfechasaldonegativo = New System.Windows.Forms.Label()
        Me.Labelsaldonegativo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBoxsaldonegativo = New System.Windows.Forms.GroupBox()
        CType(Me.Gridmeslineas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridmesActual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Gridfilasinsaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxsaldonegativo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Gridmeslineas
        '
        Me.Gridmeslineas.AllowUserToAddRows = False
        Me.Gridmeslineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Gridmeslineas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.fechas, Me.mONTO, Me.id})
        Me.Gridmeslineas.Location = New System.Drawing.Point(658, 143)
        Me.Gridmeslineas.Name = "Gridmeslineas"
        Me.Gridmeslineas.RowHeadersVisible = False
        Me.Gridmeslineas.Size = New System.Drawing.Size(357, 159)
        Me.Gridmeslineas.TabIndex = 0
        '
        'fechas
        '
        Me.fechas.HeaderText = "FECHA"
        Me.fechas.Name = "fechas"
        '
        'mONTO
        '
        Me.mONTO.HeaderText = "MONTO"
        Me.mONTO.Name = "mONTO"
        '
        'id
        '
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        '
        'GridmesActual
        '
        Me.GridmesActual.AllowUserToAddRows = False
        Me.GridmesActual.AllowUserToDeleteRows = False
        Me.GridmesActual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridmesActual.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FECHA, Me.APORTE, Me.RETIRO, Me.SALDOCAPITAL, Me.SOBREGIRO, Me.SALDOACUMULA})
        Me.GridmesActual.Location = New System.Drawing.Point(12, 57)
        Me.GridmesActual.Name = "GridmesActual"
        Me.GridmesActual.RowHeadersVisible = False
        Me.GridmesActual.Size = New System.Drawing.Size(622, 469)
        Me.GridmesActual.TabIndex = 1
        '
        'FECHA
        '
        Me.FECHA.HeaderText = "FECHA"
        Me.FECHA.Name = "FECHA"
        '
        'APORTE
        '
        Me.APORTE.HeaderText = "APORTE"
        Me.APORTE.Name = "APORTE"
        '
        'RETIRO
        '
        Me.RETIRO.HeaderText = "RETIRO"
        Me.RETIRO.Name = "RETIRO"
        '
        'SALDOCAPITAL
        '
        Me.SALDOCAPITAL.HeaderText = "SALDO CAPITAL"
        Me.SALDOCAPITAL.Name = "SALDOCAPITAL"
        '
        'SOBREGIRO
        '
        Me.SOBREGIRO.HeaderText = "SOBREGIRO"
        Me.SOBREGIRO.Name = "SOBREGIRO"
        '
        'SALDOACUMULA
        '
        Me.SALDOACUMULA.HeaderText = "SALDO ACUMULADO "
        Me.SALDOACUMULA.Name = "SALDOACUMULA"
        '
        'Textdesdemes
        '
        Me.Textdesdemes.Location = New System.Drawing.Point(18, 19)
        Me.Textdesdemes.Name = "Textdesdemes"
        Me.Textdesdemes.Size = New System.Drawing.Size(32, 20)
        Me.Textdesdemes.TabIndex = 2
        '
        'Textdesdeaño
        '
        Me.Textdesdeaño.Location = New System.Drawing.Point(56, 19)
        Me.Textdesdeaño.Name = "Textdesdeaño"
        Me.Textdesdeaño.Size = New System.Drawing.Size(46, 20)
        Me.Textdesdeaño.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(197, 18)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 21)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Ingresar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnConsultarPeriodo)
        Me.GroupBox1.Controls.Add(Me.Textdesdeaño)
        Me.GroupBox1.Controls.Add(Me.Textdesdemes)
        Me.GroupBox1.Location = New System.Drawing.Point(658, 308)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(340, 52)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Consulta Período "
        '
        'btnConsultarPeriodo
        '
        Me.btnConsultarPeriodo.Location = New System.Drawing.Point(155, 18)
        Me.btnConsultarPeriodo.Name = "btnConsultarPeriodo"
        Me.btnConsultarPeriodo.Size = New System.Drawing.Size(122, 21)
        Me.btnConsultarPeriodo.TabIndex = 7
        Me.btnConsultarPeriodo.Text = "Consultar Período"
        Me.btnConsultarPeriodo.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Textsobregiro)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Location = New System.Drawing.Point(658, 57)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(340, 52)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ingreso Sobre Giro "
        '
        'Textsobregiro
        '
        Me.Textsobregiro.Location = New System.Drawing.Point(33, 19)
        Me.Textsobregiro.Name = "Textsobregiro"
        Me.Textsobregiro.Size = New System.Drawing.Size(131, 20)
        Me.Textsobregiro.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(294, -2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(548, 31)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Disponibilidad para Retiro de Capital Social  "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(730, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(203, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Monto Sobre Giro Realizados   en el Mes "
        '
        'Gridfilasinsaldo
        '
        Me.Gridfilasinsaldo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Gridfilasinsaldo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FECHA2, Me.APORTE2, Me.RETIRO2, Me.SALDOCAPITLA2, Me.SALDOACUMULADO2})
        Me.Gridfilasinsaldo.Location = New System.Drawing.Point(12, 639)
        Me.Gridfilasinsaldo.Name = "Gridfilasinsaldo"
        Me.Gridfilasinsaldo.Size = New System.Drawing.Size(567, 153)
        Me.Gridfilasinsaldo.TabIndex = 21
        '
        'FECHA2
        '
        Me.FECHA2.HeaderText = "FECHA2"
        Me.FECHA2.Name = "FECHA2"
        '
        'APORTE2
        '
        Me.APORTE2.HeaderText = "APORTE2"
        Me.APORTE2.Name = "APORTE2"
        '
        'RETIRO2
        '
        Me.RETIRO2.HeaderText = "RETIRO2"
        Me.RETIRO2.Name = "RETIRO2"
        '
        'SALDOCAPITLA2
        '
        Me.SALDOCAPITLA2.HeaderText = "SALDO CAPITLA2"
        Me.SALDOCAPITLA2.Name = "SALDOCAPITLA2"
        '
        'SALDOACUMULADO2
        '
        Me.SALDOACUMULADO2.HeaderText = "SALDO ACUMULADO2"
        Me.SALDOACUMULADO2.Name = "SALDOACUMULADO2"
        '
        'Timer1
        '
        '
        'Textsaldodeldiaactual
        '
        Me.Textsaldodeldiaactual.Location = New System.Drawing.Point(844, 607)
        Me.Textsaldodeldiaactual.Name = "Textsaldodeldiaactual"
        Me.Textsaldodeldiaactual.Size = New System.Drawing.Size(100, 20)
        Me.Textsaldodeldiaactual.TabIndex = 22
        '
        'Saldodeldiaactual
        '
        Me.Saldodeldiaactual.AutoSize = True
        Me.Saldodeldiaactual.Location = New System.Drawing.Point(853, 591)
        Me.Saldodeldiaactual.Name = "Saldodeldiaactual"
        Me.Saldodeldiaactual.Size = New System.Drawing.Size(91, 13)
        Me.Saldodeldiaactual.TabIndex = 23
        Me.Saldodeldiaactual.Text = "Saldodeldiaactual"
        '
        'Labelmenasajesaldonegativo
        '
        Me.Labelmenasajesaldonegativo.AutoSize = True
        Me.Labelmenasajesaldonegativo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelmenasajesaldonegativo.ForeColor = System.Drawing.Color.Red
        Me.Labelmenasajesaldonegativo.Location = New System.Drawing.Point(6, 25)
        Me.Labelmenasajesaldonegativo.Name = "Labelmenasajesaldonegativo"
        Me.Labelmenasajesaldonegativo.Size = New System.Drawing.Size(409, 20)
        Me.Labelmenasajesaldonegativo.TabIndex = 24
        Me.Labelmenasajesaldonegativo.Text = "Saldo  negativo  solicitudes quedarán pendiente   "
        '
        'Labelfechasaldonegativo
        '
        Me.Labelfechasaldonegativo.AutoSize = True
        Me.Labelfechasaldonegativo.BackColor = System.Drawing.Color.Green
        Me.Labelfechasaldonegativo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelfechasaldonegativo.ForeColor = System.Drawing.SystemColors.Window
        Me.Labelfechasaldonegativo.Location = New System.Drawing.Point(104, 63)
        Me.Labelfechasaldonegativo.Name = "Labelfechasaldonegativo"
        Me.Labelfechasaldonegativo.Size = New System.Drawing.Size(69, 20)
        Me.Labelfechasaldonegativo.TabIndex = 25
        Me.Labelfechasaldonegativo.Text = "FECHA"
        '
        'Labelsaldonegativo
        '
        Me.Labelsaldonegativo.AutoSize = True
        Me.Labelsaldonegativo.BackColor = System.Drawing.Color.Red
        Me.Labelsaldonegativo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelsaldonegativo.ForeColor = System.Drawing.Color.Gold
        Me.Labelsaldonegativo.Location = New System.Drawing.Point(104, 98)
        Me.Labelsaldonegativo.Name = "Labelsaldonegativo"
        Me.Labelsaldonegativo.Size = New System.Drawing.Size(71, 20)
        Me.Labelsaldonegativo.TabIndex = 26
        Me.Labelsaldonegativo.Text = "MONTO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(14, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 20)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "FECHA : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(14, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 20)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "SALDO : "
        '
        'GroupBoxsaldonegativo
        '
        Me.GroupBoxsaldonegativo.Controls.Add(Me.Labelmenasajesaldonegativo)
        Me.GroupBoxsaldonegativo.Controls.Add(Me.Label3)
        Me.GroupBoxsaldonegativo.Controls.Add(Me.Labelfechasaldonegativo)
        Me.GroupBoxsaldonegativo.Controls.Add(Me.Label1)
        Me.GroupBoxsaldonegativo.Controls.Add(Me.Labelsaldonegativo)
        Me.GroupBoxsaldonegativo.Location = New System.Drawing.Point(658, 377)
        Me.GroupBoxsaldonegativo.Name = "GroupBoxsaldonegativo"
        Me.GroupBoxsaldonegativo.Size = New System.Drawing.Size(405, 149)
        Me.GroupBoxsaldonegativo.TabIndex = 29
        Me.GroupBoxsaldonegativo.TabStop = False
        Me.GroupBoxsaldonegativo.Text = "Saldo"
        '
        'frmDisponibilidadRetiroCapital
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1075, 538)
        Me.Controls.Add(Me.GroupBoxsaldonegativo)
        Me.Controls.Add(Me.Saldodeldiaactual)
        Me.Controls.Add(Me.Textsaldodeldiaactual)
        Me.Controls.Add(Me.Gridfilasinsaldo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GridmesActual)
        Me.Controls.Add(Me.Gridmeslineas)
        Me.Name = "frmDisponibilidadRetiroCapital"
        CType(Me.Gridmeslineas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridmesActual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Gridfilasinsaldo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxsaldonegativo.ResumeLayout(False)
        Me.GroupBoxsaldonegativo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Gridmeslineas As System.Windows.Forms.DataGridView
    Friend WithEvents GridmesActual As System.Windows.Forms.DataGridView
    Friend WithEvents Textdesdemes As System.Windows.Forms.TextBox
    Friend WithEvents Textdesdeaño As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Textsobregiro As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APORTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RETIRO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SALDOCAPITAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOBREGIRO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SALDOACUMULA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnConsultarPeriodo As System.Windows.Forms.Button
    Friend WithEvents Gridfilasinsaldo As System.Windows.Forms.DataGridView
    Friend WithEvents FECHA2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APORTE2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RETIRO2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SALDOCAPITLA2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SALDOACUMULADO2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Textsaldodeldiaactual As System.Windows.Forms.TextBox
    Friend WithEvents Saldodeldiaactual As System.Windows.Forms.Label
    Friend WithEvents fechas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mONTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Labelmenasajesaldonegativo As System.Windows.Forms.Label
    Friend WithEvents Labelfechasaldonegativo As System.Windows.Forms.Label
    Friend WithEvents Labelsaldonegativo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxsaldonegativo As System.Windows.Forms.GroupBox
End Class
