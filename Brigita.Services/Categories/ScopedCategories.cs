using Brigita.Domain.Categories;
using Brigita.Domain.Scope;
using Brigita.Core.Infrastructure.Trees;
using Brigita.Services.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Services.Categories
{
    [CacheZone("ScopedCategories")]
    public class ScopedCategories : IScopedCategories
    {
        ICategories _cats;

        public ScopedCategories(ICategories cats) {
            _cats = cats;
        }

        [Cache("Tree", "Categories.Tree")]
        public SimpleTree<IScopedCategory> GetTree(PageScope scope) {
            var catTree = _cats.Tree;

            var scopedTree = catTree.Project(
                                        (node, path) => {
                                            var cat = node.Value;

                                            var scopedCat = new ScopedCategory() { 
                                                                    IsActive = scope.CategoryID == cat.ID,
                                                                    IsActiveParent = node.Flatten()
                                                                                            .Any(n => n.Value.ID == scope.CategoryID)
                                                                };

                                            scopedCat.PopulateFrom(cat);
                                            
                                            return (IScopedCategory)scopedCat;
                                        });

            return scopedTree;
        }
    }
}
