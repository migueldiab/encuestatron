using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTypesObjects
{
    [Serializable]
    public class Usuario
    {
        private int cedula;
        private String contrasenia;
        private String nombre;
        private String apellido;
        private String mail;
        private String celular;
        private String telefono;
        private List<Rol> roles = new List<Rol>();

        public static Usuario Login(String user, String pass)
        {
            Usuario usuario ;
            usuario = findById(user);
            if (usuario != null)
            {
              if (usuario.Contrasenia ==pass)
               // if (pass.Equals("123"))
                {
                    return usuario;
                }
                else
                {
                    throw new Exception("contraseña incorrecta");
                }
            }
            else
            {
                throw new Exception("Usuario inexistente");
            }
            throw new Exception("ERROR desconocido");
            
        }
        public static Usuario findById(String id)
        {// aca debe ir la logica de buscar en BD
            Usuario usuario = null;
            if (id == "123")
            {
                usuario = new Usuario();
                usuario.Apellido = "Ape1";
                usuario.Nombre = "Nom1";
                usuario.Cedula = 123;
                usuario.Contrasenia = "123";

                Rol rol1 = new Rol();
                rol1.Descripcion = "agente";
                rol1.Id = 1;
                usuario.roles.Add(rol1);
            }
            if (id == "1234")
            {
                usuario = new Usuario();
                usuario.Apellido = "Ape1";
                usuario.Nombre = "Nom1";
                usuario.Cedula = 1234;
                usuario.Contrasenia = "1234";

                Rol rol1 = new Rol();
                rol1.Descripcion = "administrador";
                rol1.Id = 2;
                usuario.roles.Add(rol1);
            }
            return usuario;
        }
        public override string ToString()
        {
            return Nombre +" "+ Apellido;
        }
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

