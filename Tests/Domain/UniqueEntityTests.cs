using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Domain
{
    [TestClass]
    public class UniqueEntityTests : AbstractClassTests<UniqueEntity<CountryData>, UniqueEntity>
    {
        private CountryData? d;
        private class testClass : UniqueEntity<CountryData>
        {
            public testClass() : this(new CountryData()) { }
            public testClass(CountryData d) : base(d) { }
        }
        protected override UniqueEntity<CountryData> createObj()
        {
            d = GetRandom.Value<CountryData>();
            return new testClass(d);
        }
        [TestMethod] public void IDTest() => isReadOnly(obj.Data.ID);
        [TestMethod] public void TokenTest() => isReadOnly(obj.Data.Token);
        [TestMethod] public void DataTest() => isReadOnly(d);
        [TestMethod] public void DefaultStrTest() => areEqual("Undefined", UniqueEntity.DefaultStr);
    }
}
