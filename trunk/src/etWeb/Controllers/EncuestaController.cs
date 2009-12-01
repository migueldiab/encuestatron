using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Runtime.Serialization;
using etWeb.et;
using etWeb.Models;
using etWeb.Lib;
using etWeb.Lib.Security;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

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
          string xmlEncuestas = etFachada.listaEncuestas();
          List<encuesta> encuestas = (List<encuesta>)Sistema.xmlToObj(xmlEncuestas, new List<encuesta>());          
          return View(encuestas);
        }

        //
        // GET: /Encuesta/Details/5

        public ActionResult Details(string id)
        {
          Fachada etFachada = new Fachada();
          string xmlEncuesta = etFachada.encuestaPorId(id);
          encuesta unaEncuesta = (encuesta)Sistema.xmlToObj(xmlEncuesta, new encuesta());
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
            string xmlEncuesta = Sistema.objToXml(unaEncuesta);
            Fachada etFachada = new Fachada();
            if (etFachada.insertarEncuesta(xmlEncuesta))
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
          var dbModel = new dbModel();
          var unaEncuesta = dbModel.encuestas.SingleOrDefault(x => x.nombre == id);
          return View(unaEncuesta);
        }

        //
        // POST: /Encuesta/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(string id, FormCollection collection)
        {
          var dbModel = new dbModel();
          var unaEncuesta = dbModel.encuestas.SingleOrDefault(x => x.nombre == id);
          if (ModelState.IsValid)
          {
            try
            {
              UpdateModel(unaEncuesta, collection.ToValueProvider());
              dbModel.SubmitChanges();
              return RedirectToAction("Index");
            }
            catch
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
