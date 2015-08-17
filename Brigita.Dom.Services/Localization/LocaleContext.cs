using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Data;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Localization;
using Brigita.Dom.Services.Cache;
using System.Threading;

namespace Brigita.Dom.Services.Localization
{
    public class LocaleContext : ILocaleContext
    {
        IRepo<Language> _langRepo;
        IRepo<Currency> _currRepo;

        Lazy<Language> _lzLanguage;
        Lazy<Currency> _lzCurrency;        

        public LocaleContext(IRepo<Language> langRepo, IRepo<Currency> currRepo) {
            _langRepo = langRepo;
            _currRepo = currRepo;

            string localeCode = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;

            _lzLanguage = new Lazy<Language>(() => GetLanguage(localeCode));
            _lzCurrency = new Lazy<Currency>(() => GetCurrency(localeCode));
        }


        public Language Language {
            get { return _lzLanguage.Value; }
        }

        public Currency Currency {
            get { return _lzCurrency.Value; }
        }



        [Cache("Language")]
        Language GetLanguage(string localeCode) {
            return _langRepo.FirstOrDefault(l => l.UniqueSeoCode == localeCode)
                    ?? _langRepo.OrderBy(l => l.DisplayOrder).First();
        }


        [Cache("Currency")]
        Currency GetCurrency(string localeCode) {
            var currID = Language.DefaultCurrencyId;

            return _currRepo.FirstOrDefault(c => c.ID == currID)
                    ?? _currRepo.OrderBy(c => c.DisplayOrder).First();
        }
        
    }
}
