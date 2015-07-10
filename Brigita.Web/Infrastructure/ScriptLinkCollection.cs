using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brigita.Web.Infrastructure
{
    public class ScriptLinkCollection : IEnumerable<string>
    {
        List<string> _list = new List<string>();

        public void Add(string url, params object[] args) {
            _list.Add(string.Format(url, args));
        }



        public IEnumerator<string> GetEnumerator() {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _list.GetEnumerator();
        }
    }
}