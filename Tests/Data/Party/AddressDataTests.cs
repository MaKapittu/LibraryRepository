using HW_01_Eurich_Kapitonova.Data;
using HW_01_Eurich_Kapitonova.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Data.Party
{
    [TestClass]
    public class AddressDataTests : SealedClassTests<AddressData, UniqueData>
    {
        [TestMethod] public void StreetTest() => isProperty<string?>();
        [TestMethod] public void CityTest() => isProperty<string?>();
        [TestMethod] public void RegionTest() => isProperty<string?>();
        [TestMethod] public void ZipCodeTest() => isProperty<string?>();
        [TestMethod] public void CountryIDTest() => isProperty<string?>();
    }
}
