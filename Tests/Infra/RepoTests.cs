using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using HW_01_Eurich_Kapitonova.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Infra
{
    [TestClass]
    public class RepoTests
         : AbstractClassTests<Repo<Address, AddressData>, PagedRepo<Address, AddressData>>
    {
        private class testClass : Repo<Address, AddressData>
        {
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected internal override Address toDomain(AddressData d) => new(d);
        }
        protected override Repo<Address, AddressData> createObj() => new testClass(null, null);
    }

}
