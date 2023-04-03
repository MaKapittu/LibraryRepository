using HW_01_Eurich_Kapitonova.Data;
using HW_01_Eurich_Kapitonova.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HW_01_Eurich_Kapitonova.Tests.Data.Party
{
    [TestClass]
    public class PersonDataTests : SealedClassTests<PersonData, UniqueData>
    {
        [TestMethod] public void IDTest() => isProperty<string?>();
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void GenderTest() => isProperty<IsoGender>();
        [TestMethod] public void DateOfBirthTest() => isProperty<DateTime?>();
        [TestMethod] public void RentedBooksAmountTest() => isProperty<int?>();
    }
}
