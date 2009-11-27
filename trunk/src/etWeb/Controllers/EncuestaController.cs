using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using etWeb.Models;

namespace etWeb.Controllers
{
    public class EncuestaController : Controller
    {
        //
        // GET: /Encuesta/

        public ActionResult Index()
        {
          var dbModel = new dbModel();
          var encuestas = dbModel.encuestas;
          return View(encuestas);
        }

        //
        // GET: /Encuesta/Details/5

        public ActionResult Details(string id)
        {
            var dbModel = new dbModel();
            var unaEncuesta = dbModel.encuestas.SingleOrDefault(x => x.nombre == id);
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
            try
            {
              var dbModel = new dbModel();
              dbModel.encuestas.InsertOnSubmit(unaEncuesta);
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
