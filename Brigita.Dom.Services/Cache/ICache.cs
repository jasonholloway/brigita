using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Dom.Services.Cache
{
    public interface ICache
    {
        TValue Access<TValue>(CacheKey key, CacheKey[] upstreamKeys, Func<TValue> fnValue);
        TValue Access<TValue>(CacheKey key, Func<TValue> fnValue);

        void Remove(CacheKey key);

    }
}
