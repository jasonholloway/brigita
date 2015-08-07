using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Infrastructure
{
    public interface IRegistrar
    {
        void Register(IBinder binder, IScanner scanner);
    }
}
