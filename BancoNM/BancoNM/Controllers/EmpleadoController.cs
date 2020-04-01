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
    public class EmpleadoController : Controller
    {
        private BancoNMEntities db = new BancoNMEntities();

        // GET: Empleado
        public ActionResult Index()
        {
            var empleado = db.Empleado.Include(e => e.Cargos).Include(e => e.Departamentos).Include(e => e.Nacionalidad);
            return View(empleado.ToList());
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewBag.idCargo = new SelectList(db.Cargos, "idCargo", "descripcion");
            ViewBag.idDepartamento = new SelectList(db.Departamentos, "idDepartamento", "descripcion");
            ViewBag.idNacionalidad = new SelectList(db.Nacionalidad, "idNacionalidad", "descripcion");
            return View();
        }

        // POST: Empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEmpleado,idCargo,idDepartamento,idNacionalidad,nombre,apellido,cedula,fechaNac,correo,celular,fechaIngreso,salario")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCargo = new SelectList(db.Cargos, "idCargo", "descripcion", empleado.idCargo);
            ViewBag.idDepartamento = new SelectList(db.Departamentos, "idDepartamento", "descripcion", empleado.idDepartamento);
            ViewBag.idNacionalidad = new SelectList(db.Nacionalidad, "idNacionalidad", "descripcion", empleado.idNacionalidad);
            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCargo = new SelectList(db.Cargos, "idCargo", "descripcion", empleado.idCargo);
            ViewBag.idDepartamento = new SelectList(db.Departamentos, "idDepartamento", "descripcion", empleado.idDepartamento);
            ViewBag.idNacionalidad = new SelectList(db.Nacionalidad, "idNacionalidad", "descripcion", empleado.idNacionalidad);
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEmpleado,idCargo,idDepartamento,idNacionalidad,nombre,apellido,cedula,fechaNac,correo,celular,fechaIngreso,salario")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCargo = new SelectList(db.Cargos, "idCargo", "descripcion", empleado.idCargo);
            ViewBag.idDepartamento = new SelectList(db.Departamentos, "idDepartamento", "descripcion", empleado.idDepartamento);
            ViewBag.idNacionalidad = new SelectList(db.Nacionalidad, "idNacionalidad", "descripcion", empleado.idNacionalidad);
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleado.Find(id);
            db.Empleado.Remove(empleado);
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

        [HttpGet]
        public ActionResult Consulta()
        {
            var empleado = db.Empleado.Include(e => e.Cargos).Include(e => e.Departamentos).Include(e => e.Nacionalidad);
            return View(empleado.ToList());
        }

        [HttpPost]
        public ActionResult Consulta(int? salario, DateTime? fechaIngreso, DateTime? fechaNacimiento, 
            string cedulaEmpleado =null, string nombreEmpleado=null, string apellidoEmpleado=null,
            string correoEmpleado=null, string celularEmpleado=null)
        {
            var busqueda = from s in db.Empleado select s;
            if(salario != null)
            {
                busqueda = busqueda.Where(f => f.salario == salario);
            }
            if(fechaIngreso != null)
            {
                busqueda = busqueda.Where(f => f.fechaIngreso == fechaIngreso);
            }
            if(fechaNacimiento!= null)
            {
                busqueda = busqueda.Where(f => f.fechaNac == fechaNacimiento);
            }
            if(!string.IsNullOrEmpty(cedulaEmpleado))
            {
                busqueda = busqueda.Where(f => f.cedula.StartsWith(cedulaEmpleado));
            }
            if (!string.IsNullOrEmpty(nombreEmpleado))
            {
                busqueda = busqueda.Where(f => f.nombre == nombreEmpleado);
            }
            if (!string.IsNullOrEmpty(apellidoEmpleado))
            {
                busqueda = busqueda.Where(f => f.apellido == apellidoEmpleado);
            }
            if (!string.IsNullOrEmpty(correoEmpleado))
            {
                busqueda = busqueda.Where(f => f.correo == correoEmpleado);
            }
            if (!string.IsNullOrEmpty(celularEmpleado))
            {
                busqueda = busqueda.Where(f => f.celular.StartsWith(celularEmpleado));
            }
            return View(busqueda.ToList());
        }
    }
}
