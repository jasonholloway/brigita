using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Core.Infrastructure
{
    public interface IDependencyContainer
    {
        T Resolve<T>();
    }
}
