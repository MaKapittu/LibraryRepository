
using HW_01_Eurich_Kapitonova.Facade;
using System.Collections.Generic;

namespace HW_01_Eurich_Kapitonova.Pages
{
    public interface IIndexModel<TView> where TView : UniqueView
    {
        public string[] IndexColumns { get; }
        public IList<TView>? Items { get; }
        public object? GetValue(string name, TView v);
        string? DisplayName(string name);

    }
}
