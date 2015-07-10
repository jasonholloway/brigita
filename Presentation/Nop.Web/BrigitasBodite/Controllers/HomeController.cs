using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nop.Brigita.Models;
using Nop.Web.Controllers;
using Nop.Web.Framework;

namespace Nop.Brigita.Controllers
{
    public class HomeController : BrigitaBaseController
    {
        public ActionResult Index()
        {
            var model = CreatePageModel<HomeModel>(this.Url);

            model.Greeting = new HtmlString("Jason! Hello! HELLO! BOO!");

            return View(model);
        }

    }
}