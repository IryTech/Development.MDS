 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MDS.Web.Models.Vendors
{
    public class BankDetailsVendor
    {
        public int BankDetailsId { get; set; }

        public int VendorCompanyId { get; set; }

        [Display(Name = "Bank Name")]
        public string BankName { get; set; }

        [Display(Name="Account Holder Name")]
        public string AccountHolderName { get; set; }

        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }

        [Display(Name = "IFSC Code")]
        public string IFSC { get; set; }


    }
}