using FluentAssertions;
using FluentAssertions.Execution;
using AqaTest.DTO.UsersDataDTO;
using System.Text.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace AqaTest;

public class UsersJsonTests
{
    private DataDTO users;

    [OneTimeSetUp]  
    public void Setup()
    {
       var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "UsersData.json");
       string json = File.ReadAllText(path);

       users = JsonSerializer.Deserialize<DataDTO>(json);    
    }

    [Test]
    public void Test1CheckTotalUsers()
    {
        foreach (var item in users.Data)
        {
           TestContext.WriteLine($"{item.Id} | {item.Username}");
        }

        users.Data.Should().HaveCount(10);
    }

    [Test]
    public void Test2CheckFirstUserName()
    {
        var firstUserName = users.Data.Where(user => user.Id == 1).Select(user => user.Profile.FullName).FirstOrDefault();
        TestContext.WriteLine($"First user fullName: {firstUserName}");
        firstUserName.Should().Be("Alice Johnson");
    }

    [Test]
    public void Test3CheckIdsAreUnique()
    {
        var ids = users.Data.Select(user => user.Id).ToList();
        TestContext.WriteLine($"Total ids: {ids.Count}"); // проверяем количество всех id
        var uniqueIds = ids.Distinct().ToList(); // проверяем количество уникальных id
        TestContext.WriteLine($"Unique ids: {uniqueIds.Count}");
        uniqueIds.Should().HaveCount(ids.Count);
    }

    [Test]
    public void Test4HasPremiumUser()
    {
        var hasPremiumUser = users.Data.Any(user => user.Profile.Tags.Contains("premium"));
        hasPremiumUser.Should().BeTrue();
    }

    [Test]
    public void Test5CityIsNotNull()
    {
        bool allCitiesFilled = users.Data.All(user => !string.IsNullOrWhiteSpace(user.Profile.Address.City));
        allCitiesFilled.Should().BeTrue();
    }

    [Test]
    public void Test6HasUserFromStockholm()
    {
        var hasUserFromStockholm = users.Data.Any(user => user.Profile.Address.City == "Stockholm");
        hasUserFromStockholm.Should().BeTrue();
    }

    [Test]
    public void Test7AgeUsersFrom18To60()
    {
        var allUsersInAgeRange = users.Data.All(user => user.Profile.Age >= 18 && user.Profile.Age <= 60);
        allUsersInAgeRange.Should().BeTrue();
    }

    [Test]
    public void Test8HasAdmin()
    {
        var hasAdmin = users.Data.Any(user => user.Roles.Contains("admin"));
        hasAdmin.Should().BeTrue();
    }

    [Test]
    public void Test9CheckCoordinatesWithinSweden()
    {
        const double minLat = 55.0;
        const double maxLat = 69.5;
        const double minLng = 10.5;
        const double maxLng = 24.5;

        bool allWithinSweden = users.Data.All(user =>
            user.Profile.Address.Geo.Lat >= minLat && user.Profile.Address.Geo.Lat <= maxLat &&
            user.Profile.Address.Geo.Lng >= minLng && user.Profile.Address.Geo.Lng <= maxLng);
        allWithinSweden.Should().BeTrue();
    }

    [Test]
    public void Test10CheckAddressValidation()
    {
    // Регулярное выражение проверяет структуру строки:
    // ^[A-Za-zÀ-ÿ]  — строка НАЧИНАЕТСЯ с буквы
    // .*             — дальше может быть что угодно
    // \d+$           — и строка ЗАКАНЧИВАЕТСЯ на одну или несколько цифр (номер дома)
        var streetPattern = new Regex(@"^[A-Za-zÀ-ÿ].*\d+$");

        bool allStreetsValid = users.Data.All(user => streetPattern.IsMatch(user.Profile.Address.Street));
        allStreetsValid.Should().BeTrue();
    }
}
