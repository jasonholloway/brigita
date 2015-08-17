using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Dom.Services.Localization
{
    public interface ICurrencyLocalizer<TSubject>
        : ILocalizer<TSubject>
        where TSubject : IEntity
    {
    }
}
