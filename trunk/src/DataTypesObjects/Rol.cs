using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTypesObjects
{
    public class Rol
    {
        private int id;
        private String descripcion;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
       

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}
