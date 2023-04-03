using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HW_01_Eurich_Kapitonova.Facade.Party
{
    public sealed class PersonView: UniqueView
    {
        [Required][DisplayName("First name")] public string? FirstName { get; set; }
        [Required][DisplayName("Last name")] public string? LastName { get; set; }
        [DisplayName("Date of birth")] public DateTime? DateOfBirth { get; set; }
        [DisplayName("Amount of books rented")] public int? RentedBooksAmount { get; set; }
        [DisplayName("Gender")] public IsoGender? Gender { get; set; }
        [DisplayName("Full name")] public string? FullName { get; set; }
    }
    public sealed class PersonViewFactory : BaseViewFactory<PersonView, Person, PersonData>
    {
        protected override Person toEntity(PersonData d) => new(d);
        public override Person Create(PersonView? v)
        {
            v ??= new PersonView();
            v.Gender ??= IsoGender.NotApplicable;
            return base.Create(v);
        }
        public override PersonView Create(Person? e)
        {
            var v = base.Create(e);
            v.FullName = e?.ToString();
            v.Gender = e?.Gender;
            return v;
        }
    }
}
