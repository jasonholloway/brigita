using Brigita.Dom.Services.Categories;
using Brigita.Queries.Menu;
using Brigita.Infrastructure.Trees;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Brigita.Web.Infrastructure;
using Brigita.Dom.Services.Pages;
using Brigita.Dom.Scope;
using System.Web.Routing;
using Brigita.Queries.Menu;
using Brigita.Queries;

namespace Brigita.Web.Controllers
{
    public class MenuController : Controller
    {
        IMediator _mediator;
        
        public MenuController(IMediator mediator) 
        {
            _mediator = mediator;
        }
        
        [ChildActionOnly]
        public ActionResult CategoryMenu(int activeCatID = 0) 
        {
            var query = new MenuQuery() {
                               ActiveCategoryID = activeCatID
                            };

            var model = _mediator.Enquire<MenuQuery, MenuModel>(query);

            return View(model);
        }

    }
}