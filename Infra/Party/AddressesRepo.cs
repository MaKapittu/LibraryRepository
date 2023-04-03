using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using System.Linq;

namespace HW_01_Eurich_Kapitonova.Infra.Party
{
    public sealed class AddressesRepo : Repo<Address, AddressData>, IAddressRepo
    {
        public AddressesRepo(LibraryDb? db) : base(db, db?.Addresses) { }
        protected internal override Address toDomain(AddressData d) => new(d);

        internal override IQueryable<AddressData> addFilter(IQueryable<AddressData> q)
        {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
               ? q : q.Where(
                x => x.Street.Contains(y)
                || x.CountryID.Contains(y)
                || x.ID.Contains(y)
                || x.City.Contains(y)
                || x.Region.Contains(y)
                || x.ZipCode.Contains(y));
        }
    }
}
