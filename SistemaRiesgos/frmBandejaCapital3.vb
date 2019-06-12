Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class frmBandejaCapital3
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter
    Public _tabla77 As DataTable = New DataTable
    Dim bandera As Boolean = True
    Dim TOMAFEHCACOMPELTA As String = DateTime.Now().ToShortDateString()  '"16/06/2009"
    Dim Plantillas2 As New CGenerales
    'Dim ruta = My.Computer.FileSystem.SpecialDirectories.Desktop & "\Nómina_Transferencia.txt"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Plantillas2.ExportarDatosExcel(Griddetallenomina, "Sistema de Riesgo")
    End Sub

    Private Sub frmBandejaCapital3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Griddetallenomina.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        _tabla77.Rows.Clear()
        _tabla77.Columns.Clear()
        Dim conexiones4 As New CConexion
        conexiones4.conexion()
        _adaptador.SelectCommand = New SqlCommand(" SELECT distinct NRO_NOMINA ,DETA.ID_SOLICITUD,DETA.FECHA_SOLICITUD,GIRO.ESTADO_SOLICITUD,'2' COD_PROVEEDOR,DETA.RUT,DETA.DVRUT  , replace( DETA.NOMBRES,'Ñ','N') as nombre ,REPLACE(DETA.PATERNO,'Ñ','N') as paterno ,REPLACE(DETA.MATERNO,'Ñ','N') AS materno,(select case when ( RTRIM(BANCO.CODBANCO) <> '012' and  (RTRIM(CUENTABANCO.CODIGO) ='CA' OR RTRIM(CUENTABANCO.CODIGO)='AV')   ) THEN '01'  WHEN  ( rtrim(banco.codbanco) ='012' and  ( RTRIM(CUENTABANCO.CODIGO) ='CA'   or RTRIM(CUENTABANCO.CODIGO)='AV') ) THEN '02'   when rtrim(banco.codbanco) <>'012' and RTRIM(CUENTABANCO.CODIGO) ='CE' then '01'   else  rtrim(CUENTABANCO.CODIGO_BANCO )END )  AS FORMA_PAGO ,(select case when BANCO.CODBANCO='029' then '001'else BANCO.CODBANCO end   ) AS CODIGO_BANCO , RTRIM(REPLACE(GIRO.[NRO_CUENTA],'-',''))as NRO_CUENTA,DETA.MONTO_SOLICITUD AS MONTO ,' ' as EMAIL,' 'AS CODIGO_PROPIO_EMPRESA,' 'AS SUCURSAL_BANCO_ESTADO,'26'as SECTOR_FINANCIERO FROM _RIESGO_DETA_NOMINA_TRANSFERENCIA AS DETA LEFT  JOIN [_RIESGO_SOLICITUD_GIRO_CAPITAL] AS GIRO     ON DETA.ID_SOLICITUD = GIRO.ID_SOLICITUD   LEFT JOIN [_TESORERIA_TIPO_CUENTA_BANCO] AS CUENTABANCO  ON CUENTABANCO.CODIGO  = GIRO.TIPO_CUENTA right  JOIN [_TESORERIA_BANCOS] AS BANCO  ON BANCO.CODBANCO = GIRO.CODBANCO WHERE NRO_NOMINA = " + Trim(frmBandejaCapital.Textid.Text) + " and  estado_en_nomina ='SELECCIONADO'   order by ID_SOLICITUD  asc ", conexiones4._conexion)
        conexiones4.abrir()
        _adaptador.Fill(_tabla77)
        Griddetallenomina.DataSource = _tabla77
        conexiones4.cerrar()
    End Sub

    Private Sub Generartxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Generartxt.Click
        Try
            Dim TOMAFEHCACOMPELTA As String = ""
            TOMAFEHCACOMPELTA = DateTime.Now().ToShortDateString()  '"16/06/2009"
            If bandera = True Then
                Dim sFile As String = "C:\Nominas\Nómina_Transferencia.txt"
                'Dim sFile As String = "C:\Nómina_Transferencia.txt"
                Dim _Line As String = Nothing
                If File.Exists(sFile) = True Then 'Si el archivo existe, lo elimina antes
                    My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                      FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
                End If
                Dim swFile As StreamWriter = New StreamWriter(sFile)
                With Griddetallenomina 'dgvLis es el nombre de mi DataGridView
                    For i = 0 To .RowCount - 1
                        _Line = Trim(.Rows(i).Cells(4).Value) & vbTab & _
                                Trim(.Rows(i).Cells(5).Value) & vbTab & _
                                Trim(.Rows(i).Cells(6).Value) & vbTab & _
                                Trim(.Rows(i).Cells(7).Value) & vbTab & _
                                Trim(.Rows(i).Cells(8).Value) & vbTab & _
                                Trim(.Rows(i).Cells(9).Value) & vbTab & _
                                Trim(.Rows(i).Cells(10).Value) & vbTab & _
                                Trim(.Rows(i).Cells(11).Value) & vbTab & _
                                Trim(.Rows(i).Cells(12).Value) & vbTab & _
                                Trim(.Rows(i).Cells(13).Value) & vbTab & _
                               "" & vbTab & _
                               "" & vbTab & _
                                "" & vbTab & _
                                      Trim(.Rows(i).Cells(17).Value) & vbTab & _
                                         "" & vbTab & _
                                            "" & vbTab & _
                                                 "" & vbTab & _
                                                  "" & vbTab & _
                                                   "" & vbTab & _
                                                    "" & vbTab & _
                                                     "" & vbTab & _
                                                      "" & vbTab & _
                                                       "" & vbTab & _
                                                        "" & vbTab & _
                                                         "" & vbTab & _
                                                          "" & vbTab & _
                                                           "" & vbTab & _
                                                            "" & vbTab & _
                                                          "" & vbTab & _
                                                          "" & vbTab & _
                                                          "" & vbTab & _
                                                          "" & vbTab & _
                                                          "" & vbTab & _
                                                          "" & vbTab & _
                                                          "" & vbTab & _
                                                          "" & vbTab
                        swFile.WriteLine(_Line)
                    Next
                End With
                swFile.Close()
            Else
                MsgBox("Cuenta Bancaria  con letra contactarse con el administrador ")
            End If
        Catch ex As Exception
            MsgBox("Error en el proceso")
        End Try
    End Sub
End Class