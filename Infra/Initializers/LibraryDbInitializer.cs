namespace HW_01_Eurich_Kapitonova.Infra.Initializers
{
    public static class LibraryDbInitializer
    {
        public static void Init(LibraryDb? db)
        {
            new AddressInitializer(db).Init();
            new PersonInitializer(db).Init();
            new BookInitializer(db).Init();
            new LibrarianInitializer(db).Init();
            new CountryInitializer(db).Init();
            new CurrencyInitializer(db).Init();
            new CountryCurrencyInitializer(db).Init();
        }
    }
}
