using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTypesObjects
{
    public abstract class  Funcionario
    {
        private int id;
        List<Periodo> periodosActividad;


        #region Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        

        public List<Periodo> PeriodosActividad
        {
            get { return periodosActividad; }
            set { periodosActividad = value; }
        }
        #endregion

    }
}
