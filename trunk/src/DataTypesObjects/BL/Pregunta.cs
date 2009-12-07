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

        public static pregunta getPreguntaporId(int idPregunta)
        {
            var dbModel = new dbModel(Sistema.connStr);
            return dbModel.preguntas.SingleOrDefault(x => x.id == idPregunta);
        }


    }
}
