using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Web.Domain.Models
{
    public interface IListModel<TItem>
    {
        IListInfo<TItem> List { get; }
    }


    public interface IListInfo
    {
        int PageIndex { get; }
        int PageCount { get; }
        int PageSize { get; }
    }

    public interface IListInfo<TItem> : IListInfo
    {
        TItem[] Items { get; }
    }
}
