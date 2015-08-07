using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Brigita.Queries.Products;

namespace Brigita.Web.Controllers
{
    public class ProductController : Controller
    {
        IProductDetailsSource _detailsSrc;

        public ProductController(IProductDetailsSource detailsSrc) {
            _detailsSrc = detailsSrc;
        }


        public ActionResult Details(int productID) 
        {
            var details = _detailsSrc.GetDetails(productID);

            return View(details);
        }

    }
}
