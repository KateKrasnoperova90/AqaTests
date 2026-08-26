using System;
using System.Collections.Generic;
using System.Text;
using AqaTest;
using Refit;

namespace Interfaces
{
    [Headers("x-api-key: free_user_3I0Umsgap4hYjYftWSKlwjRaV6G")]
    public interface IUserApi
    {
        [Get("/users/{id}")]
        Task<ApiResponse<UserResponseDTO>> GetUserAsync(int id);

        [Post("/users")]
        Task<CreateUserResponseDTO> CreateUserAsync([Body] CreateUserRequestDTO request);

        [Put("/users/{id}")]
        Task<UpdateUserResponseDTO> UpdateUserAsync(int id, [Body] CreateUserRequestDTO request);

        [Delete("/users/{id}")]
        Task<ApiResponse<string>> DeleteUserAsync(int id);
    }
}
