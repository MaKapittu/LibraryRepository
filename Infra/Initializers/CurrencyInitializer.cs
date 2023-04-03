using HW_01_Eurich_Kapitonova.Data.Party;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace HW_01_Eurich_Kapitonova.Infra.Initializers
{
    public sealed class CurrencyInitializer : BaseInitializer<CurrencyData>
    {
        public CurrencyInitializer(LibraryDb? db) : base(db, db?.Currencies) { }
        protected override IEnumerable<CurrencyData> getEntities
        {
            get
            {
                var l = new List<CurrencyData>();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
                {
                    var c = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var id = c.ISOCurrencySymbol;
                    if (!isCorrectISOCode(id)) continue;
                    if (l.FirstOrDefault(x => x.ID == id) is not null) continue;
                    var d = createCurrency(id, c.CurrencyEnglishName, c.CurrencyNativeName);
                    l.Add(d);
                }
                return l;
            }
        }
        internal static CurrencyData createCurrency(string code, string name, string description)
            => new() { ID = code, Code = code, Name = name, Description = description};
    }
}

