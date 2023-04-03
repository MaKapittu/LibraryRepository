using HW_01_Eurich_Kapitonova.Data;
using HW_01_Eurich_Kapitonova.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Data.Party
{
    [TestClass]
    public class BookDataTests : SealedClassTests<BookData, UniqueData>
    {
        [TestMethod] public void BookNameTest() => isProperty<string?>();
        [TestMethod] public void IDTest() => isProperty<string>();
        [TestMethod] public void BooksLeftTest() => isProperty<int?>();
        [TestMethod] public void TotalNumberOfBooksTest() => isProperty<int?>();
        [TestMethod] public void PhotoPathTest() => isProperty<string?>();

    } 
}
