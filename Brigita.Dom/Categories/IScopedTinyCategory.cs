using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Dom.Categories
{
    public interface IScopedTinyCategory : ITinyCategory
    {
        bool IsActive { get; }
        bool IsActiveParent { get; }
    }
}
