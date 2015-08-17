using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Infrastructure.Accessors
{
    public interface IAccessor
    {
        void SetValue(object entity, object value);
        object GetValue(object entity);
    }

    public interface IAccessor<TEntity> : IAccessor
    {
        void SetValue(TEntity entity, object value);
        object GetValue(TEntity entity);
    }

    public interface IAccessor<TEntity, TValue> : IAccessor<TEntity>
    {
        void SetValue(TEntity entity, TValue value);
        TValue GetValue(TEntity entity);
    }
}
