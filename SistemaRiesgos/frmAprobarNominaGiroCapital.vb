
Imports System.Data
Imports System.Data.SqlClient
Public Class frmAprobarNominaGiroCapital
    Dim id As String = frmCreditosPorAprobar.txtid.Text

    Dim tomaestado As String = ""
    Dim estadonomina As String = ""
    Dim Aprobacionsubgerencia As String = ""

    Public _TABLA30 As DataTable = New DataTable
    Public _TABLA31 As DataTable = New DataTable

    Public _adaptador As SqlDataAdapter = New SqlDataAdapter
    Dim newcol As DataGridViewColumn = New DataGridViewCheckBoxColumn




    Private Sub frmAprobarNominaGiroCapital_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargadatosSocio()
    End Sub


    Sub crearcolumna()
        newcol.HeaderText = "SELECCION"
        newcol.Name = "Nombrecol"
        newcol.DataPropertyName = "nombre_campo" 'Campo de enlace a datos
        Gridnomina.Columns.Add(newcol)
    End Sub


    Sub sacarcolumna()
        Gridnomina.Columns.Remove(newcol)
    End Sub

    Sub CargadatosSocio()

        _TABLA30.Rows.Clear()
        _TABLA30.Columns.Clear()
        Dim conexiones4 As New CConexion
        conexiones4.conexion()
        _adaptador.SelectCommand = New SqlCommand("SELECT  id_solicitud ,SUBSTRING(FECHA_SOLICITUD,7,8)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4)AS [FECHA_SOLICITUD], [ESTADO_SOLICITUD],convert(varchar(8),[RUT])+'-'+[DVRUT] AS RUT,[NOMBRES],[PATERNO],[MATERNO],[MONTO_SOLICITUD],[BANCO],[TIPO_CUENTA],[NRO_CUENTA],[FORMA_PAGO]FROM [_RIESGO_DETA_NOMINA_TRANSFERENCIA] where nro_nomina = '" + Trim(id) + "'  order by id_solicitud desc ", conexiones4._conexion)
        conexiones4.abrir()
        _adaptador.Fill(_TABLA30)
        Gridnomina.DataSource = _TABLA30
        conexiones4.cerrar()

        Dim conexiones5 As New CConexion
        conexiones5.conexion()
        Dim command5 As SqlCommand = New SqlCommand("SELECT [SUCURSAL],[USUARIO],SUBSTRING(FECHA_NOMINA,7,8)+'/'+SUBSTRING(FECHA_NOMINA,5,2)+'/'+SUBSTRING(FECHA_NOMINA,1,4) AS [FECHA_NOMINA],[NRO_NOMINA],[MONTO_NOMINA] ,ESTADO_NOMINA FROM [_RIESGO_ENCA_NOMINA_TRANSFERENCIA] WHERE NRO_NOMINA='" + Trim(id) + "' ", conexiones5._conexion)
        conexiones5.abrir()
        Dim reader5 As SqlDataReader = command5.ExecuteReader()
        If reader5.HasRows Then
            Do While reader5.Read()


                txtSucursal.Text = reader5(0).ToString
                txtEjecutivo.Text = reader5(1).ToString
                txtFecha.Text = reader5(2).ToString
                txtCodigoId.Text = reader5(3).ToString
                txtMontonomina.Text = frmEvaluarCapital.PuntoX(reader5(4).ToString)
                txtestadonomina.Text = reader5(5).ToString
 
            Loop
        Else
        End If
        reader5.Close()


        crearcolumna()


        CboAprobar.Items.Add("APROBADO")
        CboAprobar.Items.Add("RECHAZADO")




    End Sub






    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim totalfilas As Integer = Gridnomina.RowCount - 1
        ' MsgBox(totalfilas)
        For i = 0 To totalfilas
            Gridnomina.Rows(i).Cells(0).Value() = True
            'MsgBox(Gridnomina.Rows(i).Cells(0).Value())
          
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim totalfilas As Integer = Gridnomina.RowCount - 1
        Dim id_fila As String = ""
        Dim MontoNomina As Integer = 0
        Dim sumanroseleccionados As Integer = 0
        Dim USUARIO As String = ""
        Dim Contrasena As String = ""
        Dim estadonomina As String = ""

        USUARIO = frmPerfil.CbmUsuario.SelectedItem


        If CboAprobar.SelectedItem = "" Then

            MsgBox("Debe selecionar una opción de Aprobación")
        Else
            If txtContrasena.Text = "" Then

                MsgBox("Debe indicar contraseña de seguridad ")

            Else


                Dim conexiones2 As New CConexion
                conexiones2.conexion()
                Dim command2 As SqlCommand = New SqlCommand("SELECT dbo.FU_DESENCRIPTA(ENSUPERCONTRASENA),DEPARTAMENTO FROM _RIESGO_PERFIL WHERE USUARIO='" + USUARIO.ToString.Trim + "'", conexiones2._conexion)
                conexiones2.abrir()

                Dim reader2 As SqlDataReader = command2.ExecuteReader()
                If reader2.HasRows Then
                    Do While reader2.Read()
                        Contrasena = reader2(0).ToString

                    Loop
                Else
                End If
                reader2.Close()


                If Contrasena.ToString.Trim = txtContrasena.Text.Trim Then

                    estadonomina = ""
                    Dim conexiones As New CConexion
                    conexiones.conexion()
                    Dim command As SqlCommand = New SqlCommand("SELECT [APROBACION_SUBGERENTE_FINANZA],[ID_FILA] FROM [_RIESGO_ENCA_NOMINA_TRANSFERENCIA] where nro_nomina = '" + Trim(txtCodigoId.Text.ToString) + "'  ", conexiones._conexion)
                    conexiones.abrir()

                    Dim reader As SqlDataReader = command.ExecuteReader()
                    If reader.HasRows Then
                        Do While reader.Read()
                            estadonomina = reader(0).ToString

                        Loop
                    Else
                    End If
                    reader.Close()

                    If Trim(estadonomina) = "Por Analizar" Or estadonomina = "" Then
                        'id = txtCodigoId.Text.ToString
                        For i = 0 To totalfilas

                            If Gridnomina.Rows(i).Cells(0).Value() = True Then
                                id_fila = Gridnomina.Rows(i).Cells(1).Value()



                                'update [_RIESGO_SOLICITUD_GIRO_CAPITAL] set EN_NOMINA  = 1  where ID_SOLICITUD = ( select id_solicitud from [_RIESGO_DETA_NOMINA_TRANSFERENCIA] where ID_FILA = '" + Trim(id_fila) + "' 


                                If Aprobacionsubgerencia = "SI" Then



                                    Dim conexiones60 As New CConexion
                                    conexiones60.conexion()
                                    _adaptador.UpdateCommand = New SqlCommand("UPDATE  [_RIESGO_DETA_NOMINA_TRANSFERENCIA] set [ESTADO_EN_NOMINA]= 'SELECCIONADO',estado_solicitud='APROBADO'  WHERE id_solicitud ='" + Trim(id_fila) + "'", conexiones60._conexion)
                                    conexiones60.abrir()
                                    _adaptador.UpdateCommand.Connection = conexiones60._conexion
                                    _adaptador.UpdateCommand.ExecuteNonQuery()
                                    conexiones60.cerrar()



                                    Dim conexiones61 As New CConexion
                                    conexiones61.conexion()
                                    _adaptador.UpdateCommand = New SqlCommand("update [_RIESGO_SOLICITUD_GIRO_CAPITAL] set EN_NOMINA  = 1, estado_solicitud='APROBADO'  where ID_solicitud  = '" + Trim(id_fila) + "'", conexiones61._conexion)
                                    conexiones61.abrir()
                                    _adaptador.UpdateCommand.Connection = conexiones61._conexion
                                    _adaptador.UpdateCommand.ExecuteNonQuery()
                                    conexiones61.cerrar()



                                    'estadonomina = "APROBADA"
                                    MontoNomina = MontoNomina + CInt(Gridnomina.Rows(i).Cells(8).Value())



                                ElseIf Aprobacionsubgerencia = "NO" Then


                                    Dim conexiones60 As New CConexion
                                    conexiones60.conexion()
                                    _adaptador.UpdateCommand = New SqlCommand("UPDATE  [_RIESGO_DETA_NOMINA_TRANSFERENCIA] set [ESTADO_EN_NOMINA]= 'SELECCIONADO',estado_solicitud='PREAPROBADO'  WHERE ID_solicitud ='" + Trim(id_fila) + "'", conexiones60._conexion)
                                    conexiones60.abrir()
                                    _adaptador.UpdateCommand.Connection = conexiones60._conexion
                                    _adaptador.UpdateCommand.ExecuteNonQuery()
                                    conexiones60.cerrar()


                                    Dim conexiones61 As New CConexion
                                    conexiones61.conexion()
                                    _adaptador.UpdateCommand = New SqlCommand("update [_RIESGO_SOLICITUD_GIRO_CAPITAL] set EN_NOMINA  = 0, estado_solicitud='PREAPROBADO'  where ID_SOLICITUD  = '" + Trim(id_fila) + "'", conexiones61._conexion)
                                    conexiones61.abrir()
                                    _adaptador.UpdateCommand.Connection = conexiones61._conexion
                                    _adaptador.UpdateCommand.ExecuteNonQuery()
                                    conexiones61.cerrar()
                                    'estadonomina = "RECHAZADA"
                                    MontoNomina = MontoNomina + CInt(Gridnomina.Rows(i).Cells(8).Value())



                                End If

                                sumanroseleccionados = sumanroseleccionados + 1




                            ElseIf Gridnomina.Rows(i).Cells(0).Value() = False Or Gridnomina.Rows(i).Cells(0).Value() <> False And Gridnomina.Rows(i).Cells(0).Value() <> True Then
                                id_fila = Gridnomina.Rows(i).Cells(1).Value()


                                If Aprobacionsubgerencia = "SI" Then

                                    Dim conexiones60 As New CConexion
                                    conexiones60.conexion()
                                    _adaptador.UpdateCommand = New SqlCommand("UPDATE  [_RIESGO_DETA_NOMINA_TRANSFERENCIA] set [ESTADO_EN_NOMINA]= 'NO SELECCIONADO' ,estado_solicitud='PREAPROBADO'  WHERE ID_solicitud  ='" + Trim(id_fila) + "'", conexiones60._conexion)
                                    conexiones60.abrir()
                                    _adaptador.UpdateCommand.Connection = conexiones60._conexion
                                    _adaptador.UpdateCommand.ExecuteNonQuery()
                                    conexiones60.cerrar()


                                    Dim conexiones61 As New CConexion
                                    conexiones61.conexion()
                                    _adaptador.UpdateCommand = New SqlCommand("update [_RIESGO_SOLICITUD_GIRO_CAPITAL] set EN_NOMINA  = 0 ,estado_solicitud='PREAPROBADO' where ID_SOLICITUD ='" + Trim(id_fila) + "'", conexiones61._conexion)
                                    conexiones61.abrir()
                                    _adaptador.UpdateCommand.Connection = conexiones61._conexion
                                    _adaptador.UpdateCommand.ExecuteNonQuery()
                                    conexiones61.cerrar()

                                ElseIf Aprobacionsubgerencia = "NO" Then


                                    Dim conexiones60 As New CConexion
                                    conexiones60.conexion()
                                    _adaptador.UpdateCommand = New SqlCommand("UPDATE  [_RIESGO_DETA_NOMINA_TRANSFERENCIA] set [ESTADO_EN_NOMINA]= 'NO SELECCIONADO' ,estado_solicitud='PREAPROBADO'  WHERE id_solicitud ='" + Trim(id_fila) + "'", conexiones60._conexion)
                                    conexiones60.abrir()
                                    _adaptador.UpdateCommand.Connection = conexiones60._conexion
                                    _adaptador.UpdateCommand.ExecuteNonQuery()
                                    conexiones60.cerrar()


                                    Dim conexiones61 As New CConexion
                                    conexiones61.conexion()
                                    _adaptador.UpdateCommand = New SqlCommand("update [_RIESGO_SOLICITUD_GIRO_CAPITAL] set EN_NOMINA  = 0 ,estado_solicitud='PREAPROBADO' where ID_SOLICITUD =  '" + Trim(id_fila) + "'", conexiones61._conexion)
                                    conexiones61.abrir()
                                    _adaptador.UpdateCommand.Connection = conexiones61._conexion
                                    _adaptador.UpdateCommand.ExecuteNonQuery()
                                    conexiones61.cerrar()

                                End If
                            End If

                            'MsgBox(Gridnomina.Rows(i).Cells(0).Value())
                        Next

                        If sumanroseleccionados > 0 Then

                            If Aprobacionsubgerencia = "SI" Then
                                estadonomina = "APROBADA"
                            ElseIf Aprobacionsubgerencia = "NO" Then
                                estadonomina = "RECHAZADA"
                            End If


                            Dim conexiones6 As New CConexion
                            conexiones6.conexion()
                            _adaptador.UpdateCommand = New SqlCommand("  UPDATE [_RIESGO_ENCA_NOMINA_TRANSFERENCIA] SET ESTADO_NOMINA='" + Trim(estadonomina.ToString) + "' ,MONTO_NOMINA='" + (MontoNomina.ToString) + "' , APROBACION_SUBGERENTE_FINANZA='" + Trim(Aprobacionsubgerencia.ToString) + "' WHERE NRO_NOMINA ='" + Trim(txtCodigoId.Text.ToString) + "'", conexiones6._conexion)
                            conexiones6.abrir()
                            _adaptador.UpdateCommand.Connection = conexiones6._conexion
                            _adaptador.UpdateCommand.ExecuteNonQuery()
                            conexiones6.cerrar()


                            'If estadonomina = "APROBADA" Then
                            '    '_TABLA30.Rows.Clear()
                            '    '_TABLA30.Columns.Clear()
                            '    'Dim conexiones4 As New CConexion
                            '    'conexiones4.conexion()
                            '    '_adaptador.SelectCommand = New SqlCommand("SELECT GIRO.ID_SOLICITUD FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL] AS GIRO  INNER JOIN [_RIESGO_DETA_NOMINA_TRANSFERENCIA] AS DETA   ON GIRO.ID_SOLICITUD =DETA.ID_SOLICITUD  INNER JOIN [_RIESGO_ENCA_NOMINA_TRANSFERENCIA] AS ENCA  ON DETA.NRO_NOMINA =ENCA.NRO_NOMINA WHERE DETA.NRO_NOMINA = '" + txtCodigoId.Text.ToString + "' AND DETA.ESTADO_EN_NOMINA='SELECCIONADO' ", conexiones4._conexion)
                            '    'conexiones4.abrir()
                            '    '_adaptador.Fill(_TABLA30)
                            '    'Gridemergencia.DataSource = _TABLA30
                            '    'conexiones4.cerrar()
                            '    Dim totalfilass As Integer = Gridemergencia.Rows.Count - 1
                            '    Dim tomavalorgrilla As String = ""
                            '    MsgBox(totalfilass)
                            '    For z = 0 To totalfilass
                            '        tomavalorgrilla = Gridemergencia.Rows(z).Cells(0).Value()
                            '        '' MsgBox("pasa  en nomina")
                            '        'Dim conexiones61 As New CConexion
                            '        'conexiones61.conexion()
                            '        '_adaptador.UpdateCommand = New SqlCommand("update [_RIESGO_SOLICITUD_GIRO_CAPITAL] set EN_NOMINA  = 1 ,estado_solicitud='APROBADO'  where ID_SOLICITUD =  '" + tomavalorgrilla + "'", conexiones61._conexion)
                            '        'conexiones61.abrir()
                            '        '_adaptador.UpdateCommand.Connection = conexiones61._conexion
                            '        '_adaptador.UpdateCommand.ExecuteNonQuery()
                            '        'conexiones61.cerrar()
                            '        'Dim conexiones99 As New CConexion
                            '        'conexiones99.conexion()
                            '        '_adaptador.UpdateCommand = New SqlCommand("  UPDATE [_RIESGO_DETA_NOMINA_TRANSFERENCIA] SET ESTADO_SOLICITUD='APROBADO'  WHERE NRO_NOMINA = '" + Trim(txtCodigoId.Text.ToString) + "' AND  ID_FILA ='" + Trim(txtCodigoId.Text.ToString) + "'", conexiones99._conexion)
                            '        'conexiones99.abrir()
                            '        '_adaptador.UpdateCommand.Connection = conexiones99._conexion
                            '        '_adaptador.UpdateCommand.ExecuteNonQuery()
                            '        'conexiones99.cerrar()
                            '    Next
                            'ElseIf estadonomina = "RECHAZADA" Then
                            '    ' MsgBox("ENTRO EN RECHAZO")
                            '    _TABLA30.Rows.Clear()
                            '    _TABLA30.Columns.Clear()
                            '    Dim conexiones4 As New CConexion
                            '    conexiones4.conexion()
                            '    _adaptador.SelectCommand = New SqlCommand("SELECT GIRO.ID_SOLICITUD FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL] AS GIRO  INNER JOIN [_RIESGO_DETA_NOMINA_TRANSFERENCIA] AS DETA   ON GIRO.ID_SOLICITUD =DETA.ID_SOLICITUD  INNER JOIN [_RIESGO_ENCA_NOMINA_TRANSFERENCIA] AS ENCA  ON DETA.NRO_NOMINA =ENCA.NRO_NOMINA WHERE DETA.NRO_NOMINA = '" + txtCodigoId.Text.ToString + "' AND DETA.ESTADO_EN_NOMINA='NO SELECCIONADO", conexiones4._conexion)
                            '    conexiones4.abrir()
                            '    _adaptador.Fill(_TABLA30)
                            '    Gridemergencia.DataSource = _TABLA30
                            '    conexiones4.cerrar()
                            '    Dim totalfilass As Integer = Gridemergencia.Rows.Count - 1
                            '    Dim tomavalorgrilla As String = ""
                            '    ' MsgBox(totalfilass)
                            '    For z = 0 To totalfilass
                            '        tomavalorgrilla = Gridemergencia.Rows(z).Cells(0).Value()
                            '        Dim conexiones61 As New CConexion
                            '        conexiones61.conexion()
                            '        _adaptador.UpdateCommand = New SqlCommand("update [_RIESGO_SOLICITUD_GIRO_CAPITAL] set EN_NOMINA  = 0  where ID_SOLICITUD =  '" + tomavalorgrilla + "'", conexiones61._conexion)
                            '        conexiones61.abrir()
                            '        _adaptador.UpdateCommand.Connection = conexiones61._conexion
                            '        _adaptador.UpdateCommand.ExecuteNonQuery()
                            '        conexiones61.cerrar()
                            '    Next
                            'End If






                            MsgBox("NOMINA SUPERVISADA CON EXITO")


                        Else
                            MsgBox("NO SELECCIONO NINGUNA TRANSFERENCIA DE LA NOMINA ")
                        End If


                        Dim plantillas2 As Metodos = New Metodos
                        Dim tabla As New DataTable

                        plantillas2._tabla.Rows.Clear()
                        plantillas2._tabla.Columns.Clear()

                        If plantillas2.Consultar_Creditos_Aprobar_Con_Nomina_Transferencia Then
                            tabla = plantillas2.tabla
                            frmCreditosPorAprobar.DGreditosAprobar.DataSource = tabla
                        End If
                        Me.Close()


                    Else
                        MsgBox("ESTA NOMINA  YA FUE ANALIZADA")
                        frmCreditosPorAprobar.CheckBox1.Checked = False
                            Me.Close()

                        End If

                Else

                    MsgBox("CONTRASEÑA INCORRECTA")
                End If

            End If
        End If
































      


     










    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Dim totalfilas As Integer = Gridnomina.RowCount - 1
        '' MsgBox(totalfilas)
        'For i = 0 To totalfilas

        '    'MsgBox(Gridnomina.Rows(i).Cells(0).Value())

        'Next
        frmCreditosPorAprobar.CheckBox1.Checked = False
        Me.Close()

    End Sub

    Private Sub CboAprobar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAprobar.SelectedIndexChanged
        Aprobacionsubgerencia = ""

        tomaestado = CboAprobar.SelectedItem



        If CboAprobar.SelectedItem = "APROBADO" Then

            Aprobacionsubgerencia = "SI"
        ElseIf CboAprobar.SelectedItem = "RECHAZADO" Then

            Aprobacionsubgerencia = "NO"
        End If


    End Sub

    Private Sub txtFecha_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecha.TextChanged

    End Sub
End Class