using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Brigita.Dom.Services.Localization;
using Nop.Core.Domain.Localization;

namespace Brigita.Web.Services
{
    [Obsolete]
    public class LocaleCodeProvider : ILocaleCodeProvider
    {
        Lazy<string> _lzLocaleCode;

        public LocaleCodeProvider(HttpContext context) {
            _lzLocaleCode = new Lazy<string>(() => context.Items.Contains("locale")
                                                                    ? (string)context.Items["locale"]
                                                                    : context.Request.UserLanguages.FirstOrDefault() 
                                                                    );
        }

        public string LocaleCode {
            get { return _lzLocaleCode.Value; }
        }
    }
}
