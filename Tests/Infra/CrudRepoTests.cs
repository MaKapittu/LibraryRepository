using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain;
using HW_01_Eurich_Kapitonova.Domain.Party;
using HW_01_Eurich_Kapitonova.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace HW_01_Eurich_Kapitonova.Tests.Infra
{
    [TestClass]
    public class CrudRepoTests
         : AbstractClassTests<CrudRepo<Address, AddressData>, BaseRepo<Address, AddressData>>
    {
        private LibraryDb? db;
        private DbSet<AddressData>? set;
        private AddressData? d;
        private Address? a;
        private int cnt;

        private class testClass : CrudRepo<Address, AddressData>
        {
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s) { }
            protected internal override Address toDomain(AddressData d) => new(d);
        }
        protected override CrudRepo<Address, AddressData> createObj()
        {
            db = GetRepo.Instance<LibraryDb>();
            set = db?.Addresses;
            isNotNull(set);
            return new testClass(db, set);
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            initSet();
            initAdr();
        }
        private void initSet()
        {
            cnt = GetRandom.Int32(5, 15);
            for (var i = 0; i < cnt; i++) set?.Add(GetRandom.Value<AddressData>());
            _ = db?.SaveChanges();
        }
        private void initAdr()
        {
            d = GetRandom.Value<AddressData>();
            isNotNull(d);
            a = new Address(d);
            var x = obj.Get(d.ID);
            isNotNull(x);
            areNotEqual(d.ID, x.ID);
        }
        [TestMethod]
        public async Task AddTest()
        {
            isNotNull(a);
            isNotNull(set);
            _ = obj?.Add(a);
            areEqual(cnt + 1, await set.CountAsync());
        }
        [TestMethod]
        public async Task AddAsyncTest()
        {
            isNotNull(a);
            isNotNull(set);
            _ = await obj.AddAsync(a);
            areEqual(cnt + 1, await set.CountAsync());
        }
        [TestMethod]
        public async Task DeleteTest()
        {
            isNotNull(d);
            await GetTest();
            _ = obj.Delete(d.ID);
            var x = obj.Get(d.ID);
            isNotNull(x);
            areNotEqual(d.ID, x.ID);
        }
        [TestMethod]
        public async Task DeleteAsyncTest()
        {
            isNotNull(d);
            await GetTest();
            _ = await obj.DeleteAsync(d.ID);
            var x = obj.Get(d.ID);
            isNotNull(x);
            areNotEqual(d.ID, x.ID);
        }
        [TestMethod]
        public async Task GetTest()
        {
            isNotNull(d);
            await AddTest();
            var x = obj.Get(d.ID);
            arePropertiesEqual(d, x.Data);
        }

        [DataRow(nameof(Address.ID))]
        [DataRow(nameof(Address.Street))]
        [DataRow(nameof(Address.City))]
        [DataRow(nameof(Address.ZipCode))]
        [DataRow(nameof(Address.Region))]
        [DataRow(nameof(Address.CountryID))]
        [DataRow(nameof(Address.Country))]
        [DataRow(nameof(Address.ToString))]
        [DataRow(null)]
        [TestMethod]
        public void GetAllTest(string s)
        {
            Func<Address, dynamic>? orderBy = null;
            if (s is nameof(Address.ID)) orderBy = x => x.ID;
            else if (s is nameof(Address.Street)) orderBy = x => x.Street;
            else if (s is nameof(Address.City)) orderBy = x => x.City;
            else if (s is nameof(Address.ZipCode)) orderBy = x => x.ZipCode;
            else if (s is nameof(Address.Region)) orderBy = x => x.Region;
            else if (s is nameof(Address.CountryID)) orderBy = x => x.CountryID;
            else if (s is nameof(Address.Country)) orderBy = x => x.Country;
            else if (s is nameof(Address.ToString)) orderBy = x => x.ToString();
            var l = obj.GetAll(orderBy);
            areEqual(cnt, l.Count);
            if (orderBy is null) return;
            for (var i = 0; i < l.Count - 1; i++)
            {
                var a = l[i];
                var b = l[i + 1];
                var aX = orderBy(a) as IComparable;
                var bX = orderBy(b) as IComparable;
                isNotNull(aX);
                isNotNull(bX);
                var r = aX.CompareTo(bX);
                isTrue(r <= 0);
            }
        }
        [TestMethod]
        public void GetListTest()
        {
            var l = obj.Get();
            areEqual(cnt, l.Count);
        }
        [TestMethod]
        public async Task GetAsyncTest()
        {
            isNotNull(d);
            await AddTest();
            var x = await obj.GetAsync(d.ID);
            arePropertiesEqual(d, x.Data);
        }
        [TestMethod]
        public async Task GetListAsyncTest()
        {
            var l = await obj.GetAsync();
            areEqual(cnt, l.Count);
        }
        [TestMethod]
        public async Task UpdateTest()
        {
            await GetTest();
            var dX = GetRandom.Value<AddressData>() as AddressData;
            isNotNull(d);
            isNotNull(dX);
            dX.ID = d.ID;
            var aX = new Address(dX);
            _ = obj.Update(aX);
            var x = obj.Get(d.ID);
            areEqualProperties(dX, x.Data);
        }
        [TestMethod]
        public async Task UpdateAsyncTest()
        {
            await GetTest();
            var dX = GetRandom.Value<AddressData>() as AddressData;
            isNotNull(d);
            isNotNull(dX);
            dX.ID = d.ID;
            var aX = new Address(dX);
            _ = await obj.UpdateAsync(aX);
            var x = obj.Get(d.ID);
            areEqualProperties(dX, x.Data);
        }
    }
}
