using Brigita.Core.Infrastructure.Pages;
using Brigita.Domain.Products;
using Brigita.Services.Cache;
using Brigita.Services.Categories;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Services.Products
{
    [CacheZone("Products")]
    public class BrigitaProducts : IProducts
    {
        IRepository<NopProduct> _repo;
        ICategories _cats;

        public BrigitaProducts(IRepository<NopProduct> repo, ICategories cats) {
            _repo = repo;
            _cats = cats;
        }
        
        [Cache("ByCategory")]
        public IProduct[] GetByCategoryID(int catalogID) 
        {          
            var cats = _cats.FindCatFamily(catalogID) //array for EF's sake
                                    .Select(c => c.ID)
                                    .ToArray();
            
            return _repo.TableNoTracking
                        .Where(p => p.ProductCategories.Any(c => cats.Contains(c.CategoryId)))
                        .ToArray();                                                            
        }
        

        [Cache("TeasersByCategory")]
        public ListPage<IProductTeaser> GetTeasersByCategoryID(int categoryID, int page) 
        {
            var cats = _cats.FindCatFamily(categoryID)
                                    .Select(c => c.ID)
                                    .ToArray();
            
            var teasers = _repo.TableNoTracking
                                    .Where(p => p.ProductCategories
                                                    .Any(pc => cats.Contains(pc.CategoryId)))
                                    .Select(p => new _ProductTeaser(p))                                                            
                                    .ToArray();

            return new ListPage<IProductTeaser>(teasers, 1, 1); //!!!!!!!!!!!!!  
        }





        class _ProductTeaser : IProductTeaser 
        {

            public _ProductTeaser(IProduct product) {
                ID = product.ID;
                Name = product.Name;
                ShortDescription = product.ShortDescription;
                Price = product.Price;
                //Picture = 
            }

            public int ID { get; set; }
            public string Name { get; set; }
            public string ShortDescription { get; set; }
            public decimal Price { get; set; }
            public object Picture { get; set; }
        }

    }


}
