using Brigita.Core.Infrastructure.Pages;
using Brigita.Domain.Products;
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
        IProduct[] GetByCategoryID(int catID);
        ListPage<IProductTeaser> GetTeasersByCategoryID(int catID, int page);

        //...

    }
}
