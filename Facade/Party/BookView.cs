using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HW_01_Eurich_Kapitonova.Facade.Party
{
    public sealed class BookView:UniqueView
    {
        [Required][DisplayName("Book name")] public string? BookName { get; set; }
        [DisplayName("Books left")] public int? BooksLeft { get; set; }
        [DisplayName("Total number of books")] public int? TotalNumberOfBooks { get; set; }
        [DisplayName("Book info")] public string? BookInfo { get; set; }
        public string? PhotoPath { get; set; }
    }
    public sealed class BookViewFactory : BaseViewFactory<BookView, Book, BookData>
    {
        protected override Book toEntity(BookData d) => new(d);
        public override BookView Create(Book? e)
        {
            var v = base.Create(e);
            v.BookInfo = e?.ToString();
            return v;
        }
    }
}
