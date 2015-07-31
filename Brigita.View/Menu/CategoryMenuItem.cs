﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brigita.View.Menu
{
    public class CategoryMenuItem
    {
        public string Name { get; set; }
        public Link Link { get; set; }
        public bool IsActive { get; set; }
        public bool IsActiveParent { get; set; }
    }
}