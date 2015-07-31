using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Infrastructure.Pages
{
    public static class ListPageExtensions
    {

        public static IListPage<TNew> Project<TOld, TNew>(
                                            this IListPage<TOld> @this, 
                                            Func<TOld, TNew> fnProject) 
        {
            return new ListPage<TNew>(
                            @this.Items.Select(fnProject),
                            @this.PageIndex,
                            @this.PageSize,
                            @this.PageCount
                            );
        }

    }
}
