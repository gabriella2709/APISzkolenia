using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;

namespace API.Tests
{
    public class ControllersTests
    {
        [Fact]
        public void GetSzkolenia_ReturnsOkResult_WithListOfSzkolenia()
        {
            // Arrange
            var controller = new SzkoleniaController(new TestWebHostEnvironment());

            // Act
            var result = controller.GetSzkolenia() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Szkolenia>>(result.Value);
        }

        [Fact]
        public void AddSzkolenie_ReturnsOkResult_AfterAddingSzkolenie()
        {
            // Arrange
            var controller = new SzkoleniaController(new TestWebHostEnvironment());
            var szkolenie = new Szkolenia {Tytul = "Test Szkolenie", Opis = "Test Opis" };

            // Act
            var result = controller.AddSzkolenie(szkolenie) as OkResult;
            var szkolenia = controller.GetSzkolenia() as OkObjectResult;
            var SzkoleniaList = szkolenia.Value as List<Szkolenia>;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(szkolenia);
            Assert.Contains(SzkoleniaList, b => b.Tytul == szkolenie.Tytul && b.Opis == szkolenie.Opis);
        }





        [Fact]
        public void GetZapisy_ReturnsOkResult_WithListOfZapisySzkolenia()
        {
            // Arrange
            var controller = new ZapisyController(new TestWebHostEnvironment());

            // Act
            var result = controller.GetZapisy() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Zapisy>>(result.Value);
        }

        [Fact]
        public void AddZapisy_ReturnsOkResult_AfterAddingZapisySzkolenia()
        {
            // Arrange
            var controller = new ZapisyController(new TestWebHostEnvironment());
            var szkolenie = new Zapisy { Tytul = "Test Szkolenie", Imie = "Test Imie", Nazwisko = "Test Nazwisko" };

            // Act
            var result = controller.AddZapis(szkolenie) as OkResult;
            var szkolenia = controller.GetZapisy() as OkObjectResult;
            var SzkoleniaList = szkolenia.Value as List<Zapisy>;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(szkolenia);
            Assert.Contains(SzkoleniaList, b => b.Tytul == szkolenie.Tytul && b.Imie == szkolenie.Imie && b.Nazwisko == szkolenie.Nazwisko);
        }

        // Test implementation of IWebHostEnvironment for testing purposes
        private class TestWebHostEnvironment : IWebHostEnvironment
        {
            public string EnvironmentName { get; set; }
            public string ApplicationName { get; set; }
            public string WebRootPath { get; set; }
            public IFileProvider WebRootFileProvider { get; set; }
            public string ContentRootPath { get; set; }
            public IFileProvider ContentRootFileProvider { get; set; }

            public TestWebHostEnvironment()
            {
                ContentRootPath = Directory.GetCurrentDirectory(); // Set current directory as content root path
            }
        }
    }
}
