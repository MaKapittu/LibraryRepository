using HW_01_Eurich_Kapitonova.Facade;
using HW_01_Eurich_Kapitonova.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Facade.Party
{
    [TestClass]
    public class PersonAddressViewTests : SealedClassTests<PersonAddressView, NamedView>
    {
        [TestMethod] public void PersonIDTest() => isRequired<string>("Person");
        [TestMethod] public void AddressIDTest() => isRequired<string>("Geographic address");
        [TestMethod] public void NameTest() => isDisplayNamed<string?>("Use for");
    }
}
