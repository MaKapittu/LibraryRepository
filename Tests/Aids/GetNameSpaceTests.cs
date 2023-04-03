using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Aids
{
    [TestClass]
    public class GetNamespaceTests : TypeTests
    {
        [TestMethod]
        public void OfTypeTest()
        {
            var obj = new CurrencyData();
            var name = obj.GetType().Namespace;
            var n = GetNamespace.OfType(obj);
            areEqual(name, n);
        }
        [TestMethod]
        public void OfTypeNullTest()
        {
            CurrencyData? obj = null;
            var n = GetNamespace.OfType(obj);
            areEqual(string.Empty, n);
        }
    }
}
