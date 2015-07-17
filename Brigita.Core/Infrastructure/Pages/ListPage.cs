using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Core.Infrastructure.Pages
{
    public class ListPage<TItem>
        : ListPageSpec, IEnumerable<TItem>
    {
        TItem[] _items;
        
        public int PageCount { get; private set; }

        public ListPage(IEnumerable<TItem> items, int pageIndex, int pageSize, int pageCount)
            : base(pageIndex, pageSize) 
        {
            _items = items.ToArray();
            PageCount = pageCount;
        }

        public IEnumerator<TItem> GetEnumerator() {
            return ((IEnumerable<TItem>)_items).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return _items.GetEnumerator();
        }
    }

    public class ListPageSpec
    {
        public int PageIndex { get; protected set; }
        public int PageSize { get; protected set; }

        public ListPageSpec(int pageIndex, int pageSize) {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }

}
