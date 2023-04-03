using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HW_01_Eurich_Kapitonova.Facade.Party
{
    public sealed class AddressView : UniqueView
    {
        [Required][DisplayName("Street")] public string? Street { get; set; }
        [DisplayName("City")] public string? City { get; set; }
        [DisplayName("Region")] public string? Region { get; set; }
        [DisplayName("Zip code")] public string? ZipCode { get; set; }
        [DisplayName("Country")] public string? CountryID { get; set; }
    }
    public sealed class AddressViewFactory : BaseViewFactory<AddressView, Address, AddressData>
    {
        protected override Address toEntity(AddressData d) => new(d);
    }
}
