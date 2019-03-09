using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MDS.Web.Models.Vendors
{
    public class AreaVendor
    {
        public int AreaCoverId { get; set; }

        public int VendorCompanyId { get; set; }

        [Display(Name = "Branch Name")]
        public string BranchName { get; set; }

        [Display (Name ="Area Name")]
        public string AreaName { get; set; }

        [Display(Name = "Popular Area")]
        public string PopularName { get; set; }

        [Display(Name = "Searching Title")]
        public string Title { get; set; }

        [Display(Name = "Searching Url")] 
        public string YourUrl { get; set; }

    }
}