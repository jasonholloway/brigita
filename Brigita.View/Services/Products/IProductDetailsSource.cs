using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.View.Products;

namespace Brigita.View.Services.Products
{
    public interface IProductDetailsSource
    {
        ProductDetails GetDetails(int productID);   
    }
}
