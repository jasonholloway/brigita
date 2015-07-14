using Brigita.Services.Products;
using Brigita.Web.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Web.Models.Products
{
    public class ProductsPageModel : PageModel, ICurrentCategoryModel, IListModel<IProductTeaser>
    {       
        public ProductsPageModel(int currentCatID) {
            CurrentCategoryID = currentCatID;
        }

        public int CurrentCategoryID { get; private set; }

        public IListInfo<IProductTeaser> List {
            get { throw new NotImplementedException(); }
        }
    }
}
