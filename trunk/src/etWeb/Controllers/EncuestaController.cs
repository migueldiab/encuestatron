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

namespace etWeb.Controllers
{
    public class EncuestaController : Controller
    {
        //
        // GET: /Encuesta/
        [autorizoUsuario(requiereRol = "agente")]
        public ActionResult Index()
        {
          Fachada etFachada = new Fachada();
          IList<encuesta> encuestas = etFachada.listaEncuestas();
          return View(encuestas);
        }

        //
        // GET: /Encuesta/Details/5

        public ActionResult Details(string id)
        {
          Fachada etFachada = new Fachada();
          encuesta unaEncuesta = etFachada.encuestaPorId(id);
          return View(unaEncuesta);
        }

        //
        // GET: /Encuesta/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Encuesta/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(encuesta unaEncuesta)
        {
          if (ModelState.IsValid)
          {
            Fachada etFachada = new Fachada();
            if (etFachada.insertarEncuesta(unaEncuesta))
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

        //
        // GET: /Encuesta/Edit/5
 
        public ActionResult Edit(string id)
        {
          Fachada etFachada = new Fachada();
          encuesta unaEncuesta = etFachada.encuestaPorId(id);
          return View(unaEncuesta);
        }

        //
        // POST: /Encuesta/Edit/5

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