using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using System.Linq;

namespace HW_01_Eurich_Kapitonova.Infra.Party
{
    public sealed class PersonsRepo : Repo<Person, PersonData>, IPersonRepo
    {
        public PersonsRepo(LibraryDb? db) : base(db, db?.Persons) { }
        protected internal override Person toDomain(PersonData d) => new(d);
        internal override IQueryable<PersonData> addFilter(IQueryable<PersonData> q)
        {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                ? q : q.Where(
                x => x.FirstName.Contains(y)
                || x.LastName.Contains(y)
                || x.ID.Contains(y)
                || x.RentedBooksAmount.ToString().Contains(y)
                || x.DateOfBirth.ToString().Contains(y));
        }
    }
}
