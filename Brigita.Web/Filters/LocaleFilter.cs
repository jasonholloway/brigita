using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Brigita.Web.Filters
{
    public class LocaleFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext) 
        {           
            object localeCode = null;

            if(filterContext.RouteData.Values.TryGetValue("locale", out localeCode)) 
            {

                //do something with locale here! tell lovely service, like.
                //...

            }
            else {
                //try and get from http header

                //otherwise set to default

                //or, we could deduce 

            }
        }
    }
}
