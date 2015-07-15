using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoDesigner.Test.Example
{
    interface IDog : IAnimal, IPerson
    {
        string Breed { get; }
        bool BarksLoudly { get; }
    }
}
