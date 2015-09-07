using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;

namespace Negocio
{
    public class TableroC : General
    {
        private Procedimientos _Proc;
        public Procedimientos Proc { get { return _Proc; } set { _Proc = value; StoreProcedure = _Proc.ToString(); } }

        private AsignacionTableroArg _TableroCA;
        public AsignacionTableroArg TableroCA { get { return _TableroCA; } set { _TableroCA = value; } }

        public TableroC()
        {
            _TableroCA = new AsignacionTableroArg();
        }

        public override void LlenaParametros()
        {            
            switch (Proc)
            {
                case Procedimientos.spt_SEL_ObtenTotalAspirantes:                    
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@cveEntidad", Value = TableroCA.CveEntidad });                    
                    break;

                case Procedimientos.spt_SEL_ObtenTipoPlazaHoras:
                    _lparam = new List<DataParam>();                    
                    _lparam.Add(new DataParam { Name = "@cveEntidad", Value = TableroCA.CveEntidad });
                    break;

                case Procedimientos.spt_SEL_ObtenTipoSostenimientoHoras:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@cveEntidad", Value = TableroCA.CveEntidad });
                    break;

                case Procedimientos.spt_SEL_SeleccionarEntidad:
                    _lparam = new List<DataParam>();                                        
                    break;
            }
        }


        public enum Procedimientos
        {
            spt_SEL_ObtenTotalAspirantes,
            spt_SEL_SeleccionarEntidad,
            spt_SEL_ObtenTipoPlazaHoras,
            spt_SEL_ObtenTipoSostenimientoHoras
        }        

    }

    public class AsignacionTableroArg
        {
            public string CveEntidad { get; set; }
        }
}
