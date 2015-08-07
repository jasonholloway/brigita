using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Dom.Services.Context
{
    public interface ILocalizerSource<TEntity>
        where TEntity : IEntity
    {
        ILocalizer<TEntity> GetLocalizer(int languageID);
        ILocalizer<TEntity> GetLocalizerUsing<TBase>(int languageID) where TBase : IEntity;
    }
}
