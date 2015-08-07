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
using Brigita.Data;
using Nop.Core;
using Brigita.Dom.Services.Context;

namespace Brigita.Dom.Services.Categories
{
    [CacheZone("Categories")]
    public class BrigitaCategories
        : ICategories
    {
        IRepo<NopCategory> _repo;
        IWorkContext _workCtx;
        ILocalizerSource<NopCategory> _localizerSrc;
        
        //The WorkContext/LocalizerSource combo should be encapsulated in a single service: would be much neater

        public BrigitaCategories(IRepo<NopCategory> repo, IWorkContext workCtx, ILocalizerSource<NopCategory> localizerSrc) {
            _repo = repo;
            _workCtx = workCtx;
            _localizerSrc = localizerSrc;
        }

        public ICategory[] All {
            [Cache("All")] //need to cache on locale
            get {
                var allCats = _repo.ToArray();

                var localizer = _localizerSrc.GetLocalizer(_workCtx.WorkingLanguage.ID);
                localizer.Localize(allCats);

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
