using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.View.Menu;

namespace Brigita.View.Services.Menu
{
    public interface ICatMenuModelSource
    {
        CategoryMenuModel GetModel(int activeCatID);
    }
}
