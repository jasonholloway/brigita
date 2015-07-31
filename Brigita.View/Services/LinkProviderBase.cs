using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.View.Services
{
    public abstract class LinkProviderBase : ILinkProvider
    {
        Dictionary<Type, object> _dFn = new Dictionary<Type, object>();

        public void Register<T>(Func<T, Link> fn) {
            _dFn[typeof(T)] = fn;
        }

        public Link GetLinkFor<T>(T obj) {
            var fn = (Func<T, Link>)_dFn[typeof(T)];
            return fn(obj);
        }
    }

}
