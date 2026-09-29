using System;

namespace AqaTest.DTO.BooksShopDTO;

public record DeleteBookResponseDTO

(
    string Isbn,
    string UserId,
    string Message
);