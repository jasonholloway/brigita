using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Queries.Products;

namespace Brigita.Queries.Products
{
    public interface IProductDetailsSource
    {
        ProductDetails GetDetails(int productID);   
    }
}
