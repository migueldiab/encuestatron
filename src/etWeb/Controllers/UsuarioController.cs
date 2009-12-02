using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using etWeb.et;
using etWeb.Lib;

namespace etWeb.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        public ActionResult Index()
        {
          Fachada etFachada = new Fachada();
          IList<usuario> usuarios = etFachada.listaUsuarios();
          return View(usuarios);
        }

        //
        // GET: /Usuario/Details/5

        public ActionResult Details(string id)
        {
          Fachada etFachada = new Fachada();
          usuario unUsuario = etFachada.usuarioPorId(id);
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
            Fachada etFachada = new Fachada();
            if (etFachada.insertarUsuario(unUsuario))
            {
              return RedirectToAction("Index");
            }
            else
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
          Fachada etFachada = new Fachada();
          usuario unUsuario = etFachada.usuarioPorId(id);
          return View(unUsuario);
        }

        //
        // POST: /Usuario/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(string id, usuario unUsuario)
        {
          if (ModelState.IsValid)
          {
            Fachada etFachada = new Fachada();
            if (etFachada.actualizarUsuario(id, unUsuario))
            {
              return RedirectToAction("Index");
            }
            else
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
