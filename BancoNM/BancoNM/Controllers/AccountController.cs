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
            if (Session["idusuario"] != null)
            {
                return RedirectToAction("Mantenimientos_", "Navegacion");
            }
            return View();
        }
        public ActionResult Login1()
        {
            if (Session["idusuario"] != null)
            {
                return RedirectToAction("Indexcreate", "PagoPrestamos");
            }
            
            return View();
        }

        public ActionResult Login2()
        {
            if (Session["idusuario"] != null)
            {
                return RedirectToAction("Solicitudes_", "Navegacion");
            }

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
                Session["idusuario"] = acc.idUsuario;
                Session["admin"] = true;
                return RedirectToAction("Index","Home");
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
                Session["idusuario"] = acc.idUsuario;
                Session["admin"] = true;
                return RedirectToAction("Indexcreate", "PagoPrestamos");
            }
        }

        [HttpPost]
        public ActionResult Verify2(Clientes acc)
        {

            var data = db.Clientes.Where(f => f.cedula == acc.cedula && f.correo == acc.correo).FirstOrDefault();

            if (data == null)
            {
                return View("Login2");
            }
            else
            {
                Session["idusuario"] = data.idCliente;
                Session["cedula"] = acc.cedula;
                return RedirectToAction("Solicitudes_", "Navegacion");
            }
        }
    }
}