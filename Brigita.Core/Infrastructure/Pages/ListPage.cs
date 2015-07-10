using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Core.Infrastructure.Pages
{
    public class ListPage<TItem>
        : IEnumerable<TItem>
    {
        IEnumerable<TItem> _items;
        
        public int PageIndex { get; private set; }
        public int PageCount { get; private set; }

        public ListPage(IEnumerable<TItem> items, int pageIndex, int pageCount) {
            _items = items;
            PageIndex = pageIndex;
            PageCount = pageCount;
        }

        public IEnumerator<TItem> GetEnumerator() {
            return _items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return _items.GetEnumerator();
        }
    }
}
