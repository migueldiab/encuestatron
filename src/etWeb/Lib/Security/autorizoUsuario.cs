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
using System.Web.Mvc;

namespace etWeb.Lib.Security
{
  public class autorizoUsuario : AuthorizeAttribute
  {
    public string requiereRol;

    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
      //Verifica Contexto HTTP Válido
      if (httpContext == null)
        throw new ArgumentNullException("httpContext");

      // Si el usuario no está autenticado, retorna Falso
      if (!httpContext.User.Identity.IsAuthenticated)
        return false;

      //bool isAuth = httpContext.User.IsInRole(this.rolesUsuario);
      // El IsInRole no me funciona :|

      // Ticket establecido mediante FormsAuthenticationTicket en AccountController
      FormsIdentity usrFrmId = (FormsIdentity)httpContext.User.Identity;
      string ticketRolesUsuario = usrFrmId.Ticket.UserData;
      if (ticketRolesUsuario.Contains(this.requiereRol))
        return true;

      /*
       * string cookieRolesUsuario = (string)httpContext.Session["role"];
       * if (cookieRolesUsuario.Contains(this.requiereRol))
       * return true;
       * 
       * De usar Cookies de Sesión en lugar de tickets, 
       * este sería el código para habilitar el acceso
       * 
       */

      // Si no autentica con Cookies ni con Tickets, niega acceso.
      return false;
    }
  }

  [Serializable]
  [Flags]
  public enum listaPermisos
  {
    Admin = 1 << 0,
    Agente = 1 << 1,
    Cliente = 1 << 2
  }
}
