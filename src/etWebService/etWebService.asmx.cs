﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

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

        [WebMethod]
        public ResultWs getListaEncuestas()
        {
          ResultWs resultado = new ResultWs();
          resultado.Error = "Hello World";
            return resultado;
        }
        [WebMethod]
        public ResultWs getEncuesta(int id, String user, String pass)
        {
          ResultWs resultado = new ResultWs();
          resultado.Error = "Hello World";
          return resultado;
        }

        [WebMethod]
        public ResultWs getPreguntaEncuestas()
        {
          ResultWs resultado = new ResultWs();
          resultado.Error = "Hello World";
          return resultado;
        }
        [WebMethod]
        public ResultWs getResultadoEncuesta(int id, String user, String pass)
        {
          ResultWs resultado = new ResultWs();
          resultado.Error = "Hello World";
          return resultado;
        }

        private void InitializeComponent()
        {

        }
    }
}
