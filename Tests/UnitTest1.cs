namespace AqaTest;

using System.Text.Json;
using System.Net.Http.Json;

public class UnitTest1
{
    private static HttpClient client;

    [OneTimeSetUp]
    public void Setup()
    {
        client = new HttpClient
        {
            BaseAddress = new Uri("https://reqres.in/api/"),
        };
        client.DefaultRequestHeaders.Add("x-api-key", "free_user_3I0Umsgap4hYjYftWSKlwjRaV6G");
    }

    [Test]
    public async Task Test1()
    {
        using HttpResponseMessage response = await client.GetAsync("users/2");
        response.EnsureSuccessStatusCode();
    }   

    public async Task Test2()
    {
        using HttpResponseMessage response = await client.GetAsync("users/2");
    response.EnsureSuccessStatusCode();
        string jsonGet = await response.Content.ReadAsStringAsync();
        UserResponseDTO userResponse = JsonSerializer.Deserialize<UserResponseDTO>(jsonGet);
        UserDataDTO user = userResponse.Data;
    }

    public async Task Test3()
    {
        var newUser = new CreateUserRequestDTO
        {
            Name = "KateKrasnoperova",
            Job = "TeslaJob"
        };

        using HttpResponseMessage response = await client.PostAsJsonAsync("users", newUser);
        response.EnsureSuccessStatusCode();
        string jsonPost = await response.Content.ReadAsStringAsync();
        CreateUserResponseDTO createdUser = JsonSerializer.Deserialize<CreateUserResponseDTO>(jsonPost);
    }


    public async Task Test4()
    {
        var updatedUser = new CreateUserRequestDTO
        {
            Name = "KateKrasnoperova",
            Job = "GoogleJob"
        };

        using HttpResponseMessage response = await client.PutAsJsonAsync("users/2", updatedUser);
        response.EnsureSuccessStatusCode();
        string jsonPut = await response.Content.ReadAsStringAsync();
        UpdateUserResponseDTO updatedUserResponse = JsonSerializer.Deserialize<UpdateUserResponseDTO>(jsonPut);
    }

    public async Task Test5()
    {
        using HttpResponseMessage response = await client.DeleteAsync("users/2");
        response.EnsureSuccessStatusCode();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        client.Dispose();
    }
}
