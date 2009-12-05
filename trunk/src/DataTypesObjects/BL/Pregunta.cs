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

        public static pregunta getPregunta(int idPregunta, int idEncuesta)
        {
            var dbModel = new dbModel(Sistema.connStr);
            return dbModel.preguntas.Single(x => (x.id_encuesta == idEncuesta.ToString()) && (x.id == idPregunta));
        }


    }
}
