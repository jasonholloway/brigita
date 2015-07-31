using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.View.Home;

namespace Brigita.View.Services.Home
{
    public interface IHomeModelSource
    {
        HomeModel GetModel();
    }
}
