using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Services.Cache
{
    public abstract class CacheElement
    {
        public string ID { get; protected set; }
        public CacheElement Parent { get; protected set; }
        public IEnumerable<CacheElement> Children { get; protected set; }
    }
}
