using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using System.Linq;

namespace HW_01_Eurich_Kapitonova.Infra.Party
{
    public sealed class CurrenciesRepo : Repo<Currency, CurrencyData>, ICurrencyRepo
    {
        public CurrenciesRepo(LibraryDb? db) : base(db, db?.Currencies) { }
        protected internal override Currency toDomain(CurrencyData d) => new(d);
        internal override IQueryable<CurrencyData> addFilter(IQueryable<CurrencyData> q)
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
