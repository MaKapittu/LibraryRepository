using HW_01_Eurich_Kapitonova.Domain.Party;
using HW_01_Eurich_Kapitonova.Facade.Party;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace HW_01_Eurich_Kapitonova.Pages.Party
{
    [Authorize]
    public class AddressesPage : PagedPage<AddressView, Address, IAddressRepo>
    {
        private readonly ICountryRepo countries;
        public AddressesPage(IAddressRepo r, ICountryRepo c) : base(r) => countries = c;
        protected override Address toObject(AddressView? item) => new AddressViewFactory().Create(item);
        protected override AddressView toView(Address? entity) => new AddressViewFactory().Create(entity);

        public override string[] IndexColumns { get; } = new[] {
            nameof(AddressView.Street),
            nameof(AddressView.City),
            nameof(AddressView.Region),
            nameof(AddressView.ZipCode),
            nameof(AddressView.CountryID)
        };
        public IEnumerable<SelectListItem> Countries
        => countries?.GetAll(x => x.Name)?.Select(x => new SelectListItem(x.Name, x.ID))
            ?? new List<SelectListItem>();
           
        public string CountryName(string? countryID = null)
            => Countries?.FirstOrDefault(x => x.Value == (countryID ?? string.Empty))?.Text ?? "Unspecified";
        public override object GetValue(string name, AddressView v)
        {
            var r = base.GetValue(name, v);
            if(name == nameof(AddressView.CountryID)) return CountryName(r as string);
            return r;
        }
    }
}
