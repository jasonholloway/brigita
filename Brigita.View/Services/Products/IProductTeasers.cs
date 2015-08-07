﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Infrastructure.Pages;
using Brigita.View.Products;

namespace Brigita.View.Services.Products
{
    public interface IProductTeasers
    {
        ProductTeasersModel GetPage(int categoryID, ListPageSpec<ProductTeaser> pageSpec);
    }
}
