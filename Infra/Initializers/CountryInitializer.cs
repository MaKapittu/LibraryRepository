using HW_01_Eurich_Kapitonova.Data;
using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace HW_01_Eurich_Kapitonova.Infra.Initializers
{

    public sealed class CountryInitializer : BaseInitializer<CountryData>
    {
        public CountryInitializer(LibraryDb? db) : base(db, db?.Countries) { }
        protected override IEnumerable<CountryData> getEntities
        {
            get
            {
                var l = new List<CountryData>();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
                {
                    var c = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var id = c.ThreeLetterISORegionName;
                    if (!isCorrectISOCode(id)) continue;
                    if (l.FirstOrDefault(x => x.ID == id) is not null) continue;
                    var d = createCountry(id, c.EnglishName, c.NativeName);
                    l.Add(d);
                }
                return l;
            }
        }
        internal static CountryData createCountry(string code, string name, string description)
            => new()
            {
                ID = code ?? UniqueData.newID,
                Code = code ?? UniqueEntity.DefaultStr,
                Name = name,
                Description = description
            };
    }
}

