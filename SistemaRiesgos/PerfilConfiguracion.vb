
Imports System.Data
Imports System.Data.SqlClient



Public Class PerfilConfiguracion
    Dim Datos As New CDatos
    Dim Plantillas As New CCEstadosGeneral
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim alfabetico As Integer = 0

        Dim Numeros As Integer = 0


        Dim leng As Integer = txtcontraseña2.Text.Length - 1
        For i As Integer = 0 To leng

            Dim ch As Char = txtcontraseña2.Text(i)
            If Char.IsLetter(ch) Then
                alfabetico += 1
            End If
            If Char.IsNumber(ch) Then
                Numeros += 1
            End If

        Next

        Dim perfil As New frmPerfil
        Dim Plantillas As New CCEstadosGeneral
        Datos._Perfil = frmPerfil.CbmUsuario.SelectedItem

        If Txtcontraseña1.Text <> txtcontraseña2.Text Then
            Lbcontraseña.Text = "Las contraseñas son diferentes"
            Lbcontraseña.ForeColor = Color.Maroon
        Else
            If Len(Txtcontraseña1.Text) < 8 Then
                Lbcontraseña.Text = "* Contraseña MINIMO de 8 caracteres"
                Lbcontraseña.ForeColor = Color.Maroon
            Else

                If alfabetico < 2 Then
                    Lbcontraseña.Text = "* Debe contener a lo menos 2 caracteres alfabéticos"
                    Lbcontraseña.ForeColor = Color.Maroon
                Else
                    If Numeros < 2 Then
                        Lbcontraseña.Text = "* Debe contener a lo menos 2 caracteres numéricos"
                        Lbcontraseña.ForeColor = Color.Maroon
                    Else
                        Datos._Contraseña = Txtcontraseña1.Text

                        If Plantillas.Actualizar_ContraseñaxCodigoPerfil(Datos) Then

                            Lbcontraseña.ForeColor = Color.Green
                            Lbcontraseña.Text = "Contraseña correctamente modificada"
                            ACTIVARBOTON()


                        End If
                    End If
                End If
            End If
        End If
    End Sub


    Sub ACTIVARBOTON()

        If (Lbcontraseña.ForeColor = Color.Green And Lbcontraseña2.ForeColor = Color.Green) Then
            Button5.Enabled = True
        Else
            Button5.Enabled = False
        End If

    End Sub




    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim alfabetico As Integer = 0

        Dim Numeros As Integer = 0

        Try


            Dim leng As Integer = TXTsUPERCONTRASENA2.Text.Length - 1
            For i As Integer = 0 To leng

                Dim ch As Char = TXTsUPERCONTRASENA2.Text(i)
                If Char.IsLetter(ch) Then
                    alfabetico += 1
                End If
                If Char.IsNumber(ch) Then
                    Numeros += 1
                End If

            Next

        Catch ex As Exception

        End Try


        Dim perfil As New frmPerfil
        Dim Plantillas As New CCEstadosGeneral
        Dim AUTORIZA As String = ""
        Dim ANTIGUACONTRASENA As String = ""
        Datos._Perfil = frmPerfil.CbmUsuario.SelectedItem


        Dim conexiones4 As New CConexion
        conexiones4.conexion()
        Dim command4 As SqlCommand = New SqlCommand("  SELECT  ATRIBUTO,dbo.FU_DESENCRIPTA(enSUPERCONTRASENA),SUCURSAL from  _RIESGO_PERFIL  WHERE USUARIO='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "'", conexiones4._conexion)
        conexiones4.abrir()
        Dim reader4 As SqlDataReader = command4.ExecuteReader()

        If reader4.HasRows Then
            Do While reader4.Read()
                AUTORIZA = (reader4(0).ToString)
                ANTIGUACONTRASENA = (reader4(1).ToString)
                cboSucursal.SelectedItem = (reader4(2).ToString)
            Loop
        Else
        End If

        reader4.Close()



        'If Len(Trim(AUTORIZA.ToString)) > 0 Then



        If TXTsUPERCONTRASENA1.Text <> TXTsUPERCONTRASENA2.Text Then
            Lbcontraseña2.Text = "Las contraseñas son diferentes"
            Lbcontraseña2.ForeColor = Color.Maroon
        Else
            If Len(TXTsUPERCONTRASENA1.Text) < 6 Then
                Lbcontraseña2.Text = "* Contraseña MINIMO de 6 caracteres"
                Lbcontraseña2.ForeColor = Color.Maroon
            Else
                If alfabetico < 2 Then
                    Lbcontraseña2.Text = "* Debe contener a lo menos 2 caracteres alfabéticos"
                    Lbcontraseña2.ForeColor = Color.Maroon
                Else
                    If Numeros < 2 Then
                        Lbcontraseña2.Text = "* Debe contener a lo menos 2 caracteres numéricos"
                        Lbcontraseña2.ForeColor = Color.Maroon
                    Else
                        Datos._Contraseña = TXTsUPERCONTRASENA1.Text
                        If Plantillas.Actualizar_ContraseñaMASESTRAxCodigoPerfil(Datos) Then
                            Lbcontraseña2.Text = "Contraseña correctamente modificada"
                            Lbcontraseña2.ForeColor = Color.Green
                            ACTIVARBOTON()
                        Else
                            Lbcontraseña2.Text = "Error interno, contacte al administrador"
                        End If
                    End If
                End If
            End If
        End If

        'Else
        'MsgBox("Usuario no autorizado para tener clave maestra")
        'End If







    End Sub

  

    Private Sub PerfilConfiguracion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


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




        Dim contrasena As String = ""
        Dim supercontrasena As String = ""

        Dim conexiones4 As New CConexion
        conexiones4.conexion()
        Dim command4 As SqlCommand = New SqlCommand("  SELECT  dbo.FU_DESENCRIPTA(enSUPERCONTRASENA),dbo.FU_DESENCRIPTA(enCONTRASENA),RTRIM([CIUDAD])+' - '+RTRIM(NOMBRECAJA) from  _RIESGO_PERFIL inner join  (SELECT * FROM [_SUCURSAL] WHERE VIGENTE=1) as  _SUCURSAL ON _RIESGO_PERFIL.UBICACION=_SUCURSAL.CODCAJA  WHERE USUARIO='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "'", conexiones4._conexion)
        conexiones4.abrir()
        Dim reader4 As SqlDataReader = command4.ExecuteReader()

        If reader4.HasRows Then
            Do While reader4.Read()
                supercontrasena = (reader4(0).ToString)
                contrasena = (reader4(1).ToString)
                cboSucursal.SelectedItem = (reader4(2).ToString)
            Loop
        Else
        End If

        reader4.Close()

     


        If (Trim(contrasena) = "LROSAS") Then
            Lbcontraseña.Text = " Debe modificar la contraseña"
            Lbcontraseña.ForeColor = Color.Maroon
        End If

        If (Trim(supercontrasena) = "LROSAS") Then
            Lbcontraseña2.Text = " Debe modificar la contraseña"
            Lbcontraseña2.ForeColor = Color.Maroon
            'Else
            '    Lbcontraseña2.Text = "No tiene permisos de evaluador"
            '    Lbcontraseña2.ForeColor = Color.Green
        End If


    End Sub





    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        frmPerfil.TxtContrasena.Text = ""
        frmPerfil.Visible = True
        Label1.Visible = False
        Label2.Visible = False


     
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub



    'Sub SUCURSALCAJA()

    '    Dim SUCUARSALCAJA2 As String = ""

    '    ' MsgBox(cboSucursal.SelectedItem)
    '    If Trim(cboSucursal.SelectedItem) = "VALPARAÍSO" Then
    '        SUCUARSALCAJA2 = "4"
    '    ElseIf Trim(cboSucursal.SelectedItem) = "VIÑA DEL MAR" Then
    '        SUCUARSALCAJA2 = "2"
    '    End If


    '    Try
    '        'MsgBox(txtCod.Text)
    '        'MsgBox(SUCUARSALCAJA2)

    '        Dim conexiones60 As New CConexion
    '        conexiones60.conexion()
    '        _adaptador.UpdateCommand = New SqlCommand("UPDATE [_RIESGO_PERFIL] SET [SUCURSALCAJA] = '" + SUCUARSALCAJA2 + "'   WHERE USUARIO='" + My.Settings.usuario + "'", conexiones60._conexion)
    '        conexiones60.abrir()
    '        _adaptador.UpdateCommand.Connection = conexiones60._conexion
    '        _adaptador.UpdateCommand.ExecuteNonQuery()
    '        conexiones60.cerrar()

    '    Catch ex As Exception
    '        'MsgBox("Existe  un error la generar o actualizar  usuario  contactarse con administrador ")
    '    End Try

    'End Sub



    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        Dim NOMBRE As String = ""
        Dim UBICACION As String = ""
        Datos._Perfil = My.Settings.usuario


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








        If Plantillas.Actualizar_Sucursal(Datos) Then
            lSUCURSAL.Text = "Ubicación correctamente modificada"
            Dim conexiones2 As New CConexion
            conexiones2.conexion()
            Dim command2 As SqlCommand = New SqlCommand("SELECT dbo.FU_DESENCRIPTA(ENCONTRASENA) ,RTRIM([CIUDAD])+' - '+RTRIM(NOMBRECAJA),NOMBRE,dbo.FU_DESENCRIPTA( [ENPERMISOS]),dbo.FU_DESENCRIPTA( [ENSUPERCONTRASENA]),departamento FROM _RIESGO_PERFIL  inner join (SELECT * FROM [_SUCURSAL] WHERE VIGENTE=1) as  _SUCURSAL ON _RIESGO_PERFIL.UBICACION=_SUCURSAL.CODCAJA  WHERE USUARIO='" + My.Settings.usuario + "'", conexiones2._conexion)
            conexiones2.abrir()
            Dim reader2 As SqlDataReader = command2.ExecuteReader()
            If reader2.HasRows Then
                Do While reader2.Read()
                    UBICACION = reader2(1).ToString
                    NOMBRE = reader2(2).ToString
                    ' MsgBox(Departamento)
                Loop
            End If

            reader2.Close()
            frmRIESGO.ToolNombres.Text = NOMBRE
            '+ vbCr + "-UBICACIÓN: " + UBICACION
            frmPerfil.TxtSede.Text = UBICACION
            frmRIESGO.ToolUbicacion.Text = UBICACION
            'SUCURSALCAJA()


        Else
            lSUCURSAL.Text = "Error interno, contacte al administrador"
        End If


    End Sub



    Private Sub cboSucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSucursal.SelectedIndexChanged

    End Sub
End Class