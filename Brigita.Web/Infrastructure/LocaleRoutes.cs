using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Reflection;

namespace Brigita.Web.Infrastructure
{
    class LocaleRouteHandler : IRouteHandler
    {
        IRouteHandler _innerHandler;

        public LocaleRouteHandler(IRouteHandler innerHandler) {
            _innerHandler = innerHandler;
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext) {
            object localeObj = null;

            if(requestContext.RouteData.Values.TryGetValue("locale", out localeObj)) 
            {                    
                requestContext.HttpContext.Items["locale"] = ((string)localeObj).ToLower();
                requestContext.RouteData.Values.Remove("locale");
            }

            //should somehow set thread culture?
            //does this actually matter?

            return _innerHandler.GetHttpHandler(requestContext);
        }
    }

    
    public class LocaleRoute : RouteBase
    {
        Route _routeWithLocale;
        Route _routeWithoutLocale;

        public LocaleRoute(
                    string pattern, 
                    RouteValueDictionary defaults, 
                    RouteValueDictionary constraints,
                    RouteValueDictionary tokens,
                    string[] namespaces,
                    IRouteHandler routeHandler)
        {
            var localeConstraints = new RouteValueDictionary(constraints);
            localeConstraints.Add("locale", @"[a-zA-Z]{2}");

            _routeWithLocale = new Route(
                                    @"{locale}/" + pattern,
                                    defaults,
                                    localeConstraints,
                                    tokens,
                                    new LocaleRouteHandler(routeHandler));

            _routeWithoutLocale = new Route(
                                        pattern,
                                        defaults,
                                        constraints,
                                        tokens,
                                        routeHandler);

            if(namespaces != null && namespaces.Any()) {
                _routeWithLocale.DataTokens["Namespaces"] = namespaces;
                _routeWithoutLocale.DataTokens["Namespaces"] = namespaces;
            }
        }

        public override RouteData GetRouteData(HttpContextBase httpContext) 
        {
            var data = _routeWithLocale.GetRouteData(httpContext);

            if(data == null) {
                data = _routeWithoutLocale.GetRouteData(httpContext);
            }

            return data;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values) 
        {
            if(values.ContainsKey("locale")) {
                var result = _routeWithLocale.GetVirtualPath(requestContext, values);

                if(result != null) {
                    return result;
                }
            }

            return _routeWithoutLocale.GetVirtualPath(requestContext, values);
        }
    }


    public static class LocaleRouteExtensions
    {
        public static LocaleRoute MapRouteWithLocale(
                                    this RouteCollection routes, 
                                    string name,
                                    string url) 
        {
            return routes.MapRouteWithLocale(name, url, null, (object)null);
        }


        public static LocaleRoute MapRouteWithLocale(
                                    this RouteCollection routes, 
                                    string name, 
                                    string url,
                                    object defaults) 
        {
            return routes.MapRouteWithLocale(name, url, defaults, (object)null);
        }


        public static LocaleRoute MapRouteWithLocale(
                                    this RouteCollection routes, 
                                    string name, 
                                    string url,
                                    string[] namespaces) 
        {
            return routes.MapRouteWithLocale(name, url, null /* defaults */, null /* constraints */, namespaces);
        }


        public static LocaleRoute MapRouteWithLocale(
                                    this RouteCollection routes, 
                                    string name, 
                                    string url, 
                                    object defaults,
                                    object constraints) 
        {
            return routes.MapRouteWithLocale(name, url, defaults, constraints, null /* namespaces */);
        }


        public static LocaleRoute MapRouteWithLocale(
                                    this RouteCollection routes, 
                                    string name, 
                                    string url, 
                                    object defaults,
                                    string[] namespaces) 
        {
            return routes.MapRouteWithLocale(name, url, defaults, null /* constraints */, namespaces);
        }


        public static LocaleRoute MapRouteWithLocale(
                                    this RouteCollection routes, 
                                    string name, 
                                    string url, 
                                    object defaults, 
                                    object constraints,
                                    string[] namespaces) 
        {
            if(routes == null) {
                throw new ArgumentNullException("routes");
            }
            if(url == null) {
                throw new ArgumentNullException("url");
            }

            var route = new LocaleRoute(
                                    url,
                                    BuildDictionary(defaults),
                                    BuildDictionary(constraints),
                                    new RouteValueDictionary(),
                                    namespaces,
                                    new MvcRouteHandler()
                                    );

            routes.Add(name, route);

            return route;
        }


        static RouteValueDictionary BuildDictionary(object obj) 
        {
            if(obj == null) {
                return new RouteValueDictionary();
            }

            if(obj is IDictionary<string, object>) {
                return new RouteValueDictionary((IDictionary<string, object>)obj);
            }

            var dict = new RouteValueDictionary();

            foreach(var prop in obj.GetType().GetProperties()) {
                dict[prop.Name] = prop.GetValue(obj);
            }

            return dict;
        }

    }

}
