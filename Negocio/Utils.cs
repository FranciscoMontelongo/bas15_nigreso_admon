using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.IO;

namespace WebNegocio
{
    public class Utils
    {
        public void Mensaje(System.Web.UI.Page pagina, string sMensaje)
        {
            if (!string.IsNullOrEmpty(sMensaje))
            {
                sMensaje = sMensaje.Replace("\r", "\\r").Replace("\n", "\\n");
                sMensaje = sMensaje.Replace("'", "\\'");
                ScriptManager.RegisterStartupScript(pagina, pagina.GetType(), "MensajePop", "alert('" + @sMensaje + "');", true);
            }
        }
        public bool ExisteFolderUpload(string sPathFull)
        {
            bool exists = System.IO.Directory.Exists(sPathFull);
            if (exists == false)
            {

                Directory.CreateDirectory(sPathFull);
                exists = System.IO.Directory.Exists(sPathFull);
            }
            return exists;
        }
    }
}

