Imports System.Data
Imports System.Data.SqlClient

Public Class frmCreditosRiesgo
    Dim plantillas As Metodos = New Metodos
    Dim tabla As New DataTable
    Dim contador As Integer = 1

    Dim alarma_general As Integer = 0
    Dim Datos As New CDatos
    Dim tiempo As Integer = 0
    Dim tiempomaximo As Integer = 1000




    Private Sub frmCreditosRiesgo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProgressBar1.Maximum = tiempomaximo
        Timer1.Enabled = True
        Timer1.Interval = 1
        vercreditos()
        'Timer1.Enabled = True
        'Timer1.Interval = 10000

        'plantillas._tabla.Rows.Clear()
        'plantillas._tabla.Columns.Clear()

        'If plantillas.Consultar_Creditos_Riesgo() Then
        '    tabla = plantillas.tabla
        '    DGreditosRiesgo.DataSource = tabla
        'End If
    End Sub


    Private Sub DGreditosRiesgo_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGreditosRiesgo.SelectionChanged
        Try


            If DGreditosRiesgo.Rows(DGreditosRiesgo.CurrentRow.Index).Cells(1).Value = "" Then


            Else

                txtid.Text = ""
                txtEjecutiva.Text = ""
                txtFecha.Text = ""
                txtMonto.Text = ""
                txtNrosocio.Text = ""
                Txtproducto.Text = ""
                txtSucursal.Text = ""

                txtid.Text = DGreditosRiesgo.Rows(DGreditosRiesgo.CurrentRow.Index).Cells(0).Value
                txtNrosocio.Text = DGreditosRiesgo.Rows(DGreditosRiesgo.CurrentRow.Index).Cells(1).Value
                txtFecha.Text = DGreditosRiesgo.Rows(DGreditosRiesgo.CurrentRow.Index).Cells(2).Value
                Txtproducto.Text = DGreditosRiesgo.Rows(DGreditosRiesgo.CurrentRow.Index).Cells(3).Value
                txtMonto.Text = DGreditosRiesgo.Rows(DGreditosRiesgo.CurrentRow.Index).Cells(4).Value
                txtEjecutiva.Text = DGreditosRiesgo.Rows(DGreditosRiesgo.CurrentRow.Index).Cells(5).Value
                txtSucursal.Text = DGreditosRiesgo.Rows(DGreditosRiesgo.CurrentRow.Index).Cells(6).Value

                'txtBuscar.Text = DGDatos.Rows(DGDatos.CurrentRow.Index).Cells(3).Value
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click


        If (DGreditosRiesgo.RowCount <= 1) Then
            MsgBox("No existen prestamos solicitados")
        Else
            My.Forms.frmFichaRiesgo.MdiParent = My.Forms.frmRIESGO
            My.Forms.frmFichaRiesgo.WindowState = FormWindowState.Normal
            My.Forms.frmFichaRiesgo.Show()
            frmFichaRiesgo.txtCodigoId.Text = txtid.Text
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick




        If ChkAutoAvisoRiesgo.Checked = True Then

            tiempo = tiempo + 1


            If (tiempo >= tiempomaximo) Then


                ProgressBar1.Value = 0
                tiempo = 0
            Else
                ProgressBar1.Value = tiempo

            End If



            If tiempo = 1 Then
                vercreditos()
            End If

        End If






  

        'MsgBox("Contador Antiguo " + contador.ToString + "Contar ACtual" + DGreditosRiesgo.RowCount.ToString)

    
    End Sub


    Sub vercreditos()
        plantillas._tabla.Rows.Clear()
        plantillas._tabla.Columns.Clear()

        If plantillas.Consultar_Creditos_Riesgo() Then
            tabla = plantillas.tabla
            DGreditosRiesgo.DataSource = tabla
        End If

        'If ChkAutoAvisoRiesgo.Checked = True And DGreditosRiesgo.RowCount > 1 And contador.ToString < DGreditosRiesgo.RowCount.ToString Then
        '    frmRIESGO.WindowState = FormWindowState.Normal

        '    My.Computer.Audio.Play(My.Resources.Beep, AudioPlayMode.Background)
        '    contador = DGreditosRiesgo.RowCount
        'End If
    End Sub








    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        plantillas._tabla.Rows.Clear()
        plantillas._tabla.Columns.Clear()

        If plantillas.Consultar_Creditos_Riesgo() Then
            tabla = plantillas.tabla
            DGreditosRiesgo.DataSource = tabla
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox(DGreditosRiesgo.RowCount)
    End Sub

  
End Class