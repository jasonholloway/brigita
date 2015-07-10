using Brigita.Core.Infrastructure.Pages;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Services.Products
{
    public interface IProducts
    {
        ListPage<ProductTeaser> GetProductTeasersByCategory(int categoryID, int page);

        //...

    }
}
