using Brigita.Dom.Categories;
using Brigita.Infrastructure.Trees;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Dom.Services.Categories
{
    public interface ICategories
    {
        ICategory[] All { get; }
        SimpleTree<ICategory> Tree { get; }

        ICategory FindCat(int id);
        ICategory FindCat(string name);

        ICategory[] FindCatFamily(int id);
    }
}
