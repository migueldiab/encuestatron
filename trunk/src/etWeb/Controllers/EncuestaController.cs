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
