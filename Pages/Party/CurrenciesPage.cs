using HW_01_Eurich_Kapitonova.Domain.Party;
using HW_01_Eurich_Kapitonova.Facade.Party;
using System.Collections.Generic;

namespace HW_01_Eurich_Kapitonova.Pages.Party
{
    public class CurrenciesPage : PagedPage<CurrencyView, Currency, ICurrencyRepo>
    {
        public CurrenciesPage(ICurrencyRepo r) : base(r) { }
        protected override Currency toObject(CurrencyView item) => new CurrencyViewFactory().Create(item);
        protected override CurrencyView toView(Currency entity) => new CurrencyViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CurrencyView.Name),
            nameof(CurrencyView.Code),
            nameof(CurrencyView.Description)
        };
        public List<Country?> Countries => toObject(Item).Countries;
    }
}
