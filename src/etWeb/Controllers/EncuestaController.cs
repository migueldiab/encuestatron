using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Runtime.Serialization;
using etWeb.Lib;
using etWeb.Lib.Security;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using etWeb.et;
using System.Web.Security;

namespace etWeb.Controllers
{
  public class EncuestaController : Controller
  {
    //
    // GET: /Encuesta/
    [autorizoUsuario(requiereRol = "admin,agente, cliente")]
    public ActionResult Index()
    {
      Fachada etFachada = new Fachada();
      IList<encuesta> encuestas = etFachada.listaEncuestas().ListaEncuestas;
      return View(encuestas);
    }

    [autorizoUsuario(requiereRol = "admin")]
    public ActionResult ListaPorAgente()
    {
      Fachada etFachada = new Fachada();
      ViewData["id_agente"] = new SelectList(etFachada.listaPorRol("agente"), "id_usuario", "nombre");
      return View();
    }

    [autorizoUsuario(requiereRol = "admin")]
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult ListaPorAgente(string id_agente)
    {
      Fachada etFachada = new Fachada();
      IList<encuesta> encuestas = null;
      ViewData["id_agente"] = new SelectList(etFachada.listaPorRol("agente"), "id_usuario", "nombre", id_agente);
      if (id_agente == "") {
        encuestas = etFachada.listaEncuestas().ListaEncuestas;
      }
      else {
        encuestas = etFachada.listaEncuestasPorIdAgente(id_agente);
      }
      return View(encuestas);
    }

    [autorizoUsuario(requiereRol = "admin, agente")]
    public ActionResult ListaPorCliente() 
    {
      usuario usuarioActual = autorizoUsuario.usuarioActual();
      Fachada etFachada = new Fachada();
      if (autorizoUsuario.esAgente())
      {
        ViewData["id_cliente"] = new SelectList(etFachada.listaClientePorAgente(usuarioActual.id_usuario), "id_usuario", "nombre");
      }
      else
      {
        ViewData["id_cliente"] = new SelectList(etFachada.listaPorRol("cliente"), "id_usuario", "nombre");
      }
      return View();
    }
    
    [autorizoUsuario(requiereRol = "admin, agente")]
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult ListaPorCliente(string id_cliente)
    {
      usuario usuarioActual = autorizoUsuario.usuarioActual();
      Fachada etFachada = new Fachada();
      IList<encuesta> encuestas = null;
      if (autorizoUsuario.esAgente())
      {
        ViewData["id_cliente"] = new SelectList(etFachada.listaClientePorAgente(usuarioActual.id_usuario), "id_usuario", "nombre", id_cliente);
      }
      else
      {
        ViewData["id_cliente"] = new SelectList(etFachada.listaPorRol("cliente"), "id_usuario", "nombre", id_cliente);
      }
      if (id_cliente == "")
      {
        if (autorizoUsuario.esAgente())
        {
          encuestas = etFachada.listaEncuestasPorIdAgente(usuarioActual.id_usuario);
        }
        else
        {
          encuestas = etFachada.listaEncuestas().ListaEncuestas;
        }
      }
      else
      {
        encuestas = etFachada.listaEncuestasPorIdCliente(id_cliente);
      }
      return View(encuestas);
    }


    [autorizoUsuario(requiereRol = "admin, agente, cliente")]
    public ActionResult ListaPorFechaIngreso()
    {
      return View();
    }

    [autorizoUsuario(requiereRol = "admin, agente, cliente")]
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult ListaPorFechaIngreso(DateTime fechaInicial, DateTime fechaFinal)
    {
      usuario usuarioActual = autorizoUsuario.usuarioActual();
      Fachada etFachada = new Fachada();
      List<encuesta> encuestas = null;
      if (autorizoUsuario.esAgente())
        encuestas = etFachada.listaEncuestasPorFechaIngreso(fechaInicial, fechaFinal, usuarioActual.id_usuario, null).ToList();
      else if (autorizoUsuario.esCliente())
        encuestas = etFachada.listaEncuestasPorFechaIngreso(fechaInicial, fechaFinal, null, usuarioActual.id_usuario).ToList();
      else
        encuestas = etFachada.listaEncuestasPorFechaIngreso(fechaInicial, fechaFinal, null, null).ToList();
      return View(encuestas);
    }


