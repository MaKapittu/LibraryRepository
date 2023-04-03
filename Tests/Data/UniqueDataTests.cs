using HW_01_Eurich_Kapitonova.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Data
{
    [TestClass]
    public class UniqueDataTests : AbstractClassTests<UniqueData, object>
    {
        private class testClass : UniqueData { }
        protected override UniqueData createObj() => new testClass();
        [TestMethod]
        public void newIDTest()
        {
            isNotNull(UniqueData.newID);
            areNotEqual(UniqueData.newID, UniqueData.newID);
            var pi = typeof(UniqueData).GetProperty(nameof(UniqueData.newID));
            isFalse(pi?.CanWrite);
        }
        [TestMethod] public void IDTest() => isProperty<string>();
        [TestMethod] public void TokenTest() => isProperty<byte[]>();
    }
}
