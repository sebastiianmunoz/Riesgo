Imports CrystalDecisions.Shared
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.IO

Public Class FCertificados

    Private Sub FCertificados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        ''Dim pvalor As New ParameterValues()
        ''Dim pvisual As New ParameterDiscreteValue()
        ''Dim preporte As New reporte()
        ''preporte.SetDatabaseLogon("sa", "universo")
        ' ''pvisual.Value = Reporte1.txtCodigo.Text
        ' ''pvalor.Add(pvisual)

        ' ''preporte.DataDefinition.ParameterFields("@codigo").ApplyCurrentValues(pvalor)

        ''Me.CrystalReportViewer1.ReportSource = preporte


        ''Dim pvalor As New ParameterValues()
        ''Dim pvisual As New ParameterDiscreteValue()
        ''Dim preporte As New reporte3()
        ''preporte.SetDatabaseLogon("sa", "universo")
        ''pvisual.Value = Integer.Parse(FrmCreditosPropios.txtId.Text)
        ''pvalor.Add(pvisual)

        ''preporte.DataDefinition.ParameterFields("@ID").ApplyCurrentValues(pvalor)


        '' Creo el parametro y asigno el nombre



        ''
        'Dim preporte As New reporte3()
        'Dim param As New ParameterField()
        'param.ParameterFieldName = "ID"

        ''
        '' creo el valor que se asignara al parametro
        ''
        'Dim discreteValue As New ParameterDiscreteValue()
        ''MsgBox(Integer.Parse(FrmCreditosPropios.txtId.Text))
        'discreteValue.Value = Integer.Parse(FrmCreditosPropios.txtId.Text)
        'param.CurrentValues.Add(discreteValue)

        ''
        '' Asigno el paramametro a la coleccion
        ''
        'Dim paramFiels As New ParameterFields()
        'paramFiels.Add(param)

        ''
        '' Asigno la coleccion de parametros al Crystal Viewer
        ''
        'CrystalReportViewer1.ParameterFieldInfo = paramFiels


        ''Dim rutadb As String = Path.Combine("LROSAS", "")
        ''preporte.DataSourceConnections(0).SetConnection("192.168.0.173", rutadb, False)

        'preporte.SetDatabaseLogon("sa", "universo")
        'Me.CrystalReportViewer1.ReportSource = preporte


        ' ''
        ' '' Creo el parametro y asigno el nombre
        ' ''
        ''Dim param As New ParameterField()
        ''param.ParameterFieldName = "CargoParam"

        ' ''
        ' '' creo el valor que se asignara al parametro
        ' ''
        ''Dim discreteValue As New ParameterDiscreteValue()
        ''discreteValue.Value = "Developer"
        ''param.CurrentValues.Add(discreteValue)

        ' ''
        ' '' Asigno el paramametro a la coleccion
        ' ''
        ''Dim paramFiels As New ParameterFields()
        ''paramFiels.Add(param)

        ' ''
        ' '' Asigno la coleccion de parametros al Crystal Viewer
        ' ''
        ''CrystalReportViewer1.ParameterFieldInfo = paramFiels

        ' ''
        ' '' Creo la instancia del reporte
        ' ''
        ''Dim report As New crListado()

        ' ''
        ' '' Cambio el path de la base de datos
        ' ''
        ''Dim rutadb As String = Path.Combine(Application.StartupPath, "TestDb.mdb")
        ''report.DataSourceConnections(0).SetConnection("", rutadb, False)

        ' ''
        ' '' Asigno el reporte a visor
        ' ''
        ''CrystalReportViewer1.ReportSource = report

        'aapp cpnfiog 
        '<startup><supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.0"/></startup><userSettings>









            Dim sucursal As String = ""

            Dim conexiones2 As New CConexion
            conexiones2.conexion()
            Dim command2 As SqlCommand = New SqlCommand("SELECT CARGO, SUCURSAL FROM _RIESGO_PERFIL WHERE USUARIO='" + frmPerfil.CbmUsuario.SelectedItem.ToString + "'", conexiones2._conexion)
            conexiones2.abrir()

            Dim reader2 As SqlDataReader = command2.ExecuteReader()


            If reader2.HasRows Then
                Do While reader2.Read()
                    sucursal = (reader2(1).ToString)
                Loop
            Else
            End If

            reader2.Close()








        'MsgBox(Trim(sucursal))

            'Reporte con parametro
        'If (Trim(sucursal) = "VALPARAÍSO") Then
        '    Dim preporte As New reporte()
        '    Dim param As New ParameterField()
        '    param.ParameterFieldName = "@ID"
        '    Dim discreteValue As New ParameterDiscreteValue()
        '    discreteValue.Value = Integer.Parse(FrmCreditosPropios.txtId.Text)
        '    param.CurrentValues.Add(discreteValue)
        '    Dim paramFiels As New ParameterFields()
        '    paramFiels.Add(param)
        '    CrystalReportViewer1.ParameterFieldInfo = paramFiels
        '    preporte.SetDatabaseLogon("sa", "universo")
        '    Me.CrystalReportViewer1.ReportSource = preporte
        '    'MsgBox("valparaiso")

        'Else
        Dim preporte As New reporte6()
        Dim param As New ParameterField()
        param.ParameterFieldName = "@ID"
        Dim discreteValue As New ParameterDiscreteValue()
        discreteValue.Value = Integer.Parse(FrmCreditosPropios.txtId.Text)
        'MsgBox(FrmCreditosPropios.txtId.Text)
        param.CurrentValues.Add(discreteValue)
        Dim paramFiels As New ParameterFields()
        paramFiels.Add(param)
        CrystalReportViewer1.ParameterFieldInfo = paramFiels
        preporte.SetDatabaseLogon("sa", "universo")
        Me.CrystalReportViewer1.ReportSource = preporte
        'MsgBox("viña")
        'End If









        'REPORTE SIN PARAMETRO

        'Dim preporte As New reporte5()
        'Dim param As New ParameterField()
        'preporte.SetDatabaseLogon("sa", "universo")
        'Me.CrystalReportViewer1.ReportSource = preporte












    End Sub


    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class