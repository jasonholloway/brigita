using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.View.Bits;

namespace Brigita.View.Products
{
    public class ProductsByCategoryModel : IProductContextProvider
    {
        public int CurrentCategoryID { get; set; }
        public string CurrentCategoryName { get; set; }
        public ListPageModel<ProductTeaserModel> ListPage { get; set; }
    }
}
