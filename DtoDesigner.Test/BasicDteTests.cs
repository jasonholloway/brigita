using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnvDTE100;
using EnvDTE80;

namespace DtoDesigner.Test
{
    [TestClass]
    public class BasicDteTests
    {
        [TestMethod]
        public void GathersInterfaces() {
            DTE2 dte = null;

            try {
                Type type = System.Type.GetTypeFromProgID("VisualStudio.DTE.12.0");
                object inst = System.Activator.CreateInstance(type, true);
                dte = (EnvDTE80.DTE2)inst;

                var sol = dte.Solution.Create(@"D:\test.sln", "Test");


                dte.Solution.Projects.Item(1).CodeModel.CodeElements.Item(9).

                sol.Open(@"C:\dev\csharp\brigita\DtoDesigner.Test.Example\DtoDesigner.Test.Example.csproj");

                // Inject into class under test

                // Perform the test

                // Analyse the DTE to test for success.

            }
            finally {
                if(dte != null) dte.Quit();
            }
        }

    }
}
