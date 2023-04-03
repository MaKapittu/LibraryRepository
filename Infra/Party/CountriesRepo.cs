using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using System.Linq;

namespace HW_01_Eurich_Kapitonova.Infra.Party
{
    public sealed class CountriesRepo : Repo<Country, CountryData>, ICountryRepo
    {
        public CountriesRepo(LibraryDb? db) : base(db, db?.Countries) { }
        protected internal override Country toDomain(CountryData d) => new(d);
        internal override IQueryable<CountryData> addFilter(IQueryable<CountryData> q)
        {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                 ? q : q.Where(
                x => x.Code.Contains(y)
                || x.Description.Contains(y)
                || x.ID.Contains(y)
                || x.Name.Contains(y));
        }
    }
}
