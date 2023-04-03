using HW_01_Eurich_Kapitonova.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Facade
{
    [TestClass]
    public class UniqueViewTests : AbstractClassTests<UniqueView, object>
    {
        private class testClass : UniqueView { }
        protected override UniqueView createObj() => new testClass();
        [TestMethod] public void IDTest() => isProperty<string>();
        [TestMethod] public void TokenTest() => isProperty<byte[]>();
    }
}
