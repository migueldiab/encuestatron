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

    public static bool incrementarContadorRespuesta(respuesta newResp)
    {
        var dbModel = new dbModel(Sistema.connStr);
        respuesta oldResp = dbModel.respuestas.SingleOrDefault(x => x.id == newResp.id);
        oldResp.contador = oldResp.contador + 1;
        dbModel.SubmitChanges();
        return true;


    }

    public static encuesta encuestaPorId(string id)
    {
      var dbModel = new dbModel(Sistema.connStr);
      return dbModel.encuestas.SingleOrDefault(x => x.nombre == id); 
    }
    public static bool esAutenticada(encuesta encuesta, String pass)
    {
         
        return (encuesta.contrasena.Trim()==pass);
        
    }


    public static bool insertarEncuesta(encuesta unaEncuesta)
    {
      try
      {
        var dbModel = new dbModel(Sistema.connStr);
        unaEncuesta.f_ingreso = DateTime.Now;
        unaEncuesta.f_modificacion = DateTime.Now;
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
        encOriginal.f_modificacion = DateTime.Now;
        encOriginal.f_vigencia = unaEncuesta.f_vigencia;
        encOriginal.id_cliente = unaEncuesta.id_cliente;
        //encOriginal.preguntas = unaEncuesta.preguntas;        
        dbModel.SubmitChanges();
        return true;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.ToString());
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

    public static List<encuesta> listaEncuestasPorFechaIngreso(DateTime fechaInicial, DateTime fechaFinal, string idAgente, string idCliente)
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
      else if (idCliente != null)
      {
        lista = from e in dbModel.encuestas
                where e.id_cliente == idCliente
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


    //public static bool esAutenticada(encuesta unaEncuesta, string pass)
    //{
    //    throw new NotImplementedException();
    //}


    public static List<encuesta> listaEncuestasPorFechaVigencia(DateTime fechaInicial, DateTime fechaFinal, string idAgente, string idCliente)
    {
      var dbModel = new dbModel(Sistema.connStr);
      IQueryable<encuesta> lista = null;
      if (idAgente != null)
      {
        var listaClientes = Usuario.clientesPorAgente(idAgente);
        lista = from e in dbModel.encuestas
                where listaClientes.Contains(e.id_cliente)
                where e.f_vigencia > fechaInicial
                where e.f_vigencia < fechaFinal
                select e;
      }
      else if (idCliente != null)
      {
        lista = from e in dbModel.encuestas
                where e.id_cliente == idCliente
                where e.f_vigencia > fechaInicial
                where e.f_vigencia < fechaFinal
                select e;
      }
      else
      {
        lista = from e in dbModel.encuestas
                where e.f_vigencia > fechaInicial
                where e.f_vigencia < fechaFinal
                select e;
      }
      return lista.ToList();    
    }

    public static List<encuesta> listaEncuestasPorFechaCierre(DateTime fechaInicial, DateTime fechaFinal, string idAgente, string idCliente)
    {
      var dbModel = new dbModel(Sistema.connStr);
      IQueryable<encuesta> lista = null;
      if (idAgente != null)
      {
        var listaClientes = Usuario.clientesPorAgente(idAgente);
        lista = from e in dbModel.encuestas
                where listaClientes.Contains(e.id_cliente)
                where e.f_cierre > fechaInicial
                where e.f_cierre < fechaFinal
                select e;
      }
      else if (idCliente != null)
      {
        lista = from e in dbModel.encuestas
                where e.id_cliente == idCliente
                where e.f_cierre > fechaInicial
                where e.f_cierre < fechaFinal
                select e;
      }
      else
      {
        lista = from e in dbModel.encuestas
                where e.f_cierre > fechaInicial
                where e.f_cierre < fechaFinal
                select e;
      }
      return lista.ToList();
    }

    public static int insertarPregunta(pregunta unaPregunta, encuesta unaEncuesta)
    {
      try
      {
        var dbModel = new dbModel(Sistema.connStr);
        unaEncuesta.f_modificacion = DateTime.Now;
        if (unaPregunta.nro_pregunta == null)
        {
          unaPregunta.nro_pregunta = obtenerUltimaPregunta(unaEncuesta)+1;
        }
        dbModel.preguntas.InsertOnSubmit(unaPregunta);
        dbModel.SubmitChanges();
        return unaPregunta.id;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.ToString());
        return -1;
      }
    }

    private static int obtenerUltimaPregunta(encuesta unaEncuesta)
    {
      var dbModel = new dbModel(Sistema.connStr);
      int max;
      try
      {
        max = (from p in dbModel.preguntas
                   where p.id_encuesta == unaEncuesta.nombre
                   select p.nro_pregunta).Max().Value;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.ToString());
        max = 0;
      }
      return max;
    }

    public static pregunta preguntaPorId(int idPregunta)
    {
      var dbModel = new dbModel(Sistema.connStr);
      return dbModel.preguntas.Single(x => x.id == idPregunta);  
    }

    public static int insertarRespuesta(respuesta unaRespuesta, pregunta unaPregunta)
    {
      try
      {
        var dbModel = new dbModel(Sistema.connStr);
        encuesta unaEncuesta = Encuesta.encuestaPorId(unaPregunta.id_encuesta);
        unaEncuesta.f_modificacion = DateTime.Now;
        dbModel.respuestas.InsertOnSubmit(unaRespuesta);
        dbModel.SubmitChanges();
        return unaPregunta.id;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.ToString());
        return -1;
      }
    }

    public static List<respuesta> respuestasPorPregunta(pregunta unaPregunta)
    {
      var dbModel = new dbModel(Sistema.connStr);
      IQueryable<respuesta> listaRespuestas = from r in dbModel.respuestas
                                        where r.id_pregunta == unaPregunta.id
                                        select r;
      return listaRespuestas.ToList();
    }

    public static List<pregunta> preguntasPorEncuesta(encuesta unaEncuesta)
    {
      var dbModel = new dbModel(Sistema.connStr);
      IQueryable<pregunta> listaPreguntas = from p in dbModel.preguntas
                                            orderby p.nro_pregunta
                                            where p.id_encuesta == unaEncuesta.nombre
                                            select p;
      return listaPreguntas.ToList();
    }

    public static bool borrarEncuestaPorId(string id)
    {
        var dbModel = new dbModel(Sistema.connStr);
        encuesta encuestaOriginal = dbModel.encuestas.SingleOrDefault(x => x.nombre == id);
        try
        {
          dbModel.encuestas.DeleteOnSubmit(encuestaOriginal);
          dbModel.SubmitChanges();
          return true;
        }
        catch (Exception e)
        {
          Console.WriteLine(e.ToString());
          return false;
        }

    }

    public static bool borrarPreguntaPorId(int id)
    {
      var dbModel = new dbModel(Sistema.connStr);
      pregunta preguntaOriginal = dbModel.preguntas.SingleOrDefault(x => x.id == id);
      try
      {
        dbModel.preguntas.DeleteOnSubmit(preguntaOriginal);
        dbModel.SubmitChanges();
        return true;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.ToString());
        return false;
      }
    }

    public static bool borrarRespuestaPorId(int id)
    {
      var dbModel = new dbModel(Sistema.connStr);
      respuesta respuestaOriginal = dbModel.respuestas.SingleOrDefault(x => x.id == id);
      try
      {
        dbModel.respuestas.DeleteOnSubmit(respuestaOriginal);
        dbModel.SubmitChanges();
        return true;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.ToString());
        return false;
      }
    }
  }
}
