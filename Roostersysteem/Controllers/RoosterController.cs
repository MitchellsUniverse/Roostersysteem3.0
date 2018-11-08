using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Roostersysteem.Models;

namespace Roostersysteem.Controllers
{
    public class RoosterController : Controller
    {
        private RoosterDB db = new RoosterDB();

        // GET: Rooster
        public ActionResult Index()
        {
            var roosters = db.Roosters.Include(r => r.PersoonVak).Include(r => r.VakLokaalType).Include(r => r.VakUrenCollege);
            return View(roosters.ToList());
        }

        // GET: Rooster/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rooster rooster = db.Roosters.Find(id);
            if (rooster == null)
            {
                return HttpNotFound();
            }
            return View(rooster);
        }

        // GET: Rooster/Create
        public ActionResult Create()
        {
            ViewBag.PersoonVak_Id = new SelectList(db.PersoonVaks, "PersoonVak_Id", "PersoonVak_Id");
            ViewBag.VakLokaalType_Id = new SelectList(db.VakLokaalTypes, "VakLokaalType_Id", "VakLokaalType_Id");
            ViewBag.VakUrenCollege_Id = new SelectList(db.VakUrenColleges, "VakUrenCollege_Id", "VakUrenCollege_Id");
            return View();
        }

        // POST: Rooster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoosterId,PersoonVak_Id,VakUrenCollege_Id,Klas,VakLokaalType_Id")] Rooster rooster)
        {
            if (ModelState.IsValid)
            {
                db.Roosters.Add(rooster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersoonVak_Id = new SelectList(db.PersoonVaks, "PersoonVak_Id", "PersoonVak_Id", rooster.PersoonVak_Id);
            ViewBag.VakLokaalType_Id = new SelectList(db.VakLokaalTypes, "VakLokaalType_Id", "VakLokaalType_Id", rooster.VakLokaalType_Id);
            ViewBag.VakUrenCollege_Id = new SelectList(db.VakUrenColleges, "VakUrenCollege_Id", "VakUrenCollege_Id", rooster.VakUrenCollege_Id);
            return View(rooster);
        }

        // GET: Rooster/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rooster rooster = db.Roosters.Find(id);
            if (rooster == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersoonVak_Id = new SelectList(db.PersoonVaks, "PersoonVak_Id", "PersoonVak_Id", rooster.PersoonVak_Id);
            ViewBag.VakLokaalType_Id = new SelectList(db.VakLokaalTypes, "VakLokaalType_Id", "VakLokaalType_Id", rooster.VakLokaalType_Id);
            ViewBag.VakUrenCollege_Id = new SelectList(db.VakUrenColleges, "VakUrenCollege_Id", "VakUrenCollege_Id", rooster.VakUrenCollege_Id);
            return View(rooster);
        }

        // POST: Rooster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoosterId,PersoonVak_Id,VakUrenCollege_Id,Klas,VakLokaalType_Id")] Rooster rooster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rooster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersoonVak_Id = new SelectList(db.PersoonVaks, "PersoonVak_Id", "PersoonVak_Id", rooster.PersoonVak_Id);
            ViewBag.VakLokaalType_Id = new SelectList(db.VakLokaalTypes, "VakLokaalType_Id", "VakLokaalType_Id", rooster.VakLokaalType_Id);
            ViewBag.VakUrenCollege_Id = new SelectList(db.VakUrenColleges, "VakUrenCollege_Id", "VakUrenCollege_Id", rooster.VakUrenCollege_Id);
            return View(rooster);
        }

        // GET: Rooster/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rooster rooster = db.Roosters.Find(id);
            if (rooster == null)
            {
                return HttpNotFound();
            }
            return View(rooster);
        }

        // POST: Rooster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rooster rooster = db.Roosters.Find(id);
            db.Roosters.Remove(rooster);
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
