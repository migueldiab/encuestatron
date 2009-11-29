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
    public class ResultadoWs
    {
        private String error;
        private List<Object> resultado = new List<Object>();

        public List<Object> Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }

        public String Error
        {
            get { return error; }
            set { error = value; }
        }
        

       

    }
}
