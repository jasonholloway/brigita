using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Brigita.Services.Categories;
using Brigita.Web.Models.Products;

namespace Brigita.Web.Controllers
{
    public class CategoryController : Controller
    {

        ICategories _cats;

        public CategoryController(ICategories cats) 
        {
            _cats = cats;
        }


        public ActionResult CategoryPage(string categoryName, int pageIndex)
        {
            //look up category name here...

            //if nothing return 404

            return CategoryPage(1, 0);
        }

        public ActionResult CategoryPage(int categoryID, int pageIndex = 0) 
        {
            var model = new CategoryPageModel();

            return View(model);
        }
    }
}