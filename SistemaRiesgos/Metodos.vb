Imports System.Data.SqlClient

Public Class Metodos

    Dim conexiones As New CConexion
    Public _tabla As DataTable = New DataTable
    Public _tabla2 As DataTable = New DataTable
    Public _tabla3 As DataTable = New DataTable
    Public _tabla4 As DataTable = New DataTable
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter


    Public Function CargarDatos_combobox(ByVal datos As CDatos, ByVal cb As ComboBox) As Boolean
        Dim estado As Boolean = True
        Try
            cb.Items.Clear()
            conexiones.conexion()
            Dim command As SqlCommand = New SqlCommand(datos._Sql, conexiones._conexion)
            conexiones.abrir()
            Dim reader As SqlDataReader = command.ExecuteReader()
            If reader.HasRows Then
                Do While reader.Read()
                    cb.Items.Add(reader(0).ToString)
                Loop
            Else
            End If
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function


    'Public Function CargarDatos_combobox_conblancos(ByVal sql As String, ByVal cb As ComboBox) As Boolean
    '    Dim estado As Boolean = True
    '    Try

    '        cb.Items.Clear()
    '        cb.Items.Add("")
    '        conexiones.conexion()
    '        Dim command As SqlCommand = New SqlCommand(sql, conexiones._conexion)
    '        conexiones.abrir()
    '        Dim reader As SqlDataReader = command.ExecuteReader()
    '        If reader.HasRows Then
    '            Do While reader.Read()
    '                cb.Items.Add(reader(0).ToString)
    '            Loop
    '        Else
    '        End If
    '        cb.SelectedItem = ""
    '    Catch ex As SqlException
    '        estado = False
    '    Finally
    '        conexiones.cerrar()
    '    End Try
    '    Return estado
    'End Function

    Public Function CargarDatos_combobox_conblancos(ByVal datos As CDatos, ByVal cb As ComboBox) As Boolean
        Dim estado As Boolean = True
        Try
            cb.Items.Clear()
            cb.Items.Add("")
            conexiones.conexion()
            Dim command As SqlCommand = New SqlCommand(datos._Sql, conexiones._conexion)
            conexiones.abrir()
            Dim reader As SqlDataReader = command.ExecuteReader()
            If reader.HasRows Then
                Do While reader.Read()
                    cb.Items.Add(reader(0).ToString)
                Loop
            Else
            End If
            cb.SelectedItem = ""
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function


    'Public Function CargarDatos_combobox_conblancos2(ByVal datos As CDatos, ByVal cb As ComboBox) As Boolean
    '    Dim estado As Boolean = True
    '    Try

    '        cb.Items.Clear()
    '        'cb.Items.Add("")
    '        conexiones.conexion()
    '        Dim commandText As String = "@sql"

    '        Dim command As New SqlCommand(commandText, conexiones._conexion)
    '        command.Parameters.Add("@sql", SqlDbType.VarChar)
    '        command.Parameters("@sql").Value = datos._Sql
    '        'command.Parameters.Add("@sql", SqlDbType.VarChar).Value = datos._Sql
    '        conexiones.abrir()
    '        Dim reader As SqlDataReader = command.ExecuteReader()
    '        If reader.HasRows Then
    '            Do While reader.Read()
    '                cb.Items.Add(reader(0).ToString)
    '            Loop
    '        Else
    '        End If
    '        'cb.SelectedItem = ""
    '    Catch ex As SqlException
    '        estado = False
    '    Finally
    '        conexiones.cerrar()
    '    End Try
    '    Return estado
    'End Function


    Public Function Consultar_puntajes() As Boolean

        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT * from _riesgo_puntajes", conexiones._conexion)
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function
    Public Function Consultar_Rentas_TODOS() As Boolean

        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT TOP 100  [ID],[NROSOCIO],[FECHA],Usuario,FORMADEPAGO from _riesgo_RENTA order by ID desc", conexiones._conexion)
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function


    Public Function Consultar_RentasPERSONALXTodos(ByVal datos As CDatos) As Boolean

        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT TOP 100 [ID],[NROSOCIO],[FECHA],FORMADEPAGO from _riesgo_RENTA where Usuario=@perfil order by ID desc", conexiones._conexion)
            _adaptador.SelectCommand.Parameters.Add("@perfil", SqlDbType.VarChar, 50).Value = datos._Perfil
            _adaptador.SelectCommand.Parameters.Add("@FORMADEPAGO", SqlDbType.VarChar, 50).Value = datos._forpago
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function
    Public Function Consultar_RentasPERSONALXRenta(ByVal datos As CDatos) As Boolean

        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT TOP 100 [ID],[NROSOCIO],[FECHA],FORMADEPAGO from _riesgo_RENTA where Usuario=@perfil AND FORMADEPAGO=@FORMADEPAGO order by ID desc", conexiones._conexion)
            _adaptador.SelectCommand.Parameters.Add("@perfil", SqlDbType.VarChar, 50).Value = datos._Perfil
            _adaptador.SelectCommand.Parameters.Add("@FORMADEPAGO", SqlDbType.VarChar, 50).Value = datos._forpago
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function

    Public Function Consultar_RentasPERSONALXNrosocio(ByVal datos As CDatos) As Boolean

        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT TOP 100 [ID],[NROSOCIO],[FECHA],FORMADEPAGO from _riesgo_RENTA where Usuario=@perfil AND NROSOCIO=@NROSOCIO order by ID desc", conexiones._conexion)
            _adaptador.SelectCommand.Parameters.Add("@perfil", SqlDbType.VarChar, 50).Value = datos._Perfil
            _adaptador.SelectCommand.Parameters.Add("@NROSOCIO", SqlDbType.VarChar, 50).Value = datos._Nrosocio
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function
    Public Function Consultar_RentasPERSONALXID(ByVal datos As CDatos) As Boolean

        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT TOP 100 [ID],[NROSOCIO],[FECHA],FORMADEPAGO from _riesgo_RENTA where Usuario=@perfil AND ID=@id order by ID desc", conexiones._conexion)
            _adaptador.SelectCommand.Parameters.Add("@perfil", SqlDbType.VarChar, 50).Value = datos._Perfil
            _adaptador.SelectCommand.Parameters.Add("@id", SqlDbType.VarChar, 50).Value = datos._ID_RENTA
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function

    Public Function Consultar_RentasxID(ByVal datos As CDatos) As Boolean

        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT TOP 100 [ID],[NROSOCIO],[FECHA] from _riesgo_RENTA where ID=@ID_RENTA", conexiones._conexion)
            _adaptador.SelectCommand.Parameters.Add("@ID_RENTA", SqlDbType.VarChar, 50).Value = datos._ID_RENTA
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function


    Public Function Consultar_puntajes2() As Boolean

        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("  SELECT Tipo,Categoria,Rango1,Rango2,[Bueno],[Malo],round(CAST ([Bueno]*100/([Bueno]+[Malo] )AS decimal (6,2) ),2)AS PORCENTAJE_BUENO  ,round(CAST ([Malo]*100/([Bueno]+[Malo] )AS decimal (6,2) ),2)AS PORCENTAJE_MALO  , CAST ((([Malo]*100/([Bueno]+[Malo])/(select sum(malo)*100/(sum([Bueno]+[Malo])) FROM [_RIESGO_SCORING2] AS CC1X INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2X ON CC1X.ID_TIPO=CC2X.ID_TIPO AND CC1X.id_tabla =CC2X.id_tabla  where cc1X.tipo=cc1.tipo and cc1X.categoria=cc1.categoria and cc1X.subcategoria='NO'))-1 )*100 AS decimal (6,2) ) as INDICE   , [Bueno]+[Malo] as total   ,[SubCategoria]  ,[numerico] ,cc1.id_tabla ,CC1.ID_TIPO FROM [_RIESGO_SCORING2] AS CC1 INNER JOIN (SELECT ID_TIPO, MAX(ID_TABLA) AS ID_TABLA FROM _RIESGO_SCORING2 GROUP BY ID_TIPO) AS CC2 ON CC1.ID_TIPO=CC2.ID_TIPO AND CC1.id_tabla =CC2.id_tabla", conexiones._conexion)
            _adaptador.Fill(_tabla2)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function

    Public Function Consultar_puntajesxAnalisis(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT * from _riesgo_puntajes where analisis=@analisis", conexiones._conexion)
            _adaptador.SelectCommand.Parameters.Add("@analisis", SqlDbType.VarChar, 50).Value = datos._Analisis
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function

    Public Function Consultar_Comportamiento(ByVal datos As CDatos) As Boolean

        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT MES,ESTADO AS CLASIFICACION,abona_prestamo AS ABONO_CAPITAL FROM _Riesgo_Comportamiento_pago where USUARIO =@usuario  AND RUT =@rut ORDER BY MES DESC ", conexiones._conexion)
            _adaptador.SelectCommand.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = datos._Compromiso_Usuario
            _adaptador.SelectCommand.Parameters.Add("@rut", SqlDbType.NVarChar).Value = datos._Compromiso_Rut
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function
    Public Function Consultar_Perfiles() As Boolean

        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT  [COD_PERFIL],[NOMBRE],[USUARIO],[DEPARTAMENTO],[PERMISOS],RTRIM([CIUDAD])+' - '+RTRIM(NOMBRECAJA),[CARGO],[ATRIBUTO] ,dbo.FU_DESENCRIPTA( [ENPERMISOS]),ATRIBUTOS_AUTORIZA FROM [_RIESGO_PERFIL]  inner join (SELECT * FROM [_SUCURSAL] WHERE VIGENTE=1) as  _SUCURSAL ON _RIESGO_PERFIL.UBICACION=_SUCURSAL.CODCAJA order by NOMBRE desc ", conexiones._conexion)
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function


    Public Function Consultar_Informacion_prepagos(ByVal datos As CDatos) As Boolean

        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("select CC1.NROSOCIO as [NRO PRESTAMO],cc3.DESCRIPCION as [TIPO DE CREDITO],CONVERT(DATE,FECHAPRESTAMO) as [FECHA PRESTAMO], DBO.PUNTOS(MONTOPRESTAMO) as [MONTO PRESTAMO],PLAZO,TAZAINTERES as [TASA INTERES],RENEGOCIACION-1 as [NRO RENEGOCIACION],CASE WHEN AVAL1=0 THEN 'SIN AVAL' ELSE CONVERT(VARCHAR, AVAL1) END  as [RUT AVAL 1],CASE WHEN AVAL2=0 THEN 'SIN AVAL' ELSE CONVERT(VARCHAR, AVAL2) END as [RUT AVAL 2],UPPER(cc4.DESCRIPCION) as [FORMA DE PAGO] ,'CORFO'= CASE WHEN COMICORFO<>'' THEN 'SI' ELSE 'NO' END  from _prestdiario as cc1 LEFT join _NOMBRECREDITO as cc3 on cc1.RECONSTRU=cc3.CODNOM LEFT join _FORMAPAGO as cc4 on cc1.FORMADEPAGO=cc4.CODFOR where CC1.corcredito in ( (SELECT rtrim(substring([NroPrepagos],1,10)) FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where id_solicitud = @IDSOLICITUD), (SELECT rtrim(substring([NroPrepagos],11,10)) FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where id_solicitud =@IDSOLICITUD), (SELECT rtrim(substring([NroPrepagos],21,10))  FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where id_solicitud =@IDSOLICITUD)) AND ESTADO='C'", conexiones._conexion)
            _adaptador.SelectCommand.Parameters.Add("@IDSOLICITUD", SqlDbType.Int, 50).Value = datos._idprestamo2
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function

    Public Function Agregar_Prestamos_Deudas() As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT id_solicitud,Nrosocio,producto,objetivo, monto_solicitado,NroPrepagos,LVL,Puntaje,Capacidad,Comentario_Riesgo,Comentario_Agencia,Comentario_Ejecutiva,Comentario_SubGerente,Comentario_Gerente,Aprobacion_Operaciones,Aprobacion_SubGerencia,Aprobacion_Gerencia FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where Nrosocio in (SELECT distinct(R.[Nrosocio])  FROM [_RIESGO_PRESTAMOS_SOLICITADOS]  AS R INNER JOIN  _COBRANZA_TABLA AS C ON R.Nrosocio=C.NROSOCIO where R.Estado='APROBADO' AND C.ESTADO<>'Cancelado' and MESES>1 and objetivo<>'Renegociación') AND Estado='APROBADO'", conexiones._conexion)
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function

    Public Function Agregar_EjecutivoAprobados_Rechazados() As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT CASE GROUPING(r.Estado) WHEN 1 THEN ''ELSE r.Estado END AS 'GRUPO',CASE GROUPING(p.NOMBRE) WHEN 1 THEN 'TOTAL' ELSE p.NOMBRE END AS 'NOMBRES', COUNT(p.NOMBRE)  AS 'TOTAL ERRORES' FROM [_RIESGO_PRESTAMOS_SOLICITADOS] as r inner join _RIESGO_PERFIL as p on r.Ejecutiva=p.USUARIO where r.Estado in ('APROBADO','RECHAZADO')  group by p.NOMBRE ,r.Estado  ORDER BY  P.NOMBRE", conexiones._conexion)
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function
    Public Function Agregar_EjecutivosRealizados() As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("  SELECT  CASE GROUPING(p.NOMBRE) WHEN 1 THEN 'TOTAL' ELSE p.NOMBRE END AS 'NOMBRES', COUNT(p.NOMBRE)  AS 'TOTAL CREDITOS' FROM [_RIESGO_PRESTAMOS_SOLICITADOS] as r inner join _RIESGO_PERFIL as p on r.Ejecutiva=p.USUARIO where r.Estado not in ('DESCARTADO','DESCARTADOASALINAS(R)','DESCARTADOASALINAS','DESCARTADOCAGUILAR')  group by p.NOMBRE  WITH ROLLUP ORDER BY  COUNT(p.NOMBRE) DESC ", conexiones._conexion)
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function


    Public Function Agregar_EjecutivosDescartados() As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT  CASE GROUPING(p.NOMBRE) WHEN 1 THEN 'TOTAL' ELSE p.NOMBRE END AS 'NOMBRES', COUNT(p.NOMBRE)  AS 'TOTAL ERRORES' FROM [_RIESGO_PRESTAMOS_SOLICITADOS] as r inner join _RIESGO_PERFIL as p on r.Ejecutiva=p.USUARIO where r.Estado in ('DESCARTADO','DESCARTADOASALINAS(R)','DESCARTADOASALINAS','DESCARTADOCAGUILAR')  group by p.NOMBRE  WITH ROLLUP ORDER BY  COUNT(p.NOMBRE) DESC ", conexiones._conexion)
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function

    Public Function Consultar_prestamos_historicosXCorcredito(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT [id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Estado],Nombre,Ejecutiva,case when PreAprobacion_Agente='' then 'Por Analizar' else PreAprobacion_Agente end as PreAprobacion_Agente,PreAprobacion_Riesgo,[Aprobacion_Operaciones],[Aprobacion_SubGerencia],[Aprobacion_Gerencia],[Aprobacion_Comision_Credito_Interno],[Aprobacion_Comision_Credito_Superior],ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_preagencia],1,19)),0) AS TIEMPO_PREAGENCIA,ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_riesgo],1,19)),0) AS TIEMPO_RIESGO,ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_agencia],1,19)),0) AS TIEMPO_AGENCIA , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([fecha_subgerente],1,19)),0) AS TIEMPO_SUBGERENTE , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_gerencia],1,19)),0) AS TIEMPO_GERENTE, ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_CCI],1,19)),0) AS TIEMPO_CCI, ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_ccs],1,19)),0) AS TIEMPO_CCS,ISNULL([PreAgencia_Perfil],'') as PreAgencia_Perfil,ISNULL([Riesgo_perfil],'')as  Riesgo_perfil,ISNULL([Agencia_Perfil],'') as  Agencia_Perfil,ISNULL([Subgerencia_Perfil],'')as Subgerencia_Perfil,ISNULL([Gerencia_Perfil],'')as Gerencia_Perfil,ISNULL([CCI_Perfil],'')as  CCI_Perfil,ISNULL([CCS_perfil],'')as CCS_perfil  ,isnull(corcredito,'') as corcredito,ISNULL((SELECT [HORAMODIFICACION] FROM [_PRESTDIARIO] WHERE CORCREDITO= _RIESGO_PRESTAMOS_SOLICITADOS.CORCREDITO ),'') AS HORAMODIFICACION,forpago,Formadepago2 FROM _RIESGO_PRESTAMOS_SOLICITADOS where ISNULL(corcredito,'')= @corcredito order by fecha_solicitud desc ", conexiones._conexion)
            _adaptador.SelectCommand.Parameters.Add("@corcredito", SqlDbType.VarChar, 50).Value = datos._Corcredito
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function


    Public Function Consultar_prestamos_historicosXNrosocio(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT [id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Estado],Nombre,Ejecutiva,case when PreAprobacion_Agente='' then 'Por Analizar' else PreAprobacion_Agente end as PreAprobacion_Agente,PreAprobacion_Riesgo,[Aprobacion_Operaciones],[Aprobacion_SubGerencia],[Aprobacion_Gerencia],[Aprobacion_Comision_Credito_Interno],[Aprobacion_Comision_Credito_Superior],ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_preagencia],1,19)),0) AS TIEMPO_PREAGENCIA,ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_riesgo],1,19)),0) AS TIEMPO_RIESGO,ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_agencia],1,19)),0) AS TIEMPO_AGENCIA , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([fecha_subgerente],1,19)),0) AS TIEMPO_SUBGERENTE , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_gerencia],1,19)),0) AS TIEMPO_GERENTE, ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_CCI],1,19)),0) AS TIEMPO_CCI, ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_ccs],1,19)),0) AS TIEMPO_CCS,ISNULL([PreAgencia_Perfil],'') as PreAgencia_Perfil,ISNULL([Riesgo_perfil],'')as  Riesgo_perfil,ISNULL([Agencia_Perfil],'') as  Agencia_Perfil,ISNULL([Subgerencia_Perfil],'')as Subgerencia_Perfil,ISNULL([Gerencia_Perfil],'')as Gerencia_Perfil,ISNULL([CCI_Perfil],'')as  CCI_Perfil,ISNULL([CCS_perfil],'')as CCS_perfil  ,isnull(corcredito,'') as corcredito , ISNULL((SELECT [HORAMODIFICACION] FROM [_PRESTDIARIO] WHERE CORCREDITO= _RIESGO_PRESTAMOS_SOLICITADOS.CORCREDITO ),'') AS HORAMODIFICACION,forpago,Formadepago2 FROM _RIESGO_PRESTAMOS_SOLICITADOS where [Nrosocio]= @Nrosocio order by fecha_solicitud desc ", conexiones._conexion)
            _adaptador.SelectCommand.Parameters.Add("@Nrosocio", SqlDbType.VarChar, 50).Value = datos._Nrosocio
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function
    Public Function Consultar_prestamos_historicosXid(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT [id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Estado],Nombre,Ejecutiva,case when PreAprobacion_Agente='' then 'Por Analizar' else PreAprobacion_Agente end as PreAprobacion_Agente,PreAprobacion_Riesgo,[Aprobacion_Operaciones],[Aprobacion_SubGerencia],[Aprobacion_Gerencia],[Aprobacion_Comision_Credito_Interno],[Aprobacion_Comision_Credito_Superior],ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_preagencia],1,19)),0) AS TIEMPO_PREAGENCIA,ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_riesgo],1,19)),0) AS TIEMPO_RIESGO,ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_agencia],1,19)),0) AS TIEMPO_AGENCIA , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([fecha_subgerente],1,19)),0) AS TIEMPO_SUBGERENTE , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_gerencia],1,19)),0) AS TIEMPO_GERENTE, ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_CCI],1,19)),0) AS TIEMPO_CCI, ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_ccs],1,19)),0) AS TIEMPO_CCS,ISNULL([PreAgencia_Perfil],'') as PreAgencia_Perfil,ISNULL([Riesgo_perfil],'')as  Riesgo_perfil,ISNULL([Agencia_Perfil],'') as  Agencia_Perfil,ISNULL([Subgerencia_Perfil],'')as Subgerencia_Perfil,ISNULL([Gerencia_Perfil],'')as Gerencia_Perfil,ISNULL([CCI_Perfil],'')as  CCI_Perfil,ISNULL([CCS_perfil],'')as CCS_perfil  ,isnull(corcredito,'') as corcredito , ISNULL((SELECT [HORAMODIFICACION] FROM [_PRESTDIARIO] WHERE CORCREDITO= _RIESGO_PRESTAMOS_SOLICITADOS.CORCREDITO ),'') AS HORAMODIFICACION,forpago,Formadepago2 FROM _RIESGO_PRESTAMOS_SOLICITADOS where id_solicitud= @id_solicitud ", conexiones._conexion)
            _adaptador.SelectCommand.Parameters.Add("@id_solicitud", SqlDbType.VarChar, 50).Value = datos._id_solicitud
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function


    Public Function Consultar_prestamos_historicosXforpago(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT top 100  [id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Estado],Nombre,Ejecutiva,case when PreAprobacion_Agente='' then 'Por Analizar' else PreAprobacion_Agente end as PreAprobacion_Agente,PreAprobacion_Riesgo,[Aprobacion_Operaciones],[Aprobacion_SubGerencia],[Aprobacion_Gerencia],[Aprobacion_Comision_Credito_Interno],[Aprobacion_Comision_Credito_Superior],ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_preagencia],1,19)),0) AS TIEMPO_PREAGENCIA,ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_riesgo],1,19)),0) AS TIEMPO_RIESGO,ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_agencia],1,19)),0) AS TIEMPO_AGENCIA , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([fecha_subgerente],1,19)),0) AS TIEMPO_SUBGERENTE , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_gerencia],1,19)),0) AS TIEMPO_GERENTE, ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_CCI],1,19)),0) AS TIEMPO_CCI, ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_ccs],1,19)),0) AS TIEMPO_CCS,ISNULL([PreAgencia_Perfil],'') as PreAgencia_Perfil,ISNULL([Riesgo_perfil],'')as  Riesgo_perfil,ISNULL([Agencia_Perfil],'') as  Agencia_Perfil,ISNULL([Subgerencia_Perfil],'')as Subgerencia_Perfil,ISNULL([Gerencia_Perfil],'')as Gerencia_Perfil,ISNULL([CCI_Perfil],'')as  CCI_Perfil,ISNULL([CCS_perfil],'')as CCS_perfil  ,isnull(corcredito,'') as corcredito , ISNULL((SELECT [HORAMODIFICACION] FROM [_PRESTDIARIO] WHERE CORCREDITO= _RIESGO_PRESTAMOS_SOLICITADOS.CORCREDITO ),'') AS HORAMODIFICACION,forpago,Formadepago2 FROM _RIESGO_PRESTAMOS_SOLICITADOS where forpago= @forpago order by fecha_solicitud desc", conexiones._conexion)
            _adaptador.SelectCommand.Parameters.Add("@forpago", SqlDbType.VarChar, 50).Value = datos._forpago
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function

    Public Function Consultar_prestamos_historicosXNOMBRE(ByVal nombre As String) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT [id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Estado],Nombre,Ejecutiva,case when PreAprobacion_Agente='' then 'Por Analizar' else PreAprobacion_Agente end as PreAprobacion_Agente,PreAprobacion_Riesgo,[Aprobacion_Operaciones],[Aprobacion_SubGerencia],[Aprobacion_Gerencia],[Aprobacion_Comision_Credito_Interno],[Aprobacion_Comision_Credito_Superior],ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_preagencia],1,19)),0) AS TIEMPO_PREAGENCIA,ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_riesgo],1,19)),0) AS TIEMPO_RIESGO,ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_agencia],1,19)),0) AS TIEMPO_AGENCIA , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([fecha_subgerente],1,19)),0) AS TIEMPO_SUBGERENTE , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_gerencia],1,19)),0) AS TIEMPO_GERENTE, ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_CCI],1,19)),0) AS TIEMPO_CCI, ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_ccs],1,19)),0) AS TIEMPO_CCS,ISNULL([PreAgencia_Perfil],'') as PreAgencia_Perfil,ISNULL([Riesgo_perfil],'')as  Riesgo_perfil,ISNULL([Agencia_Perfil],'') as  Agencia_Perfil,ISNULL([Subgerencia_Perfil],'')as Subgerencia_Perfil,ISNULL([Gerencia_Perfil],'')as Gerencia_Perfil,ISNULL([CCI_Perfil],'')as  CCI_Perfil,ISNULL([CCS_perfil],'')as CCS_perfil  ,isnull(corcredito,'') as corcredito , ISNULL((SELECT [HORAMODIFICACION] FROM [_PRESTDIARIO] WHERE CORCREDITO= _RIESGO_PRESTAMOS_SOLICITADOS.CORCREDITO ),'') AS HORAMODIFICACION,forpago,Formadepago2 FROM _RIESGO_PRESTAMOS_SOLICITADOS where Nombre LIKE '%" + nombre + "%' ", conexiones._conexion)
            '_adaptador.SelectCommand.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 50).Value = datos._Nombre
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function

    Public Function Consultar_prestamos_historicos() As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT top 100 [id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Estado],Nombre,Ejecutiva,case when PreAprobacion_Agente='' then 'Por Analizar' else PreAprobacion_Agente end as PreAprobacion_Agente,PreAprobacion_Riesgo,[Aprobacion_Operaciones],[Aprobacion_SubGerencia],[Aprobacion_Gerencia],[Aprobacion_Comision_Credito_Interno],[Aprobacion_Comision_Credito_Superior],ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_preagencia],1,19)),0) AS TIEMPO_PREAGENCIA,ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_riesgo],1,19)),0) AS TIEMPO_RIESGO,ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_agencia],1,19)),0) AS TIEMPO_AGENCIA , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([fecha_subgerente],1,19)),0) AS TIEMPO_SUBGERENTE , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_gerencia],1,19)),0) AS TIEMPO_GERENTE, ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_CCI],1,19)),0) AS TIEMPO_CCI, ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING([Fecha_ccs],1,19)),0) AS TIEMPO_CCS,ISNULL([PreAgencia_Perfil],'') as PreAgencia_Perfil,ISNULL([Riesgo_perfil],'')as  Riesgo_perfil,ISNULL([Agencia_Perfil],'') as  Agencia_Perfil,ISNULL([Subgerencia_Perfil],'')as Subgerencia_Perfil,ISNULL([Gerencia_Perfil],'')as Gerencia_Perfil,ISNULL([CCI_Perfil],'')as  CCI_Perfil,ISNULL([CCS_perfil],'')as CCS_perfil  ,isnull(corcredito,'') as corcredito , ISNULL((SELECT [HORAMODIFICACION] FROM [_PRESTDIARIO] WHERE CORCREDITO= _RIESGO_PRESTAMOS_SOLICITADOS.CORCREDITO ),'') AS HORAMODIFICACION,forpago,Formadepago2 FROM _RIESGO_PRESTAMOS_SOLICITADOS order by fecha_solicitud desc", conexiones._conexion)
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function



    Public Function Consultar_prestamos_personales(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT [id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[Sucursal],[Estado],[Aprobacion_Operaciones],[Aprobacion_SubGerencia],[Aprobacion_Gerencia],[Aprobacion_Comision_Credito_Interno],[Aprobacion_Comision_Credito_Superior] , PreAprobacion_Agente FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where [Ejecutiva]=@Ejecutiva order by fecha_solicitud desc", conexiones._conexion)
            _adaptador.SelectCommand.Parameters.Add("@Ejecutiva", SqlDbType.VarChar, 50).Value = datos._Ejecutiva
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function

    'FUNCION QUE ENTREGA TODOS LOS DATOS DE LA TABLA_COBRANZA

    Public Function Consultar_Creditos_Riesgo() As Boolean

        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            '_adaptador.SelectCommand = New SqlCommand(" SELECT [id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Ejecutiva],[Sucursal],Estado,Aprobacion_Gerencia,Aprobacion_SubGerencia,Aprobacion_Operaciones,Aprobacion_Comision_Credito_Interno,Aprobacion_Comision_Credito_Superior , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING(convert(varchar,getdate()),1,19)),'') as tiempo , PreAprobacion_Agente ,PreAprobacion_Riesgo,FueraDeZona FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where PreAprobacion_Riesgo='Por Analizar' and PreAprobacion_Agente in ('LIBERADO SIN OBJECIONES','LIBERADO CON OBJECIONES','NO VALIDA') ", conexiones._conexion)
            _adaptador.SelectCommand = New SqlCommand(" SELECT Atencion,[id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Ejecutiva],Riesgo_Renta_Verifica As Renta,[Sucursal],Estado,Aprobacion_Gerencia,Aprobacion_SubGerencia,Aprobacion_Operaciones,Aprobacion_Comision_Credito_Interno,Aprobacion_Comision_Credito_Superior , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING(convert(varchar,getdate()),1,19)),'') as tiempo , PreAprobacion_Agente ,PreAprobacion_Riesgo,FueraDeZona FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where PreAprobacion_Riesgo='Por Analizar' and PreAprobacion_Agente in ('LIBERADO SIN OBJECIONES','LIBERADO CON OBJECIONES','NO VALIDA') order by atencion desc ", conexiones._conexion)
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function

    Public Function Consultar_Creditos_Riesgo_Renta() As Boolean

        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            '_adaptador.SelectCommand = New SqlCommand(" SELECT [id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Ejecutiva],[Sucursal],Estado,Aprobacion_Gerencia,Aprobacion_SubGerencia,Aprobacion_Operaciones,Aprobacion_Comision_Credito_Interno,Aprobacion_Comision_Credito_Superior , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING(convert(varchar,getdate()),1,19)),'') as tiempo , PreAprobacion_Agente ,PreAprobacion_Riesgo,FueraDeZona FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where PreAprobacion_Riesgo='Por Analizar' and PreAprobacion_Agente in ('LIBERADO SIN OBJECIONES','LIBERADO CON OBJECIONES','NO VALIDA') ", conexiones._conexion)
            _adaptador.SelectCommand = New SqlCommand("SELECT Atencion,[id_solicitud],Riesgo_Renta_Verifica As Renta,[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Ejecutiva],[Sucursal],Estado,Aprobacion_Gerencia,Aprobacion_SubGerencia,Aprobacion_Operaciones,Aprobacion_Comision_Credito_Interno,Aprobacion_Comision_Credito_Superior , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING(convert(varchar,getdate()),1,19)),'') as tiempo , PreAprobacion_Agente ,PreAprobacion_Riesgo,FueraDeZona FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where (PreAprobacion_Riesgo='Por Analizar' or PreAprobacion_Agente='Por Analizar') and estado NOT IN ('DESCARTADO','NO LIBERADO') order by atencion desc", conexiones._conexion)
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function
    Public Function Consultar_Creditos_Aprobar() As Boolean

        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("  SELECT Atencion,[id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Ejecutiva],[Sucursal],Estado,Aprobacion_Gerencia,Aprobacion_SubGerencia,Aprobacion_Operaciones,Aprobacion_Comision_Credito_Interno,Aprobacion_Comision_Credito_Superior , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING(convert(varchar,getdate()),1,19)),'') as tiempo , PreAprobacion_Agente ,PreAprobacion_Riesgo,FueraDeZona FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where Estado in ('Enviado por Dep.riesgo como RECOMENDADO','Enviado por Dep.riesgo como RECOMENDADO CONDICIONAL','Enviado por Dep.riesgo como NO RECOMENDADO','Enviado de Ejecutivos para aprobación') and PreAprobacion_Agente in ('LIBERADO SIN OBJECIONES','LIBERADO CON OBJECIONES','NO VALIDA') ", conexiones._conexion)
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function


    Public Function Consultar_Creditos_AprobarXTipoAgencia(ByVal tipo As String, ByVal SUCURSAL As String, ByVal ciudad As String) As Boolean

        Dim estado As Boolean = True
        Try
            conexiones.conexion()

            'MsgBox()
            Dim sql As String = ""
            sql = "SELECT Atencion,[id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Ejecutiva],[Sucursal],Estado,Aprobacion_Gerencia,Aprobacion_SubGerencia,Aprobacion_Operaciones,Aprobacion_Comision_Credito_Interno,Aprobacion_Comision_Credito_Superior , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING(convert(varchar,getdate()),1,19)),'') as tiempo , PreAprobacion_Agente ,PreAprobacion_Riesgo , FueraDeZona  FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where Aprobacion_Operaciones ='Por Analizar' AND SUCURSAL='" + ciudad + "' and SEDE='" + SUCURSAL + "' AND Estado in ('Enviado por Dep.riesgo como RECOMENDADO','Enviado por Dep.riesgo como RECOMENDADO CONDICIONAL','Enviado por Dep.riesgo como NO RECOMENDADO','Enviado de Ejecutivos para aprobación') and PreAprobacion_Agente in ('LIBERADO SIN OBJECIONES','LIBERADO CON OBJECIONES','NO VALIDA') and rtrim(PreAprobacion_Agente) <>''	 UNION ALL "
            sql = sql + " SELECT Atencion,[id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Ejecutiva],[Sucursal],Estado,Aprobacion_Gerencia,Aprobacion_SubGerencia,Aprobacion_Operaciones,Aprobacion_Comision_Credito_Interno,Aprobacion_Comision_Credito_Superior , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING(convert(varchar,getdate()),1,19)),'') as tiempo,PreAprobacion_Agente ,PreAprobacion_Riesgo ,fueradezona  FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where   SUCURSAL='" + ciudad + "' and SEDE='" + SUCURSAL + "'  AND Estado in ('Enviado a Agente para su Liberación','Enviado de Ejecutivos para aprobación') and PreAprobacion_Agente ='Por Analizar'  UNION ALL "
            sql = sql + " SELECT  [Atencion],[ID_SOLICITUD],[NROSOCIO],SUBSTRING(convert(varchar,[fecha_solicitud]),1,16) AS Fecha_Solicitud,producto,dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Ejecutivo],sede AS [Sucursal] ,[Estado],'No Verifica','No Verifica',[Aprobacion_Operaciones],'No Verifica','No Verifica',ISNULL(DATEDIFF(minute,SUBSTRING(convert(varchar,[fecha_solicitud]),1,19),SUBSTRING(convert(varchar,getdate()),1,19)),'') as tiempo ,'NO VALIDA','No Verifica','No Verifica' FROM _RIESGO_SOLICITUD_PREPAGO where Estado='Enviado a Agente para su Liberación' and Aprobacion_Operaciones='Por Analizar' and sede='" + SUCURSAL + "' "


            '_adaptador.SelectCommand = New SqlCommand("  SELECT [id_solicitud],[Nrosocio],[fecha_solicitud],[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Ejecutiva],[Sucursal],Estado,Aprobacion_Gerencia,Aprobacion_SubGerencia,Aprobacion_Operaciones,Aprobacion_Comision_Credito_Interno,Aprobacion_Comision_Credito_Superior , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING(convert(varchar,getdate()),1,19)),'') as tiempo  FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where " + tipo + " ='Por Analizar' AND SUCURSAL='" + SUCURSAL + "'  AND Estado in ('Enviado por Dep.riesgo como RECOMENDADO','Enviado por Dep.riesgo como NO RECOMENDADO','Enviado de Ejecutivos para aprobación') and PreAprobacion_Agente in ('LIBERADO','LIBERADO CON OBJECION')  ", conexiones._conexion)
            _adaptador.SelectCommand = New SqlCommand(sql, conexiones._conexion)
            '_adaptador.SelectCommand = New SqlCommand("  SELECT [id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Ejecutiva],[Sucursal],Estado,Aprobacion_Gerencia,Aprobacion_SubGerencia,Aprobacion_Operaciones,Aprobacion_Comision_Credito_Interno,Aprobacion_Comision_Credito_Superior , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING(convert(varchar,getdate()),1,19)),'') as tiempo , PreAprobacion_Agente ,PreAprobacion_Riesgo , FueraDeZona  FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where Aprobacion_Operaciones ='Por Analizar' AND SUCURSAL='" + ciudad + "' and SEDE='" + SUCURSAL + "' AND Estado in ('Enviado por Dep.riesgo como RECOMENDADO','Enviado por Dep.riesgo como NO RECOMENDADO','Enviado de Ejecutivos para aprobación') and PreAprobacion_Agente in ('LIBERADO SIN OBJECIONES','LIBERADO CON OBJECIONES','NO VALIDA') and rtrim(PreAprobacion_Agente) <>''	 UNION ALL  SELECT [id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Ejecutiva],[Sucursal],Estado,Aprobacion_Gerencia,Aprobacion_SubGerencia,Aprobacion_Operaciones,Aprobacion_Comision_Credito_Interno,Aprobacion_Comision_Credito_Superior , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING(convert(varchar,getdate()),1,19)),'') as tiempo,PreAprobacion_Agente ,PreAprobacion_Riesgo ,fueradezona  FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where   SUCURSAL='" + ciudad + "' and SEDE='" + SUCURSAL + "'   and PreAprobacion_Agente ='Por Analizar' ", conexiones._conexion)
            '_adaptador.SelectCommand = New SqlCommand("SELECT [id_solicitud],[Nrosocio],[fecha_solicitud],[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Ejecutiva],[Sucursal],Estado,Aprobacion_Gerencia,Aprobacion_SubGerencia,Aprobacion_Operaciones,Aprobacion_Comision_Credito_Interno,Aprobacion_Comision_Credito_Superior , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING(convert(varchar,getdate()),1,19)),'') as tiempo , PreAprobacion_Agente ,PreAprobacion_Riesgo  FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where  SUCURSAL='" + SUCURSAL + "'  AND Estado in ('Enviado por Dep.riesgo como RECOMENDADO','Enviado por Dep.riesgo como NO RECOMENDADO','Enviado de Ejecutivos para aprobación') and rtrim(PreAprobacion_Agente) =''  ", conexiones._conexion)
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function
    Public Function Consultar_Creditos_AprobarXTipo(ByVal tipo As String) As Boolean

        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT Atencion,[id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Ejecutiva],[Sucursal],Estado,Aprobacion_Gerencia,Aprobacion_SubGerencia,Aprobacion_Operaciones,Aprobacion_Comision_Credito_Interno,Aprobacion_Comision_Credito_Superior , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING(convert(varchar,getdate()),1,19)),'') as tiempo  , PreAprobacion_Agente ,PreAprobacion_Riesgo,FueraDeZona  FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where " + tipo + " ='Por Analizar' AND Estado in ('Enviado por Dep.riesgo como RECOMENDADO','Enviado por Dep.riesgo como RECOMENDADO CONDICIONAL','Enviado por Dep.riesgo como NO RECOMENDADO','Enviado de Ejecutivos para aprobación') and PreAprobacion_Agente in ('LIBERADO SIN OBJECIONES','LIBERADO CON OBJECIONES','NO VALIDA') ", conexiones._conexion)
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function


    Public Function Consultar_Creditos_AprobarXSubGerencia() As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            '_adaptador.SelectCommand = New SqlCommand("    SELECT [id_solicitud],[Nrosocio],[fecha_solicitud],[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Ejecutiva],[Sucursal],Estado,Aprobacion_Gerencia,Aprobacion_SubGerencia,Aprobacion_Operaciones,Aprobacion_Comision_Credito_Interno,Aprobacion_Comision_Credito_Superior  FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where Aprobacion_SubGerencia ='Por Analizar' AND Aprobacion_Operaciones<>'Por Analizar' AND Estado in ('Enviado por Dep.riesgo como RECOMENDADO','Enviado por Dep.riesgo como NO RECOMENDADO','Enviado de Ejecutivos para aprobación') ", conexiones._conexion)
            '_adaptador.SelectCommand = New SqlCommand("             SELECT [id_solicitud],[Nrosocio],substring(fecha_solicitud,9,2)+'/'+substring(fecha_solicitud,6,2)+'/'+substring(fecha_solicitud,1,4)as [fecha_solicitud],[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Ejecutiva],[Sucursal],Estado,Aprobacion_Gerencia,Aprobacion_SubGerencia,Aprobacion_Operaciones,Aprobacion_Comision_Credito_Interno,Aprobacion_Comision_Credito_Superior, ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING(convert(varchar,getdate()),1,19)),'') as tiempo FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where Aprobacion_SubGerencia ='Por Analizar' AND Aprobacion_Operaciones<>'Por Analizar' AND Estado in ('Enviado por Dep.riesgo como RECOMENDADO','Enviado por Dep.riesgo como NO RECOMENDADO','Enviado de Ejecutivos para aprobación') UNION ALL SELECT [ID_SOLICITUD],[NROSOCIO] as NROSOCIO ,SUBSTRING(FECHA_SOLICITUD,7,8)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4)as [FECHA_SOLICITUD],'GIRO CAPITAL' AS PRODUCTO,dbo.puntos(convert(nvarchar(15),[MONTO_SOLICITUD])) as dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[USUARIO] as [Ejecutiva],[SUCURSAL],[ESTADO_SOLICITUD] as Estado ,'No Verifica','Por Analizar','No Verifica','No Verifica','No Verifica' FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL] WHERE RTRIM(ESTADO_SOLICITUD)='RECONSIDERACIÓN' and REEVALUACION='SI' AND ESTADO_SOLICITUD2=1 ", conexiones._conexion)

            _adaptador.SelectCommand = New SqlCommand("SELECT Atencion,[id_solicitud],[Nrosocio],substring(fecha_solicitud,9,2)+'/'+substring(fecha_solicitud,6,2)+'/'+substring(fecha_solicitud,1,4)as [fecha_solicitud],[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Ejecutiva],[Sucursal],Estado,Aprobacion_Gerencia,Aprobacion_SubGerencia,Aprobacion_Operaciones,Aprobacion_Comision_Credito_Interno,Aprobacion_Comision_Credito_Superior , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING(convert(varchar,getdate()),1,19)),'') as tiempo , PreAprobacion_Agente ,PreAprobacion_Riesgo,FueraDeZona FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where Aprobacion_SubGerencia ='Por Analizar' AND Aprobacion_Operaciones<>'Por Analizar' AND Estado in ('Enviado por Dep.riesgo como RECOMENDADO','Enviado por Dep.riesgo como RECOMENDADO CONDICIONAL','Enviado por Dep.riesgo como NO RECOMENDADO','Enviado de Ejecutivos para aprobación') and PreAprobacion_Agente in ('LIBERADO SIN OBJECIONES','LIBERADO CON OBJECIONES','NO VALIDA')    UNION ALL  SELECT 'No informa',[ID_SOLICITUD],[NROSOCIO] as NROSOCIO ,SUBSTRING(FECHA_SOLICITUD,7,8)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4)as [FECHA_SOLICITUD],'GIRO CAPITAL' AS PRODUCTO,dbo.puntos(convert(nvarchar(15),[MONTO_SOLICITUD]))  as monto_solicitado,[USUARIO] as [Ejecutiva],[SUCURSAL],[ESTADO_SOLICITUD] as Estado ,'No Verifica','Por Analizar','No Verifica','No Verifica','No Verifica' ,0 as tiempo,'No Verifica','No Verifica','' FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL] WHERE RTRIM(ESTADO_SOLICITUD)='RECONSIDERACIÓN' and REEVALUACION='SI' AND ESTADO_SOLICITUD2=1 order by id_solicitud ", conexiones._conexion)





            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function

    Public Function Consultar_Creditos_AprobarXCCI() As Boolean

        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT Atencion,[id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Ejecutiva],[Sucursal],Estado,Aprobacion_Gerencia,Aprobacion_SubGerencia,Aprobacion_Operaciones,Aprobacion_Comision_Credito_Interno,Aprobacion_Comision_Credito_Superior, ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING(convert(varchar,getdate()),1,19)),'') as tiempo , PreAprobacion_Agente ,PreAprobacion_Riesgo,FueraDeZona FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where Aprobacion_Comision_Credito_Interno ='Por Analizar' AND Aprobacion_SubGerencia <>'Por Analizar' AND Aprobacion_Operaciones<>'Por Analizar' AND Estado in ('Enviado por Dep.riesgo como RECOMENDADO','Enviado por Dep.riesgo como RECOMENDADO CONDICIONAL','Enviado por Dep.riesgo como NO RECOMENDADO','Enviado de Ejecutivos para aprobación')  and PreAprobacion_Agente in ('LIBERADO SIN OBJECIONES','LIBERADO CON OBJECIONES','NO VALIDA')  ", conexiones._conexion)
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function
    Public Function Consultar_Creditos_AprobarXCCS() As Boolean

        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT Atencion,[id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Ejecutiva],[Sucursal],Estado,Aprobacion_Gerencia,Aprobacion_SubGerencia,Aprobacion_Operaciones,Aprobacion_Comision_Credito_Interno,Aprobacion_Comision_Credito_Superior, ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING(convert(varchar,getdate()),1,19)),'') as tiempo , PreAprobacion_Agente ,PreAprobacion_Riesgo,FueraDeZona FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where Aprobacion_Comision_Credito_Superior ='Por Analizar' AND Aprobacion_SubGerencia <>'Por Analizar' AND Aprobacion_Operaciones<>'Por Analizar' AND Estado in ('Enviado por Dep.riesgo como RECOMENDADO','Enviado por Dep.riesgo como RECOMENDADO CONDICIONAL','Enviado por Dep.riesgo como NO RECOMENDADO','Enviado de Ejecutivos para aprobación') and PreAprobacion_Agente in ('LIBERADO SIN OBJECIONES','LIBERADO CON OBJECIONES','NO VALIDA')  ", conexiones._conexion)
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function
    Public Function Consultar_PRUEBA() As Boolean

        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("DROP TABLE ##_SOCIOS   SELECT * INTO ##_SOCIOS FROM _SOCIOS WHERE NROSOCIO IN (1166,1167) ", conexiones._conexion)
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function

    Public Function Consultar_Creditos_AprobarXGerencia() As Boolean

        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT Atencion,[id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[producto],dbo.puntos(replace(monto_solicitado,'.','')) as monto_solicitado,[Ejecutiva],[Sucursal],Estado,Aprobacion_Gerencia,Aprobacion_SubGerencia,Aprobacion_Operaciones,Aprobacion_Comision_Credito_Interno,Aprobacion_Comision_Credito_Superior, ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING(convert(varchar,getdate()),1,19)),'') as tiempo  , PreAprobacion_Agente ,PreAprobacion_Riesgo,FueraDeZona FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where Aprobacion_Gerencia ='Por Analizar' AND Aprobacion_SubGerencia <>'Por Analizar' AND Aprobacion_Operaciones<>'Por Analizar'  AND Estado in ('Enviado por Dep.riesgo como RECOMENDADO','Enviado por Dep.riesgo como RECOMENDADO CONDICIONAL','Enviado por Dep.riesgo como NO RECOMENDADO','Enviado de Ejecutivos para aprobación') and PreAprobacion_Agente in ('LIBERADO SIN OBJECIONES','LIBERADO CON OBJECIONES','NO VALIDA')  ", conexiones._conexion)
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function



    Public Function Consultar_prestamos_personales_bandeja() As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT TOP 100 [id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[Sucursal],[Estado],[Aprobacion_Operaciones],[Aprobacion_SubGerencia],[Aprobacion_Gerencia],[Aprobacion_Comision_Credito_Interno],[Aprobacion_Comision_Credito_Superior], isnull(condicional,'') as condicional , PreAprobacion_Agente ,PreAprobacion_Riesgo,PerfilAsignacion AS Subperfil,Ejecutiva FROM [_RIESGO_PRESTAMOS_SOLICITADOS]  order by fecha_solicitud desc", conexiones._conexion)
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function



    Public Function Consultar_prestamos_personales_bandejaxnrosocio(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT TOP 100 [id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[Sucursal],[Estado],[Aprobacion_Operaciones],[Aprobacion_SubGerencia],[Aprobacion_Gerencia],[Aprobacion_Comision_Credito_Interno],[Aprobacion_Comision_Credito_Superior], isnull(condicional,'') as condicional , PreAprobacion_Agente ,PreAprobacion_Riesgo,PerfilAsignacion AS Subperfil,Ejecutiva FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where nrosocio=@nrosocio  order by fecha_solicitud desc", conexiones._conexion)
            _adaptador.SelectCommand.Parameters.Add("@Nrosocio", SqlDbType.VarChar).Value = datos._Nrosocio
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function


    Public Function Consultar_prestamos_personales_bandeja_entrada(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT TOP 100 [id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[Sucursal],[Estado],[Aprobacion_Operaciones],[Aprobacion_SubGerencia],[Aprobacion_Gerencia],[Aprobacion_Comision_Credito_Interno],[Aprobacion_Comision_Credito_Superior], condicional , PreAprobacion_Agente ,PreAprobacion_Riesgo,PerfilAsignacion AS Subperfil,Ejecutiva FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where ([Ejecutiva]=@Ejecutiva or PerfilAsignacion=@Ejecutiva) and Bandeja<>'SI' order by fecha_solicitud desc", conexiones._conexion)
            _adaptador.SelectCommand.Parameters.Add("@Ejecutiva", SqlDbType.VarChar, 50).Value = datos._Ejecutiva
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function


    Public Function Consultar_prestamos_personales_bandeja_entradaxnrosocio(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT TOP 100 [id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[Sucursal],[Estado],[Aprobacion_Operaciones],[Aprobacion_SubGerencia],[Aprobacion_Gerencia],[Aprobacion_Comision_Credito_Interno],[Aprobacion_Comision_Credito_Superior], condicional , PreAprobacion_Agente ,PreAprobacion_Riesgo,PerfilAsignacion AS Subperfil,Ejecutiva FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where ([Ejecutiva]=@Ejecutiva or PerfilAsignacion=@Ejecutiva) and nrosocio=@nrosocio  and Bandeja<>'SI' order by fecha_solicitud desc", conexiones._conexion)
            _adaptador.SelectCommand.Parameters.Add("@Ejecutiva", SqlDbType.VarChar).Value = datos._Ejecutiva
            _adaptador.SelectCommand.Parameters.Add("@Nrosocio", SqlDbType.VarChar).Value = datos._Nrosocio
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function

    Public Function EstaAbierto(ByVal Myform As Form)
        Dim objForm As Form
        Dim blnAbierto As Boolean = False
        blnAbierto = False
        For Each objForm In My.Application.OpenForms
            If (Trim(objForm.Name) = Trim(Myform.Name)) Then
                blnAbierto = True
            End If
        Next
        Return blnAbierto
    End Function

    Public Function Consultar_prestamos_historicosxNrosocio2(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT 'PRE-SOCIO'  as tipo,CC1.NROSOCIO,rtrim([id_solicitud]) as id_solicitud ,SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,rtrim([Ejecutiva]) AS Ejecutivo,rtrim(CC1.[Sucursal]) as Sucursal,rtrim(CC1.[Estado]) as Estado, rtrim(condicional) as Condicion ,corcredito FROM [_RIESGO_PRESTAMOS_SOLICITADOS] AS CC1 INNER JOIN (SELECT * FROM _PRESOCIOS) AS CC2 ON CC2.NROSOCIO=CC1.PRESOCIO where presocio=CC1.nrosocio and CC2.RUT=@RUT UNION ALL SELECT 'SOCIO'  as tipo,CC1.NROSOCIO,rtrim([id_solicitud]) as id_solicitud ,SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,rtrim([Ejecutiva]) AS Ejecutivo,rtrim(CC1.[Sucursal]) as Sucursal,rtrim(CC1.[Estado]) as Estado, rtrim(condicional) as Condicion ,corcredito FROM [_RIESGO_PRESTAMOS_SOLICITADOS] AS CC1 INNER JOIN (SELECT * FROM _SOCIOS) AS CC2 ON CC2.NROSOCIO=CC1.NROSOCIO where presocio<>CC1.nrosocio and CC2.RUT=@RUT order by fecha_solicitud desc", conexiones._conexion)
            _adaptador.SelectCommand.Parameters.Add("@RUT", SqlDbType.VarChar, 50).Value = datos._Rut
            _adaptador.Fill(_tabla2)
        Catch ex As SqlException
            MsgBox(Err.Description)
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function


    Public Function Consultar_prestamos_personales_bandeja_historicos(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT TOP 100 [id_solicitud],[Nrosocio],SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,[Sucursal],[Estado],[Aprobacion_Operaciones],[Aprobacion_SubGerencia],[Aprobacion_Gerencia],[Aprobacion_Comision_Credito_Interno],[Aprobacion_Comision_Credito_Superior], condicional , PreAprobacion_Agente ,PreAprobacion_Riesgo,FueraDeZona,PerfilAsignacion AS Subperfil,Ejecutiva FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where ([Ejecutiva]=@Ejecutiva or PerfilAsignacion=@Ejecutiva)  and Bandeja='SI' order by fecha_solicitud desc", conexiones._conexion)
            _adaptador.SelectCommand.Parameters.Add("@Ejecutiva", SqlDbType.VarChar, 50).Value = datos._Ejecutiva
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function


    Public Function Consultar_prestamos_personales_bandeja_historicosxrut(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT TOP 100 [id_solicitud],CC1.Nrosocio,SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,CC1.Sucursal,CC1.Estado,[Aprobacion_Operaciones],[Aprobacion_SubGerencia],[Aprobacion_Gerencia],[Aprobacion_Comision_Credito_Interno],[Aprobacion_Comision_Credito_Superior], condicional , PreAprobacion_Agente ,PreAprobacion_Riesgo,FueraDeZona ,PerfilAsignacion AS Subperfil,Ejecutiva FROM [_RIESGO_PRESTAMOS_SOLICITADOS] AS CC1 INNER JOIN (SELECT * FROM _PRESOCIOS) AS CC2 ON CC2.NROSOCIO=CC1.PRESOCIO where presocio=CC1.nrosocio and CC2.RUT=@RUT UNION ALL SELECT [id_solicitud],CC1.Nrosocio,SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,CC1.Sucursal,CC1.Estado,[Aprobacion_Operaciones],[Aprobacion_SubGerencia],[Aprobacion_Gerencia],[Aprobacion_Comision_Credito_Interno],[Aprobacion_Comision_Credito_Superior], condicional , PreAprobacion_Agente ,PreAprobacion_Riesgo,FueraDeZona FROM [_RIESGO_PRESTAMOS_SOLICITADOS] AS CC1 INNER JOIN (SELECT * FROM _SOCIOS) AS CC2 ON CC2.NROSOCIO=CC1.NROSOCIO where presocio<>CC1.nrosocio and CC2.RUT=@RUT order by fecha_solicitud desc", conexiones._conexion)
            _adaptador.SelectCommand.Parameters.Add("@RUT", SqlDbType.VarChar, 50).Value = datos._Rut
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function

    Public Function Consultar_prestamos_personales_bandeja_historicosxID(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT TOP 100 [id_solicitud],CC1.Nrosocio,SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,CC1.Sucursal,CC1.Estado,[Aprobacion_Operaciones],[Aprobacion_SubGerencia],[Aprobacion_Gerencia],[Aprobacion_Comision_Credito_Interno],[Aprobacion_Comision_Credito_Superior], condicional , PreAprobacion_Agente ,PreAprobacion_Riesgo,FueraDeZona,PerfilAsignacion AS Subperfil,Ejecutiva FROM [_RIESGO_PRESTAMOS_SOLICITADOS] AS CC1 INNER JOIN (SELECT * FROM _PRESOCIOS) AS CC2 ON CC2.NROSOCIO=CC1.PRESOCIO where presocio=CC1.nrosocio and CC2.RUT=@RUT UNION ALL SELECT [id_solicitud],CC1.Nrosocio,SUBSTRING([fecha_solicitud],1,16) AS Fecha_Solicitud,CC1.Sucursal,CC1.Estado,[Aprobacion_Operaciones],[Aprobacion_SubGerencia],[Aprobacion_Gerencia],[Aprobacion_Comision_Credito_Interno],[Aprobacion_Comision_Credito_Superior], condicional , PreAprobacion_Agente ,PreAprobacion_Riesgo,FueraDeZona FROM [_RIESGO_PRESTAMOS_SOLICITADOS] AS CC1 INNER JOIN (SELECT * FROM _SOCIOS) AS CC2 ON CC2.NROSOCIO=CC1.NROSOCIO where id_solicitud=@id_solicitud ", conexiones._conexion)
            _adaptador.SelectCommand.Parameters.Add("@id_solicitud", SqlDbType.VarChar).Value = datos._id_solicitud
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function


    Public Function Actualizar_prestamos_personales_bandeja_historicos(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.UpdateCommand = New SqlCommand("update _RIESGO_PRESTAMOS_SOLICITADOS set Bandeja='SI' where id_solicitud=@id_solicitud", conexiones._conexion)
            _adaptador.UpdateCommand.Parameters.Add("@id_solicitud", SqlDbType.VarChar, 50).Value = datos._id_solicitud
            conexiones._conexion.Open()
            _adaptador.UpdateCommand.Connection = conexiones._conexion
            _adaptador.UpdateCommand.ExecuteNonQuery()
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function

    Public Function Actualizar_Segundo_Perfil(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.UpdateCommand = New SqlCommand("update _RIESGO_PRESTAMOS_SOLICITADOS set PerfilAsignacion=@Perfil where id_solicitud=@id_solicitud", conexiones._conexion)
            _adaptador.UpdateCommand.Parameters.Add("@id_solicitud", SqlDbType.VarChar, 50).Value = datos._id_solicitud
            _adaptador.UpdateCommand.Parameters.Add("@Perfil", SqlDbType.VarChar, 15).Value = datos._Perfil
            conexiones._conexion.Open()
            _adaptador.UpdateCommand.Connection = conexiones._conexion
            _adaptador.UpdateCommand.ExecuteNonQuery()
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function
    Public Function Actualizar_prestamos_personales_bandeja_entrada(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.UpdateCommand = New SqlCommand("update _RIESGO_PRESTAMOS_SOLICITADOS set Bandeja='NO' where id_solicitud=@id_solicitud", conexiones._conexion)
            _adaptador.UpdateCommand.Parameters.Add("@id_solicitud", SqlDbType.VarChar, 50).Value = datos._id_solicitud
            conexiones._conexion.Open()
            _adaptador.UpdateCommand.Connection = conexiones._conexion
            _adaptador.UpdateCommand.ExecuteNonQuery()
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function
    'METODOS GIROS DE CAPITAL '****************************************************************************************************

    Public Function Consultar_Creditos_AprobarXSubGerenciamarcos() As Boolean
        'Don pedro  creditos y reconcideracion 
        Dim estado As Boolean = True
        Try
            '  adaptador.SelectCommand = New SqlCommand("  SELECT [id_solicitud],[Nrosocio],substring(fecha_solicitud,9,2)+'/'+substring(fecha_solicitud,6,2)+'/'+substring(fecha_solicitud,1,4)as [fecha_solicitud],[producto],monto_solicitado,[Ejecutiva],[Sucursal],Estado,Aprobacion_Gerencia,Aprobacion_SubGerencia,Aprobacion_Operaciones,Aprobacion_Comision_Credito_Interno,Aprobacion_Comision_Credito_Superior FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where Aprobacion_SubGerencia ='Por Analizar' AND Aprobacion_Operaciones<>'Por Analizar' AND Estado in ('Enviado por Dep.riesgo como RECOMENDADO','Enviado por Dep.riesgo como NO RECOMENDADO','Enviado de Ejecutivos para aprobación') UNION ALL SELECT [ID_SOLICITUD],[NROSOCIO] as NROSOCIO ,SUBSTRING(FECHA_SOLICITUD,7,8)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4)as [FECHA_SOLICITUD],'GIRO CAPITAL' AS PRODUCTO,dbo.puntos(convert(nvarchar(15),[MONTO_SOLICITUD])) as monto_solicitado,[USUARIO] as [Ejecutiva],[SUCURSAL],[ESTADO_SOLICITUD] as Estado ,'No Verifica','Por Analizar','No Verifica','No Verifica','No Verifica' FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL] WHERE RTRIM(ESTADO_SOLICITUD)='RECONCIDERACION' and REEVALUACION='SI'AND [FILTRO_CAPITAL_GLOBAL]='SI' AND ESTADO_SOLICITUD2=1 
            conexiones.conexion()
            '_adaptador.SelectCommand = New SqlCommand("SELECT [id_solicitud],[Nrosocio],substring(fecha_solicitud,9,2)+'/'+substring(fecha_solicitud,6,2)+'/'+substring(fecha_solicitud,1,4)as [fecha_solicitud],[producto],monto_solicitado,[Ejecutiva],[Sucursal],Estado,Aprobacion_Gerencia,Aprobacion_SubGerencia,Aprobacion_Operaciones,Aprobacion_Comision_Credito_Interno,Aprobacion_Comision_Credito_Superior FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where Aprobacion_SubGerencia ='Por Analizar' AND Aprobacion_Operaciones<>'Por Analizar' AND Estado in ('Enviado por Dep.riesgo como RECOMENDADO','Enviado por Dep.riesgo como NO RECOMENDADO','Enviado de Ejecutivos para aprobación') UNION ALL SELECT [ID_SOLICITUD],[NROSOCIO] as NROSOCIO ,SUBSTRING(FECHA_SOLICITUD,7,8)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4)as [FECHA_SOLICITUD],'GIRO CAPITAL' AS PRODUCTO,dbo.puntos(convert(nvarchar(15),[MONTO_SOLICITUD])) as monto_solicitado,[USUARIO] as [Ejecutiva],[SUCURSAL],[ESTADO_SOLICITUD] as Estado ,'No Verifica','Por Analizar','No Verifica','No Verifica','No Verifica' FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL] WHERE RTRIM(ESTADO_SOLICITUD)='RECONSIDERACIÓN' and REEVALUACION='SI' AND ESTADO_SOLICITUD2=1  ", conexiones._conexion)
            _adaptador.SelectCommand = New SqlCommand(" SELECT [id_solicitud],[Nrosocio],substring(fecha_solicitud,9,2)+'/'+substring(fecha_solicitud,6,2)+'/'+substring(fecha_solicitud,1,4)as [fecha_solicitud],[producto],monto_solicitado,[Ejecutiva],[Sucursal],Estado,Aprobacion_Gerencia,Aprobacion_SubGerencia,Aprobacion_Operaciones,Aprobacion_Comision_Credito_Interno,Aprobacion_Comision_Credito_Superior , ISNULL(DATEDIFF(minute,SUBSTRING([fecha_solicitud],1,19),SUBSTRING(convert(varchar,getdate()),1,19)),'') as tiempo FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where Aprobacion_SubGerencia ='Por Analizar' AND Aprobacion_Operaciones<>'Por Analizar' AND Estado in ('Enviado por Dep.riesgo como RECOMENDADO','Enviado por Dep.riesgo como RECOMENDADO CONDICIONAL','Enviado por Dep.riesgo como NO RECOMENDADO','Enviado de Ejecutivos para aprobación') UNION ALL  SELECT [ID_SOLICITUD],[NROSOCIO] as NROSOCIO ,SUBSTRING(FECHA_SOLICITUD,7,8)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4)as [FECHA_SOLICITUD],'GIRO CAPITAL' AS PRODUCTO,dbo.puntos(convert(nvarchar(15),[MONTO_SOLICITUD])) as monto_solicitado,[USUARIO] as [Ejecutiva],[SUCURSAL],[ESTADO_SOLICITUD] as Estado ,'No Verifica','Por Analizar','No Verifica','No Verifica','No Verifica' ,0 as tiempo FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL] WHERE RTRIM(ESTADO_SOLICITUD)='RECONSIDERACIÓN' and REEVALUACION='SI' AND ESTADO_SOLICITUD2=1  ", conexiones._conexion)
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function

    '***** SOLICITUDES PENDIENTES  ****'
    Public Function Consultar_Creditos_Aprobar_EFECTIVO() As Boolean
        ' CALFARO REEMPLAZAR ESTE MODULO
        conexiones.conexion()
        conexiones.abrir()
        Dim command As SqlCommand

        command = New SqlCommand("_LAUCOOP_PRELACION_PENDIENTES", conexiones._conexion)
        command.CommandType = CommandType.StoredProcedure
        _adaptador = New SqlDataAdapter(command)
        With command.Parameters
            'Envió los parámetros que necesito
            .Add(New SqlParameter("@FECHA", SqlDbType.VarChar)).Value = "HOY"
            .Add(New SqlParameter("@1RA_AYUDA", SqlDbType.VarChar)).Value = "N"
            .Add(New SqlParameter("@ORDEN", SqlDbType.VarChar)).Value = "ID"
            .Add(New SqlParameter("@NROSOCIO", SqlDbType.VarChar)).Value = "0"
            .Add(New SqlParameter("@ID_SOLICITUD", SqlDbType.VarChar)).Value = "0"
        End With
        Try
            _adaptador.Fill(_tabla)
        Catch expSQL As SqlException
            MsgBox(expSQL.ToString, MsgBoxStyle.OkOnly, "SQL Exception")
        End Try

    End Function

    Public Function Consultar_SERVIDORES() As Boolean
        ' CALFARO REEMPLAZAR ESTE MODULO
        conexiones.conexion()
        conexiones.abrir()
        Dim command As SqlCommand

        command = New SqlCommand("_RIESGO_BASE2", conexiones._conexion)
        command.CommandType = CommandType.StoredProcedure
        _adaptador = New SqlDataAdapter(command)
        With command.Parameters
            'Envió los parámetros que necesito
            .Add(New SqlParameter("@ID_SOLICITUD", SqlDbType.VarChar)).Value = "DOCUMENTOS"
        End With
        Try
            _adaptador.Fill(_tabla)
        Catch expSQL As SqlException
            MsgBox(expSQL.ToString, MsgBoxStyle.OkOnly, "SQL Exception")
        End Try

    End Function



    Public Function Consultar_Giros_Trasferencia_Capital() As Boolean
        ' CALFARO REEMPLAZAR ESTE MODULO
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            conexiones.abrir()
            Dim command As SqlCommand

            command = New SqlCommand("_LAUCOOP_PRELACION_PARA_TRANSFERENCIAS", conexiones._conexion)
            command.CommandType = CommandType.StoredProcedure
            _adaptador = New SqlDataAdapter(command)
            With command.Parameters
                'Envió los parámetros que necesito
                .Add(New SqlParameter("@FECHA", SqlDbType.VarChar)).Value = "HOY"
                .Add(New SqlParameter("@1RA_AYUDA", SqlDbType.VarChar)).Value = "N"
                .Add(New SqlParameter("@NROSOCIO", SqlDbType.VarChar)).Value = "0"
                .Add(New SqlParameter("@ID_SOLICITUD", SqlDbType.VarChar)).Value = "0"
            End With
            _adaptador.Fill(_tabla)
        Catch expSQL As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function




    Public Function Consultar_BD() As Boolean
        ' CALFARO REEMPLAZAR ESTE MODULO
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            conexiones.abrir()
            Dim command As SqlCommand

            command = New SqlCommand("_LAUCOOP_PRELACION_PARA_TRANSFERENCIAS", conexiones._conexion)
            command.CommandType = CommandType.StoredProcedure
            _adaptador = New SqlDataAdapter(command)
            With command.Parameters

                'Envió los parámetros que necesito
                .Add(New SqlParameter("@FECHA", SqlDbType.VarChar)).Value = "HOY"
                .Add(New SqlParameter("@1RA_AYUDA", SqlDbType.VarChar)).Value = "N"
                .Add(New SqlParameter("@NROSOCIO", SqlDbType.VarChar)).Value = "0"
                .Add(New SqlParameter("@ID_SOLICITUD", SqlDbType.VarChar)).Value = "0"
            End With
            _adaptador.Fill(_tabla)
        Catch expSQL As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function



    '***** VISTA MARCELA METODO CREADO ****'

    Public Function C2onsultar_Giros_Trasferencia_Capital() As Boolean
        Dim estado As Boolean = True
        Try
            'SELECT giro.[ID_SOLICITUD] as ID_SOLICITUD  ,SUBSTRING(giro.FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(giro.FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(giro.FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD ,LTRIM(giro.[ESTADO_SOLICITUD]) AS ESTADO ,convert(varchar,giro.[RUT])+'-'+giro.[DVRUT] as RUT,LTRIM(giro.NOMBRES) AS NOMBRES ,LTRIM(giro.PATERNO) AS PATERNO ,giro.MATERNO AS MATERNO  ,[dbo].puntos(giro.[MONTO_SOLICITUD]) AS MONTO,giro.[BANCO],DESCRIPCION AS CUENTA,giro.[NRO_CUENTA],giro.[FORMA_PAGO] FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL]  as giro  inner join  [_TESORERIA_TIPO_CUENTA_BANCO] as Tipocuenta  on giro.TIPO_CUENTA = Tipocuenta.CODIGO LEFT JOIN [_RIESGO_DETA_NOMINA_TRANSFERENCIA] AS DETANOMIA  ON DETANOMIA.ID_SOLICITUD = GIRO.ID_SOLICITUD  WHERE GIRO.ESTADO_SOLICITUD='INGRESADO' OR GIRO.ESTADO_SOLICITUD='APROBADO'AND GIRO.FORMA_PAGO='TRANSFERENCIA' AND giro.EN_NOMINA = 0
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand(" SELECT giro.[ID_SOLICITUD] as ID_SOLICITUD , SUBSTRING(FECHA_SOLICITUD,7,2)+'/'+SUBSTRING(FECHA_SOLICITUD,5,2)+'/'+SUBSTRING(FECHA_SOLICITUD,1,4) AS FECHA_SOLICITUD ,convert(varchar,[RUT])+'-'+[DVRUT] as RUT ,LTRIM(NOMBRES) AS NOMBRES ,LTRIM(PATERNO) AS PATERNO ,MATERNO AS MATERNO ,[dbo].puntos([MONTO_SOLICITUD]) AS MONTO ,LTRIM([ESTADO_SOLICITUD]) AS ESTADO , USUARIO AS EJECUTIVO  ,giro.[BANCO],DESCRIPCION AS CUENTA,[NRO_CUENTA],[FORMA_PAGO]    FROM [_RIESGO_SOLICITUD_GIRO_CAPITAL]  as giro  inner join  [_TESORERIA_TIPO_CUENTA_BANCO] as Tipocuenta  on giro.TIPO_CUENTA = Tipocuenta.CODIGO   WHERE  FORMA_PAGO='TRANSFERENCIA' AND EN_NOMINA = 0 AND (ESTADO_SOLICITUD='PREAPROBADO' OR ESTADO_SOLICITUD='APROBADO') ORDER BY id_solicitud  desc ", conexiones._conexion)
            _adaptador.Fill(_tabla)
            'frmBandejaCapital.GridbandejaCapital.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function



    '***** SRTA JEESICA PEUDA VER SU CREDITOS PENDIENTES COMO TMABIEN  LA NOMINA DE TRBNASFERENCIAS ENVIADAS PRO MARCELA  ****'
    Public Function Consultar_Creditos_Aprobar_Con_Nomina_Transferencia() As Boolean

        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.SelectCommand = New SqlCommand("SELECT [NRO_NOMINA]AS ID_SOLICITUD,[NRO_NOMINA] as NROSOCIO ,SUBSTRING(FECHA_NOMINA ,7,2)+'/'+SUBSTRING(FECHA_NOMINA ,5,2)+'/'+SUBSTRING(FECHA_NOMINA ,1,4) AS [FECHA_SOLICITUD],'NOMINA GIRO CAPITAL' AS PRODUCTO,dbo.puntos(CONVERT(nvarchar(15),MONTO_NOMINA)) AS  [MONTO_SOLICITUD],[USUARIO],[SUCURSAL] , ESTADO_NOMINA AS[ESTADO],'No Verifica',APROBACION_SUBGERENTE_FINANZA,'No Verifica','No Verifica','No Verifica','' as PreAprobacion_Agente FROM [_RIESGO_ENCA_NOMINA_TRANSFERENCIA] WHERE RTRIM(ESTADO_NOMINA)='GENERADA' AND APROBACION_SUBGERENTE_FINANZA ='Por Analizar' ORDER BY id_solicitud  desc ", conexiones._conexion)
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function


    Public Function Consultar_General(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()

            _adaptador.SelectCommand = New SqlCommand(datos._sql1, conexiones._conexion)
            _adaptador.Fill(_tabla)
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function




    Public ReadOnly Property tabla() As DataTable
        Get
            Return _tabla
        End Get
    End Property

    Public ReadOnly Property tabla2() As DataTable
        Get
            Return _tabla2
        End Get
    End Property
End Class
