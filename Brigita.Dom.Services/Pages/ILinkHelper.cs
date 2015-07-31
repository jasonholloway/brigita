using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Dom.Services.Pages
{
    public interface ILinkHelper
    {
        Uri BuildUrl(string relativeUrl);
    }
}
