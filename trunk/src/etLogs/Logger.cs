using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Configuration;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;



namespace etLogs
{
  public class Logger : MarshalByRefObject
  {
    private List<Log> logs = new List<Log>();

    static void Main(string[] args)
    {
      HttpChannel chan1 = new HttpChannel(8096);
      
      RemotingConfiguration.RegisterWellKnownServiceType(typeof(Logger),
              "DoLog",
              WellKnownObjectMode.Singleton);

      System.Console.WriteLine("Press Enter key to exit HTTP");
      System.Console.ReadLine();
    }

    public Logger()
    {
      Console.WriteLine("El servidor esta activo HTTP");
    }

    private String getCon()
    {
      string connStr = ConfigurationManager.ConnectionStrings["etDBConnectionString"].ConnectionString;
      return connStr;
    }
    private String getSQLInsert()
    {
      string sql = "INSERT INTO bitacora" +
          "(fecha_Log,usuario_Log,descripcion_Log,severidad_Log) " +
          "VALUES " + "(@fecha, @usuario, @descripcion, @severidad)" +
          "SELECT @@Identity";
      return sql;
    }
    public void grabarLogs()
    {
      Console.WriteLine("grabando en BD");
      if (logs.Count > 0)
      {
        foreach (Log log in logs)
        {
          Console.WriteLine("grabando " + log.ToString());
          grabar(log);
          logs.Remove(log);
        }
        logs.Clear();
      }
    }
    public int grabar(Log log)
    {
      Console.WriteLine("Intentando insertar: " + log.ToString());
      Thread.Sleep(2000);

      try
      {
        string sCon = getCon();
        string sel = getSQLInsert();

        using (SqlConnection con = new SqlConnection(sCon))
        {
          SqlCommand cmd = new SqlCommand(sel, con);
          cmd.Parameters.AddWithValue("@fecha", log.Fecha);
          cmd.Parameters.AddWithValue("@usuario", log.Usuario);
          cmd.Parameters.AddWithValue("@descripcion", log.Descripcion);
          cmd.Parameters.AddWithValue("@severidad", log.Severidad.ToString());
          con.Open();

          int t = Convert.ToInt32(cmd.ExecuteScalar());
          con.Close();
          Console.WriteLine("Se inserto OK");
          return t;
        }
      }
      catch (Exception)
      {
        Console.WriteLine("ERROR al insertar log");
        return 0;
      }

    }

    public void Insertar(Log log)
    {
      Console.WriteLine("Insertando en lista");
      logs.Add(log);

    }
    public Boolean isAlive()
    {
      Console.WriteLine("The service is Alive");
      return true;
    }



  }
}
