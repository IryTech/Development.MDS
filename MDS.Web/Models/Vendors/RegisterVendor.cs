using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MDS.Web.Models.Vendors
{
    public class RegisterVendor
    {
        public int VendorId { get; set; }


        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Remote("CheckForDuplication", "RegisterVendors")]
        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Password { get; set; }

    }
}