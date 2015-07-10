using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Services.Cache
{
    public class BrigitaCache : ICache
    {
        MemoryCache _cache;
        static CacheKey[] _emptyCacheKeys = new CacheKey[0];


        public BrigitaCache(MemoryCache memoryCache) {
            _cache = memoryCache;
        }


        public void Remove(CacheKey key) {
            _cache.Remove(key.Address);
        }


        public TValue Access<TValue>(CacheKey key, CacheKey[] upstreamKeys, Func<TValue> fnValue) {
            
            var lzNew = new Lazy<TValue>(fnValue);

            var policy = new CacheItemPolicy() {
                AbsoluteExpiration = DateTimeOffset.MaxValue
            };

            var lzOld = (Lazy<TValue>)_cache.AddOrGetExisting(
                                                key.Address,
                                                lzNew,
                                                policy
                                                );

            if(lzOld == null) { //internet rumours lead me to believe this acts so

                if(upstreamKeys.Any()) {
                    policy.ChangeMonitors.Add(
                        _cache.CreateCacheEntryChangeMonitor(upstreamKeys.Select(k => k.Address))
                        );
                }

                return lzNew.Value;
            }
            else {
                return lzOld.Value;
            }

        }

        public TValue Access<TValue>(CacheKey key, Func<TValue> fnValue) {
            return Access(key, _emptyCacheKeys, fnValue);
        }

    }
}
