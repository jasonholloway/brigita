﻿using Brigita.Infrastructure.Pages;
using Brigita.Dom.Products;
using Brigita.Dom.Services.Cache;
using Brigita.Dom.Services.Categories;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Nop.Services.Catalog;
using Brigita.Data;
using Nop.Core;
using Brigita.Dom.Services.Context;

namespace Brigita.Dom.Services.Products
{
    [CacheZone("Products")]
    public class BrigitaProducts : IProducts
    {
        IRepo<Product> _repo;
        ICategories _cats;
        IWorkContext _context;
        ILocalizerSource<Product> _localizerSrc;

        //repos should be lazy...

        public BrigitaProducts(IRepo<Product> repo, ICategories cats, IWorkContext context, ILocalizerSource<Product> localizerSrc) {
            _repo = repo;
            _cats = cats;
            _context = context;
            _localizerSrc = localizerSrc;
        }

        static BrigitaProducts() {
            Mapper.CreateMap<IProduct, TinyProduct>();
        }


        [Cache("ProductsByCategory")]
        public ListPage<IProduct> GetProductsByCategory(int categoryID, ListPageSpec pageSpec) 
        {          
            var cats = _cats.FindCatFamily(categoryID) //array for EF's sake
                                    .Select(c => c.ID)
                                    .ToArray();

            var productCount = _repo.Count(p => p.ProductCategories
                                                    .Any(c => cats.Contains(c.ID)));

            var products = _repo.Include(p => p.ProductPictures)
                                    .OrderByDescending(p => p.ID)
                                    .Where(p => p.ProductCategories.Any(c => cats.Contains(c.ID)))
                                    .Skip(pageSpec.PageIndex * pageSpec.PageSize)
                                    .Take(pageSpec.PageSize)
                                    .ToArray();
            
            var languageID = _context.WorkingLanguage.ID;
            var localizer = _localizerSrc.GetLocalizer(languageID);
            localizer.Localize(products);

            return new ListPage<IProduct>(
                                    products,
                                    pageSpec.PageIndex,
                                    pageSpec.PageSize,
                                    productCount / pageSpec.PageSize + 1);            
        }


        [Cache("TinyProductsByCategory", "ProductsByCategory")]
        public ListPage<ITinyProduct> GetTinyProductsByCategory(int categoryID, ListPageSpec pageSpec) 
        {
            var products = GetProductsByCategory(categoryID, pageSpec);

            var tinyProds = products
                            .Select(p => {
                                var tp = Mapper.Map<TinyProduct>(p);

                                var pic = ((Product)p).ProductPictures
                                                            .OrderBy(pp => pp.DisplayOrder)
                                                            .FirstOrDefault();

                                tp.PictureID = pic != null 
                                                    ? (int?)pic.PictureId 
                                                    : null;

                                return tp;
                            });

            return new ListPage<ITinyProduct>(
                                        tinyProds,
                                        products.PageIndex,
                                        products.PageSize,
                                        products.PageCount
                                        );
        }





    }


}
