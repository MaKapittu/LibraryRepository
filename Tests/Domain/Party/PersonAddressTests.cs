using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain;
using HW_01_Eurich_Kapitonova.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Domain.Party
{
    [TestClass]
    public class PersonAddressTests : SealedClassTests<PersonAddress, NamedEntity<PersonAddressData>>
    {
        protected override PersonAddress createObj() => new(GetRandom.Value<PersonAddressData>());
        [TestMethod] public void AddressIDTest() => isReadOnly(obj.Data.AddressID);
        [TestMethod] public void AddressTest() => itemTest<IAddressRepo, Address, AddressData>(
            obj.AddressID, d => new Address(d), () => obj.Address);
        [TestMethod] public void PersonIDTest() => isReadOnly(obj.Data.PersonID);
        [TestMethod] public void PersonTest() => itemTest<IPersonRepo, Person, PersonData>(
            obj.PersonID, d => new Person(d), () => obj.Person);
    }
}
