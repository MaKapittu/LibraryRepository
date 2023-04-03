using HW_01_Eurich_Kapitonova.Facade;
using HW_01_Eurich_Kapitonova.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace HW_01_Eurich_Kapitonova.Tests.Facade.Party
{
    [TestClass]
    public class BookViewTests : SealedClassTests<BookView, UniqueView>
    {
        [TestMethod] public void BookNameTest() => isRequired<string>("Book name");
        [TestMethod] public void BooksLeftTest() => isDisplayNamed<int?>("Books left");
        [TestMethod] public void TotalNumberOfBooksTest() => isDisplayNamed<int?>("Total number of books");
        [TestMethod] public void BookInfoTest() => isDisplayNamed<string?>("Book info");
        [TestMethod] public void PhotoPathTest() => isProperty<string?>();

    }
}
