using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Brigita.Queries;
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

            dVals.Add(
                    "locale", 
                    Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.ToLower()
                    );

            return @this.Action(link.ActionName, link.ControllerName, dVals);
        }

    }
}
