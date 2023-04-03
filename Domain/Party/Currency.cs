using HW_01_Eurich_Kapitonova.Data.Party;
using System.Collections.Generic;
using System.Linq;

namespace HW_01_Eurich_Kapitonova.Domain.Party
{
    public interface ICurrencyRepo : IRepo<Currency> { }
    public sealed class Currency : NamedEntity<CurrencyData>
    {
        public Currency() : this(new ()) { }
        public Currency(CurrencyData d) : base(d) { }
        public List<CountryCurrency> CountryCurrencies
           => GetRepo.Instance<ICountryCurrencyRepo>()?
           .GetAll(x => x.CurrencyID)?
           .Where(x => x.CurrencyID == ID)?
           .ToList() ?? new List<CountryCurrency>();

        public List<Country?> Countries
            => CountryCurrencies
            .Select(x => x.Country)
            .ToList() ?? new List<Country?>();

    }
}
