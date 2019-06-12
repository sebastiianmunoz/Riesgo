
Imports System.Data
Imports System.Data.SqlClient
Public Class ModulosReconsideracion
    Public _tabla26 As DataTable = New DataTable
    Public _tabla27 As DataTable = New DataTable
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter
    Private Sub ModulosReconsideracion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CARGATODASlasreconcideraciones()
        IdentificarEstados()
    End Sub


    Sub CARGATODASlasreconcideraciones()
        _tabla26.Rows.Clear()
        _tabla26.Columns.Clear()
        Dim conexiones4 As New CConexion
        conexiones4.conexion()
        _adaptador.SelectCommand = New SqlCommand(" select [NROSOCIO],SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD,dbo.puntos([MONTO_SOLICITUD]) AS MONTO ,ESTADO_SOLICITUD,[NOMBRE_SOCIO],FORMA_PAGO,SUCURSAL,Aprobacion_SubGerencia ,id_solicitud   from [_RIESGO_SOLICITUD_GIRO_CAPITAL] where REEVALUACION='SI' AND Aprobacion_SubGerencia <>'Por Analizar' order by ID_SOLICITUD desc   ", conexiones4._conexion)
        conexiones4.abrir()
        _adaptador.Fill(_tabla26)
        Gridreconcideraciones.DataSource = _tabla26
        conexiones4.cerrar()
        Gridreconcideraciones.ClearSelection()
    End Sub

    Sub BuscarReconcideracdionporFecha()

        _tabla26.Rows.Clear()
        _tabla26.Columns.Clear()


        Dim fechadesde As String = ""
        Dim fechahasta As String = ""


        fechadesde = Trim(Textdesdeaño.Text) + Trim(Textdesdemes.Text) + Trim(Textdesdedia.Text)
        fechahasta = Trim(TextHASTAAÑO.Text) + Trim(TextHASTAMES.Text) + Trim(Texthastadia.Text)
        '  MsgBox(fechadesde)
        'MsgBox(fechahasta)

     
        ' select [NROSOCIO],SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD,[MONTO_SOLICITUD],ESTADO_SOLICITUD,[NOMBRE_SOCIO],FORMA_PAGO,SUCURSAL,Aprobacion_SubGerencia ,id_solicitud   from [_RIESGO_SOLICITUD_GIRO_CAPITAL] where REEVALUACION='SI' AND Aprobacion_SubGerencia <>'Por Analizar'  and  (FECHA_SOLICITUD BETWEEN '" + Trim(fechadesde.ToString) + "' and '" + Trim(fechahasta.ToString) + "')   order by id_solicitud desc   ", conexiones44._conexion)

        Dim conexiones44 As New CConexion
        conexiones44.conexion()
        _adaptador.SelectCommand = New SqlCommand(" select [NROSOCIO],SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD,dbo.puntos([MONTO_SOLICITUD]) AS MONTO ,ESTADO_SOLICITUD,[NOMBRE_SOCIO],FORMA_PAGO,SUCURSAL,Aprobacion_SubGerencia ,id_solicitud   from [_RIESGO_SOLICITUD_GIRO_CAPITAL] where REEVALUACION='SI' AND Aprobacion_SubGerencia <>'Por Analizar'  and  (FECHA_SOLICITUD BETWEEN '" + Trim(fechadesde.ToString) + "' and '" + Trim(fechahasta.ToString) + "')   order by id_solicitud desc   ", conexiones44._conexion)
        conexiones44.abrir()
        _adaptador.Fill(_tabla26)
        Gridreconcideraciones.DataSource = _tabla26
        conexiones44.cerrar()
        Gridreconcideraciones.ClearSelection()





    End Sub

    Sub BuscarReconcideracdionporFechaVIÑADELMAR()

        _tabla26.Rows.Clear()
        _tabla26.Columns.Clear()


        Dim fechadesde As String = ""
        Dim fechahasta As String = ""


        fechadesde = Trim(Textdesdeaño.Text) + Trim(Textdesdemes.Text) + Trim(Textdesdedia.Text)
        fechahasta = Trim(TextHASTAAÑO.Text) + Trim(TextHASTAMES.Text) + Trim(Texthastadia.Text)
        '  MsgBox(fechadesde)
        'MsgBox(fechahasta)


        ' select [NROSOCIO],SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD,[MONTO_SOLICITUD],ESTADO_SOLICITUD,[NOMBRE_SOCIO],FORMA_PAGO,SUCURSAL,Aprobacion_SubGerencia ,id_solicitud   from [_RIESGO_SOLICITUD_GIRO_CAPITAL] where REEVALUACION='SI' AND Aprobacion_SubGerencia <>'Por Analizar'  and  (FECHA_SOLICITUD BETWEEN '" + Trim(fechadesde.ToString) + "' and '" + Trim(fechahasta.ToString) + "')   order by id_solicitud desc   ", conexiones44._conexion)

        Dim conexiones44 As New CConexion
        conexiones44.conexion()
        _adaptador.SelectCommand = New SqlCommand(" select [NROSOCIO],SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD,dbo.puntos([MONTO_SOLICITUD]) AS MONTO ,ESTADO_SOLICITUD,[NOMBRE_SOCIO],FORMA_PAGO,SUCURSAL,Aprobacion_SubGerencia ,id_solicitud   from [_RIESGO_SOLICITUD_GIRO_CAPITAL] where REEVALUACION='SI' AND Aprobacion_SubGerencia <>'Por Analizar'  and  (FECHA_SOLICITUD BETWEEN '" + Trim(fechadesde.ToString) + "' and '" + Trim(fechahasta.ToString) + "') AND SUCURSAL2=2   order by id_solicitud desc   ", conexiones44._conexion)
        conexiones44.abrir()
        _adaptador.Fill(_tabla26)
        Gridreconcideraciones.DataSource = _tabla26
        conexiones44.cerrar()
        Gridreconcideraciones.ClearSelection()





    End Sub

    Sub BuscarReconcideracdionporFechaVVALPARAISO()

        _tabla26.Rows.Clear()
        _tabla26.Columns.Clear()


        Dim fechadesde As String = ""
        Dim fechahasta As String = ""


        fechadesde = Trim(Textdesdeaño.Text) + Trim(Textdesdemes.Text) + Trim(Textdesdedia.Text)
        fechahasta = Trim(TextHASTAAÑO.Text) + Trim(TextHASTAMES.Text) + Trim(Texthastadia.Text)
        '  MsgBox(fechadesde)
        'MsgBox(fechahasta)


        ' select [NROSOCIO],SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD,[MONTO_SOLICITUD],ESTADO_SOLICITUD,[NOMBRE_SOCIO],FORMA_PAGO,SUCURSAL,Aprobacion_SubGerencia ,id_solicitud   from [_RIESGO_SOLICITUD_GIRO_CAPITAL] where REEVALUACION='SI' AND Aprobacion_SubGerencia <>'Por Analizar'  and  (FECHA_SOLICITUD BETWEEN '" + Trim(fechadesde.ToString) + "' and '" + Trim(fechahasta.ToString) + "')   order by id_solicitud desc   ", conexiones44._conexion)

        Dim conexiones44 As New CConexion
        conexiones44.conexion()
        _adaptador.SelectCommand = New SqlCommand(" select [NROSOCIO],SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD,dbo.puntos([MONTO_SOLICITUD]) AS MONTO ,ESTADO_SOLICITUD,[NOMBRE_SOCIO],FORMA_PAGO,SUCURSAL,Aprobacion_SubGerencia ,id_solicitud   from [_RIESGO_SOLICITUD_GIRO_CAPITAL] where REEVALUACION='SI' AND Aprobacion_SubGerencia <>'Por Analizar'  and  (FECHA_SOLICITUD BETWEEN '" + Trim(fechadesde.ToString) + "' and '" + Trim(fechahasta.ToString) + "') AND SUCURSAL2=1   order by id_solicitud desc   ", conexiones44._conexion)
        conexiones44.abrir()
        _adaptador.Fill(_tabla26)
        Gridreconcideraciones.DataSource = _tabla26
        conexiones44.cerrar()
        Gridreconcideraciones.ClearSelection()





    End Sub

    Sub IdentificarEstados()

        Dim totalfilas As Integer = Gridreconcideraciones.Rows.Count - 1
        Dim tomadato As String = ""
        Dim tomaid As String = ""
        Dim estado2 As String = ""
        Dim estado3 As String = ""
        Dim estado_solicitud As String = ""


        For z = 0 To totalfilas
            tomadato = Trim(Gridreconcideraciones.Rows(z).Cells(3).Value())

            If tomadato = "PAGADO" Then

                Gridreconcideraciones.Rows(z).Cells(3).Style.BackColor = Color.Blue
                Gridreconcideraciones.Rows(z).Cells(3).Style.ForeColor = Color.White

            ElseIf tomadato = "RECONSIDERACIÓN" Then

                Gridreconcideraciones.Rows(z).Cells(3).Style.BackColor = Color.Orange
                Gridreconcideraciones.Rows(z).Cells(3).Style.ForeColor = Color.White

            ElseIf tomadato = "RECHAZADA" Then

                Gridreconcideraciones.Rows(z).Cells(3).Style.BackColor = Color.Red
                Gridreconcideraciones.Rows(z).Cells(3).Style.ForeColor = Color.White

            ElseIf tomadato = "ANULADA" Then

                Gridreconcideraciones.Rows(z).Cells(3).Style.BackColor = Color.Red
                Gridreconcideraciones.Rows(z).Cells(3).Style.ForeColor = Color.White

            ElseIf tomadato = "APROBADO" Then

                Gridreconcideraciones.Rows(z).Cells(3).Style.BackColor = Color.Green
                Gridreconcideraciones.Rows(z).Cells(3).Style.ForeColor = Color.White

            ElseIf tomadato = "PREAPROBADO" Then

                Gridreconcideraciones.Rows(z).Cells(3).Style.BackColor = Color.Green
                Gridreconcideraciones.Rows(z).Cells(3).Style.ForeColor = Color.White

            End If

            Gridreconcideraciones.Rows(z).Cells(0).Style.BackColor = Color.LightBlue
            Gridreconcideraciones.Rows(z).Cells(1).Style.BackColor = Color.LightBlue
            Gridreconcideraciones.Rows(z).Cells(2).Style.BackColor = Color.LightBlue
            Gridreconcideraciones.Rows(z).Cells(4).Style.BackColor = Color.LightBlue
            Gridreconcideraciones.Rows(z).Cells(5).Style.BackColor = Color.LightBlue
            Gridreconcideraciones.Rows(z).Cells(6).Style.BackColor = Color.LightBlue
            Gridreconcideraciones.Rows(z).Cells(7).Style.BackColor = Color.LightBlue
            Gridreconcideraciones.Rows(z).Cells(8).Style.BackColor = Color.LightBlue


        Next
    End Sub


    Private Sub Gridreconcideraciones_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Gridreconcideraciones.CellContentClick

    End Sub

    Private Sub Gridreconcideraciones_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Gridreconcideraciones.SelectionChanged
        Try
            Dim ID As String = ""
            'Dim reciberazonsocial As String = 0


            ID = Gridreconcideraciones.Rows(Gridreconcideraciones.CurrentRow.Index).Cells(8).Value().ToString()
            Dim conexiones33 As New CConexion
            conexiones33.conexion()
            Dim command33 As SqlCommand = New SqlCommand("select COMENTARIO_EVALUACION,COMENTARIO_SUBGERENTE,COMENTARIO_SUBGERENTE_FINANZAS,COMENTARIO_LIBERA_CAPITAL,[FILTRO_CAPITAL_MINIMO],[FILTRO_MONTO_SOLICITADO],[FILTRO_GIROS_ANUAL],[FILTRO_GIROS_MENSUAL],[FILTRO_SOCIO_SINMORA],[FILTRO_AVAL_SINMORA],[FILTRO_RESTRICCIONES] ,[FILTRO_CAPITAL_GLOBAL]   from  [_RIESGO_SOLICITUD_GIRO_CAPITAL]   where ID_SOLICITUD= " + Trim(ID) + " ", conexiones33._conexion)
            conexiones33.abrir()
            Dim reader33 As SqlDataReader = command33.ExecuteReader()
            If reader33.HasRows Then
                Do While reader33.Read()

                    txtComentarioEjecutiva.Text = reader33(0).ToString
                    TextComentarioSubGerente.Text = reader33(1).ToString
                    TextComentaroSubgerenteFinazas.Text = reader33(2).ToString
                    TextComentarioLiberacapital.Text = reader33(3).ToString

                    Label15.Text = reader33(4).ToString ' capital minimo 
                    Label16.Text = reader33(5).ToString ' monto maximo retirable
                    Label17.Text = reader33(6).ToString ' 
                    Label18.Text = reader33(8).ToString
                    Label19.Text = reader33(9).ToString
                    Label20.Text = reader33(10).ToString
                    Label21.Text = reader33(11).ToString




                Loop
            Else
            End If
            reader33.Close()
            '  bandera = True
        Catch ex As Exception
            MsgBox("No existen comentarios sobre la reconcideracion ")
            ' bandera = False
        End Try
    End Sub

    Private Sub Textdesdedia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textdesdedia.TextChanged
        If Not IsNumeric(Trim(Textdesdedia.Text)) Then
            MsgBox("Debe Ingresar Valores Numericos ")
        Else

            Dim TOTOAL As Double = 0
            TOTOAL = Len(Textdesdedia.Text)

            If TOTOAL = 2 Then

                Textdesdemes.Focus()


            End If
        End If
    End Sub

    Private Sub Textdesdemes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textdesdemes.TextChanged
        If Not IsNumeric(Trim(Textdesdemes.Text)) Then
            MsgBox("Debe Ingresar Valores Numericos ")
        Else

            Dim TOTOAL As Double = 0
            TOTOAL = Len(Textdesdemes.Text)

            If TOTOAL = 2 Then

                Textdesdeaño.Focus()


            End If
        End If
    End Sub

    Private Sub Textdesdeaño_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textdesdeaño.TextChanged
        If Not IsNumeric(Trim(Textdesdeaño.Text)) Then
            MsgBox("Debe Ingresar Valores Numericos ")
        Else

            Dim TOTOAL As Double = 0
            TOTOAL = Len(Textdesdeaño.Text)

            If TOTOAL = 4 Then

                Texthastadia.Focus()


            End If
        End If
    End Sub

    Private Sub Texthastadia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Texthastadia.TextChanged
        If Not IsNumeric(Trim(Texthastadia.Text)) Then
            MsgBox("Debe Ingresar Valores Numericos ")
        Else

            Dim TOTOAL As Double = 0
            TOTOAL = Len(Texthastadia.Text)

            If TOTOAL = 2 Then

                TextHASTAMES.Focus()


            End If
        End If
    End Sub

    Private Sub TextHASTAMES_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextHASTAMES.TextChanged
        If Not IsNumeric(Trim(TextHASTAMES.Text)) Then
            MsgBox("Debe Ingresar Valores Numericos ")
        Else

            Dim TOTOAL As Double = 0
            TOTOAL = Len(TextHASTAMES.Text)

            If TOTOAL = 2 Then

                TextHASTAAÑO.Focus()


            End If
        End If
    End Sub

    Private Sub TextHASTAAÑO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextHASTAAÑO.TextChanged
        If Not IsNumeric(Trim(TextHASTAAÑO.Text)) Then
            MsgBox("Debe Ingresar Valores Numericos ")
        Else

            Dim TOTOAL As Double = 0
            TOTOAL = Len(TextHASTAAÑO.Text)

            If TOTOAL = 4 Then
                BotonbuscarReconcideracion.Focus()


            End If
        End If
    End Sub

    Private Sub BotonbuscarReconcideracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonbuscarReconcideracion.Click

        If Textdesdedia.Text = "" Or Textdesdemes.Text = "" Or Textdesdeaño.Text = "" Or Texthastadia.Text = "" Or TextHASTAMES.Text = "" Or TextHASTAAÑO.Text = "" Then


            MsgBox("Debe Ingresar Dia ,Mes y Año para realizar la busqueda ")


        Else

            If (Checviña.Checked = CheckState.Unchecked And Checvalpo.Checked = CheckState.Unchecked Or Checviña.Checked = CheckState.Checked Or Checvalpo.Checked = CheckState.Checked) Or (Checviña.Checked = False And Checvalpo.Checked = False Or Checviña.Checked = True And Checvalpo.Checked = True) Then

                BuscarReconcideracdionporFecha()
                IdentificarEstados()

            ElseIf Checviña.Checked = CheckState.Checked Or Checviña.Checked = True And Checvalpo.Checked = CheckState.Unchecked Or Checvalpo.Checked = False Then

                BuscarReconcideracdionporFechaVIÑADELMAR()
                IdentificarEstados()

            ElseIf Checviña.Checked = CheckState.Unchecked Or Checviña.Checked = False And Checvalpo.Checked = CheckState.Checked Or Checvalpo.Checked = True Then

                BuscarReconcideracdionporFechaVVALPARAISO()
                IdentificarEstados()

            End If

        End If


    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub
End Class