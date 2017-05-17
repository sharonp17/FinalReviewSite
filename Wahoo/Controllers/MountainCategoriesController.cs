using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wahoo.Models;

namespace Wahoo.Controllers
{
    public class MountainCategoriesController : Controller
    {
        private WahooContext db = new WahooContext();

        // GET: MountainCategories
        public ActionResult Index()
        {
            var mountainCategories = db.MountainCategories.Include(m => m.Review);
            return View(mountainCategories.ToList());
        }

        // GET: MountainCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MountainCategory mountainCategory = db.MountainCategories.Find(id);
            if (mountainCategory == null)
            {
                return HttpNotFound();
            }
            return View(mountainCategory);
        }

        // GET: MountainCategories/Create
        public ActionResult Create()
        {
            ViewBag.ReviewId = new SelectList(db.Reviews, "ReviewId", "ReviewerName");
            return View();
        }

        // POST: MountainCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,TrailName,TrailLocation,Elevation,ReviewId")] MountainCategory mountainCategory)
        {
            if (ModelState.IsValid)
            {
                db.MountainCategories.Add(mountainCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReviewId = new SelectList(db.Reviews, "ReviewId", "ReviewerName", mountainCategory.ReviewId);
            return View(mountainCategory);
        }

        // GET: MountainCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MountainCategory mountainCategory = db.MountainCategories.Find(id);
            if (mountainCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReviewId = new SelectList(db.Reviews, "ReviewId", "ReviewerName", mountainCategory.ReviewId);
            return View(mountainCategory);
        }

        // POST: MountainCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,TrailName,TrailLocation,Elevation,ReviewId")] MountainCategory mountainCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mountainCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReviewId = new SelectList(db.Reviews, "ReviewId", "ReviewerName", mountainCategory.ReviewId);
            return View(mountainCategory);
        }

        // GET: MountainCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MountainCategory mountainCategory = db.MountainCategories.Find(id);
            if (mountainCategory == null)
            {
                return HttpNotFound();
            }
            return View(mountainCategory);
        }

        // POST: MountainCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MountainCategory mountainCategory = db.MountainCategories.Find(id);
            db.MountainCategories.Remove(mountainCategory);
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
