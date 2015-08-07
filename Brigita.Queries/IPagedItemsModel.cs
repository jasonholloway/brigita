using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Queries.Bits;

namespace Brigita.Queries
{
    public interface IPagedItemsModel<TItem>
    {
        ListPageModel<TItem> ListPage { get; }
    }
}
