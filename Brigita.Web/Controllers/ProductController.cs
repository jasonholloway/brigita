using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Brigita.Queries;
using Brigita.Queries.Products;

namespace Brigita.Web.Controllers
{
    public class ProductController : Controller
    {
        IMediator _mediator;

        public ProductController(IMediator mediator) {
            _mediator = mediator;
        }

        public ActionResult Details(int productID) 
        {
            var query = new ProductQuery() { 
                                ProductID = productID
                                };

            var model = _mediator.Enquire<ProductQuery, ProductModel>(query);

            return View(model);
        }

    }
}
