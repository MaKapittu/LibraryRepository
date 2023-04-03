using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using HW_01_Eurich_Kapitonova.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Facade.Party
{
    [TestClass]
    public class LibrarianViewFactoryTests : ViewFactoryTests<LibrarianViewFactory, LibrarianView, Librarian, LibrarianData>
    {
        [TestMethod] public override void CreateTest() { }
        protected override Librarian toObject(LibrarianData d) => new(d);
        [TestMethod]
        public override void CreateViewTest()
        {
            var v = GetRandom.Value<LibrarianView>() as LibrarianView;
            var e = new LibrarianViewFactory().Create(v);
            isNotNull(e);
            isNotNull(v);
            arePropertiesEqual(e, v);
            areNotEqual(e.ToString(), v.LibrarianInfo);
        }
    }
}
