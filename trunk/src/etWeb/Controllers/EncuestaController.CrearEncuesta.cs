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
using System.Web.Routing;

namespace etWeb.Controllers
{
  public partial class EncuestaController
  {
    /*
     *  Crear Nueva Encuesta
     */
    [autorizoUsuario(requiereRol = "agente")]
    public ActionResult Create()
    {
      Fachada etFachada = new Fachada();
      usuario usuarioActual = autorizoUsuario.usuarioActual();
      var listaClientes = etFachada.listaClientePorAgente(usuarioActual.id_usuario);
      ViewData["id_cliente"] = new SelectList(listaClientes, "id_usuario", "nombre");
      return View();
    }
    [autorizoUsuario(requiereRol = "agente")]
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Create(encuesta unaEncuesta)
    {
      Fachada etFachada = new Fachada();
      usuario usuarioActual = autorizoUsuario.usuarioActual();
      var listaClientes = etFachada.listaClientePorAgente(usuarioActual.id_usuario);
      ViewData["id_cliente"] = new SelectList(listaClientes, "id_usuario", "nombre");
      if (ModelState.IsValid)
      {
        if (etFachada.insertarEncuesta(unaEncuesta))
        {
          return RedirectToAction("PreguntasEncuesta", "Encuesta", new RouteValueDictionary(
            new { nombreEncuesta = unaEncuesta.nombre }));
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

    /*
     * Agregar Preguntas a Encuesta
     */
    [autorizoUsuario(requiereRol = "agente")]
    public ActionResult PreguntasEncuesta(string nombreEncuesta)
    {
      Fachada etFachada = new Fachada();
      encuesta unaEncuesta = etFachada.encuestaPorId(nombreEncuesta).ListaEncuestas.First();
      ViewData["unaEncuesta"] = unaEncuesta;
      List<pregunta> listaPreguntas = etFachada.preguntasPorEncuesta(unaEncuesta).ToList();
      ViewData["listaPreguntas"] = listaPreguntas;
      pregunta unaPregunta = new pregunta();
      return View(unaPregunta);
    }
    [autorizoUsuario(requiereRol = "agente")]
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult PreguntasEncuesta(pregunta unaPregunta, string id_encuesta)
    {
      Fachada etFachada = new Fachada();
      encuesta unaEncuesta = etFachada.encuestaPorId(id_encuesta).ListaEncuestas.First();
      ViewData["unaEncuesta"] = unaEncuesta;
      int idPregunta = etFachada.insertarPregunta(unaPregunta, unaEncuesta);
      if (esIdValido(idPregunta))
      {
        return RedirectToAction("RespuestasPregunta", "Encuesta", new RouteValueDictionary(
          new { idPregunta = idPregunta }));
      }
      else
      {
        ViewData["error"] = "Error al grabar";
        return View(unaPregunta);
      }
    }
    private bool esIdValido(int idPregunta) { return idPregunta != -1; }

    /*
     * Agregar Respuestas a Preguntas
     */
    [autorizoUsuario(requiereRol = "agente")]
    public ActionResult RespuestasPregunta(string idPregunta)
    {
      Fachada etFachada = new Fachada();
      pregunta unaPregunta = null;
      try
      {
        unaPregunta = etFachada.preguntaPorId(Int32.Parse(idPregunta));
      }
      catch (Exception e)
      {
        /*
         *  TODO Redirige pero no muestra mensaje de error...
         */
        Console.WriteLine(e.ToString());
        ViewData["error"] = "Error al cargar pregunta";
        return RedirectToAction("Create", "Encuesta");
      }
      ViewData["unaPregunta"] = unaPregunta;
      List<respuesta> listaRespuestas = etFachada.respuestasPorPregunta(unaPregunta).ToList();
      if (listaRespuestas.Count()>0)
        ViewData["listaRespuestas"] = listaRespuestas;
      respuesta unaRespuesta = new respuesta();
      return View(unaRespuesta);
    }
    [autorizoUsuario(requiereRol = "agente")]
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult RespuestasPregunta(respuesta unaRespuesta, string btnSubmit)
    {
      Fachada etFachada = new Fachada();
      pregunta unaPregunta = etFachada.preguntaPorId(unaRespuesta.id_pregunta);
      ViewData["unaPregunta"] = unaPregunta;
      List<respuesta> listaRespuestas = etFachada.respuestasPorPregunta(unaPregunta).ToList();
      ViewData["listaRespuestas"] = listaRespuestas;
      int idRespuesta = etFachada.insertarRespuesta(unaRespuesta, unaPregunta);
      if (esIdValido(idRespuesta))
      {
        return RedirectToAction("RespuestasPregunta", "Encuesta", new RouteValueDictionary(
          new { idPregunta = unaPregunta.id }));
      }
      else
      {
        ViewData["error"] = "Error al grabar";
        return View(unaRespuesta);
      }
    }


    /*
     *  Editar Encuesta
     */
    [autorizoUsuario(requiereRol = "agente")]
    public ActionResult Edit(string id)
    {
      Fachada etFachada = new Fachada();
      encuesta unaEncuesta = etFachada.encuestaPorId(id).ListaEncuestas.First();
      usuario usuarioActual = autorizoUsuario.usuarioActual();
      var listaClientes = etFachada.listaClientePorAgente(usuarioActual.id_usuario);
      ViewData["id_cliente"] = new SelectList(listaClientes, "id_usuario", "nombre", unaEncuesta.id_cliente);
      return View(unaEncuesta);
    }
    [autorizoUsuario(requiereRol = "agente")]
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Edit(string id, encuesta unaEncuesta)
    {
      Fachada etFachada = new Fachada();
      //encuesta unaEncuesta = etFachada.encuestaPorId(id).ListaEncuestas.First();
      usuario usuarioActual = autorizoUsuario.usuarioActual();
      var listaClientes = etFachada.listaClientePorAgente(usuarioActual.id_usuario);
      ViewData["id_cliente"] = new SelectList(listaClientes, "id_usuario", "nombre", unaEncuesta.id_cliente);
      if (ModelState.IsValid)
      {
        if (etFachada.actualizarEncuesta(id, unaEncuesta))
        {
          return RedirectToAction("PreguntasEncuesta", "Encuesta", new RouteValueDictionary(
            new { nombreEncuesta = unaEncuesta.nombre }));
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

    /*
     *  Editar Pregunta
     */
    [autorizoUsuario(requiereRol = "agente")]
    public ActionResult EditarPregunta(int id)
    {
      Fachada etFachada = new Fachada();
      pregunta unaPregunta = etFachada.preguntaPorId(id);
      return RedirectToAction("RespuestasPregunta", "Encuesta", new RouteValueDictionary(
  new { idPregunta = id }));
    }

    /*
     * Borrar Generico
     */
    [autorizoUsuario(requiereRol = "agente")]
    public ActionResult Borrar(string id)
    {
      Fachada etFachada = new Fachada();
      if (etFachada.borrarEncuestaPorId(id))
      {
        return View();
      }
      else
      {
        ViewData["error"] = "Error al borrar";
        return RedirectToAction("Details", "Encuesta", new RouteValueDictionary(
          new { id = id }));
      }
    }

    /*
     * Borrar Pregunta
     */
    [autorizoUsuario(requiereRol = "agente")]
    public ActionResult BorrarPregunta(int id, string encuesta)
    {
      Fachada etFachada = new Fachada();
      if (etFachada.borrarPreguntaPorId(id))
      {
        return RedirectToAction("PreguntasEncuesta", "Encuesta", new RouteValueDictionary(
          new { nombreEncuesta = encuesta }));
      }
      else
      {
        ViewData["error"] = "Error al borrar";
        return RedirectToAction("PreguntasEncuesta", "Encuesta", new RouteValueDictionary(
          new { nombreEncuesta = encuesta }));
      }
    }

    /*
     * Borrar Respuesta
     */
    [autorizoUsuario(requiereRol = "agente")]
    public ActionResult BorrarRespuesta(int id, int pregunta)
    {
      Fachada etFachada = new Fachada();
      if (etFachada.borrarRespuestaPorId(id))
      {
        return RedirectToAction("RespuestasPregunta", "Encuesta", new RouteValueDictionary(
          new { idPregunta = pregunta }));
      }
      else
      {
        ViewData["error"] = "Error al borrar";
        return RedirectToAction("RespuestasPregunta", "Encuesta", new RouteValueDictionary(
          new { idPregunta = pregunta }));
      }
    }
  }
}
