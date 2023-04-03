using System;
using System.ComponentModel.DataAnnotations;

namespace HW_01_Eurich_Kapitonova.Data
{
    public abstract class UniqueData
    {
        public static string newID => Guid.NewGuid().ToString();
        public string ID { get; set; } = newID;
        protected static byte[] empty => Array.Empty<byte>();
        [Timestamp] public byte[] Token { get; set; } = empty;
    }
}