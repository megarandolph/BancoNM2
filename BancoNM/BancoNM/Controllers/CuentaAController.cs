using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BancoNM;

namespace BancoNM.Controllers
{
    public class CuentaAController : Controller
    {
        private BancoNMEntities db = new BancoNMEntities();

        // GET: CuentaA
        public ActionResult Index()
        {
            var cuentaA = db.CuentaA.Include(c => c.Clientes).Include(c => c.Monedas);
            return View(cuentaA.ToList());
        }

        // GET: CuentaA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuentaA cuentaA = db.CuentaA.Find(id);
            if (cuentaA == null)
            {
                return HttpNotFound();
            }
            return View(cuentaA);
        }

        // GET: CuentaA/Create
        public ActionResult Create()
        {
            ViewBag.idCliente = new SelectList(db.Clientes, "idCliente", "cedula");
            ViewBag.idMoneda = new SelectList(db.Monedas, "idMoneda", "descripcion");
            return View();
        }

        // POST: CuentaA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numCuenta,idCliente,idMoneda,estado,balanceDisp,balanceTotal,ultimoCorte")] CuentaA cuentaA)
        {
            if (ModelState.IsValid)
            {
                db.CuentaA.Add(cuentaA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCliente = new SelectList(db.Clientes, "idCliente", "cedula", cuentaA.idCliente);
            ViewBag.idMoneda = new SelectList(db.Monedas, "idMoneda", "descripcion", cuentaA.idMoneda);
            return View(cuentaA);
        }

        // GET: CuentaA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuentaA cuentaA = db.CuentaA.Find(id);
            if (cuentaA == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente = new SelectList(db.Clientes, "idCliente", "cedula", cuentaA.idCliente);
            ViewBag.idMoneda = new SelectList(db.Monedas, "idMoneda", "descripcion", cuentaA.idMoneda);
            return View(cuentaA);
        }

        // POST: CuentaA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numCuenta,idCliente,idMoneda,estado,balanceDisp,balanceTotal,ultimoCorte")] CuentaA cuentaA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuentaA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente = new SelectList(db.Clientes, "idCliente", "cedula", cuentaA.idCliente);
            ViewBag.idMoneda = new SelectList(db.Monedas, "idMoneda", "descripcion", cuentaA.idMoneda);
            return View(cuentaA);
        }

        // GET: CuentaA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuentaA cuentaA = db.CuentaA.Find(id);
            if (cuentaA == null)
            {
                return HttpNotFound();
            }
            return View(cuentaA);
        }

        // POST: CuentaA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CuentaA cuentaA = db.CuentaA.Find(id);
            db.CuentaA.Remove(cuentaA);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
