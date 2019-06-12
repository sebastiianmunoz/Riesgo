Imports System.Data.SqlClient
Imports System.IO
Public Class CCEstadosGeneral
    Dim datos As CDatos
    Dim conexiones As New CConexion
    Public _tabla As DataTable = New DataTable
    Public _tabla2 As DataTable = New DataTable
    Public _tabla3 As DataTable = New DataTable
    Public _tabla4 As DataTable = New DataTable
    Public _adaptador As SqlDataAdapter = New SqlDataAdapter


    Sub crear()
        If File.Exists("C:\Sistemas\Actualiza\ACTUALIZARIESGO.BAT") Then
            File.Delete("C:\Sistemas\Actualiza\ACTUALIZARIESGO.BAT")
        End If
        Dim ruta = "C:\Sistemas\Actualiza\ACTUALIZARIESGO.BAT"
        My.Computer.FileSystem.WriteAllText(ruta, "@ECHO OFF" & vbCrLf & "CLS" & vbCrLf & "ECHO Espere un momento, Copiando el nuevo ejecutable ..." & vbCrLf & "C:" & vbCrLf & "Copy Z:\Actualizar\RIESGO.rar c:\Sistemas\Actualiza\RIESGO.rar" & vbCrLf & "CD\" & vbCrLf & "CD Sistemas" & vbCrLf & "CD RIESGO" & vbCrLf & "ERASE *.* /Q" & vbCrLf & "ECHO Extrayendo nuevo ejecutable ..." & vbCrLf & "c:\sistemas\Actualiza\RAR e c:\Sistemas\Actualiza\RIESGO.rar *.*   /o+" & vbCrLf & "CLS" & vbCrLf & "ECHO Sistema Actualizado con Exito, cargando...." & vbCrLf & "start C:\Sistemas\RIESGO\SistemaRiesgos.EXE", True)
    End Sub


    Public Function Agregar_Puntaje(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.InsertCommand = New SqlCommand("insert into  _RIESGO_SCORING2  ([Tipo],[Categoria],[Rango1],[Rango2],[Bueno],[Malo] ,[SubCategoria] ,[numerico],FECHA_EDICION ,PERFIL,ID_TIPO,[Castigo],[Saldo]) values (@Tipo,@Categoria,@Rango1,@Rango2,@Bueno,@Malo,@SubCategoria,@numerico,GETDATE(),@perfil,@id_tipo,@Castigo,@Saldo)", conexiones._conexion)
            _adaptador.InsertCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = datos._Tipo
            _adaptador.InsertCommand.Parameters.Add("@Categoria", SqlDbType.VarChar).Value = datos._Categoria
            _adaptador.InsertCommand.Parameters.Add("@Rango1", SqlDbType.VarChar).Value = datos._Rango1
            _adaptador.InsertCommand.Parameters.Add("@Rango2", SqlDbType.VarChar).Value = datos._Rango2
            _adaptador.InsertCommand.Parameters.Add("@Bueno", SqlDbType.VarChar).Value = datos._Bueno
            _adaptador.InsertCommand.Parameters.Add("@Malo", SqlDbType.VarChar).Value = datos._Malo
            _adaptador.InsertCommand.Parameters.Add("@SubCategoria", SqlDbType.VarChar).Value = datos._SubCategoria
            _adaptador.InsertCommand.Parameters.Add("@numerico", SqlDbType.VarChar).Value = datos._numerico
            _adaptador.InsertCommand.Parameters.Add("@id_tipo", SqlDbType.VarChar).Value = datos._id_tipo
            _adaptador.InsertCommand.Parameters.Add("@perfil", SqlDbType.VarChar).Value = datos._Perfil
            _adaptador.InsertCommand.Parameters.Add("@Saldo", SqlDbType.VarChar).Value = datos._Saldo
            _adaptador.InsertCommand.Parameters.Add("@Castigo", SqlDbType.VarChar).Value = datos._Castigo

            conexiones.abrir()
            _adaptador.InsertCommand.Connection = conexiones._conexion
            _adaptador.InsertCommand.ExecuteNonQuery()
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function
    Public Function Consultar_Pagare1(ByVal datos As CDatos) As Boolean
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

    Public Function Agregar_Renta(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.InsertCommand = New SqlCommand(" insert into _RIESGO_RENTA (VALOR,NROSOCIO,USUARIO,FORMADEPAGO) values (@VALOR,@NROSOCIO,@USUARIO,@FORMADEPAGO)", conexiones._conexion)
            _adaptador.InsertCommand.Parameters.Add("@VALOR", SqlDbType.VarChar).Value = datos._CADENA
            _adaptador.InsertCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = datos._Perfil
            _adaptador.InsertCommand.Parameters.Add("@NROSOCIO", SqlDbType.VarChar).Value = datos._Nrosocio
            _adaptador.InsertCommand.Parameters.Add("@FORMADEPAGO", SqlDbType.VarChar).Value = datos._forpago
            conexiones.abrir()
            _adaptador.InsertCommand.Connection = conexiones._conexion
            _adaptador.InsertCommand.ExecuteNonQuery()
        Catch ex As SqlException
            MsgBox(Err.Description)
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function


    Public Function Agregar_perfil(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.InsertCommand = New SqlCommand(" insert into _RIESGO_PERFIL ([NOMBRE],[USUARIO],[DEPARTAMENTO],UBICACION,[CARGO],[ATRIBUTO],[ENCONTRASENA],[ENSUPERCONTRASENA],[ENPERMISOS]) values (@NOMBRE,@USUARIO,@DEPARTAMENTO,@SUCURSAL,@CARGO,@ATRIBUTO,dbo.FU_ENCRIPTA(RTRIM(@ENCONTRASENA)),dbo.FU_ENCRIPTA(RTRIM(@ENSUPERCONTRASENA)),dbo.FU_ENCRIPTA(RTRIM(@ENPERMISOS)))", conexiones._conexion)
            _adaptador.InsertCommand.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = datos._perfil_NOMBRE
            _adaptador.InsertCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = datos._perfil_USUARIO
            _adaptador.InsertCommand.Parameters.Add("@DEPARTAMENTO", SqlDbType.VarChar).Value = datos._perfil_DEPARTAMENTO
            _adaptador.InsertCommand.Parameters.Add("@SUCURSAL", SqlDbType.VarChar).Value = datos._perfil_SUCURSAL
            _adaptador.InsertCommand.Parameters.Add("@CARGO", SqlDbType.VarChar).Value = datos._perfil_CARGO
            _adaptador.InsertCommand.Parameters.Add("@ATRIBUTO", SqlDbType.VarChar).Value = datos._perfil_ATRIBUTO
            _adaptador.InsertCommand.Parameters.Add("@ENCONTRASENA", SqlDbType.VarChar).Value = datos._perfil_ENCONTRASENA
            _adaptador.InsertCommand.Parameters.Add("@ENSUPERCONTRASENA", SqlDbType.VarChar).Value = datos._perfil_ENSUPERCONTRASENA
            _adaptador.InsertCommand.Parameters.Add("@ENPERMISOS", SqlDbType.VarChar).Value = datos._perfil_ENPERMISOS
            conexiones.abrir()
            _adaptador.InsertCommand.Connection = conexiones._conexion
            _adaptador.InsertCommand.ExecuteNonQuery()
        Catch ex As SqlException
            estado = False
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function


    Public Function Actualizar_claves(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.UpdateCommand = New SqlCommand("UPDATE _RIESGO_PERFIL set ENSUPERCONTRASENA=dbo.FU_ENCRIPTA('LROSAS') ,ENCONTRASENA=dbo.FU_ENCRIPTA('LROSAS') WHERE COD_PERFIL=@USUARIO", conexiones._conexion)
            _adaptador.UpdateCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar, 50).Value = datos._Perfil
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
    Public Function Actualizar_permisos(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.UpdateCommand = New SqlCommand("UPDATE _RIESGO_PERFIL set ENPERMISOS=dbo.FU_ENCRIPTA(RTRIM(@ENPERMISOS)) WHERE COD_PERFIL=@USUARIO", conexiones._conexion)
            _adaptador.UpdateCommand.Parameters.Add("@ENPERMISOS", SqlDbType.VarChar, 50).Value = datos._enpermisos
            _adaptador.UpdateCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar, 50).Value = datos._Perfil
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
    Public Function Actualizar_atributos(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.UpdateCommand = New SqlCommand("UPDATE _RIESGO_PERFIL set ATRIBUTOS_AUTORIZA=@ENPERMISOS,ATRIBUTOS_MUESTRA=@ENPERMISOS WHERE COD_PERFIL=@USUARIO", conexiones._conexion)
            _adaptador.UpdateCommand.Parameters.Add("@ENPERMISOS", SqlDbType.VarChar, 50).Value = datos._enpermisos
            _adaptador.UpdateCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar, 50).Value = datos._Perfil
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

    Public Function Actualizar_ContraseñaMASESTRAxCodigoPerfil(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.UpdateCommand = New SqlCommand("UPDATE _RIESGO_PERFIL set ENSUPERCONTRASENA=dbo.FU_ENCRIPTA(RTRIM(@SUPERCONTRASENA)) WHERE USUARIO=@USUARIO", conexiones._conexion)
            _adaptador.UpdateCommand.Parameters.Add("@SUPERCONTRASENA", SqlDbType.VarChar, 50).Value = datos._Contraseña
            _adaptador.UpdateCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar, 50).Value = datos._Perfil
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


    Public Function Actualizar_Sucursal(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.UpdateCommand = New SqlCommand("UPDATE _RIESGO_PERFIL set UBICACION=@SUCURSAL WHERE USUARIO=@USUARIO", conexiones._conexion)
            _adaptador.UpdateCommand.Parameters.Add("@SUCURSAL", SqlDbType.VarChar).Value = datos._Sucursal
            _adaptador.UpdateCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = datos._Perfil
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



    Public Function Actualizar_ContraseñaxCodigoPerfil(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.UpdateCommand = New SqlCommand("UPDATE _RIESGO_PERFIL set ENCONTRASENA=dbo.FU_ENCRIPTA(RTRIM(@CONTRASENA)) WHERE USUARIO=@USUARIO", conexiones._conexion)
            _adaptador.UpdateCommand.Parameters.Add("@CONTRASENA", SqlDbType.VarChar, 50).Value = datos._Contraseña
            _adaptador.UpdateCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar, 50).Value = datos._Perfil
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

    Public Function Agregar_prestamo(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()


            _adaptador.InsertCommand = New SqlCommand("INSERT INTO _RIESGO_PRESTAMOS_SOLICITADOS ([Nrosocio],[fecha_solicitud],[producto],[objetivo],[monto_solicitado],[capital],[prepago],[NroPrepagos],[nrocuotas],[primera_cuota],[tasa],[dias_gracia],[ncreditos],[fechaprimervencimiento],[forpago],[tiporenta],[protestosmorocidades],[Edeudafinanciera],[EdeudaHipo],[EdeudaConsumo],[EdeudaComercial],[EDeudadVencidas],[ELineaCredito],[ENumeroAcreedores],[Itotaldeuda],[IdeudaConsumo],[IdeudaComercial],[IDeudaIndirecta],[IPagoMensual],[RLP],[CargaFinanciera],[ExternaAcreditado],[Activos],[Propiedades],[Vehiculos],[RentaLiquidaDepurada],[LVL],[capacidad],[Validaciones],[Ejecutiva],[Sucursal],[Aprobacion_Gerencia],[Aprobacion_SubGerencia],[Aprobacion_Operaciones],[Estado],[Puntaje],[Anos_contrato],[Edad],[Anos_antiguedad],[Atribucion],[Aprobacion_Comision_Credito_Interno],[Aprobacion_Comision_Credito_Superior],[V_Puntaje],[V_Capacidad],[V_Endeudamiento],[V_Comerciales],[V_Antiguedad10],[V_Antiguedad1],[V_Moras],[V_Edad] ,[Nombre],[Rut],Monto_capital,Cuotas_prepago,Puntajes_Validaciones , Presocio,comportamiento_clasificacion,comportamiento_abonocapital,comportamiento_baja_clasificacion,Tasa_aumento,Ejecutivo_convenio,Tasa_solicitada,renegocia_refinancia,PreAprobacion_Riesgo,Comentario_Ejecutiva,PreAprobacion_Agente,Sede,FueraDeZona,Formadepago2,Region,Institucion,Plataforma,tasa_castigada,tasa_real,comentario_tasa ,Descuento_campaña,Eperiodo,EDeudadVencidasIndirectas,RutAval1,RutAval2,modificaciondeudaexterna,PYM6,PYM6A12,PYM12A24,PYM24,ID_RENTA,MaximoMontoPlanilla,MaximaCuotaPlanilla,COD_DACA,Atencion,MES_PRIMERA ,ANO_PRIMERA,COD_FORMAPAGO ,COD_INST ,ESTADO_INI,DISPONIBLE,CUOTA_ULTIMA,COD_SUCURSAL) VALUES (@Nrosocio, SYSDATETIME () ,@producto  ,@objetivo,@monto_solicitado,@capital,@prepago,@NroPrepagos,@nrocuotas  ,@primera_cuota,@tasa,@dias_gracia,@ncreditos, @fechaprimervencimiento  ,@forpago,@tiporenta,@protestosmorocidades,@Edeudafinanciera,@EdeudaHipo,@EdeudaConsumo,@EdeudaComercial,@EDeudadVencidas,@ELineaCredito,@ENumeroAcreedores,@Itotaldeuda,@IdeudaConsumo,@IdeudaComercial,@IDeudaIndirecta,@IPagoMensual,@RLP,@CargaFinanciera,@ExternaAcreditado,@Activos,@Propiedades,@Vehiculos,@RentaLiquidaDepurada,@LVL,@capacidad,@Validaciones,@Ejecutiva,@Sucursal,@Aprobacion_Gerencia,@Aprobacion_SubGerencia,@Aprobacion_Operaciones,@Estado,@Puntaje,@Anos_contrato,@Edad,@Anos_antiguedad,@Atribucion,@Aprobacion_Comision_Credito_Interno,@Aprobacion_Comision_Credito_Superior,@V_Puntaje,@V_Capacidad,@V_Endeudamiento,@V_Comerciales,@V_Antiguedad10,@V_Antiguedad1,@V_Moras,@V_Edad ,@Nombre,@Rut,@Monto_capital,@Cuotas_prepago,@Puntajes_Validaciones,@Presocio,@comportamiento_clasificacion,@comportamiento_abonocapital,@comportamiento_baja_clasificacion,@Tasa_aumento,@Ejecutivo_convenio,@Tasa_solicitada,@renegocia_refinancia,@PreAprobacion_Riesgo,@Comentario_Ejecutiva,@PreAprobacion_Agente,@Sede,@FueraDeZona,@Formadepago2,@Region,@Institucion,@Plataforma,@tasa_castigada,@tasa_real,@comentario_tasa ,@Descuento_campaña,@Eperiodo,@EDeudadVencidasIndirectas,@RutAval1,@RutAval2,@modificaciondeudaexterna,@PYM6,@PYM6A12,@PYM12A24,@PYM24,@ID_RENTA,@MaximoMontoPlanilla,@MaximaCuotaPlanilla,@COD_DACA,@Atencion,@MES_PRIMERA ,@ANO_PRIMERA,@COD_FORMAPAGO ,@COD_INST ,@ESTADO_INI,@DISPONIBLE,@CUOTA_ULTIMA,@COD_SUCURSAL) ", conexiones._conexion)
            _adaptador.InsertCommand.Parameters.Add("@Nrosocio", SqlDbType.VarChar, 8).Value = datos._Nrosocio
            _adaptador.InsertCommand.Parameters.Add("@fecha_solicitud", SqlDbType.VarChar, 30).Value = datos._fecha_solicitud
            _adaptador.InsertCommand.Parameters.Add("@producto", SqlDbType.VarChar, 30).Value = datos._producto
            _adaptador.InsertCommand.Parameters.Add("@objetivo", SqlDbType.VarChar, 30).Value = datos._objetivo
            _adaptador.InsertCommand.Parameters.Add("@monto_solicitado", SqlDbType.VarChar, 11).Value = datos._monto_solicitado
            _adaptador.InsertCommand.Parameters.Add("@capital", SqlDbType.VarChar, 10).Value = datos._capital
            _adaptador.InsertCommand.Parameters.Add("@prepago", SqlDbType.VarChar, 25).Value = datos._prepago
            _adaptador.InsertCommand.Parameters.Add("@NroPrepagos", SqlDbType.VarChar, 35).Value = datos._NroPrepagos
            _adaptador.InsertCommand.Parameters.Add("@nrocuotas", SqlDbType.VarChar, 3).Value = datos._nrocuotas
            _adaptador.InsertCommand.Parameters.Add("@primera_cuota", SqlDbType.VarChar, 12).Value = datos._primera_cuota
            _adaptador.InsertCommand.Parameters.Add("@tasa", SqlDbType.VarChar, 6).Value = datos._tasa
            _adaptador.InsertCommand.Parameters.Add("@dias_gracia", SqlDbType.VarChar, 3).Value = datos._dias_gracia
            _adaptador.InsertCommand.Parameters.Add("@ncreditos", SqlDbType.VarChar, 3).Value = datos._ncreditos
            _adaptador.InsertCommand.Parameters.Add("@fechaprimervencimiento", SqlDbType.VarChar, 25).Value = datos._fechaprimervencimiento
            _adaptador.InsertCommand.Parameters.Add("@forpago", SqlDbType.VarChar, 15).Value = datos._forpago
            _adaptador.InsertCommand.Parameters.Add("@tiporenta", SqlDbType.VarChar, 15).Value = datos._tiporenta
            _adaptador.InsertCommand.Parameters.Add("@protestosmorocidades", SqlDbType.VarChar, 60).Value = datos._protestosmorocidades
            _adaptador.InsertCommand.Parameters.Add("@Edeudafinanciera", SqlDbType.VarChar, 12).Value = datos._Edeudafinanciera
            _adaptador.InsertCommand.Parameters.Add("@EdeudaHipo", SqlDbType.VarChar, 12).Value = datos._EdeudaHipo
            _adaptador.InsertCommand.Parameters.Add("@EdeudaConsumo", SqlDbType.VarChar, 12).Value = datos._EdeudaConsumo
            _adaptador.InsertCommand.Parameters.Add("@EdeudaComercial", SqlDbType.VarChar, 12).Value = datos._EdeudaComercial
            _adaptador.InsertCommand.Parameters.Add("@EDeudadVencidas", SqlDbType.VarChar, 12).Value = datos._EDeudadVencidas
            _adaptador.InsertCommand.Parameters.Add("@ELineaCredito", SqlDbType.VarChar, 12).Value = datos._ELineaCredito
            _adaptador.InsertCommand.Parameters.Add("@ENumeroAcreedores", SqlDbType.VarChar, 2).Value = datos._ENumeroAcreedores
            _adaptador.InsertCommand.Parameters.Add("@Itotaldeuda", SqlDbType.VarChar, 12).Value = datos._Itotaldeuda
            _adaptador.InsertCommand.Parameters.Add("@IdeudaConsumo", SqlDbType.VarChar, 12).Value = datos._IdeudaConsumo
            _adaptador.InsertCommand.Parameters.Add("@IdeudaComercial", SqlDbType.VarChar, 12).Value = datos._IdeudaComercial
            _adaptador.InsertCommand.Parameters.Add("@IDeudaIndirecta", SqlDbType.VarChar, 12).Value = datos._IDeudaIndirecta
            _adaptador.InsertCommand.Parameters.Add("@IPagoMensual", SqlDbType.VarChar, 10).Value = datos._IPagoMensual
            _adaptador.InsertCommand.Parameters.Add("@RLP", SqlDbType.VarChar, 15).Value = datos._RLP
            _adaptador.InsertCommand.Parameters.Add("@CargaFinanciera", SqlDbType.VarChar, 15).Value = datos._CargaFinanciera
            _adaptador.InsertCommand.Parameters.Add("@ExternaAcreditado", SqlDbType.VarChar, 10).Value = datos._ExternaAcreditado
            _adaptador.InsertCommand.Parameters.Add("@Activos", SqlDbType.VarChar, 10).Value = datos._Activos
            _adaptador.InsertCommand.Parameters.Add("@Propiedades", SqlDbType.VarChar, 10).Value = datos._Propiedades
            _adaptador.InsertCommand.Parameters.Add("@Vehiculos", SqlDbType.VarChar, 10).Value = datos._Vehiculos
            _adaptador.InsertCommand.Parameters.Add("@RentaLiquidaDepurada", SqlDbType.VarChar, 25).Value = datos._RentaLiquidaDepurada
            _adaptador.InsertCommand.Parameters.Add("@LVL", SqlDbType.VarChar, 4).Value = datos._LVL
            _adaptador.InsertCommand.Parameters.Add("@capacidad", SqlDbType.VarChar, 8).Value = datos._capacidad
            _adaptador.InsertCommand.Parameters.Add("@Ejecutiva", SqlDbType.VarChar, 15).Value = datos._Ejecutiva
            _adaptador.InsertCommand.Parameters.Add("@Validaciones", SqlDbType.VarChar, 500).Value = datos._Validaciones
            _adaptador.InsertCommand.Parameters.Add("@Sucursal", SqlDbType.VarChar, 25).Value = datos._Sucursal
            _adaptador.InsertCommand.Parameters.Add("@Comentario_Ejecutiva", SqlDbType.VarChar, 550).Value = datos._Comentario_Ejecutiva
            '_adaptador.InsertCommand.Parameters.Add("@Comentario_Riesgo", SqlDbType.VarChar, 550).Value = datos._Comentario_Riesgo
            _adaptador.InsertCommand.Parameters.Add("@Aprobacion_Gerencia", SqlDbType.VarChar, 20).Value = datos._Aprobacion_Gerencia
            _adaptador.InsertCommand.Parameters.Add("@Aprobacion_SubGerencia", SqlDbType.VarChar, 20).Value = datos._Aprobacion_SubGerencia
            _adaptador.InsertCommand.Parameters.Add("@Aprobacion_Operaciones", SqlDbType.VarChar, 20).Value = datos._Aprobacion_Operaciones
            _adaptador.InsertCommand.Parameters.Add("@Aprobacion_Comision_Credito_Interno", SqlDbType.VarChar, 20).Value = datos._Aprobacion_Comision_Credito_Interno
            _adaptador.InsertCommand.Parameters.Add("@Aprobacion_Comision_Credito_Superior", SqlDbType.VarChar, 20).Value = datos._Aprobacion_Comision_Credito_Superior
            _adaptador.InsertCommand.Parameters.Add("@Estado", SqlDbType.VarChar, 50).Value = datos._Estado
            _adaptador.InsertCommand.Parameters.Add("@Puntaje", SqlDbType.VarChar, 10).Value = datos._Puntaje
            _adaptador.InsertCommand.Parameters.Add("@Edad", SqlDbType.VarChar, 3).Value = datos._Edad
            _adaptador.InsertCommand.Parameters.Add("@Anos_antiguedad", SqlDbType.VarChar, 3).Value = datos._Anos_Antiguedad
            _adaptador.InsertCommand.Parameters.Add("@Anos_contrato", SqlDbType.VarChar, 3).Value = datos._Anos_Contrato
            _adaptador.InsertCommand.Parameters.Add("@Atribucion", SqlDbType.VarChar, 2).Value = datos._Atribucion
            _adaptador.InsertCommand.Parameters.Add("@V_Puntaje", SqlDbType.Int).Value = datos._V_Puntaje
            _adaptador.InsertCommand.Parameters.Add("@V_Capacidad", SqlDbType.Int).Value = datos._V_Capacidad
            _adaptador.InsertCommand.Parameters.Add("@V_Endeudamiento", SqlDbType.Int).Value = datos._V_Endeudamiento
            _adaptador.InsertCommand.Parameters.Add("@V_Comerciales", SqlDbType.Int).Value = datos._V_Comerciales
            _adaptador.InsertCommand.Parameters.Add("@V_Antiguedad10", SqlDbType.Int).Value = datos._V_Antiguedad10
            _adaptador.InsertCommand.Parameters.Add("@V_Antiguedad1", SqlDbType.Int).Value = datos._V_Antiguedad1
            _adaptador.InsertCommand.Parameters.Add("@V_Moras", SqlDbType.Int).Value = datos._V_Moras
            _adaptador.InsertCommand.Parameters.Add("@V_Edad", SqlDbType.Int).Value = datos._V_Edad
            _adaptador.InsertCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 65).Value = datos._Nombre
            _adaptador.InsertCommand.Parameters.Add("@Rut", SqlDbType.VarChar, 11).Value = datos._Rut
            _adaptador.InsertCommand.Parameters.Add("@Monto_capital", SqlDbType.VarChar, 10).Value = datos._Monto_Capital
            _adaptador.InsertCommand.Parameters.Add("@Cuotas_prepago", SqlDbType.VarChar, 10).Value = datos._Cuotas_prepago
            _adaptador.InsertCommand.Parameters.Add("@Presocio", SqlDbType.VarChar, 8).Value = datos._Presocios
            _adaptador.InsertCommand.Parameters.Add("@Puntajes_Validaciones", SqlDbType.VarChar, 700).Value = datos._Puntajes_Validaciones
            _adaptador.InsertCommand.Parameters.Add("@comportamiento_clasificacion", SqlDbType.VarChar, 5).Value = datos._Comportamiento_Clasificacion
            _adaptador.InsertCommand.Parameters.Add("@comportamiento_abonocapital", SqlDbType.VarChar, 5).Value = datos._Comportamiento_Capital
            _adaptador.InsertCommand.Parameters.Add("@comportamiento_baja_clasificacion", SqlDbType.VarChar, 30).Value = datos._Comportamiento_Clasificacion_Baja
            _adaptador.InsertCommand.Parameters.Add("@Tasa_aumento", SqlDbType.VarChar, 3).Value = datos._Tasa_Aumento
            _adaptador.InsertCommand.Parameters.Add("@Ejecutivo_convenio", SqlDbType.VarChar, 40).Value = datos._Ejecutivo_Convenio
            _adaptador.InsertCommand.Parameters.Add("@Tasa_solicitada", SqlDbType.VarChar, 20).Value = datos._Tasa_solicitada
            _adaptador.InsertCommand.Parameters.Add("@renegocia_refinancia", SqlDbType.VarChar, 3).Value = datos._ReRef
            _adaptador.InsertCommand.Parameters.Add("@PreAprobacion_Riesgo", SqlDbType.VarChar, 20).Value = datos._PreAprobacion_Riesgo
            _adaptador.InsertCommand.Parameters.Add("@PreAprobacion_Agente", SqlDbType.VarChar, 25).Value = datos._Aprobacion_Pre_Agencia
            _adaptador.InsertCommand.Parameters.Add("@Sede", SqlDbType.VarChar, 20).Value = datos._Sede
            _adaptador.InsertCommand.Parameters.Add("@FueraDeZona", SqlDbType.VarChar, 2).Value = datos._FueraDeZona
            _adaptador.InsertCommand.Parameters.Add("@Formadepago2", SqlDbType.VarChar, 40).Value = datos._Formadepago2
            _adaptador.InsertCommand.Parameters.Add("@Region", SqlDbType.VarChar, 20).Value = datos._Region
            _adaptador.InsertCommand.Parameters.Add("@Institucion", SqlDbType.VarChar, 50).Value = datos._Institucion
            _adaptador.InsertCommand.Parameters.Add("@Plataforma", SqlDbType.VarChar, 30).Value = datos._Plataforma
            _adaptador.InsertCommand.Parameters.Add("@tasa_castigada", SqlDbType.VarChar, 6).Value = datos._tasa_castigada
            _adaptador.InsertCommand.Parameters.Add("@Descuento_campaña", SqlDbType.VarChar, 15).Value = datos._descuento_campaña
            _adaptador.InsertCommand.Parameters.Add("@tasa_real", SqlDbType.VarChar, 6).Value = datos._tasa_real
            _adaptador.InsertCommand.Parameters.Add("@comentario_tasa", SqlDbType.VarChar, 575).Value = datos._comentario_tasa
            _adaptador.InsertCommand.Parameters.Add("@Eperiodo", SqlDbType.VarChar, 6).Value = datos._EPerido
            _adaptador.InsertCommand.Parameters.Add("@EDeudadVencidasIndirectas", SqlDbType.VarChar, 12).Value = datos._EDeudasVencidasIndirectas
            _adaptador.InsertCommand.Parameters.Add("@RutAval1", SqlDbType.VarChar, 11).Value = datos._Aval1
            _adaptador.InsertCommand.Parameters.Add("@RutAval2", SqlDbType.VarChar, 11).Value = datos._Aval2
            _adaptador.InsertCommand.Parameters.Add("@modificaciondeudaexterna", SqlDbType.VarChar, 2).Value = datos._modificaciondeudaexterna
            _adaptador.InsertCommand.Parameters.Add("@PYM6", SqlDbType.VarChar, 11).Value = datos._PYM6
            _adaptador.InsertCommand.Parameters.Add("@PYM6A12", SqlDbType.VarChar, 11).Value = datos._PYM6A12
            _adaptador.InsertCommand.Parameters.Add("@PYM12A24", SqlDbType.VarChar, 11).Value = datos._PYM12A24
            _adaptador.InsertCommand.Parameters.Add("@PYM24", SqlDbType.VarChar, 11).Value = datos._PYM24
            _adaptador.InsertCommand.Parameters.Add("@ID_RENTA", SqlDbType.VarChar, 11).Value = datos._ID_RENTA
            _adaptador.InsertCommand.Parameters.Add("@MaximoMontoPlanilla", SqlDbType.VarChar, 11).Value = datos._MaximoMontoPlanilla
            _adaptador.InsertCommand.Parameters.Add("@MaximaCuotaPlanilla", SqlDbType.VarChar, 11).Value = datos._MaximaCuotaPlanilla
            _adaptador.InsertCommand.Parameters.Add("@COD_DACA", SqlDbType.VarChar, 11).Value = datos._CODDACA
            _adaptador.InsertCommand.Parameters.Add("@Atencion", SqlDbType.VarChar, 15).Value = datos._ATENCION
            _adaptador.InsertCommand.Parameters.Add("@MES_PRIMERA", SqlDbType.VarChar, 2).Value = datos._MES_PRIMERA
            _adaptador.InsertCommand.Parameters.Add("@ANO_PRIMERA", SqlDbType.VarChar, 4).Value = datos._ANO_PRIMERA
            _adaptador.InsertCommand.Parameters.Add("@COD_FORMAPAGO ", SqlDbType.VarChar, 3).Value = datos._COD_FORMAPAGO
            _adaptador.InsertCommand.Parameters.Add("@COD_INST", SqlDbType.VarChar, 2).Value = datos._COD_INST
            _adaptador.InsertCommand.Parameters.Add("@ESTADO_INI", SqlDbType.VarChar, 50).Value = datos._ESTADO_INI
            _adaptador.InsertCommand.Parameters.Add("@DISPONIBLE", SqlDbType.VarChar, 20).Value = datos._Disponible
            _adaptador.InsertCommand.Parameters.Add("@CUOTA_ULTIMA", SqlDbType.VarChar, 50).Value = datos._CuotaUltima
            _adaptador.InsertCommand.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar, 3).Value = datos._COD_SUCURSAL
            conexiones.abrir()
            _adaptador.InsertCommand.Connection = conexiones._conexion
            _adaptador.InsertCommand.ExecuteNonQuery()
        Catch ex As SqlException
            estado = False
            MsgBox(Err.Description)
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function



    Public Function Actualizar_Prestamo_enviado_Riesgo(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.UpdateCommand = New SqlCommand("update _RIESGO_PRESTAMOS_SOLICITADOS set  Estado= @Estado,Fecha_riesgo= SYSDATETIME () ,Riesgo_perfil=@Riesgo_perfil ,PreAprobacion_Riesgo=@PreAprobacion_Riesgo , Condicional_Tasa_R=@Condicional_Tasa_R , Condicional_Monto_R=@Condicional_Monto_R ,Condicional_Plazo_R=@Condicional_Plazo_R,Condicional_R=@Condicional_R  where id_solicitud=@id_solicitud    IF EXISTS (SELECT * FROM _RIESGO_COMENTARIOS_PRESTAMOS WHERE id_solicitud=@id_solicitud)  update _RIESGO_COMENTARIOS_PRESTAMOS set Comentario_Riesgo= @Comentario_Riesgo where id_solicitud=@id_solicitud  ELSE  INSERT INTO _RIESGO_COMENTARIOS_PRESTAMOS (id_solicitud,Comentario_Riesgo) values (@id_solicitud,@Comentario_Riesgo)  ", conexiones._conexion)
            _adaptador.UpdateCommand.Parameters.Add("@Comentario_Riesgo", SqlDbType.VarChar).Value = datos._Comentario_Riesgo
            _adaptador.UpdateCommand.Parameters.Add("@Estado", SqlDbType.VarChar, 100).Value = datos._Estado
            _adaptador.UpdateCommand.Parameters.Add("@id_solicitud", SqlDbType.VarChar, 50).Value = datos._id_solicitud
            _adaptador.UpdateCommand.Parameters.Add("@Riesgo_perfil", SqlDbType.VarChar, 50).Value = datos._Riesgo_Perfil
            _adaptador.UpdateCommand.Parameters.Add("@PreAprobacion_Riesgo", SqlDbType.VarChar, 25).Value = datos._Aprobacion_Riesgo
            _adaptador.UpdateCommand.Parameters.Add("@Condicional_Tasa_R", SqlDbType.VarChar, 5).Value = datos._Condicion_Tasa_R
            _adaptador.UpdateCommand.Parameters.Add("@Condicional_Monto_R", SqlDbType.VarChar, 15).Value = datos._Condicion_Monto_R
            _adaptador.UpdateCommand.Parameters.Add("@Condicional_Plazo_R", SqlDbType.VarChar, 3).Value = datos._Condicion_Plazo_R
            _adaptador.UpdateCommand.Parameters.Add("@Condicional_R", SqlDbType.VarChar, 150).Value = datos._Condicional_R
            conexiones._conexion.Open()
            _adaptador.UpdateCommand.Connection = conexiones._conexion
            _adaptador.UpdateCommand.ExecuteNonQuery()
        Catch ex As SqlException
            estado = False
            MsgBox(Err.Description)
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function
    Public Function Actualizar_Prestamo_enviado_Riesgo_Renta(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.UpdateCommand = New SqlCommand("update _RIESGO_PRESTAMOS_SOLICITADOS set Riesgo_Renta_Verifica=@Riesgo_Renta_Verifica  where id_solicitud=@id_solicitud   ", conexiones._conexion)
            _adaptador.UpdateCommand.Parameters.Add("@id_solicitud", SqlDbType.VarChar, 50).Value = datos._id_solicitud
            _adaptador.UpdateCommand.Parameters.Add("@Riesgo_Renta_Verifica", SqlDbType.VarChar, 15).Value = datos._Aprobacion_Riesgo
            conexiones._conexion.Open()
            _adaptador.UpdateCommand.Connection = conexiones._conexion
            _adaptador.UpdateCommand.ExecuteNonQuery()
        Catch ex As SqlException
            estado = False
            MsgBox(Err.Description)
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function

    Public Function Actualizar_Codigo_Presocio(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.UpdateCommand = New SqlCommand("  update _PRESOCIOS set Cod_Presocio=(SELECT top 1 rtrim(id_solicitud) FROM [_RIESGO_PRESTAMOS_SOLICITADOS] where Presocio=@Presocios order by convert(integer,id_solicitud) desc ) where nrosocio=@Presocios ", conexiones._conexion)
            _adaptador.UpdateCommand.Parameters.Add("@Presocios", SqlDbType.VarChar, 250).Value = datos._Presocios
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


    Public Function Actualizar_Prestamo_enviado_APROBAR_GERENCIA(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.UpdateCommand = New SqlCommand("update _RIESGO_PRESTAMOS_SOLICITADOS set Aprobacion_Gerencia= @Aprobacion_Gerencia,Fecha_gerencia= SYSDATETIME () , Gerencia_Perfil=@Gerencia_Perfil ,Condicional=@Condicional , Condicional_Tasa=@Condicional_Tasa , Condicional_Monto=@Condicional_Monto ,Condicional_Plazo=@Condicional_Plazo   where id_solicitud=@id_solicitud            IF EXISTS (SELECT * FROM _RIESGO_COMENTARIOS_PRESTAMOS WHERE id_solicitud=@id_solicitud)  update _RIESGO_COMENTARIOS_PRESTAMOS set Comentario_Gerente= @Comentario_Gerente where id_solicitud=@id_solicitud  ELSE  INSERT INTO _RIESGO_COMENTARIOS_PRESTAMOS (id_solicitud,Comentario_Gerente) values (@id_solicitud,@Comentario_Gerente)               ", conexiones._conexion)
            _adaptador.UpdateCommand.Parameters.Add("@Aprobacion_Gerencia", SqlDbType.VarChar, 250).Value = datos._Aprobacion_Gerencia
            _adaptador.UpdateCommand.Parameters.Add("@id_solicitud", SqlDbType.VarChar, 250).Value = datos._id_solicitud
            _adaptador.UpdateCommand.Parameters.Add("@Comentario_Gerente", SqlDbType.VarChar).Value = datos._Comentario_Gerencia
            _adaptador.UpdateCommand.Parameters.Add("@Gerencia_Perfil", SqlDbType.VarChar, 250).Value = datos._Gerente_Perfil
            _adaptador.UpdateCommand.Parameters.Add("@Condicional", SqlDbType.VarChar, 150).Value = datos._Condicional
            _adaptador.UpdateCommand.Parameters.Add("@Condicional_Tasa", SqlDbType.VarChar, 60).Value = datos._Condicion_Tasa
            _adaptador.UpdateCommand.Parameters.Add("@Condicional_Monto", SqlDbType.VarChar, 60).Value = datos._Condicion_Monto
            _adaptador.UpdateCommand.Parameters.Add("@Condicional_Plazo", SqlDbType.VarChar, 60).Value = datos._Condicion_Plazo

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


    Public Function Actualizar_Prestamo_enviado_APROBAR_SUBGERENCIA(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.UpdateCommand = New SqlCommand("update _RIESGO_PRESTAMOS_SOLICITADOS set Aprobacion_SubGerencia= @Aprobacion_SubGerencia ,fecha_subgerente= SYSDATETIME () , Subgerencia_Perfil=@Subgerencia_Perfil  ,Condicional=@Condicional , Condicional_Tasa=@Condicional_Tasa , Condicional_Monto=@Condicional_Monto ,Condicional_Plazo=@Condicional_Plazo  where id_solicitud=@id_solicitud                   IF EXISTS (SELECT * FROM _RIESGO_COMENTARIOS_PRESTAMOS WHERE id_solicitud=@id_solicitud)  update _RIESGO_COMENTARIOS_PRESTAMOS set Comentario_SubGerente= @Comentario_SubGerente where id_solicitud=@id_solicitud  ELSE  INSERT INTO _RIESGO_COMENTARIOS_PRESTAMOS (id_solicitud,Comentario_SubGerente) values (@id_solicitud,@Comentario_SubGerente)           ", conexiones._conexion)
            _adaptador.UpdateCommand.Parameters.Add("@Aprobacion_SubGerencia", SqlDbType.VarChar, 250).Value = datos._Aprobacion_SubGerencia
            _adaptador.UpdateCommand.Parameters.Add("@id_solicitud", SqlDbType.VarChar, 250).Value = datos._id_solicitud
            _adaptador.UpdateCommand.Parameters.Add("@Comentario_SubGerente", SqlDbType.VarChar).Value = datos._Comentario_Subgerencia
            _adaptador.UpdateCommand.Parameters.Add("@Subgerencia_Perfil", SqlDbType.VarChar, 250).Value = datos._Subgerente_Perfil
            _adaptador.UpdateCommand.Parameters.Add("@Condicional", SqlDbType.VarChar, 150).Value = datos._Condicional
            _adaptador.UpdateCommand.Parameters.Add("@Condicional_Tasa", SqlDbType.VarChar, 60).Value = datos._Condicion_Tasa
            _adaptador.UpdateCommand.Parameters.Add("@Condicional_Monto", SqlDbType.VarChar, 60).Value = datos._Condicion_Monto
            _adaptador.UpdateCommand.Parameters.Add("@Condicional_Plazo", SqlDbType.VarChar, 60).Value = datos._Condicion_Plazo
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


    Public Function Actualizar_Prestamo_enviado_APROBAR_CCI(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.UpdateCommand = New SqlCommand("update _RIESGO_PRESTAMOS_SOLICITADOS set Aprobacion_Comision_Credito_Interno=@Aprobacion_Comision_Credito_Interno ,Fecha_CCI= SYSDATETIME () , CCI_Perfil=@CCI_Perfil  ,Condicional=@Condicional , Condicional_Tasa=@Condicional_Tasa , Condicional_Monto=@Condicional_Monto ,Condicional_Plazo=@Condicional_Plazo where id_solicitud=@id_solicitud", conexiones._conexion)
            _adaptador.UpdateCommand.Parameters.Add("@Aprobacion_Comision_Credito_Interno", SqlDbType.VarChar, 250).Value = datos._Aprobacion_Comision_Credito_Interno
            _adaptador.UpdateCommand.Parameters.Add("@id_solicitud", SqlDbType.VarChar, 250).Value = datos._id_solicitud
            _adaptador.UpdateCommand.Parameters.Add("@CCI_Perfil", SqlDbType.VarChar, 250).Value = datos._CCI_Perfil
            _adaptador.UpdateCommand.Parameters.Add("@Condicional", SqlDbType.VarChar, 150).Value = datos._Condicional
            _adaptador.UpdateCommand.Parameters.Add("@Condicional_Tasa", SqlDbType.VarChar, 60).Value = datos._Condicion_Tasa
            _adaptador.UpdateCommand.Parameters.Add("@Condicional_Monto", SqlDbType.VarChar, 60).Value = datos._Condicion_Monto
            _adaptador.UpdateCommand.Parameters.Add("@Condicional_Plazo", SqlDbType.VarChar, 60).Value = datos._Condicion_Plazo
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

    Public Function Actualizar_Prestamo_enviado_APROBAR_CCS(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.UpdateCommand = New SqlCommand("update _RIESGO_PRESTAMOS_SOLICITADOS set Aprobacion_Comision_Credito_Superior=@Aprobacion_Comision_Credito_Superior ,Fecha_CCS= SYSDATETIME () , CCS_Perfil=@CCS_Perfil  ,Condicional=@Condicional , Condicional_Tasa=@Condicional_Tasa , Condicional_Monto=@Condicional_Monto ,Condicional_Plazo=@Condicional_Plazo where id_solicitud=@id_solicitud", conexiones._conexion)
            _adaptador.UpdateCommand.Parameters.Add("@Aprobacion_Comision_Credito_Superior", SqlDbType.VarChar, 250).Value = datos._Aprobacion_Comision_Credito_Superior
            _adaptador.UpdateCommand.Parameters.Add("@id_solicitud", SqlDbType.VarChar, 250).Value = datos._id_solicitud
            _adaptador.UpdateCommand.Parameters.Add("@CCS_Perfil", SqlDbType.VarChar, 250).Value = datos._CCS_Perfil
            _adaptador.UpdateCommand.Parameters.Add("@Condicional", SqlDbType.VarChar, 150).Value = datos._Condicional
            _adaptador.UpdateCommand.Parameters.Add("@Condicional_Tasa", SqlDbType.VarChar, 60).Value = datos._Condicion_Tasa
            _adaptador.UpdateCommand.Parameters.Add("@Condicional_Monto", SqlDbType.VarChar, 60).Value = datos._Condicion_Monto
            _adaptador.UpdateCommand.Parameters.Add("@Condicional_Plazo", SqlDbType.VarChar, 60).Value = datos._Condicion_Plazo
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




    Public Function Actualizar_Prestamo_enviado_APROBAR_OPERACIONES(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.UpdateCommand = New SqlCommand("update _RIESGO_PRESTAMOS_SOLICITADOS set Aprobacion_Operaciones= @Aprobacion_Operaciones ,Fecha_agencia= SYSDATETIME () , Agencia_Perfil=@Agencia_Perfil  ,Condicional=@Condicional , Condicional_Tasa=@Condicional_Tasa , Condicional_Monto=@Condicional_Monto ,Condicional_Plazo=@Condicional_Plazo where id_solicitud=@id_solicitud           IF EXISTS (SELECT * FROM _RIESGO_COMENTARIOS_PRESTAMOS WHERE id_solicitud=@id_solicitud)  update _RIESGO_COMENTARIOS_PRESTAMOS set Comentario_Agencia=@Comentario_Agencia where id_solicitud=@id_solicitud  ELSE  INSERT INTO _RIESGO_COMENTARIOS_PRESTAMOS (id_solicitud,Comentario_Agencia) values (@id_solicitud,@Comentario_Agencia)            ", conexiones._conexion)
            _adaptador.UpdateCommand.Parameters.Add("@Aprobacion_Operaciones", SqlDbType.VarChar, 250).Value = datos._Aprobacion_Operaciones
            _adaptador.UpdateCommand.Parameters.Add("@id_solicitud", SqlDbType.VarChar, 250).Value = datos._id_solicitud
            _adaptador.UpdateCommand.Parameters.Add("@Comentario_Agencia", SqlDbType.VarChar, 250).Value = datos._Comentario_Agencia
            _adaptador.UpdateCommand.Parameters.Add("@Agencia_Perfil", SqlDbType.VarChar, 250).Value = datos._Agencia_Perfil
            _adaptador.UpdateCommand.Parameters.Add("@Condicional", SqlDbType.VarChar, 150).Value = datos._Condicional
            _adaptador.UpdateCommand.Parameters.Add("@Condicional_Tasa", SqlDbType.VarChar, 60).Value = datos._Condicion_Tasa
            _adaptador.UpdateCommand.Parameters.Add("@Condicional_Monto", SqlDbType.VarChar, 60).Value = datos._Condicion_Monto
            _adaptador.UpdateCommand.Parameters.Add("@Condicional_Plazo", SqlDbType.VarChar, 60).Value = datos._Condicion_Plazo

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
    Public Function Actualizar_Prestamo_enviado_APROBAR_OPERACIONES_PREPAGO(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.UpdateCommand = New SqlCommand("update _RIESGO_SOLICITUD_PREPAGO set Aprobacion_Operaciones= @Aprobacion_Operaciones ,Fecha_agencia= SYSDATETIME () , Agencia_Perfil=@Agencia_Perfil,Comentario_Agencia=@Comentario_Agencia ,Estado=@Estado  where id_solicitud=@id_solicitud  ", conexiones._conexion)
            _adaptador.UpdateCommand.Parameters.Add("@Aprobacion_Operaciones", SqlDbType.VarChar, 250).Value = datos._Aprobacion_Operaciones
            _adaptador.UpdateCommand.Parameters.Add("@id_solicitud", SqlDbType.VarChar, 250).Value = datos._id_solicitud
            _adaptador.UpdateCommand.Parameters.Add("@Comentario_Agencia", SqlDbType.VarChar, 450).Value = datos._Comentario_Agencia
            _adaptador.UpdateCommand.Parameters.Add("@Agencia_Perfil", SqlDbType.VarChar, 250).Value = datos._Agencia_Perfil
            _adaptador.UpdateCommand.Parameters.Add("@estado", SqlDbType.VarChar, 50).Value = datos._Estado

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
    Public Function Actualizar_Prestamo_enviado_APROBAR_PREAGENTE(ByVal datos As CDatos) As Boolean
        Dim estado As Boolean = True
        Try
            conexiones.conexion()
            _adaptador.UpdateCommand = New SqlCommand("update _RIESGO_PRESTAMOS_SOLICITADOS set PreAprobacion_Agente= @PreAprobacion_Agentes ,Fecha_preagencia= SYSDATETIME () ,PreAgencia_Perfil=@PREAgencia_Perfil , Estado=@Estado where id_solicitud=@id_solicitud                    IF EXISTS (SELECT * FROM _RIESGO_COMENTARIOS_PRESTAMOS WHERE id_solicitud=@id_solicitud)  update _RIESGO_COMENTARIOS_PRESTAMOS set Comentario_PreAgente= @Comentario_PreAgente , Comentario_PreAgente_Tipos=@Comentario_Pre_Agencia_Tipo where id_solicitud=@id_solicitud  ELSE  INSERT INTO _RIESGO_COMENTARIOS_PRESTAMOS (id_solicitud,Comentario_PreAgente,Comentario_PreAgente_Tipos) values (@id_solicitud,@Comentario_PreAgente,@Comentario_Pre_Agencia_Tipo)  ", conexiones._conexion)
            '_adaptador.UpdateCommand = New SqlCommand("update _RIESGO_PRESTAMOS_SOLICITADOS set PreAprobacion_Agente= @PreAprobacion_Agentes ,Fecha_preagencia= SYSDATETIME () ,PreAgencia_Perfil=@PREAgencia_Perfil where id_solicitud=@id_solicitud", conexiones._conexion)
            _adaptador.UpdateCommand.Parameters.Add("@Estado", SqlDbType.VarChar, 100).Value = datos._Estado
            _adaptador.UpdateCommand.Parameters.Add("@PreAprobacion_Agentes", SqlDbType.VarChar).Value = datos._Aprobacion_Pre_Agencia
            _adaptador.UpdateCommand.Parameters.Add("@id_solicitud", SqlDbType.VarChar).Value = datos._id_solicitud
            _adaptador.UpdateCommand.Parameters.Add("@Comentario_PreAgente", SqlDbType.VarChar).Value = datos._Comentario_Pre_Agencia
            _adaptador.UpdateCommand.Parameters.Add("@PREAgencia_Perfil", SqlDbType.VarChar).Value = datos._Pre_Agencia_Perfil
            _adaptador.UpdateCommand.Parameters.Add("@Comentario_Pre_Agencia_Tipo", SqlDbType.VarChar).Value = datos._Comentario_Pre_Agencia_Tipo
            conexiones._conexion.Open()
            _adaptador.UpdateCommand.Connection = conexiones._conexion
            _adaptador.UpdateCommand.ExecuteNonQuery()
        Catch ex As SqlException
            estado = False
            MsgBox(Err.Description)
        Finally
            conexiones.cerrar()
        End Try
        Return estado
    End Function


  
End Class
