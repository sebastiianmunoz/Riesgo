Public Class frmEstadisticasPrestamos
    Dim plantillas As Metodos = New Metodos
    Dim tabla As New DataTable
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'plantillas._tabla.Rows.Clear()
        'plantillas._tabla.Columns.Clear()
        'If plantillas.Agregar_Prestamos_Deudas() Then
        '    tabla = plantillas.tabla
        '    DGPrestamos.DataSource = tabla
        'End If
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class