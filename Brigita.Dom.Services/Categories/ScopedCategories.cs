using Brigita.Dom.Categories;
using Brigita.Dom.Scope;
using Brigita.Infrastructure.Trees;
using Brigita.Dom.Services.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Dom.Services.Categories
{
    [CacheZone("ScopedCategories")]
    public class ScopedCategories : IScopedCategories
    {
        ICategories _cats;

        public ScopedCategories(ICategories cats) {
            _cats = cats;
        }

        [Cache("Tree", "Categories.Tree")]
        public SimpleTree<IScopedCategory> GetTree(int activeCatID) {
            var catTree = _cats.Tree;

            var scopedTree = catTree.Project(
                                        (node, path) => {
                                            var cat = node.Value;

                                            var scopedCat = new ScopedCategory() { 
                                                                    IsActive = activeCatID == cat.ID,
                                                                    IsActiveParent = node.Flatten()
                                                                                            .Except(new[] { node })
                                                                                            .Any(n => n.Value.ID == activeCatID)
                                                                };

                                            scopedCat.PopulateFrom(cat);
                                            
                                            return (IScopedCategory)scopedCat;
                                        });

            return scopedTree;
        }
    }
}
