using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Services.Cache
{

    public abstract class CacheSource
    {
        public CacheKey Key { get; protected set; }
        public CacheKey[] UpstreamKeys { get; protected set; }
    }

    public class CacheSource<TValue> : CacheSource
    {
        static CacheKey[] _emptyKeyArray = new CacheKey[0];

        public Func<TValue> Factory { get; private set; }

        public CacheSource(CacheKey key, CacheKey[] upstreamKeys, Func<TValue> fnValue = null) {
            Key = key;

            UpstreamKeys = upstreamKeys
                            ?? _emptyKeyArray;

            Factory = fnValue 
                        ?? new Func<TValue>(() => default(TValue));
        }

        public CacheSource(CacheKey key, Func<TValue> fnValue = null) 
            : this(key, _emptyKeyArray, fnValue) { }

        public CacheSource(string keyString, string[] upstreamKeyStrings, Func<TValue> fnValue = null)
            : this(
                new CacheKey(keyString), 
                upstreamKeyStrings.Select(s => new CacheKey(s)).ToArray(), 
                fnValue ) { }

        public CacheSource(string keyString, Func<TValue> fnValue = null) 
            : this(new CacheKey(keyString), fnValue) { }


        public TValue Access(ICache cache, Func<TValue> fnValue = null) {
            return cache.Get(
                            Key, 
                            fnValue ?? Factory, 
                            UpstreamKeys 
                            );
        }

        

    }
}
