using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTypesObjects
{
    public class Cliente : Usuario
    {
        List<Periodo> periodosActividad;

        public List<Periodo> PeriodosActividad
        {
            get { return periodosActividad; }
            set { periodosActividad = value; }
        }

        
    }
}
