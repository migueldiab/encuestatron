using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using encuestaTron.Models;
using encuestaTron;

namespace DataTypesObjects
{
  public class Rol
  {
    public static List<encuestaTron.rol> listaRoles()
    {
      var dbModel = new dbModel(Sistema.connStr);
      return dbModel.rols.ToList();
    }
    public static rol rolPorId(int id)
    {
      var dbModel = new dbModel(Sistema.connStr);
      rol unRol = dbModel.rols.SingleOrDefault(x => x.id == id);
      return unRol;
    }


    public static bool insertarRol(rol unRol)
    {
      try
      {
        var dbModel = new dbModel(Sistema.connStr);
        dbModel.rols.InsertOnSubmit(unRol);
        dbModel.SubmitChanges();
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    public static bool actualizarRol(int id, rol unRol)
    {
      var dbModel = new dbModel(Sistema.connStr);
      rol rolOriginal = dbModel.rols.SingleOrDefault(x => x.id == id);
      try
      {
        rolOriginal.nombre = unRol.nombre;
        rolOriginal.permiso = unRol.permiso;
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
