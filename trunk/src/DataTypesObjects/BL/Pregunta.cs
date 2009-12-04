using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using encuestaTron;
using encuestaTron.Models;


namespace DataTypesObjects
{
    public class Pregunta
    {
        private int id;
        private string planteo;
        private string condicion;
        private DateTime fechaUltimaRespuesta;
        private string idEncuesta;
        private int nroPregunta;
        private List<Respuesta> respuestas;
        private Encuesta encuesta;

        public static pregunta getPregunta(int idPregunta, int idEncuesta)
        {
            var dbModel = new dbModel(Sistema.connStr);
            return dbModel.preguntas.Single(x => (x.id_encuesta == idEncuesta.ToString()) && (x.id == idPregunta));
        }


        #region Properties

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        

        public string Planteo
        {
            get { return planteo; }
            set { planteo = value; }
        }

        

        public string Condicion
        {
            get { return condicion; }
            set { condicion = value; }
        }

       

        public DateTime FechaUltimaRespuesta
        {
            get { return fechaUltimaRespuesta; }
            set { fechaUltimaRespuesta = value; }
        }

        

        public string IdEncuesta
        {
            get { return idEncuesta; }
            set { idEncuesta = value; }
        }

        

        public int NroPregunta
        {
            get { return nroPregunta; }
            set { nroPregunta = value; }
        }

        

        internal List<Respuesta> Respuestas
        {
            get { return respuestas; }
            set { respuestas = value; }
        }

        private int respuesta;

        public int Respuesta
        {
            get { return respuesta; }
            set { respuesta = value; }
        }

       
        public Encuesta Encuesta
        {
            get { return encuesta; }
            set { encuesta = value; }
        }
        #endregion

    }
}
