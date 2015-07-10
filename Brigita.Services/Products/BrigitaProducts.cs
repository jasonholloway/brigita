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
        ICategories _categories;

        public BrigitaProducts(IRepository<Product> repo) {
            _repo = repo;
        }
        
        [Cache("ByCategory")]
        public Product[] GetByCategoryID(int catalogID) {            
            return _repo.TableNoTracking
                        .Where(p => p.ProductCategories.Any(c => c.CategoryId == catalogID))
                        .ToArray();                                                            
        }
        

        [Cache("TeasersByCategory")]
        public ListPage<ProductTeaser> GetProductTeasersByCategory(int categoryID, int page) {
            var teasers = _repo.TableNoTracking
                                    .Where(p => p.ProductCategories
                                                    .Any(pc => pc.CategoryId == categoryID))
                                    .Select(p => new _ProductTeaser(
                                                                p.ID,
                                                                p.Name,
                                                                p.ShortDescription))
                                    .ToArray();

            return new ListPage<ProductTeaser>(teasers, 1, 1);            
        }



        class _ProductTeaser : ProductTeaser 
        {
            public _ProductTeaser(
                        int id,
                        string name,
                        string shortDesc
                        ) 
            {
                ID = id;
                Name = name;
                ShortDescription = shortDesc;
            }
        }

    }


}
