using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Infrastructure
{
    public static class TypeEnumerableExtensions
    {
        public static IEnumerable<Type> GetConcreteImpls(this IEnumerable<Type> @this, Type intType) 
        {
            return @this.Where(t => !t.IsAbstract
                                    && intType.IsAssignableFrom(t));
        }    
    }
}
