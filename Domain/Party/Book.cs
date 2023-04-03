using HW_01_Eurich_Kapitonova.Data.Party;

namespace HW_01_Eurich_Kapitonova.Domain.Party
{
    public interface IBookRepo : IRepo<Book>{ }
    public sealed class Book : UniqueEntity <BookData>
    {
        public Book() : this(new ()) { }
        public Book(BookData d): base(d) { }
        public string? BookName => getValue(Data?.BookName);
        public int? BooksLeft => getValue(Data?.BooksLeft);
        public int? TotalNumberOfBooks => getValue(Data?.TotalNumberOfBooks);
        public string PhotoPath => getValue(Data?.PhotoPath);
        public override string? ToString() => $"{BookName} ({BooksLeft} / {TotalNumberOfBooks})";
    }
}
