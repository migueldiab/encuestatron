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
  public partial class EncuestaController
  {

    /*
     *  Detalles de Encuesta (con Resultados)
     */
    [autorizoUsuario(requiereRol = "agente,admin,cliente")]
    public ActionResult Details(string id)
    {
      Fachada etFachada = new Fachada();
      encuesta unaEncuesta = etFachada.encuestaPorId(id).ListaEncuestas.First();
      return View(unaEncuesta);
    }

  }
}
