using Brigita.Services.Categories;
using Brigita.Web.Models.Menu;
using Brigita.Core.Infrastructure.Trees;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Brigita.Web.Infrastructure;

namespace Brigita.Web.Controllers
{
    public class MenuController : Controller
    {
     
        ICategories _categoryProvider;

        public MenuController(ICategories categoryProvider) {
            _categoryProvider = categoryProvider;
        }


        [ChildActionOnly]
        public ActionResult CategoryMenu(int categoryID = 0) {
            var catTree = _categoryProvider.Tree;

            var menuTree = catTree.Project(cat => new CategoryMenuItem() {
                                                    Name = new HtmlString(cat.Name),
                                                    Uri = new BrigitaUri(@"http://128.0.0.1"),
                                                    IsActive = false,
                                                    IsActiveAncestor = false
                                                });

            return View(new CategoryMenuModel() { 
                                    MenuItemTree = menuTree
                                });
        }



    }
}