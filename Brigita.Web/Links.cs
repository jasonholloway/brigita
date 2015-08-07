using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Brigita.Dom.Categories;
using Brigita.Dom.Products;
using Brigita.Infrastructure.Pages;
using Brigita.View;
using Brigita.View.Products;
using Brigita.View.Services;
using Brigita.View.Services.Products;
using Brigita.Web.Infrastructure;
using Brigita.Web.Services;

namespace Brigita.Web
{
    public static class Links
    {
        public static void Register(LinkRegistrar x) 
        {
            x.Register<IScopedCategory>(
                c => new MvcLink("ProductList", "Category", new { CategoryID = c.ID }));
            
            x.Register<ITinyProduct>(
                p => new MvcLink("Product", "Details", new { ProductID = p.ID }));

            x.Register<ProductTeaserPageSpec>(
                s => new MvcLink("ProductList", "Category", new { CategoryID = s.CategoryID, PageIndex = s.PageIndex }));
        
        
            //how to get categoryid? Obvs need more than just the bare, generic model.
            //I either specialise the model, or introduce some secondary route of communication, a contextual round-the-houses kind-of-thing.
            //The contextual approach is naff.



        }        
    }
}
