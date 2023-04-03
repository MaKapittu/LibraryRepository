using HW_01_Eurich_Kapitonova.Data.Party;
using Microsoft.EntityFrameworkCore;

namespace HW_01_Eurich_Kapitonova.Infra
{
    public sealed class LibraryDb : DbContext
    {
        public LibraryDb(DbContextOptions<LibraryDb> options) : base(options) { }
        public DbSet<PersonData> Persons { get; set; }
        public DbSet<BookData> Books { get; set; }
        public DbSet<LibrarianData> Librarians { get; set; }
        public DbSet<AddressData> Addresses { get; set; }
        public DbSet<CountryData> Countries { get; set; }
        public DbSet<CurrencyData> Currencies { get; set; }
        public DbSet<CountryCurrencyData> CountryCurrencies { get; set; }
        public DbSet<PersonAddressData> PersonAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);
            InitializeTables(b);
        }
        public static void InitializeTables(ModelBuilder b)
        {
            var s = nameof(LibraryDb)[0..^2];
            _=(b?.Entity<PersonData>()?.ToTable(nameof(Persons), s));
            _=(b?.Entity<BookData>()?.ToTable(nameof(Books), s));
            _=(b?.Entity<LibrarianData>()?.ToTable(nameof(Librarians), s));
            _=(b?.Entity<AddressData>()?.ToTable(nameof(Addresses), s));
            _ =(b?.Entity<CountryData>()?.ToTable(nameof(Countries), s));
            _ = (b?.Entity<CurrencyData>()?.ToTable(nameof(Currencies), s));
            _ = (b?.Entity<CountryCurrencyData>()?.ToTable(nameof(CountryCurrencies), s));
            _ = (b?.Entity<PersonAddressData>()?.ToTable(nameof(PersonAddresses), s));
        }
    }
}
