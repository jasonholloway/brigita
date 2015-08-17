using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Brigita.Data;
using Brigita.Dom.Locale;
using Brigita.Infrastructure.Accessors;
using Nop.Core;
using Nop.Core.Domain.Localization;

namespace Brigita.Dom.Services.Localization
{
    public class StringLocalizer<TSubject> 
        : IStringLocalizer<TSubject>
        where TSubject : IEntity
    {
        static string _entityName;

        static StringLocalizer() {
            _entityName = GetEntityName(typeof(TSubject));
        }

        static string GetEntityName(Type entType) {
            var att = entType
                        .GetCustomAttributes(typeof(LocalizeAsAttribute), false)
                        .Cast<LocalizeAsAttribute>()
                        .FirstOrDefault();

            return att != null
                    ? GetEntityName(att.AliasType)
                    : entType.Name;
        }

        /*******************************************************************************/
        

        ILocaleContext _locale;
        IRepo<LocalizedProperty> _repo;


        public StringLocalizer(
                    ILocaleContext locale,
                    IRepo<LocalizedProperty> repo)
        {
            _locale = locale;
            _repo = repo;
        }
                

        public void Localize(TSubject entity) 
        {
            Localize(new[] { entity });
        }


        public void Localize(IEnumerable<TSubject> entities) 
        {
            int languageID = _locale.Language.ID;

            var ids = entities.Select(e => e.ID)
                                .ToArray();

            var propVals = _repo.Where(v => v.LocaleKeyGroup == _entityName
                                                && v.LanguageId == languageID
                                                && ids.Contains(v.EntityId));
            
            var propValsByID = propVals.GroupBy(v => v.ID)
                                        .ToDictionary(g => g.Key);

            var pendingEnts = entities
                                .Where(e => propValsByID.ContainsKey(e.ID));
            
            foreach(var ent in pendingEnts) {
                var vals = propValsByID[ent.ID];

                foreach(var val in vals) {
                    var accessor = Accessors.Get<TSubject, string>(val.LocaleKey);
                    accessor.SetValue(ent, val.LocaleValue);
                }
            }
        }

    }
}
