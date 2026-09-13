using System;

namespace AqaTest.DTO.BooksShopDTO;

public record UserBookResponseDTO

(
    string UserId,
    string Username,
    List<BookDTO> Books
);