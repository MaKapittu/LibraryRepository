using HW_01_Eurich_Kapitonova.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HW_01_Eurich_Kapitonova.Infra.Initializers
{
    public abstract class BaseInitializer<TData> where TData : UniqueData
    {
        internal protected DbContext? db;
        internal protected DbSet<TData>? set;
        protected BaseInitializer(DbContext? c, DbSet<TData>? s)
        {
            db = c;
            set = s;
        }
        public void Init()
        {
            if (set?.Any() ?? true) return;
            set.AddRange(getEntities);
            db?.SaveChanges();
        }
        protected abstract IEnumerable<TData> getEntities { get; }
        internal static bool isCorrectISOCode(string id) => string.IsNullOrWhiteSpace(id) ? false : char.IsLetter(id[0]);
    }
}
