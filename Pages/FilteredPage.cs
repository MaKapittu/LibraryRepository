using HW_01_Eurich_Kapitonova.Domain;
using HW_01_Eurich_Kapitonova.Facade;

namespace HW_01_Eurich_Kapitonova.Pages
{
    public abstract class FilteredPage<TView, TEntity, TRepo> : CrudPage<TView, TEntity, TRepo>
        where TView : UniqueView, new()
        where TRepo : IFilteredRepo<TEntity>
        where TEntity : UniqueEntity
    {
        protected FilteredPage(TRepo r) : base(r) { }
        public string? CurrentFilter
        {
            get => repo.CurrentFilter;
            set => repo.CurrentFilter = value;
        }
    }
}
