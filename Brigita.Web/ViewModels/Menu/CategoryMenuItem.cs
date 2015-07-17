using Brigita.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brigita.Web.ViewModels.Menu
{
    public class CategoryMenuItem
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public bool IsActiveParent { get; set; }
    }
}