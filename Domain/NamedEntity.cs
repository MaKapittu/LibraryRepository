﻿using HW_01_Eurich_Kapitonova.Data;

namespace HW_01_Eurich_Kapitonova.Domain
{
    public abstract class NamedEntity<TData> : UniqueEntity<TData> where TData : NamedData, new()
    {
        public NamedEntity() : this(new TData()) { }
        public NamedEntity(TData d) : base(d) { }
        public string? Name => getValue(Data?.Name);
        public string? Code => getValue(Data?.Code);
        public string? Description => getValue(Data?.Description);
    }

}
