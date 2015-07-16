using Brigita.Domain.Categories;
using Brigita.Domain.Scope;
using Brigita.Core.Infrastructure.Trees;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Services.Categories
{
    public interface IScopedCategories
    {
        SimpleTree<IScopedCategory> GetTree(int activeCatID = 0);
    }
    
}
