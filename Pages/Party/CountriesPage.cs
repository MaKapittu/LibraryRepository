using HW_01_Eurich_Kapitonova.Domain.Party;
using HW_01_Eurich_Kapitonova.Facade.Party;
using System;
using System.Collections.Generic;

namespace HW_01_Eurich_Kapitonova.Pages.Party
{
    public class CountriesPage : PagedPage<CountryView, Country, ICountryRepo>
    {
        public CountriesPage(ICountryRepo r) : base(r) { }
        protected override Country toObject(CountryView item) => new CountryViewFactory().Create(item);
        protected override CountryView toView(Country entity) => new CountryViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CountryView.Name),
            nameof(CountryView.Code),
            nameof(CountryView.Description)
        };
        public Lazy<List<Currency?>> Currencies => toObject(Item).Currencies;
    }
}
