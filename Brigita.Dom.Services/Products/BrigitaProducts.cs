using Brigita.Infrastructure.Pages;
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

namespace Brigita.Dom.Services.Products
{
    [CacheZone("Products")]
    public class BrigitaProducts : IProducts
    {
        IRepo<NopProduct> _repo;
        ICategories _cats;

        //repos should be lazy...

        public BrigitaProducts(IRepo<NopProduct> repo, ICategories cats) {
            _repo = repo;
            _cats = cats;
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

                                var pic = ((NopProduct)p).ProductPictures
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
