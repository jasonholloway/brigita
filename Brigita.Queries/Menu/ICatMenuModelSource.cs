using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Queries.Menu;

namespace Brigita.Queries.Menu
{
    public interface ICatMenuModelSource
    {
        CategoryMenuModel GetModel(int activeCatID);
    }
}
