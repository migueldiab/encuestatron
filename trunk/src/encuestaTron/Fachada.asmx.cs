using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using DataTypesObjects;
using System.Xml.Serialization;

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
    
    [WebMethod]
    public bool obtenerPermisosPorUsuario(String usuario)
    {
      return Usuario.obtenerPermisosPorUsuario(usuario);
    }
    
   /* [XmlInclude(typeof(Usuario))]        
    [WebMethod]
    public bool validarUsuario(String usuario, String password)
    {
      ResultadoWs retorno = new ResultadoWs();
      Usuario user= new Usuario();
      try
      {
         user = Usuario.Login(usuario, password);
         retorno.Resultado.Add(user);          
      }
      catch (Exception e)
      {
        retorno.Error = e.Message;
      }      
      return retorno;
    }
    */


  //  [XmlInclude(typeof(Usuario))]
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
  }
}
