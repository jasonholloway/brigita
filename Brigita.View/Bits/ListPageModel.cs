using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Infrastructure.Pages;
using Brigita.View.Services;

namespace Brigita.View.Bits
{

    public abstract class ListPageModel : IListPage
    {
        public int PageIndex { get; protected set; }
        public int PageCount { get; protected set; }
        public int PageSize { get; protected set; }
        public object[] Items { get; protected set; }
        public LinkSource<int> PageLinks { get; protected set; }
    }


    public class ListPageModel<TItem> : ListPageModel, IListPage<TItem>
    {
        IListPage<TItem> _inner;
        
        public ListPageModel(IListPage<TItem> listPage, Func<int, Link> fnPageLink) 
        {
            _inner = listPage;
            
            PageIndex = _inner.PageIndex;
            PageCount = _inner.PageCount;
            PageSize = _inner.PageSize;

            base.Items = _inner.Items.Cast<object>().ToArray();

            PageLinks = new LinkSource<int>(
                                Enumerable.Range(0, listPage.PageCount),
                                fnPageLink);
        }

        public new TItem[] Items { get; private set; }

    }

    public class LinkSource<TIndex> : IEnumerable<Link>
    {
        Func<TIndex, Link> _fnLink;
        IEnumerable<Link> _links;

        public LinkSource(IEnumerable<TIndex> indices, Func<TIndex, Link> fnLink) 
        {
            _fnLink = fnLink;
            _links = indices.Select(i => GetLink(i)); //would be nice to cache this
        }

        public Link this[TIndex index] {
            get { 
                return GetLink(index);
            }
        }

        public Link GetLink(TIndex index) {
            return _fnLink(index);
        }

        public IEnumerator<Link> GetEnumerator() {
            return _links.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

    }



}
