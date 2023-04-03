using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using System.Linq;

namespace HW_01_Eurich_Kapitonova.Infra.Party
{
    public sealed class PersonAddressesRepo : Repo<PersonAddress, PersonAddressData>, IPersonAddressRepo
    {
        public PersonAddressesRepo(LibraryDb? db) : base(db, db?.PersonAddresses) { }
        protected internal override PersonAddress toDomain(PersonAddressData d) => new(d);

        internal override IQueryable<PersonAddressData> addFilter(IQueryable<PersonAddressData> q)
        {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                ? q : q.Where(
                x => x.ID.Contains(y)
                || x.Code.Contains(y)
                || x.Name.Contains(y)
                || x.Description.Contains(y)
                || x.PersonID.Contains(y)
                || x.AddressID.Contains(y));
        }
    }
}
