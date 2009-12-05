using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.IO;
using System.Data;
using System.Threading;
using System.Runtime.Remoting.Channels.Http;

namespace Utils
{
    public class TestClientObl
    {
        delegate void enviarDelegate(Log logr);
        delegate void grabarDelegate();


        public static int Main(string[] args)
        {

            HttpChannel chan1 = new HttpChannel();
            ChannelServices.RegisterChannel(chan1, false);
            Logger logger = (Logger)Activator.GetObject(
                typeof(Utils.Logger),
                "http://localhost:8096/DoLog");


            try
            {
                enviarDelegate insDelegate = new enviarDelegate(logger.Insertar);
                grabarDelegate recDelegate = new grabarDelegate(logger.grabarLogs);

                DateTime fecha = new DateTime();
                fecha = DateTime.Now;
                Log log = new Log(fecha, 199, "XXX", Utils.Log.SEVERIDAD.ERROR);

                Console.WriteLine("Llamando a Logger");
                Boolean isLoggerAlive = false;
                while (!isLoggerAlive)
                {
                    try
                    {
                        Console.WriteLine("try service .....");
                        isLoggerAlive = logger.isAlive();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("service is down");
                        System.Diagnostics.Process.Start("Logger.exe");
                        Console.WriteLine("service started....");
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
