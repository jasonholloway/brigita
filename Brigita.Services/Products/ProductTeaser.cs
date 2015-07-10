using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Services.Products
{
    public abstract class ProductTeaser
    {
        public int ID { get; protected set; }
        public string Name { get; protected set; }
        public string ShortDescription { get; protected set; }
        public decimal Price { get; protected set; }

        public object Picture { get; protected set; } //how to populate this with nice url? API wants to give me byte array!
    }
}
