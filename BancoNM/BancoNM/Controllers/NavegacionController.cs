using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BancoNM.Controllers
{
    public class NavegacionController : Controller
    {
        // GET: Navegacion
        public ActionResult Mantenimientos()
        {
            return View();
        }
        public ActionResult Consultas()
        {
            if(Session["admin"] != null)
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Solicitudes()
        {
            return View();
        }

        public ActionResult Mantenimientos_()
        {
            return View();
        }
        public ActionResult Solicitudes_()
        {
            return View();
        }
    }
}