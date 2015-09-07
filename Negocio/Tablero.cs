using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos;


namespace Negocio
{
    public class Tablero : General
    {
        private Procedimientos _Proc;
        public Procedimientos Proc { get { return _Proc; } set { _Proc = value; StoreProcedure = _Proc.ToString(); } }

        private int _SubSis;
        public int SubSis { get { return _SubSis; } set { _SubSis = value; } }
        private int _Entidad;
        public int Entidad { get { return _Entidad; } set { _Entidad = value; } }

        private int _CveEstatus;
        public int CveEstatus { get { return _CveEstatus; } set { _CveEstatus = value; } }

        public override void LlenaParametros()
        {
            switch (Proc)
            {
                case Procedimientos.spt_Asignacion_SEL_ASIGNACION_ASPIRANTES:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubSis", Value = SubSis });
                    break;

                case Procedimientos.spt_Asignacion_SEL_ASIGNACION_ASPIRANTES_tbl2:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubSis", Value = SubSis });
                    break;

                case Procedimientos.spt_Asignacion_SEL_ASIGNACION_FOLIOSGENERADOS:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubSis", Value = SubSis });
                    break;


                case Procedimientos.spt_Asignacion_SEL_ASIGNACION_FOLIOSGENERADOS_tbl2:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubSis", Value = SubSis });
                    break;
                case Procedimientos.spt_Asignacion_SEL_ASIGNACION_SOLICITUDES:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubSis", Value = SubSis });
                    break;
                case Procedimientos.spt_Asignacion_SEL_ASIGNACION_NOTIFICACIONES:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubSis", Value = SubSis });
                    break;
                case Procedimientos.spt_Asignacion_SEL_ASIGNACION_SOSTENIMIENTO:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubSis", Value = SubSis });
                    break;
                case Procedimientos.spt_Asignacion_SEL_Uno_AsignacionNotificacion:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubsSis", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@CveEstatus", Value = CveEstatus });
                    break;
                case Procedimientos.spt_Asignacion_SEL_Notificaciones:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubsSis", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@cveEstatus", Value = CveEstatus });
                    break;
                case Procedimientos.spt_Asignacion_SEL_Notificaciones_tbl2:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubsSis", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@cveEstatus", Value = CveEstatus });
                    break;
                case Procedimientos.spt_Asignacion_SEL_ASIGNACION_SOSTENIMIENTO_ACTUALES:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubsSis", Value = SubSis });
                    break;
            }
        }
        public enum Procedimientos
        {
            spt_Asignacion_SEL_ASIGNACION_ASPIRANTES,
            spt_Asignacion_SEL_ASIGNACION_ASPIRANTES_tbl2,
            spt_Asignacion_SEL_ASIGNACION_FOLIOSGENERADOS,
            spt_Asignacion_SEL_ASIGNACION_FOLIOSGENERADOS_tbl2,
            spt_Asignacion_SEL_ASIGNACION_SOLICITUDES,
            spt_Asignacion_SEL_ASIGNACION_NOTIFICACIONES,
            spt_Asignacion_SEL_ASIGNACION_SOSTENIMIENTO,
            spt_Asignacion_SEL_Uno_AsignacionNotificacion,
            spt_Asignacion_SEL_Notificaciones,
            spt_Asignacion_SEL_Notificaciones_tbl2,
            spt_Asignacion_SEL_ASIGNACION_SOSTENIMIENTO_ACTUALES
        }
    }

}
