Imports System.Data
Imports System.Data.SqlClient
Public Class frmDisponibilidadRetiroCapital
    Public _tabla29 As DataTable = New DataTable
    Public _TABLA30 As DataTable = New DataTable  'datos mes actual 
    Public _tabla31 As DataTable = New DataTable  'cantidad de lineas de creditos ingresadas en el mes 
    Dim newcol As DataGridViewColumn = New DataGridViewTextBoxColumn  'declaracion sobre giro 
    Dim newcol2 As DataGridViewColumn = New DataGridViewTextBoxColumn 'Saldo Sobre giro 
    Dim newcol3 As DataGridViewColumn = New DataGridViewTextBoxColumn 'Saldo Sobre giro 
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter
    Dim Fechaactual As String = ""

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textdesdemes.TextChanged
        Dim TOTOAL As Double = 0
        TOTOAL = Len(Textdesdemes.Text)
        If TOTOAL = 2 Then
            Textdesdeaño.Focus()
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textdesdeaño.TextChanged
        Dim TOTOAL As Double = 0
        TOTOAL = Len(Textdesdeaño.Text)
        If TOTOAL = 4 Then
            btnConsultarPeriodo.Focus()
        End If
    End Sub

    Private Sub frmDisponibilidadRetiroCapital_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'calculo4()
        'DATOS DATA GRID PARA CONSULTA 
        GroupBoxsaldonegativo.Visible = False
        Dim TOMAFEHCACOMPELTA As String = ""
        Dim TOMAFECHAAÑOMES As String = ""
        GridmesActual.Rows.Add("LINEA SOBREGIRO", "", "", "", "", "")
        _TABLA30.Rows.Clear()
        _TABLA30.Columns.Clear()

        TOMAFEHCACOMPELTA = DateTime.Now().ToShortDateString()  '"16/06/2009"
        TOMAFECHAAÑOMES = Mid(TOMAFEHCACOMPELTA, 7, 10) + Mid(TOMAFEHCACOMPELTA, 4, 2) '201410'

        Textdesdemes.Text = Mid(TOMAFEHCACOMPELTA, 4, 2)
        Textdesdeaño.Text = Mid(TOMAFEHCACOMPELTA, 7, 10)
        'QUITARFILAS()
        'Toma las fechas  del mes completo------ 

        CALCULO1()
        CALCULO2()
        llenagrillalineasobregiro()
        coloreargrilalineasobregiro()
        colorearGridprinciapl()
        CALCULO3()
        ponerpuntos()
        'coloreargrilalineasobregiro()
        'Timer1.Start()

        'BuscarSaldorealfechaactual()
    End Sub

   'Sub Calculos()
    'Dim totalfilas As Integer = 0
    'Dim suma As Integer = 0
    'totalfilas = GridmesActual.RowCount - 1
    ' MsgBox(totalfilas)
    'For Z = 0 To totalfilas
    'If Z = 0 Then
    'MsgBox(GridmesActual.Rows(Z).Cells(4).Value)
    'suma = GridmesActual.Rows(Z).Cells(3).Value
    'GridmesActual.Rows(Z).Cells(0).Value = suma
    'MsgBox(GridmesActual.Rows(Z).Cells(5).Value())
    'ElseIf Z > 0 Then
    'GridmesActual.Rows(Z).Cells(0).Value() = CInt(GridmesActual.Rows(Z).Cells(5).Value()) + CInt(GridmesActual.Rows(Z - 1).Cells(0).Value())
    'MsgBox(GridmesActual.Rows(Z).Cells(1).Value)
    'End If
    'Next
    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        IngresarLineaSobreGiro()
    End Sub

    'Ingresa  la linea de sobre giro  para exista capital  en la cooperativa 
    Sub IngresarLineaSobreGiro()
        Dim fechacompara As String = Trim(Textdesdeaño.Text) + Trim(Textdesdemes.Text)
        Dim TOMAFEHCACOMPELTA As String = ""
        Dim TOMAFECHAAÑOMES As String = ""
        TOMAFEHCACOMPELTA = DateTime.Now().ToShortDateString()  '"16/06/2009"
        TOMAFECHAAÑOMES = Mid(TOMAFEHCACOMPELTA, 7, 10) + Mid(TOMAFEHCACOMPELTA, 4, 2) '201410'
        If Not IsNumeric(Replace(Trim(Textsobregiro.Text), ".", "")) Then
            MsgBox("Debe ingresar un valor numerico")
        ElseIf fechacompara = TOMAFECHAAÑOMES Then
            'REAL SQL CON LA VARIABLE DEL DIA ACTUAL 
            Dim FECHACOMPLETA2 As String = ""
            Dim FECHACOMPLETA3 As String = ""
            Dim FECHABUSCA As String = ""
            Dim LINEASOBREGRIO As Integer = 0
            Dim VALIDAINGRESOSOBREGIRO As String = ""
            Dim ID_TABLA As String = ""
            LINEASOBREGRIO = Textsobregiro.Text
            FECHACOMPLETA2 = DateTime.Now().ToShortDateString()  '"16/06/2009"
            FECHABUSCA = Mid(FECHACOMPLETA2, 7, 10) + Mid(FECHACOMPLETA2, 4, 2)    'VOLVEEEER A DEJAR PARA QUE PEUDA  CAMBIAR  EN EL MIMSO MES  SOLMKANRTE 
            FECHACOMPLETA3 = Mid(FECHACOMPLETA2, 7, 10) + Mid(FECHACOMPLETA2, 4, 2) + Mid(FECHACOMPLETA2, 1, 2)

            'MsgBox(FECHACOMPLETA3)
            'FECHABUSCA ="201406"
            'FECHACOMPLETA3 ="20140601"

            Dim conexiones6 As New CConexion
            conexiones6.conexion()
            Dim command6 As SqlCommand = New SqlCommand("SELECT [LINEA_SOBRE_GIRO] ,ID_TABLA FROM [_RIESGO_CONTROL_CAPITAL] where left(_RIESGO_CONTROL_CAPITAL.FECHA,6) = '" + Trim(FECHABUSCA.ToString) + "' and ES_LINEA = 1 ORDER BY ID_TABLA  ASC", conexiones6._conexion)
            conexiones6.abrir()
            Dim reader6 As SqlDataReader = command6.ExecuteReader()
            If reader6.HasRows Then
                Do While reader6.Read()
                    VALIDAINGRESOSOBREGIRO = reader6(0)
                    ID_TABLA = reader6(1).ToString
                Loop
            Else
            End If
            reader6.Close()

            'MsgBox(VALIDAINGRESOSOBREGIRO)
            'MsgBox(ID_TABLA)

            If VALIDAINGRESOSOBREGIRO = "" Then

                'INGRESO  EN LA TABLA PARA  REALZIAR  CALCULOS 
                ' MsgBox(FECHACOMPLETA2.ToString)
                ' MsgBox(FECHACOMPLETA3.ToString)
                ' MsgBox(LINEASOBREGRIO.ToString)

                Dim conexiones3 As New CConexion
                conexiones3.conexion()                                                                                                                                                                                                                                          'cumplecapitalminimo As String = ""
                _adaptador.InsertCommand = New SqlCommand("INSERT INTO [_RIESGO_CONTROL_CAPITAL]([FECHA],[LINEA_SOBRE_GIRO],ES_LINEA)VALUES('" + Trim(FECHACOMPLETA3.ToString) + "','" + Trim(LINEASOBREGRIO.ToString) + "',1 )", conexiones3._conexion)
                conexiones3.abrir()
                _adaptador.InsertCommand.Connection = conexiones3._conexion
                _adaptador.InsertCommand.ExecuteNonQuery()


                'INGRESO EN TABLA DE REGISTROS DE LINEAS DE CREDITO 
                Dim conexiones5 As New CConexion
                conexiones5.conexion()                                                                                                                                                                                                                                          'cumplecapitalminimo As String = ""
                _adaptador.InsertCommand = New SqlCommand("INSERT INTO [_RIESGO_DETA_CONTROL_CAPITAL] ([FECHA],[LINEA_SOBRE_GIRO],[FILTRO_CAPITAL_GLOBAL])VALUES('" + Trim(FECHACOMPLETA3.ToString) + "','" + Trim(LINEASOBREGRIO.ToString) + "','SI')", conexiones5._conexion)
                conexiones5.abrir()
                _adaptador.InsertCommand.Connection = conexiones5._conexion
                _adaptador.InsertCommand.ExecuteNonQuery()

                MsgBox("LINEA DE SOBRE GIRO INGRESADA CON EXITO")
                QUITARFILAS()
                Textsobregiro.Clear()

            ElseIf VALIDAINGRESOSOBREGIRO <> "" Then

                Dim conexiones60 As New CConexion
                conexiones60.conexion()
                _adaptador.UpdateCommand = New SqlCommand("UPDATE  [_RIESGO_CONTROL_CAPITAL] set [LINEA_SOBRE_GIRO] = '" + Trim(LINEASOBREGRIO.ToString) + "' WHERE ID_TABLA = '" + Trim(ID_TABLA.ToString) + "' ", conexiones60._conexion)
                conexiones60.abrir()
                _adaptador.UpdateCommand.Connection = conexiones60._conexion
                _adaptador.UpdateCommand.ExecuteNonQuery()
                conexiones60.cerrar()

                'Dim totalfilas As Integer = 0
                'totalfilas = Gridfilasinsaldo.RowCount - 1
                'For z = 1 To totalfilas
                'Next
                Dim fechagrid As String = ""
                Dim aportefrid As String = ""
                Dim retiro As String = ""
                Dim saldogrid As String = ""
                Dim saldoacumuladogrid As String = ""
                'MsgBox(Gridfilasinsaldo.Rows(0).Cells(1).Value())

                If IsNothing(Gridfilasinsaldo.Rows(0).Cells(0).Value()) Then

                    fechagrid = FECHACOMPLETA3
                    aportefrid = 0
                    retiro = 0
                    saldogrid = 0
                    saldoacumuladogrid = 0
                Else

                    fechagrid = FECHACOMPLETA3
                    aportefrid = Gridfilasinsaldo.Rows(0).Cells(1).Value().ToString()
                    retiro = Gridfilasinsaldo.Rows(0).Cells(2).Value().ToString()
                    saldogrid = Gridfilasinsaldo.Rows(0).Cells(3).Value().ToString()
                    saldoacumuladogrid = Gridfilasinsaldo.Rows(0).Cells(4).Value().ToString()
                    Gridfilasinsaldo.Rows.RemoveAt(0)


                End If

                Dim conexiones5 As New CConexion
                conexiones5.conexion()
                _adaptador.InsertCommand = New SqlCommand("INSERT INTO [_RIESGO_DETA_CONTROL_CAPITAL] ([FECHA],APORTE,RETIRO,SALDO_CAPITAL,[LINEA_SOBRE_GIRO],SALDO_ACUMULADO,[FILTRO_CAPITAL_GLOBAL])VALUES('" + Trim(fechagrid.ToString) + "','" + aportefrid + "','" + retiro + "','" + saldogrid + "','" + Trim(LINEASOBREGRIO.ToString) + "' ,'" + saldoacumuladogrid + "','SI' )", conexiones5._conexion)
                conexiones5.abrir()
                _adaptador.InsertCommand.Connection = conexiones5._conexion
                _adaptador.InsertCommand.ExecuteNonQuery()

                MsgBox("LINEA DE SOBRE GIRO ACTUALIZADA  CON EXITO ")
                QUITARFILAS()
                Textsobregiro.Clear()

            End If

        ElseIf fechacompara <> TOMAFECHAAÑOMES Then
            MsgBox("Fecha pertenece a un mes anterior . No se permite ingresar Monto a un mes ya cerrado ")

        End If
    End Sub
    Sub QUITARFILAS()
        Dim TOTLAFILAS As Integer = GridmesActual.RowCount - 1
        'MsgBox(TOTLAFILAS)
        GridmesActual.Rows(0).Cells(4).Value() = ""
        GridmesActual.Rows(0).Cells(5).Value() = ""
        Dim Z As Integer = TOTLAFILAS
        Do While Z >= 1
            GridmesActual.Rows.RemoveAt(Z)
            Z = Z - 1
        Loop
    End Sub
    Sub QUITARFILASlineasobregiro()
        Dim TOTLAFILAS As Integer = Gridmeslineas.RowCount - 1
        'MsgBox(TOTLAFILAS)
        ' Gridmeslineas.Rows(0).Cells(4).Value() = ""
        ' Gridmeslineas.Rows(0).Cells(5).Value() = ""
        Dim Z As Integer = TOTLAFILAS
        Do While Z >= 1
            GridmesActual.Rows.RemoveAt(Z)
            Z = Z - 1
        Loop
    End Sub

    Sub CALCULO1()
        GridmesActual.Rows(0).Cells(5).Value() = ""
        GridmesActual.Rows(0).Cells(4).Value() = ""
        QUITARFILAS()



        Dim tomafechacompleta As String = ""
        Dim tomafechaañomes As String = ""
        Dim tomaaño As String = ""
        Dim primerdia As String = ""
        Dim ultimodia As String = ""
        Dim primerdianumerico As Integer = 0
        Dim ultimodianumerico As Integer = 0
        Dim sumatoriadias As Integer = 0

        tomafechaañomes = Trim(Textdesdeaño.Text) + Trim(Textdesdemes.Text)

        _TABLA30.Rows.Clear()
        _TABLA30.Columns.Clear()

        GridmesActual.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        'Toma el primer y ultimo dia  del mes seleccionado 
        Dim conexiones4 As New CConexion
        conexiones4.conexion()
        Dim command4 As SqlCommand = New SqlCommand("SELECT (SELECT CONVERT (VARCHAR(8),DATEADD(MM, DATEDIFF(MM,0,CONVERT(DATETIME,'" + Trim(tomafechaañomes.ToString) + "01')),0),112))AS PRIMERDUA,(SELECT CONVERT (VARCHAR(8),dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0,CONVERT(DATETIME,'" + Trim(tomafechaañomes.ToString) + "01') )+1, 0)),112)) AS ULTIMODIA", conexiones4._conexion)
        conexiones4.abrir()
        Dim reader4 As SqlDataReader = command4.ExecuteReader()
        If reader4.HasRows Then
            Do While reader4.Read()
                primerdia = reader4(0).ToString
                ultimodia = reader4(1).ToString
                primerdianumerico = reader4(0)
                ultimodianumerico = reader4(1)
            Loop
        Else
        End If
        reader4.Close()

        Dim contador As Integer = 0
        GridmesActual.Rows(0).Cells(5).Value() = ""
        GridmesActual.Rows(0).Cells(4).Value() = ""

        For Z = primerdianumerico To ultimodianumerico
            If contador = 0 Then
                sumatoriadias = primerdianumerico
                GridmesActual.Rows.Add(sumatoriadias, "", "", "", "", "")
                contador = contador + 1
            Else
                sumatoriadias = sumatoriadias + 1
                GridmesActual.Rows.Add(sumatoriadias, "", "", "", "", "")
            End If
        Next
        'MsgBox(tomafechaañomes)
        Dim conexiones5 As New CConexion
        conexiones5.conexion()
        Dim command5 As SqlCommand = New SqlCommand("SELECT FECHA,SUM(MONTOAPORTE) AS APORTE ,SUM(MONTORETIRO) AS RETIRO  FROM _CAPITALSOCIAL WHERE  LEFT(_CAPITALSOCIAL.FECHA,6) ='" + Trim(tomafechaañomes) + "' GROUP BY FECHA ORDER BY FECHA  ", conexiones5._conexion)
        conexiones5.abrir()
        Dim reader5 As SqlDataReader = command5.ExecuteReader()
        If reader5.HasRows Then
            Dim z As Integer = 0
            Dim guarda As Integer = 0
            Dim totalfilas As Integer = 0
            ' GridmesActual.Rows.Add("LINEA SOBREGIRO", "", "", "", "")
            Do While reader5.Read()
                'MsgBox(guarda)
                'MsgBox(GridmesActual.Rows(z).Cells(0).Value())
                totalfilas = GridmesActual.Rows.Count - 1
                For z = 1 To totalfilas
                    guarda = reader5(0)
                    'MsgBox(guarda)
                    'MsgBox(GridmesActual.Rows(z).Cells(0).Value())
                    If GridmesActual.Rows(z).Cells(0).Value() = guarda Then
                        'GridmesActual.Rows.Add(reader5(0).ToString, reader5(1).ToString, reader5(2).ToString)
                        'MsgBox(reader5(1))
                        GridmesActual.Rows(z).Cells(1).Value() = CDbl(reader5(1))
                        GridmesActual.Rows(z).Cells(2).Value() = CDbl(reader5(2))
                    Else
                        guarda = reader5(0)
                    End If
                Next
            Loop
        Else
        End If
        reader5.Close()

        'Dim FECHACOMPLETA2 As String = ""
        'Dim FECHACOMPLETA3 As String = ""

        'FECHACOMPLETA2 = DateTime.Now().ToShortDateString()  '"16/06/2009"
        ''FECHABUSCA = Mid(FECHACOMPLETA2, 7, 10) + Mid(FECHACOMPLETA2, 4, 2)    'VOLVEEEER A DEJAR PARA QUE PEUDA  CAMBIAR  EN EL MIMSO MES  SOLMKANRTE 
        'FECHACOMPLETA3 = Mid(FECHACOMPLETA2, 7, 10) + Mid(FECHACOMPLETA2, 4, 2) + Mid(FECHACOMPLETA2, 1, 2)
        'MsgBox(FECHACOMPLETA2)

        'Dim totalfilas As Integer = GridmesActual.RowCount - 1
        'For x = 0 To totalfilas

        '    If Trim(GridmesActual.Rows(x).Cells(0).Value()) = Trim(FECHACOMPLETA2) Then
        '        GridmesActual.Rows(x).Cells(1).Value() = 0
        '        GridmesActual.Rows(x).Cells(2).Value() = 0
        '        GridmesActual.Rows(x).Cells(5).Value() = 60000000
        '        GridmesActual.Rows(x).Cells(5).Value() = 60000000
        '    End If
        'Next


    End Sub



    Sub CALCULO2()

        Dim totalfilas As Integer = 0
        Dim SALDORETIROAPORTE As Integer = 0
        GridmesActual.Rows(0).Cells(4).Value() = Textsobregiro.Text
        totalfilas = GridmesActual.RowCount - 1
        For Z = 1 To totalfilas
            If GridmesActual.Rows(Z).Cells(1).Value().ToString <> "" Then
                SALDORETIROAPORTE = GridmesActual.Rows(Z).Cells(1).Value() - GridmesActual.Rows(Z).Cells(2).Value()
                'MsgBox(SALDORETIROAPORTE)
                GridmesActual.Rows(Z).Cells(3).Value() = SALDORETIROAPORTE


                'SUMA   MONTOAPORTE-MONTORETIRO  PARA LUEGO DEJAR DE COLRO ROJO  LA GRILLA SI EL SALDO ES NEGATIVO 
                If GridmesActual.Rows(Z).Cells(3).Value() < 0 Then
                    GridmesActual.Rows(Z).Cells(3).Style.ForeColor = Color.Red
                End If
            Else
            End If
        Next


    End Sub
    Sub ponerpuntos()

        Dim totalfilas As Integer = GridmesActual.Rows.Count - 1
        Dim tomavalor As String = ""
        '  MsgBox(totalfilas)
        For z = 0 To totalfilas
            '  MsgBox(GridmesActual.Rows(z).Cells(5).Value())

            If IsNothing(GridmesActual.Rows(z).Cells(5).Value()) Then
            Else
                GridmesActual.Rows(z).Cells(5).Value() = frmEvaluarCapital.PuntoX(GridmesActual.Rows(z).Cells(5).Value())
            End If


            If IsNothing(GridmesActual.Rows(z).Cells(4).Value()) Then
            Else
                GridmesActual.Rows(z).Cells(4).Value() = frmEvaluarCapital.PuntoX(GridmesActual.Rows(z).Cells(4).Value())
            End If


            If IsNothing(GridmesActual.Rows(z).Cells(3).Value()) Then
            Else
                GridmesActual.Rows(z).Cells(3).Value() = frmEvaluarCapital.PuntoX(GridmesActual.Rows(z).Cells(3).Value())

            End If


            If IsNothing(GridmesActual.Rows(z).Cells(2).Value()) Then
            Else
                GridmesActual.Rows(z).Cells(2).Value() = frmEvaluarCapital.PuntoX(GridmesActual.Rows(z).Cells(2).Value())

            End If


            If IsNothing(GridmesActual.Rows(z).Cells(1).Value()) Then
            Else
                GridmesActual.Rows(z).Cells(1).Value() = frmEvaluarCapital.PuntoX(GridmesActual.Rows(z).Cells(1).Value())

            End If



        Next

        Dim totalfilas2 As Integer = GridmesActual.Rows.Count - 1
        Dim tomavalor2 As String = ""
        Dim slash As String = "/"
        Dim tomavalor3 As String = ""
        For x = 1 To totalfilas2
            If IsNothing(GridmesActual.Rows(x).Cells(0).Value()) Then

            Else

                '  permiso.Substring(0, 1) = "1"
                tomavalor2 = GridmesActual.Rows(x).Cells(0).Value()
                tomavalor3 = tomavalor2.Substring(6, 2) + slash + tomavalor2.Substring(4, 2) + slash + tomavalor2.Substring(0, 4)
                GridmesActual.Rows(x).Cells(0).Value() = tomavalor3

            End If


        Next

    End Sub

    Sub CALCULO3()
        ' Gridfilasinsaldo.Rows.RemoveAt()
        Dim LINEASOBREGRIO As Integer = 0
        Dim TOMAFECHA As String = ""
        Dim SALDODIARIO As Integer = 0
        Dim SALDODIARIO2 As Integer = 0
        Dim SALDOACUMULADO As Integer = 0
        Dim MOSTRARMENSAJE As String = ""
        Dim TOMAVALORZ As Integer = 0
        Dim SALDOANTERIOR As Integer = 0
        Dim CONTADOR As Integer = 0
        Dim TOTALFILAS As Integer = 0
        'If Textsobregiro.Text = "" Then
        'MsgBox("Debe ingresar un monto para el sobre giro")
        'Else
        'End If
        TOTALFILAS = GridmesActual.Rows.Count - 1
        TOMAFECHA = Trim(Textdesdeaño.Text) + Trim(Textdesdemes.Text)
        'LINEASOBREGRIO = Textsobregiro.Text
        'Verifica  el saldo  Ingresado   como linea de sobvre giro para ese mes 
        Dim conexiones7 As New CConexion
        conexiones7.conexion()
        Dim command7 As SqlCommand = New SqlCommand("SELECT [LINEA_SOBRE_GIRO] FROM [_RIESGO_CONTROL_CAPITAL] where left(_RIESGO_CONTROL_CAPITAL.FECHA,6) = " + TOMAFECHA + " AND  ES_LINEA=1  ", conexiones7._conexion)
        conexiones7.abrir()
        Dim reader7 As SqlDataReader = command7.ExecuteReader()
        If reader7.HasRows Then
            Do While reader7.Read()
                LINEASOBREGRIO = reader7(0)
            Loop
        Else
        End If
        reader7.Close()
        conexiones7.cerrar()

        '-------------------------------------SACAR PRIMER-ULTIMO DIA HABIL DEL MES --------------------------------------------------------------------------------------
        Dim FECHAREAL As String = DateTime.Now().ToShortDateString()  '"16/06/2009"
        Dim TOMAFECHAAÑOMES As String = Trim(Textdesdeaño.Text) + Trim(Textdesdemes.Text)
        Dim PRIMERDIAHABILDELMES As String = ""
        Dim ULTIMODIAHABILDELMES As String = ""
        Dim conexiones77 As New CConexion
        conexiones77.conexion()
        Dim command77 As SqlCommand = New SqlCommand("SET LANGUAGE Español  select min(FECHA), max(FECHA) from (SELECT FECHA , DATENAME(WEEKDAY,_BSC_CALENDARIO.FECHA) AS NOMBREDIA FROM  _BSC_CALENDARIO   where  LEFT(fecha,6)='" + Trim(TOMAFECHAAÑOMES) + "')DERIVEDTBL1 where DERIVEDTBL1.NOMBREDIA<>'Domingo'  AND DERIVEDTBL1.NOMBREDIA <> 'Sábado' AND  FECHA  not in (select FECHA  from [_FESTIVOS])", conexiones77._conexion)
        conexiones77.abrir()
        Dim reader77 As SqlDataReader = command77.ExecuteReader()
        If reader77.HasRows Then
            Do While reader77.Read()
                PRIMERDIAHABILDELMES = reader77(0)
                ULTIMODIAHABILDELMES = reader77(1)
            Loop
        Else
        End If
        reader77.Close()
        '-------------------------------------SACAR PRIMER-ULTIMO DIA HABIL DEL MES --------------------------------------------------------------------------------------

        If LINEASOBREGRIO > 0 Then
            'MsgBox(LINEASOBREGRIO)
            GridmesActual.Rows(0).Cells(5).Value() = ""
            GridmesActual.Rows(0).Cells(4).Value() = ""
            GridmesActual.Rows(0).Cells(5).Value() = LINEASOBREGRIO
            GridmesActual.Rows(0).Cells(4).Value() = LINEASOBREGRIO
            'Recorro Grilla---------------------------------------- 
            For z = 1 To TOTALFILAS
                '  MsgBox(GridmesActual.Rows(z).Cells(3).Value().ToString)
                'MsgBox(GridmesActual.Rows(z).Cells(0).Value().Substring(6, 2))
                'Dim hola As String = ""
                'hola = GridmesActual.Rows(z).Cells(0).Value().Substring(6, 2)
                ' MsgBox(hola)

                If GridmesActual.Rows(z).Cells(3).Value().ToString <> "" Then     '------verifico  que exita  valor  en   el saldo de capital 
                    'MsgBox(GridmesActual.Rows(z).Cells(3).Value().ToString)
                    'MsgBox(PRIMERDIAHABILDELMES)
                    If Int(GridmesActual.Rows(z).Cells(3).Value()) > 0 Then       '------verifica si el saldo diario  es mayor  a cero 
                        SALDODIARIO = Int(GridmesActual.Rows(z).Cells(3).Value()) 'recibo el saldo positivo
                        If Trim(PRIMERDIAHABILDELMES) = Trim(GridmesActual.Rows(z).Cells(0).Value()) Then ' Verifica que si  el dia actual  es el primer dia habil del mes 
                            SALDOACUMULADO = SALDODIARIO + LINEASOBREGRIO             'Resto  la linea  de sobre giro menos el saldo  diario 
                        ElseIf Trim(PRIMERDIAHABILDELMES) <> Trim(GridmesActual.Rows(z).Cells(0).Value()) Then ' Si no es el primer dia habil del mes  entoces de debe sumar  el saldo acumulado 
                            'MsgBox(GridmesActual.Rows(z).Cells(0).Value())
                            'MsgBox(z)
                            If GridmesActual.Rows(z).Cells(0).Value().ToString.Substring(0, 8) = "20170401" Then
                                ' MsgBox("prueba")
                                SALDODIARIO = Int(GridmesActual.Rows(z).Cells(3).Value())
                                SALDOACUMULADO = SALDODIARIO + LINEASOBREGRIO
                                GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO
                                ' GridmesActual.Rows(3).Cells(5).Value() = SALDOACUMULADO
                                'ElseIf GridmesActual.Rows(z).Cells(0).Value().ToString.Substring(0, 8) = "20170402"
                            Else
                                'MsgBox(SALDOACUMULADO)
                                SALDOACUMULADO = SALDODIARIO + SALDOACUMULADO
                            End If
                        End If

                        GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO
                        GroupBoxsaldonegativo.Visible = False



                    ElseIf Int(GridmesActual.Rows(z).Cells(3).Value()) < 0 Then   '------verifica si el saldo diario  es menor  a cero 

                        SALDODIARIO = Int(GridmesActual.Rows(z).Cells(3).Value()) 'recibo el saldo negativo 
                        SALDODIARIO = SALDODIARIO * -1                            ' lo  multiplico * - 1 para volverlo positivo 


                        If Trim(PRIMERDIAHABILDELMES) = Trim(GridmesActual.Rows(z).Cells(0).Value()) Then ' Verifica que si  el dia actual  es el primer dia habil del mes 


                            '  If GridmesActual.Rows(z).Cells(0).Value().ToString.Substring(0, 8) = "20170401" Then
                            'SALDOACUMULADO = SALDODIARIO - LINEASOBREGRIO             'Resto  la linea  de sobre giro menos el saldo  diario 
                            SALDOACUMULADO = SALDODIARIO - Int(GridmesActual.Rows(z - 1).Cells(5).Value())

                            ' ElseIf GridmesActual.Rows(z).Cells(0).Value().ToString.Substring(0, 8) = "20170401" Then
                            ' SALDOACUMULADO = SALDODIARIO - LINEASOBREGRIO

                            '  End If


                        ElseIf Trim(PRIMERDIAHABILDELMES) <> Trim(GridmesActual.Rows(z).Cells(0).Value()) Then




                            SALDOACUMULADO = SALDODIARIO - SALDOACUMULADO        ' Si no es el primer dia habil del mes  entoces de debe restar  el saldo acumulado 



                        End If




                        SALDOACUMULADO = SALDOACUMULADO * -1
                        GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO   'luego  guardo el valor  en la grilla que correpsnode  al saldo  acumulado 

                        If SALDOACUMULADO < 0 Then ' Si el  saldo acumulado  es  negativo   se paralizan todas las solicitudes  de capital 

                            If GridmesActual.Rows(z).Cells(0).Value().ToString.Substring(0, 8) <> "20170413" Then

                                GridmesActual.Rows(z).Cells(5).Style.ForeColor = Color.Yellow
                                GridmesActual.Rows(z).Cells(0).Style.BackColor = Color.Red
                                GridmesActual.Rows(z).Cells(1).Style.BackColor = Color.Red
                                GridmesActual.Rows(z).Cells(2).Style.BackColor = Color.Red
                                GridmesActual.Rows(z).Cells(3).Style.BackColor = Color.Red
                                GridmesActual.Rows(z).Cells(3).Style.ForeColor = Color.Yellow
                                GridmesActual.Rows(z).Cells(4).Style.BackColor = Color.Red
                                GridmesActual.Rows(z).Cells(5).Style.BackColor = Color.Red
                                Gridfilasinsaldo.Rows.Add(GridmesActual.Rows(z).Cells(0).Value(), GridmesActual.Rows(z).Cells(1).Value(), GridmesActual.Rows(z).Cells(2).Value(), GridmesActual.Rows(z).Cells(3).Value(), GridmesActual.Rows(z - 1).Cells(5).Value())



                                Dim FECHACOMPLETA As String = Mid(GridmesActual.Rows(z).Cells(0).Value(), 7, 2) + "/" + Mid(GridmesActual.Rows(z).Cells(0).Value(), 5, 2) + "/" + Mid(GridmesActual.Rows(z).Cells(0).Value(), 1, 4)
                                Labelfechasaldonegativo.Text = FECHACOMPLETA
                                Labelsaldonegativo.Text = frmEvaluarCapital.PuntoX(GridmesActual.Rows(z).Cells(5).Value())
                                GroupBoxsaldonegativo.Visible = True



                                'DEJA LOS SOLICITUDES PENDIENTES PRO FALTA DE CAPITAL EN  LA COPERATIVA (SOLICITUENESTADOPENDIENTE())
                                z = TOTALFILAS
                                ' MsgBox(MensajeDisponibilidadRetiroCapital.textsino.Text)
                                MOSTRARMENSAJE = Trim(MensajeDisponibilidadRetiroCapital.textsino.Text)
                                If Trim(MOSTRARMENSAJE) = "" Then
                                    MensajeDisponibilidadRetiroCapital.Enabled = True
                                    MensajeDisponibilidadRetiroCapital.Visible = True
                                End If
                                If Trim(MOSTRARMENSAJE) = "SI" Then
                                    MensajeDisponibilidadRetiroCapital.Enabled = True
                                    MensajeDisponibilidadRetiroCapital.Visible = True
                                ElseIf Trim(MOSTRARMENSAJE) = "NO" Then
                                    MensajeDisponibilidadRetiroCapital.Enabled = True
                                    MensajeDisponibilidadRetiroCapital.Visible = False
                                End If
                                SOLICITUENESTADOPENDIENTE()

                            ElseIf GridmesActual.Rows(z).Cells(0).Value().ToString.Substring(0, 8) = "20170413" Then

                            End If

                        ElseIf SALDOACUMULADO > 0 Then ' Si el  saldo acumulado  es  positivo   se activan  todas las solicitudes  de capital 
                            SOLICITUENESTADOPENDIENTEACTIVAR()
                            GroupBoxsaldonegativo.Visible = False
                        End If
                        ElseIf Int(GridmesActual.Rows(z).Cells(3).Value()) = 0 Then   '------verifica si el saldo diario  es  cero 
                            SALDODIARIO = Int(GridmesActual.Rows(z).Cells(3).Value())
                            If Trim(PRIMERDIAHABILDELMES) = Trim(GridmesActual.Rows(z).Cells(0).Value()) Then ' Verifica que si  el dia actual  es el primer dia habil del mes 
                                SALDOACUMULADO = SALDODIARIO + LINEASOBREGRIO              'Resto  la linea  de sobre giro menos el saldo  diario 
                            ElseIf Trim(PRIMERDIAHABILDELMES) <> Trim(GridmesActual.Rows(z).Cells(0).Value()) Then
                                SALDOACUMULADO = SALDODIARIO + SALDOACUMULADO
                            End If
                            GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO
                            GroupBoxsaldonegativo.Visible = False 'ya que si el resultado del saldo diria es cero no causa nigun efecto mas que  solo dejar el saldo acumulado 
                        End If

                ElseIf Trim(GridmesActual.Rows(z).Cells(3).Value().ToString) = "" Then

                    'MsgBox()
                    If GridmesActual.Rows(z).Cells(0).Value().ToString.Substring(0, 8) = "20170402" Then
                        'MsgBox("es el dia ")
                        GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO

                    ElseIf GridmesActual.Rows(z).Cells(0).Value().ToString.Substring(0, 8) = "20170414" Or GridmesActual.Rows(z).Cells(0).Value().ToString.Substring(0, 8) = "20170415" Or GridmesActual.Rows(z).Cells(0).Value().ToString.Substring(0, 8) = "20170416" Then

                        GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO


                    End If





                    GroupBoxsaldonegativo.Visible = False
                    ' MsgBox(ULTIMODIAHABILDELMES)
                    ' MsgBox(GridmesActual.Rows(z).Cells(0).Value())
                    If Trim(ULTIMODIAHABILDELMES) = Trim(GridmesActual.Rows(z).Cells(0).Value()) Then 'cuando no existe un saldo entre el aporte  y retiro  y existe una linea de sobre giro se  da por entendio que existe capital 
                        SOLICITUENESTADOPENDIENTEACTIVAR()
                    Else



                    End If

                    End If
            Next

        ElseIf LINEASOBREGRIO = 0 Then
            '  MsgBox("sin linea de sobre giro ")



            MOSTRARMENSAJE = Trim(MensajeDisponibilidadRetiroCapital.textsino.Text)

            If Trim(MOSTRARMENSAJE) = "" Then
                MensajeDisponibilidadRetiroCapital.Enabled = True
                MensajeDisponibilidadRetiroCapital.Visible = True
                MensajeDisponibilidadRetiroCapital.Show()

            End If
            If Trim(MOSTRARMENSAJE) = "SI" Then
                MensajeDisponibilidadRetiroCapital.Enabled = True
                MensajeDisponibilidadRetiroCapital.Visible = True
                MensajeDisponibilidadRetiroCapital.Show()

            ElseIf Trim(MOSTRARMENSAJE) = "NO" Then
                MensajeDisponibilidadRetiroCapital.Enabled = True
                MensajeDisponibilidadRetiroCapital.Visible = False
            End If




        End If

        '--------------------------------------------------------------------------------------------------------------------------------------------------------}
        'If LINEASOBREGRIO <> 0 Then
        '    'MsgBox(LINEASOBREGRIO)
        '    GridmesActual.Rows(0).Cells(5).Value() = ""
        '    GridmesActual.Rows(0).Cells(4).Value() = ""
        '    GridmesActual.Rows(0).Cells(5).Value() = LINEASOBREGRIO
        '    GridmesActual.Rows(0).Cells(4).Value() = LINEASOBREGRIO
        '    For z = 1 To TOTALFILAS
        '        'MsgBox(GridmesActual.Rows(z).Cells(3).Value().ToString)
        '        If GridmesActual.Rows(z).Cells(3).Value().ToString <> "" Then
        '            'TOMA  EL PRIMER SALDO DIARIO DEL DIA 
        '            SALDODIARIO = GridmesActual.Rows(z).Cells(3).Value()
        '            'PREGUNTA SI  EL SALDO DIARIO  ES NEGATIVO 
        '            ' MsgBox(SALDODIARIO)
        '            ' MsgBox(LINEASOBREGRIO)
        '            ' MsgBox(CONTADOR)
        '            If SALDODIARIO < 0 Then
        '                'CONTADOR VERIFICA QUE SEA  EL PRIMER SALDO DEL MES  
        '                If CONTADOR = 0 Then
        '                    'YA SABEMOS QUE ES  EL SALDO ES NEGATIVO  POR LO CUAL LO MULTIPLICAREMOS POR -1 PARA COMPARAR CON LA LINEA DE SOBRE GIRO 
        '                    SALDODIARIO = SALDODIARIO * -1
        '                    ' MsgBox(SALDODIARIO)
        '                    If SALDODIARIO > LINEASOBREGRIO Then
        '                        'MsgBox("saldo diaria mayor a la linena de sobre giro ")
        '                        'MsgBox("El Sobregiro  ingresado es menor  al primer saldo diario  del mes , Debe Verificar el Monto Ingresado ")
        '                        'MsgBox(MensajeDisponibilidadRetiroCapital.textsino)
        '                        SALDOACUMULADO = SALDODIARIO - LINEASOBREGRIO
        '                        SALDOACUMULADO = SALDOACUMULADO * -1
        '                        GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO
        '                        GridmesActual.Rows(z).Cells(5).Style.ForeColor = Color.Yellow
        '                        GridmesActual.Rows(z).Cells(0).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(1).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(2).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(3).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(3).Style.ForeColor = Color.Yellow
        '                        GridmesActual.Rows(z).Cells(4).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(5).Style.BackColor = Color.Red
        '                        'TOMA FILA DONDE EL SALDO  ES NEGATIVO PARA REGISTRARLO 
        '                        Gridfilasinsaldo.Rows.Add(GridmesActual.Rows(z).Cells(0).Value(), GridmesActual.Rows(z).Cells(1).Value(), GridmesActual.Rows(z).Cells(2).Value(), GridmesActual.Rows(z).Cells(3).Value(), GridmesActual.Rows(z - 1).Cells(5).Value())
        '                        'DEJA LOS SOLICITUDES PENDIENTES PRO FALTA DE CAPITAL EN  LA COPERATIVA (SOLICITUENESTADOPENDIENTE())
        '                        z = TOTALFILAS
        '                        MOSTRARMENSAJE = Trim(MensajeDisponibilidadRetiroCapital.textsino.Text)
        '                        If MOSTRARMENSAJE = "" Then
        '                            MensajeDisponibilidadRetiroCapital.Visible = True
        '                        End If
        '                        If MOSTRARMENSAJE = "SI" Then
        '                            MensajeDisponibilidadRetiroCapital.Visible = True
        '                        ElseIf MOSTRARMENSAJE = "NO" Then
        '                            MensajeDisponibilidadRetiroCapital.Visible = False
        '                        End If
        '                        SOLICITUENESTADOPENDIENTE()
        '                        SALDODIARIO = SALDODIARIO * -1
        '                        'SI EL SALDO DIARIO  ES MENOR A LA LINEA DE SOBRE GIRO INGRESADA  
        '                    ElseIf SALDODIARIO < LINEASOBREGRIO Then
        '                        ' MsgBox(SALDOACUMULADO)
        '                        '  MsgBox("sacreblu")
        '                        SALDOACUMULADO = SALDODIARIO - LINEASOBREGRIO
        '                        'Confirmar que la resta sea positiva 
        '                        'If SALDOACUMULADO < 0 Then
        '                        'MsgBox("saldo diario menor al sobre giro ")
        '                        SALDOACUMULADO = SALDOACUMULADO * -1
        '                        GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO
        '                        SOLICITUENESTADOPENDIENTEACTIVAR()
        '                        ' MsgBox("ACTIVA 1")
        '                    ElseIf SALDODIARIO = LINEASOBREGRIO Then
        '                        ' MsgBox("El Sobregiro  y el saldo diario son iguales  ")
        '                        GridmesActual.Rows(z).Cells(5).Value() = 0
        '                        GridmesActual.Rows(z).Cells(5).Style.ForeColor = Color.Yellow
        '                        GridmesActual.Rows(z).Cells(0).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(1).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(2).Style.BackColor = Color.Red
        '                        ' Saldo diaria capital 
        '                        GridmesActual.Rows(z).Cells(3).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(3).Style.ForeColor = Color.Yellow
        '                        GridmesActual.Rows(z).Cells(4).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(5).Style.BackColor = Color.Red
        '                        'toma fila donde se hace el cambio************************ 
        '                        Gridfilasinsaldo.Rows.Add(GridmesActual.Rows(z).Cells(0).Value(), GridmesActual.Rows(z).Cells(1).Value(), GridmesActual.Rows(z).Cells(2).Value(), GridmesActual.Rows(z).Cells(3).Value(), GridmesActual.Rows(z - 1).Cells(5).Value())
        '                        GridmesActual.Rows(z).Cells(5).Value() = 0
        '                        z = TOTALFILAS
        '                        MOSTRARMENSAJE = Trim(MensajeDisponibilidadRetiroCapital.textsino.Text)
        '                        If MOSTRARMENSAJE = "" Then
        '                            MensajeDisponibilidadRetiroCapital.Visible = True
        '                        End If
        '                        If MOSTRARMENSAJE = "SI" Then
        '                            MensajeDisponibilidadRetiroCapital.Visible = True
        '                        ElseIf MOSTRARMENSAJE = "NO" Then
        '                            MensajeDisponibilidadRetiroCapital.Visible = False
        '                        End If
        '                        SOLICITUENESTADOPENDIENTE()
        '                    End If
        '                ElseIf CONTADOR > 0 Then
        '                    'MsgBox("menor a cero ")
        '                    SALDODIARIO = SALDODIARIO * -1
        '                    'MsgBox(SALDODIARIO)
        '                    SALDOANTERIOR = CDbl(GridmesActual.Rows(z - 1).Cells(5).Value())
        '                    'Activas las solitudes 
        '                    'SOLICITUENESTADOPENDIENTEACTIVAR()
        '                    'MsgBox(SALDOANTERIOR)
        '                    'CAMBIO IRGENTE POR LICENCIA REALIZADOS DESDE LA CASA CRECION DE IF CUANDO   LA GRILLA ENTREGA UN VALOR EN BLANCO SE TRNASFROMA EN CERO
        '                    If SALDODIARIO > SALDOANTERIOR Then
        '                        'Deja las solicitudes pendientes 
        '                        GridmesActual.Rows(z).Cells(0).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(1).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(2).Style.BackColor = Color.Red
        '                        'Saldo diaria capital 
        '                        GridmesActual.Rows(z).Cells(3).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(3).Style.ForeColor = Color.Yellow
        '                        GridmesActual.Rows(z).Cells(4).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(5).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(5).Style.ForeColor = Color.Yellow
        '                        'toma fila donde se hace el cambio************************ 
        '                        Gridfilasinsaldo.Rows.Add(GridmesActual.Rows(z).Cells(0).Value(), GridmesActual.Rows(z).Cells(1).Value(), GridmesActual.Rows(z).Cells(2).Value(), GridmesActual.Rows(z).Cells(3).Value(), GridmesActual.Rows(z - 1).Cells(5).Value())
        '                        '*********************************************************
        '                        SALDOACUMULADO = SALDODIARIO - SALDOACUMULADO
        '                        SALDOACUMULADO = SALDOACUMULADO * -1
        '                        SALDODIARIO = SALDODIARIO * -1
        '                        GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO
        '                        'MsgBox(SALDODIARIO)
        '                        z = TOTALFILAS
        '                        'Vuelve  a dejar el valor en negativo 
        '                        MOSTRARMENSAJE = Trim(MensajeDisponibilidadRetiroCapital.textsino.Text)
        '                        If MOSTRARMENSAJE = "" Then
        '                            MensajeDisponibilidadRetiroCapital.Visible = True
        '                        End If
        '                        If MOSTRARMENSAJE = "SI" Then
        '                            MensajeDisponibilidadRetiroCapital.Visible = True
        '                        ElseIf MOSTRARMENSAJE = "NO" Then
        '                            MensajeDisponibilidadRetiroCapital.Visible = False
        '                        End If
        '                        'SOLICITUD PENDIENTE 
        '                        SOLICITUENESTADOPENDIENTE()

        '                    ElseIf SALDODIARIO < SALDOANTERIOR Then
        '                        SALDOACUMULADO = SALDODIARIO - SALDOANTERIOR
        '                        'activa solicitudes -----------------------
        '                        SOLICITUENESTADOPENDIENTEACTIVAR()
        '                        ' MsgBox("ACTIVA 2")
        '                        If SALDOACUMULADO < 0 Then
        '                            SALDOACUMULADO = SALDOACUMULADO * -1
        '                            GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO
        '                            'activa solicitudes-------------------- 
        '                            SOLICITUENESTADOPENDIENTEACTIVAR()
        '                            'MsgBox("ACTIVA 3")
        '                        End If
        '                    End If
        '                End If
        '            ElseIf SALDODIARIO > 0 Then
        '                'MsgBox(SALDODIARIO)
        '                If CONTADOR = 0 Then
        '                    SALDOACUMULADO = SALDODIARIO + LINEASOBREGRIO
        '                    GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO
        '                    'MsgBox(SALDOACUMULADO)
        '                    'ACTIVA
        '                    SOLICITUENESTADOPENDIENTEACTIVAR()
        '                    'MsgBox("ACTIVA 4")

        '                ElseIf CONTADOR > 0 Then

        '                    If Trim(GridmesActual.Rows(z - 1).Cells(5).Value()) = "" Then
        '                        GridmesActual.Rows(z - 1).Cells(5).Value() = 0
        '                        SALDOANTERIOR = 0
        '                        SALDOACUMULADO = SALDODIARIO + SALDOANTERIOR
        '                        GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO
        '                    Else
        '                        SALDOANTERIOR = CDbl(GridmesActual.Rows(z - 1).Cells(5).Value())
        '                        SALDOACUMULADO = SALDODIARIO + SALDOANTERIOR
        '                        GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO
        '                        'ACTIVA
        '                        SOLICITUENESTADOPENDIENTEACTIVAR()
        '                        'MsgBox("ACTIVA 5")
        '                    End If
        '                End If

        '            ElseIf SALDODIARIO = 0 And GridmesActual.Rows(z).Cells(1).Value() = 0 And GridmesActual.Rows(z).Cells(2).Value() = 0 Then
        '                'MsgBox("que sucede ")
        '                'MsgBox(GridmesActual.Rows(z).Cells(5).Value())
        '                Dim LINEASOBREGIRO As Double = 0
        '                'MsgBox(GridmesActual.Rows(0).Cells(4).Value())
        '                'If Trim(GridmesActual.Rows(z).Cells(1).Value()) = "" Then
        '                'GridmesActual.Rows(z).Cells(5).Value() = GridmesActual.Rows(0).Cells(4).Value()
        '                'Else
        '                GridmesActual.Rows(z).Cells(5).Value() = GridmesActual.Rows(z - 1).Cells(5).Value()
        '                'End If
        '                'MsgBox(GridmesActual.Rows(z).Cells(5).Value())
        '                'GridmesActual.Rows(z).Cells(5).Value() = CDbl(GridmesActual.Rows(z - 1).Cells(5).Value()) - CDbl(GridmesActual.Rows(z).Cells(3).Value())
        '                'MsgBox(GridmesActual.Rows(z).Cells(5).Value())
        '            End If
        '            CONTADOR = CONTADOR + 1
        '        ElseIf GridmesActual.Rows(z).Cells(3).Value().ToString = "" Then
        '            'MsgBox(SALDOACUMULADO)
        '            GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO
        '            'ACTIVA
        '            'SOLICITUENESTADOPENDIENTEACTIVAR()
        '        End If
        '    Next

        '    Dim FECHACOMPLETA As String = ""
        '    Dim FECHACOMPLETA2 As String = ""
        '    Dim AÑO As String = ""
        '    Dim MES As String = ""
        '    Dim DIA As String = ""
        '    FECHACOMPLETA = DateTime.Now().ToShortDateString()  '"16/06/2009"
        '    AÑO = Mid(FECHACOMPLETA, 7, 10)
        '    MES = Mid(FECHACOMPLETA, 4, 2)
        '    DIA = Mid(FECHACOMPLETA, 1, 2)
        '    FECHACOMPLETA2 = Mid(FECHACOMPLETA, 7, 10) + Mid(FECHACOMPLETA, 4, 2) + Mid(FECHACOMPLETA, 1, 2)
        '    Dim FECHALENASOBREGIRO As String = ""
        '    Dim MONTOLINEASOBREGIRO As String = ""
        '    Dim IDtabla As String = ""
        '    'REAL SQL CON LA VARIABLE DEL DIA ACTUAL   
        '    'Dim conexiones4 As New CConexion
        '    'conexiones4.conexion()                                                                                                                                                                                                                                          'cumplecapitalminimo As String = ""
        '    ''Dim cumpleavalsinmora As String = ""
        '    '_adaptador.InsertCommand = New SqlCommand("INSERT INTO [_RIESGO_CONTROL_CAPITAL]([FECHA],[LINEA_SOBRE_GIRO])VALUES('" + Trim(FECHACOMPLETA2.ToString) + "','" + Trim(LINEASOBREGRIO) + "' )", conexiones4._conexion)
        '    'conexiones4.abrir()
        '    '_adaptador.InsertCommand.Connection = conexiones4._conexion
        '    '_adaptador.InsertCommand.ExecuteNonQuery()
        '    'MsgBox("LINEA DE SOBRE GIRO INGRESADA CON EXITO ")
        '    ' PARA UNO ELEGIR MES CUALKIERA PARA EL INGRESO  DE LA LINEA DE CREDIOT 
        '    'Dim conexiones4 As New CConexion
        '    'conexiones4.conexion()                                                                                                                                                                                                                                          'cumplecapitalminimo As String = ""
        '    ''Dim cumpleavalsinmora As String = ""
        '    '_adaptador.InsertCommand = New SqlCommand("INSERT INTO [_RIESGO_CONTROL_CAPITAL]([FECHA],[LINEA_SOBRE_GIRO])VALUES('20141201','" + Trim(LINEASOBREGRIO) + "' )", conexiones4._conexion)
        '    'conexiones4.abrir()
        '    '_adaptador.InsertCommand.Connection = conexiones4._conexion
        '    '_adaptador.InsertCommand.ExecuteNonQuery()
        '    'MsgBox("LINEA DE SOBRE GIRO INGRESADA CON EXITO ")
        '    _tabla31.Rows.Clear()
        '    _tabla31.Columns.Clear()
        '    Dim conexiones5 As New CConexion
        '    conexiones5.conexion()
        '    _adaptador.SelectCommand = New SqlCommand(" SELECT [FECHA],[LINEA_SOBRE_GIRO] ,[ID_TABLA] FROM  [_RIESGO_DETA_CONTROL_CAPITAL] WHERE left(_RIESGO_DETA_CONTROL_CAPITAL.FECHA,6) = '" + TOMAFECHA + "'  ORDER BY ID_TABLA DESC ", conexiones5._conexion)
        '    conexiones5.abrir()
        '    _adaptador.Fill(_tabla31)
        '    Gridmeslineas.DataSource = _tabla31
        '    conexiones5.cerrar()
        'ElseIf LINEASOBREGRIO = 0 Then
        '    ' MsgBox("LINEA  DE SOBRE GIRO = 0 ")
        '    GridmesActual.Rows(0).Cells(5).Value() = LINEASOBREGRIO
        '    GridmesActual.Rows(0).Cells(4).Value() = LINEASOBREGRIO
        '    TOTALFILAS = GridmesActual.Rows.Count - 1
        '    For z = 1 To TOTALFILAS
        '        If GridmesActual.Rows(z).Cells(3).Value().ToString <> "" Then
        '            SALDODIARIO = GridmesActual.Rows(z).Cells(3).Value()
        '            ' MsgBox(SALDOACUMULADO)
        '            ' MsgBox(SALDODIARIO)
        '            If CONTADOR = 0 Then
        '                'PRIMERA LINEA DEL GRID PRIMER DIA DEL MES 
        '                If SALDODIARIO < 0 Then
        '                    'SE CONSULTA SI SU SALDO DIARIO ES NEGATIVO Y SE INGRESA  LA RESTA  DEL SALDO DEL DIA CON LA LINEA DE SOBRE GIRO EXISTENTE  Y SE ALMENCENA  
        '                    SALDOACUMULADO = (SALDODIARIO - LINEASOBREGRIO)
        '                    GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO
        '                    'COLOREA FILA COMPLETA DONDE  EL SALDO ES NEGATIVO 
        '                    GridmesActual.Rows(z).Cells(0).Style.BackColor = Color.Red
        '                    GridmesActual.Rows(z).Cells(1).Style.BackColor = Color.Red
        '                    GridmesActual.Rows(z).Cells(2).Style.BackColor = Color.Red
        '                    GridmesActual.Rows(z).Cells(3).Style.BackColor = Color.Red
        '                    GridmesActual.Rows(z).Cells(3).Style.ForeColor = Color.Yellow
        '                    GridmesActual.Rows(z).Cells(4).Style.BackColor = Color.Red
        '                    GridmesActual.Rows(z).Cells(5).Style.BackColor = Color.Red
        '                    GridmesActual.Rows(z).Cells(5).Style.ForeColor = Color.Yellow
        '                    z = TOTALFILAS
        '                    ' MsgBox("El Sobregiro  ingresado es menor  al  saldo diario  del mes , Debe Verificar el Monto Ingresado o  ingresar un nuevo monto  ")
        '                    MOSTRARMENSAJE = Trim(MensajeDisponibilidadRetiroCapital.textsino.Text)
        '                    If MOSTRARMENSAJE = "" Then
        '                        MensajeDisponibilidadRetiroCapital.Visible = True
        '                    End If
        '                    If MOSTRARMENSAJE = "SI" Then
        '                        MensajeDisponibilidadRetiroCapital.Visible = True
        '                    ElseIf MOSTRARMENSAJE = "NO" Then
        '                        MensajeDisponibilidadRetiroCapital.Visible = False
        '                    End If
        '                    'MsgBox(MOSTRARMENSAJE)
        '                    SOLICITUENESTADOPENDIENTE()
        '                ElseIf SALDODIARIO > 0 Then
        '                    'SE CONSULTA SI SU SALDO DIARIO ES POSITIVO  LA SUMA DEL SALDO DEL DIA CON LA LINEA DE SOBRE GIRO EXISTENTE  Y SE ALMENCENA  
        '                    'MsgBox("major a cero el saldo diario ")
        '                    SALDOACUMULADO = (SALDODIARIO + LINEASOBREGRIO)
        '                    GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO
        '                    SOLICITUENESTADOPENDIENTEACTIVAR()
        '                    'Saldo diario  es igual  acero = 0 
        '                ElseIf SALDODIARIO = 0 Then
        '                    'SE CONSULTA SI SU SALDO DIARIO ES POSITIVO  LA SUMA DEL SALDO DEL DIA CON LA LINEA DE SOBRE GIRO EXISTENTE  Y SE ALMENCENA  
        '                    ' MsgBox("major a cero el saldo diario ")
        '                    SALDOACUMULADO = (SALDODIARIO + LINEASOBREGRIO)
        '                    GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO
        '                    'SOLICITUENESTADOPENDIENTEACTIVAR()
        '                End If
        '            ElseIf CONTADOR > 0 Then
        '                'VERIFICA QUE YA NO ESTEMOS EN LA LINEA DEL PRIMER DIA DEL MES DE MOVIMIENTO 
        '                SALDOANTERIOR = CDbl(GridmesActual.Rows(z - 1).Cells(5).Value())
        '                If SALDODIARIO < 0 Then
        '                    'VERIFICA  SI EL SALDO DIARIO ES NEGATIVO 
        '                    'SI EL SALDO ES NEGATIVO LO TRANSFORMO EN POSITIVO PARA REALIZAR  RESTA CORRECTA 
        '                    SALDODIARIO = SALDODIARIO * -1
        '                    'REALIZO  LA RESTA DEL SALDO DIARIO MENOS EL SALDO ANTERIOR  DE LA LINEA DE SOBRE GIRO  
        '                    If SALDODIARIO > SALDOANTERIOR Then
        '                        'POSITIVO  ACTIVA 
        '                        SALDOACUMULADO = SALDODIARIO - SALDOANTERIOR
        '                        SALDOACUMULADO = SALDOACUMULADO * -1
        '                        GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO
        '                        GridmesActual.Rows(z).Cells(0).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(1).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(2).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(3).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(3).Style.ForeColor = Color.Yellow
        '                        GridmesActual.Rows(z).Cells(4).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(5).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(5).Style.ForeColor = Color.Yellow
        '                        z = TOTALFILAS
        '                        MOSTRARMENSAJE = Trim(MensajeDisponibilidadRetiroCapital.textsino.Text)
        '                        If MOSTRARMENSAJE = "" Then
        '                            MensajeDisponibilidadRetiroCapital.Visible = True
        '                        End If
        '                        If MOSTRARMENSAJE = "SI" Then
        '                            MensajeDisponibilidadRetiroCapital.Visible = True
        '                        ElseIf MOSTRARMENSAJE = "NO" Then
        '                            MensajeDisponibilidadRetiroCapital.Visible = False
        '                        End If
        '                        SOLICITUENESTADOPENDIENTE()
        '                    ElseIf SALDODIARIO < SALDOANTERIOR Then
        '                        SALDOACUMULADO = SALDODIARIO - SALDOANTERIOR
        '                        SALDOACUMULADO = SALDOACUMULADO * -1
        '                        GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO
        '                        SOLICITUENESTADOPENDIENTEACTIVAR()
        '                    ElseIf SALDODIARIO = SALDOANTERIOR Then
        '                        SALDOACUMULADO = SALDODIARIO - SALDOANTERIOR
        '                        GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO
        '                        GridmesActual.Rows(z).Cells(0).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(1).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(2).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(3).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(3).Style.ForeColor = Color.Yellow
        '                        GridmesActual.Rows(z).Cells(4).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(5).Style.BackColor = Color.Red
        '                        GridmesActual.Rows(z).Cells(5).Style.ForeColor = Color.Yellow
        '                        z = TOTALFILAS
        '                        MOSTRARMENSAJE = Trim(MensajeDisponibilidadRetiroCapital.textsino.Text)
        '                        If MOSTRARMENSAJE = "" Then
        '                            MensajeDisponibilidadRetiroCapital.Visible = True
        '                        End If
        '                        If MOSTRARMENSAJE = "SI" Then
        '                            MensajeDisponibilidadRetiroCapital.Visible = True
        '                        ElseIf MOSTRARMENSAJE = "NO" Then
        '                            MensajeDisponibilidadRetiroCapital.Visible = False
        '                        End If
        '                        SOLICITUENESTADOPENDIENTE()
        '                    End If
        '                    'SE GUARDA EN LA FILA CORRESPONDIENTE AL NUEVO SALDO DE LA LINEA DE SOBRE GIRO 
        '                    'GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO
        '                ElseIf SALDODIARIO > 0 Then
        '                    SALDOACUMULADO = (SALDODIARIO + SALDOANTERIOR)
        '                    GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO
        '                    SOLICITUENESTADOPENDIENTEACTIVAR()
        '                End If
        '            End If 'If CONTADOR 
        '            CONTADOR = CONTADOR + 1
        '        ElseIf GridmesActual.Rows(z).Cells(3).Value().ToString = "" Then
        '            GridmesActual.Rows(z).Cells(5).Value() = SALDOACUMULADO
        '        End If
        '    Next
        '    'MessageBox.Show("Los montos concuerdan  esta seguro de realizar indexacion", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '    'MsgBox("No Existe linea de sobre giro ingresada  en el mes ; Porfavor Ingresar Linea de Sobregiro")
        'End If
        '--------------------------------------------------------------------------------------------------------------------------------------------------------}
        'limpio grilla  cuando no existen aporte y retiros  limpio columna de saldo por sobre giro 

        Dim totalfilas2 As Integer = 0
        totalfilas2 = GridmesActual.RowCount - 1
        For z = 1 To totalfilas2
            'MsgBox(GridmesActual.Rows(z).Cells(1).Value())
            If GridmesActual.Rows(z).Cells(1).Value().ToString() = "" And GridmesActual.Rows(z).Cells(2).Value().ToString() = "" Then

                If GridmesActual.Rows(z).Cells(0).Value().ToString.Substring(0, 8) = "20170402" Then

                ElseIf GridmesActual.Rows(z).Cells(0).Value().ToString.Substring(0, 8) = "20170414" Or GridmesActual.Rows(z).Cells(0).Value().ToString.Substring(0, 8) = "20170415" Or GridmesActual.Rows(z).Cells(0).Value().ToString.Substring(0, 8) = "20170416" Then

                Else
                    GridmesActual.Rows(z).Cells(5).Value() = ""
                End If




            End If

        Next



    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CALCULO3()
    End Sub

    Private Sub Textsobregiro_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Textsobregiro.KeyUp
        Textsobregiro.Text = frmEvaluarCapital.PuntoX(Textsobregiro.Text)
        Textsobregiro.Select(Textsobregiro.Text.Length, 0)
    End Sub

    Private Sub Textsobregiro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textsobregiro.TextChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarPeriodo.Click

        'DATOS DATA GRID PARA CONSULTA------------------------------- 
        GroupBoxsaldonegativo.Visible = False
        GridmesActual.Rows.Add("LINEA SOBREGIRO", "", "", "", "", "")
        _TABLA30.Rows.Clear()
        _TABLA30.Columns.Clear()
        Gridfilasinsaldo.Rows.Clear()
        If Textdesdemes.Text <> "" And Textdesdeaño.Text <> "" Then
            CALCULO1()
            CALCULO2()
            llenagrillalineasobregiro()
            coloreargrilalineasobregiro()
            colorearGridprinciapl()
            CALCULO3()
            ponerpuntos()
        ElseIf Textdesdemes.Text = "" Or Textdesdeaño.Text = "" Then
            MsgBox("Debe Ingresar Mes y Año para realizar  consulta ")
        End If
        'DATOS DATA GRID PARA CONSULTA------------------------------- 

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'segundos 
        Timer1.Interval = 8000
        Dim fechacompara As String = Trim(Textdesdeaño.Text) + Trim(Textdesdemes.Text)
        Dim TOMAFEHCACOMPELTA As String = ""
        Dim TOMAFECHAAÑOMES As String = ""
        TOMAFEHCACOMPELTA = DateTime.Now().ToShortDateString()  '"16/06/2009"
        TOMAFECHAAÑOMES = Mid(TOMAFEHCACOMPELTA, 7, 10) + Mid(TOMAFEHCACOMPELTA, 4, 2) '201410'
        'MsgBox(fechacompara)

        If fechacompara = TOMAFECHAAÑOMES Then
            GridmesActual.Rows.Add("LINEA SOBREGIRO", "", "", "", "", "")
            _TABLA30.Rows.Clear()
            _TABLA30.Columns.Clear()
            'QUITARFILAS()
         
            CALCULO1()
            CALCULO2()
            'llenagrillalineasobregiro()
            coloreargrilalineasobregiro()
            colorearGridprinciapl()
            CALCULO3()
            'CALCULO4()
            ponerpuntos()
          
            'MsgBox("corresponde ")
        End If
        'MsgBox(" no corresponde ")

    End Sub




    Sub CALCULO4()
        'ACTUALIZA LA TABLA CONTROL CAPITAL  LA CUAL VE EL SALDO DE CAPITAL QUE SE TIENE   este metodo debe estar al principio  del sisetma en el frm principal  para luego completarlo con un procedmiento almeacenado 
        'Dim TOMAFEHCACOMPELTA As String = ""
        'Dim TOMAFECHAAÑOMESDIA As String = ""
        'TOMAFEHCACOMPELTA = DateTime.Now().ToShortDateString()  '"16/06/2009"
        'TOMAFECHAAÑOMESDIA = Mid(TOMAFEHCACOMPELTA, 7, 10) + Mid(TOMAFEHCACOMPELTA, 4, 2) + Mid(TOMAFEHCACOMPELTA, 1, 2) '201410'
        'Dim Validadia As String = ""
        'Dim id_tabla As String = ""

        ''MsgBox(TOMAFECHAAÑOMES)
        'Dim conexiones7 As New CConexion
        'conexiones7.conexion()
        'Dim command7 As SqlCommand = New SqlCommand(" select fecha ,id_tabla from [_RIESGO_CONTROL_CAPITAL]  where FECHA =" + TOMAFECHAAÑOMESDIA + " and ES_LINEA = 0 ", conexiones7._conexion)
        'conexiones7.abrir()
        'Dim reader7 As SqlDataReader = command7.ExecuteReader()
        'If reader7.HasRows Then
        '    Do While reader7.Read()
        '        Validadia = reader7(0)
        '        id_tabla = reader7(0)
        '    Loop
        'Else
        'End If
        'reader7.Close()

        '' MsgBox(Validadia)
        'If Validadia = "" Then

        '    'MsgBox("inserta")
        '    Dim conexiones4 As New CConexion
        '    conexiones4.conexion()
        '    _adaptador.InsertCommand = New SqlCommand("INSERT INTO _RIESGO_CONTROL_CAPITAL (FECHA,RETIRO,APORTE,SALDO_CAPITAL)SELECT [FECHA], SUM(MONTORETIRO) AS [RETIRO], SUM(MONTOAPORTE) AS [APORTE] , SUM(MONTOAPORTE - MONTORETIRO) AS [SALDO_CAPITAL]FROM _CAPITALSOCIAL  where fecha  =" + TOMAFECHAAÑOMESDIA + " GROUP BY FECHA ORDER BY FECHA ", conexiones4._conexion)
        '    conexiones4.abrir()
        '    _adaptador.InsertCommand.Connection = conexiones4._conexion
        '    _adaptador.InsertCommand.ExecuteNonQuery()
        '    'MsgBox("SOLICITUD DE GIRO DE CAPITAL INGRESADA")
        '    'INSERT INTO _RIESGO_CONTROL_CAPITAL (FECHA,RETIRO,APORTE,SALDO_CAPITAL)SELECT [FECHA], SUM(MONTORETIRO) AS [RETIRO], SUM(MONTOAPORTE) AS [APORTE] , SUM(MONTOAPORTE - MONTORETIRO) AS [SALDO_CAPITAL]FROM _CAPITALSOCIAL  where fecha  ='20141201' GROUP BY FECHA ORDER BY FECHA 
        'Else

        '    'MsgBox("actualzia")
        '    Dim conexiones60 As New CConexion
        '    conexiones60.conexion()
        '    _adaptador.UpdateCommand = New SqlCommand("UPDATE [_RIESGO_CONTROL_CAPITAL]  set RETIRO = (SELECT  SUM(MONTORETIRO) AS [RETIRO]  FROM _CAPITALSOCIAL   where fecha  ='" + Trim(TOMAFECHAAÑOMESDIA) + "' GROUP BY FECHA),APORTE =(SELECT SUM(MONTOAPORTE) AS [APORTE]  FROM  _CAPITALSOCIAL where fecha  ='" + Trim(TOMAFECHAAÑOMESDIA) + "' GROUP BY FECHA) ,SALDO_CAPITAL =(SELECT  SUM(MONTOAPORTE - MONTORETIRO) AS [SALDO_CAPITAL] FROM _CAPITALSOCIAL where fecha  ='" + Trim(TOMAFECHAAÑOMESDIA) + "' GROUP BY FECHA) WHERE ID_TABLA ='" + Trim(id_tabla) + "'", conexiones60._conexion)
        '    conexiones60.abrir()
        '    _adaptador.UpdateCommand.Connection = conexiones60._conexion
        '    _adaptador.UpdateCommand.ExecuteNonQuery()
        '    conexiones60.cerrar()
        'End If
    End Sub


    Sub SOLICITUENESTADOPENDIENTE()


        Dim conexiones60 As New CConexion
        conexiones60.conexion()
        _adaptador.UpdateCommand = New SqlCommand("UPDATE [_RIESGO_SOLICITUD_GIRO_CAPITAL] SET  ESTADO_SOLICITUD2 = 0, [FILTRO_CAPITAL_GLOBAL]='NO' WHERE ESTADO_SOLICITUD<>'PAGADO' AND ESTADO_SOLICITUD<>'RECONSIDERACIÓN'and ESTADO_SOLICITUD<>'ANULADA' and estado_solicitud <>'RECHAZADA' and estado_solicitud3<>1", conexiones60._conexion)
        conexiones60.abrir()
        _adaptador.UpdateCommand.Connection = conexiones60._conexion
        _adaptador.UpdateCommand.ExecuteNonQuery()
        conexiones60.cerrar()

        Dim conexiones61 As New CConexion
        conexiones61.conexion()
        _adaptador.UpdateCommand = New SqlCommand(" Update   [_RIESGO_DETA_CONTROL_CAPITAL] SET [FILTRO_CAPITAL_GLOBAL]  ='NO'  WHERE ID_TABLA=(SELECT MAX(ID_TABLA) FROM  [_RIESGO_DETA_CONTROL_CAPITAL] ) ", conexiones61._conexion)
        conexiones61.abrir()
        _adaptador.UpdateCommand.Connection = conexiones61._conexion
        _adaptador.UpdateCommand.ExecuteNonQuery()
        conexiones61.cerrar()


    End Sub

    Sub SOLICITUENESTADOPENDIENTEACTIVAR()
        'MsgBox("caigo2")
        'SQL ACTUALIZA   LO ESTADOS DE LA SOLICITUDES  PARA QUE SEAN CANCELADA DONDE EXISTE CAPITAL
        Dim conexiones60 As New CConexion
        conexiones60.conexion()
        _adaptador.UpdateCommand = New SqlCommand("UPDATE [_RIESGO_SOLICITUD_GIRO_CAPITAL]SET  ESTADO_SOLICITUD2 = 1 , [FILTRO_CAPITAL_GLOBAL]='SI' WHERE ESTADO_SOLICITUD<>'PAGADO' and ESTADO_SOLICITUD<>'ANULADA' and ESTADO_SOLICITUD<>'PENDIENTE'", conexiones60._conexion)
        conexiones60.abrir()
        _adaptador.UpdateCommand.Connection = conexiones60._conexion
        _adaptador.UpdateCommand.ExecuteNonQuery()
        conexiones60.cerrar()



        'SQL ACTUALIZA   LA TABLA  QUE LLEVA EL CONTROL  DEL CAPITAL 
        Dim conexiones61 As New CConexion
        conexiones61.conexion()
        _adaptador.UpdateCommand = New SqlCommand(" Update [_RIESGO_DETA_CONTROL_CAPITAL] SET [FILTRO_CAPITAL_GLOBAL]  ='SI'  WHERE ID_TABLA=(SELECT MAX(ID_TABLA) FROM  [_RIESGO_DETA_CONTROL_CAPITAL] ) ", conexiones61._conexion)
        conexiones61.abrir()
        _adaptador.UpdateCommand.Connection = conexiones61._conexion
        _adaptador.UpdateCommand.ExecuteNonQuery()
        conexiones61.cerrar()





    End Sub
    Sub BuscarSaldorealfechaactual()
        Dim TOMAFEHCACOMPELTA As String = ""
        Dim TOMAFECHAAÑOMESDIA As String = ""
        TOMAFEHCACOMPELTA = DateTime.Now().ToShortDateString()  '"16/06/2009"
        TOMAFECHAAÑOMESDIA = Mid(TOMAFEHCACOMPELTA, 7, 10) + Mid(TOMAFEHCACOMPELTA, 4, 2) + Mid(TOMAFEHCACOMPELTA, 1, 2) '201410'
        Dim Validadia As String = ""
        Dim totalfilas As Integer = GridmesActual.RowCount - 1
        Dim SALDO As String = ""
        For z = 0 To totalfilas
            If Trim(TOMAFEHCACOMPELTA) = Trim(GridmesActual.Rows(z).Cells(0).Value()) Then
                'MsgBox("dia actual ")
                '  MsgBox("paso")
                If Trim(GridmesActual.Rows(z).Cells(5).Value()) <> "" Then
                    ' MsgBox("no existe saldo en balnco ")
                    Textsaldodeldiaactual.Text = GridmesActual.Rows(z).Cells(5).Value()
                    SALDO = Textsaldodeldiaactual.Text
                    'MsgBox(SALDO)
                ElseIf Trim(GridmesActual.Rows(z).Cells(5).Value()) = "" Then
                    'Textsaldodeldiaactual.Text = GridmesActual.Rows(z - 1).Cells(5).Value()
                    'MsgBox("existe valro enn blanco ")
                    Dim totalfilas2 As Integer = GridmesActual.RowCount - 1
                    'recorre la grilla al rebes para buscar el ultimo saldo  ingresado  si el dia actual no esta contabilzado 
                    For x = totalfilas2 To 0 Step -1
                        'MsgBox("pasa")
                        ' x = x - 1
                        'While X= totalfilas2  to 0
                        'End While
                        If Trim(GridmesActual.Rows(x).Cells(5).Value()) <> "" Then
                            Textsaldodeldiaactual.Text = GridmesActual.Rows(x).Cells(5).Value()
                            'MsgBox(Textsaldodeldiaactual.Text)
                            x = 0
                            'MsgBox()
                        End If
                    Next
                    'Textsaldodeldiaactual.Text = 0
                    'SOLICITUENESTADOPENDIENTE()
                End If
            End If
        Next
    End Sub

    Sub coloreargrilalineasobregiro()
        'colorear grilla linea  sobre giro ------

        Dim totalfilas22 As Integer = Gridmeslineas.RowCount - 1
        If totalfilas22 >= 0 Then
            For z = 0 To totalfilas22
                'MsgBox(Gridmeslineas.Rows(z).Cells(0).Value())
                'GridmesActual.Rows(z).Cells(0).Style.ForeColor = Color.Yellow
                Gridmeslineas.Rows(z).Cells(0).Style.ForeColor = Color.White
                Gridmeslineas.Rows(z).Cells(0).Style.BackColor = Color.Green
                Gridmeslineas.Rows(z).Cells(1).Style.BackColor = Color.LightBlue
                Gridmeslineas.Rows(z).Cells(2).Style.BackColor = Color.LightBlue
            Next
        End If
        'colorear grilla linea  sobre giro ------
        Gridmeslineas.SelectionMode = False
    End Sub
    Sub colorearGridprinciapl()

        'colorear grilla linea  sobre giro ------
        Dim totalfilas22 As Integer = GridmesActual.RowCount - 1
        If totalfilas22 > 0 Then
            For z = 0 To totalfilas22
                'MsgBox(Gridmeslineas.Rows(z).Cells(0).Value())
                If z = 0 Then
                    GridmesActual.Rows(z).Cells(0).Style.ForeColor = Color.White
                    GridmesActual.Rows(z).Cells(0).Style.BackColor = Color.BlueViolet
                    GridmesActual.Rows(z).Cells(1).Style.BackColor = Color.BlueViolet
                    GridmesActual.Rows(z).Cells(2).Style.BackColor = Color.BlueViolet
                    GridmesActual.Rows(z).Cells(3).Style.BackColor = Color.BlueViolet

                    GridmesActual.Rows(z).Cells(4).Style.ForeColor = Color.White
                    GridmesActual.Rows(z).Cells(4).Style.BackColor = Color.BlueViolet
                    GridmesActual.Rows(z).Cells(5).Style.ForeColor = Color.White
                    GridmesActual.Rows(z).Cells(5).Style.BackColor = Color.BlueViolet

                Else
                    GridmesActual.Rows(z).Cells(0).Style.ForeColor = Color.White
                    GridmesActual.Rows(z).Cells(0).Style.BackColor = Color.Green
                    GridmesActual.Rows(z).Cells(1).Style.BackColor = Color.LightBlue
                    GridmesActual.Rows(z).Cells(2).Style.BackColor = Color.LightBlue
                    GridmesActual.Rows(z).Cells(3).Style.BackColor = Color.LightBlue
                    GridmesActual.Rows(z).Cells(4).Style.BackColor = Color.LightBlue
                    GridmesActual.Rows(z).Cells(5).Style.BackColor = Color.LightBlue

                End If

              
            Next
        End If
        'colorear grilla linea  sobre giro ------
        GridmesActual.SelectionMode = False
    End Sub
    Sub llenagrillalineasobregiro()
        Dim TOMAFECHA As String = Trim(Textdesdeaño.Text) + Trim(Textdesdemes.Text)
        '_tabla31.Rows.Clear()
        '_tabla31.Columns.Clear()
        'Dim conexiones5 As New CConexion
        'conexiones5.conexion()
        '_adaptador.SelectCommand = New SqlCommand(" SELECT Substring([FECHA],7, 2) + '/' + Substring([FECHA], 5, 2) + '/' + Substring([FECHA],1, 4) as Fecha ,dbo.puntos([LINEA_SOBRE_GIRO]) as Linea_Sobre_giro  ,[ID_TABLA] as Id  FROM  [_RIESGO_DETA_CONTROL_CAPITAL] WHERE left(_RIESGO_DETA_CONTROL_CAPITAL.FECHA,6) = '" + TOMAFECHA + "'  ORDER BY ID_TABLA DESC ", conexiones5._conexion)
        'conexiones5.abrir()
        '_adaptador.Fill(_tabla31)
        'Gridmeslineas.DataSource = _tabla31
        'conexiones5.cerrar()

        Gridmeslineas.Rows.Clear()

        _TABLA30.Rows.Clear()
        _TABLA30.Columns.Clear()


        'Toma el primer y ultimo dia  del mes seleccionado 
        Dim conexiones4 As New CConexion
        conexiones4.conexion()
        Dim command4 As SqlCommand = New SqlCommand("SELECT Substring([FECHA],7, 2) + '/' + Substring([FECHA], 5, 2) + '/' + Substring([FECHA],1, 4) as Fecha ,dbo.puntos([LINEA_SOBRE_GIRO]) as Linea_Sobre_giro  ,[ID_TABLA] as Id  FROM  [_RIESGO_DETA_CONTROL_CAPITAL] WHERE left(_RIESGO_DETA_CONTROL_CAPITAL.FECHA,6) = '" + TOMAFECHA + "'  ORDER BY ID_TABLA DESC", conexiones4._conexion)
        conexiones4.abrir()
        Dim reader4 As SqlDataReader = command4.ExecuteReader()
        If reader4.HasRows Then
            Do While reader4.Read()
                Gridmeslineas.Rows.Add(reader4(0), reader4(1), reader4(2))
            Loop
        Else
        End If
        reader4.Close()



        Gridmeslineas.SelectionMode = False






    End Sub


   
    Private Sub Labelmenasajesaldonegativo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Labelmenasajesaldonegativo.Click

    End Sub
End Class