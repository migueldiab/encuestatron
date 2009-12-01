using System;
using System.Data;
using System.Configuration;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using encuestaTron.Models;
using System.Text;
using System.Xml;

namespace encuestaTron.DTO
{
  public class Encuesta
  {

    internal static string listaEncuestas()
    {
      var dbModel = new dbModel(Sistema.connStr);
      var encuestas = dbModel.encuestas.ToList();
      return Sistema.objToXml(encuestas);
    }

    internal static string encuestaPorId(string id)
    {
      var dbModel = new dbModel(Sistema.connStr);
      encuesta unaEncuesta = dbModel.encuestas.SingleOrDefault(x => x.nombre == id);
      return Sistema.objToXml(unaEncuesta);
    }

    internal static bool insertarEncuesta(string xmlEncuesta)
    {
      try
      {
        encuesta unaEncuesta = (encuesta)Sistema.xmlToObj(xmlEncuesta, new encuesta());
        var dbModel = new dbModel(Sistema.connStr);
        dbModel.encuestas.InsertOnSubmit(unaEncuesta);
        dbModel.SubmitChanges();
        return true;
      }
	    catch (Exception)
	    {
        return false;
	    }
    }
  }
}
