using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using etWebService.et;



namespace etWebService
{
    public class ListaEncuestaResult2: ResultWs2
    {
        private List<EncuestaPortal> listaEncuestas;

        public List<EncuestaPortal> ListaEncuestas
        {
            get { return listaEncuestas; }
            set { listaEncuestas = value; }
        }
    }
}
