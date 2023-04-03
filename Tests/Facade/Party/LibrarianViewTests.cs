using HW_01_Eurich_Kapitonova.Facade;
using HW_01_Eurich_Kapitonova.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace HW_01_Eurich_Kapitonova.Tests.Facade.Party
{
    [TestClass]
    public class LibrarianViewTests : SealedClassTests<LibrarianView, UniqueView>
    {
        [TestMethod] public void FirstNameTest() => isRequired<string>("First name");
        [TestMethod] public void LastNameTest() => isRequired<string>("Last name");
        [TestMethod] public void PositionTest() => isDisplayNamed<string?>("Position");
        [TestMethod] public void AmountOfReadersItHelpsTest() => isDisplayNamed<int?>("Amount of readers it helps");
        [TestMethod] public void LibrarianInfoTest() => isDisplayNamed<string?>("Librarian info");
    }
}

