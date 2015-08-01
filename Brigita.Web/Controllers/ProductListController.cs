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
        IProductTeasers _prodsByCat;

        public ProductListController(IProductTeasers prodsByCat) {
            _prodsByCat = prodsByCat;
        }

        public ActionResult Category(int categoryID, int pageIndex = 0) 
        {
            var model = _prodsByCat
                            .GetPage(categoryID, new ListPageSpec(pageIndex, 16));

            return View(model);
        }

    }
}