using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Infrastructure;

namespace Brigita.Queries
{
    public class Registrar : IRegistrar
    {
        public void Register(IBinder x, IScanner scanner) 
        {
            ScanAndRegisterHandlers(x, scanner);




            //data dependencies here
            //...
        }




        void ScanAndRegisterHandlers(IBinder binder, IScanner scanner) 
        {
            var handlerTups = scanner.ScanTypes(typeof(Registrar).Assembly)
                                        .Where(t => !t.IsAbstract)
                                        .Select(t => new {
                                            ImplType = t,
                                            IntType = t.GetInterfaces()
                                                            .SingleOrDefault(i => i.IsGenericType
                                                                                && i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>))
                                        })
                                        .Where(tup => tup.IntType != null);

            foreach(var tup in handlerTups) {
                binder.Bind(tup.IntType, tup.ImplType);
            }
        }


    }
}
