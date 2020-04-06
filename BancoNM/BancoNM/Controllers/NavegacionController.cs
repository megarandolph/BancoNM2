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
            return View();
        }
        public ActionResult Solicitudes()
        {
            return View();
        }
        public ActionResult PagoPrestamo()
        {
            return View();
        }
    }
}