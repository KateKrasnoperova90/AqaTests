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

public class CategoryRepository : ICategoryRepository
{
    private readonly string connection;
    public CategoryRepository(string connection)
    {
        this.connection = connection;
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoryAsync()
    {
        using var bd = new SqliteConnection(connection);
        var categories = await bd.QueryAsync<CategoryDTO>("SELECT * FROM Categories");
        return categories;
    }
}