using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Brigita.Web.Models;
using Nop.Web.Framework;
using Brigita.Web.Models.Home;
using Nop.Core.Domain;
using Nop.Core.Domain.Seo;
using Nop.Web.Framework.UI;
using Nop.Core;
using Brigita.Services.Pages;

namespace Brigita.Web.Controllers
{
    public class HomeController : Controller
    {
        StoreInformationSettings _storeInfoSettings;
        SeoSettings _seoSettings;
        IWebHelper _webHelper;
        IPageHelper _pageHelper;

        public HomeController(
                    StoreInformationSettings storeInfoSettings,
                    SeoSettings seoSettings,
                    IWebHelper webHelper,
                    IPageHelper pageHelper) 
        {
            _storeInfoSettings = storeInfoSettings;
            _seoSettings = seoSettings;
            _webHelper = webHelper;
            _pageHelper = pageHelper;
        }

        public ActionResult Index()
        {
            var model = new HomeModel() { 
                Title = _pageHelper.BuildPageTitle("Brigitas Bodite"),
                Greeting = "Hullo. ho do you do?"
            };

            return View(model);
        }

    }
}