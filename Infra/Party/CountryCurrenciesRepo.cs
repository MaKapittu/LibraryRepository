using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using System.Linq;

namespace HW_01_Eurich_Kapitonova.Infra.Party
{
    public sealed class CountryCurrenciesRepo : Repo<CountryCurrency, CountryCurrencyData>, ICountryCurrencyRepo
    {
        public CountryCurrenciesRepo(LibraryDb? db) : base(db, db?.CountryCurrencies) { }
        protected internal override CountryCurrency toDomain(CountryCurrencyData d) => new(d);

        internal override IQueryable<CountryCurrencyData> addFilter(IQueryable<CountryCurrencyData> q)
        {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                ? q : q.Where(
                x => x.ID.Contains(y)
                || x.Code.Contains(y)
                || x.Name.Contains(y)
                || x.Description.Contains(y)
                || x.CountryID.Contains(y)
                || x.CurrencyID.Contains(y) );
        }
    }
}
