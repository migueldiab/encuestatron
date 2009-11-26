using System;
namespace Utils
{
    [Serializable]
    public class Log
    {
        private int id;
        private DateTime fecha;
        private int usuario;
        private String descripcion;
        private SEVERIDAD severidad;

        public static void Main(String[] args)
        {
        }
        public enum SEVERIDAD
        {
            INFO,
            ALERT,
            ERROR
        }
        public Log()
        {
            this.fecha = DateTime.Now;
            this.usuario = 55;
            this.descripcion = "Prueba";
            this.severidad = SEVERIDAD.INFO;
        }
        public Log(DateTime fecha, int usuario, String descripcion, SEVERIDAD severidad)
        {
            this.fecha = fecha;
            this.usuario = usuario;
            this.descripcion = descripcion;
            this.severidad = severidad;
        }


        #region Properties
        public SEVERIDAD Severidad
        {
            get { return severidad; }
            set { severidad = value; }
        }

        public int Id
        {
            get { return id; }

        }


        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }


        public int Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }


        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        #endregion

        public override String ToString()
        {
            String ret = "ID: " + this.id +
                        " FECHA: " + this.fecha +
                        " USUARIO: " + this.usuario +
                        " DESCRIPCION: " + this.descripcion +
                        " SEVERIDAD: " + this.severidad;
            return ret;
        }
    }

}
