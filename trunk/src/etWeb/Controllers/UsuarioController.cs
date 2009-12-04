using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using etWeb.et;
using etWeb.Lib;
using System.Web.UI.WebControls;
using etWeb.Lib.Security;

namespace etWeb.Controllers
{
    public class UsuarioController : Controller
    {
      
      /*
       *  Usuarios Acciones y Listado
       */
      [autorizoUsuario(requiereRol = "admin")]
      public ActionResult Index()
      {
        Fachada etFachada = new Fachada();
        IList<usuario> usuarios = etFachada.listaUsuarios();
        ViewData["roles"] = etFachada.listaRoles();
        return View(usuarios);
      }


      /*
       *  Detalles Usuario
       */
      [autorizoUsuario(requiereRol = "admin")]
      public ActionResult Details(string id)
      {
        Fachada etFachada = new Fachada();
        usuario unUsuario = etFachada.usuarioPorId(id);
        return View(unUsuario);
      }

      /*
       *  Crear Generico
       */
      [autorizoUsuario(requiereRol = "admin")]
      public ActionResult Create()
      {
        Fachada etFachada = new Fachada();
        ViewData["id_rol"] = new SelectList(etFachada.listaRoles(), "id", "nombre");
        return View();
      } 
      [autorizoUsuario(requiereRol = "admin")]
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

      /*
       *  Crear Agente
       */
      [autorizoUsuario(requiereRol = "admin")]
      public ActionResult CrearAgente()
      {
        Fachada etFachada = new Fachada();
        return View();
      }
      [autorizoUsuario(requiereRol = "admin")]
      [AcceptVerbs(HttpVerbs.Post)]
      public ActionResult CrearAgente(usuario unUsuario)
      {
        if (ModelState.IsValid)
        {
          Fachada etFachada = new Fachada();
          rol rolAgente = etFachada.rolPorNombre("agente");
          unUsuario.id_rol = rolAgente.id;
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


      /*
       *  Crear Cliente
       */
      [autorizoUsuario(requiereRol = "admin")]
      public ActionResult CrearCliente()
      {
        Fachada etFachada = new Fachada();
        return View();
      }      
      [autorizoUsuario(requiereRol = "admin")]
      [AcceptVerbs(HttpVerbs.Post)]
      public ActionResult CrearCliente(usuario unUsuario, string idAgente)
      {
        if (ModelState.IsValid)
        {
          Fachada etFachada = new Fachada();
          rol rolCliente = etFachada.rolPorNombre("cliente");
          unUsuario.id_rol = rolCliente.id;
          usuario unAgente = etFachada.usuarioPorId(idAgente);
          if (etFachada.insertarCliente(unUsuario, unAgente))
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


      /*
       * Editar Generico
       */
      [autorizoUsuario(requiereRol = "admin")]
      public ActionResult Edit(string id)
      {

        Fachada etFachada = new Fachada();
        usuario unUsuario = etFachada.usuarioPorId(id);
        ViewData["id_rol"] = new SelectList(etFachada.listaRoles(), "id", "nombre",unUsuario.id_rol);
        return View(unUsuario);
      }
      [autorizoUsuario(requiereRol = "admin")]
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
      
      /*
       * Borrar Generico
       */
      [autorizoUsuario(requiereRol = "admin")]
      public ActionResult Borrar(string id)
      {
        Fachada etFachada = new Fachada();
        if (etFachada.borrarUsuarioPorId(id))
        {
          return View();
        }
        else
        {
          ViewData["error"] = "Error al borrar";
          return RedirectToAction("Edit", id);
        }
      }


    }
}
