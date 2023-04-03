using HW_01_Eurich_Kapitonova.Facade;
using HW_01_Eurich_Kapitonova.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Facade.Party
{
    [TestClass]
    public class AddressViewTests : SealedClassTests<AddressView, UniqueView>
    {
        [TestMethod] public void StreetTest() => isRequired<string>("Street");
        [TestMethod] public void CityTest() => isDisplayNamed<string?>("City");
        [TestMethod] public void RegionTest() => isDisplayNamed<string?>("Region");
        [TestMethod] public void ZipCodeTest() => isDisplayNamed<string?>("Zip code");
        [TestMethod] public void CountryIDTest() => isDisplayNamed<string?>("Country");
    }
}
