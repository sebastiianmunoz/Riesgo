Imports System.Data
Imports System.Data.SqlClient
Public Class FrmGestionPerfil
    Dim plantillas As CCEstadosGeneral = New CCEstadosGeneral
    Dim plantillas2 As Metodos = New Metodos

    Dim tabla As New DataTable
    Dim Datos As New CDatos
    Dim permiso As String
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter


    'ACTUALIZA  DEPENDIENDO DE LA SUCURSAL  LA CAJA A LA QUE CORRESPONDE 
   




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim texto As String = ""
        Dim i As Integer
        For i = 0 To ListPerfil.Items.Count - 1
            Dim adicional As String = ""
            If ListPerfil.GetItemChecked(i) = True Then
                adicional = "1"
            Else
                adicional = "0"
            End If
            texto = texto + adicional
        Next

        Datos._Perfil = txtCod.Text
        Datos._enpermisos = texto

        'MsgBox(Datos._Perfil)
        'MsgBox(datos._enpermisos)

        If plantillas.Actualizar_permisos(Datos) Then
            MsgBox("Permisos Actualizados")
            '  SUCURSALCAJA()
            cargar()

        Else
            MessageBox.Show("Error al consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If







    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click


        'Evaluar		/ Personas
        ListPerfil.SetItemCheckState(0, CheckState.Unchecked)
        'Evaluar        	/ Empresas
        ListPerfil.SetItemCheckState(1, CheckState.Unchecked)
        'Estados      	/ Riesgo
        ListPerfil.SetItemCheckState(2, CheckState.Unchecked)
        'Estados     	/ Por Aprobar
        ListPerfil.SetItemCheckState(3, CheckState.Unchecked)
        'Estados		/ Mis Prestamos
        ListPerfil.SetItemCheckState(4, CheckState.Unchecked)
        'Estados		/ Historico
        ListPerfil.SetItemCheckState(5, CheckState.Unchecked)
        'Auditoria	/ Puntajes
        ListPerfil.SetItemCheckState(6, CheckState.Unchecked)
        'Estadisticas	/ Ejecutivos
        ListPerfil.SetItemCheckState(7, CheckState.Unchecked)
        'Estadisticas	/ Prestamos
        ListPerfil.SetItemCheckState(8, CheckState.Unchecked)
        'Perfil		/ Gestor
        ListPerfil.SetItemCheckState(9, CheckState.Unchecked)

        'GIROS DE CAPITLA 
        ListPerfil.SetItemCheckState(10, CheckState.Unchecked)
        ListPerfil.SetItemCheckState(11, CheckState.Unchecked)
        ListPerfil.SetItemCheckState(12, CheckState.Unchecked)
        ListPerfil.SetItemCheckState(13, CheckState.Unchecked)
        ListPerfil.SetItemCheckState(14, CheckState.Unchecked)

        'OTROS / CAPTACIONES
        ListPerfil.SetItemCheckState(15, CheckState.Unchecked)

        'OTROS / TXTCAPTACIONES
        ListPerfil.SetItemCheckState(16, CheckState.Unchecked)





        If CboTipo.SelectedItem = "Administrador" Then

            'Evaluar		/ Personas 1111111111
            ListPerfil.SetItemCheckState(0, CheckState.Checked)
            'Evaluar        	/ Empresas
            ListPerfil.SetItemCheckState(1, CheckState.Checked)
            'Estados      	/ Riesgo
            ListPerfil.SetItemCheckState(2, CheckState.Checked)
            'Estados     	/ Por Aprobar
            ListPerfil.SetItemCheckState(3, CheckState.Checked)
            'Estados		/ Mis Prestamos
            ListPerfil.SetItemCheckState(4, CheckState.Checked)
            'Estados		/ Historico
            ListPerfil.SetItemCheckState(5, CheckState.Checked)
            'Auditoria	/ Puntajes
            ListPerfil.SetItemCheckState(6, CheckState.Checked)
            'Estadisticas	/ Ejecutivos
            ListPerfil.SetItemCheckState(7, CheckState.Checked)
            'Estadisticas	/ Prestamos
            ListPerfil.SetItemCheckState(8, CheckState.Checked)
            'Perfil		/ Gestor
            ListPerfil.SetItemCheckState(9, CheckState.Checked)

            'GIROS DE CAPITLA 
            ListPerfil.SetItemCheckState(10, CheckState.Checked)
            ListPerfil.SetItemCheckState(11, CheckState.Checked)
            ListPerfil.SetItemCheckState(12, CheckState.Checked)
            ListPerfil.SetItemCheckState(13, CheckState.Checked)
            ListPerfil.SetItemCheckState(14, CheckState.Checked)

            'OTROS / CAPTACIONES
            ListPerfil.SetItemCheckState(15, CheckState.Checked)

            'OTROS / TXTCAPTACIONES
            ListPerfil.SetItemCheckState(16, CheckState.Checked)








        ElseIf CboTipo.SelectedItem = "SubAdministrador" Then
            'Evaluar		/ Personas 1000011001
            ListPerfil.SetItemCheckState(0, CheckState.Checked)
            'Estados		/ Historico
            ListPerfil.SetItemCheckState(5, CheckState.Checked)
            'Auditoria	/ Puntajes
            ListPerfil.SetItemCheckState(6, CheckState.Checked)
            'Perfil		/ Gestor
            ListPerfil.SetItemCheckState(9, CheckState.Checked)




        ElseIf CboTipo.SelectedItem = "Ejecutivo" Then
            'Evaluar		/ Personas 
            ListPerfil.SetItemCheckState(0, CheckState.Checked)
            'Evaluar        	/ Empresas
            ListPerfil.SetItemCheckState(1, CheckState.Unchecked)
            'Estados      	/ Riesgo
            ListPerfil.SetItemCheckState(2, CheckState.Unchecked)
            'Estados     	/ Por Aprobar
            ListPerfil.SetItemCheckState(3, CheckState.Unchecked)
            'Estados		/ Mis Prestamos
            ListPerfil.SetItemCheckState(4, CheckState.Checked)
            'Estados		/ Historico
            ListPerfil.SetItemCheckState(5, CheckState.Unchecked)
            'Auditoria	/ Puntajes
            ListPerfil.SetItemCheckState(6, CheckState.Unchecked)
            'Estadisticas	/ Ejecutivos
            ListPerfil.SetItemCheckState(7, CheckState.Unchecked)
            'Estadisticas	/ Prestamos
            ListPerfil.SetItemCheckState(8, CheckState.Unchecked)
            'Perfil		/ Gestor
            ListPerfil.SetItemCheckState(9, CheckState.Unchecked)

            ' GIROS DE CAPITLA 
            ListPerfil.SetItemCheckState(10, CheckState.Unchecked)
            ListPerfil.SetItemCheckState(11, CheckState.Unchecked)
            ListPerfil.SetItemCheckState(12, CheckState.Unchecked)
            ListPerfil.SetItemCheckState(13, CheckState.Unchecked)
            ListPerfil.SetItemCheckState(14, CheckState.Unchecked)

            'OTROS /CAPTACIONES
            ListPerfil.SetItemCheckState(15, CheckState.Unchecked)

            'OTROS /TXTCAPTACIONES
            ListPerfil.SetItemCheckState(16, CheckState.Unchecked)



        ElseIf CboTipo.SelectedItem = "Evaluador" Then
            'Evaluar		/ Personas
            ListPerfil.SetItemCheckState(0, CheckState.Unchecked)
            'Evaluar        	/ Empresas
            ListPerfil.SetItemCheckState(1, CheckState.Unchecked)
            'Estados      	/ Riesgo
            ListPerfil.SetItemCheckState(2, CheckState.Unchecked)
            'Estados     	/ Por Aprobar
            ListPerfil.SetItemCheckState(3, CheckState.Checked)
            'Estados		/ Mis Prestamos
            ListPerfil.SetItemCheckState(4, CheckState.Unchecked)
            'Estados		/ Historico
            ListPerfil.SetItemCheckState(5, CheckState.Checked)
            'Auditoria	/ Puntajes
            ListPerfil.SetItemCheckState(6, CheckState.Unchecked)
            'Estadisticas	/ Ejecutivos
            ListPerfil.SetItemCheckState(7, CheckState.Unchecked)
            'Estadisticas	/ Prestamos
            ListPerfil.SetItemCheckState(8, CheckState.Unchecked)
            'Perfil		/ Gestor
            ListPerfil.SetItemCheckState(9, CheckState.Unchecked)
            'GIROS DE CAPITLA 
            ListPerfil.SetItemCheckState(10, CheckState.Unchecked)
            ListPerfil.SetItemCheckState(11, CheckState.Unchecked)
            ListPerfil.SetItemCheckState(12, CheckState.Unchecked)
            ListPerfil.SetItemCheckState(13, CheckState.Unchecked)
            ListPerfil.SetItemCheckState(14, CheckState.Unchecked)

            'OTROS /CAPTACIONES
            ListPerfil.SetItemCheckState(15, CheckState.Unchecked)

            'OTROS /TXTCAPTACIONES
            ListPerfil.SetItemCheckState(16, CheckState.Unchecked)



        ElseIf CboTipo.SelectedItem = "Riesgo nivel 1" Then
            'Evaluar		/ Personas
            ListPerfil.SetItemCheckState(0, CheckState.Unchecked)
            'Evaluar        	/ Empresas
            ListPerfil.SetItemCheckState(1, CheckState.Unchecked)
            'Estados      	/ Riesgo
            ListPerfil.SetItemCheckState(2, CheckState.Checked)
            'Estados     	/ Por Aprobar
            ListPerfil.SetItemCheckState(3, CheckState.Unchecked)
            'Estados		/ Mis Prestamos
            ListPerfil.SetItemCheckState(4, CheckState.Unchecked)
            'Estados		/ Historico
            ListPerfil.SetItemCheckState(5, CheckState.Checked)
            'Auditoria	/ Puntajes
            ListPerfil.SetItemCheckState(6, CheckState.Checked)
            'Estadisticas	/ Ejecutivos
            ListPerfil.SetItemCheckState(7, CheckState.Unchecked)
            'Estadisticas	/ Prestamos
            ListPerfil.SetItemCheckState(8, CheckState.Unchecked)
            'Perfil		/ Gestor
            ListPerfil.SetItemCheckState(9, CheckState.Unchecked)

            'GIROS DE CAPITLA 
            ListPerfil.SetItemCheckState(10, CheckState.Unchecked)
            ListPerfil.SetItemCheckState(11, CheckState.Unchecked)
            ListPerfil.SetItemCheckState(12, CheckState.Unchecked)
            ListPerfil.SetItemCheckState(13, CheckState.Unchecked)
            ListPerfil.SetItemCheckState(14, CheckState.Unchecked)

            'OTROS /CAPTACIONES
            ListPerfil.SetItemCheckState(15, CheckState.Unchecked)

            'OTROS /TXTCAPTACIONES
            ListPerfil.SetItemCheckState(16, CheckState.Unchecked)



        ElseIf CboTipo.SelectedItem = "Riesgo nivel 2" Then
            'Evaluar		/ Personas
            ListPerfil.SetItemCheckState(0, CheckState.Unchecked)
            'Evaluar        	/ Empresas
            ListPerfil.SetItemCheckState(1, CheckState.Unchecked)
            'Estados      	/ Riesgo
            ListPerfil.SetItemCheckState(2, CheckState.Checked)
            'Estados     	/ Por Aprobar
            ListPerfil.SetItemCheckState(3, CheckState.Unchecked)
            'Estados		/ Mis Prestamos
            ListPerfil.SetItemCheckState(4, CheckState.Unchecked)
            'Estados		/ Historico
            ListPerfil.SetItemCheckState(5, CheckState.Checked)
            'Auditoria	/ Puntajes
            ListPerfil.SetItemCheckState(6, CheckState.Unchecked)
            'Estadisticas	/ Ejecutivos
            ListPerfil.SetItemCheckState(7, CheckState.Unchecked)
            'Estadisticas	/ Prestamos
            ListPerfil.SetItemCheckState(8, CheckState.Unchecked)
            'Perfil		/ Gestor
            ListPerfil.SetItemCheckState(9, CheckState.Unchecked)


            'GIROS DE CAPITLA ------
            ListPerfil.SetItemCheckState(10, CheckState.Unchecked)
            ListPerfil.SetItemCheckState(11, CheckState.Unchecked)
            ListPerfil.SetItemCheckState(12, CheckState.Unchecked)
            ListPerfil.SetItemCheckState(13, CheckState.Unchecked)
            ListPerfil.SetItemCheckState(14, CheckState.Unchecked)

            'OTROS /CAPTACIONES
            ListPerfil.SetItemCheckState(15, CheckState.Unchecked)

            'OTROS /TXTCAPTACIONES
            ListPerfil.SetItemCheckState(16, CheckState.Unchecked)

        End If


    End Sub


    Private Sub FrmGestionPerfil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
        cargar()

    End Sub

    Sub cargar()
        'DGUsuarios.Rows.Clear()


        cboSucursal.Items.Clear()
        Dim conexiones5 As New CConexion
        conexiones5.conexion()
        Dim command5 As SqlCommand = New SqlCommand("SELECT RTRIM([CIUDAD])+' - '+RTRIM([NOMBRECAJA])  FROM [_SUCURSAL]  WHERE VIGENTE=1 ORDER BY CIUDAD , NOMBRECAJA DESC", conexiones5._conexion)
        conexiones5.abrir()
        Dim reader5 As SqlDataReader = command5.ExecuteReader()

        If reader5.HasRows Then
            Do While reader5.Read()

                cboSucursal.Items.Add(reader5(0).ToString)
            Loop
        Else
        End If

        reader5.Close()





        tabla.Clear()
        plantillas2._tabla.Rows.Clear()
        plantillas2._tabla.Columns.Clear()
        If plantillas2.Consultar_Perfiles Then
            tabla = plantillas2.tabla
            DGUsuarios.DataSource = tabla
        End If


    End Sub

    Private Sub DGUsuarios_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGUsuarios.SelectionChanged

        Try
            txtCod.Text = ""
            txtNombre.Text = ""
            txtUsuario.Text = ""
            'txtDepartamento.Text = ""
            'TxtSucursal.Text = ""
            'txtCargo.Text = ""
            txtCod.Text = DGUsuarios.Rows(DGUsuarios.CurrentRow.Index).Cells(0).Value
            txtNombre.Text = DGUsuarios.Rows(DGUsuarios.CurrentRow.Index).Cells(1).Value
            txtUsuario.Text = DGUsuarios.Rows(DGUsuarios.CurrentRow.Index).Cells(2).Value
            'txtDepartamento.Text = DGUsuarios.Rows(DGUsuarios.CurrentRow.Index).Cells(3).Value

            cboSucursal.SelectedItem = Trim(DGUsuarios.Rows(DGUsuarios.CurrentRow.Index).Cells(5).Value.ToString)
            cboAtributo.SelectedItem = Trim(DGUsuarios.Rows(DGUsuarios.CurrentRow.Index).Cells(6).Value.ToString)

            cboDepartamento.SelectedItem = Trim(DGUsuarios.Rows(DGUsuarios.CurrentRow.Index).Cells(3).Value.ToString)

            Dim conexiones4 As New CConexion
            conexiones4.conexion()
            Dim command4 As SqlCommand = New SqlCommand("  SELECT CODCAJA  FROM [_SUCURSAL] WHERE RTRIM([CIUDAD])+' - '+RTRIM([NOMBRECAJA])='" + cboSucursal.SelectedItem.ToString.Trim + "'", conexiones4._conexion)
            conexiones4.abrir()
            Dim reader4 As SqlDataReader = command4.ExecuteReader()

            If reader4.HasRows Then
                Do While reader4.Read()

                    Datos._Sucursal = (reader4(0).ToString)
                Loop
            Else
            End If

            reader4.Close()




            'TxtSucursal.Text = DGUsuarios.Rows(DGUsuarios.CurrentRow.Index).Cells(5).Value
            'txtCargo.Text = DGUsuarios.Rows(DGUsuarios.CurrentRow.Index).Cells(6).Value
            If DGUsuarios.Rows(DGUsuarios.CurrentRow.Index).Cells(8).Value.ToString = "" Then
                permiso = "00000000000000000"
            Else
                permiso = DGUsuarios.Rows(DGUsuarios.CurrentRow.Index).Cells(8).Value
            End If

            'Evaluar		/ Personas
            If permiso.Substring(0, 1) = "1" Then
                ListPerfil.SetItemCheckState(0, CheckState.Checked)
            Else
                ListPerfil.SetItemCheckState(0, CheckState.Unchecked)
            End If

            'Evaluar        	/ Empresas
            If permiso.Substring(1, 1) = "1" Then
                ListPerfil.SetItemCheckState(1, CheckState.Checked)
            Else
                ListPerfil.SetItemCheckState(1, CheckState.Unchecked)
            End If

            'Estados      	/ Riesgo
            If permiso.Substring(2, 1) = "1" Then
                ListPerfil.SetItemCheckState(2, CheckState.Checked)
            Else
                ListPerfil.SetItemCheckState(2, CheckState.Unchecked)
            End If

            'Estados     	/ Por Aprobar
            If permiso.Substring(3, 1) = "1" Then
                ListPerfil.SetItemCheckState(3, CheckState.Checked)
            Else
                ListPerfil.SetItemCheckState(3, CheckState.Unchecked)
            End If


            'Estados		/ Mis Prestamos
            If permiso.Substring(4, 1) = "1" Then
                ListPerfil.SetItemCheckState(4, CheckState.Checked)
            Else
                ListPerfil.SetItemCheckState(4, CheckState.Unchecked)
            End If

            'Estados		/ Historico
            If permiso.Substring(5, 1) = "1" Then
                ListPerfil.SetItemCheckState(5, CheckState.Checked)
            Else
                ListPerfil.SetItemCheckState(5, CheckState.Unchecked)
            End If

            'Auditoria	/ Puntajes
            If permiso.Substring(6, 1) = "1" Then
                ListPerfil.SetItemCheckState(6, CheckState.Checked)
            Else
                ListPerfil.SetItemCheckState(6, CheckState.Unchecked)
            End If

            'Estadisticas	/ Ejecutivos
            If permiso.Substring(7, 1) = "1" Then
                ListPerfil.SetItemCheckState(7, CheckState.Checked)
            Else
                ListPerfil.SetItemCheckState(7, CheckState.Unchecked)
            End If


            'Estadisticas	/ Prestamos
            If permiso.Substring(8, 1) = "1" Then
                ListPerfil.SetItemCheckState(8, CheckState.Checked)
            Else
                ListPerfil.SetItemCheckState(8, CheckState.Unchecked)
            End If

            'Perfil		/ Gestor
            If permiso.Substring(9, 1) = "1" Then
                ListPerfil.SetItemCheckState(9, CheckState.Checked)
            Else
                ListPerfil.SetItemCheckState(9, CheckState.Unchecked)
            End If
            '****************************************************************************************************
            'GIROS DE CAPITAL  EVALUAR 
            If permiso.Substring(10, 1) = "1" Then
                ListPerfil.SetItemCheckState(10, CheckState.Checked)
            Else
                ListPerfil.SetItemCheckState(10, CheckState.Unchecked)
            End If

            ' BANDEJA MARCELA TRNASFERENCIAS 
            If permiso.Substring(11, 1) = "1" Then
                ListPerfil.SetItemCheckState(11, CheckState.Checked)
            Else
                ListPerfil.SetItemCheckState(11, CheckState.Unchecked)
            End If

            'SOLICITUDES DE GIROS DE CAPITLA PENDIENTES 

            If permiso.Substring(12, 1) = "1" Then
                ListPerfil.SetItemCheckState(12, CheckState.Checked)
            Else
                ListPerfil.SetItemCheckState(12, CheckState.Unchecked)
            End If

            ' DISPONIBILIDA DE CAPITLA SOCIAL 
            If permiso.Substring(13, 1) = "1" Then
                ListPerfil.SetItemCheckState(13, CheckState.Checked)
            Else
                ListPerfil.SetItemCheckState(13, CheckState.Unchecked)
            End If


            If permiso.Substring(14, 1) = "1" Then
                ListPerfil.SetItemCheckState(14, CheckState.Checked)
            Else
                ListPerfil.SetItemCheckState(14, CheckState.Unchecked)
            End If


            'OTROS /CAPTACIONES

            If permiso.Substring(15, 1) = "1" Then
                ListPerfil.SetItemCheckState(15, CheckState.Checked)
            Else
                ListPerfil.SetItemCheckState(15, CheckState.Unchecked)

            End If

            'OTROS /TXTCAPTACIONES

            If permiso.Substring(16, 1) = "1" Then
                ListPerfil.SetItemCheckState(16, CheckState.Checked)
            Else
                ListPerfil.SetItemCheckState(16, CheckState.Unchecked)

            End If




            '*****************************************************************************************************

            'End If


            If (permiso = "11111111111111111") Then
                CboTipo.SelectedItem = "Administrador"
            ElseIf (permiso = "00100110000000000") Then
                CboTipo.SelectedItem = "Riesgo nivel 1"
            ElseIf (permiso = "10001000000000000") Then
                CboTipo.SelectedItem = "Ejecutivo"
            ElseIf (permiso = "00010100000000000") Then
                CboTipo.SelectedItem = "Evaluador"
            ElseIf (permiso = "00100100000000000") Then
                CboTipo.SelectedItem = "Riesgo nivel 2"
            ElseIf (permiso = "10000110010000000") Then
                CboTipo.SelectedItem = "SubAdministrador"
            Else
                CboTipo.SelectedItem = "Personalizado"
            End If


            'If (permiso = "1111111111") Then
            '    CboTipo.SelectedItem = "Administrador"
            'ElseIf (permiso = "0010011000") Then
            '    CboTipo.SelectedItem = "Riesgo nivel 1"
            'ElseIf (permiso = "1000100000") Then
            '    CboTipo.SelectedItem = "Ejecutivo"
            'ElseIf (permiso = "0001010000") Then
            '    CboTipo.SelectedItem = "Evaluador"
            'ElseIf (permiso = "0010010000") Then
            '    CboTipo.SelectedItem = "Riesgo nivel 2"
            'ElseIf (permiso = "1000011001") Then
            '    CboTipo.SelectedItem = "SubAdministrador"
            'Else
            '    CboTipo.SelectedItem = "Personalizado"
            'End If




        Catch ex As Exception

        End Try
        'Catch ex As Exception

        'End Try
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


   


        Datos._perfil_NOMBRE = txtNombre.Text
        Datos._perfil_USUARIO = txtUsuario.Text
        Datos._perfil_DEPARTAMENTO = cboDepartamento.SelectedItem.ToString


        Dim conexiones4 As New CConexion
        conexiones4.conexion()
        Dim command4 As SqlCommand = New SqlCommand("  SELECT CODCAJA  FROM [_SUCURSAL] WHERE RTRIM([CIUDAD])+' - '+RTRIM([NOMBRECAJA])='" + cboSucursal.SelectedItem.ToString.Trim + "'", conexiones4._conexion)
        conexiones4.abrir()
        Dim reader4 As SqlDataReader = command4.ExecuteReader()

        If reader4.HasRows Then
            Do While reader4.Read()

                Datos._perfil_SUCURSAL = (reader4(0).ToString)
            Loop
        Else
        End If

        reader4.Close()


        Datos._perfil_CARGO = cboAtributo.SelectedItem.ToString


        If (cboAtributo.SelectedItem = "RIESGO") Then
            Datos._perfil_ATRIBUTO = "0"
        ElseIf (cboAtributo.SelectedItem = "SUBGERENTE") Then
            Datos._perfil_ATRIBUTO = "2"
        ElseIf (cboAtributo.SelectedItem = "GERENTE") Then
            Datos._perfil_ATRIBUTO = "3"
        ElseIf (cboAtributo.SelectedItem = "COMISIONI") Then
            Datos._perfil_ATRIBUTO = "4"
        ElseIf (cboAtributo.SelectedItem = "COMISIONS") Then
            Datos._perfil_ATRIBUTO = "5"
        ElseIf (cboAtributo.SelectedItem = "AGENCIA") Then
            Datos._perfil_ATRIBUTO = "1"
        End If

        Datos._perfil_ENCONTRASENA = "LROSAS"
        Datos._perfil_ENSUPERCONTRASENA = ""

        If Datos._perfil_ATRIBUTO = "" Then
            Datos._perfil_ENSUPERCONTRASENA = ""
        Else
            Datos._perfil_ENSUPERCONTRASENA = "LROSAS"
        End If


        Dim texto As String = ""

        Dim i As Integer
        For i = 0 To ListPerfil.Items.Count - 1
            Dim adicional As String = ""
            If ListPerfil.GetItemChecked(i) = True Then
                adicional = "1"
            Else
                adicional = "0"
            End If
            texto = texto + adicional
        Next



        Datos._perfil_ENPERMISOS = texto

        If plantillas.Agregar_perfil(Datos) Then
            MsgBox("Perfil creado con exito")

            cargar()
            've que surcursal tiene 
            '  SUCURSALCAJA()
        Else
            MessageBox.Show("Error al consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Datos._Perfil = txtCod.Text

        If plantillas.Actualizar_claves(Datos) Then
            MsgBox("Claves restablecidas")
            cargar()
        Else
            MessageBox.Show("Error al consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click





    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        If DGUsuarios.Rows(DGUsuarios.CurrentRow.Index).Cells(9).Value.ToString = "" Then
            permiso = "00000000"
        Else
            permiso = DGUsuarios.Rows(DGUsuarios.CurrentRow.Index).Cells(9).Value
        End If


        'EJECUTIVA
        If permiso.Substring(0, 1) = "1" Then
            ListAtributos.SetItemCheckState(0, CheckState.Checked)
        Else
            ListAtributos.SetItemCheckState(0, CheckState.Unchecked)
        End If

        '
        If permiso.Substring(1, 1) = "1" Then
            ListAtributos.SetItemCheckState(1, CheckState.Checked)
        Else
            ListAtributos.SetItemCheckState(1, CheckState.Unchecked)
        End If

        'Estados      	/ Riesgo
        If permiso.Substring(2, 1) = "1" Then
            ListAtributos.SetItemCheckState(2, CheckState.Checked)
        Else
            ListAtributos.SetItemCheckState(2, CheckState.Unchecked)
        End If

        'Estados     	/ Por Aprobar
        If permiso.Substring(3, 1) = "1" Then
            ListAtributos.SetItemCheckState(3, CheckState.Checked)
        Else
            ListAtributos.SetItemCheckState(3, CheckState.Unchecked)
        End If


        'Estados		/ Mis Prestamos
        If permiso.Substring(4, 1) = "1" Then
            ListAtributos.SetItemCheckState(4, CheckState.Checked)
        Else
            ListAtributos.SetItemCheckState(4, CheckState.Unchecked)
        End If

        'Estados		/ Historico
        If permiso.Substring(5, 1) = "1" Then
            ListAtributos.SetItemCheckState(5, CheckState.Checked)
        Else
            ListAtributos.SetItemCheckState(5, CheckState.Unchecked)
        End If

        'Auditoria	/ Puntajes
        If permiso.Substring(6, 1) = "1" Then
            ListAtributos.SetItemCheckState(6, CheckState.Checked)
        Else
            ListAtributos.SetItemCheckState(6, CheckState.Unchecked)
        End If

        'Estadisticas	/ Ejecutivos
        If permiso.Substring(7, 1) = "1" Then
            ListAtributos.SetItemCheckState(7, CheckState.Checked)
        Else
            ListAtributos.SetItemCheckState(7, CheckState.Unchecked)
        End If



    End Sub



    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Dim texto As String = ""
        Dim i As Integer
        For i = 0 To ListAtributos.Items.Count - 1
            Dim adicional As String = ""
            If ListAtributos.GetItemChecked(i) = True Then
                adicional = "1"
            Else
                adicional = "0"
            End If
            texto = texto + adicional
        Next
        Datos._Perfil = txtCod.Text
        Datos._enpermisos = texto

        'MsgBox(Datos._Perfil)
        'MsgBox(datos._enpermisos)

        If plantillas.Actualizar_atributos(Datos) Then
            MsgBox("Permisos Actualizados")
            '  SUCURSALCAJA()
            cargar()

        Else
            MessageBox.Show("Error al consultar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
End Class