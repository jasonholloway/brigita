using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerAssert;


namespace Brigita.DtoGen.Test
{
    [TestClass]
    public class DtoSpecTests
    {

        [TestMethod]
        public void BuilderOnlyAcceptsInterfaces() {
            PAssert.Throws<ArgumentException>(() => {
                DtoSpecBuilder.Build(new[] { typeof(IOne), typeof(DtoSpecTests) }, "Brigita.DtoGen.Test.ADto");
            });
        }


        [TestMethod]
        public void BuilderRejectsInterfacesWithMethods() {
            PAssert.Throws<ArgumentException>(() => {
                DtoSpecBuilder.Build(new[] { typeof(IOne), typeof(IBad) }, "Brigita.DtoGen.Test.ADto");
            });
        }

        [TestMethod]
        public void GetsPropsFromSingleInterface() {
            var spec = DtoSpecBuilder.Build(new[] { typeof(IOne) }, "Brigita.DtoGen.Test.ADto");

            PAssert.IsTrue(() => spec.Props.Select(p => p.Name).SequenceEqual(new[] { "One", "One_2", "One_3" }));
        }

        [TestMethod]
        public void GetsPropsFromMultipleInterfaces() {
            var spec = DtoSpecBuilder.Build(new[] { typeof(IOne), typeof(ITwo) }, "Brigita.DtoGen.Test.ADto");

            PAssert.IsTrue(() => spec.Props.Select(p => p.Name).SequenceEqual(new[] { "One", "One_2", "One_3", "Two" }));
        }

        [TestMethod]
        public void DisallowsOverlappingProps() {
            PAssert.Throws<ArgumentException>(() => {
                DtoSpecBuilder.Build(new[] { typeof(IOne), typeof(IAnother) }, "Brigita.DtoGen.Test.ADto");
            });
        }

        [TestMethod]
        public void GathersAllBaseInterfaces() {
            var spec = DtoSpecBuilder.Build(new[] { typeof(IThree) }, "Brigita.DtoGen.Test.ADto");

            var propNameHash = new HashSet<string>(spec.Props.Select(p => p.Name));

            PAssert.IsTrue(() => propNameHash.Contains("One"));
            PAssert.IsTrue(() => propNameHash.Contains("One_2"));
            PAssert.IsTrue(() => propNameHash.Contains("One_3"));
            PAssert.IsTrue(() => propNameHash.Contains("Two"));
            PAssert.IsTrue(() => propNameHash.Contains("Three"));

            var intNameHash = new HashSet<string>(spec.Interfaces.Select(i => i.Name));

            PAssert.IsTrue(() => intNameHash.Contains("IOne"));
            PAssert.IsTrue(() => intNameHash.Contains("ITwo"));
            PAssert.IsTrue(() => intNameHash.Contains("IThree"));
        }

        [TestMethod]
        public void ParsesPassedFullName() {
            var spec = DtoSpecBuilder.Build(new[] { typeof(IOne) }, "Brigita.DtoGen.Test.ADto");

            PAssert.IsTrue(() => spec.Name == "ADto");
            PAssert.IsTrue(() => spec.Namespace == "Brigita.DtoGen.Test");
        }


        [TestMethod]
        public void SolvesDiamondProblemWhenGatheringProps() {
            DtoSpecBuilder.Build(new[] { typeof(IFour) }, "Brigita.DtoGen.Test.ADto");
        }


    }




    interface IOne
    {
        int One { get; }
        float One_2 { get; }
        double? One_3 { get; }
    }

    interface ITwo
    {
        int Two { get; }
    }

    interface IThree : IOne, ITwo
    {
        int Three { get; }
    }

    interface IFour : IThree
    {
        int Four { get; }
    }

    interface IBad
    {
        int Number { get; }
        void AMethod();
    }

    interface IAnother
    {
        string One { get; }
    }

   
}
