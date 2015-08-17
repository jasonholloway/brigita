using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Brigita.Data;
using Brigita.Dom.Bits;
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
        : IQueryHandler<TeaserPageQuery, TeaserPageQuery>
    {
        IRepo<Product> _repo;

        public TeaserPageHandler(IRepo<Product> repo) {
            _repo = repo;
        }
        
        public TeaserPageQuery Enquire(TeaserPageQuery query) {            
            //Dom shouldn't serve pages, as these are only to be used in queries anyway
            //Dom should be per-entity as much as possible so as to simplify it.

            //get familial cats
            //...

            //get page via helper - goddagnabbit - helpers can work, i suppose.
            //though the usual idea is to get the domain as nice as possible
            //but i am legislating a shallow domain here, the Dom is being weeded out.
            //BUT we still have the domain supplied by the Repo<> class - this can 
            //provide our nice functionality. Or rather, yer Repo IQueryable + provided
            //extension methods
            //...

            throw new NotImplementedException();
        }
    }


    public class TeaserPageHandlerOld
        : IQueryHandler<TeaserPageQuery, TeaserPageModel>
    {
        IProducts _prods;
        ICategories _cats;
        IPiccies _piccies;
        ILinkProvider _links; 

        public TeaserPageHandlerOld(IProducts products, ICategories cats, IPiccies piccies, ILinkProvider links) {
            _prods = products;
            _cats = cats;
            _piccies = piccies;
            _links = links;
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
                                                        Price = null, 
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
