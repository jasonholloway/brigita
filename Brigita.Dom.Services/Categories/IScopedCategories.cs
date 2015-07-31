using Brigita.Dom.Categories;
using Brigita.Dom.Scope;
using Brigita.Infrastructure.Trees;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Dom.Services.Categories
{
    public interface IScopedCategories
    {
        SimpleTree<IScopedCategory> GetTree(int activeCatID = 0);
    }
    
}
