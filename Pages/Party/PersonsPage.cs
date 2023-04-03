using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using HW_01_Eurich_Kapitonova.Facade.Party;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HW_01_Eurich_Kapitonova.Pages.Party
{
    public class PersonsPage : PagedPage<PersonView, Person, IPersonRepo>
    {
        public PersonsPage(IPersonRepo r) : base(r) { }
        protected override Person toObject(PersonView item) => new PersonViewFactory().Create(item);
        protected override PersonView toView(Person entity) => new PersonViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(PersonView.FullName),
            nameof(PersonView.FirstName),
            nameof(PersonView.LastName),
            nameof(PersonView.DateOfBirth),
            nameof(PersonView.RentedBooksAmount),
            nameof(PersonView.Gender)
        };
        public IEnumerable<SelectListItem> Genders
        => Enum.GetValues<IsoGender>()?
           .Select(x => new SelectListItem(x.Description(), x.ToString()))
           ?? new List<SelectListItem>();
        public string GenderDescription(IsoGender? x)
            => (x ?? IsoGender.NotApplicable).Description();
        public override object? GetValue(string name, PersonView v)
        {
            var r = base.GetValue(name, v);
            return name == nameof(PersonView.Gender) ? GenderDescription((IsoGender)r) : r;
        }
    }
}
