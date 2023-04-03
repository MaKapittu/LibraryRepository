using HW_01_Eurich_Kapitonova.Aids;
using HW_01_Eurich_Kapitonova.Data.Party;
using HW_01_Eurich_Kapitonova.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;

namespace HW_01_Eurich_Kapitonova.Tests.Soft
{
    [TestClass]
    public class DetailsPagesTests : HostTests
    {
        [TestMethod]
        public async Task GetCountriesDetailedPageTest()
        {
            int cnt;
            var ID = GetRandom.String();
            var d = addRandomItems<ICountryRepo, Country, CountryData>(out cnt, x => new Country(x), ID);
            isNotNull(d);
            isNotNull(d.Name);
            isNotNull(d.Description);
            var page = await client.GetAsync($"/Countries/Details?handler=Details&id={ID}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Details</h1>"));
            isTrue(html.Contains(ID));
            isTrue(html.Contains(d.Code));
            isTrue(html.Contains(d.Name));
            isTrue(html.Contains(d.Description));
        }
        [TestMethod]
        public async Task GetCurrenciesDetailedPageTest()
        {
            int cnt;
            var ID = GetRandom.String();
            var d = addRandomItems<ICurrencyRepo, Currency, CurrencyData>(out cnt, x => new Currency(x), ID);
            isNotNull(d);
            isNotNull(d.Name);
            isNotNull(d.Description);
            var page = await client.GetAsync($"/Currencies/Details?handler=Details&id={ID}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Details</h1>"));
            isTrue(html.Contains(ID));
            isTrue(html.Contains(d.Code));
            isTrue(html.Contains(d.Name));
            isTrue(html.Contains(d.Description));
        }
        [TestMethod]
        public async Task GetAddressesDetailedPageTest()
        {
            int cnt;
            var ID = GetRandom.String();
            var d = addRandomItems<IAddressRepo, Address, AddressData>(out cnt, x => new Address(x), ID);
            var page = await client.GetAsync($"/Addresses/Details?handler=Details&id={ID}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Log in</h1>"));
        }
        [TestMethod]
        public async Task GetBooksDetailedPageTest()
        {
            int cnt;
            var ID = GetRandom.String();
            var d = addRandomItems<IBookRepo, Book, BookData>(out cnt, x => new Book(x), ID);
            isNotNull(d);
            isNotNull(d.BookName);
            isNotNull(d.BooksLeft);
            isNotNull(d.PhotoPath);
            isNotNull(d.TotalNumberOfBooks);
            var page = await client.GetAsync($"/Books/Details?handler=Details&id={ID}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Details</h1>"));
            isTrue(html.Contains(ID));
            isTrue(html.Contains(d.BookName));
            isTrue(html.Contains(d.BooksLeft.ToString()));
            isTrue(html.Contains(d.TotalNumberOfBooks.ToString()));
        }

        [TestMethod]
        public async Task GetLibrariansDetailedPageTest()
        {
            int cnt;
            var ID = GetRandom.String();
            var d = addRandomItems<ILibrarianRepo, Librarian, LibrarianData>(out cnt, x => new Librarian(x), ID);
            isNotNull(d);
            isNotNull(d.FirstName);
            isNotNull(d.LastName);
            isNotNull(d.Position);
            var page = await client.GetAsync($"/Librarians/Details?handler=Details&id={ID}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Details</h1>"));
            isTrue(html.Contains(ID));
            isTrue(html.Contains(d.FirstName));
            isTrue(html.Contains(d.LastName));
            isTrue(html.Contains(d.Position));
        }
        [TestMethod]
        public async Task GetPersonsDetailedPageTest()
        {
            int cnt;
            var ID = GetRandom.String();
            var d = addRandomItems<IPersonRepo, Person, PersonData>(out cnt, x => new Person(x), ID);
            isNotNull(d);
            isNotNull(d.FirstName);
            isNotNull(d.LastName);
            isNotNull(d.DateOfBirth);
            isNotNull(d.RentedBooksAmount);
            isNotNull(d.Gender);
            var page = await client.GetAsync($"/Persons/Details?handler=Details&id={ID}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Details</h1>"));
            isTrue(html.Contains(ID));
            isTrue(html.Contains(d.FirstName));
            isTrue(html.Contains(d.LastName));
            isTrue(html.Contains(d.DateOfBirth.ToString()));
            isTrue(html.Contains(d.RentedBooksAmount.ToString()));
            isTrue(html.Contains(d.Gender.ToString()));
        }
    }
}

