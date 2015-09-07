using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Datos;

namespace Negocio
{
    public class Filtro : General
    {
        private Procedimientos _Proc;
        public Procedimientos Proc { get { return _Proc; } set { _Proc = value; StoreProcedure = _Proc.ToString(); } }

        private FiltroArg _Filtros;
        public FiltroArg Filtros { get { return _Filtros; } set { _Filtros = value; } }

        public Filtro()
        {
            _Filtros = new FiltroArg();
        }

        public override void LlenaParametros()
        {
            switch (Proc)
            {
                case Procedimientos.spt_SEL_ObtieneFunciones:
                    _lparam = new List<DataParam>();
                    break;

                case Procedimientos.spt_SEL_ObtieneTipo_Evaluacion:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Funcion", Value = Filtros.Funcion });
                    break;

                case Procedimientos.spt_SEL_ObtieneResultadosServicios:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Funcion", Value = Filtros.Funcion });
                    _lparam.Add(new DataParam { Name = "@Tipo_Evaluacion", Value = Filtros.Tipo_Evaluacion });
                    break;

                case Procedimientos.spt_SEL_ObtieneEntidad_Federativa:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Funcion", Value = Filtros.Funcion });
                    _lparam.Add(new DataParam { Name = "@Tipo_Evaluacion", Value = Filtros.Tipo_Evaluacion });
                    _lparam.Add(new DataParam { Name = "@Servicio", Value = Filtros.Servicio });
                    break;

                case Procedimientos.spt_SEL_ObtieneTipo_Sostenimiento:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Funcion", Value = Filtros.Funcion });
                    _lparam.Add(new DataParam { Name = "@Tipo_Evaluacion", Value = Filtros.Tipo_Evaluacion });
                    _lparam.Add(new DataParam { Name = "@Servicio", Value = Filtros.Servicio });
                    _lparam.Add(new DataParam { Name = "@Entidad_Federativa", Value = Filtros.Entidad_Federativa });
                    break;
                case Procedimientos.spt_SEL_ObtieneTipoPlaza:
                    _lparam = new List<DataParam>();
                    break;
                case Procedimientos.spt_SEL_ObtieneNivelCarrera:
                    _lparam = new List<DataParam>();
                    break;/*------------------------------------*/
                case Procedimientos.spt_SEL_ObtieneTurno:
                    _lparam = new List<DataParam>();
                    break;
                case Procedimientos.spt_SEL_ObtieneVigenciaAdscripcion:
                    _lparam = new List<DataParam>();
                    break;
                case Procedimientos.spt_SEL_ObtieneTipoVacante:
                    _lparam = new List<DataParam>();
                    break;
                case Procedimientos.spt_SEL_ObtieneTipoNombramiento:
                    _lparam = new List<DataParam>();
                    break;
                case Procedimientos.spt_SEL_ObtieneTipoCategoria:
                    _lparam = new List<DataParam>();
                    break;
                case Procedimientos.spt_SEL_DenominacionPlaza:
                    _lparam = new List<DataParam>();
                    break;
                case Procedimientos.spt_SEL_SeleccionarTodoEntidad:
                    _lparam = new List<DataParam>();
                    break;
                case Procedimientos.spt_SEL_TipoPlaza:
                    _lparam = new List<DataParam>();
                    break;
                case Procedimientos.spt_SEL_ObtieneDenominacionPlazaXTipoCategoria:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@ID_TipoCategoria", Value = Filtros.ID_TipoCategoria });
                    break;
                /*------------------------------------*/
            }
        }

        public enum Procedimientos
        {
            spt_SEL_ObtieneFunciones,
            spt_SEL_ObtieneTipo_Evaluacion,
            spt_SEL_ObtieneResultadosServicios,
            spt_SEL_ObtieneEntidad_Federativa,
            spt_SEL_ObtieneTipo_Sostenimiento,

            spt_SEL_ObtieneTipoPlaza,
            spt_SEL_ObtieneNivelCarrera,

            spt_SEL_ObtieneTurno,
            spt_SEL_ObtieneVigenciaAdscripcion,
            spt_SEL_ObtieneTipoVacante,
            spt_SEL_ObtieneTipoNombramiento,
            spt_SEL_ObtieneTipoCategoria,
            spt_SEL_DenominacionPlaza,
            spt_SEL_SeleccionarTodoEntidad,
            spt_SEL_TipoPlaza,
            spt_SEL_ObtieneDenominacionPlazaXTipoCategoria
        }
    }

    public class FiltroArg
    {
        public string Funcion { get; set; }
        public int ClaveEntidad { get; set; }
        public string Tipo_Evaluacion { get; set; }
        public string Servicio { get; set; }
        public string Entidad_Federativa { get; set; }
        public string Tipo_Sostenimiento { get; set; }
        public string ID_TipoCategoria { get; set; }
    }
}
