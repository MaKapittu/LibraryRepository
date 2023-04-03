using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using HW_01_Eurich_Kapitonova.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Facade.Party
{
    [TestClass]
    public class PersonAddressViewFactoryTests
        : ViewFactoryTests<PersonAddressViewFactory, PersonAddressView, PersonAddress, PersonAddressData>
    {
        protected override PersonAddress toObject(PersonAddressData d) => new(d);
    }
}
