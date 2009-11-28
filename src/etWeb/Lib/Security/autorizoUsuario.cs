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
    public string rolesUsuario;

    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
      if (httpContext == null)
        throw new ArgumentNullException("httpContext");

      string[] users = Users.Split(',');

      if (!httpContext.User.Identity.IsAuthenticated)
        return false;

      bool isAuth = httpContext.User.IsInRole(this.rolesUsuario);

      HttpContext currentContext = System.Web.HttpContext.Current;
      //FormsIdentity frmId = System.Web.Security.FormsIdentity;
      FormsIdentity usrFrmId = (FormsIdentity)httpContext.User.Identity;


      string otherRole = (string)currentContext.Session["role"];

      string role = (string)httpContext.Session["role"];


      if (role != this.rolesUsuario)
        return false;

      return true;
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
