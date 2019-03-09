using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MDS.Web.Models.Vendors
{
    public class CourseVendor 
    {
        public int VendorCourseId { get; set; }

        public int VendorCompanyId { get; set; }

        [Display(Name = "Vehicle Company")]
        public int VehicleId { get; set; }

        [Display(Name = "Vehicle Model")]
        public int VehicleModelId { get; set; }

        public int? Vehicle { get; set; }

        public int? VehicleModel { get; set; }

        [Display(Name = "Vehicle Company")]
        public string VehicleCompany { get; set; }

        [Display(Name = "Vehicle Model")]
        public string ModelName { get; set; }

        [Display(Name ="Course Name")]
        public string CourseTitle { get; set; }

        [Display(Name = "Branch Name")]
        public string BranchName { get; set; }

        [Display(Name = "Search text")]
        public string ShortDescription { get; set; }

        [Display(Name = "About Course")]
        public string LongDescription { get; set; }

        [Display(Name = "Course Duration")]
        public string Duration { get; set; }

        [Display(Name = "Price")]
        public decimal? VendorPrice { get; set; }

        [Display(Name = "Vehicle Title")]
        public string VehicelTitle { get; set; }

        [Display(Name = "Vehicle URL")]
        public string VehicleUrl { get; set; }

        [Display(Name = "Course Title")]
        public string Title { get; set; }

        [Display(Name = "Course URL")]
        public string CourseUrl { get; set; }

    }
}