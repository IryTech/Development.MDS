using MDS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Security;

namespace MDS.Web.Controllers
{
    public class LoginVendorsController : Controller
    {
        private MdsDbContext db = new MdsDbContext();
        // GET: VendorLogin
        public ActionResult LoginVendor()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult LoginVendor(Vendor login)
        {
            IQueryable<Vendor> vendors = from s in db.Vendors select s;
            foreach (var log in vendors)
            {
                if (login.Mobile.Equals(log.Mobile) && login.Password.Equals(log.Password))
                {
                    ViewBag.name = (login.FirstName + " " + login.LastName);
                    ViewBag.idd = log.VendorId;
                    Session["VendorId"] = log.VendorId;
                    Session["VendorName"] = (log.FirstName + " " + log.LastName);
                    return RedirectToAction("Create","BranchVendors");
                }

            }
            ViewBag.msg = "Invalid UserName or Password";
            return View();
        }
        public ActionResult VendorLogout()
        {
            Session.Remove("VendorId");
            return RedirectToAction("Index", "Home", "Home");
        }

    }
}