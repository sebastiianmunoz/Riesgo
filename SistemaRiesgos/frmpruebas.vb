Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Data
Imports System.Data.SqlClient

Public Class frmpruebas
    Dim presionar As Integer = 0
    Dim datos As New CDatos
    Public _tabla29 As DataTable = New DataTable
    Public _TABLA30 As DataTable = New DataTable ' datos mes actual 
    Public _tabla31 As DataTable = New DataTable  ' cantidad de lineas de creditos ingresadas en el mes 

    Public _tabla77 As DataTable = New DataTable  ' cantidad de lineas de creditos ingresadas en el mes 




    Dim newcol As DataGridViewColumn = New DataGridViewTextBoxColumn  'declaracion sobre giro 
    Dim newcol2 As DataGridViewColumn = New DataGridViewTextBoxColumn   'Saldo Sobre giro 
    Dim newcol3 As DataGridViewColumn = New DataGridViewTextBoxColumn   'Saldo Sobre giro 
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter

    Private Sub go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'CheckValidaciones.SetItemChecked(0, True)

        'MsgBox(CheckValidaciones.GetItemChecked(0))


    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)



    End Sub






    Private Sub frmpruebas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'My.Computer.Audio.Play(My.Resources.Beep, AudioPlayMode.Background)


        '' SELECT CC1.FECHA,SUM(CC1.MONTOAPORTE) AS APORTE ,SUM(MONTORETIRO) AS RETIRO, SUM(CC1.MONTOAPORTE)-SUM(MONTORETIRO)AS SALDO_CAPITAL   ,   ISNULL(CC2.LINEA,0) AS LINEA_SOBRE_GIRO ,  (SELECT CASE  WHEN (SUM(CC1.MONTOAPORTE)-SUM(MONTORETIRO))< 0 THEN (SUM(CC1.MONTOAPORTE)-SUM(MONTORETIRO))*-1 ELSE SUM(CC1.MONTOAPORTE)-SUM(MONTORETIRO)   END ) -ISNULL(CC2.LINEA,0) AS SALDO_ACUMULADO   FROM _CAPITALSOCIAL  AS CC1 LEFT JOIN (SELECT [FECHA] , SUM(LINEA_SOBRE_GIRO) AS LINEA FROM [_RIESGO_CONTROL_CAPITAL] group by fecha) AS CC2 ON CC1.FECHA=CC2.FECHA WHERE  LEFT(CC1.FECHA,6) ='201410' GROUP BY CC1.FECHA,CC2.LINEA ORDER BY FECHA 


        '_tabla77.Rows.Clear()
        '_tabla77.Columns.Clear()
        'Dim conexiones4 As New CConexion
        'conexiones4.conexion()
        '_adaptador.SelectCommand = New SqlCommand("SELECT CC1.FECHA,SUM(CC1.MONTOAPORTE) AS APORTE ,SUM(MONTORETIRO) AS RETIRO, SUM(CC1.MONTOAPORTE)-SUM(MONTORETIRO)AS SALDO_CAPITAL   ,   ISNULL(CC2.LINEA,0) AS LINEA_SOBRE_GIRO ,  (SELECT CASE  WHEN (SUM(CC1.MONTOAPORTE)-SUM(MONTORETIRO))< 0 THEN (SUM(CC1.MONTOAPORTE)-SUM(MONTORETIRO))*-1 ELSE SUM(CC1.MONTOAPORTE)-SUM(MONTORETIRO)   END ) -ISNULL(CC2.LINEA,0) AS SALDO_ACUMULADO   FROM _CAPITALSOCIAL  AS CC1 LEFT JOIN (SELECT [FECHA] , SUM(LINEA_SOBRE_GIRO) AS LINEA FROM [_RIESGO_CONTROL_CAPITAL] group by fecha) AS CC2 ON CC1.FECHA=CC2.FECHA WHERE  LEFT(CC1.FECHA,6) ='201410' GROUP BY CC1.FECHA,CC2.LINEA ORDER BY FECHA ", conexiones4._conexion)
        'conexiones4.abrir()
        '_adaptador.Fill(_tabla77)
        'GridmesActual.DataSource = _tabla77
        'conexiones4.cerrar()



        'Dim Totalfilas As Integer = GridmesActual.Rows.Count - 1
        'Dim tomavalor As Integer = 0

        'For z = 0 To Totalfilas

        '    'si esxite linea de sobregiro 
        '    If GridmesActual.Rows(z).Cells(4).Value() > 0 Then
        '        'si el saldo capital no  negativo 
        '        If GridmesActual.Rows(z).Cells(3).Value() < 0 Then

        '            tomavalor = GridmesActual.Rows(z).Cells(3).Value() * -1
        '            'si el saldo diario es mayor al colochon  o  al saldo del cochon 
        '            If tomavalor > GridmesActual.Rows(z).Cells(4).Value() Then

        '                MsgBox("La linea de sobre giro es menor al  saldo del capital  debe ingresar una linea de  sobre giro ")
        '                GridmesActual.Rows(z).Cells(4).Style.BackColor = Color.Red
        '                z = Totalfilas
        '                'Estado pENDIENTE 
        '            ElseIf tomavalor < GridmesActual.Rows(z).Cells(4).Value() Then

        '                GridmesActual.Rows(z).Cells(5).Value() = tomavalor - GridmesActual.Rows(z).Cells(4).Value()

        '            End If



        '        ElseIf GridmesActual.Rows(z).Cells(4).Value() = 0 Then








        '        End If


        '    Else





        '    End If



        'Next
        cboTasaSolicitada.Size = New System.Drawing.Size(236, 281)
        cboTasaSolicitada.Location = New System.Drawing.Point(136, 32)
        cboTasaSolicitada.IntegralHeight = False
        cboTasaSolicitada.MaxDropDownItems = 5
        cboTasaSolicitada.DropDownStyle = ComboBoxStyle.DropDownList
        cboTasaSolicitada.Name = "ComboBox1"
        cboTasaSolicitada.Size = New System.Drawing.Size(136, 81)
        cboTasaSolicitada.TabIndex = 0
        'Controls.Add(this.ComboBox1);


    End Sub


    Private Sub TXTTEXT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        For i = 0.9 To 2.01 Step 0.01
            cboTasaSolicitada.Items.Add(i.ToString)
        Next


        'My.Computer.Audio.Play(" My.Resources.alarma2.wav")
        'My.Computer.Audio.Play(My.Resources.alarma2, AudioPlayMode.Background)
        'TabControl1.Controls.Item(1).Visible = False
        'datos._Version = "2.00"

        'MsgBox(datos._Version)
        'Dim alfabetico As Integer = 0

        'Dim Numeros As Integer = 0


        'Dim len As Integer = txtprueba.Text.Length - 1
        'For i As Integer = 0 To len

        '    Dim ch As Char = txtprueba.Text(i)
        '    If Char.IsLetter(ch) Then       ' Si el caracter es un numero
        '        alfabetico += 1
        '    End If
        '    If Char.IsNumber(ch) Then       ' Si el caracter es un numero
        '        Numeros += 1
        '    End If

        'Next


        'MsgBox(alfabetico)


    End Sub

    Private Function VT(ByRef text As String) As Boolean
  
        Dim hasNumber As Boolean          ' Determina si uno de los caracteres es un numero
        Dim hasUpperLetter As Boolean    ' Determina si uno de los caracteres alfabeticos es mayuscula
        Dim letterCount As Integer          ' Cantidad de caracteres alfabeticos

        ' Recorrer todos los caracteres
        Dim len As Integer = text.Length - 1

        For i As Integer = 0 To len
            Dim ch As Char = text(i)
            If Char.IsNumber(ch) Then       ' Si el caracter es un numero
                hasNumber = True
            ElseIf Char.IsLetter(ch) Then   ' Si es un caracter alfabetico
                letterCount += 1
                If Char.IsLower(ch) Then    ' Si es mayuscula

                End If
            End If
        Next

        Return hasNumber AndAlso letterCount >= 2 AndAlso hasUpperLetter
    End Function




    Sub CALCULO3()
        ' Gridfilasinsaldo.Rows.RemoveAt()

        Dim LINEASOBREGRIO As Integer = 0
        Dim TOMAFECHA As String = ""
        Dim SALDODIARIO As Integer = 0
        Dim SALDOACUMULADO As Integer = 0

        Dim TOMAVALORZ As Integer = 0
        Dim SALDOANTERIOR As Integer = 0
        Dim CONTADOR As Integer = 0
        Dim TOTALFILAS As Integer = 0
        'If Textsobregiro.Text = "" Then
        'MsgBox("Debe ingresar un monto para el sobre giro")
        'Else
        'End If

        TOTALFILAS = GridmesActual.Rows.Count - 1
        ' TOMAFECHA = Trim(Textdesdeaño.Text) + Trim(Textdesdemes.Text)

        'LINEASOBREGRIO = Textsobregiro.Text
        'Verifica  el saldo  Ingresado   como linea de sobvre giro para ese mes 



        Dim conexiones7 As New CConexion
        conexiones7.conexion()
        Dim command7 As SqlCommand = New SqlCommand("  SELECT [LINEA_SOBRE_GIRO] FROM [_RIESGO_CONTROL_CAPITAL] where left(_RIESGO_CONTROL_CAPITAL.FECHA,6) = " + TOMAFECHA + " AND  ES_LINEA=1  ", conexiones7._conexion)
        conexiones7.abrir()
        Dim reader7 As SqlDataReader = command7.ExecuteReader()
        If reader7.HasRows Then
            Do While reader7.Read()
                LINEASOBREGRIO = reader7(0)
            Loop
        Else
        End If
        reader7.Close()


        ' If LINEASOBREGRIO <> 0 Then


        'GridmesActual.Rows(0).Cells(5).Value() = LINEASOBREGRIO
        'GridmesActual.Rows(0).Cells(4).Value() = LINEASOBREGRIO
        GridmesActual.Rows(0).Cells(5).Value() = ""
        GridmesActual.Rows(0).Cells(4).Value() = ""


        GridmesActual.Rows(0).Cells(5).Value() = LINEASOBREGRIO
        GridmesActual.Rows(0).Cells(4).Value() = LINEASOBREGRIO



        For z = 1 To TOTALFILAS

            If GridmesActual.Rows(z).Cells(3).Value().ToString <> "" Then


                SALDODIARIO = GridmesActual.Rows(z).Cells(3).Value()

                'uf sub general encargado de las restas y sumas de capital 
                If SALDODIARIO < 0 Then
                    'MONTO SOBREGIRO PARA REALZIAR COLCHON --SE DEBE VERIFICAR SI  ES LA PRIMERA VEZ 
                    'LINEASOBREGRIO = GridmesActual.Rows(0).Cells(5).Value()
                    If CONTADOR = 0 Then
                        'SI EL SALDO DEL CAPITAL ES NEGATIVO 


                        'Cambia le valor  del saldo diario para poder comparar 
                        SALDODIARIO = SALDODIARIO * -1
                        'MsgBox(SALDODIARIO)
                        'MsgBox(SALDODIARIO)


                        If SALDODIARIO > LINEASOBREGRIO Then
                            MsgBox("El Sobregiro  ingresado es menor  al primer saldo diario  del mes , Debe Verificar el Monto Ingresado ")
                            'Vuelve  a dejar el valor en negativo 
                            GridmesActual.Rows(z).Cells(0).Style.BackColor = Color.Red
                            GridmesActual.Rows(z).Cells(1).Style.BackColor = Color.Red
                            GridmesActual.Rows(z).Cells(2).Style.BackColor = Color.Red
                            'Saldo diaria capital 
                            GridmesActual.Rows(z).Cells(3).Style.BackColor = Color.Red
                            GridmesActual.Rows(z).Cells(3).Style.ForeColor = Color.Yellow

                            GridmesActual.Rows(z).Cells(4).Style.BackColor = Color.Red
                            GridmesActual.Rows(z).Cells(5).Style.BackColor = Color.Red

                            'toma fila donde se hace el cambio************************ 

                            Gridfilasinsaldo.Rows.Add(GridmesActual.Rows(z).Cells(0).Value(), GridmesActual.Rows(z).Cells(1).Value(), GridmesActual.Rows(z).Cells(2).Value(), GridmesActual.Rows(z).Cells(3).Value(), GridmesActual.Rows(z - 1).Cells(5).Value())


                            '*********************************************************
                            z = TOTALFILAS
                            SALDODIARIO = SALDODIARIO * -1

                        Else
                            'si el saldo diario es menor al colchon entoces se resta de manera normal 
                            SALDOACUMULADO = SALDODIARIO - LINEASOBREGRIO
                            'Confirmar que la resta sea positiva 
                            If SALDOACUMULADO < 0 Then
                                SALDOACUMULADO = SALDOACUMULADO * -1
                                GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO

                                'Dejar Solicitudes Pendiente  por Falta de capital 
                            ElseIf SALDOACUMULADO = 0 Then

                                MsgBox("El Sobregiro  ingresado es menor  al primer saldo diario  del mes , Debe Verificar el Monto Ingresado o Ingresar un nuevo Monto ")

                                GridmesActual.Rows(z).Cells(5).Value() = 0
                                GridmesActual.Rows(z).Cells(0).Style.BackColor = Color.Red
                                GridmesActual.Rows(z).Cells(1).Style.BackColor = Color.Red
                                GridmesActual.Rows(z).Cells(2).Style.BackColor = Color.Red
                                'Saldo diaria capital 
                                GridmesActual.Rows(z).Cells(3).Style.BackColor = Color.Red
                                GridmesActual.Rows(z).Cells(3).Style.ForeColor = Color.Yellow

                                GridmesActual.Rows(z).Cells(4).Style.BackColor = Color.Red
                                GridmesActual.Rows(z).Cells(5).Style.BackColor = Color.Red

                                'toma fila donde se hace el cambio************************ 
                                Gridfilasinsaldo.Rows.Add(GridmesActual.Rows(z).Cells(0).Value(), GridmesActual.Rows(z).Cells(1).Value(), GridmesActual.Rows(z).Cells(2).Value(), GridmesActual.Rows(z).Cells(3).Value(), GridmesActual.Rows(z - 1).Cells(5).Value())
                                '*********************************************************
                                'Me saca de recorrer la grilla 
                                z = TOTALFILAS


                            ElseIf SALDOACUMULADO > 0 Then


                                GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO


                            End If
                        End If


                    ElseIf CONTADOR > 0 Then
                        'MsgBox("CONTADOR MAYOR  0")
                        SALDODIARIO = SALDODIARIO * -1
                        ' MsgBox(SALDODIARIO)

                        SALDOANTERIOR = CDbl(GridmesActual.Rows(z - 1).Cells(5).Value())
                        'MsgBox(SALDOANTERIOR)

                        If SALDODIARIO > SALDOANTERIOR Then
                            MsgBox("El Sobregiro  ingresado es menor  al  saldo diario  del mes , Debe Verificar el Monto Ingresado o  ingresar un nuevo monto  ")

                            GridmesActual.Rows(z).Cells(0).Style.BackColor = Color.Red
                            GridmesActual.Rows(z).Cells(1).Style.BackColor = Color.Red
                            GridmesActual.Rows(z).Cells(2).Style.BackColor = Color.Red
                            'Saldo diaria capital 
                            GridmesActual.Rows(z).Cells(3).Style.BackColor = Color.Red
                            GridmesActual.Rows(z).Cells(3).Style.ForeColor = Color.Yellow

                            GridmesActual.Rows(z).Cells(4).Style.BackColor = Color.Red
                            GridmesActual.Rows(z).Cells(5).Style.BackColor = Color.Red

                            'toma fila donde se hace el cambio************************ 

                            Gridfilasinsaldo.Rows.Add(GridmesActual.Rows(z).Cells(0).Value(), GridmesActual.Rows(z).Cells(1).Value(), GridmesActual.Rows(z).Cells(2).Value(), GridmesActual.Rows(z).Cells(3).Value(), GridmesActual.Rows(z - 1).Cells(5).Value())

                            '*********************************************************




                            z = TOTALFILAS
                            'Vuelve  a dejar el valor en negativo 
                            SALDODIARIO = SALDODIARIO * -1
                        Else
                            SALDOACUMULADO = SALDODIARIO - SALDOANTERIOR


                            If SALDOACUMULADO < 0 Then
                                SALDOACUMULADO = SALDOACUMULADO * -1
                                GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO

                            ElseIf SALDOACUMULADO = 0 Then
                                GridmesActual.Rows(z).Cells(5).Value() = 0
                                GridmesActual.Rows(z).Cells(0).Style.BackColor = Color.Red
                                GridmesActual.Rows(z).Cells(1).Style.BackColor = Color.Red
                                GridmesActual.Rows(z).Cells(2).Style.BackColor = Color.Red
                                'Saldo diaria capital 
                                GridmesActual.Rows(z).Cells(3).Style.BackColor = Color.Red
                                GridmesActual.Rows(z).Cells(3).Style.ForeColor = Color.Yellow

                                GridmesActual.Rows(z).Cells(4).Style.BackColor = Color.Red
                                GridmesActual.Rows(z).Cells(5).Style.BackColor = Color.Red

                                'toma fila donde se hace el cambio************************ 

                                Gridfilasinsaldo.Rows.Add(GridmesActual.Rows(z).Cells(0).Value(), GridmesActual.Rows(z).Cells(1).Value(), GridmesActual.Rows(z).Cells(2).Value(), GridmesActual.Rows(z).Cells(3).Value(), GridmesActual.Rows(z - 1).Cells(5).Value())


                                '*********************************************************


                                'Me saca de recorrer la grilla 
                                z = TOTALFILAS



                            ElseIf SALDOACUMULADO > 0 Then
                                GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO
                            End If






                        End If



                    End If


                ElseIf SALDODIARIO > 0 Then

                    ' MsgBox("entra cuando se suma ")

                    If CONTADOR = 0 Then

                        ' MsgBox("El PRIMER SALDO")
                        'MsgBox("Saldo Diario ver ")
                        'MONTO SOBREGIRO PARA REALZIAR COLCHON 
                        'LINEASOBREGRIO = GridmesActual.Rows(0).Cells(5).Value()
                        'LINEASOBREGRIO
                        'SALDO ACUMULADO ENTRE EL COLCHON Y EL SALDO DE CAPITAL 
                        'MsgBox(SALDODIARIO)


                        SALDOACUMULADO = SALDODIARIO + LINEASOBREGRIO
                        GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO


                    ElseIf CONTADOR > 0 Then
                        'MsgBox("El SEGUNDO  EN ADELANTE  SALDO")

                        SALDOANTERIOR = CDbl(GridmesActual.Rows(z - 1).Cells(5).Value())

                        SALDOACUMULADO = SALDODIARIO + SALDOANTERIOR
                        GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO

                    End If

                End If
                CONTADOR = CONTADOR + 1

            ElseIf GridmesActual.Rows(z).Cells(3).Value().ToString = "" Then

                GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO

            End If

        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        '' Referenciamos la fila actual del control DataGridView.
        ''
        'Dim currentRow As DataGridViewRow = GridmesActual.CurrentRow
        'If (currentRow Is Nothing) Then Return

        '' Referenciamos la celda del tipo DataGridViewComboBoxCell, que
        '' vamos a suponer que es la celda que contiene la columna del
        '' control DataGridView llamada "Column3".
        ''
        'Dim value As String = Convert.ToString(currentRow.Cells("Column1").Value)

        '' Mostramos el valor
        'MessageBox.Show(value)




        Try

            Dim Archivo As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
            ' busca "Hola mundo" en un solo nivel ( SearchTopLevelOnly ) en el directorio c: 
            Archivo = My.Computer.FileSystem.FindInFiles(
                                        "C:\Users\ccampos\Desktop\prueba\SISTEMA RIESGO\SistemaRiesgos",
                                        "_RIESGO_PERFIL",
                                        True,
                                        FileIO.SearchOption.SearchTopLevelOnly)
            ' recorre la lista
            For Each name As String In Archivo
                ' Agrega
                ListBox1.Items.Add(name)
            Next
            ' error
        Catch oe As Exception
            MsgBox(oe.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

End Class