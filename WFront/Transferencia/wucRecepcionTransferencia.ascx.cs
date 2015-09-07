using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFront.Transferencia
{
    public partial class wucRecepcionTransferencia : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //wucTransferenciaFiltro1.Buscar += new EventHandler<TransferenciaFiltroArgs>(wucTransferenciaFiltro1_Buscar);
            //wucRechazoTransferencia1.Rechazar += new EventHandler<TransferenciaRechazoArgs>(wucRechazoTransferencia1_Rechazar);
            //if (!IsPostBack)
            //{
            //    wucTransferenciaFiltro1.ForceBuscar();
            //}
        }

        //protected void wucRechazoTransferencia1_Rechazar(object sender, TransferenciaRechazoArgs e)
        //{
        //    int pkTraspaso = e.pkTraspaso;
        //    int motivo = e.Motivo;
        //    Negocio.Transferencia transferencia = new Negocio.Transferencia();

        //    /* Realizamos el rechazo de la solicitud y regresamos el registro a su lista de prelación */
        //    Ent_Usuario _Ent_Usuario = new Ent_Usuario();
        //    _Ent_Usuario.pkTraspaso = pkTraspaso;
        //    _Ent_Usuario.id_MotivoRechazoTransferencia = motivo;

        //    transferencia.RechazarDocente(_Ent_Usuario);
        //    wucTransferenciaFiltro1.ForceBuscar();
        //}

        //protected void wucTransferenciaFiltro1_Buscar(object sender, TransferenciaFiltroArgs e)
        //{
        //    /* Realizamos la búsqueda solicitada */
        //    gvNotificacion_Pendientes.GridBind(GetData(e, enumEstatusTransferencia.Pendiente).ToList());
        //    gvNotificacion_Aceptados.GridBind(GetData(e, enumEstatusTransferencia.Aceptado).ToList());
        //    gvNotificacion_Rechazados.GridBind(GetData(e, enumEstatusTransferencia.Rechazado).ToList());
        //}

        //private IEnumerable<ClassBinder> GetData(TransferenciaFiltroArgs e, enumEstatusTransferencia Estatus)
        //{
        //    IEnumerable<ClassBinder> lCB = new List<ClassBinder>();
        //    Ent_Usuario _Ent_Usuario = new Ent_Usuario();
        //    Negocio.Transferencia transferencia = new Negocio.Transferencia();

        //    _Ent_Usuario.ClaveEntidad = e.ClaveEntidad;
        //    _Ent_Usuario.ClaveEstatusAsignacionTransferencia = Estatus.ToInt();

        //    try
        //    {
        //        DataTable dataSet = transferencia.Notificaciones(_Ent_Usuario).Tables[0];

        //        lCB = dataSet.AsEnumerable().Select(p => new ClassBinder
        //        {
        //            pkTraspaso = (int)p["pkTraspaso"],
        //            pkResultados_Origen = (int)p["pkResultados_Origen"],
        //            Nombre = p["Nombre"].ToString(),
        //            CURP = p["CURP"].ToString(),
        //            FolioFederal = p["FolioFederal"].ToString(),
        //            Entidad_Destino = p["Entidad_Destino"].ToString(),
        //            Tipo_Convocatoria_Destino = p["Tipo_Convocatoria_Destino"].ToString(),
        //            Tipo_Evaluacion_Destino = p["Tipo_Evaluacion_Destino"].ToString(),
        //            MotivoRechazo = p["MotivoRechazo"].ToString()
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        /* No hubo resultados */
        //    }
        //    return lCB;
        //}

        //protected void lnkbAceptar_Click(object sender, EventArgs e)
        //{
        //    var lnk = (LinkButton)sender;
        //    int pkTraspaso = int.Parse(lnk.CommandArgument);
        //    Negocio.Transferencia transferencia = new Negocio.Transferencia();

        //    /* Realizamos la transferencia */
        //    Ent_Usuario _Ent_Usuario = new Ent_Usuario();
        //    _Ent_Usuario.pkTraspaso = pkTraspaso;

        //    transferencia.TransferirDocente(_Ent_Usuario);
        //    wucTransferenciaFiltro1.ForceBuscar();
        //}

        //protected void lnkbRechazar_Click(object sender, EventArgs e)
        //{
        //    var lnk = (LinkButton)sender;
        //    int pkTraspaso = int.Parse(lnk.CommandArgument);

        //    wucRechazoTransferencia1.Mostrar(pkTraspaso);
        //}

        //private class ClassBinder
        //{
        //    public int pkTraspaso { get; set; }
        //    public int pkResultados_Origen { get; set; }
        //    public string Nombre { get; set; }
        //    public string CURP { get; set; }
        //    public string FolioFederal { get; set; }
        //    public string Entidad_Destino { get; set; }
        //    public string Tipo_Convocatoria_Destino { get; set; }
        //    public string Tipo_Evaluacion_Destino { get; set; }
        //    public string MotivoRechazo { get; set; }
        //}
    }
}


