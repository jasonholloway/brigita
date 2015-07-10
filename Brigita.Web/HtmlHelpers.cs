using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Brigita.Web
{
    public static class HtmlHelpers
    {
        public static void NopAction(this HtmlHelper html, string action, string controller)
        {
            html.RenderAction(action, controller, new { area = string.Empty });
        }

    }
}