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
}