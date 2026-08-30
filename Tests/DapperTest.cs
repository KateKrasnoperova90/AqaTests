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
        public async Task Test1GetAllUsers()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUserAsync();
            users.Should().HaveCount(15);
        }

        [Test]
        public async Task Test2GetUserByIdAsync()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var userById = await repo.GetUserByIdAsync(12);
            userById.Should().NotBeNull();
            userById.Id.Should().Be(12);
        }

        [Test]
        public async Task Test3GetUserByNameAsync()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var userByName = await repo.GetUserByNameAsync("Мария", "Павлова");
            userByName.Should().NotBeNull();
            userByName.FirstName.Should().Be("Мария");
        }

        [Test]
        public async Task Test4GetAddresByUserId()
        {
            var repo = p.Provider.GetService<IAddressRepository>();
            var adressByUserID = await repo.GetAddressByUserIdAsync(1);
            adressByUserID.Should().NotBeNull();
            adressByUserID.UserId.Should().Be(1);
        }

        [Test]
        public async Task Test5GetAllCategories()
        {
            var repo = p.Provider.GetService<ICategoryRepository>();
            var categories = await repo.GetCategoryAsync();
            categories.Should().HaveCount(6);
        }

        [Test]
        public async Task Test6GetProductByIdAsync()
        {
            var repo = p.Provider.GetService<IProductRepository>();
            var product = await repo.GetProductByIdAsync(3);
            product.Should().NotBeNull();
            product.Id.Should().Be(3);
            product.Name.Should().Be("Xiaomi Redmi Note 13");
            product.Description.Should().Be("Бюджетный смартфон Xiaomi");
            product.Price.Should().Be(24990);
            product.Stock.Should().Be(35);
            product.CategoryId.Should().Be(1);
        }

        [Test]
        public async Task Test7GetProductByIdAsync()
        {
            var orderRepo = p.Provider.GetService<IOrderRepository>();
            var order = await orderRepo.GetOrderByUserIdAsync(11);
            order.Should().NotBeNull();

            var orderItemRepo = p.Provider.GetService<IOrderItemRepository>();
            var items = await orderItemRepo.GetOrderItemByOrderId((int)order.Id);
            items.Should().HaveCount(2);

            var productRepo = p.Provider.GetService<IProductRepository>();
            var productNames = new List<string>();
            foreach (var item in items)
            {
                var product = await productRepo.GetProductByIdAsync((int)item.ProductId);
                product.Should().NotBeNull();
                TestContext.WriteLine($"Product: {product.Name}, Quantity: {item.Quantity}, UnitPrice: {item.UnitPrice}");
                productNames.Add(product.Name);
            }
            productNames.Should().BeEquivalentTo(new[] { "AirPods Pro 2", "Anker PowerBank" });
        }
    }
}