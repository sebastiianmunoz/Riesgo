Imports System.Data
Imports System.Data.SqlClient
Public Class frmMuestraEvaluacionCapital
    Public _TABLA27 As DataTable = New DataTable
    Dim cumplecapitalminimo As String = ""
    Dim cumplemontosolicitado As String = ""
    Dim cumplenroretirosanuales As String = ""
    Dim cumplenroretirosmensuales As String = ""
    Dim cumplesociosinmora As String = ""
    Dim cumpleavalsinmora As String = ""
    Dim cumplerestriccion As String = ""
    Dim cumplecapitalglobal As String = ""
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter

    'Sub ACTUALIZASUCURSAL()
    'SELECT SUCURSAL   FROM [_RIESGO_PERFIL] WHERE  USUARIO ='CAGUILAR' 
    'If Trim(Sucursal22) = "VALPARAÍSO" Then
    'ComboSucursal.Text = "SUCURSAL PRAT VALPARAÍSO"
    'ElseIf Trim(Sucursal22) = "VIÑA DEL MAR" Then
    'ComboSucursal.Text = "VIÑA DEL MAR"
    'End If
    'NOMRES : '+' CRISTIAN'
    'frmRIESGO.TextSucural22.Text = Sucursal22
    'End Sub


    Private Sub btnAutoriza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoriza.Click
        'If Pic8A.Visible = True And (Trim(frmEvaluarCapital.Texttiposolicitud2.Text) <> "R" And Trim(frmEvaluarCapital.Texttiposolicitud2.Text) <> "F") Then
        'MsgBox(frmEvaluarCapital.Texttiposolicitud2.Text)
        AUTORIZA()
        ' ElseIf Pic8A.Visible = True And (Trim(frmEvaluarCapital.Texttiposolicitud2.Text) = "R" Or Trim(frmEvaluarCapital.Texttiposolicitud2.Text) = "F") Then
        ' AUTORIZAR_RENUNCIA_FALLECMIENTO()
        ' RECONCIDERA_FALLECIMIENTO_RENUNCIA()
        ' End If
    End Sub

    Private Sub btnReconcideracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReconcideracion.Click
        RECONCIDERA()
    End Sub
    Private Sub btnreconciderapendiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RECONCIDERA()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmEvaluarCapital.Close()
        Me.Close()
    End Sub

    Private Sub txtComentarioGirocapital_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComentarioGirocapital.KeyUp
        txtcomentariototal.Text = 250 - (txtComentarioGirocapital.Text.Length)
    End Sub

    Private Sub frmMuestraEvaluacionCapital_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'rellancorrelativounico()
        'Pic1B.Visible = False
        'Pic1A.Visible = False
        'Pic2B.Visible = False
        'Pic2A.Visible = False
        'Pic3B.Visible = False
        'Pic3A.Visible = False
        'Pic4B.Visible = False
        'Pic4A.Visible = False
        'Pic5B.Visible = False
        'Pic5A.Visible = False
        'Pic6B.Visible = False
        'Pic6A.Visible = False
        'ACTUALIZASUCURSAL()








    End Sub

   Sub AUTORIZA() ' sucursal 2 lista para autorizar 
        If txtComentarioGirocapital.Text.Length <= 250 Then

            Dim Estado_Solicitud As String = ""
            Dim Estado_Solicitud2 As Integer = 1
            Dim Tomacorrelativo As Integer = 0
            Dim tomafecha As String = ""
            Dim tomafecha2 As String = ""
            Dim RUT As String = ""
            Dim Nombresocio As String = ""
            Dim nrosocio As Integer = 0
            Dim tiporequerimiento As String = ""
            Dim Tipocuentabanco As String = ""
            Dim banco As String = ""
            Dim nrocuentabanco As String = ""
            Dim codigobanco As String = ""
            Dim formapago As String = ""
            Dim Usuario As String = ""
            Dim Sucursal As String = ""
            Dim sucursal2 As Integer = 0


            Dim montototal As Integer = frmEvaluarCapital.Texttotales.Text
            Dim correcionmonetaria As Integer = frmEvaluarCapital.Textcorrecionmonetaria.Text
            Dim cuotasparticipacion As Integer = frmEvaluarCapital.Textcuotasdeparticipacion.Text
            Dim totalnoretirable As Integer = frmEvaluarCapital.Texttotalnoretirable.Text
            Dim montodisponible As Integer = frmEvaluarCapital.Textmontodisponible.Text
            Dim montomaximoretirabel As Integer = frmEvaluarCapital.Textmontomaximoretirable.Text
            Dim Montosolicitado As Integer = CInt(frmEvaluarCapital.Textmontorequerido.Text)
            Dim en_nomina As Integer = 0

            'Dim pagootros As Long = CInt(frmEvaluarCapital.Textpagootros.Text)
            'MsgBox(Montosolicitado)
            'MsgBox(montototal)
            'MsgBox(correcionmonetaria)
            'MsgBox(cuotasparticipacion)
            'MsgBox(totalnoretirable)
            'MsgBox(montodisponible)
            'MsgBox(montomaximoretirabel)
            'MsgBox(en_nomina)
            'MsgBox(Montosolicitado)

            tomafecha = DateTime.Now().ToShortDateString()  '"16/06/2009"
            tomafecha2 = Mid(tomafecha, 7, 10) + Mid(tomafecha, 4, 2) + Mid(tomafecha, 1, 2)

            'Dim conexiones6 As New CConexion
            'conexiones6.conexion()
            'Dim command6 As SqlCommand = New SqlCommand("SELECT CORMOV+1 FROM _CORMOV", conexiones6._conexion)
            'conexiones6.abrir()
            'Dim reader6 As SqlDataReader = command6.ExecuteReader()
            'If reader6.HasRows Then
            '    Do While reader6.Read()
            '        Tomacorrelativo = reader6(0).ToString
            '    Loop
            'Else
            'End If
            'reader6.Close()

            Dim conexiones22 As New CConexion
            conexiones22.conexion()
            Dim command22 As SqlCommand = New SqlCommand("_SIGUIENTE @Tipo='CORMOV' ", conexiones22._conexion)
            conexiones22.abrir()
            Dim reader22 As SqlDataReader = command22.ExecuteReader()
            If reader22.HasRows Then
                Do While reader22.Read()
                    Tomacorrelativo = (reader22(0).ToString)
                Loop
            Else
            End If
            reader22.Close()

            'Dim conexiones60 As New CConexion
            'conexiones60.conexion()
            '_adaptador.UpdateCommand = New SqlCommand("update   _CORMOV set CORMOV = CORMOV+1 ", conexiones60._conexion)
            'conexiones60.abrir()
            '_adaptador.UpdateCommand.Connection = conexiones60._conexion
            '_adaptador.UpdateCommand.ExecuteNonQuery()
            'conexiones60.cerrar()

            Dim cadena As String
            Dim tabla() As String
            Dim n As Integer
            Dim tomarut As String
            Dim tomadigito As String
            cadena = frmEvaluarCapital.Textrut.Text
            tabla = Split(cadena, "-")
            For n = 0 To UBound(tabla, 1)
                If n = 0 Then
                    tomarut = (tabla(n))
                Else
                    tomadigito = (tabla(n))
                End If
            Next

            Nombresocio = frmEvaluarCapital.Textnombre.Text
            nrosocio = frmEvaluarCapital.Textnrosocio.Text

            'telefonico , por correo , presencial 
            tiporequerimiento = frmEvaluarCapital.Texttiporequerimiento.Text
            codigobanco = frmEvaluarCapital.Textcodbanco.Text

            'datos  cuenta  bancaria del socio 
            formapago = frmEvaluarCapital.Textformapago.Text
            'MsgBox(formapago)


            If Trim(formapago) = "TRANSFERENCIA" Then
                Tipocuentabanco = frmEvaluarCapital.Textcodtipocuenta.Text
                banco = frmEvaluarCapital.Textnombrebanco.Text
                nrocuentabanco = frmEvaluarCapital.Textnrocuentabanco.Text
                'MsgBox(Tipocuentabanco)
                'MsgBox(banco)
                'MsgBox(nrocuentabanco)
                'Estado_Solicitud = "PREAPROBADO"
            Else
                Tipocuentabanco = ""
                banco = ""
                nrocuentabanco = ""
                codigobanco = ""
            End If

            Usuario = frmPerfil.CbmUsuario.SelectedItem.ToString
            'Sucursal = Trim(frmPerfil.TxtSede.Text())
            'Dim usuario As String

            Dim conexiones2 As New CConexion
            conexiones2.conexion()
            Dim command2 As SqlCommand = New SqlCommand("SELECT top 1  UBICACION  FROM [_RIESGO_PERFIL] WHERE   USUARIO='" + usuario.ToString.Trim + "'", conexiones2._conexion)
            conexiones2.abrir()
            Dim reader2 As SqlDataReader = command2.ExecuteReader()
            If reader2.HasRows Then
                Do While reader2.Read()
                    sucursal2 = reader2(0).ToString
                Loop
            Else
            End If
            reader2.Close()


            '= frmRIESGO.TextSucural22.Text
            'If Sucursal = "VALPARAÍSO" Then
            '    'sucursal2 = 1
            '    'CORRECION SUCURSAL  ------------------------------------
            '    If Trim(frmRIESGO.TextSucural22.Text) = "1" Then
            '        sucursal2 = 1
            '    ElseIf Trim(frmRIESGO.TextSucural22.Text) = "4" Then
            '        sucursal2 = 4
            '    End If
            '    'CORRECION SUCURSAL  ------------------------------------
            'ElseIf Sucursal = "VIÑA DEL MAR" Then
            '    sucursal2 = 2
            'End If
            'CORRECION SUCURSAL  ------------------------------------
            'If Trim(frmRIESGO.TextSucural22.Text) = "1" Then  'Valpo blanco 
            '    sucursal2 = 1
            'ElseIf Trim(frmRIESGO.TextSucural22.Text) = "4" Then ' Prat 
            '    sucursal2 = 4
            'ElseIf Trim(frmRIESGO.TextSucural22.Text) = "2" Then  ' viña 
            '    sucursal2 = 2
            'End If
            'CORRECION SUCURSAL  -----------------------------------



            If Pic1A.Visible = True Then
                cumplecapitalminimo = "SI"
            Else
                cumplecapitalminimo = "NO"
            End If


            If Pic2A.Visible = True Then
                cumplemontosolicitado = "SI"
            Else
                cumplemontosolicitado = "NO"
            End If


            If Pic3A.Visible = True Then
                cumplenroretirosanuales = "SI"
            Else
                cumplenroretirosanuales = "NO"
            End If


            If Pic4A.Visible = True Then
                cumplenroretirosmensuales = "SI"

            Else
                cumplenroretirosmensuales = "NO"

            End If

            If Pic5A.Visible = True Then
                cumplesociosinmora = "SI"

            Else
                cumplesociosinmora = "NO"

            End If

            If Pic6A.Visible = True Then
                cumpleavalsinmora = "SI"

            Else
                cumpleavalsinmora = "NO"
            End If

            If Pic7A.Visible = True Then
                cumplerestriccion = "SI"

            Else
                cumplerestriccion = "NO"
            End If

            If Pic8A.Visible = True Then
                cumplecapitalglobal = "SI"

            Else
                cumplecapitalglobal = "NO"
            End If

            If Pic8A.Visible = True Then
                If formapago = "TRANSFERENCIA" Then
                    ' OJO CON ESTO  REVISAR 
                    Estado_Solicitud = "PREAPROBADO"
                    Estado_Solicitud2 = 1
                Else

                    Estado_Solicitud = "APROBADO"
                    Estado_Solicitud2 = 1
                End If

            ElseIf Pic8A.Visible = False Then

                If formapago = "TRANSFERENCIA" Then
                    'OJO CON ESTO  REVISAR 
                    Estado_Solicitud = "PREAPROBADO"
                    Estado_Solicitud2 = 0
                ElseIf formapago = "EFECTIVO" Or formapago = "CHEQUE" Then
                    Estado_Solicitud = "APROBADO"
                    Estado_Solicitud2 = 0
                End If
                'Estado_Solicitud = "PENDIENTE"
            End If


            Dim xSql As String
            xSql = ""
            'xSql = xSql + "INSERT INTO  [_SISTEMA_PREVENCIONDELITOS_DESCRIPCION_PREPAGO] "
            'xSql = xSql + "  ([NROSOCIO] ,[DESCRIPCION],[TIPO],[FECHA_CONTROL],[id_solicitud],[TIPOLOGIA],[TIPO1] ,[TIPO2])VALUES("
            'xSql = xSql + "'" + nrosocio.ToString + "'"
            'xSql = xSql + " ,'" + textdescripcion.Text.ToString + "'"
            'xSql = xSql + " ,'" + NRORIESGO.ToString + "'"
            'xSql = xSql + " , (SELECT CONVERT(VARCHAR(10), GETDATE(), 112))"
            'xSql = xSql + " ,'" + ID_SOLICITUD.ToString + "'"
            'xSql = xSql + ",'" + CODTIPOLOGIA.ToString + "','" + tipo2.ToString + "','" + tipo3.ToString + "' )"

            xSql = xSql + "   BEGIN TRAN "
            xSql = xSql + "  INSERT INTO _RIESGO_SOLICITUD_GIRO_CAPITAL"
            xSql = xSql + " ([ID_SOLICITUD]"
            xSql = xSql + " ,[FECHA_SOLICITUD]"
            xSql = xSql + " ,[MONTO_SOLICITUD]"
            xSql = xSql + " ,[ESTADO_SOLICITUD]"
            ' ,[RUT]
            ' ,[DVRUT]
            ',[NOMBRE_SOCIO]
            xSql = xSql + " ,[NROSOCIO]"
            ',[TIPO_CUENTA]
            ' ,[BANCO]
            xSql = xSql + "  ,[NRO_CUENTA] "
            xSql = xSql + " ,[CORRELATIVO]"
            xSql = xSql + "  ,[FORMA_PAGO]"
            xSql = xSql + ",[USUARIO]"
            ' ,[SUCURSAL]
            xSql = xSql + " ,[REEVALUACION]"
            xSql = xSql + ",[EN_NOMINA]"
            ' ,[CODBANCO]
            xSql = xSql + ",[TIPO_SOLICITUD]"
            ' ,NOMBRES
            ' ,PATERNO
            ' ,MATERNO
            ' ,TOTALCAPITALSOCIAL
            '  ,CORRECCION_MONETARIA
            '  ,CUOTAS_PARTICIPACION
            '  ,TOTAL_NORETIRABLE
            ' ,MONTO_DISPONIBLE
            '  ,MONTO_MAXIMO_RETIRABLE
            xSql = xSql + ",[FILTRO_CAPITAL_MINIMO]"
            xSql = xSql + ",[FILTRO_MONTO_SOLICITADO]"
            xSql = xSql + ",[FILTRO_GIROS_ANUAL]"
            xSql = xSql + ",[FILTRO_GIROS_MENSUAL]"
            xSql = xSql + ",[FILTRO_SOCIO_SINMORA]"
            xSql = xSql + ",[FILTRO_AVAL_SINMORA]"
            xSql = xSql + ",[FILTRO_RESTRICCIONES]"
            xSql = xSql + ",[FILTRO_CAPITAL_GLOBAL]"
            xSql = xSql + ",[Aprobacion_SubGerencia]"
            xSql = xSql + ",[Estado_Solicitud2] "
            xSql = xSql + ",[COMENTARIO_EVALUACION]"
            xSql = xSql + " ,[SUCURSAL2])VALUES"
            xSql = xSql + "((SELECT  max([ID_SOLICITUD]) + 1  FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL])"
            xSql = xSql + ", (CONVERT(VARCHAR(8), GETDATE(), 112) )"
            xSql = xSql + "," + Trim(Montosolicitado) + ""
            xSql = xSql + ",'" + Trim(Estado_Solicitud) + "'"
            ','" + Trim(tomarut.ToString) + "'
            ','" + Trim(tomadigito.ToString) + "'
            ','" + Nombresocio.ToString + "'
            xSql = xSql + ",'" + nrosocio.ToString + "'"
            ','" + Tipocuentabanco.ToString + "'
            ','" + banco.ToString.ToString + "'
            xSql = xSql + ",'" + nrocuentabanco.ToString + "'"
            xSql = xSql + ",'" + Tomacorrelativo.ToString + "'"
            xSql = xSql + ",'" + formapago.ToString + "'"
            xSql = xSql + ",'" + Usuario.ToString + "'"
            ','" + Sucursal.ToString + "'
            xSql = xSql + ", 'NO' "
            xSql = xSql + ", '0' "
            ','" + codigobanco.ToString + "'
            xSql = xSql + ",'" + tiporequerimiento.ToString + "'"
            ','" + Trim(frmEvaluarCapital.textnombres2.Text) + "'
            ','" + Trim(frmEvaluarCapital.textpaterno.Text) + "'
            ','" + Trim(frmEvaluarCapital.Textmaterno.Text) + "'
            '," + Trim(montototal) + "
            '," + Trim(correcionmonetaria) + "
            '," + Trim(cuotasparticipacion) + "
            '," + Trim(totalnoretirable) + "
            '," + Trim(montodisponible) + "
            '," + Trim(montomaximoretirabel) + "
            xSql = xSql + ",'" + Trim(cumplecapitalminimo.ToString) + "'"
            xSql = xSql + ",'" + Trim(cumplemontosolicitado.ToString) + "'"
            xSql = xSql + ",'" + Trim(cumplenroretirosanuales.ToString) + "'"
            xSql = xSql + ",'" + Trim(cumplenroretirosmensuales.ToString) + "'"
            xSql = xSql + ",'" + Trim(cumplesociosinmora.ToString) + "'"
            xSql = xSql + ",'" + Trim(cumpleavalsinmora.ToString) + "'"
            xSql = xSql + ",'" + Trim(cumplerestriccion.ToString) + "'"
            xSql = xSql + ",'" + Trim(cumplecapitalglobal.ToString) + "'"
            xSql = xSql + ",'Por Analizar'"
            xSql = xSql + ",'" + Estado_Solicitud2.ToString + "'"
            xSql = xSql + ",'" + txtComentarioGirocapital.Text + "'"
            xSql = xSql + " ,'" + sucursal2.ToString + "') COMMIT TRAN"
            Dim conexiones60 As New CConexion
            conexiones60.conexion()
            _adaptador.InsertCommand = New SqlCommand(xSql, conexiones60._conexion)
            conexiones60.abrir()
            _adaptador.InsertCommand.Connection = conexiones60._conexion
            _adaptador.InsertCommand.ExecuteNonQuery()
            conexiones60.cerrar()

            'Dim conexiones4 As New CConexion
            'conexiones4.conexion()
            '_adaptador.InsertCommand = New SqlCommand(" BEGIN TRAN  INSERT INTO _RIESGO_SOLICITUD_GIRO_CAPITAL([ID_SOLICITUD],[FECHA_SOLICITUD],[MONTO_SOLICITUD],[ESTADO_SOLICITUD],[RUT],[DVRUT],[NOMBRE_SOCIO],[NROSOCIO],[TIPO_CUENTA],[BANCO],[NRO_CUENTA] ,[CORRELATIVO],[FORMA_PAGO],[USUARIO],[SUCURSAL],[REEVALUACION],[EN_NOMINA],[CODBANCO],[TIPO_SOLICITUD],NOMBRES,PATERNO,MATERNO,TOTALCAPITALSOCIAL,CORRECCION_MONETARIA,CUOTAS_PARTICIPACION,TOTAL_NORETIRABLE,MONTO_DISPONIBLE,MONTO_MAXIMO_RETIRABLE,[FILTRO_CAPITAL_MINIMO],[FILTRO_MONTO_SOLICITADO],[FILTRO_GIROS_ANUAL],[FILTRO_GIROS_MENSUAL],[FILTRO_SOCIO_SINMORA],[FILTRO_AVAL_SINMORA],[FILTRO_RESTRICCIONES],[FILTRO_CAPITAL_GLOBAL],[Aprobacion_SubGerencia],[Estado_Solicitud2] ,[COMENTARIO_EVALUACION] ,[SUCURSAL2])VALUES((Select  max([ID_SOLICITUD]) + 1  FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL]), (CONVERT(VARCHAR(8), GETDATE(), 112) )," + Trim(Montosolicitado) + ",'" + Trim(Estado_Solicitud) + "','" + Trim(tomarut.ToString) + "','" + Trim(tomadigito.ToString) + "','" + Nombresocio.ToString + "','" + nrosocio.ToString + "','" + Tipocuentabanco.ToString + "','" + banco.ToString.ToString + "','" + nrocuentabanco.ToString + "','" + Tomacorrelativo.ToString + "','" + formapago.ToString + "','" + Usuario.ToString + "','" + Sucursal.ToString + "', 'NO' , '0' ,'" + codigobanco.ToString + "','" + tiporequerimiento.ToString + "','" + Trim(frmEvaluarCapital.textnombres2.Text) + "','" + Trim(frmEvaluarCapital.textpaterno.Text) + "','" + Trim(frmEvaluarCapital.Textmaterno.Text) + "'," + Trim(montototal) + "," + Trim(correcionmonetaria) + "," + Trim(cuotasparticipacion) + "," + Trim(totalnoretirable) + "," + Trim(montodisponible) + "," + Trim(montomaximoretirabel) + ",'" + Trim(cumplecapitalminimo.ToString) + "','" + Trim(cumplemontosolicitado.ToString) + "','" + Trim(cumplenroretirosanuales.ToString) + "','" + Trim(cumplenroretirosmensuales.ToString) + "','" + Trim(cumplesociosinmora.ToString) + "','" + Trim(cumpleavalsinmora.ToString) + "','" + Trim(cumplerestriccion.ToString) + "','" + Trim(cumplecapitalglobal.ToString) + "','Por Analizar','" + Estado_Solicitud2.ToString + "','" + txtComentarioGirocapital.Text + "' ,'" + sucursal2.ToString + "') COMMIT TRAN ", conexiones4._conexion)
            'conexiones4.abrir()
            '_adaptador.InsertCommand.Connection = conexiones4._conexion
            '_adaptador.InsertCommand.ExecuteNonQuery()
            MsgBox("SOLICITUD DE GIRO DE CAPITAL INGRESADA")

            frmEvaluarCapital.Close()

            Me.Close()
        ElseIf txtComentarioGirocapital.Text.Length > 250 Then
            MsgBox("El comentario sobrepasa los 250 caracteres")
        End If
    End Sub


    'Sub AUTORIZAR_RENUNCIA_FALLECMIENTO() ' sucursal 2 lista para autorizar 
    '    If txtComentarioGirocapital.Text.Length <= 250 Then
    '        Dim Estado_Solicitud As String = ""
    '        Dim Estado_Solicitud2 As Integer = 1
    '        Dim Tomacorrelativo As Integer = 0
    '        Dim tomafecha As String = ""
    '        Dim tomafecha2 As String = ""
    '        Dim RUT As String = ""
    '        Dim Nombresocio As String = ""
    '        Dim nrosocio As Integer = 0
    '        Dim tiporequerimiento As String = ""
    '        Dim Tipocuentabanco As String = ""
    '        Dim banco As String = ""
    '        Dim nrocuentabanco As String = ""
    '        Dim codigobanco As String = ""
    '        Dim formapago As String = ""
    '        Dim Usuario As String = ""
    '        Dim Sucursal As String = ""
    '        Dim sucursal2 As Integer = 0

    '        Dim montototal As Integer = frmEvaluarCapital.Texttotales.Text
    '        Dim correcionmonetaria As Integer = frmEvaluarCapital.Textcorrecionmonetaria.Text
    '        Dim cuotasparticipacion As Integer = frmEvaluarCapital.Textcuotasdeparticipacion.Text
    '        Dim totalnoretirable As Integer = frmEvaluarCapital.Texttotalnoretirable.Text
    '        Dim montodisponible As Integer = frmEvaluarCapital.Textmontodisponible.Text
    '        Dim montomaximoretirabel As Integer = frmEvaluarCapital.Textmontomaximoretirable.Text
    '        Dim Montosolicitado As Integer = CInt(frmEvaluarCapital.Textmontorequerido.Text)
    '        Dim en_nomina As Integer = 0
    '        Dim Valorufdiaactual As String = Trim(frmEvaluarCapital.Textvalorufdiactual.Text)
    '        Dim valorcuotadegasto As Long = Trim(frmEvaluarCapital.Textcuotadegastos.Text)
    '        Dim valorcapitalmonto As Long = Trim(frmEvaluarCapital.TextCapitalabonaCreditos.Text)
    '        Dim tiposolicitud2 As String = Trim(frmEvaluarCapital.Texttiposolicitud2.Text)
    '        Dim diferenciaufcapital As Long = Trim(frmEvaluarCapital.Textdiferenciufcapital.Text)
    '        Dim pagootros As Long = Trim(frmEvaluarCapital.Textotrospagos.Text)

    '        'MsgBox(Montosolicitado)
    '        'MsgBox(montototal)
    '        'MsgBox(correcionmonetaria)
    '        'MsgBox(cuotasparticipacion)
    '        'MsgBox(totalnoretirable)
    '        'MsgBox(montodisponible)
    '        'MsgBox(montomaximoretirabel)
    '        'MsgBox(en_nomina)
    '        'MsgBox(Montosolicitado)
    '        tomafecha = DateTime.Now().ToShortDateString()  '"16/06/2009"
    '        tomafecha2 = Mid(tomafecha, 7, 10) + Mid(tomafecha, 4, 2) + Mid(tomafecha, 1, 2)

    '        Dim cadena As String
    '        Dim tabla() As String
    '        Dim n As Integer
    '        Dim tomarut As String
    '        Dim tomadigito As String
    '        cadena = frmEvaluarCapital.Textrut.Text
    '        tabla = Split(cadena, "-")
    '        For n = 0 To UBound(tabla, 1)
    '            If n = 0 Then
    '                tomarut = (tabla(n))
    '            Else
    '                tomadigito = (tabla(n))
    '            End If
    '        Next

    '        Nombresocio = frmEvaluarCapital.Textnombre.Text
    '        nrosocio = frmEvaluarCapital.Textnrosocio.Text

    '        'telefonico , por correo , presencial 
    '        tiporequerimiento = frmEvaluarCapital.Texttiporequerimiento.Text
    '        codigobanco = frmEvaluarCapital.Textcodbanco.Text

    '        'datos  cuenta  bancaria del socio 
    '        formapago = frmEvaluarCapital.Textformapago.Text
    '        formapago = Trim(frmEvaluarCapital.cboformapago.SelectedItem.ToString())
    '        'MsgBox(formapago)


    '        If Trim(formapago) = "TRANSFERENCIA" Then

    '            Tipocuentabanco = frmEvaluarCapital.Textcodtipocuenta.Text
    '            banco = frmEvaluarCapital.Textnombrebanco.Text
    '            nrocuentabanco = frmEvaluarCapital.Textnrocuentabanco.Text
    '            ' MsgBox(Tipocuentabanco)
    '            'MsgBox(banco)
    '            ' MsgBox(nrocuentabanco)
    '            'Estado_Solicitud = "PREAPROBADO"
    '        Else
    '            Tipocuentabanco = ""
    '            banco = ""
    '            nrocuentabanco = ""
    '            codigobanco = ""

    '        End If

    '        Usuario = frmPerfil.CbmUsuario.SelectedItem()
    '        Sucursal = Trim(frmPerfil.TxtSede.Text())

    '        'If Sucursal = "VALPARAÍSO" Then

    '        '    'CORRECION SUCURSAL  ------------------------------------
    '        '    If Trim(frmRIESGO.TextSucural22.Text) = "1" Then
    '        '        sucursal2 = 1
    '        '    ElseIf Trim(frmRIESGO.TextSucural22.Text) = "4" Then
    '        '        sucursal2 = 4
    '        '    End If
    '        '    'CORRECION SUCURSAL  ------------------------------------
    '        'ElseIf Sucursal = "VIÑA DEL MAR" Then
    '        '    sucursal2 = 2
    '        'End If

    '        'CORRECION SUCURSAL  ------------------------------------
    '        'If Trim(frmRIESGO.TextSucural22.Text) = "1" Then  'Valpo blanco 
    '        '    sucursal2 = 1
    '        'ElseIf Trim(frmRIESGO.TextSucural22.Text) = "4" Then ' Prat 
    '        '    sucursal2 = 4
    '        'ElseIf Trim(frmRIESGO.TextSucural22.Text) = "2" Then  ' viña 
    '        '    sucursal2 = 2
    '        'End If
    '        'CORRECION SUCURSAL  -----------------------------------


    '        'If Pic1A.Visible = True Then
    '        cumplecapitalminimo = ""
    '        'Else
    '        'cumplecapitalminimo = "NO"
    '        'End If
    '        'If Pic2A.Visible = True Then
    '        cumplemontosolicitado = ""
    '        'Else
    '        'cumplemontosolicitado = "NO"
    '        'End If
    '        'If Pic3A.Visible = True Then
    '        cumplenroretirosanuales = ""
    '        'Else
    '        ' cumplenroretirosanuales = "NO"
    '        'End If
    '        'If Pic4A.Visible = True Then
    '        cumplenroretirosmensuales = ""
    '        'Else
    '        '    cumplenroretirosmensuales = "NO"
    '        'End If
    '        If Pic5A.Visible = True Then
    '            cumplesociosinmora = "SI"
    '        Else
    '            cumplesociosinmora = "NO"
    '        End If
    '        If Pic6A.Visible = True Then
    '            cumpleavalsinmora = "SI"
    '        Else
    '            cumpleavalsinmora = "NO"
    '        End If
    '        'If Pic7A.Visible = True Then
    '        cumplerestriccion = ""
    '        'Else
    '        '    cumplerestriccion = "NO"
    '        'End If
    '        If Pic8A.Visible = True Then
    '            cumplecapitalglobal = "SI"

    '        Else
    '            cumplecapitalglobal = "NO"
    '        End If



    '        If Pic8A.Visible = True Then
    '            If formapago = "TRANSFERENCIA" Then
    '                ' OJO CON ESTO  REVISAR 
    '                Estado_Solicitud = "PREAPROBADO"
    '                Estado_Solicitud2 = 1
    '            Else
    '                Estado_Solicitud = "APROBADO"
    '                Estado_Solicitud2 = 1
    '            End If

    '        ElseIf Pic8A.Visible = False Then
    '            'MsgBox("no hya capital ")

    '            ' MsgBox(formapago)
    '            If formapago = "TRANSFERENCIA" Then
    '                'OJO CON ESTO  REVISAR 
    '                Estado_Solicitud = "PREAPROBADO"
    '                Estado_Solicitud2 = 0
    '            ElseIf formapago = "EFECTIVO" Or formapago = "CHEQUE" Then
    '                Estado_Solicitud = "APROBADO"
    '                Estado_Solicitud2 = 0
    '            End If
    '            'Estado_Solicitud = "PENDIENTE"
    '        End If

    '        Dim FECHACOMPLETA2 As String = ""
    '        Dim FECHACOMPLETA3 As String = ""
    '        Dim AÑO As String = ""
    '        FECHACOMPLETA2 = DateTime.Now().ToShortDateString()  '"16/06/2009"
    '        'VOLVEEEER A DEJAR PARA QUE PEUDA  CAMBIAR  EN EL MIMSO MES  SOLMKANRTE 
    '        FECHACOMPLETA3 = Mid(FECHACOMPLETA2, 7, 10) + Mid(FECHACOMPLETA2, 4, 2) + Mid(FECHACOMPLETA2, 1, 2)
    '        AÑO = Mid(FECHACOMPLETA2, 7, 10)



    '        'Dim sumtotaluf As Double
    '        'Dim sumtotalufrecibe As String = ""
    '        'Dim conexiones77 As New CConexion
    '        'conexiones77.conexion()
    '        'Dim command77 As SqlCommand = New SqlCommand("select sum(movuf) from _Capitalsocial where nrosocio ='" + Trim(nrosocio) + "' and fecha >='" + Trim(AÑO) + "0101'", conexiones77._conexion)
    '        'conexiones77.abrir()
    '        'Dim reader77 As SqlDataReader = command77.ExecuteReader()
    '        'If reader77.HasRows Then
    '        '    Do While reader77.Read()
    '        '        MsgBox(reader77(0))
    '        '        sumtotalufrecibe = reader77(0).ToString
    '        '        MsgBox(sumtotalufrecibe)
    '        '    Loop
    '        'Else
    '        'End If
    '        'reader77.Close()
    '        ' sumtotaluf = CDec(sumtotalufrecibe)

    '        '  MsgBox(sumtotaluf)
    '        'Dim ArrCadenaW As String() = sumtotalufrecibe.Split(",")
    '        'sumtotalufrecibe = ArrCadenaW(0) + "." + ArrCadenaW(1)
    '        'sumtotaluf = sumtotalufrecibe
    '        'RANGO_INTERMEDIO2_OBESP_5 = ArrCadenaW(1)

    '        ' MsgBox(sumtotaluf)

    '        Dim conexiones6 As New CConexion
    '        conexiones6.conexion()
    '        Dim command6 As SqlCommand = New SqlCommand("SELECT CORMOV+1 FROM _CORMOV", conexiones6._conexion)
    '        conexiones6.abrir()
    '        Dim reader6 As SqlDataReader = command6.ExecuteReader()
    '        If reader6.HasRows Then
    '            Do While reader6.Read()
    '                Tomacorrelativo = reader6(0).ToString
    '            Loop
    '        Else
    '        End If
    '        reader6.Close()


    '        Dim conexiones60 As New CConexion
    '        conexiones60.conexion()
    '        _adaptador.UpdateCommand = New SqlCommand("update   _CORMOV set CORMOV = CORMOV+1 ", conexiones60._conexion)
    '        conexiones60.abrir()
    '        _adaptador.UpdateCommand.Connection = conexiones60._conexion
    '        _adaptador.UpdateCommand.ExecuteNonQuery()
    '        conexiones60.cerrar()

    '        Dim conexiones4 As New CConexion
    '        conexiones4.conexion()
    '        _adaptador.InsertCommand = New SqlCommand(" BEGIN TRAN  INSERT INTO _RIESGO_SOLICITUD_GIRO_CAPITAL([ID_SOLICITUD],[FECHA_SOLICITUD],[MONTO_SOLICITUD],[ESTADO_SOLICITUD],[RUT],[DVRUT],[NOMBRE_SOCIO],[NROSOCIO],[TIPO_CUENTA],[BANCO],[NRO_CUENTA] ,[CORRELATIVO],[FORMA_PAGO],[USUARIO],[SUCURSAL],[REEVALUACION],[EN_NOMINA],[CODBANCO],[TIPO_SOLICITUD],NOMBRES,PATERNO,MATERNO,TOTALCAPITALSOCIAL,CORRECCION_MONETARIA,CUOTAS_PARTICIPACION,TOTAL_NORETIRABLE,MONTO_DISPONIBLE,MONTO_MAXIMO_RETIRABLE,[FILTRO_CAPITAL_MINIMO],[FILTRO_MONTO_SOLICITADO],[FILTRO_GIROS_ANUAL],[FILTRO_GIROS_MENSUAL],[FILTRO_SOCIO_SINMORA],[FILTRO_AVAL_SINMORA],[FILTRO_RESTRICCIONES],[FILTRO_CAPITAL_GLOBAL],[Aprobacion_SubGerencia],[Estado_Solicitud2] ,[COMENTARIO_EVALUACION] ,[SUCURSAL2],[VALORUFDIAACTUAL],[CUOTAGASTOS],[MONTOABONAPRESTAMOS],[TIPOSOLICITUD2],[SALDOVRUFCAPITAL],[MONTOPAGAOTROS])VALUES((SELECT  max([ID_SOLICITUD]) + 1  FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL]), (CONVERT(VARCHAR(8), GETDATE(), 112)) ," + Trim(Montosolicitado) + ",'" + Trim(Estado_Solicitud) + "','" + Trim(tomarut.ToString) + "','" + Trim(tomadigito.ToString) + "','" + Nombresocio.ToString + "','" + nrosocio.ToString + "','" + Tipocuentabanco.ToString + "','" + banco.ToString.ToString + "','" + nrocuentabanco.ToString + "','" + Tomacorrelativo.ToString + "','" + formapago.ToString + "','" + Usuario.ToString + "','" + Sucursal.ToString + "', 'NO' , '0' ,'" + codigobanco.ToString + "','" + tiporequerimiento.ToString + "','" + Trim(frmEvaluarCapital.textnombres2.Text) + "','" + Trim(frmEvaluarCapital.textpaterno.Text) + "','" + Trim(frmEvaluarCapital.Textmaterno.Text) + "'," + Trim(montototal) + "," + Trim(correcionmonetaria) + "," + Trim(cuotasparticipacion) + "," + Trim(totalnoretirable) + "," + Trim(montodisponible) + "," + Trim(montomaximoretirabel) + ",'" + Trim(cumplecapitalminimo.ToString) + "','" + Trim(cumplemontosolicitado.ToString) + "','" + Trim(cumplenroretirosanuales.ToString) + "','" + Trim(cumplenroretirosmensuales.ToString) + "','" + Trim(cumplesociosinmora.ToString) + "','" + Trim(cumpleavalsinmora.ToString) + "','" + Trim(cumplerestriccion.ToString) + "','" + Trim(cumplecapitalglobal.ToString) + "','Por Analizar','" + Estado_Solicitud2.ToString + "','" + txtComentarioGirocapital.Text + "' ,'" + sucursal2.ToString + "',(select sum(movuf) from _Capitalsocial where nrosocio ='" + Trim(nrosocio) + "' and fecha >='" + Trim(AÑO) + "0101')," + Trim(valorcuotadegasto) + "," + Trim(valorcapitalmonto) + ",'" + Trim(tiposolicitud2) + "'," + Trim(diferenciaufcapital) + ",'" + pagootros.ToString + "') COMMIT TRAN ", conexiones4._conexion)
    '        conexiones4.abrir()
    '        _adaptador.InsertCommand.Connection = conexiones4._conexion
    '        _adaptador.InsertCommand.ExecuteNonQuery()
    '        MsgBox("SOLICITUD DE GIRO DE CAPITAL INGRESADA")

    '        frmEvaluarCapital.Close()
    '        Me.Close()
    '    ElseIf txtComentarioGirocapital.Text.Length > 250 Then
    '        MsgBox("El comentario sobrepasa los 250 caracteres")
    '    End If
    'End Sub

    'Sub RECONCIDERA_FALLECIMIENTO_RENUNCIA()

    '    If txtComentarioGirocapital.Text.Length <= 250 Then
    '        Dim Estado_Solicitud As String = ""
    '        Dim Estado_Solicitud2 As Integer = 1
    '        Dim Tomacorrelativo As Integer = 0
    '        Dim tomafecha As String = ""
    '        Dim tomafecha2 As String = ""
    '        Dim RUT As String = ""
    '        Dim Nombresocio As String = ""
    '        Dim nrosocio As String = ""
    '        Dim tiporequerimiento As String = ""
    '        Dim Tipocuentabanco As String = ""
    '        Dim banco As String = ""
    '        Dim nrocuentabanco As String = ""
    '        Dim codigobanco As String = ""
    '        Dim formapago As String = ""
    '        Dim Usuario As String = ""
    '        Dim Sucursal As String = ""
    '        Dim Sucursal2 As Integer = 0
    '        Dim montototal As Integer = frmEvaluarCapital.Texttotales.Text
    '        'MsgBox(frmEvaluarCapital.Texttotales.Text)
    '        'Texttotales
    '        Dim correcionmonetaria As Integer = frmEvaluarCapital.Textcorrecionmonetaria.Text
    '        Dim cuotasparticipacion As Integer = frmEvaluarCapital.Textcuotasdeparticipacion.Text
    '        Dim totalnoretirable As Integer = frmEvaluarCapital.Texttotalnoretirable.Text
    '        Dim montodisponible As Integer = frmEvaluarCapital.Textmontodisponible.Text
    '        Dim montomaximoretirabel As Integer = frmEvaluarCapital.Textmontomaximoretirable.Text
    '        Dim Montosolicitado As Long = frmEvaluarCapital.Textmontorequerido.Text

    '        ' VALOR UF 
    '        Dim Valorufdiaactual As String = Trim(frmEvaluarCapital.Textvalorufdiactual.Text)
    '        Dim valorcuotadegasto As Long = Trim(frmEvaluarCapital.Textcuotadegastos.Text)
    '        Dim valorcapitalmonto As Long = Trim(frmEvaluarCapital.TextCapitalabonaCreditos.Text)
    '        Dim tiposolicitud2 As String = Trim(frmEvaluarCapital.Texttiposolicitud2.Text)
    '        Dim diferenciaufcapital As Long = Trim(frmEvaluarCapital.Textdiferenciufcapital.Text)
    '        Dim pagootros As Long = Trim(frmEvaluarCapital.Textotrospagos.Text)





    '        'MsgBox(montototal)
    '        'MsgBox(correcionmonetaria)
    '        'MsgBox(cuotasparticipacion)
    '        'MsgBox(totalnoretirable)
    '        'MsgBox(montodisponible)
    '        'MsgBox(montomaximoretirabel)
    '        'MsgBox(Montosolicitado)
    '        tomafecha = DateTime.Now().ToShortDateString()  '"16/06/2009"
    '        tomafecha2 = Mid(tomafecha, 7, 10) + Mid(tomafecha, 4, 2) + Mid(tomafecha, 1, 2)
    '        Dim conexiones6 As New CConexion
    '        conexiones6.conexion()
    '        Dim command6 As SqlCommand = New SqlCommand("SELECT CORMOV+1 FROM _CORMOV", conexiones6._conexion)
    '        conexiones6.abrir()
    '        Dim reader6 As SqlDataReader = command6.ExecuteReader()
    '        If reader6.HasRows Then
    '            Do While reader6.Read()
    '                Tomacorrelativo = reader6(0).ToString
    '            Loop
    '        Else
    '        End If
    '        reader6.Close()



    '        Dim conexiones60 As New CConexion
    '        conexiones60.conexion()
    '        _adaptador.UpdateCommand = New SqlCommand("update   _CORMOV set CORMOV = CORMOV+1 ", conexiones60._conexion)
    '        conexiones60.abrir()
    '        _adaptador.UpdateCommand.Connection = conexiones60._conexion
    '        _adaptador.UpdateCommand.ExecuteNonQuery()
    '        conexiones60.cerrar()

    '        Dim cadena As String
    '        Dim tabla() As String
    '        Dim n As Integer
    '        Dim tomarut As String
    '        Dim tomadigito As String
    '        cadena = frmEvaluarCapital.Textrut.Text
    '        tabla = Split(cadena, "-")
    '        For n = 0 To UBound(tabla, 1)
    '            If n = 0 Then
    '                tomarut = (tabla(n))
    '            Else
    '                tomadigito = (tabla(n))
    '            End If
    '        Next

    '        Nombresocio = frmEvaluarCapital.Textnombre.Text
    '        nrosocio = frmEvaluarCapital.Textnrosocio.Text

    '        'telefonico , por correo , presencial 
    '        tiporequerimiento = frmEvaluarCapital.Texttiporequerimiento.Text
    '        codigobanco = frmEvaluarCapital.Textcodbanco.Text

    '        'datos  cuenta  bancaria del socio 

    '        ' formapago = frmEvaluarCapital.Textformapago.Text
    '        'datos  cuenta  bancaria del socio 
    '        formapago = frmEvaluarCapital.Textformapago.Text
    '        formapago = Trim(frmEvaluarCapital.cboformapago.SelectedItem.ToString())
    '        'MsgBox(formapago)
    '        If formapago = "TRANSFERENCIA" Then
    '            Tipocuentabanco = frmEvaluarCapital.Textcodtipocuenta.Text
    '            banco = frmEvaluarCapital.Textnombrebanco.Text
    '            nrocuentabanco = frmEvaluarCapital.Textnrocuentabanco.Text
    '            'MsgBox(Tipocuentabanco)
    '            ' MsgBox(banco)
    '            ' MsgBox(nrocuentabanco)
    '            'Estado_Solicitud = "PREAPROBADO"
    '        Else
    '            Tipocuentabanco = ""
    '            banco = ""
    '            nrocuentabanco = ""
    '            codigobanco = ""
    '        End If

    '        Usuario = frmPerfil.CbmUsuario.SelectedItem()
    '        Sucursal = Trim(frmPerfil.TxtSede.Text())
    '        'MsgBox(Sucursal)
    '        'If Sucursal = "VALPARAÍSO" Then

    '        '    'CORRECION SUCURSAL  ------------------------------------
    '        '    If Trim(frmRIESGO.TextSucural22.Text) = "1" Then
    '        '        Sucursal2 = 1
    '        '    ElseIf Trim(frmRIESGO.TextSucural22.Text) = "4" Then
    '        '        Sucursal2 = 4
    '        '    End If
    '        '    'CORRECION SUCURSAL  ------------------------------------

    '        'ElseIf Sucursal = "VIÑA DEL MAR" Then
    '        '    Sucursal2 = 2
    '        'End If

    '        'CORRECION SUCURSAL  ------------------------------------
    '        'If Trim(frmRIESGO.TextSucural22.Text) = "1" Then  'Valpo blanco 
    '        '    Sucursal2 = 1
    '        'ElseIf Trim(frmRIESGO.TextSucural22.Text) = "4" Then ' Prat 
    '        '    Sucursal2 = 4
    '        'ElseIf Trim(frmRIESGO.TextSucural22.Text) = "2" Then  ' viña 
    '        '    Sucursal2 = 2
    '        'End If
    '        'CORRECION SUCURSAL  -----------------------------------





    '        'MsgBox(Sucursal2)
    '        'If Pic1A.Visible = True Then
    '        cumplecapitalminimo = ""
    '        'Else
    '        '    cumplecapitalminimo = "NO"
    '        'End If

    '        'If Pic2A.Visible = True Then
    '        cumplemontosolicitado = ""
    '        'Else
    '        '    cumplemontosolicitado = "NO"
    '        'End If

    '        'If Pic3A.Visible = True Then
    '        cumplenroretirosanuales = ""
    '        'Else
    '        '    cumplenroretirosanuales = "NO"
    '        'End If

    '        'If Pic4A.Visible = True Then
    '        cumplenroretirosmensuales = ""

    '        'Else
    '        '    cumplenroretirosmensuales = "NO"
    '        'End If

    '        If Pic5A.Visible = True Then
    '            cumplesociosinmora = "SI"
    '        Else
    '            cumplesociosinmora = "NO"

    '        End If

    '        If Pic6A.Visible = True Then
    '            cumpleavalsinmora = "SI"
    '        Else
    '            cumpleavalsinmora = "NO"
    '        End If

    '        'If Pic7A.Visible = True Then
    '        cumplerestriccion = ""
    '        'Else
    '        '    cumplerestriccion = "NO"
    '        'End If

    '        'If Pic8A.Visible = True Then
    '        cumplecapitalglobal = ""
    '        'Else
    '        '    cumplecapitalglobal = "NO"
    '        'End If

    '        'If Pic8A.Visible = True Then
    '        'OJO CON ESTO  REVISAR 
    '        Estado_Solicitud = "RECONSIDERACIÓN"
    '        Estado_Solicitud2 = 1
    '        'Estado_Solicitud = "RECONCIDERACION"

    '        'ElseIf Pic8A.Visible = False Then
    '        '    'ver tema despues  de que  no este en estado pendiente 
    '        '    Estado_Solicitud = "RECONSIDERACIÓN"
    '        '    'Estado_Solicitud2 = 0
    '        'End If
    '        Dim FECHACOMPLETA2 As String = ""
    '        Dim FECHACOMPLETA3 As String = ""
    '        Dim AÑO As String = ""
    '        FECHACOMPLETA2 = DateTime.Now().ToShortDateString()  '"16/06/2009"
    '        'VOLVEEEER A DEJAR PARA QUE PEUDA  CAMBIAR  EN EL MIMSO MES  SOLMKANRTE 
    '        FECHACOMPLETA3 = Mid(FECHACOMPLETA2, 7, 10) + Mid(FECHACOMPLETA2, 4, 2) + Mid(FECHACOMPLETA2, 1, 2)
    '        AÑO = Mid(FECHACOMPLETA2, 7, 10)

    '        Dim conexiones4 As New CConexion
    '        conexiones4.conexion()                                                                                                                                                                                                                                          'cumplecapitalminimo As String = ""
    '        'Dim cumpleavalsinmora As String = ""
    '        _adaptador.InsertCommand = New SqlCommand("BEGIN TRAN  INSERT INTO _RIESGO_SOLICITUD_GIRO_CAPITAL([ID_SOLICITUD],[FECHA_SOLICITUD],[MONTO_SOLICITUD],[ESTADO_SOLICITUD],[RUT],[DVRUT],[NOMBRE_SOCIO],[NROSOCIO],[TIPO_CUENTA],[BANCO],[NRO_CUENTA] ,[CORRELATIVO],[FORMA_PAGO],[USUARIO],[SUCURSAL],[REEVALUACION],[EN_NOMINA],[CODBANCO],[TIPO_SOLICITUD],NOMBRES,PATERNO,MATERNO,TOTALCAPITALSOCIAL,CORRECCION_MONETARIA,CUOTAS_PARTICIPACION,TOTAL_NORETIRABLE,MONTO_DISPONIBLE,MONTO_MAXIMO_RETIRABLE,[FILTRO_CAPITAL_MINIMO],[FILTRO_MONTO_SOLICITADO],[FILTRO_GIROS_ANUAL],[FILTRO_GIROS_MENSUAL],[FILTRO_SOCIO_SINMORA],[FILTRO_AVAL_SINMORA],[FILTRO_RESTRICCIONES],[FILTRO_CAPITAL_GLOBAL],[Aprobacion_SubGerencia],[Estado_Solicitud2],[COMENTARIO_EVALUACION],[SUCURSAL2],[VALORUFDIAACTUAL],[CUOTAGASTOS],[MONTOABONAPRESTAMOS],[TIPOSOLICITUD2],[SALDOVRUFCAPITAL],[MONTOPAGAOTROS] )VALUES((SELECT  max([ID_SOLICITUD]) + 1  FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL]),(CONVERT(VARCHAR(8), GETDATE(), 112)  )," + Trim(Montosolicitado) + ",'" + Trim(Estado_Solicitud) + "','" + Trim(tomarut.ToString) + "','" + Trim(tomadigito.ToString) + "','" + Nombresocio.ToString + "','" + nrosocio.ToString + "','" + Tipocuentabanco.ToString + "','" + banco.ToString.ToString + "','" + nrocuentabanco.ToString + "','" + Tomacorrelativo.ToString + "','" + formapago.ToString + "','" + Usuario.ToString + "','" + Sucursal.ToString + "', 'SI' , '0','" + codigobanco.ToString + "','" + tiporequerimiento.ToString + "','" + Trim(frmEvaluarCapital.textnombres2.Text) + "','" + Trim(frmEvaluarCapital.textpaterno.Text) + "','" + Trim(frmEvaluarCapital.Textmaterno.Text) + "'," + Trim(montototal) + "," + Trim(correcionmonetaria) + "," + Trim(cuotasparticipacion) + "," + Trim(totalnoretirable) + "," + Trim(montodisponible) + "," + Trim(montomaximoretirabel) + ",'" + Trim(cumplecapitalminimo.ToString) + "','" + Trim(cumplemontosolicitado.ToString) + "','" + Trim(cumplenroretirosanuales.ToString) + "','" + Trim(cumplenroretirosmensuales.ToString) + "','" + Trim(cumplesociosinmora.ToString) + "','" + Trim(cumpleavalsinmora.ToString) + "','" + Trim(cumplerestriccion.ToString) + "','" + Trim(cumplecapitalglobal.ToString) + "','Por Analizar','" + Estado_Solicitud2.ToString + "' ,'" + txtComentarioGirocapital.Text + "','" + Sucursal2.ToString + "',(select sum(movuf) from _Capitalsocial where nrosocio ='" + Trim(nrosocio) + "' and fecha >='" + Trim(AÑO) + "0101')," + Trim(valorcuotadegasto) + "," + Trim(valorcapitalmonto) + ",'" + Trim(tiposolicitud2) + "'," + Trim(diferenciaufcapital) + ",'" + pagootros.ToString + "') COMMIT TRAN ", conexiones4._conexion)
    '        conexiones4.abrir()
    '        _adaptador.InsertCommand.Connection = conexiones4._conexion
    '        _adaptador.InsertCommand.ExecuteNonQuery()
    '        conexiones4.cerrar()
    '        MsgBox("SOLICITUD DE GIRO DE CAPITAL INGRESADA A RECONSIDERACIÓN")
    '        frmEvaluarCapital.Close()
    '        Me.Close()

    '    ElseIf txtComentarioGirocapital.Text.Length > 250 Then
    '        MsgBox("El comentario sobrepasa los 250 caracteres")
    '    End If


    'End Sub







    Sub RECONCIDERA() ' reconcidera listo con la sucursal 2

        If txtComentarioGirocapital.Text.Length <= 250 Then
            Dim Estado_Solicitud As String = ""
            Dim Estado_Solicitud2 As Integer = 1
            Dim Tomacorrelativo As Integer = 0
            Dim tomafecha As String = ""
            Dim tomafecha2 As String = ""
            Dim RUT As String = ""
            Dim Nombresocio As String = ""
            Dim nrosocio As String = ""
            Dim tiporequerimiento As String = ""
            Dim Tipocuentabanco As String = ""
            Dim banco As String = ""
            Dim nrocuentabanco As String = ""
            Dim codigobanco As String = ""
            Dim formapago As String = ""
            Dim Usuario As String = ""
            Dim Sucursal As String = ""
            Dim Sucursal2 As Integer = 0
            Dim montototal As Integer = frmEvaluarCapital.Texttotales.Text
            'MsgBox(frmEvaluarCapital.Texttotales.Text)
            'Texttotales
            Dim correcionmonetaria As Integer = frmEvaluarCapital.Textcorrecionmonetaria.Text
            Dim cuotasparticipacion As Integer = frmEvaluarCapital.Textcuotasdeparticipacion.Text
            Dim totalnoretirable As Integer = frmEvaluarCapital.Texttotalnoretirable.Text
            Dim montodisponible As Integer = frmEvaluarCapital.Textmontodisponible.Text
            Dim montomaximoretirabel As Integer = frmEvaluarCapital.Textmontomaximoretirable.Text
            Dim Montosolicitado As Long = frmEvaluarCapital.Textmontorequerido.Text
            'MsgBox(montototal)
            'MsgBox(correcionmonetaria)
            'MsgBox(cuotasparticipacion)
            'MsgBox(totalnoretirable)
            'MsgBox(montodisponible)
            'MsgBox(montomaximoretirabel)
            'MsgBox(Montosolicitado)
            

            Dim cadena As String
            Dim tabla() As String
            Dim n As Integer
            Dim tomarut As String
            Dim tomadigito As String
            cadena = frmEvaluarCapital.Textrut.Text
            tabla = Split(cadena, "-")
            For n = 0 To UBound(tabla, 1)
                If n = 0 Then
                    tomarut = (tabla(n))
                Else
                    tomadigito = (tabla(n))
                End If
            Next

            Nombresocio = frmEvaluarCapital.Textnombre.Text
            nrosocio = frmEvaluarCapital.Textnrosocio.Text

            'telefonico , por correo , presencial 
            tiporequerimiento = frmEvaluarCapital.Texttiporequerimiento.Text
            codigobanco = frmEvaluarCapital.Textcodbanco.Text

            'datos  cuenta  bancaria del socio 

            formapago = frmEvaluarCapital.Textformapago.Text
            'MsgBox(formapago)
            If formapago = "TRANSFERENCIA" Then
                Tipocuentabanco = frmEvaluarCapital.Textcodtipocuenta.Text
                banco = frmEvaluarCapital.Textnombrebanco.Text
                nrocuentabanco = frmEvaluarCapital.Textnrocuentabanco.Text
                'MsgBox(Tipocuentabanco)
                ' MsgBox(banco)
                ' MsgBox(nrocuentabanco)
                'Estado_Solicitud = "PREAPROBADO"
            Else
                Tipocuentabanco = ""
                banco = ""
                nrocuentabanco = ""
                codigobanco = ""
            End If

            Usuario = frmPerfil.CbmUsuario.SelectedItem()
            ' Sucursal = Trim(frmPerfil.TxtSede.Text())

            Dim conexiones2 As New CConexion
            conexiones2.conexion()
            Dim command2 As SqlCommand = New SqlCommand("SELECT top 1  UBICACION  FROM [_RIESGO_PERFIL] WHERE   USUARIO='" + Usuario.ToString.Trim + "'", conexiones2._conexion)
            conexiones2.abrir()
            Dim reader2 As SqlDataReader = command2.ExecuteReader()
            If reader2.HasRows Then
                Do While reader2.Read()
                    Sucursal2 = reader2(0).ToString
                Loop
            Else
            End If
            reader2.Close()

            'MsgBox(Sucursal)
            'If Sucursal = "VALPARAÍSO" Then
            'Sucursal2 = 1
            'ElseIf Sucursal = "VIÑA DEL MAR" Then
            'Sucursal2 = 2
            'End If
            'CORRECION SUCURSAL  ------------------------------------
            'If Trim(frmRIESGO.TextSucural22.Text) = "1" Then  'Valpo blanco 
            'Sucursal2 = 1
            'ElseIf Trim(frmRIESGO.TextSucural22.Text) = "4" Then ' Prat 
            'Sucursal2 = 4
            'ElseIf Trim(frmRIESGO.TextSucural22.Text) = "2" Then  ' viña 
            'Sucursal2 = 2
            'End If
            'CORRECION SUCURSAL  ------------------------------------
            'MsgBox(Sucursal2)

            If Pic1A.Visible = True Then
                cumplecapitalminimo = "SI"
            Else
                cumplecapitalminimo = "NO"
            End If

            If Pic2A.Visible = True Then
                cumplemontosolicitado = "SI"
            Else
                cumplemontosolicitado = "NO"
            End If

            If Pic3A.Visible = True Then
                cumplenroretirosanuales = "SI"
            Else
                cumplenroretirosanuales = "NO"
            End If

            If Pic4A.Visible = True Then
                cumplenroretirosmensuales = "SI"
            Else
                cumplenroretirosmensuales = "NO"
            End If

            If Pic5A.Visible = True Then
                cumplesociosinmora = "SI"
            Else
                cumplesociosinmora = "NO"

            End If

            If Pic6A.Visible = True Then
                cumpleavalsinmora = "SI"
            Else
                cumpleavalsinmora = "NO"
            End If

            If Pic7A.Visible = True Then
                cumplerestriccion = "SI"
            Else
                cumplerestriccion = "NO"
            End If

            If Pic8A.Visible = True Then
                cumplecapitalglobal = "SI"
            Else
                cumplecapitalglobal = "NO"
            End If

            If Pic8A.Visible = True Then
                'OJO CON ESTO  REVISAR 
                Estado_Solicitud = "RECONSIDERACIÓN"
                Estado_Solicitud2 = 1
                'Estado_Solicitud ="RECONCIDERACION"

            ElseIf Pic8A.Visible = False Then
                '  ver tema despues  de que  no este en estado pendiente 
                Estado_Solicitud = "RECONSIDERACIÓN"
                Estado_Solicitud2 = 0
            End If

            tomafecha = DateTime.Now().ToShortDateString()  '"16/06/2009"
            tomafecha2 = Mid(tomafecha, 7, 10) + Mid(tomafecha, 4, 2) + Mid(tomafecha, 1, 2)


            'Dim conexiones2 As New CConexion
            'conexiones2.conexion()
            'Dim command2 As SqlCommand = New SqlCommand("_SIGUIENTE @Tipo='CORMOV' ", conexiones2._conexion)
            'conexiones2.abrir()
            'Dim reader2 As SqlDataReader = command2.ExecuteReader()
            'If reader2.HasRows Then
            '    Do While reader2.Read()
            '        Tomacorrelativo = (reader2(0).ToString)
            '    Loop
            'Else
            'End If
            'reader2.Close()



            Dim conexiones6 As New CConexion
            conexiones6.conexion()
            Dim command6 As SqlCommand = New SqlCommand("_SIGUIENTE @Tipo='CORMOV' ", conexiones6._conexion)
            conexiones6.abrir()
            Dim reader6 As SqlDataReader = command6.ExecuteReader()
            If reader6.HasRows Then
                Do While reader6.Read()
                    Tomacorrelativo = reader6(0).ToString
                Loop
            Else
            End If
            reader6.Close()

            'Dim conexiones60 As New CConexion
            'conexiones60.conexion()
            '_adaptador.UpdateCommand = New SqlCommand("update   _CORMOV set CORMOV = CORMOV+1 ", conexiones60._conexion)
            'conexiones60.abrir()
            '_adaptador.UpdateCommand.Connection = conexiones60._conexion
            '_adaptador.UpdateCommand.ExecuteNonQuery()
            'conexiones60.cerrar()
            Dim xSql As String
            xSql = ""
            xSql = xSql + " BEGIN TRAN  INSERT "
            xSql = xSql + "   INTO _RIESGO_SOLICITUD_GIRO_CAPITAL"
            xSql = xSql + " ([ID_SOLICITUD]"
            xSql = xSql + " ,[FECHA_SOLICITUD]"
            xSql = xSql + "  ,[MONTO_SOLICITUD]"
            xSql = xSql + "  ,[ESTADO_SOLICITUD]"
            '  ,[RUT]
            '  ,[DVRUT]
            '  ,[NOMBRE_SOCIO]
            xSql = xSql + " ,[NROSOCIO]"
            '  ,[TIPO_CUENTA]
            '  ,[BANCO]
            xSql = xSql + "  ,[NRO_CUENTA] "
            xSql = xSql + " ,[CORRELATIVO]"
            xSql = xSql + "   ,[FORMA_PAGO]"
            xSql = xSql + " ,[USUARIO]"
            '  ,[SUCURSAL]
            xSql = xSql + " ,[REEVALUACION]"
            xSql = xSql + " ,[EN_NOMINA]"
            '  ,[CODBANCO]
            xSql = xSql + " ,[TIPO_SOLICITUD]"
            '  ,NOMBRES
            '  ,PATERNO
            '   ,MATERNO
            '  ,TOTALCAPITALSOCIAL
            '  ,CORRECCION_MONETARIA
            '   ,CUOTAS_PARTICIPACION
            '  ,TOTAL_NORETIRABLE
            '   ,MONTO_DISPONIBLE
            ' ,MONTO_MAXIMO_RETIRABLE
            xSql = xSql + "   ,[FILTRO_CAPITAL_MINIMO]"
            xSql = xSql + "   ,[FILTRO_MONTO_SOLICITADO]"
            xSql = xSql + "   ,[FILTRO_GIROS_ANUAL]"
            xSql = xSql + ",[FILTRO_GIROS_MENSUAL]"
            xSql = xSql + " ,[FILTRO_SOCIO_SINMORA]"
            xSql = xSql + " ,[FILTRO_AVAL_SINMORA]"
            xSql = xSql + ",[FILTRO_RESTRICCIONES]"
            xSql = xSql + " ,[FILTRO_CAPITAL_GLOBAL]"
            xSql = xSql + " ,[Aprobacion_SubGerencia]"
            xSql = xSql + ",[Estado_Solicitud2]"
            xSql = xSql + " ,[COMENTARIO_EVALUACION]"
            xSql = xSql + ",[SUCURSAL2])"
            xSql = xSql + " VALUES((SELECT  max([ID_SOLICITUD]) + 1  "
            xSql = xSql + "From [_RIESGO_SOLICITUD_GIRO_CAPITAL])"
            xSql = xSql + " ,(CONVERT(VARCHAR(8), GETDATE(), 112)  )"
            xSql = xSql + "," + Trim(Montosolicitado) + ""
            xSql = xSql + " ,'" + Trim(Estado_Solicitud) + "'"
            ' ,'" + Trim(tomarut.ToString) + "'
            '  ,'" + Trim(tomadigito.ToString) + "'
            '  ,'" + Nombresocio.ToString + "'
            xSql = xSql + "  ,'" + nrosocio.ToString + "'"
            '  ,'" + Tipocuentabanco.ToString + "'
            '  ,'" + banco.ToString.ToString + "'
            xSql = xSql + "  ,'" + nrocuentabanco.ToString + "'"
            xSql = xSql + " ,'" + Tomacorrelativo.ToString + "'"
            xSql = xSql + " ,'" + formapago.ToString + "'"
            xSql = xSql + ",'" + Usuario.ToString + "'"
            '   ,'" + Sucursal.ToString + "'
            xSql = xSql + "  , 'SI' "
            xSql = xSql + "  , '0'"
            '   ,'" + codigobanco.ToString + "'
            xSql = xSql + "  ,'" + tiporequerimiento.ToString + "'"
            '  ,'" + Trim(frmEvaluarCapital.textnombres2.Text) + "'
            '  ,'" + Trim(frmEvaluarCapital.textpaterno.Text) + "'
            '  ,'" + Trim(frmEvaluarCapital.Textmaterno.Text) + "'
            '  ," + Trim(montototal) + "
            '  ," + Trim(correcionmonetaria) + "
            '   ," + Trim(cuotasparticipacion) + "
            ' ," + Trim(totalnoretirable) + "
            '  ," + Trim(montodisponible) + "
            '   ," + Trim(montomaximoretirabel) + "
            xSql = xSql + "  ,'" + Trim(cumplecapitalminimo.ToString) + "'"
            xSql = xSql + " ,'" + Trim(cumplemontosolicitado.ToString) + "'"
            xSql = xSql + " ,'" + Trim(cumplenroretirosanuales.ToString) + "'"
            xSql = xSql + "  ,'" + Trim(cumplenroretirosmensuales.ToString) + "'"
            xSql = xSql + "  ,'" + Trim(cumplesociosinmora.ToString) + "'"
            xSql = xSql + "  ,'" + Trim(cumpleavalsinmora.ToString) + "'"
            xSql = xSql + "  ,'" + Trim(cumplerestriccion.ToString) + "'"
            xSql = xSql + "  ,'" + Trim(cumplecapitalglobal.ToString) + "'"
            xSql = xSql + "  ,'Por Analizar'"
            xSql = xSql + "   ,'" + Estado_Solicitud2.ToString + "' "
            xSql = xSql + "   ,'" + txtComentarioGirocapital.Text + "'"
            xSql = xSql + "   ,'" + Sucursal2.ToString + "') COMMIT TRAN  "




            Dim conexiones60 As New CConexion
            conexiones60.conexion()
            _adaptador.InsertCommand = New SqlCommand(xSql, conexiones60._conexion)
            conexiones60.abrir()
            _adaptador.InsertCommand.Connection = conexiones60._conexion
            _adaptador.InsertCommand.ExecuteNonQuery()
            conexiones60.cerrar()













            'Dim conexiones4 As New CConexion
            'conexiones4.conexion()                                                                                                                                                                                                                                          'cumplecapitalminimo As String = ""
            ''Dim cumpleavalsinmora As String = ""
            '_adaptador.InsertCommand = New SqlCommand("BEGIN TRAN  INSERT INTO _RIESGO_SOLICITUD_GIRO_CAPITAL([ID_SOLICITUD],[FECHA_SOLICITUD],[MONTO_SOLICITUD],[ESTADO_SOLICITUD],[RUT],[DVRUT],[NOMBRE_SOCIO],[NROSOCIO],[TIPO_CUENTA],[BANCO],[NRO_CUENTA] ,[CORRELATIVO],[FORMA_PAGO],[USUARIO],[SUCURSAL],[REEVALUACION],[EN_NOMINA],[CODBANCO],[TIPO_SOLICITUD],NOMBRES,PATERNO,MATERNO,TOTALCAPITALSOCIAL,CORRECCION_MONETARIA,CUOTAS_PARTICIPACION,TOTAL_NORETIRABLE,MONTO_DISPONIBLE,MONTO_MAXIMO_RETIRABLE,[FILTRO_CAPITAL_MINIMO],[FILTRO_MONTO_SOLICITADO],[FILTRO_GIROS_ANUAL],[FILTRO_GIROS_MENSUAL],[FILTRO_SOCIO_SINMORA],[FILTRO_AVAL_SINMORA],[FILTRO_RESTRICCIONES],[FILTRO_CAPITAL_GLOBAL],[Aprobacion_SubGerencia],[Estado_Solicitud2],[COMENTARIO_EVALUACION],[SUCURSAL2])VALUES((Select  max([ID_SOLICITUD]) + 1  FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL]),(CONVERT(VARCHAR(8), GETDATE(), 112)  )," + Trim(Montosolicitado) + ",'" + Trim(Estado_Solicitud) + "','" + Trim(tomarut.ToString) + "','" + Trim(tomadigito.ToString) + "','" + Nombresocio.ToString + "','" + nrosocio.ToString + "','" + Tipocuentabanco.ToString + "','" + banco.ToString.ToString + "','" + nrocuentabanco.ToString + "','" + Tomacorrelativo.ToString + "','" + formapago.ToString + "','" + Usuario.ToString + "','" + Sucursal.ToString + "', 'SI' , '0','" + codigobanco.ToString + "','" + tiporequerimiento.ToString + "','" + Trim(frmEvaluarCapital.textnombres2.Text) + "','" + Trim(frmEvaluarCapital.textpaterno.Text) + "','" + Trim(frmEvaluarCapital.Textmaterno.Text) + "'," + Trim(montototal) + "," + Trim(correcionmonetaria) + "," + Trim(cuotasparticipacion) + "," + Trim(totalnoretirable) + "," + Trim(montodisponible) + "," + Trim(montomaximoretirabel) + ",'" + Trim(cumplecapitalminimo.ToString) + "','" + Trim(cumplemontosolicitado.ToString) + "','" + Trim(cumplenroretirosanuales.ToString) + "','" + Trim(cumplenroretirosmensuales.ToString) + "','" + Trim(cumplesociosinmora.ToString) + "','" + Trim(cumpleavalsinmora.ToString) + "','" + Trim(cumplerestriccion.ToString) + "','" + Trim(cumplecapitalglobal.ToString) + "','Por Analizar','" + Estado_Solicitud2.ToString + "' ,'" + txtComentarioGirocapital.Text + "','" + Sucursal2.ToString + "') COMMIT TRAN  ", conexiones4._conexion)
            'conexiones4.abrir()
            '_adaptador.InsertCommand.Connection = conexiones4._conexion
            '_adaptador.InsertCommand.ExecuteNonQuery()
            'conexiones4.cerrar()
            MsgBox("SOLICITUD DE GIRO DE CAPITAL INGRESADA")
            frmEvaluarCapital.Close()
            Me.Close()

        ElseIf txtComentarioGirocapital.Text.Length > 250 Then
            MsgBox("El comentario sobrepasa los 250 caracteres")
        End If
    End Sub

    Sub PENDIENTE() ' pendiente listo cvon surcursal 2
        If txtComentarioGirocapital.Text.Length <= 250 Then

            Dim Estado_Solicitud As String = ""
            Dim Estado_Solicitud2 As Integer = 1
            Dim Tomacorrelativo As Integer = 0
            Dim tomafecha As String = ""
            Dim tomafecha2 As String = ""
            Dim RUT As String = ""
            Dim Nombresocio As String = ""
            Dim nrosocio As Integer = 0
            Dim tiporequerimiento As String = ""
            Dim Tipocuentabanco As String = ""
            Dim banco As String = ""
            Dim nrocuentabanco As String = ""
            Dim codigobanco As String = ""

            Dim formapago As String = ""
            Dim Usuario As String = ""
            Dim Sucursal As String = ""
            Dim Sucursal2 As Integer = 0

            Dim montototal As Integer = frmEvaluarCapital.Texttotales.Text
            Dim correcionmonetaria As Integer = frmEvaluarCapital.Textcorrecionmonetaria.Text
            Dim cuotasparticipacion As Integer = frmEvaluarCapital.Textcuotasdeparticipacion.Text
            Dim totalnoretirable As Integer = frmEvaluarCapital.Texttotalnoretirable.Text
            Dim montodisponible As Integer = frmEvaluarCapital.Textmontodisponible.Text
            Dim montomaximoretirabel As Integer = frmEvaluarCapital.Textmontomaximoretirable.Text
            Dim Montosolicitado As Integer = CInt(frmEvaluarCapital.Textmontorequerido.Text)
            Dim en_nomina As Integer = 0


            Dim Valorufdiaactual As String = Trim(frmEvaluarCapital.Textvalorufdiactual.Text)
            Dim valorcuotadegasto As Long = Trim(frmEvaluarCapital.Textcuotadegastos.Text)
            Dim valorcapitalmonto As Long = Trim(frmEvaluarCapital.TextCapitalabonaCreditos.Text)
            Dim tiposolicitud2 As String = Trim(frmEvaluarCapital.Texttiposolicitud2.Text)
            Dim diferenciaufcapital As Long = Trim(frmEvaluarCapital.Textdiferenciufcapital.Text)
            Dim pagootros As Long = Trim(frmEvaluarCapital.Textotrospagos.Text)
            'MsgBox(Montosolicitado)
            'MsgBox(montototal)
            'MsgBox(correcionmonetaria)
            'MsgBox(cuotasparticipacion)
            'MsgBox(totalnoretirable)
            'MsgBox(montodisponible)
            'MsgBox(montomaximoretirabel)
            'MsgBox(en_nomina)
            'MsgBox(Montosolicitado)

            tomafecha = DateTime.Now().ToShortDateString()  '"16/06/2009"
            tomafecha2 = Mid(tomafecha, 7, 10) + Mid(tomafecha, 4, 2) + Mid(tomafecha, 1, 2)



           


            'Dim conexiones6 As New CConexion
            'conexiones6.conexion()
            'Dim command6 As SqlCommand = New SqlCommand("SELECT CORMOV+1 FROM _CORMOV", conexiones6._conexion)
            'conexiones6.abrir()
            'Dim reader6 As SqlDataReader = command6.ExecuteReader()
            'If reader6.HasRows Then
            '    Do While reader6.Read()
            '        Tomacorrelativo = reader6(0).ToString
            '    Loop
            'Else
            'End If
            'reader6.Close()
            Dim conexiones6 As New CConexion
            conexiones6.conexion()
            Dim command6 As SqlCommand = New SqlCommand("_SIGUIENTE @Tipo='CORMOV' ", conexiones6._conexion)
            conexiones6.abrir()
            Dim reader6 As SqlDataReader = command6.ExecuteReader()
            If reader6.HasRows Then
                Do While reader6.Read()
                    Tomacorrelativo = reader6(0).ToString
                Loop
            Else
            End If
            reader6.Close()

            'Dim conexiones60 As New CConexion
            'conexiones60.conexion()
            '_adaptador.UpdateCommand = New SqlCommand("update   _CORMOV set CORMOV = CORMOV+1 ", conexiones60._conexion)
            'conexiones60.abrir()
            '_adaptador.UpdateCommand.Connection = conexiones60._conexion
            '_adaptador.UpdateCommand.ExecuteNonQuery()
            'conexiones60.cerrar()

            Dim cadena As String
            Dim tabla() As String
            Dim n As Integer
            Dim tomarut As String
            Dim tomadigito As String
            cadena = frmEvaluarCapital.Textrut.Text
            tabla = Split(cadena, "-")
            For n = 0 To UBound(tabla, 1)
                If n = 0 Then
                    tomarut = (tabla(n))
                Else
                    tomadigito = (tabla(n))
                End If
            Next
            Nombresocio = frmEvaluarCapital.Textnombre.Text
            nrosocio = frmEvaluarCapital.Textnrosocio.Text
            'telefonico , por correo , presencial 
            tiporequerimiento = frmEvaluarCapital.Texttiporequerimiento.Text
            codigobanco = frmEvaluarCapital.Textcodbanco.Text
            'datos  cuenta  bancaria del socio 
            formapago = frmEvaluarCapital.Textformapago.Text
            formapago = Trim(frmEvaluarCapital.cboformapago.SelectedItem.ToString())
            'MsgBox(formapago)
            If formapago = "TRANSFERENCIA" Then
                Tipocuentabanco = frmEvaluarCapital.Textcodtipocuenta.Text
                banco = frmEvaluarCapital.Textnombrebanco.Text
                nrocuentabanco = frmEvaluarCapital.Textnrocuentabanco.Text
                ' MsgBox(Tipocuentabanco)
                ' MsgBox(banco)
                ' MsgBox(nrocuentabanco)
                'Estado_Solicitud = "PREAPROBADO"
            Else
                Tipocuentabanco = ""
                banco = ""
                nrocuentabanco = ""
                codigobanco = ""

            End If

            Usuario = frmPerfil.CbmUsuario.SelectedItem()
            ' Sucursal = Trim(frmPerfil.TxtSede.Text())
            Dim conexiones2 As New CConexion
            conexiones2.conexion()
            Dim command2 As SqlCommand = New SqlCommand("SELECT top 1  UBICACION  FROM [_RIESGO_PERFIL] WHERE   USUARIO='" + Usuario.ToString.Trim + "'", conexiones2._conexion)
            conexiones2.abrir()
            Dim reader2 As SqlDataReader = command2.ExecuteReader()
            If reader2.HasRows Then
                Do While reader2.Read()
                    Sucursal2 = reader2(0).ToString
                Loop
            Else
            End If
            reader2.Close()


            'If Sucursal = "VALPARAÍSO" Then
            'CORRECION SUCURSAL  ------------------------------------
            'If Trim(frmRIESGO.TextSucural22.Text) = "1" Then
            'Sucursal2 = 1
            'ElseIf Trim(frmRIESGO.TextSucural22.Text) = "4" Then
            'Sucursal2 = 4
            'End If
            'CORRECION SUCURSAL  ------------------------------------
            'ElseIf Sucursal = "VIÑA DEL MAR" Then
            'Sucursal2 = 2
            'End If

            'CORRECION SUCURSAL  ------------------------------------
            'If Trim(frmRIESGO.TextSucural22.Text) = "1" Then  'Valpo blanco 
            '    Sucursal2 = 1
            'ElseIf Trim(frmRIESGO.TextSucural22.Text) = "4" Then ' Prat 
            '    Sucursal2 = 4
            'ElseIf Trim(frmRIESGO.TextSucural22.Text) = "2" Then  ' viña 
            '    Sucursal2 = 2
            'End If
            'CORRECION SUCURSAL  ------------------------------------
            'If Pic1A.Visible = True Then
            'cumplecapitalminimo = "SI"
            'Else
            cumplecapitalminimo = ""
            'End If
            'If Pic2A.Visible = True Then
            '    cumplemontosolicitado = "SI"
            'Else
            cumplemontosolicitado = ""
            'End If
            'If Pic3A.Visible = True Then
            'cumplenroretirosanuales = "SI"
            'Else
            cumplenroretirosanuales = ""
            'End If
            'If Pic4A.Visible = True Then
            'cumplenroretirosmensuales = "SI"
            'Else
            cumplenroretirosmensuales = ""
            'End If

            If Pic5A.Visible = True Then
                cumplesociosinmora = "SI"
            Else
                cumplesociosinmora = "NO"
            End If

            If Pic6A.Visible = True Then
                cumpleavalsinmora = "SI"
            Else
                cumpleavalsinmora = "NO"
            End If

            'If Pic7A.Visible = True Then
            cumplerestriccion = ""
            'Else
            'cumplerestriccion = "NO"
            'End If

            If Pic8A.Visible = True Then
                cumplecapitalglobal = "SI"
            Else
                cumplecapitalglobal = "NO"
            End If

            If Pic8A.Visible = True Then
                If formapago = "TRANSFERENCIA" Then
                    ' OJO CON ESTO  REVISAR 
                    Estado_Solicitud = "PREAPROBADO"
                    Estado_Solicitud2 = 1
                Else
                    Estado_Solicitud = "APROBADO"
                    Estado_Solicitud2 = 1
                End If

            ElseIf Pic8A.Visible = False Then
                If formapago = "TRANSFERENCIA" Then
                    'OJO CON ESTO  REVISAR 
                    Estado_Solicitud = "PREAPROBADO"
                    Estado_Solicitud2 = 0
                ElseIf formapago = "EFECTIVO" Or formapago = "CHEQUE" Then

                    Estado_Solicitud = "APROBADO"
                    Estado_Solicitud2 = 0
                End If
                Estado_Solicitud = "PENDIENTE"
            End If

            Dim FECHACOMPLETA2 As String = ""
            Dim FECHACOMPLETA3 As String = ""
            Dim AÑO As String = ""
            FECHACOMPLETA2 = DateTime.Now().ToShortDateString()  '"16/06/2009"
            'VOLVEEEER A DEJAR PARA QUE PEUDA  CAMBIAR  EN EL MIMSO MES  SOLMKANRTE 
            FECHACOMPLETA3 = Mid(FECHACOMPLETA2, 7, 10) + Mid(FECHACOMPLETA2, 4, 2) + Mid(FECHACOMPLETA2, 1, 2)
            AÑO = Mid(FECHACOMPLETA2, 7, 10)

            Dim xSql As String
            xSql = ""



            xSql = xSql + "    BEGIN TRAN "
            xSql = xSql + "    INSERT INTO _RIESGO_SOLICITUD_GIRO_CAPITAL"
            xSql = xSql + "  ([ID_SOLICITUD]"
            xSql = xSql + "  ,[FECHA_SOLICITUD]"
            xSql = xSql + "  ,[MONTO_SOLICITUD]"
            xSql = xSql + "  ,[ESTADO_SOLICITUD]"
            ',[RUT]
            ' ,[DVRUT]
            ',[NOMBRE_SOCIO]
            ' ,[NROSOCIO]
            ' ,[TIPO_CUENTA]
            ' ,[BANCO]
            ' ,[NRO_CUENTA] 
            xSql = xSql + "  ,[CORRELATIVO]"
            xSql = xSql + " ,[FORMA_PAGO]"
            xSql = xSql + "  ,[USUARIO]"
            ' ,[SUCURSAL]
            xSql = xSql + "  ,[REEVALUACION]"
            xSql = xSql + "  ,[EN_NOMINA]"
            ',[CODBANCO]
            xSql = xSql + "  ,[TIPO_SOLICITUD]"
            ' ,NOMBRES
            ' ,PATERNO
            ' ,MATERNO
            ' ,TOTALCAPITALSOCIAL
            ' ,CORRECCION_MONETARIA
            ' ,CUOTAS_PARTICIPACION
            ' ,TOTAL_NORETIRABLE
            ' ,MONTO_DISPONIBLE
            ' ,MONTO_MAXIMO_RETIRABLE
            xSql = xSql + "  ,[FILTRO_CAPITAL_MINIMO]"
            xSql = xSql + "  ,[FILTRO_MONTO_SOLICITADO]"
            xSql = xSql + "  ,[FILTRO_GIROS_ANUAL]"
            xSql = xSql + " ,[FILTRO_GIROS_MENSUAL]"
            xSql = xSql + " ,[FILTRO_SOCIO_SINMORA]"
            xSql = xSql + " ,[FILTRO_AVAL_SINMORA]"
            xSql = xSql + " ,[FILTRO_RESTRICCIONES]"
            xSql = xSql + " ,[FILTRO_CAPITAL_GLOBAL]"
            xSql = xSql + " ,[Aprobacion_SubGerencia]"
            xSql = xSql + "  ,[Estado_Solicitud2]"
            xSql = xSql + " ,[COMENTARIO_EVALUACION]"
            xSql = xSql + "  ,[SUCURSAL2]"
            ' ,[VALORUFDIAACTUAL]
            '  ,[CUOTAGASTOS]
            ' ,[MONTOABONAPRESTAMOS]
            xSql = xSql + "  ,[TIPOSOLICITUD2]"
            ' ,[SALDOVRUFCAPITAL]
            ',[MONTOPAGAOTROS])
            xSql = xSql + "            VALUES((SELECT  max([ID_SOLICITUD]) + 1  FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL])"
            xSql = xSql + "  , (CONVERT(VARCHAR(8), GETDATE(), 112) )"
            xSql = xSql + " ," + Trim(Montosolicitado) + ""
            xSql = xSql + "  ,'" + Trim(Estado_Solicitud) + "'"
            ' ,'" + Trim(tomarut.ToString) + "'
            ' ,'" + Trim(tomadigito.ToString) + "'
            ' ,'" + Nombresocio.ToString + "'
            xSql = xSql + "  ,'" + nrosocio.ToString + "'"
            ','" + Tipocuentabanco.ToString + "'
            ' ,'" + banco.ToString.ToString + "'
            xSql = xSql + "  ,'" + nrocuentabanco.ToString + "'"
            xSql = xSql + " ,'" + Tomacorrelativo.ToString + "'"
            xSql = xSql + "  ,'" + formapago.ToString + "'"
            xSql = xSql + " ,'" + Usuario.ToString + "'"
            ','" + Sucursal.ToString + "'
            xSql = xSql + " , 'NO' "
            xSql = xSql + "  , '0' "
            ','" + codigobanco.ToString + "'
            xSql = xSql + "  ,'" + tiporequerimiento.ToString + "'"
            ','" + Trim(frmEvaluarCapital.textnombres2.Text) + "'
            ','" + Trim(frmEvaluarCapital.textpaterno.Text) + "'
            ','" + Trim(frmEvaluarCapital.Textmaterno.Text) + "'
            ' ," + Trim(montototal) + "
            ' ," + Trim(correcionmonetaria) + "
            ' ," + Trim(cuotasparticipacion) + "
            ' ," + Trim(totalnoretirable) + "
            ' ," + Trim(montodisponible) + "
            ' ," + Trim(montomaximoretirabel) + "
            xSql = xSql + "  ,'" + Trim(cumplecapitalminimo.ToString) + "'"
            xSql = xSql + " ,'" + Trim(cumplemontosolicitado.ToString) + "'"
            xSql = xSql + "  ,'" + Trim(cumplenroretirosanuales.ToString) + "'"
            xSql = xSql + "  ,'" + Trim(cumplenroretirosmensuales.ToString) + "'"
            xSql = xSql + " ,'" + Trim(cumplesociosinmora.ToString) + "'"
            xSql = xSql + " ,'" + Trim(cumpleavalsinmora.ToString) + "'"
            xSql = xSql + "  ,'" + Trim(cumplerestriccion.ToString) + "'"
            xSql = xSql + " ,'NO'"
            xSql = xSql + "  ,'Por Analizar'"
            xSql = xSql + " ,'0'"
            xSql = xSql + " ,'" + txtComentarioGirocapital.Text + "' "
            xSql = xSql + " ,'" + Sucursal2.ToString + "'"
            '--,(select sum(movuf) from _Capitalsocial where nrosocio ='" + Trim(nrosocio) + "' and fecha >='" + Trim(AÑO) + "0101')
            '--," + Trim(valorcuotadegasto) + "
            ' --, " + Trim(valorcapitalmonto) + "
            xSql = xSql + " ,'" + Trim(tiposolicitud2) + "'"
            ' ," + Trim(diferenciaufcapital) + "
            ' ,'" + pagootros.ToString + "') COMMIT TRAN
            Dim conexiones60 As New CConexion
            conexiones60.conexion()
            _adaptador.InsertCommand = New SqlCommand(xSql, conexiones60._conexion)
            conexiones60.abrir()
            _adaptador.InsertCommand.Connection = conexiones60._conexion
            _adaptador.InsertCommand.ExecuteNonQuery()
            conexiones60.cerrar()



















            'Dim conexiones4 As New CConexion
            'conexiones4.conexion()
            '_adaptador.InsertCommand = New SqlCommand(" BEGIN TRAN INSERT INTO _RIESGO_SOLICITUD_GIRO_CAPITAL([ID_SOLICITUD],[FECHA_SOLICITUD],[MONTO_SOLICITUD],[ESTADO_SOLICITUD],[RUT],[DVRUT],[NOMBRE_SOCIO],[NROSOCIO],[TIPO_CUENTA],[BANCO],[NRO_CUENTA] ,[CORRELATIVO],[FORMA_PAGO],[USUARIO],[SUCURSAL],[REEVALUACION],[EN_NOMINA],[CODBANCO],[TIPO_SOLICITUD],NOMBRES,PATERNO,MATERNO,TOTALCAPITALSOCIAL,CORRECCION_MONETARIA,CUOTAS_PARTICIPACION,TOTAL_NORETIRABLE,MONTO_DISPONIBLE,MONTO_MAXIMO_RETIRABLE,[FILTRO_CAPITAL_MINIMO],[FILTRO_MONTO_SOLICITADO],[FILTRO_GIROS_ANUAL],[FILTRO_GIROS_MENSUAL],[FILTRO_SOCIO_SINMORA],[FILTRO_AVAL_SINMORA],[FILTRO_RESTRICCIONES],[FILTRO_CAPITAL_GLOBAL],[Aprobacion_SubGerencia],[Estado_Solicitud2],[COMENTARIO_EVALUACION],[SUCURSAL2],[VALORUFDIAACTUAL],[CUOTAGASTOS],[MONTOABONAPRESTAMOS],[TIPOSOLICITUD2],[SALDOVRUFCAPITAL],[MONTOPAGAOTROS])VALUES((Select  max([ID_SOLICITUD]) + 1  FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL]), (CONVERT(VARCHAR(8), GETDATE(), 112) )," + Trim(Montosolicitado) + ",'" + Trim(Estado_Solicitud) + "','" + Trim(tomarut.ToString) + "','" + Trim(tomadigito.ToString) + "','" + Nombresocio.ToString + "','" + nrosocio.ToString + "','" + Tipocuentabanco.ToString + "','" + banco.ToString.ToString + "','" + nrocuentabanco.ToString + "','" + Tomacorrelativo.ToString + "','" + formapago.ToString + "','" + Usuario.ToString + "','" + Sucursal.ToString + "', 'NO' , '0' ,'" + codigobanco.ToString + "','" + tiporequerimiento.ToString + "','" + Trim(frmEvaluarCapital.textnombres2.Text) + "','" + Trim(frmEvaluarCapital.textpaterno.Text) + "','" + Trim(frmEvaluarCapital.Textmaterno.Text) + "'," + Trim(montototal) + "," + Trim(correcionmonetaria) + "," + Trim(cuotasparticipacion) + "," + Trim(totalnoretirable) + "," + Trim(montodisponible) + "," + Trim(montomaximoretirabel) + ",'" + Trim(cumplecapitalminimo.ToString) + "','" + Trim(cumplemontosolicitado.ToString) + "','" + Trim(cumplenroretirosanuales.ToString) + "','" + Trim(cumplenroretirosmensuales.ToString) + "','" + Trim(cumplesociosinmora.ToString) + "','" + Trim(cumpleavalsinmora.ToString) + "','" + Trim(cumplerestriccion.ToString) + "','NO','Por Analizar','0','" + txtComentarioGirocapital.Text + "' ,'" + Sucursal2.ToString + "',(select sum(movuf) from _Capitalsocial where nrosocio ='" + Trim(nrosocio) + "' and fecha >='" + Trim(AÑO) + "0101')," + Trim(valorcuotadegasto) + ", " + Trim(valorcapitalmonto) + ",'" + Trim(tiposolicitud2) + "'," + Trim(diferenciaufcapital) + ",'" + pagootros.ToString + "') COMMIT TRAN ", conexiones4._conexion)
            'conexiones4.abrir()
            '_adaptador.InsertCommand.Connection = conexiones4._conexion
            '_adaptador.InsertCommand.ExecuteNonQuery()
            MsgBox("SOLICITUD DE GIRO DE CAPITAL INGRESADA")
            frmEvaluarCapital.Close()
            Me.Close()
        ElseIf txtComentarioGirocapital.Text.Length > 250 Then
            MsgBox("El comentario sobrepasa los 250 caracteres")
        End If
    End Sub



    Private Sub BtnPendiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPendiente.Click
        'AUTORIZAR_RENUNCIA_FALLECMIENTO()

        If Pic8A.Visible = False Then
            PENDIENTE()
            'Else
            'If Trim(frmEvaluarCapital.Texttiposolicitud2.Text) = "R" Then
            'MsgBox("SELECIONO RENUNCIA ")
            'ElseIf Trim(frmEvaluarCapital.Texttiposolicitud2.Text) <> "R" Then
        End If
    End Sub

    Private Sub Pic8A_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pic8A.Click
    End Sub

    'Sub rellancorrelativounico()
    '    _TABLA27.Rows.Clear()
    '    _TABLA27.Columns.Clear()
    '    'LLENA LA GRILLA "GRIDESTADOSGIROS" Y MUESTRA TODAS LAS SOLICITUDES DE GIRO DE CAPITAL 
    '    Gridestadogiros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
    '    Dim xSql As String
    '    xSql = ""
    '    xSql = xSql + "SELECT  [ID_SOLICITUD],[CORRELATIVOUNICO] "
    '    xSql = xSql + "FROM [LROSAS].[dbo].[_RIESGO_SOLICITUD_GIRO_CAPITAL] order by ID_SOLICITUD  desc "
    '    'xSql = xSql + ", [CORREOEJECUTIVA] "
    '    Dim conexiones4 As New CConexion
    '    conexiones4.conexion()
    '    _adaptador.SelectCommand = New SqlCommand(xSql, conexiones4._conexion)
    '    _adaptador.Fill(_TABLA27)
    '    Gridestadogiros.DataSource = _TABLA27
    '    conexiones4.cerrar()
    'End Sub


End Class