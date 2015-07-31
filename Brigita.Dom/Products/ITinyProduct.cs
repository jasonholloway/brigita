using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brigita.Dom;

namespace Brigita.Dom.Products
{
    public interface ITinyProduct : IEntity
    {
        //int ID { get; }
        string Name { get; }
        string ShortDescription { get; }
        decimal Price { get; }

        object Picture { get; } //how to populate this with nice url? API wants to give me byte array!
    }
}
