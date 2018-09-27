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
    public class BankDetailsController : Controller
    {
        private MdsDbContext db = new MdsDbContext();

        // GET: BankDetails
        public ActionResult Index()
        {
            var bankDetails = from bk in db.BankDetails select new BankDetailsVendor { BankDetailsId = bk.BankDetailsId, BankName = bk.BankName, AccountHolderName = bk.AccountHolderName, AccountNumber = bk.AccountNumber, IFSC = bk.IFSC };
            return View(bankDetails.ToList());
        }

        // GET: BankDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bankDetails = (from bk in db.BankDetails where bk.BankDetailsId == id select new BankDetailsVendor { BankDetailsId = bk.BankDetailsId, BankName = bk.BankName, AccountHolderName = bk.AccountHolderName, AccountNumber = bk.AccountNumber, IFSC = bk.IFSC }).SingleOrDefault();
            if (bankDetails == null)
            {
                return HttpNotFound();
            }
            return View(bankDetails);
        }

        // GET: BankDetails/Create
        [HttpGet]
        public ActionResult Create()
        {
           // ViewBag.VendorId = new SelectList(db.Vendors, "VendorId", "FirstName");
            return View();
        }

        // POST: BankDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Create( BankDetailsVendor bankDetailsVendor)
        {
            if (ModelState.IsValid)
            {
                BankDetail bankDetail = new BankDetail()
                {
                    VendorId = (int)System.Web.HttpContext.Current.Session["vendorid"],
                    BankName=bankDetailsVendor.BankName,
                    AccountHolderName = bankDetailsVendor.AccountHolderName,
                    AccountNumber = bankDetailsVendor.AccountNumber,
                    IFSC = bankDetailsVendor.IFSC
                };                
                db.BankDetails.Add(bankDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.VendorId = new SelectList(db.Vendors, "VendorId", "FirstName", bankDetail.VendorId);
            return View(bankDetailsVendor);
        }

        // GET: BankDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bankDetails = (from bk in db.BankDetails where bk.BankDetailsId == id select new BankDetailsVendor { BankDetailsId = bk.BankDetailsId,BankName=bk.BankName, AccountHolderName = bk.AccountHolderName, AccountNumber = bk.AccountNumber, IFSC = bk.IFSC }).SingleOrDefault();
            if (bankDetails == null)
            {
                return HttpNotFound();
            }
            //ViewBag.VendorId = new SelectList(db.Vendors, "VendorId", "FirstName", bankDetail.VendorId);
            return View(bankDetails);
        }

        // POST: BankDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BankDetailsId,VendorId,AccountHolderName,AccountNumber,ConfirmAccountNumber,IFSC,BankName,State,City,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] BankDetailsVendor bankDetailsVendor, int id)
        {
            if (ModelState.IsValid)
            {
                BankDetail bankDetail = db.BankDetails.Find(id);
                bankDetail.BankName = bankDetailsVendor.BankName;
                bankDetail.AccountHolderName = bankDetailsVendor.AccountHolderName;
                bankDetail.AccountNumber = bankDetailsVendor.AccountNumber;
                bankDetail.IFSC = bankDetailsVendor.IFSC;              
                db.Entry(bankDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           // ViewBag.VendorId = new SelectList(db.Vendors, "VendorId", "FirstName", bankDetail.VendorId);
            return View(bankDetailsVendor);
        }

        // GET: BankDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bankDetails = (from bk in db.BankDetails where bk.BankDetailsId == id select new BankDetailsVendor { BankDetailsId = bk.BankDetailsId,BankName=bk.BankName, AccountHolderName = bk.AccountHolderName, AccountNumber = bk.AccountNumber, IFSC = bk.IFSC }).SingleOrDefault();
            if (bankDetails == null)
            {
                return HttpNotFound();
            }
            return View(bankDetails);
        }

        // POST: BankDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BankDetail bankDetail = db.BankDetails.Find(id);
            db.BankDetails.Remove(bankDetail);
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
