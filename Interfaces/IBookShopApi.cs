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
        Task<UserBookResponseDTO> CreateUserAsync([Body] UserBodyDTO user);

        [Post("/Account/v1/GenerateToken")]
        Task<TokenResponseDTO> GetUserTokenAsync([Body] UserBodyDTO user);

        [Post("/Account/v1/Login")]
        Task<LoginUserResponseDTO> GetUserIdAsync([Body] UserBodyDTO user);

        [Get("/BookStore/v1/Books")]
        Task<BookListDTO> GetBookListAsync();

        [Get("/BookStore/v1/Book")]
        Task<BookListDTO> GetBookByIdAsync([Query] string ISBN);

        [Post("/BookStore/v1/Books")]
        Task<UserBookResponseDTO> AddBookToCollectionAsync([Body] AddCollectionBooksOfUserDTO request,
            [Header("Authorization")] string token);
        
        [Delete("/BookStore/v1/Book")]
        Task<DeleteBookResponseDTO> DeleteBookAsync([Body] DeleteBookRequestDTO request,
            [Header("Authorization")] string token);
    }
}