using System;

namespace AqaTest.DTO.BooksShopDTO;

public record TokenResponseDTO

(
    string Token,
    string Expires,
    string Status,
    string Result
);