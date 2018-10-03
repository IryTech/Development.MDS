using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MDS.Core;
using MDS.Web;
using MDS.Web.Models.Customers;

namespace MDS.Web.Controllers
{
    public class RegisterCustomersController : Controller
    {
        private MdsDbContext db = new MdsDbContext();

        // GET: Customers
        public ActionResult Index(string search)
        {
            var registerCustomers = from c in db.Customers select new RegisterCustomer { CustomerId = c.CustomerId, FirstName = c.FirstName, LastName = c.LastName, Email = c.Email, Mobile = c.Mobile};
            if (search == null)
            {
                return View(registerCustomers.ToList());
            }
            else
            {
                return View(registerCustomers.Where(x => x.FirstName.StartsWith(search) || x.LastName.StartsWith(search) || x.Email.StartsWith(search) || x.Mobile.StartsWith(search)).ToList());
            }
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var registerCustomers = (from c in db.Customers where c.CustomerId==id select new RegisterCustomer { CustomerId = c.CustomerId, FirstName = c.FirstName, LastName = c.LastName, Email = c.Email, Mobile = c.Mobile }).SingleOrDefault();
            if (registerCustomers == null)
            {
                return HttpNotFound();
            }
            return View(registerCustomers);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,FirstName,LastName,Email,Mobile,Password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var registerCustomers = (from c in db.Customers where c.CustomerId == id select new RegisterCustomer { CustomerId = c.CustomerId, FirstName = c.FirstName, LastName = c.LastName, Email = c.Email, Mobile = c.Mobile }).SingleOrDefault();
            if (registerCustomers == null)
            {
                return HttpNotFound();
            }
            return View(registerCustomers);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var registerCustomers = (from c in db.Customers where c.CustomerId == id select new RegisterCustomer { CustomerId = c.CustomerId, FirstName = c.FirstName, LastName = c.LastName, Email = c.Email, Mobile = c.Mobile }).SingleOrDefault();
            if (registerCustomers == null)
            {
                return HttpNotFound();
            }
            return View(registerCustomers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
