using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Services.Cache
{
    public class CacheAccess<TValue>
    {
        Lazy<TValue> _lzValue;

        public CacheAccess(ICache cache, CacheKey key, Func<TValue> fnValue, params CacheKey[] dependencies) 
        {
            _lzValue = new Lazy<TValue>(() => {
                return cache.Get(key, fnValue, dependencies);
            });
        }

        public TValue Value {
            get {
                return _lzValue.Value;
            }
        }

    }
}
