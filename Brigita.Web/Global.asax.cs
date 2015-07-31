using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FluentValidation.Mvc;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain;
using Nop.Core.Domain.Common;
using Nop.Core.Infrastructure;
using Nop.Services.Logging;
using Nop.Services.Tasks;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Routes;
using Nop.Web.Framework.Themes;
using StackExchange.Profiling;
using StackExchange.Profiling.Mvc;
using Brigita.Web.Infrastructure;
using Brigita.Infrastructure;
using Nop.Core.Configuration;
using System.Configuration;
using Brigita.Dom.Services.Categories;

namespace Brigita.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start() {
            var engine = new BrigitaEngine();

            engine.Build(Dependencies.Register);
            
            engine.RunStartUpTasks();

            EngineContext.Replace(engine);
            
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new BrigitaViewEngine());

            ModelMetadataProviders.Current = new NopMetadataProvider();

            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //Registering areas by scanning all assemblies is a slow business!
            //Much better to do it manually, when needed
//            AreaRegistration.RegisterAllAreas();

            Routes.Register(RouteTable.Routes);

            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            ModelValidatorProviders.Providers.Add(
                new FluentValidationModelValidatorProvider(new NopValidatorFactory())
                );


//            TaskManager.Instance.Initialize(); //VERY SLOW! IS IT NEEDED FOR NOW???????
//            TaskManager.Instance.Start();

            if(EngineContext.Current.Resolve<StoreInformationSettings>().DisplayMiniProfilerInPublicStore) {
                GlobalFilters.Filters.Add(new ProfilingActionFilter());
            }

            try {
                var logger = EngineContext.Current.Resolve<ILogger>();
                logger.Information("Application started", null, null);
            }
            catch(Exception) {
                //...
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e) {
            //ignore static resources
            var webHelper = EngineContext.Current.Resolve<IWebHelper>();
            if(webHelper.IsStaticResource(this.Request))
                return;

            //keep alive page requested (we ignore it to prevent creating a guest customer records)
            string keepAliveUrl = string.Format("{0}keepalive/index", webHelper.GetStoreLocation());
            if(webHelper.GetThisPageUrl(false).StartsWith(keepAliveUrl, StringComparison.InvariantCultureIgnoreCase))
                return;

            //ensure database is installed
            if(!DataSettingsHelper.DatabaseIsInstalled()) {
                string installUrl = string.Format("{0}install", webHelper.GetStoreLocation());
                if(!webHelper.GetThisPageUrl(false).StartsWith(installUrl, StringComparison.InvariantCultureIgnoreCase)) {
                    this.Response.Redirect(installUrl);
                }
            }

            if(!DataSettingsHelper.DatabaseIsInstalled())
                return;

            //miniprofiler
            if(EngineContext.Current.Resolve<StoreInformationSettings>().DisplayMiniProfilerInPublicStore) {
                MiniProfiler.Start();
                //store a value indicating whether profiler was started
                HttpContext.Current.Items["nop.MiniProfilerStarted"] = true;
            }
        }

        protected void Application_EndRequest(object sender, EventArgs e) {
            //miniprofiler
            var miniProfilerStarted = HttpContext.Current.Items.Contains("nop.MiniProfilerStarted") &&
                 Convert.ToBoolean(HttpContext.Current.Items["nop.MiniProfilerStarted"]);
            if(miniProfilerStarted) {
                MiniProfiler.Stop();
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {
            //we don't do it in Application_BeginRequest because a user is not authenticated yet
            SetWorkingCulture();
        }

        protected void Application_Error(Object sender, EventArgs e) {
            var exception = Server.GetLastError();

            //log error
            LogException(exception);

            //process 404 HTTP errors
            var httpException = exception as HttpException;
            if(httpException != null && httpException.GetHttpCode() == 404) {
                var webHelper = EngineContext.Current.Resolve<IWebHelper>();
                if(!webHelper.IsStaticResource(this.Request)) {
                    Response.Clear();
                    Server.ClearError();
                    Response.TrySkipIisCustomErrors = true;

                    // Call target Controller and pass the routeData.
                    //IController errorController = EngineContext.Current.Resolve<CommonController>();
                    //
                    //var routeData = new RouteData();
                    //routeData.Values.Add("controller", "Common");
                    //routeData.Values.Add("action", "PageNotFound");

                    //errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));


                    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
                }
            }
        }

        protected void SetWorkingCulture() {
            if(!DataSettingsHelper.DatabaseIsInstalled())
                return;

            //ignore static resources
            var webHelper = EngineContext.Current.Resolve<IWebHelper>();
            if(webHelper.IsStaticResource(this.Request))
                return;

            //keep alive page requested (we ignore it to prevent creation of guest customer records)
            string keepAliveUrl = string.Format("{0}keepalive/index", webHelper.GetStoreLocation());
            if(webHelper.GetThisPageUrl(false).StartsWith(keepAliveUrl, StringComparison.InvariantCultureIgnoreCase))
                return;


            if(webHelper.GetThisPageUrl(false).StartsWith(string.Format("{0}admin", webHelper.GetStoreLocation()),
                StringComparison.InvariantCultureIgnoreCase)) {
                //admin area


                //always set culture to 'en-US'
                //we set culture of admin area to 'en-US' because current implementation of Telerik grid 
                //doesn't work well in other cultures
                //e.g., editing decimal value in russian culture
                CommonHelper.SetTelerikCulture();
            }
            else {
                //public store
                var workContext = EngineContext.Current.Resolve<IWorkContext>();
                var culture = new CultureInfo(workContext.WorkingLanguage.LanguageCulture);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }
        }

        protected void LogException(Exception exc) {
            if(exc == null)
                return;

            if(!DataSettingsHelper.DatabaseIsInstalled())
                return;

            //ignore 404 HTTP errors
            var httpException = exc as HttpException;
            if(httpException != null && httpException.GetHttpCode() == 404 &&
                !EngineContext.Current.Resolve<CommonSettings>().Log404Errors)
                return;

            try {
                //log
                var logger = EngineContext.Current.Resolve<ILogger>();
                var workContext = EngineContext.Current.Resolve<IWorkContext>();
                logger.Error(exc.Message, exc, workContext.CurrentCustomer);
            }
            catch(Exception) {
                //don't throw new exception if occurs
            }
        }
    }
}