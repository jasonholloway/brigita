using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Brigita.Dom.Categories;
using Brigita.Dom.Products;
using Brigita.View;
using Brigita.View.Services;
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
                p => new MvcLink("Product", "Detail", new { ProductID = 0 }));
                
        }        
    }
}
