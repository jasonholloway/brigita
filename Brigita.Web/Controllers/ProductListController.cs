using Brigita.Domain.Categories;
using Brigita.Services.Categories;
using Brigita.Services.Products;
using Nop.Core.Domain.Catalog;
using Nop.Services.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Brigita.Web.ViewModels.Products;

namespace Brigita.Web.Controllers
{
    public class ProductListController : Controller
    {
        IProducts _prods;
        ICategories _cats;

        public ProductListController(IProducts prods, ICategories cats) {
            _prods = prods;
            _cats = cats;
        }



        public ActionResult CategoryByName(string categoryName, int pageIndex = 0) {
            //look up category name here...

            //if nothing return 404

            return Category(1, 0);
        }

        public ActionResult Category(int categoryID, int pageIndex = 0) {
            var model = new CategoryPageModel();

            return View(model);
        }





        //public ActionResult ListByCategoryID(int categoryID) {
        //    var category = _categoryProvider..GetByID(categoryID);

        //    if(category == null) {
        //        //invoke 404 etc!
        //        //...
        //    }

        //    return ListByCategory(category);
        //}

        //public ActionResult ListByCategoryName(string categoryName) {
        //    var category = _categoryProvider.FindCat(categoryName);

        //    if(category == null) {
        //        //Invoke 404 etc!
        //        //...
        //    }

        //    return ListByCategory(null);
        //}

        //[NonAction]
        //private ActionResult ListByCategory(ICategory category) {
            
            
        //    return View();
        //}
        
    }
}