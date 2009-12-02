using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using etWeb.et;

namespace etWeb.Controllers
{
    public class RolController : Controller
    {
        //
        // GET: /Rol/

        public ActionResult Index()
        {
          Fachada etFachada = new Fachada();
          IList<rol> roles = etFachada.listaRoles();
          return View(roles);
        }

        //
        // GET: /Rol/Details/5

        public ActionResult Details(int id)
        {
          Fachada etFachada = new Fachada();
          rol unRol = etFachada.rolPorId(id);
          return View(unRol);
        }

        //
        // GET: /Rol/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Rol/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(rol unRol)
        {
          if (ModelState.IsValid)
          {
            Fachada etFachada = new Fachada();
            if (etFachada.insertarRol(unRol))
            {
              return RedirectToAction("Index");
            }
            else
            {
              ViewData["error"] = "Error al grabar";
              return View(unRol);
            }
          }
          else
          {
            ViewData["error"] = "Error al validar modelo";
            return View(unRol);
          }
        }

        //
        // GET: /Rol/Edit/5
 
        public ActionResult Edit(int id)
        {
          Fachada etFachada = new Fachada();
          rol unRol = etFachada.rolPorId(id);
          return View(unRol);
        }

        //
        // POST: /Rol/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, rol unRol)
        {
          if (ModelState.IsValid)
          {
            Fachada etFachada = new Fachada();
            if (etFachada.actualizarRol(id, unRol))
            {
              return RedirectToAction("Index");
            }
            else
            {
              ViewData["error"] = "Error al grabar";
              return View(unRol);
            }
          }
          else
          {
            ViewData["error"] = "Error al validar modelo";
            return View(unRol);
          }
        }
    }
}
