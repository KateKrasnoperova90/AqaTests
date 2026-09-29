using System;

namespace AqaTest.DTO.BooksShopDTO;

public record AddCollectionBooksOfUserDTO

(
    string UserId,
    List<CollectionsOfIsbnsDTO> Books
);