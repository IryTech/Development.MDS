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
    public class AreaCoversController : Controller
    {
        private MdsDbContext db = new MdsDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            var areaCovers = from ac in db.AreaCovers select new AreaVendor { AreaCoverId = ac.AreaCoverId, AreaName = ac.AreaName, PopularName = ac.PopularName, Title = ac.Title, YourUrl = ac.YourUrl };
            return View(areaCovers.ToList());
            //var areaCovers = db.AreaCovers.Include(a => a.VendorCompany);
            //return View(areaCovers.ToList());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var areaCovers = (from ac in db.AreaCovers where ac.AreaCoverId == id select new AreaVendor { AreaCoverId = ac.AreaCoverId, AreaName = ac.AreaName, PopularName = ac.PopularName, Title = ac.Title, YourUrl = ac.YourUrl }).SingleOrDefault();
            if (areaCovers == null)
            {
                return HttpNotFound();
            }
            return View(areaCovers);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.VendorCompanyId = new SelectList(db.VendorCompanies, "VendorCompanyId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AreaCoverId,VendorCompanyId,AreaName,PopularName,Title,YourUrl")] AreaVendor areaVendor)
        {
           
            if (ModelState.IsValid)
            {
                AreaCover areaCover = new AreaCover()
                {
                    //VendorCompanyId =(int)System.Web.HttpContext.Current.Session["vendorBranchid"],
                    //ViewBag.CompanyId = new SelectList(db.VendorCompanies, "VendorCompanyId", "Name"),
                    VendorCompanyId=areaVendor.VendorCompanyId,
                    AreaName = areaVendor.AreaName,
                    PopularName=areaVendor.PopularName,
                    Title=areaVendor.Title,
                    YourUrl=areaVendor.YourUrl
                };
                db.AreaCovers.Add(areaCover);
                db.SaveChanges();
                ViewBag.VendorCompanyId = new SelectList(db.VendorCompanies, "VendorCompanyId", "Name", areaCover.VendorCompanyId);
                return RedirectToAction("Index");
            }
            return View(areaVendor);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var areaCovers = (from ac in db.AreaCovers where ac.AreaCoverId == id select new AreaVendor { AreaCoverId = ac.AreaCoverId, AreaName = ac.AreaName, PopularName = ac.PopularName, Title = ac.Title, YourUrl = ac.YourUrl }).SingleOrDefault();
            if (areaCovers == null)
            {
                return HttpNotFound();
            }
            return View(areaCovers);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AreaCoverId,VendorCompanyId,AreaName,PopularName,Title,YourUrl,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] AreaVendor areaVendor,int id)
        {
            if (ModelState.IsValid)
            {
                AreaCover areaCover = db.AreaCovers.Find(id);
                areaCover.AreaName = areaVendor.AreaName;
                areaCover.PopularName = areaVendor.PopularName;
                areaCover.Title = areaVendor.PopularName;
                areaCover.YourUrl = areaVendor.YourUrl;
                db.Entry(areaCover).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(areaVendor);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var areaCovers = (from ac in db.AreaCovers where ac.AreaCoverId == id select new AreaVendor { AreaCoverId = ac.AreaCoverId,VendorCompanyId=ac.VendorCompanyId, AreaName = ac.AreaName, PopularName = ac.PopularName, Title = ac.Title, YourUrl = ac.YourUrl }).SingleOrDefault();
            if (areaCovers == null)
            {
                return HttpNotFound();
            }
            return View(areaCovers);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AreaCover areaCover = db.AreaCovers.Find(id);
            db.AreaCovers.Remove(areaCover);
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
