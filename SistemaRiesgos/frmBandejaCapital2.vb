Imports System.Data
Imports System.Data.SqlClient
Public Class frmBandejaCapital2
    Dim plantillas As Metodos = New Metodos
    ' Public _tabla7 As DataTable = New DataTable
    Dim tabla7 As New DataTable

    Dim recibefrmcapital4 As Integer = 0


    Dim newcol As DataGridViewColumn = New DataGridViewCheckBoxColumn
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter
    Dim Contadorllenagrill As Integer = 1



    Private Sub frmBandejaCapital2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Consultar_Creditos_Aprobar_EFECTIVO()
        GridbandejaCapital.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        plantillas._tabla.Rows.Clear()
        plantillas._tabla.Columns.Clear()
        plantillas.Consultar_Creditos_Aprobar_EFECTIVO() 'metodo que se  debe  ver en profundiad  =) 
        tabla7 = plantillas.tabla
        GridbandejaCapital.DataSource = tabla7
        crearcolumna()
        Timer1.Start()
    End Sub
    Private Sub GridbandejaCapital_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridbandejaCapital.SelectionChanged
        If Contadorllenagrill = 1 Then
            Try
                txtID.Text = ""
                txtFecha.Text = ""
                txtMonto.Text = ""
                txtNrosocio.Text = ""
                txtSucursal.Text = ""
                txtNrosocio.Text = GridbandejaCapital.Rows(GridbandejaCapital.CurrentRow.Index).Cells(5).Value
                txtFecha.Text = GridbandejaCapital.Rows(GridbandejaCapital.CurrentRow.Index).Cells(1).Value
                txtMonto.Text = GridbandejaCapital.Rows(GridbandejaCapital.CurrentRow.Index).Cells(2).Value
                txtID.Text = GridbandejaCapital.Rows(GridbandejaCapital.CurrentRow.Index).Cells(9).Value
                txtSucursal.Text = GridbandejaCapital.Rows(GridbandejaCapital.CurrentRow.Index).Cells(8).Value
            Catch ex As Exception
            End Try
        Else
            Try
                txtID.Text = ""
                txtFecha.Text = ""
                txtMonto.Text = ""
                txtNrosocio.Text = ""
                txtSucursal.Text = ""
                txtNrosocio.Text = GridbandejaCapital.Rows(GridbandejaCapital.CurrentRow.Index).Cells(4).Value
                txtFecha.Text = GridbandejaCapital.Rows(GridbandejaCapital.CurrentRow.Index).Cells(0).Value
                txtMonto.Text = GridbandejaCapital.Rows(GridbandejaCapital.CurrentRow.Index).Cells(1).Value
                txtID.Text = GridbandejaCapital.Rows(GridbandejaCapital.CurrentRow.Index).Cells(8).Value
                txtSucursal.Text = GridbandejaCapital.Rows(GridbandejaCapital.CurrentRow.Index).Cells(7).Value
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim totalfilas As Integer = GridbandejaCapital.RowCount - 1
        Dim totalselecionado As Integer = 0
        Dim id_fila As String = ""
        Dim dialogoresultado As DialogResult
        Dim contador As Integer = 0
        Dim i As Integer = 0
        'MsgBox(totalfilas)
        For i = 0 To totalfilas
            If GridbandejaCapital.Rows(i).Cells(11).Value() = True Then
                contador = contador + 1
            End If
        Next

        If contador > 1 Then
            MsgBox("Debe Liberar una Solicitud a la vez ")
        ElseIf contador = 1 Then

            i = 0
            For i = 0 To totalfilas
                If GridbandejaCapital.Rows(i).Cells(11).Value() = True Then
                    Exit For
                End If
            Next
            If GridbandejaCapital.Rows(i).Cells(10).Value() <> 0 And (GridbandejaCapital.Rows(i).Cells(9).Value() = "Fallecimiento" Or GridbandejaCapital.Rows(i).Cells(9).Value() = "Renuncia" Or GridbandejaCapital.Rows(i).Cells(9).Value() = "Castigo") Then
                MsgBox("No puede realizar operaciones sobre esta solicitud por ser actualizable (Renuncias, Castigos, Fallecimientos) y tener otras solicitudes anteriores pendientes de pagar o contabilizar")
            Else
                Timer1.Stop()
                frmBandejaCapital4.Visible = True
                frmBandejaCapital4.Label3.Text = GridbandejaCapital.Rows(i).Cells(3).Value()
                'GridbandejaCapital.Rows(GridbandejaCapital.CurrentRow.Index).Cells(5).Value
                frmBandejaCapital4.Label5.Text = frmEvaluarCapital.PuntoX(GridbandejaCapital.Rows(i).Cells(1).Value())
                frmBandejaCapital4.Textnrosocio.Text = GridbandejaCapital.Rows(i).Cells(4).Value()
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'CALFARO DESACTIVA TIMER
        If Checkparaactualizaciongrilla.Checked = False Then
            Contadorllenagrill = Contadorllenagrill + 1
            Timer1.Interval = 12000
            ACTUALIZAGRILLAPENDIENTE()
        End If
    End Sub
    Sub ACTUALIZAGRILLAPENDIENTE()
        'If Contadorllenagrill = 1 Then
        sacarcolumna()
        plantillas._tabla.Rows.Clear()
        plantillas._tabla.Columns.Clear()
        plantillas.Consultar_Creditos_Aprobar_EFECTIVO() 'metodo que se  debe  ver en profundiad  =) 
        tabla7 = plantillas.tabla
        GridbandejaCapital.DataSource = tabla7
        crearcolumna()
        'ElseIf Contadorllenagrill > 1 Then
        'End If
    End Sub
    Sub crearcolumna()
        newcol.HeaderText = "SELECCION"
        newcol.Name = "Nombrecol"
        newcol.DataPropertyName = "nombre_campo" 'Campo de enlace a datos
        GridbandejaCapital.Columns.Add(newcol)

    End Sub
    Sub sacarcolumna()
        GridbandejaCapital.Columns.Remove(newcol)
    End Sub

    Private Sub GridbandejaCapital_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridbandejaCapital.CellContentClick

    End Sub
End Class