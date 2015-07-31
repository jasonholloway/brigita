using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Services.Cache
{
    public static class CacheExtensions
    {
        public static CacheAccess<TValue> Access<TValue>(this ICache @this, CacheKey cacheKey, Func<TValue> fnValue) {
            return new CacheAccess<TValue>(
                                @this, 
                                cacheKey, 
                                fnValue );
        }
    }
}
