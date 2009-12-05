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

namespace etWeb.et
{
   /*
    * Clase que complemente métodos de objetos del webservice
    * y extiende la encuesta con sus preguntas y respuestas respectivas
    */
  public partial class encuesta
  {
    public override string ToString()
    {
      return this.nombre;
    }
  }
}
