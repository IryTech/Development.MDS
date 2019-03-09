 //using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using MDS.Core;
//namespace MDS.Web.Models.Vendors
//{
//    public class Branch_State_CityBind
//    {
//        private readonly MdsDbContext db = new MdsDbContext();

//        public IEnumerable<State> GetStateList()
//        {
//            return db.States.ToList();
//        }

//        public IEnumerable<City> GetCityByState(int StateID)
//        {
//            return db.Cities.Where(s => s.StateId == StateID).ToList();
//        }

//        //public IList<BranchVendor> GetAllBranchList()
//        //{
//        //    var myQuery = (from v in db.VendorCompanies
//        //                   join s in db.States on v.State equals s.StateId
//        //                   join c in db.Cities on v.City equals c.CityId
//        //                   select new BranchVendor()
//        //                   {
//        //                       VendorId = (int)System.Web.HttpContext.Current.Session["vendorid"],
//        //                       BranchName = v.BranchName,
//        //                       ShortDescription = v.ShortDescription,
//        //                       LongDescription = v.LongDescription,
//        //                       Email = v.Email,
//        //                       Mobile = v.Mobile,
//        //                       Country = v.Country,
//        //                       State = s.StateId,
//        //                       City = c.CityId,
//        //                       Street = v.Street,
//        //                       ZIPCode = v.ZIPCode,
//        //                       AddressLine1 = v.AddressLine1,
//        //                       AddressLine2 = v.AddressLine2,
//        //                   });
//        //    return myQuery.ToList();
//        //}
//        public bool IsVendorAlreadyExist(string mobile)
//        {
//            bool IsRecordExist = false;

//            var result = (from t in db.VendorCompanies
//                          where t.Mobile == mobile
//                          select t).SingleOrDefault();

//            if (result != null)
//            {
//                IsRecordExist = true;
//            }
//            return IsRecordExist;
//        }

//        //public void AddNewEmployee(VendorCompany vendorCompany)
//        //{
//        //    db.VendorCompanies.Add(vendorCompany);
//        //    db.SaveChanges();
//        //}
//    }
//}
