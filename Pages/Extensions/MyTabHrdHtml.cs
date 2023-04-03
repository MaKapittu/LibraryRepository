using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace HW_01_Eurich_Kapitonova.Pages.Extensions
{
    public static class MyTabHrdHtml
    {
        public static IHtmlContent MyTabHdr<TModel>(this IHtmlHelper<TModel> h, string name)
        {
            var s = htmlStrings(name, h.ViewData.Model as IPageModel);
            return new HtmlContentBuilder(s);
        }
        private static List<object> htmlStrings(string name, IPageModel? m)
        {
            name ??= "Unspecified";
            var l = new List<object> {
                new HtmlString($"<a style=\"text-decoration:none;\" href=\"/{pageName(m)}?"),
                new HtmlString($"handler=Index&amp;"),
                new HtmlString($"order={m?.SortOrder(name)}&amp;"),
                new HtmlString($"Idx={m?.PageIndex ?? 0}&amp;"),
                new HtmlString($"filter={m?.CurrentFilter}\">"),
                new HtmlString($"{name}</a>")
            };
            return l;
        }
        private static string? pageName(IPageModel? m) => m?.GetType()?.Name?.Replace("Page", "");
    }
}
