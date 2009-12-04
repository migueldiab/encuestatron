using System;
using System.Data;
using System.Configuration;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Text;
using System.Xml;
using System.Collections.Generic;
using encuestaTron;
using encuestaTron.Models;

namespace DataTypesObjects
{
    public class Encuesta : Controller
  {

    public static List<encuesta> listaEncuestas()
    {
      var dbModel = new dbModel(Sistema.connStr);
      return dbModel.encuestas.ToList();
    }
    public static List<encuesta> listaEncuestasPorCliente(usuario unCliente)
    {
      var dbModel = new dbModel(Sistema.connStr);            
      List<encuesta> encuestas = null;
      //dbModel.encuestas.SelectMany(x => x.id_cliente == unCliente.id_usuario);
      return encuestas;
    }

    public static encuesta encuestaPorId(string id)
    {
      var dbModel = new dbModel(Sistema.connStr);
      return dbModel.encuestas.SingleOrDefault(x => x.nombre == id); 
    }

    public static bool insertarEncuesta(encuesta unaEncuesta)
    {
      try
      {
        var dbModel = new dbModel(Sistema.connStr);
        dbModel.encuestas.InsertOnSubmit(unaEncuesta);
        dbModel.SubmitChanges();
        return true;
      }
	    catch (Exception e)
	    {
        Console.WriteLine(e.ToString());
        return false;
	    }
    }

    public static bool actualizarEncuesta(string id, encuesta unaEncuesta)
    {
      var dbModel = new dbModel(Sistema.connStr);
      encuesta encOriginal = dbModel.encuestas.SingleOrDefault(x => x.nombre == id);
      try
      {
        encOriginal.contrasena = unaEncuesta.contrasena;
        encOriginal.f_cierre = unaEncuesta.f_cierre;
        encOriginal.f_ingreso = unaEncuesta.f_ingreso;
        encOriginal.f_modificacion = unaEncuesta.f_modificacion;
        encOriginal.f_vigencia = unaEncuesta.f_vigencia;
        encOriginal.id_cliente = unaEncuesta.id_cliente;
        encOriginal.preguntas = unaEncuesta.preguntas;        
        dbModel.SubmitChanges();
        return true;
      }
      catch
      {
        return false;
      }
    }

    public static List<encuesta> listaEncuestasPorIdAgente(string idAgente)
    {
      var dbModel = new dbModel(Sistema.connStr);
      var listaClientes = Usuario.clientesPorAgente(idAgente);
      IQueryable<encuesta> lista = from e in dbModel.encuestas where listaClientes.Contains(e.id_cliente) select e;

      return lista.ToList();      
    }

    public static List<encuesta> listaEncuestasPorIdCliente(string idCliente)
    {
      var dbModel = new dbModel(Sistema.connStr);
      IQueryable<encuesta> lista = from e in dbModel.encuestas where e.id_cliente == idCliente select e;
      return lista.ToList();    
    }

    public static List<encuesta> listaEncuestasPorIdCliente(DateTime fechaInicial, DateTime fechaFinal, string idAgente)
    {
      var dbModel = new dbModel(Sistema.connStr);
      IQueryable<encuesta> lista = null;
      if (idAgente != null)
      {
        var listaClientes = Usuario.clientesPorAgente(idAgente);
        lista = from e in dbModel.encuestas
                where listaClientes.Contains(e.id_cliente)
                where e.f_ingreso > fechaInicial
                where e.f_ingreso < fechaFinal
                select e;
      }
      else
      {
        lista = from e in dbModel.encuestas
                where e.f_ingreso > fechaInicial
                where e.f_ingreso < fechaFinal
                select e;
      }
      return lista.ToList();    
    }

    public static bool esAutenticada(encuesta unaEncuesta, string pass)
    {
      throw new NotImplementedException();
    }
  }
}
