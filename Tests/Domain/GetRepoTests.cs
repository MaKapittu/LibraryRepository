using HW_01_Eurich_Kapitonova.Domain;
using HW_01_Eurich_Kapitonova.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HW_01_Eurich_Kapitonova.Infra.Party;

namespace HW_01_Eurich_Kapitonova.Tests.Domain
{
    [TestClass]
    public class GetRepoTests : TypeTests 
    {
        private class testClass : IServiceProvider
        {
            public object? GetService(Type serviceType)
            {
                throw new NotImplementedException();
            }
        }
        [TestMethod]
        public void InstanceTest()
            => Assert.IsInstanceOfType(GetRepo.Instance<ICountryRepo>(), typeof(CountriesRepo));
        [TestMethod]
        public void SetServiceTest()
        {
            var s = GetRepo.service;
            var x = new testClass();
            GetRepo.SetService(x);
            areEqual(x, GetRepo.service);
            GetRepo.service = s;
        }
    }
}
