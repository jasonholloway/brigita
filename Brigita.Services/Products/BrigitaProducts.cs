using Brigita.Core.Infrastructure.Pages;
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
        IRepository<Product> _repo;
        ICategories _cats;

        public BrigitaProducts(IRepository<Product> repo, ICategories cats) {
            _repo = repo;
            _cats = cats;
        }
        
        [Cache("ByCategory")]
        public Product[] GetByCategoryID(int catalogID) 
        {          
            var catHash = new HashSet<int>(_cats.FindCatFamily(catalogID)
                                                    .Select(c => c.ID));
            
            return _repo.TableNoTracking
                        .Where(p => p.ProductCategories.Any(c => catHash.Contains(c.CategoryId)))
                        .ToArray();                                                            
        }
        

        [Cache("TeasersByCategory")]
        public ListPage<IProductTeaser> GetTeasersByCategoryID(int categoryID, int page) 
        {
            var catHash = new HashSet<int>(_cats.FindCatFamily(categoryID)
                                                    .Select(c => c.ID));
            
            var teasers = _repo.TableNoTracking
                                    .Where(p => p.ProductCategories
                                                    .Any(pc => catHash.Contains(pc.CategoryId)))
                                    .Select(p => new _ProductTeaser(p))                                                            
                                    .ToArray();

            return new ListPage<IProductTeaser>(teasers, 1, 1); //!!!!!!!!!!!!!  
        }





        class _ProductTeaser : IProductTeaser 
        {

            public _ProductTeaser(Product product) {
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
