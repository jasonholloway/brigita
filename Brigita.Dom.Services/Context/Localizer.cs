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
    public class Localizer<TEntity> : ILocalizer<TEntity>
        where TEntity : BaseEntity
    {
        IRepo<LocalizedProperty> _repo;

        string _entityName;
        int _languageID;
        ConcurrentDictionary<string, Action<TEntity, string>> _dSetters;


        public Localizer(int languageID, IRepo<LocalizedProperty> repo) 
        {
            _repo = repo;
            _entityName = typeof(TEntity).Name;
            _languageID = languageID;
            _dSetters = new ConcurrentDictionary<string, Action<TEntity, string>>();
        }
        

        public void Localize(TEntity entity) 
        {
            Localize(new[] { entity });
        }


        public void Localize(IEnumerable<TEntity> entities) 
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



        static Action<TEntity, string> BuildSetter(string propName) 
        {
            var prop = typeof(TEntity).GetProperty(propName);

            var exEntity = Expression.Parameter(typeof(TEntity));
            var exValue = Expression.Parameter(typeof(string));

            var exLambda = Expression.Lambda<Action<TEntity, string>>(
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
