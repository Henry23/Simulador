using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Simulador.Models;

namespace Simulador.Controllers
{
    public class DatosController : Controller
    {
        private DatiosModel db = new DatiosModel();

        // GET: Datos
        public ActionResult Index()
        {
            return View(db.Datos.ToList());
        }

        // GET: Datos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dato dato = db.Datos.Find(id);
            if (dato == null)
            {
                return HttpNotFound();
            }
            return View(dato);
        }

        // GET: Datos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Datos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,cap_max_tanque,temp_inicial_tanque,material_tanque,resistencia_watts,cant_ml_s,cant_ml_incial")] Dato dato)
        {
            if (ModelState.IsValid)
            {
                db.Datos.Add(dato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dato);
        }

        // GET: Datos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dato dato = db.Datos.Find(id);
            if (dato == null)
            {
                return HttpNotFound();
            }
            return View(dato);
        }

        // POST: Datos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,cap_max_tanque,temp_inicial_tanque,material_tanque,resistencia_watts,cant_ml_s,cant_ml_incial")] Dato dato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dato);
        }

        // GET: Datos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dato dato = db.Datos.Find(id);
            if (dato == null)
            {
                return HttpNotFound();
            }
            return View(dato);
        }

        // POST: Datos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dato dato = db.Datos.Find(id);
            db.Datos.Remove(dato);
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
