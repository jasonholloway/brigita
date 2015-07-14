using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Brigita.Web
{
    
    public static class Routes
    {
        public static void Register(RouteCollection routes) {
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //should have nice short URLs to categories here
            //...
            
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Brigita.Web.Controllers" }
            ).DataTokens["UseNamespaceFallback"] = false;
        }

    }
}