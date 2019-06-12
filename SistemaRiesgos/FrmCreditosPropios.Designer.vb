<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCreditosPropios
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
        Me.DGreditosAprobar = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.cboSegundoUsuario = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNrosocio2 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtSubAsignado = New System.Windows.Forms.TextBox()
        Me.txtEjecutivo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtValidaAgente = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtCondicional = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtnrosocio = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.txtIp = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnEntrada = New System.Windows.Forms.Button()
        Me.BtnPapelera = New System.Windows.Forms.Button()
        Me.ChkAutoAvisoRiesgo2 = New System.Windows.Forms.CheckBox()
        Me.ChkAutoAvisoRiesgo = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.CboSonido = New System.Windows.Forms.ComboBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        CType(Me.DGreditosAprobar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGreditosAprobar
        '
        Me.DGreditosAprobar.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.DGreditosAprobar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGreditosAprobar.Location = New System.Drawing.Point(5, 40)
        Me.DGreditosAprobar.Name = "DGreditosAprobar"
        Me.DGreditosAprobar.Size = New System.Drawing.Size(882, 398)
        Me.DGreditosAprobar.TabIndex = 20
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(893, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(296, 494)
        Me.TabControl1.TabIndex = 22
        '
        'TabPage2
        '
        Me.TabPage2.BackgroundImage = Global.SistemaRiesgos.My.Resources.Resources.Informe4
        Me.TabPage2.Controls.Add(Me.Button3)
        Me.TabPage2.Controls.Add(Me.cboSegundoUsuario)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.txtNrosocio2)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.Button2)
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage2.Controls.Add(Me.txtIp)
        Me.TabPage2.Controls.Add(Me.TextBox1)
        Me.TabPage2.Controls.Add(Me.DateTimePicker2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(288, 468)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Evaluación"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(217, 435)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(65, 23)
        Me.Button3.TabIndex = 66
        Me.Button3.Text = "Envio"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'cboSegundoUsuario
        '
        Me.cboSegundoUsuario.FormattingEnabled = True
        Me.cboSegundoUsuario.Location = New System.Drawing.Point(101, 435)
        Me.cboSegundoUsuario.Name = "cboSegundoUsuario"
        Me.cboSegundoUsuario.Size = New System.Drawing.Size(110, 21)
        Me.cboSegundoUsuario.TabIndex = 65
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label10.Location = New System.Drawing.Point(3, 436)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 20)
        Me.Label10.TabIndex = 64
        Me.Label10.Text = "Sub-Asignar"
        '
        'txtNrosocio2
        '
        Me.txtNrosocio2.Location = New System.Drawing.Point(101, 408)
        Me.txtNrosocio2.Name = "txtNrosocio2"
        Me.txtNrosocio2.Size = New System.Drawing.Size(110, 20)
        Me.txtNrosocio2.TabIndex = 63
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label9.Location = New System.Drawing.Point(3, 407)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 20)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "Nrosocio"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(217, 406)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(65, 23)
        Me.Button2.TabIndex = 61
        Me.Button2.Text = "Buscar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.97491!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.02509!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtSubAsignado, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.txtEjecutivo, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtValidaAgente, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtId, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCondicional, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtnrosocio, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtEstado, 1, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(6, 6)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(279, 398)
        Me.TableLayoutPanel1.TabIndex = 59
        '
        'txtSubAsignado
        '
        Me.txtSubAsignado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubAsignado.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txtSubAsignado.Location = New System.Drawing.Point(95, 371)
        Me.txtSubAsignado.Multiline = True
        Me.txtSubAsignado.Name = "txtSubAsignado"
        Me.txtSubAsignado.Size = New System.Drawing.Size(181, 24)
        Me.txtSubAsignado.TabIndex = 64
        '
        'txtEjecutivo
        '
        Me.txtEjecutivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEjecutivo.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txtEjecutivo.Location = New System.Drawing.Point(95, 337)
        Me.txtEjecutivo.Multiline = True
        Me.txtEjecutivo.Name = "txtEjecutivo"
        Me.txtEjecutivo.Size = New System.Drawing.Size(181, 28)
        Me.txtEjecutivo.TabIndex = 63
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label8.Location = New System.Drawing.Point(3, 368)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 15)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "SubAsignado"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(3, 334)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Ejecutivo"
        '
        'txtValidaAgente
        '
        Me.txtValidaAgente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValidaAgente.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txtValidaAgente.Location = New System.Drawing.Point(95, 285)
        Me.txtValidaAgente.Multiline = True
        Me.txtValidaAgente.Name = "txtValidaAgente"
        Me.txtValidaAgente.Size = New System.Drawing.Size(181, 46)
        Me.txtValidaAgente.TabIndex = 59
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(3, 282)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 40)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "Validación Agente"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(3, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 20)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Id:"
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(95, 3)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(181, 20)
        Me.txtId.TabIndex = 43
        '
        'txtCondicional
        '
        Me.txtCondicional.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCondicional.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txtCondicional.Location = New System.Drawing.Point(95, 162)
        Me.txtCondicional.Multiline = True
        Me.txtCondicional.Name = "txtCondicional"
        Me.txtCondicional.Size = New System.Drawing.Size(181, 117)
        Me.txtCondicional.TabIndex = 56
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(3, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 20)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Nro Socio:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(3, 159)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 20)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Condición:"
        '
        'txtnrosocio
        '
        Me.txtnrosocio.Location = New System.Drawing.Point(95, 29)
        Me.txtnrosocio.Name = "txtnrosocio"
        Me.txtnrosocio.Size = New System.Drawing.Size(181, 20)
        Me.txtnrosocio.TabIndex = 46
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(3, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 20)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Estado:"
        '
        'txtEstado
        '
        Me.txtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstado.ForeColor = System.Drawing.SystemColors.Window
        Me.txtEstado.Location = New System.Drawing.Point(95, 54)
        Me.txtEstado.Multiline = True
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(181, 102)
        Me.txtEstado.TabIndex = 47
        '
        'txtIp
        '
        Me.txtIp.Location = New System.Drawing.Point(3, 475)
        Me.txtIp.Name = "txtIp"
        Me.txtIp.Size = New System.Drawing.Size(279, 20)
        Me.txtIp.TabIndex = 54
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(21, 483)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(194, 24)
        Me.TextBox1.TabIndex = 37
        Me.TextBox1.Visible = False
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(3, 520)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(207, 20)
        Me.DateTimePicker2.TabIndex = 41
        Me.DateTimePicker2.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(9, 464)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(878, 14)
        Me.ProgressBar1.TabIndex = 47
        '
        'Timer2
        '
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(378, 441)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(190, 20)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "AUTO-ACTUALIZACIÓN:"
        '
        'BtnEntrada
        '
        Me.BtnEntrada.ForeColor = System.Drawing.Color.ForestGreen
        Me.BtnEntrada.Location = New System.Drawing.Point(5, 11)
        Me.BtnEntrada.Name = "BtnEntrada"
        Me.BtnEntrada.Size = New System.Drawing.Size(421, 23)
        Me.BtnEntrada.TabIndex = 50
        Me.BtnEntrada.Text = "BANDEJA DE ENTRADA"
        Me.BtnEntrada.UseVisualStyleBackColor = True
        '
        'BtnPapelera
        '
        Me.BtnPapelera.ForeColor = System.Drawing.Color.Gray
        Me.BtnPapelera.Location = New System.Drawing.Point(453, 11)
        Me.BtnPapelera.Name = "BtnPapelera"
        Me.BtnPapelera.Size = New System.Drawing.Size(434, 23)
        Me.BtnPapelera.TabIndex = 51
        Me.BtnPapelera.Text = "BANDEJA PAPELERA"
        Me.BtnPapelera.UseVisualStyleBackColor = True
        '
        'ChkAutoAvisoRiesgo2
        '
        Me.ChkAutoAvisoRiesgo2.AutoSize = True
        Me.ChkAutoAvisoRiesgo2.BackColor = System.Drawing.Color.Transparent
        Me.ChkAutoAvisoRiesgo2.Checked = True
        Me.ChkAutoAvisoRiesgo2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkAutoAvisoRiesgo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAutoAvisoRiesgo2.ForeColor = System.Drawing.Color.Black
        Me.ChkAutoAvisoRiesgo2.Location = New System.Drawing.Point(267, 486)
        Me.ChkAutoAvisoRiesgo2.Name = "ChkAutoAvisoRiesgo2"
        Me.ChkAutoAvisoRiesgo2.Size = New System.Drawing.Size(281, 16)
        Me.ChkAutoAvisoRiesgo2.TabIndex = 55
        Me.ChkAutoAvisoRiesgo2.Text = "ALARMA SI EXISTE ALGUNA SOLICITUD EN LA BANDEJA"
        Me.ChkAutoAvisoRiesgo2.UseVisualStyleBackColor = False
        '
        'ChkAutoAvisoRiesgo
        '
        Me.ChkAutoAvisoRiesgo.AutoSize = True
        Me.ChkAutoAvisoRiesgo.BackColor = System.Drawing.Color.Transparent
        Me.ChkAutoAvisoRiesgo.Checked = True
        Me.ChkAutoAvisoRiesgo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkAutoAvisoRiesgo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAutoAvisoRiesgo.ForeColor = System.Drawing.Color.Black
        Me.ChkAutoAvisoRiesgo.Location = New System.Drawing.Point(12, 487)
        Me.ChkAutoAvisoRiesgo.Name = "ChkAutoAvisoRiesgo"
        Me.ChkAutoAvisoRiesgo.Size = New System.Drawing.Size(237, 16)
        Me.ChkAutoAvisoRiesgo.TabIndex = 54
        Me.ChkAutoAvisoRiesgo.Text = "ALARMA POR LLEGADA DE NUEVA SOLICITUD"
        Me.ChkAutoAvisoRiesgo.UseVisualStyleBackColor = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(644, 486)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 12)
        Me.Label19.TabIndex = 62
        Me.Label19.Text = "ALARMA"
        '
        'CboSonido
        '
        Me.CboSonido.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboSonido.FormattingEnabled = True
        Me.CboSonido.Items.AddRange(New Object() {"Por Defecto", "Alternativa 1", "Alternativa 2", "Alternativa 3"})
        Me.CboSonido.Location = New System.Drawing.Point(697, 482)
        Me.CboSonido.Name = "CboSonido"
        Me.CboSonido.Size = New System.Drawing.Size(190, 20)
        Me.CboSonido.TabIndex = 61
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.Black
        Me.CheckBox1.Location = New System.Drawing.Point(552, 484)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(86, 16)
        Me.CheckBox1.TabIndex = 60
        Me.CheckBox1.Text = "DESACTIVAR"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'FrmCreditosPropios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1201, 509)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.CboSonido)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.ChkAutoAvisoRiesgo2)
        Me.Controls.Add(Me.ChkAutoAvisoRiesgo)
        Me.Controls.Add(Me.BtnPapelera)
        Me.Controls.Add(Me.BtnEntrada)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.DGreditosAprobar)
        Me.Name = "FrmCreditosPropios"
        CType(Me.DGreditosAprobar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGreditosAprobar As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents txtnrosocio As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtIp As System.Windows.Forms.TextBox
    Friend WithEvents txtCondicional As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtValidaAgente As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNrosocio2 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents cboSegundoUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents BtnEntrada As System.Windows.Forms.Button
    Friend WithEvents BtnPapelera As System.Windows.Forms.Button
    Friend WithEvents ChkAutoAvisoRiesgo2 As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAutoAvisoRiesgo As System.Windows.Forms.CheckBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents CboSonido As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents txtSubAsignado As System.Windows.Forms.TextBox
    Friend WithEvents txtEjecutivo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
