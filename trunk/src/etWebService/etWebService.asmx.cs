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

        Fachada fachada = new Fachada();

        [WebMethod]
        public ListaEncuestaResult getListaEncuestas()
        {
          return null;
              //fachada.listaEncuestas();
        }
        [WebMethod]
        public ListaEncuestaResult encuestaPorIdPassword(int id, String pass)
        {
          return null; // fachada.encuestaPorIdPassword(id, pass);
        }

      /*
        [WebMethod]
        public ResultWs getPreguntaEncuesta(int idEncuesta, String passEncuesta, respuesta respuesta)
        {
            return fachada.getPregunta(idEncuesta,passEncuesta,respuesta);
        }
       */
        [WebMethod]
        public ResultWs getResultadoEncuesta(int id, String pass)
        {
          
          return null;
        }

        private void InitializeComponent()
        {

        }
    }
}
