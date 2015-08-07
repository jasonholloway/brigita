using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Queries.Home
{
    public class HomeHandler : IQueryHandler<HomeQuery, HomeModel>
    {
        public HomeHandler() {
            //...
        }

        public HomeModel Enquire(HomeQuery query) {
            return new HomeModel() { 
                Greeting = "Hello!"
            };
        }
    }
}
