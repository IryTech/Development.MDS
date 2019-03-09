using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MDS.Web.Models.Vendors
{
    public class BranchVendor
    {
        private string country=India;
        public static string India { get; private set; }
        public int VendorCompanyId { get; set; }    

        public int VendorId { get; set; }

        public int VendorImageId { get; set; }

        [Required, Display(Name = "State")]
        public int StateId { get; set; }

        [Required, Display(Name = "City")] 
        public int CityId { get; set; }

        [Display(Name = "Branch Banner")]
        public string ImageName { get; set; }

        [Display(Name = "Banner Location")]
        public string ImageLocation { get; set; }

        [Display(Name = "State Name")]
        public string StateName { get; set; }

        [Display(Name = "City Name")]
        public string CityName { get; set; }

        public int? State { get; set; }
        
        public int? City { get; set; }

        [Display(Name="Branch Name")]
        public string BranchName { get; set; }

        public string VendorName { get; set; }

        [Display(Name = "Branch Helpline")]
        public string Mobile { get; set; }

        [Display(Name = "Branch Email")]
        public string Email { get; set; }

        public string Country { get { return country; } set { country = value; } }
       
        public string Street { get; set; }

        public int? ZIPCode { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

    }
}