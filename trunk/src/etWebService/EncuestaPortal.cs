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
using etWebService.et;
using System.Collections.Generic;

namespace etWebService
{[Serializable]
    public class EncuestaPortal
    {
        private String nombre;
        private List<pregunta> preguntas;

        public List<pregunta> Preguntas
        {
            get { return preguntas; }
            set { preguntas = value; }
        }
        

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private String accion;

        public String Accion
        {
            get { return accion; }
            set { accion = value; }
        }
        private DateTime fechaDesde;

        public DateTime FechaDesde
        {
            get { return fechaDesde; }
            set { fechaDesde = value; }
        }
        private DateTime fechaFin;

        public DateTime FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }

    }
}
