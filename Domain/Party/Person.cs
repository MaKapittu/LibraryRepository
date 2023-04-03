using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Data.Party;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HW_01_Eurich_Kapitonova.Domain.Party
{
    public interface IPersonRepo : IRepo<Person> { }
    public sealed class Person : UniqueEntity<PersonData>
    {
        public Person() : this(new ()) { }
        public Person(PersonData d) : base(d) { }
        public string? FirstName => getValue(Data?.FirstName);
        public string? LastName => getValue(Data?.LastName);
        public DateTime DateOfBirth => getValue(Data?.DateOfBirth);
        public int? RentedBooksAmount => getValue(Data?.RentedBooksAmount);
        public IsoGender Gender => getValue(Data?.Gender);
        public override string ToString() => $"{FirstName} {LastName}({DateOfBirth}, {RentedBooksAmount}), {Gender.Description()}";
        public List<PersonAddress> PersonAddresses
           => GetRepo.Instance<IPersonAddressRepo>()?
           .GetAll(x => x.PersonID)?
           .Where(x => x.PersonID == ID)?
           .ToList() ?? new List<PersonAddress>();
        public List<Address?> Addresses
            => PersonAddresses
            .Select(x => x.Address)
            .ToList() ?? new List<Address?>();
    }
}
