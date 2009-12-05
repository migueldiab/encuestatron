using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Runtime.Serialization;
using etWeb.Lib;
using etWeb.Lib.Security;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using etWeb.et;
using System.Web.Security;
using System.Web.Routing;

namespace etWeb.Controllers
{
  public partial class EncuestaController : Controller
  {
    /*
     *  Encuestas Acciones y Listados
     */
    [autorizoUsuario(requiereRol = "admin,agente, cliente")]
    public ActionResult Index()
    {
      usuario usuarioActual = autorizoUsuario.usuarioActual();
      Fachada etFachada = new Fachada();
      List<encuesta> encuestas = null;
      if (autorizoUsuario.esAgente())
        encuestas = etFachada.listaEncuestasPorIdAgente(usuarioActual.id_usuario).ToList();
      else if (autorizoUsuario.esCliente())
        encuestas = etFachada.listaEncuestasPorIdCliente(usuarioActual.id_usuario).ToList();
      else
        encuestas = etFachada.listaEncuestas().ListaEncuestas.ToList();
      ViewData["id_encuesta"] = new SelectList(encuestas, "nombre", "nombre");
      return View(encuestas);
    }
    [autorizoUsuario(requiereRol = "admin,agente, cliente")]
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Index(string id_encuesta)
    {
      return RedirectToAction("Details", "Encuesta", new RouteValueDictionary(
          new { id = id_encuesta }));
    }

    /*
     *  Editar Encuesta
     */
    [autorizoUsuario(requiereRol = "agente")]
    public ActionResult Edit(string id)
    {
      Fachada etFachada = new Fachada();
      encuesta unaEncuesta = etFachada.encuestaPorId(id).ListaEncuestas.First();
      usuario usuarioActual = autorizoUsuario.usuarioActual();
      ViewData["id_cliente"] = new SelectList(etFachada.listaClientePorAgente(usuarioActual.id_usuario), "id_usuario", "nombre");
      return View(unaEncuesta);
    }
    [autorizoUsuario(requiereRol = "agente")]
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Edit(string id, encuesta unaEncuesta)
    {
      Fachada etFachada = new Fachada();
      if (ModelState.IsValid)
      {
        if (etFachada.actualizarEncuesta(id, unaEncuesta))
        {
          return RedirectToAction("Index");
        }
        else
        {
          ViewData["error"] = "Error al grabar";
          return View(unaEncuesta);
        }
      }
      else
      {
        ViewData["error"] = "Error al validar modelo";
        return View(unaEncuesta);
      }
    }
    /*
     * Borrar Generico
     */
    [autorizoUsuario(requiereRol = "agente")]
    public ActionResult Borrar(string id)
    {
      Fachada etFachada = new Fachada();
      if (etFachada.borrarEncuestaPorId(id))
      {
        return View();
      }
      else
      {
        ViewData["error"] = "Error al borrar";
        return RedirectToAction("Details", "Encuesta", new RouteValueDictionary(
          new { id = id }));
      }
    }

    
  }
}
