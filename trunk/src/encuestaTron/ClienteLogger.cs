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
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using System.IO;
using System.Threading;
using etLogs;


namespace encuestaTron
{
    public class ClienteLogger
    {
        delegate void enviarDelegate(Log logr);
        delegate void grabarDelegate();
        private static bool channelYaRegistrado = false;

        public static void insertLog(string mensaje,int idUsuario,Log.SEVERIDAD severidad)
        {
             Log log;
             DateTime fecha = new DateTime();
             fecha = DateTime.Now;
             log = new Log(fecha, idUsuario,mensaje, severidad);
             insertLog(log);
        }
        public static void insertLog(string mensaje,Log.SEVERIDAD severidad)
        {
            insertLog(mensaje, 0, severidad);
        }
        public static void insertLog(string mensaje)
        {
            insertLog(mensaje, Log.SEVERIDAD.INFO);
        }
        private static int insertLog(Log log)
        {

            try
            {
                HttpChannel chan1 = new HttpChannel();
                if (!channelYaRegistrado)
                {
                    ChannelServices.RegisterChannel(chan1, false);
                    channelYaRegistrado = true;
                }
                Logger logger = (Logger)Activator.GetObject(
                    typeof(Logger),
                    "http://localhost:8096/DoLog");

            
                enviarDelegate insDelegate = new enviarDelegate(logger.Insertar);
                grabarDelegate recDelegate = new grabarDelegate(logger.grabarLogs);

               // DateTime fecha = new DateTime();
               // fecha = DateTime.Now;
               // Log log = new Log(fecha, 200, "XXX", Utils.Log.SEVERIDAD.ERROR);

                Console.WriteLine("Llamando a Logger");
                Boolean isLoggerAlive = false;
                int retries = 0;
                while (!isLoggerAlive && retries<10)
                {
                  retries++;
                    try
                    {
                        Console.WriteLine("try service .....");
                        isLoggerAlive = logger.isAlive();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("service is down");
                        

                    }

                }

                Console.WriteLine("service OK....");

                IAsyncResult insAsyncres = insDelegate.BeginInvoke(log, null, null);
                Console.WriteLine("Se envio la insercion Asincronica " + log.Fecha);
                Thread.Sleep(500);
                IAsyncResult recAsyncres = recDelegate.BeginInvoke(null, null);
            }
            catch (IOException ioExcep)
            {
                Console.WriteLine("Remote IO Error" +
                    "\nException:\n" + ioExcep.ToString());
                return 1;
            }
            return 0;
            
        }
    }

}
