Imports System.Data
Imports System.Data.SqlClient
Public Class MensajeAlertaMovimientoSocios7Dias
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter
    Public _tabla26 As DataTable = New DataTable
    Public _tabla27 As DataTable = New DataTable
    Dim contadorrojo As Integer = 0
    Dim FECHACOMPLETASINSALSH As String = ""

    Private Sub MensajeAlertaMovimientoSocios7Dias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MUESTRAGRILLA()
        CONTARESTADOSSOLICITUD()
    End Sub

    Sub MUESTRAGRILLA()
        Dim TOMAFEHCACOMPELTA As String = ""
        Dim FECHAMESAÑO As String = ""
        Dim FECHAAÑOMESANTERIOR As String = ""
        Dim MESANTERIOR As String = ""
        Dim AÑOANTERIOR As String = ""
        Dim TOMAAÑO As String = ""
        TOMAFEHCACOMPELTA = DateTime.Now().ToShortDateString()
        FECHACOMPLETASINSALSH = Mid(TOMAFEHCACOMPELTA, 7, 10) + Mid(TOMAFEHCACOMPELTA, 4, 2) + Mid(TOMAFEHCACOMPELTA, 1, 2)

        Dim SIETEDIASATRAS As String = Int(Mid(TOMAFEHCACOMPELTA, 1, 2)) - 7
        Dim totaldiashabiles As String = ""

        FECHAMESAÑO = Mid(TOMAFEHCACOMPELTA, 7, 10) + Mid(TOMAFEHCACOMPELTA, 4, 2)
        MESANTERIOR = Int(Mid(TOMAFEHCACOMPELTA, 4, 2)) - 3 ' 
        TOMAAÑO = Mid(TOMAFEHCACOMPELTA, 7, 10)


        Label5.Text = "Movimientos  Socio  año  " + TOMAAÑO
        'MsgBox(MESANTERIOR)
        'If Int(MESANTERIOR) < 0 Then
        'End If
        'If MESANTERIOR = 0 Then
        '    MESANTERIOR = "12"
        '    AÑOANTERIOR = Int(Mid(TOMAFEHCACOMPELTA, 7, 10)) - 1
        '    FECHAAÑOMESANTERIOR = AÑOANTERIOR + MESANTERIOR
        '    'MsgBox(FECHAAÑOMESANTERIOR)
        'End If
        'If Len(MESANTERIOR) = 1 Then
        '    MESANTERIOR = "0" + MESANTERIOR
        '    'MsgBox(MESANTERIOR)
        'End If
        'FECHAAÑOMESANTERIOR = Mid(TOMAFEHCACOMPELTA, 7, 10) + MESANTERIOR
        'MsgBox(FECHAMESAÑO)
        'MsgBox(FECHAAÑOMESANTERIOR)
        '_tabla26.Rows.Clear()
        '_tabla26.Columns.Clear()
        'Dim conexiones4 As New CConexion
        'conexiones4.conexion()
        '_adaptador.SelectCommand = New SqlCommand("SET LANGUAGE Español  SELECT DERIVEDTBL1.*  FROM (SELECT FECHA,NOMBREDIA,FESTIVO FROM (SELECT _BSC_CALENDARIO.FECHA, DATENAME(WEEKDAY,_BSC_CALENDARIO.FECHA) AS NOMBREDIA ,ISNULL(_FESTIVOS.FECHA,'XX')  AS FESTIVO FROM _BSC_CALENDARIO LEFT OUTER JOIN _FESTIVOS ON _BSC_CALENDARIO.FECHA= _FESTIVOS.FECHA WHERE LEFT(_BSC_CALENDARIO.FECHA,6) <= " + Trim(FECHAMESAÑO) + " and LEFT(_BSC_CALENDARIO.FECHA,6)> =" + Trim(FECHAAÑOMESANTERIOR) + ")DERIVEDTBL WHERE DERIVEDTBL.FECHA <> DERIVEDTBL.FESTIVO AND DERIVEDTBL.NOMBREDIA <> 'Domingo' AND DERIVEDTBL.NOMBREDIA <> 'Sábado')DERIVEDTBL1  ", conexiones4._conexion)
        'conexiones4.abrir()
        '_adaptador.Fill(_tabla27)
        'Gridmesactualmesanterior.DataSource = _tabla27
        'conexiones4.cerrar()
        'Dim DIAHABIL7DIASATRAS As String = ""
        'Dim Totalfilas As Integer = Gridmesactualmesanterior.RowCount - 1
        'For z = 0 To Totalfilas
        '    If Trim(Gridmesactualmesanterior.Rows(z).Cells(0).Value()) = Trim(FECHACOMPLETASINSALSH) Then
        '        DIAHABIL7DIASATRAS = Trim(Gridmesactualmesanterior.Rows(z - 60).Cells(0).Value())
        '    End If
        'Next
        'Label1.Text = DIAHABIL7DIASATRAS
        'MsgBox(FECHACOMPLETASINSALSH)
        'SELECT  ID_SOLICITUD ,SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD , MONTO_SOLICITUD,ESTADO_SOLICITUD   from  [_RIESGO_SOLICITUD_GIRO_CAPITAL] where  estado_solicitud='PREAPROBADO'  OR  estado_solicitud='APROBADO'  ORDER BY FECHA_SOLICITUD  ASC 
        '_tabla26.Rows.Clear()
        '_tabla26.Columns.Clear()
        'Dim conexiones44 As New CConexion
        'conexiones44.conexion()
        '_adaptador.SelectCommand = New SqlCommand("SELECT  NROSOCIO as NRO_SOCIOS ,ID_SOLICITUD ,SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD ,DBO.PUNTOS(MONTO_SOLICITUD) AS MONTO_SOLICITUD ,ESTADO_SOLICITUD   from  [_RIESGO_SOLICITUD_GIRO_CAPITAL] where  [FECHA_SOLICITUD] < =  '" + Trim(FECHACOMPLETASINSALSH.ToString) + "' AND [FECHA_SOLICITUD] > =  '" + Trim(DIAHABIL7DIASATRAS.ToString) + "' and (estado_solicitud <>'ANULADA')  and NROSOCIO='" + Trim(frmEvaluarCapital.txtNrosocio.Text) + "' ORDER BY FECHAHORA  desc  ", conexiones44._conexion)
        'conexiones44.abrir()
        '_adaptador.Fill(_tabla26)
        'GRIDPENDIENTES.DataSource = _tabla26
        'conexiones44.cerrar()

        _tabla26.Rows.Clear()
        _tabla26.Columns.Clear()
        Dim conexiones44 As New CConexion
        conexiones44.conexion()
        _adaptador.SelectCommand = New SqlCommand("SELECT  NROSOCIO as NRO_SOCIOS ,ID_SOLICITUD ,SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD ,DBO.PUNTOS(MONTO_SOLICITUD) AS MONTO_SOLICITUD ,ESTADO_SOLICITUD   from  [_RIESGO_SOLICITUD_GIRO_CAPITAL] where   (estado_solicitud <>'ANULADA')  and NROSOCIO='" + Trim(frmEvaluarCapital.txtNrosocio.Text) + "' AND LEFT(FECHA_SOLICITUD,4)>= '" + TOMAAÑO + "' ORDER BY FECHAHORA  desc  ", conexiones44._conexion)
        conexiones44.abrir()
        _adaptador.Fill(_tabla26)
        GRIDPENDIENTES.DataSource = _tabla26
        conexiones44.cerrar()

        'Dim conexiones8 As New CConexion
        'conexiones8.conexion()
        'Dim command8 As SqlCommand = New SqlCommand("SELECT COUNT(*) FROM (SELECT FECHA,NOMBREDIA,FESTIVO  FROM (SELECT _BSC_CALENDARIO.FECHA, DATENAME(WEEKDAY,_BSC_CALENDARIO.FECHA) AS NOMBREDIA  ,ISNULL(_FESTIVOS.FECHA,'XX')  AS FESTIVO FROM _BSC_CALENDARIO LEFT OUTER JOIN _FESTIVOS ON _BSC_CALENDARIO.FECHA= _FESTIVOS.FECHA WHERE LEFT(_BSC_CALENDARIO.FECHA,6) = '" + Trim(FECHAMESAÑO) + "') DERIVEDTBL WHERE DERIVEDTBL.FECHA <> DERIVEDTBL.FESTIVO AND DERIVEDTBL.NOMBREDIA <> 'Domingo' AND DERIVEDTBL.NOMBREDIA <> 'Sábado')DERIVEDTBL1 ", conexiones8._conexion)
        'conexiones8.abrir()
        'Dim reader8 As SqlDataReader = command8.ExecuteReader()
        'If reader8.HasRows Then
        '    Do While reader8.Read()
        '        'MsgBox(reader8(0).ToString)
        '        totaldiashabiles = (Trim(reader8(0).ToString))
        '    Loop
        'Else
        'End If
        'reader8.Close()
        'conexiones8.cerrar()

    End Sub
    Sub CONTARESTADOSSOLICITUD()
        Dim totalfilas As Integer = GRIDPENDIENTES.RowCount - 1
        Dim contadorpagado As Integer = 0
        Dim contadoraprobado As Integer = 0
        Dim contadorpreaporbado As Integer = 0
        Dim contadorreocncideracion As Integer = 0
        Dim totalsolicitudes As Integer = 0


        For z = 0 To totalfilas


            If Trim(GRIDPENDIENTES.Rows(z).Cells(4).Value()) = "PAGADO" Then

                contadorpagado = contadorpagado + 1

                GRIDPENDIENTES.Rows(z).Cells(4).Style.BackColor = Color.Blue
                GRIDPENDIENTES.Rows(z).Cells(4).Style.ForeColor = Color.White
            ElseIf Trim(GRIDPENDIENTES.Rows(z).Cells(4).Value()) = "APROBADO" Then
                contadoraprobado = contadoraprobado + 1

                GRIDPENDIENTES.Rows(z).Cells(4).Style.BackColor = Color.Green
                GRIDPENDIENTES.Rows(z).Cells(4).Style.ForeColor = Color.White


            ElseIf Trim(GRIDPENDIENTES.Rows(z).Cells(4).Value()) = "PREAPROBADO" Then
                contadorpreaporbado = contadorpreaporbado + 1
                GRIDPENDIENTES.Rows(z).Cells(4).Style.BackColor = Color.Green
                GRIDPENDIENTES.Rows(z).Cells(4).Style.ForeColor = Color.White

            ElseIf Trim(GRIDPENDIENTES.Rows(z).Cells(4).Value()) = "RECONSIDERACIÓN" Then

                contadorreocncideracion = contadorreocncideracion + 1
                GRIDPENDIENTES.Rows(z).Cells(2).Style.BackColor = Color.Orange
                GRIDPENDIENTES.Rows(z).Cells(2).Style.ForeColor = Color.White
            End If

            totalsolicitudes = totalsolicitudes + 1


            GRIDPENDIENTES.Rows(z).Cells(0).Style.BackColor = Color.LightBlue
            GRIDPENDIENTES.Rows(z).Cells(1).Style.BackColor = Color.LightBlue
            GRIDPENDIENTES.Rows(z).Cells(2).Style.BackColor = Color.LightBlue
            GRIDPENDIENTES.Rows(z).Cells(3).Style.BackColor = Color.LightBlue
            ' GRIDPENDIENTES.Rows(z).Cells(4).Style.BackColor = Color.Green
            'GRIDPENDIENTES.Rows(z).Cells(4).Style.ForeColor = Color.White


        Next


        LabelRESULTADOTOTALSOLICITUD.Text = totalsolicitudes

        LabelRESULTADOTOTALPAGADOS.Text = contadorpagado
        LabelRESULTADOTOTALAPROBADO.Text = contadoraprobado
        LabelRESULTADOTOTALPREAPROBADO.Text = contadorpreaporbado
        LabelTotalReconcideracion.Text = contadorreocncideracion







    End Sub
End Class