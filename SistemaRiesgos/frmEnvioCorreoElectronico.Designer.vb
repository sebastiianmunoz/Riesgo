<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnvioCorreoElectronico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEnvioCorreoElectronico))
        Me.TextDE = New System.Windows.Forms.TextBox()
        Me.TextPARA = New System.Windows.Forms.TextBox()
        Me.TextAsunto = New System.Windows.Forms.TextBox()
        Me.TextCONTRASEÑA = New System.Windows.Forms.TextBox()
        Me.txtmensaje1 = New System.Windows.Forms.TextBox()
        Me.btnenviar = New System.Windows.Forms.Button()
        Me.Adjuntar1 = New System.Windows.Forms.Label()
        Me.Textruta = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Btngenerarcarta = New System.Windows.Forms.Button()
        Me.textmensajecorreo2muestra = New System.Windows.Forms.TextBox()
        Me.txtmensaje2 = New System.Windows.Forms.TextBox()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.TextFECHA = New System.Windows.Forms.TextBox()
        Me.txtmensaje3 = New System.Windows.Forms.TextBox()
        Me.Textmuestraejecutiva = New System.Windows.Forms.TextBox()
        Me.Textencabezado = New System.Windows.Forms.TextBox()
        Me.Textsucursal = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lbltiempoenvio = New System.Windows.Forms.Label()
        Me.ProgressBarporcentaje = New System.Windows.Forms.ProgressBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextID = New System.Windows.Forms.TextBox()
        Me.txtmensaje2remplaza = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextDE
        '
        Me.TextDE.Location = New System.Drawing.Point(916, 751)
        Me.TextDE.Name = "TextDE"
        Me.TextDE.Size = New System.Drawing.Size(171, 20)
        Me.TextDE.TabIndex = 0
        '
        'TextPARA
        '
        Me.TextPARA.Location = New System.Drawing.Point(19, 19)
        Me.TextPARA.Name = "TextPARA"
        Me.TextPARA.ReadOnly = True
        Me.TextPARA.Size = New System.Drawing.Size(367, 20)
        Me.TextPARA.TabIndex = 1
        '
        'TextAsunto
        '
        Me.TextAsunto.Location = New System.Drawing.Point(19, 19)
        Me.TextAsunto.Name = "TextAsunto"
        Me.TextAsunto.Size = New System.Drawing.Size(366, 20)
        Me.TextAsunto.TabIndex = 2
        '
        'TextCONTRASEÑA
        '
        Me.TextCONTRASEÑA.Location = New System.Drawing.Point(1152, 751)
        Me.TextCONTRASEÑA.Name = "TextCONTRASEÑA"
        Me.TextCONTRASEÑA.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextCONTRASEÑA.Size = New System.Drawing.Size(215, 20)
        Me.TextCONTRASEÑA.TabIndex = 3
        '
        'txtmensaje1
        '
        Me.txtmensaje1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmensaje1.Location = New System.Drawing.Point(725, 189)
        Me.txtmensaje1.Multiline = True
        Me.txtmensaje1.Name = "txtmensaje1"
        Me.txtmensaje1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtmensaje1.Size = New System.Drawing.Size(366, 84)
        Me.txtmensaje1.TabIndex = 78
        Me.txtmensaje1.Text = resources.GetString("txtmensaje1.Text")
        '
        'btnenviar
        '
        Me.btnenviar.Location = New System.Drawing.Point(35, 440)
        Me.btnenviar.Name = "btnenviar"
        Me.btnenviar.Size = New System.Drawing.Size(75, 23)
        Me.btnenviar.TabIndex = 79
        Me.btnenviar.Text = "Enviar"
        Me.btnenviar.UseVisualStyleBackColor = True
        '
        'Adjuntar1
        '
        Me.Adjuntar1.AutoSize = True
        Me.Adjuntar1.Location = New System.Drawing.Point(58, 141)
        Me.Adjuntar1.Name = "Adjuntar1"
        Me.Adjuntar1.Size = New System.Drawing.Size(46, 13)
        Me.Adjuntar1.TabIndex = 80
        Me.Adjuntar1.Text = "Adjuntar"
        '
        'Textruta
        '
        Me.Textruta.Location = New System.Drawing.Point(124, 138)
        Me.Textruta.Name = "Textruta"
        Me.Textruta.Size = New System.Drawing.Size(277, 20)
        Me.Textruta.TabIndex = 81
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(407, 136)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 23)
        Me.Button1.TabIndex = 82
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(889, 755)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "De"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1093, 754)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "Password"
        '
        'Btngenerarcarta
        '
        Me.Btngenerarcarta.Location = New System.Drawing.Point(407, 165)
        Me.Btngenerarcarta.Name = "Btngenerarcarta"
        Me.Btngenerarcarta.Size = New System.Drawing.Size(88, 23)
        Me.Btngenerarcarta.TabIndex = 87
        Me.Btngenerarcarta.Text = "Generar Carta"
        Me.Btngenerarcarta.UseVisualStyleBackColor = True
        '
        'textmensajecorreo2muestra
        '
        Me.textmensajecorreo2muestra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textmensajecorreo2muestra.Location = New System.Drawing.Point(725, 571)
        Me.textmensajecorreo2muestra.Multiline = True
        Me.textmensajecorreo2muestra.Name = "textmensajecorreo2muestra"
        Me.textmensajecorreo2muestra.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.textmensajecorreo2muestra.Size = New System.Drawing.Size(366, 169)
        Me.textmensajecorreo2muestra.TabIndex = 88
        Me.textmensajecorreo2muestra.Text = resources.GetString("textmensajecorreo2muestra.Text")
        '
        'txtmensaje2
        '
        Me.txtmensaje2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmensaje2.Location = New System.Drawing.Point(725, 307)
        Me.txtmensaje2.Multiline = True
        Me.txtmensaje2.Name = "txtmensaje2"
        Me.txtmensaje2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtmensaje2.Size = New System.Drawing.Size(366, 79)
        Me.txtmensaje2.TabIndex = 89
        Me.txtmensaje2.Text = resources.GetString("txtmensaje2.Text")
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(725, 281)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(366, 20)
        Me.TxtNombre.TabIndex = 90
        '
        'TextFECHA
        '
        Me.TextFECHA.Location = New System.Drawing.Point(725, 405)
        Me.TextFECHA.Name = "TextFECHA"
        Me.TextFECHA.Size = New System.Drawing.Size(366, 20)
        Me.TextFECHA.TabIndex = 91
        '
        'txtmensaje3
        '
        Me.txtmensaje3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmensaje3.Location = New System.Drawing.Point(725, 443)
        Me.txtmensaje3.Multiline = True
        Me.txtmensaje3.Name = "txtmensaje3"
        Me.txtmensaje3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtmensaje3.Size = New System.Drawing.Size(366, 113)
        Me.txtmensaje3.TabIndex = 92
        Me.txtmensaje3.Text = resources.GetString("txtmensaje3.Text")
        '
        'Textmuestraejecutiva
        '
        Me.Textmuestraejecutiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textmuestraejecutiva.Location = New System.Drawing.Point(35, 42)
        Me.Textmuestraejecutiva.Multiline = True
        Me.Textmuestraejecutiva.Name = "Textmuestraejecutiva"
        Me.Textmuestraejecutiva.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Textmuestraejecutiva.Size = New System.Drawing.Size(514, 392)
        Me.Textmuestraejecutiva.TabIndex = 93
        Me.Textmuestraejecutiva.Text = resources.GetString("Textmuestraejecutiva.Text")
        '
        'Textencabezado
        '
        Me.Textencabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textencabezado.Location = New System.Drawing.Point(725, 17)
        Me.Textencabezado.Multiline = True
        Me.Textencabezado.Name = "Textencabezado"
        Me.Textencabezado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Textencabezado.Size = New System.Drawing.Size(374, 130)
        Me.Textencabezado.TabIndex = 94
        Me.Textencabezado.Text = resources.GetString("Textencabezado.Text")
        '
        'Textsucursal
        '
        Me.Textsucursal.Location = New System.Drawing.Point(725, 158)
        Me.Textsucursal.Name = "Textsucursal"
        Me.Textsucursal.Size = New System.Drawing.Size(366, 20)
        Me.Textsucursal.TabIndex = 95
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Textmuestraejecutiva)
        Me.GroupBox1.Controls.Add(Me.btnenviar)
        Me.GroupBox1.Location = New System.Drawing.Point(37, 216)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(581, 474)
        Me.GroupBox1.TabIndex = 96
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mensaje Email"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextPARA)
        Me.GroupBox2.Location = New System.Drawing.Point(104, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(403, 60)
        Me.GroupBox2.TabIndex = 97
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Para"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextAsunto)
        Me.GroupBox3.Location = New System.Drawing.Point(104, 68)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(403, 60)
        Me.GroupBox3.TabIndex = 98
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Asunto"
        '
        'lbltiempoenvio
        '
        Me.lbltiempoenvio.AutoSize = True
        Me.lbltiempoenvio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltiempoenvio.Location = New System.Drawing.Point(77, 178)
        Me.lbltiempoenvio.Name = "lbltiempoenvio"
        Me.lbltiempoenvio.Size = New System.Drawing.Size(16, 16)
        Me.lbltiempoenvio.TabIndex = 118
        Me.lbltiempoenvio.Text = "0"
        '
        'ProgressBarporcentaje
        '
        Me.ProgressBarporcentaje.Location = New System.Drawing.Point(123, 176)
        Me.ProgressBarporcentaje.Name = "ProgressBarporcentaje"
        Me.ProgressBarporcentaje.Size = New System.Drawing.Size(278, 18)
        Me.ProgressBarporcentaje.TabIndex = 117
        '
        'Timer1
        '
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(96, 178)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 16)
        Me.Label3.TabIndex = 119
        Me.Label3.Text = "%"
        '
        'TextID
        '
        Me.TextID.Location = New System.Drawing.Point(1267, 788)
        Me.TextID.Name = "TextID"
        Me.TextID.Size = New System.Drawing.Size(100, 20)
        Me.TextID.TabIndex = 120
        '
        'txtmensaje2remplaza
        '
        Me.txtmensaje2remplaza.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmensaje2remplaza.Location = New System.Drawing.Point(1110, 307)
        Me.txtmensaje2remplaza.Multiline = True
        Me.txtmensaje2remplaza.Name = "txtmensaje2remplaza"
        Me.txtmensaje2remplaza.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtmensaje2remplaza.Size = New System.Drawing.Size(373, 79)
        Me.txtmensaje2remplaza.TabIndex = 121
        Me.txtmensaje2remplaza.Text = resources.GetString("txtmensaje2remplaza.Text")
        '
        'frmEnvioCorreoElectronico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(649, 748)
        Me.Controls.Add(Me.txtmensaje2remplaza)
        Me.Controls.Add(Me.TextID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbltiempoenvio)
        Me.Controls.Add(Me.ProgressBarporcentaje)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Textsucursal)
        Me.Controls.Add(Me.Textencabezado)
        Me.Controls.Add(Me.txtmensaje3)
        Me.Controls.Add(Me.TextFECHA)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.txtmensaje2)
        Me.Controls.Add(Me.textmensajecorreo2muestra)
        Me.Controls.Add(Me.Btngenerarcarta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Textruta)
        Me.Controls.Add(Me.Adjuntar1)
        Me.Controls.Add(Me.txtmensaje1)
        Me.Controls.Add(Me.TextCONTRASEÑA)
        Me.Controls.Add(Me.TextDE)
        Me.Controls.Add(Me.GroupBox3)
        Me.MaximizeBox = False
        Me.Name = "frmEnvioCorreoElectronico"
        Me.Text = "L.R"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextDE As System.Windows.Forms.TextBox
    Friend WithEvents TextPARA As System.Windows.Forms.TextBox
    Friend WithEvents TextAsunto As System.Windows.Forms.TextBox
    Friend WithEvents TextCONTRASEÑA As System.Windows.Forms.TextBox
    Friend WithEvents txtmensaje1 As System.Windows.Forms.TextBox
    Friend WithEvents btnenviar As System.Windows.Forms.Button
    Friend WithEvents Adjuntar1 As System.Windows.Forms.Label
    Friend WithEvents Textruta As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Btngenerarcarta As System.Windows.Forms.Button
    Friend WithEvents textmensajecorreo2muestra As System.Windows.Forms.TextBox
    Friend WithEvents txtmensaje2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextFECHA As System.Windows.Forms.TextBox
    Friend WithEvents txtmensaje3 As System.Windows.Forms.TextBox
    Friend WithEvents Textmuestraejecutiva As System.Windows.Forms.TextBox
    Friend WithEvents Textencabezado As System.Windows.Forms.TextBox
    Friend WithEvents Textsucursal As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lbltiempoenvio As System.Windows.Forms.Label
    Friend WithEvents ProgressBarporcentaje As System.Windows.Forms.ProgressBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextID As System.Windows.Forms.TextBox
    Friend WithEvents txtmensaje2remplaza As System.Windows.Forms.TextBox
End Class
