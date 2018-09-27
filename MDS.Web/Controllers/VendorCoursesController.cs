using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MDS.Core;
using MDS.Web.Models.Vendors;

namespace MDS.Web.Controllers
{
    public class VendorCoursesController : Controller
    {
        private MdsDbContext db = new MdsDbContext();
        int vendorCompanyId = (int) System.Web.HttpContext.Current.Session["VendorCompanyId"];
        // GET: VendorCourses
        public ActionResult Index()
        {
            var vendorCourses = db.VendorCourses.Include(v => v.VendorCompany);
            return View(vendorCourses.ToList());
        }

        // GET: VendorCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorCourse vendorCourse = db.VendorCourses.Find(id);
            if (vendorCourse == null)
            {
                return HttpNotFound();
            }
            return View(vendorCourse);
        }

        // GET: VendorCourses/Create
        public ActionResult Create()
        {
            ViewBag.VendorCompanyId = new SelectList(db.VendorCompanies, "VendorCompanyId", "Name");
            return View();
        }

        // POST: VendorCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendorCourseId,VendorCompanyId,CourseTitle,ShortDescription,LongDescription,Duration,VendorPrice,Title,YourUrl,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] VendorCourse vendorCourse)
        {
            if (ModelState.IsValid)
            {
                db.VendorCourses.Add(vendorCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VendorCompanyId = new SelectList(db.VendorCompanies, "VendorCompanyId", "Name", vendorCourse.VendorCompanyId);
            return View(vendorCourse);
        }

        // GET: VendorCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorCourse vendorCourse = db.VendorCourses.Find(id);
            if (vendorCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.VendorCompanyId = new SelectList(db.VendorCompanies, "VendorCompanyId", "Name", vendorCourse.VendorCompanyId);
            return View(vendorCourse);
        }

        // POST: VendorCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendorCourseId,VendorCompanyId,CourseTitle,ShortDescription,LongDescription,Duration,VendorPrice,Title,YourUrl,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] VendorCourse vendorCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendorCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VendorCompanyId = new SelectList(db.VendorCompanies, "VendorCompanyId", "Name", vendorCourse.VendorCompanyId);
            return View(vendorCourse);
        }

        // GET: VendorCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorCourse vendorCourse = db.VendorCourses.Find(id);
            if (vendorCourse == null)
            {
                return HttpNotFound();
            }
            return View(vendorCourse);
        }

        // POST: VendorCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VendorCourse vendorCourse = db.VendorCourses.Find(id);
            db.VendorCourses.Remove(vendorCourse);
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
