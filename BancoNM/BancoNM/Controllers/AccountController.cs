using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BancoNM.Controllers
{
    public class AccountController : Controller
    {
        private BancoNMEntities db = new BancoNMEntities();

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Verify(Usuarios acc)
        {

            var data = db.Database.SqlQuery<Usuarios>("select * from Usuarios where usuario='" + acc.usuario + "' and pass='" + acc.pass + "'").SingleOrDefault();

            if (data == null)
            {
                return View("Login");
            }
            else
            {

                return RedirectToAction("Mantenimientos_","Navegacion");

            }
        }
        [HttpPost]
        public ActionResult Verify1(Usuarios acc)
        {

            var data = db.Database.SqlQuery<Usuarios>("select * from Usuarios where usuario='" + acc.usuario + "' and pass='" + acc.pass + "'").SingleOrDefault();

            if (data == null)
            {
                return View("Login1");
            }
            else
            {
                return RedirectToAction("Indexcreate", "PagoPrestamos");
            }
        }
    }
}