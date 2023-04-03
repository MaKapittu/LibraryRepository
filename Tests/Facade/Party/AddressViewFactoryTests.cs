using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using HW_01_Eurich_Kapitonova.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Facade.Party
{
    [TestClass]
    public class AddressViewFactoryTests : ViewFactoryTests<AddressViewFactory, AddressView, Address, AddressData>
    {
        protected override Address toObject(AddressData d) => new(d);
    }
}
