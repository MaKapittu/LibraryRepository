using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HW_01_Eurich_Kapitonova.Facade
{
    public abstract class IsoNamedView : NamedView
    {
        [DisplayName("English name")] public new string? Name { get; set; }
        [Required][DisplayName("ISO three letter code")] public new string? Code { get; set; }
        [DisplayName("Native name")] public new string? Description { get; set; }
    }
}
