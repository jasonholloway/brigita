using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.View.Bits;

namespace Brigita.View
{
    public interface IPagedItemsModel<TItem>
    {
        ListPageModel<TItem> ListPage { get; }
    }
}
