using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Infrastructure;

namespace Brigita
{
    public abstract class StartupTask : IStartupTask
    {
        public abstract void Run();

        public virtual int Order {
            get { return 0; }
        }
    }
}
