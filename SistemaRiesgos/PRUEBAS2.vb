Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class PRUEBAS2
    'Public Cadena As String = "Data Source=(local);Initial Catalog=DocBD;Integrated Security = True"
    Public Cadena As String = "Data Source=192.168.0.173; Initial Catalog=DocBD; User ID=sa;Password=universo"

    Public conexion As SqlConnection = New SqlConnection(Cadena)
    Public cmd As SqlCommand
    Public da As SqlDataAdapter
    Public dtb As DataTable
    Public ar As String = ""





   

    Sub Limpiar()
        txtRuta.Clear()
        txtTitulo.Clear()
    End Sub

    Public Function GenerarNombreFichero()
        Dim ultimoTick As Integer = 0
        While ultimoTick = Environment.TickCount
            System.Threading.Thread.Sleep(1)
        End While
        ultimoTick = Environment.TickCount
        Return DateTime.Now.ToString("yyyyMMddhhmmss") + "." + ultimoTick.ToString()
    End Function



    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim open As New OpenFileDialog()
        open.Title = "Abrir"
        open.Filter = "Archivos Docx(*.pdf)|*.pdf|Archivos Docx(*.docx)|*.docx|Archivos doc(*.doc)|*.doc|Todos los Archivos(*.*)|*.*"
        If open.ShowDialog() = DialogResult.OK Then
            ar = open.FileName
            'MsgBox(ar)
            txtRuta.Text = ar
            txtTitulo.Text = open.SafeFileName
        End If
        Try
            txtFecha.Text = txtTitulo.Text.Substring(0, 10)
            txtRut.Text = txtTitulo.Text.Substring(11, 10)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'txtRuta.Text = DataGridView2.Rows(0).Cells(0).Value.ToString
        'txtTitulo.Text = DataGridView2.Rows(1).Cells(1).Value.ToString


        If txtRuta.Text <> "" Or txtTitulo.Text <> "" Or Cbotipo.SelectedItem <> "" Then
            Dim fs As New FileStream(ar, FileMode.Open)
            Dim data(0 To fs.Length - 1) As Byte
            fs.Read(data, 0, Convert.ToInt32(fs.Length))
            If conexion.State = 0 Then
                conexion.Open()
            End If
            cmd = New SqlCommand("P_Doc3", conexion)
            cmd.CommandType = CommandType.StoredProcedure


            cmd.Parameters.Add("@doc", SqlDbType.VarBinary).Value = data
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = txtTitulo.Text
            'cmd.Parameters.Add("@tipo", SqlDbType.VarChar, 100).Value = "ADJUNTOS"
            cmd.Parameters.Add("@tipo", SqlDbType.VarChar, 100).Value = Cbotipo.SelectedItem.ToString
            cmd.Parameters.Add("@rut", SqlDbType.VarChar, 100).Value = txtRut.Text.Trim
            cmd.Parameters.Add("@fecha", SqlDbType.VarChar, 100).Value = txtFecha.Text.Trim



            cmd.ExecuteNonQuery()
            MessageBox.Show("Guardado Correctamente")
            Me.PRUEBAS2_Load(Nothing, Nothing)
            conexion.Close()
            fs.Close()
            Limpiar()
        Else
            MessageBox.Show("Adjuntar y escribir Ttulo", "Error Guardar", MessageBoxButtons.OK)

        End If

    End Sub





    Private Sub btnLeer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeer.Click
        Dim i As Integer = Me.DataGridView1.CurrentRow.Index
        Dim cod As Integer = Integer.Parse(Me.DataGridView1.Rows(i).Cells(0).Value.ToString())
        cmd = New SqlCommand("select doc from documentos where docId=" & cod & "", conexion)
        da = New SqlDataAdapter(cmd)
        dtb = New DataTable()
        da.Fill(dtb)
        Dim f As DataRow = dtb.Rows(0)
        Dim Bits As Byte() = (CType((f.ItemArray(0)), Byte()))
        Dim sFile As String = "tmp" & GenerarNombreFichero() & ".pdf"
        Dim fs As New FileStream(sFile, FileMode.Create)
        fs.Write(Bits, 0, Convert.ToInt32(Bits.Length))
        fs.Close()
        Dim obj As System.Diagnostics.Process = New System.Diagnostics.Process()
        AxAcroPDF1.src = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
        'AxAcroPDF1.setCurrentPage(2)
        'AxAcroPDF1.setZoom(90)
        Dim ArchivoBorrar As String
        ArchivoBorrar = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
        If System.IO.File.Exists(ArchivoBorrar) = True Then
            System.IO.File.Delete(ArchivoBorrar)
        End If
    End Sub














    Private Sub PRUEBAS2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load




        'txtRuta.Enabled = False
        'txtTitulo.Focus()
        Cbotipo.SelectedItem = "DICOM"

        'buscartodos()


        'txtRuta.Enabled = False
        'txtTitulo.Focus()
        'cmd = New SqlCommand("select RTRIM('C:\Users\ccampos\Desktop\_____DOCUMENTOS HISTORICO_____\'+nombre) AS RUTA ,nombre AS NOMBRE,SUBSTRING(replace(nombre,'.pdf',''),12,10) as rut ,SUBSTRING(replace(nombre,'.pdf',''),1,10) as fecha from _ARCHIVOS_ADJUNTOS", conexion)
        cmd = New SqlCommand("select RTRIM('C:\ADJUNTO\'+nombre) AS RUTA ,nombre AS NOMBRE,SUBSTRING(replace(nombre,'.pdf',''),12,10) as rut ,SUBSTRING(replace(nombre,'.pdf',''),1,10) as fecha from [DocBD].[dbo].ADJUNTOS", conexion)
        da = New SqlDataAdapter(cmd)
        dtb = New DataTable()
        da.Fill(dtb)
        DataGridView2.DataSource = dtb
        DataGridView2.Columns(1).Width = 250
        conexion.Close()
        DataGridView2.AllowUserToAddRows = False

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If DataGridView2.Rows.Count > 0 Then
            For i As Integer = 0 To DataGridView2.Rows.Count - 1
                'For i As Integer = 0 To 5
                'DataGridView2.CurrentCell = DataGridView2.Rows(i).Cells(0)
                txtRuta.Text = DataGridView2.Rows(i).Cells(0).Value.ToString
                txtTitulo.Text = DataGridView2.Rows(i).Cells(1).Value.ToString
                txtRut.Text = DataGridView2.Rows(i).Cells(2).Value.ToString
                txtFecha.Text = DataGridView2.Rows(i).Cells(3).Value.ToString

                ar = txtRuta.Text
                guardarbinario()
            Next
            MsgBox("Realizado")
            'If DataGridView.Item("CodigoTabla1", DataGridView.CurrentRow.Index).Value() = ComboBox1.SelectedValue Then
            '    MsgBox("El Codigo Seleccionado del Combobox ya ha sido utilizado en el Datagrid                                  y No puede repetirse!")
            '    Me.ComboBox1.Focus()
            Exit Sub
        End If


    End Sub



    Sub guardarbinario()


        If txtRuta.Text <> "" AndAlso txtTitulo.Text <> "" Then
            'MsgBox(txtRuta.Text)
            'MsgBox(txtTitulo.Text)
            Dim fs As New FileStream(ar, FileMode.Open)
            Dim data(0 To fs.Length - 1) As Byte
            fs.Read(data, 0, Convert.ToInt32(fs.Length))
            If conexion.State = 0 Then
                conexion.Open()
            End If
            cmd = New SqlCommand("P_Doc", conexion)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add("@doc", SqlDbType.VarBinary).Value = data
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = txtTitulo.Text
            cmd.Parameters.Add("@tipo", SqlDbType.VarChar, 100).Value = "ADJUNTOS"
            'cmd.Parameters.Add("@tipo", SqlDbType.VarChar, 100).Value = "DICOM"
            cmd.Parameters.Add("@rut", SqlDbType.VarChar, 100).Value = txtRut.Text.Trim
            cmd.Parameters.Add("@fecha", SqlDbType.VarChar, 100).Value = txtFecha.Text.Trim

            cmd.ExecuteNonQuery()
            Me.PRUEBAS2_Load(Nothing, Nothing)
            conexion.Close()
            fs.Close()
            Limpiar()
        Else
            MessageBox.Show("Adjuntar y escribir Ttulo", "Error Guardar", MessageBoxButtons.OK)

        End If

    End Sub














    Sub buscarrut()
        txtTitulo.Focus()
        cmd = New SqlCommand("select top 100 docid,rut,fecha,tipo from documentos where rut='" + txtRut.Text.ToString.Trim + "'", conexion)
        da = New SqlDataAdapter(cmd)
        dtb = New DataTable()
        da.Fill(dtb)
        DataGridView1.DataSource = dtb
        DataGridView1.Columns(1).Width = 250
        conexion.Close()

    End Sub


    Sub buscartodos()
        cmd = New SqlCommand("select top 100 docid,rut,fecha,tipo from documentos", conexion)
        da = New SqlDataAdapter(cmd)
        dtb = New DataTable()
        da.Fill(dtb)
        DataGridView1.DataSource = dtb
        DataGridView1.Columns(1).Width = 250
        conexion.Close()
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If txtRut.Text.ToString.Trim = "" Then
            buscartodos()
        Else
            buscarrut()
        End If

    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Try
            txtRut.Text = ""

            txtRut.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("rut").Value

        Catch ex As Exception

        End Try
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        AxAcroPDF1.gotoPreviousPage()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        AxAcroPDF1.gotoNextPage()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        AxAcroPDF1.setCurrentPage(txtPagina.Text)
    End Sub

    Private Sub Cbotipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbotipo.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)


        'Dim politicas As String = ""

        'Dim valor As Decimal = Math.Round(((((Integer.Parse(Replace(txtID.Text, ".", "")) * 100)) / TextBox2.Text) - 100), 1)
        'MsgBox(valor)



        'If valor > 5 Then
        '    politicas = politicas + "2:  la diferencia es un " + valor.ToString + "% más alto es MALO" + Environment.NewLine + Environment.NewLine



        'ElseIf valor <= 5 And valor > 0 Then

        '    politicas = politicas + "2:  la diferencia es un " + valor.ToString + "% más alto pero es BUENO" + Environment.NewLine + Environment.NewLine


        'ElseIf valor = 0 Then

        '    politicas = politicas + "2: la diferencia es igual es BUENO" + Environment.NewLine + Environment.NewLine

        'Else

        '    politicas = politicas + "2: la diferencia es un " + valor.ToString + "% más bajo es BUENO" + Environment.NewLine + Environment.NewLine
        'End If

        'MsgBox(politicas)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        txtFecha.Text = ""
        txtRut.Text = ""

        Dim conexiones14 As New CConexion
        conexiones14.conexion()
        'Dim command14 As SqlCommand = New SqlCommand("SELECT MAX([PLAZO]) AS PLAZO ,SUM([PRIMERDIVIDENDO]) AS CUOTA FROM [_PRESTDIARIO] where CORCREDITO IN (select PRESTAMO from _RIESGO_DEUDAS_CREDITOS where perfil='" + Trim(frmPerfil.CbmUsuario.SelectedItem.ToString) + "' and Estado<>'Normal' ) GROUP BY NROSOCIO", conexiones14._conexion)
        Dim command14 As SqlCommand = New SqlCommand("SELECT SUBSTRING([fecha_solicitud],1,10) AS FECHA,RUT FROM _RIESGO_PRESTAMOS_SOLICITADOS WHERE ID_SOLICITUD=" + txtID.Text + "", conexiones14._conexion)
        conexiones14.abrir()
        Dim reader14 As SqlDataReader = command14.ExecuteReader()

        If reader14.HasRows Then
            Do While reader14.Read()
                txtFecha.Text = (reader14(0).ToString)
                txtRut.Text = (reader14(1).ToString)
            Loop
        Else
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim open As New OpenFileDialog()
        open.Title = "Abrir"
        open.Filter = "Archivos Docx(*.pdf)|*.pdf|Archivos Docx(*.docx)|*.docx|Archivos doc(*.doc)|*.doc|Todos los Archivos(*.*)|*.*"
        If open.ShowDialog() = DialogResult.OK Then
            ar = open.FileName
            'MsgBox(ar)
            txtRuta.Text = ar
            txtTitulo.Text = open.SafeFileName
        End If
        Try
            'txtFecha.Text = txtTitulo.Text.Substring(0, 10)
            'txtRut.Text = txtTitulo.Text.Substring(11, 10)
        Catch ex As Exception

        End Try
    End Sub
End Class