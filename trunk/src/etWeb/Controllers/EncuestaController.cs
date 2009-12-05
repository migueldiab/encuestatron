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
      return View();
    }

    /*
     *  Detalles de Encuesta
     */
    [autorizoUsuario(requiereRol = "agente,admin,cliente")]
    public ActionResult Details(string id)
    {
      Fachada etFachada = new Fachada();
      encuesta unaEncuesta = etFachada.encuestaPorId(id).ListaEncuestas.First();
      return View(unaEncuesta);
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
  }
}
