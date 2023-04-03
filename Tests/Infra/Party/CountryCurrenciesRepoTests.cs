﻿using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain;
using HW_01_Eurich_Kapitonova.Domain.Party;
using HW_01_Eurich_Kapitonova.Infra;
using HW_01_Eurich_Kapitonova.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW_01_Eurich_Kapitonova.Tests.Infra.Party
{
    [TestClass]
    public class CountryCurrenciesRepoTests
        : SealedRepoTests<CountryCurrenciesRepo, Repo<CountryCurrency, CountryCurrencyData>, CountryCurrency, CountryCurrencyData>
    {
        protected override CountryCurrenciesRepo createObj() => new(GetRepo.Instance<LibraryDb>());
        protected override object? getSet(LibraryDb db) => db.CountryCurrencies;
    }
}
