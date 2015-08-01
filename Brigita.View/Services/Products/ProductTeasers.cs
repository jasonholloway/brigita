using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Infrastructure.Pages;
using Brigita.Dom.Services.Categories;
using Brigita.Dom.Services.Products;
using Brigita.View.Bits;
using Brigita.View.Products;
using Brigita.Dom.Services.Media;

namespace Brigita.View.Services.Products
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

        public ProductTeaserPage GetPage(int categoryID, ListPageSpec pageSpec) 
        {            
            var cat = _cats.FindCat(categoryID);

            if(cat == null) {
                throw new ArgumentException("Bad CategoryID!");
            }

            var teaserPage = new ProductTeaserPage() {                
                CurrentCategoryID = categoryID,
                CurrentCategoryName = cat.Name
            };


            var productListPage = _prods.GetTinyProductsByCategory(
                                            categoryID,
                                            pageSpec 
                                            );

            teaserPage.ListPage = new ListPageModel<ProductTeaser>(
                                    productListPage.Project(
                                                        p => {
                                                            return new ProductTeaser() {
                                                                    Name = p.Name,
                                                                    Price = p.Price,
                                                                    Link = _links.GetLinkFor(p),
                                                                    Image = p.PictureID != null 
                                                                                ? _piccies.GetByID((int)p.PictureID) 
                                                                                : null
                                                            };
                                                        }),
                                    null
                                    );

            return teaserPage;
        }
    }
}
