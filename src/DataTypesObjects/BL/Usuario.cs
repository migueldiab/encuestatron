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
          var dbModel = new dbModel(Sistema.connStr);
          usuario unUsuario = dbModel.usuarios.SingleOrDefault(x => x.id_usuario == usuario);
          if (unUsuario == null)
            return "invitado";
          else
          {
            if (unUsuario.rol == null)
              return "invitado";
            else
              return unUsuario.rol.permiso;
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
          catch (Exception e)
          {
            string error = e.ToString();
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
          var dbModel = new dbModel(Sistema.connStr);
          usuario unUsuario = dbModel.usuarios.SingleOrDefault(x => x.id_usuario == usuario);
          if (unUsuario == null)
            return false;
          if (unUsuario.contrasena == password)
            return true;
          else
            return false;
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

        public static List<usuario> listaPorRol(string nombreRol)
        {
          var dbModel = new dbModel(Sistema.connStr);
          IQueryable<usuario> lista = from m in dbModel.usuarios where m.rol.permiso == nombreRol select m;
          return lista.ToList();
        }

        public static List<usuario> listaClientePorAgente(string nombreAgente)
        {
          var dbModel = new dbModel(Sistema.connStr);
          var listaClientes = clientesPorAgente(nombreAgente);
          IQueryable<usuario> lista = from m in dbModel.usuarios
                                      where listaClientes.Contains(m.id_usuario)
                                      select m;
          return lista.ToList();
        }

        internal static List<string> clientesPorAgente(string nombreAgente)
        {
          var dbModel = new dbModel(Sistema.connStr);
          IQueryable<string> listaClientes = from a in dbModel.clientes where a.id_agente == nombreAgente select a.id_usuario;
          return listaClientes.ToList();
        }

        public static bool insertarCliente(usuario unCliente, usuario unAgente)
        {
          throw new NotImplementedException();
        }
    }
}

