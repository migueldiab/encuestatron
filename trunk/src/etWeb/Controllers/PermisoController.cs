using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace etWeb.Controllers
{
    public class PermisoController : Controller
    {
        //
        // GET: /Permiso/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Permiso/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Permiso/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Permiso/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Permiso/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Permiso/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
