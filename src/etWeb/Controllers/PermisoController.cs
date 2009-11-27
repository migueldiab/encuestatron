using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using etWeb.Models;

namespace etWeb.Controllers
{
    public class PermisoController : Controller
    {
        //
        // GET: /Permiso/

        public ActionResult Index()
        {
          var dbModel = new dbModel();
          var permisos = dbModel.permisos;
          return View(permisos);
        }

        //
        // GET: /Permiso/Details/5

        public ActionResult Details(string id)
        {
          var dbModel = new dbModel();
          var unPermiso = dbModel.permisos.SingleOrDefault(x => x.nombre == id);
          return View(unPermiso);
        }

        //
        // GET: /Permiso/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Permiso/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(permiso unPermiso)
        {
          if (ModelState.IsValid)
          {
            try
            {
              var dbModel = new dbModel();
              dbModel.permisos.InsertOnSubmit(unPermiso);
              dbModel.SubmitChanges();
              return RedirectToAction("Index");
            }
            catch
            {
              ViewData["error"] = "Error al grabar";
              return View(unPermiso);
            }
          }
          else
          {
            ViewData["error"] = "Error al validar modelo";
            return View(unPermiso);
          }
        }

        //
        // GET: /Permiso/Edit/5
 
        public ActionResult Edit(int id)
        {
          var dbModel = new dbModel();
          var unPermiso = dbModel.permisos.SingleOrDefault(x => x.id == id);
          return View(unPermiso); 
        }

        //
        // POST: /Permiso/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
          var dbModel = new dbModel();
          var unPermiso = dbModel.permisos.SingleOrDefault(x => x.id == id);
          if (ModelState.IsValid)
          {
            try
            {
              UpdateModel(unPermiso, collection.ToValueProvider());
              dbModel.SubmitChanges();
              return RedirectToAction("Index");
            }
            catch
            {
              ViewData["error"] = "Error al grabar";
              return View(unPermiso);
            }
          }
          else
          {
            ViewData["error"] = "Error al validar modelo";
            return View(unPermiso);
          }
        }
    }
}
