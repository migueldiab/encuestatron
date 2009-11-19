using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace etBackend.Controllers
{
    public class EncuestaController : Controller
    {
        //
        // GET: /Encuesta/

        public ActionResult Index()
        {
            var db = new db();
            var encuestas = db.encuestas;
            return View(encuestas);
        }

        //
        // GET: /Encuesta/Details/5

        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Encuesta/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Encuesta/Edit/5

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
