using HW_01_Eurich_Kapitonova.Domain.Party;
using HW_01_Eurich_Kapitonova.Facade.Party;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace HW_01_Eurich_Kapitonova.Pages.Party
{
    public class PersonAddressesPage : PagedPage<PersonAddressView, PersonAddress, IPersonAddressRepo>
    {
        private readonly IPersonRepo persons;
        private readonly IAddressRepo addresses;
        public PersonAddressesPage(IPersonAddressRepo r, IPersonRepo p, IAddressRepo a) : base(r)
        {
            persons = p;
            addresses = a;
        }
        protected override PersonAddress toObject(PersonAddressView? item) => new PersonAddressViewFactory().Create(item);
        protected override PersonAddressView toView(PersonAddress? entity) => new PersonAddressViewFactory().Create(entity);

        public override string[] IndexColumns { get; } = new[] {
            nameof(PersonAddressView.Code),
            nameof(PersonAddressView.Name),
            nameof(PersonAddressView.Description),
            nameof(PersonAddressView.PersonID),
            nameof(PersonAddressView.AddressID)
        };
        public IEnumerable<SelectListItem> Persons
        => persons?.GetAll(x => x.ToString())?
            .Select(x => new SelectListItem(x.ToString(), x.ID))
            ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> Addresses
       => addresses?.GetAll(x => x.ToString())?
            .Select(x => new SelectListItem(x.ToString(), x.ID))
           ?? new List<SelectListItem>();

        public string PersonName(string? personID = null)
            => Persons?.FirstOrDefault(x => x.Value == (personID ?? string.Empty))?.Text ?? "Unspecified";
        public string AddressName(string? addressID = null)
           => Addresses?.FirstOrDefault(x => x.Value == (addressID ?? string.Empty))?.Text ?? "Unspecified";
        public override object GetValue(string name, PersonAddressView v)
        {
            var r = base.GetValue(name, v);
            return name == nameof(PersonAddressView.PersonID) ? PersonName(r as string) 
                : name == nameof(PersonAddressView.AddressID) ? AddressName(r as string)
                : r;
        }
    }
}
