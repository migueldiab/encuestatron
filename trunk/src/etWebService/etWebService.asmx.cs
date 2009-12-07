using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Collections.Generic;
using etWebService.et;

namespace etWebService
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class etWebService : System.Web.Services.WebService
    {
       //TODO rd borrar List<respuesta> respuestasContestadas = new List<respuesta>();
        Fachada fachada = new Fachada();

        [System.Xml.Serialization.XmlInclude( typeof(et.ListaEncuestaResult))]
        [System.Xml.Serialization.XmlInclude( typeof(EncuestaPortal))]
        [WebMethod (EnableSession=true)]
        public ListaEncuestaResult2 getListaEncuestas()
        {
            ListaEncuestaResult2 resultAEnviar = new ListaEncuestaResult2();
            ListaEncuestaResult result = fachada.listaEncuestas();
            if (result.Error ==null)
            {
                encuesta[] encuestas = result.ListaEncuestas;
                List<EncuestaPortal> listaAEnviar = new List<EncuestaPortal>();
                foreach (encuesta e in encuestas)
                {
                    EncuestaPortal encuestaP = new EncuestaPortal();
                    encuestaP.FechaDesde = (DateTime)e.f_vigencia;
                    encuestaP.FechaFin = (DateTime)e.f_cierre;
                    encuestaP.Nombre = e.nombre;
                    encuestaP.Accion = getAccion((DateTime)e.f_vigencia, (DateTime)e.f_cierre);
                    listaAEnviar.Add(encuestaP);
                }
                resultAEnviar.Error = "";
                resultAEnviar.ListaEncuestas = listaAEnviar;
            }
            else
            {
                resultAEnviar.Error = result.Error;
            }
            
            return resultAEnviar;
              
        }
        protected String getAccion(DateTime f_inicio, DateTime f_cierre)
        {
            String nombre = "Inactiva";
            DateTime ahora = new DateTime();
            ahora = DateTime.Now;
            if ((ahora.CompareTo(f_inicio) >= 0) && (ahora.CompareTo(f_cierre) <= 0))
            {
                nombre = "Responder";
            }
            if (ahora.CompareTo(f_cierre) >= 0)
            {
                nombre = "Consultar";
            }

            return nombre;

        }
        [WebMethod (EnableSession=true)]
        public ListaEncuestaResult2 encuestaPorIdPassword(String id, String pass)
        {
            ListaEncuestaResult2 resultAEnviar = new ListaEncuestaResult2();
            ListaEncuestaResult result = (ListaEncuestaResult)fachada.encuestaPorIdPassword(id, pass);
            List<EncuestaPortal> listaAEnviar = new List<EncuestaPortal>();
            if (result.Error == null)
            {
                encuesta encuesta = result.ListaEncuestas[0];
                Session["encuestaActiva"] = encuesta;
                              
                    EncuestaPortal encuestaP = new EncuestaPortal();
                    encuestaP.FechaDesde = (DateTime)encuesta.f_vigencia;
                    encuestaP.FechaFin = (DateTime)encuesta.f_cierre;
                    encuestaP.Nombre = encuesta.nombre;
                    encuestaP.Accion = getAccion((DateTime)encuesta.f_vigencia, (DateTime)encuesta.f_cierre);
                    encuestaP.Preguntas = encuesta.preguntas.ToList<pregunta>();
                    //pregunta pregunta = encuesta.preguntas[0];
                    //respuesta[] respuestas = pregunta.respuestas;
                   listaAEnviar.Add(encuestaP);
                
                resultAEnviar.Error = null;
                resultAEnviar.ListaEncuestas = listaAEnviar;
            }
            else
            {
                resultAEnviar.Error = result.Error;
            }
            return resultAEnviar;             
        }

      
        [WebMethod (EnableSession=true )]
        public getPreguntaResult2 getSiguientePreguntaEncuesta(respuesta respuesta)
        {
            getPreguntaResult2 result = new getPreguntaResult2();
            if (Session["count"] == null)
                Session["count"] = 0;
            Session["count"] = (int)Session["count"]+1;

            if (Session["respuestas"] == null)
                Session["respuestas"] = new List<respuesta>();
            ((List<respuesta>)Session["respuestas"]).Add(respuesta);
           

          //  respuestasContestadas.Add(respuesta);
            if (respuesta.id_proxima_pregunta == null)
            {
                result.Error = "No hay mas preguntas para la encuesta. Muchas Gracias."+ Session["count"];
                //TODO rd Terminar guardarRespuestas();
                return result;
            }
            try
            {
                et.getPreguntaResult resultPreg = fachada.getPreguntaPorId((int)respuesta.id_proxima_pregunta);
                
                if (resultPreg.Error != null)
                {
                    result.Error = resultPreg.Error;
                    return result;
                }
                pregunta pregunta = resultPreg.Pregunta;
                if (pregunta == null)
                {
                    result.Error = "No se encontro la pregunta id: " + respuesta.id_proxima_pregunta;
                }
                else
                {
                    result.Pregunta = pregunta;
                }
            }
            catch (Exception)
            {

                result.Error = "Error en fachada";
                return result;
            }
            return result;
            //return fachada.getPregunta(idEncuesta,passEncuesta,respuesta);
        }
        [WebMethod]
        public ResultWs guardarEncuesta(respuesta[] respuestas){
            ResultWs result = fachada.guardarEncuesta(respuestas);
            return result;
        }

       
        //TODO rd Borrar si no se utiliza [WebMethod]
        //public et.ResultWs getResultadoEncuesta(int id, String pass)
        //{
          
        //  return null;
        //}

        private void InitializeComponent()
        {

        }
    }
}
