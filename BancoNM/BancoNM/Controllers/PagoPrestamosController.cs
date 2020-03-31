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
    public class PagoPrestamosController : Controller
    {
        private BancoNMEntities db = new BancoNMEntities();

        // GET: PagoPrestamos
        public ActionResult Index()
        {
            var pagoPrestamos = db.PagoPrestamos.Include(p => p.Clientes).Include(p => p.Prestamos);
            return View(pagoPrestamos.ToList());
        }

        // GET: PagoPrestamos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagoPrestamos pagoPrestamos = db.PagoPrestamos.Find(id);
            if (pagoPrestamos == null)
            {
                return HttpNotFound();
            }
            return View(pagoPrestamos);
        }

        // GET: PagoPrestamos/Create
        public ActionResult Create()
        {
            ViewBag.idCliente = new SelectList(db.Clientes, "idCliente", "cedula");
            ViewBag.idPrestamo = new SelectList(db.Prestamos, "idPrestamo", "idPrestamo");
            return View();
        }

        // POST: PagoPrestamos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPago,idPrestamo,idCliente,fechaPago,cuota,capital,interes,balance")] PagoPrestamos pagoPrestamos)
        {
            if (ModelState.IsValid)
            {
                db.PagoPrestamos.Add(pagoPrestamos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCliente = new SelectList(db.Clientes, "idCliente", "cedula", pagoPrestamos.idCliente);
            ViewBag.idPrestamo = new SelectList(db.Prestamos, "idPrestamo", "idPrestamo", pagoPrestamos.idPrestamo);
            return View(pagoPrestamos);
        }

        // GET: PagoPrestamos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagoPrestamos pagoPrestamos = db.PagoPrestamos.Find(id);
            if (pagoPrestamos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente = new SelectList(db.Clientes, "idCliente", "cedula", pagoPrestamos.idCliente);
            ViewBag.idPrestamo = new SelectList(db.Prestamos, "idPrestamo", "idPrestamo", pagoPrestamos.idPrestamo);
            return View(pagoPrestamos);
        }

        // POST: PagoPrestamos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPago,idPrestamo,idCliente,fechaPago,cuota,capital,interes,balance")] PagoPrestamos pagoPrestamos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagoPrestamos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente = new SelectList(db.Clientes, "idCliente", "cedula", pagoPrestamos.idCliente);
            ViewBag.idPrestamo = new SelectList(db.Prestamos, "idPrestamo", "idPrestamo", pagoPrestamos.idPrestamo);
            return View(pagoPrestamos);
        }

        // GET: PagoPrestamos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagoPrestamos pagoPrestamos = db.PagoPrestamos.Find(id);
            if (pagoPrestamos == null)
            {
                return HttpNotFound();
            }
            return View(pagoPrestamos);
        }

        // POST: PagoPrestamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PagoPrestamos pagoPrestamos = db.PagoPrestamos.Find(id);
            db.PagoPrestamos.Remove(pagoPrestamos);
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
