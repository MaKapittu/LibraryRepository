using HW_01_Eurich_Kapitonova.Domain.Party;
using HW_01_Eurich_Kapitonova.Facade.Party;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace HW_01_Eurich_Kapitonova.Pages.Party
{
    public class CountryCurrenciesPage : PagedPage<CountryCurrencyView, CountryCurrency, ICountryCurrencyRepo>
    {
        private readonly ICountryRepo countries;
        private readonly ICurrencyRepo currencies;
        public CountryCurrenciesPage(ICountryCurrencyRepo r, ICountryRepo co, ICurrencyRepo cu) : base(r)
        {
            countries = co;
            currencies = cu;
        }
        protected override CountryCurrency toObject(CountryCurrencyView? item) => new CountryCurrencyViewFactory().Create(item);
        protected override CountryCurrencyView toView(CountryCurrency? entity) => new CountryCurrencyViewFactory().Create(entity);

        public override string[] IndexColumns { get; } = new[] {
            nameof(CountryCurrencyView.Code),
            nameof(CountryCurrencyView.Name),
            nameof(CountryCurrencyView.Description),
            nameof(CountryCurrencyView.CountryID),
            nameof(CountryCurrencyView.CurrencyID)
        };
        public IEnumerable<SelectListItem> Countries
        => countries?.GetAll(x => x.Name)?
            .Select(x => new SelectListItem(x.Name, x.ID))
            ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> Currencies
       => currencies?.GetAll(x => x.Name)?
            .Select(x => new SelectListItem(x.Name, x.ID))
           ?? new List<SelectListItem>();

        public string CountryName(string? countyID = null)
            => Countries?.FirstOrDefault(x => x.Value == (countyID ?? string.Empty))?.Text ?? "Unspecified";
        public string CurrencyName(string? currencyID = null)
           => Currencies?.FirstOrDefault(x => x.Value == (currencyID ?? string.Empty))?.Text ?? "Unspecified";
        public override object GetValue(string name, CountryCurrencyView v)
        {
            var r = base.GetValue(name, v);
            return name == nameof(CountryCurrencyView.CountryID) ? CountryName(r as string)
                : name == nameof(CountryCurrencyView.CurrencyID) ? CurrencyName(r as string)
                : r;
        }
    }
}
