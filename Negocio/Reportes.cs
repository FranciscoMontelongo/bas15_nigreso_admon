using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;

namespace Negocio
{
    public class Reportes : General
    {
        private Procedimientos _Proc;
        public Procedimientos Proc { get { return _Proc; } set { _Proc = value; StoreProcedure = _Proc.ToString(); } }

        private ReportesArg _Reportes;
        public ReportesArg _Ent_Usuario { get { return _Reportes; } set { _Reportes = value; } }

        public override void LlenaParametros()
        {
            switch (Proc)
            {
                case Procedimientos.spt_Asignacion_SEL_Reporte_De_Asignaciones:
                    var _Ent_Usuario = this._Ent_Usuario._Ent_Usuario;
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Funcion", Value = _Ent_Usuario.Funcion });
                    _lparam.Add(new DataParam { Name = "@TipoEvaluacion", Value = _Ent_Usuario.TipoEvaluacion });
                    _lparam.Add(new DataParam { Name = "@Servicio", Value = _Ent_Usuario.Servicio });
                    _lparam.Add(new DataParam { Name = "@ClaveEntidad", Value = _Ent_Usuario.ClaveEntidad });
                    _lparam.Add(new DataParam { Name = "@TipoSostenimiento", Value = _Ent_Usuario.TipoSostenimiento });
                    _lparam.Add(new DataParam { Name = "@ClaveEstatusAsignacion", Value = _Ent_Usuario.ClaveEstatusAsignacion });
                    break;
                case Procedimientos.spt_Asignacion_SEL_Entidades:
                    _lparam = new List<DataParam>();
                    break;
                case Procedimientos.spt_Asignacion_SEL_Reporte_General:
                    var _Ent_Usuario2 = this._Ent_Usuario._Ent_Usuario;
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@ClaveEntidad", Value = _Ent_Usuario2.ClaveEntidad });
                    break;
                case Procedimientos.spt_Asignacion_SEL_Cat_TipoNombramiento:
                    var _Ent_Usuario3 = this._Ent_Usuario._Ent_Usuario;
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Concurso", Value = _Ent_Usuario3.Concurso });
                    if (_Ent_Usuario3.TipoPantalla == null) { _Ent_Usuario3.TipoPantalla = "1"; }
                    _lparam.Add(new DataParam { Name = "@TipoPantalla", Value = _Ent_Usuario3.TipoPantalla });
                    break;
            }
        }

        public enum Procedimientos
        {
            spt_Asignacion_SEL_Reporte_De_Asignaciones,
            spt_Asignacion_SEL_Entidades,
            spt_Asignacion_SEL_Reporte_General,
            spt_Asignacion_SEL_Cat_TipoNombramiento
        }
    }

    public class ReportesArg
    {
        public Ent_Usuario _Ent_Usuario { get; set; }
    }
}