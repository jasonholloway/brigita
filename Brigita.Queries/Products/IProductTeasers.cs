using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Infrastructure.Pages;
using Brigita.Queries.Products;

namespace Brigita.Queries.Products
{
    public interface IProductTeasers
    {
        ProductTeasersModel GetPage(int categoryID, ListPageSpec<ProductTeaser> pageSpec);
    }
}
