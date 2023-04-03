using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain;
using HW_01_Eurich_Kapitonova.Domain.Party;
using HW_01_Eurich_Kapitonova.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Domain.Party
{
    [TestClass]
    public class AddressTests : SealedClassTests<Address, UniqueEntity<AddressData>>
    {
        protected override Address createObj() => new(GetRandom.Value<AddressData>());
        [TestMethod] public void StreetTest() => isReadOnly(obj.Data.Street);
        [TestMethod] public void CityTest() => isReadOnly(obj.Data.City);
        [TestMethod] public void RegionTest() => isReadOnly(obj.Data.Region);
        [TestMethod] public void ZipCodeTest() => isReadOnly(obj.Data.ZipCode);
        [TestMethod] public void CountryIDTest() => isReadOnly(obj.Data.CountryID);
        [TestMethod] public void ToStringTest()
        {
            var expected = $"{obj.Street} {obj.City} {obj.Region} {obj.ZipCode} {obj.Country?.Name}";
            areEqual(expected, obj.ToString());
        }
        [TestMethod] public void CountryTest() => itemTest<ICountryRepo, Country, CountryData>
            (obj.CountryID, d => new Country(d), () => obj.Country);
    }
}
