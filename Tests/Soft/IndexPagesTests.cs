using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;

namespace HW_01_Eurich_Kapitonova.Tests.Soft;

[TestClass]
public class IndexPagesTests : HostTests
{

    [TestMethod]
    public async Task GetCountriesIndexPageTest()
    {
        int cnt;
        var d = addRandomItems<ICountryRepo, Country, CountryData>(out cnt, x => new Country(x));
        var page = await client.GetAsync("/Countries?handler=Index");
        areEqual(HttpStatusCode.OK, page.StatusCode);
        var html = await page.Content.ReadAsStringAsync();
        isTrue(html.Contains("<h1>Countries</h1>"));
    }
    [TestMethod]
    public async Task GetCurrenciesIndexPageTest()
    {
        int cnt;
        var d = addRandomItems<ICurrencyRepo, Currency, CurrencyData>(out cnt, x => new Currency(x));
        var page = await client.GetAsync("/Currencies?handler=Index");
        areEqual(HttpStatusCode.OK, page.StatusCode);
        var html = await page.Content.ReadAsStringAsync();
        isTrue(html.Contains("<h1>Currencies</h1>"));
    }
    [TestMethod]
    public async Task GetPersonsIndexPageTest()
    {
        var page = await client.GetAsync("/Persons?handler=Index");
        areEqual(HttpStatusCode.OK, page.StatusCode);
        var html = await page.Content.ReadAsStringAsync();
        isTrue(html.Contains("<h1>Persons</h1>"));
    }
    [TestMethod]
    public async Task GetAddressesIndexPageTest()
    {
        int cnt;
        var d = addRandomItems<IAddressRepo, Address, AddressData>(out cnt, x => new Address(x));
        var page = await client.GetAsync("/Addresses?handler=Index");
        areEqual(HttpStatusCode.OK, page.StatusCode);
        var html = await page.Content.ReadAsStringAsync();
        isTrue(html.Contains("<h1>Log in</h1>"));
    }
    [TestMethod]
    public async Task GetLibrariansIndexPageTest()
    {
        int cnt;
        var d = addRandomItems<ILibrarianRepo, Librarian, LibrarianData>(out cnt, x => new Librarian(x));
        var page = await client.GetAsync("/Librarians?handler=Index");
        areEqual(HttpStatusCode.OK, page.StatusCode);
        var html = await page.Content.ReadAsStringAsync();
        isTrue(html.Contains("<h1>Librarians</h1>"));
    }
    [TestMethod]
    public async Task GetBooksIndexPageTest()
    {
        int cnt;
        var d = addRandomItems<IBookRepo, Book, BookData>(out cnt, x => new Book(x));
        var page = await client.GetAsync("/Books?handler=Index");
        areEqual(HttpStatusCode.OK, page.StatusCode);
        var html = await page.Content.ReadAsStringAsync();
        isTrue(html.Contains("<h1>Books</h1>"));
    }

}
