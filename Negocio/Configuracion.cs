using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos;


namespace Negocio
{
    public class Configuracion : General
    {
        private Procedimientos _Proc;
        public Procedimientos Proc { get { return _Proc; } set { _Proc = value; StoreProcedure = _Proc.ToString(); } }

        private int _SubSis;
        public int SubSis { get { return _SubSis; } set { _SubSis = value; } }
        private int _Entidad;
        public int Entidad { get { return _Entidad; } set { _Entidad = value; } }
        private int _CveEstatus;
        public int CveEstatus { get { return _CveEstatus; } set { _CveEstatus = value; } }
        private DateTime _FechaFinalAsignacion;
        public DateTime FechaFinalAsignacion { get { return _FechaFinalAsignacion; } set { _FechaFinalAsignacion = value; } }
        private DateTime _FechaInicioAsignacion;
        public DateTime FechaInicioAsignacion { get { return _FechaInicioAsignacion; } set { _FechaInicioAsignacion = value; } }
        private int _Tipo;
        public int Tipo { get { return _Tipo; } set { _Tipo = value; } }
        private string _cveDisc;
        public string cveDisc { get { return _cveDisc; } set { _cveDisc = value; } }
        private string _cveAfin;
        public string cveAfin { get { return _cveAfin; } set { _cveAfin = value; } }
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        public override void LlenaParametros()
        {
            switch (Proc)
            {
                case Procedimientos.spt_Asignacion_USC_ConfiguracionFechas:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@SubSis", Value = SubSis });
                    break;
                case Procedimientos.spt_Asignacion_UPD_ConfiguracionFechas:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@FechaFinalAsignacion", Value = FechaFinalAsignacion });
                    _lparam.Add(new DataParam { Name = "@FechaInicioAsignacion", Value = FechaInicioAsignacion });
                    _lparam.Add(new DataParam { Name = "@SubSis", Value = SubSis });
                    break;
                case Procedimientos.spt_Asignacion_SEL_AsignacionConfiguracionListaDeEspera:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubSis", Value = SubSis });
                    break;
                case Procedimientos.spt_SEL_CargaDatos_Perfiles2:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@CVESUBSIS", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@Tipo", Value = Tipo });
                    break;
                case Procedimientos.spt_SEL_Todos_Disiplinares2:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@cveSubSis", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@cveTipo", Value = Tipo });
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = cveDisc });
                    break;
                case Procedimientos.spt_SEL_Todos_Disiplinares3:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@cveSubSis", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@cveTipo", Value = Tipo });
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@Categoria", Value = cveDisc });
                    break;
                case Procedimientos.spt_Asignacion_INS_AsignacionConfiguracionListaDeEspera:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubSis", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@Categoria", Value = cveDisc });
                    _lparam.Add(new DataParam { Name = "@Afin", Value = cveAfin });
                    _lparam.Add(new DataParam { Name = "@TIPO", Value = Tipo });
                    break;
                case Procedimientos.spt_Asignacion_UPD_AsignacionConfiguracionListaDeEspera:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@ID", Value = ID });
                    break;

            }
        }
        public enum Procedimientos
        {
            spt_Asignacion_USC_ConfiguracionFechas,
            spt_Asignacion_UPD_ConfiguracionFechas,
            spt_Asignacion_SEL_AsignacionConfiguracionListaDeEspera,
            spt_SEL_CargaDatos_Perfiles2,
            spt_SEL_Todos_Disiplinares2,
            spt_SEL_Todos_Disiplinares3,
            spt_Asignacion_INS_AsignacionConfiguracionListaDeEspera,
            spt_Asignacion_UPD_AsignacionConfiguracionListaDeEspera
        } 
    }
}
