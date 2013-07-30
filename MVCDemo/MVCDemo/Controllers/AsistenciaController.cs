using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class AsistenciaController : Controller
    {
        private COLEGIOEntities db = new COLEGIOEntities();

        //
        // GET: /Asistencia/

        public ActionResult Index()
        {
            var asistencias = db.Asistencias.Include(a => a.Alumno);
            return View(asistencias.ToList());
        }

        //
        // GET: /Asistencia/Details/5

        public ActionResult Details(int id = 0)
        {
            Asistencia asistencia = db.Asistencias.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        //
        // GET: /Asistencia/Create

        public ActionResult Create()
        {
            ViewBag.CodigoAlumno = new SelectList(db.Alumnoes, "CodigoAlumno", "Nombre");
            return View();
        }

        //
        // POST: /Asistencia/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Asistencias.Add(asistencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoAlumno = new SelectList(db.Alumnoes, "CodigoAlumno", "Nombre", asistencia.CodigoAlumno);
            return View(asistencia);
        }

        //
        // GET: /Asistencia/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Asistencia asistencia = db.Asistencias.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoAlumno = new SelectList(db.Alumnoes, "CodigoAlumno", "Nombre", asistencia.CodigoAlumno);
            return View(asistencia);
        }

        //
        // POST: /Asistencia/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asistencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoAlumno = new SelectList(db.Alumnoes, "CodigoAlumno", "Nombre", asistencia.CodigoAlumno);
            return View(asistencia);
        }

        //
        // GET: /Asistencia/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Asistencia asistencia = db.Asistencias.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        //
        // POST: /Asistencia/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asistencia asistencia = db.Asistencias.Find(id);
            db.Asistencias.Remove(asistencia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}