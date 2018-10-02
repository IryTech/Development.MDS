﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MDS.Web.Models.Customers
{
    public class RegisterCustomer
    {
        public int CustomerId { get; set; }

        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Mobile No:")]
        public string Mobile { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }


    }
}