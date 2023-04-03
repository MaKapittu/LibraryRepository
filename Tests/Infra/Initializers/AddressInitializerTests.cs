using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain;
using HW_01_Eurich_Kapitonova.Infra;
using HW_01_Eurich_Kapitonova.Infra.Initializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Infra.Initializers
{
    [TestClass]
    public class AddressInitializerTests
        : SealedBaseTests<AddressInitializer, BaseInitializer<AddressData>>
    {
        protected override AddressInitializer createObj()
        {
            var db = GetRepo.Instance<LibraryDb>();
            return new AddressInitializer(db);
        }
    }
}
