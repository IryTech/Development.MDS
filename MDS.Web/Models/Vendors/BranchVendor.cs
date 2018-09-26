using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MDS.Web.Models.Vendors
{
    public class BranchVendor
    {
        public int VendorCompanyId { get; set; }

        public int VendorId { get; set; }

        public int VendorImageId { get; set; }

        [Display(Name = "Branch Banner")]
        public string ImageName { get; set; }

        public string ImageLocation { get; set; }

        [Display(Name="Branch Name")]
        public string Name { get; set; }

        [Display(Name = "Branch Helpline")]
        public string Mobile { get; set; }

        [Display(Name = "Branch Email")]
        public string Email { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int? ZIPCode { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

    }
}