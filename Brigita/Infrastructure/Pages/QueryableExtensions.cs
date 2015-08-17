using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Dom;

namespace Brigita.Infrastructure.Pages
{
    public static class QueryableExtensions
    {
        public static ListPage<TElem> GetPage<TElem>(
                                        this IQueryable<TElem> queryable, 
                                        int pageIndex, 
                                        int pageSize)
            where TElem : IEntity 
        {
            var cElems = queryable.Count();

            var pageCount = cElems / pageSize;

            return new ListPage<TElem>(
                            queryable.OrderBy(e => e.ID)
                                        .Skip(pageIndex * pageSize)
                                        .Take(pageSize)
                                        .ToArray(),
                            pageIndex,
                            pageSize,
                            pageCount
                            );
        }


    }
}
