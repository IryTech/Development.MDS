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
      //  int vendorCompanyId = (int) System.Web.HttpContext.Current.Session["VendorCompanyId"];
        // GET: VendorCourses
        public ActionResult Index()
        {
            var vendorCourses = from vc in db.VendorCourses select new CourseVendor {VendorCourseId=vc.VendorCourseId, VendorCompanyId=vc.VendorCompanyId,CourseTitle=vc.CourseTitle,Duration=vc.Duration,VendorPrice=vc.VendorPrice,ShortDescription=vc.ShortDescription, LongDescription=vc.LongDescription,Title=vc.Title,YourUrl=vc.YourUrl};
            return View(vendorCourses.ToList());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vendorCourses = (from vc in db.VendorCourses where vc.VendorCourseId == id select new CourseVendor { VendorCourseId = vc.VendorCourseId, CourseTitle = vc.CourseTitle, Duration = vc.Duration, VendorPrice = vc.VendorPrice, ShortDescription = vc.ShortDescription, LongDescription = vc.LongDescription, Title = vc.Title, YourUrl = vc.YourUrl }).SingleOrDefault();
            if (vendorCourses == null)
            {
                return HttpNotFound();
            }
            return View(vendorCourses);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.VendorCompanyId = new SelectList(db.VendorCompanies, "VendorCompanyId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendorCourseId,VendorCompanyId,CourseTitle,ShortDescription,LongDescription,Duration,VendorPrice,Title,YourUrl,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] CourseVendor courseVendor)
        {
            
            if (ModelState.IsValid)
            {
                VendorCourse vendorCourse = new VendorCourse()
                {
                    VendorCompanyId = courseVendor.VendorCompanyId,
                    CourseTitle = courseVendor.CourseTitle,
                    Duration = courseVendor.Duration,
                    VendorPrice=courseVendor.VendorPrice,
                    ShortDescription=courseVendor.ShortDescription,
                    LongDescription=courseVendor.LongDescription,
                    Title=courseVendor.Title,
                    YourUrl=courseVendor.YourUrl
                };

                db.VendorCourses.Add(vendorCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           // ViewBag.VendorCompanyId = new SelectList(db.VendorCompanies, "VendorCompanyId", "Name", vendorCourse.VendorCompanyId);
            return View(courseVendor);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vendorCourses = (from vc in db.VendorCourses where vc.VendorCourseId==id select new CourseVendor { VendorCourseId = vc.VendorCourseId, VendorCompanyId = vc.VendorCompanyId, CourseTitle = vc.CourseTitle, Duration = vc.Duration, VendorPrice = vc.VendorPrice, ShortDescription = vc.ShortDescription, LongDescription = vc.LongDescription, Title = vc.Title, YourUrl = vc.YourUrl }).SingleOrDefault();
            if (vendorCourses == null)
            {
                return HttpNotFound();
            }
           // ViewBag.VendorCompanyId = new SelectList(db.VendorCompanies, "VendorCompanyId", "Name", vendorCourse.VendorCompanyId);
            return View(vendorCourses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendorCourseId,VendorCompanyId,CourseTitle,ShortDescription,LongDescription,Duration,VendorPrice,Title,YourUrl,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] CourseVendor courseVendor,int id)
        {
            if (ModelState.IsValid)
            {
                VendorCourse vendorCourse = db.VendorCourses.Find(id);
                vendorCourse.CourseTitle = courseVendor.CourseTitle;
                vendorCourse.Duration = courseVendor.Duration;
                vendorCourse.VendorPrice = courseVendor.VendorPrice;
                vendorCourse.Title = courseVendor.Title;
                vendorCourse.YourUrl = courseVendor.YourUrl;
                db.Entry(vendorCourse).State = EntityState.Modified; 
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           // ViewBag.VendorCompanyId = new SelectList(db.VendorCompanies, "VendorCompanyId", "Name", vendorCourse.VendorCompanyId);
            return View(courseVendor);
        }

       [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vendorCourses = (from vc in db.VendorCourses where vc.VendorCourseId == id select new CourseVendor { VendorCourseId = vc.VendorCourseId, VendorCompanyId = vc.VendorCompanyId, CourseTitle = vc.CourseTitle, Duration = vc.Duration, VendorPrice = vc.VendorPrice, ShortDescription = vc.ShortDescription, LongDescription = vc.LongDescription, Title = vc.Title, YourUrl = vc.YourUrl }).SingleOrDefault();
            if (vendorCourses == null)
            {
                return HttpNotFound();
            }
            return View(vendorCourses);
        }

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
