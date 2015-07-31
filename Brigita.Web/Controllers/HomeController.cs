using System.Linq;
using System.Web.Mvc;
using Brigita.View.Services.Home;

namespace Brigita.Web.Controllers
{
    public class HomeController : Controller
    {
        IHomeModelSource _homeModelSource;

        public HomeController(IHomeModelSource homeModelSource) {
            _homeModelSource = homeModelSource;
        }

        public ActionResult Index()
        {
            var model = _homeModelSource.GetModel();

            return View(model);
        }

    }
}