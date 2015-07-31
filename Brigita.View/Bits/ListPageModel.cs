using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Infrastructure.Pages;

namespace Brigita.View.Bits
{

    public interface IListPageUrlProvider
    {

    }


    public class ListPageModel<TItem> : ListPageModel, IListPage<TItem>
    {
        IListPage<TItem> _inner;

        public ListPageModel(IListPage<TItem> listPage, IListPageUrlProvider urlProv) 
            : base(listPage, urlProv) 
        {
            _inner = listPage;
        }

        public new TItem[] Items {
            get { return _inner.Items; }
        }

    }



    public abstract class ListPageModel : IListPage
    {
        IListPage _inner;
        IListPageUrlProvider _urlProv;

        protected ListPageModel(IListPage listPage, IListPageUrlProvider urlProv) {
            _inner = listPage;
            _urlProv = urlProv;
        }

        public int PageIndex {
            get { return _inner.PageIndex; }
        }

        public int PageCount {
            get { return _inner.PageCount; }
        }

        public int PageSize {
            get { return _inner.PageSize; }
        }

        public object[] Items {
            get { return _inner.Items; }
        }


        public string GetUrlOfPage(int pageIndex) {
            throw new NotImplementedException();
        }

    }

}
