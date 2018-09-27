using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MDS.Core;
using MDS.Web.Models.Vendors;

namespace MDS.Web.Controllers
{
    public class BranchVendorsController : Controller
    {
        MdsDbContext db = new MdsDbContext();
        // GET: BranchVendors
        public ActionResult Index()
        {
            //var vendorId = (int)System.Web.HttpContext.Current.Session["vendorid"];
            //Vendor vendor = db.Vendors.Find(vendorId);
            //var vendorName = vendor.FirstName;

            var branchVendor = (from vc in db.VendorCompanies  
                                join v in db.Vendors on vc.VendorId equals v.VendorId
                               join vm in db.VendorImages on vc.VendorCompanyId equals vm.VendorCompanyId
                               select new BranchVendor { VendorCompanyId = vc.VendorCompanyId, VendorName=v.FirstName,
                               Name = vc.Name, ImageName = vm.ImageName, ShortDescription = vc.ShortDescription, LongDescription = vc.LongDescription,
                               Email = vc.Email, Mobile = vc.Mobile, Country = vc.Country, State = vc.State, City = vc.City, Street = vc.Street,
                               ZIPCode = vc.ZIPCode, AddressLine1 = vc.AddressLine1, AddressLine2 = vc.AddressLine2 } );

            

            return View(branchVendor.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(BranchVendor branchVendor)
           
        {
            if(ModelState.IsValid)
            {
                VendorCompany vendorCompany = new VendorCompany()
                {
                    VendorId = (int)System.Web.HttpContext.Current.Session["vendorid"],
                    Name = branchVendor.Name,
                    ShortDescription=branchVendor.ShortDescription,
                    LongDescription=branchVendor.LongDescription,
                    Email=branchVendor.Email,
                    Mobile=branchVendor.Mobile,
                    Country=branchVendor.Country,
                    State=branchVendor.State,
                    City=branchVendor.City,
                    Street=branchVendor.Street,
                    ZIPCode=branchVendor.ZIPCode,
                    AddressLine1=branchVendor.AddressLine1,
                    AddressLine2=branchVendor.AddressLine2,
                   // CreatedOn=DateTime.Now                   
                };                
                //db.VendorCompanies.Add(vendorCompany);
               // db.SaveChanges();
                
                var vendorCompanyId = vendorCompany.VendorCompanyId;
                db.VendorCompanies.Add(vendorCompany);

                VendorImage vendorImage = new VendorImage()
                {
                    VendorCompanyId = vendorCompanyId,
                    ImageName = branchVendor.ImageName,
                    ImageLocation = branchVendor.ImageLocation
                };
                db.VendorImages.Add(vendorImage);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int? id)
       {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var branchDetail = (from vc in db.VendorCompanies
                                join vm in db.VendorImages on vc.VendorCompanyId equals vm.VendorCompanyId
                                where vc.VendorCompanyId == id
                                select new BranchVendor
                                {
                                    Name = vc.Name,
                                    Mobile = vc.Mobile,
                                    Email = vc.Email,
                                    Country = vc.Country,
                                    State = vc.State,
                                    City = vc.City,
                                    Street = vc.Street,
                                    ZIPCode = vc.ZIPCode,
                                    AddressLine1 = vc.AddressLine1,
                                    AddressLine2 = vc.AddressLine2,
                                    ShortDescription = vc.ShortDescription,
                                    LongDescription = vc.LongDescription,
                                    ImageName = vm.ImageName,
                                }).SingleOrDefault();
            return View(branchDetail);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var branchVendor = (from vc in db.VendorCompanies
                                join vm in db.VendorImages on vc.VendorCompanyId equals vm.VendorCompanyId
                                where vc.VendorCompanyId == id
                                select new BranchVendor
                                {
                                    Name = vc.Name,
                                    Mobile = vc.Mobile,
                                    Email = vc.Email,
                                    Country = vc.Country,
                                    State = vc.State,
                                    City = vc.City,
                                    Street = vc.Street,
                                    ZIPCode = vc.ZIPCode,
                                    AddressLine1 = vc.AddressLine1,
                                    AddressLine2 = vc.AddressLine2,
                                    ShortDescription = vc.ShortDescription,
                                    LongDescription = vc.LongDescription,
                                    ImageName = vm.ImageName,
                                }).SingleOrDefault();
            if (branchVendor== null)
            {
                return HttpNotFound();
            }
            return View(branchVendor);
        }
        [HttpPost]
        public ActionResult Edit(BranchVendor branchVendor ,int id)
        {
            if (ModelState.IsValid)
            {
                VendorCompany vc   = db.VendorCompanies.Find(id);
                branchVendor.Name = vc.Name;
                branchVendor.Mobile = vc.Mobile;
                branchVendor.Email = vc.Email;
                branchVendor.Country = vc.Country;
                branchVendor.State = vc.State;
                branchVendor.City = vc.City;
                branchVendor.Street = vc.Street;
                branchVendor.ZIPCode = vc.ZIPCode;
                branchVendor.AddressLine1 = vc.AddressLine1;
                branchVendor.AddressLine2 = vc.AddressLine2;
                branchVendor.ShortDescription = vc.ShortDescription;
                branchVendor.LongDescription = vc.LongDescription;                  
                db.Entry(vc).State = EntityState.Modified;
                VendorImage vendorImage = db.VendorImages.Find(id);
                branchVendor.ImageName = vendorImage.ImageName;
                db.Entry(vendorImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(branchVendor);
        }

    }
}