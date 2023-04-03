using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using HW_01_Eurich_Kapitonova.Facade;
using HW_01_Eurich_Kapitonova.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Facade.Party
{
    [TestClass]
    public class PersonViewFactoryTests : ViewFactoryTests<PersonViewFactory, PersonView, Person, PersonData>
    {
        [TestMethod] public override void CreateTest() { }
        protected override Person toObject(PersonData d) => new(d);
        [TestMethod]
        public override void CreateViewTest()
        {
            var v = GetRandom.Value<PersonView>() as PersonView;
            var e = new PersonViewFactory().Create(v);
            isNotNull(e);
            isNotNull(v);
            arePropertiesEqual(e, v);
            areNotEqual(e.ToString(), v.FullName);
        }
    }
}
