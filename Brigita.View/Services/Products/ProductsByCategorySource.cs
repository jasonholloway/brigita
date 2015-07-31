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

namespace Brigita.View.Services.Products
{
    public class ProductsByCategorySource : IProductsByCategorySource
    {
        IProducts _prods;
        ICategories _cats;
        ILinkProvider _links; 

        public ProductsByCategorySource(IProducts products, ICategories cats, ILinkProvider links) {
            _prods = products;
            _cats = cats;
            _links = links;
        }

        public ProductsByCategoryModel GetModel(int categoryID, ListPageSpec pageSpec) 
        {            
            var cat = _cats.FindCat(categoryID);

            if(cat == null) {
                throw new ArgumentException("Bad CategoryID!");
            }

            var model = new ProductsByCategoryModel() {                
                CurrentCategoryID = categoryID,
                CurrentCategoryName = cat.Name
            };


            var productListPage = _prods.GetTinyProductsByCategory(
                                            categoryID,
                                            pageSpec 
                                            );

            model.ListPage = new ListPageModel<ProductTeaserModel>(
                                    productListPage.Project(
                                                        p => {
                                                            return new ProductTeaserModel() {
                                                                    Name = p.Name,
                                                                    Price = p.Price,
                                                                    Link = _links.GetLinkFor(p),
                                                                    Image = null
                                                            };
                                                        }),
                                    null
                                    );

            return model;
        }
    }
}
