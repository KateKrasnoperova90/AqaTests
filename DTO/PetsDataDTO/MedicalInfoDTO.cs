using System;

namespace AqaTest.DTO.PetsDataDTO;

public record MedicalInfoDTO

(
    bool Vaccinated,
    bool SpayedNeutered,
    bool Microchipped,
    bool SpecialNeeds,
    string HealthNotes
);