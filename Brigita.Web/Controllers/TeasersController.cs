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
using Brigita.Queries.Products;
using Brigita.Infrastructure.Pages;
using Brigita.Queries.Bits;
using Brigita.Queries.Products;
using Brigita.Queries;
using Brigita.Queries.Teasers;

namespace Brigita.Web.Controllers
{
    public class TeasersController : Controller
    {
        IMediator _mediator;

        public TeasersController(IMediator mediator) {
            _mediator = mediator;
        }

        public ActionResult Category(int categoryID, int pageIndex = 0) 
        {
            var query = new TeaserPageQuery() { 
                                CategoryID = categoryID,
                                PageSpec = new ListPageSpec<TeaserModel>(pageIndex, 16)
                                };

            var model = _mediator.Enquire<TeaserPageQuery, TeaserPageModel>(query);

            return View(model);
        }

    }
}