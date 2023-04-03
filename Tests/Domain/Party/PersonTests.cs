using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain;
using HW_01_Eurich_Kapitonova.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Domain.Party
{
    [TestClass]
    public class PersonTests : SealedClassTests<Person, UniqueEntity<PersonData>>
    {
        protected override Person createObj() => new(GetRandom.Value<PersonData>());
        [TestMethod] public void FirstNameTest() => isReadOnly(obj.Data.FirstName);
        [TestMethod] public void RentedBooksAmountTest() => isReadOnly(obj.Data.RentedBooksAmount);
        [TestMethod] public void LastNameTest() => isReadOnly(obj.Data.LastName);
        [TestMethod] public void GenderTest() => isReadOnly(obj.Data.Gender);
        [TestMethod] public void DateOfBirthTest() => isReadOnly(obj.Data.DateOfBirth);
        [TestMethod] public void ToStringTest()
        {
            var expected = $"{obj.FirstName} {obj.LastName}({obj.DateOfBirth}, {obj.RentedBooksAmount}), {obj.Gender.Description()}";
            areEqual(expected, obj.ToString());
        }
        [TestMethod]public void PersonAddressesTest()
           => itemsTest<IPersonAddressRepo, PersonAddress, PersonAddressData>(
               d => d.PersonID = obj.ID, d => new PersonAddress(d), () => obj.PersonAddresses);
        [TestMethod]public void AddressesTest() => relatedItemsTest<IAddressRepo, PersonAddress, Address, AddressData>
            (PersonAddressesTest, () => obj.PersonAddresses, () => obj.Addresses,
              x => x.AddressID, d => new Address(d), c => c?.Data, x => x?.Address?.Data);
    }
}
