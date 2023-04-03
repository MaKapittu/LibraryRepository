using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Facade;
using HW_01_Eurich_Kapitonova.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HW_01_Eurich_Kapitonova.Tests.Facade.Party
{
    [TestClass]
    public class PersonViewTests : SealedClassTests<PersonView, UniqueView>
    {
        [TestMethod] public void FirstNameTest() => isRequired<string>("First name");
        [TestMethod] public void LastNameTest() => isRequired<string>("Last name");
        [TestMethod] public void GenderTest() => isDisplayNamed<IsoGender?>("Gender");
        [TestMethod] public void DateOfBirthTest() => isDisplayNamed<DateTime?>("Date of birth");
        [TestMethod] public void RentedBooksAmountTest() => isDisplayNamed<int?>("Amount of books rented");
        [TestMethod] public void FullNameTest() => isDisplayNamed<string?>("Full name");
    }
}
