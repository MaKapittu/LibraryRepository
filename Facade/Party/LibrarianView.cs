using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HW_01_Eurich_Kapitonova.Facade.Party
{
    public sealed class LibrarianView : UniqueView
    { 
        [DisplayName("First name")][Required] public string? FirstName { get; set; }
        [DisplayName("Last name")][Required] public string? LastName { get; set; }
        [DisplayName("Position")] public string? Position { get; set; }
        [DisplayName("Amount of readers it helps")] public int? AmountOfReadersItHelps { get; set; }
        [DisplayName("Librarian info")] public string? LibrarianInfo { get; set; }
    }
    public sealed class LibrarianViewFactory : BaseViewFactory<LibrarianView, Librarian, LibrarianData>
    {
        protected override Librarian toEntity(LibrarianData d) => new(d);
        public override LibrarianView Create(Librarian? e)
        {
            var v = base.Create(e);
            v.LibrarianInfo = e?.ToString();
            return v;
        }
    }
}
