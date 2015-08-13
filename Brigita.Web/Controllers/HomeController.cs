using System.Linq;
using System.Web.Mvc;
using Brigita.Queries;
using Brigita.Queries.Home;

namespace Brigita.Web.Controllers
{
    public class HomeController : Controller
    {
        //IHomeModelSource _homeModelSource;

        //public HomeController(IHomeModelSource homeModelSource) {
        //    _homeModelSource = homeModelSource;
        //}

        IMediator _mediator;

        public HomeController(IMediator mediator) {
            _mediator = mediator;
        }
        

        public ActionResult Index()
        {
            var model = _mediator.Enquire<HomeQuery, HomeModel>(new HomeQuery());
            //var model = _homeModelSource.GetModel();

            return View(model);
        }

    }
}