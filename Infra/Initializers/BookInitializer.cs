using HW_01_Eurich_Kapitonova.Data.Party;
using System.Collections.Generic;


namespace HW_01_Eurich_Kapitonova.Infra.Initializers
{
    public sealed class BookInitializer : BaseInitializer<BookData>
    {
        public BookInitializer(LibraryDb? db) : base(db, db?.Books) { }
        internal static BookData CreateBook(string bookName, int booksLeft, int totalNumberOfBooks, string photoPath)
        {
            var book = new BookData
            {
                ID = bookName,
                BookName = bookName,
                BooksLeft = booksLeft,
                TotalNumberOfBooks = totalNumberOfBooks,
                PhotoPath = photoPath,
            };
            return book;
        }
        protected override IEnumerable<BookData> getEntities => new[]
               {
            CreateBook("The Guns of August", 7, 10, "TheGunsOfAugust.jpg"),
            CreateBook("The Voyage of the Beagle (1845)", 3, 5, "TheVoyageOfTheBeagle.jpg"),
            CreateBook("Relativity: The Special and General Theory", 5, 9, "Relativity.jpg"),
            CreateBook("Harry Potter and the Philosopher's Stone", 7, 15, "HarryPotter.jpg"),
            CreateBook("The little Prince", 2, 5, "LittlePrince.jpg"),
            CreateBook("The Catcher in the Rye", 6, 6, "TheCatcher.jpg"),
            CreateBook("The Da Vinci Code", 7, 8, "TheCodeDaVinci.jpg"),
            CreateBook("The Midnight Library", 9, 10, "TheMid.jpg"),
            CreateBook("The Adventures of Pinocchio", 3, 11, "ThePinocchio.jpg"),
        };
    }
}
