using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Infrastructure.Accessors
{

    static class Accessor
    {
        public static IAccessor Build(PropertyInfo prop) 
        {
            var accType = typeof(Accessor<,>)
                            .MakeGenericType(prop.DeclaringType, prop.PropertyType);

            return (IAccessor)Activator.CreateInstance(accType, prop);                    
        }
    }


    class Accessor<TEntity, TValue> 
        : IAccessor<TEntity, TValue>
    {
        Lazy<Action<TEntity, TValue>> _lzFnSet;
        Lazy<Func<TEntity, TValue>> _lzFnGet;
        
        public Accessor(PropertyInfo prop) 
        {
            _lzFnSet = new Lazy<Action<TEntity,TValue>>(() => BuildSetter(prop));
            _lzFnGet = new Lazy<Func<TEntity,TValue>>(() => BuildGetter(prop));
        }
        

        static Action<TEntity, TValue> BuildSetter(PropertyInfo prop) 
        {
            var exEntParam = Expression.Parameter(typeof(TEntity), "ent");
            var exValParam = Expression.Parameter(typeof(TValue), "val");

            var exFnSetter = Expression.Lambda<Action<TEntity, TValue>>(
                                Expression.Call(
                                            exEntParam,
                                            prop.GetSetMethod(),
                                            exValParam
                                            ),
                                exEntParam,
                                exValParam
                                );

            return exFnSetter.Compile();
        }

        static Func<TEntity, TValue> BuildGetter(PropertyInfo prop) 
        {
            var exEntParam = Expression.Parameter(typeof(TEntity), "ent");

            var exFnGetter = Expression.Lambda<Func<TEntity, TValue>>(
                                Expression.Call(
                                            exEntParam,
                                            prop.GetGetMethod()
                                            ),
                                exEntParam
                                );

            return exFnGetter.Compile();
        }




        void IAccessor<TEntity, TValue>.SetValue(TEntity entity, TValue value) {
            _lzFnSet.Value(entity, value);
        }

        TValue IAccessor<TEntity, TValue>.GetValue(TEntity entity) {
            return _lzFnGet.Value(entity);
        }

        void IAccessor<TEntity>.SetValue(TEntity entity, object value) {
            _lzFnSet.Value(entity, (TValue)value);
        }

        object IAccessor<TEntity>.GetValue(TEntity entity) {
            return _lzFnGet.Value(entity);
        }

        void IAccessor.SetValue(object entity, object value) {
            _lzFnSet.Value((TEntity)entity, (TValue)value);
        }

        object IAccessor.GetValue(object entity) {
            return _lzFnGet.Value((TEntity)entity);
        }
    }
}
