using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Dom.Services.Locale
{
    public interface ILocalizer<TEntity>
        where TEntity : IEntity
    {
        void Localize(TEntity entity);
        void Localize(IEnumerable<TEntity> entities);
    }
}
