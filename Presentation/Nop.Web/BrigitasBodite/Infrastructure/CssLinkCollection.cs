using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Brigita.Infrastructure
{
    public class CssLinkCollection : List<string>
    {
        public void Add(string url, params object[] args)
        {
            base.Add(string.Format(url, args));
        }

        //...
    }
}