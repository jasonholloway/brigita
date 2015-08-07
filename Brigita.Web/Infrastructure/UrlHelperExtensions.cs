using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Brigita.View;
using Brigita.Web.Services;

namespace Brigita.Web.Infrastructure
{
    public static class UrlHelperExtensions
    {
        public static string MvcLink(this UrlHelper @this, Link link) {
            return @this.MvcLink((MvcLink)link);
        }

        public static string MvcLink(this UrlHelper @this, MvcLink link) 
        {
            var dVals = new RouteValueDictionary(link.RouteValues);

            var httpCtx = @this.RequestContext.HttpContext;

            if(httpCtx.Items.Contains("locale")) {                
                var locale = (string)httpCtx.Items["locale"];
                dVals.Add("locale", locale.ToLower());
            }

            return @this.Action(link.ActionName, link.ControllerName, dVals);
        }

    }
}
