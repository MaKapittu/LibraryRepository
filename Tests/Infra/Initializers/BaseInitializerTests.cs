using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain;
using HW_01_Eurich_Kapitonova.Infra;
using HW_01_Eurich_Kapitonova.Infra.Initializers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HW_01_Eurich_Kapitonova.Tests.Infra.Initializers
{
    [TestClass]
    public class BaseInitializerTests
        : AbstractClassTests<BaseInitializer<AddressData>, object>
    {
        private class testClass : BaseInitializer<AddressData>
        {
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected override IEnumerable<AddressData> getEntities => throw new System.NotImplementedException();
        }
        protected override BaseInitializer<AddressData> createObj()
        {
            var db = GetRepo.Instance<LibraryDb>();
            var set = db?.Addresses;
            return new testClass(db, set);
        }
    }
}
