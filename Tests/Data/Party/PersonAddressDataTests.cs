using HW_01_Eurich_Kapitonova.Data;
using HW_01_Eurich_Kapitonova.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Data.Party
{
    [TestClass]
    public class PersonAddressDataTests : SealedClassTests<PersonAddressData, NamedData>
    {
        [TestMethod] public void PersonIDTest() => isProperty<string>();
        [TestMethod] public void AddressIDTest() => isProperty<string>();
    }
}
