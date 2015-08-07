using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Queries.Home;

namespace Brigita.Queries.Home
{
    public class HomeModelSource : IHomeModelSource
    {
        public HomeModelSource() {
            //...
        }

        public HomeModel GetModel() {
            return new HomeModel() { 
                Greeting = "Hello!"
            };
        }
    }
}
