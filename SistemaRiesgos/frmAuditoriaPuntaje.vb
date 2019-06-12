Imports System.Data
Imports System.Data.SqlClient
Public Class frmAuditoriaPuntaje
    Dim plantillas As Metodos = New Metodos
    Dim plantillas2 As CCEstadosGeneral = New CCEstadosGeneral
    Dim plantillas3 As CGenerales = New CGenerales
    Dim tabla As New DataTable
    Dim tabla2 As New DataTable
    Dim Datos As New CDatos
    Private Sub frmAuditoriaPuntaje_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        plantillas._tabla.Rows.Clear()
        plantillas._tabla.Columns.Clear()

        If plantillas.Consultar_puntajes() Then
            tabla = plantillas.tabla
            DGPuntajes.DataSource = tabla
        End If


        CboAnalisis.Items.Clear()
        CboAnalisis.Items.Add("TODOS")
        Dim conexiones1 As New CConexion
        conexiones1.conexion()
        Dim command1 As SqlCommand = New SqlCommand("SELECT DISTINCT(rtrim(ANALISIS)) FROM [_RIESGO_PUNTAJES] WHERE ANALISIS IS NOT NULL", conexiones1._conexion)
        conexiones1.abrir()
        Dim reader1 As SqlDataReader = command1.ExecuteReader()
        If reader1.HasRows Then
            Do While reader1.Read()
                CboAnalisis.Items.Add(reader1(0).ToString)
            Loop
        Else
        End If
        reader1.Close()

  


        Datos._Sql = "select distinct([Categoria]) FROM [_RIESGO_SCORING2]  order by Categoria asc"
        plantillas.CargarDatos_combobox_conblancos(Datos, cboCategoria)

        Datos._Sql = "select distinct(Tipo) FROM [_RIESGO_SCORING2]  order by Tipo asc"
        plantillas.CargarDatos_combobox_conblancos(Datos, cboTipo)
        plantillas.CargarDatos_combobox(Datos, cboTipo2)
        cboTipo2.Items.Add("TODOS")
        cboTipo2.SelectedItem = "TODOS"
        CARGARPUNTAJES2(cboTipo2.SelectedItem.ToString)

        'Dim inicio As Integer = -1
        'Dim final As Integer = 10000000
        'Do While inicio < final
        '    cboTipo.Items.Add(inicio)
        '    inicio = inicio + 1
        'Loop


    End Sub
    Sub CARGARPUNTAJES2(ByVal tipo As String)



        Dim conexiones2 As New CConexion
        conexiones2.conexion()
        conexiones2.abrir()
        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter
        Dim dtTable As DataTable

        'Indico el SP que voy a utilizar
        If tipo = "TODOS" Then
            command = New SqlCommand("Riesgo_puntajes2", conexiones2._conexion)
            command.CommandType = CommandType.StoredProcedure
            adapter = New SqlDataAdapter(command)
            dtTable = New DataTable
        Else
            command = New SqlCommand("Riesgo_puntajes2_tipo", conexiones2._conexion)
            command.CommandType = CommandType.StoredProcedure
            adapter = New SqlDataAdapter(command)
            dtTable = New DataTable
            With command.Parameters
                'Envió los parámetros que necesito
                .Add(New SqlParameter("@tipo", SqlDbType.VarChar)).Value = tipo
            End With
        End If
       
     
        Try
            'Aquí ejecuto el SP y lo lleno en el DataTable
            adapter.Fill(dtTable)
            'Enlazo mis datos obtenidos en el DataTable con el grid
            DGPuntajes2.DataSource = dtTable
            'Si no pongo esta línea, se crean automáticamente los campos del grid dependiendo de los campos del DataTable
            DGPuntajes2.AutoGenerateColumns = False
            'Aquí le indico cuales campos del select de mi SP van con los campos de mi grid
            'With DGPuntajes2
            '    .Columns("Tipo").DataPropertyName = "Tipo"
            '    '.Columns("Campo2").DataPropertyName = "campo2"
            '    '.Columns("Campo3").DataPropertyName = "campo3"
            'End With
        Catch expSQL As SqlException
            MsgBox(expSQL.ToString, MsgBoxStyle.OkOnly, "SQL Exception")
            Exit Sub
        End Try


        'DGPuntajes2.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable


        'Dim cmd2 As New SqlCommand("Riesgo_puntajes2", conexiones2._conexion)
        'Dim dr2 As SqlDataReader = cmd2.ExecuteReader(CommandBehavior.CloseConnection)
        'Command.CommandType = CommandType.StoredProcedure
        'DataTable(dt = New DataTable())
        'conexiones2.cerrar()





        'plantillas._tabla2.Rows.Clear()
        'plantillas._tabla2.Columns.Clear()

        'If plantillas.Consultar_puntajes2() Then
        '    tabla = plantillas.tabla2
        '    DGPuntajes2.DataSource = tabla
        'End If
    End Sub

    Private Sub DGPuntajes_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGPuntajes.SelectionChanged
        Try


            If DGPuntajes.Rows(DGPuntajes.CurrentRow.Index).Cells(1).Value = "" Then


            Else

                CboxCategoria.SelectedItem = ""
                txtTipo.Text = ""
                txtTipo2.Text = ""
                txtpuntaje.Text = ""
                CboxCategoria.Text = DGPuntajes.Rows(DGPuntajes.CurrentRow.Index).Cells(0).Value
                txtTipo.Text = DGPuntajes.Rows(DGPuntajes.CurrentRow.Index).Cells(1).Value
                txtTipo2.Text = DGPuntajes.Rows(DGPuntajes.CurrentRow.Index).Cells(2).Value
                txtpuntaje.Text = DGPuntajes.Rows(DGPuntajes.CurrentRow.Index).Cells(3).Value

                'txtBuscar.Text = DGDatos.Rows(DGDatos.CurrentRow.Index).Cells(3).Value
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



        Dim puntaje As String = txtpuntaje.Text
        Dim categoria As String = CboxCategoria.SelectedItem.ToString
        Dim id As String = DGPuntajes.Rows(DGPuntajes.CurrentRow.Index).Cells(4).Value

        Dim conexiones5 As New CConexion
        conexiones5.conexion()
        Dim command5 As SqlCommand = New SqlCommand("  update _RIESGO_PUNTAJES set puntaje='" + puntaje + "' where  id='" + id + "'", conexiones5._conexion)
        conexiones5.abrir()
        Dim reader5 As SqlDataReader = command5.ExecuteReader()
        reader5.Close()

        MsgBox("Actualizado con exito")

        plantillas._tabla.Rows.Clear()
        plantillas._tabla.Columns.Clear()

        If plantillas.Consultar_puntajes() Then
            tabla = plantillas.tabla
            DGPuntajes.DataSource = tabla
        End If




    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        plantillas._tabla.Rows.Clear()
        plantillas._tabla.Columns.Clear()

        If plantillas.Consultar_puntajes() Then
            tabla = plantillas.tabla
            DGPuntajes.DataSource = tabla
        End If
    End Sub

    Private Sub DGPuntajes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGPuntajes.CellContentClick

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (CboAnalisis.SelectedItem = "TODOS") Then
            plantillas._tabla.Rows.Clear()
            plantillas._tabla.Columns.Clear()
            If plantillas.Consultar_puntajes() Then
                tabla = plantillas.tabla
                DGPuntajes.DataSource = tabla
            End If
        Else
            Datos._Analisis = CboAnalisis.SelectedItem.ToString.Trim
            plantillas._tabla.Rows.Clear()
            plantillas._tabla.Columns.Clear()
            If plantillas.Consultar_puntajesxAnalisis(Datos) Then
                tabla = plantillas.tabla
                DGPuntajes.DataSource = tabla
            End If
        End If
    End Sub


    Private Sub DGPuntajes2_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGPuntajes2.SelectionChanged
        Try


            If DGPuntajes2.Rows(DGPuntajes2.CurrentRow.Index).Cells(1).Value = "" Then


            Else

                cboTipo.SelectedItem = ""
                cboCategoria.SelectedItem = ""
                TxtRango1.Text = ""
                TxtRango2.Text = ""
                txtPuntajeBueno.Text = ""
                TxtPuntajeMalo.Text = ""
                cboNumerico.SelectedItem = ""
                cboSubCategoria.SelectedItem = ""
                txtIdTabla.Text = ""
                txtIdTipo.Text = ""
                txtSaldo.Text = ""
                txtCastigo.Text = ""

                cboTipo.SelectedItem = DGPuntajes2.Rows(DGPuntajes2.CurrentRow.Index).Cells("Tipo").Value
                cboCategoria.SelectedItem = DGPuntajes2.Rows(DGPuntajes2.CurrentRow.Index).Cells("Categoria").Value
                TxtRango1.Text = DGPuntajes2.Rows(DGPuntajes2.CurrentRow.Index).Cells("Rango1").Value + " >"
                TxtRango2.Text = DGPuntajes2.Rows(DGPuntajes2.CurrentRow.Index).Cells("Rango2").Value + " <="
                txtPuntajeBueno.Text = DGPuntajes2.Rows(DGPuntajes2.CurrentRow.Index).Cells("Bueno").Value
                TxtPuntajeMalo.Text = DGPuntajes2.Rows(DGPuntajes2.CurrentRow.Index).Cells("Malo").Value
                cboNumerico.SelectedItem = DGPuntajes2.Rows(DGPuntajes2.CurrentRow.Index).Cells("numerico").Value
                cboSubCategoria.SelectedItem = DGPuntajes2.Rows(DGPuntajes2.CurrentRow.Index).Cells("SubCategoria").Value
                txtIdTabla.Text = DGPuntajes2.Rows(DGPuntajes2.CurrentRow.Index).Cells("id_tabla").Value
                txtIdTipo.Text = DGPuntajes2.Rows(DGPuntajes2.CurrentRow.Index).Cells("ID_TIPO").Value
                txtSaldo.Text = DGPuntajes2.Rows(DGPuntajes2.CurrentRow.Index).Cells("Saldo").Value
                txtCastigo.Text = DGPuntajes2.Rows(DGPuntajes2.CurrentRow.Index).Cells("Castigo").Value
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Datos._Tipo = cboTipo.SelectedItem.ToString
        Datos._Categoria = cboCategoria.SelectedItem.ToString
        Datos._Rango1 = Replace(TxtRango1.Text, ">", "")
        Datos._Rango2 = Replace(Replace(TxtRango2.Text, "<", ""), "=", "")
        Datos._Bueno = txtPuntajeBueno.Text
        Datos._Malo = TxtPuntajeMalo.Text
        Datos._Saldo = txtSaldo.Text
        Datos._Castigo = txtCastigo.Text
        Datos._SubCategoria = cboSubCategoria.SelectedItem.ToString
        Datos._numerico = cboNumerico.SelectedItem.ToString
        Datos._id_tipo = txtIdTipo.Text
        Datos._Perfil = frmPerfil.CbmUsuario.SelectedItem
        If plantillas2.Agregar_Puntaje(Datos) Then
            MsgBox("MODIFICADO CON EXITO")
            CARGARPUNTAJES2(cboTipo2.SelectedItem.ToString)
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        plantillas3.ExportarDatosExcel(DGPuntajes2, "Sistema de Riesgo")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click


        CARGARPUNTAJES2(cboTipo2.SelectedItem.ToString)


    End Sub
End Class