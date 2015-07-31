using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Brigita.Web.Infrastructure
{
    public class LinkCollection : IEnumerable<string>
    {
        List<string> _list = new List<string>();
        UrlHelper _url;
        
        public LinkCollection(UrlHelper url) {
            _url = url;
        }


        public void Add(string url, params object[] args)
        {
            _list.Add(_url.Content(string.Format(url, args)));
        }

        //...

        public IEnumerator<string> GetEnumerator() {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _list.GetEnumerator();
        }
    }
}