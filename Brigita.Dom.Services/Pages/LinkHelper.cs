using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Dom.Services.Pages
{
    public class LinkHelper : ILinkHelper
    {
        public Uri BuildUrl(string relativeUrl) {
            return new Uri(@"http:\\128.0.0.1\" + relativeUrl);
        }
    }
}
