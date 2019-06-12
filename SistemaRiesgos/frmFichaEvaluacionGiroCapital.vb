Imports CrystalDecisions.Shared
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.IO
Public Class frmFichaEvaluacionGiroCapital

    Private Sub frmFichaEvaluacionGiroCapital_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ID_SOLICITUD_GIRO_CAPITAL()
        'SUBINFORME_MOVIMIENTOS7DIASATRAS()
        ' GENERAL()
        'Me.ReportViewer1.RefreshReport()
        'Me.ReportViewer1.RefreshReport()
        'Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub FichaEvaluacionGiroCapital1_InitReport(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FichaEvaluacionGiroCapital1.InitReport

    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub
    Sub GENERAL()
        'Dim preporte As New ReporteFichaEvaluacionGiroCapital()
        'Dim param As New ParameterField()
        'param.ParameterFieldName = "@ID_SOLICITUD"
        'Dim discreteValue As New ParameterDiscreteValue()
        ''MsgBox(frmBandejaCapital5.TextID.Text)
        'discreteValue.Value = Integer.Parse(frmBandejaCapital5.TextID.Text)
        ''MsgBox(discreteValue)
        'param.CurrentValues.Add(discreteValue)
        'Dim paramFiels As New ParameterFields()
        'paramFiels.Add(param)
        'Dim param1 As New ParameterField()
        'CrystalReportViewer1.ParameterFieldInfo = paramFiels
        ''preporte.SetDatabaseLogon("sa", "universo")
        'Me.CrystalReportViewer1.ReportSource = preporte











        'Dim preporte1 As New Giro_Capital_Movimiento_Ultimos7dias()

        'Dim param1, param2, param3 As New ParameterField()
        'param1.ParameterFieldName = "@FECHA_SOLICITUD"
        'param2.ParameterFieldName = "@FECHA_SOLICITUD_7DIAS_ATRAS"
        'param3.ParameterFieldName = "@NRO_SOCIO"


        'Dim discreteValue1, discreteValue2, discreteValue3 As New ParameterDiscreteValue()
        ''MsgBox(frmBandejaCapital5.TextID.Text)
        'discreteValue1.Value = Trim(frmBandejaCapital5.textfechasolicitud.Text)
        'discreteValue2.Value = Trim(frmBandejaCapital5.Textfecha7diasatras.Text)
        'discreteValue3.Value = Trim(frmBandejaCapital5.Textnorosico.Text)
        ''MsgBox(discreteValue)

        'param1.CurrentValues.Add(discreteValue1)
        'param2.CurrentValues.Add(discreteValue2)
        'param3.CurrentValues.Add(discreteValue3)

        'Dim paramFiels1 As New ParameterFields()

        'paramFiels1.Add(param1)
        'paramFiels1.Add(param2)
        'paramFiels1.Add(param3)


        'CrystalReportViewer1.ParameterFieldInfo = (paramFiels1)
        ''CrystalReportViewer1.ParameterFieldInfo = (paramFiels2)
        ''CrystalReportViewer1.ParameterFieldInfo = (paramFiels3)
        ''preporte.SetDatabaseLogon("sa", "universo")

        'Me.CrystalReportViewer1.ReportSource = preporte1
        'Me.CrystalReportViewer1.ReportSource = preporte

    End Sub


    Sub ID_SOLICITUD_GIRO_CAPITAL()

        'Dim preporte As New FichaEvaluacionGiroCapital()
        'Dim param As New ParameterField()
        'param.ParameterFieldName = "@ID_SOLICITUD"
        'Dim discreteValue As New ParameterDiscreteValue()
        'discreteValue.Value = Integer.Parse(frmBandejaCapital5.TextID.Text)
        'param.CurrentValues.Add(discreteValue)
        'Dim paramFiels As New ParameterFields()
        'paramFiels.Add(param)
        'CrystalReportViewer1.ParameterFieldInfo = paramFiels
        '' preporte.SetDatabaseLogon("sa", "universo")
        'Me.CrystalReportViewer1.ReportSource = preporte

        'Dim paramFiels1 As New ParameterFields()
        'Dim discreteValue1 As New ParameterDiscreteValue()
        'param1.ParameterFieldName = "@FECHA_SOLICITUD"
        'discreteValue1.Value = Trim(frmBandejaCapital5.textfechasolicitud.Text)

        'param1.CurrentValues.Add(discreteValue1)

        'paramFiels1.Add(param1)


        Dim preporte As New ReporteFichaEvaluacionGiroCapital()
        Dim variable As New ParameterDiscreteValue()

        Dim vvalor As New ParameterValues()
        Dim vvalor2 As New ParameterValues()
        Dim vvalor3 As New ParameterValues()
        'preporte.SetDatabaseLogon("sa", "universo")
        preporte.Refresh()

        variable.Value = Integer.Parse(frmBandejaCapital5.TextID.Text)
        vvalor.Add(variable)
        MsgBox(frmBandejaCapital5.TextID.Text)
        preporte.DataDefinition.ParameterFields("@ID_SOLICITUD").ApplyCurrentValues(vvalor)

        'MsgBox(frmBandejaCapital5.textfechasolicitud.Text)
        variable.Value = Trim(frmBandejaCapital5.textfechasolicitud.Text)
        vvalor2.Add(variable)
        preporte.DataDefinition.ParameterFields("@FECHA_SOLICITUD").ApplyCurrentValues(vvalor2)

        ' MsgBox(frmBandejaCapital5.Textfecha7diasatras.Text)
        variable.Value = Trim(frmBandejaCapital5.Textfecha7diasatras.Text)
        vvalor3.Add(variable)
        preporte.DataDefinition.ParameterFields("@FECHA_SOLICITUD_7DIAS_ATRAS").ApplyCurrentValues(vvalor3)

        preporte.SetDatabaseLogon("sa", "universo")
        Me.CrystalReportViewer1.ReportSource = preporte



        'Dim preporte As New FichaEvaluacionGiroCapital()
        'Dim param, param2 As New ParameterField()
        'param.ParameterFieldName = "@ID_SOLICITUD"
        'param2.ParameterFieldName = "fecha_solicitud2"

        'Dim discreteValue, discreteValue2 As New ParameterDiscreteValue()
        'discreteValue.Value = Integer.Parse(frmBandejaCapital5.TextID.Text)
        'discreteValue2.Value = Trim(frmBandejaCapital5.textfechasolicitud.Text)
        'param.CurrentValues.Add(discreteValue)
        'param2.CurrentValues.Add(discreteValue2)
        'Dim paramFiels, paramFiels2 As New ParameterFields()
        'paramFiels.Add(param)
        'paramFiels2.Add(param2)

        'CrystalReportViewer1.ParameterFieldInfo = paramFiels
        'CrystalReportViewer1.ParameterFieldInfo = paramFiels2
        '' preporte.SetDatabaseLogon("sa", "universo")
        'Me.CrystalReportViewer1.ReportSource = preporte



    End Sub

    Sub SUBINFORME_MOVIMIENTOS7DIASATRAS()
        Dim preporte1 As New ReporteFichaEvaluacionGiroCapital_Movimiento_Ultimos7dias()

        Dim param1, param2, param3 As New ParameterField()
        param1.ParameterFieldName = "@FECHA_SOLICITUD"
        param2.ParameterFieldName = "@FECHA_SOLICITUD_7DIAS_ATRAS"
        param3.ParameterFieldName = "@NRO_SOCIO"


        Dim discreteValue1, discreteValue2, discreteValue3 As New ParameterDiscreteValue()
        'MsgBox(frmBandejaCapital5.TextID.Text)
        discreteValue1.Value = Trim(frmBandejaCapital5.textfechasolicitud.Text)
        discreteValue2.Value = Trim(frmBandejaCapital5.Textfecha7diasatras.Text)
        discreteValue3.Value = Trim(frmBandejaCapital5.Textnorosico.Text)
        'MsgBox(discreteValue)

        param1.CurrentValues.Add(discreteValue1)
        param2.CurrentValues.Add(discreteValue2)
        param3.CurrentValues.Add(discreteValue3)



        Dim paramFiels1 As New ParameterFields()

        paramFiels1.Add(param1)
        paramFiels1.Add(param2)
        paramFiels1.Add(param3)


        CrystalReportViewer1.ParameterFieldInfo = (paramFiels1)
        'CrystalReportViewer1.ParameterFieldInfo = (paramFiels2)
        'CrystalReportViewer1.ParameterFieldInfo = (paramFiels3)
        'preporte.SetDatabaseLogon("sa", "universo")
        Me.CrystalReportViewer1.ReportSource = preporte1


        ' Me.Show()



    End Sub
End Class