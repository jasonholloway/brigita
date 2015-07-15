﻿using Brigita.Web.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Web.Domain.Models
{
    public interface IPagedItemsModel<TItem>
    {
        IListPage<TItem> ListPage { get; }
    }

    public interface IListPage
    {
        int PageIndex { get; }
        int PageCount { get; }
        int PageSize { get; }
    }

    public interface IListPage<TItem> : IListPage
    {
        TItem[] Items { get; }
    }

}