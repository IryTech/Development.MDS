using System;
using System.Collections.Generic;
using System.Linq;
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
            var branchVendor = (from vc in db.VendorCompanies
                               join vm in db.VendorImages on vc.VendorCompanyId equals vm.VendorCompanyId select new BranchVendor { VendorCompanyId = vc.VendorCompanyId, Name = vc.Name, ImageName = vm.ImageName, ShortDescription = vc.ShortDescription, LongDescription = vc.LongDescription, Email = vc.Email, Mobile = vc.Mobile, Country = vc.Country, State = vc.State, City = vc.City, Street = vc.Street, ZIPCode = vc.ZIPCode, AddressLine1 = vc.AddressLine1, AddressLine2 = vc.AddressLine2 });
                             
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
                    CreatedOn=DateTime.Now                   
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

    }
}