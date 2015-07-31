using Brigita.Infrastructure.Pages;
using Brigita.Dom.Products;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Dom.Services.Products
{
    public interface IProducts
    {
        ListPage<IProduct> GetProductsByCategory(int categoryID, ListPageSpec pageSpec);

        ListPage<ITinyProduct> GetTinyProductsByCategory(int categoryID, ListPageSpec pageSpec);
        //...

    }
}
