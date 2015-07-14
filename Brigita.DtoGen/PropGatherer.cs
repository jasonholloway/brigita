using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.DtoGen
{
    public static class PropGatherer
    {
        public static IEnumerable<PropertyInfo> Gather(Type type) {
            foreach(var prop in type.GetProperties()) {
                yield return prop;
            }

            if(type.IsInterface) {
                foreach(var iface in type.GetInterfaces()) {
                    foreach(var prop in iface.GetProperties()) {
                        yield return prop;
                    }
                }
            }
        }        
    }
}
