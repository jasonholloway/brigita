using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Dom.Services.Locale
{
    public interface ILocalizerSchemaSource
    {
        LocalizerSchema<TSubject> GetSchema<TSubject>() where TSubject : IEntity;
    }
}
