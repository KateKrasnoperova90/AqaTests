using System;

namespace AqaTest.DTO.PetsDataDTO;

public record PetsDTO

(
    string Id,
    string Name,
    string Species,
    string Breed,
    int AgeMonths,
    string Size,
    string Status,
    string Price,
    string Currency,
    bool GoodWithKids,
    string CreatedAt,
    string UpdatedAt,
    MedicalInfoDTO MedicalInfo
);