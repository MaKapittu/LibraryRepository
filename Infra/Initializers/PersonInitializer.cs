using HW_01_Eurich_Kapitonova.Data.Party;
using System;
using System.Collections.Generic;

namespace HW_01_Eurich_Kapitonova.Infra.Initializers
{
    public sealed class PersonInitializer : BaseInitializer<PersonData>
    {
        public PersonInitializer(LibraryDb? db) : base(db, db?.Persons) { }
        internal static PersonData CreatePerson(string firstName, string lastName, DateTime dateOfBirth, int rentedBooksAmount, IsoGender gender)
        {
            var person = new PersonData
            {
                ID = firstName + lastName,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                RentedBooksAmount = rentedBooksAmount,
                Gender = gender  
            };
            return person;
        }
        protected override IEnumerable<PersonData> getEntities => new[]
               {
            CreatePerson("Alakei", "Kek", new DateTime(2000, 03, 01), 10, IsoGender.NotApplicable),
            CreatePerson("Stephen", "Hawking", new DateTime(1942, 01, 08), 15,IsoGender.Male ),
            CreatePerson("Ray", "Bradbury", new DateTime(1920, 08, 22), 30, IsoGender.Male),
            CreatePerson("Mary", "Whakins", new DateTime(1820, 03, 11), 3, IsoGender.Female),
            CreatePerson("Alan", "Liht", new DateTime(2000, 01, 01), 1, IsoGender.NotKnown),
        };
    }
}
