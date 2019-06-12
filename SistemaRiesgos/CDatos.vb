Public Class CDatos
    Private IP As String = ""
    Private sql1 As String = ""
    Private Version As String = "5.19"
    Private Testeo As String = "NO"
    Private Perfil As String = ""
    Private Contraseña As String = ""
    Private ELineaCredito As String = ""
    Private ENumeroAcreedores As String = ""
    Private Itotaldeuda As String = ""
    Private IdeudaConsumo As String = ""
    Private IdeudaComercial As String = ""
    Private IDeudaIndirecta As String = ""
    Private IPagoMensual As String = ""
    Private RLP As String = ""
    Private CargaFinanciera As String = ""
    Private ExternaAcreditado As String = ""
    Private Activos As String = ""
    Private Propiedades As String = ""
    Private Vehiculos As String = ""
    Private RentaLiquidaDepurada As String = ""
    Private LVL As String = ""
    Private capacidad As String = ""
    Private Validaciones As String = ""
    Private Ejecutiva As String = ""
    Private Sucursal As String = ""
    Private Comentario_Ejecutiva As String = ""
    Private Comentario_Riesgo As String = ""
    Private Aprobacion_Gerencia As String = ""
    Private Aprobacion_SubGerencia As String = ""
    Private Aprobacion_Operaciones As String = ""
    Private Aprobacion_Comercial As String = ""
    Private Nrosocio As String = ""
    Private fecha_solicitud As String = ""
    Private producto As String = ""
    Private objetivo As String = ""
    Private monto_solicitado As String = ""
    Private capital As String = ""
    Private prepago As String = ""
    Private NroPrepagos As String = ""
    Private nrocuotas As String = ""
    Private primera_cuota As String = ""
    Private tasa As String = ""
    Private dias_gracia As String = ""
    Private ncreditos As String = ""
    Private fechaprimervencimiento As String = ""
    Private forpago As String = ""
    Private tiporenta As String = ""
    Private protestosmorocidades As String = ""
    Private comportamientopago As String = ""
    Private Edeudafinanciera As String = ""
    Private EdeudaHipo As String = ""
    Private EdeudaConsumo As String = ""
    Private EdeudaComercial As String = ""
    Private EDeudadVencidas As String = ""
    Private Estado As String = ""
    Private Puntaje As String = ""
    Private Edad As String = ""
    Private Anos_Contrato As String = ""
    Private Anos_Antiguedad As String = ""
    Private id_solicitud As String = ""
    Private Atribucion As String = ""
    Private Aprobacion_Comision_Credito_Interno As String = ""
    Private Aprobacion_Comision_Credito_Superior As String = ""
    Private V_Puntaje As Integer = 0
    Private V_Capacidad As Integer = 0
    Private V_Endeudamiento As Integer = 0
    Private V_Comerciales As Integer = 0
    Private V_Antiguedad10 As Integer = 0
    Private V_Antiguedad1 As Integer = 0
    Private V_Moras As Integer = 0
    Private V_Edad As Integer = 0
    Private Nombre As String = ""
    Private Rut As String = ""
    Private Monto_Capital As String = ""
    Private Cuotas_prepago As String = ""
    Private Comentario_Gerencia As String = ""
    Private Comentario_Subgerencia As String = ""
    Private Comentario_Agencia As String = ""
    Private Aprobacion As String = ""
    Private Puntajes_Validaciones As String = ""
    Private Riesgo_Perfil As String = ""
    Private Agencia_Perfil As String = ""
    Private Subgerente_Perfil As String = ""
    Private Gerente_Perfil As String = ""
    Private CCI_Perfil As String = ""
    Private CCS_Perfil As String = ""
    Private Condicional As String = ""
    Private Condicional_R As String = ""
    Private Presocios As String = ""
    Private idprestamo2 As Integer = 0
    Private enpermisos As String = ""
    Private perfil_NOMBRE As String = ""
    Private perfil_USUARIO As String = ""
    Private perfil_DEPARTAMENTO As String = ""
    Private perfil_SUCURSAL As String = ""
    Private perfil_CARGO As String = ""
    Private perfil_ATRIBUTO As String = ""
    Private perfil_ENCONTRASENA As String = ""
    Private perfil_ENSUPERCONTRASENA As String = ""
    Private perfil_ENPERMISOS As String = ""
    Private Compromiso_Rut As String = ""
    Private Compromiso_Usuario As String = ""
    Private Comportamiento_Clasificacion As String = ""
    Private Comportamiento_Capital As String = ""
    Private Comportamiento_Clasificacion_Baja As String = ""
    Private Tasa_Aumento As String = ""
    Private Analisis As String = ""
    Private Ejecutivo_Convenio As String = ""
    Private Modifica_Tasa As String = ""
    Private Corcredito As String = ""
    Private Tasa_solicitada As String = ""
    Private Condicion_Tasa As String = ""
    Private Condicion_Monto As String = ""
    Private Condicion_Plazo As String = ""
    Private Condicion_Tasa_R As String = ""
    Private Condicion_Monto_R As String = ""
    Private Condicion_Plazo_R As String = ""
    Private ReRef As String = ""
    Private PreAprobacion_Riesgo As String = ""
    Private Pre_Agencia_Perfil As String = ""
    Private Comentario_Pre_Agencia As String = ""
    Private Comentario_Pre_Agencia_Tipo As String = ""
    Private Aprobacion_Pre_Agencia As String = ""
    Private Aprobacion_Riesgo As String = ""
    Private Sede As String = ""
    Private FueraDeZona As String = ""
    Private Formadepago2 As String = ""
    Private Region As String = ""
    Private Institucion As String = ""
    Private Plataforma As String = ""
    Private Sql As String = ""
    Private Tipo As String = ""
    Private Categoria As String = ""
    Private Rango1 As String = ""
    Private Rango2 As String = ""
    Private Bueno As String = ""
    Private Malo As String = ""
    Private SubCategoria As String = ""
    Private numerico As String = ""
    Private id_tipo As String = ""
    Private saldo As String = ""
    Private castigo As String = ""
    Private comentario_tasa As String = ""
    Private tasa_real As String = ""
    Private tasa_castigada As String = ""
    Private descuento_campaña As String = ""
    Private EPerido As String = ""
    Private EDeudasVencidasIndirectas As String = ""
    Private Aval1 As String = ""
    Private Aval2 As String = ""
    Private modificaciondeudaexterna As String = ""

    Private PYM6 As String = ""
    Private PYM12A24 As String = ""
    Private PYM6A12 As String = ""
    Private PYM24 As String = ""

    Private CADENA As String = ""
    Private CODDACA As String = ""

    Private ID_RENTA As String = ""
    Private MaximoMontoPlanilla As String = ""
    Private MaximaCuotaPlanilla As String = ""


    Private MES_PRIMERA As String = ""
    Private ANO_PRIMERA As String = ""
    Private COD_FORMAPAGO As String = ""
    Private COD_INST As String = ""
    Private ESTADO_INI As String = ""
    Private ATENCION As String = ""

    Private Disponible As String = ""
    Private CuotaUltima As String = ""
    Private COD_SUCURSAL As String = ""
    Public Property _IP() As String
        Get
            Return IP
        End Get
        Set(ByVal value As String)
            IP = value
        End Set
    End Property

    Public Property _Aprobacion_Comercial() As String
        Get
            Return Aprobacion_Comercial
        End Get
        Set(ByVal value As String)
            Aprobacion_Comercial = value
        End Set
    End Property

    Public Property _COD_SUCURSAL() As String
        Get
            Return COD_SUCURSAL
        End Get
        Set(ByVal value As String)
            COD_SUCURSAL = value
        End Set
    End Property

    Public Property _Disponible() As String
        Get
            Return Disponible
        End Get
        Set(ByVal value As String)
            Disponible = value
        End Set
    End Property
    Public Property _CuotaUltima() As String
        Get
            Return CuotaUltima
        End Get
        Set(ByVal value As String)
            CuotaUltima = value
        End Set
    End Property
    Public Property _ATENCION() As String
        Get
            Return ATENCION
        End Get
        Set(ByVal value As String)
            ATENCION = value
        End Set
    End Property

    Public Property _MES_PRIMERA() As String
        Get
            Return MES_PRIMERA
        End Get
        Set(ByVal value As String)
            MES_PRIMERA = value
        End Set
    End Property

    Public Property _ANO_PRIMERA() As String
        Get
            Return ANO_PRIMERA
        End Get
        Set(ByVal value As String)
            ANO_PRIMERA = value
        End Set
    End Property

    Public Property _COD_FORMAPAGO() As String
        Get
            Return COD_FORMAPAGO
        End Get
        Set(ByVal value As String)
            COD_FORMAPAGO = value
        End Set
    End Property

    Public Property _COD_INST() As String
        Get
            Return COD_INST
        End Get
        Set(ByVal value As String)
            COD_INST = value
        End Set
    End Property
    Public Property _ESTADO_INI() As String
        Get
            Return ESTADO_INI
        End Get
        Set(ByVal value As String)
            ESTADO_INI = value
        End Set
    End Property
    Public Property _sql1() As String
        Get
            Return sql1
        End Get
        Set(ByVal value As String)
            sql1 = value
        End Set
    End Property

    Public Property _CODDACA() As String
        Get
            Return CODDACA
        End Get
        Set(ByVal value As String)
            CODDACA = value
        End Set
    End Property

    Public Property _ID_RENTA() As String
        Get
            Return ID_RENTA
        End Get
        Set(ByVal value As String)
            ID_RENTA = value
        End Set
    End Property


    Public Property _MaximoMontoPlanilla() As String
        Get
            Return MaximoMontoPlanilla
        End Get
        Set(ByVal value As String)
            MaximoMontoPlanilla = value
        End Set
    End Property



    Public Property _MaximaCuotaPlanilla() As String
        Get
            Return MaximaCuotaPlanilla
        End Get
        Set(ByVal value As String)
            MaximaCuotaPlanilla = value
        End Set
    End Property




    Public Property _CADENA() As String
        Get
            Return CADENA
        End Get
        Set(ByVal value As String)
            CADENA = value
        End Set
    End Property

    Public Property _PYM6() As String
        Get
            Return PYM6
        End Get
        Set(ByVal value As String)
            PYM6 = value
        End Set
    End Property

    Public Property _PYM12A24() As String
        Get
            Return PYM12A24
        End Get
        Set(ByVal value As String)
            PYM12A24 = value
        End Set
    End Property

    Public Property _PYM6A12() As String
        Get
            Return PYM6A12
        End Get
        Set(ByVal value As String)
            PYM6A12 = value
        End Set
    End Property

    Public Property _PYM24() As String
        Get
            Return PYM24
        End Get
        Set(ByVal value As String)
            PYM24 = value
        End Set
    End Property



    Public Property _modificaciondeudaexterna() As String
        Get
            Return modificaciondeudaexterna
        End Get
        Set(ByVal value As String)
            modificaciondeudaexterna = value
        End Set
    End Property

    Public Property _Aval1() As String
        Get
            Return Aval1
        End Get
        Set(ByVal value As String)
            Aval1 = value
        End Set
    End Property
    Public Property _Aval2() As String
        Get
            Return Aval2
        End Get
        Set(ByVal value As String)
            Aval2 = value
        End Set
    End Property

    '[Categoria],[Rango1],[Rango2],[Bueno],[Malo] ,[SubCategoria] ,[numerico],FECHA_EDICION ,PERFIL,ID_TIPO
    Public Property _descuento_campaña() As String
        Get
            Return descuento_campaña
        End Get
        Set(ByVal value As String)
            descuento_campaña = value
        End Set
    End Property

    Public Property _comentario_tasa() As String
        Get
            Return comentario_tasa
        End Get
        Set(ByVal value As String)
            comentario_tasa = value
        End Set
    End Property
    Public Property _tasa_real() As String
        Get
            Return tasa_real
        End Get
        Set(ByVal value As String)
            tasa_real = value
        End Set
    End Property
    Public Property _tasa_castigada() As String
        Get
            Return tasa_castigada
        End Get
        Set(ByVal value As String)
            tasa_castigada = value
        End Set
    End Property




    Public Property _Saldo() As String
        Get
            Return saldo
        End Get
        Set(ByVal value As String)
            saldo = value
        End Set
    End Property
    Public Property _Castigo() As String
        Get
            Return castigo
        End Get
        Set(ByVal value As String)
            castigo = value
        End Set
    End Property
    Public Property _Tipo() As String
        Get
            Return Tipo
        End Get
        Set(ByVal value As String)
            Tipo = value
        End Set
    End Property
    Public Property _Categoria() As String
        Get
            Return Categoria
        End Get
        Set(ByVal value As String)
            Categoria = value
        End Set
    End Property
    Public Property _Rango1() As String
        Get
            Return Rango1
        End Get
        Set(ByVal value As String)
            Rango1 = value
        End Set
    End Property
    Public Property _Rango2() As String
        Get
            Return Rango2
        End Get
        Set(ByVal value As String)
            Rango2 = value
        End Set
    End Property
    Public Property _Bueno() As String
        Get
            Return Bueno
        End Get
        Set(ByVal value As String)
            Bueno = value
        End Set
    End Property
    Public Property _Malo() As String
        Get
            Return Malo
        End Get
        Set(ByVal value As String)
            Malo = value
        End Set
    End Property
    Public Property _SubCategoria() As String
        Get
            Return SubCategoria
        End Get
        Set(ByVal value As String)
            SubCategoria = value
        End Set
    End Property
    Public Property _numerico() As String
        Get
            Return numerico
        End Get
        Set(ByVal value As String)
            numerico = value
        End Set
    End Property
    Public Property _id_tipo() As String
        Get
            Return id_tipo
        End Get
        Set(ByVal value As String)
            id_tipo = value
        End Set
    End Property

    Public Property _Sql() As String
        Get
            Return Sql
        End Get
        Set(ByVal value As String)
            Sql = value
        End Set
    End Property

    Public Property _Plataforma() As String
        Get
            Return Plataforma
        End Get
        Set(ByVal value As String)
            Plataforma = value
        End Set
    End Property
    Public Property _Institucion() As String
        Get
            Return Institucion
        End Get
        Set(ByVal value As String)
            Institucion = value
        End Set
    End Property
    Public Property _Region() As String
        Get
            Return Region
        End Get
        Set(ByVal value As String)
            Region = value
        End Set
    End Property
    Public Property _Formadepago2() As String
        Get
            Return Formadepago2
        End Get
        Set(ByVal value As String)
            Formadepago2 = value
        End Set
    End Property


    Public Property _FueraDeZona() As String
        Get
            Return FueraDeZona
        End Get
        Set(ByVal value As String)
            FueraDeZona = value
        End Set
    End Property

    Public Property _Sede() As String
        Get
            Return Sede
        End Get
        Set(ByVal value As String)
            Sede = value
        End Set
    End Property

    Public Property _Comentario_Pre_Agencia_Tipo() As String
        Get
            Return Comentario_Pre_Agencia_Tipo
        End Get
        Set(ByVal value As String)
            Comentario_Pre_Agencia_Tipo = value
        End Set
    End Property
    Public Property _Aprobacion_Riesgo() As String
        Get
            Return Aprobacion_Riesgo
        End Get
        Set(ByVal value As String)
            Aprobacion_Riesgo = value
        End Set
    End Property
    Public Property _Pre_Agencia_Perfil() As String
        Get
            Return Pre_Agencia_Perfil
        End Get
        Set(ByVal value As String)
            Pre_Agencia_Perfil = value
        End Set
    End Property
    Public Property _Aprobacion_Pre_Agencia() As String
        Get
            Return Aprobacion_Pre_Agencia
        End Get
        Set(ByVal value As String)
            Aprobacion_Pre_Agencia = value
        End Set
    End Property

    Public Property _Comentario_Pre_Agencia() As String
        Get
            Return Comentario_Pre_Agencia
        End Get
        Set(ByVal value As String)
            Comentario_Pre_Agencia = value
        End Set
    End Property
    Public Property _PreAprobacion_Riesgo() As String
        Get
            Return PreAprobacion_Riesgo
        End Get
        Set(ByVal value As String)
            PreAprobacion_Riesgo = value
        End Set
    End Property

    Public Property _ReRef() As String
        Get
            Return ReRef
        End Get
        Set(ByVal value As String)
            ReRef = value
        End Set
    End Property
    Public Property _Condicion_Tasa() As String
        Get
            Return Condicion_Tasa
        End Get
        Set(ByVal value As String)
            Condicion_Tasa = value
        End Set
    End Property
    Public Property _Condicion_Monto() As String
        Get
            Return Condicion_Monto
        End Get
        Set(ByVal value As String)
            Condicion_Monto = value
        End Set
    End Property
    Public Property _Condicion_Plazo() As String
        Get
            Return Condicion_Plazo
        End Get
        Set(ByVal value As String)
            Condicion_Plazo = value
        End Set
    End Property
    Public Property _Condicion_Tasa_R() As String
        Get
            Return Condicion_Tasa_R
        End Get
        Set(ByVal value As String)
            Condicion_Tasa_R = value
        End Set
    End Property
    Public Property _Condicion_Monto_R() As String
        Get
            Return Condicion_Monto_R
        End Get
        Set(ByVal value As String)
            Condicion_Monto_R = value
        End Set
    End Property
    Public Property _Condicion_Plazo_R() As String
        Get
            Return Condicion_Plazo_R
        End Get
        Set(ByVal value As String)
            Condicion_Plazo_R = value
        End Set
    End Property


    Public Property _Tasa_solicitada() As String
        Get
            Return Tasa_solicitada
        End Get
        Set(ByVal value As String)
            Tasa_solicitada = value
        End Set
    End Property


    Public Property _Corcredito() As String
        Get
            Return Corcredito
        End Get
        Set(ByVal value As String)
            Corcredito = value
        End Set
    End Property

    Public Property _Ejecutivo_Convenio() As String
        Get
            Return Ejecutivo_Convenio
        End Get
        Set(ByVal value As String)
            Ejecutivo_Convenio = value
        End Set
    End Property

    Public Property _Modifica_Tasa() As String
        Get
            Return Modifica_Tasa
        End Get
        Set(ByVal value As String)
            Modifica_Tasa = value
        End Set
    End Property


    Public Property _Analisis() As String
        Get
            Return Analisis
        End Get
        Set(ByVal value As String)
            Analisis = value
        End Set
    End Property
    Public Property _Tasa_Aumento() As String
        Get
            Return Tasa_Aumento
        End Get
        Set(ByVal value As String)
            Tasa_Aumento = value
        End Set
    End Property
    Public Property _Testeo() As String
        Get
            Return Testeo
        End Get
        Set(ByVal value As String)
            Testeo = value
        End Set
    End Property
    Public Property _Comportamiento_Clasificacion() As String
        Get
            Return Comportamiento_Clasificacion
        End Get
        Set(ByVal value As String)
            Comportamiento_Clasificacion = value
        End Set
    End Property
    Public Property _Comportamiento_Capital() As String
        Get
            Return Comportamiento_Capital
        End Get
        Set(ByVal value As String)
            Comportamiento_Capital = value
        End Set
    End Property
    Public Property _Comportamiento_Clasificacion_Baja() As String
        Get
            Return Comportamiento_Clasificacion_Baja
        End Get
        Set(ByVal value As String)
            Comportamiento_Clasificacion_Baja = value
        End Set
    End Property
    Public Property _Compromiso_Rut() As String
        Get
            Return Compromiso_Rut
        End Get
        Set(ByVal value As String)
            Compromiso_Rut = value
        End Set
    End Property
    Public Property _Compromiso_Usuario() As String
        Get
            Return Compromiso_Usuario
        End Get
        Set(ByVal value As String)
            Compromiso_Usuario = value
        End Set
    End Property
    Public Property _perfil_NOMBRE() As String
        Get
            Return perfil_NOMBRE
        End Get
        Set(ByVal value As String)
            perfil_NOMBRE = value
        End Set
    End Property
    Public Property _perfil_USUARIO() As String
        Get
            Return perfil_USUARIO
        End Get
        Set(ByVal value As String)
            perfil_USUARIO = value
        End Set
    End Property
    Public Property _perfil_DEPARTAMENTO() As String
        Get
            Return perfil_DEPARTAMENTO
        End Get
        Set(ByVal value As String)
            perfil_DEPARTAMENTO = value
        End Set
    End Property
    Public Property _perfil_SUCURSAL() As String
        Get
            Return perfil_SUCURSAL
        End Get
        Set(ByVal value As String)
            perfil_SUCURSAL = value
        End Set
    End Property
    Public Property _perfil_CARGO() As String
        Get
            Return perfil_CARGO
        End Get
        Set(ByVal value As String)
            perfil_CARGO = value
        End Set
    End Property
    Public Property _perfil_ATRIBUTO() As String
        Get
            Return perfil_ATRIBUTO
        End Get
        Set(ByVal value As String)
            perfil_ATRIBUTO = value
        End Set
    End Property
    Public Property _perfil_ENCONTRASENA() As String
        Get
            Return perfil_ENCONTRASENA
        End Get
        Set(ByVal value As String)
            perfil_ENCONTRASENA = value
        End Set
    End Property
    Public Property _perfil_ENSUPERCONTRASENA() As String
        Get
            Return perfil_ENSUPERCONTRASENA
        End Get
        Set(ByVal value As String)
            perfil_ENSUPERCONTRASENA = value
        End Set
    End Property
    Public Property _perfil_ENPERMISOS() As String
        Get
            Return perfil_ENPERMISOS
        End Get
        Set(ByVal value As String)
            perfil_ENPERMISOS = value
        End Set
    End Property

    Public Property _enpermisos() As String
        Get
            Return enpermisos
        End Get
        Set(ByVal value As String)
            enpermisos = value
        End Set
    End Property
    Public Property _idprestamo2() As Integer
        Get
            Return idprestamo2
        End Get
        Set(ByVal value As Integer)
            idprestamo2 = value
        End Set
    End Property
    Public Property _Presocios() As String
        Get
            Return Presocios
        End Get
        Set(ByVal value As String)
            Presocios = value
        End Set
    End Property

    Public Property _Condicional() As String
        Get
            Return Condicional
        End Get
        Set(ByVal value As String)
            Condicional = value
        End Set
    End Property
    Public Property _Condicional_R() As String
        Get
            Return Condicional_R
        End Get
        Set(ByVal value As String)
            Condicional_R = value
        End Set
    End Property
    Public Property _CCS_Perfil() As String
        Get
            Return CCI_Perfil
        End Get
        Set(ByVal value As String)
            CCI_Perfil = value
        End Set
    End Property

    Public Property _CCI_Perfil() As String
        Get
            Return CCI_Perfil
        End Get
        Set(ByVal value As String)
            CCI_Perfil = value
        End Set
    End Property


    Public Property _Riesgo_Perfil() As String
        Get
            Return Riesgo_Perfil
        End Get
        Set(ByVal value As String)
            Riesgo_Perfil = value
        End Set
    End Property
    Public Property _Agencia_Perfil() As String
        Get
            Return Agencia_Perfil
        End Get
        Set(ByVal value As String)
            Agencia_Perfil = value
        End Set
    End Property
    Public Property _Subgerente_Perfil() As String
        Get
            Return Subgerente_Perfil
        End Get
        Set(ByVal value As String)
            Subgerente_Perfil = value
        End Set
    End Property
    Public Property _Gerente_Perfil() As String
        Get
            Return Gerente_Perfil
        End Get
        Set(ByVal value As String)
            Gerente_Perfil = value
        End Set
    End Property

    Public Property _Puntajes_Validaciones() As String
        Get
            Return Puntajes_Validaciones
        End Get
        Set(ByVal value As String)
            Puntajes_Validaciones = value
        End Set
    End Property

    Public Property _Aprobacion() As String
        Get
            Return Aprobacion
        End Get
        Set(ByVal value As String)
            Aprobacion = value
        End Set
    End Property
    Public Property _Comentario_Gerencia() As String
        Get
            Return Comentario_Gerencia
        End Get
        Set(ByVal value As String)
            Comentario_Gerencia = value
        End Set
    End Property

    Public Property _Comentario_Subgerencia() As String
        Get
            Return Comentario_Subgerencia
        End Get
        Set(ByVal value As String)
            Comentario_Subgerencia = value
        End Set
    End Property


    Public Property _Comentario_Agencia() As String
        Get
            Return Comentario_Agencia
        End Get
        Set(ByVal value As String)
            Comentario_Agencia = value
        End Set
    End Property


    Public Property _Cuotas_prepago() As String
        Get
            Return Cuotas_prepago
        End Get
        Set(ByVal value As String)
            Cuotas_prepago = value
        End Set
    End Property

    Public Property _Monto_Capital() As String
        Get
            Return Monto_Capital
        End Get
        Set(ByVal value As String)
            Monto_Capital = value
        End Set
    End Property
    Public Property _Rut() As String
        Get
            Return Rut
        End Get
        Set(ByVal value As String)
            Rut = value
        End Set
    End Property

    Public Property _Nombre() As String
        Get
            Return Nombre
        End Get
        Set(ByVal value As String)
            Nombre = value
        End Set
    End Property

    Public Property _V_Puntaje() As Integer
        Get
            Return V_Puntaje
        End Get
        Set(ByVal value As Integer)
            V_Puntaje = value
        End Set
    End Property

    Public Property _V_Capacidad() As Integer
        Get
            Return V_Capacidad
        End Get
        Set(ByVal value As Integer)
            V_Capacidad = value
        End Set
    End Property

    Public Property _V_Comerciales() As Integer
        Get
            Return V_Comerciales
        End Get
        Set(ByVal value As Integer)
            V_Comerciales = value
        End Set
    End Property

    Public Property _V_Endeudamiento() As Integer
        Get
            Return V_Puntaje
        End Get
        Set(ByVal value As Integer)
            V_Puntaje = value
        End Set
    End Property

    Public Property _V_Antiguedad10() As Integer
        Get
            Return V_Antiguedad10
        End Get
        Set(ByVal value As Integer)
            V_Antiguedad10 = value
        End Set
    End Property

    Public Property _V_Antiguedad1() As Integer
        Get
            Return V_Antiguedad1
        End Get
        Set(ByVal value As Integer)
            V_Antiguedad1 = value
        End Set
    End Property

    Public Property _V_Moras() As Integer
        Get
            Return V_Moras
        End Get
        Set(ByVal value As Integer)
            V_Moras = value
        End Set
    End Property

    Public Property _V_Edad() As Integer
        Get
            Return V_Edad
        End Get
        Set(ByVal value As Integer)
            V_Edad = value
        End Set
    End Property


    Public Property _Aprobacion_Comision_Credito_Interno() As String
        Get
            Return Aprobacion_Comision_Credito_Interno
        End Get
        Set(ByVal value As String)
            Aprobacion_Comision_Credito_Interno = value
        End Set
    End Property
    Public Property _Aprobacion_Comision_Credito_Superior() As String
        Get
            Return Aprobacion_Comision_Credito_Superior
        End Get
        Set(ByVal value As String)
            Aprobacion_Comision_Credito_Superior = value
        End Set
    End Property
    Public Property _Atribucion() As String
        Get
            Return Atribucion
        End Get
        Set(ByVal value As String)
            Atribucion = value
        End Set
    End Property

    Public Property _id_solicitud() As String
        Get
            Return id_solicitud
        End Get
        Set(ByVal value As String)
            id_solicitud = value
        End Set

    End Property
    Public Property _Edad() As String
        Get
            Return Edad
        End Get
        Set(ByVal value As String)
            Edad = value
        End Set

    End Property

    Public Property _Anos_Contrato() As String
        Get
            Return Anos_Contrato
        End Get
        Set(ByVal value As String)
            Anos_Contrato = value
        End Set

    End Property

    Public Property _Anos_Antiguedad() As String
        Get
            Return Anos_Antiguedad
        End Get
        Set(ByVal value As String)
            Anos_Antiguedad = value
        End Set

    End Property


    Public Property _Estado() As String
        Get
            Return Estado
        End Get
        Set(ByVal value As String)
            Estado = value
        End Set

    End Property
    Public Property _Puntaje() As String
        Get
            Return Puntaje
        End Get
        Set(ByVal value As String)
            Puntaje = value
        End Set

    End Property


    Public Property _Validaciones() As String
        Get
            Return Validaciones
        End Get
        Set(ByVal value As String)
            Validaciones = value
        End Set

    End Property

    Public Property _Aprobacion_SubGerencia() As String
        Get
            Return Aprobacion_SubGerencia
        End Get
        Set(ByVal value As String)
            Aprobacion_SubGerencia = value
        End Set
    End Property
    Public Property _capacidad() As String
        Get
            Return capacidad
        End Get
        Set(ByVal value As String)
            capacidad = value
        End Set
    End Property


    Public Property _ncreditos() As String
        Get
            Return ncreditos
        End Get
        Set(ByVal value As String)
            ncreditos = value
        End Set
    End Property
    Public Property _producto() As String
        Get
            Return producto
        End Get
        Set(ByVal value As String)
            producto = value
        End Set
    End Property
    Public Property _fecha_solicitud() As String
        Get
            Return fecha_solicitud
        End Get
        Set(ByVal value As String)
            fecha_solicitud = value
        End Set
    End Property
    Public Property _Nrosocio() As String
        Get
            Return Nrosocio
        End Get
        Set(ByVal value As String)
            Nrosocio = value
        End Set
    End Property

    Public Property _fechaprimervencimiento() As String
        Get
            Return fechaprimervencimiento
        End Get
        Set(ByVal value As String)
            fechaprimervencimiento = value
        End Set
    End Property
    Public Property _dias_gracia() As String
        Get
            Return dias_gracia
        End Get
        Set(ByVal value As String)
            dias_gracia = value
        End Set
    End Property
    Public Property _tasa() As String
        Get
            Return tasa
        End Get
        Set(ByVal value As String)
            tasa = value
        End Set
    End Property
    Public Property _primera_cuota() As String
        Get
            Return primera_cuota
        End Get
        Set(ByVal value As String)
            primera_cuota = value
        End Set
    End Property
    Public Property _nrocuotas() As String
        Get
            Return nrocuotas
        End Get
        Set(ByVal value As String)
            nrocuotas = value
        End Set
    End Property
    Public Property _NroPrepagos() As String
        Get
            Return NroPrepagos
        End Get
        Set(ByVal value As String)
            NroPrepagos = value
        End Set
    End Property
    Public Property _capital() As String
        Get
            Return capital
        End Get
        Set(ByVal value As String)
            capital = value
        End Set
    End Property
    Public Property _prepago() As String
        Get
            Return prepago
        End Get
        Set(ByVal value As String)
            prepago = value
        End Set
    End Property
    Public Property _monto_solicitado() As String
        Get
            Return monto_solicitado
        End Get
        Set(ByVal value As String)
            monto_solicitado = value
        End Set
    End Property
    Public Property _objetivo() As String
        Get
            Return objetivo
        End Get
        Set(ByVal value As String)
            objetivo = value
        End Set
    End Property

    Public Property _EDeudadVencidas() As String
        Get
            Return EDeudadVencidas
        End Get
        Set(ByVal value As String)
            EDeudadVencidas = value
        End Set
    End Property


    Public Property _EdeudaComercial() As String
        Get
            Return EdeudaComercial
        End Get
        Set(ByVal value As String)
            EdeudaComercial = value
        End Set
    End Property

    Public Property _EdeudaConsumo() As String
        Get
            Return EdeudaConsumo
        End Get
        Set(ByVal value As String)
            EdeudaConsumo = value
        End Set
    End Property
    Public Property _EdeudaHipo() As String
        Get
            Return EdeudaHipo
        End Get
        Set(ByVal value As String)
            EdeudaHipo = value
        End Set
    End Property

    Public Property _Edeudafinanciera() As String
        Get
            Return Edeudafinanciera
        End Get
        Set(ByVal value As String)
            Edeudafinanciera = value
        End Set
    End Property

    Public Property _comportamientopago() As String
        Get
            Return comportamientopago
        End Get
        Set(ByVal value As String)
            comportamientopago = value
        End Set
    End Property
    Public Property _protestosmorocidades() As String
        Get
            Return protestosmorocidades
        End Get
        Set(ByVal value As String)
            protestosmorocidades = value
        End Set
    End Property
    Public Property _tiporenta() As String
        Get
            Return tiporenta
        End Get
        Set(ByVal value As String)
            tiporenta = value
        End Set
    End Property
    Public Property _forpago() As String
        Get
            Return forpago
        End Get
        Set(ByVal value As String)
            forpago = value
        End Set
    End Property

    Public Property _Activos() As String
        Get
            Return Activos
        End Get
        Set(ByVal value As String)
            Activos = value
        End Set
    End Property


    Public Property _ExternaAcreditado() As String
        Get
            Return ExternaAcreditado
        End Get
        Set(ByVal value As String)
            ExternaAcreditado = value
        End Set
    End Property


    Public Property _CargaFinanciera() As String
        Get
            Return CargaFinanciera
        End Get
        Set(ByVal value As String)
            CargaFinanciera = value
        End Set
    End Property



    Public Property _RLP() As String
        Get
            Return RLP
        End Get
        Set(ByVal value As String)
            RLP = value
        End Set
    End Property

    Public Property _IPagoMensual() As String
        Get
            Return IPagoMensual
        End Get
        Set(ByVal value As String)
            IPagoMensual = value
        End Set
    End Property

    Public Property _IDeudaIndirecta() As String
        Get
            Return IDeudaIndirecta
        End Get
        Set(ByVal value As String)
            IDeudaIndirecta = value
        End Set
    End Property


    Public Property _IdeudaComercial() As String
        Get
            Return IdeudaComercial
        End Get
        Set(ByVal value As String)
            IdeudaComercial = value
        End Set
    End Property


    Public Property _IdeudaConsumo() As String
        Get
            Return IdeudaConsumo
        End Get
        Set(ByVal value As String)
            IdeudaConsumo = value
        End Set
    End Property

    Public Property _Itotaldeuda() As String
        Get
            Return Itotaldeuda
        End Get
        Set(ByVal value As String)
            Itotaldeuda = value
        End Set
    End Property


    Public Property _ENumeroAcreedores() As String
        Get
            Return ENumeroAcreedores
        End Get
        Set(ByVal value As String)
            ENumeroAcreedores = value
        End Set
    End Property

    Public Property _ELineaCredito() As String
        Get
            Return ELineaCredito
        End Get
        Set(ByVal value As String)
            ELineaCredito = value
        End Set
    End Property


    Public Property _Aprobacion_Operaciones() As String
        Get
            Return Aprobacion_Operaciones
        End Get
        Set(ByVal value As String)
            Aprobacion_Operaciones = value
        End Set
    End Property

    Public Property _Aprobacion_Gerencia() As String
        Get
            Return Aprobacion_Gerencia
        End Get
        Set(ByVal value As String)
            Aprobacion_Gerencia = value
        End Set
    End Property

    Public Property _Comentario_Riesgo() As String
        Get
            Return Comentario_Riesgo
        End Get
        Set(ByVal value As String)
            Comentario_Riesgo = value
        End Set
    End Property
    Public Property _Comentario_Ejecutiva() As String
        Get
            Return Comentario_Ejecutiva
        End Get
        Set(ByVal value As String)
            Comentario_Ejecutiva = value
        End Set
    End Property
    Public Property _Sucursal() As String
        Get
            Return Sucursal
        End Get
        Set(ByVal value As String)
            Sucursal = value
        End Set
    End Property
    Public Property _Ejecutiva() As String
        Get
            Return Ejecutiva
        End Get
        Set(ByVal value As String)
            Ejecutiva = value
        End Set
    End Property




    Public Property _LVL() As String
        Get
            Return LVL
        End Get
        Set(ByVal value As String)
            LVL = value
        End Set
    End Property


    Public Property _RentaLiquidaDepurada() As String
        Get
            Return RentaLiquidaDepurada
        End Get
        Set(ByVal value As String)
            RentaLiquidaDepurada = value
        End Set
    End Property
    Public Property _Vehiculos() As String
        Get
            Return Vehiculos
        End Get
        Set(ByVal value As String)
            Vehiculos = value
        End Set
    End Property
    Public Property _Propiedades() As String
        Get
            Return Propiedades
        End Get
        Set(ByVal value As String)
            Propiedades = value
        End Set
    End Property



    Public Property _EPerido() As String
        Get
            Return EPerido
        End Get
        Set(ByVal value As String)
            EPerido = value
        End Set
    End Property
    Public Property _EDeudasVencidasIndirectas() As String
        Get
            Return EDeudasVencidasIndirectas
        End Get
        Set(ByVal value As String)
            EDeudasVencidasIndirectas = value
        End Set
    End Property














































    Public Property _Contraseña() As String
        Get
            Return Contraseña
        End Get
        Set(ByVal value As String)
            Contraseña = value
        End Set
    End Property
    Public Property _Perfil() As String
        Get
            Return Perfil
        End Get
        Set(ByVal value As String)
            Perfil = value
        End Set
    End Property

    Public Property _Version() As String
        Get
            Return Version
        End Get
        Set(ByVal value As String)
            Version = value
        End Set
    End Property


End Class
