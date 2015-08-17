using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Dom.Services.Localization
{
    public class Localizer<TSubject> 
        : ILocalizer<TSubject>
        where TSubject : IEntity
    {
        ILocalizer<TSubject>[] _subLocalizers;

        public Localizer(
                    IStringLocalizer<TSubject> stringLocalizer,
                    ICurrencyLocalizer<TSubject> currLocalizer ) 
        {
            _subLocalizers = new ILocalizer<TSubject>[] {
                                    stringLocalizer,
                                    currLocalizer 
                                    };
        }
        
        public void Localize(TSubject entity) 
        {
            foreach(var subLocalizer in _subLocalizers) {
                subLocalizer.Localize(entity);
            }
        }

        public void Localize(IEnumerable<TSubject> entities) 
        {
            var rEnts = entities.ToArray();
            
            foreach(var subLocalizer in _subLocalizers) {
                subLocalizer.Localize(rEnts);
            }
        }
    }
}
