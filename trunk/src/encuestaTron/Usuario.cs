using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace encuestaTron
{
    public class Usuario
    {

        internal static string Login(string usuario, string password)
        {
            return "Logueado";
        }

        internal static bool validarUsuario(string usuario, string password)
        {
          return true;
        }
    }
}
