﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Localization;

namespace Brigita.Dom.Services.Localization
{
    public interface ILocaleContext
    {
        Language Language { get; }
        Currency Currency { get; }
    }
}
