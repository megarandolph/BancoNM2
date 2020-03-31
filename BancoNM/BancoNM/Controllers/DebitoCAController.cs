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
    public class DebitoCAController : Controller
    {
        private BancoNMEntities db = new BancoNMEntities();

        // GET: DebitoCA
        public ActionResult Index()
        {
            var debitoCA = db.DebitoCA.Include(d => d.CuentaA);
            return View(debitoCA.ToList());
        }

        // GET: DebitoCA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebitoCA debitoCA = db.DebitoCA.Find(id);
            if (debitoCA == null)
            {
                return HttpNotFound();
            }
            return View(debitoCA);
        }

        // GET: DebitoCA/Create
        public ActionResult Create()
        {
            ViewBag.numCuenta = new SelectList(db.CuentaA, "numCuenta", "numCuenta");
            return View();
        }

        // POST: DebitoCA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numTrans,numCuenta,descripcion,fecha,monto")] DebitoCA debitoCA)
        {
            if (ModelState.IsValid)
            {
                db.DebitoCA.Add(debitoCA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.numCuenta = new SelectList(db.CuentaA, "numCuenta", "numCuenta", debitoCA.numCuenta);
            return View(debitoCA);
        }

        // GET: DebitoCA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebitoCA debitoCA = db.DebitoCA.Find(id);
            if (debitoCA == null)
            {
                return HttpNotFound();
            }
            ViewBag.numCuenta = new SelectList(db.CuentaA, "numCuenta", "numCuenta", debitoCA.numCuenta);
            return View(debitoCA);
        }

        // POST: DebitoCA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numTrans,numCuenta,descripcion,fecha,monto")] DebitoCA debitoCA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(debitoCA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.numCuenta = new SelectList(db.CuentaA, "numCuenta", "numCuenta", debitoCA.numCuenta);
            return View(debitoCA);
        }

        // GET: DebitoCA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebitoCA debitoCA = db.DebitoCA.Find(id);
            if (debitoCA == null)
            {
                return HttpNotFound();
            }
            return View(debitoCA);
        }

        // POST: DebitoCA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DebitoCA debitoCA = db.DebitoCA.Find(id);
            db.DebitoCA.Remove(debitoCA);
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
