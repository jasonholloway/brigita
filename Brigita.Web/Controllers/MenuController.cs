using Brigita.Dom.Services.Categories;
using Brigita.View.Menu;
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
using Brigita.View.Services.Menu;

namespace Brigita.Web.Controllers
{
    public class MenuController : Controller
    {        
        ICatMenuModelSource _catMenuModelSource;
        
        public MenuController(ICatMenuModelSource catMenuModelSource) 
        {
            _catMenuModelSource = catMenuModelSource;
        }
        
        [ChildActionOnly]
        public ActionResult CategoryMenu(int activeCatID = 0) 
        {
            var model = _catMenuModelSource
                                .GetModel(activeCatID);

            return View(model);
        }

    }
}