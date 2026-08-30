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

public class UserRepository : IUserRepository
{
    private readonly string connection;
    public UserRepository(string connection)
    {
        this.connection = connection;
    }

    public async Task<IEnumerable<UserDTO>> GetUserAsync()
    {
        using var bd = new SqliteConnection(connection);
        var users = await bd.QueryAsync<UserDTO>("SELECT * FROM Users");
        return users;
    }

    public async Task<UserDTO> GetUserByIdAsync(int id)
    {
        using var bd = new SqliteConnection(connection);
        var userById = await bd.QueryFirstOrDefaultAsync<UserDTO>("SELECT * FROM Users WHERE Id = @id", new {id});
        return userById;
    }

    public async Task<UserDTO> GetUserByNameAsync(string firstName, string lastName)
    {
        using var bd = new SqliteConnection(connection);
        var userByNameAndLastname = await bd.QueryFirstOrDefaultAsync<UserDTO>("SELECT * FROM Users WHERE FirstName = @firstName AND LastName = @lastName", new {firstName, lastName});
        return userByNameAndLastname;
    }
}