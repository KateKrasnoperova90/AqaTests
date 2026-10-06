using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using Refit;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using FluentAssertions;
using FluentAssertions.Execution;
using AqaTest.DTO.BooksShopDTO;
using Helpers;


namespace AqaTest.Tests

{
    public class BookStoreTests
    
    {
        private IBookShopApi api;

        [OneTimeSetUp]
        public void Setup()
        {
            var services = new ServiceCollection();

            services
                .AddRefitClient<IBookShopApi>()
                .ConfigureHttpClient(c => 
                {
                    c.BaseAddress = new Uri("https://demoqa.com");
                });

            var provider = services.BuildServiceProvider();
            api = provider.GetRequiredService<IBookShopApi>();
        }

        // [Test]

        // public async Task CreateUser()
        // {
        //     var user = new UserBodyDTO("TestUser123120", "StrongPass43539!");
        //     var response = await api.CreateUserAsync(user); // "8644ba91-dc03-4062-83c1-903a1efed8f5"
        //     response.UserId.Should().NotBeNullOrEmpty();
        // }

        [Test]

        public async Task GetUserToken()
        {
            var user = new UserBodyDTO("TestUser123120", "StrongPass43539!");
            var response = await api.GetUserTokenAsync(user);
            response.Token.Should().NotBeNullOrEmpty(); // "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6IlRlc3RVc2VyMTIzMTIzIiwicGFzc3dvcmQiOiJTdHJvbmdQYXNzNDM1MzMhIiwiaWF0IjoxNzg5MzI2OTYxfQ.gpnBRCIjpj8tMD69ywYUZ1dnkCzjF6cctmcMyS6ru-Q"
        }

        [Test]

        public async Task GetUserById()
        {
            var user = new UserBodyDTO("TestUser123120", "StrongPass43539!");
            var response = await api.GetUserIdAsync(user);
            response.UserId.Should().NotBeNullOrEmpty(); 
        }

        [Test]

        public async Task GetBookList()
        {
            var response = await api.GetBookListAsync();
            response.Books.Should().NotBeNullOrEmpty();
            response.Books.Should().HaveCount(8);
        }

        [Test]

        public async Task GetBookById()
        {
            var response = await api.GetBookByIdAsync("9781449337711");
            response.Should().NotBeNull();
        }

        [Test]

        public async Task AddBookToCollection()
        {
            var token = await GetTokenAsync();
            var userId = await GetUserIdAsync();
            var listOfBooks = await api.GetBookListAsync();
            var isbnRandom = RandomizerHelper.GetRandomNumber(listOfBooks.Books).Isbn;
            var request = new AddCollectionBooksOfUserDTO
            (
                userId,
                new List<CollectionsOfIsbnsDTO>
                {
                    new CollectionsOfIsbnsDTO (isbnRandom)
                }
            );
            var response = await api.AddBookToCollectionAsync(request, token);
            response.Should().NotBeNull();
        }

         [Test]

        public async Task AddBookToCollectionNegative()
        {
            var token = await GetTokenAsync();
            var userId = await GetUserIdAsync();
            var request = new AddCollectionBooksOfUserDTO
            (
                userId,
                new List<CollectionsOfIsbnsDTO>
                {
                    new CollectionsOfIsbnsDTO ("INVALID_ISBN")
                }
            );
            Func<Task> act = async () => await api.AddBookToCollectionAsync(request, token);
            await act.Should().ThrowAsync<ApiException>().Where(p => p.StatusCode == HttpStatusCode.BadRequest);
        }


        [Test]
        public async Task DeleteBook()
        {
            var token = await GetTokenAsync();
            var rightToken = $"Bearer {token}";
            var userId = await GetUserIdAsync();
            var request = new DeleteBookRequestDTO
            (
                "9781449337711",
                userId
            );
            var response = await api.DeleteBookAsync(request, rightToken);
            response.Should().BeNull();
        }

        [Test]

        public async Task AddBookToCollectionTokenInvalid()
        {
            var userId = await GetUserIdAsync();
            var listOfBooks = await api.GetBookListAsync();
            var isbnRandom = RandomizerHelper.GetRandomNumber(listOfBooks.Books).Isbn;
            var request = new AddCollectionBooksOfUserDTO
            (
                userId,
                new List<CollectionsOfIsbnsDTO>
                {
                    new CollectionsOfIsbnsDTO (isbnRandom)
                }
            );

            Func<Task> act = async () => await api.AddBookToCollectionAsync(request, token: null); // метод делигат, который будет вызван в тесте

            act.Should().ThrowAsync<ApiException>().Where(p => p.StatusCode == HttpStatusCode.Unauthorized);
        }

        private async Task<string> GetTokenAsync()
        {
            var credentials = new UserBodyDTO("TestUser123120", "StrongPass43539!");
            var token = await api.GetUserTokenAsync(credentials);
            return token.Token;
        }
        
         private async Task<string> GetUserIdAsync() 
        {
            var credentials = new UserBodyDTO("TestUser123120", "StrongPass43539!");
            var user = await api.GetUserIdAsync(credentials);
            return user.UserId;
        }
    }
}