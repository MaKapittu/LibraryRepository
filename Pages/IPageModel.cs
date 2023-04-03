namespace HW_01_Eurich_Kapitonova.Pages
{
    public interface IPageModel
    {
        public int PageIndex { get; }
        public string? CurrentFilter { get; }
        public string? CurrentOrder { get; }
        public string? SortOrder(string propertyName);
    }
}
