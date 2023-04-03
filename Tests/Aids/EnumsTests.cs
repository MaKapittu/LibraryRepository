using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Aids
{
    [TestClass]
    public class EnumsTests : TypeTests
    {
        [TestMethod]
        public void DescriptionTest()
             => areEqual("Not applicable", Enums.Description(IsoGender.NotApplicable));
        [TestMethod]
        public void ToStringTest()
              => areEqual("NotApplicable", IsoGender.NotApplicable.ToString());
    }
}
