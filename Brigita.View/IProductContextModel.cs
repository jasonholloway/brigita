﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.View
{
    public interface IProductContextProvider
    {
        int CurrentCategoryID { get; }
    }
}