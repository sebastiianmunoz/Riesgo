<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstadosGiroCapital
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
        Me.txtSocioBuscar = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboEstadoCapital = New System.Windows.Forms.ComboBox()
        Me.Gridestadogiros = New System.Windows.Forms.DataGridView()
        Me.Checktodos = New System.Windows.Forms.CheckBox()
        Me.gridestadosgiroscapital2 = New System.Windows.Forms.DataGridView()
        Me.CheckBoxcarta = New System.Windows.Forms.CheckBox()
        Me.txtIdBuscar = New System.Windows.Forms.TextBox()
        Me.CheckOrdenPrelacion = New System.Windows.Forms.CheckBox()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCalculando = New System.Windows.Forms.Label()
        Me.TextHASTAAÑO = New System.Windows.Forms.TextBox()
        Me.TextHASTAMES = New System.Windows.Forms.TextBox()
        Me.Texthastadia = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Textdesdeaño = New System.Windows.Forms.TextBox()
        Me.Textdesdedia = New System.Windows.Forms.TextBox()
        Me.Textdesdemes = New System.Windows.Forms.TextBox()
        CType(Me.Gridestadogiros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridestadosgiroscapital2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSocioBuscar
        '
        Me.txtSocioBuscar.BackColor = System.Drawing.Color.MistyRose
        Me.txtSocioBuscar.Location = New System.Drawing.Point(142, 476)
        Me.txtSocioBuscar.Name = "txtSocioBuscar"
        Me.txtSocioBuscar.Size = New System.Drawing.Size(55, 20)
        Me.txtSocioBuscar.TabIndex = 139
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label27.Location = New System.Drawing.Point(12, 479)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(133, 16)
        Me.Label27.TabIndex = 138
        Me.Label27.Text = "Socio Específico :"
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnBuscar.Location = New System.Drawing.Point(702, 502)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(156, 23)
        Me.btnBuscar.TabIndex = 137
        Me.btnBuscar.Text = "Aplicar Filtros"
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(352, 479)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(275, 16)
        Me.Label1.TabIndex = 140
        Me.Label1.Text = "SOLICITUDES REGISTRADAS ENTRE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(12, 555)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 16)
        Me.Label2.TabIndex = 142
        Me.Label2.Text = "Estado Solicitud  :"
        '
        'cboEstadoCapital
        '
        Me.cboEstadoCapital.BackColor = System.Drawing.Color.MistyRose
        Me.cboEstadoCapital.FormattingEnabled = True
        Me.cboEstadoCapital.Location = New System.Drawing.Point(142, 552)
        Me.cboEstadoCapital.Name = "cboEstadoCapital"
        Me.cboEstadoCapital.Size = New System.Drawing.Size(165, 21)
        Me.cboEstadoCapital.TabIndex = 143
        '
        'Gridestadogiros
        '
        Me.Gridestadogiros.AllowUserToAddRows = False
        Me.Gridestadogiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Gridestadogiros.Location = New System.Drawing.Point(15, 49)
        Me.Gridestadogiros.Name = "Gridestadogiros"
        Me.Gridestadogiros.ReadOnly = True
        Me.Gridestadogiros.Size = New System.Drawing.Size(1274, 417)
        Me.Gridestadogiros.TabIndex = 144
        '
        'Checktodos
        '
        Me.Checktodos.AutoSize = True
        Me.Checktodos.Location = New System.Drawing.Point(328, 22)
        Me.Checktodos.Name = "Checktodos"
        Me.Checktodos.Size = New System.Drawing.Size(113, 17)
        Me.Checktodos.TabIndex = 146
        Me.Checktodos.Text = "Identificar Estados"
        Me.Checktodos.UseVisualStyleBackColor = True
        '
        'gridestadosgiroscapital2
        '
        Me.gridestadosgiroscapital2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridestadosgiroscapital2.Location = New System.Drawing.Point(1370, 69)
        Me.gridestadosgiroscapital2.Name = "gridestadosgiroscapital2"
        Me.gridestadosgiroscapital2.Size = New System.Drawing.Size(207, 203)
        Me.gridestadosgiroscapital2.TabIndex = 156
        '
        'CheckBoxcarta
        '
        Me.CheckBoxcarta.AutoSize = True
        Me.CheckBoxcarta.Location = New System.Drawing.Point(467, 22)
        Me.CheckBoxcarta.Name = "CheckBoxcarta"
        Me.CheckBoxcarta.Size = New System.Drawing.Size(92, 17)
        Me.CheckBoxcarta.TabIndex = 160
        Me.CheckBoxcarta.Text = "Estado Cartas"
        Me.CheckBoxcarta.UseVisualStyleBackColor = True
        '
        'txtIdBuscar
        '
        Me.txtIdBuscar.BackColor = System.Drawing.Color.MistyRose
        Me.txtIdBuscar.Location = New System.Drawing.Point(142, 501)
        Me.txtIdBuscar.Name = "txtIdBuscar"
        Me.txtIdBuscar.Size = New System.Drawing.Size(71, 20)
        Me.txtIdBuscar.TabIndex = 161
        '
        'CheckOrdenPrelacion
        '
        Me.CheckOrdenPrelacion.AutoSize = True
        Me.CheckOrdenPrelacion.Checked = True
        Me.CheckOrdenPrelacion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckOrdenPrelacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckOrdenPrelacion.Location = New System.Drawing.Point(15, 22)
        Me.CheckOrdenPrelacion.Name = "CheckOrdenPrelacion"
        Me.CheckOrdenPrelacion.Size = New System.Drawing.Size(204, 17)
        Me.CheckOrdenPrelacion.TabIndex = 167
        Me.CheckOrdenPrelacion.Text = "Solo Lista de Prelación Vigente"
        Me.CheckOrdenPrelacion.UseVisualStyleBackColor = True
        '
        'cboSucursal
        '
        Me.cboSucursal.BackColor = System.Drawing.Color.MistyRose
        Me.cboSucursal.FormattingEnabled = True
        Me.cboSucursal.Location = New System.Drawing.Point(142, 526)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(165, 21)
        Me.cboSucursal.TabIndex = 169
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(353, 524)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 170
        Me.Label5.Text = "Fecha Inicial :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(352, 550)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 171
        Me.Label6.Text = "Fecha Final  : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(12, 529)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 16)
        Me.Label3.TabIndex = 173
        Me.Label3.Text = "Sucursal               :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(12, 504)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 16)
        Me.Label4.TabIndex = 174
        Me.Label4.Text = "Id. Solicitud          :"
        '
        'lblCalculando
        '
        Me.lblCalculando.AutoSize = True
        Me.lblCalculando.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCalculando.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalculando.ForeColor = System.Drawing.Color.Yellow
        Me.lblCalculando.Location = New System.Drawing.Point(697, 502)
        Me.lblCalculando.Name = "lblCalculando"
        Me.lblCalculando.Size = New System.Drawing.Size(334, 25)
        Me.lblCalculando.TabIndex = 175
        Me.lblCalculando.Text = "BUSCANDO INFORMACION......."
        Me.lblCalculando.Visible = False
        '
        'TextHASTAAÑO
        '
        Me.TextHASTAAÑO.Location = New System.Drawing.Point(525, 548)
        Me.TextHASTAAÑO.Name = "TextHASTAAÑO"
        Me.TextHASTAAÑO.Size = New System.Drawing.Size(41, 20)
        Me.TextHASTAAÑO.TabIndex = 182
        '
        'TextHASTAMES
        '
        Me.TextHASTAMES.Location = New System.Drawing.Point(483, 548)
        Me.TextHASTAMES.Name = "TextHASTAMES"
        Me.TextHASTAMES.Size = New System.Drawing.Size(36, 20)
        Me.TextHASTAMES.TabIndex = 181
        '
        'Texthastadia
        '
        Me.Texthastadia.Location = New System.Drawing.Point(443, 548)
        Me.Texthastadia.Name = "Texthastadia"
        Me.Texthastadia.Size = New System.Drawing.Size(34, 20)
        Me.Texthastadia.TabIndex = 180
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(443, 501)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 13)
        Me.Label11.TabIndex = 179
        Me.Label11.Text = "DD      /   MM     /   AA"
        '
        'Textdesdeaño
        '
        Me.Textdesdeaño.Location = New System.Drawing.Point(525, 522)
        Me.Textdesdeaño.Name = "Textdesdeaño"
        Me.Textdesdeaño.Size = New System.Drawing.Size(41, 20)
        Me.Textdesdeaño.TabIndex = 178
        '
        'Textdesdedia
        '
        Me.Textdesdedia.Location = New System.Drawing.Point(443, 522)
        Me.Textdesdedia.Name = "Textdesdedia"
        Me.Textdesdedia.Size = New System.Drawing.Size(32, 20)
        Me.Textdesdedia.TabIndex = 176
        '
        'Textdesdemes
        '
        Me.Textdesdemes.Location = New System.Drawing.Point(483, 522)
        Me.Textdesdemes.Name = "Textdesdemes"
        Me.Textdesdemes.Size = New System.Drawing.Size(36, 20)
        Me.Textdesdemes.TabIndex = 177
        '
        'frmEstadosGiroCapital
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1301, 653)
        Me.Controls.Add(Me.TextHASTAAÑO)
        Me.Controls.Add(Me.TextHASTAMES)
        Me.Controls.Add(Me.Texthastadia)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Textdesdeaño)
        Me.Controls.Add(Me.Textdesdedia)
        Me.Controls.Add(Me.Textdesdemes)
        Me.Controls.Add(Me.lblCalculando)
        Me.Controls.Add(Me.txtSocioBuscar)
        Me.Controls.Add(Me.txtIdBuscar)
        Me.Controls.Add(Me.cboSucursal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CheckOrdenPrelacion)
        Me.Controls.Add(Me.CheckBoxcarta)
        Me.Controls.Add(Me.gridestadosgiroscapital2)
        Me.Controls.Add(Me.Checktodos)
        Me.Controls.Add(Me.Gridestadogiros)
        Me.Controls.Add(Me.cboEstadoCapital)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.btnBuscar)
        Me.MaximizeBox = False
        Me.Name = "frmEstadosGiroCapital"
        CType(Me.Gridestadogiros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridestadosgiroscapital2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSocioBuscar As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboEstadoCapital As System.Windows.Forms.ComboBox
    Friend WithEvents Gridestadogiros As System.Windows.Forms.DataGridView
    Friend WithEvents Checktodos As System.Windows.Forms.CheckBox
    Friend WithEvents gridestadosgiroscapital2 As System.Windows.Forms.DataGridView
    Friend WithEvents CheckBoxcarta As System.Windows.Forms.CheckBox
    Friend WithEvents txtIdBuscar As System.Windows.Forms.TextBox
    Friend WithEvents CheckOrdenPrelacion As System.Windows.Forms.CheckBox
    Friend WithEvents cboSucursal As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblCalculando As Label
    Friend WithEvents TextHASTAAÑO As TextBox
    Friend WithEvents TextHASTAMES As TextBox
    Friend WithEvents Texthastadia As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Textdesdeaño As TextBox
    Friend WithEvents Textdesdedia As TextBox
    Friend WithEvents Textdesdemes As TextBox
End Class
