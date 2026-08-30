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
}