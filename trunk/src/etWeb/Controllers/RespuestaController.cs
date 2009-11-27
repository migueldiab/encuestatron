using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using etWeb.Models;


namespace etWeb.Controllers
{
    public class RespuestaController : Controller
    {
        //
        // GET: /Respuesta/

        public ActionResult Index()
        {
          var dbModel = new dbModel();
          var respuestas = dbModel.respuestas;
          return View(respuestas);
        }

        //
        // GET: /Respuesta/Details/5

        public ActionResult Details(int id)
        {
          var dbModel = new dbModel();
          var unaRespuesta = dbModel.respuestas.SingleOrDefault(x => x.id == id);
          return View(unaRespuesta);
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
        public ActionResult Create(respuesta unaRespuesta)
        {
          if (ModelState.IsValid)
          {
            try
            {
              var dbModel = new dbModel();
              dbModel.respuestas.InsertOnSubmit(unaRespuesta);
              dbModel.SubmitChanges();
              return RedirectToAction("Index");
            }
            catch
            {
              ViewData["error"] = "Error al grabar";
              return View(unaRespuesta);
            }
          }
          else
          {
            ViewData["error"] = "Error al validar modelo";
            return View(unaRespuesta);
          }
        }

        //
        // GET: /Respuesta/Edit/5
 
        public ActionResult Edit(int id)
        {
          var dbModel = new dbModel();
          var unaRespuesta = dbModel.respuestas.SingleOrDefault(x => x.id == id);
          return View(unaRespuesta);
        }

        //
        // POST: /Respuesta/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
          var dbModel = new dbModel();
          var unaRespuesta = dbModel.respuestas.SingleOrDefault(x => x.id == id);
          if (ModelState.IsValid)
          {
            try
            {
              UpdateModel(unaRespuesta, collection.ToValueProvider());
              dbModel.SubmitChanges();
              return RedirectToAction("Index");
            }
            catch
            {
              ViewData["error"] = "Error al grabar";
              return View(unaRespuesta);
            }
          }
          else
          {
            ViewData["error"] = "Error al validar modelo";
            return View(unaRespuesta);
          }
        }
    }
}
