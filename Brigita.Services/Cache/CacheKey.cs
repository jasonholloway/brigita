using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Services.Cache
{

    public abstract class CacheKey
    {
        public CacheRegion Region { get; private set; }
        public string ID { get; private set; }
        public string Address { get; private set; }
        
        protected CacheKey(CacheRegion region, string id) {
            Region = region;
            ID = id;

            Address = region != null
                            ? string.Format("{0}.{1}", region.Address, ID)
                            : ID;
        }

    }

}
