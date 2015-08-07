using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Infrastructure.Pages;
using Brigita.Dom.Services.Categories;
using Brigita.Dom.Services.Products;
using Brigita.Queries.Bits;
using Brigita.Queries.Products;
using Brigita.Dom.Services.Media;
using Brigita.Dom.Products;

namespace Brigita.Queries.Products
{
    public class ProductTeasers : IProductTeasers
    {
        IProducts _prods;
        ICategories _cats;
        IPiccies _piccies;
        ILinkProvider _links; 

        public ProductTeasers(IProducts products, ICategories cats, IPiccies piccies, ILinkProvider links) {
            _prods = products;
            _cats = cats;
            _piccies = piccies;
            _links = links;
        }

        public ProductTeasersModel GetPage(int categoryID, ListPageSpec<ProductTeaser> pageSpec) 
        {            
            var cat = _cats.FindCat(categoryID);

            if(cat == null) {
                throw new ArgumentException("Bad CategoryID!");
            }

            var teaserPage = new ProductTeasersModel() {                
                CurrentCategoryID = categoryID,
                CurrentCategoryName = cat.Name
            };


            var productListPage = _prods.GetTinyProductsByCategory(
                                            categoryID,
                                            pageSpec.ProjectTo<ITinyProduct>()
                                            );

            var projectedPage = productListPage
                                    .Project(p => new ProductTeaser() {
                                                        Name = p.Name,
                                                        Price = p.Price,
                                                        Link = _links.GetLinkFor(p),
                                                        Image = p.PictureID != null 
                                                                    ? _piccies.GetByID((int)p.PictureID) 
                                                                    : null
                                                    });

            teaserPage.ListPage = new ListPageModel<ProductTeaser>(
                                                        projectedPage,
                                                        i => _links.GetLinkFor(new ProductTeaserPageSpec(
                                                                                        categoryID, 
                                                                                        i, 
                                                                                        pageSpec.PageSize
                                                                                        )));

            return teaserPage;
        }
    }

    public class ProductTeaserPageSpec : ListPageSpec<ProductTeaser>
    {
        public ProductTeaserPageSpec(int categoryID, int pageIndex, int pageSize)
            : base(pageIndex, pageSize) 
        {
            CategoryID = categoryID;
        }

        public int CategoryID { get; private set; }
    }
}
