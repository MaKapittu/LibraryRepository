using HW_01_Eurich_Kapitonova.Data;
using HW_01_Eurich_Kapitonova.Data.Party;
using System;

namespace HW_01_Eurich_Kapitonova.Domain
{
    public abstract class UniqueEntity
    {
        public static string DefaultStr = "Undefined";
        private static DateTime defaultDate => DateTime.MinValue;
        private static int defaultInt => 0;
        protected static string getValue(string? v) => v ?? DefaultStr;
        protected static int getValue(int? v) => v ?? defaultInt;
        protected static DateTime getValue(DateTime? v) => v ?? defaultDate;
        protected static IsoGender getValue(IsoGender? v) => v ?? IsoGender.NotApplicable;
        public abstract string ID { get; }
        public abstract byte[] Token { get; }
    }
    public abstract class UniqueEntity<TData>: UniqueEntity where TData : UniqueData, new()
    {
        public TData Data { get; }
        public UniqueEntity() : this(new TData()) { }
        public UniqueEntity(TData d) => Data = d;
        public override string ID => getValue(Data?.ID);
        public override byte[] Token => Data?.Token ?? Array.Empty<byte>();
    }

}
