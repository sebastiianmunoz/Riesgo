Imports System.Data
Imports System.Data.SqlClient
Public Class MensajeSolicitudesPendientes
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter
    Public _tabla26 As DataTable = New DataTable
    Dim contadorrojo As Integer = 0
    Dim FECHACOMPLETASINSALSH As String = ""
    Private Sub MensajeSolicitudesPendientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MUESTRAGRILLA()
        PUNTOSYTOTALES()
        FECHAROJA()
    End Sub


    Sub MUESTRAGRILLA()
        Dim TOMAFEHCACOMPELTA As String = ""
        TOMAFEHCACOMPELTA = DateTime.Now().ToShortDateString()
        FECHACOMPLETASINSALSH = Mid(TOMAFEHCACOMPELTA, 7, 10) + Mid(TOMAFEHCACOMPELTA, 4, 2) + Mid(TOMAFEHCACOMPELTA, 1, 2)

        ' MsgBox(FECHACOMPLETASINSALSH)

        'SELECT  ID_SOLICITUD ,SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD , MONTO_SOLICITUD,ESTADO_SOLICITUD   from  [_RIESGO_SOLICITUD_GIRO_CAPITAL] where  estado_solicitud='PREAPROBADO'  OR  estado_solicitud='APROBADO'  ORDER BY FECHA_SOLICITUD  ASC 
        _tabla26.Rows.Clear()
        _tabla26.Columns.Clear()
        Dim conexiones4 As New CConexion
        conexiones4.conexion()
        _adaptador.SelectCommand = New SqlCommand("SELECT  NROSOCIO as NRO_SOCIOS ,ID_SOLICITUD ,SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD ,DBO.PUNTOS(MONTO_SOLICITUD) AS MONTO_SOLICITUD ,ESTADO_SOLICITUD   from  [_RIESGO_SOLICITUD_GIRO_CAPITAL] where  [FECHA_SOLICITUD] < =  '" + Trim(FECHACOMPLETASINSALSH.ToString) + "' and (estado_solicitud='PREAPROBADO'  OR  estado_solicitud='APROBADO')  ORDER BY FECHA_SOLICITUD  ASC  ", conexiones4._conexion)
        conexiones4.abrir()
        _adaptador.Fill(_tabla26)
        GRIDPENDIENTES.DataSource = _tabla26
        conexiones4.cerrar()



    End Sub



    Sub PUNTOSYTOTALES()

        Dim TOTALAPORBADOS As Integer = 0
        Dim TOTALPREAPOBADOS As Integer = 0
        Dim TOTALFILAS As Integer = GRIDPENDIENTES.RowCount - 1

        For Z = 0 To TOTALFILAS

            'MsgBox(GRIDPENDIENTES.Rows(Z).Cells(2).Value())
            'GRIDPENDIENTES.Rows(Z).Cells(2).Value() = PuntoX(CDbl(GRIDPENDIENTES.Rows(Z).Cells(2).Value()))
            'GRIDPENDIENTES.Rows(Z).Cells(2).Value() = ""
            'MsgBox(GRIDPENDIENTES.Rows(Z).Cells(2).Value())
            'MsgBox(GRIDPENDIENTES.Rows(Z).Cells(3).Value())


            If Trim(GRIDPENDIENTES.Rows(Z).Cells(4).Value()) = "APROBADO" Then

                TOTALAPORBADOS = TOTALAPORBADOS + 1


            ElseIf Trim(GRIDPENDIENTES.Rows(Z).Cells(4).Value()) = "PREAPROBADO" Then

                TOTALPREAPOBADOS = TOTALPREAPOBADOS + 1


            End If

            GRIDPENDIENTES.Rows(Z).Cells(4).Style.BackColor = Color.Green
            GRIDPENDIENTES.Rows(Z).Cells(4).Style.ForeColor = Color.White
        Next

        RESULTADOAPROBADO.Text = TOTALAPORBADOS
        RESULTADOPREAPORBADO.Text = TOTALPREAPOBADOS



    End Sub
    Sub FECHAROJA()

        Dim TOMAFEHCACOMPELTA As String = ""
        Dim TOMAFECHAAÑOMESDIA As String = ""
        Dim FECHACOMPARAR As String = ""

        TOMAFEHCACOMPELTA = DateTime.Now().ToShortDateString()  '"16/06/2009"
        TOMAFECHAAÑOMESDIA = Mid(TOMAFEHCACOMPELTA, 7, 10) + Mid(TOMAFEHCACOMPELTA, 4, 2) + Mid(TOMAFEHCACOMPELTA, 1, 2) '201410'
        FECHACOMPLETASINSALSH = Mid(TOMAFEHCACOMPELTA, 7, 10) + Mid(TOMAFEHCACOMPELTA, 4, 2) + Mid(TOMAFEHCACOMPELTA, 1, 2) + Mid(TOMAFEHCACOMPELTA, 1, 2)

        Dim TOTALFILAS As Integer = GRIDPENDIENTES.RowCount - 1

        For Z = 0 To TOTALFILAS

            FECHACOMPARAR = Mid(GRIDPENDIENTES.Rows(Z).Cells(2).Value(), 7, 10) + Mid(GRIDPENDIENTES.Rows(Z).Cells(2).Value(), 4, 2) + Mid(GRIDPENDIENTES.Rows(Z).Cells(2).Value(), 1, 2)
            'MsgBox(FECHACOMPARAR)
            'MsgBox(TOMAFECHAAÑOMESDIA)

            If Trim(FECHACOMPARAR) < Trim(TOMAFECHAAÑOMESDIA) Then

                GRIDPENDIENTES.Rows(Z).Cells(2).Style.BackColor = Color.Red
                GRIDPENDIENTES.Rows(Z).Cells(2).Style.ForeColor = Color.White

                contadorrojo = contadorrojo + 1


            Else
                GRIDPENDIENTES.Rows(Z).Cells(2).Style.BackColor = Color.LightBlue

            End If

            GRIDPENDIENTES.Rows(Z).Cells(0).Style.BackColor = Color.LightBlue
            GRIDPENDIENTES.Rows(Z).Cells(1).Style.BackColor = Color.LightBlue
            GRIDPENDIENTES.Rows(Z).Cells(3).Style.BackColor = Color.LightBlue
            GRIDPENDIENTES.Rows(Z).Cells(4).Style.BackColor = Color.Green
            GRIDPENDIENTES.Rows(Z).Cells(4).Style.ForeColor = Color.White
        Next

        'If contadorrojo <> "" Then

        Textrojo.Text = contadorrojo

        ' Else

        ' Textrojo.Text = "0"


        'End If






    End Sub



    Public Function PuntoX(ByVal strValor As String, Optional ByVal intNumDecimales As Integer = 0) As String

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

    Private Sub Textrojo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textrojo.TextChanged

    End Sub

    Private Sub CheckCOLOR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckCOLOR.CheckedChanged
        FECHAROJA()
    End Sub
End Class