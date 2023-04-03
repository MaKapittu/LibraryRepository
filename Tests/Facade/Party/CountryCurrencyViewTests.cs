using HW_01_Eurich_Kapitonova.Facade;
using HW_01_Eurich_Kapitonova.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Facade.Party
{
    [TestClass]
    public class CountryCurrencyViewTests : SealedClassTests<CountryCurrencyView, NamedView>
    {
        [TestMethod] public void CountryIDTest() => isRequired<string>("Country");
        [TestMethod] public void CurrencyIDTest() => isRequired<string>("Currency");
        [TestMethod] public void CodeTest() => isDisplayNamed<string?>("Currency native code");
        [TestMethod] public void NameTest() => isDisplayNamed<string?>("Currency native name");
    }
}
