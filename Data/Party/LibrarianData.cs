
namespace HW_01_Eurich_Kapitonova.Data.Party
{
    public sealed class LibrarianData: UniqueData
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public int? AmountOfReadersItHelps { get; set; }
    }
}
