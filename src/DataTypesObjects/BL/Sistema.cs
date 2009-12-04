﻿using System;
using System.Configuration;
using System.Linq;
using System.Web;
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
    public static string connStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=eTronDB;User ID=admin;Password=adminadmin";

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