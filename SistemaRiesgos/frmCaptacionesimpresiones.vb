
Imports CrystalDecisions.Shared
Public Class frmCaptacionesimpresiones

    Private Sub fmrCaptaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'preporte.SetDatabaseLogon("sa", "universo", "192.168.0.173", "LROSAS")


        Dim pvalor As New ParameterValues()
        Dim pvisual As New ParameterDiscreteValue()
        Dim preporte As New ReporteCaptaciones()
        'Dim preporte1 As New ReporteCaptaciones1()
        preporte.SetDatabaseLogon("sa", "universo")
        pvisual.Value = Trim(frmCaptacionesGeneral.txtRUT.Text.ToString)
        pvalor.Add(pvisual)
        preporte.DataDefinition.ParameterFields("@RUT").ApplyCurrentValues(pvalor)
        'preporte.DataDefinition.ParameterFields("@RUT2").ApplyCurrentValues(pvalor)
        'preporte.DataDefinition.ParameterFields("@RUT(ReporteCaptaciones1.rpt)").ApplyCurrentValues(pvalor)
        Me.CrystalReportViewer1.ReportSource = preporte



        'MsgBox(frmCaptacionesGeneral.txtRUT.Text.ToString)

        'Dim preporte As New ReporteCaptaciones()
        'Dim param As New ParameterField()
        'param.ParameterFieldName = "@RUT"
        'Dim discreteValue As New ParameterDiscreteValue()
        'discreteValue.Value = Integer.Parse(frmCaptacionesGeneral.txtRUT.Text.ToString)
        'param.CurrentValues.Add(discreteValue)
        'Dim paramFiels As New ParameterFields()
        'paramFiels.Add(param)
        'CrystalReportViewer1.ParameterFieldInfo = paramFiels
        'preporte.SetDatabaseLogon("sa", "universo")
        'Me.CrystalReportViewer1.ReportSource = preporte

    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub
End Class