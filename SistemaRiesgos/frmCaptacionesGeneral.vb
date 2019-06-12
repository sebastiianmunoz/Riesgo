Imports System.Data.SqlClient
Imports System.Data


Public Class frmCaptacionesGeneral

    Public _adaptador As SqlDataAdapter = New SqlDataAdapter
    Public _tabla As DataTable = New DataTable

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim valor1 As String = Trim(txtRut.Text)
        Dim valor2 As String = valor1.Replace(".", "")
        'MsgBox(valor2)




        '------------------------------------------VALIDA EL RUT EN TABLA DETALLE--------------------------------------------------
        Dim Rut As String = ""
        Dim conexiones2 As New CConexion
        conexiones2.conexion()
        Dim command2 As SqlCommand = New SqlCommand("SELECT RUT ,DOCUMENTO FROM _COBRANZA_CERTIFICADOS_DETA_respaldo_italiano WHERE rut='" + valor2 + "'", conexiones2._conexion)
        conexiones2.abrir()
        Dim reader2 As SqlDataReader = command2.ExecuteReader()

        If reader2.HasRows Then
            Do While reader2.Read()
                Rut = reader2(0).ToString
            Loop
        Else
        End If
        reader2.Close()


        '-----------------------------------------------------------------------------------------------------------------------------------


        '------------------------------------------VALIDA EL RUT SI ES MENOR DE EDAD EN _COBRANZA_CERTIFICADOS--------------------------------

        ' string Replace(string oldValue,string newValue)


        Dim Rut2 As String = ""
        Dim conexiones3 As New CConexion
        conexiones3.conexion()
        Dim command3 As SqlCommand = New SqlCommand("SELECT CC1.id_certificado,CC1.rut,CC1.ano,CC1.nombre,CC1.estado,CC1.usuario_solicitante,CC1.Fecha_solicitud,(DATEDIFF(year,convert(date,cc2.FechaNac,100),convert(date,'20141231',100)))AS EDAD FROM _COBRANZA_CERTIFICADOS AS CC1 INNER JOIN _TITULARES AS CC2 ON CC1.rut=CC2.RUT WHERE CC1.rut='" + valor2 + "'", conexiones3._conexion)
        conexiones3.abrir()
        Dim reader3 As SqlDataReader = command3.ExecuteReader()
        'si el rut es encontrado se guarda en variable Rut'

        If reader3.HasRows Then
            Do While reader3.Read()
                Rut2 = reader3(1).ToString
                'MsgBox(Rut)
            Loop
        Else
        End If

        reader3.Close()

        'Condicion si la variable rut es vacia muestra el mensaje, si tiene datos abre el form de captaciones'
        If Rut = "" Then
            MsgBox("El Rut no se encuentra en los registros.")
        Else
            If Rut2 = "" Then
                MsgBox("El Rut es menor de Edad, Ingrese el Siguiente Titular de la Cuenta")
            Else
                frmCaptacionesimpresiones.Show()
            End If

        End If



        '----------------------------------------------------------------------------------------------------------------------------------------------------------------



    End Sub

    Private Sub frmCaptacionesGeneral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '_tabla.Rows.Clear()
        '_tabla.Columns.Clear()
        'Dim conexiones4 As New CConexion
        'conexiones4.conexion()
        '_adaptador.SelectCommand = New SqlCommand("SELECT [RUT],[Nº_DEL_DOCUMENTO],[FECHAINICIO],[FECHATERMINO],[MONTOOPERACION],[MONTOPERCIBIDO],[INTERES],[interes_real],[factor],[interes_real_factor] FROM [_Cobranza_certificados_deta3]", conexiones4._conexion)
        'conexiones4.abrir()
        '_adaptador.Fill(_tabla)
        'DGMostrar.DataSource = _tabla
        'conexiones4.cerrar()
    End Sub

    Private Sub DGMostrar_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGMostrar.SelectionChanged

        'txtRut.Text = ""
        'txtRut.Text = Trim(DGMostrar.Rows(DGMostrar.CurrentRow.Index).Cells(0).Value)

    End Sub

End Class