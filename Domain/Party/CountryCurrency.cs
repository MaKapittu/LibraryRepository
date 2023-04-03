using HW_01_Eurich_Kapitonova.Data.Party;

namespace HW_01_Eurich_Kapitonova.Domain.Party
{
    public interface ICountryCurrencyRepo : IRepo<CountryCurrency> { }
    public sealed class CountryCurrency : NamedEntity<CountryCurrencyData>
    {
        public CountryCurrency() : this(new ()) { }
        public CountryCurrency(CountryCurrencyData d) : base(d) { }
        public string CountryID => getValue(Data?.CountryID);
        public string CurrencyID => getValue(Data?.CurrencyID);
        public Country? Country => GetRepo.Instance<ICountryRepo>()?.Get(CountryID);
        public Currency? Currency => GetRepo.Instance<ICurrencyRepo>()?.Get(CurrencyID);

    }
}
