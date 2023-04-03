using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain;
using HW_01_Eurich_Kapitonova.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Domain.Party
{
    [TestClass]
    public class LibrarianTests : SealedClassTests<Librarian, UniqueEntity<LibrarianData>>
    {
        protected override Librarian createObj() => new(GetRandom.Value<LibrarianData>());
        [TestMethod] public void FirstNameTest() => isReadOnly(obj.Data.FirstName);
        [TestMethod] public void LastNameTest() => isReadOnly(obj.Data.LastName);
        [TestMethod] public void AmountOfReadersItHelpsTest() => isReadOnly(obj.Data.AmountOfReadersItHelps);
        [TestMethod] public void PositionTest() => isReadOnly(obj.Data.Position);
        [TestMethod] public void ToStringTest()
        {
            var expected = $"{obj.FirstName} {obj.LastName} ({obj.Position}) - {obj.AmountOfReadersItHelps}";
            areEqual(expected, obj.ToString());
        }
    }
}
