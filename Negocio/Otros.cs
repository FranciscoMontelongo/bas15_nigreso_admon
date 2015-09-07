using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos;

namespace Negocio
{
    public class Otros : General
    {
        private Procedimientos _Proc;

        public Procedimientos Proc { get { return _Proc; } set { _Proc = value; StoreProcedure = _Proc.ToString(); } }

        private string _Usuario;

        public string Usuario { get { return _Usuario; } set { _Usuario = value; } }

        private string _Contraseña;

        public string Contraseña { get { return _Contraseña; } set { _Contraseña = value; } }

        private string _Perfil;

        public string Perfil { get { return _Perfil; } set { _Perfil = value; } }

        private int _id_Usuario;

        public int id_Usuario { get { return _id_Usuario; } set { _id_Usuario = value; } }

        private int _id_Padre;

        public int id_Padre { get { return _id_Padre; } set { _id_Padre = value; } }

        private int _Ent;

        public int Ent { get { return _Ent; } set { _Ent = value; } }

        private int _ClaveSubsistema;

        public int ClaveSubsistema { get { return _ClaveSubsistema; } set { _ClaveSubsistema = value; } }

        private int _Entidad;

        public int Entidad { get { return _Entidad; } set { _Entidad = value; } }

        private string _ClaveCCT;

        public string ClaveCCT { get { return _ClaveCCT; } set { _ClaveCCT = value; } }

        private string _Folio;

        public string Folio { get { return _Folio; } set { _Folio = value; } }

        private string _sEntidad;

        public string sEntidad { get { return _sEntidad; } set { _sEntidad = value; } }
        // Montel Las agrego...
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }



        public override void LlenaParametros()
        {
            switch (Proc)
            {
                case Procedimientos.spt_SEL_ObtieneLogin:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Usuario", Value = Usuario });
                    _lparam.Add(new DataParam { Name = "@Pass", Value = Contraseña });
                    _lparam.Add(new DataParam { Name = "@Perfil", Value = Perfil });
                    break;

                case Procedimientos.spt_Sel_Perfiles:
                    _lparam = new List<DataParam>();
                    break;

                case Procedimientos.usc_TS_ASIGNACIONMenu:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@id_usuario", Value = id_Usuario });
                    break;

                case Procedimientos.spt_SEL_SeleccionarEntidadClaveTipo2:
                    _lparam = new List<DataParam>();
                    break;
                case Procedimientos.spt_SEL_SeleccionarEntidad_Resultado:
                    _lparam = new List<DataParam>();
                    break;
                case Procedimientos.spt_SEL_SeleccionarEntidad_Resultado_tbl2:
                    _lparam = new List<DataParam>();
                    break;
                case Procedimientos.spt_SEL_Todos_SISTEMAS_ENTIDAD:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@cveEntidad", Value = Ent });
                    break;

                case Procedimientos.spt_SEL_Todos_SISTEMAS_ENTIDAD_2:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@cveEntidad", Value = Ent });
                    break;

                case Procedimientos.spt_SEL_Todos_SISTEMAS_ENTIDAD_4:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@sEntidad", Value = sEntidad });
                    break;

                case Procedimientos.spt_SEL_Todos_SISTEMAS_ENTIDAD_4_tbl2:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@sEntidad", Value = sEntidad });
                    break;
                case Procedimientos.spt_SEL_Todos_ASIGNACION_SISTEMAS_ENTIDAD:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@ClaveSubsistema", Value = ClaveSubsistema });
                    break;

                case Procedimientos.spt_SEL_ImpresionFoliosAsignacion:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@ClaveSubsistema", Value = ClaveSubsistema });
                    _lparam.Add(new DataParam { Name = "@Folio", Value = Folio });
                    break;

                case Procedimientos.stp_SEL_ObtieneTodosSubsistemas:
                    _lparam = new List<DataParam>();
                    break;

                case Procedimientos.spt_SEL_CCT_SUBSIS_REsultado:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@sEntidad", Value = sEntidad });
                    _lparam.Add(new DataParam { Name = "@cvesubsist", Value = ClaveSubsistema });

                    break;

                case Procedimientos.spt_Sel_CargoDirectores_CCT_Subsistema:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@sEntidad", Value = sEntidad });
                    _lparam.Add(new DataParam { Name = "@cvesubsist", Value = ClaveSubsistema });
                    _lparam.Add(new DataParam { Name = "@CCT", Value = ClaveCCT });

                    break;
                case Procedimientos.spt_Sel_CargoDirectores_CCT_Subsistema_tbl2:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@sEntidad", Value = sEntidad });
                    _lparam.Add(new DataParam { Name = "@cvesubsist", Value = ClaveSubsistema });
                    break;
                // Montel Agrego estos metodos y sps...
                case Procedimientos.spt_AsignacionFechasXEntidad:
                    _lparam = new List<DataParam>();
                    break;
                case Procedimientos.spt_ActualizaFechasXEntidad:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@FechaIni", Value = FechaIni });
                    _lparam.Add(new DataParam { Name = "@FechaFin", Value = FechaFin });
                    break;
                case Procedimientos.spt_Asignacion_SEL_ConfiguracionFechas_PorEntidad:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@ClaveEntidad", Value = Entidad });
                    break;
            }
        }

        public enum Procedimientos
        {
            spt_Sel_Perfiles,
            spt_SEL_ObtieneLogin,
            usc_TS_ASIGNACIONMenu,
            spt_SEL_SeleccionarEntidadClaveTipo2,
            spt_SEL_SeleccionarEntidad_Resultado,
            spt_SEL_SeleccionarEntidad_Resultado_tbl2,
            spt_SEL_Todos_SISTEMAS_ENTIDAD,
            spt_SEL_Todos_SISTEMAS_ENTIDAD_2,
            spt_SEL_Todos_SISTEMAS_ENTIDAD_4,
            spt_SEL_Todos_SISTEMAS_ENTIDAD_4_tbl2,
            spt_SEL_Todos_ASIGNACION_SISTEMAS_ENTIDAD,
            spt_SEL_ImpresionFoliosAsignacion,
            stp_SEL_ObtieneTodosSubsistemas,
            spt_SEL_CCT_SUBSIS_REsultado,
            spt_Sel_CargoDirectores_CCT_Subsistema,
            spt_Sel_CargoDirectores_CCT_Subsistema_tbl2,
            spt_AsignacionFechasXEntidad,
            spt_ActualizaFechasXEntidad,
            spt_Asignacion_SEL_ConfiguracionFechas_PorEntidad
        }
    }
}