
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms
Public Class frmFichaHistorico


    Dim plantillas As Metodos = New Metodos
    Dim tabla As New DataTable
    Dim Datos As New CDatos
    Dim id As String = ""
    '<BrowsableAttribute(False)>
    Public Property SelectionBullet As Boolean

    'Public Cadena As String = "Data Source=(local);Initial Catalog=DocBD;Integrated Security = True"

    'Public Cadena As String = "Data Source=192.168.0.173; Initial Catalog=DocBD; User ID=sa;Password=universo"
    'Public conexion As SqlConnection = New SqlConnection(Cadena)
    Public cmd As SqlCommand
    Public da As SqlDataAdapter
    Public dtb As DataTable
    Public ar As String = ""
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = 0 Then
            Dim i As Integer = Me.DataGridView1.CurrentRow.Index
            Dim cod As Integer = Integer.Parse(Me.DataGridView1.Rows(i).Cells(2).Value.ToString())
            Dim conexiones3 As New CConexion
            conexiones3.conexion()
            cmd = New SqlCommand("select doc from [DocBD].[dbo].documentos where docId=" & cod & " and estado=1 ", conexiones3._conexion)
            da = New SqlDataAdapter(cmd)
            dtb = New DataTable()
            da.Fill(dtb)
            Dim f As DataRow = dtb.Rows(0)
            Dim Bits As Byte() = (CType((f.ItemArray(0)), Byte()))
            Dim sFile As String = "a" & GenerarNombreFichero() & ".pdf"
            Dim fs As New FileStream(sFile, FileMode.Create)
            fs.Write(Bits, 0, Convert.ToInt32(Bits.Length))
            fs.Close()
            Dim obj As System.Diagnostics.Process = New System.Diagnostics.Process()
            'AxAcroPDF1.src = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
            AxAcroPDF1.src = "C:\SISTEMAS\Riesgo\" + sFile
            'AxAcroPDF1.setCurrentPage(2)
            AxAcroPDF1.setZoom(90)
            Dim ArchivoBorrar As String
            'ArchivoBorrar = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
            ArchivoBorrar = "C:\SISTEMAS\Riesgo\" + sFile
            If System.IO.File.Exists(ArchivoBorrar) = True Then
                System.IO.File.Delete(ArchivoBorrar)
            End If

        End If
    End Sub







    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If e.ColumnIndex = 0 Then
            Dim i As Integer = Me.DataGridView2.CurrentRow.Index
            Dim cod As Integer = Integer.Parse(Me.DataGridView2.Rows(i).Cells(2).Value.ToString())
            Dim conexiones3 As New CConexion
            conexiones3.conexion()
            cmd = New SqlCommand("select doc from [DocBD].[dbo].documentos where docId=" & cod & " and estado=1 ", conexiones3._conexion)
            da = New SqlDataAdapter(cmd)
            dtb = New DataTable()
            da.Fill(dtb)
            Dim f As DataRow = dtb.Rows(0)
            Dim Bits As Byte() = (CType((f.ItemArray(0)), Byte()))
            Dim sFile As String = "a" & GenerarNombreFichero() & ".pdf"
            Dim fs As New FileStream(sFile, FileMode.Create)
            fs.Write(Bits, 0, Convert.ToInt32(Bits.Length))
            fs.Close()
            Dim obj As System.Diagnostics.Process = New System.Diagnostics.Process()
            'AxAcroPDF2.src = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
            AxAcroPDF2.src = "C:\SISTEMAS\Riesgo\" + sFile
            'AxAcroPDF2.setCurrentPage(2)
            AxAcroPDF2.setZoom(90)
            Dim ArchivoBorrar As String
            'ArchivoBorrar = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
            ArchivoBorrar = "C:\SISTEMAS\Riesgo\" + sFile
            If System.IO.File.Exists(ArchivoBorrar) = True Then
                System.IO.File.Delete(ArchivoBorrar)
            End If

        End If
    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnteriorAdjuntos.Click
        AxAcroPDF2.gotoPreviousPage()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguenteAdjuntos.Click
        AxAcroPDF2.gotoNextPage()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnteriorDicom.Click
        AxAcroPDF1.gotoPreviousPage()
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguienteDicom.Click
        AxAcroPDF1.gotoNextPage()
    End Sub

    'Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim i As Integer = Me.DataGridView2.CurrentRow.Index
    '    Dim cod As Integer = Integer.Parse(Me.DataGridView2.Rows(i).Cells(0).Value.ToString())
    '    Dim conexiones3 As New CConexion
    '    conexiones3.conexion()
    '    cmd = New SqlCommand("select doc from [DocBD].[dbo].documentos where docId=" & cod & " and estado=1 ", conexiones3._conexion)
    '    da = New SqlDataAdapter(cmd)
    '    dtb = New DataTable()
    '    da.Fill(dtb)
    '    Dim f As DataRow = dtb.Rows(0)
    '    Dim Bits As Byte() = (CType((f.ItemArray(0)), Byte()))
    '    Dim sFile As String = "a" & GenerarNombreFichero() & ".pdf"
    '    Dim fs As New FileStream(sFile, FileMode.Create)
    '    fs.Write(Bits, 0, Convert.ToInt32(Bits.Length))
    '    fs.Close()
    '    Dim obj As System.Diagnostics.Process = New System.Diagnostics.Process()
    '    AxAcroPDF2.src = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
    '    'AxAcroPDF2.setCurrentPage(2)
    '    AxAcroPDF2.setZoom(90)
    '    Dim ArchivoBorrar As String
    '    ArchivoBorrar = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
    '    If System.IO.File.Exists(ArchivoBorrar) = True Then
    '        System.IO.File.Delete(ArchivoBorrar)
    '    End If
    'End Sub

    'Private Sub btnLeer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeer.Click

    'End Sub


    Private Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As TabControlCancelEventArgs) Handles TabControl1.Selecting
        'MsgBox(Me.TabControl1.SelectedIndex)

        If Me.TabControl1.SelectedIndex = 9 Then

            Try
                buscarrutDICOM()
                txtCodigo.Text = "select top 1  doc from [DocBD].[dbo].documentos where fecha='" & Trim(txtFecha.Text.ToString).Substring(0, 10) & "' and rut ='" & Trim(txtRut2.Text.ToString) & "' and tipo='DICOM' and estado=1 order by docid desc"
                Dim Archivo As String
                Dim conexiones3 As New CConexion
                conexiones3.conexion()
                cmd = New SqlCommand("select top 1  doc from [DocBD].[dbo].documentos where fecha='" & Trim(txtFecha.Text.ToString).Substring(0, 10) & "' and rut ='" & Trim(txtRut2.Text.ToString) & "' and tipo='DICOM' and estado=1  order by docid desc", conexiones3._conexion)
                da = New SqlDataAdapter(cmd)
                dtb = New DataTable()
                da.Fill(dtb)
                Dim f As DataRow = dtb.Rows(0)
                Dim Bits As Byte() = (CType((f.ItemArray(0)), Byte()))
                Dim sFile As String = "d" & GenerarNombreFichero() & ".pdf"
                Dim fs As New FileStream(sFile, FileMode.Create)
                fs.Write(Bits, 0, Convert.ToInt32(Bits.Length))
                fs.Close()
                Dim obj As System.Diagnostics.Process = New System.Diagnostics.Process()
                'Archivo = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
                Archivo = "C:\SISTEMAS\Riesgo\" + sFile
                AxAcroPDF1.src = Archivo
                'AxAcroPDF1.setCurrentPage(2)
                AxAcroPDF1.setZoom(90)
                If System.IO.File.Exists(Archivo) = True Then
                    System.IO.File.Delete(Archivo)
                End If

            Catch ex As Exception
                MsgBox("Dicom No encontrado")
            End Try
        End If




        If Me.TabControl1.SelectedIndex = 10 Then
            Try
                buscarrutADJUNTOS()
                txtCodigo.Text = "select top 1  doc from [DocBD].[dbo].documentos where fecha='" & Trim(txtFecha.Text.ToString).Substring(0, 10) & "' and rut ='" & Trim(txtRut2.Text.ToString) & "' and tipo='ADJUNTOS' and estado=1  order by docid desc"
                Dim Archivo As String
                Dim conexiones3 As New CConexion
                conexiones3.conexion()
                cmd = New SqlCommand("select top 1  doc from [DocBD].[dbo].documentos where fecha='" & Trim(txtFecha.Text.ToString).Substring(0, 10) & "' and rut ='" & Trim(txtRut2.Text.ToString) & "' and tipo='ADJUNTOS' and estado=1  order by docid desc", conexiones3._conexion)
                da = New SqlDataAdapter(cmd)
                dtb = New DataTable()
                da.Fill(dtb)
                Dim f As DataRow = dtb.Rows(0)
                Dim Bits As Byte() = (CType((f.ItemArray(0)), Byte()))
                Dim sFile As String = "a" & GenerarNombreFichero() & ".pdf"
                Dim fs As New FileStream(sFile, FileMode.Create)
                fs.Write(Bits, 0, Convert.ToInt32(Bits.Length))
                fs.Close()
                Dim obj As System.Diagnostics.Process = New System.Diagnostics.Process()
                'Archivo = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
                Archivo = "C:\SISTEMAS\Riesgo\" + sFile
                AxAcroPDF2.src = Archivo
                'AxAcroPDF1.setCurrentPage(2)
                AxAcroPDF2.setZoom(90)
                If System.IO.File.Exists(Archivo) = True Then
                    System.IO.File.Delete(Archivo)
                End If

            Catch ex As Exception
                MsgBox("Adjuntos No encontrado")
            End Try
        End If



    End Sub
    Public Function GenerarNombreFichero()
        Dim ultimoTick As Integer = 0
        While ultimoTick = Environment.TickCount
            System.Threading.Thread.Sleep(1)
        End While
        ultimoTick = Environment.TickCount
        Return DateTime.Now.ToString("yyyyMMddhhmmss") + "." + ultimoTick.ToString()
    End Function




    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnactualDicom.Click
        Try

            'MsgBox(Trim(txtFecha.Text.ToString).Substring(0, 10))
            'MsgBox(Trim(txtRut2.Text.ToString))

            'txtCodigo.Text = "select top 1  doc from [DocBD].[dbo].documentos where fecha='" & Trim(txtFecha.Text.ToString).Substring(0, 10) & "' and rut ='" & Trim(txtRut2.Text.ToString) & "' and tipo='DICOM' and estado=1  order by docid desc"
            Dim Archivo As String
            Dim conexiones3 As New CConexion
            conexiones3.conexion()
            cmd = New SqlCommand("select top 1  doc from [DocBD].[dbo].documentos where fecha='" & Trim(txtFecha.Text.ToString).Substring(0, 10) & "' and rut ='" & Trim(txtRut2.Text.ToString) & "' and tipo='DICOM' and estado=1  order by docid desc", conexiones3._conexion)
            da = New SqlDataAdapter(cmd)
            dtb = New DataTable()
            da.Fill(dtb)
            Dim f As DataRow = dtb.Rows(0)
            Dim Bits As Byte() = (CType((f.ItemArray(0)), Byte()))
            Dim sFile As String = "d" & GenerarNombreFichero() & ".pdf"
            Dim fs As New FileStream(sFile, FileMode.Create)
            fs.Write(Bits, 0, Convert.ToInt32(Bits.Length))
            fs.Close()
            Dim obj As System.Diagnostics.Process = New System.Diagnostics.Process()
            'Archivo = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
            Archivo = "C:\SISTEMAS\Riesgo\" + sFile
            AxAcroPDF1.src = Archivo
            'AxAcroPDF1.setCurrentPage(2)
            AxAcroPDF1.setZoom(90)
            If System.IO.File.Exists(Archivo) = True Then
                System.IO.File.Delete(Archivo)
            End If

        Catch ex As Exception
            MsgBox("Dicom No encontrado")
        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnactualAdjuntos.Click
        Try

            'MsgBox(Trim(txtFecha.Text.ToString).Substring(0, 10))
            'MsgBox(Trim(txtRut2.Text.ToString))

            'txtCodigo.Text = "select top 1  doc from [DocBD].[dbo].documentos where fecha='" & Trim(txtFecha.Text.ToString).Substring(0, 10) & "' and rut ='" & Trim(txtRut2.Text.ToString) & "' and tipo='ADJUNTOS' and estado=1  order by docid desc"
            Dim Archivo As String
            Dim conexiones3 As New CConexion
            conexiones3.conexion()
            cmd = New SqlCommand("select top 1  doc from [DocBD].[dbo].documentos where fecha='" & Trim(txtFecha.Text.ToString).Substring(0, 10) & "' and rut ='" & Trim(txtRut2.Text.ToString) & "' and tipo='ADJUNTOS' and estado=1  order by docid desc", conexiones3._conexion)
            da = New SqlDataAdapter(cmd)
            dtb = New DataTable()
            da.Fill(dtb)
            Dim f As DataRow = dtb.Rows(0)
            Dim Bits As Byte() = (CType((f.ItemArray(0)), Byte()))
            Dim sFile As String = "a" & GenerarNombreFichero() & ".pdf"
            Dim fs As New FileStream(sFile, FileMode.Create)
            fs.Write(Bits, 0, Convert.ToInt32(Bits.Length))
            fs.Close()
            Dim obj As System.Diagnostics.Process = New System.Diagnostics.Process()
            'Archivo = "C:\Users\ccampos\Desktop\SISTEMAS\2010\SISTEMA RIESGO\SISTEMA RIESGO\SISTEMA RIESGO\SistemaRiesgos\bin\Debug\" + sFile
            Archivo = "C:\SISTEMAS\Riesgo\" + sFile
            AxAcroPDF2.src = Archivo
            'AxAcroPDF1.setCurrentPage(2)
            AxAcroPDF2.setZoom(90)
            If System.IO.File.Exists(Archivo) = True Then
                System.IO.File.Delete(Archivo)
            End If

        Catch ex As Exception
            MsgBox("Adjuntos No encontrado")
        End Try





    End Sub


    Sub buscarrutDICOM()
        'txtTitulo.Focus()
        crearcolumnaDicom()
        Dim conexiones3 As New CConexion
        conexiones3.conexion()
        cmd = New SqlCommand(" select top 20 CC1.fecha,CC1.docid from [DocBD].[dbo].documentos AS CC1 INNER JOIN (SELECT [rut] ,[fecha] ,MAX(docId) AS docId FROM [DocBD].[dbo].[DOCUMENTOS] where estado=1  and tipo='DICOM' GROUP BY rut, fecha ) AS CC2 ON  CC1.docId=CC2.docId  where CC1.rut='" + Trim(txtRut2.Text.ToString) + "' order by CC1.fecha DESC", conexiones3._conexion)
        da = New SqlDataAdapter(cmd)
        dtb = New DataTable()
        da.Fill(dtb)
        DataGridView1.DataSource = dtb
        DataGridView1.Columns(1).Width = 250
        conexiones3.cerrar()
        DataGridView1.AllowUserToAddRows = False
        COLOREARACTUALDICOM()
    End Sub

    Sub buscarrutADJUNTOS()
        'txtTitulo.Focus()
        crearcolumnaAdjuntos()
        Dim conexiones3 As New CConexion
        conexiones3.conexion()
        cmd = New SqlCommand(" select top 20 CC1.fecha,CC1.docid from [DocBD].[dbo].documentos AS CC1 INNER JOIN (SELECT [rut] ,[fecha] ,MAX(docId) AS docId FROM [DocBD].[dbo].[DOCUMENTOS]  where estado=1  and tipo='ADJUNTOS' GROUP BY rut, fecha ) AS CC2 ON  CC1.docId=CC2.docId  where CC1.rut='" + Trim(txtRut2.Text.ToString) + "'  order by CC1.fecha DESC", conexiones3._conexion)
        da = New SqlDataAdapter(cmd)
        dtb = New DataTable()
        da.Fill(dtb)
        DataGridView2.DataSource = dtb
        DataGridView2.Columns(1).Width = 250
        conexiones3.cerrar()
        DataGridView2.AllowUserToAddRows = False
        COLOREARACTUALADJUNTO()
    End Sub


    Sub COLOREARACTUALDICOM()
        For Each fila As DataGridViewRow In DataGridView1.Rows
            If fila.Cells("Fecha").Value = Trim(txtFecha.Text.ToString).Substring(0, 10) Then
                fila.DefaultCellStyle.BackColor = Color.Blue
                fila.DefaultCellStyle.ForeColor = Color.White
                'Else
                '    fila.DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub
    Sub COLOREARACTUALADJUNTO()
        For Each fila As DataGridViewRow In DataGridView2.Rows
            If fila.Cells("Fecha").Value = Trim(txtFecha.Text.ToString).Substring(0, 10) Then
                fila.DefaultCellStyle.BackColor = Color.Blue
                fila.DefaultCellStyle.ForeColor = Color.White
                'Else
                '    fila.DefaultCellStyle.BackColor = Color.Red
            End If
        Next
    End Sub
    Sub crearcolumnaDicom()
        If DataGridView1.Columns.Contains("btn") Then
        Else

            Dim btn As New DataGridViewButtonColumn()
            DataGridView1.Columns.Add(btn)
            btn.HeaderText = "Ver"
            btn.Text = "Ver"
            btn.Name = "btn"
            btn.UseColumnTextForButtonValue = True
        End If
    End Sub

    Sub crearcolumnaAdjuntos()
        If DataGridView2.Columns.Contains("btn") Then
        Else

            Dim btn As New DataGridViewButtonColumn()
            DataGridView2.Columns.Add(btn)
            btn.HeaderText = "Ver"
            btn.Text = "Ver"
            btn.Name = "btn"
            btn.UseColumnTextForButtonValue = True
        End If
    End Sub
    Sub calcular()

        Dim LVLCORRESPONDIENTE As String = 0

        Dim RL As String = Replace(txtRLP.Text, ".", "")

        Dim conexiones112 As New CConexion
        conexiones112.conexion()
        Dim command112 As SqlCommand = New SqlCommand("SELECT TIPO FROM _RIESGO_LEVERAGE where CONVERT(INT,'" + RL + "')>=CONVERT(INT,MONTO1) AND CONVERT(INT,'" + RL + "')<=CONVERT(INT,MONTO2) ", conexiones112._conexion)
        conexiones112.abrir()
        Dim reader112 As SqlDataReader = command112.ExecuteReader()

        If reader112.HasRows Then
            Do While reader112.Read()

                txtLvl.Text = "El RPL debe ser inferior a " + (reader112(0).ToString)
                'txtScoringLvl.Text = "BUENO"
                If (Integer.Parse(txtLeverage.Text) > Integer.Parse((reader112(0).ToString))) Then
                    txtLvl.ForeColor = Color.Red
                    'txtScoringLvl.Text = "MALO"
                End If


            Loop
        Else
        End If

        reader112.Close()

    End Sub



    Private Sub DIGITAL2()
        'txtDicom.Text = "NO"
        'txtAdjuntos.Text = "NO"
        'If File.Exists("Z:\_____DICOM HISTORICO_____\" + System.DateTime.Today.ToString("yyyy-MM-dd") + "-" + Trim(txtRut.Text.ToString) + ".pdf") Then
        '    txtDicom.Text = "SI"
        'End If
        'If File.Exists("Z:\_____DOCUMENTOS HISTORICO_____\" + System.DateTime.Today.ToString("yyyy-MM-dd") + "-" + Trim(txtRut.Text.ToString) + ".pdf") Then
        '    txtAdjuntos.Text = "SI"
        'End If


        'txtRut.Text = "15883797-8"
        'txtFecha.Text = System.DateTime.Today.ToString("yyyy-MM-dd")
        'txtDicom.Text = "NO"

        'MsgBox(txtFecha.Text.Substring(0, 10).Trim)

        Dim conexiones4 As New CConexion
        conexiones4.conexion()
        Dim command4 As SqlCommand = New SqlCommand(" IF EXISTS (SELECT TOP 1 [docId] FROM [DocBD].[dbo].[documentos] where tipo='DICOM' and rut='" + txtRut2.Text + "' and fecha='" + txtFecha.Text.Substring(0, 10).Trim + "' order by docId) BEGIN SELECT 'SI' END ELSE SELECT 'NO'", conexiones4._conexion)
        conexiones4.abrir()
        Dim reader4 As SqlDataReader = command4.ExecuteReader()

        If reader4.HasRows Then
            Do While reader4.Read()


                txtDicom.Text = (reader4(0).ToString)
                'Datos._Sede = (reader4(1).ToString)
            Loop
        Else
        End If

        reader4.Close()



        Dim conexiones5 As New CConexion
        conexiones5.conexion()
        Dim command5 As SqlCommand = New SqlCommand(" IF EXISTS (SELECT TOP 1 [docId] FROM [DocBD].[dbo].[documentos] where tipo='ADJUNTOS' and rut='" + txtRut2.Text + "' and fecha='" + txtFecha.Text.Substring(0, 10).Trim + "' order by docId) BEGIN SELECT 'SI' END ELSE SELECT 'NO'", conexiones5._conexion)
        conexiones5.abrir()
        Dim reader5 As SqlDataReader = command5.ExecuteReader()

        If reader5.HasRows Then
            Do While reader5.Read()


                txtAdjuntos.Text = (reader5(0).ToString)
                'Datos._Sede = (reader5(1).ToString)
            Loop
        Else
        End If

        reader5.Close()
    End Sub


    Private Sub WriteTextToRichTextBox()

        Dim i As Integer
        Dim cadena As String = txtComentarioSistema2.Text
        For i = 0 To txtComentarioSistema2.TextLength - 9
            'MsgBox(cadena.Substring(i, 9))
            If cadena.Substring(i, 9) = "Rechazado" Then
                txtComentarioSistema2.Select(i, 9)
                txtComentarioSistema2.SelectionColor = Color.Red
                i = i + 1
            End If
        Next
        For i = 0 To txtComentarioSistema2.TextLength - 5
            If cadena.Substring(i, 5) = "BUENO" Then
                txtComentarioSistema2.Select(i, 5)
                txtComentarioSistema2.SelectionColor = Color.Green
                i = i + 1
            End If
        Next

        For i = 0 To txtComentarioSistema2.TextLength - 4
            If cadena.Substring(i, 4) = "MALO" Then
                txtComentarioSistema2.Select(i, 4)
                txtComentarioSistema2.SelectionColor = Color.Red
                i = i + 1
            End If
        Next

        For i = 0 To txtComentarioSistema2.TextLength - 9
            If cadena.Substring(i, 9) = "Negativos" Then
                txtComentarioSistema2.Select(i, 9)
                txtComentarioSistema2.SelectionColor = Color.Red
                i = i + 1
            End If
        Next


        For i = 0 To txtComentarioSistema2.TextLength - 9
            If cadena.Substring(i, 9) = "No aplica" Then
                txtComentarioSistema2.Select(i, 9)
                txtComentarioSistema2.SelectionColor = Color.Blue
                i = i + 1
            End If
        Next

        For i = 0 To txtComentarioSistema2.TextLength - 9
            If cadena.Substring(i, 9) = "No aplica" Then
                txtComentarioSistema2.Select(i, 9)
                txtComentarioSistema2.SelectionColor = Color.Blue
                i = i + 1
            End If
        Next

        For i = 0 To txtComentarioSistema2.TextLength - 51
            If cadena.Substring(i, 51) = "Tiene condiciones favorables para aplicar excepción" Then
                txtComentarioSistema2.Select(i, 51)
                txtComentarioSistema2.SelectionColor = Color.Green
                txtComentarioSistema2.SelectionFont = New Font("Arial", 11)
                i = i + 1
            End If
        Next

        For i = 0 To txtComentarioSistema2.TextLength - 49
            If cadena.Substring(i, 49) = "No se excepciona al tener 2 condiciones Negativas" Or cadena.Substring(i, 49) = "No se excepciona al tener 3 condiciones Negativas" Or cadena.Substring(i, 49) = "No se excepciona al tener 4 condiciones Negativas" Then
                txtComentarioSistema2.Select(i, 49)
                txtComentarioSistema2.SelectionColor = Color.Red
                txtComentarioSistema2.SelectionFont = New Font("Arial", 11)
                i = i + 1
            End If
        Next

        For i = 0 To txtComentarioSistema2.TextLength - 46
            If cadena.Substring(i, 46) = "No se excepciona al tener 1 condición Negativa" Then
                txtComentarioSistema2.Select(i, 46)
                txtComentarioSistema2.SelectionColor = Color.Red
                txtComentarioSistema2.SelectionFont = New Font("Arial", 11)
                i = i + 1
            End If
        Next

        For i = 0 To txtComentarioSistema2.TextLength - 8
            If cadena.Substring(i, 8) = "más alto" Then
                txtComentarioSistema2.Select(i, 8)
                txtComentarioSistema2.SelectionColor = Color.Red
                i = i + 1
            End If
        Next

        For i = 0 To txtComentarioSistema2.TextLength - 8
            If cadena.Substring(i, 8) = "más bajo" Then
                txtComentarioSistema2.Select(i, 8)
                txtComentarioSistema2.SelectionColor = Color.Green
                i = i + 1
            End If
        Next


        For i = 0 To txtComentarioSistema2.TextLength - 5
            If cadena.Substring(i, 5) = "igual" Then
                txtComentarioSistema2.Select(i, 5)
                txtComentarioSistema2.SelectionColor = Color.Green
                i = i + 1
            End If
        Next

        For i = 0 To txtComentarioSistema2.TextLength - 62
            If cadena.Substring(i, 62) = "Por cosiguiente no cumple con las politicas 6.1 de excepciones" Then
                txtComentarioSistema2.Select(i, 62)
                txtComentarioSistema2.SelectionColor = Color.Red
                txtComentarioSistema2.SelectionFont = New Font("Arial", 11)
                i = i + 1
            End If
        Next

        For i = 0 To txtComentarioSistema2.TextLength - 16
            If cadena.Substring(i, 16) = "No se excepciona" Then
                txtComentarioSistema2.Select(i, 16)
                txtComentarioSistema2.SelectionColor = Color.Red
                txtComentarioSistema2.SelectionFont = New Font("Arial", 11)
                i = i + 1
            End If
        Next

        For i = 0 To txtComentarioSistema2.TextLength - 9
            If cadena.Substring(i, 9) = "positivos" Or cadena.Substring(i, 9) = "Positivos" Then
                txtComentarioSistema2.Select(i, 9)
                txtComentarioSistema2.SelectionColor = Color.Green
                i = i + 1
            End If
        Next


        For i = 0 To txtComentarioSistema2.TextLength - 12
            If cadena.Substring(i, 12) = "No aplicable" Then
                txtComentarioSistema2.Select(i, 12)
                txtComentarioSistema2.SelectionColor = Color.Blue
                i = i + 1
            End If
        Next


    End Sub


    Public Function Puntos(ByVal strValor As String, Optional ByVal intNumDecimales As Integer = 0) As String

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

    Sub cargainicial()



        Dim Datos As New CDatos()


        If (My.Settings.variableglobal = "Historicos") Then
            id = FrmCreditosHistoricos.txtid.Text
            txtCodigoId.Text = FrmCreditosHistoricos.txtid.Text
        ElseIf (My.Settings.variableglobal = "Propios") Then
            id = FrmCreditosPropios.txtId.Text
            txtCodigoId.Text = FrmCreditosPropios.txtId.Text
        ElseIf (My.Settings.variableglobal = "HistoricoPrestamos") Then
            id = FrmFichaAprobar.DGHistoricoPrestamos.Rows(FrmFichaAprobar.DGHistoricoPrestamos.CurrentRow.Index).Cells("id_solicitud").Value
            txtCodigoId.Text = FrmFichaAprobar.DGHistoricoPrestamos.Rows(FrmFichaAprobar.DGHistoricoPrestamos.CurrentRow.Index).Cells("id_solicitud").Value
        End If







        Dim ATRIBUTO_PERFIL As String
        Dim ATRIBUTO_PRESTAMO As String
        Dim CARGO As String = ""
        Dim conexiones3 As New CConexion
        conexiones3.conexion()
        Dim command3 As SqlCommand = New SqlCommand("SELECT  CC1.*,CC2.Comentario_PreAgente,cc2.Comentario_riesgo as Comentario_riesgo2 ,cc2.Comentario_Gerente as Comentario_Gerente2 , cc2.Comentario_SubGerente as Comentario_SubGerente2 , cc2.Comentario_Agencia as Comentario_Agencia2   , cc2.Comentario_PreAgente_Tipos,Institucion,Plataforma,tasa_castigada,tasa_real,comentario_tasa,Descuento_campaña,Condicional,comentario_tasa,EDeudadVencidasIndirectas,RutAval1,RutAval2,Eperiodo,modificaciondeudaexterna,PYM6,PYM6A12,PYM12A24,PYM24,ID_RENTA,MaximoMontoPlanilla,MaximaCuotaPlanilla,COD_DACA,DISPONIBLE,CUOTA_ULTIMA,CONDICIONAL_R FROM [_RIESGO_PRESTAMOS_SOLICITADOS] AS CC1  LEFT JOIN  _RIESGO_COMENTARIOS_PRESTAMOS AS CC2 ON CC1.id_solicitud=CC2.id_solicitud    where  CC1.id_solicitud='" + id + "'", conexiones3._conexion)
        conexiones3.abrir()
        Dim reader3 As SqlDataReader = command3.ExecuteReader()
        If reader3.HasRows Then
            Do While reader3.Read()
                txtNrosocio2.Text = (reader3("Nrosocio").ToString)
                txtFecha.Text = (reader3("fecha_solicitud").ToString)
                txtProducto.Text = (reader3("producto").ToString)
                txtObjetivo2.Text = (reader3("objetivo").ToString)
                'TxtMonto.Text = (reader3(5).ToString)
                TxtMonto.Text = Format(Decimal.Round(reader3("monto_solicitado").ToString), "#,##0")
                'TxtMonto2.Text = (reader3(5).ToString)
                'TxtMonto2.Text = Format(Decimal.Round(reader3("monto_solicitado").ToString), "#,##0")
                'TxtMonto3.Text = (reader3(5).ToString)
                'TxtMonto3.Text = Format(Decimal.Round(reader3("monto_solicitado").ToString), "#,##0")
                'txtCapital.Text = (reader3(6).ToString)
                txtCapital.Text = Format(Decimal.Round(reader3("capital").ToString), "#,##0")
                'txtPrepago.Text = (reader3(7).ToString)
                txtPrepago.Text = Format(Decimal.Round(reader3("prepago").ToString), "#,##0")
                'txtPrepago2.Text = (reader3(7).ToString)
                'txtPrepago2.Text = Format(Decimal.Round(reader3("prepago").ToString), "#,##0")
                'txtMonto4.Text = (reader3(7).ToString)
                'txtMonto4.Text = Format(Decimal.Round(reader3("prepago").ToString), "#,##0")
                'txtMonto4.Text = "Por Analizar"
                txtPrepagos.Text = (reader3("NroPrepagos").ToString)
                'txtPrepagos2.Text = (reader3("NroPrepagos").ToString)
                txtPlazo.Text = (reader3("nrocuotas").ToString)
                'txtPlazo2.Text = (reader3("nrocuotas").ToString)
                'txtPlazo3.Text = (reader3("nrocuotas").ToString)
                'TxtCuota.Text = (reader3(10).ToString)
                TxtCuota.Text = Format(Decimal.Round(reader3("primera_cuota").ToString), "#,##0")
                'TxtCuota2.Text = (reader3(10).ToString)
                'TxtCuota2.Text = Format(Decimal.Round(reader3("primera_cuota").ToString), "#,##0")
                'txtCuota3.Text = (reader3(10).ToString)
                'txtCuota3.Text = Format(Decimal.Round(reader3("primera_cuota").ToString), "#,##0")

                txtTasa.Text = (reader3("tasa").ToString)
                txtTasaCastigo.Text = (reader3("tasa_castigada").ToString)
                txtTasaSolicitud.Text = (reader3("Tasa_solicitada").ToString)
                txtDescuentoTasa.Text = (reader3("Descuento_campaña").ToString)
                txtTasaReal.Text = (reader3("tasa_real").ToString)

                txtDiasGracia.Text = (reader3("dias_gracia").ToString)
                'txtDiasGracia2.Text = (reader3("dias_gracia").ToString)
                txtNrocuotas.Text = (reader3("ncreditos").ToString)
                txtFechaPrimeraCuota.Text = (reader3("fechaprimervencimiento").ToString)
                txtFormaPago.Text = (reader3("forpago").ToString)
                txtFormadepago2.Text = (reader3("formadepago2").ToString)
                txtRenta2.Text = (reader3("tiporenta").ToString)
                txtProtesto2.Text = (reader3("protestosmorocidades").ToString)
                'txtComportamiento2.Text = (reader3("comportamientopago").ToString.Trim)
                'txtEdeudafinanciera.Text = (reader3(19).ToString)
                txtEdeudafinanciera.Text = Format(Decimal.Round(reader3("Edeudafinanciera").ToString), "#,##0")
                'txtEdeudaHipo.Text = (reader3(20).ToString)
                txtEdeudaHipo.Text = Format(Decimal.Round(reader3("EdeudaHipo").ToString), "#,##0")
                'txtEdeudaConsumo.Text = (reader3(21).ToString)
                txtEdeudaConsumo.Text = Format(Decimal.Round(reader3("EdeudaConsumo").ToString), "#,##0")
                'txtEdeudaComercial.Text = (reader3(22).ToString)
                txtEdeudaComercial.Text = Format(Decimal.Round(reader3("EdeudaComercial").ToString), "#,##0")
                'txtEDeudadVencidas.Text = (reader3(23).ToString)
                txtEDeudadVencidas.Text = Format(Decimal.Round(reader3("EDeudadVencidas").ToString), "#,##0")
                'txtELineaCredito.Text = (reader3(24).ToString)
                txtELineaCredito.Text = Format(Decimal.Round(reader3("ELineaCredito").ToString), "#,##0")
                txtENumeroAcreedores.Text = (reader3("ENumeroAcreedores").ToString)


                'txtItotaldeuda.Text = (reader3(26).ToString)
                txtItotaldeuda.Text = Format(Decimal.Round(reader3("Itotaldeuda").ToString), "#,##0")
                'txtItotaldeuda2.Text = (reader3(26).ToString)
                'txtItotaldeuda2.Text = Format(Decimal.Round(reader3("Itotaldeuda").ToString), "#,##0")
                'txtInternaTotalDeuda.Text = (reader3(26).ToString)
                'txtInternaTotalDeuda.Text = Format(Decimal.Round(reader3("Itotaldeuda").ToString), "#,##0")
                'txtInternaTotalDeuda.Text = (reader3(26).ToString)
                'txtInternaTotalDeuda.Text = Format(Decimal.Round(reader3("Itotaldeuda").ToString), "#,##0")


                'txtIdeudaConsumo.Text = (reader3(27).ToString)
                txtIdeudaConsumo.Text = Format(Decimal.Round(reader3("IdeudaConsumo").ToString), "#,##0")
                'txtInternaDeudaConsumo.Text = (reader3(27).ToString)
                'txtInternaDeudaConsumo.Text = Format(Decimal.Round(reader3("IdeudaConsumo").ToString), "#,##0")

                'txtIdeudaComercial.Text = (reader3(28).ToString)
                txtIdeudaComercial.Text = Format(Decimal.Round(reader3("IdeudaComercial").ToString), "#,##0")
                'txtInternaDeudaComercial.Text = (reader3(28).ToString)
                'txtInternaDeudaComercial.Text = Format(Decimal.Round(reader3("IdeudaComercial").ToString), "#,##0")

                'txtIDeudaIndirecta.Text = (reader3(29).ToString)
                txtIDeudaIndirecta.Text = Format(Decimal.Round(reader3("IDeudaIndirecta").ToString), "#,##0")
                'txtInternaDeudaIndirecta.Text = (reader3(29).ToString)
                'txtInternaDeudaIndirecta.Text = Format(Decimal.Round(reader3("IDeudaIndirecta").ToString), "#,##0")


                'txtIPagoMensual.Text = (reader3(30).ToString)
                txtIPagoMensual.Text = Format(Decimal.Round(reader3("IPagoMensual").ToString), "#,##0")
                'txtIPagoMensual2.Text = (reader3(30).ToString)
                'txtIPagoMensual2.Text = Format(Decimal.Round(reader3("IPagoMensual").ToString), "#,##0")
                'txtInternaPagoMensual.Text = (reader3(30).ToString)
                'txtInternaPagoMensual.Text = Format(Decimal.Round(reader3("IPagoMensual").ToString), "#,##0")

                'txtRLP.Text = (reader3(31).ToString)
                txtRLP.Text = Format(Decimal.Round(reader3("RLP").ToString), "#,##0")
                'txtCargaFinanciera.Text = (reader3(32).ToString)
                txtCargaFinanciera.Text = Format(Decimal.Round(reader3("CargaFinanciera").ToString), "#,##0")
                'txtExternaAcreditado.Text = (reader3(33).ToString)
                txtExternaAcreditado.Text = Format(Decimal.Round(reader3("ExternaAcreditado").ToString), "#,##0")


                'txtActivos.Text = (reader3(34).ToString)
                txtActivos.Text = Format(Decimal.Round(reader3("Activos").ToString), "#,##0")
                'txtPropiedades.Text = (reader3(35).ToString)
                txtPropiedades.Text = Format(Decimal.Round(reader3("Propiedades").ToString), "#,##0")
                'txtVehiculos.Text = (reader3(36).ToString)
                txtVehiculos.Text = Format(Decimal.Round(reader3("Vehiculos").ToString), "#,##0")
                'txtRentaLiquidaDepurada.Text = (reader3(37).ToString)
                txtRentaLiquidaDepurada.Text = Format(Decimal.Round(reader3("RentaLiquidaDepurada").ToString), "#,##0")



                txtLeverage.Text = (reader3("LVL").ToString)
                'txtLeverage2.Text = (reader3("LVL").ToString)

                txtCapacidad.Text = (reader3("Capacidad").ToString)
                'txtCapacidad2.Text = (reader3("Capacidad").ToString)

                txtvalidaciones2.Text = (reader3("Validaciones").ToString)
                txtEjecutivo.Text = (reader3("Ejecutiva").ToString)
                txtSucursal.Text = (reader3("Sucursal").ToString)

                txtPuntaje.Text = (reader3("Puntaje").ToString)
                txtPuntaje2.Text = (reader3("Puntaje").ToString)
                txtAntiguedadLab2.Text = (reader3("Anos_contrato").ToString)
                txtEdad2.Text = (reader3("Edad").ToString)
                'txtEdad.Text = (reader3("Edad").ToString)
                txtAntiguedad2.Text = (reader3("Anos_antiguedad").ToString)
                ATRIBUTO_PRESTAMO = (reader3("Atribucion").ToString)
                'ATRIBUTO_PRESTAMO2 = (reader3("Atribucion").ToString)
                txtCapitalAcumulado.Text = (reader3("Monto_capital").ToString)
                txtCapitalAcumulado.Text = Format(Decimal.Round(reader3("Monto_capital").ToString), "#,##0")


                txtCuotasPrepagadas.Text = (reader3("Cuotas_prepago").ToString)
                'txtCuotasPrepagadas2.Text = (reader3("Cuotas_prepago").ToString)
                'txtCuotasPrestamos.Text = (reader3("Cuotas_prepago").ToString)

                txtPuntajes.Text = (reader3("Puntajes_Validaciones").ToString)
                If (Trim(reader3("Presocio").ToString) = Trim(reader3("Nrosocio").ToString)) Then
                    Timer1.Enabled = True
                    Timer1.Interval = 250
                End If
                'If Trim(reader3("Presocio").ToString) = "" Then
                '    txtNuevo.Text = "NO"
                'Else
                '    txtNuevo.Text = "SI"
                'End If

                txtComportamientoClasificaciones.Text = (reader3("comportamiento_clasificacion").ToString)
                txtComportamientoCapital.Text = (reader3("comportamiento_abonocapital").ToString)
                txtClasificacionBaja.Text = (reader3("comportamiento_baja_clasificacion").ToString)

                txtEjecutivoVentas.Text = (reader3("Ejecutivo_convenio").ToString)

                txtReref.Text = (reader3("renegocia_refinancia").ToString)
                txtValidacionAgente.Text = (reader3("PreAprobacion_Agente").ToString.Trim)
                txtComentarioAgente.Text = (reader3("Comentario_PreAgente").ToString.Trim)
                txtValidacionAgente.Text = (reader3("PreAprobacion_Agente").ToString.Trim)

                txtComentarioEjecutivo.Text = (reader3("Comentario_Ejecutiva").ToString)
                txtComentarioEjecutivoUser.Text = (reader3("Ejecutiva").ToString)

                txtComentarioRiesgo.Text = (reader3("Comentario_riesgo2").ToString)
                txtComentarioRiesgoUser.Text = (reader3("Riesgo_perfil").ToString)

                txtComentarioAgente.Text = (reader3("Comentario_PreAgente").ToString)
                txtComentarioAgenteUser.Text = (reader3("PreAgencia_Perfil").ToString)


                txtComentarioGerente2.Text = (reader3("Comentario_Gerente2").ToString)
                txtComentarioGerente2User.Text = (reader3("Gerencia_Perfil").ToString)

                txtComentarioSubGerente.Text = (reader3("Comentario_SubGerente2").ToString)
                txtComentarioSubGerenteUser.Text = (reader3("Subgerencia_Perfil").ToString)

                txtComentarioAgencia.Text = (reader3("Comentario_Agencia2").ToString)
                txtComentarioAgenciaUser.Text = (reader3("Agencia_Perfil").ToString)
                cboTipologiasDeObjeciones.SelectedItem = (reader3("Comentario_PreAgente_Tipos").ToString.Trim)
                txtRegion.Text = (reader3("Region").ToString)
                txtInstitucion.Text = (reader3("Institucion").ToString)
                txtPlataforma.Text = (reader3("Plataforma").ToString)
                txtCondicion.Text = (reader3("Condicional").ToString)
                txtCondicion2.Text = (reader3("Condicional_R").ToString)
                If frmPerfil.CbmUsuario.SelectedItem.ToString.Trim = "CCAMPOS" Or frmPerfil.CbmUsuario.SelectedItem.ToString.Trim = "CAGUILAR" Or frmPerfil.CbmUsuario.SelectedItem.ToString.Trim = "HHERRERA(R)" Or frmPerfil.CbmUsuario.SelectedItem.ToString.Trim = "JFARIAS(R)" Or frmPerfil.CbmUsuario.SelectedItem.ToString.Trim = "BPEREZ(R)" Then
                    txtPuntaje2.Visible = True
                    LPuntaje2.Visible = True
                    txtPuntaj2.Visible = True
                Else
                    txtPuntaje2.Visible = False
                    LPuntaje2.Visible = False
                    txtPuntaj2.Visible = False
                End If


                If frmPerfil.CbmUsuario.SelectedItem.ToString.Trim = "CCAMPOS" Or frmPerfil.CbmUsuario.SelectedItem.ToString.Trim = "CAGUILAR" Or frmPerfil.CbmUsuario.SelectedItem.ToString.Trim = "HHERRERA(R)" Or frmPerfil.CbmUsuario.SelectedItem.ToString.Trim = "JFARIAS(R)" Or frmPerfil.CbmUsuario.SelectedItem.ToString.Trim = "BPEREZ(R)" Then

                    txtComentarioSistema2.Text = (reader3("comentario_tasa").ToString)
                Else

                    txtComentarioSistema2.Text = "TESTEO DE EXCEPCIONES, SOLO PARA DISPONIBLE PARA DEPARTAMENTO DE RIESGO"
                End If

                txtEDeudadIndirectasVencidas.Text = (reader3("EDeudadVencidasIndirectas").ToString.Trim)

                txtAval1.Text = (reader3("RutAval1").ToString.Trim)
                txtAval2.Text = (reader3("RutAval2").ToString.Trim)


                txtPeriodo.Text = (reader3("Eperiodo").ToString.Trim)

                If reader3("modificaciondeudaexterna").ToString.Trim = "SI" Then
                    LDeudaExterna.Text = "Deuda externa incorporada MANUALMENTE"
                Else
                    LDeudaExterna.Text = "Deuda externa incorporada AUTOMATICAMENTE"
                End If


                txtPYM6.Text = Puntos((reader3("PYM6").ToString.Trim))
                txtPYM612.Text = Puntos((reader3("PYM6A12").ToString.Trim))
                txtPYM1224.Text = Puntos((reader3("PYM12A24").ToString.Trim))
                TXTPYM24.Text = Puntos((reader3("PYM24").ToString.Trim))


                TXTPYMTOTAL.Text = Integer.Parse(Replace(txtPYM6.Text, ".", "")) + Integer.Parse(Replace(TXTPYM24.Text, ".", "")) + Integer.Parse(Replace(txtPYM1224.Text, ".", "")) + Integer.Parse(Replace(txtPYM612.Text, ".", ""))
                TXTPYMTOTAL.Text = Puntos(TXTPYMTOTAL.Text)

                txtIdRenta.Text = Puntos((reader3("ID_RENTA").ToString.Trim))



                txtMaxCuota.Text = Puntos((reader3("MaximaCuotaPlanilla").ToString.Trim))
                txtMaxMonto.Text = Puntos((reader3("MaximoMontoPlanilla").ToString.Trim))

                TXTCodDaca.Text = Puntos((reader3("COD_DACA").ToString.Trim))


                txtMontoDisponible.Text = Puntos((reader3("DISPONIBLE").ToString.Trim))
                txtCuotaFinal.Text = Puntos((reader3("CUOTA_ULTIMA").ToString.Trim))

            Loop
        Else
        End If

        reader3.Close()




        'Dim command3 As SqlCommand = New SqlCommand("SELECT  * FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where  id_solicitud='" + id + "'", conexiones3._conexion)
        'conexiones3.abrir()
        'Dim reader3 As SqlDataReader = command3.ExecuteReader()
        'If reader3.HasRows Then
        '    Do While reader3.Read()

        'txtNrosocio2.Text = (reader3(1).ToString)
        'txtFecha.Text = (reader3(2).ToString)
        'txtProducto.Text = (reader3(3).ToString)
        'txtObjetivo2.Text = (reader3(4).ToString)
        'TxtMonto.Text = (reader3(5).ToString)
        'txtCapital.Text = (reader3(6).ToString)
        'txtPrepago.Text = (reader3(7).ToString)
        'txtPrepagos.Text = (reader3(8).ToString)
        'txtPlazo.Text = (reader3(9).ToString)
        'TxtCuota.Text = (reader3(10).ToString)
        'txtTasa.Text = (reader3(11).ToString)
        'txtDiasGracia.Text = (reader3(12).ToString)
        'txtNrocuotas.Text = (reader3(13).ToString)
        'txtFechaPrimeraCuota.Text = (reader3(14).ToString)
        'txtFormaPago.Text = (reader3(15).ToString)
        'txtRenta2.Text = (reader3(16).ToString)
        'txtProtesto2.Text = (reader3(17).ToString)
        'txtComportamiento2.Text = (reader3(18).ToString)
        'txtEdeudafinanciera.Text = (reader3(19).ToString)
        'txtEdeudaHipo.Text = (reader3(20).ToString)
        'txtEdeudaConsumo.Text = (reader3(21).ToString)
        'txtEdeudaComercial.Text = (reader3(22).ToString)
        'txtEDeudadVencidas.Text = (reader3(23).ToString)
        'txtELineaCredito.Text = (reader3(24).ToString)
        'txtENumeroAcreedores.Text = (reader3(25).ToString)
        'txtItotaldeuda.Text = (reader3(26).ToString)
        'txtIdeudaConsumo.Text = (reader3(27).ToString)
        'txtIdeudaComercial.Text = (reader3(28).ToString)
        'txtIDeudaIndirecta.Text = (reader3(29).ToString)
        'txtIPagoMensual.Text = (reader3(30).ToString)
        'txtRLP.Text = (reader3(31).ToString)
        'txtCargaFinanciera.Text = (reader3(32).ToString)
        'txtExternaAcreditado.Text = (reader3(33).ToString)
        'txtActivos.Text = (reader3(34).ToString)
        'txtPropiedades.Text = (reader3(35).ToString)
        'txtVehiculos.Text = (reader3(36).ToString)
        'txtRentaLiquidaDepurada.Text = (reader3(37).ToString)
        'txtLeverage.Text = (reader3(38).ToString)
        'txtCapacidad.Text = (reader3(39).ToString)
        'txtvalidaciones2.Text = (reader3(40).ToString)
        'txtEjecutivo.Text = (reader3(41).ToString)
        'txtSucursal.Text = (reader3(42).ToString)
        'txtComentarioEjecutiva.Text = (reader3(43).ToString)
        'txtComentarioRiesgo.Text = (reader3(44).ToString)
        'txtPuntaje.Text = (reader3(49).ToString)
        'txtAntiguedadLab2.Text = (reader3(50).ToString)
        'txtEdad2.Text = (reader3(51).ToString)
        'txtAntiguedad2.Text = (reader3(52).ToString)
        'ATRIBUTO_PRESTAMO = (reader3(53).ToString)
        'txtCapitalAcumulado.Text = (reader3(67).ToString)
        'txtComentarioGerente.Text = (reader3(68).ToString)
        'txtComentarioSubGerente.Text = (reader3(69).ToString)
        'txtComentarioAgencia.Text = (reader3(70).ToString)
        'txtEstado.Text = (reader3(48).ToString)
        'txtCuotasPrepagadas.Text = (reader3(71).ToString)
        'txtPuntajes.Text = (reader3(77).ToString)


        'If (Trim(reader3(87).ToString) = Trim(reader3(1).ToString)) Then
        '    Timer1.Enabled = True
        '    Timer1.Interval = 250
        'End If

        'txtComportamientoClasificaciones.Text = (reader3(90).ToString)
        'txtComportamientoCapital.Text = (reader3(91).ToString)
        'txtClasificacionBaja.Text = (reader3(92).ToString)
        'txtAumentoTasa.Text = (reader3(93).ToString)
        'txtEjecutivoVentas.Text = (reader3(96).ToString)
        'txtModificacionTasa.Text = (reader3(97).ToString)
        'txtReref.Text = (reader3("renegocia_refinancia").ToString)
        '    Loop
        'Else
        'End If

        'reader3.Close()

        Dim estadocivil As String
        Dim tipovivienda As String

        Dim conexiones4 As New CConexion
        conexiones4.conexion()
        Dim command4 As SqlCommand
        If (Timer1.Enabled = False) Then
            'MsgBox("ES SOCIO")
            command4 = New SqlCommand("SELECT convert(varchar,[RUT])+'-'+ convert(varchar,[DVRUT]),[FechaIng],[FechaNac],[FechaContrato],[Nombres]+' '+[Paterno]+' '+[Materno],[EstadoCivil],[CantCargas],[TipoViv],_INSTITUCIONES.DESCRIPCION,[SUELDOLIQUIDO],SEXO FROM [_SOCIOS] left join _INSTITUCIONES on _SOCIOS.CODINST= _INSTITUCIONES.CODINS where NROSOCIO='" + txtNrosocio2.Text + "'", conexiones3._conexion)

        ElseIf (Timer1.Enabled = True) Then
            'MsgBox("ES PRE-SOCIO")
            command4 = New SqlCommand("SELECT convert(varchar,[RUT])+'-'+ convert(varchar,[DVRUT]),[FechaSolicitud],[FechaNac],[FechaContrato],[Nombres]+' '+[Paterno]+' '+[Materno],[EstadoCivil],[CantCargas],[TipoViv],_INSTITUCIONES.DESCRIPCION,[SUELDOLIQUIDO],SEXO FROM [_PRESOCIOS] left join _INSTITUCIONES on _PRESOCIOS.CODINST= _INSTITUCIONES.CODINS where NROSOCIO='" + txtNrosocio2.Text + "'", conexiones3._conexion)
        End If
        'Dim command4 As SqlCommand = New SqlCommand("SELECT convert(varchar,[RUT])+'-'+ convert(varchar,[DVRUT]),[FechaIng],[FechaNac],[FechaContrato],[Nombres]+' '+[Paterno]+' '+[Materno],[EstadoCivil],[CantCargas],[TipoViv],_INSTITUCIONES.DESCRIPCION,[SUELDOLIQUIDO]FROM [_SOCIOS] left join _INSTITUCIONES on _SOCIOS.CODINST= _INSTITUCIONES.CODINS where NROSOCIO='" + txtNrosocio2.Text + "'", conexiones4._conexion)
        conexiones4.abrir()
        Dim reader4 As SqlDataReader = command4.ExecuteReader()


        If reader4.HasRows Then
            Do While reader4.Read()
                txtRut2.Text = (reader4(0).ToString)
                'InputDateString1 = (reader4(1).ToString)
                'InputDateString2 = (reader4(2).ToString)
                'InputDateString4 = (reader4(3).ToString)
                txtNombre2.Text = (reader4(4).ToString)
                estadocivil = (reader4(5).ToString)

                'txtCargasFamiliares.Text = (reader4(6).ToString)
                tipovivienda = (reader4(7).ToString)
                'txtProtesto.Text = (reader4(8).ToString)
                'txtRemuneracion.Text = (reader4(9).ToString)
                TxtSexo.Text = (reader4("Sexo").ToString)
            Loop
        Else
        End If

        reader4.Close()

        If estadocivil = "C" Then
            txtEstadocivil2.Text = "Casado en Sociedad Conyugal"
        ElseIf estadocivil = "S" Then
            txtEstadocivil2.Text = "Soltero"
        ElseIf estadocivil = "V" Then
            txtEstadocivil2.Text = "Viudo"
        ElseIf estadocivil = "P" Then
            txtEstadocivil2.Text = "Divorciado"
        ElseIf estadocivil = "B" Then
            txtEstadocivil2.Text = "Casado Separación de Bienes"
        Else
            txtEstadocivil2.Text = "Sin registro"
        End If


        If tipovivienda = "1" Then
            txtTipovivienda2.Text = "Propia"
        ElseIf tipovivienda = "2" Then
            txtTipovivienda2.Text = "Propia con Dividendos"
        ElseIf tipovivienda = "3" Then
            txtTipovivienda2.Text = "Arrendada"
        ElseIf tipovivienda = "4" Then
            txtTipovivienda2.Text = "Cedida o Gratuita"
        Else
            txtTipovivienda2.Text = "Sin registro"
        End If


        DIGITAL()

        DIGITAL2()

        txtCapcid.Text = "La capacidad de pago no debe mayor a 20% o menor 0%"



        If txtFormaPago.Text.Trim = "PLANILLA" Then
            txtPuntaj.Text = "El puntaje debe ser inferior a los -50 puntos"
            txtPuntaj2.Text = "El puntaje debe ser inferior a los -50 puntos"
        Else
            txtPuntaj.Text = "El puntaje debe ser inferior a los -30 puntos"
            txtPuntaj2.Text = "El puntaje debe ser inferior a los -30 puntos"
        End If

        Try
            If (Integer.Parse(Replace(txtCapacidad.Text, "%", "")) > 20 Or Integer.Parse(Replace(txtCapacidad.Text, "%", "")) <= 0) Then
                txtCapcid.ForeColor = Color.Red
            End If
            If txtFormaPago.Text.Trim = "PLANILLA" Then
                If (Double.Parse(txtPuntaje.Text) > -50) Then
                    txtPuntaj.ForeColor = Color.Red
                    txtPuntaj2.ForeColor = Color.Red
                End If
            Else
                If (Double.Parse(txtPuntaje.Text) > -30) Then
                    txtPuntaj.ForeColor = Color.Red
                    txtPuntaj2.ForeColor = Color.Red
                End If
            End If

        Catch ex As Exception

        End Try



        'txtPuntaj.Text = "El puntaje debe ser superior a los 500 puntos"
        calcular()

        cargarrentas()
        ''txtScoringCapacidad.Text = "BUENO"
        'If (Integer.Parse(Replace(txtCapacidad.Text, "%", "")) > 20 Or Integer.Parse(Replace(txtCapacidad.Text, "%", "")) <= 0) Then
        '    txtCapcid.ForeColor = Color.Red
        '    'txtScoringCapacidad.Text = "MALO"
        'End If

        'If (Double.Parse(txtPuntaje.Text) < -30) Then
        '    txtPuntaj.ForeColor = Color.Red
        'End If

        'carculartasanormal()
        WriteTextToRichTextBox()
        'puntajes()

    End Sub




    Private Sub frmFichaHistorico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargainicial()
        'If frmPerfil.CbmUsuario.SelectedItem.ToString.Trim = "CCAMPOS" Or frmPerfil.CbmUsuario.SelectedItem.ToString.Trim = "CAGUILAR" Or frmPerfil.CbmUsuario.SelectedItem.ToString.Trim = "PBOMBAL" Or frmPerfil.CbmUsuario.SelectedItem.ToString.Trim = "HHERRERA(R)" Or frmPerfil.CbmUsuario.SelectedItem.ToString.Trim = "JRODENAS" Or frmPerfil.CbmUsuario.SelectedItem.ToString.Trim = "JRODENAS(CCI)" Or frmPerfil.CbmUsuario.SelectedItem.ToString.Trim = "JRODENAS(CCS)" Then
        '    PanelScoring.Visible = False
        'Else
        '    PanelScoring.Visible = True
        'End If

        'cargainicial()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub txtObjetivo2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObjetivo2.TextChanged
        If txtObjetivo2.Text = "Renegociación" Then
            txtObjetivo2.BackColor = Color.Red
            txtAviso.Visible = True
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static c As String
        c = c + 1
        If (c = 1) Then
            lpresocio.Visible = True
        ElseIf (c = 2) Then
            lpresocio.Visible = False
        ElseIf (c = 3) Then
            lpresocio.Visible = True
        ElseIf (c = 4) Then
            c = 0
        End If
    End Sub


    Private Sub DIGITAL()
        'txtDicom.Text = "NO"
        'txtAdjuntos.Text = "NO"

        'If File.Exists("Z:\_____DICOM HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut2.Text.ToString) + ".pdf") Then
        '    txtDicom.Text = "SI"
        'End If
        'If File.Exists("Z:\_____DOCUMENTOS HISTORICO_____\" + Trim(txtFecha.Text.ToString).Substring(0, 10) + "-" + Trim(txtRut2.Text.ToString) + ".pdf") Then
        '    txtAdjuntos.Text = "SI"
        'End If
    End Sub





    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If Timer1.Enabled = True Then
            MsgBox("Los Pre-Socios no registran comportamientos historicos")
        Else
            Dim usuario As String
            Dim rut As String


            Dim conexiones1 As New CConexion
            conexiones1.conexion()
            Dim command1 As SqlCommand = New SqlCommand("SELECT convert(varchar,[RUT]) from _socios where SOCIOSINO='S' and RTRIM(NROSOCIO)='" + txtNrosocio2.Text + "'", conexiones1._conexion)
            conexiones1.abrir()
            Dim reader1 As SqlDataReader = command1.ExecuteReader()

            If reader1.HasRows Then
                Do While reader1.Read()
                    Datos._Compromiso_Rut = (reader1(0).ToString.Trim)
                Loop
            Else
            End If
            reader1.Close()



            Datos._Compromiso_Usuario = Trim(frmPerfil.CbmUsuario.SelectedItem.ToString)
            usuario = Datos._Compromiso_Usuario
            rut = Trim(Datos._Compromiso_Rut.ToString)


            Dim conexiones71 As New CConexion
            conexiones71.conexion()
            conexiones71.abrir()
            Dim cmd71 As New SqlCommand("_Riesgo_Comportamiento4", conexiones71._conexion)
            cmd71.CommandType = CommandType.StoredProcedure
            Dim prm71 As SqlParameter = _
            New SqlParameter("@rut", SqlDbType.NVarChar)
            Dim prm71_2 As SqlParameter = _
            New SqlParameter("@usuario", SqlDbType.NVarChar)
            cmd71.Parameters.Add(prm71)
            cmd71.Parameters.Add(prm71_2)
            With cmd71
                .Parameters("@rut").Value = rut
                .Parameters("@usuario").Value = usuario
            End With
            Dim dr71 As SqlDataReader = cmd71.ExecuteReader(CommandBehavior.CloseConnection)
            conexiones71.cerrar()


            plantillas._tabla.Rows.Clear()
            plantillas._tabla.Columns.Clear()
            If plantillas.Consultar_Comportamiento(Datos) Then
                tabla = plantillas.tabla
                DGComportamiento.DataSource = tabla
            End If



            Dim conexiones9 As New CConexion
            conexiones9.conexion()
            Dim command9 As SqlCommand = New SqlCommand("SELECT TIPO,COMENTARIO FROM _RIESGO_COMPORTAMIENTO_COMENTARIOS where USUARIO='" + usuario + "' AND RUT ='" + rut + "'", conexiones9._conexion)
            conexiones9.abrir()
            Dim reader9 As SqlDataReader = command9.ExecuteReader()

            If reader9.HasRows Then
                Do While reader9.Read()

                    If reader9(0).ToString.Trim = "GENERAL MESES" Then
                        txtGeneral.Text = reader9(1).ToString.Trim
                    ElseIf reader9(0).ToString.Trim = "1 MES" Then
                        txt1Mes.Text = reader9(1).ToString.Trim
                    ElseIf reader9(0).ToString.Trim = "6 MESES CLASIFICACION" Then
                        txt6MesesClasificacion.Text = reader9(1).ToString.Trim
                    ElseIf reader9(0).ToString.Trim = "6 MESES CAPITAL" Then
                        txt6MesesCapital.Text = reader9(1).ToString.Trim
                    ElseIf reader9(0).ToString.Trim = "12 MESES CLASIFICACION" Then
                        txt12MesesClasificacion.Text = reader9(1).ToString.Trim
                    ElseIf reader9(0).ToString.Trim = "12 MESES CAPITAL" Then
                        txt12MesesCapital.Text = reader9(1).ToString.Trim
                    ElseIf reader9(0).ToString.Trim = "24 MESES CLASIFICACION" Then
                        txt24MesesClasificacion.Text = reader9(1).ToString.Trim
                    ElseIf reader9(0).ToString.Trim = "24 MESES CAPITAL" Then
                        txt24MesesCapital.Text = reader9(1).ToString.Trim
                    ElseIf reader9(0).ToString.Trim = "HISTORICO CLASIFICACION" Then
                        txtHistoricoClasificacion.Text = reader9(1).ToString.Trim
                    ElseIf reader9(0).ToString.Trim = "HISTORICO CAPITAL" Then
                        txtHistoricoCapital.Text = reader9(1).ToString.Trim
                    End If

                Loop
            Else
            End If

            reader9.Close()


        End If

    End Sub

    Private Sub txt6MesesClasificacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt6MesesClasificacion.TextChanged
        If (Trim(txt6MesesClasificacion.Text) = "EN LOS ULTIMOS 6 MESES PRESENTA 0 CLASIFICACIÓN/ES NEGATIVA") Then
            txt6MesesClasificacion.BackColor = Color.Green()
        Else
            txt6MesesClasificacion.BackColor = Color.Red()
        End If
    End Sub

    Private Sub txt6MesesCapital_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt6MesesCapital.TextChanged
        If (Trim(txt6MesesCapital.Text) = "EN LOS ULTIMOS 6 MESES HA PAGADO CON CAPITAL 0, POR UN TOTAL DE $0") Then
            txt6MesesCapital.BackColor = Color.Green()
        Else
            txt6MesesCapital.BackColor = Color.Red()
        End If
    End Sub

    Private Sub txt12MesesClasificacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt12MesesClasificacion.TextChanged
        If (Trim(txt12MesesClasificacion.Text) = "EN LOS ULTIMOS 12 MESES PRESENTA 0 CLASIFICACIÓN/ES NEGATIVA") Then
            txt12MesesClasificacion.BackColor = Color.Green()
        Else
            txt12MesesClasificacion.BackColor = Color.Red()
        End If
    End Sub

    Private Sub txt12MesesCapital_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt12MesesCapital.TextChanged
        If (Trim(txt12MesesCapital.Text) = "EN LOS ULTIMOS 12 MESES HA PAGADO CON CAPITAL 0, POR UN TOTAL DE $0") Then
            txt12MesesCapital.BackColor = Color.Green()
        Else
            txt12MesesCapital.BackColor = Color.Red()
        End If
    End Sub

    Private Sub txt24MesesClasificacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt24MesesClasificacion.TextChanged
        If (Trim(txt24MesesClasificacion.Text) = "EN LOS ULTIMOS 24 MESES PRESENTA 0 CLASIFICACIÓN/ES NEGATIVA") Then
            txt24MesesClasificacion.BackColor = Color.Green()
        Else
            txt24MesesClasificacion.BackColor = Color.Red()
        End If
    End Sub

    Private Sub txt24MesesCapital_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt24MesesCapital.TextChanged
        If (Trim(txt24MesesCapital.Text) = "EN LOS ULTIMOS 24 MESES HA PAGADO CON CAPITAL 0, POR UN TOTAL DE $0") Then
            txt24MesesCapital.BackColor = Color.Green()
        Else
            txt24MesesCapital.BackColor = Color.Red()
        End If
    End Sub

    Private Sub txtComportamientoClasificaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComportamientoClasificaciones.TextChanged
        If txtComportamientoClasificaciones.Text.Trim <> "0" Then
            txtComportamientoClasificaciones.BackColor = Color.Red
        Else
            txtComportamientoClasificaciones.BackColor = Color.Green
        End If
    End Sub

    Private Sub txtComportamientoCapital_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComportamientoCapital.TextChanged
        If txtComportamientoCapital.Text.Trim <> "0" Then
            txtComportamientoCapital.BackColor = Color.Red
        Else
            txtComportamientoCapital.BackColor = Color.Green
        End If
    End Sub

    Private Sub txtClasificacionBaja_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClasificacionBaja.TextChanged
        If txtClasificacionBaja.Text.Trim = "A" Or txtClasificacionBaja.Text.Trim = "B" Or txtClasificacionBaja.Text.Trim = "NUNCA HA SIDO CLASIFICADO" Then
            txtClasificacionBaja.BackColor = Color.Green
        Else
            txtClasificacionBaja.BackColor = Color.Red
        End If
    End Sub


    'Private Sub txtAumentoTasa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTasaCastigo.TextChanged
    '    'If txtTasaCastigo.Text.Trim = "0" Then
    '    '    txtTasaCastigo.BackColor = Color.Green
    '    'Else
    '    '    txtTasaCastigo.BackColor = Color.Red
    '    'End If
    'End Sub

    Private Sub txtEjecutivoVentas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEjecutivoVentas.TextChanged
        If txtEjecutivoVentas.Text.Trim <> "SIN EJECUTIVO" Then
            txtEjecutivoVentas.BackColor = Color.Green
        End If



    End Sub

    Private Sub txtModificacionTasa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTasaSolicitud.TextChanged



        If txtTasaSolicitud.Text.Trim <> "Por Defecto Sistema" Then
            txtTasaSolicitud.BackColor = Color.Yellow
            txtTasaSolicitud.ForeColor = Color.Black
        End If

    End Sub

    Private Sub txtReref_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReref.TextChanged
        If txtReref.Text.Trim = "NO" Then
            txtReref.BackColor = Color.Green
        Else
            txtReref.BackColor = Color.Red
            txtReref.ForeColor = Color.White

        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'txtPuntajes.Visible = True
        'richTextBox1.Visible = False
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'richTextBox1.Visible = True
        'txtPuntajes.Visible = False
    End Sub



    'Private Sub WriteTextToRichTextBox()
    '    ' Clear all text from the RichTextBox;
    '    richTextBox1.Clear()
    '    ' Indent bulleted text 30 pixels away from the bullet.
    '    richTextBox1.BulletIndent = 30
    '    ' Set the font for the opening text to a larger Arial font;
    '    richTextBox1.SelectionFont = New Font("Arial", 16)
    '    ' Assign the introduction text to the RichTextBox control.
    '    RichTextBox1.SelectedText = "The following is a list of bulleted items:" + ControlChars.Cr
    '    ' Set the Font for the first item to a smaller size Arial font.
    '    richTextBox1.SelectionFont = New Font("Arial", 12)
    '    ' Specify that the following items are to be added to a bulleted list.
    '    richTextBox1.SelectionBullet = True
    '    ' Set the color of the item text.
    '    richTextBox1.SelectionColor = Color.Red
    '    ' Assign the text to the bulleted item.
    '    richTextBox1.SelectedText = "Apples" + ControlChars.Cr
    '    ' Apply same font since font settings do not carry to next line.
    '    richTextBox1.SelectionFont = New Font("Arial", 12)
    '    richTextBox1.SelectionColor = Color.Orange
    '    richTextBox1.SelectedText = "Oranges" + ControlChars.Cr
    '    richTextBox1.SelectionFont = New Font("Arial", 12)
    '    richTextBox1.SelectionColor = Color.Purple
    '    richTextBox1.SelectedText = "Grapes" + ControlChars.Cr
    '    ' End the bulleted list.
    '    richTextBox1.SelectionBullet = False
    '    ' Specify the font size and string for text displayed below bulleted list.
    '    richTextBox1.SelectionFont = New Font("Verdana", 10)
    '    richTextBox1.SelectedText = "The bulleted text is indented 30 pixels from the bullet symbol using the BulletIndent property." + ControlChars.Cr
    'End Sub



    'Public Sub puntajes()
    '    richTextBox1.Clear()
    '    richTextBox1.BulletIndent = 30
    '    'WriteTextToRichTextBox()
    '    Dim ADVERTENCIA As String = ""
    '    Dim edad As String
    '    Dim estadocivil As String
    '    Dim vivienda As String
    '    Dim categoria As String
    '    Dim formadepago2 As String
    '    Dim region As String
    '    Dim puntaje As String
    '    Dim antiguedad As String
    '    Dim sexo As String
    '    Dim lvl As String
    '    Dim capacidad As String
    '    Dim renta As String
    '    Dim plazo As String
    '    Dim TipodeSocio As String
    '    Dim DiasdeGracia As String
    '    Dim Plataforma As String
    '    Dim Monto As String
    '    Dim contador As Integer = 0
    '    Dim aumentaTasa As Integer = 0

    '    Dim Words As New List(Of String)

    '    richTextBox1.Text = ""
    '    puntaje = 0


    '    '' ---------------- CATEGORIA PLANILLA O CONSUMO
    '    'TXTPUNTAJES3.Text = TXTPUNTAJES3.Text + "{\rtf1\ansi This is in \b bold\b0.}" + Environment.NewLine
    '    'richTextBox1.Rtf = "{\rtf1\ansi This is in \b bold\b0.}"
    '    If txtFormaPago.Text.Trim = "PLANILLA" Then
    '        categoria = "Planilla"
    '        richTextBox1.Text = "Forma De Pago No valida por PLANILLA" + Environment.NewLine + Environment.NewLine
    '    Else
    '        categoria = "Consumo"
    '    End If


    '    ''INDICE FORMAPAGO------------------------------------------


    '    formadepago2 = txtFormadepago2.Text.Trim
    '    'MsgBox(formadepago2)
    '    If (formadepago2 = "") Then
    '        formadepago2 = "Pago en Oficina"
    '        ADVERTENCIA = "* No tiene Historico por defecto 'Pago en Oficina' "
    '    End If


    '    Dim conexiones7 As New CConexion
    '    conexiones7.conexion()
    '    Dim command7 As SqlCommand = New SqlCommand("  SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (6,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Forma Pago' and  [Rango1] ='" + formadepago2 + "'", conexiones7._conexion)
    '    conexiones7.abrir()
    '    Dim reader7 As SqlDataReader = command7.ExecuteReader()

    '    If reader7.HasRows Then
    '        Do While reader7.Read()


    '            puntaje = puntaje + Double.Parse((reader7(0).ToString))



    '            richTextBox1.Text += "Forma de pago:" + Environment.NewLine + "Valor= " + formadepago2 + "     |     Puntaje= " + reader7(0).ToString + Environment.NewLine + Environment.NewLine
    '            'richTextBox1.Text += "Valor= " + formadepago2 + "     |     Puntaje= " + reader7(0).ToString + Environment.NewLine


    '            If (ADVERTENCIA <> "") Then
    '                richTextBox1.Text = richTextBox1.Text + ADVERTENCIA + Environment.NewLine + Environment.NewLine
    '            End If
    '            Words.Add(reader7(0).ToString)
    '            'colorWord(reader7(0).ToString)
    '        Loop
    '    Else
    '    End If

    '    reader7.Close()

    '    ADVERTENCIA = ""



    '    ' ''INDICE CAPACIDAD------------------------------------------


    '    If Replace(txtCapacidad.Text.ToString, "%", "") = "" Then
    '        capacidad = "0"
    '        ADVERTENCIA = "* No tiene Historico por defecto 0 "
    '    Else
    '        capacidad = Replace(txtCapacidad.Text.ToString, "%", "")
    '    End If

    '    'End If


    '    Dim conexiones9 As New CConexion
    '    conexiones9.conexion()
    '    Dim command9 As SqlCommand = New SqlCommand("SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (38,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Capacidad' and   CONVERT(decimal (38,2),'" + capacidad + "')>CONVERT(decimal (38,2),rango1) AND CONVERT(decimal (38,2),'" + capacidad + "')<=CONVERT(decimal (38,2),rango2) ", conexiones9._conexion)
    '    conexiones9.abrir()
    '    Dim reader9 As SqlDataReader = command9.ExecuteReader()

    '    If reader9.HasRows Then
    '        Do While reader9.Read()

    '            puntaje = puntaje + Double.Parse((reader9(0).ToString))

    '            'richTextBox1.Text = richTextBox1.Text + "Capacidad de Pago (" + capacidad.Trim + ") " + reader9(0).ToString + Environment.NewLine

    '            richTextBox1.Text += "Capacidad de pago:" + Environment.NewLine + "Valor= " + capacidad.Trim + "     |     Puntaje= " + reader9(0).ToString + Environment.NewLine + Environment.NewLine
    '            'richTextBox1.Text += 


    '            If (ADVERTENCIA <> "") Then
    '                richTextBox1.Text = richTextBox1.Text + ADVERTENCIA + Environment.NewLine + Environment.NewLine
    '            End If

    '            Words.Add(reader9(0).ToString)
    '        Loop
    '    Else
    '    End If

    '    reader9.Close()
    '    ADVERTENCIA = ""

    '    ''INDICE EDAD------------------------------------------
    '    edad = txtEdad2.Text
    '    Dim conexiones8 As New CConexion
    '    conexiones8.conexion()
    '    Dim command8 As SqlCommand = New SqlCommand("SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (38,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Edad' and   CONVERT(decimal (38,2),'" + edad + "')>CONVERT(decimal (38,2),rango1) AND CONVERT(decimal (38,2),'" + edad + "')<=CONVERT(decimal (38,2),rango2)", conexiones8._conexion)
    '    conexiones8.abrir()
    '    Dim reader8 As SqlDataReader = command8.ExecuteReader()

    '    If reader8.HasRows Then
    '        Do While reader8.Read()
    '            puntaje = puntaje + Double.Parse((reader8(0).ToString))

    '            richTextBox1.Text += "Edad:" + Environment.NewLine + "Valor= " + edad.Trim + "     |     Puntaje= " + reader8(0).ToString + Environment.NewLine + Environment.NewLine

    '            Words.Add(reader8(0).ToString)
    '        Loop
    '    Else
    '    End If

    '    reader8.Close()


    '    ''INDICE LEVERAGE------------------------------------------

    '    lvl = txtLeverage.Text
    '    Dim conexiones88 As New CConexion
    '    conexiones88.conexion()
    '    Dim command88 As SqlCommand = New SqlCommand("SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (38,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Leverage' and   CONVERT(decimal (38,2),'" + lvl + "')>CONVERT(decimal (38,2),rango1) AND CONVERT(decimal (38,2),'" + lvl + "')<=CONVERT(decimal (38,2),rango2)", conexiones88._conexion)
    '    conexiones88.abrir()
    '    Dim reader88 As SqlDataReader = command88.ExecuteReader()

    '    If reader88.HasRows Then
    '        Do While reader88.Read()
    '            puntaje = puntaje + Double.Parse((reader88(0).ToString))
    '            richTextBox1.Text += "Leverage:" + Environment.NewLine + "Valor= " + lvl.Trim + "     |     Puntaje= " + reader88(0).ToString + Environment.NewLine + Environment.NewLine
    '            Words.Add(reader88(0).ToString)
    '        Loop
    '    Else
    '    End If

    '    reader88.Close()


    '    ''INDICE VIVIENDA------------------------------------------


    '    vivienda = txtTipovivienda2.Text.Trim
    '    'MsgBox(formadepago2)
    '    If (vivienda = "") Then
    '        vivienda = "Sin registro"
    '        ADVERTENCIA = "* No tiene Historico por defecto 'Sin registro' "
    '    End If


    '    Dim conexiones77 As New CConexion
    '    conexiones77.conexion()
    '    Dim command77 As SqlCommand = New SqlCommand("  SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (6,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Vivienda' and  [Rango1] ='" + vivienda + "'", conexiones77._conexion)
    '    conexiones77.abrir()
    '    Dim reader77 As SqlDataReader = command77.ExecuteReader()

    '    If reader77.HasRows Then
    '        Do While reader77.Read()


    '            puntaje = puntaje + Double.Parse((reader77(0).ToString))


    '            richTextBox1.Text += "Vivienda:" + Environment.NewLine + "Valor= " + vivienda.Trim + "     |     Puntaje= " + reader77(0).ToString + Environment.NewLine + Environment.NewLine

    '            If (ADVERTENCIA <> "") Then
    '                richTextBox1.Text = richTextBox1.Text + ADVERTENCIA + Environment.NewLine + Environment.NewLine
    '            End If

    '            Words.Add(reader77(0).ToString)
    '        Loop
    '    Else
    '    End If

    '    reader77.Close()

    '    ADVERTENCIA = ""

    '    ''INDICE ESTADO CIVIL------------------------------------------

    '    estadocivil = txtEstadocivil2.Text.Trim

    '    If (estadocivil = "") Then
    '        estadocivil = "Soltero"
    '        ADVERTENCIA = "* No tiene Historico por defecto 'Soltero' "
    '    End If


    '    Dim conexiones99 As New CConexion
    '    conexiones99.conexion()
    '    Dim command99 As SqlCommand = New SqlCommand("  SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (6,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Estado Civil' and  [Rango1] ='" + estadocivil + "'", conexiones99._conexion)
    '    conexiones99.abrir()
    '    Dim reader99 As SqlDataReader = command99.ExecuteReader()

    '    If reader99.HasRows Then
    '        Do While reader99.Read()


    '            puntaje = puntaje + Double.Parse((reader99(0).ToString))

    '            richTextBox1.Text += "Estado Civil:" + Environment.NewLine + "Valor= " + estadocivil.Trim + "     |     Puntaje= " + reader99(0).ToString + Environment.NewLine + Environment.NewLine

    '            If (ADVERTENCIA <> "") Then
    '                richTextBox1.Text = richTextBox1.Text + ADVERTENCIA + Environment.NewLine + Environment.NewLine
    '            End If

    '            Words.Add(reader99(0).ToString)
    '        Loop
    '    Else
    '    End If

    '    reader99.Close()

    '    ADVERTENCIA = ""

    '    ''INDICE REGIÓN------------------------------------------

    '    region = txtRegion.Text.Trim

    '    If (region = "") Then
    '        region = "VALPARAISO                              "
    '        ADVERTENCIA = "* No tiene Historico por defecto 'VALPARAISO' "
    '    End If


    '    Dim conexiones99b As New CConexion
    '    conexiones99b.conexion()
    '    Dim command99b As SqlCommand = New SqlCommand("  SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (6,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Región' and  [Rango1] ='" + region + "'", conexiones99b._conexion)
    '    conexiones99b.abrir()
    '    Dim reader99b As SqlDataReader = command99b.ExecuteReader()

    '    If reader99b.HasRows Then
    '        Do While reader99b.Read()


    '            puntaje = puntaje + Double.Parse((reader99b(0).ToString))


    '            richTextBox1.Text += "Región:" + Environment.NewLine + "Valor= " + region.Trim + "     |     Puntaje= " + reader99b(0).ToString + Environment.NewLine + Environment.NewLine

    '            If (ADVERTENCIA <> "") Then
    '                richTextBox1.Text = richTextBox1.Text + ADVERTENCIA + Environment.NewLine + Environment.NewLine
    '            End If

    '            Words.Add(reader99b(0).ToString)
    '        Loop
    '    Else
    '    End If

    '    reader99b.Close()

    '    ADVERTENCIA = ""




    '    ''INDICE SEXO------------------------------------------

    '    sexo = TxtSexo.Text.Trim

    '    'If (region = "") Then
    '    '    region = "VALPARAISO                              "
    '    '    ADVERTENCIA = "* No tiene Historico por defecto 'VALPARAISO' "
    '    'End If


    '    Dim conexiones99C As New CConexion
    '    conexiones99C.conexion()
    '    Dim command99C As SqlCommand = New SqlCommand("  SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (6,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Sexo' and  [Rango1] ='" + sexo + "'", conexiones99C._conexion)
    '    conexiones99C.abrir()
    '    Dim reader99C As SqlDataReader = command99C.ExecuteReader()

    '    If reader99C.HasRows Then
    '        Do While reader99C.Read()


    '            puntaje = puntaje + Double.Parse((reader99C(0).ToString))


    '            richTextBox1.Text += "Sexo:" + Environment.NewLine + "Valor= " + sexo.Trim + "     |     Puntaje= " + reader99C(0).ToString + Environment.NewLine + Environment.NewLine

    '            'If (ADVERTENCIA <> "") Then
    '            '    richTextBox1.Text = richTextBox1.Text + ADVERTENCIA + Environment.NewLine
    '            'End If

    '            Words.Add(reader99C(0).ToString)
    '        Loop
    '    Else
    '    End If

    '    reader99C.Close()


    '    ''INDICE ANTIGUEDAD------------------------------------------
    '    antiguedad = txtAntiguedad2.Text
    '    Dim conexiones88A As New CConexion
    '    conexiones88A.conexion()
    '    Dim command88A As SqlCommand = New SqlCommand("SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (38,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Antigüedad' and   CONVERT(decimal (38,2),'" + antiguedad + "')>CONVERT(decimal (38,2),rango1) AND CONVERT(decimal (38,2),'" + antiguedad + "')<=CONVERT(decimal (38,2),rango2)", conexiones88A._conexion)
    '    conexiones88A.abrir()
    '    Dim reader88A As SqlDataReader = command88A.ExecuteReader()

    '    If reader88A.HasRows Then
    '        Do While reader88A.Read()
    '            puntaje = puntaje + Double.Parse((reader88A(0).ToString))
    '            richTextBox1.Text += "Antiguedad:" + Environment.NewLine + "Valor= " + antiguedad.Trim + "     |     Puntaje= " + reader88A(0).ToString + Environment.NewLine + Environment.NewLine
    '            Words.Add(reader88A(0).ToString)
    '        Loop
    '    Else
    '    End If

    '    reader88A.Close()



    '    ''INDICE RENTA------------------------------------------
    '    renta = Replace(txtRLP.Text, ".", "")
    '    Dim conexiones88B As New CConexion
    '    conexiones88B.conexion()
    '    Dim command88B As SqlCommand = New SqlCommand("SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (38,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Renta' and   CONVERT(decimal (38,2),'" + renta + "')>CONVERT(decimal (38,2),rango1) AND CONVERT(decimal (38,2),'" + renta + "')<=CONVERT(decimal (38,2),rango2)", conexiones88B._conexion)
    '    conexiones88B.abrir()
    '    Dim reader88B As SqlDataReader = command88B.ExecuteReader()

    '    If reader88B.HasRows Then
    '        Do While reader88B.Read()
    '            puntaje = puntaje + Double.Parse((reader88B(0).ToString))
    '            richTextBox1.Text += "Renta:" + Environment.NewLine + "Valor= " + txtRLP.Text.Trim + "     |     Puntaje= " + reader88B(0).ToString + Environment.NewLine + Environment.NewLine
    '            Words.Add(reader88B(0).ToString)
    '        Loop
    '    Else
    '    End If

    '    reader88B.Close()

    '    'INDICE PLAZO------------------------------------------
    '    plazo = txtPlazo.Text
    '    Dim conexiones88C As New CConexion
    '    conexiones88C.conexion()
    '    Dim command88C As SqlCommand = New SqlCommand("SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (38,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='plazo' and   CONVERT(decimal (38,2),'" + plazo + "')>CONVERT(decimal (38,2),rango1) AND CONVERT(decimal (38,2),'" + plazo + "')<=CONVERT(decimal (38,2),rango2)", conexiones88C._conexion)
    '    conexiones88C.abrir()
    '    Dim reader88C As SqlDataReader = command88C.ExecuteReader()

    '    If reader88C.HasRows Then
    '        Do While reader88C.Read()
    '            puntaje = puntaje + Double.Parse((reader88C(0).ToString))
    '            richTextBox1.Text += "Plazo:" + Environment.NewLine + "Valor= " + plazo.Trim + "     |     Puntaje= " + reader88C(0).ToString + Environment.NewLine + Environment.NewLine
    '            Words.Add(reader88C(0).ToString)
    '        Loop
    '    Else
    '    End If

    '    reader88C.Close()

    '    'INDICE MONTO------------------------------------------
    '    Monto = Replace(TxtMonto.Text, ".", "")
    '    Dim conexiones88D As New CConexion
    '    conexiones88D.conexion()
    '    Dim command88D As SqlCommand = New SqlCommand("SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (38,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Monto' and   CONVERT(decimal (38,2),'" + Monto + "')>CONVERT(decimal (38,2),rango1) AND CONVERT(decimal (38,2),'" + Monto + "')<=CONVERT(decimal (38,2),rango2)", conexiones88D._conexion)
    '    conexiones88D.abrir()
    '    Dim reader88D As SqlDataReader = command88D.ExecuteReader()

    '    If reader88D.HasRows Then
    '        Do While reader88D.Read()
    '            puntaje = puntaje + Double.Parse((reader88D(0).ToString))
    '            richTextBox1.Text += "Monto:" + Environment.NewLine + "Valor= " + TxtMonto.Text.Trim + "     |     Puntaje= " + reader88D(0).ToString + Environment.NewLine + Environment.NewLine
    '            Words.Add(reader88D(0).ToString)
    '        Loop
    '    Else
    '    End If

    '    reader88D.Close()
    '    'ADVERTENCIA = ""


    '    ''INDICE Tipo de Socio------------------------------------------

    '    TipodeSocio = txtInstitucion.Text.Trim

    '    If (TipodeSocio = "") Then
    '        TipodeSocio = "Particular"
    '        ADVERTENCIA = "* No tiene Historico por defecto 'Particular' "
    '    End If



    '    Dim conexiones99De As New CConexion
    '    conexiones99De.conexion()
    '    Dim command99De As SqlCommand = New SqlCommand("IF EXISTS (SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (6,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Tipo de Socio' and  [Rango1] ='" + TipodeSocio + "') select 'SI' ELSE select 'NO'", conexiones99De._conexion)
    '    conexiones99De.abrir()
    '    Dim reader99De As SqlDataReader = command99De.ExecuteReader()

    '    If reader99De.HasRows Then
    '        Do While reader99De.Read()
    '            If (reader99De(0).ToString = "NO") Then
    '                TipodeSocio = "Particular"
    '                ADVERTENCIA = "* Categoria no ingresada por defecto puntaje de 'Particular' "
    '            End If
    '        Loop
    '    Else
    '    End If

    '    reader99De.Close()




    '    Dim conexiones99D As New CConexion
    '    conexiones99D.conexion()
    '    Dim command99D As SqlCommand = New SqlCommand("  SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (6,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Tipo de Socio' and  [Rango1] ='" + TipodeSocio + "'", conexiones99D._conexion)
    '    conexiones99D.abrir()
    '    Dim reader99D As SqlDataReader = command99D.ExecuteReader()

    '    If reader99D.HasRows Then
    '        Do While reader99D.Read()


    '            puntaje = puntaje + Double.Parse((reader99D(0).ToString))


    '            richTextBox1.Text += "Tipo de Socio:" + Environment.NewLine + "Valor= " + txtInstitucion.Text.Trim + "     |     Puntaje= " + reader99D(0).ToString + Environment.NewLine + Environment.NewLine

    '            If (ADVERTENCIA <> "") Then
    '                richTextBox1.Text = richTextBox1.Text + ADVERTENCIA + Environment.NewLine + Environment.NewLine
    '            End If

    '            Words.Add(reader99D(0).ToString)
    '        Loop
    '    Else
    '    End If

    '    reader99D.Close()


    '    ADVERTENCIA = ""


    '    'INDICE Dias de Gracia------------------------------------------
    '    DiasdeGracia = Replace(txtDiasGracia.Text, ".", "")
    '    Dim conexiones88F As New CConexion
    '    conexiones88F.conexion()
    '    Dim command88F As SqlCommand = New SqlCommand("SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (38,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Dias de Gracia' and   CONVERT(decimal (38,2),'" + DiasdeGracia + "')>CONVERT(decimal (38,2),rango1) AND CONVERT(decimal (38,2),'" + DiasdeGracia + "')<=CONVERT(decimal (38,2),rango2)", conexiones88F._conexion)
    '    conexiones88F.abrir()
    '    Dim reader88F As SqlDataReader = command88F.ExecuteReader()

    '    If reader88F.HasRows Then
    '        Do While reader88F.Read()
    '            puntaje = puntaje + Double.Parse((reader88F(0).ToString))
    '            richTextBox1.Text += "Dias de Gracia:" + Environment.NewLine + "Valor= " + DiasdeGracia.ToString.Trim + "     |     Puntaje= " + reader88F(0).ToString + Environment.NewLine + Environment.NewLine
    '            Words.Add(reader88F(0).ToString)
    '        Loop
    '    Else
    '    End If
    '    reader88F.Close()



    '    ''INDICE PLATAFORMA------------------------------------------

    '    Plataforma = txtPlataforma.Text.Trim

    '    'If (region = "") Then
    '    '    region = "VALPARAISO                              "
    '    '    ADVERTENCIA = "* No tiene Historico por defecto 'VALPARAISO' "
    '    'End If

    '    Dim conexiones99F As New CConexion
    '    conexiones99F.conexion()
    '    Dim command99F As SqlCommand = New SqlCommand("  SELECT  isnull( CAST((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) from _RIESGO_SCORING2 where tipo=cc1.tipo and categoria=cc1.categoria and subcategoria='NO'))-1 )*100 AS decimal (6,2) ),0) as INDICE  FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla WHERE cc1.CATEGORIA='" + categoria + "' and cc1.Tipo='Plataforma' and  [Rango1] ='" + Plataforma + "'", conexiones99F._conexion)
    '    conexiones99F.abrir()
    '    Dim reader99F As SqlDataReader = command99F.ExecuteReader()

    '    If reader99F.HasRows Then
    '        Do While reader99F.Read()


    '            puntaje = puntaje + Double.Parse((reader99F(0).ToString))


    '            richTextBox1.Text += "Plataforma:" + Environment.NewLine + "Valor= " + Plataforma.Trim + "     |     Puntaje= " + reader99F(0).ToString + Environment.NewLine + Environment.NewLine

    '            'If (ADVERTENCIA <> "") Then
    '            '    richTextBox1.Text = richTextBox1.Text + ADVERTENCIA + Environment.NewLine
    '            'End If

    '            Words.Add(reader99F(0).ToString)
    '        Loop
    '    Else
    '    End If

    '    reader99F.Close()

    '    ADVERTENCIA = ""




    '    'INDICA EL PUNTAJE FINAL
    '    'If (txtPuntaje3.Text.Trim <> "") Then
    '    '    txtPuntaje2.Text = txtPuntaje3.Text.Trim
    '    '    puntaje = txtPuntaje3.Text.Trim
    '    'Else
    '    '    txtPuntaje2.Text = puntaje
    '    richTextBox1.Text = Environment.NewLine + "Indice Acumulado " + puntaje + Environment.NewLine + Environment.NewLine + richTextBox1.Text
    '    'richTextBox1.SelectedRtf = richTextBox1.Text + Environment.NewLine + "{\rtf1\ansi This is in \b bold\b0.}" + puntaje + Environment.NewLine
    '    Words.Add(puntaje)
    '    'LPuntaje.Text = puntaje
    '    'End If

    '    For i As Integer = 0 To Words.Count - 1
    '        colorWord(Words.Item(i))
    '    Next

    '    SIZEWord("Indice Acumulado " + puntaje, "titulo")
    '    'SIZEWord("Factor ", "titulo")

    '    SIZEWord("Forma de pago:", "subtitulo")
    '    SIZEWord("Capacidad de pago:", "subtitulo")
    '    SIZEWord("Edad:", "subtitulo")
    '    SIZEWord("Leverage:", "subtitulo")
    '    SIZEWord("Vivienda:", "subtitulo")
    '    SIZEWord("Estado Civil:", "subtitulo")
    '    SIZEWord("Región:", "subtitulo")
    '    SIZEWord("Sexo:", "subtitulo")
    '    SIZEWord("Antiguedad:", "subtitulo")
    '    SIZEWord("Renta:", "subtitulo")
    '    SIZEWord("Plazo:", "subtitulo")
    '    SIZEWord("Monto:", "subtitulo")
    '    SIZEWord("Tipo de Socio:", "subtitulo")
    '    SIZEWord("Dias de Gracia:", "subtitulo")
    '    SIZEWord("Plataforma:", "subtitulo")
    '    SIZEWord("Forma De Pago No valida por PLANILLA", "subtitulo")






    '    cargarfactor(categoria, puntaje, plazo, txtTasaReal.Text)
    '    cargartasamaxima(Replace(TxtMonto.Text, ".", ""))
    '    'EXCEPCIONESTASAS()
    '    'cargarestado()







    'End Sub


    'Sub cargarestado()


    'End Sub

    'Sub cargarfactor(ByRef categoria As String, ByRef puntaje As Double, ByRef plazo As Integer, ByRef tasa As Double)

    '    Dim conexiones2 As New CConexion
    '    conexiones2.conexion()
    '    conexiones2.abrir()
    '    Dim command As SqlCommand
    '    Dim adapter As SqlDataAdapter
    '    Dim dtTable As DataTable

    '    'Indico el SP que voy a utilizar
    '    If txtObjetivo2.Text.Trim = "Renegociación" Or txtObjetivo2.Text.Trim = "Refinanciamiento" Then
    '        command = New SqlCommand("Riesgo_puntajes2_tasa_renegociado", conexiones2._conexion)
    '        command.CommandType = CommandType.StoredProcedure
    '        adapter = New SqlDataAdapter(command)
    '        dtTable = New DataTable
    '        With command.Parameters
    '            'Envió los parámetros que necesito
    '            .Add(New SqlParameter("@puntaje", SqlDbType.Decimal)).Value = puntaje
    '            .Add(New SqlParameter("@PLAZO", SqlDbType.Int)).Value = plazo
    '            .Add(New SqlParameter("@tasa", SqlDbType.Decimal)).Value = tasa
    '        End With
    '    Else
    '        command = New SqlCommand("Riesgo_puntajes2_tasa", conexiones2._conexion)
    '        command.CommandType = CommandType.StoredProcedure
    '        adapter = New SqlDataAdapter(command)
    '        dtTable = New DataTable
    '        With command.Parameters
    '            'Envió los parámetros que necesito
    '            .Add(New SqlParameter("@Categoria", SqlDbType.VarChar)).Value = categoria
    '            .Add(New SqlParameter("@puntaje", SqlDbType.Decimal)).Value = puntaje
    '            .Add(New SqlParameter("@PLAZO", SqlDbType.Int)).Value = plazo
    '            .Add(New SqlParameter("@tasa", SqlDbType.Decimal)).Value = tasa
    '        End With


    '    End If
    '    Try
    '        'Aquí ejecuto el SP y lo lleno en el DataTable
    '        adapter.Fill(dtTable)
    '        'Enlazo mis datos obtenidos en el DataTable con el grid
    '        DGScoring.DataSource = dtTable
    '        'Si no pongo esta línea, se crean automáticamente los campos del grid dependiendo de los campos del DataTable
    '        DGScoring.AutoGenerateColumns = False
    '        'Aquí le indico cuales campos del select de mi SP van con los campos de mi grid
    '        'With DGPuntajes2
    '        '    .Columns("Tipo").DataPropertyName = "Tipo"
    '        '    '.Columns("Campo2").DataPropertyName = "campo2"
    '        '    '.Columns("Campo3").DataPropertyName = "campo3"
    '        'End With
    '    Catch expSQL As SqlException
    '        MsgBox(expSQL.ToString, MsgBoxStyle.OkOnly, "SQL Exception")
    '        Exit Sub
    '    End Try

    '    DGScoring.AllowUserToAddRows = False
    'End Sub



    'Sub cargartasamaxima(ByRef monto As Integer)

    '    Dim conexiones2 As New CConexion
    '    conexiones2.conexion()
    '    conexiones2.abrir()
    '    Dim command As SqlCommand
    '    Dim adapter As SqlDataAdapter
    '    Dim dtTable As DataTable

    '    'Indico el SP que voy a utilizar

    '    command = New SqlCommand("Riesgo_puntaje_tasamaxima", conexiones2._conexion)
    '    command.CommandType = CommandType.StoredProcedure
    '    adapter = New SqlDataAdapter(command)
    '    dtTable = New DataTable
    '    With command.Parameters
    '        'Envió los parámetros que necesito
    '        .Add(New SqlParameter("@monto", SqlDbType.Int)).Value = monto
    '    End With

    '    Try
    '        'Aquí ejecuto el SP y lo lleno en el DataTable
    '        adapter.Fill(dtTable)
    '        'Enlazo mis datos obtenidos en el DataTable con el grid
    '        DGTasaMaxima.DataSource = dtTable
    '        'Si no pongo esta línea, se crean automáticamente los campos del grid dependiendo de los campos del DataTable
    '        DGTasaMaxima.AutoGenerateColumns = False
    '        'Aquí le indico cuales campos del select de mi SP van con los campos de mi grid
    '        'With DGPuntajes2
    '        '    .Columns("Tipo").DataPropertyName = "Tipo"
    '        '    '.Columns("Campo2").DataPropertyName = "campo2"
    '        '    '.Columns("Campo3").DataPropertyName = "campo3"
    '        'End With
    '    Catch expSQL As SqlException
    '        MsgBox(expSQL.ToString, MsgBoxStyle.OkOnly, "SQL Exception")
    '        Exit Sub
    '    End Try

    '    DGScoring.AllowUserToAddRows = False
    'End Sub
    'Sub colorWord(ByVal word As String) ' by im4dbr0
    '    For i As Integer = 0 To richTextBox1.TextLength
    '        Try
    '            If richTextBox1.Text.ElementAt(i).ToString = word.ElementAt(0).ToString Then
    '                Dim found As Boolean = False
    '                For j As Integer = 1 To word.Count - 1
    '                    If richTextBox1.Text.ElementAt(i + j) = word.ElementAt(j) Then
    '                        found = True
    '                    Else
    '                        found = False
    '                        Exit For
    '                    End If
    '                Next
    '                If found = True Then
    '                    richTextBox1.Select(i, word.Length)
    '                    If word <= 0 Then
    '                        richTextBox1.SelectionColor = Drawing.Color.Green
    '                    ElseIf word > 0 And word <= 100 Then
    '                        richTextBox1.SelectionColor = Drawing.Color.Orange
    '                    Else
    '                        richTextBox1.SelectionColor = Drawing.Color.Red
    '                    End If

    '                End If
    '            End If
    '        Catch ex As Exception
    '            Continue For
    '        End Try
    '    Next
    'End Sub

    'Sub SIZEWord(ByVal word As String, ByVal tipo As String) ' by im4dbr0
    '    For i As Integer = 0 To richTextBox1.TextLength
    '        Try
    '            If richTextBox1.Text.ElementAt(i).ToString = word.ElementAt(0).ToString Then
    '                Dim found As Boolean = False
    '                For j As Integer = 1 To word.Count - 1
    '                    If richTextBox1.Text.ElementAt(i + j) = word.ElementAt(j) Then
    '                        found = True
    '                    Else
    '                        found = False
    '                        Exit For
    '                    End If
    '                Next
    '                If found = True Then
    '                    richTextBox1.Select(i, word.Length)

    '                    If tipo = "titulo" Then
    '                        richTextBox1.SelectionFont = New Font("Tahoma", 12, FontStyle.Bold)
    '                    ElseIf tipo = "subtitulo" Then

    '                        richTextBox1.SelectionFont = New Font("Tahoma", 9, FontStyle.Bold)
    '                        richTextBox1.SelectionBullet = True
    '                    End If



    '                End If
    '            End If
    '        Catch ex As Exception
    '            Continue For
    '        End Try
    '    Next
    'End Sub



    'Private Sub EnNegrita(ByVal Rtf As RichTextBox, ByVal Texto As String)
    '    Rtf.SelectionStart = InStr(Rtf.Text, Texto) - 1
    '    Rtf.SelectionLength = Len(Texto)
    '    Rtf.Width = 20
    'End Sub



    'Private Sub DGScoring_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try


    '        txtTasaActual.Text = ""
    '        txtPuntaje2.Text = ""
    '        txtPlazo2.Text = ""
    '        txtMontoUF.Text = ""
    '        txtTasaFinalSI.Text = ""
    '        TXTTasaFinalCI.Text = ""
    '        txtTipo.Text = ""
    '        txtCategoria.Text = ""
    '        txtRango1.Text = ""
    '        txtFactorSI.Text = ""
    '        txtFactorCI.Text = ""
    '        txtFactorPlazoSI.Text = ""
    '        txtFactorPlazoCI.Text = ""
    '        txtAntecedentes.Text = ""
    '        txtPregago2.Text = ""

    '        txtTasaActual.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("tasa").Value.ToString.Trim
    '        txtPuntaje2.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("puntaje").Value.ToString.Trim
    '        txtPlazo2.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("plazo").Value.ToString.Trim
    '        'txtMontoUF.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("monto_solicitado").Value.ToString.Trim
    '        txtTasaFinalSI.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("Factor_total_plazo_tasafinal").Value.ToString.Trim
    '        TXTTasaFinalCI.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("Factor_total_con_informes_plazo_tasafinal").Value.ToString.Trim
    '        txtTipo.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("Tipo").Value.ToString.Trim
    '        txtCategoria.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("Categoria").Value.ToString.Trim
    '        txtRango1.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("Rango1").Value.ToString.Trim
    '        txtRango2.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("Rango2").Value.ToString.Trim
    '        txtFactorSI.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("Factor_total").Value.ToString.Trim
    '        txtFactorCI.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("Factor_total_con_informes").Value.ToString.Trim
    '        txtFactorPlazoSI.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("Factor_total_plazo").Value.ToString.Trim
    '        txtFactorPlazoCI.Text = DGScoring.Rows(DGScoring.CurrentRow.Index).Cells("Factor_total_con_informes_plazo").Value.ToString.Trim


    '        If txtObjetivo2.Text.Trim = "Renegociación" Or txtObjetivo2.Text.Trim = "Refinanciamiento" Then
    '            txtPregago2.Text = "SI"
    '        Else
    '            txtPregago2.Text = "NO"
    '        End If


    '        txtMonto2.Text = ""
    '        txtMontoUF.Text = ""
    '        txtTasaMaxima.Text = ""
    '        txtMontoUF.Text = DGTasaMaxima.Rows(DGTasaMaxima.CurrentRow.Index).Cells("montouf").Value.ToString.Trim
    '        txtTasaMaxima.Text = DGTasaMaxima.Rows(DGTasaMaxima.CurrentRow.Index).Cells("tasa").Value.ToString.Trim
    '        txtMonto2.Text = DGTasaMaxima.Rows(DGTasaMaxima.CurrentRow.Index).Cells("monto").Value.ToString.Trim



    '        If txtProtesto2.Text.ToString.Trim = "Sin Antecedentes" Then
    '            If Double.Parse(txtTasaFinalSI.Text) > Double.Parse(txtTasaMaxima.Text) Then
    '                txtTasaMaxima.BackColor = Color.Green
    '                txtTasaFinalSI.BackColor = Color.Orange
    '                TXTTasaFinalCI.BackColor = Color.White
    '                txtAntecedentes.Text = "NO"

    '            Else
    '                txtTasaMaxima.BackColor = Color.White
    '                txtTasaFinalSI.BackColor = Color.Green
    '                TXTTasaFinalCI.BackColor = Color.White
    '                txtAntecedentes.Text = "NO"

    '            End If


    '        Else
    '            If Double.Parse(txtTasaFinalSI.Text) > Double.Parse(txtTasaMaxima.Text) Then
    '                txtTasaMaxima.BackColor = Color.Green
    '                txtTasaFinalSI.BackColor = Color.White
    '                TXTTasaFinalCI.BackColor = Color.Orange
    '                txtAntecedentes.Text = "SI"
    '            Else
    '                txtTasaMaxima.BackColor = Color.White
    '                txtTasaFinalSI.BackColor = Color.White
    '                TXTTasaFinalCI.BackColor = Color.Green
    '                txtAntecedentes.Text = "SI"
    '            End If



    '        End If


    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Sub carculartasanormal()
    '    'MsgBox(txtAumentoTasa.Text)
    '    'If Integer.Parse(txtTasaCastigo.Text) = 0 Then

    '    '    txtTasaReal.Text = txtTasa.Text
    '    'Else
    '    '    txtTasaReal.Text = (txtTasa.Text * 100) / (txtTasaCastigo.Text + 100)
    '    'End If
    'End Sub





    'Sub EXCEPCIONESTASAS()
    '    'If Double.Parse(txtPuntaje2.Text) <= -30 And txtScoringLvl.Text = "BUENO" And txtAntecedentes.Text = "NO" And txtCapacidad.Text = "BUENO" Then
    '    '    LTEXTO.Text = "Resolución: Socio sujeto de crédito a tasas normales."
    '    'End If

    '    'If Double.Parse(txtPuntaje2.Text) <= -30 And txtScoringLvl.Text.Trim = "BUENO" And txtAntecedentes.Text.Trim = "NO" And txtCapacidad.Text.Trim = "BUENO" Then
    '    '    'LTEXTO.Text = "Resolución: Socio sujeto de crédito a tasas normales."
    '    '    LTEXTO.Text = "menor o igual a -30%"
    '    'ElseIf Double.Parse(txtPuntaje2.Text) > -30 And Double.Parse(txtPuntaje2.Text) < 30 Then
    '    '    LTEXTO.Text = "sea menor o igual a 29,99%, y mayor o igual a -29,99%"
    '    'ElseIf Double.Parse(txtPuntaje2.Text) > 30 Then
    '    '    LTEXTO.Text = "sea mayor o igual a 30%"
    '    'End If



    '    If Double.Parse(txtPuntaje2.Text) <= -30 And txtScoringLvl.Text.Trim = "BUENO" And txtAntecedentes.Text.Trim = "NO" And txtScoringCapacidad.Text.Trim = "BUENO" Then
    '        LTEXTO.Text = "Resolución: Socio sujeto de crédito a tasas normales."
    '        txtPuntaje2.BackColor = Color.Green
    '        txtScoringLvl.BackColor = Color.Green
    '        txtAntecedentes.BackColor = Color.Green
    '        txtScoringCapacidad.BackColor = Color.Green
    '        txtTasaFinalSI.BackColor = Color.White
    '        TXTTasaFinalCI.BackColor = Color.White
    '        txtTasaActual.BackColor = Color.Green
    '        txtestado2.Text = "ACEPTADO , SE ENVIA PARA EVALUACIÓN"
    '    ElseIf Double.Parse(txtPuntaje2.Text) > -30 And Double.Parse(txtPuntaje2.Text) < 30 And txtScoringLvl.Text = "BUENO" And txtAntecedentes.Text = "NO" And txtScoringCapacidad.Text = "BUENO" Then
    '        LTEXTO.Text = "Resolución: Socio sujeto de crédito, pero se incorpora pérdida esperada a la tasa aplicada al crédito, hasta el límite de la tasa máxima convencional."

    '        txtPuntaje2.BackColor = Color.Yellow
    '        txtScoringLvl.BackColor = Color.Green
    '        txtAntecedentes.BackColor = Color.Green
    '        txtScoringCapacidad.BackColor = Color.Green
    '        txtestado2.Text = "ACEPTADO , SE ENVIA PARA EVALUACIÓN PERO CON TASA CASTIGADA"
    '    ElseIf Double.Parse(txtPuntaje2.Text) > 30 And txtScoringLvl.Text = "BUENO" And txtAntecedentes.Text = "NO" And txtScoringCapacidad.Text = "BUENO" Then
    '        LTEXTO.Text = "Resolución: Se enviará solicitud de crédito y al área de riesgo para su evaluación,  se incorpora pérdida esperada a la tasa aplicada al crédito, hasta el límite de la tasa máxima convencional."

    '        txtPuntaje2.BackColor = Color.Red
    '        txtScoringLvl.BackColor = Color.Green
    '        txtAntecedentes.BackColor = Color.Green
    '        txtScoringCapacidad.BackColor = Color.Green
    '        txtestado2.Text = "ACEPTADO , SE ENVIA A RIESGO Y EVALUACIÓN PERO CON TASA CASTIGADA "
    '    Else
    '        LTEXTO.Text = "Resolución: Se incorpora pérdida esperada a la tasa aplicada al crédito"

    '        If txtScoringLvl.Text <> "BUENO" Then
    '            txtScoringLvl.BackColor = Color.Red
    '        End If

    '        If txtAntecedentes.Text <> "NO" Then
    '            txtAntecedentes.BackColor = Color.Red
    '        End If

    '        If txtScoringCapacidad.Text <> "BUENO" Then
    '            txtScoringCapacidad.BackColor = Color.Red
    '        End If
    '        txtestado2.Text = "RECHAZADO"
    '        'txtestado2.ForeColor = Color.Red
    '    End If

    'End Sub



    'Sub colorespropiedad()
    '    If txtScoringPropiedad.Text = "Propia con Dividendos" Or txtScoringPropiedad.Text = "Propia " Then
    '        txtScoringPropiedad.BackColor = Color.Green
    '    Else
    '        txtScoringPropiedad.BackColor = Color.Red
    '    End If
    'End Sub

    'Sub colorestadocivil()
    '    If txtScoringEstadoCivil.Text = "Comunidad de Bienes" Or txtScoringEstadoCivil.Text = "Casado Separación de Bienes" Or txtScoringEstadoCivil.Text = "Casado en Sociedad Conyugal" Then
    '        txtScoringEstadoCivil.BackColor = Color.Green
    '    Else
    '        txtScoringEstadoCivil.BackColor = Color.Red
    '    End If
    'End Sub

    'Sub coloresRenta()
    '    If txtScoringRenta.Text > 250000 Then
    '        txtScoringRenta.BackColor = Color.Green
    '    Else
    '        txtScoringRenta.BackColor = Color.Red
    '    End If
    'End Sub

    'Sub coloresantiguedad()
    '    If txtScoringAntiguedad.Text >= 1 Then
    '        txtScoringAntiguedad.BackColor = Color.Green
    '    Else
    '        txtScoringAntiguedad.BackColor = Color.Red
    '    End If
    'End Sub

    'Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    EXCEPCIONESTASAS()

    '    txtScoringEstadoCivil.Text = txtEstadocivil2.Text
    '    txtScoringPropiedad.Text = txtTipovivienda2.Text
    '    txtScoringRenta.Text = Replace(txtRentaLiquidaDepurada.Text, ".", "")
    '    txtScoringAntiguedad.Text = txtAntiguedadLab2.Text
    '    txtScoringClasificacion.Text = txtClasificacionBaja.Text

    '    If txtNuevo.Text = "SI" Then
    '        If txtEdad.Text <= 30 Then

    '            colorespropiedad()
    '            colorestadocivil()
    '            coloresRenta()

    '            MsgBox("Nuevo menor de 30")

    '        ElseIf txtEdad.Text > 30 And txtEdad.Text <= 40 Then

    '            colorespropiedad()
    '            colorestadocivil()
    '            coloresRenta()

    '            MsgBox("Nuevo mayor de 30 y menor de 40")
    '        Else
    '            colorespropiedad()
    '            colorestadocivil()
    '            coloresRenta()

    '            MsgBox("Nuevo mayor de 40")

    '        End If


    '    Else

    '        MsgBox("Antiguo")

    '    End If
    'End Sub


    


 
    Private Sub txtDicom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDicom.TextChanged
        If txtDicom.Text = "SI" Then
            txtDicom.BackColor = Color.Green
            txtDicom.ForeColor = Color.White
        Else
            txtDicom.BackColor = Color.Red
            txtDicom.ForeColor = Color.White

        End If
    End Sub

    Private Sub txtAdjuntos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdjuntos.TextChanged
        If txtAdjuntos.Text = "SI" Then
            txtAdjuntos.BackColor = Color.Green
            txtAdjuntos.ForeColor = Color.White
        Else
            txtAdjuntos.BackColor = Color.Red
            txtAdjuntos.ForeColor = Color.White

        End If
    End Sub



    Sub cargarguadados()



        Dim CADENA As String = ""

        Dim conexiones22 As New CConexion
        conexiones22.conexion()
        Dim command22 As SqlCommand = New SqlCommand("SELECT  [VALOR] FROM [_RIESGO_RENTA] WHERE ID=REPLACE('" + txtIdRenta.Text + "','.','') ORDER BY ID DESC ", conexiones22._conexion)
        conexiones22.abrir()
        Dim reader22 As SqlDataReader = command22.ExecuteReader()


        If reader22.HasRows Then
            Do While reader22.Read()

                CADENA = Trim((reader22(0).ToString))

            Loop
        Else
        End If
        reader22.Close()

        Dim conexiones2 As New CConexion
        conexiones2.conexion()
        conexiones2.abrir()
        Dim command As SqlCommand
        Dim adapter As SqlDataAdapter
        Dim dtTable As DataTable


        command = New SqlCommand("RecibirParametros", conexiones2._conexion)
        command.CommandType = CommandType.StoredProcedure
        adapter = New SqlDataAdapter(command)
        dtTable = New DataTable
        With command.Parameters
            'Envió los parámetros que necesito
            .Add(New SqlParameter("@Parametros", SqlDbType.VarChar)).Value = CADENA
        End With

        Try
            adapter.Fill(dtTable)
            DGRentas.DataSource = dtTable
            DGRentas.AutoGenerateColumns = False
        Catch expSQL As SqlException
            MsgBox(expSQL.ToString, MsgBoxStyle.OkOnly, "SQL Exception")
            Exit Sub
        End Try

        DGRentas.AllowUserToAddRows = False




        Dim NUMERO As Integer = 0
        'cboTipo.Visible = True

        ''TIPO
        'cboTipo.SelectedItem = DataGridView1.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1

        'RENTA LIQUIDA MENSUAL
        For m = 1 To DGEmpreadosyPensionados4.ColumnCount - 3
            For i = 0 To DGEmpreadosyPensionados4.RowCount - 2
                DGEmpreadosyPensionados4.Rows(i).Cells(m).Value() = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
                NUMERO = NUMERO + 1

            Next
        Next

        'PORCENTAJE DESCUENTO
        cboPorcentajeDescuento.Text = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1

        ''DESCUENTOS DE LA ULTIMA LIQUIDACION
        For i = 0 To DGEDescuentos.RowCount - 2
            DGEDescuentos.Rows(i).Cells(1).Value() = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
            NUMERO = NUMERO + 1
        Next

        ''HABERES IMPONIBLES

        For m = 1 To DGEmpreadosyPensionados.ColumnCount - 3
            For i = 0 To DGEmpreadosyPensionados.RowCount - 2
                DGEmpreadosyPensionados.Rows(i).Cells(m).Value() = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
                NUMERO = NUMERO + 1
            Next
        Next


        ''OPCIONAL 1
        DGEmpreadosyPensionados.Rows(20).Cells(0).Value() = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1
        ''OPCIONAL 2
        DGEmpreadosyPensionados.Rows(21).Cells(0).Value() = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1
        ''OPCIONAL 3

        DGEmpreadosyPensionados.Rows(22).Cells(0).Value() = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1


        ''TASA
        'CboTasa.SelectedItem = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1
        ''PLAZO
        'CboPlazo.SelectedItem = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1

        ''COMENTARIO

        txtComentario.Text = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
        NUMERO = NUMERO + 1

        ''HONORARIOS
        For i = 0 To DGProfesionalesyTrabajadoresIndependientes.RowCount - 2
            DGProfesionalesyTrabajadoresIndependientes.Rows(i).Cells(1).Value() = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
            NUMERO = NUMERO + 1

        Next

        ''FORMULARIOS ANUAL
        For i = 0 To DGProfesionalesyTrabajadoresIndependientes2.RowCount - 1
                DGProfesionalesyTrabajadoresIndependientes2.Rows(i).Cells(1).Value() = DGRentas.Rows(NUMERO).Cells(0).Value().ToString()
                NUMERO = NUMERO + 1
            Next


        calcularRentaLiquida()
        calcularhaberes()
        calculardescuentos()
        calcularhonorarios()

        calcularRPLEmpleado()
        calcularRPLIndependiente()
        calcularRPLTotal()



        'DGGuardado.AllowUserToAddRows = False

    End Sub

    Sub cargarrentas()

        For i = 0 To 23
            Me.DGEmpreadosyPensionados.Rows.Add()
        Next

        For i = 0 To 6
            Me.DGEmpreadosyPensionados4.Rows.Add()
        Next

        For i = 0 To 9
            Me.DGEDescuentos.Rows.Add()
        Next


        For i = 0 To 12
            Me.DGProfesionalesyTrabajadoresIndependientes.Rows.Add()
        Next


        For i = 0 To 1
            Me.DGProfesionalesyTrabajadoresIndependientes2.Rows.Add()
        Next

        DGEmpreadosyPensionados4.Rows(0).Cells(0).Value() = "Sueldo Base Mas Gratificación"
        DGEmpreadosyPensionados4.Rows(1).Cells(0).Value() = "Otros haberes imponibles variables"
        DGEmpreadosyPensionados4.Rows(2).Cells(0).Value() = "Otros haberes no imponibles"
        DGEmpreadosyPensionados4.Rows(3).Cells(0).Value() = "Descuentos Legales"
        DGEmpreadosyPensionados4.Rows(4).Cells(0).Value() = "Descuentos Deudas u Obligaciones"
        DGEmpreadosyPensionados4.Rows(5).Cells(0).Value() = "Impuesto Único de Segunda Categoría"
        DGEmpreadosyPensionados4.Rows(6).Cells(0).Value() = "TOTAL"
        DGEmpreadosyPensionados4.Columns(5).DefaultCellStyle.BackColor = Color.LightGray
        DGEmpreadosyPensionados4.Columns(5).DefaultCellStyle.BackColor = Color.LightGray
        DGEmpreadosyPensionados4.Rows(6).DefaultCellStyle.BackColor = Color.Black
        DGEmpreadosyPensionados4.Rows(6).DefaultCellStyle.ForeColor = Color.White
        DGEmpreadosyPensionados4.Rows(6).ReadOnly = True


        DGEmpreadosyPensionados.Rows(0).Cells(0).Value() = "Salario del Período / Sueldo Base"
        DGEmpreadosyPensionados.Rows(1).Cells(0).Value() = "Gratificación/Componente Base PMG/Asignación Municipal"
        DGEmpreadosyPensionados.Rows(2).Cells(0).Value() = "Incremento Remun. Imponible / Incremento Prev."
        DGEmpreadosyPensionados.Rows(3).Cells(0).Value() = "Asignación Unica Tributable"
        DGEmpreadosyPensionados.Rows(4).Cells(0).Value() = "Bonif. Salud ley 18566"
        DGEmpreadosyPensionados.Rows(5).Cells(0).Value() = "Asig. Ley 18675 Art. 10"
        DGEmpreadosyPensionados.Rows(6).Cells(0).Value() = "Asig. Ley 18717"
        DGEmpreadosyPensionados.Rows(7).Cells(0).Value() = "Asig. Ley 19529"
        DGEmpreadosyPensionados.Rows(8).Cells(0).Value() = "Bonif. Art. 21 Ley 19429"
        DGEmpreadosyPensionados.Rows(9).Cells(0).Value() = "Asig. Sust. L, 19185"
        DGEmpreadosyPensionados.Rows(10).Cells(0).Value() = "Asig. Fiscalización"
        DGEmpreadosyPensionados.Rows(11).Cells(0).Value() = "Bono Productividad / Bono Resultado/ Asig. Merito"
        DGEmpreadosyPensionados.Rows(12).Cells(0).Value() = "Incentivo"
        DGEmpreadosyPensionados.Rows(13).Cells(0).Value() = "Semana Corrida"
        DGEmpreadosyPensionados.Rows(14).Cells(0).Value() = "Horas Extras"
        DGEmpreadosyPensionados.Rows(15).Cells(0).Value() = "Bono Vacaciones"
        DGEmpreadosyPensionados.Rows(16).Cells(0).Value() = "Bono Producción Vacaciones"
        DGEmpreadosyPensionados.Rows(17).Cells(0).Value() = "Otros Bonos"
        DGEmpreadosyPensionados.Rows(18).Cells(0).Value() = "Atención Primaria (en salud)"
        DGEmpreadosyPensionados.Rows(19).Cells(0).Value() = "Otros Haberes Imp."
        DGEmpreadosyPensionados.Rows(20).Cells(0).Value() = "Opcional 1"
        DGEmpreadosyPensionados.Rows(21).Cells(0).Value() = "Opcional 2"
        DGEmpreadosyPensionados.Rows(22).Cells(0).Value() = "Opcional 3"
        DGEmpreadosyPensionados.Rows(23).Cells(0).Value() = "TOTAL"
        DGEmpreadosyPensionados.Columns(4).DefaultCellStyle.BackColor = Color.LightGray
        DGEmpreadosyPensionados.Columns(5).DefaultCellStyle.BackColor = Color.LightGray
        DGEmpreadosyPensionados.Rows(23).DefaultCellStyle.BackColor = Color.Black
        DGEmpreadosyPensionados.Rows(23).DefaultCellStyle.ForeColor = Color.White
        DGEmpreadosyPensionados.Rows(23).ReadOnly = True

        'DGEmpreadosyPensionados.Rows(20).DefaultCellStyle.ForeColor = Color.White


        DGEDescuentos.Rows(0).Cells(0).Value() = "Seguro Salud"
        DGEDescuentos.Rows(1).Cells(0).Value() = "Seguro de Vida"
        DGEDescuentos.Rows(2).Cells(0).Value() = "Seguro Catastrófico"
        DGEDescuentos.Rows(3).Cells(0).Value() = "Préstamo Interno"
        DGEDescuentos.Rows(4).Cells(0).Value() = "Cuota sindical Empresa"
        DGEDescuentos.Rows(5).Cells(0).Value() = "Cuota extra sindical"
        DGEDescuentos.Rows(6).Cells(0).Value() = "Cuota 75% sindical"
        DGEDescuentos.Rows(7).Cells(0).Value() = "Descuentos Varios (préstamos comerciales)"
        DGEDescuentos.Rows(8).Cells(0).Value() = "Otros Descuentos"
        DGEDescuentos.Rows(9).Cells(0).Value() = "TOTAL"
        DGEDescuentos.Rows(9).DefaultCellStyle.BackColor = Color.Black
        DGEDescuentos.Rows(9).DefaultCellStyle.ForeColor = Color.White
        DGEDescuentos.Rows(9).ReadOnly = True








        DGProfesionalesyTrabajadoresIndependientes.Rows(0).Cells(0).Value() = "Mes 1"
        DGProfesionalesyTrabajadoresIndependientes.Rows(1).Cells(0).Value() = "Mes 2"
        DGProfesionalesyTrabajadoresIndependientes.Rows(2).Cells(0).Value() = "Mes 3"
        DGProfesionalesyTrabajadoresIndependientes.Rows(3).Cells(0).Value() = "Mes 4"
        DGProfesionalesyTrabajadoresIndependientes.Rows(4).Cells(0).Value() = "Mes 5"
        DGProfesionalesyTrabajadoresIndependientes.Rows(5).Cells(0).Value() = "Mes 6"
        DGProfesionalesyTrabajadoresIndependientes.Rows(6).Cells(0).Value() = "Mes 7"
        DGProfesionalesyTrabajadoresIndependientes.Rows(7).Cells(0).Value() = "Mes 8"
        DGProfesionalesyTrabajadoresIndependientes.Rows(8).Cells(0).Value() = "Mes 9"
        DGProfesionalesyTrabajadoresIndependientes.Rows(9).Cells(0).Value() = "Mes 10"
        DGProfesionalesyTrabajadoresIndependientes.Rows(10).Cells(0).Value() = "Mes 11"
        DGProfesionalesyTrabajadoresIndependientes.Rows(11).Cells(0).Value() = "Mes 12"
        DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(0).Value() = "TOTAL"
        DGProfesionalesyTrabajadoresIndependientes.Rows(12).DefaultCellStyle.BackColor = Color.Black
        DGProfesionalesyTrabajadoresIndependientes.Rows(12).DefaultCellStyle.ForeColor = Color.White
        DGProfesionalesyTrabajadoresIndependientes.Rows(12).ReadOnly = True


        DGProfesionalesyTrabajadoresIndependientes2.Rows(0).Cells(0).Value() = "Línea 547, Formulario 22"
        DGProfesionalesyTrabajadoresIndependientes2.Rows(1).Cells(0).Value() = "Línea 492, Formulario 22"
        DGProfesionalesyTrabajadoresIndependientes2.Columns(0).DefaultCellStyle.ForeColor = Color.White
        DGProfesionalesyTrabajadoresIndependientes2.Columns(0).DefaultCellStyle.BackColor = Color.Black





        RELLENA0()
        BLOQUEACOLUMNAS()



        If txtIdRenta.Text = "" Or txtIdRenta.Text = "0" Then
            LaDVERTENCIARENTA.Visible = True

        Else
            LaDVERTENCIARENTA.Visible = False
            cargarguadados()
        End If




        'For i = 0.9 To 2.01 Step 0.01
        '    CboTasa.Items.Add(i.ToString)
        'Next









    End Sub


    Sub RELLENA0()


        For m = 1 To DGEmpreadosyPensionados.ColumnCount - 1
            For i = 0 To DGEmpreadosyPensionados.RowCount - 2
                DGEmpreadosyPensionados.Rows(i).Cells(m).Value() = 0
            Next
        Next
        DGEmpreadosyPensionados.Rows(23).Cells(5).Value() = 0

        For i = 0 To DGEDescuentos.RowCount - 1
            DGEDescuentos.Rows(i).Cells(1).Value() = 0
        Next



        For m = 1 To DGEmpreadosyPensionados4.ColumnCount - 1
            For i = 0 To DGEmpreadosyPensionados4.RowCount - 2
                DGEmpreadosyPensionados4.Rows(i).Cells(m).Value() = 0
            Next
        Next
        DGEmpreadosyPensionados4.Rows(6).Cells(5).Value() = 0


        For i = 0 To DGProfesionalesyTrabajadoresIndependientes.RowCount - 1
            DGProfesionalesyTrabajadoresIndependientes.Rows(i).Cells(1).Value() = 0
        Next

        For m = 1 To DGProfesionalesyTrabajadoresIndependientes2.ColumnCount - 1
            For i = 0 To DGProfesionalesyTrabajadoresIndependientes2.RowCount - 1
                DGProfesionalesyTrabajadoresIndependientes2.Rows(i).Cells(m).Value() = 0
            Next
        Next
    End Sub
    Sub calcularRentaLiquida()


        'inicio contar filas
        For f = 0 To DGEmpreadosyPensionados4.RowCount - 2

            'verifica que las finas no tengan valores en 0 antes de sumar el promedio
            If Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(f).Cells(1).Value(), ".", "")) = 0 Or Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(f).Cells(2).Value(), ".", "")) = 0 Or Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(f).Cells(3).Value(), ".", "")) = 0 Then
                ' si alguna columna tiene valor 0 no se realiza la sumatoria
                DGEmpreadosyPensionados4.Rows(f).Cells(4).Value() = 0
            Else
                ' tisi todos los meses tienen vvalor se realiza la suma de su total
                DGEmpreadosyPensionados4.Rows(f).Cells(4).Value() = Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(f).Cells(1).Value(), ".", "")) + Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(f).Cells(2).Value(), ".", "")) + Integer.Parse(Replace(DGEmpreadosyPensionados4.Rows(f).Cells(3).Value(), ".", ""))
                DGEmpreadosyPensionados4.Rows(f).Cells(4).Value() = Puntos(DGEmpreadosyPensionados4.Rows(f).Cells(4).Value())
            End If


            'si el promedio es 0 se deja el total 0
            If DGEmpreadosyPensionados4.Rows(f).Cells(4).Value() = 0 Then
                DGEmpreadosyPensionados4.Rows(f).Cells(5).Value() = 0
            Else
                'si el promedio no es 0 se divide por 3 para sacar el promedio
                DGEmpreadosyPensionados4.Rows(f).Cells(5).Value() = Math.Round((Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(f).Cells(4).Value(), ".", "")) / 3))
            End If


            ' de deja el total con puntos
            DGEmpreadosyPensionados4.Rows(f).Cells(5).Value() = Puntos(DGEmpreadosyPensionados4.Rows(f).Cells(5).Value())

        Next



        '   CALCULO DE LOS HABERES VARIABLES 

        Dim minimo As Integer = DGEmpreadosyPensionados4.Rows(1).Cells(1).Value()
        Dim maximo As Integer = DGEmpreadosyPensionados4.Rows(1).Cells(1).Value()
        Dim resultado As Integer

        For i = 2 To 3
            If Double.Parse(minimo) > Double.Parse(DGEmpreadosyPensionados4.Rows(1).Cells(i).Value()) Then
                minimo = DGEmpreadosyPensionados4.Rows(1).Cells(i).Value()
            End If
            If Double.Parse(maximo) < Double.Parse(DGEmpreadosyPensionados4.Rows(1).Cells(i).Value()) Then
                maximo = DGEmpreadosyPensionados4.Rows(1).Cells(i).Value()
            End If
        Next

        If DGEmpreadosyPensionados4.Rows(1).Cells(4).Value() = 0 Then
            DGEmpreadosyPensionados4.Rows(1).Cells(5).Value() = 0
        Else

            If (Double.Parse(maximo) - Double.Parse(minimo)) / Double.Parse(maximo) >= 0.3 Then
                DGEmpreadosyPensionados4.Rows(1).Cells(5).Value() = Math.Round((Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(1).Cells(4).Value(), ".", "")) / 3) * 0.8)

            Else

                DGEmpreadosyPensionados4.Rows(1).Cells(5).Value() = Math.Round((Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(1).Cells(4).Value(), ".", "")) / 3))
            End If
            DGEmpreadosyPensionados4.Rows(1).Cells(5).Value() = Puntos(DGEmpreadosyPensionados4.Rows(1).Cells(5).Value())
        End If


        '   CALCULO DE LOS HABERES NO IMPONIBLES 

        If DGEmpreadosyPensionados4.Rows(2).Cells(4).Value() = 0 Then


            DGEmpreadosyPensionados4.Rows(2).Cells(5).Value() = 0
        Else
            If (Double.Parse(DGEmpreadosyPensionados4.Rows(0).Cells(4).Value()) - Double.Parse(DGEmpreadosyPensionados4.Rows(2).Cells(4).Value())) / Double.Parse(DGEmpreadosyPensionados4.Rows(0).Cells(4).Value()) < 0.5 Then

                DGEmpreadosyPensionados4.Rows(2).Cells(5).Value() = Math.Round((Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(2).Cells(4).Value(), ".", "")) / 3) * 0.5)
            Else
                DGEmpreadosyPensionados4.Rows(2).Cells(5).Value() = Math.Round((Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(2).Cells(4).Value(), ".", "")) / 3))
            End If
            DGEmpreadosyPensionados4.Rows(2).Cells(5).Value() = Puntos(DGEmpreadosyPensionados4.Rows(2).Cells(5).Value())
        End If







        DGEmpreadosyPensionados4.Rows(6).Cells(5).Value() = 0

        For f = 0 To DGEmpreadosyPensionados4.RowCount - 2
            If f <= 2 Then
                DGEmpreadosyPensionados4.Rows(6).Cells(5).Value() = Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(6).Cells(5).Value(), ".", "")) + DGEmpreadosyPensionados4.Rows(f).Cells(5).Value()
            Else
                DGEmpreadosyPensionados4.Rows(6).Cells(5).Value() = Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(6).Cells(5).Value(), ".", "")) - DGEmpreadosyPensionados4.Rows(f).Cells(5).Value()
            End If

        Next

        DGEmpreadosyPensionados4.Rows(6).Cells(5).Value() = Puntos(DGEmpreadosyPensionados4.Rows(6).Cells(5).Value())


    End Sub

    Sub BLOQUEACOLUMNAS()


        For m = 0 To DGEmpreadosyPensionados.ColumnCount - 1
            DGEmpreadosyPensionados.Columns(m).SortMode = DataGridViewColumnSortMode.NotSortable
        Next


        For m = 0 To DGEDescuentos.ColumnCount - 1
            DGEDescuentos.Columns(m).SortMode = DataGridViewColumnSortMode.NotSortable
        Next



        For m = 0 To DGEmpreadosyPensionados4.ColumnCount - 1

            DGEmpreadosyPensionados4.Columns(m).SortMode = DataGridViewColumnSortMode.NotSortable
        Next





        For i = 0 To DGProfesionalesyTrabajadoresIndependientes.ColumnCount - 1
            DGProfesionalesyTrabajadoresIndependientes.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        For m = 0 To DGProfesionalesyTrabajadoresIndependientes2.ColumnCount - 1
            DGProfesionalesyTrabajadoresIndependientes2.Columns(m).SortMode = DataGridViewColumnSortMode.NotSortable
        Next


    End Sub

    Sub calcularRPLIndependiente()

        txtRPLIndependientes.Text = Math.Round((Decimal.Round((Double.Parse(DGProfesionalesyTrabajadoresIndependientes2.Rows(0).Cells(1).Value()) - Double.Parse(DGProfesionalesyTrabajadoresIndependientes2.Rows(1).Cells(1).Value())) / 12)) + (Double.Parse(DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value()) / 2))



        txtRPLIndependientes.Text = "$" + Puntos(txtRPLIndependientes.Text)


    End Sub


    Sub calcularRPLEmpleado()


        'If cboPorcentajeDescuento.SelectedItem = "" Then
        TxtRLPEmpleados.Text = Math.Round(Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(6).Cells(5).Value(), ".", "")))
        TxtRLPEmpleados.Text = "$" + Puntos(TxtRLPEmpleados.Text)

        'Else


        '    txtMaxCuota.Text = Math.Round(((Double.Parse(Replace(DGEmpreadosyPensionados.Rows(23).Cells(5).Value(), ".", "")) * Double.Parse(cboPorcentajeDescuento.SelectedItem)) / 100) - Double.Parse(Replace(DGEDescuentos.Rows(9).Cells(1).Value(), ".", ""))) - 6000
        '    txtMaxCuota.Text = "$" + Puntos(txtMaxCuota.Text)

        '    Dim plazo As Double = 0
        '    Dim tasa As Double = 0
        '    Dim monto As Double = 0
        '    Try

        '        monto = Math.Round(Double.Parse(Replace(Replace(txtMaxCuota.Text, ".", ""), "$", "")))

        '        plazo = Double.Parse(CboPlazo.SelectedItem)
        '        tasa = Double.Parse(CboTasa.SelectedItem) / 100


        '        txtMaxMonto.Text = Math.Round(monto * (((1 + tasa) ^ plazo - 1) / (tasa * (1 + tasa) ^ plazo)))
        '        txtMaxMonto.Text = "$" + Puntos(txtMaxMonto.Text)

        '    Catch ex As Exception

        '    End Try
        '    TxtRLPEmpleados.Text = Math.Round(Double.Parse(Replace(DGEmpreadosyPensionados4.Rows(6).Cells(5).Value(), ".", "")))
        '    TxtRLPEmpleados.Text = "$" + Puntos(TxtRLPEmpleados.Text)
        'End If



    End Sub


    Sub calcularRPLTotal()

        txtRLPTotal.Text = Double.Parse(Replace(Replace(TxtRLPEmpleados.Text, ".", ""), "$", "")) + Double.Parse(Replace(Replace(txtRPLIndependientes.Text, ".", ""), "$", ""))
        txtRLPTotal.Text = "$" + Puntos(txtRLPTotal.Text)

    End Sub

    Sub calcularhaberes()

        'inicio contar filas
        For f = 0 To DGEmpreadosyPensionados.RowCount - 2

            'verifica que las finas no tengan valores en 0 antes de sumar el promedio
            If Double.Parse(Replace(DGEmpreadosyPensionados.Rows(f).Cells(1).Value(), ".", "")) = 0 Or Double.Parse(Replace(DGEmpreadosyPensionados.Rows(f).Cells(2).Value(), ".", "")) = 0 Or Double.Parse(Replace(DGEmpreadosyPensionados.Rows(f).Cells(3).Value(), ".", "")) = 0 Then
                ' si alguna columna tiene valor 0 no se realiza la sumatoria
                DGEmpreadosyPensionados.Rows(f).Cells(4).Value() = 0
            Else
                ' tisi todos los meses tienen vvalor se realiza la suma de su total
                DGEmpreadosyPensionados.Rows(f).Cells(4).Value() = Double.Parse(Replace(DGEmpreadosyPensionados.Rows(f).Cells(1).Value(), ".", "")) + Double.Parse(Replace(DGEmpreadosyPensionados.Rows(f).Cells(2).Value(), ".", "")) + Integer.Parse(Replace(DGEmpreadosyPensionados.Rows(f).Cells(3).Value(), ".", ""))
                DGEmpreadosyPensionados.Rows(f).Cells(4).Value() = Puntos(DGEmpreadosyPensionados.Rows(f).Cells(4).Value())
            End If


            'si el promedio es 0 se deja el total 0
            If DGEmpreadosyPensionados.Rows(f).Cells(4).Value() = 0 Then
                DGEmpreadosyPensionados.Rows(f).Cells(5).Value() = 0
            Else
                'si el promedio no es 0 se divide por 3 para sacar el promedio
                DGEmpreadosyPensionados.Rows(f).Cells(5).Value() = Math.Round((Double.Parse(Replace(DGEmpreadosyPensionados.Rows(f).Cells(4).Value(), ".", "")) / 3))
            End If


            ' de deja el total con puntos
            DGEmpreadosyPensionados.Rows(f).Cells(5).Value() = Puntos(DGEmpreadosyPensionados.Rows(f).Cells(5).Value())

        Next

        DGEmpreadosyPensionados.Rows(23).Cells(5).Value() = 0
        For f = 0 To DGEmpreadosyPensionados.RowCount - 2
            DGEmpreadosyPensionados.Rows(23).Cells(5).Value() = Double.Parse(Replace(DGEmpreadosyPensionados.Rows(23).Cells(5).Value(), ".", "")) + DGEmpreadosyPensionados.Rows(f).Cells(5).Value()
        Next

        DGEmpreadosyPensionados.Rows(23).Cells(5).Value() = Puntos(DGEmpreadosyPensionados.Rows(23).Cells(5).Value())

        If frmPerfil.CbmUsuario.SelectedItem = "CCAMPOS" Or frmPerfil.CbmUsuario.SelectedItem = "HHERRERA(R)" Or frmPerfil.CbmUsuario.SelectedItem = "CAGUILAR" Then

            DGEmpreadosyPensionados.Rows(23).Cells(3).Value() = 0
            For f = 0 To DGEmpreadosyPensionados.RowCount - 2
                DGEmpreadosyPensionados.Rows(23).Cells(3).Value() = Double.Parse(Replace(DGEmpreadosyPensionados.Rows(23).Cells(3).Value(), ".", "")) + DGEmpreadosyPensionados.Rows(f).Cells(3).Value()
            Next
            DGEmpreadosyPensionados.Rows(23).Cells(3).Value() = Puntos(DGEmpreadosyPensionados.Rows(23).Cells(3).Value())

            DGEmpreadosyPensionados.Rows(23).Cells(2).Value() = 0
            For f = 0 To DGEmpreadosyPensionados.RowCount - 2
                DGEmpreadosyPensionados.Rows(23).Cells(2).Value() = Double.Parse(Replace(DGEmpreadosyPensionados.Rows(23).Cells(2).Value(), ".", "")) + DGEmpreadosyPensionados.Rows(f).Cells(2).Value()
            Next
            DGEmpreadosyPensionados.Rows(23).Cells(2).Value() = Puntos(DGEmpreadosyPensionados.Rows(23).Cells(2).Value())

            DGEmpreadosyPensionados.Rows(23).Cells(1).Value() = 0
            For f = 0 To DGEmpreadosyPensionados.RowCount - 2
                DGEmpreadosyPensionados.Rows(23).Cells(1).Value() = Double.Parse(Replace(DGEmpreadosyPensionados.Rows(23).Cells(1).Value(), ".", "")) + DGEmpreadosyPensionados.Rows(f).Cells(1).Value()
            Next
            DGEmpreadosyPensionados.Rows(23).Cells(1).Value() = Puntos(DGEmpreadosyPensionados.Rows(23).Cells(1).Value())
        End If


    End Sub
    Sub calculardescuentos()



        DGEDescuentos.Rows(9).Cells(1).Value() = 0
        For f = 0 To DGEDescuentos.RowCount - 2
            DGEDescuentos.Rows(9).Cells(1).Value() = Double.Parse(Replace(DGEDescuentos.Rows(9).Cells(1).Value(), ".", "")) + DGEDescuentos.Rows(f).Cells(1).Value()
        Next
        DGEDescuentos.Rows(9).Cells(1).Value() = Puntos(DGEDescuentos.Rows(9).Cells(1).Value())


    End Sub

    Sub calcularhonorarios()



        DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value() = 0
        For f = 0 To DGProfesionalesyTrabajadoresIndependientes.RowCount - 2
            'MsgBox(DGProfesionalesyTrabajadoresIndependientes.Rows(f).Cells(1).Value())
            'MsgBox(Double.Parse(Replace(DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value(), ".", "")))
            DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value() = Double.Parse(Replace(DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value(), ".", "")) + DGProfesionalesyTrabajadoresIndependientes.Rows(f).Cells(1).Value()
        Next
        DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value() = Puntos(Math.Round(DGProfesionalesyTrabajadoresIndependientes.Rows(12).Cells(1).Value() / 12))




    End Sub
End Class