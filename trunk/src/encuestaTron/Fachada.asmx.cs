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

#region Usuarios
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
    public List<usuario> listaUsuarios()
    {
      return Usuario.listaUsuarios(); 
    }
    [WebMethod]
    public List<usuario> listaPorRol(string rol)
    {
      return Usuario.listaPorRol(rol); 
    }
    [WebMethod]
    public List<usuario> listaClientePorAgente(string nombreAgente)
    {
      return Usuario.listaClientePorAgente(nombreAgente); 
    }    
    [WebMethod]
    public bool borrarUsuarioPorId(string id)
    {
      return Usuario.borrarUsuarioPorId(id);
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
    public bool insertarCliente(usuario unCliente, usuario unAgente)
    {
      return Usuario.insertarCliente(unCliente, unAgente);
    }
    [WebMethod]
    public bool actualizarUsuario(string id, usuario unUsuario)
    {
      return Usuario.actualizarUsuario(id, unUsuario);
    } 

#endregion

#region Encuestas
  [WebMethod]
  public ListaEncuestaResult listaEncuestas()
  {
      ListaEncuestaResult listaEncuestaResult = new ListaEncuestaResult();
      if (Encuesta.listaEncuestas().Count() > 0)
      {
          listaEncuestaResult.ListaEncuestas = Encuesta.listaEncuestas();
          listaEncuestaResult.Error = null;
      }
      else
      {
          listaEncuestaResult.Error = "No se encontraron encuestas";
      }
      
    return listaEncuestaResult;
  }
  [WebMethod]
  public bool borrarEncuestaPorId(string id)
  {
    return Encuesta.borrarEncuestaPorId(id);
  }


  [WebMethod]
  public ResultWs encuestaPorIdPassword(int id, String pass)
  {
    ClienteLogger.insertLog("encuestaPorIdPassword(int "+ id+", String "+ pass+")");
    ListaEncuestaResult listaEncuestaResult = new ListaEncuestaResult();
    encuesta unaEncuesta = Encuesta.encuestaPorId(id.ToString());
    if (unaEncuesta != null)
    {
      if (Encuesta.esAutenticada(unaEncuesta, pass))
      {
        listaEncuestaResult.ListaEncuestas.Add(unaEncuesta);
        listaEncuestaResult.Error = null;
      }
      else
      {
        listaEncuestaResult.Error = "No se valido la contraseña para la encuesta id: " + id;
      }
    }
    else
    {
      listaEncuestaResult.Error = "No se encontro encuesta con id: " + id;
    }

    return listaEncuestaResult;
  }

  [WebMethod]
  public ListaEncuestaResult encuestaPorId(string id)
  {
    ListaEncuestaResult listaEncuestaResult = new ListaEncuestaResult();
    encuesta unaEncuesta = Encuesta.encuestaPorId(id.ToString());
    if (unaEncuesta != null)
    {
      listaEncuestaResult.ListaEncuestas.Add(unaEncuesta);
      listaEncuestaResult.Error = null;
    }
    else
    {
      listaEncuestaResult.Error = "No se encontro encuesta con id: " + id;
    }
    return listaEncuestaResult;
  }

  [WebMethod]
  public ResultWs getPregunta(int idEncuesta, string pass, respuesta respuesta)
  {
     return new ResultWs();
  }
  [WebMethod]
  public List<encuesta> listaEncuestasPorIdAgente(string idAgente)
  {
    return Encuesta.listaEncuestasPorIdAgente(idAgente);
  }
  [WebMethod]
  public List<encuesta> listaEncuestasPorIdCliente(string idCliente)
  {
    return Encuesta.listaEncuestasPorIdCliente(idCliente);
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
  public List<encuesta> listaEncuestasPorFechaIngreso(DateTime fechaInicial, DateTime fechaFinal, string idAgente, string idCliente)
  {
    return Encuesta.listaEncuestasPorFechaIngreso(fechaInicial, fechaFinal, idAgente, idCliente);
  }
  [WebMethod]
  public List<encuesta> listaEncuestasPorFechaVigencia(DateTime fechaInicial, DateTime fechaFinal, string idAgente, string idCliente)
  {
    return Encuesta.listaEncuestasPorFechaVigencia(fechaInicial, fechaFinal, idAgente, idCliente);
  }
  [WebMethod]
  public List<encuesta> listaEncuestasPorFechaCierre(DateTime fechaInicial, DateTime fechaFinal, string idAgente, string idCliente)
  {
    return Encuesta.listaEncuestasPorFechaCierre(fechaInicial, fechaFinal, idAgente, idCliente);
  }
  [WebMethod]
  public int insertarPregunta(pregunta unaPregunta, encuesta unaEncuesta)
  {
    return Encuesta.insertarPregunta(unaPregunta, unaEncuesta);
  }
  [WebMethod]
  public int insertarRespuesta(respuesta unaRespuesta, pregunta unaPregunta)
  {
    return Encuesta.insertarRespuesta(unaRespuesta, unaPregunta);
  }
  [WebMethod]
  public pregunta preguntaPorId(int idPregunta)
  {
    return Encuesta.preguntaPorId(idPregunta);
  }

  [WebMethod]
  public List<respuesta> respuestasPorPregunta(pregunta unaPregunta)
  {
    return Encuesta.respuestasPorPregunta(unaPregunta);
  }

  [WebMethod]
  public List<pregunta> preguntasPorEncuesta(encuesta unaEncuesta)
  {
    return Encuesta.preguntasPorEncuesta(unaEncuesta);
  } 
  [WebMethod]
  public bool borrarPreguntaPorId(int id)
  {
    return Encuesta.borrarPreguntaPorId(id);
  }    
   [WebMethod]
  public bool borrarRespuestaPorId(int id)
  {
    return Encuesta.borrarRespuestaPorId(id);
  }      
#endregion

#region Roles

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
    public rol rolPorNombre(string nombre)
    {
      return Rol.rolPorNombre(nombre);
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
#endregion
    
  }
}
