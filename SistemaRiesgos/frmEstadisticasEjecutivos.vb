Imports System.Data
Imports System.Data.SqlClient

Public Class frmEstadisticasEjecutivos
    Dim plantillas As Metodos = New Metodos
    Dim plantillas2 As Metodos = New Metodos
    Dim plantillas3 As Metodos = New Metodos
    Dim tabla As New DataTable
    Dim tabla2 As New DataTable


    Sub AgregarEjecutivosDescartados()
        plantillas._tabla.Rows.Clear()
        plantillas._tabla.Columns.Clear()
        If plantillas.Agregar_EjecutivosDescartados() Then
            tabla = plantillas.tabla
            DGEjecutivosDescartados.DataSource = tabla
        End If
    End Sub

    Sub AgregarEjecutivosRealizados()
        plantillas2._tabla2.Rows.Clear()
        plantillas2._tabla2.Columns.Clear()
        If plantillas2.Agregar_EjecutivosRealizados() Then
            tabla2 = plantillas2.tabla2
            DGEjecutivosSolicitados.DataSource = tabla2
        End If
    End Sub

    Sub AgregarEjecutivosAprobados_Rechazados()
        plantillas3._tabla2.Rows.Clear()
        plantillas3._tabla2.Columns.Clear()
        If plantillas3.Agregar_EjecutivoAprobados_Rechazados() Then
            tabla2 = plantillas3.tabla2
            DGEjecutivosAprobadosyRechazados.DataSource = tabla2
        End If
    End Sub

    Private Sub frmEstadisticasEjecutivos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AgregarEjecutivosDescartados()
        'DGEjecutivosDescartados.AutoResizeColumn(AutoSize)
        AgregarEjecutivosRealizados()
        'DGEjecutivosSolicitados.AutoResizeColumn(AutoSize)
        AgregarEjecutivosAprobados_Rechazados()
        'DGEjecutivosAprobadosyRechazados.AutoResizeColumn(AutoSize)
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub
End Class