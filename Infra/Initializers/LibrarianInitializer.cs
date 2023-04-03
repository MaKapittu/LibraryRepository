using HW_01_Eurich_Kapitonova.Data.Party;
using System;
using System.Collections.Generic;

namespace HW_01_Eurich_Kapitonova.Infra.Initializers
{
    public sealed class LibrarianInitializer : BaseInitializer<LibrarianData>
    {
        public LibrarianInitializer(LibraryDb? db) : base(db, db?.Librarians) { }
        internal static LibrarianData CreateLibrarian(string firstName, string lastName, string position, int amountOfReadersItHelps)
        {
            var librarian = new LibrarianData
            {
                ID = firstName+lastName,
                FirstName = firstName,
                LastName = lastName,
                Position = position,
                AmountOfReadersItHelps = amountOfReadersItHelps
            };
            return librarian;
        }
        protected override IEnumerable<LibrarianData> getEntities => new[]
               {
            CreateLibrarian("Ande", "Lalli", "Сurator of book archives", 1),
            CreateLibrarian("Amanda", "Haw"," Librarian of historical literature", 15),
            CreateLibrarian("Viljam", "Bardu", "Librarian of science literature", 20),
        };
    }
}
