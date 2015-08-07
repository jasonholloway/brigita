using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Data;
using Brigita.Infrastructure.Pages;
using Brigita.View.Products;
using Nop.Core.Domain.Catalog;

namespace Brigita.View.Services.Products
{
    public class ProductTeasers2 : IProductTeasers
    {
        IRepo<Product> _repo;

        public ProductTeasers2(IRepo<Product> repo) {
            _repo = repo;
        }
        
        public ProductTeasersModel GetPage(int categoryID, ListPageSpec<ProductTeaser> pageSpec) {




            throw new NotImplementedException();
        }
    }
}
