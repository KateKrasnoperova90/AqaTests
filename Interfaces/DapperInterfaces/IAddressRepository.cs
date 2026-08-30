using System;
using System.Collections.Generic;
using System.Text;
using AqaTest;
using AqaTest.DTO.DapperDTO;

namespace AqaTest.Interfaces.DapperInterfaces
{
    public interface IAddressRepository
    {
        Task<AddressDTO> GetAddressByUserIdAsync(int userId);
    }
}