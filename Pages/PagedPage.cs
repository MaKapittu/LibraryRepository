using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Domain;
using HW_01_Eurich_Kapitonova.Facade;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;

namespace HW_01_Eurich_Kapitonova.Pages
{
    public abstract class PagedPage<TView, TEntity, TRepo> : OrderedPage<TView, TEntity, TRepo>,
        IPageModel, IIndexModel<TView>
        where TView : UniqueView, new()
        where TEntity : UniqueEntity
        where TRepo : IPagedRepo<TEntity>
    {
        protected PagedPage(TRepo r) : base(r) { }

        public int PageIndex
        {
            get => repo.PageIndex;
            set => repo.PageIndex = value;
        }
        public int TotalPages => repo.TotalPages;
        public bool HasNextPage => repo.HasNextPage;
        public bool HasPreviousPage => repo.HasPreviousPage;

        protected override void setAttributes(int Idx, string? filter, string? order)
        {
            PageIndex = Idx;
            CurrentFilter = filter;
            CurrentOrder = order;
        }
        protected override IActionResult redirectToIndex() => RedirectToPage("./Index", "Index",
            new
            {
                pageIndex = PageIndex,
                currentFilter = CurrentFilter,
                sortOrder = CurrentOrder,
            });
        protected override IActionResult redirectToEdit(TView v)
        {
            TempData["Item"] = JsonSerializer.Serialize(v);
            return RedirectToPage("./Edit", "Edit",
            new
            {
                iD = v.ID,
                pageIndex = PageIndex,
                currentFilter = CurrentFilter,
                sortOrder = CurrentOrder
            });
        }
        protected override IActionResult redirectToDelete(string ID)
        {
            TempData["Error"] = "The record you attempted to delete "
                  + "was modified by another user after you selected delete. "
                  + "The delete operation was canceled and the current values in the "
                  + "database have been displayed. If you still want to delete this "
                  + "record, click the Delete button again.";

            return RedirectToPage("./Delete", "Delete",
            new
            {
                ID = ID,
                pageIndex = PageIndex,
                currentFilter = CurrentFilter,
                sortOrder = CurrentOrder
            });
        }
        public virtual string[] IndexColumns => Array.Empty<string>();
        public virtual object? GetValue(string name, TView v)
           => Safe.Run(() =>
           {
               var pi = v?.GetType()?.GetProperty(name);
               return pi?.GetValue(v);
           }, null);
        public string? DisplayName(string name) => Safe.Run(() =>
        {
            var p = typeof(TView).GetProperty(name);
            var a = p?.CustomAttributes?
                .FirstOrDefault(x => x.AttributeType == typeof(DisplayNameAttribute));
            return a?.ConstructorArguments[0].Value?.ToString() ?? name;
        }, name);
    }
}

