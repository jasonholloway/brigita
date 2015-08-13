using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Brigita.Data;
using Nop.Core;
using Nop.Core.Domain.Localization;

namespace Brigita.Dom.Services.Locale
{
    public class Localizer<TSubject> : ILocalizer<TSubject>
        where TSubject : IEntity
    {
        ILocaleContext _locale;
        IRepo<LocalizedProperty> _repo;
        LocalizerSchema<TSubject> _schema;

        public Localizer(
                    ILocalizerSchemaSource schemas,
                    ILocaleContext locale,
                    IRepo<LocalizedProperty> repo)
        {
            _locale = locale;
            _repo = repo;
            _schema = schemas.GetSchema<TSubject>();
        }
        

        public void Localize(TSubject entity) 
        {
            Localize(new[] { entity });
        }


        public void Localize(IEnumerable<TSubject> entities) 
        {
            string entityName = _schema.EntityName;
            int languageID = _locale.CurrentLanguage.ID;

            var ids = entities.Select(e => e.ID)
                                .ToArray();

            var propVals = _repo.Where(v => v.LocaleKeyGroup == entityName
                                                && v.LanguageId == languageID
                                                && ids.Contains(v.EntityId));
            
            var propValsByID = propVals.GroupBy(v => v.ID)
                                        .ToDictionary(g => g.Key);

            var pendingEnts = entities
                                .Where(e => propValsByID.ContainsKey(e.ID));
            
            foreach(var ent in pendingEnts) {
                var vals = propValsByID[ent.ID];

                foreach(var val in vals) {
                    var fnSetter = _schema.GetSetter(val.LocaleKey);
                    fnSetter(ent, val.LocaleValue);
                }
            }
        }

    }
}
