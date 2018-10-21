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
            var vendorCourses = from vc in db.VendorCourses join vm in db.VehicleModels on vc.VehicleModel equals vm.VehicleModelId join v in db.Vehicles on vc.Vehicle equals v.VehicleId
                                join branch in db.VendorCompanies on vc.VendorCompanyId equals branch.VendorCompanyId
                                select new CourseVendor {BranchName=branch.BranchName,VehicleCompany=v.VehicleCompany,ModelName=vm.VehicleModelName,
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
                                 join vm in db.VehicleModels on vc.VehicleModel equals vm.VehicleModelId
                                 join v in db.Vehicles on vc.Vehicle equals v.VehicleId
                                 join branch in db.VendorCompanies on vc.VendorCompanyId equals branch.VendorCompanyId
                                 where vc.VendorCourseId == id
                                 select new CourseVendor
                                 { BranchName = branch.BranchName, VendorCourseId = vc.VendorCourseId , CourseTitle = vc.CourseTitle,VehicleCompany=v.VehicleCompany,ModelName=vm.VehicleModelName,
                                    VehicelTitle=vc.VehicleTitle,VehicleUrl=vc.VehicleUrl, Duration = vc.Duration, VendorPrice = vc.VendorPrice, ShortDescription = vc.ShortDescription, LongDescription = vc.LongDescription, Title = vc.Title, CourseUrl = vc.CourseUrl }).SingleOrDefault();
            if (vendorCourses == null)
            {
                return HttpNotFound();
            }
            return View(vendorCourses);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.VendorCompanyId = new SelectList(db.VendorCompanies, "VendorCompanyId", "BranchName");
            ViewBag.VehicleList = new SelectList(db.Vehicles, "VehicleId", "VehicleCompany");
            return View();
        }
        public JsonResult GetVehicleList(int VehicleId)

        {
            db.Configuration.ProxyCreationEnabled = false;
            List<VehicleModel> vehicleModels = db.VehicleModels.Where(v => v.VehicleId == VehicleId).ToList();
            return Json(vehicleModels, JsonRequestBehavior.AllowGet);
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
                    Vehicle=courseVendor.VehicleId,
                    VehicleModel=courseVendor.VehicleModelId,
                    ShortDescription=courseVendor.ShortDescription,
                    LongDescription=courseVendor.LongDescription,
                    Title=courseVendor.Title,
                    CourseUrl=courseVendor.CourseUrl,
                    VehicleTitle = courseVendor.VehicelTitle,
                    VehicleUrl = courseVendor.VehicleUrl,

                };
                db.VendorCourses.Add(vendorCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleList = new SelectList(db.Vehicles, "VehicleId", "VehicleCompany");
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
                                 join vm in db.VehicleModels on vc.VehicleModel equals vm.VehicleModelId
                                 join v in db.Vehicles on vc.Vehicle equals v.VehicleId
                                 where vc.VendorCourseId == id
                                 select new CourseVendor
                                 {
                                     VendorCourseId = vc.VendorCourseId,
                                     CourseTitle = vc.CourseTitle,
                                     VehicleCompany = v.VehicleCompany,
                                     ModelName = vm.VehicleModelName,
                                     VehicelTitle = vc.VehicleTitle,
                                     VehicleUrl = vc.VehicleUrl,
                                     Duration = vc.Duration,
                                     VendorPrice = vc.VendorPrice,
                                     ShortDescription = vc.ShortDescription,
                                     LongDescription = vc.LongDescription,
                                     Title = vc.Title,
                                     CourseUrl = vc.CourseUrl
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
                vendorCourse.CourseUrl = courseVendor.CourseUrl;
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
            var vendorCourses = (from vc in db.VendorCourses
                                 join vm in db.VehicleModels on vc.VehicleModel equals vm.VehicleModelId
                                 join v in db.Vehicles on vc.Vehicle equals v.VehicleId
                                 where vc.VendorCourseId == id
                                 select new CourseVendor
                                 {
                                     VendorCourseId = vc.VendorCourseId,
                                     CourseTitle = vc.CourseTitle,
                                     VehicleCompany = v.VehicleCompany,
                                     ModelName = vm.VehicleModelName,
                                     VehicelTitle = vc.VehicleTitle,
                                     VehicleUrl = vc.VehicleUrl,
                                     Duration = vc.Duration,
                                     VendorPrice = vc.VendorPrice,
                                     ShortDescription = vc.ShortDescription,
                                     LongDescription = vc.LongDescription,
                                     Title = vc.Title,
                                     CourseUrl = vc.CourseUrl
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
