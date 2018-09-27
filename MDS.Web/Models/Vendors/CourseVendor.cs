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
       
        [Display(Name ="Course Name")]
        public string CourseTitle { get; set; }

        [Display(Name = "Search text")]
        public string ShortDescription { get; set; }

        [Display(Name = "About Course")]
        public string LongDescription { get; set; }

        [Display(Name = "Course Duration")]
        public string Duration { get; set; }

        [Display(Name = "Price")]
        public decimal? VendorPrice { get; set; }

        [Display(Name = "Course Title")]
        public string Title { get; set; }

        [Display(Name = "Course URL")]
        public string YourUrl { get; set; }

    }
}