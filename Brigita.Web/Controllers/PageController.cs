using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Brigita.Web.Models;
using Nop.Core.Domain;
using Nop.Core.Domain.Seo;
using Nop.Core.Infrastructure;
using Nop.Web.Framework.UI;
using Nop.Core;
using Brigita.Web.Domain.Models;

namespace Brigita.Web.Controllers
{
    public abstract class PageController : Controller
    {
        StoreInformationSettings _storeInfoSettings;
        SeoSettings _seoSettings;
        IPageHeadBuilder _pageHeadBuilder; //not sure if i even need this really, what functionality does it add?
        IWebHelper _webHelper;

        public PageController()
        {
            var engine = EngineContext.Current;

            _storeInfoSettings = engine.Resolve<StoreInformationSettings>();
            _seoSettings = engine.Resolve<SeoSettings>();
            _pageHeadBuilder = engine.Resolve<IPageHeadBuilder>();       
            _webHelper = engine.Resolve<IWebHelper>();
        }


        public TPageModel CreatePageModel<TPageModel>()
            where TPageModel : IWebPageModel, new()
        {
            var model = new TPageModel();

            



            model.WebPage.Title = this._pageHeadBuilder.GenerateTitle(false));

            model.WebPage.HeadCustom = MvcHtmlString.Create(this._pageHeadBuilder.GenerateHeadCustom());

            model.WebPage.MetaDescription = MvcHtmlString.Create(this._pageHeadBuilder.GenerateMetaDescription());

            model.WebPage.MetaKeywords = MvcHtmlString.Create(this._pageHeadBuilder.GenerateMetaKeywords());

            model.WebPage.CanonicalURLs = MvcHtmlString.Create(this._pageHeadBuilder.GenerateCanonicalUrls());

            model.WebPage.DisplayProfiler = this._storeInfoSettings.DisplayMiniProfilerInPublicStore;

            model.WebPage.FaviconUrl = new HtmlString(_webHelper.GetStoreLocation() + "favicon.ico");





            //populate any css links here?
            //populate any script links here?

            //controllers should have multiple output streams...
            //their returned views should incorporate dictionaries of css & scripts,
            //all to be brought together in the header
            //these dictionaries would themselves be cached
            //The page header would be generated finally


            return model;
        } 

    }
}