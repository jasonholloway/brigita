using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Data;
using Nop.Core;
using Nop.Core.Domain.Localization;

namespace Brigita.Dom.Services.Context
{
    public class LocalizerSource<TSubject> : ILocalizerSource<TSubject>
        where TSubject : IEntity
    {
        IRepo<LocalizedProperty> _repo;
        ConcurrentDictionary<LocalizerKey, ILocalizer<TSubject>> _dLocalizers;

        public LocalizerSource(IRepo<LocalizedProperty> repo) 
        {
            _repo = repo;
            _dLocalizers = new ConcurrentDictionary<LocalizerKey, ILocalizer<TSubject>>(LocalizerKeyComparer.Instance);
        }

        public ILocalizer<TSubject> GetLocalizer(int languageID) 
        {
            return _dLocalizers.GetOrAdd(
                                    new LocalizerKey(typeof(TSubject), languageID),
                                    k => new Localizer<TSubject, TSubject>(k.LanguageID, _repo) 
                                    );
        }

        public ILocalizer<TSubject> GetLocalizerUsing<TBaseEntity>(int languageID) 
            where TBaseEntity : IEntity
        {
            return _dLocalizers.GetOrAdd(
                                    new LocalizerKey(typeof(TSubject), languageID),
                                    k => new Localizer<TBaseEntity, TSubject>(k.LanguageID, _repo)
                                    );
        }


        struct LocalizerKey
        {
            public readonly Type BaseEntityType;
            public readonly int LanguageID;

            public LocalizerKey(Type baseEntType, int langID) {
                BaseEntityType = baseEntType;
                LanguageID = langID;
            }
        }

        class LocalizerKeyComparer : IEqualityComparer<LocalizerKey>
        {
            public static readonly LocalizerKeyComparer Instance = new LocalizerKeyComparer();
            
            public bool Equals(LocalizerKey x, LocalizerKey y) {
                return x.LanguageID == y.LanguageID 
                        && x.BaseEntityType == y.BaseEntityType;
            }

            public int GetHashCode(LocalizerKey obj) {
                return obj.LanguageID.GetHashCode()
                        ^ obj.BaseEntityType.GetHashCode();
            }
        }
    }
}
