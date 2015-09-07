using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Datos;

namespace Negocio
{
    public class AsignacionListas : General
    {
        private Procedimientos _Proc;
        public Procedimientos Proc { get { return _Proc; } set { _Proc = value; StoreProcedure = _Proc.ToString(); } }

        private AsignacionFiltroArg _Filtros;
        public AsignacionFiltroArg Filtros { get { return _Filtros; } set { _Filtros = value; } }
        private AsignacionArg _Asignacion;
        public AsignacionArg Asignacion { get { return _Asignacion; } set { _Asignacion = value; } }

        public AsignacionListas()
        {
            _Filtros = new AsignacionFiltroArg();
            _Asignacion = new AsignacionArg();
        }

        public override void LlenaParametros()
        {
            switch (Proc)
            {
                case Procedimientos.spt_SEL_AsignacionPorEstatus:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad_Federativa", Value = Filtros.Entidad_Federativa });
                    _lparam.Add(new DataParam { Name = "@Funcion", Value = Filtros.Funcion });
                    _lparam.Add(new DataParam { Name = "@Tipo_Evaluacion", Value = Filtros.Tipo_Evaluacion });
                    _lparam.Add(new DataParam { Name = "@Servicio", Value = Filtros.Servicio });
                    _lparam.Add(new DataParam { Name = "@Tipo_Sostenimiento", Value = Filtros.Tipo_Sostenimiento });
                    _lparam.Add(new DataParam { Name = "@ClaveEstatusAsignacion", Value = Filtros.ClaveEstatusAsignacion });
                    break;
                case Procedimientos.spt_SEL_DocenteResultado:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@id_Resultados", Value = Filtros.id_Resultados });
                    break;
                case Procedimientos.spt_SEL_DocenteAsignaciones:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@id_Resultados", Value = Filtros.id_Resultados });
                    break;
                case Procedimientos.spt_SEL_DocenteAsignacion:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@ID_AsignacionDetalle", Value = Filtros.ID_AsignacionDetalle });
                    break;
                case Procedimientos.spt_INS_AsignacionDetalle:
                    _lparam = new List<DataParam>();

                    _lparam.Add(new DataParam { Name = "@id_Resultados", Value = Asignacion.id_Resultados });
                    _lparam.Add(new DataParam { Name = "@FolioFederal", Value = Asignacion.FolioFederal });
                    _lparam.Add(new DataParam { Name = "@CURP", Value = Asignacion.CURP });
                    _lparam.Add(new DataParam { Name = "@CCT", Value = Asignacion.CCT });
                    _lparam.Add(new DataParam { Name = "@NombreCCT", Value = Asignacion.NombreCCT });
                    _lparam.Add(new DataParam { Name = "@ClaveDeTurno", Value = Asignacion.ClaveDeTurno });
                    _lparam.Add(new DataParam { Name = "@ID_VigenciaAdscripcion", Value = Asignacion.ID_VigenciaAdscripcion });
                    _lparam.Add(new DataParam { Name = "@Fecha_Inicio", Value = Asignacion.Fecha_Inicio });
                    _lparam.Add(new DataParam { Name = "@Fecha_Fin", Value = Asignacion.Fecha_Fin });
                    _lparam.Add(new DataParam { Name = "@ID_TipoVacante", Value = Asignacion.ID_TipoVacante });
                    _lparam.Add(new DataParam { Name = "@ID_TipoNombramiento", Value = Asignacion.ID_TipoNombramiento });
                    _lparam.Add(new DataParam { Name = "@ID_TipoCategoria", Value = Asignacion.ID_TipoCategoria });
                    _lparam.Add(new DataParam { Name = "@Funcion", Value = Asignacion.Funcion });
                    _lparam.Add(new DataParam { Name = "@TipoEvaluacion", Value = Asignacion.TipoEvaluacion });
                    _lparam.Add(new DataParam { Name = "@ClaveEntidad", Value = Asignacion.ClaveEntidad });
                    _lparam.Add(new DataParam { Name = "@TipoSostenimiento", Value = Asignacion.TipoSostenimiento });
                    _lparam.Add(new DataParam { Name = "@ClavePresupuestal", Value = Asignacion.ClavePresupuestal });
                    _lparam.Add(new DataParam { Name = "@FechaAsignacion", Value = Asignacion.FechaAsignacion });
                    _lparam.Add(new DataParam { Name = "@ClaveEntidad_OrigenDocente", Value = Asignacion.ClaveEntidad_OrigenDocente });
                    _lparam.Add(new DataParam { Name = "@AproboEvaluacionInduccion", Value = Asignacion.AproboEvaluacionInduccion });
                    _lparam.Add(new DataParam { Name = "@UsuarioRegistro", Value = Asignacion.UsuarioRegistro });
                    _lparam.Add(new DataParam { Name = "@ClaveEstatusAsignacion", Value = Asignacion.ClaveEstatusAsignacion });
                    _lparam.Add(new DataParam { Name = "@ID_MotivoRechazo", Value = Asignacion.ID_MotivoRechazo });
                    _lparam.Add(new DataParam { Name = "@Servicio", Value = Asignacion.Servicio });
                    _lparam.Add(new DataParam { Name = "@ID_DenominacionPlaza", Value = Asignacion.ID_DenominacionPlaza });
                    _lparam.Add(new DataParam { Name = "@NumHoras", Value = Asignacion.NumHoras });
                    _lparam.Add(new DataParam { Name = "@ID_TipoPlaza", Value = Asignacion.ID_TipoPlaza });
                    
                    break;
                case Procedimientos.spt_UPD_AsignacionDetalle:
                    _lparam = new List<DataParam>();

                    _lparam.Add(new DataParam { Name = "@ID_AsignacionDetalle", Value = Asignacion.ID_AsignacionDetalle });
                    _lparam.Add(new DataParam { Name = "@id_Resultados", Value = Asignacion.id_Resultados });
                    _lparam.Add(new DataParam { Name = "@FolioFederal", Value = Asignacion.FolioFederal });
                    _lparam.Add(new DataParam { Name = "@CURP", Value = Asignacion.CURP });
                    _lparam.Add(new DataParam { Name = "@CCT", Value = Asignacion.CCT });
                    _lparam.Add(new DataParam { Name = "@NombreCCT", Value = Asignacion.NombreCCT });
                    _lparam.Add(new DataParam { Name = "@ClaveDeTurno", Value = Asignacion.ClaveDeTurno });
                    _lparam.Add(new DataParam { Name = "@ID_VigenciaAdscripcion", Value = Asignacion.ID_VigenciaAdscripcion });
                    _lparam.Add(new DataParam { Name = "@Fecha_Inicio", Value = Asignacion.Fecha_Inicio });
                    _lparam.Add(new DataParam { Name = "@Fecha_Fin", Value = Asignacion.Fecha_Fin });
                    _lparam.Add(new DataParam { Name = "@ID_TipoVacante", Value = Asignacion.ID_TipoVacante });
                    _lparam.Add(new DataParam { Name = "@ID_TipoNombramiento", Value = Asignacion.ID_TipoNombramiento });
                    _lparam.Add(new DataParam { Name = "@ID_TipoCategoria", Value = Asignacion.ID_TipoCategoria });
                    _lparam.Add(new DataParam { Name = "@Funcion", Value = Asignacion.Funcion });
                    _lparam.Add(new DataParam { Name = "@TipoEvaluacion", Value = Asignacion.TipoEvaluacion });
                    _lparam.Add(new DataParam { Name = "@ClaveEntidad", Value = Asignacion.ClaveEntidad });
                    _lparam.Add(new DataParam { Name = "@TipoSostenimiento", Value = Asignacion.TipoSostenimiento });
                    _lparam.Add(new DataParam { Name = "@ClavePresupuestal", Value = Asignacion.ClavePresupuestal });
                    _lparam.Add(new DataParam { Name = "@FechaAsignacion", Value = Asignacion.FechaAsignacion });
                    _lparam.Add(new DataParam { Name = "@ClaveEntidad_OrigenDocente", Value = Asignacion.ClaveEntidad_OrigenDocente });
                    _lparam.Add(new DataParam { Name = "@AproboEvaluacionInduccion", Value = Asignacion.AproboEvaluacionInduccion });
                    _lparam.Add(new DataParam { Name = "@UsuarioRegistro", Value = Asignacion.UsuarioRegistro });
                    _lparam.Add(new DataParam { Name = "@ClaveEstatusAsignacion", Value = Asignacion.ClaveEstatusAsignacion });
                    _lparam.Add(new DataParam { Name = "@ID_MotivoRechazo", Value = Asignacion.ID_MotivoRechazo });
                    _lparam.Add(new DataParam { Name = "@Servicio", Value = Asignacion.Servicio });
                    _lparam.Add(new DataParam { Name = "@ID_DenominacionPlaza", Value = Asignacion.ID_DenominacionPlaza });
                    _lparam.Add(new DataParam { Name = "@NumHoras", Value = Asignacion.NumHoras });
                    _lparam.Add(new DataParam { Name = "@ID_TipoPlaza", Value = Asignacion.ID_TipoPlaza });
                    break;
            }
        }

