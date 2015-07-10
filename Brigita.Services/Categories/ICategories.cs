using Brigita.Domain.Categories;
using Brigita.Core.Infrastructure.Trees;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Services.Categories
{
    public interface ICategories
    {
        ICategory[] All { get; }
        SimpleTree<ICategory> Tree { get; }

        ICategory GetByID(int id);
        ICategory GetByName(string name);
    }
}
