using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using AqaTest.Preconditions;
using AqaTest.DTO.DapperDTO;
using AqaTest.Interfaces.DapperInterfaces;
using FluentAssertions;
using FluentAssertions.Execution;

namespace AqaTest.Tests
{
    public class DapperTest
    {
        private readonly DataBasePreconditions p = new DataBasePreconditions();
        
        [Test]
        public async Task TestGetAllUsers()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUserAsync();
            users.Should().HaveCount(15);
        }

        [Test]
        public async Task TestGetUserByIdAsync()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var userById = await repo.GetUserByIdAsync(12);
            userById.Should().NotBeNull();
            userById.Id.Should().Be(12);
        }

        [Test]
        public async Task TestGetUserByNameAsync()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var userByName = await repo.GetUserByNameAsync("Мария", "Павлова");
            userByName.Should().NotBeNull();
            userByName.FirstName.Should().Be("Мария");
        }

        [Test]
        public async Task TestGetAddresByUserId()
        {
            var repo = p.Provider.GetService<IAddressRepository>();
            var adressByUserID = await repo.GetAddressByUserIdAsync(1);
            adressByUserID.Should().NotBeNull();
            adressByUserID.UserId.Should().Be(1);
        }
    }
}