using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using Refit;
using Microsoft.Extensions.DependencyInjection;
using NUnit;
using System.Net;
using FluentAssertions;
using FluentAssertions.Execution;


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
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]

        public async Task TestRefit2()
        {
            var response = await api.GetUserAsync(2);
            response.Content.Data.Id.Should().Be(2);
        }

        [Test]
        public async Task TestRefit3()
        {
            var request = new CreateUserRequestDTO
            {
                Name = "Kate Krasnoperova",
                Job = "Software Enterprise"
            };
            var response = await api.CreateUserAsync(request);
            
            using (new AssertionScope())
            {
                response.Name.Should().Be("Kate Krasnoperova");
                response.Job.Should().Be("Software Enterprise");
            }
        }

        [Test]
        public async Task TestRefit4()
        {
            var request = new CreateUserRequestDTO
            {
                Name = "Kate",
                Job = "Apple"
            };
            var response = await api.UpdateUserAsync(2, request);
            
            using (new AssertionScope())
            {
                response.Name.Should().Be("Kate");
                response.Job.Should().Be("Apple");
            }
        }

        [Test]
        public async Task TestRefit5()
        {
            var response = await api.DeleteUserAsync(2);
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
