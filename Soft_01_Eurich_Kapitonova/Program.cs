using HW_01_Eurich_Kapitonova.Domain;
using HW_01_Eurich_Kapitonova.Domain.Party;
using HW_01_Eurich_Kapitonova.Infra;
using HW_01_Eurich_Kapitonova.Infra.Initializers;
using HW_01_Eurich_Kapitonova.Infra.Party;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Soft_01_Eurich_Kapitonova.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<LibraryDb>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages(o =>
{
    o.Conventions.AuthorizePage("/Countries/Create");
    o.Conventions.AuthorizePage("/Countries/Delete");
    o.Conventions.AuthorizePage("/Countries/Edit");
    o.Conventions.AuthorizePage("/Currencies/Create");
    o.Conventions.AuthorizePage("/Currencies/Delete");
    o.Conventions.AuthorizePage("/Currencies/Edit");
    o.Conventions.AuthorizePage("/Books/Edit");
    o.Conventions.AuthorizePage("/Books/Delete");

});
builder.Services.AddTransient<IPersonRepo, PersonsRepo>();
builder.Services.AddTransient<IBookRepo, BooksRepo>();
builder.Services.AddTransient<ILibrarianRepo, LibrariansRepo>();
builder.Services.AddTransient<IAddressRepo, AddressesRepo>();
builder.Services.AddTransient<ICurrencyRepo, CurrenciesRepo>();
builder.Services.AddTransient<ICountryRepo, CountriesRepo>();
builder.Services.AddTransient<ICountryCurrencyRepo, CountryCurrenciesRepo>();
builder.Services.AddTransient<IPersonAddressRepo, PersonAddressesRepo>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseMigrationsEndPoint();
}
else
{
    _ = app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    _ = app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    GetRepo.SetService(app.Services);
    var db = scope.ServiceProvider.GetService<LibraryDb>();
    _ = (db?.Database?.EnsureCreated());
    LibraryDbInitializer.Init(db);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
