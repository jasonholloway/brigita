using Brigita.Dom.Categories;
using Brigita.Infrastructure.Trees;
using Brigita.Dom.Services.Cache;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Dom.Services.Categories
{
    [CacheZone("Categories")]
    public class BrigitaCategories
        : ICategories
    {
        IRepository<NopCategory> _repo;
        
        public BrigitaCategories(IRepository<NopCategory> repo) {
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




        public ICategory FindCat(string name) {
            throw new NotImplementedException();
        }
        
        public ICategory FindCat(int id) {
            return _repo.GetById(id); //EUUUURRRRRGH!!!!!
        }

        public ICategory[] FindCatFamily(int id) {
            var headNode = Tree.Flatten().FirstOrDefault(n => n.Value.ID == id); //this should be indexed!!!!

            return headNode != null
                    ? headNode.Flatten().Select(n => n.Value).ToArray()
                    : new ICategory[0];
        }

    }
}
