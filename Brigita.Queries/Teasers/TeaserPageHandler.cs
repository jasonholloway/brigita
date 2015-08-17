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
using AutoMapper.QueryableExtensions;
using Brigita.Dom.Services.Localization;

namespace Brigita.Queries.Teasers
{
    public class TeaserPageHandler
        : IQueryHandler<TeaserPageQuery, TeaserPageModel>
    {
        IRepo<Product> _repo;
        ICategories _cats;
        ILinkProvider _links;
        IPicSource _pics;
        ILocalizer<TeaserModel> _localizer;

        public TeaserPageHandler(
                    IRepo<Product> repo, 
                    ICategories cats, 
                    ILinkProvider links, 
                    IPicSource pics,
                    ILocalizer<TeaserModel> localizer) 
        {
            _repo = repo;
            _cats = cats;
            _links = links;
            _pics = pics;
            _localizer = localizer;
        }
        
        public TeaserPageModel Enquire(TeaserPageQuery query) 
        {
            var familyOfCats = _cats.FindCatFamily(query.CategoryID);

            var primeCat = familyOfCats.First(c => c.ID == query.CategoryID);

            var catFamilyIDs = familyOfCats.Select(c => c.ID).ToArray();

            var teaserPage = _repo.Include(p => p.ProductPictures)
                                    .Where(p => p.ProductCategories
                                                    .Any(c => catFamilyIDs.Contains(c.CategoryId)))
                                    .ProjectTo<TeaserModel>()
                                    .GetPage(query.PageSpec.PageIndex, query.PageSpec.PageSize);


            //finalisation of model should be done by finalisation service
            foreach(var teaser in teaserPage.Items) {
                teaser.Link = _links.GetLinkFor(teaser);

                if(teaser.Picture != null) {
                    teaser.Picture = _pics.GetByID(teaser.Picture.Id);
                }
            }

            _localizer.Localize(teaserPage.Items);


            return new TeaserPageModel() {
                CurrentCategoryID = primeCat.ID,
                CurrentCategoryName = primeCat.Name,
                ListPage = new ListPageModel<TeaserModel>(
                                    teaserPage,
                                    i => _links.GetLinkFor(new TeaserPageQuery() { 
                                                                    CategoryID = primeCat.ID,
                                                                    PageSpec = new ListPageSpec<TeaserModel>(i, teaserPage.PageSize)
                                                                    })
                                    )
            };
        }
    }


    //public class TeaserPageHandlerOld
    //    : IQueryHandler<TeaserPageQuery, TeaserPageModel>
    //{
    //    IProducts _prods;
    //    ICategories _cats;
    //    IPiccies _piccies;
    //    ILinkProvider _links; 

    //    public TeaserPageHandlerOld(IProducts products, ICategories cats, IPiccies piccies, ILinkProvider links) {
    //        _prods = products;
    //        _cats = cats;
    //        _piccies = piccies;
    //        _links = links;
    //    }
                

    //    public TeaserPageModel Enquire(TeaserPageQuery query) 
    //    {
    //        var cat = _cats.FindCat(query.CategoryID);

    //        if(cat == null) {
    //            throw new ArgumentException("Bad CategoryID!");
    //        }

    //        var teaserPage = new TeaserPageModel() {                
    //            CurrentCategoryID = query.CategoryID,
    //            CurrentCategoryName = cat.Name
    //        };


    //        var productListPage = _prods.GetTinyProductsByCategory(
    //                                        query.CategoryID,
    //                                        query.PageSpec.ProjectTo<ITinyProduct>()
    //                                        );

    //        var projectedPage = productListPage
    //                                .Project(p => new TeaserModel() {
    //                                                    Name = p.Name,
    //                                                    Price = null, 
    //                                                    Link = _links.GetLinkFor(p),
    //                                                    Image = p.PictureID != null 
    //                                                                ? _piccies.GetByID((int)p.PictureID) 
    //                                                                : null
    //                                                });

    //        teaserPage.ListPage = new ListPageModel<TeaserModel>(
    //                                                    projectedPage,
    //                                                    i => _links.GetLinkFor(new TeaserPageQuery() {
    //                                                                                CategoryID = query.CategoryID,
    //                                                                                PageSpec = new ListPageSpec<TeaserModel>(i, query.PageSpec.PageSize)
    //                                                                                }));
            
    //        return teaserPage;
    //    }




    //}
}
