using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Tax;
using Nop.Core.Domain.Vendors;
using Nop.Services.Localization;

namespace Brigita.Dom.Services.Context
{
    public class BrigitaWorkContext : IWorkContext
    {
        ILocaleCodeProvider _localeCtx;
        ILanguageService _languages;

        Lazy<Language> _lzLanguage;

        public BrigitaWorkContext(ILocaleCodeProvider localeCtx, ILanguageService languages) {
            _localeCtx = localeCtx;
            _languages = languages;

            _lzLanguage = new Lazy<Language>(() => _languages.GetLanguageByCode(_localeCtx.LocaleCode)
                                                    ?? _languages.GetDefaultLanguage());
        }


        public Customer CurrentCustomer {
            get {
                return new Customer(); //!!!!!!!!!!!!!!!!!!!!!
            }
            set {
                throw new NotImplementedException();
            }
        }

        public Customer OriginalCustomerIfImpersonated {
            get { throw new NotImplementedException(); }
        }

        public Vendor CurrentVendor {
            get { throw new NotImplementedException(); }
        }

        public Language WorkingLanguage {
            get { return _lzLanguage.Value; }
            set {
                throw new NotImplementedException();
            }
        }

        public Currency WorkingCurrency {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public TaxDisplayType TaxDisplayType {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public bool IsAdmin {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }
    }
}
