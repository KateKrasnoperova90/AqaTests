using System;

namespace AqaTest.DTO.BooksShopDTO;

public record UserCreateBodyDTO

(
    string UserName,
    string Password
);