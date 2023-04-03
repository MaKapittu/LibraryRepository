using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HW_01_Eurich_Kapitonova.Facade.Party
{
    public sealed class PersonAddressView : NamedView
    {
        [Required][DisplayName("Person")] public string PersonID { get; set; } = string.Empty;
        [Required][DisplayName("Geographic address")] public string AddressID { get; set; } = string.Empty;
        [DisplayName("Use for")] public new string? Name { get; set; }
    }
    public sealed class PersonAddressViewFactory : BaseViewFactory<PersonAddressView, PersonAddress, PersonAddressData>
    {
        protected override PersonAddress toEntity(PersonAddressData d) => new(d);
    }
}
