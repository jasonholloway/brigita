using Brigita.Core.Infrastructure.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brigita.Web.Models.Menu
{
    public class CategoryMenuModel
    {
        public SimpleTree<CategoryMenuItem> MenuItemTree { get; set; }
    }
}