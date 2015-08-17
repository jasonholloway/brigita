using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Infrastructure.Accessors
{
    public static class Accessors
    {
        static AccessorSource _source = new AccessorSource();
        
        public static IAccessor<TEntity> Get<TEntity>(string propName) 
        {
            return (IAccessor<TEntity>)_source
                                        .GetAccessor(typeof(TEntity), propName);
        }

        public static IAccessor<TEntity, TValue> Get<TEntity, TValue>(string propName) 
        {
            return (IAccessor<TEntity, TValue>)_source
                                                .GetAccessor(typeof(TEntity), propName);
        }

        public static IAccessor<TEntity, TValue> Get<TEntity, TValue>(PropertyInfo prop) 
        {
            return (IAccessor<TEntity, TValue>)_source
                                                .GetAccessor(prop);
        }
    }
}
