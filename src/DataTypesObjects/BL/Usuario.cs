using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using encuestaTron.Models;
using encuestaTron;

namespace DataTypesObjects
{
    [Serializable]
    public class Usuario
    {
        public static string obtenerPermisosPorUsuario(string usuario)
        {
          if (usuario == "agente")
          {
            return "agente";
          }
          if (usuario == "admin")
          {
            return "admin";
          }
          else
          {
            return "invitado";
          }
        }

        public static List<usuario> listaUsuarios()
        {
          var dbModel = new dbModel(Sistema.connStr);
          return dbModel.usuarios.ToList();
        }
        public static usuario usuarioPorId(string id)
        {
          var dbModel = new dbModel(Sistema.connStr);
          usuario unUsuario = dbModel.usuarios.SingleOrDefault(x => x.id_usuario == id);
          return unUsuario;
        }


        public static bool insertarUsuario(usuario unUsuario)
        {
          try
          {
            var dbModel = new dbModel(Sistema.connStr);
            dbModel.usuarios.InsertOnSubmit(unUsuario);
            dbModel.SubmitChanges();
            return true;
          }
          catch (Exception)
          {
            return false;
          }
        }

        public static bool actualizarUsuario(string id, usuario unUsuario)
        {
          var dbModel = new dbModel(Sistema.connStr);
          usuario usuarioOriginal = dbModel.usuarios.SingleOrDefault(x => x.id_usuario == id);
          try
          {
            usuarioOriginal.nombre = unUsuario.nombre;
            usuarioOriginal.celular = unUsuario.celular;
            usuarioOriginal.contrasena = unUsuario.contrasena;
            usuarioOriginal.email = unUsuario.email;
            usuarioOriginal.f_ingreso = unUsuario.f_ingreso;
            usuarioOriginal.id_rol = unUsuario.id_rol;
            usuarioOriginal.telefono = unUsuario.telefono;
            dbModel.SubmitChanges();
            return true;
          }
          catch
          {
            return false;
          }
        }


        public static bool validarUsuario(string usuario, string password)
        {
          return true;
        }

        public static bool borrarUsuarioPorId(string id)
        {
          var dbModel = new dbModel(Sistema.connStr);
          usuario usuarioOriginal = dbModel.usuarios.SingleOrDefault(x => x.id_usuario == id);
          try
          {

            dbModel.usuarios.DeleteOnSubmit(usuarioOriginal);
            dbModel.SubmitChanges();
            return true;
          }
          catch
          {
            return false;
          }
        }
    }
}

