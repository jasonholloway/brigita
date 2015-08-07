using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Infrastructure
{
    public interface IScanner
    {
        IEnumerable<Type> ScanTypes(params Assembly[] assemblies);
        IEnumerable<Type> ScanTypes(IEnumerable<Assembly> assemblies);
        IEnumerable<Type> GetImplOf<TInterface>();
    }
}
