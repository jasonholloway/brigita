using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Infrastructure;

namespace Brigita.Queries
{
    public class Mediator : IMediator
    {
        IResolver _cont;

        public Mediator(IResolver cont) {
            _cont = cont;
        }
        
        public TResult Enquire<TQuery, TResult>(TQuery query)
            where TQuery : IQuery
        {
            var handler = _cont.Resolve<IQueryHandler<TQuery, TResult>>();
            return handler.Enquire(query);
        }
    }
}
