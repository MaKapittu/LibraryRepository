using System;

namespace HW_01_Eurich_Kapitonova.Data.Party
{
    public sealed class PersonData : UniqueData
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? RentedBooksAmount { get; set; }
        public IsoGender? Gender { get; set; }
    }
}
