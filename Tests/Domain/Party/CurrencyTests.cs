using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain;
using HW_01_Eurich_Kapitonova.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Domain.Party
{
    [TestClass]
    public class CurrencyTests : SealedClassTests<Currency, NamedEntity<CurrencyData>>
    {
        protected override Currency createObj() => new(GetRandom.Value<CurrencyData>());
        [TestMethod]
        public void CountryCurrenciesTest()
             => itemsTest<ICountryCurrencyRepo, CountryCurrency, CountryCurrencyData>(
                 d => d.CurrencyID = obj.ID, d => new CountryCurrency(d), () => obj.CountryCurrencies);

        [TestMethod]
        public void CountriesTest() => relatedItemsTest<ICountryRepo, CountryCurrency, Country, CountryData>
            (CountryCurrenciesTest, () => obj.CountryCurrencies, () => obj.Countries,
              x => x.CountryID, d => new Country(d), c => c?.Data, x => x?.Country?.Data);
    }
}
