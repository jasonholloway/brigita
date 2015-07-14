using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brigita.DtoGen;
using System.Collections.Generic;
using System.Text;

namespace Brigita.DtoGen.Test
{
    [TestClass]
    public class TypeScriberTests
    {
        [TestMethod]
        public void NamespacesElided() 
        {
            var types = new[] { 
                                typeof(int),
                                typeof(TypeScriberTests),
                                typeof(System.Reflection.Assembly)
                            };

            var typeScriber = new TypeScriber(types.Select(t => t.Namespace));

            var namespaceHash = new HashSet<string>(types.Select(t => t.Namespace));

            foreach(var @namespace in typeScriber.Namespaces) {
                Assert.IsTrue(namespaceHash.Contains(@namespace));
            }
        }


        [TestMethod]
        public void SimpleTypesWrittenCorrectly() {
            var ts = new TypeScriber(new[] { "System" });
            
            Assert.AreEqual("Int32", ts.WriteFullTypeName<int>());
            Assert.AreEqual("Brigita.Domain.Test.DtoTests", ts.WriteFullTypeName<TypeScriberTests>());
            Assert.AreEqual("Reflection.Assembly", ts.WriteFullTypeName<System.Reflection.Assembly>());
        }


        [TestMethod]
        public void ComplexTypesWrittenCorrectly() {
            var namespaces = new[] { 
                                "System",
                                "System.Collections.Generic",
                                "Brigita.Domain"
                            };
            
            var scriber = new TypeScriber(namespaces);

            var tests = new Dictionary<Type, string> { 
                                { typeof(int?), "Nullable<Int32>" }, 
                                { typeof(List<TypeScriberTests>), "List<Test.DtoTests>" },
                                { typeof(SortedDictionary<string, float>), "SortedDictionary<String, Single>" },
                                { typeof(byte[]), "Byte[]" },
                                { typeof(float?[]), "Nullable<Single>[]" },
                                { typeof(TypeScriberTests[][][]), "Test.DtoTests[][][]" }
                            };
            
            foreach(var test in tests) {
                Assert.AreEqual(test.Value, scriber.WriteFullTypeName(test.Key));
            }
        }
        
    }
}
