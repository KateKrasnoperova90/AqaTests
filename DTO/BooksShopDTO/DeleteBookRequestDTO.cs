using System;

namespace AqaTest.DTO.BooksShopDTO;

public record DeleteBookRequestDTO

(
    string Isbn,
    string UserId
);