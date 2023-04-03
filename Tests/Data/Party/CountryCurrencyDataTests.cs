using HW_01_Eurich_Kapitonova.Data;
using HW_01_Eurich_Kapitonova.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Data.Party
{
    [TestClass]
    public class CountryCurrencyDataTests : SealedClassTests<CountryCurrencyData, NamedData>
    {
        [TestMethod] public void CountryIDTest() => isProperty<string>();
        [TestMethod] public void CurrencyIDTest() => isProperty<string>();
    }
}
