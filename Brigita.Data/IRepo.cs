using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Data
{

    public interface IRepo : IQueryable
    {
        //...
    }

    public interface IRepo<TEntity> : IQueryable<TEntity>, IRepo
    {
        IQueryable<TEntity> Include(params string[] rIncludes);
        IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] rIncludes);
    }

}