        public enum Procedimientos
        {
            spt_SEL_AsignacionPorEstatus,
            spt_SEL_DocenteResultado,
            spt_SEL_DocenteAsignacion,
            spt_SEL_DocenteAsignaciones,
            spt_INS_AsignacionDetalle,
            spt_UPD_AsignacionDetalle
        }
    }

    public class AsignacionFiltroArg
    {
        public string Entidad_Federativa { get; set; }
        public string Funcion { get; set; }
        public string Tipo_Evaluacion { get; set; }
        public string Servicio { get; set; }
        public string Tipo_Sostenimiento { get; set; }
        public int ClaveEstatusAsignacion { get; set; }

        public int id_Resultados { get; set; }
        public int ID_AsignacionDetalle { get; set; }
    }

    public class AsignacionArg
    {
        public int? ID_AsignacionDetalle { get; set; }
        public int? id_Resultados { get; set; }
        public string FolioFederal { get; set; }
        public string CURP { get; set; }
	    public string CCT { get; set; }
	    public string NombreCCT { get; set; }
	    public int? ClaveDeTurno { get; set; }
	    public int? ID_VigenciaAdscripcion { get; set; }
	    public DateTime? Fecha_Inicio { get; set; }
	    public DateTime? Fecha_Fin { get; set; }
	    public int? ID_TipoVacante { get; set; }
	    public int? ID_TipoNombramiento { get; set; }
	    public int? ID_TipoCategoria { get; set; }
	    public string Funcion { get; set; }
	    public string TipoEvaluacion { get; set; }
	    public int? ClaveEntidad { get; set; }
	    public string TipoSostenimiento { get; set; }
	    public string ClavePresupuestal { get; set; }
	    public DateTime? FechaAsignacion { get; set; }
	    public int? ClaveEntidad_OrigenDocente { get; set; }
	    public bool? AproboEvaluacionInduccion { get; set; }
	    public string UsuarioRegistro { get; set; }
	    public int? ClaveEstatusAsignacion { get; set; }
	    public int? ID_MotivoRechazo { get; set; }
	    public string Servicio { get; set; }
        public int? ID_DenominacionPlaza { get; set; }
        public int? ID_TipoPlaza { get; set; }
        public int? NumHoras { get; set; }
    }
}
