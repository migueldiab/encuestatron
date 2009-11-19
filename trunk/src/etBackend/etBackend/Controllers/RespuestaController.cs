using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace etBackend.Controllers
{
    public class RespuestaController : Controller
    {
        //
        // GET: /Respuesta/

        public ActionResult Index()
        {
            var db = new db();
            var respuestas = db.respuestas;
            return View(respuestas);
        }

        //
        // GET: /Respuesta/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Respuesta/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Respuesta/Create

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
        // GET: /Respuesta/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Respuesta/Edit/5

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
