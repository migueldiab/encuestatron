using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.SqlTypes;
using System.Xml;
using System.Runtime.Serialization;
using System.Text;
using System.IO;

namespace encuestaTron
{
  public class Sistema
  {
    public static string connStr = global::System.Configuration.ConfigurationManager.ConnectionStrings["etTempDBConnectionString"].ConnectionString;

    public bool connectDb() {
      string db_server = getAppConfig("db_server");
      string db_name = getAppConfig("db_name");
      string db_user = getAppConfig("db_user");
      string db_password = getAppConfig("db_password");

      string strConn = "Server=" + db_server +
        ";Database=" + db_name +
        ";User ID=" + db_user +
        ";Password=" + db_password + 
        ";Trusted_Connection=False;";
      SqlConnection conn = new SqlConnection(strConn);

      return true;

    }

    private string getAppConfig(string nombre) 
    {
      System.Configuration.Configuration web_config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);
      if (web_config.AppSettings.Settings.Count > 0)
      {
        string parametro = ConfigurationSettings.AppSettings["nombre"];
        if (parametro != null)
        {
          return parametro;
        }
      }
      throw new Exception("Error! Parametro no encontrado");
    }

    internal static Object xmlToObj(string stringXml, object unObjeto)
    {
      DataContractSerializer dcs = new DataContractSerializer(unObjeto.GetType());
      StringReader strReader = new StringReader(stringXml);
      XmlReader xmlReader = new XmlTextReader(strReader);
      return dcs.ReadObject(xmlReader);
    }

    internal static string objToXml(Object unObjeto)
    {
      DataContractSerializer dcs = new DataContractSerializer(unObjeto.GetType());
      StringBuilder sb = new StringBuilder();
      XmlWriter writer = XmlWriter.Create(sb);
      dcs.WriteObject(writer, unObjeto);
      writer.Close();
      return sb.ToString();
    }
  }
}
