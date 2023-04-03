using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using System.Linq;

namespace HW_01_Eurich_Kapitonova.Infra.Party
{
    public sealed class LibrariansRepo : Repo<Librarian, LibrarianData>, ILibrarianRepo
    {
        public LibrariansRepo(LibraryDb? db) : base(db, db?.Librarians) { }
        protected internal override Librarian toDomain(LibrarianData d) => new(d);
        internal override IQueryable<LibrarianData> addFilter(IQueryable<LibrarianData> q)
        {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
               ? q : q.Where(
                x => x.FirstName.Contains(y)
                || x.LastName.Contains(y)
                || x.ID.Contains(y)
                || x.AmountOfReadersItHelps.ToString().Contains(y)
                || x.Position.Contains(y));
        }
    }
}
