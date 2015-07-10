using Brigita.Domain.Categories;
using Brigita.Core.Infrastructure.Trees;
using Brigita.Services.Cache;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Services.Categories
{
    [CacheZone("Categories")]
    public class BrigitaCategories
        : ICategories
    {
        IRepository<Category> _repo;
        
        public BrigitaCategories(IRepository<Category> repo) {
            _repo = repo;
        }

        public ICategory[] All {
            [Cache("All")]
            get {
                return _repo.Table.ToArray();
            }
        }
        
        public SimpleTree<ICategory> Tree {
            [Cache("Tree", "All")]
            get {
                return SimpleTree.BuildFromIndexedItems(
                                        this.All,
                                        c => c.ID,
                                        c => c.ParentCategoryId
                                        );
            }
        }




        public ICategory GetByID(int id) {
            throw new NotImplementedException();
        }

        public ICategory GetByName(string name) {
            throw new NotImplementedException();
        }


    }
}
