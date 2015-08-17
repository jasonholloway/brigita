using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Infrastructure.Accessors
{
    public class AccessorSource
    {
        ConcurrentDictionary<Type, ConcurrentDictionary<string, IAccessor>> _dTypeAccs;

        public AccessorSource() {
            _dTypeAccs = new ConcurrentDictionary<Type, ConcurrentDictionary<string, IAccessor>>();
        }


        public IAccessor GetAccessor(Type entType, string propName) 
        {
            var dPropAccs = GetPropAccs(entType);

            return dPropAccs.GetOrAdd(
                                propName,
                                n => {
                                    var prop = entType.GetProperty(n);
                                    return Accessor.Build(prop);
                                });
        }

        public IAccessor GetAccessor(PropertyInfo prop) 
        {
            var dPropAccs = GetPropAccs(prop.DeclaringType);

            return dPropAccs.GetOrAdd(
                                prop.Name,
                                n => Accessor.Build(prop));
        }



        ConcurrentDictionary<string, IAccessor> GetPropAccs(Type entType) 
        {
            return _dTypeAccs.GetOrAdd(
                                entType,
                                t => new ConcurrentDictionary<string, IAccessor>()
                                );
        }



    }
}
