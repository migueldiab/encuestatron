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
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Text;

namespace etWeb.Lib
{
  public class Sistema
  {

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
