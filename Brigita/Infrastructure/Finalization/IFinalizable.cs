using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Infrastructure.Finalization
{
    public interface IFinalizable
    {
        bool IsFinal { get; }
    }
}
