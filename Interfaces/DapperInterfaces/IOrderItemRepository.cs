using System;
using System.Collections.Generic;
using System.Text;
using AqaTest;
using AqaTest.DTO.DapperDTO;

namespace AqaTest.Interfaces.DapperInterfaces
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItemDTO>> GetOrderItemByOrderId(int orderId);
    }
}