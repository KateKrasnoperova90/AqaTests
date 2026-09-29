using System;

namespace AqaTest.DTO.BooksShopDTO;

public record BookDTO

(
    string Isbn,
    string Title,
    string SubTitle,
    string Author,
    string PublishDate,
    string Publisher,
    int Pages,
    string Website
);