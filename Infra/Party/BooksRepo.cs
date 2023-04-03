using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using System.Linq;

namespace HW_01_Eurich_Kapitonova.Infra.Party
{
    public sealed class BooksRepo : Repo<Book, BookData>, IBookRepo
    {
        public BooksRepo(LibraryDb? db) : base(db, db?.Books) { }
        protected internal override Book toDomain(BookData d) => new(d);
        internal override IQueryable<BookData> addFilter(IQueryable<BookData> q)
        {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                 ? q : q.Where(
                x => x.BookName.Contains(y)
                || x.ID.Contains(y)
                || x.BooksLeft.ToString().Contains(y)
                || x.PhotoPath.Contains(y)
                || x.TotalNumberOfBooks.ToString().Contains(y));
        }
    }
}
