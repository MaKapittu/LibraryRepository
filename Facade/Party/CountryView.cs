using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;


namespace HW_01_Eurich_Kapitonova.Facade.Party
{
    public sealed class CountryView : IsoNamedView{ }
   
    public sealed class CountryViewFactory : BaseViewFactory<CountryView, Country, CountryData>
    {
        protected override Country toEntity(CountryData d) => new(d);
    }
}
