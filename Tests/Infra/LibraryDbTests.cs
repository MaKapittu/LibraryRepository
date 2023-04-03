using HW_01_Eurich_Kapitonova.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Infra
{
    [TestClass]
    public class LibraryDbTests : SealedBaseTests<LibraryDb, DbContext>
    {
        protected override LibraryDb createObj() => null;
        protected override void isSealedTest() => isInconclusive();
        [TestMethod] public void InitializeTablesTests() => isInconclusive();

    }

}
