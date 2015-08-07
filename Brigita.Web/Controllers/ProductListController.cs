using Brigita.Dom.Categories;
using Brigita.Dom.Services.Categories;
using Brigita.Dom.Services.Products;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Brigita.View.Products;
using Brigita.Infrastructure.Pages;
using Brigita.View.Bits;
using Brigita.View.Services.Products;

namespace Brigita.Web.Controllers
{
    public class ProductListController : Controller
    {
        IProductTeasers _teasers;

        public ProductListController(IProductTeasers teasers) {
            _teasers = teasers;
        }

        public ActionResult Category(int categoryID, int pageIndex = 0) 
        {
            var model = _teasers.GetPage(
                                    categoryID, 
                                    new ListPageSpec<ProductTeaser>(pageIndex, 16)
                                    );

            return View(model);
        }

    }
}