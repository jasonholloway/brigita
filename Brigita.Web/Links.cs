using Brigita.Dom.Categories;
using Brigita.Queries.Teasers;
using Brigita.Web.Infrastructure;
using Brigita.Web.Services;

namespace Brigita.Web
{
    public static class Links
    {
        public static void Register(LinkRegistrar x) 
        {
            x.Register<IScopedCategory>(
                c => new MvcLink("Teasers", "Category", new { CategoryID = c.ID }));
            
            x.Register<TeaserModel>(
                p => new MvcLink("Product", "Details", new { ProductID = p.ID }));

            x.Register<TeaserPageQuery>(
                q => new MvcLink("Teasers", "Category", new { CategoryID = q.CategoryID, PageIndex = q.PageSpec.PageIndex }));
        
        }        
    }
}
