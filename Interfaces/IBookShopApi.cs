using System;
using System.Collections.Generic;
using System.Text;
using AqaTest;
using Refit;
using AqaTest.DTO.BooksShopDTO;

namespace Interfaces

{
    public interface IBookShopApi
    
    {
        [Post("/Account/v1/User")]
        Task<UserBookResponseDTO> CreateUserAsync([Body] UserCreateBodyDTO user);

        [Post("/Account/v1/GenerateToken")]
        Task<TokenResponseDTO> GetUserTokenAsync([Body] UserCreateBodyDTO user);
    }
}