using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using HW_01_Eurich_Kapitonova.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Facade.Party
{
    [TestClass]
    public class CurrencyViewFactoryTests
        : ViewFactoryTests<CurrencyViewFactory, CurrencyView, Currency, CurrencyData>
    {
        protected override Currency toObject(CurrencyData d) => new(d);
    }
}
