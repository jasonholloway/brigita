using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Services.Products;

namespace Brigita.Web.Models.Products
{
    public class CategoryPageModel : IWebPageModel, IProductContextModel, IPagedItemsModel<IProductTeaser>
    {
        public string Title { get; set; }
        public string HeadCustom { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string CanonicalURLs { get; set; }
        public string FaviconURL { get; set; }
        public bool DisplayProfiler { get; set; }

        public int CurrentCategoryID { get; set; }



        public IListPage<IProductTeaser> ListPage { get; set; }
    }
}
