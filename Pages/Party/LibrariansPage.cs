using HW_01_Eurich_Kapitonova.Domain.Party;
using HW_01_Eurich_Kapitonova.Facade.Party;
using Microsoft.AspNetCore.Mvc;

namespace HW_01_Eurich_Kapitonova.Pages.Party
{
    public class LibrariansPage : PagedPage<LibrarianView, Librarian, ILibrarianRepo>
    {
        public LibrariansPage(ILibrarianRepo r) : base(r) { }
        protected override Librarian toObject(LibrarianView item) => new LibrarianViewFactory().Create(item);
        protected override LibrarianView toView(Librarian entity) => new LibrarianViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(LibrarianView.LibrarianInfo),
            nameof(LibrarianView.FirstName),
            nameof(LibrarianView.LastName),
            nameof(LibrarianView.Position),
            nameof(LibrarianView.AmountOfReadersItHelps)
        };
    }
}

