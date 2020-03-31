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
    public class CreditoCAController : Controller
    {
        private BancoNMEntities db = new BancoNMEntities();

        // GET: CreditoCA
        public ActionResult Index()
        {
            var creditoCA = db.CreditoCA.Include(c => c.CuentaA);
            return View(creditoCA.ToList());
        }

        // GET: CreditoCA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditoCA creditoCA = db.CreditoCA.Find(id);
            if (creditoCA == null)
            {
                return HttpNotFound();
            }
            return View(creditoCA);
        }

        // GET: CreditoCA/Create
        public ActionResult Create()
        {
            ViewBag.numCuenta = new SelectList(db.CuentaA, "numCuenta", "numCuenta");
            return View();
        }

        // POST: CreditoCA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numTrans,numCuenta,descripcion,fecha,monto")] CreditoCA creditoCA)
        {
            if (ModelState.IsValid)
            {
                db.CreditoCA.Add(creditoCA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.numCuenta = new SelectList(db.CuentaA, "numCuenta", "numCuenta", creditoCA.numCuenta);
            return View(creditoCA);
        }

        // GET: CreditoCA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditoCA creditoCA = db.CreditoCA.Find(id);
            if (creditoCA == null)
            {
                return HttpNotFound();
            }
            ViewBag.numCuenta = new SelectList(db.CuentaA, "numCuenta", "numCuenta", creditoCA.numCuenta);
            return View(creditoCA);
        }

        // POST: CreditoCA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numTrans,numCuenta,descripcion,fecha,monto")] CreditoCA creditoCA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(creditoCA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.numCuenta = new SelectList(db.CuentaA, "numCuenta", "numCuenta", creditoCA.numCuenta);
            return View(creditoCA);
        }

        // GET: CreditoCA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditoCA creditoCA = db.CreditoCA.Find(id);
            if (creditoCA == null)
            {
                return HttpNotFound();
            }
            return View(creditoCA);
        }

        // POST: CreditoCA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreditoCA creditoCA = db.CreditoCA.Find(id);
            db.CreditoCA.Remove(creditoCA);
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
