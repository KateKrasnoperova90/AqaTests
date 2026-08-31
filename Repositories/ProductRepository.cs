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

public class ProductRepository : IProductRepository
{
    private readonly string connection;
    public ProductRepository(string connection)
    {
        this.connection = connection;
    }

    public async Task<ProductDTO> GetProductByIdAsync(int id)
    {
        using var bd = new SqliteConnection(connection);
        var product = await bd.QueryFirstOrDefaultAsync<ProductDTO>("SELECT * FROM Products WHERE Id = @id", new {id});
        return product;
    }
}