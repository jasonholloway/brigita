using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.View.Bits;

namespace Brigita.View.Products
{
    public class ProductTeaserModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ImageModel Image { get; set; }
        public Link Link { get; set; }
    }
}
