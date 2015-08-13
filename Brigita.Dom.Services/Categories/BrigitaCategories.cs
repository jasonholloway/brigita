using Brigita.Dom.Categories;
using Brigita.Infrastructure.Trees;
using Brigita.Dom.Services.Cache;
using Nop.Core.Domain.Catalog;
using System;
using System.Linq;
using Brigita.Data;
using Brigita.Dom.Services.Locale;

namespace Brigita.Dom.Services.Categories
{
    [CacheZone("Categories")]
    public class BrigitaCategories
        : ICategories
    {
        IRepo<Category> _repo;
        ILocalizer<Category> _localizer;
        
        public BrigitaCategories(IRepo<Category> repo, ILocalizer<Category> localizer) {
            _repo = repo;
            _localizer = localizer;
        }

        public ICategory[] All {
            [Cache("All")] //need to cache on locale
            get {
                var allCats = _repo.ToArray();
                _localizer.Localize(allCats);
                return allCats;
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
            return _repo.First(c => c.ID == id);
        }

        public ICategory[] FindCatFamily(int id) {
            var headNode = Tree.Flatten().FirstOrDefault(n => n.Value.ID == id); //this should be indexed!!!!

            return headNode != null
                    ? headNode.Flatten().Select(n => n.Value).ToArray()
                    : new ICategory[0];
        }

    }
}