    [autorizoUsuario(requiereRol = "admin, agente, cliente")]
    public ActionResult ListaPorFechaVigencia()
    {
      return View();
    }

    [autorizoUsuario(requiereRol = "admin, agente, cliente")]
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult ListaPorFechaVigencia(DateTime fechaInicial, DateTime fechaFinal)
    {
      usuario usuarioActual = autorizoUsuario.usuarioActual();
      Fachada etFachada = new Fachada();
      List<encuesta> encuestas = null;
      if (autorizoUsuario.esAgente())
        encuestas = etFachada.listaEncuestasPorFechaVigencia(fechaInicial, fechaFinal, usuarioActual.id_usuario, null).ToList();
      else if (autorizoUsuario.esCliente())
        encuestas = etFachada.listaEncuestasPorFechaVigencia(fechaInicial, fechaFinal, null, usuarioActual.id_usuario).ToList();
      else
        encuestas = etFachada.listaEncuestasPorFechaVigencia(fechaInicial, fechaFinal, null, null).ToList();
      return View(encuestas);
    }

    [autorizoUsuario(requiereRol = "admin, agente, cliente")]
    public ActionResult ListaPorFechaCierre()
    {
      return View();
    }

    [autorizoUsuario(requiereRol = "admin, agente, cliente")]
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult ListaPorFechaCierre(DateTime fechaInicial, DateTime fechaFinal)
    {
      usuario usuarioActual = autorizoUsuario.usuarioActual();
      Fachada etFachada = new Fachada();
      List<encuesta> encuestas = null;
      if (autorizoUsuario.esAgente())
        encuestas = etFachada.listaEncuestasPorFechaCierre(fechaInicial, fechaFinal, usuarioActual.id_usuario, null).ToList();
      else if (autorizoUsuario.esCliente())
        encuestas = etFachada.listaEncuestasPorFechaCierre(fechaInicial, fechaFinal, null, usuarioActual.id_usuario).ToList();
      else
        encuestas = etFachada.listaEncuestasPorFechaCierre(fechaInicial, fechaFinal, null, null).ToList();
      return View(encuestas);
    }
    
    //
    // GET: /Encuesta/Details/5
    [autorizoUsuario(requiereRol = "agente,admin,cliente")]
    public ActionResult Details(string id)
    {
      Fachada etFachada = new Fachada();
      encuesta unaEncuesta = etFachada.encuestaPorId(id).ListaEncuestas.First();
      return View(unaEncuesta);
    }

    //
    // GET: /Encuesta/Create

    [autorizoUsuario(requiereRol = "agente")]
    public ActionResult Create()
    {
        return View();
    } 

    //
    // POST: /Encuesta/Create
    [autorizoUsuario(requiereRol = "agente")]
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Create(encuesta unaEncuesta)
    {
      if (ModelState.IsValid)
      {
        Fachada etFachada = new Fachada();
        if (etFachada.insertarEncuesta(unaEncuesta))
        {
          return RedirectToAction("Index");
        }
        else
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
    [autorizoUsuario(requiereRol = "agente")]
    public ActionResult Edit(string id)
    {
      Fachada etFachada = new Fachada();
      encuesta unaEncuesta = etFachada.encuestaPorId(id).ListaEncuestas.First();
      return View(unaEncuesta);
    }

    //
    // POST: /Encuesta/Edit/5
    [autorizoUsuario(requiereRol = "agente")]
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Edit(string id, encuesta unaEncuesta)
    {
      Fachada etFachada = new Fachada();
      if (ModelState.IsValid)
      {
        if (etFachada.actualizarEncuesta(id, unaEncuesta))
        {
          return RedirectToAction("Index");
        }
        else
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
  }
}
