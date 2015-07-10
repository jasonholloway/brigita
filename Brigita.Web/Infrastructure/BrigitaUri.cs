using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brigita.Web.Infrastructure
{
    public class BrigitaUri 
        : Uri, IHtmlString
    {
        public BrigitaUri(string uri) : base(uri) {
            //...
        }

        string IHtmlString.ToHtmlString() {
            return Uri.EscapeUriString(this.AbsoluteUri);
        }
    }
}