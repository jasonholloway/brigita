using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Dom.Services.Cache
{
    internal class CacheAttribute : Attribute
    {
        public string ID { get; private set; }
        public string[] UpstreamIDs { get; private set; }

        public CacheAttribute(string id, params string[] upstreamIDs) {
            ID = id;
            UpstreamIDs = upstreamIDs;
        }
    }


    internal class CacheZoneAttribute : Attribute
    {
        public string Name { get; private set; }

        public CacheZoneAttribute(string name) {
            Name = name;
        }
    }

}
