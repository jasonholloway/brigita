using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Queries
{
    public interface IMediator
    {
        TResult Enquire<TQuery, TResult>(TQuery query)
            where TQuery : IQuery;
    }
}
