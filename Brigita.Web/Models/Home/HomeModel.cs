using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brigita.Web.Models.Home
{
    public class HomeModel : ShopModel
    {
        public IHtmlString Greeting { get; set; }
    }
}