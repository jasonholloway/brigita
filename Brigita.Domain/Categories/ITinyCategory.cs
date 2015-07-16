using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Domain.Categories
{
    public interface ITinyCategory : IEntity
    {
        string Name { get; }
    }
}
