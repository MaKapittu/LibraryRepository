using HW_01_Eurich_Kapitonova.Domain.Party;
using HW_01_Eurich_Kapitonova.Facade.Party;

namespace HW_01_Eurich_Kapitonova.Pages.Party
{
    public class BooksPage : PagedPage<BookView, Book, IBookRepo>
    {
        public BooksPage(IBookRepo r) : base(r) { }
        protected override Book toObject(BookView item) => new BookViewFactory().Create(item);
        protected override BookView toView(Book entity) => new BookViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(BookView.BookInfo),
            nameof(BookView.BookName),
            nameof(BookView.BooksLeft),
            nameof(BookView.PhotoPath),
            nameof(BookView.TotalNumberOfBooks)
        };
    }
}

