Imports System.Data
Imports System.Data.SqlClient

Public Class CConexion
    Public _Cadena As String
    Public _conexion As SqlConnection
    Public _Cadena2 As String
    Public _conexion2 As SqlConnection
    Dim Datos As New CDatos
    Public Sub conexion()
        _Cadena = "Data Source=192.168.0.173; Initial Catalog=LROSAS; User ID=sa;Password=universo"
        '_Cadena = "Data Source=192.168.0.174; Initial Catalog=LROSAS; User ID=sa;Password=universo"
        '_Cadena = "Data Source=192.168.0.167;Initial Catalog=LROSAS_R;User ID=sa;Password=universo"
        '_Cadena = "Data Source=192.168.0.167\MSSQLSERVER_LR;Initial Catalog=LROSAS_R2;User ID=sa;Password=universo" 'version 16
        '_Cadena = "Data Source=(local);Initial Catalog=LROSAS;Integrated Security = True"
        '_Cadena = "Data Source=.\LOCALSMUÑOZ;Initial Catalog=LROSAS;Integrated Security = True"
        _conexion = New SqlConnection(_Cadena)
    End Sub
    Public Sub cerrar()
        _conexion.Close()
    End Sub
    Public Sub abrir()
        _conexion.Open()

    End Sub
    Public Sub conexion2()

        'MsgBox("entro")

        Dim TIPO As String = "DOCUMENTOS"

        Dim SRV As String = ""

        Dim BASE As String = ""


        Dim conexiones As New CConexion
        conexiones.conexion()
        Dim command2 As SqlCommand = New SqlCommand("SELECT [SRV_DIGITALES] ,[BASE_DIGITALES]  FROM _SERVIDORES WHERE TIPO='" + TIPO + "'", conexiones._conexion)
        conexiones.abrir()

        Dim reader2 As SqlDataReader = command2.ExecuteReader()


        If reader2.HasRows Then

            Do While reader2.Read()
                'MsgBox(reader2(0).ToString)
                SRV = (reader2(0).ToString)
                BASE = (reader2(1).ToString)
            Loop
        Else
        End If

        reader2.Close()

        'MsgBox("Data Source=" + SRV + "; Initial Catalog=" + BASE + "; User ID=sa;Password=universo")

        _Cadena = "Data Source=" + SRV + "; Initial Catalog=" + BASE + "; User ID=sa;Password=universo"
        '_Cadena = "Data Source=192.168.0.167;Initial Catalog=LROSAS_R;User ID=sa;Password=universo"
        '_Cadena = "Data Source=192.168.0.167\MSSQLSERVER_LR;Initial Catalog=LROSAS_R2;User ID=sa;Password=universo" 'version 16
        '_Cadena = "Data Source=(local);Initial Catalog=LROSAS;Integrated Security = True"
        ' _Cadena = "Data Source=.\LOCALSMUÑOZ;Initial Catalog=LROSAS;Integrated Security = True"
        _conexion2 = New SqlConnection(_Cadena)
    End Sub
    Public Sub cerrar2()
        _conexion2.Close()
    End Sub
    Public Sub abrir2()
        _conexion2.Open()
    End Sub
    'Public Sub conexion2()
    '_Cadena = "Data Source=192.168.0.173; Initial Catalog=LROSAS; User ID=sa;Password=universo"
    '_Cadena = "Data Source=192.168.0.167\MSSQLSERVER_LR;Initial Catalog=LROSAS_R;User ID=sa;Password=universo"
    '_Cadena = "Data Source=192.168.0.167\MSSQLSERVER_LR;Initial Catalog=LROSAS_R;User ID=sa;Password=universo" 'version 16
    '_Cadena = "Data Source=(local)\LOCALSMUÑOZ;Initial Catalog=LROSAS;Integrated Security = True"
    '_Cadena = "Data Source=KIOSCO\SQLEXPRESS; Initial Catalog=Totalpack; User ID=Lautaro;Password=universo"
    '_conexion = New SqlConnection(_Cadena)
    'End Sub
    'Public Sub cerrar2()
    '_conexion.Close()
    'End Sub
    'Public Sub abrir2()
    '_conexion.Open()
    'End Sub
End Class
