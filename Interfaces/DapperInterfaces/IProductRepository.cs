using System;
using System.Collections.Generic;
using System.Text;
using AqaTest;
using AqaTest.DTO.DapperDTO;

namespace AqaTest.Interfaces.DapperInterfaces
{
    public interface IProductRepository
    {
        Task<ProductDTO> GetProductByIdAsync(int id);
    }
}