using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using AqaTest.Interfaces.DapperInterfaces;
using AqaTest.DTO.DapperDTO;
using AqaTest.Repositories;

namespace AqaTest.Repositories;

public class AddressRepository : IAddressRepository

{
    private readonly string connection;
    public AddressRepository(string connection)
    {
        this.connection = connection;
    }

    public async Task<AddressDTO> GetAddressByUserIdAsync(int userId)
    {
        using var bd = new SqliteConnection(connection);
        var addressByUserId = await bd.QueryFirstOrDefaultAsync<AddressDTO>("SELECT * FROM Addresses WHERE UserId = @userId", new {userId});
        return addressByUserId;
    }

    public async Task<IEnumerable<string>> GetCitiesByCategoryNameAsync(string categoryName)
    {
        using var bd = new SqliteConnection(connection);
        var cities = await bd.QueryAsync<string>("SELECT a.City FROM Categories c JOIN Products p ON p.CategoryId = c.Id JOIN OrderItems oi ON oi.ProductId = p.Id JOIN Orders o ON o.Id = oi.OrderId JOIN Addresses a ON a.UserId = o.UserId WHERE c.Name = @categoryName", new {categoryName});
        return cities;
    }
}