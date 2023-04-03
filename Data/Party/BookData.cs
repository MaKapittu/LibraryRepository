
namespace HW_01_Eurich_Kapitonova.Data.Party
{
    public sealed class BookData: UniqueData
    {
        public string? BookName { get; set; }
        public int? BooksLeft { get; set; }
        public int? TotalNumberOfBooks { get; set; }
        public string? PhotoPath { get; set; }
    }
}
