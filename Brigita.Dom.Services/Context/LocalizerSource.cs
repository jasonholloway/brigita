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
    public class LocalizerSource<TEntity> : ILocalizerSource<TEntity>
        where TEntity : BaseEntity
    {
        IRepo<LocalizedProperty> _repo;
        ConcurrentDictionary<int, ILocalizer<TEntity>> _dLocalizers;

        public LocalizerSource(IRepo<LocalizedProperty> repo) 
        {
            _repo = repo;
            _dLocalizers = new ConcurrentDictionary<int, ILocalizer<TEntity>>();
        }

        public ILocalizer<TEntity> GetLocalizer(int languageID) 
        {
            return _dLocalizers.GetOrAdd(
                                    languageID,
                                    k => new Localizer<TEntity>(k, _repo) 
                                    );
        }
    }
}
