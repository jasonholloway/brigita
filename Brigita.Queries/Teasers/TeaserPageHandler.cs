using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Brigita.Dom.Products;
using Brigita.Dom.Services.Categories;
using Brigita.Dom.Services.Media;
using Brigita.Dom.Services.Products;
using Brigita.Infrastructure.Pages;
using Brigita.Queries.Bits;
using Nop.Core.Domain.Catalog;

namespace Brigita.Queries.Teasers
{
    public class TeaserPageHandler 
        : IQueryHandler<TeaserPageQuery, TeaserPageModel>
    {
        IProducts _prods;
        ICategories _cats;
        IPiccies _piccies;
        ILinkProvider _links; 

        public TeaserPageHandler(IProducts products, ICategories cats, IPiccies piccies, ILinkProvider links) {
            _prods = products;
            _cats = cats;
            _piccies = piccies;
            _links = links;
        }



        static TeaserPageHandler() {
            
        }


        public TeaserPageModel Enquire(TeaserPageQuery query) 
        {
            var cat = _cats.FindCat(query.CategoryID);

            if(cat == null) {
                throw new ArgumentException("Bad CategoryID!");
            }

            var teaserPage = new TeaserPageModel() {                
                CurrentCategoryID = query.CategoryID,
                CurrentCategoryName = cat.Name
            };


            var productListPage = _prods.GetTinyProductsByCategory(
                                            query.CategoryID,
                                            query.PageSpec.ProjectTo<ITinyProduct>()
                                            );

            var projectedPage = productListPage
                                    .Project(p => new TeaserModel() {
                                                        Name = p.Name,
                                                        Price = null, //p.Price,
                                                        Link = _links.GetLinkFor(p),
                                                        Image = p.PictureID != null 
                                                                    ? _piccies.GetByID((int)p.PictureID) 
                                                                    : null
                                                    });

            teaserPage.ListPage = new ListPageModel<TeaserModel>(
                                                        projectedPage,
                                                        i => _links.GetLinkFor(new TeaserPageQuery() {
                                                                                    CategoryID = query.CategoryID,
                                                                                    PageSpec = new ListPageSpec<TeaserModel>(i, query.PageSpec.PageSize)
                                                                                    }));
            
            return teaserPage;
        }




    }
}
