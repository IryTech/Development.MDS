using MDS.Core;
using MDS.Web.Models.Vendors;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MDS.Web.Controllers
{
    public class BranchVendorsController : Controller
    {
        MdsDbContext db = new MdsDbContext();
        // GET: BranchVendors
        public ActionResult Index(string search)
        {
            var branchVendor = (from vc in db.VendorCompanies  
                                join v in db.Vendors on vc.VendorId equals v.VendorId join s in db.States on vc.State equals s.StateId
                                join c in db.Cities on vc.City equals c.CityId
                                join vi in db.VendorImages on vc.VendorCompanyId equals vi.VendorCompanyId
                               select new BranchVendor { VendorCompanyId = vc.VendorCompanyId, VendorName=v.FirstName, BranchName = vc.BranchName,
                               Email = vc.Email, Mobile = vc.Mobile, Country = vc.Country, StateName=s.StateName, CityName =c.CityName,ImageName=vi.ImageName
                               } );
            if (search == null)
            {
                return View(branchVendor.ToList());
            }
            else
            {
                return View(branchVendor.Where(x => x.BranchName.StartsWith(search) || x.VendorName.StartsWith(search) || x.Mobile.StartsWith(search) || x.CityName.StartsWith(search)).ToList());

            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.country = "India";
            ViewBag.stateList = new SelectList(db.States, "StateId", "StateName");
            return View();
        }

        public JsonResult GetStateList(int StateId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<City> CityList = db.Cities.Where(x => x.StateId == StateId).ToList();
            return Json(CityList, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult Create(BranchVendor branchVendor,HttpPostedFileBase File)
        {
            if (ModelState.IsValid)
              { 
            VendorCompany vendorCompany = new VendorCompany()
            {
                VendorId = (int)System.Web.HttpContext.Current.Session["vendorid"],
                BranchName = branchVendor.BranchName,
                ShortDescription = branchVendor.ShortDescription,
                LongDescription = branchVendor.LongDescription,
                Email = branchVendor.Email,
                Mobile = branchVendor.Mobile,
                Country = branchVendor.Country,
                State =branchVendor.StateId,
                City =branchVendor. CityId,
                Street = branchVendor.Street,
                ZIPCode = branchVendor.ZIPCode,
                AddressLine1 = branchVendor.AddressLine1,
                AddressLine2 = branchVendor.AddressLine2,
            };
                db.VendorCompanies.Add(vendorCompany);
                VendorImage vendorImage = new VendorImage();
                if (File == null)
                {
                    ViewBag.mess = "please select image.";
                }
                else
                {
                    string filex = Path.GetExtension(File.FileName);

                    if (filex.Equals(".jpg") || filex.Equals(".png"))
                    {
                        string imageName = System.IO.Path.GetFileName(File.FileName);
                        string Filepath = Server.MapPath("~/ImageFolder/" + imageName);
                        File.SaveAs(Filepath);
                        vendorImage.VendorCompanyId = branchVendor.VendorCompanyId;
                        vendorImage.ImageName = imageName;
                        db.VendorImages.Add(vendorImage);
                    }
                }

                ViewBag.StateList = db.States;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(branchVendor);
        }
        
        [HttpGet]
        public ActionResult Details(int? id)
       {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var branchDetail = (from vc in db.VendorCompanies
                                join v in db.Vendors on vc.VendorId equals v.VendorId
                                join s in db.States on vc.State equals s.StateId
                                join c in db.Cities on vc.City equals c.CityId
                                join vi in db.VendorImages on vc.VendorCompanyId equals vi.VendorCompanyId
                                where (vc.VendorCompanyId == id)
                                select new BranchVendor
                                {
                                    VendorCompanyId = vc.VendorCompanyId,
                                    BranchName = vc.BranchName,
                                    Mobile = vc.Mobile,
                                    Email = vc.Email,
                                    Country = vc.Country,
                                    StateName = s.StateName,
                                    CityName = c.CityName,
                                    Street = vc.Street,
                                    ZIPCode = vc.ZIPCode,
                                    AddressLine1 = vc.AddressLine1,
                                    AddressLine2 = vc.AddressLine2,
                                    ShortDescription = vc.ShortDescription,
                                    LongDescription = vc.LongDescription,
                                    ImageName = vi.ImageName,
                                }).SingleOrDefault();
            return View(branchDetail);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var branchVendor = (from vc in db.VendorCompanies
                               join v in db.Vendors on vc.VendorId equals v.VendorId
                               join s in db.States on vc.State equals s.StateId
                               join c in db.Cities on vc.City equals c.CityId
                               join vi in db.VendorImages on vc.VendorCompanyId equals vi.VendorCompanyId
                                where (vc.VendorCompanyId == id)
                                select new BranchVendor
                                {
                                    BranchName = vc.BranchName,
                                    Mobile = vc.Mobile,
                                    Email = vc.Email,
                                    Country = vc.Country,
                                    State = vc.State,
                                    StateName = s.StateName,
                                    CityName = c.CityName,
                                    ZIPCode = vc.ZIPCode,
                                    AddressLine1 = vc.AddressLine1,
                                    AddressLine2 = vc.AddressLine2,
                                    ShortDescription = vc.ShortDescription,
                                    LongDescription = vc.LongDescription,
                                    ImageName = vi.ImageName,
                                }).SingleOrDefault();
            if (branchVendor== null)
            {
                return HttpNotFound();
            }
            return View(branchVendor);
        }
        [HttpPost]
        public ActionResult Edit(BranchVendor branchVendor,int id)
        {
            if (ModelState.IsValid)
            {
                VendorCompany vendorCompany   = db.VendorCompanies.Find(id);
                vendorCompany.BranchName = branchVendor.BranchName;
                vendorCompany.Mobile = branchVendor.Mobile;
                vendorCompany.Email = branchVendor.Email;
                vendorCompany.Country = branchVendor.Country;
                vendorCompany.State = branchVendor.StateId;
                vendorCompany.City = branchVendor.CityId;
                vendorCompany.Street = branchVendor.Street;
                vendorCompany.ZIPCode = branchVendor.ZIPCode;
                vendorCompany.AddressLine1 = branchVendor.AddressLine1;
                vendorCompany.AddressLine2 = branchVendor.AddressLine2;
                vendorCompany.ShortDescription = branchVendor.ShortDescription;
                vendorCompany.LongDescription = branchVendor.LongDescription;                  
                db.Entry(vendorCompany).State = EntityState.Modified;
                var vendorImage = db.VendorImages.FirstOrDefault(x => x.VendorCompanyId == id);
                vendorImage.ImageName = branchVendor.ImageName; 
                db.Entry(vendorImage).State = EntityState.Modified; 
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(branchVendor);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var branchVendor = (from vc in db.VendorCompanies
                                join v in db.Vendors on vc.VendorId equals v.VendorId
                                join s in db.States on vc.State equals s.StateId
                                join c in db.Cities on vc.City equals c.CityId
                                join vi in db.VendorImages on vc.VendorCompanyId equals vi.VendorCompanyId
                                where (vc.VendorCompanyId == id)
                                select new BranchVendor
                                {
                                    VendorCompanyId=vc.VendorCompanyId,
                                    BranchName = vc.BranchName,
                                    Mobile = vc.Mobile,
                                    Email = vc.Email,
                                    Country = vc.Country,
                                    StateName = s.StateName,
                                    CityName = c.CityName,
                                    Street = vc.Street,
                                    ZIPCode = vc.ZIPCode,
                                    AddressLine1 = vc.AddressLine1,
                                    AddressLine2 = vc.AddressLine2,
                                    ShortDescription = vc.ShortDescription,
                                    LongDescription = vc.LongDescription,
                                    ImageName = vi.ImageName,
                                }).SingleOrDefault();

            if (branchVendor == null)
            {
                return HttpNotFound();
            }
            return View(branchVendor);
        }

        // POST: Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //var bankDetail = db.BankDetails.FirstOrDefault(x => x.VendorCompanyId == id);
            //db.BankDetails.Remove(bankDetail);

            var vendorCourse = db.VendorCourses.FirstOrDefault(x => x.VendorCompanyId == id);
            db.VendorCourses.Remove(vendorCourse);

            var vendorCompany = db.VendorCompanies.FirstOrDefault(x=>x.VendorCompanyId==id);
            db.VendorCompanies.Remove(vendorCompany);

            var vendorImages = db.VendorImages.FirstOrDefault(x => x.VendorCompanyId == id);
            db.VendorImages.Remove(vendorImages);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        }

    }
