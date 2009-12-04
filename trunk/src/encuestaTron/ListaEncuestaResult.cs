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



namespace encuestaTron
{
    public class ListaEncuestaResult: ResultWs
    {
        private List<encuesta> listaEncuestas = new List<encuesta>();

        public List<encuesta> ListaEncuestas
        {
            get { return listaEncuestas; }
            set { listaEncuestas = value; }
        }
    }
}
