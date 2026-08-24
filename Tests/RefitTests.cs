using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using Refit;
using Microsoft.Extensions.DependencyInjection;
using NUnit;
using System.Net;

namespace AqaTest.Tests
{
    public class RefitTests
    {
        private IUserApi api;

        [OneTimeSetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddRefitClient<IUserApi>()
            .ConfigureHttpClient(c => 
            {
                c.BaseAddress = new Uri("https://reqres.in/api");
            });

            var provider = services.BuildServiceProvider();
            api = provider.GetRequiredService<IUserApi>();
        }

        [Test]

        public async Task TestRefit1()
        {
            var response = await api.GetUserAsync(2);
            Assert.That(response.Data.Id, Is.EqualTo(2));
        }

        [Test]
        public async Task TestRefit2()
        {
            var request = new CreateUserRequestDTO
            {
                Name = "Kate Krasnoperova",
                Job = "Software Enterprise"
            };
            var response = await api.CreateUserAsync(request);
            Assert.That(response.Name, Is.EqualTo("Kate Krasnoperova"));
        }

        [Test]
        public async Task TestRefit3()
        {
            var response = await api.DeleteUserAsync(2);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            //Assert.That((int)response.StatusCode, Is.EqualTo(204));
        }
    }
}
