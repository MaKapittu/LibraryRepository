using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain;
using HW_01_Eurich_Kapitonova.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Domain.Party
{
    [TestClass]
    public class CountryTests : SealedClassTests<Country, NamedEntity<CountryData>>
    {
        protected override Country createObj() => new(GetRandom.Value<CountryData>());
        [TestMethod] public void CountryCurrenciesTest() =>
            itemsTest<ICountryCurrencyRepo, CountryCurrency, CountryCurrencyData>(
            d => d.CountryID = obj.ID, d => new CountryCurrency(d), () => obj.CountryCurrencies.Value);
        [TestMethod]
        public void CurrenciesTest() => relatedItemsTest<ICurrencyRepo, CountryCurrency, Currency, CurrencyData>
            (CountryCurrenciesTest, () => obj.CountryCurrencies.Value, () => obj.Currencies.Value,
              x => x.CurrencyID, d => new Currency(d), c => c?.Data, x => x?.Currency?.Data);
        
        [TestMethod]
        public void CompareToTest()
        {
            var dX = GetRandom.Value<CountryData>() as CountryData;
            var dY = GetRandom.Value<CountryData>() as CountryData;
            isNotNull(dX);
            isNotNull(dY);
            var expected = dX.Name?.CompareTo(dY.Name);
            areEqual(expected, new Country(dX).CompareTo(new Country(dY)));
        }
    }
}
