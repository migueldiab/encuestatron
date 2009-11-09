using System;
using Castle.MonoRail.Framework;

namespace etBackend.Controllers
{
    [Layout("default"), Rescue("generalerror")]
    public class HomeController : Controller
    {
        public void Index()
        {
            
            PropertyBag["Creator"] = "Miguel A. Diab";
            PropertyBag["email"] = "migueldiab@adinet.com.uy";
        }

        public void Data() {
            PropertyBag["name"] = "John Doe";
            PropertyBag["today"] = DateTime.Now;

        }


    }
}