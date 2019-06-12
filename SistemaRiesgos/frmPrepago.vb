Imports System.Data
Imports System.Data.SqlClient


Public Class frmPrepago
    Dim PRESTAMO As String = ""

    'Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
    '    'Dim prestamo As String = frmEvaluar.cboConsumo.SelectedItem
    '    Dim actual_cuota As String
    '    Dim actual_corcredito As String
    '    Dim actual_año As String
    '    Dim actual_mes As String

    '    Dim conexiones1 As New CConexion
    '    conexiones1.conexion()
    '    Dim command1 As SqlCommand = New SqlCommand("SELECT top 1 [CUOTANRO],corcredito,RTRIM (CONVERT(char(20),[_AMORTIZACION].[ANODESCUENTO])) as año ,CONVERT(char(20),[_AMORTIZACION].[MESDESCUENTO]) as mes,[SALDOPRESTAMO],[CUOTA],[CAPITAL],[INTERES],[SALDOCAPITAL] FROM [_AMORTIZACION] where CORCREDITO in (  SELECT top 1 CORCREDITO  AS FECHA_PRESTAMO FROM [_PRESTDIARIO] WHERE ESTADO='C'  and nrosocio='" + prestamo + "' order by FECHAPRESTAMO desc) and SALDOPRESTAMO>=(select SUM(cargo)-SUM(abono) from _PRESTAMOS2 where NROSOCIO='" + prestamo + "' group by NROSOCIO) order by CUOTANRO desc", conexiones1._conexion)
    '    conexiones1.abrir()
    '    Dim reader1 As SqlDataReader = command1.ExecuteReader()

    '    If reader1.HasRows Then
    '        Do While reader1.Read()
    '            'txtCapitalPrestamo.Text = (Format(Integer.Parse(reader1(8).ToString), "#,##0"))
    '            actual_cuota = reader1(0).ToString
    '            actual_corcredito = reader1(1).ToString
    '            actual_año = reader1(2).ToString
    '            actual_mes = reader1(3).ToString
    '        Loop
    '    Else
    '    End If

    '    reader1.Close()



    '    'MsgBox("actualcorcredito" + actual_corcredito + "nrosocio" + prestamo + "anteriorcuota" + anterior_cuota.ToString)

    '    Dim conexiones2 As New CConexion
    '    conexiones2.conexion()
    '    Dim command2 As SqlCommand = New SqlCommand("SELECT SUM(capital) FROM [_AMORTIZACION] where  NROSOCIO='" + prestamo + "' and CUOTANRO>='" + actual_cuota + "' and CORCREDITO='" + actual_corcredito + "'", conexiones2._conexion)
    '    conexiones2.abrir()
    '    Dim reader2 As SqlDataReader = command2.ExecuteReader()

    '    If reader2.HasRows Then
    '        Do While reader2.Read()
    '            txtCapitalPrestamo.Text = (Format(Integer.Parse(reader2(0).ToString), "#,##0"))

    '        Loop
    '    Else
    '    End If

    '    reader2.Close()


    '    Dim conexiones3 As New CConexion
    '    conexiones3.conexion()
    '    Dim command3 As SqlCommand = New SqlCommand("SELECT * FROM [_AMORTIZACION] where  NROSOCIO='" + prestamo + "'  and CORCREDITO='" + actual_corcredito + "' and CONVERT(VARCHAR(10),ANODESCUENTO)+CONVERT(VARCHAR(10),MESDESCUENTO) in ((SELECT SUBSTRING(REPLACE(CONVERT(VARCHAR(10), GETDATE(), 111), '/', ''),1,4)+SUBSTRING(REPLACE(CONVERT(VARCHAR(10), GETDATE(), 111), '/', ''),6,1) where SUBSTRING(REPLACE(CONVERT(VARCHAR(10), GETDATE(), 111), '/', ''),5,2) not in (10,11,12)), (SELECT SUBSTRING(REPLACE(CONVERT(VARCHAR(10), GETDATE(), 111), '/', ''),1,6) where SUBSTRING(REPLACE(CONVERT(VARCHAR(10), GETDATE(), 111), '/', ''),5,2) in ('10','11','12')))", conexiones3._conexion)
    '    conexiones3.abrir()
    '    Dim reader3 As SqlDataReader = command3.ExecuteReader()

    '    If reader3.HasRows Then
    '        Do While reader3.Read()
    '            txtCapitalPrestamo.Text = (Format(Integer.Parse(reader3(0).ToString), "#,##0"))

    '        Loop
    '    Else
    '    End If

    '    reader3.Close()

    '    txtInteresVencidoNoPagado.Text = 0
    '    txtSaldoInsoluto.Text = Integer.Parse(Replace(txtCapitalPrestamo.Text, ".", "")) + Integer.Parse(Replace(txtInteresVencidoNoPagado.Text, ".", ""))


    'End Sub

    'Private Sub frmPrepago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    '    'cboConsumo.SelectedIndex = "-1"
    '    'cboComercial.SelectedIndex = "-1"
    '    'CboAdicional.SelectedIndex = "-1"
    '    'cboEmergencia.SelectedIndex = "-1"




    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        Try

            Dim prestamo As String = LboxConsumo.SelectedItem

            Dim conexiones1 As New CConexion
            conexiones1.conexion()
            conexiones1.abrir()
            Dim cmd1 As New SqlCommand("Riesgo_prepago", conexiones1._conexion)
            cmd1.CommandType = CommandType.StoredProcedure
            Dim prm1 As SqlParameter =
                New SqlParameter("@prestamo", SqlDbType.NChar, 30)
            cmd1.Parameters.Add(prm1)
            With cmd1
                .Parameters("@prestamo").Value = prestamo
            End With
            Dim dr1 As SqlDataReader = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
            conexiones1.cerrar()


            Dim conexiones6 As New CConexion
            conexiones6.conexion()
            Dim command6 As SqlCommand = New SqlCommand("SELECT * FROM _RIESGO_PREPAGO where prestamo='" + prestamo + "'", conexiones6._conexion)
            conexiones6.abrir()
            Dim reader6 As SqlDataReader = command6.ExecuteReader()

            If reader6.HasRows Then
                Do While reader6.Read()
                    txtCapitalPrestamo.Text = Format(Integer.Parse(reader6(0).ToString), "#,##0")
                    txtInteresVencidoNoPagado.Text = Format(Integer.Parse(reader6(1).ToString), "#,##0")
                    txtInteresdelmes.Text = Format(Integer.Parse(reader6(2).ToString), "#,##0")
                    txtComisionAnticipoCredito.Text = Format(Integer.Parse(reader6(3).ToString), "#,##0")
                Loop
            Else
            End If

            reader6.Close()

            txtSaldoInsoluto.Text = Format(Integer.Parse(Replace(txtCapitalPrestamo.Text, ".", "")) + Integer.Parse(Replace(txtInteresVencidoNoPagado.Text, ".", "")), "#,##0")

            txtTotalaPagar.Text = Format(Integer.Parse(Replace(txtSaldoInsoluto.Text, ".", "")) + Integer.Parse(Replace(txtInteresdelmes.Text, ".", "")) + Integer.Parse(Replace(txtComisionAnticipoCredito.Text, ".", "")), "#,##0")
        Catch ex As Exception

        End Try
    End Sub




    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim prestamo As String = LboxEmergencia.SelectedItem

        Dim conexiones1 As New CConexion
        conexiones1.conexion()
        conexiones1.abrir()
        Dim cmd1 As New SqlCommand("Riesgo_prepago3_H", conexiones1._conexion)
        cmd1.CommandType = CommandType.StoredProcedure
        Dim prm1 As SqlParameter =
            New SqlParameter("@prestamo", SqlDbType.NChar, 30)
        cmd1.Parameters.Add(prm1)

        Dim prm2 As SqlParameter =
            New SqlParameter("@PERFIL", SqlDbType.NChar, 30)
        cmd1.Parameters.Add(prm2)

        Dim prm3 As SqlParameter =
           New SqlParameter("@nrosocio", SqlDbType.NChar, 30)
        cmd1.Parameters.Add(prm3)

        With cmd1
            .Parameters("@prestamo").Value = prestamo
            .Parameters("@PERFIL").Value = frmPerfil.CbmUsuario.SelectedItem
            .Parameters("@nrosocio").Value = frmEvaluar.txtNrosocio.Text.ToString.Trim
        End With
        Dim dr1 As SqlDataReader = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
        conexiones1.cerrar()



        Dim conexiones6 As New CConexion
        conexiones6.conexion()
        Dim command6 As SqlCommand = New SqlCommand("SELECT * FROM _RIESGO_PREPAGO where prestamo='" + prestamo + "'", conexiones6._conexion)
        conexiones6.abrir()
        Dim reader6 As SqlDataReader = command6.ExecuteReader()

        If reader6.HasRows Then
            Do While reader6.Read()
                txtCapitalPrestamo.Text = Format(Integer.Parse(reader6(0).ToString), "#,##0")
                txtInteresVencidoNoPagado.Text = Format(Integer.Parse(reader6(1).ToString), "#,##0")
                txtInteresdelmes.Text = Format(Integer.Parse(reader6(2).ToString), "#,##0")
                txtComisionAnticipoCredito.Text = Format(Integer.Parse(reader6(3).ToString), "#,##0")
            Loop
        Else
        End If

        reader6.Close()

        txtSaldoInsoluto.Text = Format(Integer.Parse(Replace(txtCapitalPrestamo.Text, ".", "")) + Integer.Parse(Replace(txtInteresVencidoNoPagado.Text, ".", "")), "#,##0")

        txtTotalaPagar.Text = Format(Integer.Parse(Replace(txtSaldoInsoluto.Text, ".", "")) + Integer.Parse(Replace(txtInteresdelmes.Text, ".", "")) + Integer.Parse(Replace(txtComisionAnticipoCredito.Text, ".", "")), "#,##0")

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim prestamo As String = LBoxAdicional.SelectedItem

        Dim conexiones1 As New CConexion
        conexiones1.conexion()
        conexiones1.abrir()
        Dim cmd1 As New SqlCommand("Riesgo_prepago3_H", conexiones1._conexion)
        cmd1.CommandType = CommandType.StoredProcedure
        Dim prm1 As SqlParameter =
            New SqlParameter("@prestamo", SqlDbType.NChar, 30)
        cmd1.Parameters.Add(prm1)

        Dim prm2 As SqlParameter =
            New SqlParameter("@PERFIL", SqlDbType.NChar, 30)
        cmd1.Parameters.Add(prm2)

        Dim prm3 As SqlParameter =
           New SqlParameter("@nrosocio", SqlDbType.NChar, 30)
        cmd1.Parameters.Add(prm3)

        With cmd1
            .Parameters("@prestamo").Value = prestamo
            .Parameters("@PERFIL").Value = frmPerfil.CbmUsuario.SelectedItem
            .Parameters("@nrosocio").Value = frmEvaluar.txtNrosocio.Text.ToString.Trim
        End With
        Dim dr1 As SqlDataReader = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
        conexiones1.cerrar()



        Dim conexiones6 As New CConexion
        conexiones6.conexion()
        Dim command6 As SqlCommand = New SqlCommand("SELECT * FROM _RIESGO_PREPAGO where prestamo='" + prestamo + "'", conexiones6._conexion)
        conexiones6.abrir()
        Dim reader6 As SqlDataReader = command6.ExecuteReader()

        If reader6.HasRows Then
            Do While reader6.Read()
                txtCapitalPrestamo.Text = Format(Integer.Parse(reader6(0).ToString), "#,##0")
                txtInteresVencidoNoPagado.Text = Format(Integer.Parse(reader6(1).ToString), "#,##0")
                txtInteresdelmes.Text = Format(Integer.Parse(reader6(2).ToString), "#,##0")
                txtComisionAnticipoCredito.Text = Format(Integer.Parse(reader6(3).ToString), "#,##0")
            Loop
        Else
        End If

        reader6.Close()

        txtSaldoInsoluto.Text = Format(Integer.Parse(Replace(txtCapitalPrestamo.Text, ".", "")) + Integer.Parse(Replace(txtInteresVencidoNoPagado.Text, ".", "")), "#,##0")

        txtTotalaPagar.Text = Format(Integer.Parse(Replace(txtSaldoInsoluto.Text, ".", "")) + Integer.Parse(Replace(txtInteresdelmes.Text, ".", "")) + Integer.Parse(Replace(txtComisionAnticipoCredito.Text, ".", "")), "#,##0")

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim prestamo As String = LBoxAdicional.SelectedItem

        Dim conexiones1 As New CConexion
        conexiones1.conexion()
        conexiones1.abrir()
        Dim cmd1 As New SqlCommand("Riesgo_prepago3_H", conexiones1._conexion)
        cmd1.CommandType = CommandType.StoredProcedure
        Dim prm1 As SqlParameter =
            New SqlParameter("@prestamo", SqlDbType.NChar, 30)
        cmd1.Parameters.Add(prm1)

        Dim prm2 As SqlParameter =
            New SqlParameter("@PERFIL", SqlDbType.NChar, 30)
        cmd1.Parameters.Add(prm2)

        Dim prm3 As SqlParameter =
           New SqlParameter("@nrosocio", SqlDbType.NChar, 30)
        cmd1.Parameters.Add(prm3)

        With cmd1
            .Parameters("@prestamo").Value = prestamo
            .Parameters("@PERFIL").Value = frmPerfil.CbmUsuario.SelectedItem
            .Parameters("@nrosocio").Value = frmEvaluar.txtNrosocio.Text.ToString.Trim
        End With
        Dim dr1 As SqlDataReader = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
        conexiones1.cerrar()



        Dim conexiones6 As New CConexion
        conexiones6.conexion()
        Dim command6 As SqlCommand = New SqlCommand("SELECT * FROM _RIESGO_PREPAGO where prestamo='" + prestamo + "' AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem + "'", conexiones6._conexion)
        conexiones6.abrir()
        Dim reader6 As SqlDataReader = command6.ExecuteReader()

        If reader6.HasRows Then
            Do While reader6.Read()
                txtCapitalPrestamo.Text = Format(Integer.Parse(reader6(0).ToString), "#,##0")
                txtInteresVencidoNoPagado.Text = Format(Integer.Parse(reader6(1).ToString), "#,##0")
                txtInteresdelmes.Text = Format(Integer.Parse(reader6(2).ToString), "#,##0")
                txtComisionAnticipoCredito.Text = Format(Integer.Parse(reader6(3).ToString), "#,##0")
            Loop
        Else
        End If

        reader6.Close()

        txtSaldoInsoluto.Text = Format(Integer.Parse(Replace(txtCapitalPrestamo.Text, ".", "")) + Integer.Parse(Replace(txtInteresVencidoNoPagado.Text, ".", "")), "#,##0")

        txtTotalaPagar.Text = Format(Integer.Parse(Replace(txtSaldoInsoluto.Text, ".", "")) + Integer.Parse(Replace(txtInteresdelmes.Text, ".", "")) + Integer.Parse(Replace(txtComisionAnticipoCredito.Text, ".", "")), "#,##0")

    End Sub

    Public Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click

        PRESTAMO = LboxConsumo.SelectedItem
        agregar()
        sumar()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        PRESTAMO = LboxEmergencia.SelectedItem
        agregar()
        sumar()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        PRESTAMO = LBoxAdicional.SelectedItem

        agregar()
        sumar()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        PRESTAMO = LBoxComercial.SelectedItem
        agregar()
        sumar()
    End Sub



    Private Sub Quitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Quitar.Click
        Dim prestamo As String = LboxAgregados.SelectedItem

        If prestamo = "" Then
            MsgBox("Debe Selecionar el prestamo que desee quitar")

        Else
            Dim conexiones5 As New CConexion
            conexiones5.conexion()
            Dim command5 As SqlCommand = New SqlCommand(" update _RIESGO_PREPAGO set estado='NO' where prestamo='" + prestamo + "' AND PERFIL ='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "'", conexiones5._conexion)
            conexiones5.abrir()
            Dim reader5 As SqlDataReader = command5.ExecuteReader()

            reader5.Close()

            LboxAgregados.Items.Clear()

            Dim conexiones8 As New CConexion
            conexiones8.conexion()
            Dim command8 As SqlCommand = New SqlCommand("SELECT [Prestamo] FROM [_RIESGO_PREPAGO] where estado='SI' AND PERFIL ='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "'", conexiones8._conexion)
            conexiones8.abrir()
            Dim reader8 As SqlDataReader = command8.ExecuteReader()

            If reader8.HasRows Then
                Do While reader8.Read()
                    LboxAgregados.Items.Add(reader8(0).ToString)

                Loop
            Else
            End If

            reader8.Close()


            sumar()


        End If



        If (LboxAgregados.Items.Count = 0) Then
            txtMonto.Text = 0
            txtCuotasPrestamos.Text = 0
        End If


    End Sub







    'Private Sub LboxAgregados_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LboxAgregados.SizeChanged
    '    Dim conexiones8 As New CConexion
    '    conexiones8.conexion()
    '    Dim command8 As SqlCommand = New SqlCommand("SELECT sum([Saldo_Capital_Prestamo]+[Interes_Vencido_No_Pagado]+[Intereses_del_mes]+[Comision_por_anticipo_del_credito]) FROM [_RIESGO_PREPAGO] where estado='SI'", conexiones8._conexion)
    '    conexiones8.abrir()
    '    Dim reader8 As SqlDataReader = command8.ExecuteReader()

    '    If reader8.HasRows Then
    '        Do While reader8.Read()
    '            txtMonto.Text = Format(Integer.Parse(reader8(0).ToString), "#,##0")

    '        Loop
    '    Else
    '    End If

    '    reader8.Close()
    'End Sub



    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim conexiones5 As New CConexion
        conexiones5.conexion()
        Dim command5 As SqlCommand = New SqlCommand(" update _RIESGO_PREPAGO set estado='NO' WHERE PERFIL ='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "'", conexiones5._conexion)
        conexiones5.abrir()
        Dim reader5 As SqlDataReader = command5.ExecuteReader()

        reader5.Close()

        LboxAgregados.Items.Clear()

        Dim conexiones8 As New CConexion
        conexiones8.conexion()
        Dim command8 As SqlCommand = New SqlCommand("SELECT [Prestamo] FROM [_RIESGO_PREPAGO] where estado='SI' AND PERFIL ='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "'", conexiones8._conexion)
        conexiones8.abrir()
        Dim reader8 As SqlDataReader = command8.ExecuteReader()

        If reader8.HasRows Then
            Do While reader8.Read()
                LboxAgregados.Items.Add(reader8(0).ToString)

            Loop
        Else
        End If

        reader8.Close()

        txtMonto.Text = 0
        txtCuotasPrestamos.Text = 0
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click


        If (LboxAgregados.Items.Count = 0) Then
            If frmEvaluar.cboRefRen.SelectedItem.ToString.Trim = "SI" Then
                MsgBox("Si el crédito es Renegociación o Refinanciamiento el prepago debe ser mayor a 0")
            Else
                txtMonto.Text = 0
                frmEvaluar.txtPrepago.Text = txtMonto.Text
                cargar()
                Me.Visible = False

            End If

        Else

            If frmEvaluar.cboRefRen.SelectedItem.ToString.Trim = "SI" Then
                frmEvaluar.txtPrepago.Text = txtMonto.Text
                cargar()
                Me.Visible = False
            Else
                MsgBox("Si el crédito es distinto a Renegociación, Refinanciamiento el prepago es igual a 0")
            End If
        End If





    End Sub


    Sub cargar()
        Dim conexiones14 As New CConexion
        conexiones14.conexion()
        conexiones14.abrir()
        Dim cmd14 As New SqlCommand("Riesgo_prestamo_deudas3", conexiones14._conexion)
        cmd14.CommandType = CommandType.StoredProcedure
        Dim prm2 As SqlParameter =
            New SqlParameter("@PERFIL", SqlDbType.NChar, 30)
        cmd14.Parameters.Add(prm2)
        With cmd14
            .Parameters("@PERFIL").Value = frmPerfil.CbmUsuario.SelectedItem
        End With
        Dim dr14 As SqlDataReader = cmd14.ExecuteReader(CommandBehavior.CloseConnection)
        conexiones14.cerrar()

        frmEvaluar.btnPrepago.BackColor = Color.White

    End Sub


    Private Sub frmPrepago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtMonto.Text = 0
    End Sub

    Private Sub LboxAgregados_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LboxAgregados.SelectedIndexChanged
        sumar()
    End Sub

    Private Sub LboxAgregados_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LboxAgregados.SelectedValueChanged
        sumar()
    End Sub

    Private Sub LboxAgregados_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LboxAgregados.TextChanged
        sumar()
    End Sub

    Private Sub LboxAgregados_ForeColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LboxAgregados.ForeColorChanged
        sumar()
    End Sub

    Sub agregar()

        Dim conexiones1 As New CConexion
        conexiones1.conexion()
        conexiones1.abrir()
        Dim cmd1 As New SqlCommand("Riesgo_prepago3_H", conexiones1._conexion)
        cmd1.CommandType = CommandType.StoredProcedure
        Dim prm1 As SqlParameter =
            New SqlParameter("@prestamo", SqlDbType.NChar, 30)
        cmd1.Parameters.Add(prm1)

        Dim prm2 As SqlParameter =
            New SqlParameter("@PERFIL", SqlDbType.NChar, 30)
        cmd1.Parameters.Add(prm2)

        Dim prm3 As SqlParameter =
           New SqlParameter("@nrosocio", SqlDbType.NChar, 30)
        cmd1.Parameters.Add(prm3)

        With cmd1
            .Parameters("@prestamo").Value = PRESTAMO
            .Parameters("@PERFIL").Value = frmPerfil.CbmUsuario.SelectedItem
            .Parameters("@nrosocio").Value = frmEvaluar.txtNrosocio.Text.ToString.Trim
        End With
        Dim dr1 As SqlDataReader = cmd1.ExecuteReader(CommandBehavior.CloseConnection)
        conexiones1.cerrar()


        Dim conexiones6 As New CConexion
        conexiones6.conexion()
        Dim command6 As SqlCommand = New SqlCommand("SELECT * FROM _RIESGO_PREPAGO where prestamo='" + PRESTAMO + "' AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem + "'", conexiones6._conexion)
        conexiones6.abrir()
        Dim reader6 As SqlDataReader = command6.ExecuteReader()

        If reader6.HasRows Then
            Do While reader6.Read()
                txtCapitalPrestamo.Text = Format(Integer.Parse(reader6(0).ToString), "#,##0")
                txtInteresVencidoNoPagado.Text = Format(Integer.Parse(reader6(1).ToString), "#,##0")
                txtInteresdelmes.Text = Format(Integer.Parse(reader6(2).ToString), "#,##0")
                txtComisionAnticipoCredito.Text = Format(Integer.Parse(reader6(3).ToString), "#,##0")
            Loop
        Else
        End If

        reader6.Close()

        txtSaldoInsoluto.Text = Format(Integer.Parse(Replace(txtCapitalPrestamo.Text, ".", "")) + Integer.Parse(Replace(txtInteresVencidoNoPagado.Text, ".", "")), "#,##0")

        txtTotalaPagar.Text = Format(Integer.Parse(Replace(txtSaldoInsoluto.Text, ".", "")) + Integer.Parse(Replace(txtInteresdelmes.Text, ".", "")) + Integer.Parse(Replace(txtComisionAnticipoCredito.Text, ".", "")), "#,##0")

        Dim conexiones5 As New CConexion
        conexiones5.conexion()
        Dim command5 As SqlCommand = New SqlCommand("  update _RIESGO_PREPAGO set estado='SI' where prestamo='" + PRESTAMO + "' AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem + "'", conexiones5._conexion)
        conexiones5.abrir()
        Dim reader5 As SqlDataReader = command5.ExecuteReader()

        reader5.Close()



        LboxAgregados.Items.Clear()

        Dim conexiones8 As New CConexion
        conexiones8.conexion()
        Dim command8 As SqlCommand = New SqlCommand("SELECT [Prestamo] FROM [_RIESGO_PREPAGO] where estado='SI' AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem + "'", conexiones8._conexion)
        conexiones8.abrir()
        Dim reader8 As SqlDataReader = command8.ExecuteReader()

        If reader8.HasRows Then
            Do While reader8.Read()
                LboxAgregados.Items.Add(reader8(0).ToString)

            Loop
        Else
        End If

        reader8.Close()
    End Sub
    Sub sumar()
        Try



            Dim conexiones8 As New CConexion
            conexiones8.conexion()
            Dim command8 As SqlCommand = New SqlCommand("SELECT sum([Saldo_Capital_Prestamo]+[Interes_Vencido_No_Pagado]+[Intereses_del_mes]+[Comision_por_anticipo_del_credito]) FROM [_RIESGO_PREPAGO] where estado='SI' AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem + "'", conexiones8._conexion)
            conexiones8.abrir()
            Dim reader8 As SqlDataReader = command8.ExecuteReader()

            If reader8.HasRows Then
                Do While reader8.Read()
                    txtMonto.Text = Format(Integer.Parse(reader8(0).ToString), "#,##0")

                Loop
            Else
            End If

            reader8.Close()

            frmEvaluar.txtPrepago.Text = txtMonto.Text




            Dim conexiones9 As New CConexion
            conexiones9.conexion()
            Dim command9 As SqlCommand = New SqlCommand("SELECT sum(Cuota_Actual) FROM [_RIESGO_PREPAGO] where estado='SI' AND PERFIL='" + frmPerfil.CbmUsuario.SelectedItem + "'", conexiones9._conexion)
            conexiones9.abrir()
            Dim reader9 As SqlDataReader = command9.ExecuteReader()

            If reader9.HasRows Then
                Do While reader9.Read()
                    txtCuotasPrestamos.Text = Format(Integer.Parse(reader9(0).ToString), "#,##0")

                Loop
            Else
            End If

            reader9.Close()

        Catch ex As Exception

        End Try
    End Sub



    Private Sub LboxConsumo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LboxConsumo.SelectedIndexChanged

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Me.Visible = False
        frmEvaluar.btnPrepago.BackColor = Color.MistyRose
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub txtMonto_TextChanged(sender As Object, e As EventArgs) Handles txtMonto.TextChanged

    End Sub
End Class