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
using Brigita.Services.Pages;
using Brigita.Domain.Scope;

namespace Brigita.Web.Controllers
{
    public class MenuController : Controller
    {
        IScopedCategories _scopedCats;
        
        public MenuController(
                    IScopedCategories scopedCats) 
        {
            _scopedCats = scopedCats;
        }


        [ChildActionOnly]
        public ActionResult CategoryMenu(int activeCatID = 0) 
        {
            var catTree = _scopedCats.GetTree(activeCatID);

            var menuTree = catTree.Project(cat => new CategoryMenuItem() {
                                                            Name = cat.Name,
                                                            Url = "socks",
                                                            IsActive = cat.IsActive,
                                                            IsActiveParent = cat.IsActiveParent
                                                        });

            return View(new CategoryMenuModel() { 
                                    MenuItemTree = menuTree
                                });
        }



    }
}