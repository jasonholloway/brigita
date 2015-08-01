using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Dom.Services.Media;
using Brigita.View.Bits;

namespace Brigita.View.Products
{
    public class ProductTeaser
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Piccy Image { get; set; }
        public Link Link { get; set; }
    }
}
