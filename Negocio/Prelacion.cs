using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos;


namespace Negocio
{
    public class Prelacion : General
    {
        private Procedimientos _Proc;
        public Procedimientos Proc { get { return _Proc; } set { _Proc = value; StoreProcedure = _Proc.ToString(); } }

        private int _SubSis;
        public int SubSis { get { return _SubSis; } set { _SubSis = value; } }
        private int _Entidad;
        public int Entidad { get { return _Entidad; } set { _Entidad = value; } }
        private int _Tipo;
        public int Tipo { get { return _Tipo; } set { _Tipo = value; } }
        private string _ClaveCentroTrabajo;
        public string ClaveCentroTrabajo { get { return _ClaveCentroTrabajo; } set { _ClaveCentroTrabajo = value; } }
        private string _ClaveCCT;

        public string ClaveCCT { get { return _ClaveCCT; } set { _ClaveCCT = value; } }
        private string _cargo;

        public string Cargo { get { return _cargo; } set { _cargo = value; } }
        public override void LlenaParametros()
        {
            switch (Proc)
            {
                case Procedimientos.spt_Asignacion_PrelacionConsulta:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubSis", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@cct", Value = ClaveCCT });
                    _lparam.Add(new DataParam { Name = "@cargo", Value = Cargo });
                    break;
                case Procedimientos.spt_Asignacion_PrelacionConsulta_tbl2:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubSis", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@cct", Value = ClaveCCT });
                    _lparam.Add(new DataParam { Name = "@cargo", Value = Cargo });
                    break;
            }
        }
        public enum Procedimientos
        {
            spt_Asignacion_PrelacionConsulta,
            spt_Asignacion_PrelacionConsulta_tbl2
        }
    }
}
