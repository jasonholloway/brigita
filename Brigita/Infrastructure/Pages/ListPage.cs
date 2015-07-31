using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Infrastructure.Pages
{

    public interface IListPage
    {
        int PageIndex { get; }
        int PageCount { get; }
        int PageSize { get; }
        object[] Items { get; }
    }

    public interface IListPage<TItem> : IListPage
    {
        new TItem[] Items { get; }
    }



    public class ListPage<TItem>
        : IListPage<TItem>, IEnumerable<TItem>
    {
        TItem[] _items;

        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int PageCount { get; private set; }

        public ListPage(IEnumerable<TItem> items, int pageIndex, int pageSize, int pageCount)
        {
            _items = items.ToArray();
            PageIndex = pageIndex;
            PageSize = pageSize;
            PageCount = pageCount;
        }

        public IEnumerator<TItem> GetEnumerator() {
            return ((IEnumerable<TItem>)_items).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return _items.GetEnumerator();
        }

        public TItem[] Items {
            get { return _items; }
        }

        object[] IListPage.Items {
            get { return _items.Cast<object>().ToArray(); }
        }
    }




    public class ListPageSpec
    {
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }

        public ListPageSpec(int pageIndex, int pageSize) {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }

}
