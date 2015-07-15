using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.DtoGen
{
    public static class TypeExtensions
    {
        public static IEnumerable<PropertyInfo> GatherAllProps(this Type @this) {
            foreach(var prop in @this.GetProperties()) {
                yield return prop;
            }

            if(@this.IsInterface) {
                foreach(var @interface in @this.GetInterfaces()) {
                    foreach(var prop in @interface.GatherAllProps()) {
                        yield return prop;
                    }
                }
            }
        }
    }
}
