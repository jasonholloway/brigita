using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Data;

namespace Brigita.Data
{
    public class Repo<TEntity> : IRepo<TEntity>
        where TEntity : BaseEntity, new()
    {
        IDbContext _ctx;
        IQueryable<TEntity> _inner;

        public Repo(IDbContext ctx) {
            _ctx = ctx;
            _inner = _ctx.Set<TEntity>().AsNoTracking();            
        }


        public IEnumerator<TEntity> GetEnumerator() {
            return _inner.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _inner.GetEnumerator();
        }

        public Type ElementType {
            get { return _inner.ElementType; }
        }

        public Expression Expression {
            get { return _inner.Expression; }
        }

        public IQueryProvider Provider {
            get { return _inner.Provider; }
        }

        public IQueryable<TEntity> Include(params string[] rIncludes) {
            var q = _inner;

            foreach(var include in rIncludes) {
                q = q.Include(include);
            }

            return q;
        }
        
        public IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] rIncludes) {
            var q = _inner;

            foreach(var include in rIncludes) {
                q = q.Include(include);
            }

            return q;
        }
    }

}
