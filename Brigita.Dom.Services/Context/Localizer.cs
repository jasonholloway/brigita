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

namespace Brigita.Dom.Services.Context
{
    public class Localizer<TBaseEntity, TSubject> : ILocalizer<TSubject>
        where TSubject : IEntity
    {
        IRepo<LocalizedProperty> _repo;

        string _entityName;
        int _languageID;
        ConcurrentDictionary<string, Action<TSubject, string>> _dSetters;


        public Localizer(int languageID, IRepo<LocalizedProperty> repo) 
        {
            _repo = repo;
            _entityName = typeof(TBaseEntity).Name;
            _languageID = languageID;
            _dSetters = new ConcurrentDictionary<string, Action<TSubject, string>>();
        }
        

        public void Localize(TSubject entity) 
        {
            Localize(new[] { entity });
        }


        public void Localize(IEnumerable<TSubject> entities) 
        {
            var ids = entities.Select(e => e.ID)
                                .ToArray();
            
            var propVals = _repo.Where(v => v.LocaleKeyGroup == _entityName
                                                && v.LanguageId == _languageID
                                                && ids.Contains(v.EntityId));
            
            var propValsByID = propVals.GroupBy(v => v.ID)
                                        .ToDictionary(g => g.Key);

            var pendingEnts = entities
                                .Where(e => propValsByID.ContainsKey(e.ID));
            
            foreach(var ent in pendingEnts) {
                var vals = propValsByID[ent.ID];

                foreach(var val in vals) {
                    var fnSetter = _dSetters.GetOrAdd(
                                                val.LocaleKey,
                                                k => BuildSetter(k));

                    fnSetter(ent, val.LocaleValue);
                }
            }
        }



        static Action<TSubject, string> BuildSetter(string propName) 
        {
            var prop = typeof(TSubject).GetProperty(propName);

            if(prop == null) {
                return (a1, a2) => { };
            }

            var exEntity = Expression.Parameter(typeof(TSubject));
            var exValue = Expression.Parameter(typeof(string));

            var exLambda = Expression.Lambda<Action<TSubject, string>>(
                                        Expression.Call(
                                                    exEntity,
                                                    prop.SetMethod,
                                                    exValue ), 
                                        exEntity, 
                                        exValue);

            return exLambda.Compile();
        }

    }
}
