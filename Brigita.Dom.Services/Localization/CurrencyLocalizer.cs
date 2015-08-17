using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Data;
using Brigita.Dom.Bits;
using Brigita.Infrastructure.Accessors;
using Nop.Core.Domain.Directory;

namespace Brigita.Dom.Services.Localization
{
    public class CurrencyLocalizer<TSubject>
        : ICurrencyLocalizer<TSubject>
        where TSubject : IEntity
    {
        static IAccessor<TSubject, CurrencyValue>[] _accs;

        static CurrencyLocalizer() {
            _accs = typeof(TSubject)
                        .GetProperties()
                        .Where(p => p.PropertyType == typeof(CurrencyValue))
                        .Select(p => Accessors.Get<TSubject, CurrencyValue>(p))
                        .ToArray();
        }

        /******************************************************************************/


        ILocaleContext _locale;
        
        public CurrencyLocalizer(ILocaleContext locale) 
        {
            _locale = locale;
        }


        public void Localize(TSubject entity) {
            Localize(new[] { entity });
        }

        public void Localize(IEnumerable<TSubject> entities) 
        {
            if(!_accs.Any()) return;
            
            var curr = _locale.Currency;

            foreach(var ent in entities) {
                foreach(var acc in _accs) {
                    var vOld = acc.GetValue(ent);

                    if(vOld != null) {                        
                        acc.SetValue(
                                ent,
                                new CurrencyValue() {
                                        Amount = curr.Rate != vOld.Rate 
                                                    ? (curr.Rate / vOld.Rate) * vOld.Amount
                                                    : vOld.Amount,
                                        Rate = curr.Rate,
                                        Code = curr.CurrencyCode
                                });
                    }
                }
            }
        }
    }
}
