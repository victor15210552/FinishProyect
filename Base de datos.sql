CREATE DATABASE `club_ninos_ninas` /*!40100 DEFAULT CHARACTER SET utf8 */;

CREATE TABLE `miembros` (
  `no_miembro` int(11) NOT NULL,
  `tipo` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`no_miembro`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `nino_autorizacion` (
  `no_miembro` int(11) NOT NULL,
  `autorzacion_medica` tinyint(4) DEFAULT NULL,
  `autorizacion_salida_solo` tinyint(4) DEFAULT NULL,
  `autorizacion_foto_video` tinyint(4) DEFAULT NULL,
  `enterado_camaras` tinyint(4) DEFAULT NULL,
  KEY `no_miembro` (`no_miembro`),
  CONSTRAINT `nino_autorizacion_ibfk_1` FOREIGN KEY (`no_miembro`) REFERENCES `miembros` (`no_miembro`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `nino_desarollo_humano` (
  `no_miembro` int(11) NOT NULL,
  `alegre` varchar(10) DEFAULT NULL,
  `amigable` varchar(10) DEFAULT NULL,
  `callado` varchar(10) DEFAULT NULL,
  `cooperador` varchar(10) DEFAULT NULL,
  `curioso` varchar(10) DEFAULT NULL,
  `comparte` varchar(10) DEFAULT NULL,
  `berrinches` varchar(10) DEFAULT NULL,
  `independiente` varchar(10) DEFAULT NULL,
  `imaginativo` varchar(10) DEFAULT NULL,
  `irritable` varchar(10) DEFAULT NULL,
  `miedo` varchar(10) DEFAULT NULL,
  `moja_cama` varchar(10) DEFAULT NULL,
  `tolerante` varchar(10) DEFAULT NULL,
  `compania_adulto` varchar(10) DEFAULT NULL,
  `responsable` varchar(10) DEFAULT NULL,
  `ordendo` varchar(10) DEFAULT NULL,
  `chupa_dedo` varchar(10) DEFAULT NULL,
  `sociable` varchar(10) DEFAULT NULL,
  `persistente` varchar(10) DEFAULT NULL,
  `timido` varchar(10) DEFAULT NULL,
  `hace_tarea` varchar(10) DEFAULT NULL,
  `hace_quehacer` varchar(10) DEFAULT NULL,
  `va_solo_bano` varchar(10) DEFAULT NULL,
  `terapia_previa` tinyint(4) DEFAULT NULL,
  `motivo_terapia` longtext,
  `presenta_tics` mediumtext,
  `diversiones` mediumtext,
  `situaciones_incomodas` mediumtext,
  `juegos_preferidos` mediumtext,
  `tipo_castigo` mediumtext,
  `obediente` tinyint(4) DEFAULT NULL,
  `juega_peligroso` tinyint(4) DEFAULT NULL,
  `reaccion_obscuridad` mediumtext,
  `fobias_miedos` mediumtext,
  `duerme_solo` tinyint(4) DEFAULT NULL,
  `duerme_con_padres` tinyint(4) DEFAULT NULL,
  `duerme_con_hermanos` tinyint(4) DEFAULT NULL,
  `duerme_otros` tinyint(4) DEFAULT NULL,
  `siseta_durante_dia` tinyint(4) DEFAULT NULL,
  `horas_siesta` float DEFAULT NULL,
  `horas_sueno` float DEFAULT NULL,
  `transtorno_sueno` tinyint(4) DEFAULT NULL,
  `pesadilla` tinyint(4) DEFAULT NULL,
  `insomnio` tinyint(4) DEFAULT NULL,
  `rechina_dientes` tinyint(4) DEFAULT NULL,
  `suena_tranquilo` tinyint(4) DEFAULT NULL,
  `habla_dormido` tinyint(4) DEFAULT NULL,
  `duerme_poco` tinyint(4) DEFAULT NULL,
  `otro_transtorno_sueno` varchar(45) DEFAULT NULL,
  `horas_television` int(11) DEFAULT NULL,
  `minutos_television` int(11) DEFAULT NULL,
  `television_solo` tinyint(4) DEFAULT NULL,
  `television_compania` tinyint(4) DEFAULT NULL,
  `hora_aparatos_electronicos` int(11) DEFAULT NULL,
  `minutos_aparatos_electronicos` int(11) DEFAULT NULL,
  `ve_caricaturas` tinyint(4) DEFAULT NULL,
  `ve_telenovelas` tinyint(4) DEFAULT NULL,
  `ve_documentales` tinyint(4) DEFAULT NULL,
  `ve_series_policiacas` tinyint(4) DEFAULT NULL,
  `ve_concursos` tinyint(4) DEFAULT NULL,
  `ve_videos` tinyint(4) DEFAULT NULL,
  `ve_series_terror` tinyint(4) DEFAULT NULL,
  `visitas_familiares` tinyint(4) DEFAULT NULL,
  `cine` tinyint(4) DEFAULT NULL,
  `parque_diversines` tinyint(4) DEFAULT NULL,
  `conciertos` tinyint(4) DEFAULT NULL,
  `salida_usa` tinyint(4) DEFAULT NULL,
  `salida_deportiva` tinyint(4) DEFAULT NULL,
  `redes_sociales` tinyint(4) DEFAULT NULL,
  `otra_actividad` varchar(45) DEFAULT NULL,
  `come_solo` tinyint(4) DEFAULT NULL,
  `bano_solo` tinyint(4) DEFAULT NULL,
  `peina_solo` tinyint(4) DEFAULT NULL,
  `lava_dientes` tinyint(4) DEFAULT NULL,
  `viste_solo` tinyint(4) DEFAULT NULL,
  `lava_manos` tinyint(4) DEFAULT NULL,
  `otro_programa` varchar(45) DEFAULT NULL,
  KEY `no_miembro` (`no_miembro`),
  CONSTRAINT `nino_desarollo_humano_ibfk_1` FOREIGN KEY (`no_miembro`) REFERENCES `miembros` (`no_miembro`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `nino_familia` (
  `no_miembro` int(11) NOT NULL,
  `tutores_situacion` varchar(40) DEFAULT NULL,
  `nombre_padre` varchar(70) DEFAULT NULL,
  `apellido_padre` varchar(70) DEFAULT NULL,
  `fecha_nacim_padre` date DEFAULT NULL,
  `lugar_nacim_padre` varchar(70) DEFAULT NULL,
  `nacionalidad_padre` varchar(45) DEFAULT NULL,
  `Escolaridad_padre` varchar(45) DEFAULT NULL,
  `Ocupacion_padre` varchar(45) DEFAULT NULL,
  `lugar_trabajo_padre` varchar(45) DEFAULT NULL,
  `tel_particular_padre` varchar(20) DEFAULT NULL,
  `tel_trabajo_padre` varchar(20) DEFAULT NULL,
  `celular_padre` varchar(20) DEFAULT NULL,
  `email_padre` varchar(50) DEFAULT NULL,
  `nombre_madre` varchar(70) DEFAULT NULL,
  `apellido_madre` varchar(70) DEFAULT NULL,
  `fecha_nacim_madre` date DEFAULT NULL,
  `lugar_nacim_madre` varchar(70) DEFAULT NULL,
  `nacionalidad_madre` varchar(45) DEFAULT NULL,
  `Escolaridad_madre` varchar(45) DEFAULT NULL,
  `Ocupacion_madre` varchar(45) DEFAULT NULL,
  `lugar_trabajo_madre` varchar(45) DEFAULT NULL,
  `tel_particular_madre` varchar(20) DEFAULT NULL,
  `tel_trabajo_madre` varchar(20) DEFAULT NULL,
  `celular_madre` varchar(20) DEFAULT NULL,
  `email_madre` varchar(50) DEFAULT NULL,
  `restriccion_legal` tinyint(1) DEFAULT NULL,
  `tutor_autorizado` varchar(150) DEFAULT NULL,
  `desintegracion_familiar` tinyint(1) DEFAULT NULL,
  `fallecimientos` tinyint(1) DEFAULT NULL,
  `nacimientos` tinyint(1) DEFAULT NULL,
  `situacion_economica` tinyint(1) DEFAULT NULL,
  `cambios_rutina` tinyint(1) DEFAULT NULL,
  `disciplica` varchar(10) DEFAULT NULL,
  `juegos` varchar(10) DEFAULT NULL,
  `al_acostarse` varchar(10) DEFAULT NULL,
  `hora_alimentos` varchar(10) DEFAULT NULL,
  `al_levantarse` varchar(10) DEFAULT NULL,
  `hora_bano` varchar(10) DEFAULT NULL,
  KEY `no_miembro` (`no_miembro`),
  CONSTRAINT `nino_familia_ibfk_1` FOREIGN KEY (`no_miembro`) REFERENCES `miembros` (`no_miembro`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `nino_medicos` (
  `no_miembro` int(11) NOT NULL,
  `alergias` varchar(70) DEFAULT NULL,
  `medicamentos` varchar(70) DEFAULT NULL,
  `cuidado_especial` varchar(70) DEFAULT NULL,
  `rebeola` tinyint(1) DEFAULT NULL,
  `varicela` tinyint(1) DEFAULT NULL,
  `escarlatina` tinyint(1) DEFAULT NULL,
  `hepatitis` tinyint(1) DEFAULT NULL,
  `influenza` tinyint(1) DEFAULT NULL,
  `tifoidea` tinyint(1) DEFAULT NULL,
  `paperas` tinyint(1) DEFAULT NULL,
  `tosferina` tinyint(1) DEFAULT NULL,
  `otra_enfermedad` varchar(50) DEFAULT NULL,
  `ataques_epilepticos` varchar(50) DEFAULT NULL,
  `enfermedad_cronica` varchar(50) DEFAULT NULL,
  `accidentes_graves` varchar(50) DEFAULT NULL,
  `ha_sido_operado` tinyint(1) DEFAULT NULL,
  `tipo-operacion` varchar(50) DEFAULT NULL,
  `cantidad_operaciones` int(11) DEFAULT NULL,
  `fecha_operacion` date DEFAULT NULL,
  `piojos_liendres` tinyint(1) DEFAULT NULL,
  `frec_piojos_liendres` varchar(50) DEFAULT NULL,
  `problema_habla` tinyint(1) DEFAULT NULL,
  `problema_vista` tinyint(1) DEFAULT NULL,
  `problema_oido` tinyint(1) DEFAULT NULL,
  `problema_tono_muscular` tinyint(1) DEFAULT NULL,
  `otro_problema` varchar(50) DEFAULT NULL,
  `aparato_dental` tinyint(1) DEFAULT NULL,
  `aparato_anteojos` tinyint(1) DEFAULT NULL,
  `aparato_auditivo` tinyint(1) DEFAULT NULL,
  `aparato_ortopedico` tinyint(1) DEFAULT NULL,
  `otro_aparato` varchar(50) DEFAULT NULL,
  KEY `no_miembro` (`no_miembro`),
  CONSTRAINT `nino_medicos_ibfk_1` FOREIGN KEY (`no_miembro`) REFERENCES `miembros` (`no_miembro`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `ninos_baja` (
  `no_miembro` int(11) NOT NULL,
  `motivo` varchar(300) DEFAULT NULL,
  `fecha_baja` date DEFAULT NULL,
  KEY `no_miembro` (`no_miembro`),
  CONSTRAINT `ninos_baja_ibfk_1` FOREIGN KEY (`no_miembro`) REFERENCES `miembros` (`no_miembro`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `ninos_datos` (
  `no_miembro` int(11) NOT NULL,
  `nombres` varchar(70) NOT NULL,
  `ap_paterno` varchar(45) DEFAULT NULL,
  `ap_materno` varchar(45) DEFAULT NULL,
  `fecha_nac` date DEFAULT NULL,
  `lugar_nac` varchar(100) DEFAULT NULL,
  `nacionalidad` varchar(30) DEFAULT NULL,
  `sexo` varchar(20) DEFAULT NULL,
  `vive_con` varchar(80) DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `dom_calle` varchar(100) DEFAULT NULL,
  `dom_numero` varchar(15) DEFAULT NULL,
  `dom_colonia` varchar(70) DEFAULT NULL,
  `dom_codpost` varchar(15) DEFAULT NULL,
  `dom_delegacion` varchar(120) DEFAULT NULL,
  `dom_municipio` varchar(100) DEFAULT NULL,
  `escuela` varchar(100) DEFAULT NULL,
  `esc_turno` varchar(45) DEFAULT NULL,
  `recoge1_nino` varchar(100) DEFAULT NULL,
  `parent_recoge1` varchar(30) DEFAULT NULL,
  `recoge2_nino` varchar(100) DEFAULT NULL,
  `parent_recoge2` varchar(30) DEFAULT NULL,
  `recoge3_nino` varchar(100) DEFAULT NULL,
  `parent_recoge3` varchar(30) DEFAULT NULL,
  `aviso_emergencia1` varchar(250) DEFAULT NULL,
  `aviso_emergencia2` varchar(250) DEFAULT NULL,
  `aviso_emergencia3` varchar(250) DEFAULT NULL,
  `fecha_inscripcion` date DEFAULT NULL,
  `estado` varchar(20) DEFAULT NULL,
  `imss` tinyint(4) DEFAULT NULL,
  `isste` tinyint(4) DEFAULT NULL,
  `isstecali` tinyint(4) DEFAULT NULL,
  `seguro_popular` tinyint(4) DEFAULT NULL,
  `particular` tinyint(4) DEFAULT NULL,
  KEY `no_miembro` (`no_miembro`),
  CONSTRAINT `ninos_datos_ibfk_1` FOREIGN KEY (`no_miembro`) REFERENCES `miembros` (`no_miembro`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `ninos_socioeconomico` (
  `no_miembro` int(11) NOT NULL,
  `transporte` varchar(50) DEFAULT NULL,
  `vivienda` varchar(50) DEFAULT NULL,
  `cocina` int(11) DEFAULT NULL,
  `comedor` int(11) DEFAULT NULL,
  `sala` int(11) DEFAULT NULL,
  `bano` int(11) DEFAULT NULL,
  `dormitorio` int(11) DEFAULT NULL,
  `lavado` int(11) DEFAULT NULL,
  `jardin` int(11) DEFAULT NULL,
  `patio` int(11) DEFAULT NULL,
  `terraza` int(11) DEFAULT NULL,
  `alberca` int(11) DEFAULT NULL,
  `estacionamiento` int(11) DEFAULT NULL,
  `tipo_vivienda` varchar(20) DEFAULT NULL,
  `techo_vivienda` varchar(20) DEFAULT NULL,
  `piso_vivienda` varchar(20) DEFAULT NULL,
  `serv_luz` tinyint(4) DEFAULT NULL,
  `serv_agua` tinyint(4) DEFAULT NULL,
  `serv_drenaje` tinyint(4) DEFAULT NULL,
  `serv_gas` tinyint(4) DEFAULT NULL,
  `serv_rec_basura` tinyint(4) DEFAULT NULL,
  `serv_alumbrado_publico` tinyint(4) DEFAULT NULL,
  `serv_telefono` tinyint(4) DEFAULT NULL,
  `serv_tv` tinyint(4) DEFAULT NULL,
  `serv_area_recreativa` tinyint(4) DEFAULT NULL,
  `gasto_vivienda` float DEFAULT NULL,
  `gasto_luz` float DEFAULT NULL,
  `gasto_agua` float DEFAULT NULL,
  `gasto_rec_basura` float DEFAULT NULL,
  `gasto_telefono` float DEFAULT NULL,
  `gasto_tv` float DEFAULT NULL,
  `gasto_vehiculos` float DEFAULT NULL,
  `gasto_despensa` float DEFAULT NULL,
  `gasto_deudas` float DEFAULT NULL,
  `gasto_entretenimiento` float DEFAULT NULL,
  `gasto_mensual` float DEFAULT NULL,
  `tipo_familia` varchar(45) DEFAULT NULL,
  `nivel_ingreso_mensual` varchar(100) DEFAULT NULL,
  KEY `no_miembro` (`no_miembro`),
  CONSTRAINT `ninos_socioeconomico_ibfk_1` FOREIGN KEY (`no_miembro`) REFERENCES `miembros` (`no_miembro`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `staff` (
  `no_miembro` int(11) NOT NULL,
  `nombre` varchar(45) DEFAULT NULL,
  `ap_paterno` varchar(45) DEFAULT NULL,
  `ap_materno` varchar(45) DEFAULT NULL,
  `carrera` varchar(100) DEFAULT NULL,
  `puesto` varchar(100) DEFAULT NULL,
  `edocivil` varchar(30) DEFAULT NULL,
  `tel1` varchar(45) DEFAULT NULL,
  `tel2` varchar(45) DEFAULT NULL,
  `fecha_naci` date DEFAULT NULL,
  `nacionalidad` varchar(45) DEFAULT NULL,
  `estado` tinyint(4) DEFAULT NULL,
  `voluntario` tinyint(4) DEFAULT NULL,
  `fecha_ingreso` tinyint(4) DEFAULT NULL,
  `direccion` varchar(100) DEFAULT NULL,
  `entradares` tinyint(4) DEFAULT NULL,
  `razon_entrada` varchar(45) DEFAULT NULL,
  KEY `staff_fbk1_idx` (`no_miembro`),
  CONSTRAINT `staff_fbk1` FOREIGN KEY (`no_miembro`) REFERENCES `miembros` (`no_miembro`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `staff_baja` (
  `no_miembro` int(11) NOT NULL,
  `motivo_baja` varchar(300) DEFAULT NULL,
  `fecha_baja` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `usuarios`(

	idUsuario int,
	nombre varchar(20),
	password varchar(20),
  
	PRIMARY KEY (`idUsuario`)
    
)
