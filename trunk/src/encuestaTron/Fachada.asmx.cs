using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Collections.Generic;
using encuestaTron.DTO;
using encuestaTron.Models;
using DataTypesObjects;

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
    public List<encuesta> listaEncuestas()
    {
      return Encuesta.listaEncuestas();
    }

    [WebMethod]
    public encuesta encuestaPorId(string id)
    {
      return Encuesta.encuestaPorId(id);
    }

    [WebMethod]
    public bool insertarEncuesta(encuesta unaEncuesta)
    {
      return Encuesta.insertarEncuesta(unaEncuesta);
    }      
    [WebMethod]
    public bool actualizarEncuesta(string id, encuesta unaEncuesta)
    {
      return Encuesta.actualizarEncuesta(id,unaEncuesta);
    }      

    [WebMethod]
    public List<rol> listaRoles()
    {
      return Rol.listaRoles();
    }    
    [WebMethod]
    public rol rolPorId(int id)
    {
      return Rol.rolPorId(id);
    }
    [WebMethod]
    public bool insertarRol(rol unRol)
    {
      return Rol.insertarRol(unRol);
    } 
    [WebMethod]
    public bool actualizarRol(int id, rol unRol)
    {
      return Rol.actualizarRol(id, unRol);
    }

    [WebMethod]
    public List<usuario> listaUsuarios()
    {
      return Usuario.listaUsuarios(); 
    }
    

    [WebMethod]
    public usuario usuarioPorId(string id)
    {
      return Usuario.usuarioPorId(id);
    }

    [WebMethod]
    public bool insertarUsuario(usuario unUsuario)
    {
      return Usuario.insertarUsuario(unUsuario);
    }

    [WebMethod]
    public bool actualizarUsuario(string id, usuario unUsuario)
    {
      return Usuario.actualizarUsuario(id, unUsuario);
    } 
  }
}
