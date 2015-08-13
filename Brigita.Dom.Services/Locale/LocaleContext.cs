using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Data;
using Nop.Core.Domain.Localization;

namespace Brigita.Dom.Services.Locale
{
    public class LocaleContext : ILocaleContext
    {
        ILocaleCodeProvider _codeProv;
        IRepo<Language> _langRepo;

        Lazy<Language> _lzLanguage;
        

        public LocaleContext(ILocaleCodeProvider codeProv, IRepo<Language> langRepo) {
            _codeProv = codeProv;
            _langRepo = langRepo;

            _lzLanguage = new Lazy<Language>(
                                        () => {
                                            string code = _codeProv.LocaleCode;

                                            return _langRepo.FirstOrDefault(l => l.UniqueSeoCode == code)
                                                    ?? _langRepo.OrderBy(l => l.DisplayOrder).First();
                                        });
        }


        public Language CurrentLanguage {
            get { return _lzLanguage.Value; }
        }

    }
}
