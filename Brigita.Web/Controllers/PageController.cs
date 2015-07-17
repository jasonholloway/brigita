//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Brigita.Web.ViewModels;
//using Nop.Core.Domain;
//using Nop.Core.Domain.Seo;
//using Nop.Core.Infrastructure;
//using Nop.Web.Framework.UI;
//using Nop.Core;
//using Brigita.Web.Domain.Models;

//namespace Brigita.Web.Controllers
//{
//    public abstract class PageController : Controller
//    {
//        //StoreInformationSettings _storeInfoSettings;
//        //SeoSettings _seoSettings;
//        //IPageHeadBuilder _pageHeadBuilder; //not sure if i even need this really, what functionality does it add?
//        //IWebHelper _webHelper;

//        public PageController()
//        {
//            //var engine = EngineContext.Current;

//            //_storeInfoSettings = engine.Resolve<StoreInformationSettings>();
//            //_seoSettings = engine.Resolve<SeoSettings>();
//            //_pageHeadBuilder = engine.Resolve<IPageHeadBuilder>();       
//            //_webHelper = engine.Resolve<IWebHelper>();
//        }


//        public TPageModel CreatePageModel<TPageModel>()
//            where TPageModel : IWebPageModel, new()
//        {
//            var model = new TPageModel();
  
//            model.Title = _pageHeadBuilder.GenerateTitle(false);

//            model.HeadCustom = _pageHeadBuilder.GenerateHeadCustom());

//            model.MetaDescription = _pageHeadBuilder.GenerateMetaDescription());

//            model.MetaKeywords = _pageHeadBuilder.GenerateMetaKeywords());

//            model.CanonicalURLs = _pageHeadBuilder.GenerateCanonicalUrls());

//            model.DisplayProfiler = _storeInfoSettings.DisplayMiniProfilerInPublicStore;

//            model.FaviconUrl = _webHelper.GetStoreLocation() + "favicon.ico";





//            //populate any css links here?
//            //populate any script links here?

//            //controllers should have multiple output streams...
//            //their returned views should incorporate dictionaries of css & scripts,
//            //all to be brought together in the header
//            //these dictionaries would themselves be cached
//            //The page header would be generated finally


//            return model;
//        } 

//    }
//}