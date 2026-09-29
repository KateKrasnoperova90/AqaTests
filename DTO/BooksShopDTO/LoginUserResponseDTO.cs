using System;

namespace AqaTest.DTO.BooksShopDTO;

public record LoginUserResponseDTO

(
    string UserId,
    string Username,
    string Password,
    string Token,
    string Expires,
    string Created_Date,
    bool IsActive
);