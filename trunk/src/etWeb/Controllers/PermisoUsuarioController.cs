using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using etWeb.Models;

namespace etWeb.Controllers
{
    public class PermisoUsuarioController : Controller
    {
        //
        // GET: /PermisoUsuario/

        public ActionResult Index()
        {
          var dbModel = new dbModel();
          var permisoUsuarios = dbModel.permiso_usuarios;
          return View(permisoUsuarios);
        }

        //
        // GET: /PermisoUsuario/Details/5

        public ActionResult Details(int id)
        {
          var dbModel = new dbModel();
          var unPermisoUsuario = dbModel.permiso_usuarios.SingleOrDefault(x => x.id_permiso == id);
          return View(unPermisoUsuario);
        }

        //
        // GET: /PermisoUsuario/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /PermisoUsuario/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(permiso_usuario unPermisoUsuario)
        {
          if (ModelState.IsValid)
          {
            try
            {
              var dbModel = new dbModel();
              dbModel.permiso_usuarios.InsertOnSubmit(unPermisoUsuario);
              dbModel.SubmitChanges();
              return RedirectToAction("Index");
            }
            catch
            {
              ViewData["error"] = "Error al grabar";
              return View(unPermisoUsuario);
            }
          }
          else
          {
            ViewData["error"] = "Error al validar modelo";
            return View(unPermisoUsuario);
          }
        }

        //
        // GET: /PermisoUsuario/Edit/5
 
        public ActionResult Edit(int id)
        {
          var dbModel = new dbModel();
          var unPermisoUsuario = dbModel.permiso_usuarios.SingleOrDefault(x => x.id_permiso == id);
          return View(unPermisoUsuario);
        }

        //
        // POST: /PermisoUsuario/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
          var dbModel = new dbModel();
          var unPermisoUsuario = dbModel.permiso_usuarios.SingleOrDefault(x => x.id_permiso == id);
          if (ModelState.IsValid)
          {
            try
            {
              UpdateModel(unPermisoUsuario, collection.ToValueProvider());
              dbModel.SubmitChanges();
              return RedirectToAction("Index");
            }
            catch
            {
              ViewData["error"] = "Error al grabar";
              return View(unPermisoUsuario);
            }
          }
          else
          {
            ViewData["error"] = "Error al validar modelo";
            return View(unPermisoUsuario);
          }
        }
    }
}
