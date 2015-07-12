using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.Domain.Dtos
{
    public class TypeScriber
    {
        HashSet<string> _namespaces;


        public TypeScriber(IEnumerable<string> rNamespaces) {
            _namespaces = new HashSet<string>(rNamespaces);
        }


        public IEnumerable<string> Namespaces {
            get { return _namespaces; }
        }


        public string WriteType(Type type) 
        {
            //switch(type.FullName) {
            //    case "System.Int32":
            //        return "int";

            //    case "System.Boolean":
            //        return "bool";

            //    case "System.String":
            //        return "string";
            //}
            
            var qParts = new Queue<string>(type.Namespace.Split('.'));




            // * * *
            // * *
            // *


            return string.Join(".", qParts) + "." + type.Name;
        }

    }
}
