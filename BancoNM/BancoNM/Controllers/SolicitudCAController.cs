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
    public class SolicitudCAController : Controller
    {
        private BancoNMEntities db = new BancoNMEntities();

        // GET: SolicitudCA
        public ActionResult Index()
        {
            var solicitudCA = db.SolicitudCA.Include(s => s.Clientes);
            return View(solicitudCA.ToList());
        }

        // GET: SolicitudCA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudCA solicitudCA = db.SolicitudCA.Find(id);
            if (solicitudCA == null)
            {
                return HttpNotFound();
            }
            return View(solicitudCA);
        }

        // GET: SolicitudCA/Create
        public ActionResult Create()
        {
            ViewBag.idCliente = new SelectList(db.Clientes, "idCliente", "cedula");
            return View();
        }

        // POST: SolicitudCA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSolicitudCA,idCliente,ingresosM,justiIngreM,montoMin,fechaA")] SolicitudCA solicitudCA)
        {
            if (ModelState.IsValid)
            {
                db.SolicitudCA.Add(solicitudCA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCliente = new SelectList(db.Clientes, "idCliente", "cedula", solicitudCA.idCliente);
            return View(solicitudCA);
        }

        // GET: SolicitudCA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudCA solicitudCA = db.SolicitudCA.Find(id);
            if (solicitudCA == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente = new SelectList(db.Clientes, "idCliente", "cedula", solicitudCA.idCliente);
            return View(solicitudCA);
        }

        // POST: SolicitudCA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSolicitudCA,idCliente,ingresosM,justiIngreM,montoMin,fechaA")] SolicitudCA solicitudCA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitudCA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente = new SelectList(db.Clientes, "idCliente", "cedula", solicitudCA.idCliente);
            return View(solicitudCA);
        }

        // GET: SolicitudCA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudCA solicitudCA = db.SolicitudCA.Find(id);
            if (solicitudCA == null)
            {
                return HttpNotFound();
            }
            return View(solicitudCA);
        }

        // POST: SolicitudCA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SolicitudCA solicitudCA = db.SolicitudCA.Find(id);
            db.SolicitudCA.Remove(solicitudCA);
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
