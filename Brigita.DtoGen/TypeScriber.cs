using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.DtoGen
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



        public string WriteFullTypeName<T>() {
            return WriteFullTypeName(typeof(T));
        }

        public string WriteFullTypeName(Type type) 
        {
            //switch(type.FullName) {
            //    case "System.Int32":
            //        return "int";

            //    case "System.Boolean":
            //        return "bool";

            //    case "System.String":
            //        return "string";
            //}

            string typeName = WriteTypeName(type);

            var stFore = new Stack<string>(type.Namespace.Split('.'));

            var stAft = new Stack<string>(new[] { typeName });

            while(stFore.Any() && !_namespaces.Contains(string.Join(".", stFore.Reverse().ToArray()))) 
            {
                stAft.Push(stFore.Pop());
            }

            return string.Join(".", stAft.ToArray());
        }


        string WriteTypeName(Type type) {
            if(type.IsGenericType && !type.IsGenericTypeDefinition) {
                var sb = new StringBuilder();

                sb.Append(new string(type.Name
                                            .TakeWhile(c => c != '`')
                                            .ToArray()));
                sb.Append("<");

                bool isFirst = true;

                foreach(var genArg in type.GetGenericArguments()) {
                    if(!isFirst) sb.Append(", ");

                    sb.Append(WriteFullTypeName(genArg));

                    isFirst = false;
                }

                sb.Append(">");

                return sb.ToString();
            }

            if(type.IsArray) {
                return WriteTypeName(type.GetElementType()) + "[]";
            }

            return type.Name;
        }


    }
}
