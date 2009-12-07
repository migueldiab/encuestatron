﻿using System;
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
     *  Lista Encuestas Por Agente
     */
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
      if (id_agente == "")
      {
        encuestas = etFachada.listaEncuestas().ListaEncuestas;
      }
      else
      {
        encuestas = etFachada.listaEncuestasPorIdAgente(id_agente);
      }
      return View(encuestas);
    }


    /*
     *  Lista Encuestas Por Cliente
     */
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


    /*
     *  Lista Encuestas Por Fecha de Ingreso
     */
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

    /*
     *  Lista Encuestas Por Fecha de Vigencia
     */
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

    /*
     *  Lista Encuestas Por Fecha de Cierre
     */
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
  }
}