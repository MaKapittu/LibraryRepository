using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HW_01_Eurich_Kapitonova.Tests.Aids
{
    [TestClass]
    public class ConcurencyTokenTests : TypeTests
    {
        [TestMethod]
        public void ToStrTests() => isInconclusive();
        //{
        //    var s = string.Empty;
        //    foreach (var b in token ?? Array.Empty<byte>()) s += b;
        //    return s;
        //}
        public void ToByteArray() => isInconclusive();
        //{
        //    var l = new List<byte>();
        //    foreach (var c in token ?? GetRandom.String(8, 8)) l.Add(Convert.ToByte(c));
        //    return l.ToArray();
        //}
    }
}
