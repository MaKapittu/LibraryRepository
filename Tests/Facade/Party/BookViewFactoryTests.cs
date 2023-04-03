using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using HW_01_Eurich_Kapitonova.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Facade.Party
{
    [TestClass]
    public class BookViewFactoryTests : ViewFactoryTests<BookViewFactory, BookView, Book, BookData>
    {
        [TestMethod] public override void CreateTest() { }
        protected override Book toObject(BookData d) => new(d);
        [TestMethod]
        public override void CreateViewTest()
        {
            var v = GetRandom.Value<BookView>() as BookView;
            var e = new BookViewFactory().Create(v);
            isNotNull(e);
            isNotNull(v);
            arePropertiesEqual(e, v);
            areNotEqual(e.ToString(), v.BookInfo);
        }
    }
}
