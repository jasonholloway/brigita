using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.View.Home;

namespace Brigita.View.Services.Home
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
