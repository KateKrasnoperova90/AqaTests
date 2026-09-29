using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;
using Refit;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using FluentAssertions;
using FluentAssertions.Execution;
using AqaTest.DTO.PetsDataDTO;
using Helpers;


namespace AqaTest.Tests

{
    public class PetsTests
    
    {
        private IPetsApi api;

        [OneTimeSetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (msg, cert, chain, errors) => true
            };

            services.AddRefitClient<IPetsApi>()
                .ConfigureHttpClient(c => 
                {
                    c.BaseAddress = new Uri("https://api.petstoreapi.com/v1");
                })
                .ConfigurePrimaryHttpMessageHandler(() => handler);

            var provider = services.BuildServiceProvider();
            api = provider.GetRequiredService<IPetsApi>();
        }

        [Test]

        public async Task GetAllPets()
        {
            var response = await api.GetAllPetsAsync();
            response.Data.Should().HaveCount(20);
        }

        [Test]

        public async Task GetPetByRandomId()
        {
            var response = await api.GetAllPetsAsync();
            var randomPetID = RandomizerHelper.GetRandomNumber(response.Data);
            var petIdResponse = await api.GetPetByIdAsync(randomPetID.Id);
            petIdResponse.Should().BeEquivalentTo(randomPetID);
        }

        [Test]

        public async Task GetAllPetsByFilterAgeMinAndLimit()
        {
            var pets = await api.GetAllPetsByFilterAgeMinAndLimitAsync(6, 10);
            var result = pets.Data;
            foreach (var pet in result)
            {
                pet.AgeMonths.Should().BeGreaterThanOrEqualTo(6);
            }

            bool res = result.All(pets => pets.AgeMonths >= 6); // xерез LINQ
            res.Should().BeTrue();
        }
    }
}