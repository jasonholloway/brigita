using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brigita.Domain.Dtos;
using System.Collections.Generic;

namespace Brigita.Domain.Test
{
    [TestClass]
    public class DtoTests
    {
        Type[] _simpleTypes = new[] { 
                            typeof(int),
                            typeof(DtoTests),
                            typeof(System.Reflection.Assembly)
                        };


        [TestMethod]
        public void NamespacesElided() 
        {            
            var typeScriber = new TypeScriber(_simpleTypes.Select(t => t.Namespace));

            var namespaceHash = new HashSet<string>(_simpleTypes.Select(t => t.Namespace));

            foreach(var @namespace in typeScriber.Namespaces) {
                Assert.IsTrue(namespaceHash.Contains(@namespace));
            }
        }


        [TestMethod]
        public void SimpleTypesWrittenCorrectly() {
            var typeScriber = new TypeScriber(_simpleTypes.Select(t => t.Namespace));
            
            foreach(var type in _simpleTypes) {
                Assert.AreEqual(type.Name, typeScriber.WriteType(type));
            }
        }


        [TestMethod]
        public void GenericTypesWrittenCorrectly() {
            throw new NotImplementedException();
        }

    }
}
