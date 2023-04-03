using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Domain;
using HW_01_Eurich_Kapitonova.Facade;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;

namespace HW_01_Eurich_Kapitonova.Pages
{
    public abstract class CrudPage<TView, TEntity, TRepo> : BasePage<TView, TEntity, TRepo>
        where TView : UniqueView, new()
        where TEntity : UniqueEntity
        where TRepo : ICrudRepo<TEntity>
    {
        protected CrudPage(TRepo r) : base(r) { }
        protected override IActionResult getCreate() => Page();
        protected virtual async Task<IActionResult> getItemPage(string ID)
        {
            Item = await getItem(ID);
            return itemPage();
        }
        protected IActionResult itemPage() => Item == null ? NotFound() : Page();
        protected override async Task<IActionResult> getDetailsAsync(string id) => await getItemPage(id);
        protected override async Task<IActionResult> getDeleteAsync(string ID)
        {
            ErrorMessage = TempData["Error"] as string;
            return await getItemPage(ID);
        }
        protected override async Task<IActionResult> getEditAsync(string ID)
        {
            var s = TempData["Item"] as string;
            TView? v = null;
            if (s is not null) v = JsonSerializer.Deserialize<TView>(s);
            if (v is null) return await getItemPage(ID);
            return await getEditAsync(v);
        }
        protected async Task<IActionResult> getEditAsync(TView v)
        {
            Item = await getItem(v.ID);
            ModelState.AddModelError(string.Empty,
                "The record you attempted to edit was modified by another user after you. The "
                + "edit operation was canceled and the current values in the database "
                + "have been displayed. If you still want to edit this record, click "
                + "the Save button again.");
            foreach (var p in Item.GetType().GetProperties())
            {
                var n = p.Name;
                var currentValue = p.GetValue(Item)?.ToString();
                var clientValue = v?.GetType()?.GetProperty(n)?.GetValue(v)?.ToString();
                if (currentValue != clientValue)
                    ModelState.AddModelError(
                        $"{nameof(Item)}.{n}",
                        $"Your value: {clientValue}");
            }
            return itemPage();
        }
        protected override async Task<IActionResult> postCreateAsync()
        {
            if (!ModelState.IsValid) return Page();
            _ = await repo.AddAsync(toObject(Item));
            return redirectToIndex();
        }
        protected override async Task<IActionResult> postDeleteAsync(string ID, string? token = null)
        {
            if (ID == null) return redirectToIndex();
            var o = await getItem(ID);
            if (ConcurrencyToken.ToStr(o.Token) == ConcurrencyToken.ToStr()) return redirectToIndex();
            var oToken = ConcurrencyToken.ToStr(o.Token);
            if (oToken != token) return redirectToDelete(ID);

            _ = await repo.DeleteAsync(ID);
            return redirectToIndex();
        }
        protected override async Task<IActionResult> postEditAsync()
        {
            var o = repo.Get(Item.ID);
            if (ConcurrencyToken.ToStr(o.Token) == ConcurrencyToken.ToStr())
            {
                ModelState.AddModelError(string.Empty, "Unable to save. The item was deleted by another user.");
                return Page();
            }
            var oToken = ConcurrencyToken.ToStr(o.Token);
            var itemToken = ConcurrencyToken.ToStr(Item.Token);
            if (oToken != itemToken) return redirectToEdit(Item);

            if (!ModelState.IsValid) return Page();
            var obj = toObject(Item);
            var updated = await repo.UpdateAsync(obj);
            return !updated ? NotFound() : redirectToIndex();
        }
        protected override async Task<IActionResult> getIndexAsync()
        {
            var list = await repo.GetAsync();
            Items = new List<TView>();
            foreach (var obj in list)
            {
                var v = toView(obj);
                Items.Add(v);
            }
            return Page();
        }
        private async Task<TView> getItem(string ID)
            => toView(await repo.GetAsync(ID));
    }
}
