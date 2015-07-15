using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Brigita.DtoGen
{
    public static class DtoSpecBuilder
    {
        static Regex _reSplitName = new Regex(@"^(.+)\.(.+)$");
        


        public static IDtoSpec Build(Type[] rtInts, string fullName) 
        {
            var allInts = GatherInterfaces(rtInts).Distinct();

            foreach(var i in allInts) {
                if(!i.IsInterface) {
                    throw new ArgumentException(string.Format(
                                                    "Can't compose DTO from {0}, as it's not an interface.",
                                                    i.FullName ));
                }

                var accessorMethodHash = new HashSet<MethodBase>(i.GetProperties()
                                                                    .SelectMany(p => new[] { p.GetGetMethod(), p.GetSetMethod() })
                                                                    .Where(m => m != null));

                if(i.GetMethods().Any(m => !accessorMethodHash.Contains(m))) {
                    throw new ArgumentException(string.Format(
                                                    "Can't compose DTO from {0}, as it requires a non-accessor method implementation.",
                                                    i.FullName ));
                }
            }


            var props = allInts.SelectMany(t => t.GetProperties())
                                .ToArray();

            foreach(var g in props.GroupBy(p => p.Name)) {
                if(g.Count() > 1) {
                    throw new ArgumentException(string.Format("Clash on property {0}!", g.Key));
                }
            }


            var splitName = _reSplitName.Matches(fullName);

            return new _DtoSpec() {
                Name = splitName[0].Groups[2].Value,
                Namespace = splitName[0].Groups[1].Value,
                Interfaces = allInts.ToArray(),
                Props = props
            };
        }
        


        static IEnumerable<Type> GatherInterfaces(IEnumerable<Type> types) {
            return types.SelectMany(t => GatherInterfaces(t));
        }

        static IEnumerable<Type> GatherInterfaces(Type type) {
            yield return type;

            foreach(var @interface in type.GetInterfaces()) {
                foreach(var childInterface in GatherInterfaces(@interface)) {
                    yield return childInterface;
                }
            }
        }



        class _DtoSpec : IDtoSpec
        {
            public string Name { get; set; }
            public string Namespace { get; set; }
            public Type[] Interfaces { get; set; }
            public PropertyInfo[] Props { get; set; }
        }



    }
}
