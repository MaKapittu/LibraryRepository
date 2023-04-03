using HW_01_Eurich_Kapitonova.Data.Party;

namespace HW_01_Eurich_Kapitonova.Domain.Party
{
    public interface ILibrarianRepo : IRepo<Librarian> {}
    public sealed class Librarian : UniqueEntity <LibrarianData>
    {
        public Librarian() : this(new ()) { }
        public Librarian(LibrarianData d): base(d) { }
        public string FirstName => getValue(Data?.FirstName);
        public string LastName => getValue(Data?.LastName);
        public int AmountOfReadersItHelps => getValue(Data?.AmountOfReadersItHelps);
        public string Position => getValue(Data?.Position);
        public override string ToString() => $"{FirstName} {LastName} ({Position}) - {AmountOfReadersItHelps}";
    }
}
