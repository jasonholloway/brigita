using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoDesigner
{
    public interface IDtoSpec
    {
        string Name { get; }
        string Namespace { get; }

        IEnumerable<string> Usings { get; }
                
        void Generate();
    }

    public interface IPropSpec
    {
        string Name { get; }
        string 
    }


    public interface ITypeRef {
        string Namespace { get; }
        string Name { get; }
    }

}
