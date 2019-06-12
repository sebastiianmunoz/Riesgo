Imports CrystalDecisions.Shared
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.IO
Public Class frmReporteCartagirocapital

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        GENERAL()
    End Sub

    Sub GENERAL()
        'Dim preporte As New ReporteCartaRetiroCapitalCuotasparticipacion()
        'preporte.SetDatabaseLogon("sa", "universo")
        'Dim param As New ParameterField()
        'param.ParameterFieldName = "@ID_SOLICITUD"

        'Dim discreteValue As New ParameterDiscreteValue()
        'MsgBox(frmBandejaCapital5.TextID.Text)
        'discreteValue.Value = Integer.Parse(frmBandejaCapital5.TextID.Text)

        'param.CurrentValues.Add(discreteValue)
        'Dim paramFiels As New ParameterFields()
        'paramFiels.Add(param)


        'Me.CrystalReportViewer1.ReportSource = preporte


        Dim preporte As New ReporteCartaRetiroCapitalCuotasparticipacion()
        Dim variable As New ParameterDiscreteValue()

        Dim vvalor As New ParameterValues()
     preporte.Refresh()

        variable.Value = Integer.Parse(frmBandejaCapital5.TextID.Text)
        vvalor.Add(variable)
        ' MsgBox(frmBandejaCapital5.TextID.Text)
        preporte.DataDefinition.ParameterFields("@ID_SOLICITUD").ApplyCurrentValues(vvalor)

        variable.Value = Trim(frmBandejaCapital5.textfechasolicitud.Text)
      

        preporte.SetDatabaseLogon("sa", "universo")
        Me.CrystalReportViewer1.ReportSource = preporte





    End Sub

End Class