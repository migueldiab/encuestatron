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

namespace etWebService
{
    [Serializable]
    public class getPreguntaResult2:ResultWs2
    {
        pregunta pregunta;

        public pregunta Pregunta
        {
            get { return pregunta; }
            set { pregunta = value; }
        }
    }
}
