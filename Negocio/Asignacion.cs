using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos;


namespace Negocio
{
    public class Asignacion : General
    {
        private Procedimientos _Proc;
        public Procedimientos Proc { get { return _Proc; } set { _Proc = value; StoreProcedure = _Proc.ToString(); } }
        #region Variables

        //JDRA ID_Resultados - pkresultados
        private int _id_Resultados;

        public int Id_Resultados
        {
            get { return _id_Resultados; }
            set { _id_Resultados = value; }
        }

        private int _ID_Antecedente;

        public int ID_Antecedente
        {
            get { return _ID_Antecedente; }
            set { _ID_Antecedente = value; }
        }

        private int _SubSis;
        public int SubSis { get { return _SubSis; } set { _SubSis = value; } }
        private int _Entidad;
        public int Entidad { get { return _Entidad; } set { _Entidad = value; } }
        private int _Tipo;
        public int Tipo { get { return _Tipo; } set { _Tipo = value; } }
        private int _cveEstatus;
        public int cveEstatus { get { return _cveEstatus; } set { _cveEstatus = value; } }
        private string _GPO;
        public string GPO { get { return _GPO; } set { _GPO = value; } }
        private string _CURP;
        public string CURP { get { return _CURP; } set { _CURP = value; } }
        private int _TipoDocente;
        public int TipoDocente { get { return _TipoDocente; } set { _TipoDocente = value; } }
        private string _Categoria;
        public string Categoria { get { return _Categoria; } set { _Categoria = value; } }
        private string _ClaveCCT;
        public string ClaveCCT { get { return _ClaveCCT; } set { _ClaveCCT = value; } }
        private string _DescCCT;
        public string DescCCT { get { return _DescCCT; } set { _DescCCT = value; } }
        private int _TipoSost;
        public int TipoSost { get { return _TipoSost; } set { _TipoSost = value; } }
        private int _TipoPlaza;
        public int TipoPlaza { get { return _TipoPlaza; } set { _TipoPlaza = value; } }
        private string _EfectoNombramiento;
        public string EfectoNombramiento { get { return _EfectoNombramiento; } set { _EfectoNombramiento = value; } }
        private int _Turno;
        public int Turno { get { return _Turno; } set { _Turno = value; } }
        private string _CvePresupuestal;
        public string CvePresupuestal { get { return _CvePresupuestal; } set { _CvePresupuestal = value; } }
        private int _TipoNombramiento;
        public int TipoNombramiento { get { return _TipoNombramiento; } set { _TipoNombramiento = value; } }
        private int _EstatusAsignacion;
        public int EstatusAsignacion { get { return _EstatusAsignacion; } set { _EstatusAsignacion = value; } }
        private int _EstatusRechazo;
        public int EstatusRechazo { get { return _EstatusRechazo; } set { _EstatusRechazo = value; } }
        private string _FolioFed;
        public string FolioFed { get { return _FolioFed; } set { _FolioFed = value; } }
        private string _FolioGenerado;
        public string FolioGenerado { get { return _FolioGenerado; } set { _FolioGenerado = value; } }
        private string _UsuarioGenera;
        public string UsuarioGenera { get { return _UsuarioGenera; } set { _UsuarioGenera = value; } }
        private string _Campo;
        public string Campo { get { return _Campo; } set { _Campo = value; } }
        private string _EstatusAsigancion;
        public string EstatusAsigancion { get { return _EstatusAsigancion; } set { _EstatusAsigancion = value; } }
        private int _ClaveNombramiento;
        public int ClaveNombramiento { get { return _ClaveNombramiento; } set { _ClaveNombramiento = value; } }
        public string CURPS { get; set; }
        private int _Firma;
        public int Firma { get { return _Firma; } set { _Firma = value; } }
        private int _IdUsuarioAsignador;
        public int IdUsuarioAsignador { get { return _IdUsuarioAsignador; } set { _IdUsuarioAsignador = value; } }
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }
        private int _idUsuarioGenera;
        public int idUsuarioGenera { get { return _idUsuarioGenera; } set { _idUsuarioGenera = value; } }
        private int _Opcion;
        public int Opcion { get { return _Opcion; } set { _Opcion = value; } }
        private DateTime? _FechaInicio;
        public DateTime? FechaInicio { get { return _FechaInicio; } set { _FechaInicio = value; } }
        private DateTime? _FechaTermino;
        public DateTime? FechaTermino { get { return _FechaTermino; } set { _FechaTermino = value; } }
        private int _Adicional;
        public int Adicional { get { return _Adicional; } set { _Adicional = value; } }
        private int _TipoRegistro;//SILVER
        public int TipoRegistro { get { return _TipoRegistro; } set { _TipoRegistro = value; } }
        private int _TipoSostenimiento;
        public int TipoSostenimiento { get { return _TipoSostenimiento; } set { _TipoSostenimiento = value; } }
        private string _Nombre;
        public string Nombre { get { return _Nombre; } set { _Nombre = value; } }
        private string _RFC;
        public string RFC { get { return _RFC; } set { _RFC = value; } }
        private int _TipoPerfil;
        public int TipoPerfil { get { return _TipoPerfil; } set { _TipoPerfil = value; } }
        private string _Direccion;
        public string Direccion { get { return _Direccion; } set { _Direccion = value; } }
        private long _Telefono;
        public long Telefono { get { return _Telefono; } set { _Telefono = value; } }
        private long _TelefonoCelular;
        public long TelefonoCelular { get { return _TelefonoCelular; } set { _TelefonoCelular = value; } }
        private string _Correo;
        public string Correo { get { return _Correo; } set { _Correo = value; } }
        private int? _Jornada;
        public int? Jornada { get { return _Jornada; } set { _Jornada = value; } }
        private decimal? _Horas;
        public decimal? Horas { get { return _Horas; } set { _Horas = value; } }
        private int _Estatus;
        public int Estatus { get { return _Estatus; } set { _Estatus = value; } }
        private string _ApeidoPaterno;
        public string ApeidoPaterno { get { return _ApeidoPaterno; } set { _ApeidoPaterno = value; } }
        private string _ApeidoMaterno;
        public string ApeidoMaterno { get { return _ApeidoMaterno; } set { _ApeidoMaterno = value; } }
        private string _DesEntidadAsignacion;
        public string DesEntidadAsignacion { get { return _DesEntidadAsignacion; } set { _DesEntidadAsignacion = value; } }
        private string _DesEntidad;
        public string DesEntidad { get { return _DesEntidad; } set { _DesEntidad = value; } }
        private string _cargo;

