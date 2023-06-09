﻿using HW_01_Eurich_Kapitonova.Facade;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace HW_01_Eurich_Kapitonova.Pages.Extensions
{
    public static class ShowTableHtml
    {
        public static IHtmlContent ShowTable<TModel, TView>(this IHtmlHelper<TModel> h, IList<TView>? items)
                where TModel : IIndexModel<TView> where TView : UniqueView
        {
            var s = htmlStrings(h, items);
            return new HtmlContentBuilder(s);
        }
        private static List<object> htmlStrings<TModel, TView>(IHtmlHelper<TModel> h, IList<TView>? items)
            where TModel : IIndexModel<TView> where TView : UniqueView
        {
            var m = h.ViewData.Model;
            var l = new List<object>
            {
                new HtmlString("<table class=\"table\">"),
                new HtmlString("<thead>"),
                new HtmlString("<tr>")
            };
            foreach (var name in m.IndexColumns)
            {
                l.Add(new HtmlString("<td>"));
                l.Add(h.MyTabHdr(m.DisplayName(name)));
                l.Add(new HtmlString("</td>"));
            }
            l.Add(new HtmlString("<th></th>"));
            l.Add(new HtmlString("</tr>"));
            l.Add(new HtmlString("</thead>"));
            l.Add(new HtmlString("<tbody>"));
            foreach (var item in items ?? new List<TView>())
            {
                l.Add(new HtmlString("<tr>"));
                foreach (var name in m.IndexColumns)
                {
                    l.Add(new HtmlString("<td>"));
                    l.Add(h.Raw(m.GetValue(name, item)));
                    l.Add(new HtmlString("</td>"));
                }
                l.Add(new HtmlString("<td>"));
                l.Add(h.ItemButtons(item.ID));
                l.Add(new HtmlString("</td>"));
                l.Add(new HtmlString("</tr>"));
            }
            l.Add(new HtmlString("</tbody>"));
            l.Add(new HtmlString("</table>"));
            return l;
        }
    }
}
