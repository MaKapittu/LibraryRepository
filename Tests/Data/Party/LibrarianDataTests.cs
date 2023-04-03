using HW_01_Eurich_Kapitonova.Data;
using HW_01_Eurich_Kapitonova.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace HW_01_Eurich_Kapitonova.Tests.Data.Party
{
    [TestClass]
    public class LibrarianDataTests : SealedClassTests<LibrarianData, UniqueData>
    {
        [TestMethod] public void IDTest() => isProperty<string?>();
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void PositionTest() => isProperty<string?>();
        [TestMethod] public void AmountOfReadersItHelpsTest() => isProperty<int?>();

    }
}
