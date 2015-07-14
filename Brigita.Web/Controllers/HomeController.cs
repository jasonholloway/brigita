using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Brigita.Web.Models;
using Nop.Web.Framework;
using Brigita.Web.Models.Home;

namespace Brigita.Web.Controllers
{
    public class HomeController : PageController
    {
        public HomeController() {

        }

        public ActionResult Index()
        {
            var model = base.CreatePageModel<HomeModel>();

            model.Greeting = new HtmlString("Jason! Hello! HELLO! BOO! GRRRRRR!");

            return View(model);
        }

    }
}