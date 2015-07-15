using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.DtoGen
{
    public interface IDtoSpec
    {
        string Name { get; }
        string Namespace { get; }
        
        Type[] Interfaces { get; }
        PropertyInfo[] Props { get; }
    }
}
