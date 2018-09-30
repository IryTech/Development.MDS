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
        public ActionResult Index(string search)
        {
            var vendorCourses = from vc in db.VendorCourses join vt in db.VehicleTypes on vc.VendorCourseId equals vt.VendorCourseId join v in db.Vehicles on vt.VendorCourseId equals v.VendorCourseId
                                select new CourseVendor {VendorCourseId=vc.VendorCourseId, VendorCompanyId=vc.VendorCompanyId,WhealsType=vt.WhealsType,VehicleCompany=v.VehicleCompany,VehicleModel=v.VehicleModel,
                                    CourseTitle = vc.CourseTitle,Duration=vc.Duration,VendorPrice=vc.VendorPrice};
            if (search == null)
            {
                return View(vendorCourses.ToList());
            }
            else
            {
                return View(vendorCourses.Where(x => x.CourseTitle.StartsWith(search)).ToList());
            }
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vendorCourses = (from vc in db.VendorCourses
                                 join vt in db.VehicleTypes on vc.VendorCourseId equals vt.VendorCourseId
                                 join v in db.Vehicles on vt.VendorCourseId equals v.VendorCourseId
                                 where vc.VendorCourseId == id|| vt.VehicleTypesId==id || v.VehicleTypesId==id
                                 select new CourseVendor
                                 { VendorCourseId = vc.VendorCourseId , CourseTitle = vc.CourseTitle,WhealsType=vt.WhealsType,VehicleCompany=v.VehicleCompany,VehicleModel=v.VehicleModel,
                                    VehicelTitle=v.VehicleTitle,VehicleUrl=v.VehicleUrl, Duration = vc.Duration, VendorPrice = vc.VendorPrice, ShortDescription = vc.ShortDescription, LongDescription = vc.LongDescription, Title = vc.Title, YourUrl = vc.YourUrl }).SingleOrDefault();
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
        public ActionResult Create( CourseVendor courseVendor)
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
                VehicleType vehicleType = new VehicleType()
                {
                    VendorCourseId=courseVendor.VendorCourseId,
                    WhealsType=courseVendor.WhealsType,
                };
                db.VehicleTypes.Add(vehicleType);
                Vehicle vehicle = new Vehicle()
                {
                    VendorCourseId=courseVendor.VendorCourseId,
                    VehicleCompany=courseVendor.VehicleCompany,
                    VehicleModel=courseVendor.VehicleModel,
                    VehicleTitle=courseVendor.VehicleModel,
                    VehicleUrl=courseVendor.VehicleUrl,
                };
                db.Vehicles.Add(vehicle);
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
            var vendorCourses = (from vc in db.VendorCourses
                                 join v in db.Vehicles on vc.VendorCourseId equals v.VendorCourseId
                                 join vt in db.VehicleTypes on v.VendorCourseId equals vt.VendorCourseId
                                 where vc.VendorCourseId == id && v.VendorCourseId==id && vt.VendorCourseId==id
                                 select new CourseVendor
                                 {
                                     //VendorCourseId = vc.VendorCourseId,
                                     CourseTitle = vc.CourseTitle,
                                     WhealsType = vt.WhealsType,
                                     VehicleCompany = v.VehicleCompany,
                                     VehicleModel = v.VehicleModel,
                                     VehicelTitle = v.VehicleTitle,
                                     VehicleUrl = v.VehicleUrl,
                                     Duration = vc.Duration,
                                     VendorPrice = vc.VendorPrice,
                                     ShortDescription = vc.ShortDescription,
                                     LongDescription = vc.LongDescription,
                                     Title = vc.Title,
                                     YourUrl = vc.YourUrl
                                 }).SingleOrDefault();
            if (vendorCourses == null)
            {
                return HttpNotFound();
            }
           // ViewBag.VendorCompanyId = new SelectList(db.VendorCompanies, "VendorCompanyId", "Name", vendorCourse.VendorCompanyId);
            return View(vendorCourses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( CourseVendor courseVendor,int id)
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

                VehicleType vehicleType = db.VehicleTypes.Find(id);
                vehicleType.WhealsType = courseVendor.WhealsType;
                db.Entry(vehicleType).State = EntityState.Modified;

                Vehicle vehicle = db.Vehicles.Find(id);
                var key1 = db.Vehicles.Find(vehicle.VendorCourseId);
                vehicle.VehicleCompany = courseVendor.VehicleCompany;
                vehicle.VehicleModel = courseVendor.VehicleModel;
                vehicle.VehicleTitle = courseVendor.CourseTitle;
                vehicle.VehicleUrl = courseVendor.VehicleUrl;
                db.Entry(vehicle).State = EntityState.Modified;
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
            var vendorCourses = (from vc in db.VendorCourses
                                 join vt in db.VehicleTypes on vc.VendorCourseId equals vt.VendorCourseId
                                 join v in db.Vehicles on vt.VendorCourseId equals v.VendorCourseId
                                 where v.VendorCourseId==id 
                                 select new CourseVendor
                                 {
                                     
                                     
                                     CourseTitle = vc.CourseTitle,
                                     WhealsType = vt.WhealsType,
                                     VehicleCompany = v.VehicleCompany,
                                     VehicleModel = v.VehicleModel,
                                     VehicelTitle = v.VehicleTitle,
                                     VehicleUrl = v.VehicleUrl,
                                     Duration = vc.Duration,
                                     VendorPrice = vc.VendorPrice,
                                     ShortDescription = vc.ShortDescription,
                                     LongDescription = vc.LongDescription,
                                     Title = vc.Title,
                                     YourUrl = vc.YourUrl
                                 }).SingleOrDefault();

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
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            VehicleType vehicleType = db.VehicleTypes.Find(id);
            db.VehicleTypes.Remove(vehicleType);
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
