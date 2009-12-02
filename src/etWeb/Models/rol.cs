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

namespace etWeb.et
{
  /*
   * Clase que complemente métodos de objetos del webservice
   */
  public partial class  rol
  {
    public override string ToString()
    {
      return this.nombre;
    }
  }
}
