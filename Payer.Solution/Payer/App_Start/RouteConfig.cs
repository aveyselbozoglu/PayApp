using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Payer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default3",
                url: "Employee/Index/{pageIndex}",
                defaults: new { controller = "Employee", action = "Index", pageIndex = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default2",
                url: "Pay/Index/{pageIndex}",
                defaults: new { controller = "Pay", action = "Index", pageIndex = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
