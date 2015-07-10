using Brigita.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brigita.Web.Models.Menu
{
    public class CategoryMenuItem
    {
        public IHtmlString Name { get; set; }
        public BrigitaUri Uri { get; set; }
        public bool IsActive { get; set; }
        public bool IsActiveAncestor { get; set; }
    }
}