        public string Cargo { get { return _cargo; } set { _cargo = value; } }
        private int _prelacion;
        public int prelacion { get { return _prelacion; } set { _prelacion = value; } }


        private int _HorasAntecedente;
        public int HorasAntecedente { get { return _HorasAntecedente; } set { _HorasAntecedente = value; } }
        private string _ClavePlaza;
        public string ClavePlaza { get { return _ClavePlaza; } set { _ClavePlaza = value; } }
        private string _DescPlaza;
        public string DescPlaza { get { return _DescPlaza; } set { _DescPlaza = value; } }
        private int _NivelCarrera;
        public int NivelCarrera { get { return _NivelCarrera; } set { _NivelCarrera = value; } }

        private AsignacionFiltroArg _Parametros;
        public AsignacionFiltroArg Parametros { get { return _Parametros; } set { _Parametros = value; } }

        #endregion

        public Asignacion()
        {
            _Parametros = new AsignacionFiltroArg();
        }

        public override void LlenaParametros()
        {
            switch (Proc)
            {
                case Procedimientos.spt_Asignacion_SEL_Todos_AsignacionEstatus:
                    _lparam = new List<DataParam>();
                    break;
                case Procedimientos.spt_Asignacion_SEL_Todos_Grupos:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Tipo", Value = Tipo });
                    break;
                case Procedimientos.spt_Asignacion_SEL_Todos_ResultadosFILTRO:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubSis", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@cveEstatus", Value = cveEstatus });
                    _lparam.Add(new DataParam { Name = "@cct", Value = ClaveCCT });
                    _lparam.Add(new DataParam { Name = "@cargo", Value = Cargo });

                    break;

