using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain;
using HW_01_Eurich_Kapitonova.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Domain.Party
{
    [TestClass]
    public class BookTests : SealedClassTests<Book, UniqueEntity<BookData>>
    {
        protected override Book createObj() => new(GetRandom.Value<BookData>());
        [TestMethod] public void BookNameTest() => isReadOnly(obj.Data.BookName);
        [TestMethod] public void BooksLeftTest() => isReadOnly(obj.Data.BooksLeft);
        [TestMethod] public void TotalNumberOfBooksTest() => isReadOnly(obj.Data.TotalNumberOfBooks);
        [TestMethod] public void PhotoPathTest() => isReadOnly(obj.Data.PhotoPath);
        [TestMethod] public void ToStringTest()
        {
            var expected = $"{obj.BookName} ({obj.BooksLeft} / {obj.TotalNumberOfBooks})";
            areEqual(expected, obj.ToString());
        }
    }
}
