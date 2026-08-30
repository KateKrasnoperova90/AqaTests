using System;
using System.Collections.Generic;
using System.Text;
using AqaTest;
using AqaTest.DTO.DapperDTO;

namespace AqaTest.Interfaces.DapperInterfaces
{
    public interface IOrderRepository
    {
        Task<OrderDTO> GetOrderByUserIdAsync(int userId);
    }
}