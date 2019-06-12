Imports System.Data
Imports System.Data.SqlClient
Public Class frmEnvioCorreoElectronicoAuditoria
    Public _TABLA27 As DataTable = New DataTable
    Public _TABLA28 As DataTable = New DataTable
    Public _tabla29 As DataTable = New DataTable
    Public _tabla30 As DataTable = New DataTable
    Public _tabla31 As DataTable = New DataTable
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter
    Private Sub frmEnvioCorreoElectronicoAuditoria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        estadosgenerales()
    End Sub

    Sub estadosgenerales()
        _TABLA27.Rows.Clear()
        _TABLA27.Columns.Clear()
        'LLENA LA GRILLA "GRIDESTADOSGIROS" Y MUESTRA TODAS LAS SOLICITUDES DE GIRO DE CAPITAL 
        Gridestadogiros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        Dim xSql As String
        xSql = ""
        xSql = xSql + "Select ID_SOLICITUD"
        xSql = xSql + ",FECHAENVIO"
        xSql = xSql + ", [CORREOEJECUTIVA] "
        xSql = xSql + ",[CORREORECEPCION] "
        xSql = xSql + ",(select case when [ENVIOFISICO]=1 then 'ENVIO FISICO REALIZADO' when [ENVIOFISICO]=0 then 'SIN ENVIO FISICO' END ) as ENVIO "
        xSql = xSql + " from [_RIESGO_GIRO_CAPITAL_ENVIO_CARTA_SOCIO]  WHERE CORREORECEPCION='secretaria.gerencia@lautarorosas.cl'  ORDER BY FECHAENVIO DESC  "
        Dim conexiones4 As New CConexion
        conexiones4.conexion()
        _adaptador.SelectCommand = New SqlCommand(xSql, conexiones4._conexion)
        _adaptador.Fill(_TABLA27)
        Gridestadogiros.DataSource = _TABLA27
        conexiones4.cerrar()
    End Sub


    Sub ConfirmarEnvioFisico()
        Dim ID As String = ""
        ID = Trim(TextaID.Text)
        Dim recibevalor As String = ""
        Try
            Dim conexiones2 As New CConexion
            conexiones2.conexion()
            Dim command2 As SqlCommand = New SqlCommand("SELECT top 1 [CORREOEJECUTIVA]  from  [_RIESGO_GIRO_CAPITAL_ENVIO_CARTA_SOCIO] where ID_SOLICITUD= '" + ID + "'", conexiones2._conexion)
            conexiones2.abrir()
            Dim reader2 As SqlDataReader = command2.ExecuteReader()
            If reader2.HasRows Then
                Do While reader2.Read()
                    recibevalor = (reader2(0).ToString)
                Loop
            Else
            End If
            reader2.Close()
            conexiones2.cerrar()

            If recibevalor <> "" Then
                Dim conexiones60 As New CConexion
                conexiones60.conexion()
                _adaptador.UpdateCommand = New SqlCommand("UPDATE [_RIESGO_SOLICITUD_GIRO_CAPITAL]  set [CORREOENVIOCARTA] =1  where ID_SOLICITUD= '" + ID + "' ", conexiones60._conexion)
                conexiones60.abrir()
                _adaptador.UpdateCommand.Connection = conexiones60._conexion
                _adaptador.UpdateCommand.ExecuteNonQuery()
                conexiones60.cerrar()

                Dim conexiones600 As New CConexion
                conexiones600.conexion()
                _adaptador.UpdateCommand = New SqlCommand("UPDATE [_RIESGO_GIRO_CAPITAL_ENVIO_CARTA_SOCIO]  set [ENVIOFISICO] =1  where ID_SOLICITUD= '" + ID + "' ", conexiones600._conexion)
                conexiones600.abrir()
                _adaptador.UpdateCommand.Connection = conexiones600._conexion
                _adaptador.UpdateCommand.ExecuteNonQuery()
                conexiones600.cerrar()
                MessageBox.Show(" Operación  Realizada", "Información Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                estadosgenerales()
            ElseIf recibevalor = "" Then
                '  MsgBox(, , )
                MessageBox.Show("No Existe ese ID  de operación ", "Información Registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error Contactarse con  el adminstrador", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ConfirmarEnvioFisico()
    End Sub
End Class