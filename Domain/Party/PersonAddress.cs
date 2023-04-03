using HW_01_Eurich_Kapitonova.Data.Party;

namespace HW_01_Eurich_Kapitonova.Domain.Party
{
    public interface IPersonAddressRepo : IRepo<PersonAddress> { }
    public sealed class PersonAddress : NamedEntity<PersonAddressData>
    {
        public PersonAddress() : this(new ()) { }
        public PersonAddress(PersonAddressData d) : base(d) { }
        public string? AddressID => getValue(Data?.AddressID);
        public string? PersonID => getValue(Data?.PersonID);
        public Address? Address => GetRepo.Instance<IAddressRepo>()?.Get(AddressID);
        public Person? Person => GetRepo.Instance<IPersonRepo>()?.Get(PersonID);
    }
}
