using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using etWeb.Models;
using etWeb.Lib.Security;

namespace etWeb.Controllers
{
    public class PreguntaController : Controller
    {
        //
        // GET: /Pregunta/

      [autorizoUsuario(requiereRol = "admin")]
        public ActionResult Index()
        {
          var dbModel = new dbModel();
          var preguntas = dbModel.preguntas;
          return View(preguntas);
        }

        //
        // GET: /Pregunta/Details/5

        public ActionResult Details(int id)
        {
          var dbModel = new dbModel();
          var unaPregunta = dbModel.preguntas.SingleOrDefault(x => x.id == id);
          return View(unaPregunta);
        }

        //
        // GET: /Pregunta/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Pregunta/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(pregunta unaPregunta)
        {
          if (ModelState.IsValid)
          {
            try
            {
              var dbModel = new dbModel();
              dbModel.preguntas.InsertOnSubmit(unaPregunta);
              dbModel.SubmitChanges();
              return RedirectToAction("Index");
            }
            catch
            {
              ViewData["error"] = "Error al grabar";
              return View(unaPregunta);
            }
          }
          else
          {
            ViewData["error"] = "Error al validar modelo";
            return View(unaPregunta);
          }
        }

        //
        // GET: /Pregunta/Edit/5
 
        public ActionResult Edit(int id)
        {
          var dbModel = new dbModel();
          var unaPregunta = dbModel.preguntas.SingleOrDefault(x => x.id == id);
          return View(unaPregunta);
        }

        //
        // POST: /Pregunta/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
          var dbModel = new dbModel();
          var unaPregunta = dbModel.preguntas.SingleOrDefault(x => x.id == id);
          if (ModelState.IsValid)
          {
            try
            {
              UpdateModel(unaPregunta, collection.ToValueProvider());
              dbModel.SubmitChanges();
              return RedirectToAction("Index");
            }
            catch
            {
              ViewData["error"] = "Error al grabar";
              return View(unaPregunta);
            }
          }
          else
          {
            ViewData["error"] = "Error al validar modelo";
            return View(unaPregunta);
          }
        }
    }
}
