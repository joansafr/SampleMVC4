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
    public class AlumnoController : Controller
    {
        private COLEGIOEntities db = new COLEGIOEntities();

        //
        // GET: /Alumno/

        public ActionResult Index()
        {
            return View(db.Alumnoes.ToList());
        }

        //
        // GET: /Alumno/Details/5

        public ActionResult Details(int id = 0)
        {
            Alumno alumno = db.Alumnoes.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        //
        // GET: /Alumno/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Alumno/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                db.Alumnoes.Add(alumno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alumno);
        }

        //
        // GET: /Alumno/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Alumno alumno = db.Alumnoes.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        //
        // POST: /Alumno/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alumno);
        }

        //
        // GET: /Alumno/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Alumno alumno = db.Alumnoes.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        //
        // POST: /Alumno/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alumno alumno = db.Alumnoes.Find(id);
            db.Alumnoes.Remove(alumno);
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