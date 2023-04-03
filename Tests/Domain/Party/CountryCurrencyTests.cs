using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain;
using HW_01_Eurich_Kapitonova.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Domain.Party
{
    [TestClass]
    public class CountryCurrencyTests : SealedClassTests<CountryCurrency, NamedEntity<CountryCurrencyData>>
    {
        protected override CountryCurrency createObj() => new(GetRandom.Value<CountryCurrencyData>());
        [TestMethod] public void CountryIDTest() => isReadOnly(obj.Data.CountryID);
        [TestMethod] public void CurrencyIDTest() => isReadOnly(obj.Data.CurrencyID);
        [TestMethod]
        public void CountryTest() => itemTest<ICountryRepo, Country, CountryData>(
            obj.CountryID, d => new Country(d), () => obj.Country);
        [TestMethod]
        public void CurrencyTest() => itemTest<ICurrencyRepo, Currency, CurrencyData>(
            obj.CurrencyID, d => new Currency(d), () => obj.Currency);
    }
}
