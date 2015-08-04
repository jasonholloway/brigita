using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Dom.Services.Context
{
    public interface ILocalizer<TEntity>
    {
        void Localize(TEntity entity);
        void Localize(IEnumerable<TEntity> entities);
    }
}
