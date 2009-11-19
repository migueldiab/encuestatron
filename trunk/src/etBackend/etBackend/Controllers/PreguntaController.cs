using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using etBackend.Model;

namespace etBackend.Controllers
{
    public class PreguntaController : Controller
    {
        //
        // GET: /Pregunta/

        public ActionResult Index()
        {
            var db = new db();
            var preguntas = db.preguntas;
            return View(preguntas);
        }

        //
        // GET: /Pregunta/Details/5

        public ActionResult Details(int id)
        {
            return View();
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
                    // TODO: Add insert logic here
                    var db = new db();
                    db.preguntas.InsertOnSubmit(unaPregunta);
                    db.SubmitChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(unaPregunta);
                }
            }
            else
            {
                return View(unaPregunta);
            }
        }

        //
        // GET: /Pregunta/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Pregunta/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
