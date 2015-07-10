using Nop.Core;
using Nop.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Services.Test.Infrastructure
{
    public class RepositoryMock<T> : IRepository<T>
        where T : BaseEntity
    {
        T[] _items;


        public RepositoryMock(IEnumerable<T> items) {
            _items = items.ToArray();
        }


        public T GetById(object id) {
            throw new NotImplementedException();
        }

        public void Insert(T entity) {
            throw new NotImplementedException();
        }

        public void Insert(IEnumerable<T> entities) {
            throw new NotImplementedException();
        }

        public void Update(T entity) {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<T> entities) {
            throw new NotImplementedException();
        }

        public void Delete(T entity) {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<T> entities) {
            throw new NotImplementedException();
        }

        public IQueryable<T> Table {
            get { return new EnumerableQuery<T>(_items); }
        }

        public IQueryable<T> TableNoTracking {
            get { return new EnumerableQuery<T>(_items); }
        }
    }
}
