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
using Brigita.Queries;
using Brigita.Queries;

namespace Brigita.Web.Services
{
    public class LinkProvider : ILinkProvider
    {        
        static Dictionary<Type, object> _dFn = new Dictionary<Type, object>();

        static LinkProvider() {
            var registrar = new LinkRegistrar(_dFn);
            Links.Register(registrar);
        }
                
        public Link GetLinkFor<T>(T obj) {
            var fn = (Func<T, Link>)_dFn[typeof(T)];
            return fn(obj);
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
