﻿using Brigita.Infrastructure;
using Brigita.Dom.Services.Cache;
using Brigita.Dom.Services.Categories;
using Brigita.Dom.Services.Plugins;
using Brigita.Dom.Services.Stores;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Core.Domain;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Seo;
using Nop.Core.Domain.Tax;
using Nop.Core.Fakes;
using Nop.Core.Plugins;
using Nop.Data;
using Nop.Services.Authentication;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Customers;
using Nop.Services.Directory;
using Nop.Services.Events;
using Nop.Services.Helpers;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Stores;
using Nop.Services.Vendors;
using Nop.Web.Framework;
using Nop.Web.Framework.UI;
using System.Runtime.Caching;
using System.Web;
using Brigita.Dom.Services.Pages;
using Brigita.Dom.Services.Products;
using Brigita.View.Services;
using Brigita.Web.Services;
using Brigita.View.Services.Products;
using Brigita.View.Services.Home;
using Brigita.View.Services.Menu;
using Brigita.Dom.Services.Media;
using Brigita.Data;
using Nop.Services.Media;
using Brigita.Dom.Services.Context;

namespace Brigita.Web
{
    public static class Dependencies
    {
        public static void Register(IDependencyBinder x) {
            //x.Bind<HttpContextBase>(_ =>
            //        HttpContext.Current != null 
            //            ? new HttpContextWrapper(HttpContext.Current) as HttpContextBase
            //            : new FakeHttpContext("~/"));

            x.Bind<HttpContext>(_ => HttpContext.Current);
            x.Bind<HttpContextBase>(_ => new HttpContextWrapper(HttpContext.Current));

            x.Bind(c => c.Resolve<HttpContext>().Request);
            x.Bind(c => c.Resolve<HttpContext>().Response);
            x.Bind(c => c.Resolve<HttpContext>().Server);
            x.Bind(c => c.Resolve<HttpContext>().Session);

            x.BindSingleton<ICache>(_ => new BrigitaCache(MemoryCache.Default));
            x.Bind<ICacheManager, MemoryCacheManager>();

            //x.Register<IRoutePublisher, RoutePublisher>();

            x.Bind<IEventPublisher, EventPublisher>();
            x.Bind<ISubscriptionService, SubscriptionService>();

            x.Bind<IGenericAttributeService, GenericAttributeService>();

            x.Bind<IPluginFinder, BrigitaPluginFinder>();

            x.Bind<ILogger, NullLogger>();


            x.BindGeneric(typeof(IRepo<>), typeof(Repo<>));
            x.BindGenericSingleton(typeof(ILocalizerSource<>), typeof(LocalizerSource<>));

            x.Bind<ILinkProvider, LinkProvider>();

            x.Bind<IPiccies, Piccies>();
            x.Bind<IPictureService, PictureService>();

            x.Bind<IHomeModelSource, HomeModelSource>();
            x.Bind<IProductTeasers, ProductTeasers>();
            x.Bind<ICatMenuModelSource, CatMenuModelSource>();
            x.Bind<IProductDetailsSource, ProductDetailsSource>();

            x.Bind<ILocaleContext, LocaleContext>();
            x.Bind<IWorkContext, BrigitaWorkContext>();


            x.Bind<IPageHelper, PageHelper>();
            x.Bind<ILinkHelper, LinkHelper>();

            //!!!!!!!! JUST FOR TESTING... !!!!!!!!!
            x.Bind(new StoreInformationSettings());
            x.Bind(new TaxSettings());
            x.Bind(new CurrencySettings());
            x.Bind(new LocalizationSettings());
            x.Bind(new CustomerSettings());
            x.Bind(new CommonSettings());
            x.Bind(new CatalogSettings());
            x.Bind(new SeoSettings());
            x.Bind<ISettingService, SettingService>();

            x.Bind<IUserAgentHelper, UserAgentHelper>();
            x.Bind<IWebHelper, WebHelper>();

            /*x.Bind<IWorkContext, WebWorkContext>();*/
            x.Bind<IStoreContext, WebStoreContext>();

            x.Bind<ICategories, BrigitaCategories>();
            x.Bind<IScopedCategories, ScopedCategories>();

            x.Bind<IProducts, BrigitaProducts>();


            x.Bind<ICustomerService, CustomerService>();
            x.Bind<IVendorService, VendorService>();
            x.Bind<IStoreService, BrigitaStores>();
            x.Bind<IAuthenticationService, FormsAuthenticationService>();
            x.Bind<ILanguageService, LanguageService>();
            x.Bind<ICurrencyService, CurrencyService>();
            x.Bind<IStoreMappingService, StoreMappingService>();

            x.Bind<IPageHeadBuilder, PageHeadBuilder>();

            //data layer
            var dataSettingsManager = new DataSettingsManager();
            var dataProviderSettings = dataSettingsManager.LoadSettings();
            x.Bind<DataSettings>(c => dataSettingsManager.LoadSettings());

            x.BindTransient<BaseDataProviderManager, EfDataProviderManager>();
            x.BindTransient<IDataProvider>(c => c.Resolve<BaseDataProviderManager>().LoadDataProvider());

            if(dataProviderSettings != null && dataProviderSettings.IsValid()) {
                var efDataProviderManager = new EfDataProviderManager(dataSettingsManager.LoadSettings());
                var dataProvider = efDataProviderManager.LoadDataProvider();
                dataProvider.InitConnectionFactory();

                x.Bind<IDbContext>(c => new NopObjectContext(dataProviderSettings.DataConnectionString, false, false));
            }
            else {
                x.Bind<IDbContext>(c => new NopObjectContext(dataSettingsManager.LoadSettings().DataConnectionString, false, false));
            }

            x.BindGeneric(typeof(IRepository<>), typeof(EfRepository<>));



            //all entities taken from the db should be auto cached, 


        }
    }
}