using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Brigita.Web.Infrastructure;

namespace Brigita.Web
{
    
    public static class Routes
    {





        public static void Register(RouteCollection routes) {
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRouteWithLocale(
                        "Home",
                        "",
                        new { controller = "Home", action = "Index" }
                        );



            //routes.MapRoute(
            //    "Home",
            //    "{locale}",
            //    new { locale = UrlParameter.Optional, controller = "Home", action = "Index" }
            //    );

            //routes.MapRoute(
            //    "ProductsByCategory",
            //    "products/{categoryName}/{pageIndex}",
            //    new { 
            //        controller = "ProductList", 
            //        action = "CategoryByName", 
            //        pageIndex = UrlParameter.Optional 
            //    });
            
            routes.MapRouteWithLocale(
                        "Default",
                        "{controller}/{action}"
                        );
        }

    }
}