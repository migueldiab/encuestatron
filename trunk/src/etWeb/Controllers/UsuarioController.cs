using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using etWeb.Models;

namespace etWeb.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        public ActionResult Index()
        {
          var dbModel = new dbModel();
          var usuarios = dbModel.usuarios;
          return View(usuarios);
        }

        //
        // GET: /Usuario/Details/5

        public ActionResult Details(string id)
        {
          var dbModel = new dbModel();
          var unUsuario = dbModel.usuarios.SingleOrDefault(x => x.nombre == id);
          return View(unUsuario);
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Usuario/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(usuario unUsuario)
        {
          if (ModelState.IsValid)
          {
            try
            {
              var dbModel = new dbModel();
              dbModel.usuarios.InsertOnSubmit(unUsuario);
              dbModel.SubmitChanges();
              return RedirectToAction("Index");
            }
            catch
            {
              ViewData["error"] = "Error al grabar";
              return View(unUsuario);
            }
          }
          else
          {
            ViewData["error"] = "Error al validar modelo";
            return View(unUsuario);
          }
        }

        //
        // GET: /Usuario/Edit/5

        public ActionResult Edit(string id)
        {
          var dbModel = new dbModel();
          var unUsuario = dbModel.usuarios.SingleOrDefault(x => x.nombre == id);
          return View(unUsuario);
        }

        //
        // POST: /Usuario/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(string id, FormCollection collection)
        {
          var dbModel = new dbModel();
          var unUsuario = dbModel.usuarios.SingleOrDefault(x => x.nombre == id);
          if (ModelState.IsValid)
          {
            try
            {
              UpdateModel(unUsuario, collection.ToValueProvider());
              dbModel.SubmitChanges();
              return RedirectToAction("Index");
            }
            catch
            {
              ViewData["error"] = "Error al grabar";
              return View(unUsuario);
            }
          }
          else
          {
            ViewData["error"] = "Error al validar modelo";
            return View(unUsuario);
          }
        }
    }
}
