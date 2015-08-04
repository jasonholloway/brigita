using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Brigita.Web.Controllers;
using Brigita.Web.Test.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcRouteTester;
using MvcRouteTester.Fluent;

namespace Brigita.Web.Test
{
    [TestClass]
    public class RouteTests
    {
        RouteCollection _routes;
        RouteEvaluator _eval;

        [TestInitialize]
        public void Init() {
            _routes = new RouteCollection();
            Routes.Register(_routes);

            _eval = new RouteEvaluator(_routes);
        }


        [TestMethod]
        public void HomeResolves() {            
            var data = _eval.GetMatches("~/").First();

            Assert.AreEqual("Home", data.Values["controller"]);
            Assert.AreEqual("Index", data.Values["action"]);
        }



        [TestMethod]
        public void LocaleResolves() 
        {
            _routes.ShouldMap("~/lv")
                        .To<HomeController>(x => x.Index());

            _routes.ShouldMap("~/")
                        .To<HomeController>(x => x.Index());
        }






        [TestMethod]
        public void ProductCategoriesResolve() 
        {
            //Ultimately needs to be better than this!
            //need hierarchy of categories - ie special route

            var urls = new[] {
                            "~/products/jumpers/3",
                            "~/products/sweaters"
                        };

            var datas = urls.Select(u => _eval.GetMatches(u).First());

            foreach(var data in datas) {
                Assert.AreEqual("ProductList", data.Values["controller"]);
                Assert.AreEqual("CategoryByName", data.Values["action"]);
            }
        }


        [TestMethod]
        public void ProductListVirtualPaths() {

            //To test this we need to mock the request context nicely
            //somehow...

            var httpContext = new Mock<HttpContextBase>().Object;

            var requestContext = new RequestContext(httpContext, new RouteData(_routes["Home"], null));

            var url = new UrlHelper(requestContext, _routes);

            var path = url.Action(
                            "CategoryByName", 
                            "ProductList", 
                            new { 
                                categoryName = "socks", 
                                pageIndex = 0 
                            });

            Assert.AreEqual("~/products/socks", path);
        }

    }
}
