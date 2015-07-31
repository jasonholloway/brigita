using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Dom.Services.Cache
{
    public class CacheRegion : CacheKey
    {
        Dictionary<string, CacheKey> _dKeys = new Dictionary<string,CacheKey>();

        private CacheRegion(string id, CacheRegion parentRegion) 
            : base(parentRegion, id) { }

        public CacheRegion(string id) 
            : this(id, null) { }


        public IEnumerable<CacheKey> Keys {
            get { return _dKeys.Values; }
        }


        public void Clear(ICache cache) {
            //...
        }

        public CacheKey Key(string id) {
            var key = new ValueCacheKey(this, id);
            _dKeys[id] = key;
            return key;
        }

        public CacheRegion Region(string id) {
            var region = new CacheRegion(id, this);
            _dKeys[id] = region;
            return region;
        }

        class ValueCacheKey : CacheKey
        {
            public ValueCacheKey(CacheRegion region, string id)
                : base(region, id) { }
        }

    }
}
