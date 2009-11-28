using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTypesObjects
{
   public class Usuario
    {
        private int cedula;
        private String contrasenia;
        private String nombre;
        private String apellido;
        private String mail;
        private String celular;
        private String telefono;
        private List<Rol> roles;

#region Properties
		 
	

        public List<Rol> Roles
        {
            get { return roles; }
            set { roles = value; }
        }
        public int Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }
        public String Contrasenia
        {
            get { return contrasenia; }
            set { contrasenia = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public String Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public String Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        public String Celular
        {
            get { return celular; }
            set { celular = value; }
        }

        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

#endregion

    }
}
