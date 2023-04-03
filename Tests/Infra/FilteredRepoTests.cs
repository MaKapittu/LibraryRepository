using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain;
using HW_01_Eurich_Kapitonova.Domain.Party;
using HW_01_Eurich_Kapitonova.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Infra
{
    [TestClass]
    public class FilteredRepoTests
         : AbstractClassTests<FilteredRepo<Address, AddressData>, CrudRepo<Address, AddressData>>
    {
        private class testClass : FilteredRepo<Address, AddressData>
        {
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected internal override Address toDomain(AddressData d) => new(d);
        }
        protected override FilteredRepo<Address, AddressData> createObj()
        {
            var db = GetRepo.Instance<LibraryDb>();
            var set = db?.Addresses;
            return new testClass(db, set);
        }
        [TestMethod] public void CurrentFilterTest() => isProperty<string>();
        [DataRow(true)]
        [DataRow(false)]
        [TestMethod]
        public void CreateSqlTest(bool hasCurrentFilter)
        {
            obj.CurrentFilter = hasCurrentFilter ? GetRandom.String() : null;
            var q1 = obj.createSql();
            var q2 = obj.addFilter(q1);
            areEqual(q1, q2);
            var s = q1.Expression.ToString();
            isTrue(s.EndsWith(".Select(s => s)"));
        }
    }
}
