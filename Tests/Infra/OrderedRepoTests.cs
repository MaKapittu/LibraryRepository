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
    public class OrderedRepoTests
        : AbstractClassTests<OrderedRepo<Address, AddressData>, FilteredRepo<Address, AddressData>>
    {
        private class testClass : OrderedRepo<Address, AddressData>
        {
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected internal override Address toDomain(AddressData d) => new(d);
        }
        protected override OrderedRepo<Address, AddressData> createObj()
        {
            var db = GetRepo.Instance<LibraryDb>();
            var set = db?.Addresses;
            return new testClass(db, set);
        }
        [TestMethod] public void CurrentOrderTest() => isProperty<string?>();
        [TestMethod] public void DescendingStringTest() => areEqual("_desc", testClass.DescendingString);
        [DataRow(null, true)]
        [DataRow(null, false)]
        [DataRow(nameof(Address.ID), true)]
        [DataRow(nameof(Address.ID), false)]
        [DataRow(nameof(Address.Street), true)]
        [DataRow(nameof(Address.Street), false)]
        [DataRow(nameof(Address.City), true)]
        [DataRow(nameof(Address.City), false)]
        [DataRow(nameof(Address.CountryID), true)]
        [DataRow(nameof(Address.CountryID), false)]
        [TestMethod]
        public void CreateSqlTest(string s, bool isDescending)
        {
            obj.CurrentOrder = (s is null) ? s : isDescending ? s + testClass.DescendingString : s;
            var q = obj.createSql();
            var actual = q.Expression.ToString();
            if (s is null) isTrue(actual.EndsWith(".Select(s => s)"));
            else if (isDescending) isTrue(actual.EndsWith(
                $".Select(s => s).OrderByDescending(x => Convert(x.{s}, Object))"));
            else isTrue(actual.EndsWith(
                $".Select(s => s).OrderBy(x => Convert(x.{s}, Object))"));
        }

        [DataRow(true, true)]
        [DataRow(false, true)]
        [DataRow(true, false)]
        [DataRow(false, false)]
        [TestMethod]
        public void SortOrderTest(bool isDescending, bool isSame)
        {
            var s = GetRandom.String();
            var c = isSame ? s : GetRandom.String();
            obj.CurrentOrder = isDescending ? c + testClass.DescendingString : c;
            var actual = obj.SortOrder(s);
            var sDes = s + testClass.DescendingString;
            var expected = isSame ? (isDescending ? s : sDes) : sDes;
            areEqual(expected, actual);
        }
    }
}
