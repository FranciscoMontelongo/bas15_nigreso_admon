using System.Data;

namespace Negocio
{
    public class Ent_Usuario
    {
        /*LOGIN*/
        public string Id_Usuario { get; set; }
        public string Usuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Usuario_ClaveEntidad { get; set; }
        public string Usuario_Entidad { get; set; }
        public string Usuario_CURP { get; set; }
        public string Sistema { get; set; }
        public string Perfil { get; set; }
        public string Concurso { get; set; }
        /*Tablero*/


        /*Asignacion*/
        public string CURP { get; set; }

        /*Antecedentes*/

        public string editar { get; set; }
        public string ID_Antecedente { get; set; }
        public string EstatusActual { get; set; }

        /*Reportes*/
        public string Funcion { get; set; }
        public string TipoEvaluacion { get; set; }
        public string Servicio { get; set; }
        public string ClaveNivelEducativo { get; set; }
        public string ClaveNivelEducativoServico { get; set; }
        public string TipoSostenimiento { get; set; }
        public int ClaveEstatusAsignacion { get; set; }
        public string ClaveEntidad { get; set; }


        public DataSet ds { get; set; }

        public int id_Resultados { get; set; }
        public string TipoPantalla { get; set; }    
    }
}
