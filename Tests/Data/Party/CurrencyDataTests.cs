using HW_01_Eurich_Kapitonova.Data;
using HW_01_Eurich_Kapitonova.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HW_01_Eurich_Kapitonova.Tests.Data.Party
{
    [TestClass]
    public class CurrencyDataTests: SealedClassTests<CurrencyData, NamedData>
    {
        [TestMethod] public void IDTest() => isProperty<string?>();
        [TestMethod] public void NameTest() => isProperty<string?>();
        [TestMethod] public void CodeTest() => isProperty<string?>();
        [TestMethod] public void DescriptionTest() => isProperty<string?>();
    }
}
