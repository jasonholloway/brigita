using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Brigita.View;
using Brigita.Web.Services;

namespace Brigita.Web.Infrastructure
{
    public static class UrlHelperExtensions
    {
        public static string MvcLink(this UrlHelper @this, MvcLink link) {
            return @this.Action(link.ActionName, link.ControllerName, link.RouteValues);
        }

        public static string MvcLink(this UrlHelper @this, Link link) {
            return @this.MvcLink((MvcLink)link);
        }
    }
}
