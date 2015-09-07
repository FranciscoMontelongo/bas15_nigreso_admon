--
	USE CONAPD15_BASICA_PROM_DIRECTORES
	select * from tbc_CND_Usuarios U INNER JOIN tbr_CND_UsuariosPerfil UP
	ON U.Usuario = UP.Usuario
	AND UP.ClavePerfil = 'A'
	and U.ClaveEntidad = 27


	sp_helptext spt_Asignacion_UPD_ConfiguracionFechas
	
	select * from tbd_CND_AsignacionConfiguracionFechas       
	sp_helptext spt_Asignacion_UPD_ConfiguracionFechas
	
	select * from tbd_CND_AsignacionConfiguracionFechas       
	
	sp_helptext spt_SEL_ObtieneLogin
	SELECT * FROM dbo.TBC_ASIGNACION_USUARIOS    
	
	spt_SEL_Todos_SISTEMAS_ENTIDAD_2
	
	sp_helptext spt_Asignacion_USC_ConfiguracionFechas -- Este store debe cambiar por el "spt_Asignacion_USC_ConfiguracionFechas2"
	sp_helptext usc_TS_ASIGNACIONMenu


	
	-- 1) (OK) Se cambia la carga de Menu
	--		Id_Menu	Id_Padre	Descripcion				URL										Orden	Visibilidad
	--		6		5			Periodo de Asignación	Configuracion/FechaContratacion.aspx	1		0

			USE CONAPD15_BASICA_PROM_DIRECTORES
			USE CONAPD15_BASICA_PROM_ATP					
			USE CONAPD15_BASICA_PROM_SUPERVISORES

			SELECT * FROM CONAPD15_BASICA_PROM_DIRECTORES.dbo.TBC_ASIGNACION_Permisos
			SELECT * FROM CONAPD15_BASICA_PROM_ATP.dbo.TBC_ASIGNACION_Permisos
			SELECT * FROM CONAPD15_BASICA_PROM_SUPERVISORES.dbo.TBC_ASIGNACION_Permisos
			--		
			SELECT * FROM CONAPD15_BASICA_PROM_DIRECTORES.dbo.TBC_ASIGNACION_MENU
			SELECT * FROM CONAPD15_BASICA_PROM_ATP.dbo.TBC_ASIGNACION_MENU
			SELECT * FROM CONAPD15_BASICA_PROM_SUPERVISORES.dbo.TBC_ASIGNACION_MENU
			--			
			UPDATE CONAPD15_BASICA_PROM_ATP.dbo.TBC_ASIGNACION_MENU SET URL = 'Configuracion/AsignacionFechasXEntidad.aspx' WHERE Id_Menu = 6
			UPDATE CONAPD15_BASICA_PROM_SUPERVISORES.dbo.TBC_ASIGNACION_MENU SET URL = 'Configuracion/AsignacionFechasXEntidad.aspx' WHERE Id_Menu = 6
						
	-- 2) (OK) Sedio de alta este SP [spt_AsignacionFechasXEntidad]
			USE CONAPD15_BASICA_PROM_DIRECTORES
			USE CONAPD15_BASICA_PROM_ATP					
			USE CONAPD15_BASICA_PROM_SUPERVISORES

			sp_helptext spt_AsignacionFechasXEntidad
			SELECT * FROM CONAPD15_BASICA_PROM_DIRECTORES.dbo.TBC_ASIGNACION_MENU
			SELECT * FROM CONAPD15_BASICA_PROM_ATP.dbo.TBC_ASIGNACION_MENU
			SELECT * FROM CONAPD15_BASICA_PROM_SUPERVISORES.dbo.TBC_ASIGNACION_MENU
	
	-- 3) (OK) Se agregó la imagen "editar.png"
	
	-- 4) (OK) Se agrego este SP  spt_ActualizaFechasXEntidad
			USE CONAPD15_BASICA_PROM_DIRECTORES
			USE CONAPD15_BASICA_PROM_ATP					
			USE CONAPD15_BASICA_PROM_SUPERVISORES
			
			sp_helptext spt_ActualizaFechasXEntidad
	
	-- 5) (NO) Esto tambien debe cargarse
		--<script type="text/javascript">
		--	$(document).ready(function () {
		--		$('a#popup').live('click', function (e) {
		--			var page = $(this).attr("href")
		--			var $dialog = $('<div></div>')
		--			.html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
		--			.dialog({
		--				autoOpen: false,
		--				modal: true,
		--				height: 400,
		--				width: 600,
		--				title: "",
		--				buttons: {
		--					"Cerrar": function () { $dialog.dialog('close'); }
		--				},
		--				close: function (event, ui) {
		--					__doPostBack('<%= btnRefresh.ClientID %>', '');
		--				}
		--			});
		--			$dialog.dialog('open');
		--			e.preventDefault();
		--		});
		--	});
	    
		--</script>
	-- 6) (OK) Se limpia y se carga la tabla tbd_CND_AsignacionConfiguracionFechas
	
		--USE CONAPD15_BASICA_PROM_DIRECTORES
		--USE CONAPD15_BASICA_PROM_ATP					
		--USE CONAPD15_BASICA_PROM_SUPERVISORES

			select * from CONAPD15_BASICA_PROM_DIRECTORES.dbo.tbd_CND_AsignacionConfiguracionFechas	
			select * from CONAPD15_BASICA_PROM_ATP.dbo.tbd_CND_AsignacionConfiguracionFechas	
			select * from CONAPD15_BASICA_PROM_SUPERVISORES.dbo.tbd_CND_AsignacionConfiguracionFechas	

			DELETE from tbd_CND_AsignacionConfiguracionFechas
		

		select * from tbd_CND_AsignacionConfiguracionFechas	
		DELETE from tbd_CND_AsignacionConfiguracionFechas

			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (1,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (2,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (3,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (4,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (5,'2015-09-15','2015-12-15',0)
			--
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (6,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (7,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (8,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (9,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (10,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (11,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (12,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (13,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (14,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (15,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (16,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (17,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (18,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (19,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (20,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (21,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (22,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (23,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (24,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (25,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (26,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (27,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (28,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (29,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (30,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (31,'2015-09-15','2015-12-15',0)
			INSERT INTO tbd_CND_AsignacionConfiguracionFechas	 (ClaveEntidad, FechaInicioAsignacion, FechaFinalAsignacion, ClaveSubsistema) VALUES (32,'2015-09-15','2015-12-15',0)

	-- 7. (OK) Se agregó este SP "spt_Asignacion_SEL_ConfiguracionFechas_PorEntidad"
		USE CONAPD15_BASICA
			sp_HelpText spt_Asignacion_SEL_ConfiguracionFechas_PorEntidad

		USE CONAPD15_BASICA_PROM_DIRECTORES
			sp_HelpText spt_Asignacion_SEL_ConfiguracionFechas_PorEntidad
		USE CONAPD15_BASICA_PROM_ATP
			sp_HelpText spt_Asignacion_SEL_ConfiguracionFechas_PorEntidad
		USE CONAPD15_BASICA_PROM_SUPERVISORES
			sp_HelpText spt_Asignacion_SEL_ConfiguracionFechas_PorEntidad

	-- 8. () 

    //Rem Montel 2015/08/19 Aqui debe entrar la Validación de Fechas de Asignacion...
    Negocio.Otros _nCargarDatos = new Negocio.Otros();
    if (Session["Perfil"].ToString() == "A")
    {
		_nCargarDatos.Proc = Negocio.Otros.Procedimientos.spt_Asignacion_SEL_ConfiguracionFechas_PorEntidad;
		_nCargarDatos.Busqueda();
        DateTime miFecha = DateTime.Today;
        DateTime miFechaIni = Convert.ToDateTime(_nCargarDatos.datos.Tables[0].Rows[0][2]);
        DateTime miFechaFin = Convert.ToDateTime(_nCargarDatos.datos.Tables[0].Rows[0][3]);
        if ((miFecha > Convert.ToDateTime(_nCargarDatos.datos.Tables[0].Rows[0][2])) && (miFecha < Convert.ToDateTime(_nCargarDatos.datos.Tables[0].Rows[0][3])))
        {
            // OK
        }
        else
        {
            String miPar = "false";
            Session["PasoFechas"] = miPar;
            Response.Redirect("~/Tablero/Resumen.aspx");
        }
    }
    //Rem Montel 
    
        public void mensaje(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ScriptRep1", String.Format("<script language='javascript'>javascript:alert('{0}');</script>", mensaje), false);
        }
    
		




	-- END



-- ORI
SELECT * FROM [dbo].[tbc_CND_Turno]
SELECT * FROM tbc_CND_VigenciaAdscripcion
SELECT * FROM tbc_CND_TipoVacante
SELECT * FROM tbc_CND_TipoNombramiento
SELECT * FROM tbc_CND_TipoCategoria
SELECT * FROM tbc_CND_DenominacionPlaza
SELECT * FROM tbc_CND_AntecedentesFuncion

SELECT * FROM tbd_CND_AsignacionDetalle
SELECT * FROM tbd_CND_AsignacionRegistroAntecedentes
SELECT * FROM tbc_CND_DenominacionPlaza_TipoCategoria
SELECT * FROM tbd_CND_Docentes_Nuevos

-- FIN ORI	


USE CONAPD15_BASICA_PROM_DIRECTORES

SELECT * FROM tbc_CND_Turno order by ClaveDeTurno
SELECT * FROM tbc_CND_VigenciaAdscripcion
SELECT * FROM tbc_CND_TipoVacante
SELECT * FROM tbc_CND_TipoNombramiento
SELECT * FROM tbc_CND_TipoCategoria

SELECT * FROM tbd_CND_AsignacionDetalle
SELECT * FROM tbc_CND_VigenciaAdscripcion
SELECT * FROM tbc_CND_TipoVacante
SELECT * FROM tbd_CND_AsignacionRegistroAntecedentes
SELECT * FROM tbc_CND_DenominacionPlaza
SELECT * FROM tbc_CND_DenominacionPlaza_TipoCategoria
SELECT * FROM tbd_CND_Docentes_Nuevos
SELECT * FROM tbc_CND_AntecedentesFuncion	
