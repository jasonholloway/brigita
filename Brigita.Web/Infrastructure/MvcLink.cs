using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Queries;

namespace Brigita.Web.Infrastructure
{
    public class MvcLink : Link
    {
        public string ControllerName { get; private set; }
        public string ActionName { get; private set; }
        public object RouteValues { get; private set; }

        public MvcLink(string controller, string action, object routeValues) {
            ControllerName = controller;
            ActionName = action;
            RouteValues = routeValues;
        }
    }


}
