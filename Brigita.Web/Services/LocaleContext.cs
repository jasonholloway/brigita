using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Brigita.Dom.Services.Context;
using Nop.Core.Domain.Localization;

namespace Brigita.Web.Services
{
    public class LocaleContext : ILocaleContext
    {
        Lazy<string> _lzLocaleCode;

        public LocaleContext(HttpContext context) {
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
