
using HW_01_Eurich_Kapitonova.Data;
using HW_01_Eurich_Kapitonova.Domain;
using Microsoft.EntityFrameworkCore;

namespace HW_01_Eurich_Kapitonova.Infra
{
    public abstract class Repo<TDomain, TData> : PagedRepo<TDomain, TData>
        where TDomain : UniqueEntity<TData>, new() where TData : UniqueData, new()
    {
        protected Repo(DbContext c, DbSet<TData> s) : base(c, s) { }
        internal protected static bool contains(string? value, string s) => (s is null) || (value?.Contains(s) ?? false);
    }
}
