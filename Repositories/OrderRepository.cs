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

public class OrderRepository : IOrderRepository

{
    private readonly string connection;
    public OrderRepository(string connection)
    {
        this.connection = connection;
    }

    public async Task<OrderDTO> GetOrderByUserIdAsync(int userId)
    {
        using var bd = new SqliteConnection(connection);
        var orderByUserId = await bd.QueryFirstOrDefaultAsync<OrderDTO>("SELECT * FROM Orders WHERE UserId = @userId", new {userId});
        return orderByUserId;
    }

    public async Task<IEnumerable<long>> GetUserIdsByCategoryNameAsync(string categoryName)
    {
        using var bd = new SqliteConnection(connection);
        var userIds = await bd.QueryAsync<long>("SELECT DISTINCT o.UserId FROM Orders o JOIN OrderItems oi ON oi.OrderId = o.Id JOIN Products p ON p.Id = oi.ProductId JOIN Categories c ON c.Id = p.CategoryId WHERE c.Name = @categoryName", new {categoryName});
        return userIds;
    }
}