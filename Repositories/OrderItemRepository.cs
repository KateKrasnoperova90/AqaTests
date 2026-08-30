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

public class OrderItemRepository : IOrderItemRepository
{
    private readonly string connection;
    public OrderItemRepository(string connection)
    {
        this.connection = connection;
    }

    public async Task<List<OrderItemDTO>> GetOrderItemByOrderId(int orderId)
    {
        using var bd = new SqliteConnection(connection);
        var orderItemByOrderId = await bd.QueryAsync<OrderItemDTO>("SELECT * FROM OrderItems WHERE OrderId = @orderId", new {orderId});
        return orderItemByOrderId.ToList();
    }
}