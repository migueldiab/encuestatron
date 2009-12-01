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
using encuestaTron.Models;

namespace encuestaTron.DTO
{
    public class Usuario
    {

        internal static bool validarUsuario(string usuario, string password)
        {
          return true;
        }

        internal static string obtenerPermisosPorUsuario(string usuario)
        {
          if (usuario == "agente")
          {
            return "agente";
          }
          if (usuario == "admin")
          {
            return "admin";
          }          
          else
          {
            return "invitado";
          }

        }
    }
}
