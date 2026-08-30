using System;
using System.Collections.Generic;
using System.Text;
using AqaTest;
using AqaTest.DTO.DapperDTO;

namespace AqaTest.Interfaces.DapperInterfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> GetUserAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> GetUserByNameAsync(string firstName, string lastName);
    }
}