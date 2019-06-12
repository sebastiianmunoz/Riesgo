Imports System.Data
Imports System.Data.SqlClient
Public Class frmBandejaCapital6EditarNominaTransferencia
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter
    Private Sub frmBandejaCapital6EditarNominaTransferencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim TOMAFEHCACOMPELTA As String = ""
        Dim TOMAFECHAAÑOMES As String = ""
        TOMAFEHCACOMPELTA = DateTime.Now().ToShortDateString()  '"16/06/2009"
        TOMAFECHAAÑOMES = Mid(TOMAFEHCACOMPELTA, 7, 10) + Mid(TOMAFEHCACOMPELTA, 4, 2) '201410'
        Textdesdemes.Text = Mid(TOMAFEHCACOMPELTA, 4, 2)
        Textdesdeaño.Text = Mid(TOMAFEHCACOMPELTA, 7, 10)
        Textdesdedia.Text = Mid(TOMAFEHCACOMPELTA, 1, 2)
        llenaencabezadoNomina()
        colorearencabezadonmina()

    End Sub


    Sub llenaencabezadoNomina()
        GridSupervisada.Rows.Clear()
        Dim TOMAFECHAAÑOMES As String = ""
        TOMAFECHAAÑOMES = Trim(Textdesdeaño.Text) + Trim(Textdesdemes.Text) + Trim(Textdesdedia.Text)
        QUITARFILANOMINA()
        ' MsgBox(TOMAFECHAAÑOMES)
        Dim conexiones4 As New CConexion
        conexiones4.conexion()
        Dim command4 As SqlCommand = New SqlCommand("SELECT  [NRO_NOMINA], Substring([FECHA_NOMINA],7, 2) + '/' + Substring([FECHA_NOMINA], 5, 2) + '/' + Substring([FECHA_NOMINA],1, 4) AS FECHA_NOMINA,ESTADO_NOMINA,dbo.puntos(MONTO_NOMINA) as MONTO  , USUARIO,[APROBACION_SUBGERENTE_FINANZA],ID_FILA  FROM  [_RIESGO_ENCA_NOMINA_TRANSFERENCIA] where FECHA_NOMINA='" + Trim(TOMAFECHAAÑOMES) + "' AND [ESTADO_NOMINA]<>'GENERADA'  ORDER BY NRO_NOMINA DESC  ", conexiones4._conexion)
        conexiones4.abrir()
        Dim reader4 As SqlDataReader = command4.ExecuteReader()
        If reader4.HasRows Then
            Do While reader4.Read()
                GridSupervisada.Rows.Add(reader4(0), reader4(1), reader4(2), reader4(3), reader4(4), reader4(5), reader4(6))
            Loop
        Else
        End If
        reader4.Close()
        conexiones4.cerrar()
        colorearencabezadonmina()
        GridSupervisada.SelectionMode = False
    End Sub
    Sub colorearencabezadonmina()

        Dim totalfilas22 As Integer = GridSupervisada.RowCount - 1
        If totalfilas22 >= 0 Then
            For z = 0 To totalfilas22
                'MsgBox(Gridmeslineas.Rows(z).Cells(0).Value())
                'GridmesActual.Rows(z).Cells(0).Style.ForeColor = Color.Yellow
                GridSupervisada.Rows(z).Cells(0).Style.ForeColor = Color.White
                GridSupervisada.Rows(z).Cells(0).Style.BackColor = Color.Green
                GridSupervisada.Rows(z).Cells(1).Style.BackColor = Color.LightBlue
                GridSupervisada.Rows(z).Cells(2).Style.BackColor = Color.LightBlue
                GridSupervisada.Rows(z).Cells(3).Style.BackColor = Color.LightBlue
                GridSupervisada.Rows(z).Cells(4).Style.BackColor = Color.LightBlue
                GridSupervisada.Rows(z).Cells(5).Style.BackColor = Color.LightBlue
                GridSupervisada.Rows(z).Cells(6).Style.BackColor = Color.LightBlue
            Next
        End If
        'colorear grilla linea  sobre giro ------
        GridSupervisada.SelectionMode = False
    End Sub
    Sub coloreadetallenomina()


        Dim totalfilas22 As Integer = GridSupervisadadetalle.RowCount
        If totalfilas22 >= 0 Then
            For z = 0 To totalfilas22
                'MsgBox(Gridmeslineas.Rows(z).Cells(0).Value())
                'GridmesActual.Rows(z).Cells(0).Style.ForeColor = Color.Yellow
                GridSupervisadadetalle.Rows(z).Cells(0).Style.ForeColor = Color.White
                GridSupervisadadetalle.Rows(z).Cells(0).Style.BackColor = Color.Green
                GridSupervisadadetalle.Rows(z).Cells(1).Style.BackColor = Color.LightBlue
                GridSupervisadadetalle.Rows(z).Cells(2).Style.BackColor = Color.LightBlue
                GridSupervisadadetalle.Rows(z).Cells(3).Style.BackColor = Color.LightBlue
                GridSupervisadadetalle.Rows(z).Cells(4).Style.BackColor = Color.LightBlue
                GridSupervisadadetalle.Rows(z).Cells(5).Style.BackColor = Color.LightBlue
                GridSupervisadadetalle.Rows(z).Cells(6).Style.BackColor = Color.LightBlue
                GridSupervisadadetalle.Rows(z).Cells(7).Style.BackColor = Color.LightBlue
                GridSupervisadadetalle.Rows(z).Cells(8).Style.BackColor = Color.LightBlue
                GridSupervisadadetalle.Rows(z).Cells(9).Style.BackColor = Color.LightBlue
            Next
        End If
        'colorear grilla linea  sobre giro ------
        GridSupervisadadetalle.SelectionMode = False

    End Sub




    Private Sub Textdesdemes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textdesdemes.TextChanged
        Dim TOTOAL As Double = 0
        TOTOAL = Len(Textdesdemes.Text)
        If TOTOAL = 2 Then
            Textdesdeaño.Focus()
        End If
    End Sub

    Private Sub Textdesdeaño_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textdesdeaño.TextChanged
        Dim TOTOAL As Double = 0
        TOTOAL = Len(Textdesdeaño.Text)
        If TOTOAL = 4 Then
            btnConsultarPeriodo.Focus()
        End If
    End Sub
    Sub seleccionanomina()
        QUITARFILAsDETALLENOMINA()
        Try
            ' MsgBox("pasa")
            Dim ID As Integer = 0
            ID = Trim(GridSupervisada.Rows(GridSupervisada.CurrentRow.Index).Cells(0).Value().ToString())
            TextIDnomina.Text = ID
            Dim conexiones4 As New CConexion
            conexiones4.conexion()
            Dim command4 As SqlCommand = New SqlCommand("SELECT SUBSTRING(FECHA_SOLICITUD,7,8)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4)AS [FECHA_SOLICITUD], [ESTADO_SOLICITUD],convert(varchar(8),[RUT])+'-'+[DVRUT] AS RUT,[NOMBRES]+' '+[PATERNO]+' '+[MATERNO] as NOMBRECOMPLETO ,DBO.PUNTOS([MONTO_SOLICITUD]) AS MONTO ,[BANCO],[TIPO_CUENTA],[NRO_CUENTA], [ID_FILA] FROM [_RIESGO_DETA_NOMINA_TRANSFERENCIA] where nro_nomina='" + Trim(ID) + "' and  [ESTADO_EN_NOMINA]<>'NO SELECCIONADO' ", conexiones4._conexion)
            conexiones4.abrir()
            Dim reader4 As SqlDataReader = command4.ExecuteReader()
            If reader4.HasRows Then
                Do While reader4.Read()
                    GridSupervisadadetalle.Rows.Add(reader4(0), reader4(1), reader4(2), reader4(3), reader4(4), reader4(5), reader4(6), reader4(7), reader4(8))
                Loop
            Else
            End If
            reader4.Close()
            conexiones4.cerrar()
            GridSupervisadadetalle.SelectionMode = False
            coloreadetallenomina()



        Catch ex As Exception
        End Try
    End Sub

    Private Sub GridSupervisada_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridSupervisada.SelectionChanged
        seleccionanomina()
    End Sub
    Sub QUITARFILAsDETALLENOMINA()
        Dim TOTLAFILAS As Integer = GridSupervisadadetalle.RowCount - 1
        Dim Z As Integer = TOTLAFILAS
        Do While Z >= 0
            GridSupervisadadetalle.Rows.RemoveAt(Z)
            Z = Z - 1
        Loop
    End Sub
    Sub QUITARFILANOMINA()
        Dim TOTLAFILAS As Integer = GridSupervisada.RowCount - 1
        Dim Z As Integer = TOTLAFILAS
        Do While Z >= 0
            GridSupervisada.Rows.RemoveAt(Z)
            Z = Z - 1
        Loop
    End Sub

    Private Sub btnConsultarPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarPeriodo.Click
        llenaencabezadoNomina()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        sacardelanomina()
    End Sub

    Sub sacardelanomina()
        '  Dim TOMANRONOMINA As String = GridSupervisadadetalle.Rows(0).Cells(1).Value()

        Dim totalfilas As Integer = GridSupervisadadetalle.RowCount - 1
        Dim iddetatransfer As String = ""
        GridSeleccion.Rows.Clear()
        For z = 0 To totalfilas
            If GridSupervisadadetalle.Rows(z).Cells(9).Value() = True Then
                iddetatransfer = GridSupervisadadetalle.Rows(z).Cells(8).Value()

                GridSupervisadadetalle.Rows(z).Cells(0).Style.ForeColor = Color.Yellow
                GridSupervisadadetalle.Rows(z).Cells(0).Style.BackColor = Color.Red

                GridSupervisadadetalle.Rows(z).Cells(1).Style.ForeColor = Color.Yellow
                GridSupervisadadetalle.Rows(z).Cells(1).Style.BackColor = Color.Red

                GridSupervisadadetalle.Rows(z).Cells(2).Style.ForeColor = Color.Yellow
                GridSupervisadadetalle.Rows(z).Cells(2).Style.BackColor = Color.Red


                GridSupervisadadetalle.Rows(z).Cells(3).Style.ForeColor = Color.Yellow
                GridSupervisadadetalle.Rows(z).Cells(3).Style.BackColor = Color.Red


                GridSupervisadadetalle.Rows(z).Cells(4).Style.ForeColor = Color.Yellow
                GridSupervisadadetalle.Rows(z).Cells(4).Style.BackColor = Color.Red


                GridSupervisadadetalle.Rows(z).Cells(5).Style.ForeColor = Color.Yellow
                GridSupervisadadetalle.Rows(z).Cells(5).Style.BackColor = Color.Red

                GridSupervisadadetalle.Rows(z).Cells(6).Style.ForeColor = Color.Yellow
                GridSupervisadadetalle.Rows(z).Cells(6).Style.BackColor = Color.Red

                GridSupervisadadetalle.Rows(z).Cells(7).Style.ForeColor = Color.Yellow
                GridSupervisadadetalle.Rows(z).Cells(7).Style.BackColor = Color.Red

                GridSupervisadadetalle.Rows(z).Cells(8).Style.ForeColor = Color.Yellow
                GridSupervisadadetalle.Rows(z).Cells(8).Style.BackColor = Color.Red

                GridSupervisadadetalle.Rows(z).Cells(9).Style.ForeColor = Color.Yellow
                GridSupervisadadetalle.Rows(z).Cells(9).Style.BackColor = Color.Red



                GridSeleccion.Rows.Add(iddetatransfer)
                'MsgBox(GridSeleccion.RowCount)
            ElseIf GridSupervisadadetalle.Rows(z).Cells(9).Value() = False Then
            End If
        Next

        If GridSeleccion.RowCount > 0 Then
            gridrecibetablaprincipal.Rows.Clear()
            Dim totalfilas2 As Integer = GridSeleccion.RowCount - 1
            ' MsgBox("pase")
            For z = 0 To totalfilas2
                'SELECT ESTADO_SOLICITUD ,CORREGRESO FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL]  WHERE ID_SOLICITUD = ( select ID_SOLICITUD FROM [_RIESGO_DETA_NOMINA_TRANSFERENCIA] WHERE ID_FILA ='4143') 
                Try
                    Dim ID As String = ""
                    'MsgBox(GridSeleccion.Rows(z).Cells(0).Value())
                    ID = GridSeleccion.Rows(z).Cells(0).Value()
                    Dim conexiones4 As New CConexion
                    conexiones4.conexion()
                    Dim command4 As SqlCommand = New SqlCommand("SELECT ESTADO_SOLICITUD ,CORREGRESO,ID_SOLICITUD  FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL]  WHERE ID_SOLICITUD = ( select ID_SOLICITUD FROM [_RIESGO_DETA_NOMINA_TRANSFERENCIA] WHERE ID_FILA ='" + Trim(ID) + "')  ", conexiones4._conexion)
                    conexiones4.abrir()
                    Dim reader4 As SqlDataReader = command4.ExecuteReader()
                    If reader4.HasRows Then
                        Do While reader4.Read()
                            gridrecibetablaprincipal.Rows.Add(reader4(0), reader4(1), reader4(2))
                        Loop
                    Else
                    End If
                    reader4.Close()
                    conexiones4.cerrar()
                    GridSupervisadadetalle.SelectionMode = False
                    'coloreadetallenomina()
                Catch ex As Exception

                End Try
            Next

            Dim totalfilas22 As Integer = gridrecibetablaprincipal.RowCount - 1
            Dim semaforomuestramensaje As Boolean = True
            For z = 0 To totalfilas22
                If Trim(gridrecibetablaprincipal.Rows(z).Cells(0).Value()) = "PAGADO" And Int(gridrecibetablaprincipal.Rows(z).Cells(1).Value()) <> 0 Then
                    'No se puede sacar de la nomina este requerimiento  debido a que tiene un egreso asociado primero se debe  canceloar el egreso 
                    If semaforomuestramensaje = True Then
                        MsgBox("------------Existe una solicitud  que tiene un egreso asociado debe eliminar ese egreso primero -------------- ", MsgBoxStyle.Information, "Solicitud con egreso ")
                    Else
                    End If
                    semaforomuestramensaje = False


                ElseIf (Trim(gridrecibetablaprincipal.Rows(z).Cells(0).Value()) = "APROBADO" Or Trim(gridrecibetablaprincipal.Rows(z).Cells(0).Value()) = "PREAPROBADO") And Int(gridrecibetablaprincipal.Rows(z).Cells(1).Value()) = 0 Then
                    'si  se puede sacar de la nomina este requerimiento  debido a que no  tiene un egreso asociado 
                    Dim ID_SOLICITUD As String = Trim(gridrecibetablaprincipal.Rows(z).Cells(2).Value())
                    sacarnominaupdate(ID_SOLICITUD)

                    If totalfilas22 = z Then
                        MsgBox("------------Cambio Realizado -------------- ", MsgBoxStyle.Information, "Operacion Realizada  ")
                    End If

                End If


            Next


            ' MsgBox(totalfilas2)
            If totalfilas2 >= 1 And semaforomuestramensaje = True Then
                ActualizarMontoNomina(TextIDnomina.Text)
                llenaencabezadoNomina()
                GridSeleccion.Rows.Clear()
            ElseIf totalfilas2 = 0 And semaforomuestramensaje = True Then
                ActualizarMontoNomina(TextIDnomina.Text)
                'ActualizarNominasolicitudDirecta(TextIDnomina.Text)
                llenaencabezadoNomina()
                GridSeleccion.Rows.Clear()
            End If

        Else

            MsgBox(" Debe seleccionar las solicitudes para sacar de la nómina  ", MsgBoxStyle.Information, "Verificar")
        End If

    End Sub

    Sub sacarnominaupdate(ByVal ID_SOLICITUD As String)

        ' update [_RIESGO_DETA_NOMINA_TRANSFERENCIA] set  [ESTADO_EN_NOMINA]='NO SELECCIONADO',ESTADO_SOLICITUD='PREAPROBADO' where ID_SOLICITUD=7238 
        ' update [_RIESGO_SOLICITUD_GIRO_CAPITAL]  set ESTADO_SOLICITUD='PREAPROBADO' , EN_NOMINA=0  where ID_SOLICITUD=7238    
        ' select sum([MONTO_SOLICITUD]) from [_RIESGO_DETA_NOMINA_TRANSFERENCIA] where [NRO_NOMINA] = 579 and  [ESTADO_EN_NOMINA]<>'NO SELECCIONADO'
        Dim conexiones60 As New CConexion
        conexiones60.conexion()
        _adaptador.UpdateCommand = New SqlCommand("UPDATE  [_RIESGO_SOLICITUD_GIRO_CAPITAL]  set ESTADO_SOLICITUD='PREAPROBADO' , EN_NOMINA=0  where ID_SOLICITUD='" + Trim(ID_SOLICITUD) + "' ", conexiones60._conexion)
        conexiones60.abrir()
        _adaptador.UpdateCommand.Connection = conexiones60._conexion
        _adaptador.UpdateCommand.ExecuteNonQuery()
        conexiones60.cerrar()

        Dim conexiones61 As New CConexion
        conexiones61.conexion()
        _adaptador.UpdateCommand = New SqlCommand("UPDATE [_RIESGO_DETA_NOMINA_TRANSFERENCIA] set  [ESTADO_EN_NOMINA]='NO SELECCIONADO',ESTADO_SOLICITUD='PREAPROBADO' where ID_SOLICITUD='" + Trim(ID_SOLICITUD) + "' ", conexiones61._conexion)
        conexiones61.abrir()
        _adaptador.UpdateCommand.Connection = conexiones61._conexion
        _adaptador.UpdateCommand.ExecuteNonQuery()
        conexiones61.cerrar()
    End Sub


    Sub ActualizarMontoNomina(ByVal NRO_NOMINA As String)
        ' falta ver que pasa cuando existe  una solo solciutd y esta  es retira de la nomina  
        'Toma el primer y ultimo dia  del mes seleccionado 
        Dim RECIBENUMEROSOLICITUDES As Integer = 0
        Dim conexiones4 As New CConexion
        conexiones4.conexion()
        Dim command4 As SqlCommand = New SqlCommand("select COUNT(*) from  [_RIESGO_DETA_NOMINA_TRANSFERENCIA]  where nro_nomina  ='" + Trim(NRO_NOMINA) + "' and ESTADO_EN_NOMINA ='SELECCIONADO' ", conexiones4._conexion)
        conexiones4.abrir()
        Dim reader4 As SqlDataReader = command4.ExecuteReader()
        If reader4.HasRows Then
            Do While reader4.Read()
                RECIBENUMEROSOLICITUDES = reader4(0)
            Loop
        Else
        End If
        reader4.Close()
        conexiones4.cerrar()

        If RECIBENUMEROSOLICITUDES >= 1 Then

            Dim conexiones60 As New CConexion
            conexiones60.conexion()
            _adaptador.UpdateCommand = New SqlCommand(" update [_RIESGO_ENCA_NOMINA_TRANSFERENCIA] set [MONTO_NOMINA]=(select sum([MONTO_SOLICITUD]) from [_RIESGO_DETA_NOMINA_TRANSFERENCIA] where [NRO_NOMINA] = '" + Trim(NRO_NOMINA) + "' and  [ESTADO_EN_NOMINA]<>'NO SELECCIONADO') WHERE NRO_NOMINA='" + Trim(NRO_NOMINA) + "'   ", conexiones60._conexion)
            conexiones60.abrir()
            _adaptador.UpdateCommand.Connection = conexiones60._conexion
            _adaptador.UpdateCommand.ExecuteNonQuery()
            conexiones60.cerrar()

        ElseIf RECIBENUMEROSOLICITUDES = 0 Then

            ActualizarNominasolicitudDirecta(NRO_NOMINA)
            'MsgBox("SE BORRA TODA LA NOMINA ")
        End If


    End Sub
    Sub ActualizarNominasolicitudDirecta(ByVal NRO_NOMINA As String)
        ' falta ver que pasa cuando existe  una solo solciutd y esta  es retira de la nomina  
        Dim conexiones60 As New CConexion
        conexiones60.conexion()
        _adaptador.UpdateCommand = New SqlCommand(" update [_RIESGO_ENCA_NOMINA_TRANSFERENCIA] set [ESTADO_NOMINA]='RECHAZADA' ,[APROBACION_SUBGERENTE_FINANZA]='NO'  WHERE NRO_NOMINA='" + Trim(NRO_NOMINA) + "'   ", conexiones60._conexion)
        conexiones60.abrir()
        _adaptador.UpdateCommand.Connection = conexiones60._conexion
        _adaptador.UpdateCommand.ExecuteNonQuery()
        conexiones60.cerrar()
    End Sub


    Private Sub Textdesdedia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textdesdedia.TextChanged
        Dim TOTOAL As Double = 0
        TOTOAL = Len(Textdesdedia.Text)
        If TOTOAL = 2 Then
            Textdesdemes.Focus()
        End If
    End Sub


    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub
End Class