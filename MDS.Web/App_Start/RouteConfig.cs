﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MDS.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "RegisterVendors", action = "Index", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Course",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "VendorCourses", action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}
