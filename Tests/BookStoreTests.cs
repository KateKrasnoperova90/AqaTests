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

        [Test]

        public async Task CreateUser()
        {
            var user = new UserCreateBodyDTO("TestUser123123", "StrongPass43533!");
            var response = await api.CreateUserAsync(user); // "8644ba91-dc03-4062-83c1-903a1efed8f5"
            response.UserId.Should().NotBeNullOrEmpty();
        }

        [Test]

        public async Task GetUserToken()
        {
            var user = new UserCreateBodyDTO("TestUser123123", "StrongPass43533!");
            var response = await api.GetUserTokenAsync(user);
            response.Token.Should().NotBeNullOrEmpty(); // "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6IlRlc3RVc2VyMTIzMTIzIiwicGFzc3dvcmQiOiJTdHJvbmdQYXNzNDM1MzMhIiwiaWF0IjoxNzg5MzI2OTYxfQ.gpnBRCIjpj8tMD69ywYUZ1dnkCzjF6cctmcMyS6ru-Q"
        }
    }
}