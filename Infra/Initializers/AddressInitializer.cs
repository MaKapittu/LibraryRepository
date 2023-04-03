using HW_01_Eurich_Kapitonova.Data.Party;
using System.Collections.Generic;

namespace HW_01_Eurich_Kapitonova.Infra.Initializers
{
    public sealed class AddressInitializer : BaseInitializer<AddressData>
    {
        public AddressInitializer(LibraryDb? db) : base(db, db?.Addresses) { }
        protected override IEnumerable<AddressData> getEntities => new[]
        {
           CreateAddress("Mustamae tee", "Tallinn", "Harjumaa", "12917", "EST"),
           CreateAddress("14 Whitehall", "London", "Covent Garden", "SW1A 2DY", "GBR"),
           CreateAddress("Cheviot Drive in Cheviot Hills", "Los Angeles", "California", "10265", "USA"),
           CreateAddress("Estonia pst 9", "Tallinn", "Harjumaa", "11314", "EST"),
        };
        internal static AddressData CreateAddress(string street, string city, string region, string zipCode, string country)
        {
            var address = new AddressData
            {
                ID = street,
                Street = street,
                City = city,
                Region = region,
                ZipCode = zipCode,
                CountryID = country
            };
            return address;
        }
    }
}
