
Imports System.Data
Imports System.Data.SqlClient

Public Class frmRentas



    Dim Datos As New CDatos
    Dim Plantillas As New CCEstadosGeneral
    Dim plantillas2 As Metodos = New Metodos
    Dim tabla As New DataTable
    Dim saliryguardar = "no"
    Public Function Puntos(ByVal strValor As String, Optional ByVal intNumDecimales As Integer = 0) As String

        Dim strAux As String
        Dim strComas As String
        Dim strPuntos As String
        Dim intX As Integer
        Dim bolMenos As Boolean = False

        strComas = ""
        strValor = strValor.Replace(".", "")
        If InStr(strValor, ",") > 0 Then
            strAux = Mid(strValor, 1, InStr(strValor, ",") - 1)
            strComas = Mid(strValor, InStr(strValor, ","))
        Else
            strAux = strValor
        End If

        If Mid(strAux, 1, 1) = "-" Then
            bolMenos = True
            strAux = Mid(strAux, 2)
        End If

        strPuntos = strAux
        strAux = ""
        While strPuntos.Length > 3
            strAux = "." & Mid(strPuntos, strPuntos.Length - 2, 3) & strAux
            strPuntos = Mid(strPuntos, 1, strPuntos.Length - 3)
        End While
        If intNumDecimales <> 0 Then
            If strComas = "" Then strComas = ","
            For intX = Len(strComas) - 1 To intNumDecimales - 1
                strComas = strComas & "0"
            Next

        End If
        strAux = strPuntos & strAux & strComas
        If Mid(strAux, 1, 1) = "." Then strAux = Mid(strAux, 2)
        If bolMenos Then strAux = "-" & strAux

        Return strAux
    End Function



    Sub calcularhaberes()

        'inicio contar filas
        For f = 0 To DGEmpreadosyPensionados.RowCount - 2

            'verifica que las finas no tengan valores en 0 antes de sumar el promedio
            If Double.Parse(Replace(DGEmpreadosyPensionados.Rows(f).Cells(1).Value(), ".", "")) = 0 Or Double.Parse(Replace(DGEmpreadosyPensionados.Rows(f).Cells(2).Value(), ".", "")) = 0 Or Double.Parse(Replace(DGEmpreadosyPensionados.Rows(f).Cells(3).Value(), ".", "")) = 0 Then
                ' si alguna columna tiene valor 0 no se realiza la sumatoria
                DGEmpreadosyPensionados.Rows(f).Cells(4).Value() = 0
            Else
                ' tisi todos los meses tienen vvalor se realiza la suma de su total
                DGEmpreadosyPensionados.Rows(f).Cells(4).Value() = Double.Parse(Replace(DGEmpreadosyPensionados.Rows(f).Cells(1).Value(), ".", "")) + Double.Parse(Replace(DGEmpreadosyPensionados.Rows(f).Cells(2).Value(), ".", "")) + Integer.Parse(Replace(DGEmpreadosyPensionados.Rows(f).Cells(3).Value(), ".", ""))
                DGEmpreadosyPensionados.Rows(f).Cells(4).Value() = Puntos(DGEmpreadosyPensionados.Rows(f).Cells(4).Value())
            End If


            'si el promedio es 0 se deja el total 0
            If DGEmpreadosyPensionados.Rows(f).Cells(4).Value() = 0 Then
                DGEmpreadosyPensionados.Rows(f).Cells(5).Value() = 0
            Else
                'si el promedio no es 0 se divide por 3 para sacar el promedio
                DGEmpreadosyPensionados.Rows(f).Cells(5).Value() = Math.Round((Double.Parse(Replace(DGEmpreadosyPensionados.Rows(f).Cells(4).Value(), ".", "")) / 3))
            End If


            ' de deja el total con puntos
            DGEmpreadosyPensionados.Rows(f).Cells(5).Value() = Puntos(DGEmpreadosyPensionados.Rows(f).Cells(5).Value())

        Next

        DGEmpreadosyPensionados.Rows(23).Cells(5).Value() = 0
        For f = 0 To DGEmpreadosyPensionados.RowCount - 2
            DGEmpreadosyPensionados.Rows(23).Cells(5).Value() = Double.Parse(Replace(DGEmpreadosyPensionados.Rows(23).Cells(5).Value(), ".", "")) + DGEmpreadosyPensionados.Rows(f).Cells(5).Value()
        Next


        DGEmpreadosyPensionados.Rows(23).Cells(5).Value() = Puntos(DGEmpreadosyPensionados.Rows(23).Cells(5).Value())




    End Sub
    Sub calculardescuentos()



        DGEDescuentos.Rows(9).Cells(1).Value() = 0
        For f = 0 To DGEDescuentos.RowCount - 2
            DGEDescuentos.Rows(9).Cells(1).Value() = Double.Parse(Replace(DGEDescuentos.Rows(9).Cells(1).Value(), ".", "")) + DGEDescuentos.Rows(f).Cells(1).Value()
        Next
        DGEDescuentos.Rows(9).Cells(1).Value() = Puntos(DGEDescuentos.Rows(9).Cells(1).Value())


    End Sub

    Sub calcularhonorarios()



        DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value() = 0
        For f = 0 To DGProfesionalesyTrabajadoresIndependientes.RowCount - 2
            DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value() = Double.Parse(Replace(DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value(), ".", "")) + DGProfesionalesyTrabajadoresIndependientes.Rows(f).Cells(1).Value()
        Next
        DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value() = Puntos(Math.Round(DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value() / 12))




    End Sub
    Sub calcularRentaLiquida()


        'inicio contar filas
        For f = 0 To DGEmpreadosyPensionados4.RowCount - 2

            'verifica que las finas no tengan valores en 0 antes de sumar el promedio
            If Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(f).Cells(1).Value(), ".", "")) = 0 Or Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(f).Cells(2).Value(), ".", "")) = 0 Or Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(f).Cells(3).Value(), ".", "")) = 0 Then
                ' si alguna columna tiene valor 0 no se realiza la sumatoria
                DGEmpreadosyPensionados4.Rows(f).Cells(4).Value() = 0
            Else
                ' tisi todos los meses tienen vvalor se realiza la suma de su total
                DGEmpreadosyPensionados4.Rows(f).Cells(4).Value() = Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(f).Cells(1).Value(), ".", "")) + Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(f).Cells(2).Value(), ".", "")) + Integer.Parse(Replace(DGEmpreadosyPensionados4.Rows(f).Cells(3).Value(), ".", ""))
                DGEmpreadosyPensionados4.Rows(f).Cells(4).Value() = Puntos(DGEmpreadosyPensionados4.Rows(f).Cells(4).Value())
            End If


            'si el promedio es 0 se deja el total 0
            If DGEmpreadosyPensionados4.Rows(f).Cells(4).Value() = 0 Then
                DGEmpreadosyPensionados4.Rows(f).Cells(5).Value() = 0
            Else
                'si el promedio no es 0 se divide por 3 para sacar el promedio
                DGEmpreadosyPensionados4.Rows(f).Cells(5).Value() = Math.Round((Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(f).Cells(4).Value(), ".", "")) / 3))
            End If


            ' de deja el total con puntos
            DGEmpreadosyPensionados4.Rows(f).Cells(5).Value() = Puntos(DGEmpreadosyPensionados4.Rows(f).Cells(5).Value())

        Next



        '   CALCULO DE LOS HABERES VARIABLES 

        Dim minimo As Integer = DGEmpreadosyPensionados4.Rows(1).Cells(1).Value()
        Dim maximo As Integer = DGEmpreadosyPensionados4.Rows(1).Cells(1).Value()
        Dim resultado As Integer

        For i = 2 To 3
            If Double.Parse(minimo) > Double.Parse(DGEmpreadosyPensionados4.Rows(1).Cells(i).Value()) Then
                minimo = DGEmpreadosyPensionados4.Rows(1).Cells(i).Value()
            End If
            If Double.Parse(maximo) < Double.Parse(DGEmpreadosyPensionados4.Rows(1).Cells(i).Value()) Then
                maximo = DGEmpreadosyPensionados4.Rows(1).Cells(i).Value()
            End If
        Next

        If DGEmpreadosyPensionados4.Rows(1).Cells(4).Value() = 0 Then
            DGEmpreadosyPensionados4.Rows(1).Cells(5).Value() = 0
        Else

            If (Double.Parse(maximo) - Double.Parse(minimo)) / Double.Parse(maximo) >= 0.3 Then
                DGEmpreadosyPensionados4.Rows(1).Cells(5).Value() = Math.Round((Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(1).Cells(4).Value(), ".", "")) / 3) * 0.8)

            Else

                DGEmpreadosyPensionados4.Rows(1).Cells(5).Value() = Math.Round((Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(1).Cells(4).Value(), ".", "")) / 3))
            End If
            DGEmpreadosyPensionados4.Rows(1).Cells(5).Value() = Puntos(DGEmpreadosyPensionados4.Rows(1).Cells(5).Value())
        End If


        '   CALCULO DE LOS HABERES NO IMPONIBLES 

        If DGEmpreadosyPensionados4.Rows(2).Cells(4).Value() = 0 Then


            DGEmpreadosyPensionados4.Rows(2).Cells(5).Value() = 0
        Else
            If (Double.Parse(DGEmpreadosyPensionados4.Rows(0).Cells(4).Value()) - Double.Parse(DGEmpreadosyPensionados4.Rows(2).Cells(4).Value())) / Double.Parse(DGEmpreadosyPensionados4.Rows(0).Cells(4).Value()) < 0.5 Then

                DGEmpreadosyPensionados4.Rows(2).Cells(5).Value() = Math.Round((Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(2).Cells(4).Value(), ".", "")) / 3) * 0.5)
            Else
                DGEmpreadosyPensionados4.Rows(2).Cells(5).Value() = Math.Round((Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(2).Cells(4).Value(), ".", "")) / 3))
            End If
            DGEmpreadosyPensionados4.Rows(2).Cells(5).Value() = Puntos(DGEmpreadosyPensionados4.Rows(2).Cells(5).Value())
        End If







        DGEmpreadosyPensionados4.Rows(6).Cells(5).Value() = 0

        For f = 0 To DGEmpreadosyPensionados4.RowCount - 2
            If f <= 2 Then
                DGEmpreadosyPensionados4.Rows(6).Cells(5).Value() = Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(6).Cells(5).Value(), ".", "")) + DGEmpreadosyPensionados4.Rows(f).Cells(5).Value()
            Else
                DGEmpreadosyPensionados4.Rows(6).Cells(5).Value() = Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(6).Cells(5).Value(), ".", "")) - DGEmpreadosyPensionados4.Rows(f).Cells(5).Value()
            End If

        Next


        DGEmpreadosyPensionados4.Rows(6).Cells(5).Value() = Puntos(DGEmpreadosyPensionados4.Rows(6).Cells(5).Value())


    End Sub

    Sub calcularRPLIndependiente()

        txtRPLIndependientes.Text = Math.Round((Decimal.Round((Double.Parse(DGProfesionalesyTrabajadoresIndependientes2.Rows(0).Cells(1).Value()) - Double.Parse(DGProfesionalesyTrabajadoresIndependientes2.Rows(1).Cells(1).Value())) / 12)) + (Double.Parse(DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value()) / 2))



        txtRPLIndependientes.Text = "$" + Puntos(txtRPLIndependientes.Text)


    End Sub


    Sub calcularRPLEmpleado()


        If cboPorcentajeDescuento.SelectedItem = "" Or cboPorcentajeDescuento.SelectedItem = "Cod DACA" Then
            TxtRLPEmpleados.Text = Math.Round(Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(6).Cells(5).Value(), ".", "")))
            TxtRLPEmpleados.Text = "$" + Puntos(TxtRLPEmpleados.Text)

        Else


            txtMaxCuota.Text = Math.Round(((Double.Parse(Replace(DGEmpreadosyPensionados.Rows(23).Cells(5).Value(), ".", "")) * Double.Parse(cboPorcentajeDescuento.SelectedItem)) / 100) - Double.Parse(Replace(DGEDescuentos.Rows(9).Cells(1).Value(), ".", ""))) - 6000
            txtMaxCuota.Text = "$" + Puntos(txtMaxCuota.Text)

            Dim plazo As Double = 0
            Dim tasa As Double = 0
            Dim monto As Double = 0
            Try

                monto = Math.Round(Double.Parse(Replace(Replace(txtMaxCuota.Text, ".", ""), "$", "")))

                plazo = Double.Parse(CboPlazo.SelectedItem)
                tasa = Double.Parse(CboTasa.SelectedItem) / 100


                txtMaxMonto.Text = Math.Round(monto * (((1 + tasa) ^ plazo - 1) / (tasa * (1 + tasa) ^ plazo)))
                txtMaxMonto.Text = "$" + Puntos(txtMaxMonto.Text)

            Catch ex As Exception

            End Try
            TxtRLPEmpleados.Text = Math.Round(Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(6).Cells(5).Value(), ".", "")))
            TxtRLPEmpleados.Text = "$" + Puntos(TxtRLPEmpleados.Text)
        End If



    End Sub


    Sub calcularRPLTotal()

        txtRLPTotal.Text = Double.Parse(Replace(Replace(TxtRLPEmpleados.Text, ".", ""), "$", "")) + Double.Parse(Replace(Replace(txtRPLIndependientes.Text, ".", ""), "$", "")) - Double.Parse(Replace(Replace(txtCuotaTrimestral.Text, ".", ""), "$", ""))
        txtRLPTotal.Text = "$" + Puntos(txtRLPTotal.Text)

    End Sub




    Private Sub PRUEBAS1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        For i = 0 To 23
            Me.DGEmpreadosyPensionados.Rows.Add()
        Next


        For i = 0 To 6
            Me.DGEmpreadosyPensionados4.Rows.Add()
        Next

        For i = 0 To 9
            Me.DGEDescuentos.Rows.Add()
        Next


        For i = 0 To 12
            Me.DGProfesionalesyTrabajadoresIndependientes.Rows.Add()
        Next


        For i = 0 To 1
            Me.DGProfesionalesyTrabajadoresIndependientes2.Rows.Add()
        Next

        DGEmpreadosyPensionados4.Rows(0).Cells(0).Value() = "Sueldo Base Mas Gratificación"
        DGEmpreadosyPensionados4.Rows(1).Cells(0).Value() = "Otros haberes imponibles variables"
        DGEmpreadosyPensionados4.Rows(2).Cells(0).Value() = "Otros haberes no imponibles"
        DGEmpreadosyPensionados4.Rows(3).Cells(0).Value() = "Descuentos Legales"
        DGEmpreadosyPensionados4.Rows(4).Cells(0).Value() = "Descuentos Deudas u Obligaciones"
        DGEmpreadosyPensionados4.Rows(5).Cells(0).Value() = "Impuesto Único de Segunda Categoría"
        DGEmpreadosyPensionados4.Rows(6).Cells(0).Value() = "TOTAL"
        DGEmpreadosyPensionados4.Columns(5).DefaultCellStyle.BackColor = Color.LightGray
        DGEmpreadosyPensionados4.Columns(5).DefaultCellStyle.BackColor = Color.LightGray
        DGEmpreadosyPensionados4.Rows(6).DefaultCellStyle.BackColor = Color.Black
        DGEmpreadosyPensionados4.Rows(6).DefaultCellStyle.ForeColor = Color.White
        DGEmpreadosyPensionados4.Rows(6).ReadOnly = True

        DGEmpreadosyPensionados.Rows(0).Cells(0).Value() = "Salario del Período / Sueldo Base / ANEF / C.J"
        DGEmpreadosyPensionados.Rows(1).Cells(0).Value() = "Gratificación/Componente Base PMG/Asignación Municipal"
        DGEmpreadosyPensionados.Rows(2).Cells(0).Value() = "Incremento Remun. Imponible / Incremento Prev."
        DGEmpreadosyPensionados.Rows(3).Cells(0).Value() = "Asignación Unica Tributable"
        DGEmpreadosyPensionados.Rows(4).Cells(0).Value() = "Bonif. Salud ley 18566"
        DGEmpreadosyPensionados.Rows(5).Cells(0).Value() = "Asig. Ley 18675 Art. 10"
        DGEmpreadosyPensionados.Rows(6).Cells(0).Value() = "Asig. Ley 18717"
        DGEmpreadosyPensionados.Rows(7).Cells(0).Value() = "Asig. Ley 19529"
        DGEmpreadosyPensionados.Rows(8).Cells(0).Value() = "Bonif. Art. 21 Ley 19429"
        DGEmpreadosyPensionados.Rows(9).Cells(0).Value() = "Asig. Sust. L, 19185"
        DGEmpreadosyPensionados.Rows(10).Cells(0).Value() = "Asig. Fiscalización"
        DGEmpreadosyPensionados.Rows(11).Cells(0).Value() = "Bono Productividad / Bono Resultado/ Asig. Merito"
        DGEmpreadosyPensionados.Rows(12).Cells(0).Value() = "Incentivo"
        DGEmpreadosyPensionados.Rows(13).Cells(0).Value() = "Semana Corrida"
        DGEmpreadosyPensionados.Rows(14).Cells(0).Value() = "Horas Extras"
        DGEmpreadosyPensionados.Rows(15).Cells(0).Value() = "Bono Vacaciones"
        DGEmpreadosyPensionados.Rows(16).Cells(0).Value() = "Bono Producción Vacaciones"
        DGEmpreadosyPensionados.Rows(17).Cells(0).Value() = "Otros Bonos"
        DGEmpreadosyPensionados.Rows(18).Cells(0).Value() = "Atención Primaria (en salud)"
        DGEmpreadosyPensionados.Rows(19).Cells(0).Value() = "Otros Haberes Imp."
        DGEmpreadosyPensionados.Rows(20).Cells(0).Value() = "Opcional 1"
        DGEmpreadosyPensionados.Rows(21).Cells(0).Value() = "Opcional 2"
        DGEmpreadosyPensionados.Rows(22).Cells(0).Value() = "Opcional 3"
        DGEmpreadosyPensionados.Rows(23).Cells(0).Value() = "TOTAL"
        DGEmpreadosyPensionados.Columns(4).DefaultCellStyle.BackColor = Color.LightGray
        DGEmpreadosyPensionados.Columns(5).DefaultCellStyle.BackColor = Color.LightGray
        DGEmpreadosyPensionados.Rows(23).DefaultCellStyle.BackColor = Color.Black
        DGEmpreadosyPensionados.Rows(23).DefaultCellStyle.ForeColor = Color.White
        DGEmpreadosyPensionados.Rows(23).ReadOnly = True
        'DGEmpreadosyPensionados.Rows(20).DefaultCellStyle.ForeColor = Color.White

        DGEDescuentos.Rows(0).Cells(0).Value() = "Seguro Salud"
        DGEDescuentos.Rows(1).Cells(0).Value() = "Seguro de Vida"
        DGEDescuentos.Rows(2).Cells(0).Value() = "Seguro Catastrófico"
        DGEDescuentos.Rows(3).Cells(0).Value() = "Préstamo Interno"
        DGEDescuentos.Rows(4).Cells(0).Value() = "Cuota sindical Empresa"
        DGEDescuentos.Rows(5).Cells(0).Value() = "Cuota extra sindical"
        DGEDescuentos.Rows(6).Cells(0).Value() = "Cuota 75% sindical"
        DGEDescuentos.Rows(7).Cells(0).Value() = "Descuentos Varios (préstamos comerciales)"
        DGEDescuentos.Rows(8).Cells(0).Value() = "Otros Descuentos"
        DGEDescuentos.Rows(9).Cells(0).Value() = "TOTAL"
        DGEDescuentos.Rows(9).DefaultCellStyle.BackColor = Color.Black
        DGEDescuentos.Rows(9).DefaultCellStyle.ForeColor = Color.White
        DGEDescuentos.Rows(9).ReadOnly = True

        DGProfesionalesyTrabajadoresIndependientes.Rows(0).Cells(0).Value() = "Mes 1"
        DGProfesionalesyTrabajadoresIndependientes.Rows(1).Cells(0).Value() = "Mes 2"
        DGProfesionalesyTrabajadoresIndependientes.Rows(2).Cells(0).Value() = "Mes 3"
        DGProfesionalesyTrabajadoresIndependientes.Rows(3).Cells(0).Value() = "Mes 4"
        DGProfesionalesyTrabajadoresIndependientes.Rows(4).Cells(0).Value() = "Mes 5"
        DGProfesionalesyTrabajadoresIndependientes.Rows(5).Cells(0).Value() = "Mes 6"
        DGProfesionalesyTrabajadoresIndependientes.Rows(6).Cells(0).Value() = "Mes 7"
        DGProfesionalesyTrabajadoresIndependientes.Rows(7).Cells(0).Value() = "Mes 8"
        DGProfesionalesyTrabajadoresIndependientes.Rows(8).Cells(0).Value() = "Mes 9"
        DGProfesionalesyTrabajadoresIndependientes.Rows(9).Cells(0).Value() = "Mes 10"
        DGProfesionalesyTrabajadoresIndependientes.Rows(10).Cells(0).Value() = "Mes 11"
        DGProfesionalesyTrabajadoresIndependientes.Rows(11).Cells(0).Value() = "Mes 12"
        DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(0).Value() = "TOTAL"
        DGProfesionalesyTrabajadoresIndependientes.Rows(12).DefaultCellStyle.BackColor = Color.Black
        DGProfesionalesyTrabajadoresIndependientes.Rows(12).DefaultCellStyle.ForeColor = Color.White
        DGProfesionalesyTrabajadoresIndependientes.Rows(12).ReadOnly = True

        DGProfesionalesyTrabajadoresIndependientes2.Rows(0).Cells(0).Value() = "Línea 547, Formulario 22"
        DGProfesionalesyTrabajadoresIndependientes2.Rows(1).Cells(0).Value() = "Línea 492, Formulario 22"
        DGProfesionalesyTrabajadoresIndependientes2.Columns(0).DefaultCellStyle.ForeColor = Color.White
        DGProfesionalesyTrabajadoresIndependientes2.Columns(0).DefaultCellStyle.BackColor = Color.Black

        RELLENA0()
        BLOQUEACOLUMNAS()

        'cargarguadados()


        CARGARPORCENTAJES()

        'For i = 1 To 100 Step 1

        'cboPorcentajeDescuento.Items.Add(i.ToString)
        'Next


        For i = 0.9 To 2.01 Step 0.01
            CboTasa.Items.Add(i.ToString)
        Next


    End Sub


    Sub CARGARPORCENTAJES()

        Try

        

        cboPorcentajeDescuento.Items.Clear()
        cboPorcentajeDescuento.Items.Add("")
        cboPorcentajeDescuento.Items.Add("Cod DACA")

        Dim codigo As Integer = 0


        Dim conexiones15 As New CConexion
        conexiones15.conexion()
        Dim command15 As SqlCommand = New SqlCommand("SELECT PORCENTAJE_DESCUENTO,CODFOR from _FORMAPAGO WHERE RTRIM(DESCRIPCION)='" + frmEvaluar.CboFormaDePago2.SelectedItem.ToString() + "'", conexiones15._conexion)
        conexiones15.abrir()
        Dim reader15 As SqlDataReader = command15.ExecuteReader()

        If reader15.HasRows Then
            Do While reader15.Read()
                'TXTid.Text = (reader15(0).ToString)
                cboPorcentajeDescuento.Items.Add(reader15(0).ToString)
                codigo = reader15(1).ToString
            Loop
        Else
        End If
        conexiones15.cerrar()

        Dim conexiones16 As New CConexion
        conexiones16.conexion()
        Dim command16 As SqlCommand = New SqlCommand("SELECT [porcentaje] FROM _PORCENTAJEDESCUENTO_EXCEPCIONES where rtrim(rut)='" + frmEvaluar.txtRut.Text.Trim + "' and convert(date,GETDATE())>=convert(date,fecha) and convert(date,GETDATE())<=convert(date,fecha_final) and rtrim(formapago)='" + codigo.ToString.Trim + "' ", conexiones16._conexion)
        conexiones16.abrir()
        Dim reader16 As SqlDataReader = command16.ExecuteReader()
        If reader16.HasRows Then
            Do While reader16.Read()
                cboPorcentajeDescuento.Items.Add(reader16(0).ToString)
            Loop
        Else
        End If
        conexiones16.cerrar()

        cboPorcentajeDescuento.SelectedItem = ""
        Catch ex As Exception

        End Try

        ' If (codigo = 79) Then
        'cboPorcentajeDescuento.Items.Clear()
        ' cboPorcentajeDescuento.Items.Add("")
        ' cboPorcentajeDescuento.Items.Add("Cod DACA")
        ' For i = 1 To 100 Step 1
        'cboPorcentajeDescuento.Items.Add(i.ToString)
        'Next
        ' End If

    End Sub
    Sub cargarguadados()

        Plantillas._tabla.Rows.Clear()
        Plantillas._tabla.Columns.Clear()

        'Datos._Perfil = "CCAMPOS"
        'Datos._forpago = "PLANILLA"
        'CboFormaDePago.SelectedItem


        Datos._Perfil = frmPerfil.CbmUsuario.SelectedItem.ToString.Trim()
        Datos._forpago = frmEvaluar.CboFormaDePago.SelectedItem.ToString

        crearcolumna()




        If (frmPerfil.CbmUsuario.SelectedItem.ToString.Trim() = "CCAMPOS") Then

            If plantillas2.Consultar_Rentas_TODOS() Then
                tabla = plantillas2.tabla
                DGGuardado.DataSource = tabla

            End If



        Else

            If plantillas2.Consultar_RentasPERSONALXTodos(Datos) Then
                tabla = plantillas2.tabla
                DGGuardado.DataSource = tabla
                LViendo.Text = "Se muestran rentas guardadas por la forma de pago en solicitud (" + Datos._forpago + ")"

            End If



        End If





        DGGuardado.AllowUserToAddRows = False

    End Sub


    Private Sub Button14_Click(sender As Object, e As EventArgs)
        calcularhaberes()
    End Sub
    Sub BLOQUEACOLUMNAS()


        For m = 0 To DGEmpreadosyPensionados.ColumnCount - 1
            DGEmpreadosyPensionados.Columns(m).SortMode = DataGridViewColumnSortMode.NotSortable
        Next


        For m = 0 To DGEDescuentos.ColumnCount - 1
            DGEDescuentos.Columns(m).SortMode = DataGridViewColumnSortMode.NotSortable
        Next



        For m = 0 To DGEmpreadosyPensionados4.ColumnCount - 1

            DGEmpreadosyPensionados4.Columns(m).SortMode = DataGridViewColumnSortMode.NotSortable
        Next





        For i = 0 To DGProfesionalesyTrabajadoresIndependientes.ColumnCount - 1
            DGProfesionalesyTrabajadoresIndependientes.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        For m = 0 To DGProfesionalesyTrabajadoresIndependientes2.ColumnCount - 1
            DGProfesionalesyTrabajadoresIndependientes2.Columns(m).SortMode = DataGridViewColumnSortMode.NotSortable
        Next


    End Sub
    Sub RELLENA0()


        For m = 1 To DGEmpreadosyPensionados.ColumnCount - 1
            For i = 0 To DGEmpreadosyPensionados.RowCount - 2
                DGEmpreadosyPensionados.Rows(i).Cells(m).Value() = 0
            Next
        Next
        DGEmpreadosyPensionados.Rows(23).Cells(5).Value() = 0

        For i = 0 To DGEDescuentos.RowCount - 1
            DGEDescuentos.Rows(i).Cells(1).Value() = 0
        Next



        For m = 1 To DGEmpreadosyPensionados4.ColumnCount - 1
            For i = 0 To DGEmpreadosyPensionados4.RowCount - 2
                DGEmpreadosyPensionados4.Rows(i).Cells(m).Value() = 0
            Next
        Next
        DGEmpreadosyPensionados4.Rows(6).Cells(5).Value() = 0


        For i = 0 To DGProfesionalesyTrabajadoresIndependientes.RowCount - 1
            DGProfesionalesyTrabajadoresIndependientes.Rows(i).Cells(1).Value() = 0
        Next

        For m = 1 To DGProfesionalesyTrabajadoresIndependientes2.ColumnCount - 1
            For i = 0 To DGProfesionalesyTrabajadoresIndependientes2.RowCount - 1
                DGProfesionalesyTrabajadoresIndependientes2.Rows(i).Cells(m).Value() = 0
            Next
        Next
    End Sub


    Private Sub DGEmpreadosyPensionados_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGEmpreadosyPensionados.CellEndEdit


        If DGEmpreadosyPensionados.CurrentCell.ColumnIndex <> 0 Then

            If IsNumeric(DGEmpreadosyPensionados.CurrentCell.Value) = True Then
                DGEmpreadosyPensionados.CurrentCell.Value = Puntos(DGEmpreadosyPensionados.CurrentCell.Value)
            Else
                MsgBox("No es un dato numérico")
                DGEmpreadosyPensionados.CurrentCell.Value = 0
            End If
        End If


        If (DGEmpreadosyPensionados.Rows(20).Cells(1).Value() <> 0 Or DGEmpreadosyPensionados.Rows(20).Cells(2).Value() <> 0 Or DGEmpreadosyPensionados.Rows(20).Cells(3).Value() <> 0) Then

            DGEmpreadosyPensionados.Rows(20).Cells(0).ReadOnly = False


            If DGEmpreadosyPensionados.Rows(20).Cells(0).Value() = "Opcional 1" Or String.IsNullOrEmpty(DGEmpreadosyPensionados.Rows(20).Cells(0).Value()) = True Then

                DGEmpreadosyPensionados.Rows(20).Cells(0).Style.BackColor = Color.Yellow

            Else
                DGEmpreadosyPensionados.Rows(20).Cells(0).Style.BackColor = Color.WhiteSmoke
            End If
        Else
            DGEmpreadosyPensionados.Rows(20).Cells(0).Value = "Opcional 1"
            DGEmpreadosyPensionados.Rows(20).Cells(0).Style.BackColor = Color.WhiteSmoke
            DGEmpreadosyPensionados.Rows(20).Cells(0).ReadOnly = True
        End If




        If (DGEmpreadosyPensionados.Rows(21).Cells(1).Value() <> 0 Or DGEmpreadosyPensionados.Rows(21).Cells(2).Value() <> 0 Or DGEmpreadosyPensionados.Rows(21).Cells(3).Value() <> 0) Then

            If String.IsNullOrEmpty(DGEmpreadosyPensionados.Rows(21).Cells(0).Value()) = True Or DGEmpreadosyPensionados.Rows(21).Cells(0).Value() = "Opcional 2" Then

                DGEmpreadosyPensionados.Rows(21).Cells(0).Style.BackColor = Color.Yellow

            Else
                DGEmpreadosyPensionados.Rows(21).Cells(0).Style.BackColor = Color.WhiteSmoke
            End If

            DGEmpreadosyPensionados.Rows(21).Cells(0).ReadOnly = False
        Else
            DGEmpreadosyPensionados.Rows(21).Cells(0).Value = "Opcional 2"
            DGEmpreadosyPensionados.Rows(21).Cells(0).Style.BackColor = Color.WhiteSmoke
            DGEmpreadosyPensionados.Rows(21).Cells(0).ReadOnly = True
        End If


        If (DGEmpreadosyPensionados.Rows(22).Cells(1).Value() <> 0 Or DGEmpreadosyPensionados.Rows(22).Cells(2).Value() <> 0 Or DGEmpreadosyPensionados.Rows(22).Cells(3).Value() <> 0) Then

            DGEmpreadosyPensionados.Rows(22).Cells(0).ReadOnly = False
            If String.IsNullOrEmpty(DGEmpreadosyPensionados.Rows(22).Cells(0).Value()) = True Or DGEmpreadosyPensionados.Rows(22).Cells(0).Value() = "Opcional 3" Then

                DGEmpreadosyPensionados.Rows(22).Cells(0).Style.BackColor = Color.Yellow

            Else
                DGEmpreadosyPensionados.Rows(22).Cells(0).Style.BackColor = Color.WhiteSmoke
            End If
        Else
            DGEmpreadosyPensionados.Rows(22).Cells(0).Value = "Opcional 3"
            DGEmpreadosyPensionados.Rows(22).Cells(0).Style.BackColor = Color.WhiteSmoke
            DGEmpreadosyPensionados.Rows(22).Cells(0).ReadOnly = True
        End If


        calcularhaberes()
        calcularRPLEmpleado()


    End Sub



    Private Sub DGEDescuentos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGEDescuentos.CellEndEdit

        If IsNumeric(DGEDescuentos.CurrentCell.Value) = True Then
            DGEDescuentos.CurrentCell.Value = Puntos(DGEDescuentos.CurrentCell.Value)
        Else
            MsgBox("No es un dato numérico")
            DGEDescuentos.CurrentCell.Value = 0
        End If

        calculardescuentos()
        calcularRPLEmpleado()



    End Sub

    Private Sub Button14_Click_1(sender As Object, e As EventArgs) Handles BGEmpreadosyPensionados.Click


        For f = 0 To DGEmpreadosyPensionados.RowCount - 2
            DGEmpreadosyPensionados.Rows(f).Cells(2).Value() = DGEmpreadosyPensionados.Rows(f).Cells(1).Value()
            DGEmpreadosyPensionados.Rows(f).Cells(3).Value() = DGEmpreadosyPensionados.Rows(f).Cells(1).Value()
        Next

        calcularhaberes()
        calcularRPLEmpleado()

    End Sub



    Private Sub DGProfesionalesyTrabajadoresIndependientes_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGProfesionalesyTrabajadoresIndependientes.CellEndEdit
        If IsNumeric(DGProfesionalesyTrabajadoresIndependientes.CurrentCell.Value) = True Then
            DGProfesionalesyTrabajadoresIndependientes.CurrentCell.Value = Puntos(DGProfesionalesyTrabajadoresIndependientes.CurrentCell.Value)
        Else
            MsgBox("No es un dato numérico")
            DGProfesionalesyTrabajadoresIndependientes.CurrentCell.Value = 0
        End If
        calcularhonorarios()
        calcularRPLIndependiente()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        DGProfesionalesyTrabajadoresIndependientes.Rows(1).Cells(1).Value() = DGProfesionalesyTrabajadoresIndependientes.Rows(0).Cells(1).Value()
        DGProfesionalesyTrabajadoresIndependientes.Rows(2).Cells(1).Value() = DGProfesionalesyTrabajadoresIndependientes.Rows(0).Cells(1).Value()
        DGProfesionalesyTrabajadoresIndependientes.Rows(3).Cells(1).Value() = DGProfesionalesyTrabajadoresIndependientes.Rows(0).Cells(1).Value()
        DGProfesionalesyTrabajadoresIndependientes.Rows(4).Cells(1).Value() = DGProfesionalesyTrabajadoresIndependientes.Rows(0).Cells(1).Value()
        DGProfesionalesyTrabajadoresIndependientes.Rows(5).Cells(1).Value() = DGProfesionalesyTrabajadoresIndependientes.Rows(0).Cells(1).Value()
        DGProfesionalesyTrabajadoresIndependientes.Rows(6).Cells(1).Value() = DGProfesionalesyTrabajadoresIndependientes.Rows(0).Cells(1).Value()
        DGProfesionalesyTrabajadoresIndependientes.Rows(7).Cells(1).Value() = DGProfesionalesyTrabajadoresIndependientes.Rows(0).Cells(1).Value()
        DGProfesionalesyTrabajadoresIndependientes.Rows(8).Cells(1).Value() = DGProfesionalesyTrabajadoresIndependientes.Rows(0).Cells(1).Value()
        DGProfesionalesyTrabajadoresIndependientes.Rows(9).Cells(1).Value() = DGProfesionalesyTrabajadoresIndependientes.Rows(0).Cells(1).Value()
        DGProfesionalesyTrabajadoresIndependientes.Rows(10).Cells(1).Value() = DGProfesionalesyTrabajadoresIndependientes.Rows(0).Cells(1).Value()
        DGProfesionalesyTrabajadoresIndependientes.Rows(11).Cells(1).Value() = DGProfesionalesyTrabajadoresIndependientes.Rows(0).Cells(1).Value()

        calcularhonorarios()
        calcularRPLIndependiente()
    End Sub



    Private Sub DGProfesionalesyTrabajadoresIndependientes2_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGProfesionalesyTrabajadoresIndependientes2.CellEndEdit

        If IsNumeric(DGProfesionalesyTrabajadoresIndependientes2.CurrentCell.Value) = True Then
            DGProfesionalesyTrabajadoresIndependientes2.CurrentCell.Value = Puntos(DGProfesionalesyTrabajadoresIndependientes2.CurrentCell.Value)
        Else
            MsgBox("No es un dato numérico")
            DGProfesionalesyTrabajadoresIndependientes2.CurrentCell.Value = 0
        End If
        calcularRPLIndependiente()


    End Sub

    Private Sub txtRPLEmpleados_TextChanged(sender As Object, e As EventArgs) Handles txtMaxCuota.TextChanged
        Try
            calcularRPLTotal()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtRPLIndependientes_TextChanged(sender As Object, e As EventArgs) Handles txtRPLIndependientes.TextChanged
        Try
            calcularRPLTotal()
        Catch ex As Exception

        End Try

    End Sub

    'Private Sub Button16_Click(sender As Object, e As EventArgs)

    '    Dim cadena As String = ""

    '    For m = 1 To DGEmpreadosyPensionados.ColumnCount - 3
    '        For i = 0 To DGEmpreadosyPensionados.RowCount - 2

    '            If cadena = "" Then

    '                cadena = DGEmpreadosyPensionados.Rows(i).Cells(m).Value().ToString()

    '            Else

    '                cadena = cadena + ";" + DGEmpreadosyPensionados.Rows(i).Cells(m).Value().ToString()
    '            End If

    '        Next
    '    Next




    '    For i = 0 To DGEDescuentos.RowCount - 2
    '        cadena = cadena + ";" + DGEDescuentos.Rows(i).Cells(1).Value().ToString()
    '    Next



    '    For i = 0 To DGProfesionalesyTrabajadoresIndependientes.RowCount - 2
    '        cadena = cadena + ";" + DGProfesionalesyTrabajadoresIndependientes.Rows(i).Cells(1).Value().ToString()

    '    Next


    '    For i = 0 To DGProfesionalesyTrabajadoresIndependientes2.RowCount - 1
    '        cadena = cadena + ";" + DGProfesionalesyTrabajadoresIndependientes2.Rows(i).Cells(1).Value().ToString()
    '    Next

    '    'GUARDADO SE DEBE INCORPORAR
    '    'For i = 0 To DGEmpreadosyPensionados3.RowCount - 2
    '    '    cadena = cadena + ";" + DGEmpreadosyPensionados3.Rows(i).Cells(1).Value().ToString()
    '    'Next


    '    If cboPorcentajeDescuento.SelectedItem = "" Then
    '        cadena = cadena + ";" + " "
    '    End If
    '    cadena = cadena + ";" + cboPorcentajeDescuento.SelectedItem



    '    MsgBox(cadena)

    '    Datos._CADENA = cadena

    '    Datos._Nrosocio = "1166"
    '    Datos._Perfil = "CCAMPOS"



    '    If Plantillas.Agregar_Renta(Datos) Then
    '        MsgBox("Guardado con exito")
    '    Else
    '        MessageBox.Show("Error al consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End If

    '    Me.Close()

    'End Sub
    Sub crearcolumna()
        If DGGuardado.Columns.Contains("btn") Then
        Else
            Dim btn As New DataGridViewButtonColumn()
            DGGuardado.Columns.Add(btn)
            btn.HeaderText = "Cargar"
            btn.Text = "Cargar"
            btn.Name = "btn"
            btn.UseColumnTextForButtonValue = True
        End If
    End Sub
    Sub cargar()
        TXTid.Text = DGGuardado.Rows(DGGuardado.CurrentRow.Index).Cells("ID").Value
        Dim CADENA As String = ""

        Dim conexiones22 As New CConexion
        conexiones22.conexion()
        Dim command22 As SqlCommand = New SqlCommand("SELECT  [VALOR] FROM [_RIESGO_RENTA] WHERE ID=" + TXTid.Text + " ORDER BY ID DESC ", conexiones22._conexion)
        conexiones22.abrir()
        Dim reader22 As SqlDataReader = command22.ExecuteReader()


        If reader22.HasRows Then
            Do While reader22.Read()
                CADENA = Trim((reader22(0).ToString))

            Loop
        Else
        End If
        reader22.Close()

        Dim conexiones2 As New CConexion
        conexiones2.conexion()
        conexiones2.abrir()
        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter
        Dim dtTable As DataTable

        command = New SqlCommand("RecibirParametros", conexiones2._conexion)
        command.CommandType = CommandType.StoredProcedure
        adapter = New SqlDataAdapter(command)
        dtTable = New DataTable
        With command.Parameters
            'Envió los parámetros que necesito
            .Add(New SqlParameter("@Parametros", SqlDbType.VarChar)).Value = CADENA
        End With

        Try
            adapter.Fill(dtTable)
            DataGridView1.DataSource = dtTable
            DataGridView1.AutoGenerateColumns = False
        Catch expSQL As SqlException
            MsgBox(expSQL.ToString, MsgBoxStyle.OkOnly, "SQL Exception")
            Exit Sub
        End Try

        DataGridView1.AllowUserToAddRows = False


        RELLENA0()





        Dim NUMERO As Integer = 0
        cboTipo.Visible = True

        'TIPO
        cboTipo.SelectedItem = DataGridView1.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1

        'RENTA LIQUIDA MENSUAL
        For m = 1 To DGEmpreadosyPensionados4.ColumnCount - 3
            For i = 0 To DGEmpreadosyPensionados4.RowCount - 2
                DGEmpreadosyPensionados4.Rows(i).Cells(m).Value() = DataGridView1.Rows(NUMERO).Cells(0).Value().ToString()
                NUMERO = NUMERO + 1

            Next
        Next

        'PORCENTAJE DESCUENTO
        cboPorcentajeDescuento.SelectedItem = DataGridView1.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1

        'DESCUENTOS DE LA ULTIMA LIQUIDACION
        For i = 0 To DGEDescuentos.RowCount - 2
            DGEDescuentos.Rows(i).Cells(1).Value() = DataGridView1.Rows(NUMERO).Cells(0).Value().ToString()
            NUMERO = NUMERO + 1
        Next

        'HABERES IMPONIBLES

        For m = 1 To DGEmpreadosyPensionados.ColumnCount - 3
            For i = 0 To DGEmpreadosyPensionados.RowCount - 2
                DGEmpreadosyPensionados.Rows(i).Cells(m).Value() = DataGridView1.Rows(NUMERO).Cells(0).Value().ToString()
                NUMERO = NUMERO + 1
            Next
        Next


        'OPCIONAL 1
        DGEmpreadosyPensionados.Rows(20).Cells(0).Value() = DataGridView1.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1
        'OPCIONAL 2
        DGEmpreadosyPensionados.Rows(21).Cells(0).Value() = DataGridView1.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1
        'OPCIONAL 3
        DGEmpreadosyPensionados.Rows(22).Cells(0).Value() = DataGridView1.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1


        'TASA
        CboTasa.SelectedItem = DataGridView1.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1
        'PLAZO
        CboPlazo.SelectedItem = DataGridView1.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1

        'COMENTARIO

        txtComentario.Text = DataGridView1.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1

        'HONORARIOS
        For i = 0 To DGProfesionalesyTrabajadoresIndependientes.RowCount - 2
            DGProfesionalesyTrabajadoresIndependientes.Rows(i).Cells(1).Value() = DataGridView1.Rows(NUMERO).Cells(0).Value().ToString()
            NUMERO = NUMERO + 1

        Next

        'FORMULARIOS ANUAL
        For i = 0 To DGProfesionalesyTrabajadoresIndependientes2.RowCount - 1
            DGProfesionalesyTrabajadoresIndependientes2.Rows(i).Cells(1).Value() = DataGridView1.Rows(NUMERO).Cells(0).Value().ToString()
            NUMERO = NUMERO + 1
        Next

        txtcaracteres.Text = 900 - (txtComentario.Text.Length)

        calcularRentaLiquida()
        calcularhaberes()
        calculardescuentos()
        calcularRPLEmpleado()
        calcularhonorarios()
        calcularRPLIndependiente()
        calcularRPLTotal()

    End Sub



    Private Sub DataGridView2_SelectionChanged(sender As Object, e As EventArgs) Handles DGGuardado.SelectionChanged
        'TXTid.Text = DGGuardado.Rows(DGGuardado.CurrentRow.Index).Cells("ID").Value
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        PanelEmpleadoPlanilla.Visible = True
        PanelIndependiente.Visible = False
        PanelRentasGuardadas.Visible = False
        'CARGARPORCENTAJES()
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        PanelEmpleadoPlanilla.Visible = False
        PanelIndependiente.Visible = True
        PanelRentasGuardadas.Visible = False
    End Sub

    Private Sub Button14_Click_2(sender As Object, e As EventArgs) Handles Button14.Click
        cargarguadados()
        PanelEmpleadoPlanilla.Visible = False
        PanelIndependiente.Visible = False
        PanelRentasGuardadas.Visible = True
    End Sub

    Private Sub DGEmpreadosyPensionados3_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)


        calcularRentaLiquida()
        calcularRPLEmpleado()
        calcularRPLTotal()
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles BGEmpreadosyPensionados3.Click
        For f = 0 To DGEmpreadosyPensionados4.RowCount - 2
            DGEmpreadosyPensionados4.Rows(f).Cells(2).Value() = DGEmpreadosyPensionados4.Rows(f).Cells(1).Value()
            DGEmpreadosyPensionados4.Rows(f).Cells(3).Value() = DGEmpreadosyPensionados4.Rows(f).Cells(1).Value()
        Next

        calcularRentaLiquida()
        calcularRPLEmpleado()
        calcularRPLTotal()
    End Sub

    Private Sub cboPorcentajeDescuento_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cboPorcentajeDescuento.SelectedItem = "" Then
            LGEDescuentos.Visible = False
            DGEDescuentos.Visible = False
            LGEmpreadosyPensionados.Visible = False
            BGEmpreadosyPensionados.Visible = False
            DGEmpreadosyPensionados.Visible = False
        Else
            LGEDescuentos.Visible = True
            DGEDescuentos.Visible = True
            LGEmpreadosyPensionados.Visible = True
            BGEmpreadosyPensionados.Visible = True
            DGEmpreadosyPensionados.Visible = True
            calcularhaberes()
            calcularRPLEmpleado()
            calcularRPLTotal()
        End If
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Dim RECIBERESPUESTA As DialogResult
        RECIBERESPUESTA = MessageBox.Show("Al Salir no se guardara la renta ¿Quiere salir del formulario?", "Renta", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If RECIBERESPUESTA = Windows.Forms.DialogResult.Yes Then
            Me.Visible = False
            frmEvaluar.BtnRenta.BackColor = Color.MistyRose
            frmEvaluar.txtIdRentaSocios.Text = ""
        End If




    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged



        If cboTipo.SelectedItem = "Empleados" Then
            LDGEmpreadosyPensionados3.Visible = True
            BGEmpreadosyPensionados3.Visible = True
            DGEmpreadosyPensionados4.Visible = True
            cboPorcentajeDescuento.SelectedItem = ""
            'SI ES PLANILLA LO HABILITA
            If frmEvaluar.CboFormaDePago.SelectedItem = "PLANILLA" Then
                'If CboFormaDePago.SelectedItem = "PLANILLA" Then
                cboPorcentajeDescuento.Visible = True
                LboPorcentajeDescuento.Visible = True
            Else
                cboPorcentajeDescuento.Visible = False
                LboPorcentajeDescuento.Visible = False
            End If


        ElseIf cboTipo.SelectedItem = "Pensionados" Then
            LDGEmpreadosyPensionados3.Visible = True
            BGEmpreadosyPensionados3.Visible = True
            DGEmpreadosyPensionados4.Visible = True
            cboPorcentajeDescuento.SelectedItem = ""
            cboPorcentajeDescuento.Visible = False
            LboPorcentajeDescuento.Visible = False
        Else

            LDGEmpreadosyPensionados3.Visible = False
            BGEmpreadosyPensionados3.Visible = False
            DGEmpreadosyPensionados4.Visible = False
            cboPorcentajeDescuento.SelectedItem = ""
            cboPorcentajeDescuento.Visible = False
            LboPorcentajeDescuento.Visible = False



            For m = 1 To DGEmpreadosyPensionados4.ColumnCount - 1
                For i = 0 To DGEmpreadosyPensionados4.RowCount - 2
                    DGEmpreadosyPensionados4.Rows(i).Cells(m).Value() = 0
                Next
            Next
            DGEmpreadosyPensionados4.Rows(6).Cells(5).Value() = 0

            calcularRentaLiquida()
            calcularRPLEmpleado()
            calcularRPLTotal()
        End If



    End Sub

    Private Sub cboPorcentajeDescuento_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboPorcentajeDescuento.SelectedIndexChanged
        If cboPorcentajeDescuento.SelectedItem <> "" And cboPorcentajeDescuento.SelectedItem <> "Cod DACA" Then

            LGEDescuentos.Visible = True
            DGEDescuentos.Visible = True
            LGEmpreadosyPensionados.Visible = True
            BGEmpreadosyPensionados.Visible = True
            DGEmpreadosyPensionados.Visible = True
            TableMax.Visible = True
            lxtMaxCuotaaDescontar.Visible = True
            calcularRPLEmpleado()
            txtCodDaca.Visible = False
            txtCodDaca.Text = ""
            txtCodDaca.BackColor = Color.MistyRose
        ElseIf cboPorcentajeDescuento.SelectedItem = "Cod DACA" Then
            txtCodDaca.Visible = True
            LGEDescuentos.Visible = False
            DGEDescuentos.Visible = False
            LGEmpreadosyPensionados.Visible = False
            BGEmpreadosyPensionados.Visible = False
            DGEmpreadosyPensionados.Visible = False
            RELLENA0PLANILLA()
            calculardescuentos()
            calcularhaberes()
            txtMaxCuota.Text = "$0"
            txtMaxMonto.Text = "$0"
            TableMax.Visible = False
            lxtMaxCuotaaDescontar.Visible = False
            txtComentario.Text = ""
            CboPlazo.SelectedItem = ""
            CboTasa.SelectedItem = ""
            txtCodDaca.Text = ""
            txtCodDaca.BackColor = Color.MistyRose
        Else
            LGEDescuentos.Visible = False
            DGEDescuentos.Visible = False
            LGEmpreadosyPensionados.Visible = False
            BGEmpreadosyPensionados.Visible = False
            DGEmpreadosyPensionados.Visible = False
            RELLENA0PLANILLA()
            calculardescuentos()
            calcularhaberes()
            txtMaxCuota.Text = "$0"
            txtMaxMonto.Text = "$0"
            TableMax.Visible = False
            lxtMaxCuotaaDescontar.Visible = False
            txtComentario.Text = ""
            CboPlazo.SelectedItem = ""
            CboTasa.SelectedItem = ""
            txtCodDaca.Visible = False
            txtCodDaca.Text = ""
            txtCodDaca.BackColor = Color.MistyRose
        End If




    End Sub



    Sub RELLENA0PLANILLA()

        For m = 1 To DGEmpreadosyPensionados.ColumnCount - 1
            For i = 0 To DGEmpreadosyPensionados.RowCount - 2
                DGEmpreadosyPensionados.Rows(i).Cells(m).Value() = 0
            Next
        Next


        For i = 0 To DGEDescuentos.RowCount - 1
            DGEDescuentos.Rows(i).Cells(1).Value() = 0
        Next

    End Sub



    Private Sub Button20_Click_1(sender As Object, e As EventArgs) Handles Button20.Click


        Dim RECIBERESPUESTA As DialogResult
        RECIBERESPUESTA = MessageBox.Show("¿Desea Guardar la renta y continuar con la solicitud?", "Renta", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If RECIBERESPUESTA = Windows.Forms.DialogResult.Yes Then


            If Double.Parse(Replace(Replace(txtRLPTotal.Text, ".", ""), "$", "")) <= 0 Then
                MsgBox("No es posible ingresar a la solicitud de un RLP igual o menor a 0")

            Else


                If cboTipo.SelectedItem <> "" And (Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(0).Cells(1).Value(), ".", "")) = 0 Or Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(0).Cells(2).Value(), ".", "")) = 0 Or Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(0).Cells(3).Value(), ".", "")) = 0) Then
                    MsgBox("Se deben informar las 3 ULTIMAS RENTAS al ser tipo de renta " + cboTipo.SelectedItem.ToString.Trim)

                Else
                    'If CboFormaDePago.SelectedItem = "PLANILLA" And cboPorcentajeDescuento.SelectedItem = "" Then
                    If frmEvaluar.CboFormaDePago.SelectedItem = "PLANILLA" And cboPorcentajeDescuento.SelectedItem = "" And cboTipo.SelectedItem = "Empleados" And cboPorcentajeDescuento.SelectedItem <> "Cod DACA" Then

                        MsgBox("Al ser forma de pago por planilla se debe indicar un PORCENTAJE DE DESCUENTO")

                    Else
                        If frmEvaluar.CboFormaDePago.SelectedItem = "PLANILLA" And cboPorcentajeDescuento.SelectedItem = "Cod DACA" And txtCodDaca.Text = "" Then
                            'If CboFormaDePago.SelectedItem = "PLANILLA" And Double.Parse(Replace(DGEDescuentos.Rows(9).Cells(1).Value(), ".", "")) = 0 Then
                            MsgBox("Debe indicar el codigo DACA otorgado")

                        Else

                            'If CboFormaDePago.SelectedItem = "PLANILLA" And Double.Parse(Replace(DGEmpreadosyPensionados.Rows(23).Cells(5).Value(), ".", "")) = 0 Then
                            If frmEvaluar.CboFormaDePago.SelectedItem = "PLANILLA" And Double.Parse(Replace(DGEmpreadosyPensionados.Rows(23).Cells(5).Value(), ".", "")) = 0 And cboTipo.SelectedItem = "Empleados" And cboPorcentajeDescuento.SelectedItem <> "Cod DACA" Then
                                MsgBox("Al ser forma de pago por planilla se debe indicar los valores de HABERES")

                            Else


                                'If CboFormaDePago.SelectedItem = "PLANILLA" And CboTasa.SelectedItem = "" Then
                                If frmEvaluar.CboFormaDePago.SelectedItem = "PLANILLA" And CboTasa.SelectedItem = "" And cboTipo.SelectedItem = "Empleados" And cboPorcentajeDescuento.SelectedItem <> "Cod DACA" Then
                                    MsgBox("Al ser forma de pago por planilla se debe indicar los valores de la TASA a solicitar")

                                Else

                                    'If CboFormaDePago.SelectedItem = "PLANILLA" And CboPlazo.SelectedItem = "" Then
                                    If frmEvaluar.CboFormaDePago.SelectedItem = "PLANILLA" And CboPlazo.SelectedItem = "" And cboTipo.SelectedItem = "Empleados" And cboPorcentajeDescuento.SelectedItem <> "Cod DACA" Then
                                        MsgBox("Al ser forma de pago por planilla se debe indicar los valores del PLAZO a solicitar")

                                    Else

                                        If Double.Parse(Replace(DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value(), ".", "")) > 0 And (Double.Parse(Replace(DGProfesionalesyTrabajadoresIndependientes2.Rows(0).Cells(1).Value(), ".", "")) = 0) Then

                                            MsgBox("Se debe declarar la Línea 547, FORMULARIO 22 de la Renta al ser independiente")

                                        Else


                                            If Double.Parse(Replace(DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value(), ".", "")) > 0 And (Double.Parse(Replace(DGProfesionalesyTrabajadoresIndependientes2.Rows(1).Cells(1).Value(), ".", "")) = 0) Then

                                                MsgBox("Se debe declarar la Línea 492, FORMULARIO 22 de la Renta al ser independiente")

                                            Else

                                                If txtcaracteres.Text < 0 Then
                                                    MsgBox("El maximo de caracteres en el comentario es de 900")
                                                Else




                                                    calcularRentaLiquida()
                                                    calcularhaberes()
                                                    calculardescuentos()
                                                    calcularRPLEmpleado()
                                                    calcularhonorarios()
                                                    calcularRPLIndependiente()
                                                    calcularRPLTotal()

                                                    Dim cadena As String = ""

                                                    'TIPO
                                                    cadena = cadena + cboTipo.SelectedItem.ToString
                                                    'RENTA LIQUIDA MENSUAL
                                                    For m = 1 To DGEmpreadosyPensionados4.ColumnCount - 3
                                                        For i = 0 To DGEmpreadosyPensionados4.RowCount - 2
                                                            cadena = cadena + ";" + DGEmpreadosyPensionados4.Rows(i).Cells(m).Value().ToString()
                                                        Next
                                                    Next

                                                    'PORCENTAJE DESCUENTO
                                                    If cboPorcentajeDescuento.SelectedItem = "" Then
                                                        cadena = cadena + ";" + " "
                                                    Else
                                                        cadena = cadena + ";" + cboPorcentajeDescuento.SelectedItem.ToString.Trim
                                                    End If

                                                    'DESCUENTOS DE LA ULTIMA LIQUIDACION
                                                    For i = 0 To DGEDescuentos.RowCount - 2
                                                        cadena = cadena + ";" + DGEDescuentos.Rows(i).Cells(1).Value().ToString()
                                                    Next

                                                    'HABERES IMPONIBLES

                                                    For m = 1 To DGEmpreadosyPensionados.ColumnCount - 3
                                                        For i = 0 To DGEmpreadosyPensionados.RowCount - 2

                                                            If cadena = "" Then

                                                                cadena = DGEmpreadosyPensionados.Rows(i).Cells(m).Value().ToString()

                                                            Else

                                                                cadena = cadena + ";" + DGEmpreadosyPensionados.Rows(i).Cells(m).Value().ToString()
                                                            End If

                                                        Next
                                                    Next

                                                    'OPCIONAL 1
                                                    cadena = cadena + ";" + DGEmpreadosyPensionados.Rows(20).Cells(0).Value().ToString().Trim
                                                    'OPCIONAL 2
                                                    cadena = cadena + ";" + DGEmpreadosyPensionados.Rows(21).Cells(0).Value().ToString().Trim
                                                    'OPCIONAL 3
                                                    cadena = cadena + ";" + DGEmpreadosyPensionados.Rows(22).Cells(0).Value().ToString().Trim


                                                    'TASA
                                                    cadena = cadena + ";" + CboTasa.SelectedItem.ToString
                                                    'PLAZO
                                                    cadena = cadena + ";" + CboPlazo.SelectedItem.ToString
                                                    'COMENTARIO
                                                    If txtComentario.Text = "" Then
                                                        txtComentario.Text = " "
                                                    End If
                                                    cadena = cadena + ";" + Replace(txtComentario.Text, ";", "")

                                                    'HONORARIOS
                                                    For i = 0 To DGProfesionalesyTrabajadoresIndependientes.RowCount - 2
                                                        cadena = cadena + ";" + DGProfesionalesyTrabajadoresIndependientes.Rows(i).Cells(1).Value().ToString()
                                                    Next

                                                    'FORMULARIOS ANUAL
                                                    For i = 0 To DGProfesionalesyTrabajadoresIndependientes2.RowCount - 1
                                                        cadena = cadena + ";" + DGProfesionalesyTrabajadoresIndependientes2.Rows(i).Cells(1).Value().ToString()
                                                    Next


                                                    'MsgBox(cadena)




                                                    Datos._CADENA = cadena

                                                    Datos._Nrosocio = frmEvaluar.txtNrosocio.Text

                                                    Datos._forpago = frmEvaluar.CboFormaDePago.SelectedItem.ToString

                                                    Datos._Perfil = frmPerfil.CbmUsuario.SelectedItem.ToString
                                                    'Datos._Perfil = "CCAMPOS"
                                                    'Datos._Nrosocio = 1166
                                                    'Datos._forpago = CboFormaDePago.SelectedItem.ToString
                                                    If Plantillas.Agregar_Renta(Datos) Then

                                                        'cargarguadados()


                                                        Dim conexiones14 As New CConexion
                                                        conexiones14.conexion()
                                                        Dim command14 As SqlCommand = New SqlCommand("Select MAX([ID]) FROM [_RIESGO_RENTA] where Usuario='" + Datos._Perfil.ToString + "'", conexiones14._conexion)
                                                        conexiones14.abrir()
                                                        Dim reader14 As SqlDataReader = command14.ExecuteReader()

                                                        If reader14.HasRows Then
                                                            Do While reader14.Read()
                                                                'TXTid.Text = (reader14(0).ToString)
                                                                frmEvaluar.txtIdRentaSocios.Text = (reader14(0).ToString)
                                                            Loop
                                                        Else
                                                        End If


                                                        Dim codigo As String = ""
                                                        Dim TIPOPAGO As String = ""
                                                        Dim PERMITE_INDICAR_ANOMES As String = ""

                                                        Dim conexiones15 As New CConexion
                                                        conexiones15.conexion()
                                                        Dim command15 As SqlCommand = New SqlCommand("SELECT CODFOR, TIPOPAGO , PERMITE_INDICAR_ANOMES FROM _FORMAPAGO WHERE DESCRIPCION='" + frmEvaluar.CboFormaDePago2.SelectedItem.ToString().Trim() + "'", conexiones15._conexion)
                                                        conexiones15.abrir()
                                                        Dim reader15 As SqlDataReader = command15.ExecuteReader()

                                                        If reader15.HasRows Then
                                                            Do While reader15.Read()
                                                                'TXTid.Text = (reader15(0).ToString)
                                                                codigo = (reader15(0).ToString)
                                                                frmEvaluar.txtCOD_FORMAPAGO.Text = (reader15(0).ToString)
                                                                TIPOPAGO = (reader15(1).ToString)
                                                                PERMITE_INDICAR_ANOMES = (reader15(2).ToString)

                                                            Loop
                                                        Else
                                                        End If



                                                        If Double.Parse(Replace(Replace(TxtRLPEmpleados.Text, ".", ""), "$", "")) > 0 Then
                                                            frmEvaluar.CboRenta.SelectedItem = cboTipo.SelectedItem.ToString.Trim
                                                        End If

                                                        If Double.Parse(Replace(Replace(txtRPLIndependientes.Text, ".", ""), "$", "")) > 0 Then
                                                            frmEvaluar.CboRenta.SelectedItem = "Independientes"
                                                        End If


                                                        If Double.Parse(Replace(Replace(txtRPLIndependientes.Text, ".", ""), "$", "")) > 0 And Double.Parse(Replace(Replace(TxtRLPEmpleados.Text, ".", ""), "$", "")) > 0 Then
                                                            frmEvaluar.CboRenta.SelectedItem = "Mixta"
                                                        End If

                                                        frmEvaluar.TXTRENTALIQUIDA.Text = Math.Round(Double.Parse(Replace(Replace(txtRLPTotal.Text, ".", ""), "$", "")), 0, MidpointRounding.ToEven)
                                                        frmEvaluar.txtMaxCuotaPlanilla.Text = Math.Round(Double.Parse(Replace(Replace(txtMaxCuota.Text, ".", ""), "$", "")), 0, MidpointRounding.ToEven)
                                                        frmEvaluar.txtMaxCuotaPlanilla.Text = Puntos(frmEvaluar.txtMaxCuotaPlanilla.Text)
                                                        frmEvaluar.txtMaxCuotaPlanilla.Text = Math.Round(Double.Parse(Replace(Replace(txtMaxCuota.Text, ".", ""), "$", "")), 0, MidpointRounding.ToEven)
                                                        frmEvaluar.txtMaxCuotaPlanilla.Text = Puntos(frmEvaluar.txtMaxCuotaPlanilla.Text)
                                                        frmEvaluar.txtMaxMontoPlanilla.Text = Math.Round(Double.Parse(Replace(Replace(txtMaxMonto.Text, ".", ""), "$", "")), 0, MidpointRounding.ToEven)
                                                        frmEvaluar.txtMaxMontoPlanilla.Text = Puntos(frmEvaluar.txtMaxMontoPlanilla.Text)

                                                        If frmEvaluar.CboFormaDePago.SelectedItem = "PLANILLA" And cboPorcentajeDescuento.SelectedItem <> "Cod DACA" And cboTipo.SelectedItem = "Empleados" Then

                                                            frmEvaluar.CboCuotas.SelectedItem = CboPlazo.SelectedItem
                                                            frmEvaluar.CboCuotas.Enabled = False
                                                            frmEvaluar.txtTasaConvenio.Text = CboTasa.SelectedItem
                                                        Else
                                                            frmEvaluar.CboCuotas.SelectedItem = ""
                                                            frmEvaluar.CboCuotas.Enabled = True

                                                        End If

                                                        If codigo = "18" Or codigo = "19" Then
                                                            MsgBox("Para la forma de pago " + frmEvaluar.CboFormaDePago2.SelectedItem.ToString() + ", se solicitara un monto de " + txtMaxMonto.Text)
                                                            frmEvaluar.TxtMonto.Text = Replace(txtMaxMonto.Text, "$", "")
                                                        End If


                                                        If (TIPOPAGO = "TRIMESTRAL") Then
                                                            frmEvaluar.ChkFechaInicio.Enabled = False
                                                        Else
                                                            frmEvaluar.ChkFechaInicio.Enabled = True
                                                        End If





                                                        Me.Visible = False

                                                            frmEvaluar.BtnRenta.BackColor = Color.White

                                                            If cboPorcentajeDescuento.SelectedItem = "Cod DACA" Then
                                                                frmEvaluar.txtCodDaca.Text = txtCodDaca.Text
                                                            Else
                                                                frmEvaluar.txtCodDaca.Text = ""
                                                            End If

                                                            frmEvaluar.txtTipoEP.Text = cboTipo.SelectedItem

                                                        Else
                                                            MessageBox.Show("Error al consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                    End If

                                                End If

                                            End If

                                        End If
                                    End If
                                End If
                            End If

                        End If

                    End If
                End If

            End If
        End If




    End Sub



    Private Sub DGEmpreadosyPensionados4_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGEmpreadosyPensionados4.CellEndEdit

        If IsNumeric(DGEmpreadosyPensionados4.CurrentCell.Value) = True Then
            DGEmpreadosyPensionados4.CurrentCell.Value = Puntos(DGEmpreadosyPensionados4.CurrentCell.Value)
        Else
            MsgBox("No es un dato numérico")
            DGEmpreadosyPensionados4.CurrentCell.Value = 0
        End If

        calcularRentaLiquida()
        calcularRPLEmpleado()
        calcularRPLTotal()
    End Sub





    Private Sub CboPlazo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboPlazo.SelectedIndexChanged
        If CboPlazo.SelectedItem <> "" Then
            CboPlazo.BackColor = Color.White
        Else
            CboPlazo.BackColor = Color.MistyRose
            txtMaxMonto.Text = "$0"
        End If

        If CboTasa.BackColor <> Color.MistyRose And CboPlazo.BackColor <> Color.MistyRose Then
            calcularRPLEmpleado()
        End If

    End Sub

    Private Sub CboTasa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboTasa.SelectedIndexChanged
        If CboTasa.SelectedItem <> "" Then
            CboTasa.BackColor = Color.White
        Else
            CboTasa.BackColor = Color.MistyRose
            txtMaxMonto.Text = "$0"
        End If

        If CboTasa.BackColor <> Color.MistyRose And CboPlazo.BackColor <> Color.MistyRose Then
            calcularRPLEmpleado()
        End If

    End Sub

    Private Sub CboFormaDePago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboFormaDePago.SelectedIndexChanged
        cboTipo.SelectedItem = ""
    End Sub


    Private Sub DGGuardado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGGuardado.CellContentClick
        If e.ColumnIndex = 0 Then
            cargar()
        End If
    End Sub

    Private Sub DGProfesionalesyTrabajadoresIndependientes2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGProfesionalesyTrabajadoresIndependientes2.CellContentClick

    End Sub

    Private Sub txtCodDaca_TextChanged(sender As Object, e As EventArgs) Handles txtCodDaca.TextChanged

        If txtCodDaca.Visible = True And txtCodDaca.Text = "" Then
            txtCodDaca.BackColor = Color.MistyRose
        Else
            txtCodDaca.BackColor = Color.White
        End If
    End Sub



    Private Sub txtComentario_KeyUp(sender As Object, e As KeyEventArgs) Handles txtComentario.KeyUp
        txtcaracteres.Text = 600 - (txtComentario.Text.Length)
    End Sub



    Private Sub cboPorcentajeDescuento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboPorcentajeDescuento.KeyPress
        e.Handled = True
    End Sub

    Private Sub frmRentas_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged

        If Me.Visible = True Then
            CARGARPORCENTAJES()
        End If



    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click

        tabla.Clear()
        plantillas2._tabla.Rows.Clear()
        plantillas2._tabla.Columns.Clear()
        Datos._Perfil = frmPerfil.CbmUsuario.SelectedItem.ToString.Trim()
        Datos._forpago = frmEvaluar.CboFormaDePago.SelectedItem.ToString
        If plantillas2.Consultar_RentasPERSONALXRenta(Datos) Then
            tabla = plantillas2.tabla
            DGGuardado.DataSource = tabla
            LViendo.Text = "Se muestran rentas guardadas por la forma de pago en solicitud (" + Datos._forpago + ")"
        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        tabla.Clear()
        plantillas2._tabla.Rows.Clear()
        plantillas2._tabla.Columns.Clear()
        Datos._Perfil = frmPerfil.CbmUsuario.SelectedItem.ToString.Trim()
        Datos._Nrosocio = frmEvaluar.txtNrosocio.Text
        If plantillas2.Consultar_RentasPERSONALXNrosocio(Datos) Then
            tabla = plantillas2.tabla
            DGGuardado.DataSource = tabla
            LViendo.Text = "Se muestran rentas guardadas por Nrosocio (" + Datos._Nrosocio + ")"
            If frmEvaluar.Cbotipo.SelectedItem <> "SOCIO" Then
                MsgBox("Advertencia al ser Pre-Socio podria mostrar contenido de una Renta de un Socio")
            End If
        End If
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        If txtIdGuadado.Text.Trim = "" Then
            MsgBox("Debe Indicar un Id")
        Else
            tabla.Clear()
            plantillas2._tabla.Rows.Clear()
            plantillas2._tabla.Columns.Clear()
            Datos._Perfil = frmPerfil.CbmUsuario.SelectedItem.ToString.Trim()
            Datos._ID_RENTA = txtIdGuadado.Text
            If plantillas2.Consultar_RentasPERSONALXID(Datos) Then
                tabla = plantillas2.tabla
                DGGuardado.DataSource = tabla
                LViendo.Text = "Se muestran rentas guardadas por ID (" + Datos._ID_RENTA + ")"
            End If
        End If
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        tabla.Clear()
        plantillas2._tabla.Rows.Clear()
        plantillas2._tabla.Columns.Clear()
        Datos._Perfil = frmPerfil.CbmUsuario.SelectedItem.ToString.Trim()
        If plantillas2.Consultar_RentasPERSONALXTodos(Datos) Then
            tabla = plantillas2.tabla
            DGGuardado.DataSource = tabla
            LViendo.Text = "Se muestran todas rentas guardadas del usuario"
        End If
    End Sub



    Private Sub txtCuotaTrimestral_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCuotaTrimestral.KeyPress
        If IsNumeric(txtCuotaTrimestral.Text) Then
            calcularRPLTotal()
        Else
            MsgBox("De indicar un valor numerico")
            txtCuotaTrimestral.Text = 0
        End If
    End Sub
End Class