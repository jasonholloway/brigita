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

namespace Brigita.Web.Controllers
{
    public class ProductController : Controller
    {
        IProducts _prods;
        ICategories _cats;

        public ProductController(IProducts prods, ICategories cats) {
            _prods = prods;
            _cats = cats;
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