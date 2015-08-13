using Brigita.Infrastructure.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brigita.Queries.Menu
{
    public class MenuModel
    {
        public SimpleTree<MenuItemModel> MenuItemTree { get; set; }
    }
}