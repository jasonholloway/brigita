using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Queries.Bits;

namespace Brigita.Queries.Products
{
    public class ProductTeasersModel : IProductContextProvider
    {
        public int CurrentCategoryID { get; set; }
        public string CurrentCategoryName { get; set; }
        public ListPageModel<ProductTeaser> ListPage { get; set; }
    }
}