                case Procedimientos.spt_Asignacion_SEL_Todos_ResultadosFILTRO_tbl2:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubSis", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@cveEstatus", Value = cveEstatus });
                    _lparam.Add(new DataParam { Name = "@cargo", Value = Cargo });

                    break;

                case Procedimientos.spt_Asignacion_SEL_SOSTENIMIENTO:
                    _lparam = new List<DataParam>();
                    break;
                case Procedimientos.spt_Asignacion_INS_ASIGNACION:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@ID", Value = ClaveNombramiento });
                    _lparam.Add(new DataParam { Name = "@ClaveEntidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@ClaveSubsistema", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@CURP", Value = CURP });
                    _lparam.Add(new DataParam { Name = "@ClaveCCT", Value = ClaveCCT });
                    _lparam.Add(new DataParam { Name = "@DescripcionCCT", Value = DescCCT });
                    _lparam.Add(new DataParam { Name = "@EfectosNombramientos", Value = EfectoNombramiento });
                    _lparam.Add(new DataParam { Name = "@TipoPlaza", Value = TipoPlaza });
                    _lparam.Add(new DataParam { Name = "@ClavePresupuestal", Value = CvePresupuestal });
                    _lparam.Add(new DataParam { Name = "@Turno", Value = Turno });
                    _lparam.Add(new DataParam { Name = "@EstatusAsignacion", Value = EstatusAsignacion });
                    _lparam.Add(new DataParam { Name = "@TipoNombramiento", Value = TipoNombramiento });
                    _lparam.Add(new DataParam { Name = "@EstatusRechazo", Value = EstatusRechazo });
                    _lparam.Add(new DataParam { Name = "@FolioFederal", Value = FolioFed });
                    _lparam.Add(new DataParam { Name = "@FolioGenerado", Value = FolioGenerado });
                    _lparam.Add(new DataParam { Name = "@UsuarioModificacion", Value = UsuarioGenera });
                    _lparam.Add(new DataParam { Name = "@FechaInicio", Value = FechaInicio });
                    _lparam.Add(new DataParam { Name = "@Fechatermino", Value = FechaTermino });
                    _lparam.Add(new DataParam { Name = "@prelacion", Value = prelacion });
                    break;
                case Procedimientos.spt_Asignacion_SEL_AsignaturasValidaSistema:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubSis", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@Categoria", Value = Categoria });
                    _lparam.Add(new DataParam { Name = "@Tipo", Value = Tipo });
                    _lparam.Add(new DataParam { Name = "@TipoPlaza", Value = TipoPlaza });
                    break;
                case Procedimientos.spt_SEL_ASIGNACION_COMPROBACION:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@ClaveSubsistema", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@CentroTrabajo", Value = DescCCT });
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = DesEntidadAsignacion });
                    break;
                case Procedimientos.spt_Asignacion_SEL_ASIGNATURAS:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@SubSis", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    break;
                case Procedimientos.spt_Asignacion_INS_GENERAFOLIOS:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubSis", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@CURPs", Value = this.CURPS });
                    break;
                case Procedimientos.spt_SEL_TiposNombramientoAspirante:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@CURP", Value = CURP });
                    _lparam.Add(new DataParam { Name = "@FolioFederal", Value = FolioFed });
                    _lparam.Add(new DataParam { Name = "@prelacion", Value = prelacion });

                    break;
                case Procedimientos.spt_SEL_TiposNombramientoAspiranteDetalle:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@ID", Value = ClaveNombramiento });
                    _lparam.Add(new DataParam { Name = "@CURP", Value = CURP });
                    break;
                case Procedimientos.SPT_DEL_EliminaAspiranteAsignacionDetalle:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@ID", Value = ClaveNombramiento });
                    break;
                case Procedimientos.spt_SEL_SeleccionarFolios:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubSis", Value = SubSis });
                    break;
                case Procedimientos.spt_Asignacion_Sel_Firma:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubSis", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@Folio", Value = FolioGenerado });
                    break;
                case Procedimientos.spt_Asignacion_UPD_Firma:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@CURP", Value = CURP });
                    _lparam.Add(new DataParam { Name = "@Firma", Value = Firma });
                    break;
                case Procedimientos.spt_Asignacion_Sel_FirmaSolicitudes:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubSis", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@Folio", Value = FolioGenerado });
                    _lparam.Add(new DataParam { Name = "@Firma", Value = Firma });
                    break;
                case Procedimientos.spt_InsertaAsignacionSolicitudes:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@ClaveEntidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@ClaveSubsistema", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@CURP", Value = CURP });
                    _lparam.Add(new DataParam { Name = "@FolioGenerado", Value = FolioGenerado });
                    _lparam.Add(new DataParam { Name = "@IdUsuarioAsignador", Value = IdUsuarioAsignador });
                    break;



                case Procedimientos.spt_InsertaAsignacionSolicitudes_tbl2:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@ClaveEntidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@ClaveSubsistema", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@CURP", Value = CURP });
                    _lparam.Add(new DataParam { Name = "@FolioGenerado", Value = FolioGenerado });
                    _lparam.Add(new DataParam { Name = "@IdUsuarioAsignador", Value = IdUsuarioAsignador });
                    break;
                case Procedimientos.spt_Asignacion_UPD_Notificaciones:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@idNotificacion", Value = ID });
                    _lparam.Add(new DataParam { Name = "@EstatusAccion", Value = cveEstatus });
                    _lparam.Add(new DataParam { Name = "@idUsuarioCoordinador", Value = idUsuarioGenera });
                    break;
                case Procedimientos.spt_Sel_NuevoEstatusAsignacion:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Opcion", Value = Opcion });
                    break;
                case Procedimientos.spt_ObtieneEstatus:
                    _lparam = new List<DataParam>();
                    break;
                case Procedimientos.spt_Asignacion_SEL_Todos_ResultadosFiltroAdicionales:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@SubSis", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@cveEstatus", Value = cveEstatus });
                    _lparam.Add(new DataParam { Name = "@Adicional", Value = Adicional });
                    break;
                case Procedimientos.spt_Asignacion_SEL_VerificaNuevoregistro:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@CURP", Value = CURP });
                    break;
                case Procedimientos.spt_ObtieneCatalogos:
                    _lparam = new List<DataParam>();
                    break;
                case Procedimientos.spt_InertaNuevoRegistroAsignacion:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@Susbistema", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@Tipo", Value = Tipo });
                    _lparam.Add(new DataParam { Name = "@Estatus", Value = Estatus });
                    _lparam.Add(new DataParam { Name = "@CURP", Value = CURP });
                    _lparam.Add(new DataParam { Name = "@TipoRegistro", Value = TipoRegistro });
                    _lparam.Add(new DataParam { Name = "@TipoSostenimiento", Value = TipoSostenimiento });
                    _lparam.Add(new DataParam { Name = "@Nombre", Value = Nombre });
                    _lparam.Add(new DataParam { Name = "@ApeidoPaterno", Value = ApeidoPaterno });
                    _lparam.Add(new DataParam { Name = "@ApeidoMaterno", Value = ApeidoMaterno });
                    _lparam.Add(new DataParam { Name = "@RFC", Value = RFC });
                    _lparam.Add(new DataParam { Name = "@TipoPerfil", Value = TipoPerfil });
                    _lparam.Add(new DataParam { Name = "@Correo", Value = Correo });
                    _lparam.Add(new DataParam { Name = "@Direccion", Value = Direccion });
                    _lparam.Add(new DataParam { Name = "@Telefono", Value = Telefono });
                    _lparam.Add(new DataParam { Name = "@TelefonoCelular", Value = TelefonoCelular });
                    _lparam.Add(new DataParam { Name = "@ClaveCCT", Value = ClaveCCT });
                    _lparam.Add(new DataParam { Name = "@NombreCCT", Value = DescCCT });
                    _lparam.Add(new DataParam { Name = "@TipoPlaza", Value = TipoPlaza });
                    _lparam.Add(new DataParam { Name = "@Jornada", Value = Jornada });
                    _lparam.Add(new DataParam { Name = "@Horas", Value = Horas });
                    _lparam.Add(new DataParam { Name = "@Turno", Value = Turno });
                    _lparam.Add(new DataParam { Name = "@TipoNombramiento", Value = TipoNombramiento });
                    break;
                case Procedimientos.spt_SEL_ConsultaPublicaAsignacion:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@ClaveEntidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@ClaveSubsistema", Value = SubSis });
                    break;
                case Procedimientos.spt_SEL_ReporteAsignacionHistorico:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = DesEntidad });
                    _lparam.Add(new DataParam { Name = "@ClaveSubsistema", Value = SubSis });
                    break;
                case Procedimientos.spt_SEL_ReporteEstatusAsignacion_tbl2:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@Entidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@Subsistema", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@Estatus", Value = Estatus });
                    _lparam.Add(new DataParam { Name = "@cct", Value = ClaveCCT });
                    _lparam.Add(new DataParam { Name = "@cargo", Value = Cargo });
                    break;
                case Procedimientos.spt_Asignacion_INS_PlazasAntecedentes:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@ClaveEntidad", Value = Entidad });
                    _lparam.Add(new DataParam { Name = "@Id_Resultados", Value = Id_Resultados });
                    //_lparam.Add(new DataParam { Name = "@ClaveSubsistema", Value = SubSis });
                    _lparam.Add(new DataParam { Name = "@CURP", Value = CURP });
                    _lparam.Add(new DataParam { Name = "@ClaveCCT", Value = ClaveCCT });
                    _lparam.Add(new DataParam { Name = "@DescripcionCCT", Value = DescCCT });
                    _lparam.Add(new DataParam { Name = "@TipoPlaza", Value = TipoPlaza });
                    _lparam.Add(new DataParam { Name = "@Horas", Value = HorasAntecedente });
                    _lparam.Add(new DataParam { Name = "@ClavePlaza", Value = ClavePlaza });
                    _lparam.Add(new DataParam { Name = "@DescPlaza", Value = DescPlaza });
                    _lparam.Add(new DataParam { Name = "@ClavePresupuestal", Value = CvePresupuestal });
                    _lparam.Add(new DataParam { Name = "@NivelCarrera", Value = NivelCarrera });
                    _lparam.Add(new DataParam { Name = "@ID", Value = ID });
                    break;
                case Procedimientos.spt_SEL_MostrarPlazasAntecedentes:
                    _lparam = new List<DataParam>();
                    //_lparam.Add(new DataParam { Name = "@ClaveEntidad", Value = Entidad });
                    //_lparam.Add(new DataParam { Name = "@ClaveSubsistema", Value = SubSis });
                    //_lparam.Add(new DataParam { Name = "@CURP", Value = CURP });
                    _lparam.Add(new DataParam { Name = "@id_Resultados", Value = Id_Resultados });
                    break;

                case Procedimientos.spt_DEL_EliminaPlazasAntecedentes:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@ID_Antecedente", Value = ID_Antecedente });
                    break;
                case Procedimientos.spt_SEL_PlazasAntecedentesPorID:
                    _lparam = new List<DataParam>();
                    _lparam.Add(new DataParam { Name = "@ID_Antecedente", Value = ID_Antecedente });
                    break;

            }
        }
        public enum Procedimientos
        {
            spt_Asignacion_SEL_Todos_AsignacionEstatus,
            spt_Asignacion_SEL_Todos_Grupos,
            spt_Asignacion_SEL_Todos_ResultadosFILTRO,
            spt_Asignacion_SEL_Todos_ResultadosFILTRO_tbl2,
            spt_Asignacion_SEL_SOSTENIMIENTO,
            spt_Asignacion_INS_ASIGNACION,
            spt_Asignacion_INS_PlazasAntecedentes,
            spt_Asignacion_SEL_AsignaturasValidaSistema,
            spt_SEL_ASIGNACION_COMPROBACION,
            spt_Asignacion_SEL_ASIGNATURAS,
            spt_Asignacion_INS_GENERAFOLIOS,
            spt_SEL_TiposNombramientoAspirante,
            spt_SEL_TiposNombramientoAspiranteDetalle,
            SPT_DEL_EliminaAspiranteAsignacionDetalle,
            spt_SEL_SeleccionarFolios,
            spt_Asignacion_Sel_Firma,
            spt_Asignacion_UPD_Firma,
            spt_Asignacion_Sel_FirmaSolicitudes,
            spt_InsertaAsignacionSolicitudes,
            spt_InsertaAsignacionSolicitudes_tbl2,
            spt_Asignacion_UPD_Notificaciones,
            spt_Sel_NuevoEstatusAsignacion,
            spt_ObtieneEstatus,
            spt_Asignacion_SEL_Todos_ResultadosFiltroAdicionales,
            spt_Asignacion_SEL_VerificaNuevoregistro,
            spt_ObtieneCatalogos,
            spt_InertaNuevoRegistroAsignacion,
            spt_SEL_ConsultaPublicaAsignacion,
            spt_SEL_ReporteAsignacionHistorico,
            spt_SEL_ReporteEstatusAsignacion_tbl2,
            spt_SEL_MostrarPlazasAntecedentes,
            spt_DEL_EliminaPlazasAntecedentes,
            spt_SEL_PlazasAntecedentesPorID
        }
    }
}
