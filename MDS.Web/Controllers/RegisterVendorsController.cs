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
    public class RegisterVendorsController : Controller
    {
        private MdsDbContext db = new MdsDbContext();
         
        // GET: Vendors
        public ActionResult Index()
        {
            var registerVendors = from s in db.Vendors select new RegisterVendor {VendorId=s.VendorId, FirstName= s.FirstName, LastName=s.LastName,Mobile=s.Mobile, Email=s.Email, Password=s.Password};
           
            return View(registerVendors.ToList());
        }

        // GET: Vendors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var registerVendor = (from item in db.Vendors
                                 where item.VendorId == id
                                 select new RegisterVendor {VendorId =item.VendorId, FirstName = item.FirstName, LastName = item.LastName, Mobile = item.Mobile, Password = item.Password, Email = item.Email }).SingleOrDefault();

            return View(registerVendor);
        }

        // GET: Vendors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendorId,FirstName,LastName,Email,Mobile,Password,ConfirmPassword,Designation,DateofBirth,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] RegisterVendor  registerVendor)
        {
            if (ModelState.IsValid)
            {
                Vendor vendor = new Vendor()
                {
                    FirstName = registerVendor.FirstName,
                    LastName=registerVendor.LastName ,
                    Mobile=registerVendor.Mobile,
                    Email=registerVendor.Email,
                    Password=registerVendor.Password,
                    CreatedOn=DateTime.Now,                   
                };
                db.Vendors.Add(vendor);
                db.SaveChanges();
                Session["vendorId"] = vendor.VendorId;
                return RedirectToAction("Create","BranchVendors");
            }

            return View(registerVendor);
        }

        // GET: Vendors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var registerVendor = (from item in db.Vendors
                                  where item.VendorId == id
                                  select new RegisterVendor { FirstName = item.FirstName, LastName = item.LastName, Mobile = item.Mobile, Password = item.Password, Email = item.Email }).SingleOrDefault();
            if (registerVendor == null)
            {
                return HttpNotFound();
            }
            return View(registerVendor);
        }

        // POST: Vendors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendorId,FirstName,LastName,Email,Mobile,Password,ConfirmPassword,Designation,DateofBirth,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] RegisterVendor registerVendor, int id)
        {

            if (ModelState.IsValid)
            {
                Vendor vendor = db.Vendors.Find(id);
                vendor.FirstName = registerVendor.FirstName;
                vendor.LastName = registerVendor.LastName;
                vendor.Mobile = registerVendor.Mobile;
                vendor.Email = registerVendor.Email;
                vendor.Password = registerVendor.Password;
                db.Entry(vendor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registerVendor);
        }

        // GET: Vendors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var registerVendor = (from item in db.Vendors
                                  where item.VendorId == id
                                  select new RegisterVendor { FirstName = item.FirstName, LastName = item.LastName, Mobile = item.Mobile, Password = item.Password, Email = item.Email }).SingleOrDefault();
            if (registerVendor == null)
            {
                return HttpNotFound();
            }
            return View(registerVendor);
        }

        // POST: Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendor vendor = db.Vendors.Find(id);
            db.Vendors.Remove(vendor);
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
