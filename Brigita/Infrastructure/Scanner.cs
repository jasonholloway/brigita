using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Infrastructure
{
    class Scanner : IScanner
    {
        //Type system should ensure only one assembly object served
        static ConcurrentDictionary<Assembly, Type[]> _dAsmTypes = new ConcurrentDictionary<Assembly, Type[]>();

        public IEnumerable<Type> ScanTypes(params Assembly[] assemblies) {
            return ScanTypes(assemblies.AsEnumerable());
        }
        
        public IEnumerable<Type> ScanTypes(IEnumerable<Assembly> assemblies) {
            return assemblies
                    .SelectMany(asm => _dAsmTypes.GetOrAdd(asm, k => k.GetTypes()));
        }

        public IEnumerable<Type> GetImplOf<TInterface>() {
            throw new NotImplementedException();
        }
    }
}
