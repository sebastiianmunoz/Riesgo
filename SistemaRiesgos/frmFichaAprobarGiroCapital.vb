
Imports System.Data
Imports System.Data.SqlClient
Public Class frmFichaAprobarGiroCapital
    Dim nrosocio As String = frmCreditosPorAprobar.txtNrosocio.Text
    Dim id As String = frmCreditosPorAprobar.txtid.Text
    Dim correo As String = ""
    Dim tomaestado As String = ""
    Dim Aprobacionsubgerencia As String = ""
    Dim Verificaraprovacion As String = ""
    Public _TABLA29 As DataTable = New DataTable
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter


    Private Sub CboAprobar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAprobar.SelectedIndexChanged
        ' tomaestado = CboAprobar.SelectedItem
        If CboAprobar.SelectedItem = "APROBADO" Then
            Aprobacionsubgerencia = "SI"
        ElseIf CboAprobar.SelectedItem = "RECHAZADO" Then
            Aprobacionsubgerencia = "NO"
        End If
    End Sub

    Sub CargadatosSocio()

        'Dim textsaldofinaltotal As Long = 0
        Dim conexiones3 As New CConexion
        conexiones3.conexion()
        Dim command3 As SqlCommand = New SqlCommand("SELECT CONVERT(varchar(8),RUT )+'-'+CONVERT(varchar(1),DVRUT ) AS RUT  , Nombres +' '+ Paterno+' '+ Materno AS NOMBRE_COMPLETO , NROSOCIO,rtrim(Direccion) +' '+rtrim(SECTOR)+' '+rtrim(Villa)+' '+rtrim(Ciudad) as direccion,TELEFONO+'/'+CELULAR AS TELEFONO, EMAIL+''+LABOEMAIL  AS CORREO  ,(select  case  when Descripcion IS NULL THEN 'Sin Institucion' ELSE Descripcion  END ) as Institucion   ,Nombres,Paterno,MATERNO  FROM _SOCIOS  as socio  Left join _INSTITUCIONES as inst on socio.CODINST = inst.CODINS   WHERE  NROSOCIO = " + Trim(nrosocio) + " ", conexiones3._conexion)
        conexiones3.abrir()
        Dim reader3 As SqlDataReader = command3.ExecuteReader()
        If reader3.HasRows Then
            Do While reader3.Read()
                Textrut.Text = reader3(0).ToString
                Textnombre.Text = reader3(1).ToString
                Textnrosocio.Text = reader3(2).ToString
                Textdireccion.Text = reader3(3).ToString
                Texttelefono.Text = reader3(4).ToString
                Textcorreo.Text = reader3(5).ToString()
                'correo = reader3(5).ToString()
                ' MsgBox(correo)
                If Trim(Textcorreo.Text) = "" Then
                    Textcorreo.Text = "Sin Correo Registrado"
                End If
            Loop
        Else
        End If
        reader3.Close()

        'MONTO TOTAL
        Dim conexiones5 As New CConexion
        conexiones5.conexion()
        Dim command5 As SqlCommand = New SqlCommand("SELECT  [ID_SOLICITUD],substring(fecha_solicitud,7,2)+'/'+substring(fecha_solicitud,5,2)+'/'+substring(fecha_solicitud,1,4) as [FECHA_SOLICITUD],dbo.puntos([MONTO_SOLICITUD]),[ESTADO_SOLICITUD],[TIPO_CUENTA],[BANCO],[NRO_CUENTA],[correlativo],[FORMA_PAGO] ,[USUARIO], ( select case when  [SUCURSAL]='' and sucursal2=1   then  'CASA MATRIZ'  when [SUCURSAL]='' and sucursal2=2 then 'AGENCIA VERGARA' when [SUCURSAL]='' and sucursal2=4    then  'AGENCIA VALPARAISO' else [SUCURSAL]  end  from [_RIESGO_SOLICITUD_GIRO_CAPITAL]  where id_solicitud ='" + Trim(id) + "'  ) as [SUCURSAL]   ,[REEVALUACION],[EN_NOMINA],[TIPO_SOLICITUD],[TOTALCAPITALSOCIAL] ,[CORRECCION_MONETARIA],[CUOTAS_PARTICIPACION],[TOTAL_NORETIRABLE],[MONTO_DISPONIBLE] ,[MONTO_MAXIMO_RETIRABLE] ,[Aprobacion_SubGerencia],[TIPOSOLICITUD2],(select dbo.puntos((MONTO_SOLICITUD+[OTROSHABERES]) -(MONTOGASTOABOGADO+CUOTAGASTOS+MONTOABONAPRESTAMOS+[MONTOPAGAOTROS] )) from [_RIESGO_SOLICITUD_GIRO_CAPITAL] where ID_SOLICITUD='" + Trim(id) + "')AS SALDOFINAL,[CUOTAGASTOS],[MONTOABONAPRESTAMOS],[MONTOPAGAOTROS],[OTROSHABERES],[MONTOGASTOABOGADO] ,[COMENTARIO_EVALUACION]FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL] where id_solicitud ='" + Trim(id) + "' ", conexiones5._conexion)
        conexiones5.abrir()
        Dim reader5 As SqlDataReader = command5.ExecuteReader()
        If reader5.HasRows Then
            Do While reader5.Read()
                Texttiporequerimiento.Text = reader5(13).ToString
                textformapago.Text = reader5(8).ToString
                txtSucursal.Text = reader5(10).ToString
                txtEjecutivo.Text = reader5(9).ToString
                txtFecha.Text = reader5(1).ToString
                txtCodigoId.Text = reader5(0).ToString
                TextRF.Text = reader5(21).ToString
                ' MsgBox(TextRF.Text)
                'MONTOS'
                Texttotales.Text = frmEvaluarCapital.PuntoX(reader5(14).ToString)
                Textcorrecionmonetaria.Text = frmEvaluarCapital.PuntoX(reader5(15).ToString)
                Textcuotasdeparticipacion.Text = frmEvaluarCapital.PuntoX(reader5(16).ToString)
                Texttotalnoretirable.Text = frmEvaluarCapital.PuntoX(reader5(17).ToString)
                Textmontodisponible.Text = frmEvaluarCapital.PuntoX(reader5(18).ToString)
                Textmontomaximoretirable.Text = frmEvaluarCapital.PuntoX(reader5(19).ToString)
                Textmontorequerido.Text = frmEvaluarCapital.PuntoX(reader5(2).ToString)

                textsaldofinal.Text = frmEvaluarCapital.PuntoX(reader5(22).ToString)
                Textsaldofinal2.Text = textsaldofinal.Text
                Textnombreconp.Text = (reader5(28).ToString)

                If Int(Textsaldofinal2.Text) < 0 Then
                    Textsaldofinal2.Text = 0
                    Label38.Visible = True
                Else
                    Label38.Visible = False
                End If

                ''
                Textgastoabogado.Text = frmEvaluarCapital.PuntoX(reader5(27).ToString)
                Textcuotadegastos.Text = frmEvaluarCapital.PuntoX(reader5(23).ToString())
                TextCapitalabonaCreditos.Text = frmEvaluarCapital.PuntoX(reader5(24).ToString())
                TextrevalorizacionUF.Text = frmEvaluarCapital.PuntoX(reader5(2).ToString)
                Textotrospagos.Text = frmEvaluarCapital.PuntoX(reader5(25).ToString)
                Textotroshaberes.Text = frmEvaluarCapital.PuntoX(reader5(26).ToString)
                'por verirficar o no o si 
                Verificaraprovacion = reader5(20).ToString

            Loop
        Else
        End If
        reader5.Close()

        _TABLA29.Rows.Clear()
        _TABLA29.Columns.Clear()
        Dim conexiones4 As New CConexion
        conexiones4.conexion()
        _adaptador.SelectCommand = New SqlCommand("SELECT DESCRIPCION,capi.[BANCO],[NRO_CUENTA]  FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL]as capi inner join [_TESORERIA_TIPO_CUENTA_BANCO] as cuenta on capi.TIPO_CUENTA = cuenta.CODIGO where id_solicitud = '" + Trim(id) + "'", conexiones4._conexion)
        conexiones4.abrir()
        _adaptador.Fill(_TABLA29)
        Gridcuentas.DataSource = _TABLA29
        conexiones4.cerrar()
       

        CboAprobar.Items.Add("APROBADO")
        CboAprobar.Items.Add("RECHAZADO")

        'If TextRF.Text = "F" Then
        '    LabelRenunciaOfallecmiento.Visible = True
        '    LabelRenunciaOfallecmiento.Text = "FALLECIMIENTO"
        '    Panel1.Visible = False
        '    Panel2.Visible = False
        '    Panel3.Visible = False
        '    '  Panel5.Visible = False
        '    '  Panel6.Visible = False
        '    Panel7.Visible = False
        '    'Panel8.Visible = False
        '    Label7.Text = "Capital Reajustado en UF :"
        '    Label12.Text = "condición de pago"
        '    'monot revalorado
        '    LabelrevalorizacionUF.Visible = True
        '    TextrevalorizacionUF.Visible = True
        '    'Cuota gastos 
        '    Label32.Visible = True
        '    Textcuotadegastos.Visible = True
        '    'Pago creditos 
        '    Label33.Visible = True
        '    TextCapitalabonaCreditos.Visible = True
        '    'Otros pagos 
        '    Label37.Visible = True
        '    Textotrospagos.Visible = True
        '    'gatos de abogado 
        '    Label34.Visible = True
        '    Textgastoabogado.Visible = True
        '    'Liquido a pago 1
        '    Label28.Visible = True
        '    textsaldofinal.Visible = True
        '    'Liquido a pago 2
        '    Textsaldofinal2.Visible = True
        '    Label29.Visible = True
        '    textsaldofinal.Text = textsaldofinal.Text
        '    '----------------------------------------------
        '    'Monto  Disponible 
        '    Label16.Visible = False
        '    Textmontodisponible.Visible = False
        '    'Monto  Maximo retirable 
        '    Label17.Visible = False
        '    Textmontomaximoretirable.Visible = False
        '    'TOTALES 
        '    Label18.Visible = False
        '    Texttotales.Visible = False
        '    'REVALORIAZCION CAPITAL 
        '    Label19.Visible = False
        '    Label20.Visible = False
        '    Textcorrecionmonetaria.Visible = False


        '    'MINIMO CUOTAS PARTICIPACION 
        '    Label21.Visible = False
        '    Label22.Visible = False
        '    Textcuotasdeparticipacion.Visible = False

        '    'TOTAL NO RETIRABLE 
        '    Label23.Visible = False
        '    Texttotalnoretirable.Visible = False

        '    GroupBox2.Visible = False


        '    '----------------------------------------------

        '    Label31.Visible = True
        '    Textotroshaberes.Visible = True
        'ElseIf TextRF.Text = "R" Then
        '    LabelRenunciaOfallecmiento.Visible = True
        '    LabelRenunciaOfallecmiento.Text = "RENUNCIA"
        '    Panel1.Visible = False
        '    Panel2.Visible = False
        '    Panel3.Visible = False
        '    ' Panel5.Visible = False
        '    '  Panel6.Visible = False
        '    Panel7.Visible = False
        '    ' Panel8.Visible = False
        '    Label7.Text = "Capital Reajustado en UF :"



        '    'monot revalorado
        '    LabelrevalorizacionUF.Visible = True
        '    TextrevalorizacionUF.Visible = True

        '    'Cuota gastos 
        '    Label32.Visible = True
        '    Textcuotadegastos.Visible = True

        '    'Pago creditos 
        '    Label33.Visible = True
        '    TextCapitalabonaCreditos.Visible = True
        '    'Otros pagos 
        '    Label37.Visible = True
        '    Textotrospagos.Visible = True

        '    'gatos de abogado 
        '    Label34.Visible = True
        '    Textgastoabogado.Visible = True

        '    'Liquido a pago 1
        '    Label28.Visible = True
        '    textsaldofinal.Visible = True

        '    'Liquido a pago 2
        '    Textsaldofinal2.Visible = True
        '    Label29.Visible = True

        '    Textsaldofinal2.Text = textsaldofinal.Text

        '    '----------------------------------------------
        '    'Monto  Disponible 
        '    Label16.Visible = False
        '    Textmontodisponible.Visible = False

        '    'Monto  Maximo retirable 
        '    Label17.Visible = False
        '    Textmontomaximoretirable.Visible = False


        '    'TOTALES 
        '    Label18.Visible = False
        '    Texttotales.Visible = False

        '    'REVALORIAZCION CAPITAL 
        '    Label19.Visible = False
        '    Label20.Visible = False
        '    Textcorrecionmonetaria.Visible = False


        '    'MINIMO CUOTAS PARTICIPACION 
        '    Label21.Visible = False
        '    Label22.Visible = False
        '    Textcuotasdeparticipacion.Visible = False

        '    'TOTAL NO RETIRABLE 
        '    Label23.Visible = False
        '    Texttotalnoretirable.Visible = False
        '    GroupBox2.Visible = False
        '    '----------------------------------------------
        '    Label31.Visible = True
        '    Textotroshaberes.Visible = True
        'ElseIf TextRF.Text = "T" Then
        '    LabelRenunciaOfallecmiento.Visible = True
        '    LabelRenunciaOfallecmiento.Text = "TRASPASO"
        '    Panel1.Visible = False
        '    Panel2.Visible = False
        '    Panel3.Visible = False
        '    'monot revalorado
        '    LabelrevalorizacionUF.Visible = False
        '    TextrevalorizacionUF.Visible = False
        '    'Cuota gastos 
        '    Label32.Visible = True
        '    Textcuotadegastos.Visible = True
        '    'Pago creditos 
        '    Label33.Visible = True
        '    TextCapitalabonaCreditos.Visible = True
        '    'Otros pagos 
        '    Label37.Visible = True
        '    Textotrospagos.Visible = True
        '    'gatos de abogado 
        '    Label34.Visible = True
        '    Textgastoabogado.Visible = True
        '    'Liquido a pago 1
        '    Label28.Visible = True
        '    textsaldofinal.Visible = True
        '    'Liquido a pago 2
        '    'Textsaldofinal2.Visible = True
        '    'Label29.Visible = True
        '    'Textsaldofinal2.Text = textsaldofinal.Text
        '    '----------------------------------------------
        '    'Monto  Disponible 
        '    Label16.Visible = False
        '    Textmontodisponible.Visible = False
        '    'Monto  Maximo retirable 
        '    Label17.Visible = False
        '    Textmontomaximoretirable.Visible = False
        '    'TOTALES 
        '    Label18.Visible = False
        '    Texttotales.Visible = False
        '    'REVALORIAZCION CAPITAL 
        '    Label19.Visible = False
        '    Label20.Visible = False
        '    Textcorrecionmonetaria.Visible = False
        '    'MINIMO CUOTAS PARTICIPACION 
        '    Label21.Visible = False
        '    Label22.Visible = False
        '    Textcuotasdeparticipacion.Visible = False
        '    'TOTAL NO RETIRABLE 
        '    Label23.Visible = False
        '    Texttotalnoretirable.Visible = False
        '    GroupBox2.Visible = False
        '    '----------------------------------------------
        '    'forma de pago 
        '    Label12.Visible = False
        '    textformapago.Visible = False
        '    Label31.Visible = True
        '    Textotroshaberes.Visible = True
        'End If
        If TextRF.Text = "F" Then
            LabelRenunciaOfallecmiento.Visible = True
            LabelRenunciaOfallecmiento.Text = "FALLECIMIENTO"
            Panel1.Visible = False
            Panel2.Visible = False
            Panel3.Visible = False
            '  Panel5.Visible = False
            '  Panel6.Visible = False
            Panel7.Visible = False
            'Panel8.Visible = False
            Label7.Text = "Capital Reajustado en UF :"
            Label12.Text = "condición de pago"

            'monot revalorado
            LabelrevalorizacionUF.Visible = True
            TextrevalorizacionUF.Visible = True

            'Cuota gastos 
            Label32.Visible = True
            Textcuotadegastos.Visible = True

            'Pago creditos 
            Label33.Visible = True
            TextCapitalabonaCreditos.Visible = True
            'Otros pagos 
            Label37.Visible = True
            Textotrospagos.Visible = True


            'gatos de abogado 
            Label34.Visible = True
            Textgastoabogado.Visible = True

            'Liquido a pago 1
            Label28.Visible = True
            textsaldofinal.Visible = True

            'Liquido a pago 2
            Textsaldofinal2.Visible = True
            Label29.Visible = True
            textsaldofinal.Text = textsaldofinal.Text

            '----------------------------------------------
            'Monto  Disponible 
            Label16.Visible = False
            Textmontodisponible.Visible = False

            'Monto  Maximo retirable 
            Label17.Visible = False
            Textmontomaximoretirable.Visible = False

            'TOTALES 
            Label18.Visible = False
            Texttotales.Visible = False

            'REVALORIAZCION CAPITAL 
            Label19.Visible = False
            Label20.Visible = False
            Textcorrecionmonetaria.Visible = False


            'MINIMO CUOTAS PARTICIPACION 
            Label21.Visible = False
            Label22.Visible = False
            Textcuotasdeparticipacion.Visible = False

            'TOTAL NO RETIRABLE 
            Label23.Visible = False
            Texttotalnoretirable.Visible = False

            GroupBox2.Visible = False


            '----------------------------------------------

            Label31.Visible = True
            Textotroshaberes.Visible = True



            'group descuentos 
            Groupdescuentos.Visible = True

            conceptolabel.Visible = True
            Textnombreconp.Visible = True

            concepto(TextBoxcorrelativoRFT.Text)


        ElseIf TextRF.Text = "R" Then
            LabelRenunciaOfallecmiento.Visible = True
            LabelRenunciaOfallecmiento.Text = "RENUNCIA"
            Panel1.Visible = False
            Panel2.Visible = False
            Panel3.Visible = False
            ' Panel5.Visible = False
            '  Panel6.Visible = False
            Panel7.Visible = False
            ' Panel8.Visible = False
            Label7.Text = "Capital Reajustado en UF :"



            'monot revalorado
            LabelrevalorizacionUF.Visible = True
            TextrevalorizacionUF.Visible = True

            'Cuota gastos 
            Label32.Visible = True
            Textcuotadegastos.Visible = True

            'Pago creditos 
            Label33.Visible = True
            TextCapitalabonaCreditos.Visible = True
            'Otros pagos 
            Label37.Visible = True
            Textotrospagos.Visible = True

            'gatos de abogado 
            Label34.Visible = True
            Textgastoabogado.Visible = True

            'Liquido a pago 1
            Label28.Visible = True
            textsaldofinal.Visible = True

            'Liquido a pago 2
            Textsaldofinal2.Visible = True
            Label29.Visible = True

            Textsaldofinal2.Text = textsaldofinal.Text

            '----------------------------------------------
            'Monto  Disponible 
            Label16.Visible = False
            Textmontodisponible.Visible = False

            'Monto  Maximo retirable 
            Label17.Visible = False
            Textmontomaximoretirable.Visible = False


            'TOTALES 
            Label18.Visible = False
            Texttotales.Visible = False

            'REVALORIAZCION CAPITAL 
            Label19.Visible = False
            Label20.Visible = False
            Textcorrecionmonetaria.Visible = False


            'MINIMO CUOTAS PARTICIPACION 
            Label21.Visible = False
            Label22.Visible = False
            Textcuotasdeparticipacion.Visible = False

            'TOTAL NO RETIRABLE 
            Label23.Visible = False
            Texttotalnoretirable.Visible = False


            GroupBox2.Visible = False
            '----------------------------------------------


            Label31.Visible = True
            Textotroshaberes.Visible = True

            'group descuentos 
            Groupdescuentos.Visible = True
            conceptolabel.Visible = True
            Textnombreconp.Visible = True
            concepto(TextBoxcorrelativoRFT.Text)

        ElseIf TextRF.Text = "T" Then
            LabelRenunciaOfallecmiento.Visible = True
            LabelRenunciaOfallecmiento.Text = "TRASPASO"
            Panel1.Visible = False
            Panel2.Visible = False
            Panel3.Visible = False

            'monot revalorado
            LabelrevalorizacionUF.Visible = False
            TextrevalorizacionUF.Visible = False

            'Cuota gastos 
            Label32.Visible = True
            Textcuotadegastos.Visible = True

            'Pago creditos 
            Label33.Visible = True
            TextCapitalabonaCreditos.Visible = True
            'Otros pagos 
            Label37.Visible = True
            Textotrospagos.Visible = True

            'gatos de abogado 
            Label34.Visible = True
            Textgastoabogado.Visible = True

            'Liquido a pago 1
            Label28.Visible = True
            textsaldofinal.Visible = True

            'Liquido a pago 2
            'Textsaldofinal2.Visible = True
            'Label29.Visible = True
            'Textsaldofinal2.Text = textsaldofinal.Text

            '----------------------------------------------
            'Monto  Disponible 
            Label16.Visible = False
            Textmontodisponible.Visible = False

            'Textmontodisponible.Text = (Textmontorequerido.Text)

            'Label16.Visible = True
            'Textmontodisponible.Visible = True

            'Monto  Maximo retirable 
            Label17.Visible = False
            Textmontomaximoretirable.Visible = False

            'TOTALES 
            Label18.Visible = False
            Texttotales.Visible = False

            'REVALORIAZCION CAPITAL 
            Label19.Visible = False
            Label20.Visible = False
            Textcorrecionmonetaria.Visible = False

            'MINIMO CUOTAS PARTICIPACION 
            Label21.Visible = False
            Label22.Visible = False
            Textcuotasdeparticipacion.Visible = False

            'TOTAL NO RETIRABLE 
            Label23.Visible = False
            Texttotalnoretirable.Visible = False

            GroupBox2.Visible = False
            '----------------------------------------------
            'forma de pago 
            Label12.Visible = False
            textformapago.Visible = False

            Label31.Visible = True
            Textotroshaberes.Visible = True

            'group descuentos 
            Groupdescuentos.Visible = True
            conceptolabel.Visible = True
            Textnombreconp.Visible = True
            concepto(TextBoxcorrelativoRFT.Text)

            'monot revalorado
            LabelrevalorizacionUF.Text = "Total Capital Social"
            LabelrevalorizacionUF.Visible = True
            TextrevalorizacionUF.Visible = True

        ElseIf TextRF.Text = "C" Then
            'GroupBox2.Visible = True
            LabelRenunciaOfallecmiento.Visible = True
            LabelRenunciaOfallecmiento.Text = "CASTIGO"
            Panel1.Visible = False
            Panel2.Visible = False
            Panel3.Visible = False

            'monot revalorado
            LabelrevalorizacionUF.Visible = False
            TextrevalorizacionUF.Visible = False

            'Cuota gastos 
            Label32.Visible = True
            Textcuotadegastos.Visible = True

            'Pago creditos 
            Label33.Visible = True
            TextCapitalabonaCreditos.Visible = True
            'Otros pagos 
            Label37.Visible = True
            Textotrospagos.Visible = True

            'gatos de abogado 
            Label34.Visible = True
            Textgastoabogado.Visible = True

            'Liquido a pago 1
            Label28.Visible = True
            textsaldofinal.Visible = True

            'Liquido a pago 2
            'Textsaldofinal2.Visible = True
            'Label29.Visible = True
            'Textsaldofinal2.Text = textsaldofinal.Text

            '----------------------------------------------
            'Monto  Disponible 
            Label16.Visible = False
            Textmontodisponible.Visible = False

            'Textmontodisponible.Text = (Textmontorequerido.Text)

            'Label16.Visible = True
            'Textmontodisponible.Visible = True

            'Monto  Maximo retirable 
            Label17.Visible = False
            Textmontomaximoretirable.Visible = False

            'TOTALES 
            Label18.Visible = False
            Texttotales.Visible = False

            'REVALORIAZCION CAPITAL 
            Label19.Visible = False
            Label20.Visible = False
            Textcorrecionmonetaria.Visible = False

            'MINIMO CUOTAS PARTICIPACION 
            Label21.Visible = False
            Label22.Visible = False
            Textcuotasdeparticipacion.Visible = False

            'TOTAL NO RETIRABLE 
            Label23.Visible = False
            Texttotalnoretirable.Visible = False

            GroupBox2.Visible = False
            '----------------------------------------------
            'forma de pago 
            Label12.Visible = False
            textformapago.Visible = False

            Label31.Visible = True
            Textotroshaberes.Visible = True

            'group descuentos 
            Groupdescuentos.Visible = True
            conceptolabel.Visible = True
            Textnombreconp.Visible = True
            concepto(TextBoxcorrelativoRFT.Text)

            'monot revalorado
            LabelrevalorizacionUF.Text = "Total Capital Social"
            LabelrevalorizacionUF.Visible = True
            TextrevalorizacionUF.Visible = True
        Else
            LabelRenunciaOfallecmiento.Visible = True
            LabelRenunciaOfallecmiento.Text = "GIRO CAPITAL"
        End If


    End Sub


    Private Sub frmFichaAprobarGiroCapital_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LabelRenunciaOfallecmiento.Visible = False

        'monot revalorado
        LabelrevalorizacionUF.Visible = False
        TextrevalorizacionUF.Visible = False

        'Cuota gastos 
        Label32.Visible = False
        Textcuotadegastos.Visible = False

        'Pago creditos 
        Label33.Visible = False
        TextCapitalabonaCreditos.Visible = False
        'Otros pagos 
        Label37.Visible = False
        Textotrospagos.Visible = False

        'Liquido a pago 1
        Label28.Visible = False
        textsaldofinal.Visible = False


        'Liquido a pago 2
        Textsaldofinal2.Visible = False
        Label29.Visible = False

        Label31.Visible = False
        Textotroshaberes.Visible = False

        'gatos de abogado 
        Label34.Visible = False
        Textgastoabogado.Visible = False

        'group descuentos 
        Groupdescuentos.Visible = False
        conceptolabel.Visible = False
        Textnombreconp.Visible = False





        CargadatosSocio()
        Evaluacion()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim USUARIO As String
        Dim Contrasena As String = ""
        Dim Departamento As String = ""


        USUARIO = frmPerfil.CbmUsuario.SelectedItem


        If CboAprobar.SelectedItem = "" Then

            MsgBox("Debe selecionar una opción de Aprobación")

        Else

            If txtContrasena.Text = "" Then

                MsgBox("Debe indicar contraseña de seguridad ")


            Else
                If txtComentariosubgerente.Text.Length >= 250 Then

                    MsgBox("El comentario sobrepasa los 250 caracteres")

                Else
                    Dim conexiones2 As New CConexion
                    conexiones2.conexion()
                    Dim command2 As SqlCommand = New SqlCommand("SELECT dbo.FU_DESENCRIPTA(ENSUPERCONTRASENA),DEPARTAMENTO FROM _RIESGO_PERFIL WHERE USUARIO='" + USUARIO.ToString.Trim + "'", conexiones2._conexion)
                    conexiones2.abrir()

                    Dim reader2 As SqlDataReader = command2.ExecuteReader()
                    If reader2.HasRows Then
                        Do While reader2.Read()
                            Contrasena = reader2(0).ToString
                            Departamento = reader2(1).ToString
                        Loop
                    Else
                    End If
                    reader2.Close()


                    If Contrasena.ToString.Trim = txtContrasena.Text.Trim Then



                        If Trim(Verificaraprovacion) = "Por Analizar" Or Verificaraprovacion = "" Then

                            If textformapago.Text = "TRANSFERENCIA" Then

                                If Aprobacionsubgerencia = "SI" Then
                                    tomaestado = "PREAPROBADO"

                                ElseIf Aprobacionsubgerencia = "NO" Then
                                    tomaestado = "RECHAZADA"

                                End If


                            ElseIf textformapago.Text <> "TRANSFERENCIA" Then

                                If Aprobacionsubgerencia = "SI" Then
                                    tomaestado = "APROBADO"

                                ElseIf Aprobacionsubgerencia = "NO" Then
                                    tomaestado = "RECHAZADA"

                                End If
                            End If

                            'MsgBox(tomaestado)
                            'MsgBox(id)
                            Dim Plantillas As New CCEstadosGeneral
                            id = txtCodigoId.Text.ToString
                            'MsgBox(id)
                            Dim conexiones60 As New CConexion
                            conexiones60.conexion()
                            _adaptador.UpdateCommand = New SqlCommand("UPDATE  [_RIESGO_SOLICITUD_GIRO_CAPITAL] set [ESTADO_SOLICITUD]= '" + Trim(tomaestado.ToString) + "',[Aprobacion_SubGerencia]='" + Trim(Aprobacionsubgerencia.ToString) + "',[COMENTARIO_SUBGERENTE] = '" + Trim(txtComentariosubgerente.Text) + "', Aprobacion_Gerencia ='" + USUARIO.ToString.Trim + "',[FECHA_AUTORIZADO]= CONVERT(CHAR(19), CURRENT_TIMESTAMP, 20) WHERE id_solicitud ='" + Trim(id) + "'", conexiones60._conexion)
                            conexiones60.abrir()
                            _adaptador.UpdateCommand.Connection = conexiones60._conexion
                            _adaptador.UpdateCommand.ExecuteNonQuery()
                            conexiones60.cerrar()
                            'frmCreditosPorAprobar.vercreditos()

                            If Trim(tomaestado.ToString) = "RECHAZADA" Then
                                conexiones60.conexion()
                                _adaptador.UpdateCommand = New SqlCommand("UPDATE [_INGRESOS] SET ESTADOCONT = 'A',NROCOMP=0  WHERE CORRELATIVO IN (SELECT RI.CORRELATIVO FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL] AS RI WHERE RI.id_solicitud ='" + Trim(id) + "' ) ", conexiones60._conexion)
                                conexiones60.abrir()
                                _adaptador.UpdateCommand.Connection = conexiones60._conexion
                                _adaptador.UpdateCommand.ExecuteNonQuery()
                                conexiones60.cerrar()
                                'MsgBox("aqui")
                            End If

                            MsgBox("RECONSIDERACIÓN REALIZADA CON EXITO")

                            Dim plantillas2 As Metodos = New Metodos
                            Dim tabla As New DataTable

                            plantillas2._tabla.Rows.Clear()
                            plantillas2._tabla.Columns.Clear()

                            If plantillas2.Consultar_Creditos_AprobarXSubGerencia Then
                                tabla = plantillas2.tabla
                                frmCreditosPorAprobar.DGreditosAprobar.DataSource = tabla
                            End If
                            Me.Close()

                        Else
                            MsgBox("ESTE GIRO DE CAPITAL YA FUE ANALIZADO")
                            Me.Close()
                            frmCreditosPorAprobar.CheckBox1.Checked = False
                        End If
                    Else

                        MsgBox("CONTRASEÑA INCORRECTA")

                    End If
                End If
            End If
        End If
        'End If



    End Sub
    Sub Evaluacion()

        Dim capitalminimo As String = ""
        Dim montosolicitado As String = ""
        Dim girosanuales As String = ""
        Dim girosmensual As String = ""
        Dim sociosinmora As String = ""
        Dim avalsinmora As String = ""

        Dim restricciones As String = ""
        Dim capitalsocialglobal As String = ""

        Dim conexiones As New CConexion
        conexiones.conexion()
        Dim command As SqlCommand = New SqlCommand(" select   [FILTRO_CAPITAL_MINIMO],[FILTRO_MONTO_SOLICITADO],[FILTRO_GIROS_ANUAL],[FILTRO_GIROS_MENSUAL],[FILTRO_SOCIO_SINMORA],[FILTRO_AVAL_SINMORA],[FILTRO_RESTRICCIONES],[FILTRO_CAPITAL_GLOBAL] ,COMENTARIO_EVALUACION FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL] where ID_SOLICITUD ='" + Trim(id) + "'", conexiones._conexion)
        conexiones.abrir()
        Dim reader As SqlDataReader = command.ExecuteReader()
        If reader.HasRows Then
            Do While reader.Read()
                'Retirocapitalanual = reader(0)
                capitalminimo = reader(0).ToString
                montosolicitado = reader(1).ToString
                girosanuales = reader(2).ToString
                girosmensual = reader(3).ToString
                sociosinmora = reader(4).ToString
                avalsinmora = reader(5).ToString

                'Falta ver estos filtros 
                restricciones = reader(6)
                capitalsocialglobal = reader(7)
                txtComentarioGirocapital.Text = reader(8).ToString

            Loop
        Else
        End If
        reader.Close()

        'MsgBox(capitalminimo)
        'MsgBox(montosolicitado)
        'MsgBox(girosanuales)
        'MsgBox(girosmensual)
        'MsgBox(sociosinmora)
        'MsgBox(avalsinmora)

        'Capital  Minimo 
        If capitalminimo = "NO" Then
            Pic1B.Visible = True
            Pic1A.Visible = False
        ElseIf capitalminimo = "SI" Then
            Pic1B.Visible = False
            Pic1A.Visible = True
        End If

        'Monto solicitado menor al maximo retirable 
        If montosolicitado = "NO" Then
            Pic2B.Visible = True
            Pic2A.Visible = False
        ElseIf montosolicitado = "SI" Then
            Pic2B.Visible = False
            Pic2A.Visible = True
        End If

        'Mas de  5 giros en el año  
        If girosanuales = "NO" Then
            'MsgBox("Poseee mas  de 5 retiros en el año ")
            Pic3B.Visible = True
            Pic3A.Visible = False
        ElseIf girosanuales = "SI" Then
            Pic3B.Visible = False
            Pic3A.Visible = True
        End If

        'Mas de  2 giros en el mes  
        If girosmensual = "NO" Then
            Pic4B.Visible = True
            Pic4A.Visible = False
        ElseIf girosmensual = "SI" Then
            Pic4B.Visible = False
            Pic4A.Visible = True
        End If

        'Socio con mora 
        'MsgBox(sociosinmora)
        'MsgBox(avalsinmora)

        If Trim(sociosinmora) = "NO" Then
            Pic5B.Visible = True
            Pic5A.Visible = False
        ElseIf sociosinmora = "SI" Then
            Pic5B.Visible = False
            Pic5A.Visible = True
        End If

        'Aval con mora 
        If Trim(avalsinmora) = "NO" Then
            Pic6B.Visible = True
            Pic6A.Visible = False
        ElseIf avalsinmora = "SI" Then
            Pic6B.Visible = False
            Pic6A.Visible = True
        End If

        'restricciones
        If restricciones = "NO" Then
            Pic7B.Visible = True
            Pic7A.Visible = False
        ElseIf restricciones = "SI" Then
            Pic7B.Visible = False
            Pic7A.Visible = True
        End If

        'Capital social global 
        If capitalsocialglobal = "NO" Then
            Pic8B.Visible = True
            Pic8A.Visible = False
        ElseIf capitalsocialglobal = "SI" Then
            Pic8B.Visible = False
            Pic8A.Visible = True
        End If
    End Sub

    Sub concepto(ByVal correlativo As String)

        Try


            Dim conexiones As New CConexion
            conexiones.conexion()
            Dim command As SqlCommand = New SqlCommand(" select descripcion from [_INGRESOS] as ingreso inner join [_CONCEPTOS] as concepto  on ingreso.codconcepto= concepto.codconcepto where correlativo ='" + Trim(correlativo) + "' ", conexiones._conexion)
            conexiones.abrir()
            Dim reader As SqlDataReader = command.ExecuteReader()
            If reader.HasRows Then
                Do While reader.Read()
                    Textnombreconp.Text = (Trim(reader(0).ToString))
                Loop
            Else
            End If
            reader.Close()

        Catch ex As Exception
        End Try

    End Sub



    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click
    End Sub

    Private Sub TabPage2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TabPage2.MouseClick
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        frmCreditosPorAprobar.CheckBox1.Checked = False
    End Sub

    Private Sub txtFecha_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecha.TextChanged
    End Sub

    Private Sub txtComentariosubgerente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComentariosubgerente.KeyUp
        txtcomentariototal.Text = 250 - (txtComentariosubgerente.Text.Length)
    End Sub

    Private Sub textsaldofinal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textsaldofinal.TextChanged
    End Sub

    Private Sub Textsaldofinal2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textsaldofinal2.TextChanged
    End Sub

End Class