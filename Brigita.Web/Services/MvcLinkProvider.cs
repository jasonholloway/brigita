using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Brigita.Dom.Categories;
using Brigita.Dom.Products;
using Brigita.View;
using Brigita.View.Services;

namespace Brigita.Web.Services
{
    public class MvcLinkProvider : ILinkProvider
    {        
        static Dictionary<Type, object> _dFn = new Dictionary<Type, object>();

        static MvcLinkProvider() {
            var registrar = new LinkRegistrar(_dFn);
            Links.Register(registrar);
        }
     

        public Link GetLinkFor<T>(T obj) {
            var fn = (Func<T, Link>)_dFn[typeof(T)];
            return fn(obj);
        }

    }


    public class MvcLink : Link
    {
        public string ControllerName { get; private set; }
        public string ActionName { get; private set; }
        public object RouteValues { get; private set; }

        public MvcLink(string controller, string action, object routeValues) {
            ControllerName = controller;
            ActionName = action;
            RouteValues = routeValues;
        }
    }



    public class LinkRegistrar
    {
        Dictionary<Type, object> _dFn;

        public LinkRegistrar(Dictionary<Type, object> dFn) {
            _dFn = dFn;
        }

        public void Register<TModel>(Func<TModel, Link> fn) {
            _dFn[typeof(TModel)] = fn;
        }


    }



}
