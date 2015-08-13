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
    public class LocalizerSchemaSource : ILocalizerSchemaSource
    {
        ConcurrentDictionary<Type, object> _dSchemas;

        public LocalizerSchemaSource() 
        {
            _dSchemas = new ConcurrentDictionary<Type, object>();
        }

        public LocalizerSchema<TSubject> GetSchema<TSubject>()
            where TSubject : IEntity 
        {
            return (LocalizerSchema<TSubject>)_dSchemas
                                                .GetOrAdd(
                                                    typeof(TSubject),
                                                    _ => new LocalizerSchema<TSubject>()
                                                );
        }

    }
}
