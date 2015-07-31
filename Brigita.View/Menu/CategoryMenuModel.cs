using Brigita.Infrastructure.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brigita.View.Menu
{
    public class CategoryMenuModel
    {
        public SimpleTree<CategoryMenuItem> MenuItemTree { get; set; }
    }
}