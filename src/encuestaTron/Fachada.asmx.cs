using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using encuestaTron.DTO;

namespace encuestaTron
{
  /// <summary>
  /// Summary description for Service1
  /// </summary>
  [WebService(Namespace = "http://tempuri.org/")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [ToolboxItem(false)]
  // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
  // [System.Web.Script.Services.ScriptService]
  public class Fachada : System.Web.Services.WebService
  {
  
    //  [XmlInclude(typeof(Usuario))]
    /*
    [WebMethod]
    public LoginResult UsuarioLogin(String usuario, String password)
    {
        LoginResult retorno = new LoginResult();
        Usuario user = new Usuario();
        try
        {
            user = Usuario.Login(usuario, password);
            retorno.IdUsuario = user.Cedula;
            retorno.NombreCompleto = user.Nombre + " " + user.Apellido;
            retorno.Token = "qqwerty";
            retorno.Rol = (user.Roles[0].Id).ToString();
        }
        catch (Exception e)
        {
            retorno.Error = e.Message;
        }
        return retorno;
    }
    */
    [WebMethod]
    public bool validarUsuario(String usuario, String password)
    {
        return Usuario.validarUsuario(usuario, password);
    }
    [WebMethod]
    public string obtenerPermisosPorUsuario(String usuario)
    {
      return Usuario.obtenerPermisosPorUsuario(usuario);
    }

    [WebMethod]
    public string listaEncuestas()
    {
      return Encuesta.listaEncuestas();
    }

    [WebMethod]
    public string encuestaPorId(string id)
    {
      return Encuesta.encuestaPorId(id);
    }

    [WebMethod]
    public bool insertarEncuesta(string xmlEncuesta)
    {
        return Encuesta.insertarEncuesta(xmlEncuesta);
      }      
  }
}
