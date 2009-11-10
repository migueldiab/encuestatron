using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using etBackend.Model;

namespace etBackend.Controllers
{
    public class EncuestaController : Controller
    {
        //
        // GET: /Encuesta/

        public ActionResult Index()
        {

            var db = new DB();
            var encuestas = db.Encuestas;

            return View(encuestas);
        }

        //
        // GET: /Encuesta/Details/5

        public ActionResult Details(string id)
        {
            var db = new DB();
            var encuesta = db.Encuestas.SingleOrDefault(x => x.nombre == id);


            return View(encuesta);
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
        public ActionResult Create(Encuesta unaEncuesta)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var db = new DB();
                    db.Encuestas.InsertOnSubmit(unaEncuesta);
                    db.SubmitChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(unaEncuesta);
                }
            }
            else
            {
                return View(unaEncuesta);
            }            
        }

        //
        // GET: /Encuesta/Edit/5
 
        public ActionResult Edit(string id)
        {
            var db = new DB();
            var encuesta = db.Encuestas.SingleOrDefault(x => x.nombre == id);

            
            return View(encuesta);
        }

        //
        // POST: /Encuesta/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var db = new DB();
            var encuesta = db.Encuestas.SingleOrDefault(x => x.nombre == id);

            try
            {
                // TODO: Add update logic here
                UpdateModel(encuesta, collection.ToValueProvider());
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(encuesta);
            }
        }
    }
}
