
Imports System.Data
Imports System.Data.SqlClient
Public Class frmActualizaciones
    'Dim Fecha As String
    Dim Version As String
    Dim tabla As New DataTable
    Dim tabla2 As New DataTable
    Dim Datos As New CDatos
    Dim Plantillas As New Metodos
    Public Fecha As String = ""
    Public FechaULTIMA As String = ""
    Dim Usuario As String = ""
    Dim Sistema As String = ""
    Private Sub frmActualizaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        'Sistema = "RIESGO"
        'Usuario = frmPerfil.CbmUsuario.SelectedItem.ToString.Trim
        ''Usuario = "CCAMPOS"

        'Dim conexiones1 As New CConexion
        'conexiones1.conexion()
        'Dim command1 As SqlCommand = New SqlCommand("  SELECT MAX( FECHA)  FROM [LROSAS].[dbo].[_RIESGO_ACTUALIZACIONES] ", conexiones1._conexion)
        'conexiones1.abrir()
        'Dim reader1 As SqlDataReader = command1.ExecuteReader()
        'If reader1.HasRows Then
        '    Do While reader1.Read()
        '        Fecha = (reader1(0).ToString)
        '        'MsgBox(Fecha)
        '    Loop
        'Else

        'End If



        'Dim conexiones2 As New CConexion
        'conexiones2.conexion()
        'Dim command2 As SqlCommand = New SqlCommand("SELECT ISNULL(MAX(convert(bigint,FECHA)),201801010000) FROM _ACTUALIZACIONES_SISTEMAS   AS CC1 INNER JOIN (select MAX(ID) AS ID,SISTEMA,USUARIO from _ACTUALIZACIONES_SISTEMAS group by SISTEMA,USUARIO) AS CC2 ON CC1.ID=CC2.ID AND CC2.USUARIO=CC1.USUARIO AND CC1.SISTEMA=CC2.SISTEMA WHERE CC1.USUARIO='" + Usuario + "' AND CC1.SISTEMA='" + Sistema + "'", conexiones2._conexion)
        'conexiones2.abrir()
        'Dim reader2 As SqlDataReader = command2.ExecuteReader()
        'If reader2.HasRows Then
        '    Do While reader2.Read()
        '        FechaULTIMA = (reader2(0).ToString)
        '        'MsgBox(Fecha)
        '    Loop
        'Else

        'End If


        'Datos._sql1 = "SELECT substring([FECHA],1,4)+'/'+substring([FECHA],5,2)+'/'+substring([FECHA],7,2)+' '+ substring([FECHA],9,2)+':'+substring([FECHA],11,2)  as FECHA ,USUARIO,[VERSION_SISTEMA] AS VERSION ,RTRIM(MODULO) AS MODULO,rtrim([COMENTARIO]) AS DESCRIPCIÓN, FECHA AS FECHA2,PRIORIDAD  FROM [LROSAS].[dbo].[_RIESGO_ACTUALIZACIONES] where FECHA>" + FechaULTIMA + " order by FECHA desc"

        'Plantillas.tabla.Rows.Clear()

        'If Plantillas.Consultar_General(Datos) Then
        '    tabla = Plantillas.tabla
        '    DGDatos.DataSource = tabla
        'End If


        'DGDatos.AllowUserToAddRows = False





        'Dim totalcolumnas As Integer = DGDatos.Columns.Count - 1
        'Dim tomadato As String = ""

        'For A = 0 To totalcolumnas
        '    tomadato = Trim(DGDatos.Columns(A).Name)

        '    If tomadato <> "FECHA" And tomadato <> "VERSION" And tomadato <> "DESCRIPCIÓN" And tomadato <> "USUARIO" And tomadato <> "MODULO" And tomadato <> "PRIORIDAD" Then
        '        DGDatos.Columns(A).Visible = False
        '    End If
        'Next
        'colores()

        'If DGDatos.RowCount > 0 Then
        '    MsgBox("entro")
        '    Me.Visible = True
        'End If


        'If DGDatos.RowCount > 0 Then
        '    DGDatos.Rows(0).Cells(0).Style.BackColor = Color.LightBlue
        '    DGDatos.Rows(0).Cells(1).Style.BackColor = Color.LightBlue
        '    DGDatos.Rows(0).Cells(2).Style.BackColor = Color.LightBlue
        'End If



        'Dim conexiones3 As New CConexion
        'conexiones3.conexion()
        'Dim command3 As SqlCommand = New SqlCommand("SELECT dbo.FU_DESENCRIPTA(ENSUPERCONTRASENA),CARGO FROM _RIESGO_PERFIL WHERE USUARIO='" + Usuario.ToString.Trim + "'", conexiones2._conexion)
        'conexiones3.abrir()

        'Dim reader3 As SqlDataReader = command2.ExecuteReader()


        'If reader3.HasRows Then
        '    Do While reader3.Read()
        '        Contrasena = reader2(0).ToString
        '        Departamento = reader2(1).ToString
        '    Loop
        'Else
        'End If

        'reader2.Close()


    End Sub
    Sub colores()
        'MsgBox("ENTRO")
        Dim totalcolumnas As Integer = DGDatos.ColumnCount - 1
        Dim totalfilas As Integer = DGDatos.Rows.Count - 1
        Dim tomadato As String = ""
        Dim tomadato2 As String = ""
        Dim estado_solicitud As String = ""


        For A = 0 To totalfilas
            tomadato = Trim(DGDatos.Rows(A).Cells("PRIORIDAD").Value())

            'tomadato2 = Trim(DGDatos.Rows(A).Cells("PreAprobacion_Agente").Value())


            If tomadato = "ALTA" Then
                For M = 0 To totalcolumnas
                    DGDatos.Rows(A).Cells(M).Style.BackColor = Color.Red
                    DGDatos.Rows(A).Cells(M).Style.ForeColor = Color.White
                    'MsgBox(tomadato)
                Next

            ElseIf tomadato = "MEDIA" Then
                For M = 0 To totalcolumnas
                    DGDatos.Rows(A).Cells(M).Style.BackColor = Color.Yellow
                    DGDatos.Rows(A).Cells(M).Style.ForeColor = Color.White
                Next

            Else

                For M = 0 To totalcolumnas
                    DGDatos.Rows(A).Cells(M).Style.BackColor = Color.GreenYellow
                    DGDatos.Rows(A).Cells(M).Style.ForeColor = Color.White
                Next
                'For M = 0 To totalcolumnas
                '    If tomadato2 = "Por Analizar" Then

                '        DGDatos.Rows(A).Cells(M).Style.BackColor = Color.Yellow
                '    Else

                '        DGDatos.Rows(A).Cells(M).Style.BackColor = Color.MediumSeaGreen

            End If




            'DGreditosAprobar.Rows(A).Cells(M).Style.ForeColor = Color.
            'Next

            '    End If
        Next



    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'If TXTVisto.Text = "VISTO" Then

        '    Datos._sql1 = "insert into _ACTUALIZACIONES_SISTEMAS values ('" + Sistema + "','" + Usuario + "','" + Fecha + "')"

        '    'If 
        '    Plantillas.Consultar_General(Datos)

        '    Me.Close()
        '    'Then
        '    '    'MsgBox("ok")
        '    'End If
        'Else

        '    Me.Close()

        'End If
        frmRIESGO.GUARDAR()


        'Else

        '    Me.Close()
        'End If

        'MsgBox(Fecha)
        'insertar()


    End Sub

    Private Sub frmActualizaciones_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'MsgBox("")


        'If DGDatos.RowCount = 0 Then
        '    Me.Close()
        'End If


    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TXTVisto_TextChanged(sender As Object, e As EventArgs) Handles TXTVisto.TextChanged

    End Sub

    Private Sub DGDatos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGDatos.CellContentClick

    End Sub
End Class