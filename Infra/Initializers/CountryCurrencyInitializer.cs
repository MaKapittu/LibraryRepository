using HW_01_Eurich_Kapitonova.Data;
using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain;
using System.Collections.Generic;
using System.Globalization;

namespace HW_01_Eurich_Kapitonova.Infra.Initializers
{
    public sealed class CountryCurrencyInitializer : BaseInitializer<CountryCurrencyData>
    {
        public CountryCurrencyInitializer(LibraryDb? db) : base(db, db?.CountryCurrencies) { }
        protected override IEnumerable<CountryCurrencyData> getEntities
        {
            get
            {
                var l = new List<CountryCurrencyData>();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
                {
                    var c = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var countryID = c.ThreeLetterISORegionName;
                    var currencyID = c.ISOCurrencySymbol;
                    var nativeName = c.CurrencyNativeName;
                    var currencyCode = c.CurrencySymbol;
                    var d = createEntity(countryID, currencyID, currencyCode, nativeName);
                    l.Add(d);
                }
                return l;
            }
        }
        internal static CountryCurrencyData createEntity(string countryID, string currencyID,
             string code, string? name = null, string? description = null)
             => new()
             {
                 ID = UniqueData.newID,
                 CurrencyID = currencyID,
                 CountryID = countryID,
                 Code = code ?? UniqueEntity.DefaultStr,
                 Name = name,
                 Description = description
             };
    }
}

