using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Brigita.Models
{
    public class HomeModel : ShopModel
    {
        public IHtmlString Greeting { get; set; }
    }
}