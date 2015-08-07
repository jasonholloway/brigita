using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Queries
{
    /// <summary>
    /// Provides ViewModel with presentation-layer urls to viewmodel controllers
    /// </summary>
    public interface ILinkProvider
    {
        Link GetLinkFor<T>(T obj); 
    }

}
