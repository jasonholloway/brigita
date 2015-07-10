using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nop.Brigita.Models;
using Nop.Core.Domain;
using Nop.Core.Domain.Seo;
using Nop.Core.Infrastructure;
using Nop.Web.Controllers;
using Nop.Web.Framework.UI;

namespace Nop.Brigita.Controllers
{
    public class BrigitaBaseController : BasePublicController
    {
        public StoreInformationSettings StoreInfoSettings { get; private set; }
        public SeoSettings SeoSettings { get; private set; }
        public IPageHeadBuilder PageHeadBuilder { get; private set; }

        public BrigitaBaseController()
        {
            var engine = EngineContext.Current;

            this.StoreInfoSettings = engine.Resolve<StoreInformationSettings>();
            this.SeoSettings = engine.Resolve<SeoSettings>();
            this.PageHeadBuilder = engine.Resolve<IPageHeadBuilder>();       
        }


        public TPageModel CreatePageModel<TPageModel>(UrlHelper url)
            where TPageModel : PageModel, new()
        {
            var model = new TPageModel();

            model.Page.Title = MvcHtmlString.Create(this.PageHeadBuilder.GenerateTitle(false));

            model.Page.HeadCustom = MvcHtmlString.Create(this.PageHeadBuilder.GenerateHeadCustom());

            model.Page.MetaDescription = MvcHtmlString.Create(this.PageHeadBuilder.GenerateMetaDescription());

            model.Page.MetaKeywords = MvcHtmlString.Create(this.PageHeadBuilder.GenerateMetaKeywords());

            model.Page.CanonicalURLs = MvcHtmlString.Create(this.PageHeadBuilder.GenerateCanonicalUrls());

            model.Page.DisplayProfiler = this.StoreInfoSettings.DisplayMiniProfilerInPublicStore;

            //populate any css links here?
            //populate any script links here?

            return model;
        } 

    }
}