using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Domain.Localization;

namespace Brigita.Dom.Services.Locale
{
    public interface ILocaleContext
    {
        Language CurrentLanguage { get; }
    }
}
