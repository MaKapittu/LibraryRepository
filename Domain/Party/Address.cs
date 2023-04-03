using HW_01_Eurich_Kapitonova.Data.Party;

namespace HW_01_Eurich_Kapitonova.Domain.Party
{
    public interface IAddressRepo : IRepo<Address> { }
    public sealed class Address : UniqueEntity<AddressData>
    {
        public Address() : this(new()) { }
        public Address(AddressData d) : base(d) { }
        public string Street => getValue(Data?.Street);
        public string City => getValue(Data?.City);
        public string Region => getValue(Data?.Region);
        public string ZipCode => getValue(Data?.ZipCode);
        public string CountryID => getValue(Data?.CountryID);
        public override string ToString() => $"{Street} {City} {Region} {ZipCode} {Country?.Name}";
        public Country? Country => GetRepo.Instance<ICountryRepo>()?.Get(CountryID);
    }
}
