using System;
using Castle.MonoRail.Framework;
using etBackend.Models;

namespace etBackend.Controllers
{
    [Layout("default"), Rescue("generalerror")]
    public class UsuarioController : SmartDispatcherController
    {
        public void Lista()
        {

        }

        public void GuardarUsuario([DataBind("usuario")] Usuario unUsuario)
        {

            PropertyBag["usuario"] = unUsuario;

            RenderView("mensaje");


        }
    }
}